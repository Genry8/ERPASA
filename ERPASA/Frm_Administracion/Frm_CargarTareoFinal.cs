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
    public partial class Frm_CargarTareoFinal : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_administracion objcnlog = new cn_administracion();
        string TipoAlimento;

        public Frm_CargarTareoFinal()
        {
            InitializeComponent();
        }

        private void Frm_CargarTareoFinal_Load(object sender, EventArgs e)
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
                    GuardarTareoFinal();
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

        public void GuardarTareoFinal()
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
                    var exrev = cn_administracion.BuscExisteTareoFinal(
                        dataGridView1[38, i].Value.ToString().Trim(), //Fecha
                        dataGridView1[2, i].Value.ToString().Trim() //DNI
                        );

                    if (exrev == true)
                    {
                        objcnlog.ActualizarTareoFinal(
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Codigo
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Ape_Nom
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Dni
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//Cod_Planilla
                        dataGridView1[4, i].Value.ToString().Trim(),//Fecha_Ing
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//Empresa
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//Cargo
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//

                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//Actividad
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//Labor
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//Labor_Correcta
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//Centro_Costo
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//Jornada
                        dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//Fecha_Tareo
                        dataGridView1[17, i].Value.ToString().Trim(),//time7
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//dnisup
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//nombsup
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//fecingtarea

                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//Hora_Ingreso_Tareo
                        dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//fecha salida tareo
                        dataGridView1[23, i].Value.ToString().Trim(),//Hora_Salida_Tareo
                        dataGridView1[24, i].Value.ToString().Trim(),//Horas_En_Sede
                        dataGridView1[25, i].Value.ToString().Trim(),//Refrigerio
                        dataGridView1[26, i].Value.ToString().Trim(),//Horas_Normales
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[28, i].Value.ToString().Trim(),//Hora_Ingreso_Real
                        dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[31, i].Value.ToString().Trim(),//Horas_Pagar

                        dataGridView1[32, i].Value.ToString().Trim(),//Horas_Compensadas
                        dataGridView1[33, i].Value.ToString().Trim(),//Devolución_Horas
                        dataGridView1[34, i].Value.ToString().Trim(),//Día_Tareo
                        dataGridView1[35, i].Value.ToString().Trim(),//Horas_Nocturnas
                        dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[38, i].Value.ToString().Trim(),//Fecha_Registro
                        dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[41, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Tareo

                        dataGridView1[42, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Real
                        dataGridView1[43, i].Value.ToString().Trim(),//Num_Hora_Salida_Tareo
                        dataGridView1[44, i].Value.ToString().Trim(),//Num_Hora_Salida_Real
                        dataGridView1[45, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso
                        dataGridView1[46, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso_Final
                        dataGridView1[47, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida
                        dataGridView1[48, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida_Final
                        dataGridView1[49, i].Value.ToString().Trim(),//HH_NO_Validadas_Final
                        dataGridView1[50, i].Value.ToString().Trim(),//Horas_extra
                        dataGridView1[51, i].Value.ToString().Trim(),//Num_Horas_Compensadas

                        dataGridView1[52, i].Value.ToString().Trim(),//Num_Devolución_Horas
                        dataGridView1[53, i].Value.ToString().Trim(),//Almuerzo
                        dataGridView1[54, i].Value.ToString().Trim(),//Cena
                        dataGridView1[55, i].Value.ToString().Trim(),//Alimentación_Total
                        dataGridView1[56, i].Value.ToString().Trim(),//Horas_Efectivas_Fundo
                        dataGridView1[57, i].Value.ToString().Trim(),//Sobretiempo_Ingresado
                        dataGridView1[58, i].Value.ToString().Trim(),//Sobretiempo_Final

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

                        //if (dataGridView1[14, i].Value.ToString() == "")
                        //{
                        //    dataGridView1[14, i].Value = 0;
                        //}
                        //else
                        //{
                        //    dataGridView1[14, i].Value.ToString();
                        //}
                        //if (dataGridView1[17, i].Value.ToString() == "")
                        //{
                        //    dataGridView1[17, i].Value = 0;
                        //}
                        //else
                        //{
                        //    dataGridView1[17, i].Value.ToString();
                        //}

                        objcnlog.GuardarTareoFinal(
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Codigo
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Ape_Nom
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Dni
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//Cod_Planilla
                        dataGridView1[4, i].Value.ToString().Trim(),//Fecha_Ing
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//Empresa
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//Cargo
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//

                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//Actividad
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//Labor
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//Labor_Correcta
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//Centro_Costo
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//Jornada
                        dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//Fecha_Tareo
                        dataGridView1[17, i].Value.ToString().Trim(),//time7
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//dnisup
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//nombsup
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//fecingtarea

                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//Hora_Ingreso_Tareo
                        dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//fecha salida tareo 
                        dataGridView1[23, i].Value.ToString().Trim(),//Hora_Salida_Tareo
                        dataGridView1[24, i].Value.ToString().Trim(),//Horas_En_Sede
                        dataGridView1[25, i].Value.ToString().Trim(),//Refrigerio
                        dataGridView1[26, i].Value.ToString().Trim(),//Horas_Normales
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[28, i].Value.ToString().Trim(),//Hora_Ingreso_Real
                        dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[31, i].Value.ToString().Trim(),//Horas_Pagar

                        dataGridView1[32, i].Value.ToString().Trim(),//Horas_Compensadas
                        dataGridView1[33, i].Value.ToString().Trim(),//Devolución_Horas
                        dataGridView1[34, i].Value.ToString().Trim(),//Día_Tareo
                        dataGridView1[35, i].Value.ToString().Trim(),//Horas_Nocturnas
                        dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[38, i].Value.ToString().Trim(),//Fecha_Registro
                        dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//
                        dataGridView1[41, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Tareo

                        dataGridView1[42, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Real
                        dataGridView1[43, i].Value.ToString().Trim(),//Num_Hora_Salida_Tareo
                        dataGridView1[44, i].Value.ToString().Trim(),//Num_Hora_Salida_Real
                        dataGridView1[45, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso
                        dataGridView1[46, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso_Final
                        dataGridView1[47, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida
                        dataGridView1[48, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida_Final
                        dataGridView1[49, i].Value.ToString().Trim(),//HH_NO_Validadas_Final
                        dataGridView1[50, i].Value.ToString().Trim(),//Horas_extra
                        dataGridView1[51, i].Value.ToString().Trim(),//Num_Horas_Compensadas

                        dataGridView1[52, i].Value.ToString().Trim(),//Num_Devolución_Horas
                        dataGridView1[53, i].Value.ToString().Trim(),//Almuerzo
                        dataGridView1[54, i].Value.ToString().Trim(),//Cena
                        dataGridView1[55, i].Value.ToString().Trim(),//Alimentación_Total
                        dataGridView1[56, i].Value.ToString().Trim(),//Horas_Efectivas_Fundo
                        dataGridView1[57, i].Value.ToString().Trim(),//Sobretiempo_Ingresado
                        dataGridView1[58, i].Value.ToString().Trim(),//Sobretiempo_Final

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

    }
}
