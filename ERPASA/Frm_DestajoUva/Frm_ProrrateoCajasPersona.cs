using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Comercial;
using ERPASA.Msbox;
using ERPASA.Reportes.Acopio;
using ExcelDataReader;
using Ghostscript.NET;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;


namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_ProrrateoCajasPersona : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtgCierre;
        List<RegistroQR> lista = new List<RegistroQR>();
        DataTable dtgCampos;

        cn_packing objcnpack = new cn_packing();

        private List<bool> checkBoxStates = new List<bool>();
        DataTable dniTable = new DataTable();
        DataTable datosInsertados;
        DateTime fechaProc;
        string sessionId;

        public static DataTable dtgTodosCampos = new DataTable();

        private CancellationTokenSource _cts;


        public Frm_ProrrateoCajasPersona()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void Frm_ProrrateoCajasPersona_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            PonerOscuroComboBox();
            CargarDatosComboBox();
            guna2TextBox_Buscar.Text = guna2TextBox_Buscar.Text.ToUpper();
            guna2TextBox_Buscar.Focus();
            inicializarDtgCampos();
            comboBox_Cultivo.Text = "UVA";
        }

        public void inicializarDtgCampos()
        {
            dtgCampos = new DataTable();

            dtgCampos.Columns.Add("TramaReal", typeof(string));
            dtgCampos.Columns.Add("CodPre", typeof(int));
            dtgCampos.Columns.Add("Detalle", typeof(string));
            dtgCampos.Columns.Add("CodSticker", typeof(int));

        }

        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_linea.DropDownStyle = ComboBoxStyle.DropDownList;
            //DATAGRIDVIEW
        }


        public void CargarDatosComboBox()
        {
            comboBox_linea.DataSource = cn_packing.ListaLinea();
            comboBox_linea.DisplayMember = "Linea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_linea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void guna2TextBox_LecturaSticker_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "BUSCANDO REPORTE...";

            try
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.SuspendLayout();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }));

                // 1) Procesar datos sin tocar controles
                await Task.Run(() =>
                {
                    checkBox1.Invoke(new Action(() =>
                    {
                        checkBox1.Checked = false;
                    }));
                    BuscarReporteProrrateo();   // ❗ DEBE trabajar solo con dtg (DataTable)
                });

                // 2) Actualizar controles en UI thread
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dtg;
                    dataGridView1.AllowUserToAddRows = false;

                    // ✅ AGREGAR COLUMNA CHECKBOX
                    dataGridView1.ColumnHeaderMouseClick += (s, e) =>
                    {
                        if (dataGridView1.Columns[e.ColumnIndex].Name == "chkSeleccion")
                        {
                            bool marcarTodo = true;

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells["chkSeleccion"].Value is bool b && b)
                                {
                                    marcarTodo = false;
                                    break;
                                }
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                row.Cells["chkSeleccion"].Value = marcarTodo;
                            }
                        }
                    };

                    label_estado_reg.Text = "Registros: " + dtg.Rows.Count.ToString();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    // 🔓 Hacer todas las columnas editables

                    foreach (DataColumn column in dtg.Columns)
                    {
                        column.ReadOnly = false; // Deshabilita el solo lectura en todas las columnas
                    }
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                    }
                    // Habilitar la edición solo para la primera columna
                    if (dataGridView1.Columns.Count > 0)
                    {
                        dataGridView1.Columns[0].ReadOnly = false; // Permitir la edición solo de la primera columna
                    }

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.MinimumWidth = 100;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // CENTRAR VALORES
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // CENTRAR CABECERAS                        
                    }

                }));

                dataGridView1.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.ResumeLayout();
                }));
                Cursor.Current = Cursors.Default;
                frbm.Close();
            }
        }


        public void BuscarReporteProrrateo()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{

            string cultivoText = string.Empty, lineaText = string.Empty;

            string cultivo, linea;

            ////////////////////////////////////
            if (comboBox_Cultivo.InvokeRequired)
            {
                comboBox_Cultivo.Invoke(new MethodInvoker(() =>
                {
                    cultivoText = comboBox_Cultivo.Text;
                }));
            }
            else
            {
                cultivoText = comboBox_Cultivo.Text;
            }
            if (comboBox_linea.InvokeRequired)
            {
                comboBox_linea.Invoke(new MethodInvoker(() =>
                {
                    lineaText = comboBox_linea.Text;
                }));
            }
            else
            {
                lineaText = comboBox_linea.Text;
            }

            if (cultivoText == "SELECCIONE")
            {
                cultivo = "%";
            }
            else
            {
                cultivo = cultivoText;
            }
            if (lineaText == "SELECCIONE")
            {
                linea = "%";
            }
            else
            {
                linea = lineaText;
            }


            //dataGridView3.ReadOnly = true;

            var resultado = cn_planilla.ReporteProrrateoCajas(
    Fecha_Inicio.Value.Date, linea, cultivo);

            // Mostrar detalle en DataGridView
            dtg = resultado;
            /*
            dtg = cn_planilla.DestajoLecturaSticker(Fecha_Proceso.Value.Date
                , nave, linea);
            */
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string pres="", sel = "", pes = "", emp = "",session="";
            //if (e.RowIndex >= 0) // Asegura que no haga click en el header
            //{
            //    pres = 
            //        dataGridView1.Rows[e.RowIndex].Cells["CodPre"].Value?.ToString();
            //    TextBox_Presentacion.Text = pres;

            //    sel =
            //            dataGridView1.Rows[e.RowIndex].Cells["SecuenciaSel"].Value?.ToString();
            //    TextBox_Seleccion.Text = sel;

            //    pes =
            //        dataGridView1.Rows[e.RowIndex].Cells["SecuenciaPes"].Value?.ToString();
            //    TextBox_Pesado.Text = pes;

            //    emp =
            //        dataGridView1.Rows[e.RowIndex].Cells["SecuenciaEmp"].Value?.ToString();
            //    TextBox_Empaque.Text = emp;
            //    session =
            //        dataGridView1.Rows[e.RowIndex].Cells["SessionId"].Value?.ToString();
            //    label_SessionId.Text = session;
            //}

            //// Convertir a número
            //if (int.TryParse(pres, out int numPre))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Presentacion.Enabled = numPre <= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Presentacion.Enabled = true;
            //    TextBox_Presentacion.Equals("");
            //}
            //// Convertir a número
            //if (int.TryParse(sel, out int numSel))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Seleccion.Enabled = numSel <= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Seleccion.Enabled = true;
            //    TextBox_Seleccion.Equals("");
            //}// Convertir a número
            //if (int.TryParse(pes, out int numPes))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Pesado.Enabled = numPes <= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Pesado.Enabled = true;
            //    TextBox_Pesado.Text.Equals("");
            //}// Convertir a número
            //if (int.TryParse(emp, out int numEmp))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Empaque.Enabled = numEmp<= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Empaque.Enabled = true;
            //    TextBox_Empaque.Text.Equals("");
            //}
        }

        private void comboBox_linea_SelectedValueChanged(object sender, EventArgs e)
        {
            //CargarDatosSync();
            guna2TextBox_Buscar.Focus();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string value = cell.Value?.ToString().Trim();

            // ✔ Permitir editar SI:
            //   - está vacío
            //   - es exactamente "0"
            if (value == "0")
            {
                e.Cancel = false; // permitir edición
            }
            else
            {
                e.Cancel = true; // ❌ bloquear edición
            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y teclas de control (borrar, flechas, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // bloquea la tecla
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Fecha_Proceso_ValueChanged(object sender, EventArgs e)
        {
            guna2TextBox_Buscar.Focus();
            CargarDatosSync();
            //MessageBox.Show("Fecha de proceso cambiada a: " + Fecha_Proceso.Value.ToString("yyyy-MM-dd"));
        }

        private void comboBox_nave_SelectedValueChanged(object sender, EventArgs e)
        {
            guna2TextBox_Buscar.Focus();
        }

        private void pictureBox_agregarErrores_Click(object sender, EventArgs e)
        {

            ExportarExcel2();
        }

        private async void pictureBox_Search_Click(object sender, EventArgs e)
        {
            await CargarDatosSyncFechaProceso();

            if (dtgCierre == null || dtgCierre.Rows.Count == 0)
                return;

            bool procesoCerrado = dtgCierre.AsEnumerable()
                .Any(row =>
                    row.Field<DateTime>("FechaProceso").Date == Fecha_Inicio.Value.Date &&
                    row.Field<bool>("Estatus"));

            if (procesoCerrado)
            {
                var msg = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = "⚠️ EL PROCESO YA HA CERRADO PARA ESTA FECHA",
                    Caption = "Proceso Cerrado",
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
                };

                msg.Show();
                Fecha_Inicio.Value = DateTime.Now;
                return;
            }


            CargarDatosSync();
        }


        private async Task CargarDatosSyncFechaProceso()
        {
            try
            {
                await Task.Run(() =>
                {
                    BuscarReporteDestajo();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }



        public void BuscarReporteDestajo()
        {
            var resultado = cn_planilla.ReporteCierreProcesoDia(
                                        Fecha_Inicio.Value.Date);

            dtgCierre = resultado;

            // Imprimir el contenido del DataTable en consola
            ImprimirDataTable(dtgCierre);
        }

        private void ImprimirDataTable(DataTable dt)
        {
            // Verificar que el DataTable no sea nulo ni vacío
            if (dt == null || dt.Rows.Count == 0)
            {
                Console.WriteLine("El DataTable está vacío o es nulo.");
                return;
            }

            // Imprimir nombres de las columnas
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();  // Salto de línea después de los nombres de columnas

            // Imprimir los datos de las filas
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item.ToString() + "\t");
                }
                Console.WriteLine();  // Salto de línea después de cada fila
            }
        }


        private async void ExportarExcel2()
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
                        objexcel_progress.exportarexcelTimer(dataGridView1, frbm, token);
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

        private void guna2TextBox_LecturaSticker_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBox_Buscar.Text.Trim().Replace("'", "''");

            if (dtg != null)
            {
                DataView dv = dtg.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }

        private bool ValidarFilasCompletasDT1()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int filaVisible = row.Index + 1;

                    // Recorrer todas las celdas de la fila
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        var valor = row.Cells[i].FormattedValue?.ToString().Trim() ?? "";

                        if (string.IsNullOrEmpty(valor))
                        {
                            dataGridView1.CurrentCell = row.Cells[i];
                            MessageBox.Show(
                                $"La columna '{dataGridView1.Columns[i].HeaderText}' no puede estar vacía en la fila {filaVisible}.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning
                            );
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private async void pictureBox_prorrateo_usuarios_Click(object sender, EventArgs e)
        {

            await CargarDatosSyncFechaProceso();

            if (dtgCierre == null || dtgCierre.Rows.Count == 0)
                return;

            bool procesoCerrado = dtgCierre.AsEnumerable()
                .Any(row =>
                    row.Field<DateTime>("FechaProceso").Date == Fecha_Inicio.Value.Date &&
                    row.Field<bool>("Estatus"));

            if (procesoCerrado)
            {
                var msg = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = "⚠️ EL PROCESO YA HA CERRADO PARA ESTA FECHA",
                    Caption = "Proceso Cerrado",
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
                };

                msg.Show();
                Fecha_Inicio.Value = DateTime.Now;
                return;
            }

            int filas1 = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(p => Convert.ToBoolean(p.Cells[0].Value) == true)
                .Count();

            if (filas1 > 0)
            {
                if (ValidarFilasCompletasDT1())
                {
                    string MessageBoxTitle = "PRORRATEO";
                    string MessageBoxContent = "¿Desea distribuir cajas?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Msbox.frm_cargando frbm = new Msbox.frm_cargando();
                        //frbm.StartPosition = FormStartPosition.CenterParent;
                        frbm.Show(this); // Mostrar como formulario hijo
                        frbm.label1.Text = "DISTRIBUYENDO CAJAS...";

                        try
                        {
                            await GenerarDniPorCantidad();  // Espera a que termine
                            CargarDatosSync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al distribuir: " + ex.Message);
                        }
                        finally
                        {
                            dataGridView1.Invoke(new Action(() =>
                            {
                                dataGridView1.ResumeLayout();
                            }));
                            Cursor.Current = Cursors.Default;
                            frbm.Close();
                        }
                    }
                }
                else
                {
                    // ❌ Hay celdas vacías, se cancela el guardado
                }
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
            }
        }

        public async Task GenerarDniPorCantidad()
        {
            // Crear DataTable con las columnas necesarias
            dniTable = new DataTable();
            dniTable.Columns.Add("Fecha", typeof(string));
            dniTable.Columns.Add("Id", typeof(int));
            dniTable.Columns.Add("Dni", typeof(string));
            dniTable.Columns.Add("Tipo", typeof(string));
            dniTable.Columns.Add("Codigo", typeof(string));
            dniTable.Columns.Add("IdPre", typeof(string));
            dniTable.Columns.Add("Cantidad", typeof(int));

            // Iterar por las filas del DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    int cantidad = Convert.ToInt32(row.Cells[16].Value);

                    for (int i = 0; i < cantidad; i++)
                    {
                        dniTable.Rows.Add(
                            row.Cells[1].Value?.ToString(), //fecha
                            row.Cells[2].Value,             //id
                            row.Cells[8].Value?.ToString(), //dni
                            row.Cells[4].Value?.ToString(), //tipo selec,pes,emp
                            row.Cells[3].Value?.ToString(), //codigo
                            row.Cells[5].Value?.ToString(), //idPresentacion
                            cantidad                         // Cantidad = 1 por fila repetida
                        );
                    }
                }
            }

            string sessionId = Guid.NewGuid().ToString();
            await GuardarDatosSync(dniTable, sessionId);  // Asegurarse que se espera

            //Mensaje de resultado (si lo necesitas)
            //MessageBox.Show("Filas generadas: " + dniTable.Rows.Count);
        }

        private async Task GuardarDatosSync(DataTable table, string sessionId)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                await GuardarImpresionPersonasBulk(table, sessionId);  // Espera el método async
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

        public async Task GuardarImpresionPersonasBulk(DataTable table, string sessionId)
        {
            List<CeImpresionStickerPersona> listaTareo = ConvertirDataGridViewALista(table, sessionId);
            DataTable dt = ConvertirListaADataTable(listaTareo);

            cd_administracion datos = new cd_administracion();
            datos.GuardarStickerPersonasBulk(dt);

            // Obtener los datos insertados
            datosInsertados = datos.ObtenerStickersPorSessionId(sessionId);

            // Mostrar en consola
            Console.WriteLine("===== lista de usuarios =====");
            foreach (DataRow row in datosInsertados.Rows)
            {
                for (int i = 0; i < datosInsertados.Columns.Count; i++)
                {
                    Console.Write($"{datosInsertados.Columns[i].ColumnName}: {row[i]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("===================");

            //Mostrar en un DataGridView o retornarlo como prefieras
            // Por ejemplo:

            // Procesar los datos insertados de manera asíncrona
            await ProcesarDatosInsertados(datosInsertados);  // Espera este proceso antes de continuar
        }

        private async Task ProcesarDatosInsertados(DataTable datosInsertados)
        {
            lista.Clear(); // Limpiar lista antes de iniciar el proceso

            foreach (DataRow row in datosInsertados.Rows)
            {
                DateTime fechaProceso = Convert.ToDateTime(row["FecProceso"]);

                string idCodigo = row["IdCodigo"]?.ToString();
                string codigo = row["Codigo"]?.ToString();
                string id = row["Id"]?.ToString();

                if (string.IsNullOrEmpty(idCodigo) ||
                    string.IsNullOrEmpty(codigo) ||
                    string.IsNullOrEmpty(id))
                    continue;

                string trama = $"PR'{idCodigo}{codigo}'{id}";
                string sessionId = Guid.NewGuid().ToString(); // NUEVA SESSION por fila

                // Esperar por cada trama de manera asíncrona
                await SepararCamposDesdeTrama(trama, fechaProceso, sessionId);
            }
        }

        private async Task SepararCamposDesdeTrama(string trama, DateTime fechaProceso, string sessionId)
        {
            int codPre = 0;
            var matchPR = Regex.Match(trama, @"PR'(\d+)");
            if (matchPR.Success)
                codPre = int.Parse(matchPR.Groups[1].Value);

            // SM
            var matchSM = Regex.Match(trama, @"SM\d+'(\d+)");
            if (matchSM.Success)
            {
                int codSM = int.Parse(matchSM.Groups[1].Value);
                lista.Add(new RegistroQR
                {
                    TramaReal = trama,
                    CodPre = codPre,
                    Detalle = "Seleccion",
                    CodSticker = codSM,
                    FechaProceso = fechaProceso
                });
            }

            // PM
            var matchPM = Regex.Match(trama, @"PM\d+'(\d+)");
            if (matchPM.Success)
            {
                int codPM = int.Parse(matchPM.Groups[1].Value);
                lista.Add(new RegistroQR
                {
                    TramaReal = trama,
                    CodPre = codPre,
                    Detalle = "Pesado",
                    CodSticker = codPM,
                    FechaProceso = fechaProceso
                });
            }

            // EM
            var matchEM = Regex.Match(trama, @"EM\d+'(\d+)");
            if (matchEM.Success)
            {
                int codEM = int.Parse(matchEM.Groups[1].Value);
                lista.Add(new RegistroQR
                {
                    TramaReal = trama,
                    CodPre = codPre,
                    Detalle = "Empaque",
                    CodSticker = codEM,
                    FechaProceso = fechaProceso
                });
            }

            // Guardar la lista de esta fila con SU sessionId
            await GuardarDatosSyncSP(sessionId);  // Asegúrate de esperar aquí

            // Limpiar lista antes de procesar la siguiente fila
            lista.Clear();
        }

        private async Task GuardarDatosSyncSP(string sessionId)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Ejecutar el guardado de manera asincrónica
                await Task.Run(() =>
                {
                    GuardarLecturaStickerBulkSP(lista, sessionId);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void GuardarLecturaStickerBulkSP(List<RegistroQR> listaQR, string sessionId)
        {
            // 1. Convertir lista de RegistroQR a lista para BD
            List<ce_pedateosticker> listaBD = ConvertirDataTableAListaSP(listaQR, sessionId);

            // 2. Convertir lista a DataTable
            DataTable dt = ConvertirListaADataTable(listaBD);

            // 3. Guardar en BD
            cd_planilla datos = new cd_planilla();
            var resultado = datos.GuardarLecturaStickerBulkTVP(dt);

            // Mostrar en consola            
            Console.WriteLine("RETORNA " + resultado.Mensaje);

            //Mostrar en un DataGridView o retornarlo como prefieras
            // Por ejemplo:
            //// Opcional
            //Console.WriteLine("SessionId: " + resultado.SessionId);
            //Console.WriteLine("CadOriginal: " + resultado.CadOriginal);

        }


        public List<CeImpresionStickerPersona> ConvertirDataGridViewALista(DataTable dgv, string sessionId)
        {
            List<CeImpresionStickerPersona> lista = new List<CeImpresionStickerPersona>();

            foreach (DataRow row in dgv.Rows)
            {
                // No existe IsNewRow ni CheckBox directamente en DataTable.
                // Si tienes una columna booleana "Seleccionado" para filtrar, valida así:
                // if (row.Field<bool>("Seleccionado") == true)
                // Si no, procesa todas las filas o agrega tu lógica de filtrado aquí.

                CeImpresionStickerPersona entidad = new CeImpresionStickerPersona
                {
                    Id = 0,
                    // Cambiado: Fecha de proceso = columna 0 convertida a DateTime
                    FecProceso = row[0] != DBNull.Value ? Convert.ToDateTime(row[0]) : Convert.ToDateTime("2025-12-01").Date,

                    // Cambiado: IdGrupoPersona = columna 1 (Id)
                    IdGrupoPersona = row[1] != DBNull.Value ? Convert.ToInt32(row[1]) : (int?)null,

                    IdNave = "00",
                    Nave = "S/N",

                    IdLinea = "00",
                    Linea = "S/L",

                    // Cambiado: IdPuestoTrabajo = columna 2 (Dni) como string
                    IdPuestoTrabajo = "0",

                    // Cambiado: PuestoTrabajo = columna 2 (Dni) como string
                    PuestoTrabajo = row[3]?.ToString(),

                    // Cambiado: Dni = columna 2 (Dni) para mantener coherencia con datos
                    Dni = row[2]?.ToString(),

                    // Cambiado: IdCodigo = columna 3 (Tipo)
                    IdCodigo = row[5]?.ToString(),

                    // Cambiado: Codigo = columna 4 (Codigo)
                    Codigo = row[4]?.ToString(),

                    // Cambiado: Cantidad = columna 6 (Cantidad)
                    Cantidad = row[6] != DBNull.Value ? Convert.ToInt32(row[6]) : (int?)null,

                    Obs = "PRORRATEO SISTEMA",

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

        public List<ce_pedateosticker> ConvertirDataTableAListaSP(
    List<RegistroQR> lista,
    string sessionId)
        {
            List<ce_pedateosticker> listaBD = new List<ce_pedateosticker>();

            foreach (var item in lista)
            {
                listaBD.Add(new ce_pedateosticker
                {
                    FechaProceso = item.FechaProceso.ToString("yyyy-MM-dd"),

                    CadOriginal = item.TramaReal,
                    CodPreStick = item.CodPre,
                    DetGrupo = item.Detalle,
                    CodGrupoStick = item.CodSticker,

                    IdNave = 1,
                    Nave = "NAVE 01",
                    IdLinea = 3,
                    Linea = "Linea 03",

                    Obs = "PRORRATEO SISTEMA",
                    Estado = "S",

                    FecCre = ce_usuario.FechaSistema(),
                    UseReg = ce_usuario.usecod,
                    Hostname = ce_usuario.HostName(),
                    FecEdit = ce_usuario.FechaSistema(),
                    UseEdit = 0,
                    UseElim = 0,

                    SessionId = sessionId
                });
            }

            return listaBD;
        }

        /*
         public List<ce_pedateosticker> ConvertirDataTableAListaSP(List<RegistroQR> lista, string sessionId)
         {           
             List<ce_pedateosticker> listaBD = new List<ce_pedateosticker>();

             foreach (var item in lista)
             {
                 listaBD.Add(new ce_pedateosticker
                 {
                     FechaProceso = Fecha_Proceso.Value.ToString("yyyy-MM-dd"),
                     CadOriginal = item.TramaReal,
                     CodPreStick = item.CodPre,
                     DetGrupo = item.Detalle,
                     CodGrupoStick = item.CodSticker,
                     IdNave = idNave,
                     Nave = naveText,
                     IdLinea = idLinea,
                     Linea = lineaText,
                     Obs = "LECTURA SCANNER",
                     Estado = "S",
                     FecCre = ce_usuario.FechaSistema(),
                     UseReg = ce_usuario.usecod,
                     Hostname = ce_usuario.HostName(),
                     FecEdit = ce_usuario.FechaSistema(),
                     UseEdit = 0,
                     UseElim = 0,
                     SessionId = sessionId
                 });
             }

             return listaBD;
         }
         */

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clic en encabezados
            if (e.RowIndex < 0) return;

            // Primera columna (checkbox)
            int colCheck = 0;

            // Obtener el valor actual del checkbox
            bool valorActual = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[colCheck].Value);

            // Invertir el valor al hacer clic
            dataGridView1.Rows[e.RowIndex].Cells[colCheck].Value = !valorActual;
        }

        private async void Fecha_Inicio_ValueChanged(object sender, EventArgs e)
        {

            await CargarDatosSyncFechaProceso();

            if (dtgCierre == null || dtgCierre.Rows.Count == 0)
                return;

            bool procesoCerrado = dtgCierre.AsEnumerable()
                .Any(row =>
                    row.Field<DateTime>("FechaProceso").Date == Fecha_Inicio.Value.Date &&
                    row.Field<bool>("Estatus"));

            if (procesoCerrado)
            {
                var msg = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = "⚠️ EL PROCESO YA HA CERRADO PARA ESTA FECHA",
                    Caption = "Proceso Cerrado",
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
                };

                msg.Show();
                Fecha_Inicio.Value = DateTime.Now;
                return;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
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
    }
}
