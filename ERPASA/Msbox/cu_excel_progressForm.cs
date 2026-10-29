using ERPASA.Msbox;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

                // Columnas que terminaron con fotos: al final hay que
                // devolverles el ancho, porque AutoFitColumns no ve los
                // dibujos y las dejaria angostas.
                var columnasConImagen = new HashSet<int>();

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
                        else if (value is Image)
                        {
                            // La celda queda vacia y la foto se pega encima;
                            // si se escribiera el valor saldria el texto
                            // "System.Drawing.Bitmap".
                            AgregarImagen(worksheet, (Image)value, row + 2, col + 1);
                            columnasConImagen.Add(col + 1);
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

                foreach (int columna in columnasConImagen)
                {
                    if (worksheet.Column(columna).Width < AnchoColumnaImagen)
                        worksheet.Column(columna).Width = AnchoColumnaImagen;
                }

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

        // Tamaño que se le da a la foto dentro de la celda, en pixeles.
        private const int AnchoImagen = 110;
        private const int AltoImagen = 80;

        // Ancho de la columna en "caracteres", que es la unidad de Excel.
        private const double AnchoColumnaImagen = (AnchoImagen + 12) / 7.0;

        /// <summary>
        /// Pega una foto de la grilla dentro de la celda indicada.
        ///
        /// En Excel las imagenes no son valores de celda sino dibujos que
        /// flotan encima, asi que ademas de insertarla hay que agrandar la
        /// fila para que entre.
        /// </summary>
        private static void AgregarImagen(ExcelWorksheet hoja, Image imagen, int fila, int columna)
        {
            try
            {
                double escala = Math.Min((double)AnchoImagen / imagen.Width,
                                         (double)AltoImagen / imagen.Height);
                if (escala > 1) escala = 1;

                int ancho = Math.Max(1, (int)Math.Round(imagen.Width * escala));
                int alto = Math.Max(1, (int)Math.Round(imagen.Height * escala));

                // EPPlus necesita el flujo vivo hasta que se guarda el libro,
                // por eso no se libera aca.
                var memoria = new MemoryStream();
                imagen.Save(memoria, ImageFormat.Png);
                memoria.Position = 0;

                var dibujo = hoja.Drawings.AddPicture("img_" + fila + "_" + columna, memoria);

                // SetPosition trabaja con indices que empiezan en cero.
                dibujo.SetPosition(fila - 1, 3, columna - 1, 3);
                dibujo.SetSize(ancho, alto);

                // La altura de fila va en puntos: 1 pixel son 0.75 puntos.
                double altoFila = (alto + 6) * 0.75;
                if (hoja.Row(fila).Height < altoFila) hoja.Row(fila).Height = altoFila;
            }
            catch
            {
                // Si una foto no se puede pegar, el resto del Excel igual sale.
            }
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


        /// <summary>
        /// Excel del correo de destajo: dos hojas, igual que el archivo que
        /// hoy se arma a mano.
        ///   "Paletas Producidas" -> el detalle tal cual sale de la grilla.
        ///   "Resumen_IA"         -> la tabla dinamica de cajas por
        ///                           presentacion y fecha de proceso.
        /// </summary>
        public string exportarexcelCorreoDestajo(DataGridView dataGridView,
            frm_dowloadExcel frbm, CancellationToken token, string titulo,
            DateTime fecini, DateTime fecfin,
            ERPASA.Reportes.Acopio.ResumenPaletasDestajo.Resumen resumen)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            int totalRows = dataGridView.RowCount;
            int totalColumns = dataGridView.ColumnCount;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Paletas Producidas");

                for (int i = 0; i < totalColumns; i++)
                    worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;

                using (var encabezado = worksheet.Cells[1, 1, 1, totalColumns])
                {
                    encabezado.Style.Font.Bold = true;
                    encabezado.Style.Font.Color.SetColor(Color.White);
                    encabezado.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    encabezado.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(31, 78, 121));
                    encabezado.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    encabezado.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                for (int row = 0; row < totalRows; row++)
                {
                    token.ThrowIfCancellationRequested();

                    for (int col = 0; col < totalColumns; col++)
                    {
                        object value = dataGridView.Rows[row].Cells[col].Value;

                        if (value is DateTime)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = (DateTime)value;
                            worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                        else if (value is bool || value is double || value is float ||
                                 value is int || value is decimal)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, col + 1].Value = value == null ? "" : value.ToString();
                        }
                    }

                    int progress = totalRows == 0 ? 100 : (int)(((double)(row + 1) / totalRows) * 100);

                    if (frbm.InvokeRequired)
                        frbm.Invoke(new MethodInvoker(() =>
                        {
                            frbm.progressBar1.Value = progress;
                            frbm.label_porcentaje.Text = progress + "%";
                        }));
                    else
                    {
                        frbm.progressBar1.Value = progress;
                        frbm.label_porcentaje.Text = progress + "%";
                    }
                }

                if (totalRows > 0)
                {
                    var rango = worksheet.Cells[1, 1, totalRows + 1, totalColumns];
                    var tabla = worksheet.Tables.Add(rango, "TablaPaletas");
                    tabla.TableStyle = TableStyles.Light1;
                    tabla.ShowFilter = true;
                }

                worksheet.View.FreezePanes(2, 1);
                worksheet.Cells.AutoFitColumns();

                // La hoja resumen va primero, que es lo que se mira al abrir.
                var hojaResumen = package.Workbook.Worksheets.Add("Resumen_IA");
                ERPASA.Reportes.Acopio.ResumenPaletasDestajo.VolcarEnHoja(hojaResumen, resumen);
                package.Workbook.Worksheets.MoveToStart("Resumen_IA");

                string nombre = titulo + fecini.ToString("yyyyMMdd") + "_" +
                                fecfin.ToString("yyyyMMdd") + ".xlsx";
                string ruta = Path.Combine(Path.GetTempPath(), nombre);

                package.SaveAs(new FileInfo(ruta));
                return ruta;
            }
        }

    }
}
