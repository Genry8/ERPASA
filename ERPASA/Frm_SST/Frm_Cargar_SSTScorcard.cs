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

namespace ERPASA.Frm_SST
{
    public partial class Frm_Cargar_SSTScorcard : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg1, dtg2, dtg3, dtg4, dtg5;
        private CancellationTokenSource _cts;
        public Frm_Cargar_SSTScorcard()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_Cargar_SSTScorcard_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            comboBox_area.SelectedIndex = 0;

            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_ReglaOro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_Acto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_Percepcion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_Inspecciones.DropDownStyle = ComboBoxStyle.DropDownList;


            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_emp_acto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_acto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            comboBox_emp_reglaoro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_reglaoro.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            comboBox_emp_percepcion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_percepcion.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            comboBox_emp_inspecciones.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_inspecciones.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA CHARLA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA ACTO
            comboBox_emp_acto.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_acto.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_acto.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA REGLA ORO
            comboBox_emp_reglaoro.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_reglaoro.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_reglaoro.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA PERCEPCION
            comboBox_emp_percepcion.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_percepcion.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_percepcion.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA INSPECCION
            comboBox_emp_inspecciones.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_inspecciones.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_inspecciones.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


            //CARGAR AREA

            //comboBox_area.DataSource = cn_logistica.ListaCBAreaTodoAsignacionTI();
            //comboBox_area.DisplayMember = "DesArea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_area.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


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
                dataGridView1.DataSource = dtg1;
                dataGridView1.AllowUserToAddRows = false;

                // Verificar si alguna columna contiene horas (tipo DateTime o TimeSpan)
                // Verificar si alguna columna contiene horas (tipo DateTime o TimeSpan)
                // Verificar si alguna columna contiene horas (tipo DateTime o TimeSpan)
                //foreach (DataGridViewColumn column in dataGridView1.Columns)
                //{
                //    // Verificar que la columna sea de tipo string o DateTime
                //    foreach (DataGridViewRow row in dataGridView1.Rows)
                //    {
                //        if (row.Cells[column.Index].Value != null)
                //        {
                //            string cellValue = row.Cells[column.Index].Value.ToString();

                //            // Verificar si los primeros 10 caracteres son "31/12/1899"
                //            if (cellValue.Length >= 10 && cellValue.Substring(0, 10).Trim() == "31/12/1899")
                //            {
                //                // Extraer solo la hora, que está en los caracteres después de "31/12/1899"
                //                string timePart = cellValue.Substring(11, 5); // Obtener solo la hora (hh:mm)

                //                // Asignar solo la hora a la celda
                //                row.Cells[column.Index].Value = timePart;

                //                // Formatear la columna para mostrar solo la hora
                //                column.DefaultCellStyle.Format = "HH:mm:ss"; // Formato solo hora (24h)
                //            }
                //            // Asignar valores de celdas según el tipo de columna
                //            else if (row.Cells[column.Index].ValueType == typeof(DateTime))
                //            {
                //                DateTime tempDate;
                //                // Si el valor es solo fecha, convertir a DateTime
                //                if (DateTime.TryParse(cellValue.ToString(), out tempDate))
                //                {
                //                    row.Cells[column.Index].Value = tempDate.Date; // Solo asignar la fecha, sin la parte de la hora
                //                }
                //                else
                //                {
                //                    row.Cells[column.Index].Value = DBNull.Value;
                //                }
                //            }

                //            else
                //            {
                //                // Si no es "31/12/1899", dejar el valor tal como está
                //                row.Cells[column.Index].Value = cellValue;
                //            }
                //        }
                //    }
                //}


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
            dtg1 = dtsTablas.Tables[hojaText];
            dataGridView1.ClearSelection();
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
                            cn_planilla.BuscExisteCharla(
                                comboBox_empresa.Text,//EMPRESA
                                comboBox_CodSede.Text//SEDE
                                );

                            GuardarDatosSync();
                        }

                        //GuardarCharla();
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
                    GuardarSSTCharlaBulk();
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


        public void GuardarSSTCharlaBulk()
        {
            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_sst_charla> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_sst datos = new cd_sst();
            datos.GuardarSSTCharlaBulk(dt);

        }


        public List<ce_sst_charla> ConvertirDataGridViewALista(DataGridView dgv)
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
            // Obtener empresa
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
            // Obtener sede
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

            List<ce_sst_charla> lista = new List<ce_sst_charla>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_sst_charla entidad = new ce_sst_charla
                    {
                        id = row.Cells[0].Value?.ToString(),
                        empresa = empText,
                        sede = sedText,
                        area = row.Cells[1].Value?.ToString(),
                        tipoevaluacion = row.Cells[2].Value?.ToString(),
                        nrotrabajador = int.TryParse(row.Cells[3].Value?.ToString(), out int trabajadores) ? trabajadores : 0,
                        nroejecutado = int.TryParse(row.Cells[4].Value?.ToString(), out int ejecutados) ? ejecutados : 0,
                        fecha = row.Cells[5].Value != null ? Convert.ToDateTime(row.Cells[5].Value) : default(DateTime),
                        semana = row.Cells[6].Value?.ToString(),
                        hoja = hojaText,
                        estado = "", // Ajustar si es necesario
                        feccre = ce_usuario.FechaSistema(),
                        usereg = ce_usuario.usecod,
                        hostname = ce_usuario.HostName(),
                        fecedit = ce_usuario.FechaSistema(),
                        useedit = 0
                    };

                    lista.Add(entidad);
                }
            }


            return lista;
        }

        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            // Crear el DataTable
            DataTable dt = new DataTable();

            // Obtener las propiedades de la clase T (MiEntidad)
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Crear las columnas del DataTable basadas en las propiedades de la clase
            foreach (var propiedad in propiedades)
            {
                // Definir la columna con el nombre de la propiedad y el tipo de datos correspondiente
                dt.Columns.Add(propiedad.Name, propiedad.PropertyType);
            }

            // Llenar el DataTable con los valores de la lista
            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                // Asignar valores de las propiedades a las columnas del DataTable
                foreach (var propiedad in propiedades)
                {
                    fila[propiedad.Name] = propiedad.GetValue(entidad) ?? DBNull.Value; // Maneja valores null
                }

                dt.Rows.Add(fila);
            }

            return dt;
        }

        /*
        public void GuardarCharla()
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

                    var exchar = cn_planilla.BuscExisteCharla(
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_CodSede.Text,//SEDE
                        dataGridView1[1, i].Value.ToString(),//area
                        Convert.ToDateTime(dataGridView1[5, i].Value), //fecha
                        dataGridView1[2, i].Value.ToString() //TIPO
                        );

                    if (exchar == true)
                    {

                        objcnlog.ActualizarCharla(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//ID
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_CodSede.Text,//SEDE
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION
                        Convert.ToInt32(dataGridView1[3, i].Value),//NUM TRAB
                        Convert.ToInt32(dataGridView1[4, i].Value),//NUM EJECUTADO
                        Convert.ToDateTime(dataGridView1[5, i].Value),//FECHA
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas.Text,
                        "",
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

                        objcnlog.GuardarCharla(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//ID
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_CodSede.Text,//SEDE
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION
                        Convert.ToInt32(dataGridView1[3, i].Value),//NUM TRAB
                        Convert.ToInt32(dataGridView1[4, i].Value),//NUM EJECUTADO
                        Convert.ToDateTime(dataGridView1[5, i].Value),//FECHA
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas.Text,
                        "",
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
        */

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

        private void toolStripButton_MostarAccidenteIncidente_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_ReglaOro.Text != "")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtsTablas.Tables[comboBox_Hojas_ReglaOro.SelectedIndex];
                dataGridView2.ClearSelection();
                if (dataGridView2.Rows.Count > 1)
                {
                    label_cantreg_reglaOro.Text = (dataGridView2.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        private void btnBuscar_accidente_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView2.DataSource = null;

                textBox_ruta_ReglaOro.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_ReglaOro.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_ReglaOro.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_ReglaOro.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton_GuardarAccidenteIncidente_Click(object sender, EventArgs e)
        {

            dataGridView2.AllowUserToAddRows = false;

            if (dataGridView2.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_reglaoro.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_reglaoro.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarReglaOro();
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

        private void toolStripButton_LimpiarAccidenteIncidente_Click(object sender, EventArgs e)
        {

        }


        public void GuardarReglaOro()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarReglaOro(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        Convert.ToInt32(dataGridView2[0, i].Value.ToString().Trim()),//ID
                        comboBox_emp_reglaoro.Text,//EMPRESA
                        comboBox_sede_reglaoro.Text,//SEDE
                        dataGridView2[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView2[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION

                        dataGridView2[3, i].Value.ToString().Trim(),//NUM TRAB
                        dataGridView2[4, i].Value.ToString().Trim(),//NUM COMPROMISO
                        Convert.ToDateTime(dataGridView2[5, i].Value),//FECHA
                        dataGridView2[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas_ReglaOro.Text,
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


            dataGridView2.AllowUserToAddRows = true;

        }



        private void toolStripButton_MostarActoCondicion_Click(object sender, EventArgs e)
        {
            if (textBox_ruta_acto.Text != "")
            {
                CargarDatosActoCond();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        private async void CargarDatosActoCond()
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
                    mostrarDatosActoCond();
                    dataGridView3.ClearSelection();
                });

                dataGridView3.Columns.Clear();
                dataGridView3.DataSource = dtg3;
                dataGridView3.AllowUserToAddRows = false;

                // Verificar el número de registros y mostrar un mensaje adecuado
                if (dataGridView3.Rows.Count > 1)
                {
                    label_cantreg_acto.Text = (dataGridView3.RowCount - 1).ToString() + " REGISTROS";
                }

                if (dataGridView3.Rows.Count > 0)
                {
                    label_cantreg_acto.Text = (dataGridView3.RowCount).ToString() + " REGISTROS";
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


        public void mostrarDatosActoCond()
        {
            string hojaText = string.Empty, hoja;
            ////////////////////////////////////
            if (comboBox_Hojas_Acto.InvokeRequired)
            {
                comboBox_Hojas_Acto.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas_Acto.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas_Acto.Text;
            }

            // Cargar los datos desde el DataTable
            dtg3 = dtsTablas.Tables[hojaText];
            dataGridView3.ClearSelection();
        }


        private void toolStripButton_GuardarActoCondicion_Click(object sender, EventArgs e)
        {

            dataGridView3.AllowUserToAddRows = false;

            if (dataGridView3.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_acto.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_acto.Text == "SELECCIONE")
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
                            cn_planilla.BuscExisteActoCondicion(
                        comboBox_emp_acto.Text, comboBox_sede_acto.Text
                        );
                            GuardarDatosActoCondSync();
                        }
                    }

                    //GuardarActoCondicion();
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


        private async void GuardarDatosActoCondSync()
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
                    GuardarActoCondicionBulk();
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


        public void GuardarActoCondicionBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_sst_actocondicion> listaTareo = ConvertirDataGridViewAListaActoCond(dataGridView3);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTableActoCond(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_sst datos = new cd_sst();
            datos.GuardarSSTActoCondicionBulk(dt);

        }


        public List<ce_sst_actocondicion> ConvertirDataGridViewAListaActoCond(DataGridView dgv)
        {
            string hojaText = string.Empty
                , empText = string.Empty, sedText = string.Empty;

            // Obtener el valor de la hojaText
            if (comboBox_Hojas_Acto.InvokeRequired)
            {
                comboBox_Hojas_Acto.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas_Acto.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas_Acto.Text;
            }
            // Obtener empresa
            if (comboBox_emp_acto.InvokeRequired)
            {
                comboBox_emp_acto.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_emp_acto.Text;
                }));
            }
            else
            {
                empText = comboBox_emp_acto.Text;
            }
            // Obtener sede
            if (comboBox_sede_acto.InvokeRequired)
            {
                comboBox_sede_acto.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_sede_acto.Text;
                }));
            }
            else
            {
                sedText = comboBox_sede_acto.Text;
            }

            List<ce_sst_actocondicion> lista = new List<ce_sst_actocondicion>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_sst_actocondicion entidad = new ce_sst_actocondicion
                    {
                        id = row.Cells[0].Value?.ToString(),
                        empresa = empText,
                        sede = sedText,
                        area = row.Cells[1].Value?.ToString(),
                        incidencia = row.Cells[2].Value?.ToString(),
                        hallazgo = row.Cells[3].Value?.ToString(),
                        peligro = row.Cells[4].Value?.ToString(),
                        jerarquia = row.Cells[5].Value?.ToString(),
                        hallazgo_desviacion = row.Cells[6].Value?.ToString(),
                        medida_correctiva = row.Cells[7].Value?.ToString(),
                        responsable = row.Cells[8].Value?.ToString(),
                        fecrep = DateTime.TryParse(row.Cells[9].Value?.ToString(), out DateTime repFecha) ? repFecha : default(DateTime),
                        estado_insp = row.Cells[10].Value?.ToString(),
                        medida_correctiva_2 = row.Cells[11].Value?.ToString(),
                        evidencia = row.Cells[12].Value?.ToString(),
                        feclevant = DateTime.TryParse(row.Cells[13].Value?.ToString(), out DateTime levantFecha)
                        ? levantFecha : (DateTime?)null,
                        semana = int.TryParse(row.Cells[14].Value?.ToString(), out int sem) ? sem : 0,
                        hoja = hojaText,
                        estado = "", // Definir si hay lógica
                        feccre = ce_usuario.FechaSistema(),
                        usereg = ce_usuario.usecod,
                        hostname = ce_usuario.HostName(),
                        fecedit = ce_usuario.FechaSistema(),
                        useedit = 0
                    };

                    lista.Add(entidad);
                }
            }


            return lista;
        }

        public DataTable ConvertirListaADataTableActoCond<T>(List<T> lista)
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


        private void btnBuscar_Acto_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView3.DataSource = null;

                textBox_ruta_acto.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_Acto.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_Acto.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Acto.SelectedIndex = 0;

                reader.Close();
            }
        }


        /*
        public void GuardarActoCondicion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView3.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    var exchar = cn_planilla.BuscExisteActoCondicion(
                        dataGridView3[0, i].Value.ToString().Trim(), //Cod
                        Convert.ToDateTime(dataGridView3[9, i].Value).Date,//Fecha
                        comboBox_emp_acto.Text, comboBox_sede_acto.Text,
                        dataGridView3[1, i].Value.ToString().Trim()
                        );
                    if (exchar == true)
                    {
                        if (dataGridView3[13, i].Value.ToString() == "")
                        {
                            dataGridView3[13, i].Value = "1990-01-01";
                        }
                        else
                        {
                            dataGridView3[13, i].Value = dataGridView3[13, i].Value;
                        }

                        objcnlog.ActualizarActoCondicion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView3[0, i].Value.ToString().ToUpper().Trim(),//ID
                        Convert.ToInt32(dataGridView3[14, i].Value),//SEMANA
                        comboBox_emp_acto.Text,//EMPRESA
                        comboBox_sede_acto.Text,//SEDE
                        dataGridView3[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView3[2, i].Value.ToString().ToUpper().Trim(),//INCIDENCIA
                        dataGridView3[3, i].Value.ToString().ToUpper().Trim(),//HALLAZGO
                        dataGridView3[4, i].Value.ToString().ToUpper().Trim(),//PELIGRO
                        dataGridView3[5, i].Value.ToString().ToUpper().Trim(),//TIPO JERARAQUIA
                        dataGridView3[6, i].Value.ToString().ToUpper().Trim(),//HALLAZGO_DESVIACION --
                        dataGridView3[7, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA ---
                        dataGridView3[8, i].Value.ToString().ToUpper().Trim(),//RESPONSABLE
                        Convert.ToDateTime(dataGridView3[9, i].Value),//FEC REP
                        dataGridView3[10, i].Value.ToString().ToUpper().Trim(),//ESTADO INSPECCION
                        dataGridView3[11, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA 2 ---
                        dataGridView3[12, i].Value.ToString().ToUpper().Trim(),//EVIDENCIA
                        Convert.ToDateTime(dataGridView3[13, i].Value),//FEC LEVANT

                        comboBox_Hojas_Acto.Text,
                        "",
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
                        if (dataGridView3[13, i].Value.ToString() == "")
                        {
                            dataGridView3[13, i].Value = "1990-01-01";
                        }
                        else
                        {
                            dataGridView3[13, i].Value = dataGridView3[13, i].Value;
                        }

                        objcnlog.GuardarActoCondicion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView3[0, i].Value.ToString().ToUpper().Trim(),//ID
                        Convert.ToInt32(dataGridView3[14, i].Value),//SEMANA
                        comboBox_emp_acto.Text,//EMPRESA
                        comboBox_sede_acto.Text,//SEDE
                        dataGridView3[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView3[2, i].Value.ToString().ToUpper().Trim(),//INCIDENCIA
                        dataGridView3[3, i].Value.ToString().ToUpper().Trim(),//HALLAZGO
                        dataGridView3[4, i].Value.ToString().ToUpper().Trim(),//PELIGRO
                        dataGridView3[5, i].Value.ToString().ToUpper().Trim(),//TIPO JERARAQUIA
                        dataGridView3[6, i].Value.ToString().ToUpper().Trim(),//HALLAZGO_DESVIACION
                        dataGridView3[7, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA
                        dataGridView3[8, i].Value.ToString().ToUpper().Trim(),//RESPONSABLE
                        Convert.ToDateTime(dataGridView3[9, i].Value),//FEC REP
                        dataGridView3[10, i].Value.ToString().ToUpper().Trim(),//ESTADO INSPECCION
                        dataGridView3[11, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA 2
                        dataGridView3[12, i].Value.ToString().ToUpper().Trim(),//EVIDENCIA
                        Convert.ToDateTime(dataGridView3[13, i].Value),//FEC LEVANT

                        comboBox_Hojas_Acto.Text,
                        "",
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


            dataGridView3.AllowUserToAddRows = true;

        }
        */

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

        private void comboBox_emp_acto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_acto.Text == comboBox_emp_acto.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_acto.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_acto.Text);
                comboBox_sede_acto.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_acto.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void btnBuscar_Percepcion_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView4.DataSource = null;

                textBox_ruta_percepcion.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_Percepcion.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_Percepcion.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Percepcion.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton_Mostrar_PercepcionRiesgo_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_percepcion.Text != "")
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = dtsTablas.Tables[comboBox_Hojas_Percepcion.SelectedIndex];
                dataGridView4.ClearSelection();
                if (dataGridView4.Rows.Count > 1)
                {
                    label_cantreg_Percepcion.Text = (dataGridView4.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_Guardar_PercepcionRiesgo_Click(object sender, EventArgs e)
        {

            dataGridView4.AllowUserToAddRows = false;

            if (dataGridView4.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_percepcion.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_percepcion.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarPercepcion();
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



        public void GuardarPercepcion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView4.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarPercepcion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        Convert.ToInt32(dataGridView4[0, i].Value.ToString().Trim()),//ID
                        comboBox_emp_percepcion.Text,//EMPRESA
                        comboBox_sede_percepcion.Text,//SEDE
                        dataGridView4[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView4[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION

                        dataGridView4[3, i].Value.ToString().Trim(),//NUM TRAB
                        dataGridView4[4, i].Value.ToString().Trim(),//NUM COMPROMISO
                        Convert.ToDateTime(dataGridView4[5, i].Value),//FECHA
                        dataGridView4[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas_Percepcion.Text,
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


            dataGridView4.AllowUserToAddRows = true;

        }


        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Inspecciones_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView5.DataSource = null;

                textBox_ruta_inspecciones.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_Inspecciones.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_Inspecciones.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Inspecciones.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton_Mostrar_Inspecciones_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_inspecciones.Text != "")
            {
                CargarDatosInspeccion();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        private async void CargarDatosInspeccion()
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
                    mostrarDatosInspeccion();
                    dataGridView5.ClearSelection();
                });

                dataGridView5.Columns.Clear();
                dataGridView5.DataSource = dtg5;
                dataGridView5.AllowUserToAddRows = false;

                // Verificar el número de registros y mostrar un mensaje adecuado
                if (dataGridView5.Rows.Count > 1)
                {
                    label_cantreg_Inspecciones.Text = (dataGridView5.RowCount - 1).ToString() + " REGISTROS";
                }

                if (dataGridView5.Rows.Count > 0)
                {
                    label_cantreg_Inspecciones.Text = (dataGridView5.RowCount).ToString() + " REGISTROS";
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


        public void mostrarDatosInspeccion()
        {
            string hojaText = string.Empty, hoja;
            ////////////////////////////////////
            if (comboBox_Hojas_Inspecciones.InvokeRequired)
            {
                comboBox_Hojas_Inspecciones.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas_Inspecciones.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas_Inspecciones.Text;
            }

            // Cargar los datos desde el DataTable
            dtg5 = dtsTablas.Tables[hojaText];
            dataGridView5.ClearSelection();
        }


        private void toolStripButton_Guardar_Inspecciones_Click(object sender, EventArgs e)
        {

            dataGridView5.AllowUserToAddRows = false;

            if (dataGridView5.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_inspecciones.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_inspecciones.Text == "SELECCIONE")
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
                            cn_planilla.BuscExisteInspeccion(
                        comboBox_emp_inspecciones.Text, comboBox_sede_inspecciones.Text
                        );
                            GuardarDatosInspeccionSync();
                        }
                        //GuardarInspeccion();
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



        private async void GuardarDatosInspeccionSync()
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
                    GuardarInspeccionBulk();
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


        public void GuardarInspeccionBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_sst_inspeccion> listaTareo = ConvertirDataGridViewAListaInspeccion(dataGridView5);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTableInspeccion(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_sst datos = new cd_sst();
            datos.GuardarSSTInspeccionBulk(dt);

        }


        public List<ce_sst_inspeccion> ConvertirDataGridViewAListaInspeccion(DataGridView dgv)
        {
            string hojaText = string.Empty
                , empText = string.Empty, sedText = string.Empty;

            // Obtener el valor de la hojaText
            if (comboBox_Hojas_Inspecciones.InvokeRequired)
            {
                comboBox_Hojas_Inspecciones.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas_Inspecciones.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas_Inspecciones.Text;
            }
            // Obtener empresa
            if (comboBox_emp_inspecciones.InvokeRequired)
            {
                comboBox_emp_inspecciones.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_emp_inspecciones.Text;
                }));
            }
            else
            {
                empText = comboBox_emp_inspecciones.Text;
            }
            // Obtener sede
            if (comboBox_sede_inspecciones.InvokeRequired)
            {
                comboBox_sede_inspecciones.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_sede_inspecciones.Text;
                }));
            }
            else
            {
                sedText = comboBox_sede_inspecciones.Text;
            }

            List<ce_sst_inspeccion> lista = new List<ce_sst_inspeccion>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_sst_inspeccion entidad = new ce_sst_inspeccion
                    {
                        id = int.TryParse(row.Cells[0].Value?.ToString(), out int idVal) ? idVal : 0,
                        empresa = empText,
                        sede = sedText,
                        area = row.Cells[1].Value?.ToString(),
                        tipoevaluacion = row.Cells[2].Value?.ToString(),
                        nroprogramados = float.TryParse(row.Cells[3].Value?.ToString(), out float prog) ? prog : 0,
                        nroejecutados = float.TryParse(row.Cells[4].Value?.ToString(), out float ejec) ? ejec : 0,
                        fecha = DateTime.TryParse(row.Cells[5].Value?.ToString(), out DateTime fechaVal) ? fechaVal : (DateTime?)null,
                        semana = float.TryParse(row.Cells[6].Value?.ToString(), out float semanaVal) ? semanaVal : 0,
                        hoja = hojaText,
                        estado = "", // Define según lógica de negocio
                        feccre = ce_usuario.FechaSistema(),
                        usereg = ce_usuario.usecod,
                        hostname = ce_usuario.HostName(),
                        fecedit = ce_usuario.FechaSistema(),
                        useedit = 0
                    };

                    lista.Add(entidad);
                }
            }


            return lista;
        }

        public DataTable ConvertirListaADataTableInspeccion<T>(List<T> lista)
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


        public void GuardarInspeccion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView5.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarInspeccion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        Convert.ToInt32(dataGridView5[0, i].Value.ToString().Trim()),//ID
                        comboBox_emp_inspecciones.Text,//EMPRESA
                        comboBox_sede_inspecciones.Text,//SEDE
                        dataGridView5[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView5[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION

                        dataGridView5[3, i].Value.ToString().Trim(),//NUM TRAB
                        dataGridView5[4, i].Value.ToString().Trim(),//NUM COMPROMISO
                        Convert.ToDateTime(dataGridView5[5, i].Value),//FECHA
                        dataGridView5[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas_Percepcion.Text,
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


            dataGridView5.AllowUserToAddRows = true;

        }


        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_emp_reglaoro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_reglaoro.Text == comboBox_emp_reglaoro.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_reglaoro.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_reglaoro.Text);
                comboBox_sede_reglaoro.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_reglaoro.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_emp_percepcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_percepcion.Text == comboBox_emp_percepcion.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_percepcion.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_percepcion.Text);
                comboBox_sede_percepcion.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_percepcion.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_emp_inspecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_inspecciones.Text == comboBox_emp_inspecciones.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_inspecciones.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_inspecciones.Text);
                comboBox_sede_inspecciones.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_inspecciones.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }


    }
}
