using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Comunicacion
{
    /// <summary>
    /// Carga del reporte de estudiantes de Netzun a
    /// COM_NetzunReporteEstudiantes.
    ///
    /// Misma mecanica que Frm_CargarPuntosPlanilla: se elige el Excel, se
    /// muestra la hoja en la grilla y al guardar toda la tanda sube de una
    /// sola vez con SqlBulkCopy.
    /// </summary>
    public partial class Frm_CargarNetzunRepGeneral : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_comunicacion objcncom = new cn_comunicacion();

        public Frm_CargarNetzunRepGeneral()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de titulo, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarNetzunRepGeneral_Load(object sender, EventArgs e)
        {
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker_FecReporte.Value = DateTime.Today;
        }

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {
            if (textRuta.Text != "")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
                dataGridView1.ClearSelection();

                if (dataGridView1.Rows.Count > 1)
                {
                    label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    GuardarNetzunEstudiantes();
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA CARGAR DATOS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        public void GuardarNetzunEstudiantes()
        {
            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;

                // Toda la tanda va de una sola vez con SqlBulkCopy; el SP
                // resuelve alta y actualizacion en un MERGE por
                // IdNetzun + Curso + FecReporte.
                //
                // El orden de las columnas es el de la hoja REP_GENERAL y
                // tiene que coincidir con el de la tabla temporal: SqlBulkCopy
                // mapea por posicion, no por nombre.
                DataTable datos = new DataTable();
                datos.Columns.Add("IdNetzun", typeof(int));
                datos.Columns.Add("NombresApellidos", typeof(string));
                datos.Columns.Add("Email", typeof(string));
                datos.Columns.Add("Funcion", typeof(string));
                datos.Columns.Add("EstadoUsuario", typeof(string));
                datos.Columns.Add("InicioSesion", typeof(string));
                datos.Columns.Add("Rol", typeof(string));
                datos.Columns.Add("Curso", typeof(string));
                datos.Columns.Add("FecPrimeraMatricula", typeof(DateTime));
                datos.Columns.Add("EstadoCurso", typeof(string));
                datos.Columns.Add("IntentosDesaprobados", typeof(int));
                datos.Columns.Add("Capsulas", typeof(string));
                datos.Columns.Add("PorcentajeProgreso", typeof(decimal));
                datos.Columns.Add("DuracionCurso", typeof(TimeSpan));
                datos.Columns.Add("AvanceHoras", typeof(TimeSpan));
                datos.Columns.Add("NotaExamen", typeof(string));
                datos.Columns.Add("FecAprobacionExamen", typeof(DateTime));
                datos.Columns.Add("FecUltimaLeccion", typeof(DateTime));
                datos.Columns.Add("HoraUltimaLeccion", typeof(TimeSpan));
                datos.Columns.Add("FecDeadline", typeof(DateTime));
                datos.Columns.Add("Nivel1", typeof(string));
                datos.Columns.Add("CodigoInterno", typeof(string));
                datos.Columns.Add("CursoAsignadoLibre", typeof(string));
                datos.Columns.Add("Cargo", typeof(string));
                datos.Columns.Add("NumeroDocumento", typeof(string));
                datos.Columns.Add("CursoNetzunPropio", typeof(string));
                datos.Columns.Add("FecCertificacion", typeof(DateTime));
                datos.Columns.Add("FecInscripcionCurso", typeof(DateTime));
                datos.Columns.Add("RutaAprendizaje", typeof(string));
                datos.Columns.Add("FecInscripcionUsuario", typeof(DateTime));
                datos.Columns.Add("FecDesactivacionUsuario", typeof(DateTime));
                datos.Columns.Add("Especializaciones", typeof(string));
                datos.Columns.Add("FecFinEspecializacion", typeof(string));
                datos.Columns.Add("FecFinRuta", typeof(DateTime));
                datos.Columns.Add("HoraFinRuta", typeof(TimeSpan));
                datos.Columns.Add("FecUltimaMatricula", typeof(DateTime));
                datos.Columns.Add("Empresa", typeof(string));
                datos.Columns.Add("Gerencia", typeof(string));
                datos.Columns.Add("TipoTrabajador", typeof(string));
                datos.Columns.Add("Dni", typeof(string));
                datos.Columns.Add("FecReporte", typeof(DateTime));
                datos.Columns.Add("FecCre", typeof(DateTime));
                datos.Columns.Add("UseReg", typeof(int));
                datos.Columns.Add("Hostname", typeof(string));
                datos.Columns.Add("FecEdit", typeof(DateTime));
                datos.Columns.Add("UseEdit", typeof(int));

                DateTime fechaSis = ce_usuario.FechaSistema();
                string hostname = ce_usuario.HostName();

                // La fecha de reporte la elige el usuario arriba y es la misma
                // para toda la carga: es parte de la clave del MERGE, asi que
                // no se toma de la columna del Excel.
                DateTime fecReporte = dateTimePicker_FecReporte.Value.Date;

                int filas = dataGridView1.Rows.Count;
                for (int i = 0; i <= filas - 1; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataRow fila = datos.NewRow();
                    fila["IdNetzun"] = cu_valores.Entero(dataGridView1[0, i].Value);
                    fila["NombresApellidos"] = cu_valores.TextoMayus(dataGridView1[1, i].Value);
                    fila["Email"] = cu_valores.Texto(dataGridView1[2, i].Value);
                    fila["Funcion"] = cu_valores.Texto(dataGridView1[3, i].Value);
                    fila["EstadoUsuario"] = cu_valores.Texto(dataGridView1[4, i].Value);
                    fila["InicioSesion"] = cu_valores.Texto(dataGridView1[5, i].Value);
                    fila["Rol"] = cu_valores.Texto(dataGridView1[6, i].Value);
                    fila["Curso"] = cu_valores.Texto(dataGridView1[7, i].Value);
                    fila["FecPrimeraMatricula"] = cu_valores.Fecha(dataGridView1[8, i].Value);
                    fila["EstadoCurso"] = cu_valores.Texto(dataGridView1[9, i].Value);
                    fila["IntentosDesaprobados"] = cu_valores.Entero(dataGridView1[10, i].Value);
                    fila["Capsulas"] = cu_valores.Texto(dataGridView1[11, i].Value);
                    fila["PorcentajeProgreso"] = cu_valores.Decimal(dataGridView1[12, i].Value);
                    fila["DuracionCurso"] = HoraONulo(dataGridView1[13, i].Value);
                    fila["AvanceHoras"] = HoraONulo(dataGridView1[14, i].Value);
                    fila["NotaExamen"] = cu_valores.Texto(dataGridView1[15, i].Value);
                    fila["FecAprobacionExamen"] = cu_valores.Fecha(dataGridView1[16, i].Value);
                    fila["FecUltimaLeccion"] = cu_valores.Fecha(dataGridView1[17, i].Value);
                    fila["HoraUltimaLeccion"] = HoraONulo(dataGridView1[18, i].Value);
                    fila["FecDeadline"] = cu_valores.Fecha(dataGridView1[19, i].Value);
                    fila["Nivel1"] = cu_valores.Texto(dataGridView1[20, i].Value);
                    fila["CodigoInterno"] = cu_valores.Texto(dataGridView1[21, i].Value);
                    fila["CursoAsignadoLibre"] = cu_valores.Texto(dataGridView1[22, i].Value);
                    fila["Cargo"] = cu_valores.TextoMayus(dataGridView1[23, i].Value);
                    fila["NumeroDocumento"] = cu_valores.Texto(dataGridView1[24, i].Value);
                    fila["CursoNetzunPropio"] = cu_valores.Texto(dataGridView1[25, i].Value);
                    fila["FecCertificacion"] = cu_valores.Fecha(dataGridView1[26, i].Value);
                    fila["FecInscripcionCurso"] = cu_valores.Fecha(dataGridView1[27, i].Value);
                    fila["RutaAprendizaje"] = cu_valores.Texto(dataGridView1[28, i].Value);
                    fila["FecInscripcionUsuario"] = cu_valores.Fecha(dataGridView1[29, i].Value);
                    fila["FecDesactivacionUsuario"] = cu_valores.Fecha(dataGridView1[30, i].Value);
                    fila["Especializaciones"] = cu_valores.Texto(dataGridView1[31, i].Value);
                    fila["FecFinEspecializacion"] = cu_valores.Texto(dataGridView1[32, i].Value);
                    fila["FecFinRuta"] = cu_valores.Fecha(dataGridView1[33, i].Value);
                    fila["HoraFinRuta"] = HoraONulo(dataGridView1[34, i].Value);
                    fila["FecUltimaMatricula"] = FechaHora(dataGridView1[35, i].Value);
                    fila["Empresa"] = cu_valores.TextoMayus(dataGridView1[36, i].Value);
                    fila["Gerencia"] = cu_valores.TextoMayus(dataGridView1[37, i].Value);
                    fila["TipoTrabajador"] = cu_valores.TextoMayus(dataGridView1[38, i].Value);
                    fila["Dni"] = cu_valores.Texto(dataGridView1[39, i].Value);
                    fila["FecReporte"] = fecReporte;
                    fila["FecCre"] = fechaSis;
                    fila["UseReg"] = ce_usuario.usecod;
                    fila["Hostname"] = hostname;
                    fila["FecEdit"] = fechaSis;
                    fila["UseEdit"] = ce_usuario.usecod;
                    datos.Rows.Add(fila);
                }

                objcncom.GuardarActualizarNetzunEstudiantesMasivo(datos);

                Cursor = Cursors.Default;

                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE",
                        Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;
        }


        /// <summary>
        /// Igual que cu_valores.Hora, pero una celda vacia queda nula en vez
        /// de quedar en 00:00:00, que en el reporte significa otra cosa.
        /// </summary>
        private static object HoraONulo(object valor)
        {
            if (valor == null || valor == DBNull.Value) return DBNull.Value;
            if (valor.ToString().Trim() == "") return DBNull.Value;
            return cu_valores.Hora(valor);
        }

        /// <summary>
        /// Fecha con su hora, para FecUltimaMatricula, que es datetime2.
        /// cu_valores.Fecha sirve para las columnas date porque recorta la
        /// hora, y aca justamente hay que conservarla.
        /// </summary>
        private static object FechaHora(object valor)
        {
            if (valor == null || valor == DBNull.Value) return DBNull.Value;
            if (valor is DateTime) return (DateTime)valor;

            string texto = valor.ToString().Trim();
            if (texto == "") return DBNull.Value;

            DateTime f;
            if (DateTime.TryParse(texto, System.Globalization.CultureInfo.CurrentCulture,
                    System.Globalization.DateTimeStyles.None, out f)) return f;
            if (DateTime.TryParse(texto, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out f)) return f;
            return DBNull.Value;
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            label_cantreg.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;

                textRuta.Text = oOpenFileDialog.FileName;

                FileStream fsSource = new FileStream(oOpenFileDialog.FileName,
                    FileMode.Open, FileAccess.Read);

                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                //convierte todas las hojas a un DataSet
                dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                comboBox_Hojas.Items.Clear();
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas.Items.Add(tabla.TableName);
                }

                comboBox_Hojas.SelectedIndex = 0;

                reader.Close();
            }
        }
    }
}
