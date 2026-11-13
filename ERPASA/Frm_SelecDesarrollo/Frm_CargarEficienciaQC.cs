using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_SelecDesarrollo
{
    /// <summary>
    /// Carga de la eficiencia de los procesos de seleccion (QC) a SD_EficienciaQC.
    ///
    /// Misma pantalla que Frm_CargarEficiencia, con dos diferencias que importan:
    ///
    /// 1) Lee el Excel por la POSICION de sus columnas, en el mismo orden que
    ///    la tabla (los encabezados del Excel no se llaman igual). Si la hoja
    ///    trae una cantidad de columnas que no cuadra, no adivina: avisa y no
    ///    guarda, porque una columna corrida deja los datos en el campo
    ///    equivocado sin que nada lo muestre.
    ///
    /// 2) Si el año y la semana ya estaban cargados, pregunta antes de
    ///    reemplazarlos. Frm_CargarEficiencia no lo hace: carga otra vez y duplica.
    /// </summary>
    public partial class Frm_CargarEficienciaQC : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_selecdesarrollo objcn = new cn_selecdesarrollo();

        // Columnas del Excel, en el orden en que vienen: es el mismo de la
        // tabla, sin lo que completa la carga (año, semana, hoja) ni la
        // auditoria. Las que llevan un numero de grupo son opcionales: algunas
        // hojas no las traen y el ancho de la hoja dice cuales faltan.
        private static readonly CampoExcel[] Campos =
        {
            new CampoExcel("IdReq", TipoCampo.Entero, 0),
            new CampoExcel("Posicion", TipoCampo.Texto, 180),
            new CampoExcel("Sede", TipoCampo.Texto, 80),
            new CampoExcel("Planta", TipoCampo.Texto, 180),
            new CampoExcel("EstadoProceso", TipoCampo.Texto, 80),
            new CampoExcel("SemProy", TipoCampo.Entero, 0),
            new CampoExcel("FechaProy", TipoCampo.Fecha, 0),
            new CampoExcel("SemAjuste", TipoCampo.Entero, 0),
            new CampoExcel("FechaReq", TipoCampo.Fecha, 0),
            new CampoExcel("TiempoProceso", TipoCampo.Entero, 0),
            new CampoExcel("TipoPersonal", TipoCampo.Texto, 80),
            new CampoExcel("FechaTerna", TipoCampo.Fecha, 0),
            new CampoExcel("FechaRpta", TipoCampo.Fecha, 0),
            new CampoExcel("Dias", TipoCampo.Entero, 0),
            new CampoExcel("FechaEntrevista", TipoCampo.Fecha, 0),
            CampoExcel.Omitida(1),   // SemCierreProc: la hoja la trae, la tabla no la guarda
            new CampoExcel("FechaCierreProc", TipoCampo.Fecha, 0),
            CampoExcel.Omitida(1),   // SemIng: la hoja la trae, la tabla no la guarda
            new CampoExcel("FechaIng", TipoCampo.Fecha, 0),
            new CampoExcel("DiasDuracion", TipoCampo.Entero, 0),
            new CampoExcel("Vencimiento", TipoCampo.Entero, 0),
            new CampoExcel("Inspector", TipoCampo.Texto, 180),
            new CampoExcel("Incidencia", TipoCampo.Texto, 480),
            new CampoExcel("Obs", TipoCampo.Texto, 480, 2),
        };

        public Frm_CargarEficienciaQC()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            comboBox_Hojas.SelectedIndexChanged += comboBox_Hojas_SelectedIndexChanged;
        }

        private void Frm_CargarEficienciaQC_Load(object sender, EventArgs e)
        {
            comboBox_Semana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Año.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            // El año arranca en el actual: el primero de la lista es 2021 y
            // dejarlo asi invita a guardar en el año equivocado.
            int anio = comboBox_Año.Items.IndexOf(DateTime.Today.Year.ToString());
            comboBox_Año.SelectedIndex = anio >= 0 ? anio : 0;
            comboBox_Semana.SelectedIndex = 0;

            // La tabla no guarda empresa; el combo del modelo no haria nada.
            comboBox_empresa.Visible = false;
            label10.Visible = false;
        }

        /// <summary>
        /// La semana sale del nombre de la hoja ("Sem. 40" = 40). Se deja en
        /// el combo, a la vista, por si hay que corregirla a mano.
        /// </summary>
        private void comboBox_Hojas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? semana = MapeoExcel.SemanaDeHoja(comboBox_Hojas.Text);
            if (!semana.HasValue) return;

            int indice = comboBox_Semana.Items.IndexOf(semana.Value.ToString());
            if (indice >= 0) comboBox_Semana.SelectedIndex = indice;
        }

        private void Aviso(string mensaje)
        {
            Msbox.Frm_NotificacionesPeligro ng =
                new Msbox.Frm_NotificacionesPeligro(mensaje, Color.FromArgb(238, 24, 24), 3);
            ng.ShowDialog();
        }

        // ------------------------------------------------------ mostrar datos

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {
            if (textRuta.Text == "")
            {
                Aviso("ELIJA UN EXCEL");
                return;
            }

            if (comboBox_Hojas.SelectedIndex < 0) return;

            DataTable hoja = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = hoja;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ClearSelection();

            label_cantreg.Text = dataGridView1.RowCount + " REGISTROS";

            if (dataGridView1.RowCount == 0)
            {
                Msbox.Frm_NotificacionesGuardar ng =
                    new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                ng.Show();
            }
        }

        // ------------------------------------------------------------ guardar

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.Rows.Count < 1)
            {
                Aviso("FALTA CARGAR DATOS");
                return;
            }

            string anio = comboBox_Año.Text;
            int semana = Convert.ToInt32(comboBox_Semana.Text);
            string hoja = comboBox_Hojas.Text;

            DataTable datos;
            ResultadoMapeo mapeo;
            string problema = ArmarDatos(anio, semana, hoja, out datos, out mapeo);

            if (problema != null)
            {
                MessageBox.Show(problema, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (datos.Rows.Count == 0)
            {
                Aviso("NO HAY FILAS PARA GUARDAR");
                return;
            }

            int existentes;
            try
            {
                existentes = cn_selecdesarrollo.ContarEficienciaQC(anio, semana);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar lo que ya hay cargado:\n\n" +
                    ex.GetBaseException().Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensaje = "¿Desea guardar " + datos.Rows.Count + " registros?\n\n" +
                "Año: " + anio + "     Semana: " + semana + "     Hoja: " + hoja;

            if (existentes > 0)
            {
                mensaje += "\n\nATENCION: el año " + anio + " semana " + semana + " ya tiene " +
                    existentes + " registros cargados. Se REEMPLAZARAN por los de este archivo.";
            }

            if (mapeo.NoEncontradas.Count > 0)
            {
                mensaje += "\n\nColumnas que no vienen en la hoja (quedaran vacias):\n" +
                    string.Join(", ", mapeo.NoEncontradas);
            }

            if (mapeo.Sobrantes > 0)
            {
                mensaje += "\n\nLa hoja trae " + mapeo.Sobrantes +
                    " columna(s) de mas al final: se ignoran.";
            }

            DialogResult respuesta = MessageBox.Show(mensaje,
                existentes > 0 ? "REEMPLAZAR" : "REGISTRO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                existentes > 0 ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1);

            if (respuesta != DialogResult.Yes) return;

            GuardarDatosSync(datos);
        }

        /// <summary>
        /// Convierte la grilla en la tabla que se sube. Devuelve null si todo
        /// esta bien, o el motivo por el que no se debe guardar.
        /// </summary>
        private string ArmarDatos(string anio, int semana, string hoja,
            out DataTable datos, out ResultadoMapeo mapeo)
        {
            datos = null;
            mapeo = MapeoExcel.BuscarPorPosicion(dataGridView1, Campos);

            // Una cantidad de columnas que no cuadra es otro formato de hoja:
            // se frena aca en vez de guardar datos corridos.
            if (mapeo.Problema != null) return mapeo.Problema;

            datos = new DataTable();
            datos.Columns.Add("IdReq", typeof(int));
            datos.Columns.Add("Semana", typeof(int));
            datos.Columns.Add("Año", typeof(string));
            datos.Columns.Add("Posicion", typeof(string));
            datos.Columns.Add("Sede", typeof(string));
            datos.Columns.Add("Planta", typeof(string));
            datos.Columns.Add("EstadoProceso", typeof(string));
            datos.Columns.Add("SemProy", typeof(int));
            datos.Columns.Add("FechaProy", typeof(DateTime));
            datos.Columns.Add("SemAjuste", typeof(int));
            datos.Columns.Add("FechaReq", typeof(DateTime));
            datos.Columns.Add("TiempoProceso", typeof(int));
            datos.Columns.Add("TipoPersonal", typeof(string));
            datos.Columns.Add("FechaTerna", typeof(DateTime));
            datos.Columns.Add("FechaRpta", typeof(DateTime));
            datos.Columns.Add("Dias", typeof(int));
            datos.Columns.Add("FechaEntrevista", typeof(DateTime));
            datos.Columns.Add("FechaCierreProc", typeof(DateTime));
            datos.Columns.Add("FechaIng", typeof(DateTime));
            datos.Columns.Add("DiasDuracion", typeof(int));
            datos.Columns.Add("Vencimiento", typeof(int));
            datos.Columns.Add("Inspector", typeof(string));
            datos.Columns.Add("Incidencia", typeof(string));
            datos.Columns.Add("Obs", typeof(string));
            datos.Columns.Add("Hoja", typeof(string));
            datos.Columns.Add("Estado", typeof(string));
            datos.Columns.Add("FecCre", typeof(DateTime));
            datos.Columns.Add("UseReg", typeof(int));
            datos.Columns.Add("Hostname", typeof(string));
            datos.Columns.Add("FecEdit", typeof(DateTime));
            datos.Columns.Add("UseEdit", typeof(int));

            DateTime ahora = ce_usuario.FechaSistema();
            string equipo = ce_usuario.HostName();

            // Por cada columna de fecha o numero: cuantos datos trae y cuantos
            // no se pudieron leer como tal.
            var conDato = new Dictionary<string, int>();
            var ilegibles = new Dictionary<string, int>();

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow || MapeoExcel.FilaVacia(fila)) continue;

                DataRow nueva = datos.NewRow();

                foreach (CampoExcel campo in Campos)
                {
                    if (campo.NoSeGuarda) continue;

                    object valor = DBNull.Value;
                    int indice;

                    if (mapeo.Indices.TryGetValue(campo.Columna, out indice))
                    {
                        object crudo = fila.Cells[indice].Value;
                        valor = MapeoExcel.Convertir(crudo, campo.Tipo);

                        bool hayDato = crudo != null && crudo != DBNull.Value && crudo.ToString().Trim() != "";
                        if (hayDato && campo.Tipo != TipoCampo.Texto)
                        {
                            int n;
                            conDato.TryGetValue(campo.Columna, out n);
                            conDato[campo.Columna] = n + 1;

                            if (valor == DBNull.Value)
                            {
                                ilegibles.TryGetValue(campo.Columna, out n);
                                ilegibles[campo.Columna] = n + 1;
                            }
                        }
                    }

                    // Un texto mas largo que la columna haria fallar la carga
                    // con un error que no dice cual fue; aca se avisa cual.
                    string texto = valor as string;
                    if (texto != null && campo.Largo > 0 && texto.Length > campo.Largo)
                    {
                        datos = null;
                        return "La fila " + (fila.Index + 2) + " del Excel trae en " + campo.Columna + " " +
                            texto.Length + " caracteres y la tabla admite " + campo.Largo + ".";
                    }

                    nueva[campo.Columna] = valor;
                }

                nueva["Semana"] = semana;
                nueva["Año"] = anio;
                nueva["Hoja"] = hoja;
                nueva["Estado"] = "S";
                nueva["FecCre"] = ahora;
                nueva["UseReg"] = ce_usuario.usecod;
                nueva["Hostname"] = equipo;
                nueva["FecEdit"] = ahora;
                nueva["UseEdit"] = 0;

                datos.Rows.Add(nueva);
            }

            // Si casi todo lo que trae una columna de fecha o de numero no se
            // lee como tal, lo mas probable es que las columnas de la hoja
            // esten en otro orden: se frena antes de guardar datos corridos.
            foreach (CampoExcel campo in Campos)
            {
                if (campo.NoSeGuarda || !conDato.ContainsKey(campo.Columna)) continue;

                int total = conDato[campo.Columna];
                int malos;
                ilegibles.TryGetValue(campo.Columna, out malos);

                if (malos * 2 > total)
                {
                    datos = null;
                    return "La columna " + (mapeo.Indices[campo.Columna] + 1) + " de la hoja (\"" +
                        dataGridView1.Columns[mapeo.Indices[campo.Columna]].HeaderText + "\") deberia ser " +
                        (campo.Tipo == TipoCampo.Fecha ? "una fecha" : "un numero") + " (" + campo.Columna +
                        ") pero " + malos + " de sus " + total + " valores no se pueden leer asi.\n\n" +
                        "Puede que las columnas de esta hoja esten en otro orden.";
                }
            }

            return null;
        }

        private async void GuardarDatosSync(DataTable datos)
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            frbm.Show(this);

            bool correcto = false;

            try
            {
                // La tabla ya esta armada, asi que en el hilo de fondo no se
                // toca ningun control.
                await Task.Run(() => objcn.GuardarEficienciaQC(datos));
                correcto = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos:\n\n" + ex.GetBaseException().Message,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close();
            }

            if (correcto)
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }
        }

        // ------------------------------------------------------ limpiar / abrir

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Items.Clear();
            comboBox_Hojas.Text = "";
            label_cantreg.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dtsTablas = new DataSet();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() != DialogResult.OK) return;

            dataGridView1.DataSource = null;
            textRuta.Text = oOpenFileDialog.FileName;

            try
            {
                // Con "using" el Excel no queda bloqueado despues de leerlo.
                using (FileStream fsSource = new FileStream(oOpenFileDialog.FileName,
                    FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource))
                {
                    dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo leer el Excel:\n\n" + ex.GetBaseException().Message,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textRuta.Text = "";
                return;
            }

            comboBox_Hojas.Items.Clear();
            foreach (DataTable tabla in dtsTablas.Tables)
                comboBox_Hojas.Items.Add(tabla.TableName);

            if (comboBox_Hojas.Items.Count > 0)
                comboBox_Hojas.SelectedIndex = 0;
        }
    }
}
