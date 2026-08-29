using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Planilla
{
    public partial class Frm_Registrar_VacTruncasDev : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_Registrar_VacTruncasDev()
        {
            InitializeComponent();
        }

        private void Frm_Registrar_VacTruncasDev_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_Mes.SelectedIndex = 0;
            comboBox_Año.SelectedIndex = 0;
            //poner osucro

            //textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_Mes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Año.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
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

            dataGridView1.AllowUserToAddRows = false;

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
                        cn_planilla.BuscExisteVacacionesTruncas(
                            comboBox_empresa.Text,
                        Convert.ToInt32(comboBox_Mes.Text)
                        , Convert.ToInt32(comboBox_Año.Text)
                        );

                        GuardarDatosSync();
                    }

                    //GuardarCompensacion();
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
                    GuardarVacacionesTruncasBulk();
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

        public void GuardarVacacionesTruncasBulk()
        {
            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_vacacion_trunca> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_planilla datos = new cd_planilla();
            datos.GuardarVacacionesTruncasBulk(dt);

        }

        public List<ce_vacacion_trunca> ConvertirDataGridViewALista(DataGridView dgv)
        {

            string hojaText = string.Empty, empresaText = string.Empty
                , añoText = string.Empty, semText = string.Empty;
            // Obtener el valor de empresatext
            if (comboBox_empresa.InvokeRequired)
            {
                comboBox_empresa.Invoke(new MethodInvoker(() =>
                {
                    empresaText = comboBox_empresa.Text;
                }));
            }
            else
            {
                empresaText = comboBox_empresa.Text;
            }
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
            if (comboBox_Mes.InvokeRequired)
            {
                comboBox_Mes.Invoke(new MethodInvoker(() =>
                {
                    semText = comboBox_Mes.Text;
                }));
            }
            else
            {
                semText = comboBox_Mes.Text;
            }

            List<ce_vacacion_trunca> lista = new List<ce_vacacion_trunca>();

            foreach (DataGridViewRow row in dgv.Rows)
            {

                if (!row.IsNewRow)
                {
                    // Obtener el valor de Cod
                    string cod = row.Cells[0].Value?.ToString();

                    // Verificar que cod no sea null o vacío
                    string dni = (cod != null && cod.Length > 1) ? cod.Substring(1) : cod;  // Eliminar el primer dígito de Cod para obtener Dni

                    ce_vacacion_trunca entidad = new ce_vacacion_trunca
                    {
                        Cod = cod,
                        ApeNom = row.Cells[1].Value?.ToString(),
                        Dni = dni,  // Asignar el Dni sin el primer dígito de Cod
                        FecIngreso = DateTime.TryParse(row.Cells[2].Value?.ToString(), out DateTime fecIng) ? fecIng : (DateTime?)null, // Ahora en la columna 2
                        FecMigracion = DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime fecMig) ? fecMig : (DateTime?)null,  // Agregado
                        FecCese = DateTime.TryParse(row.Cells[4].Value?.ToString(), out DateTime fecCes) ? fecCes : (DateTime?)null,
                        Planilla = row.Cells[5].Value?.ToString(),  // Agregado
                        Area = row.Cells[6].Value?.ToString(),
                        SitEspecial = row.Cells[7].Value?.ToString(),
                        CondTrabajador = row.Cells[8].Value?.ToString(),
                        Ceco = row.Cells[9].Value?.ToString(),
                        Zona = row.Cells[10].Value?.ToString(),  // Agregado
                        UltPago = row.Cells[11].Value?.ToString(),  // Agregado
                        FecUltPago = DateTime.TryParse(row.Cells[12].Value?.ToString(), out DateTime fecUltPago) ? fecUltPago : (DateTime?)null,  // Agregado
                        Gerencia = row.Cells[13].Value?.ToString(),
                        Cargo = row.Cells[14].Value?.ToString(),
                        NivelJerarquico = row.Cells[15].Value?.ToString(),  // Ahora NivelJerarquico antes de TipoTrab
                        TipoTrab = row.Cells[16].Value?.ToString(),
                        AsigFamiliar = row.Cells[17].Value?.ToString(),
                        RemBasica = double.TryParse(row.Cells[18].Value?.ToString(), out double remBas) ? remBas : (double?)null,
                        TotalDiasRH = double.TryParse(row.Cells[19].Value?.ToString(), out double totalDiasRH) ? totalDiasRH : (double?)null,  // Agregado
                        TotalDiasCont = double.TryParse(row.Cells[20].Value?.ToString(), out double totalDiasCont) ? totalDiasCont : (double?)null,  // Agregado
                        TotalVacaciones = double.TryParse(row.Cells[21].Value?.ToString(), out double totalVac) ? totalVac : (double?)null,  // Agregado
                        TotalIndemnizacion = double.TryParse(row.Cells[22].Value?.ToString(), out double totalIndemn) ? totalIndemn : (double?)null,  // Agregado
                        TotalValorizacion = double.TryParse(row.Cells[23].Value?.ToString(), out double totalVal) ? totalVal : (double?)null,  // Agregado
                        Indemnizados = double.TryParse(row.Cells[24].Value?.ToString(), out double indemnizados) ? indemnizados : (double?)null,  // Agregado
                        Pendientes = double.TryParse(row.Cells[25].Value?.ToString(), out double pendientes) ? pendientes : (double?)null,  // Agregado
                        Truncos = double.TryParse(row.Cells[26].Value?.ToString(), out double truncos) ? truncos : (double?)null,  // Agregado
                        Empresa = empresaText,
                        Sede = "",
                        // Convertir semText y añoText a int
                        Mes = int.TryParse(semText, out int mesVal) ? mesVal : (int?)null,
                        Año = int.TryParse(añoText, out int añoVal) ? añoVal : (int?)null,
                        Hoja = hojaText,
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = 0,
                        UseElim = 0
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
