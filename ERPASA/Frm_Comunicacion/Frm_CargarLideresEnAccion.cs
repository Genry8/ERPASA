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
    public partial class Frm_CargarLideresEnAccion : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_comunicacion objcnlog = new cn_comunicacion();


        public Frm_CargarLideresEnAccion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarLideresEnAccion_Load(object sender, EventArgs e)
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
                    //if (comboBox_empresa.Text == "SELECCIONE")
                    //{
                    //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    //    ng.ShowDialog();
                    //}
                    //else if (comboBox_Sede.Text == "SELECCIONE")
                    //{
                    //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                    //    ng.ShowDialog();
                    //}
                    //else
                    //{

                    //}
                    GuardarLideresEnAccion();
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

        public void GuardarLideresEnAccion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;

                // Toda la tanda va de una sola vez con SqlBulkCopy; el SP
                // resuelve alta y actualizacion en un MERGE por
                // Empresa + Sede + Fecha + Item, asi que ya no hace falta
                // preguntar por cada fila si existe.
                DataTable datos = new DataTable();
                datos.Columns.Add("Item", typeof(int));
                datos.Columns.Add("Fecha", typeof(DateTime));
                foreach (string c in new string[] { "Ape_Nom", "Dni", "Empresa", "Sede",
                    "Area", "Labor", "Jefe" })
                    datos.Columns.Add(c, typeof(string));
                datos.Columns.Add("Puntaje", typeof(decimal));
                datos.Columns.Add("Categoria", typeof(string));
                datos.Columns.Add("Estrellas", typeof(int));
                datos.Columns.Add("Premio", typeof(string));
                datos.Columns.Add("Hoja", typeof(string));
                datos.Columns.Add("Estado", typeof(string));
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
                    fila["Item"] = cu_valores.Entero(dataGridView1[0, i].Value);
                    fila["Fecha"] = cu_valores.Fecha(dataGridView1[1, i].Value);
                    fila["Ape_Nom"] = cu_valores.TextoMayus(dataGridView1[2, i].Value);
                    fila["Dni"] = cu_valores.TextoMayus(dataGridView1[3, i].Value);
                    fila["Empresa"] = cu_valores.TextoMayus(dataGridView1[4, i].Value);
                    fila["Sede"] = cu_valores.Texto(dataGridView1[5, i].Value);
                    fila["Area"] = cu_valores.TextoMayus(dataGridView1[6, i].Value);
                    fila["Labor"] = cu_valores.TextoMayus(dataGridView1[7, i].Value);
                    fila["Jefe"] = cu_valores.TextoMayus(dataGridView1[8, i].Value);
                    fila["Puntaje"] = cu_valores.Decimal(dataGridView1[9, i].Value);
                    fila["Categoria"] = cu_valores.TextoMayus(dataGridView1[10, i].Value);
                    fila["Estrellas"] = cu_valores.Entero(dataGridView1[11, i].Value);
                    fila["Premio"] = cu_valores.TextoMayus(dataGridView1[12, i].Value);
                    fila["Hoja"] = comboBox_Hojas.Text;
                    fila["Estado"] = "S";
                    fila["FecCre"] = fechaSis;
                    fila["UseReg"] = ce_usuario.usecod;
                    fila["Hostname"] = hostname;
                    fila["FecEdit"] = fechaSis;
                    fila["UseEdit"] = ce_usuario.usecod;
                    datos.Rows.Add(fila);
                }

                objcnlog.GuardarActualizarLideresEnAccionMasivo(datos);

                Cursor = Cursors.Default;

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
