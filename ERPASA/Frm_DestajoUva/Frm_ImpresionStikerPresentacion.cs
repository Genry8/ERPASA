using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using CrystalDecisions.CrystalReports.Engine;
using ERPASA.Msbox;
using ERPASA.Reportes;
using ERPASA.Reportes.Acopio;
using Google.Apis.Drive.v3.Data;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Printing;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Datamatrix;

namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_ImpresionStikerPresentacion : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_packing objcnpack = new cn_packing();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtgv;
        private CancellationTokenSource _cts;
        int cantRepite;

        cn_sst objcnsst = new cn_sst();
        string codImpresion, codQR;
        // Lista para almacenar los estados de los checkboxes (si están marcados o no)
        private List<bool> checkBoxStates = new List<bool>();

        DataTable dniTable = new DataTable();

        public Frm_ImpresionStikerPresentacion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dataGridView2.EditingControlShowing += dataGridView2_EditingControlShowing;
        }

        private void Frm_ImpresionStikerPresentacion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            CargarImpresoras();
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            comboBoxImpresoras.DropDownStyle = ComboBoxStyle.DropDownList;
            //DETALLE DE REPORTE
        }


        public void CargarDatosComboBox()
        {

        }

        private void CargarImpresoras()
        {
            comboBoxImpresoras.Items.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxImpresoras.Items.Add(printer);
            }

            if (comboBoxImpresoras.Items.Count > 0)
            {
                PrintDocument pd = new PrintDocument();
                comboBoxImpresoras.SelectedItem = pd.PrinterSettings.PrinterName;
            }
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }

        public void BuscarParaImprimirPresentacion(List<EmployeeAttendanceModel> lista)
        {
            DataTable dt = new DataTable();

            // Columna Check
            dt.Columns.Add("Selec", typeof(bool));

            // Mismas columnas que tu foto
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Cod", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Stickers", typeof(int));
            dt.Columns.Add("Tipo", typeof(string));
            //dt.Columns.Add("Cantidad", typeof(int)); // siempre 3

            // 1️⃣ Agrupación por Código
            var listaAgrupada = lista
                .GroupBy(x => x.Codigo)
                .Select((g, index) => new
                {
                    Id = index + 1,
                    Cod = g.Key,
                    Descripcion = g.First().Descripcion,

                    // 2️⃣ Une los tipos: "S,P,E"
                    Tipo = string.Join(",", g
                                .Select(t => t.TipoLectura)
                                .Distinct()),

                    // 3️⃣ Cantidad de filas = Stickers
                    Stickers = g.Count()

                    //Cantidad = 3
                })
                .ToList();

            // 4️⃣ Añadir filas al DataTable
            foreach (var item in listaAgrupada)
            {
                dt.Rows.Add(
                    false,              // Check
                    item.Id,
                    item.Cod,
                    item.Descripcion,
                    item.Stickers,
                    item.Tipo
                //item.Cantidad
                );
            }
            GuardarPresentacionBulk(dt);
            //dtg = dt;
            dtg = cn_planilla.DestajoPresentacion();
        }


        //dtg = cn_planilla.DestajoPresentacion();//dt;   // ← AQUÍ se llena tu DataGridView


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            CargarDatosSync();

        }

        private async void CargarDatosSync()
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (guna2TextBox_Cantidad.Text.Trim().Equals(""))
                {
                    MessageBox.Show("FALTA CANTIDAD");
                }
                else if (!int.TryParse(guna2TextBox_Cantidad.Text.Trim(), out int cantidad))
                {
                    MessageBox.Show("CANTIDAD INVÁLIDA");
                }
                else if (cantidad <= 0)
                {
                    MessageBox.Show("LA CANTIDAD DEBE SER MAYOR A CERO");
                }
                else
                {
                    checkBox1.Checked = false;
                    //CargarDatosSync();

                    Cursor.Current = Cursors.WaitCursor;
                    // Mostrar el formulario de carga de manera no modal
                    Msbox.frm_cargando frbm = new Msbox.frm_cargando();
                    //frbm.StartPosition = FormStartPosition.CenterParent;
                    frbm.Show(this); // Mostrar como formulario hijo

                    try
                    {
                        List<EmployeeAttendanceModel> lista = new List<EmployeeAttendanceModel>();

                        // Intentar obtener datos del API
                        try
                        {
                            var api = new cn_apiservices();
                            lista = await api.GetEmployeeAttendanceAsync();
                        }
                        catch (Exception apiEx)
                        {
                            // Si falla el API, solo mostrar mensaje pero continuar
                            //Console.WriteLine("Error al obtener datos del API: " + apiEx.Message);
                            lista = new List<EmployeeAttendanceModel>(); // lista vacía
                        }

                        // Llenar dtg con los datos del API (si hubo) o vacía
                        await Task.Run(async () =>
                        {
                            BuscarParaImprimirPresentacion(lista);
                            dataGridView2.ClearSelection();
                        });


                        // 3. Actualizar UI
                        dataGridView2.SuspendLayout();
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = dtg;
                        dataGridView2.AllowUserToAddRows = false;
                        //dataGridView2.Columns[4].Visible = false;
                        // Asegúrate de que la primera columna sea editable
                        // Establecer ReadOnly en false para permitir la edición de todas las columnas
                        // Asegúrate de que las columnas sean editables (ReadOnly = false)
                        foreach (DataColumn column in dtg.Columns)
                        {
                            column.ReadOnly = false; // Deshabilita el solo lectura en todas las columnas
                        }
                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                        }
                        // Habilitar la edición solo para la primera columna
                        if (dataGridView2.Columns.Count > 0)
                        {
                            dataGridView2.Columns[0].ReadOnly = false; // Permitir la edición solo de la primera columna
                        }

                        foreach (DataGridViewColumn col in dataGridView2.Columns)
                        {
                            col.MinimumWidth = 60;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //col.ReadOnly = true;
                        }

                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView2.AutoResizeColumns();

                        // 👉 Agregar nueva columna al final del DataTable
                        DataColumn nuevaColumna = new DataColumn("Cantidad", typeof(string));
                        nuevaColumna.DefaultValue = guna2TextBox_Cantidad.Text.ToString().Trim(); // Valor por defecto si lo deseas
                        nuevaColumna.ReadOnly = false;  // Asegúrate de que sea editable
                        dtg.Columns.Add(nuevaColumna);


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
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private async void ExportarExcel()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var frbm = new frm_dowloadExcel();

            frbm.OnCancelRequested = () =>
            {
                _cts?.Cancel();
            };

            frbm.Show(this);

            try
            {

                await Task.Run(() =>
                {
                    try
                    {
                        objexcel_progress.exportarexcelTimer(dataGridView2, frbm, token);
                    }
                    catch (OperationCanceledException)
                    {
                        // Re-lanzamos para que el catch externo lo maneje
                        throw;
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Exportación cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            //AlertaGuardarProgVolcado();
        }


        private async void GuardarDatosPresentacionSync(DataTable table
            , string sessionId, string nombreImpresora)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                await Task.Run(() =>
                {
                    GuardarImpresionPresentacionBulk(table, sessionId, nombreImpresora);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar datos repetidos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /*
        public void GuardarImpresionPersonasBulk(DataTable table)
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<CeImpresionStickerPresentacion> listaTareo = ConvertirDataGridViewALista(table);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_administracion datos = new cd_administracion();
            datos.GuardarStickerPersonasBulk(dt);
        }
        */

        public void GuardarImpresionPresentacionBulk(DataTable table
            , string sessionId, string nombreImpresora)
        {
            List<CeImpresionStickerPresentacion> listaTareo = ConvertirDataGridViewAListaPresentacion(table, sessionId);
            DataTable dt = ConvertirListaADataTable(listaTareo);

            cd_administracion datos = new cd_administracion();
            datos.GuardarStickerPresentacionBulk(dt);

            // 🔁 Obtener datos insertados y mostrarlos
            DataTable datosInsertados = datos.ObtenerStickersPresentacionSessionId(sessionId);


            datosInsertados = MultiplicarFilasPorCantidad(datosInsertados);

            //// Mostrar en consola
            //Console.WriteLine("===== lista de presentacion =====");
            //foreach (DataRow row in datosInsertados.Rows)
            //{
            //    for (int i = 0; i < datosInsertados.Columns.Count; i++)
            //    {
            //        Console.Write($"{datosInsertados.Columns[i].ColumnName}: {row[i]}\t");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("===================");

            //// Mostrar en un DataGridView o retornarlo como prefieras
            //// Por ejemplo:
            MostrarDatosPresentacionInsertadosParaImprimir(datosInsertados, nombreImpresora);
        }

        private DataTable MultiplicarFilasPorCantidad(DataTable dt)
        {
            DataTable resultado = dt.Clone(); // Copia estructura

            if (!resultado.Columns.Contains("IdUnico"))
                resultado.Columns.Add("IdUnico", typeof(int));

            int idUnico = 1;

            foreach (DataRow row in dt.Rows)
            {
                //int cantidad = Convert.ToInt32(row["cantidad"]);

                for (int i = 0; i < cantRepite; i++)
                {
                    DataRow nuevaFila = resultado.NewRow();

                    foreach (DataColumn col in dt.Columns)
                    {
                        nuevaFila[col.ColumnName] = row[col.ColumnName];
                    }

                    nuevaFila["IdUnico"] = idUnico++;
                    resultado.Rows.Add(nuevaFila);
                }
            }

            return resultado;
        }


        private async void MostrarDatosPresentacionInsertadosParaImprimir(DataTable datos, string nombreImpresora)
        {
            if (datos != null && datos.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;

                // Crear instancia del formulario de carga
                Msbox.frm_cargando frbm = null;

                // Mostrar el formulario en el hilo principal
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        frbm = new Msbox.frm_cargando();
                        frbm.Show(this); // Mostrar como formulario hijo
                        frbm.label1.Text = "IMPRIMIENDO..."; // imprimir
                    }));
                }
                else
                {
                    frbm = new Msbox.frm_cargando();
                    frbm.Show(this);
                    frbm.label1.Text = "IMPRIMIENDO..."; // imprimir
                }

                try
                {
                    // Procesar en segundo plano
                    await Task.Run(() =>
                    {
                        dtg = datos;
                        //// Actualizar el DataGridView en el hilo principal
                        //DataGridView1.Invoke(new Action(() =>
                        //{
                        //    DataGridView1.Columns.Clear();
                        //    DataGridView1.DataSource = dtg;
                        //    DataGridView1.AllowUserToAddRows = false;
                        //    DataGridView1.ClearSelection();
                        //}));
                    });

                    // Ejecutar en el hilo principal
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            ImprimirReportePresentacion(nombreImpresora);
                        }));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al devolver datos: " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;

                    // Cerrar el formulario de carga en el hilo principal
                    if (frbm != null)
                    {
                        if (frbm.InvokeRequired)
                        {
                            frbm.Invoke(new Action(() => frbm.Close()));
                        }
                        else
                        {
                            frbm.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos insertados.");
            }
        }

        public List<CeImpresionStickerPresentacion> ConvertirDataGridViewAListaPresentacion(DataTable dgv, string sessionId)
        {
            List<CeImpresionStickerPresentacion> lista = new List<CeImpresionStickerPresentacion>();

            foreach (DataRow row in dgv.Rows)
            {
                CeImpresionStickerPresentacion entidad = new CeImpresionStickerPresentacion
                {
                    Id = 0, // o 0 si necesitas que no sea null
                    IdPre = row[0] != DBNull.Value ? Convert.ToInt32(row[0]) : (int?)null,
                    Cod = row[1]?.ToString(),
                    Presentacion = row[2]?.ToString(),
                    Precio = row[3] != DBNull.Value ? Convert.ToDecimal(row[3]) : (decimal?)null,
                    Cantidad = row[4] != DBNull.Value ? Convert.ToInt32(row[4]) : (int?)null,
                    Obs = "--",
                    Estado = "S",

                    FecCre = ce_usuario.FechaSistema(),
                    UseReg = ce_usuario.usecod,
                    Hostname = ce_usuario.HostName(),

                    FecEdit = ce_usuario.FechaSistema(),
                    UseEdit = 0,
                    UseElim = 0,
                    SessionId = sessionId,
                };

                lista.Add(entidad);
            }


            return lista;
        }

        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {
                Type tipoColumna = propiedad.PropertyType;

                if (tipoColumna.IsGenericType && tipoColumna.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipoColumna = Nullable.GetUnderlyingType(tipoColumna);
                }

                dt.Columns.Add(propiedad.Name, tipoColumna);
            }

            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();
                foreach (var propiedad in propiedades)
                {
                    fila[propiedad.Name] = propiedad.GetValue(entidad) ?? DBNull.Value;
                }
                dt.Rows.Add(fila);
            }

            return dt;
        }



        public void GuardarPresentacionBulk(DataTable table)
        {
            List<ce_presetancion_destajo> listaTareo
                = ConvertirDataGridViewALista(table);
            DataTable dt = ConvertirListaADataTable(listaTareo);

            cd_administracion datos = new cd_administracion();
            datos.GuardarPresentacionBulk(dt);
        }

        public List<ce_presetancion_destajo> ConvertirDataGridViewALista
            (DataTable dgv)
        {
            List<ce_presetancion_destajo> lista = new List<ce_presetancion_destajo>();

            foreach (DataRow row in dgv.Rows)
            {
                ce_presetancion_destajo entidad = new ce_presetancion_destajo
                {
                    Id = row[1] != DBNull.Value ? Convert.ToInt32(row[1]) : (int?)null,
                    Cod = row[2]?.ToString(),
                    Descripcion = row[3]?.ToString(),
                    Cantidad = row[4] != DBNull.Value ? Convert.ToInt32(row[4]) : (int?)null,
                    Tipo = row[5]?.ToString(),
                    CodExtech = row[2]?.ToString(),
                    Precio = 0,
                    Obs = "--",
                    Estado = "S",

                    FecCre = ce_usuario.FechaSistema(),
                    UseReg = ce_usuario.usecod,
                    Hostname = ce_usuario.HostName(),

                    FecEdit = ce_usuario.FechaSistema(),
                    UseEdit = 0,
                    UseElim = 0,
                };

                lista.Add(entidad);
            }


            return lista;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (checkBox1.Checked == true)
                {
                    row.Cells[0].Value = true;
                }
                else
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            // Obtener el DataTable del dataGridView2
            DataTable dt = dataGridView2.DataSource as DataTable;

            if (dt != null)
            {
                DataView dv = dt.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Sin filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas de tipo string
                    var condiciones = dt.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Filtrar solo texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }

        private void toolStripButton_imprimir_Click_1(object sender, EventArgs e)
        {
            guna2TextBoxSearch.Focus();

            int filasSeleccionadas = dataGridView2.Rows.Cast<DataGridViewRow>()
                .Where(p => Convert.ToBoolean(p.Cells[0].Value) == true)
                .Count();

            if (filasSeleccionadas > 0)
            {
                GenerarPresentacionPorCantidad(comboBoxImpresoras.Text);
                //// Mostrar formulario de selección de impresora
                //using (FrmSeleccionImpresora frm = new FrmSeleccionImpresora())
                //{
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        string impresoraSeleccionada = frm.ImpresoraSeleccionada;

                //        // Genera los DNI como antes
                //        GenerarPresentacionPorCantidad(impresoraSeleccionada);

                //        // 🔥 Aquí llamas al nuevo método que imprime con DataMatrix
                //        //ImprimirReporteDestajo(impresoraSeleccionada);
                //    }
                //}
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
            }
        }


        /*
        private void toolStripButton_imprimir_Click_1(object sender, EventArgs e)
        {
            guna2TextBox_Cantidad.Focus();
            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > 0)
            {
                GenerarDniPorCantidad(nombreImpresora);
                //ImprimirReporteDestajo();
                //ImprimirReporteConSeleccionDeImpresora();
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
            }
        }
        */

        public void GenerarPresentacionPorCantidad(string nombreImpresora)
        {
            // Crear DataTable con las columnas necesarias
            dniTable = new DataTable();
            dniTable.Columns.Add("Id", typeof(int));         // o string, si tu Id es textual
            dniTable.Columns.Add("Codigo", typeof(string));
            dniTable.Columns.Add("Descripcion", typeof(string));
            dniTable.Columns.Add("Precio", typeof(decimal));
            dniTable.Columns.Add("Cantidad", typeof(int));

            // Iterar por las filas del DataGridView
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    // Suponiendo que las columnas están en estas posiciones:
                    // Id -> columna 1
                    // Dni -> columna 3
                    // Codigo -> columna 5
                    // Cantidad -> columna 4
                    cantRepite = Convert.ToInt32(row.Cells[6].Value);

                    for (int i = 0; i < 1; i++)
                    {
                        dniTable.Rows.Add(
                            row.Cells[1].Value //id
                        , row.Cells[2].Value?.ToString() //codigo
                        , row.Cells[3].Value?.ToString() //descripcion
                        , row.Cells[4].Value //Can Sticker
                        , 1
                        ); // Cantidad = 1 por fila repetida

                    }

                }
            }

            string sessionId = Guid.NewGuid().ToString();
            GuardarDatosPresentacionSync(dniTable, sessionId, nombreImpresora);

            //MessageBox.Show("Filas generadas: " + dniTable.Rows.Count);
            //GuardarDatosSync(dniTable);

        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 6)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(Cantidad_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(Cantidad_KeyPress);
                }
            }
        }

        private void Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Asegurarse que sea la columna "Cantidad"
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("La cantidad no puede estar vacía.");
                    e.Cancel = true;
                    return;
                }

                //if (!int.TryParse(e.FormattedValue.ToString(), out int cantidad) || cantidad <= 0)
                //{
                //    MessageBox.Show("La cantidad debe ser un número mayor a cero.");
                //    e.Cancel = true;
                //}
            }
        }

        private void guna2TextBox_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;  // Previene la entrada de caracteres no numéricos
            }
            // Verifica si se presionó Enter (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido "beep" al presionar Enter
                CargarDatosSync(); // Llama a tu método
                return;
            }
        }


        public void ImprimirReporteDestajoOF(string nombreImpresora)
        {
            if (!ImpresoraActiva(nombreImpresora))
            {
                MessageBox.Show("Impresora no encontrada o no está disponible/activa.",
                                "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // --- PREPARAR DATOS ---
                DataTable dtOrigen = dtg;
                DataSet_DestajoUva objDs = new DataSet_DestajoUva();
                DataTable tablaDestino = objDs.Tables[0];

                // Las columnas son las mismas que en el primer método, se deben adaptar según lo necesario.
                foreach (DataRow row in dtOrigen.Rows)
                {
                    string codImpresion = row[3].ToString().Trim();   // Código
                    string codQR = "PR-" + row[0].ToString().Trim();           // Correlativo (ID)

                    tablaDestino.Rows.Add(new object[]
                    {
                row[0],               // ID
                codImpresion,         // Código de impresión
                "",                   // DNI
                "",                   // Nave
                "",                   // Línea
                codQR,                // Correlativo
                "",                   // Fecha
                "PRE",                // Primera letra del puesto
                GenerarDataMatrix($"{codQR}") // Generar DataMatrix (byte[])
                    });
                }

                // --- CONFIGURAR CRYSTAL ---

                // Determinar el reporte a imprimir según el valor de la columna 4
                bool imprimirReporteDestPres3 = false;
                bool imprimirReporteDestPres2 = false;

                foreach (DataGridViewRow selectedRow in dataGridView2.Rows)
                {
                    if (Convert.ToBoolean(selectedRow.Cells[0].Value) == true) // Fila seleccionada
                    {
                        int valorColumna4 = Convert.ToInt32(selectedRow.Cells[4].Value);
                        if (valorColumna4 == 3)
                        {
                            imprimirReporteDestPres3 = true;
                            //break;  // No es necesario seguir verificando si ya encontramos un valor 3
                        }
                        else if (valorColumna4 == 2)
                        {
                            imprimirReporteDestPres2 = true;
                            //break;  // No es necesario seguir verificando si ya encontramos un valor 2
                        }
                    }
                }

                // Configurar el reporte correcto según el valor de la columna 4
                if (imprimirReporteDestPres3)
                {
                    using (var objCryRep = new Frm_DestajoUva.CrystalReportDestPres3())
                    {
                        objCryRep.Load(@"~\CrystalReportDestPres3.rpt");  // Ruta del reporte

                        // Asignar el DataSet al reporte
                        objCryRep.SetDataSource(objDs);

                        // Configurar la impresora
                        objCryRep.PrintOptions.PrinterName = nombreImpresora;
                        objCryRep.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;

                        // Asegurarse de usar la impresora real
                        objCryRep.PrintOptions.NoPrinter = false;

                        // Imprimir el reporte
                        objCryRep.PrintToPrinter(1, false, 0, 0);
                    }
                }
                else if (imprimirReporteDestPres2)
                {
                    using (var objCryRep = new Frm_DestajoUva.CrystalReportDestPres2())
                    {
                        objCryRep.Load(@"~\CrystalReportDestPres2.rpt");  // Ruta del reporte

                        // Asignar el DataSet al reporte
                        objCryRep.SetDataSource(objDs);

                        // Configurar la impresora
                        objCryRep.PrintOptions.PrinterName = nombreImpresora;
                        objCryRep.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;

                        // Asegurarse de usar la impresora real
                        objCryRep.PrintOptions.NoPrinter = false;

                        // Imprimir el reporte
                        objCryRep.PrintToPrinter(1, false, 0, 0);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna fila con el valor esperado en la columna 4 (2 o 3).",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message,
                                "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public byte[] GenerarDataMatrix(string texto)
        {
            var writer = new DataMatrixWriter();

            var matrix = writer.encode(texto,
                                       BarcodeFormat.DATA_MATRIX,
                                       0, 0);

            var barcodeWriter = new ZXing.BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 120,
                    Width = 120,
                    Margin = 0
                }
            };

            using (Bitmap img = barcodeWriter.Write(texto))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        public bool ImpresoraActiva(string nombreImpresora)
        {
            try
            {
                // 1. Validar si existe en la lista de impresoras instaladas
                bool existe = PrinterSettings.InstalledPrinters
                    .Cast<string>()
                    .Any(p => string.Equals(p, nombreImpresora, StringComparison.OrdinalIgnoreCase));

                if (!existe)
                    return false;

                // 2. Validar si la impresora está activa / online
                LocalPrintServer servidorImpresion = new LocalPrintServer();
                PrintQueue cola = servidorImpresion
                    .GetPrintQueues()
                    .FirstOrDefault(q => q.Name.Equals(nombreImpresora, StringComparison.OrdinalIgnoreCase));

                if (cola == null)
                    return false;

                cola.Refresh();

                // Verifica error, offline, sin papel, etc.
                bool estaCorrecta =
                    !cola.IsOffline &&
                    !cola.HasPaperProblem &&
                    !cola.IsDoorOpened &&
                    !cola.IsInError &&
                    !cola.NeedUserIntervention;

                return estaCorrecta;
            }
            catch
            {
                // Si ocurre cualquier error inesperado, devolvemos false
                return false;
            }
        }


        public void ImprimirReportePresentacion(string zebraIP)
        {
            List<StickerData> lista = new List<StickerData>();

            int colID = 0, colFecha = 1, colDNI = 9, colCod = 11;
            foreach (DataRow row in dtg.Rows)
            {

                string codImpresion = row[3].ToString().Trim();   // Código
                string codQR = "PR-" + row[0].ToString().Trim();           // Correlativo (ID)

                lista.Add(new StickerData
                {
                    Dni = row[colDNI].ToString().ToUpper(),                       // Para DataMatrix
                    Correlativo = row[colID].ToString(),                       // Para DataMatrix
                    DataMatrix = codQR,                       // Para DataMatrix
                    Codigo = "",         // Código visible
                    Numero = codImpresion // Puesto
                });
            }

            // Determinar el reporte a imprimir según el valor de la columna 4
            bool imprimirReporteDestPres3 = false;
            bool imprimirReporteDestPres2 = false;
            bool imprimirReporteDestPres1 = false;

            foreach (DataGridViewRow selectedRow in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(selectedRow.Cells[0].Value) == true) // Fila seleccionada
                {
                    int valorColumna4 = Convert.ToInt32(selectedRow.Cells[4].Value);
                    if (valorColumna4 == 3)
                    {
                        imprimirReporteDestPres3 = true;
                        //break;  // No es necesario seguir verificando si ya encontramos un valor 3
                    }
                    else if (valorColumna4 == 2)
                    {
                        imprimirReporteDestPres2 = true;
                        //break;  // No es necesario seguir verificando si ya encontramos un valor 2
                    }
                    else if (valorColumna4 == 1)
                    {
                        imprimirReporteDestPres1 = true;
                        //break;  // No es necesario seguir verificando si ya encontramos un valor 2
                    }
                }
            }

            // Configurar el reporte correcto según el valor de la columna 4
            if (imprimirReporteDestPres3)
            {
                string zpl = GenerarZPL_3Etiqueta(lista);

                ImprimirPorNombre(zebraIP, zpl);
            }
            else if (imprimirReporteDestPres2)
            {
                string zpl2 = GenerarZPL_2Etiqueta(lista);

                ImprimirPorNombre(zebraIP, zpl2);
            }
            else if (imprimirReporteDestPres1)
            {
                string zpl1 = GenerarZPL_1Etiqueta(lista);

                ImprimirPorNombre(zebraIP, zpl1);
            }
            else
            {
                MessageBox.Show("No se encontró ninguna fila con el valor esperado en la columna 4 (2 o 3).",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //ListarPuertosTCPIP();
            //EnviarZPL_porIP("10.51.51.17", 9100, zpl);
            //EnviarZPL_porIP(zebraIP, 9100, zpl);
        }

        public string ObtenerPuertoDeImpresora(string printerName)
        {
            try
            {
                string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName.Replace("\\", "\\\\")}'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject printer in searcher.Get())
                {
                    var portName = printer["PortName"]?.ToString();
                    if (!string.IsNullOrEmpty(portName))
                        return portName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obteniendo puerto de impresora: " + ex.Message);
            }
            return null;
        }

        public void ImprimirPorNombre(string printerName, string zpl, int puerto = 9100)
        {
            string ip = ObtenerPuertoDeImpresora(printerName);

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("No se pudo encontrar la IP de la impresora: " + printerName);
                return;
            }

            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ip, 7000); // Timeout = 2000 ms (2 segundos)

                    if (reply.Status != IPStatus.Success)
                    {
                        MessageBox.Show("La impresora: " + printerName + " no esta conectado");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la impresora: " + ex.Message);
                return;
            }

            // Si pasó el ping, enviamos el ZPL
            EnviarZPL_porIP(ip, puerto, zpl);
        }

        public void EnviarZPL_porIP(string ip, int puerto, string zpl)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect(ip, puerto);

                    using (var stream = client.GetStream())
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(zpl);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                }

                //MessageBox.Show("ZPL enviado a la Zebra correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando a la Zebra: " + ex.Message);
            }
        }


        public string GenerarZPL_3EtiquetaXX(List<StickerData> items)
        {
            StringBuilder zpl = new StringBuilder();

            foreach (var s in items)
            {
                zpl.Append("^XA\n");
                zpl.Append("^PW800\n");   // tamaño real 100mm = 800 dots
                zpl.Append("^LL400\n");   // tamaño real 50mm = 400 dots
                zpl.Append("^LH0,0\n");

                // ENCABEZADO
                zpl.Append("^FO40,40\n");
                zpl.Append("^A0N,40,40\n");
                zpl.Append($"^FD{s.Numero}^FS\n");

                // LETRAS S, P, E
                zpl.Append("^FO280,80\n^A0N,36,36\n^FDS^FS\n");
                zpl.Append("^FO500,80\n^A0N,36,36\n^FDP^FS\n");
                zpl.Append("^FO700,80\n^A0N,36,36\n^FDE^FS\n");

                // LÍNEAS VERTICALES
                zpl.Append("^FO390,80\n^GB3,280,3^FS\n");
                zpl.Append("^FO600,80\n^GB3,280,3^FS\n");

                // DATAMATRIX
                zpl.Append("^FO40,160\n");
                zpl.Append("^BXN,9,200\n");
                zpl.Append($"^FD{s.DataMatrix}^FS\n");

                // TEXTO DEBAJO DEL DATAMATRIX (Correlativo)
                zpl.Append("^FO60,340\n");  // <- POSICIÓN CORREGIDA
                zpl.Append("^A0B,26,26\n");
                zpl.Append($"^FD{s.Correlativo}^FS\n");

                zpl.Append("^XZ\n");
            }

            return zpl.ToString();
        }

        public string GenerarZPL_2EtiquetaXX(List<StickerData> items)
        {
            StringBuilder zpl = new StringBuilder();

            foreach (var s in items)
            {
                zpl.Append("^XA\n");
                zpl.Append("^PW800\n");   // tamaño real 100mm = 800 dots
                zpl.Append("^LL400\n");   // tamaño real 50mm = 400 dots
                zpl.Append("^LH0,0\n");

                // ENCABEZADO
                zpl.Append("^FO40,40\n");
                zpl.Append("^A0N,40,40\n");
                zpl.Append($"^FD{s.Numero}^FS\n");

                // LETRAS S, P, E
                //zpl.Append("^FO280,80\n^A0N,36,36\n^FDS^FS\n");
                zpl.Append("^FO400,80\n^A0N,36,36\n^FDP^FS\n");
                zpl.Append("^FO640,80\n^A0N,36,36\n^FDE^FS\n");

                // LÍNEAS VERTICALES
                //zpl.Append("^FO390,80\n^GB3,280,3^FS\n");
                zpl.Append("^FO540,80\n^GB3,280,3^FS\n");

                // DATAMATRIX
                zpl.Append("^FO40,160\n");
                zpl.Append("^BXN,8,200,0,0\n");
                zpl.Append($"^FD{s.DataMatrix}^FS\n");

                // TEXTO DEBAJO DEL DATAMATRIX (Correlativo)
                zpl.Append("^FO60,340\n");  // <- POSICIÓN CORREGIDA
                zpl.Append("^A0B,26,26\n");
                zpl.Append($"^FD{s.Correlativo}^FS\n");

                zpl.Append("^XZ\n");
            }

            return zpl.ToString();
        }

        public string GenerarZPL_3Etiqueta(List<StickerData> items)
        {
            StringBuilder zpl = new StringBuilder();

            foreach (var s in items)
            {
                zpl.Append("^XA\n");
                zpl.Append("^PW645\n");   // 76 mm
                zpl.Append("^LL423\n");   // 50 mm
                zpl.Append("^LH0,0\n");

                // ----------------------------------------
                // ENCABEZADO (REEMPLAZADO POR TU VARIABLE: Numero)
                // ----------------------------------------
                zpl.Append("^FO40,20\n");
                zpl.Append("^A0N,40,40\n");
                zpl.Append($"^FD{s.Numero}^FS\n");

                // ----------------------------------------
                // LETRAS S - P - E
                // ----------------------------------------
                zpl.Append("^FO180,80\n^A0N,36,36\n^FDS^FS\n");
                zpl.Append("^FO360,80\n^A0N,36,36\n^FDP^FS\n");
                zpl.Append("^FO540,80\n^A0N,36,36\n^FDE^FS\n");

                // ----------------------------------------
                // LÍNEAS VERTICALES
                // ----------------------------------------
                zpl.Append("^FO110,80\n^GB3,280,2^FS\n");     // Línea entre QR y S
                zpl.Append("^FO290,80\n^GB3,280,3^FS\n");     // Línea entre S y P
                zpl.Append("^FO460,80\n^GB3,280,3^FS\n");     // Línea entre P y E

                // ----------------------------------------
                // DATAMATRIX (abajo izquierda)
                // ----------------------------------------
                zpl.Append("^FO20,160\n");
                zpl.Append("^BXN,6,200\n");
                zpl.Append($"^FD{s.DataMatrix}^FS\n");

                // ----------------------------------------
                // NÚMERO PEQUEÑO DEBAJO DEL DATAMATRIX (como la foto)
                // ----------------------------------------
                zpl.Append("^FO60,300\n");
                zpl.Append("^A0B,26,26\n");
                zpl.Append($"^FD{s.Correlativo}^FS\n");

                zpl.Append("^XZ\n");
            }

            return zpl.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clic en encabezados
            if (e.RowIndex < 0) return;

            // Primera columna (checkbox)
            int colCheck = 0;

            // Obtener el valor actual del checkbox
            bool valorActual = Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[colCheck].Value);

            // Invertir el valor al hacer clic
            dataGridView2.Rows[e.RowIndex].Cells[colCheck].Value = !valorActual;
        }

        public string GenerarZPL_2Etiqueta(List<StickerData> items)
        {
            StringBuilder zpl = new StringBuilder();

            foreach (var s in items)
            {
                zpl.Append("^XA\n");
                zpl.Append("^PW645\n");   // 76 mm
                zpl.Append("^LL423\n");   // 50 mm
                zpl.Append("^LH0,0\n");

                // ----------------------------------------
                // ENCABEZADO (REEMPLAZADO POR TU VARIABLE: Numero)
                // ----------------------------------------
                zpl.Append("^FO40,20\n");
                zpl.Append("^A0N,40,40\n");
                zpl.Append($"^FD{s.Numero}^FS\n");

                // ----------------------------------------
                // LETRAS P - E
                // ----------------------------------------
                //zpl.Append("^FO200,80\n^A0N,36,36\n^FDS^FS\n");
                zpl.Append("^FO260,80\n^A0N,36,36\n^FDP^FS\n");
                zpl.Append("^FO520,80\n^A0N,36,36\n^FDE^FS\n");

                // ----------------------------------------
                // LÍNEAS VERTICALES
                // ----------------------------------------
                //zpl.Append("^FO240,80\n^GB3,280,3^FS\n");     // Línea entre S y P
                zpl.Append("^FO400,80\n^GB3,280,3^FS\n");     // Línea entre P y E

                // ----------------------------------------
                // DATAMATRIX (abajo izquierda)
                // ----------------------------------------
                zpl.Append("^FO40,160\n");
                zpl.Append("^BXN,9,200\n");
                zpl.Append($"^FD{s.DataMatrix}^FS\n");

                // ----------------------------------------
                // NÚMERO PEQUEÑO DEBAJO DEL DATAMATRIX (como la foto)
                // ----------------------------------------
                zpl.Append("^FO60,340\n");
                zpl.Append("^A0B,26,26\n");
                zpl.Append($"^FD{s.Correlativo}^FS\n");

                zpl.Append("^XZ\n");
            }

            return zpl.ToString();
        }

        public string GenerarZPL_1Etiqueta(List<StickerData> items)
        {
            StringBuilder zpl = new StringBuilder();

            foreach (var s in items)
            {
                zpl.Append("^XA\n");
                zpl.Append("^PW645\n");   // 76 mm
                zpl.Append("^LL423\n");   // 50 mm
                zpl.Append("^LH0,0\n");

                // ----------------------------------------
                // ENCABEZADO (REEMPLAZADO POR TU VARIABLE: Numero)
                // ----------------------------------------
                zpl.Append("^FO40,20\n");
                zpl.Append("^A0N,40,40\n");
                zpl.Append($"^FD{s.Numero}^FS\n");

                // ----------------------------------------
                // LETRAS S
                // ----------------------------------------
                zpl.Append("^FO380,80\n^A0N,36,36\n^FDS^FS\n");
                //zpl.Append("^FO260,80\n^A0N,36,36\n^FDP^FS\n");
                //zpl.Append("^FO520,80\n^A0N,36,36\n^FDE^FS\n");

                // ----------------------------------------
                // LÍNEAS VERTICALES
                // ----------------------------------------
                //zpl.Append("^FO240,80\n^GB3,280,3^FS\n");     // Línea entre S y P
                //zpl.Append("^FO400,80\n^GB3,280,3^FS\n");     // Línea entre P y E

                // ----------------------------------------
                // DATAMATRIX (abajo izquierda)
                // ----------------------------------------
                zpl.Append("^FO40,160\n");
                zpl.Append("^BXN,9,200\n");
                zpl.Append($"^FD{s.DataMatrix}^FS\n");

                // ----------------------------------------
                // NÚMERO PEQUEÑO DEBAJO DEL DATAMATRIX (como la foto)
                // ----------------------------------------
                zpl.Append("^FO60,340\n");
                zpl.Append("^A0B,26,26\n");
                zpl.Append($"^FD{s.Correlativo}^FS\n");

                zpl.Append("^XZ\n");
            }

            return zpl.ToString();
        }

    }
}
