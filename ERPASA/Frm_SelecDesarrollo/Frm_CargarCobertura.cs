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

namespace ERPASA.Frm_SelecDesarrollo
{
    public partial class Frm_CargarCobertura : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_CargarCobertura()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarCobertura_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            //comboBox_Semana.SelectedIndex = 0;

            comboBox_Semana.SelectedIndex = 0;
            comboBox_Año.SelectedIndex = 0;
            comboBox_Semana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Año.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            PonerOscuroComboBox();
        }

        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            //comboBox_Semana.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
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

                        cn_planilla.EliminarCobertura(
                                Convert.ToInt32(comboBox_Año.Text),//Año
                                comboBox_Semana.Text//Semana
                                );

                        GuardarDatosSync();
                    }


                    //GuardarCobertura();
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
                    GuardarReporteCoberturaBulk();
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

        public void GuardarReporteCoberturaBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_coberturaprog> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_selecdesarrollo datos = new cd_selecdesarrollo();
            datos.GuardarCoberturaProgBulk(dt);

        }

        public List<ce_coberturaprog> ConvertirDataGridViewALista(DataGridView dgv)
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

            List<ce_coberturaprog> lista = new List<ce_coberturaprog>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_coberturaprog entidad = new ce_coberturaprog
                    {
                        fecha = DateTime.TryParse(row.Cells[0].Value?.ToString(), out DateTime levantFecha)
                        ? levantFecha : (DateTime?)null,
                        turno = row.Cells[1].Value?.ToString(),
                        jefatura = row.Cells[2].Value?.ToString(),
                        fundo = row.Cells[3].Value?.ToString(),
                        cultivo = row.Cells[4].Value?.ToString(),
                        area = row.Cells[5].Value?.ToString(),
                        recurso = row.Cells[6].Value?.ToString(),
                        tipo_recurso = row.Cells[7].Value?.ToString(),
                        labor_sistema = row.Cells[8].Value?.ToString(),
                        cant_prog = row.Cells[9].Value?.ToString(),
                        observaciones = row.Cells[10].Value?.ToString(),
                        total_prog = row.Cells[11].Value?.ToString(),
                        area_extech = row.Cells[12].Value?.ToString(),
                        area_ = row.Cells[13].Value?.ToString(),
                        año = int.TryParse(añoText, out int anioVal) ? anioVal : 0,
                        semana = semText,
                        hoja = hojaText,
                        estado = "", // Completar según lógica de negocio
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



        public void GuardarCobertura()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                //var exf = cn_planilla.BuscExisteEficiencia(comboBox_Año.Text, Convert.ToInt32(comboBox_Semana.Text));
                //if (exf == true)
                //{
                //    Msbox.Frm_NotificacionesPeligro nga = new Msbox.Frm_NotificacionesPeligro("SEMANA " + comboBox_Semana.Text + " AÑO " + comboBox_Año.Text + " YA FUE CARGADO", Color.FromArgb(238, 24, 24), 3);
                //    nga.ShowDialog();
                //}
                //else
                //{
                cn_planilla.EliminarCobertura(
                        Convert.ToInt32(comboBox_Año.Text),//Año
                        comboBox_Semana.Text//Semana
                        );

                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarCobertura(
                        Convert.ToDateTime(dataGridView1[0, i].Value),//Fecha
                        dataGridView1[1, i].Value.ToString(),//Turno
                        dataGridView1[2, i].Value.ToString(),//Jefatura
                        dataGridView1[3, i].Value.ToString(),//Fundo
                        dataGridView1[4, i].Value.ToString(),//Cultivo
                        dataGridView1[5, i].Value.ToString(),//Area
                        dataGridView1[6, i].Value.ToString(),//Recurso
                        dataGridView1[7, i].Value.ToString(),//Tipo Recurso
                        dataGridView1[8, i].Value.ToString(),//Labor Sistema
                        dataGridView1[9, i].Value.ToString().Trim(),//Cant Prog
                        dataGridView1[10, i].Value.ToString(),//Observaciones
                        dataGridView1[11, i].Value.ToString().Trim(),//TotalProg
                        dataGridView1[12, i].Value.ToString(),//Area Extech
                        dataGridView1[13, i].Value.ToString(),//Area_
                        Convert.ToInt32(comboBox_Año.Text),//Año
                        comboBox_Semana.Text,//Semana

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
                //}
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
