using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using DocumentFormat.OpenXml.Spreadsheet;
using ERPASA.Frm_Comercial;
using ERPASA.Msbox;
using ExcelDataReader;
using Guna.UI2.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_ReporteDestajo : Form
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


        public Frm_ReporteDestajo()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void Frm_ReporteDestajo_Load(object sender, EventArgs e)
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
            //ALTO RIESGO
            comboBox_nave.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_linea.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Puestotrabajo.DropDownStyle = ComboBoxStyle.DropDownList;
            //DATAGRIDVIEW
        }


        public void CargarDatosComboBox()
        {
            comboBox_nave.DataSource = cn_packing.ListaNave();
            comboBox_nave.DisplayMember = "Nave"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_nave.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_linea.DataSource = cn_packing.ListaLinea();
            comboBox_linea.DisplayMember = "Linea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_linea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Puestotrabajo.DataSource = cn_packing.ListaPuestoTrabajo();
            comboBox_Puestotrabajo.DisplayMember = "PuestoTrabajo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Puestotrabajo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
                    BuscarReporteDestajo();   // ❗ DEBE trabajar solo con dtg (DataTable)
                });

                // 2) Actualizar controles en UI thread
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dtg;
                    dataGridView1.AllowUserToAddRows = false;

                    label_estado_reg.Text = "Registros: " + dtg.Rows.Count.ToString();
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    // 🔓 Hacer todas las columnas editables

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.MinimumWidth = 80;
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

            string naveText = string.Empty, lineaText = string.Empty
                , trabajoText = string.Empty;
            string nave, linea, trabajo;

            ////////////////////////////////////
            if (comboBox_nave.InvokeRequired)
            {
                comboBox_nave.Invoke(new MethodInvoker(() =>
                {
                    naveText = comboBox_nave.Text;
                }));
            }
            else
            {
                naveText = comboBox_nave.Text;
            }
            ////////////////////////////////////
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
            ////////////////////////////////////
            if (comboBox_Puestotrabajo.InvokeRequired)
            {
                comboBox_Puestotrabajo.Invoke(new MethodInvoker(() =>
                {
                    trabajoText = comboBox_Puestotrabajo.Text;
                }));
            }
            else
            {
                trabajoText = comboBox_Puestotrabajo.Text;
            }


            if (naveText == "SELECCIONE")
            {
                nave = "%";
            }
            else
            {
                nave = naveText;
            }
            if (lineaText == "SELECCIONE")
            {
                linea = "%";
            }
            else
            {
                linea = lineaText;
            }
            if (trabajoText == "SELECCIONE")
            {
                trabajo = "%";
            }
            else
            {
                trabajo = trabajoText;
            }

            //dataGridView3.ReadOnly = true;

            var resultado = cn_planilla.ReporteDestajo(
    Fecha_Inicio.Value.Date, Fecha_Fin.Value.Date, nave, linea, trabajo, 1);

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
            TextBox txt = e.Control as TextBox;
            if (txt != null)
            {
                txt.KeyPress -= Txt_KeyPress; // evitar múltiples suscripciones
                txt.KeyPress += Txt_KeyPress;
            }
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

        private void pictureBox_Imprimir_Click(object sender, EventArgs e)
        {
            ExportarExcel3();
        }

        private async void ExportarExcel3()
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
                        exportarExcelDinamico(frbm, token);
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

        public void exportarExcelDinamico()
        {
            // Licencia EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // =========================
            // 1. Obtener datos del DataGridView
            // =========================
            var data = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new
                {
                    Puesto = r.Cells["PuestoTrabajo"].Value?.ToString(),
                    Formato = r.Cells["Formato"].Value?.ToString(),
                    Persona = r.Cells["ApeNom"].Value?.ToString(),
                    Avance = Convert.ToInt32(r.Cells["Avance"].Value ?? 0)
                })
                .ToList();

            if (!data.Any())
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            // =========================
            // 2. Estructura dinámica
            // =========================
            var puestos = data
                .GroupBy(x => x.Puesto)
                .Select(g => new
                {
                    Puesto = g.Key,
                    Formatos = g.Select(x => x.Formato).Distinct().OrderBy(x => x).ToList()
                })
                .ToList();

            var personas = data
                .Select(x => x.Persona)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            // =========================
            // 3. Crear Excel
            // =========================
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("AVANCE");

                // =========================
                // 4. Título con Fecha (FEC INI)
                // =========================
                int rowTitle = 1;
                int colTitle = 1;

                worksheet.Cells[rowTitle, colTitle].Value = "AVANCE TOTAL POR LABOR INCLUYE PRORRATEO DEL " + DateTime.Now.ToString("dd/MM/yyyy");
                worksheet.Cells[rowTitle, colTitle, rowTitle, colTitle + puestos.Sum(p => p.Formatos.Count) - 1].Merge = true;
                worksheet.Cells[rowTitle, colTitle].Style.Font.Bold = true;
                worksheet.Cells[rowTitle, colTitle].Style.Font.Size = 14;
                worksheet.Cells[rowTitle, colTitle].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[rowTitle, colTitle].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[rowTitle, colTitle].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[rowTitle, colTitle].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                worksheet.Row(rowTitle).Height = 30; // Ajuste de altura para el título

                // =========================
                // 5. Encabezado PERSONA
                // =========================
                int rowHeader1 = 2; // Puesto
                int rowHeader2 = 3; // Formato
                int colStart = 2;   // Columna 1 es Persona

                worksheet.Cells[rowHeader1, 1, rowHeader2, 1].Merge = true;
                worksheet.Cells[rowHeader1, 1].Value = "PERSONA";
                worksheet.Cells[rowHeader1, 1].Style.Font.Bold = true;
                worksheet.Cells[rowHeader1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[rowHeader1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                int currentCol = colStart;

                // =========================
                // 6. Encabezados Puesto / Formato
                // =========================
                foreach (var p in puestos)
                {
                    int startCol = currentCol;

                    foreach (var f in p.Formatos)
                    {
                        worksheet.Cells[rowHeader2, currentCol].Value = f;
                        worksheet.Cells[rowHeader2, currentCol].Style.Font.Bold = true;
                        worksheet.Cells[rowHeader2, currentCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[rowHeader2, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        // Color de fondo para las secciones (EMPAQUE, PESADO, SELECCIÓN)
                        if (p.Puesto == "EMPAQUE")
                        {
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                        }
                        else if (p.Puesto == "PESADO")
                        {
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        }
                        else if (p.Puesto == "SELECCIÓN")
                        {
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        }

                        currentCol++;
                    }

                    worksheet.Cells[rowHeader1, startCol, rowHeader1, currentCol - 1].Merge = true;
                    worksheet.Cells[rowHeader1, startCol].Value = p.Puesto;
                    worksheet.Cells[rowHeader1, startCol].Style.Font.Bold = true;
                    worksheet.Cells[rowHeader1, startCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[rowHeader1, startCol, rowHeader1, currentCol - 1]
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // =========================
                // 7. Llenar datos (SUMA Avance)
                // =========================
                int dataRowStart = 4;
                int totalRow = dataRowStart + personas.Count; // Fila donde estará el Total General

                // Variable para agregar el total general de la columna
                double totalGeneral = 0;

                for (int i = 0; i < personas.Count; i++)
                {
                    string persona = personas[i];
                    worksheet.Cells[dataRowStart + i, 1].Value = persona;
                    worksheet.Cells[dataRowStart + i, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    int col = colStart;
                    double sumaTotal = 0;  // Acumulador para el total por persona

                    foreach (var p in puestos)
                    {
                        foreach (var f in p.Formatos)
                        {
                            int suma = data
                                .Where(x => x.Persona == persona &&
                                            x.Puesto == p.Puesto &&
                                            x.Formato == f)
                                .Sum(x => x.Avance);

                            if (suma > 0)
                                worksheet.Cells[dataRowStart + i, col].Value = suma;

                            worksheet.Cells[dataRowStart + i, col]
                                .Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            sumaTotal += suma;  // Sumamos al total general de la persona
                            col++;
                        }
                    }

                    // Escribimos el Total de cada persona en la última columna
                    worksheet.Cells[dataRowStart + i, currentCol].Value = sumaTotal;
                    worksheet.Cells[dataRowStart + i, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    totalGeneral += sumaTotal;  // Agregamos al total general
                }

                // =========================
                // 8. Agregar Título Total
                // =========================
                worksheet.Cells[rowHeader2, currentCol].Value = "Total";
                worksheet.Cells[rowHeader2, currentCol].Style.Font.Bold = true;
                worksheet.Cells[rowHeader2, currentCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //worksheet.Cells[rowHeader2, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                // =========================
                // 9. Agregar Suma de Totales por Columna (final de columnas)
                // =========================
                for (int i = colStart; i <= currentCol - 1; i++)
                {
                    double sumaColumna = 0;

                    // Sumar los valores de cada columna (SELECCION, PESADO, EMPAQUE)
                    for (int row = dataRowStart; row < totalRow; row++)
                    {
                        var cellValue = worksheet.Cells[row, i].Text;

                        if (double.TryParse(cellValue, out double value))
                        {
                            sumaColumna += value;
                        }
                    }

                    // Escribimos la suma al final de la columna
                    worksheet.Cells[totalRow, i].Value = sumaColumna;
                    worksheet.Cells[totalRow, i].Style.Font.Bold = true;
                    worksheet.Cells[totalRow, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // =========================
                // 10. Agregar Total General al final de las filas
                // =========================
                worksheet.Cells[totalRow + 0, 1].Value = "TOTAL GENERAL";
                worksheet.Cells[totalRow + 0, 1].Style.Font.Bold = true;
                worksheet.Cells[totalRow + 0, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[totalRow + 0, currentCol].Value = totalGeneral;
                worksheet.Cells[totalRow + 0, currentCol].Style.Font.Bold = true;
                worksheet.Cells[totalRow + 0, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                // =========================
                // 11. Ajustes finales
                // =========================
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                worksheet.View.FreezePanes(4, 2); // Congela encabezados

                // =========================
                // 12. Guardar y abrir
                // =========================
                string filePath = Path.Combine(
                    Path.GetTempPath(),
                    $"Avance_Total_{Fecha_Inicio.Value:yyyyMMdd_HHmmss}.xlsx"
                );

                package.SaveAs(new FileInfo(filePath));

                Process.Start(new ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                });
            }
        }

        public void exportarExcelDinamico(frm_dowloadExcel frbm, CancellationToken token)
        {
            // Licencia EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // =========================
            // 1. Obtener datos del DataGridView
            // =========================
            var data = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new
                {
                    Puesto = r.Cells["PuestoTrabajo"].Value?.ToString(),
                    Formato = r.Cells["Formato"].Value?.ToString(),
                    Persona = r.Cells["ApeNom"].Value?.ToString(),
                    Avance = Convert.ToInt32(r.Cells["Avance"].Value ?? 0)
                })
                .ToList();

            if (!data.Any())
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            // =========================
            // 2. Estructura dinámica
            // =========================
            var puestos = data
                .GroupBy(x => x.Puesto)
                .Select(g => new
                {
                    Puesto = g.Key,
                    Formatos = g.Select(x => x.Formato).Distinct().OrderBy(x => x).ToList()
                })
                .ToList();

            var personas = data
                .Select(x => x.Persona)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            // =========================
            // 3. Crear Excel
            // =========================
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("AVANCE");

                // =========================
                // 4. Título con Fecha (FEC INI)
                // =========================
                int rowTitle = 1;
                int colTitle = 1;

                worksheet.Cells[rowTitle, colTitle].Value = "AVANCE TOTAL POR LABOR INCLUYE PRORRATEO DEL " + Fecha_Inicio.Value.ToString("dd/MM/yyyy");
                worksheet.Cells[rowTitle, colTitle, rowTitle, colTitle + puestos.Sum(p => p.Formatos.Count) - 1].Merge = true;
                worksheet.Cells[rowTitle, colTitle].Style.Font.Bold = true;
                worksheet.Cells[rowTitle, colTitle].Style.Font.Size = 24;
                worksheet.Cells[rowTitle, colTitle].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[rowTitle, colTitle].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[rowTitle, colTitle].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[rowTitle, colTitle].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                worksheet.Row(rowTitle).Height = 30; // Ajuste de altura para el título

                // =========================
                // 5. Encabezado PERSONA
                // =========================
                int rowHeader1 = 2; // Puesto
                int rowHeader2 = 3; // Formato
                int colStart = 2;   // Columna 1 es Persona

                worksheet.Cells[rowHeader1, 1, rowHeader2, 1].Merge = true;
                worksheet.Cells[rowHeader1, 1].Value = "APELLIDOS Y NOMBRES";
                worksheet.Cells[rowHeader1, 1].Style.Font.Bold = true;
                worksheet.Cells[rowHeader1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[rowHeader1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                int currentCol = colStart;

                // =========================
                // 6. Encabezados Puesto / Formato
                // =========================
                foreach (var p in puestos)
                {
                    int startCol = currentCol;

                    foreach (var f in p.Formatos)
                    {
                        worksheet.Cells[rowHeader2, currentCol].Value = f;
                        worksheet.Cells[rowHeader2, currentCol].Style.Font.Bold = true;
                        worksheet.Cells[rowHeader2, currentCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[rowHeader2, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        // Color de fondo para las secciones (EMPAQUE, PESADO, SELECCIÓN)
                        if (p.Puesto == "EMPAQUE")
                        {
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                        }
                        else if (p.Puesto == "PESADO")
                        {
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        }
                        else if (p.Puesto == "SELECCIÓN")
                        {
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowHeader2, currentCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        }

                        currentCol++;
                    }

                    worksheet.Cells[rowHeader1, startCol, rowHeader1, currentCol - 1].Merge = true;
                    worksheet.Cells[rowHeader1, startCol].Value = p.Puesto;
                    worksheet.Cells[rowHeader1, startCol].Style.Font.Bold = true;
                    worksheet.Cells[rowHeader1, startCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[rowHeader1, startCol, rowHeader1, currentCol - 1]
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // =========================
                // 7. Llenar datos (SUMA Avance)
                // =========================
                int dataRowStart = 4;
                int totalRow = dataRowStart + personas.Count; // Fila donde estará el Total General

                // Variable para agregar el total general de la columna
                double totalGeneral = 0;

                for (int i = 0; i < personas.Count; i++)
                {
                    string persona = personas[i];
                    worksheet.Cells[dataRowStart + i, 1].Value = persona;
                    worksheet.Cells[dataRowStart + i, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    int col = colStart;
                    double sumaTotal = 0;  // Acumulador para el total por persona

                    foreach (var p in puestos)
                    {
                        foreach (var f in p.Formatos)
                        {
                            int suma = data
                                .Where(x => x.Persona == persona &&
                                            x.Puesto == p.Puesto &&
                                            x.Formato == f)
                                .Sum(x => x.Avance);

                            if (suma > 0)
                                worksheet.Cells[dataRowStart + i, col].Value = suma;

                            worksheet.Cells[dataRowStart + i, col]
                                .Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            sumaTotal += suma;  // Sumamos al total general de la persona
                            col++;
                        }
                    }

                    // Escribimos el Total de cada persona en la última columna
                    worksheet.Cells[dataRowStart + i, currentCol].Value = sumaTotal;
                    worksheet.Cells[dataRowStart + i, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    totalGeneral += sumaTotal;  // Agregamos al total general
                }

                // =========================
                // 8. Agregar Título Total
                // =========================
                worksheet.Cells[rowHeader2, currentCol].Value = "TOTAL";
                worksheet.Cells[rowHeader2, currentCol].Style.Font.Bold = true;
                worksheet.Cells[rowHeader2, currentCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // =========================
                // 9. Agregar Suma de Totales por Columna (final de columnas)
                // =========================
                for (int i = colStart; i <= currentCol - 1; i++)
                {
                    double sumaColumna = 0;

                    // Sumar los valores de cada columna (SELECCION, PESADO, EMPAQUE)
                    for (int row = dataRowStart; row < totalRow; row++)
                    {
                        var cellValue = worksheet.Cells[row, i].Text;

                        if (double.TryParse(cellValue, out double value))
                        {
                            sumaColumna += value;
                        }
                    }

                    // Escribimos la suma al final de la columna
                    worksheet.Cells[totalRow, i].Value = sumaColumna;
                    worksheet.Cells[totalRow, i].Style.Font.Bold = true;
                    worksheet.Cells[totalRow, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // =========================
                // 10. Agregar Total General al final de las filas
                // =========================
                worksheet.Cells[totalRow + 0, 1].Value = "TOTAL GENERAL";
                worksheet.Cells[totalRow + 0, 1].Style.Font.Bold = true;
                worksheet.Cells[totalRow + 0, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[totalRow + 0, currentCol].Value = totalGeneral;
                worksheet.Cells[totalRow + 0, currentCol].Style.Font.Bold = true;
                worksheet.Cells[totalRow + 0, currentCol].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                // =========================
                // 11. Ajustes finales
                // =========================
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                worksheet.View.FreezePanes(4, 2); // Congela encabezados

                // =========================
                // 12. Guardar y abrir
                // =========================
                string filePath = Path.Combine(
                    Path.GetTempPath(),
                    $"Avance_Total_{Fecha_Inicio.Value:yyyyMMdd_HHmmss}.xlsx"
                );

                package.SaveAs(new FileInfo(filePath));

                // Llamar a Process para abrir el archivo
                Process.Start(new ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                });

                // Fin de la carga
                if (frbm.InvokeRequired)
                {
                    frbm.Invoke(new MethodInvoker(() =>
                    {
                        frbm.progressBar1.Value = 100;
                        frbm.label_porcentaje.Text = "100%";
                    }));
                }
                else
                {
                    frbm.progressBar1.Value = 100;
                    frbm.label_porcentaje.Text = "100%";
                }
            }
        }


    }
}
