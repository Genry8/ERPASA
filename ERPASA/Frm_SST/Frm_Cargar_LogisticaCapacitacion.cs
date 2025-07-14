using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_SST
{
    public partial class Frm_Cargar_LogisticaCapacitacion : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_sst objcnlog = new cn_sst();


        public Frm_Cargar_LogisticaCapacitacion()
        {
            InitializeComponent();
        }

        private void Frm_Cargar_LogisticaCapacitacion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            Cargar_Empresa();
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede.DropDownStyle = ComboBoxStyle.DropDownList;

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
                    else if (comboBox_CodSede.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarCursoDeCapacitacion();
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

        public void GuardarCursoDeCapacitacion()
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
                    objcnlog.GuardarCursoCapacitacionLogistica(
                        dataGridView1[0, i].Value.ToString().Trim(),//codigo
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//apenom
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//dni
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//ruc
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//razon social
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//cargo
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//fecha induccion

                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//des trabajo
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//hombre nuevo
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//trab altura
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//trab caliente
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//excav zanja
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//lugar cap
                        comboBox_empresa.Text.Trim(),
                        comboBox_CodSede.Text.Trim(),

                        comboBox_Hojas.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
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

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_CodSede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_CodSede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_CodSede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }
    }
}
