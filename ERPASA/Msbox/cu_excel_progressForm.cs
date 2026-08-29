using ERPASA.Msbox;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CapaUtilidad
{
    public class cu_excel_progressForm
    {
        public void exportarexcelTimerOF(DataGridView dataGridView, frm_dowloadExcel frbm, CancellationToken token)
        {
            // Asegurarse de que EPPlus está trabajando en un entorno de licencia de código abierto o comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;  // O LicenseContext.Commercial para la versión comercial

            int totalRows = dataGridView.RowCount;
            int totalColumns = dataGridView.ColumnCount;

            // Crear un nuevo archivo Excel en memoria
            using (var package = new ExcelPackage())
            {
                // Crear una hoja de trabajo
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Escribir las cabeceras de columna
                for (int i = 0; i < totalColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                }

                // Escribir las filas de datos
                for (int row = 0; row < totalRows; row++)
                {
                    token.ThrowIfCancellationRequested(); // Detectar cancelación

                    for (int col = 0; col < totalColumns; col++)
                    {
                        object value = dataGridView.Rows[row].Cells[col].Value;

                        if (value is DateTime dt) // Si es una fecha
                        {
                            //worksheet.Cells[row + 2, col + 1].Value = dt;
                            //worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss"; // formato Excel compatible
                            worksheet.Cells[row + 2, col + 1].Value = dt;

                            // Verificar si es solo una hora (sin una fecha)
                            if (dt.Date == dt) // Si la fecha es igual a la fecha sin hora (es decir, es una hora)
                            {
                                worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-mm-dd"; // Solo formato de hora
                            }
                            else if (dt == dt) // Si la fecha es igual a la fecha sin hora (es decir, es una hora)
                            {
                                worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-mm-dd HH:mm:ss"; // Solo formato de hora
                            }
                            else
                            {
                                worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "HH:mm:ss"; // Formato fecha y hora
                            }
                        }
                        else if (value is bool) // Si es un booleano
                        {
                            worksheet.Cells[row + 2, col + 1].Value = (bool)value;
                        }
                        else if (value is double || value is float
                            || value is int || value is decimal) // Si es un número
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value;
                        }
                        else // Para cualquier otro tipo (cadena, etc.)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value?.ToString() ?? "";
                        }
                    }

                    // Calcular el porcentaje de progreso y actualizar la UI
                    int progress = (int)(((double)(row + 1) / totalRows) * 100);
                    if (frbm.InvokeRequired)
                    {
                        frbm.Invoke(new MethodInvoker(() =>
                        {
                            frbm.progressBar1.Value = progress;
                            frbm.label_porcentaje.Text = progress + "%";
                        }));
                    }
                    else
                    {
                        frbm.progressBar1.Value = progress;
                        frbm.label_porcentaje.Text = progress + "%";
                    }
                }

                // Crear un archivo temporal para almacenar el archivo Excel en memoria
                // Generar un nombre único usando un timestamp (o GUID) para evitar el conflicto de nombres
                var uniqueFileName = "ExportedData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                var tempFilePath = Path.Combine(Path.GetTempPath(), uniqueFileName);

                // Guardar el archivo en la ruta temporal
                FileInfo fi = new FileInfo(tempFilePath);
                package.SaveAs(fi);

                // Abrir el archivo Excel
                Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            }

            // Opción: Mostrar mensaje de finalización
            // MessageBox.Show("Exportación completada", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void exportarexcelTimer(DataGridView dataGridView, frm_dowloadExcel frbm, CancellationToken token)
        {
            // Asegurarse de que EPPlus está trabajando en un entorno de licencia de código abierto o comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            int totalRows = dataGridView.RowCount;
            int totalColumns = dataGridView.ColumnCount;

            // Crear un nuevo archivo Excel en memoria
            using (var package = new ExcelPackage())
            {
                // Crear una hoja de trabajo
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Escribir las cabeceras de columna
                for (int i = 0; i < totalColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                }

                // ==========================
                // FORMATO DEL ENCABEZADO
                // ==========================
                using (var encabezado = worksheet.Cells[1, 1, 1, totalColumns])
                {
                    encabezado.Style.Font.Bold = true;
                    encabezado.Style.Font.Color.SetColor(Color.White);

                    encabezado.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    encabezado.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(31, 78, 121));

                    encabezado.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    encabezado.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // Escribir las filas de datos
                for (int row = 0; row < totalRows; row++)
                {
                    token.ThrowIfCancellationRequested(); // Detectar cancelación

                    for (int col = 0; col < totalColumns; col++)
                    {
                        object value = dataGridView.Rows[row].Cells[col].Value;

                        if (value is DateTime dt) // Si es una fecha
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dt;

                            if (dt.Date == dt)
                            {
                                worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-MM-dd";
                            }
                            else
                            {
                                worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            }
                        }
                        else if (value is bool)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = (bool)value;
                        }
                        else if (value is double || value is float
                            || value is int || value is decimal)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value?.ToString() ?? "";
                        }
                    }

                    // Calcular el porcentaje de progreso y actualizar la UI
                    int progress = (int)(((double)(row + 1) / totalRows) * 100);

                    if (frbm.InvokeRequired)
                    {
                        frbm.Invoke(new MethodInvoker(() =>
                        {
                            frbm.progressBar1.Value = progress;
                            frbm.label_porcentaje.Text = progress + "%";
                        }));
                    }
                    else
                    {
                        frbm.progressBar1.Value = progress;
                        frbm.label_porcentaje.Text = progress + "%";
                    }
                }

                // ==========================
                // TABLA CON FILTROS
                // ==========================
                var rango = worksheet.Cells[1, 1, totalRows + 1, totalColumns];

                var tabla = worksheet.Tables.Add(rango, "TablaReporte");
                tabla.TableStyle = TableStyles.Light1;
                tabla.ShowFilter = true;

                // Congelar encabezado
                worksheet.View.FreezePanes(2, 1);

                // Ajustar ancho de columnas
                worksheet.Cells.AutoFitColumns();

                // Crear un archivo temporal para almacenar el archivo Excel
                var uniqueFileName = "ExportedData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                var tempFilePath = Path.Combine(Path.GetTempPath(), uniqueFileName);

                // Guardar el archivo
                FileInfo fi = new FileInfo(tempFilePath);
                package.SaveAs(fi);

                // Abrir el archivo Excel
                Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            }

            // MessageBox.Show("Exportación completada", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string exportarexcelCorreoOF(DataGridView dataGridView, frm_dowloadExcel frbm,
    CancellationToken token, string titulo, DateTime fecini, DateTime fecfin)
        {
            // Configuración EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            int totalRows = dataGridView.RowCount;
            int totalColumns = dataGridView.ColumnCount;


            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Reporte");


                // Cabeceras
                for (int i = 0; i < totalColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Value =
                        dataGridView.Columns[i].HeaderText;
                }


                // Datos
                for (int row = 0; row < totalRows; row++)
                {
                    token.ThrowIfCancellationRequested();


                    for (int col = 0; col < totalColumns; col++)
                    {
                        object value = dataGridView.Rows[row].Cells[col].Value;


                        if (value is DateTime dt)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dt;
                            worksheet.Cells[row + 2, col + 1]
                                .Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                        else if (value is bool)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = (bool)value;
                        }
                        else if (value is double ||
                                 value is float ||
                                 value is int ||
                                 value is decimal)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, col + 1].Value =
                                value?.ToString() ?? "";
                        }
                    }


                    // Progreso
                    int progress = (int)(((double)(row + 1) / totalRows) * 100);


                    if (frbm.InvokeRequired)
                    {
                        frbm.Invoke(new MethodInvoker(() =>
                        {
                            frbm.progressBar1.Value = progress;
                            frbm.label_porcentaje.Text = progress + "%";
                        }));
                    }
                    else
                    {
                        frbm.progressBar1.Value = progress;
                        frbm.label_porcentaje.Text = progress + "%";
                    }
                }


                // Ajustar columnas
                worksheet.Cells.AutoFitColumns();


                // Crear archivo temporal
                // Crear archivo temporal
                string nombreArchivo;

                if (fecini.Date == fecfin.Date)
                {
                    nombreArchivo =
                        titulo +
                        fecini.ToString("yyyyMMdd") +
                        DateTime.Now.ToString("_HHmmss") +
                        ".xlsx";
                }
                else
                {
                    nombreArchivo =
                        titulo +
                        fecini.ToString("yyyyMMdd") +
                        "_hasta_" +
                        fecfin.ToString("yyyyMMdd") +
                        DateTime.Now.ToString("_HHmmss") +
                        ".xlsx";
                }

                string rutaArchivo = Path.Combine(
                    Path.GetTempPath(),
                    nombreArchivo
                );


                // Guardar
                FileInfo archivo = new FileInfo(rutaArchivo);

                package.SaveAs(archivo);


                // Retornar ruta para adjuntar al correo
                return rutaArchivo;
            }
        }

        public string exportarexcelCorreo(DataGridView dataGridView, frm_dowloadExcel frbm,
    CancellationToken token, string titulo, DateTime fecini, DateTime fecfin)
        {
            // Configuración EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            int totalRows = dataGridView.RowCount;
            int totalColumns = dataGridView.ColumnCount;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Reporte");

                // Cabeceras
                for (int i = 0; i < totalColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Value =
                        dataGridView.Columns[i].HeaderText;
                }

                // ==========================
                // FORMATO DEL ENCABEZADO
                // ==========================
                using (var encabezado = worksheet.Cells[1, 1, 1, totalColumns])
                {
                    encabezado.Style.Font.Bold = true;
                    encabezado.Style.Font.Color.SetColor(Color.White);

                    encabezado.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    encabezado.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(31, 78, 121)); // Azul oscuro

                    encabezado.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    encabezado.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // Datos
                for (int row = 0; row < totalRows; row++)
                {
                    token.ThrowIfCancellationRequested();

                    for (int col = 0; col < totalColumns; col++)
                    {
                        object value = dataGridView.Rows[row].Cells[col].Value;

                        if (value is DateTime dt)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dt;
                            worksheet.Cells[row + 2, col + 1]
                                .Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                        else if (value is bool)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = (bool)value;
                        }
                        else if (value is double ||
                                 value is float ||
                                 value is int ||
                                 value is decimal)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, col + 1].Value =
                                value?.ToString() ?? "";
                        }
                    }

                    // Progreso
                    int progress = (int)(((double)(row + 1) / totalRows) * 100);

                    if (frbm.InvokeRequired)
                    {
                        frbm.Invoke(new MethodInvoker(() =>
                        {
                            frbm.progressBar1.Value = progress;
                            frbm.label_porcentaje.Text = progress + "%";
                        }));
                    }
                    else
                    {
                        frbm.progressBar1.Value = progress;
                        frbm.label_porcentaje.Text = progress + "%";
                    }
                }

                // ==========================
                // TABLA CON FILTROS
                // ==========================
                var rango = worksheet.Cells[1, 1, totalRows + 1, totalColumns];

                var tabla = worksheet.Tables.Add(rango, "TablaReporte");
                tabla.TableStyle = TableStyles.Light1;
                tabla.ShowFilter = true;

                // Congelar encabezado
                worksheet.View.FreezePanes(2, 1);

                // Ajustar columnas automáticamente
                worksheet.Cells.AutoFitColumns();

                // Crear archivo temporal
                string nombreArchivo;

                if (fecini.Date == fecfin.Date)
                {
                    nombreArchivo =
                        titulo +
                        fecini.ToString("yyyyMMdd") +
                        DateTime.Now.ToString("_HHmmss") +
                        ".xlsx";
                }
                else
                {
                    nombreArchivo =
                        titulo +
                        fecini.ToString("yyyyMMdd") +
                        "_hasta_" +
                        fecfin.ToString("yyyyMMdd") +
                        DateTime.Now.ToString("_HHmmss") +
                        ".xlsx";
                }

                string rutaArchivo = Path.Combine(
                    Path.GetTempPath(),
                    nombreArchivo
                );

                // Guardar
                FileInfo archivo = new FileInfo(rutaArchivo);

                package.SaveAs(archivo);

                // Retornar ruta para adjuntar al correo
                return rutaArchivo;
            }
        }
        /*        
        public void exportarexcelTimer(DataGridView dataGridView, frm_dowloadExcel frbm, CancellationToken token)
        {
            int totalRows = dataGridView.RowCount;
            int totalColumns = dataGridView.ColumnCount;

            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Worksheet worksheet = (Worksheet)workbook.ActiveSheet;

            for (int i = 0; i < totalColumns; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }

            for (int row = 0; row < totalRows; row++)
            {
                token.ThrowIfCancellationRequested(); // 🔴 DETECTA cancelación

                for (int col = 0; col < totalColumns; col++)
                {
                    object value = dataGridView.Rows[row].Cells[col].Value;
                    worksheet.Cells[row + 2, col + 1] = value?.ToString() ?? "";
                }

                int progress = (int)(((double)(row + 1) / totalRows) * 100);
                if (frbm.InvokeRequired)
                {
                    frbm.Invoke(new MethodInvoker(() =>
                    {
                        frbm.progressBar1.Value = progress;
                        frbm.label_porcentaje.Text = progress + "%";
                    }));

                }
                else
                {
                    frbm.progressBar1.Value = progress;
                    frbm.label_porcentaje.Text = progress + "%";
                }
            }

            excelApp.Visible = true;
        }
        
        */

    }
}
