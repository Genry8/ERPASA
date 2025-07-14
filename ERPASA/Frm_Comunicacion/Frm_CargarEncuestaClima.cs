using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Comunicacion
{
    public partial class Frm_CargarEncuestaClima : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_comunicacion objcnlog = new cn_comunicacion();


        public Frm_CargarEncuestaClima()
        {
            InitializeComponent();
        }

        private void Frm_CargarEncuestaClima_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            comboBox_TipoPersonal.SelectedIndex = 0;

            Cargar_Empresa();
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoPersonal.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void Cargar_Empresa()
        {

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
                    GuardarEncuestaClima();

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

        public void GuardarEncuestaClima()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                cn_comunicacion.EliminarExisteEncuestaClima(
                        comboBox_TipoPersonal.Text,
                        dateTimePicker_FecEncuesta.Value.Date //item
                        );

                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    objcnlog.GuardarEncuestaClima(
                        "",//Empresa
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//Sede
                        Convert.ToDateTime(dataGridView1[0, i].Value),//item
                        dateTimePicker_FecEncuesta.Value.Date,//fecha
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//sexo
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//rango edad
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//gerencia
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//puesto
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//tiempo en compañia

                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//item_1
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//item_2
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//item_3
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//item_4
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//item_5
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//item_6
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//item_7
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//item_8
                        dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//item_9
                        dataGridView1[17, i].Value.ToString().ToUpper().Trim(),//item_10
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//item_11
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//item_12
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//item_13
                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//item_14
                        dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//item_15
                        dataGridView1[23, i].Value.ToString().ToUpper().Trim(),//item_16
                        dataGridView1[24, i].Value.ToString().ToUpper().Trim(),//item_17
                        dataGridView1[25, i].Value.ToString().ToUpper().Trim(),//item_18
                        dataGridView1[26, i].Value.ToString().ToUpper().Trim(),//item_19
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//item_20

                        dataGridView1[28, i].Value.ToString().ToUpper().Trim(),//item_21
                        dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//item_22
                        dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//item_23
                        dataGridView1[31, i].Value.ToString().ToUpper().Trim(),//item_24
                        dataGridView1[32, i].Value.ToString().ToUpper().Trim(),//item_25
                        dataGridView1[33, i].Value.ToString().ToUpper().Trim(),//item_26
                        dataGridView1[34, i].Value.ToString().ToUpper().Trim(),//item_27
                        dataGridView1[35, i].Value.ToString().ToUpper().Trim(),//item_28
                        dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//item_29
                        dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//item_30
                        dataGridView1[38, i].Value.ToString().ToUpper().Trim(),//item_31
                        dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//item_32
                        dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//item_33
                        dataGridView1[41, i].Value.ToString().ToUpper().Trim(),//item_34
                        dataGridView1[42, i].Value.ToString().ToUpper().Trim(),//item_35
                        dataGridView1[43, i].Value.ToString().ToUpper().Trim(),//item_36
                        dataGridView1[44, i].Value.ToString().ToUpper().Trim(),//item_37
                        dataGridView1[45, i].Value.ToString().ToUpper().Trim(),//item_38
                        dataGridView1[46, i].Value.ToString().ToUpper().Trim(),//item_39
                        dataGridView1[47, i].Value.ToString().ToUpper().Trim(),//item_40

                        dataGridView1[48, i].Value.ToString().ToUpper().Trim(),//item_41
                        dataGridView1[49, i].Value.ToString().ToUpper().Trim(),//item_42
                        dataGridView1[50, i].Value.ToString().ToUpper().Trim(),//item_43
                        dataGridView1[51, i].Value.ToString().ToUpper().Trim(),//item_44
                        dataGridView1[52, i].Value.ToString().ToUpper().Trim(),//item_45
                        dataGridView1[53, i].Value.ToString().ToUpper().Trim(),//item_46
                        dataGridView1[54, i].Value.ToString().ToUpper().Trim(),//item_47
                        dataGridView1[55, i].Value.ToString().ToUpper().Trim(),//item_48
                        dataGridView1[56, i].Value.ToString().ToUpper().Trim(),//item_49
                        dataGridView1[57, i].Value.ToString().ToUpper().Trim(),//item_50
                        dataGridView1[58, i].Value.ToString().ToUpper().Trim(),//item_51
                        dataGridView1[59, i].Value.ToString().ToUpper().Trim(),//item_52
                        dataGridView1[60, i].Value.ToString().ToUpper().Trim(),//item_53
                        dataGridView1[61, i].Value.ToString().ToUpper().Trim(),//item_54
                        dataGridView1[62, i].Value.ToString().ToUpper().Trim(),//item_55
                        dataGridView1[63, i].Value.ToString().ToUpper().Trim(),//item_56
                        dataGridView1[64, i].Value.ToString().ToUpper().Trim(),//item_57
                        dataGridView1[65, i].Value.ToString().ToUpper().Trim(),//item_58
                        dataGridView1[66, i].Value.ToString().ToUpper().Trim(),//item_59
                        dataGridView1[67, i].Value.ToString().ToUpper().Trim(),//item_60

                        dataGridView1[68, i].Value.ToString().ToUpper().Trim(),//item_61
                        dataGridView1[69, i].Value.ToString().ToUpper().Trim(),//item_62
                        dataGridView1[70, i].Value.ToString().ToUpper().Trim(),//item_63
                        dataGridView1[71, i].Value.ToString().ToUpper().Trim(),//item_64
                        dataGridView1[72, i].Value.ToString().ToUpper().Trim(),//item_65
                        dataGridView1[73, i].Value.ToString().ToUpper().Trim(),//item_66
                        dataGridView1[74, i].Value.ToString().ToUpper().Trim(),//item_67
                        dataGridView1[75, i].Value.ToString().ToUpper().Trim(),//item_68
                        dataGridView1[76, i].Value.ToString().ToUpper().Trim(),//item_69
                        dataGridView1[77, i].Value.ToString().ToUpper().Trim(),//item_70
                        dataGridView1[78, i].Value.ToString().ToUpper().Trim(),//item_71
                        dataGridView1[79, i].Value.ToString().ToUpper().Trim(),//item_72
                        dataGridView1[80, i].Value.ToString().ToUpper().Trim(),//tienes sugerencia
                        dataGridView1[81, i].Value.ToString().ToUpper().Trim(),//sugerencia_recomend

                        comboBox_TipoPersonal.Text,
                        comboBox_Hojas.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0
                        );
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
