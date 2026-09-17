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
    public partial class Frm_CargarMovimientoCanje : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        public Frm_CargarMovimientoCanje()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarMovimientoCanje_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox_Año.SelectedIndex = 0;
            comboBox_Año.DropDownStyle = ComboBoxStyle.DropDownList;

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
                    GuardarMovimientoCanje();
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

        public void GuardarMovimientoCanje()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                cn_comunicacion.EliminarMovimientoCanje(
                        Convert.ToInt32(comboBox_Año.Text)
                        );

                Cursor = Cursors.WaitCursor;

                // Toda la tanda va de una sola vez con SqlBulkCopy. El borrado
                // por año ya corrio arriba.
                DataTable datos = new DataTable();
                foreach (string c in new string[] { "empresa", "dni", "nombre_completo", "Sede",
                    "tipo_movimiento", "tipo_logico", "tipo_bono", "labor" })
                    datos.Columns.Add(c, typeof(string));
                datos.Columns.Add("Cantidad", typeof(double));
                datos.Columns.Add("puntos", typeof(double));
                datos.Columns.Add("PrecioIGV", typeof(double));
                foreach (string c in new string[] { "CodigoNisira", "codigo", "codigo_producto",
                    "descripcion_producto", "estado_canje" })
                    datos.Columns.Add(c, typeof(string));
                datos.Columns.Add("fecha_movimiento", typeof(DateTime));
                datos.Columns.Add("fecha_estimada", typeof(DateTime));
                datos.Columns.Add("fecha_entrega", typeof(DateTime));
                foreach (string c in new string[] { "estado", "correo", "direccion", "telefono",
                    "usuario_registro", "usuario_edicion", "usuario_entrega", "Hoja" })
                    datos.Columns.Add(c, typeof(string));
                datos.Columns.Add("FecCre", typeof(DateTime));
                datos.Columns.Add("UseReg", typeof(int));
                datos.Columns.Add("Hostname", typeof(string));

                DateTime fechaSis = ce_usuario.FechaSistema();
                string hostname = ce_usuario.HostName();

                int filas = dataGridView1.Rows.Count;
                for (int i = 0; i <= filas - 1; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataRow fila = datos.NewRow();
                    fila["empresa"] = cu_valores.Texto(dataGridView1[0, i].Value);
                    fila["dni"] = cu_valores.Texto(dataGridView1[1, i].Value);
                    fila["nombre_completo"] = cu_valores.TextoMayus(dataGridView1[2, i].Value);
                    fila["Sede"] = cu_valores.TextoMayus(dataGridView1[3, i].Value);
                    fila["tipo_movimiento"] = cu_valores.TextoMayus(dataGridView1[4, i].Value);
                    fila["tipo_logico"] = cu_valores.TextoMayus(dataGridView1[5, i].Value);
                    fila["tipo_bono"] = cu_valores.TextoMayus(dataGridView1[6, i].Value);
                    fila["labor"] = cu_valores.TextoMayus(dataGridView1[7, i].Value);
                    fila["Cantidad"] = cu_valores.Numero(dataGridView1[8, i].Value);
                    fila["puntos"] = cu_valores.Numero(dataGridView1[9, i].Value);
                    fila["PrecioIGV"] = cu_valores.Numero(dataGridView1[10, i].Value);
                    fila["CodigoNisira"] = cu_valores.TextoMayus(dataGridView1[11, i].Value);
                    fila["codigo"] = cu_valores.TextoMayus(dataGridView1[12, i].Value);
                    fila["codigo_producto"] = cu_valores.TextoMayus(dataGridView1[13, i].Value);
                    fila["descripcion_producto"] = cu_valores.TextoMayus(dataGridView1[14, i].Value);
                    fila["estado_canje"] = cu_valores.TextoMayus(dataGridView1[15, i].Value);
                    fila["fecha_movimiento"] = cu_valores.Fecha(dataGridView1[16, i].Value);
                    fila["fecha_estimada"] = cu_valores.Fecha(dataGridView1[17, i].Value);
                    fila["fecha_entrega"] = cu_valores.Fecha(dataGridView1[18, i].Value);
                    fila["estado"] = cu_valores.TextoMayus(dataGridView1[19, i].Value);
                    fila["correo"] = cu_valores.TextoMayus(dataGridView1[20, i].Value);
                    fila["direccion"] = cu_valores.TextoMayus(dataGridView1[21, i].Value);
                    fila["telefono"] = cu_valores.TextoMayus(dataGridView1[22, i].Value);
                    fila["usuario_registro"] = cu_valores.TextoMayus(dataGridView1[23, i].Value);
                    fila["usuario_edicion"] = cu_valores.TextoMayus(dataGridView1[24, i].Value);
                    fila["usuario_entrega"] = cu_valores.TextoMayus(dataGridView1[25, i].Value);
                    fila["Hoja"] = comboBox_Hojas.Text;
                    fila["FecCre"] = fechaSis;
                    fila["UseReg"] = ce_usuario.usecod;
                    fila["Hostname"] = hostname;
                    // FecEdit, UseEdit y UseElim quedan nulos en el alta, igual
                    // que los dejaba el INSERT del SP.
                    datos.Rows.Add(fila);
                }

                objcnlog.GuardarMovimientoCanjeMasivo(datos);

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

    }
}
