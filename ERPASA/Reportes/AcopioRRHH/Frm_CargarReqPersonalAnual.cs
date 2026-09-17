using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Reportes.AcopioRRHH
{
    public partial class Frm_CargarReqPersonalAnual : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_packing objcnlog = new cn_packing();
        string TipoAlimento;

        public Frm_CargarReqPersonalAnual()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarReqPersonalAnual_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void ColumnasDtgv1()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView1.Columns.Add(Dni);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Apellidos = new DataGridViewTextBoxColumn();
            Apellidos.HeaderText = "APELLIDOS Y NOMBRES";
            Apellidos.Name = "Column2";
            Apellidos.Width = 85;
            dataGridView1.Columns.Add(Apellidos);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn FechaCese = new DataGridViewTextBoxColumn();
            FechaCese.HeaderText = "FECHA INGRESO";
            FechaCese.Name = "Column3";
            FechaCese.Width = 87;
            dataGridView1.Columns.Add(FechaCese);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Area = new DataGridViewTextBoxColumn();
            Area.HeaderText = "AREA";
            Area.Name = "Column3";
            Area.Width = 87;
            dataGridView1.Columns.Add(Area);
        }


        private void ColumnasDtgv2()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView1.Columns.Add(Dni);
            //
            //
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "NOMBRES";
            Nombres.Name = "Column3";
            Nombres.Width = 85;
            dataGridView1.Columns.Add(Nombres);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "EMPRESA";
            Empresa.Name = "Column4";
            Empresa.Width = 87;
            dataGridView1.Columns.Add(Empresa);
            //
            // Column5
            // 
            DataGridViewTextBoxColumn Autorizacion = new DataGridViewTextBoxColumn();
            Autorizacion.HeaderText = "AUTORIZACION";
            Autorizacion.Name = "Column5";
            Autorizacion.Width = 87;
            dataGridView1.Columns.Add(Autorizacion);
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
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
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
                    GuardarReqPersonalSemanal();
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA CARGAR DATOS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        public void GuardarReqPersonalSemanal()
        {
            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea guardar el requerimiento semanal de personal?";

            DialogResult dialogResult = MessageBox.Show(
                MessageBoxContent,
                MessageBoxTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult != DialogResult.Yes)
                return;

            try
            {
                DataTable dt = CrearDataTableReqPersonalAnual();

                DateTime fechaSistema = ce_usuario.FechaSistema();
                int usuario = ce_usuario.usecod;
                string hostname = ce_usuario.HostName();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // No procesar la fila nueva
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataRow row = dt.NewRow();

                    // =====================================================
                    // DATOS DEL EXCEL
                    // =====================================================

                    row["Anio"] = ValorInt(dataGridView1[0, i].Value);
                    row["Semana"] = ValorInt(dataGridView1[1, i].Value);
                    row["Fecha"] = ValorDate(dataGridView1[2, i].Value);

                    row["Turno"] =
                        ValorString(dataGridView1[3, i].Value);

                    row["Supervisor"] =
                        ValorString(dataGridView1[4, i].Value);

                    row["Jefatura"] =
                        ValorString(dataGridView1[5, i].Value);

                    row["Area"] =
                        ValorString(dataGridView1[6, i].Value);

                    row["Labor_Sistema"] =
                        ValorString(dataGridView1[7, i].Value);

                    row["Cantidad"] =
                        ValorInt(dataGridView1[8, i].Value);


                    // =====================================================
                    // AUDITORÍA
                    // =====================================================

                    row["Observacion"] = "";
                    row["Hoja"] = comboBox_Hojas.Text.Trim();
                    row["Estado"] = "S";

                    row["FecCre"] = fechaSistema;
                    row["UseReg"] = usuario;
                    row["Hostname"] = hostname;

                    row["FecEdit"] = fechaSistema;
                    row["UseEdit"] = usuario;


                    dt.Rows.Add(row);
                }


                // =====================================================
                // VALIDAR REGISTROS
                // =====================================================

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No existen registros para guardar.",
                        "REGISTRO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }


                // =====================================================
                // GUARDAR BULK
                // =====================================================

                objcnlog.GuardarReqPersonalAnualBulk(dt);


                // =====================================================
                // NOTIFICACIÓN
                // =====================================================

                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro(
                        $"GUARDADO ({dt.Rows.Count:N0} REGISTROS)",
                        Color.FromArgb(12, 19, 214),
                        1
                    );

                ng.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el requerimiento anual de personal:\n\n" +
                    ex.Message +
                    "\n\nDetalle:\n" +
                    ex.ToString(),
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dataGridView1.AllowUserToAddRows = true;
            }
        }

        private DataTable CrearDataTableReqPersonalAnual()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Anio", typeof(int));
            dt.Columns.Add("Semana", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Turno", typeof(string));
            dt.Columns.Add("Supervisor", typeof(string));
            dt.Columns.Add("Jefatura", typeof(string));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Labor_Sistema", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));

            dt.Columns.Add("Observacion", typeof(string));
            dt.Columns.Add("Hoja", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("FecCre", typeof(DateTime));
            dt.Columns.Add("UseReg", typeof(int));
            dt.Columns.Add("Hostname", typeof(string));
            dt.Columns.Add("FecEdit", typeof(DateTime));
            dt.Columns.Add("UseEdit", typeof(int));

            return dt;
        }

        private string ValorString(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return "";

            return valor.ToString().Trim().ToUpper();
        }

        private object ValorDate(object valor)
        {
            if (valor == null || valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                return DBNull.Value;

            DateTime fecha;

            if (DateTime.TryParse(valor.ToString(), out fecha))
                return fecha;

            return DBNull.Value;
        }

        private object ValorDecimal(object valor)
        {
            if (valor == null || valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                return DBNull.Value;

            decimal numero;

            if (decimal.TryParse(
                valor.ToString(),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.CurrentCulture,
                out numero))
            {
                return numero;
            }

            return DBNull.Value;
        }

        private object ValorInt(object valor)
        {
            if (valor == null ||
                valor == DBNull.Value ||
                string.IsNullOrWhiteSpace(valor.ToString()))
            {
                return DBNull.Value;
            }

            int numero;

            if (int.TryParse(
                valor.ToString(),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.CurrentCulture,
                out numero))
            {
                return numero;
            }

            return DBNull.Value;
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
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

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
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
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas.Items.Add(tabla.TableName);
                }
                comboBox_Hojas.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }


        private void textBox_dni_agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

    }
}
