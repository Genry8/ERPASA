using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_SelecDesarrollo
{
    public partial class Frm_Registrar_Trabajador : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_selecdesarrollo objcnlog = new cn_selecdesarrollo();
        string TipoAlimento;

        public Frm_Registrar_Trabajador()
        {
            InitializeComponent();
        }

        private void Frm_Registrar_EvInventario_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_TipoProgramacion.SelectedIndex = 0;
            comboBox_empresa.SelectedIndex = 0;
            //comboBox_Sede.SelectedIndex = 0;
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_TipoProgramacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_Sede.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_empresa.Text);
                comboBox_Sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
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
                    GuardarTrabActivo();
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

        public void GuardarTrabActivo()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registro?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    cn_selecdesarrollo.BuscExisteTrabajadorActivo(dataGridView1[1, i].Value.ToString().Trim(), Convert.ToDateTime(dataGridView1[12, i].Value).Date);
                    if (dataGridView1[1, i].Value.ToString().Trim() == ce_selecdesarrollo.codigo & Convert.ToDateTime(dataGridView1[12, i].Value).Date == ce_selecdesarrollo.FechaInicio.Date)
                    {
                        objcnlog.ActualizarTrabActivo(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//[]
                        Convert.ToDateTime(dataGridView1[12, i].Value),// 
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[17, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[23, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[24, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[25, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[26, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[28, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[31, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[32, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[33, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[34, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[35, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[38, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[41, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[42, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[43, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[44, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[45, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[46, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[47, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[48, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[49, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[50, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[51, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[52, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[53, i].Value.ToString().ToUpper().Trim(),//
                        Convert.ToDecimal(dataGridView1[54, i].Value),//
                        dataGridView1[55, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[56, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[57, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[58, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[59, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[60, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[61, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[62, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[63, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[64, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[65, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[66, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[67, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[68, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[69, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[70, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[71, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[72, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[73, i].Value.ToString().ToUpper().Trim(),//[[]]

                        comboBox_Hojas.Text,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        //ce_usuario.HostName(),
                        //ce_usuario.FechaSistema(),
                        //0,
                        //0
                        );

                    }

                    else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objcnlog.GuardarTrabActivo(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//[]
                        Convert.ToDateTime(dataGridView1[12, i].Value),// 
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[17, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[23, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[24, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[25, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[26, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[28, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[31, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[32, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[33, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[34, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[35, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[38, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[41, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[42, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[43, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[44, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[45, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[46, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[47, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[48, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[49, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[50, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[51, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[52, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[53, i].Value.ToString().ToUpper().Trim(),//
                        Convert.ToDecimal(dataGridView1[54, i].Value),//
                        dataGridView1[55, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[56, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[57, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[58, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[59, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[60, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[61, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[62, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[63, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[64, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[65, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[66, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[67, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[68, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[69, i].Value.ToString().ToUpper().Trim(),//[[]]
                        dataGridView1[70, i].Value.ToString().ToUpper().Trim(),//[]

                        dataGridView1[71, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[72, i].Value.ToString().ToUpper().Trim(),//[]
                        dataGridView1[73, i].Value.ToString().ToUpper().Trim(),//[[]]

                        comboBox_Hojas.Text,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0
                        );

                    }
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;

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
