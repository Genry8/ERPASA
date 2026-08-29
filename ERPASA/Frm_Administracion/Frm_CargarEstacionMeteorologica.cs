using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Administracion
{
    public partial class Frm_CargarEstacionMeteorologica : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_administracion objcnlog = new cn_administracion();
        string TipoAlimento;

        public Frm_CargarEstacionMeteorologica()
        {
            InitializeComponent();
        }

        private void Frm_CargarEstacionMeteorologica_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargar_Empresa();
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA CHARLA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


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
                    if (comboBox_empresa.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_Sede.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarEstacionMeteorologica();
                    }
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

        public void GuardarEstacionMeteorologica()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var exrev = cn_administracion.BuscExisteEstacionMeteorologica(
                        comboBox_empresa.Text,
                        comboBox_Sede.Text,
                        Convert.ToDateTime(dataGridView1[0, i].Value).Date, //Fecha
                        Convert.ToDateTime(dataGridView1[1, i].Value) //hora
                        );

                    decimal brillo, hr;

                    if (Convert.ToDecimal(dataGridView1[22, i].Value) > 0)
                    {
                        brillo = Convert.ToDecimal(0.5);
                    }
                    else { brillo = 0; }
                    if (Convert.ToDecimal(dataGridView1[5, i].Value) >= 90)
                    {
                        hr = 1;
                    }
                    else { hr = 0; }


                    if (exrev == true)
                    {
                        objcnlog.ActualizarEstacionMeteorológica(
                        comboBox_empresa.Text,//Empresa
                        comboBox_Sede.Text,//Sede
                        Convert.ToDateTime(dataGridView1[0, i].Value).Date,//fecha
                        Convert.ToDateTime(dataGridView1[1, i].Value),//hora
                        Convert.ToDecimal(dataGridView1[2, i].Value),//Temp_Out
                        Convert.ToDecimal(dataGridView1[3, i].Value),//Hi_Temp
                        Convert.ToDecimal(dataGridView1[4, i].Value),//Low_Temp
                        Convert.ToDecimal(dataGridView1[5, i].Value),//Out_Hum
                        Convert.ToDecimal(dataGridView1[6, i].Value),//Dew_Pt
                        Convert.ToDecimal(dataGridView1[7, i].Value),//Wind_Speed

                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//Wind_Dir
                        Convert.ToDecimal(dataGridView1[9, i].Value),//Wind_Run
                        Convert.ToDecimal(dataGridView1[10, i].Value),//Hi_Speed
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//Hi_Dir
                        Convert.ToDecimal(dataGridView1[12, i].Value),//Wind_Chill
                        Convert.ToDecimal(dataGridView1[13, i].Value),//Heat_Index
                        Convert.ToDecimal(dataGridView1[14, i].Value),//THW_Index
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//THSW_Index
                        Convert.ToDecimal(dataGridView1[16, i].Value),//Bar
                        Convert.ToDecimal(dataGridView1[17, i].Value),//Rain

                        Convert.ToDecimal(dataGridView1[18, i].Value),//Rain_Rate
                        Convert.ToDecimal(dataGridView1[19, i].Value),//
                        Convert.ToDecimal(dataGridView1[20, i].Value),//
                        Convert.ToDecimal(dataGridView1[21, i].Value),//
                        Convert.ToDecimal(dataGridView1[22, i].Value),//indx
                        Convert.ToDecimal(dataGridView1[23, i].Value),//dose
                        Convert.ToDecimal(dataGridView1[24, i].Value),//uv
                        Convert.ToDecimal(dataGridView1[25, i].Value),//d-d
                        Convert.ToDecimal(dataGridView1[26, i].Value),//d-d co
                        Convert.ToDecimal(dataGridView1[27, i].Value),//In_Temp

                        Convert.ToDecimal(dataGridView1[28, i].Value),//In_Hum
                        Convert.ToDecimal(dataGridView1[29, i].Value),//
                        Convert.ToDecimal(dataGridView1[30, i].Value),//
                        Convert.ToDecimal(dataGridView1[31, i].Value),//
                        Convert.ToDecimal(dataGridView1[32, i].Value),//
                        Convert.ToDecimal(dataGridView1[33, i].Value),//
                        Convert.ToDecimal(dataGridView1[34, i].Value),//
                        Convert.ToDecimal(dataGridView1[35, i].Value),//
                        Convert.ToDecimal(dataGridView1[36, i].Value),//
                        Convert.ToDecimal(dataGridView1[37, i].Value),//Arc_Int

                        brillo,//H_H_Brillo_Solar
                        hr,//HR_90

                        comboBox_Hojas.Text,
                        "S",
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
                        objcnlog.GuardarEstacionMeteorologica(
                        comboBox_empresa.Text,//Empresa
                        comboBox_Sede.Text,//Sede
                        Convert.ToDateTime(dataGridView1[0, i].Value).Date,//fecha
                        Convert.ToDateTime(dataGridView1[1, i].Value),//hora
                        Convert.ToDecimal(dataGridView1[2, i].Value),//Temp_Out
                        Convert.ToDecimal(dataGridView1[3, i].Value),//Hi_Temp
                        Convert.ToDecimal(dataGridView1[4, i].Value),//Low_Temp
                        Convert.ToDecimal(dataGridView1[5, i].Value),//Out_Hum
                        Convert.ToDecimal(dataGridView1[6, i].Value),//Dew_Pt
                        Convert.ToDecimal(dataGridView1[7, i].Value),//Wind_Speed

                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//Wind_Dir
                        Convert.ToDecimal(dataGridView1[9, i].Value),//Wind_Run
                        Convert.ToDecimal(dataGridView1[10, i].Value),//Hi_Speed
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//Hi_Dir
                        Convert.ToDecimal(dataGridView1[12, i].Value),//Wind_Chill
                        Convert.ToDecimal(dataGridView1[13, i].Value),//Heat_Index
                        Convert.ToDecimal(dataGridView1[14, i].Value),//THW_Index
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//THSW_Index
                        Convert.ToDecimal(dataGridView1[16, i].Value),//Bar
                        Convert.ToDecimal(dataGridView1[17, i].Value),//Rain

                        Convert.ToDecimal(dataGridView1[18, i].Value),//Rain_Rate
                        Convert.ToDecimal(dataGridView1[19, i].Value),//
                        Convert.ToDecimal(dataGridView1[20, i].Value),//
                        Convert.ToDecimal(dataGridView1[21, i].Value),//
                        Convert.ToDecimal(dataGridView1[22, i].Value),//indx
                        Convert.ToDecimal(dataGridView1[23, i].Value),//dose
                        Convert.ToDecimal(dataGridView1[24, i].Value),//uv
                        Convert.ToDecimal(dataGridView1[25, i].Value),//d-d
                        Convert.ToDecimal(dataGridView1[26, i].Value),//d-d co
                        Convert.ToDecimal(dataGridView1[27, i].Value),//In_Temp

                        Convert.ToDecimal(dataGridView1[28, i].Value),//In_Hum
                        Convert.ToDecimal(dataGridView1[29, i].Value),//
                        Convert.ToDecimal(dataGridView1[30, i].Value),//
                        Convert.ToDecimal(dataGridView1[31, i].Value),//
                        Convert.ToDecimal(dataGridView1[32, i].Value),//
                        Convert.ToDecimal(dataGridView1[33, i].Value),//
                        Convert.ToDecimal(dataGridView1[34, i].Value),//
                        Convert.ToDecimal(dataGridView1[35, i].Value),//
                        Convert.ToDecimal(dataGridView1[36, i].Value),//
                        Convert.ToDecimal(dataGridView1[37, i].Value),//Arc_Int

                        brillo,//H_H_Brillo_Solar
                        hr,//HR_90

                        comboBox_Hojas.Text,
                        "S",
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

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_Sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_Sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }
    }
}
