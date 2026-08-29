using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Comercial;
using ERPASA.Msbox;
using ExcelDataReader;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_EnviarCuadreAExtech : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        List<RegistroQR> lista = new List<RegistroQR>();
        DataTable dtgCampos;


        public static DataTable dtgTodosCampos = new DataTable();

        private CancellationTokenSource _cts;


        public Frm_EnviarCuadreAExtech()
        {
            InitializeComponent();
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void Frm_EnviarCuadreAExtech_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            PonerOscuroComboBox();
            CargarDatosComboBox();
            guna2TextBox_Buscar.Text = guna2TextBox_Buscar.Text.ToUpper();
            guna2TextBox_Buscar.Focus();
            inicializarDtgCampos();
            //comboBox_nave.Text = "NAVE 01";
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
            ////ALTO RIESGO
            //comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_linea.DropDownStyle = ComboBoxStyle.DropDownList;
            ////DATAGRIDVIEW
        }


        public void CargarDatosComboBox()
        {
            //comboBox_linea.DataSource = cn_packing.ListaLinea();
            //comboBox_linea.DisplayMember = "Linea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_linea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            //comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
                    BuscarReporteDestajo();   // ❗ DEBE trabajar solo con dtg (DataTable)
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


        public void BuscarReporteDestajo()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{



            //dataGridView3.ReadOnly = true;

            var resultado = cn_planilla.ReporteDestajo(
    Fecha_Inicio.Value.Date, fecha_fin.Value.Date, "%", "%", "%", 2);

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

        private void pictureBox_Search_Click(object sender, EventArgs e)
        {
            CargarDatosSync();
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

        private async void pictureBox_enviardatos_Extech_Click(object sender, EventArgs e)
        {
            var api = new cn_apiservices();
            //var resp = await api.SendDestajoAsync(lista);
            var resp = await api.ConfirmarDestajoRecibido();

            await MigrarCajasExtech();
            //MigrarCajasExtechPRD();
        }

        //---=====================
        //--ENVIAR A --GET-- FC_ASA/received/destajo
        //--DESPUES ACEPTAR --POST-- FC_ASA/received/destajo/confirmar
        //--======================

        public async Task MigrarCajasExtech()
        {
            int filas1 = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(p => Convert.ToBoolean(p.Cells[0].Value) == true)
                .Count();

            if (filas1 > 0)
            {
                if (ValidarFilasCompletasDT1())
                {
                    dataGridView1.EndEdit();

                    var lista = ObtenerListaDesdeGrid();
                    //string resumen = GenerarResumenEnvio(lista);

                    //string MessageBoxTitle = "ENVIAR DATOS";
                    //string MessageBoxContent =
                    //    resumen + Environment.NewLine + Environment.NewLine +
                    //    "¿Desea enviar estos datos a Extech?";

                    var resumen = GenerarResumenEnvioGrid(lista);
                    AgregarFilaTotal(resumen);

                    using (var frm = new FrmResumenEnvio(resumen))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // 👉 AQUÍ haces el envío a Extech

                            //DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            //if (dialogResult == DialogResult.Yes)
                            //{
                            Cursor.Current = Cursors.WaitCursor;
                            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
                            //frbm.StartPosition = FormStartPosition.CenterParent;
                            frbm.Show(this); // Mostrar como formulario hijo
                            frbm.label1.Text = "ENVIANDO DATOS...";

                            try
                            {
                                await EnviarDatosApi();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al enviar: " + ex.Message);
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

        private void AgregarFilaTotal(List<ResumenEnvioDto> resumen)
        {
            if (resumen == null || resumen.Count == 0)
                return;

            resumen.Add(new ResumenEnvioDto
            {
                Fecha = null,
                Presentacion = "TOTAL",
                Seleccion = resumen.Sum(x => x.Seleccion),
                Pesado = resumen.Sum(x => x.Pesado),
                Empaque = resumen.Sum(x => x.Empaque)
            });
        }

        private List<ResumenEnvioDto> GenerarResumenEnvioGrid(List<ce_destajo_uva> lista)
        {
            return lista
                .Where(x => x.fecha.HasValue) // seguridad
                .GroupBy(x => new
                {
                    Fecha = x.fecha.Value.Date,   // 👈 SOLO DÍA
                    Presentacion = x.formato
                })
                .Select(g => new ResumenEnvioDto
                {
                    Fecha = g.Key.Fecha,
                    Presentacion = g.Key.Presentacion,
                    Seleccion = g.Count(x => x.grupo?.ToUpper() == "SELECCION"),
                    Pesado = g.Count(x => x.grupo?.ToUpper() == "PESADO"),
                    Empaque = g.Count(x => x.grupo?.ToUpper() == "EMPAQUE")
                })
                .OrderBy(x => x.Fecha)
                .ThenBy(x => x.Presentacion)
                .ToList();
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

        private async Task EnviarDatosApi()
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this);

            try
            {
                dataGridView1.EndEdit();

                var lista = ObtenerListaDesdeGrid();

                if (lista.Count == 0)
                {
                    MessageBox.Show("No hay datos para enviar");
                    return;
                }

                var api = new cn_apiservices();
                //var resp = await api.SendDestajoAsync(lista);
                var resp = await api.SendDestajoPorLotesAsync(lista);
                var datos = resp.Data;

                if (resp.Success && datos != null)
                {
                    int totalSeleccion = datos.Sum(x => x.Seleccion.Count);
                    int totalPesado = datos.Sum(x => x.Pesado.Count);
                    int totalEmpaque = datos.Sum(x => x.Empaque.Count);

                    MessageBox.Show(
                        $"✅ Envío correcto\n" +
                        $"Fechas procesadas: {datos.Count}\n" +
                        $"Seleccion: {totalSeleccion}\n" +
                        $"Pesado: {totalPesado}\n" +
                        $"Empaque: {totalEmpaque}"
                    );
                }

                else
                {
                    MessageBox.Show(
                        $"❌ Error al enviar:\n{resp.Message}\n\n" +
                        $"Detalle bruto de respuesta:\n{JsonConvert.SerializeObject(resp)}"
                    );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al enviar datos:\n" + ex.Message);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private List<ce_destajo_uva> ObtenerListaDesdeGrid()
        {
            List<ce_destajo_uva> lista = new List<ce_destajo_uva>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // 👉 VALIDAR CHECKBOX (columna 0)
                bool seleccionado = row.Cells[0].Value != null &&
                                    Convert.ToBoolean(row.Cells[0].Value);

                if (!seleccionado)
                    continue;

                lista.Add(new ce_destajo_uva
                {
                    fecha = Convert.ToDateTime(row.Cells["Fecha"].Value),
                    centro = Convert.ToInt32(row.Cells["Centro"].Value),
                    nave = Convert.ToInt32(row.Cells["Nave"].Value),
                    turno = row.Cells["Turno"].Value.ToString(),
                    materiaprima = Convert.ToInt32(row.Cells["MateriaPrima"].Value),
                    tipotareo = row.Cells["TipoTareo"].Value.ToString(),
                    grupo = row.Cells["Grupo"].Value.ToString(),
                    npersonal = row.Cells["NroPersonal"].Value.ToString(),
                    dni = row.Cells["DNI"].Value.ToString(),
                    apellidopaterno = row.Cells["ApellidoPaterno"].Value.ToString(),
                    apellidomaterno = row.Cells["ApellidoMaterno"].Value.ToString(),
                    nombres = row.Cells["Nombres"].Value.ToString(),
                    fechaingreso = Convert.ToDateTime(row.Cells["FechaIngreso"].Value),
                    formato = row.Cells["Formato"].Value.ToString(),
                    sticker = row.Cells["Sticker"].Value.ToString()
                });
            }

            return lista;
        }

        /// <summary>
        /// OTRA FORMA DE ENVIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>




        ///////////
        ////////////7

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

        private void pictureBox_EnviarExtechQA_Click(object sender, EventArgs e)
        {
            //MigrarCajasExtechQA();
            //MigrarCajasExtechPRD();
        }

        //---=====================
        //--ENVIAR A QA
        //--======================

        public void MigrarCajasExtechQA()
        {
            int filas1 = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(p => Convert.ToBoolean(p.Cells[0].Value) == true)
                .Count();

            if (filas1 > 0)
            {
                if (ValidarFilasCompletasDT1QA())
                {
                    dataGridView1.EndEdit();

                    var lista = ObtenerListaDesdeGridQA();
                    //string resumen = GenerarResumenEnvio(lista);

                    //string MessageBoxTitle = "ENVIAR DATOS";
                    //string MessageBoxContent =
                    //    resumen + Environment.NewLine + Environment.NewLine +
                    //    "¿Desea enviar estos datos a Extech?";

                    var resumen = GenerarResumenEnvioGridQA(lista);
                    AgregarFilaTotalQA(resumen);

                    using (var frm = new FrmResumenEnvio(resumen))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // 👉 AQUÍ haces el envío a Extech

                            //DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            //if (dialogResult == DialogResult.Yes)
                            //{
                            Cursor.Current = Cursors.WaitCursor;
                            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
                            //frbm.StartPosition = FormStartPosition.CenterParent;
                            frbm.Show(this); // Mostrar como formulario hijo
                            frbm.label1.Text = "ENVIANDO DATOS...";

                            try
                            {
                                EnviarDatosApiQA();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al enviar: " + ex.Message);
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

        private void AgregarFilaTotalQA(List<ResumenEnvioDto> resumen)
        {
            if (resumen == null || resumen.Count == 0)
                return;

            resumen.Add(new ResumenEnvioDto
            {
                Fecha = null,
                Presentacion = "TOTAL",
                Seleccion = resumen.Sum(x => x.Seleccion),
                Pesado = resumen.Sum(x => x.Pesado),
                Empaque = resumen.Sum(x => x.Empaque)
            });
        }

        private List<ResumenEnvioDto> GenerarResumenEnvioGridQA(List<ce_destajo_uva> lista)
        {
            return lista
                .GroupBy(x => new
                {
                    Fecha = x.fecha?.Date,
                    Presentacion = x.formato
                })
                .Select(g => new ResumenEnvioDto
                {
                    Fecha = g.Key.Fecha,
                    Presentacion = g.Key.Presentacion,
                    Seleccion = g.Count(x => x.grupo?.ToUpper() == "SELECCION"),
                    Pesado = g.Count(x => x.grupo?.ToUpper() == "PESADO"),
                    Empaque = g.Count(x => x.grupo?.ToUpper() == "EMPAQUE")
                })
                .OrderBy(x => x.Fecha)
                .ThenBy(x => x.Presentacion)
                .ToList();
        }

        private bool ValidarFilasCompletasDT1QA()
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

        /*
        private async Task EnviarDatosApiQA()
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this);
            frbm.label1.Text = "ENVIANDO DATOS...";

            try
            {
                dataGridView1.EndEdit();

                var lista = ObtenerListaDesdeGridQA();

                if (lista.Count == 0)
                {
                    MessageBox.Show("No hay datos para enviar");
                    return;
                }

                var api = new cn_apiservices();
                var resp = await api.SendDestajoAsyncQA(lista);
                var datos = resp.Data;

                if (resp.Success)
                {
                    MessageBox.Show("✅ Enviado a Extech QA");

                    var api2 = new cn_apiservices();

                    // 1️⃣ Leer datos recibidos
                    var recibidos = await api2.GetDestajoRecibido();

                    if (!recibidos.Success || recibidos.Data == null)
                    {
                        MessageBox.Show("❌ Error al obtener datos de Extech");
                        return;
                    }

                    var listaIndustrial = ConvertirTareoAListaIndustrial(recibidos.Data);

                    if (listaIndustrial.Count == 0)
                    {
                        MessageBox.Show("⚠️ No hay registros para enviar a Industrial");
                        return;
                    }

                    var envioIndustrial = await api2.SendDestajoIndustrialAsyncQA(recibidos.Data);

                    if (envioIndustrial != null)
                    {
                        if (envioIndustrial.Success)
                        {
                            MessageBox.Show("✅ Enviado correctamente a Industrial");
                            await api2.ConfirmarDestajoRecibido();
                        }
                        else
                        {
                            MessageBox.Show(
                                "⚠️ Error desde Industrial\n\n" +
                                $"StatusCode: {envioIndustrial.StatusCode}\n\n" +
                                $"Respuesta completa:\n{envioIndustrial.RawResponse}"
                            );
                            await api2.ConfirmarDestajoRecibido();
                        }
                    }
                    else
                    {
                        MessageBox.Show("❌ Respuesta nula desde Industrial");
                        await api2.ConfirmarDestajoRecibido();
                    }


                }

                else
                {
                    MessageBox.Show(
                        $"❌ Error al enviar:\n{resp.Message}\n\n" +
                        $"Detalle bruto de respuesta:\n{JsonConvert.SerializeObject(resp)}"
                    );

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al enviar datos:\n" + ex.Message);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        */

        private async Task EnviarDatosApiQA()
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this);
            frbm.label1.Text = "ENVIANDO DATOS...";

            try
            {
                dataGridView1.EndEdit();

                // 1️⃣ Obtener datos desde el Grid
                var lista = ObtenerListaDesdeGridQA();

                if (lista.Count == 0)
                {
                    MessageBox.Show("No hay datos para enviar");
                    return;
                }

                var api = new cn_apiservices();

                // 2️⃣ Enviar a Extech QA
                var resp = await api.SendDestajoAsyncQA(lista);

                if (!resp.Success)
                {
                    MessageBox.Show(
                        $"❌ Error al enviar a Extech QA:\n{resp.Message}\n\n" +
                        $"Detalle bruto de respuesta:\n{JsonConvert.SerializeObject(resp)}"
                    );
                    return;
                }

                MessageBox.Show("✅ Enviado correctamente a Extech QA");

                // 3️⃣ Obtener los datos recibidos de Extech
                var recibidos = await api.GetDestajoRecibido();

                if (!recibidos.Success || recibidos.Data == null || recibidos.Data.Count == 0)
                {
                    MessageBox.Show("⚠️ No hay datos recibidos de Extech QA");
                    return;
                }

                // 4️⃣ Convertir a formato Industrial (si necesitas, aunque tu método lo hace plano)
                var listaIndustrial = ConvertirTareoAListaIndustrial(recibidos.Data);

                if (listaIndustrial.Count == 0)
                {
                    MessageBox.Show("⚠️ No hay registros para enviar a Industrial");
                    return;
                }

                // 5️⃣ Enviar **una fecha por request** a Industrial
                var api2 = new cn_apiservices();

                foreach (var tareo in recibidos.Data)
                {
                    var envioIndustrial = await api2.SendDestajoIndustrialAsyncQA(tareo);

                    if (envioIndustrial.Success)
                    {
                        MessageBox.Show($"✅ Fecha {tareo.Fecha:yyyy-MM-dd} enviada correctamente a Industrial");
                    }
                    else
                    {
                        MessageBox.Show(
                            $"⚠️ Error enviando fecha {tareo.Fecha:yyyy-MM-dd} a Industrial\n" +
                            $"StatusCode: {envioIndustrial.StatusCode}\n" +
                            $"Respuesta completa:\n{envioIndustrial.RawResponse}"
                        );
                    }
                }

                // 6️⃣ Confirmar recepción de Extech QA
                await api2.ConfirmarDestajoRecibido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al enviar datos:\n" + ex.Message);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }


        private List<ce_destajo_uva> ObtenerListaDesdeGridQA()
        {
            List<ce_destajo_uva> lista = new List<ce_destajo_uva>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // 👉 VALIDAR CHECKBOX (columna 0)
                bool seleccionado = row.Cells[0].Value != null &&
                                    Convert.ToBoolean(row.Cells[0].Value);

                if (!seleccionado)
                    continue;

                lista.Add(new ce_destajo_uva
                {
                    fecha = Convert.ToDateTime(row.Cells["Fecha"].Value),
                    centro = Convert.ToInt32(row.Cells["Centro"].Value),
                    nave = Convert.ToInt32(row.Cells["Nave"].Value),
                    turno = row.Cells["Turno"].Value.ToString(),
                    materiaprima = Convert.ToInt32(row.Cells["MateriaPrima"].Value),
                    tipotareo = row.Cells["TipoTareo"].Value.ToString(),
                    grupo = row.Cells["Grupo"].Value.ToString(),
                    npersonal = row.Cells["NroPersonal"].Value.ToString(),
                    dni = row.Cells["DNI"].Value.ToString(),
                    apellidopaterno = row.Cells["ApellidoPaterno"].Value.ToString(),
                    apellidomaterno = row.Cells["ApellidoMaterno"].Value.ToString(),
                    nombres = row.Cells["Nombres"].Value.ToString(),
                    fechaingreso = Convert.ToDateTime(row.Cells["FechaIngreso"].Value),
                    formato = row.Cells["Formato"].Value.ToString(),
                    sticker = row.Cells["Sticker"].Value.ToString()
                });
            }

            return lista;
        }

        private List<ce_destajo_uva> ConvertirTareoAListaIndustrial(List<ce_tareo_api> data)
        {
            var lista = new List<ce_destajo_uva>();

            if (data == null || data.Count == 0)
                return lista;

            foreach (var tareo in data)
            {
                void Agregar(List<ce_trabajador> origen, string grupo)
                {
                    if (origen == null) return;

                    foreach (var t in origen)
                    {
                        lista.Add(new ce_destajo_uva
                        {
                            fecha = tareo.Fecha,
                            centro = tareo.Centro,
                            nave = tareo.Nave,
                            turno = tareo.Turno,
                            materiaprima = tareo.MateriaPrima,
                            tipotareo = tareo.TipoTareo,
                            grupo = grupo,
                            npersonal = t.NroPersonal,
                            dni = t.DNI,
                            apellidopaterno = t.ApellidoPaterno,
                            apellidomaterno = t.ApellidoMaterno,
                            nombres = t.Nombres,
                            fechaingreso = t.FechaIngreso,
                            formato = t.Formato,
                            sticker = t.Sticker
                        });
                    }
                }

                Agregar(tareo.Seleccion, "SELECCION");
                Agregar(tareo.Pesado, "PESADO");
                Agregar(tareo.Empaque, "EMPAQUE");
            }

            return lista;
        }


        //---=====================
        //--ENVIAR A PRODUCCION
        //--======================
        public void MigrarCajasExtechPRD()
        {
            int filas1 = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(p => Convert.ToBoolean(p.Cells[0].Value) == true)
                .Count();

            if (filas1 > 0)
            {
                if (ValidarFilasCompletasDT1PRD())
                {
                    dataGridView1.EndEdit();

                    var lista = ObtenerListaDesdeGridPRD();
                    //string resumen = GenerarResumenEnvio(lista);

                    //string MessageBoxTitle = "ENVIAR DATOS";
                    //string MessageBoxContent =
                    //    resumen + Environment.NewLine + Environment.NewLine +
                    //    "¿Desea enviar estos datos a Extech?";

                    var resumen = GenerarResumenEnvioGridPRD(lista);
                    AgregarFilaTotalPRD(resumen);

                    using (var frm = new FrmResumenEnvio(resumen))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // 👉 AQUÍ haces el envío a Extech

                            //DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            //if (dialogResult == DialogResult.Yes)
                            //{
                            Cursor.Current = Cursors.WaitCursor;
                            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
                            //frbm.StartPosition = FormStartPosition.CenterParent;
                            frbm.Show(this); // Mostrar como formulario hijo
                            frbm.label1.Text = "ENVIANDO DATOS...";

                            try
                            {
                                EnviarDatosApiPRD();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al enviar: " + ex.Message);
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

        private void AgregarFilaTotalPRD(List<ResumenEnvioDto> resumen)
        {
            if (resumen == null || resumen.Count == 0)
                return;

            resumen.Add(new ResumenEnvioDto
            {
                Fecha = null,
                Presentacion = "TOTAL",
                Seleccion = resumen.Sum(x => x.Seleccion),
                Pesado = resumen.Sum(x => x.Pesado),
                Empaque = resumen.Sum(x => x.Empaque)
            });
        }

        private List<ResumenEnvioDto> GenerarResumenEnvioGridPRD(List<ce_destajo_uva> lista)
        {
            return lista
                .GroupBy(x => new
                {
                    Fecha = x.fecha?.Date,
                    Presentacion = x.formato
                })
                .Select(g => new ResumenEnvioDto
                {
                    Fecha = g.Key.Fecha,
                    Presentacion = g.Key.Presentacion,
                    Seleccion = g.Count(x => x.grupo?.ToUpper() == "SELECCION"),
                    Pesado = g.Count(x => x.grupo?.ToUpper() == "PESADO"),
                    Empaque = g.Count(x => x.grupo?.ToUpper() == "EMPAQUE")
                })
                .OrderBy(x => x.Fecha)
                .ThenBy(x => x.Presentacion)
                .ToList();
        }

        private bool ValidarFilasCompletasDT1PRD()
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

        private async Task EnviarDatosApiPRD()
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this);
            frbm.label1.Text = "ENVIANDO DATOS...";

            try
            {
                dataGridView1.EndEdit();

                // 1️⃣ Obtener datos desde el Grid
                var lista = ObtenerListaDesdeGridPRD();

                if (lista.Count == 0)
                {
                    MessageBox.Show("No hay datos para enviar");
                    return;
                }

                var api = new cn_apiservices();

                // 2️⃣ Enviar a Extech QA
                var resp = await api.SendDestajoAsyncPRD(lista);

                if (!resp.Success)
                {
                    MessageBox.Show(
                        $"❌ Error al enviar a Extech QA:\n{resp.Message}\n\n" +
                        $"Detalle bruto de respuesta:\n{JsonConvert.SerializeObject(resp)}"
                    );
                    return;
                }

                MessageBox.Show("✅ Enviado correctamente a Extech QA");

                // 3️⃣ Obtener los datos recibidos de Extech
                var recibidos = await api.GetDestajoRecibido();

                if (!recibidos.Success || recibidos.Data == null || recibidos.Data.Count == 0)
                {
                    MessageBox.Show("⚠️ No hay datos recibidos de Extech QA");
                    return;
                }

                // 4️⃣ Convertir a formato Industrial (si necesitas, aunque tu método lo hace plano)
                var listaIndustrial = ConvertirTareoAListaIndustrial(recibidos.Data);

                if (listaIndustrial.Count == 0)
                {
                    MessageBox.Show("⚠️ No hay registros para enviar a Industrial");
                    return;
                }

                // 5️⃣ Enviar **una fecha por request** a Industrial
                var api2 = new cn_apiservices();

                foreach (var tareo in recibidos.Data)
                {
                    var envioIndustrial = await api2.SendDestajoIndustrialAsyncPRD(tareo);

                    if (envioIndustrial.Success)
                    {
                        MessageBox.Show($"✅ Fecha {tareo.Fecha:yyyy-MM-dd} enviada correctamente a Industrial");
                    }
                    else
                    {
                        MessageBox.Show(
                            $"⚠️ Error enviando fecha {tareo.Fecha:yyyy-MM-dd} a Industrial\n" +
                            $"StatusCode: {envioIndustrial.StatusCode}\n" +
                            $"Respuesta completa:\n{envioIndustrial.RawResponse}"
                        );
                    }
                }

                // 6️⃣ Confirmar recepción de Extech QA
                await api2.ConfirmarDestajoRecibido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al enviar datos:\n" + ex.Message);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }


        private List<ce_destajo_uva> ObtenerListaDesdeGridPRD()
        {
            List<ce_destajo_uva> lista = new List<ce_destajo_uva>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // 👉 VALIDAR CHECKBOX (columna 0)
                bool seleccionado = row.Cells[0].Value != null &&
                                    Convert.ToBoolean(row.Cells[0].Value);

                if (!seleccionado)
                    continue;

                lista.Add(new ce_destajo_uva
                {
                    fecha = Convert.ToDateTime(row.Cells["Fecha"].Value),
                    centro = Convert.ToInt32(row.Cells["Centro"].Value),
                    nave = Convert.ToInt32(row.Cells["Nave"].Value),
                    turno = row.Cells["Turno"].Value.ToString(),
                    materiaprima = Convert.ToInt32(row.Cells["MateriaPrima"].Value),
                    tipotareo = row.Cells["TipoTareo"].Value.ToString(),
                    grupo = row.Cells["Grupo"].Value.ToString(),
                    npersonal = row.Cells["NroPersonal"].Value.ToString(),
                    dni = row.Cells["DNI"].Value.ToString(),
                    apellidopaterno = row.Cells["ApellidoPaterno"].Value.ToString(),
                    apellidomaterno = row.Cells["ApellidoMaterno"].Value.ToString(),
                    nombres = row.Cells["Nombres"].Value.ToString(),
                    fechaingreso = Convert.ToDateTime(row.Cells["FechaIngreso"].Value),
                    formato = row.Cells["Formato"].Value.ToString(),
                    sticker = row.Cells["Sticker"].Value.ToString()
                });
            }

            return lista;
        }


    }
}
