using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Contabilidad;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Comercial
{
    public partial class Frm_CargarLiquidacion : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_CargarLiquidacion()
        {
            InitializeComponent();
        }

        private void Frm_CargarLiquidacion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox_TipoCarga.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox_TipoCarga.SelectedIndex = 0;

            Cargar_Empresa();

            dataGridView1.AllowUserToAddRows = false;

        }


        public void Cargar_Empresa()
        {
            //CARGAR NORMA
            //comboBox_norma.DataSource = cn_sig.ListaNormaSig();
            //comboBox_norma.DisplayMember = "Norma"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_norma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
                string tipoCarga = guna2ComboBox_TipoCarga.Text;
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    if (tipoCarga == "CARGA ORIGINAL")
                    {
                        mostrarDatos();
                    }
                    else if (tipoCarga == "CARGA AJUSTADO")
                    {
                        mostrarDatosOF();
                    }
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
                    label_cantreg.Text = "---";
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
            string hojaSeleccionada = "";

            // Obtener el nombre de la hoja seleccionada
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaSeleccionada = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaSeleccionada = comboBox_Hojas.Text;
            }

            // Tabla del Excel
            DataTable dtExcel = dtsTablas.Tables[hojaSeleccionada];

            // Propiedades de la clase
            var propiedadesClase = typeof(ce_liquidaciones)
                .GetProperties()
                .Select(p => p.Name)
                .ToList();

            // ❌ Propiedades EXCLUIDAS del DataGridView
            List<string> columnasExcluidas = new List<string>()
            {
        "idliq",
                "ShipmentCode",
        "fecha",
        "Hoja",
        "NombreExcel",
        "Ruta",
        "Estado",
        "FecCre",
        "UseReg",
        "Hostname",
        "FecEdit",
        "UseEdit",
        "UseElim"
            };

            // Columnas permitidas
            var columnasMostrar = propiedadesClase
                .Where(c => !columnasExcluidas.Contains(c))
                .ToList();

            // Nuevo DataTable filtrado
            DataTable dtFiltrado = new DataTable();

            // Crear columnas permitidas en el mismo orden que la clase
            foreach (var col in columnasMostrar)
            {
                dtFiltrado.Columns.Add(col);
            }

            // Llenar filas
            foreach (DataRow filaExcel in dtExcel.Rows)
            {
                DataRow nuevaFila = dtFiltrado.NewRow();

                foreach (var col in columnasMostrar)
                {
                    if (dtExcel.Columns.Contains(col))
                    {
                        nuevaFila[col] = filaExcel[col];
                    }
                    else
                    {
                        nuevaFila[col] = DBNull.Value;
                    }
                }

                dtFiltrado.Rows.Add(nuevaFila);
            }

            // Asignar datatable filtrado
            dtg = dtFiltrado;
        }


        public void mostrarDatosOF()
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
                    string MessageBoxTitle = guna2ComboBox_TipoCarga.Text;
                    string MessageBoxContent = "¿Desea Guardar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (guna2ComboBox_TipoCarga.Text == "CARGA ORIGINAL")
                        {
                            GuardarDatosSync();
                        }
                        else if (guna2ComboBox_TipoCarga.Text == "CARGA AJUSTADO")
                        {
                            GuardarDatosSyncFn();
                        }
                    }

                    //GuardarProductividad();
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
            frbm.label1.Text = "🤖 ANALIZANDO Y PROCESANDO..."; // Actualizar el texto del formulario de carga

            try
            {
                // Esperar 1 segundo antes de continuar
                await Task.Delay(600);
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarReporteLiquidacionesBulk();
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

            }
        }

        public object GuardarReporteLiquidacionesBulk()
        {
            try
            {
                // 1️⃣ Convertir el DataGridView a una lista de entidades ce_liquidaciones
                List<ce_liquidaciones> listaLiquidaciones = ConvertirDataGridViewALista(dataGridView1);

                // 2️⃣ Convertir la lista a un DataTable compatible con el TVP de SQL
                DataTable dt = ConvertirListaADataTable(listaLiquidaciones);

                // 3️⃣ Llamar al método de la capa de datos
                var result = cd_comercial.UpsertLiquidacionesSave(dt);

                bool success = result.IdLiq != null;

                string mensaje = result.Mensaje;
                string titulo = success ? "Éxito" : "Error al Guardar";
                MessageBoxIcon icono = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;

                // Mostrar el MessageBox
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);


                // 5️⃣ Retornar respuesta estructurada (por si quieres usarla en código)
                return new
                {
                    Success = success,
                    Message = result.Mensaje,
                    IdLiq = result.IdLiq
                };
            }
            catch (Exception ex)
            {
                string mensajeError = "Error al realizar el UPSERT: " + ex.Message;
                string titulo = "Error al guardar";

                // Mostrar el MessageBox
                MessageBox.Show(mensajeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new
                {
                    Success = false,
                    Message = "Error al Guardar: " + ex.Message,
                    IdLiq = (int?)null
                };
            }
        }


        public List<ce_liquidaciones> ConvertirDataGridViewALista(DataGridView dgv)
        {

            string hojaText = string.Empty;

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

            List<ce_liquidaciones> lista = new List<ce_liquidaciones>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_liquidaciones entidad = new ce_liquidaciones
                    {
                        idliq = 0, // SQL Server genera el ID automáticamente

                        // 🟢 Datos de embarque
                        ShipmentCode = hojaText, // Se asigna desde la variable externa

                        // 🟢 Datos del bloque
                        growerblockid = row.Cells[0].Value?.ToString(),
                        blockname = row.Cells[1].Value?.ToString(),

                        // 🟢 Información de transacción
                        trxtype = decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal trxtypeVal) ? trxtypeVal : (decimal?)null,
                        chargeorderby = decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal chargeorderbyVal) ? chargeorderbyVal : (decimal?)null,
                        chargeid = row.Cells[4].Value?.ToString(),
                        chargedescr = row.Cells[5].Value?.ToString(),
                        chargeratetype = decimal.TryParse(row.Cells[6].Value?.ToString(), out decimal chargeratetypeVal) ? chargeratetypeVal : (decimal?)null,
                        invcqnt = decimal.TryParse(row.Cells[7].Value?.ToString(), out decimal invcqntVal) ? invcqntVal : (decimal?)null,

                        // 🟢 Montos
                        saleamt = decimal.TryParse(row.Cells[8].Value?.ToString(), out decimal saleamtVal) ? saleamtVal : (decimal?)null,
                        chgqnt = decimal.TryParse(row.Cells[9].Value?.ToString(), out decimal chgqntVal) ? chgqntVal : (decimal?)null,
                        chgamt = decimal.TryParse(row.Cells[10].Value?.ToString(), out decimal chgamtVal) ? chgamtVal : (decimal?)null,

                        // 🟢 Descripción del producto
                        gwrproductdescr = row.Cells[11].Value?.ToString(),
                        cmtyinvc = row.Cells[12].Value?.ToString(),
                        vrtyinvc = row.Cells[13].Value?.ToString(),

                        // 🟢 Clasificación
                        styleorderby = decimal.TryParse(row.Cells[14].Value?.ToString(), out decimal styleorderbyVal) ? styleorderbyVal : (decimal?)null,
                        gradeinvc = row.Cells[15].Value?.ToString(),
                        gradeorderby = decimal.TryParse(row.Cells[16].Value?.ToString(), out decimal gradeorderbyVal) ? gradeorderbyVal : (decimal?)null,
                        sizeorderby = decimal.TryParse(row.Cells[17].Value?.ToString(), out decimal sizeorderbyVal) ? sizeorderbyVal : (decimal?)null,

                        // 🟢 Unidad y factores de cargo
                        uom = row.Cells[18].Value?.ToString(),
                        fcchargeidx = row.Cells[19].Value?.ToString(),
                        invcicqnt = decimal.TryParse(row.Cells[20].Value?.ToString(), out decimal invcicqntVal) ? invcicqntVal : (decimal?)null,

                        // 🟢 Información de compañía
                        astitle = row.Cells[21].Value?.ToString(),
                        ascompanyname = row.Cells[22].Value?.ToString(),

                        // 🟢 Fechas
                        reportdate = DateTime.TryParse(row.Cells[23].Value?.ToString(), out DateTime reportVal) ? reportVal : (DateTime?)null,
                        date11 = DateTime.TryParse(row.Cells[24].Value?.ToString(), out DateTime date11Val) ? date11Val : (DateTime?)null,
                        date12 = DateTime.TryParse(row.Cells[25].Value?.ToString(), out DateTime date12Val) ? date12Val : (DateTime?)null,

                        // 🟢 Datos del agricultor
                        growerid = row.Cells[26].Value?.ToString(),
                        growername = row.Cells[27].Value?.ToString(),
                        fecha = dateTimePicker_fecha.Value,
                        // 🟢 Datos del archivo (personaliza según tus controles)
                        Hoja = hojaText,                   // Nombre de hoja Excel
                        NombreExcel = label_nombreExcel.Text,  // Nombre del archivo
                        Ruta = textRuta.Text,              // Ruta completa del archivo

                        // 🟢 Control y auditoría
                        Estado = "S", // Activo por defecto
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = ce_usuario.usecod,
                        UseElim = null
                    };

                    lista.Add(entidad);
                }


            }



            return lista;
        }

        /**/

        private async void GuardarDatosSyncFn()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "🤖 ANALIZANDO Y PROCESANDO..."; // Actualizar el texto del formulario de carga

            try
            {
                // Esperar 1 segundo antes de continuar
                await Task.Delay(600);
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarReporteLiquidacionesBulkFn();
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

            }
        }

        public object GuardarReporteLiquidacionesBulkFn()
        {
            try
            {
                // 1️⃣ Convertir el DataGridView a una lista de entidades ce_liquidaciones
                List<ce_liquidaciones> listaLiquidaciones = ConvertirDataGridViewAListaFn(dataGridView1);

                // 2️⃣ Convertir la lista a un DataTable compatible con el TVP de SQL
                DataTable dt = ConvertirListaADataTable(listaLiquidaciones);

                // 3️⃣ Llamar al método de la capa de datos
                var result = cd_comercial.UpsertLiquidacionesSave(dt);

                bool success = result.IdLiq != null;

                string mensaje = result.Mensaje;
                string titulo = success ? "Éxito" : "Error al Guardar";
                MessageBoxIcon icono = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;

                // Mostrar el MessageBox
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);


                // 5️⃣ Retornar respuesta estructurada (por si quieres usarla en código)
                return new
                {
                    Success = success,
                    Message = result.Mensaje,
                    IdLiq = result.IdLiq
                };
            }

            catch (Exception ex)
            {
                string mensajeError = "Error al realizar el UPSERT: " + ex.Message;
                string titulo = "Error al guardar";

                // Mostrar el MessageBox
                MessageBox.Show(mensajeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new
                {
                    Success = false,
                    Message = "Error al Guardar: " + ex.Message,
                    IdLiq = (int?)null
                };
            }
        }


        public List<ce_liquidaciones> ConvertirDataGridViewAListaFn(DataGridView dgv)
        {

            string hojaText = string.Empty;

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

            List<ce_liquidaciones> lista = new List<ce_liquidaciones>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    /*
                    ce_liquidaciones entidad = new ce_liquidaciones
                    {
                        idliq = 0, // SQL Server genera el ID automáticamente

                        // 🟢 Datos de embarque
                        ShipmentCode = hojaText, // Se asigna desde la variable externa

                        // 🟢 Datos del bloque
                        growerblockid = row.Cells[0].Value?.ToString(),
                        blockname = row.Cells[1].Value?.ToString(),

                        // 🟢 Información de transacción
                        trxtype = decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal trxtypeVal) ? trxtypeVal : (decimal?)null,
                        chargeorderby = decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal chargeorderbyVal) ? chargeorderbyVal : (decimal?)null,
                        chargeid = row.Cells[4].Value?.ToString(),
                        chargedescr = row.Cells[5].Value?.ToString(),
                        chargeratetype = decimal.TryParse(row.Cells[6].Value?.ToString(), out decimal chargeratetypeVal) ? chargeratetypeVal : (decimal?)null,
                        invcqnt = decimal.TryParse(row.Cells[7].Value?.ToString(), out decimal invcqntVal) ? invcqntVal : (decimal?)null,

                        // 🟢 Montos
                        saleamt = decimal.TryParse(row.Cells[8].Value?.ToString(), out decimal saleamtVal) ? saleamtVal : (decimal?)null,
                        chgqnt = decimal.TryParse(row.Cells[9].Value?.ToString(), out decimal chgqntVal) ? chgqntVal : (decimal?)null,
                        chgamt = decimal.TryParse(row.Cells[10].Value?.ToString(), out decimal chgamtVal) ? chgamtVal : (decimal?)null,

                        // 🟢 Descripción del producto
                        gwrproductdescr = row.Cells[11].Value?.ToString(),
                        cmtyinvc = row.Cells[12].Value?.ToString(),
                        vrtyinvc = row.Cells[13].Value?.ToString(),

                        // 🟢 Clasificación
                        styleorderby = decimal.TryParse(row.Cells[14].Value?.ToString(), out decimal styleorderbyVal) ? styleorderbyVal : (decimal?)null,
                        gradeinvc = row.Cells[15].Value?.ToString(),
                        gradeorderby = decimal.TryParse(row.Cells[16].Value?.ToString(), out decimal gradeorderbyVal) ? gradeorderbyVal : (decimal?)null,
                        sizeorderby = decimal.TryParse(row.Cells[17].Value?.ToString(), out decimal sizeorderbyVal) ? sizeorderbyVal : (decimal?)null,

                        // 🟢 Unidad y factores de cargo
                        uom = row.Cells[18].Value?.ToString(),
                        fcchargeidx = row.Cells[19].Value?.ToString(),
                        invcicqnt = decimal.TryParse(row.Cells[20].Value?.ToString(), out decimal invcicqntVal) ? invcicqntVal : (decimal?)null,

                        // 🟢 Información de compañía
                        astitle = row.Cells[21].Value?.ToString(),
                        ascompanyname = row.Cells[22].Value?.ToString(),

                        // 🟢 Fechas
                        reportdate = DateTime.TryParse(row.Cells[23].Value?.ToString(), out DateTime reportVal) ? reportVal : (DateTime?)null,
                        date11 = DateTime.TryParse(row.Cells[24].Value?.ToString(), out DateTime date11Val) ? date11Val : (DateTime?)null,
                        date12 = DateTime.TryParse(row.Cells[25].Value?.ToString(), out DateTime date12Val) ? date12Val : (DateTime?)null,

                        // 🟢 Datos del agricultor
                        growerid = row.Cells[26].Value?.ToString(),
                        growername = row.Cells[27].Value?.ToString(),
                        fecha = dateTimePicker_fecha.Value,
                        // 🟢 Datos del archivo (personaliza según tus controles)
                        Hoja = hojaText,                   // Nombre de hoja Excel
                        NombreExcel = label_nombreExcel.Text,  // Nombre del archivo
                        Ruta = textRuta.Text,              // Ruta completa del archivo

                        // 🟢 Control y auditoría
                        Estado = "S", // Activo por defecto
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = ce_usuario.usecod,
                        UseElim = null
                    };
                    */

                    ce_liquidaciones entidad = new ce_liquidaciones
                    {
                        idliq = 0,

                        ShipmentCode = hojaText,

                        // 🟢 Datos del bloque
                        growerblockid = row.Cells[0].Value?.ToString(),
                        blockname = row.Cells[1].Value?.ToString(),

                        // 🟢 Información de transacción
                        trxtype = decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal trxtypeVal) ? trxtypeVal : (decimal?)null,
                        chargeorderby = null, // ❌ ya no viene
                        chargeid = row.Cells[3].Value?.ToString(),
                        chargedescr = row.Cells[4].Value?.ToString(),
                        chargeratetype = decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal chargeratetypeVal) ? chargeratetypeVal : (decimal?)null,
                        invcqnt = null, // ❌ ya no viene

                        // 🟢 Montos
                        saleamt = decimal.TryParse(row.Cells[10].Value?.ToString(), out decimal saleamtVal) ? saleamtVal : (decimal?)null,
                        chgqnt = decimal.TryParse(row.Cells[15].Value?.ToString(), out decimal chgqntVal) ? chgqntVal : (decimal?)null,
                        chgamt = decimal.TryParse(row.Cells[17].Value?.ToString(), out decimal chgamtVal) ? chgamtVal : (decimal?)null,

                        // 🟢 Descripción del producto
                        gwrproductdescr = row.Cells[18].Value?.ToString(),
                        cmtyinvc = null,
                        vrtyinvc = null,

                        // 🟢 Clasificación
                        styleorderby = null,
                        gradeinvc = null,
                        gradeorderby = null,
                        sizeorderby = null,

                        // 🟢 Unidad y factores de cargo
                        uom = null,
                        fcchargeidx = null,
                        invcicqnt = decimal.TryParse(row.Cells[19].Value?.ToString(), out decimal invcicqntVal) ? invcicqntVal : (decimal?)null,

                        // 🟢 Información de compañía
                        astitle = row.Cells[20].Value?.ToString(),
                        ascompanyname = row.Cells[21].Value?.ToString(),

                        // 🟢 Fechas
                        reportdate = DateTime.TryParse(row.Cells[22].Value?.ToString(), out DateTime reportVal) ? reportVal : (DateTime?)null,
                        date11 = DateTime.TryParse(row.Cells[23].Value?.ToString(), out DateTime date11Val) ? date11Val : (DateTime?)null,
                        date12 = DateTime.TryParse(row.Cells[24].Value?.ToString(), out DateTime date12Val) ? date12Val : (DateTime?)null,

                        // 🟢 Datos del agricultor
                        growerid = row.Cells[25].Value?.ToString(),
                        growername = row.Cells[26].Value?.ToString(),

                        fecha = dateTimePicker_fecha.Value,

                        Hoja = hojaText,
                        NombreExcel = label_nombreExcel.Text,
                        Ruta = textRuta.Text,

                        Estado = "S",
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = ce_usuario.usecod,
                        UseElim = null
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
                // Mostrar solo el nombre del archivo Excel en el label
                label_nombreExcel.Text = Path.GetFileName(oOpenFileDialog.FileName);

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


        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            frm_EliminarLiquidacion frbm = new frm_EliminarLiquidacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }
    }


}
