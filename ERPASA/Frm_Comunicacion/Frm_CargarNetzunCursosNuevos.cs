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
    /// Carga del formato de cursos nuevos de Netzun a COM_NetzunCursosNuevos.
    ///
    /// Misma mecanica que las demas cargas de comunicaciones: se elige el
    /// Excel, se muestra la hoja en la grilla y al guardar toda la tanda sube
    /// de una sola vez con SqlBulkCopy.
    /// </summary>
    public partial class Frm_CargarNetzunCursosNuevos : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_comunicacion objcncom = new cn_comunicacion();

        public Frm_CargarNetzunCursosNuevos()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de titulo, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarNetzunCursosNuevos_Load(object sender, EventArgs e)
        {
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    GuardarCursosNuevos();
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

        public void GuardarCursosNuevos()
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
                // NombresApellidos + Curso + FecAsignacion.
                //
                // El orden de las columnas es el de la hoja y tiene que
                // coincidir con el de la tabla temporal: SqlBulkCopy mapea por
                // posicion, no por nombre.
                DataTable datos = new DataTable();
                datos.Columns.Add("NombresApellidos", typeof(string));
                datos.Columns.Add("Especializacion", typeof(string));
                datos.Columns.Add("Curso", typeof(string));
                datos.Columns.Add("FecAsignacion", typeof(DateTime));
                datos.Columns.Add("HorasTotales", typeof(decimal));
                datos.Columns.Add("Combinada", typeof(string));
                datos.Columns.Add("FecCre", typeof(DateTime));
                datos.Columns.Add("UseReg", typeof(int));
                datos.Columns.Add("Hostname", typeof(string));
                datos.Columns.Add("FecEdit", typeof(DateTime));
                datos.Columns.Add("UseEdit", typeof(int));

                DateTime fechaSis = ce_usuario.FechaSistema();
                string hostname = ce_usuario.HostName();

                int filas = dataGridView1.Rows.Count;
                for (int i = 0; i <= filas - 1; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataRow fila = datos.NewRow();
                    fila["NombresApellidos"] = cu_valores.TextoMayus(dataGridView1[0, i].Value);
                    fila["Especializacion"] = cu_valores.Texto(dataGridView1[1, i].Value);
                    fila["Curso"] = cu_valores.Texto(dataGridView1[2, i].Value);
                    fila["FecAsignacion"] = cu_valores.Fecha(dataGridView1[3, i].Value);
                    fila["HorasTotales"] = cu_valores.Decimal(dataGridView1[4, i].Value);
                    fila["Combinada"] = cu_valores.Texto(dataGridView1[5, i].Value);
                    fila["FecCre"] = fechaSis;
                    fila["UseReg"] = ce_usuario.usecod;
                    fila["Hostname"] = hostname;
                    fila["FecEdit"] = fechaSis;
                    fila["UseEdit"] = ce_usuario.usecod;
                    datos.Rows.Add(fila);
                }

                objcncom.GuardarActualizarNetzunCursosNuevosMasivo(datos);

                Cursor = Cursors.Default;

                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE",
                        Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;
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
