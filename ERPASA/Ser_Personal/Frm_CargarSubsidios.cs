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

namespace ERPASA.Ser_personal
{
    public partial class Frm_CargarSubsidios : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_comunicacion objcnlog = new cn_comunicacion();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_CargarSubsidios()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarSubsidios_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro
            comboBox_Semana.SelectedIndex = 0;
            comboBox_Año.SelectedIndex = 0;
            comboBox_Semana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Año.DropDownStyle = ComboBoxStyle.DropDownList;

            Cargar_Empresa();
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

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

            // Obtener datagridview
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new MethodInvoker(() =>
                {
                    dataGridView1.AllowUserToAddRows = false;
                }));
            }
            if (dataGridView1.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string MessageBoxTitle = "REGISTRO";
                    string MessageBoxContent = "¿Desea Guardar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objcnlog.EliminarSubsidios(
                                comboBox_Año.Text,
                                comboBox_Semana.Text
                                );
                        GuardarDatosSync();
                    }

                    //GuardarSubsidio();

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
                    GuardareficienciaBulk();
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

        public void GuardareficienciaBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<sper_subsidio> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_servpersonal datos = new cd_servpersonal();
            datos.GuardarSubsidioBulk(dt);

        }

        public List<sper_subsidio> ConvertirDataGridViewALista(DataGridView dgv)
        {

            string hojaText = string.Empty
                , añoText = string.Empty, semText = string.Empty;

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
            if (comboBox_Año.InvokeRequired)
            {
                comboBox_Año.Invoke(new MethodInvoker(() =>
                {
                    añoText = comboBox_Año.Text;
                }));
            }
            else
            {
                añoText = comboBox_Año.Text;
            }
            // Obtener el valor de la semana
            if (comboBox_Semana.InvokeRequired)
            {
                comboBox_Semana.Invoke(new MethodInvoker(() =>
                {
                    semText = comboBox_Semana.Text;
                }));
            }
            else
            {
                semText = comboBox_Semana.Text;
            }

            List<sper_subsidio> lista = new List<sper_subsidio>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    sper_subsidio entidad = new sper_subsidio
                    {
                        id = row.Cells[0].Value?.ToString(), // Celda 0: "id"
                        empresa = row.Cells[1].Value?.ToString(), // Celda 1: "empresa"
                        sede = row.Cells[2].Value?.ToString(), // Celda 2: "sede"
                        dni = row.Cells[3].Value?.ToString(), // Celda 3: "dni"
                        nombrecompleto = row.Cells[4].Value?.ToString(), // Celda 4: "nombrecompleto"
                        area = row.Cells[5].Value?.ToString(), // Celda 5: "area"
                        tipotrabajador = row.Cells[6].Value?.ToString(), // Celda 6: "tipotrabajador"
                        tipodescanso = row.Cells[7].Value?.ToString(), // Celda 7: "tipodescanso"
                        feciniciosub = DateTime.TryParse(row.Cells[8].Value?.ToString(), out DateTime feciniciosub) ? feciniciosub : (DateTime?)null, // Celda 8: "feciniciosub"
                        fecfinsub = DateTime.TryParse(row.Cells[9].Value?.ToString(), out DateTime fecfinsub) ? fecfinsub : (DateTime?)null, // Celda 9: "fecfinsub"
                        mes = row.Cells[10].Value?.ToString(), // Celda 10: "mes"
                        año = int.TryParse(row.Cells[11].Value?.ToString(), out int añoVal) ? añoVal : 0, // Celda 11: "año"
                        dias = int.TryParse(row.Cells[12].Value?.ToString(), out int dias) ? dias : 0, // Celda 12: "dias"
                        fechapresentacion = DateTime.TryParse(row.Cells[13].Value?.ToString(), out DateTime fechapresentacion) ? fechapresentacion : (DateTime?)null, // Celda 13: "fechapresentacion"
                        fechaseguimiento = DateTime.TryParse(row.Cells[14].Value?.ToString(), out DateTime fechaseguimiento) ? fechaseguimiento : (DateTime?)null, // Celda 14: "fechaseguimiento"
                        montosubsidio = float.TryParse(row.Cells[15].Value?.ToString(), out float montosubsidio) ? montosubsidio : 0f, // Celda 15: "montosubsidio"
                        montocontabilidad = float.TryParse(row.Cells[16].Value?.ToString(), out float montocontabilidad) ? montocontabilidad : 0f, // Celda 16: "montocontabilidad"
                        contingencia = row.Cells[17].Value?.ToString(), // Celda 17: "contingencia"
                        statusbienestar = row.Cells[18].Value?.ToString(), // Celda 18: "statusbienestar"
                        nittcitt = row.Cells[19].Value?.ToString(), // Celda 19: "nittcitt"
                        obs = row.Cells[20].Value?.ToString(), // Celda 20: "obs"
                        añocarga = float.TryParse(añoText, out float añocarga) ? añocarga : 0f, // Año desde el TextBox
                        semana = int.TryParse(semText, out int semanaVal) ? semanaVal : 0, // Semana desde el TextBox
                        hoja = hojaText, // Hoja desde el TextBox
                        estado = "S", // Estado fijo

                        // Datos automáticos
                        feccre = ce_usuario.FechaSistema(), // Fecha de creación
                        usereg = ce_usuario.usecod, // Código de usuario
                        hostname = ce_usuario.HostName(), // Nombre del host
                        fecedit = ce_usuario.FechaSistema(), // Fecha de edición
                        useedit = 0 // Usuario de edición
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

        public void GuardarSubsidio()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                objcnlog.EliminarSubsidios(
                        comboBox_Año.Text,
                        comboBox_Semana.Text
                        );

                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    objcnlog.GuardarSubsidios(
                        dataGridView1[0, i].Value.ToString().Trim(),//id
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//empresa
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//SEDE
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//dni
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//apenom
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//Area
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//Tipo trabajador
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//tipo des med

                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//inicio subsidio
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//fin subsidio
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//mes
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//año
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//dias

                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//FechaPresentacion
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//FechaSeguimiento
                        dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//monto
                        dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//MontoContabilidad
                        dataGridView1[17, i].Value.ToString().ToUpper().Trim(),//contingencia
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//status

                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//nit cir
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//obs
                        comboBox_Año.Text,
                        comboBox_Semana.Text,
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

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel_guardar_Click(object sender, EventArgs e)
        {

        }
    }
}
