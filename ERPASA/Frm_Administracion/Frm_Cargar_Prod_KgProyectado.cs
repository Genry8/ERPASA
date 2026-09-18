using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Administracion
{
    public partial class Frm_Cargar_Prod_KgProyectado : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_sst objcnlog = new cn_sst();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_Cargar_Prod_KgProyectado()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_Cargar_Prod_KgProyectado_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            Cargar_Empresa();
            //textRuta.Enabled = false;
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
                CargarDatos();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private async void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this); // Mostrar como formulario hijo
            Application.DoEvents(); // 🔧 permite que el formulario se pinte

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    mostrarDatos();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AllowUserToAddRows = false;


                // Verificar el número de registros y mostrar un mensaje adecuado
                if (dataGridView1.Rows.Count > 1)
                {
                    label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
                }
                else
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
            }
        }

        public void mostrarDatos()
        {
            string hojaText = string.Empty, hoja;
            ////////////////////////////////////
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas.Text;
            }

            // Cargar los datos desde el DataTable
            dtg = dtsTablas.Tables[hojaText];
            dataGridView1.ClearSelection();


            // Rellenar el DataGridView con los datos
            //dataGridView1.DataSource = dtg;
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
                        string MessageBoxTitle = "REGISTRO";
                        string MessageBoxContent = "¿Desea Guardar?";

                        DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GuardarDatosSync();
                        }

                        //GuardarCursoDeCapacitacion();
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


        private async void GuardarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            //frbm.label1.Text = "GUARDANDO DATOS..."; // Actualizar el texto del formulario de carga

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarCapacitacionBulk();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              // Mostrar mensaje de éxito
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }
        }

        public void GuardarCapacitacionBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_prodkilosproy> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_administracion datos = new cd_administracion();
            datos.GuardarProdKgProyectadoBulk(dt);

        }

        public List<ce_prodkilosproy> ConvertirDataGridViewALista(DataGridView dgv)
        {

            string hojaText = string.Empty
                , empText = string.Empty, sedText = string.Empty;

            // Obtener el valor de la hojaText
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas.Text;
            }
            // Obtener el valor de la año
            if (comboBox_empresa.InvokeRequired)
            {
                comboBox_empresa.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_empresa.Text;
                }));
            }
            else
            {
                empText = comboBox_empresa.Text;
            }
            // Obtener el valor de la semana
            if (comboBox_CodSede.InvokeRequired)
            {
                comboBox_CodSede.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_CodSede.Text;
                }));
            }
            else
            {
                sedText = comboBox_CodSede.Text;
            }

            List<ce_prodkilosproy> lista = new List<ce_prodkilosproy>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_prodkilosproy entidad = new ce_prodkilosproy
                    {
                        // Adaptación de valores desde DataGridView
                        campaña = int.TryParse(row.Cells[0].Value?.ToString(), out int campaña) ? campaña : 0,
                        mes = row.Cells[1].Value?.ToString(),
                        sem = int.TryParse(row.Cells[2].Value?.ToString(), out int sem) ? sem : 0,
                        fecha = DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime fecha) ? fecha : (DateTime?)null,
                        variedad = row.Cells[4].Value?.ToString(),
                        kg_prog = decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal kg_prog) ? kg_prog : 0m,
                        sede = sedText,
                        empresa = empText,
                        obs = "",

                        estado = "S",
                        feccre = ce_usuario.FechaSistema(),
                        usereg = ce_usuario.usecod,
                        hostname = ce_usuario.HostName(),
                        fecedit = ce_usuario.FechaSistema(),
                        useedit = 0,
                        useelim = 0
                    };

                    lista.Add(entidad);
                }
            }


            return lista;
        }

        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Crear columnas
            foreach (var propiedad in propiedades)
            {
                Type tipo = propiedad.PropertyType;

                if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipo = Nullable.GetUnderlyingType(tipo);
                }

                dt.Columns.Add(propiedad.Name, tipo);
            }

            // Llenar filas
            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                foreach (var propiedad in propiedades)
                {
                    var valor = propiedad.GetValue(entidad);
                    fila[propiedad.Name] = valor ?? DBNull.Value;
                }

                dt.Rows.Add(fila);
            }

            return dt;
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
                    objcnlog.GuardarCursoCapacitacion(
                        dataGridView1[0, i].Value.ToString().Trim(),//codigo
                        comboBox_empresa.Text.Trim(),
                        comboBox_CodSede.Text.Trim(),
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//apenom
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//dni
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ruc
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//cargo
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//sede induccion
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//fecha induccion

                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//trab altura
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//nota
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//excavacion
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//nota
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//caliente
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//nota
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//espacio confinado
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//nota

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

        private void textRuta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
