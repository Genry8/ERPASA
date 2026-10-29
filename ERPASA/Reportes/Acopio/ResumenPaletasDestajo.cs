using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    /// <summary>
    /// Arma el resumen de cajas producidas del reporte de producto terminado:
    /// la misma tabla dinámica que hoy se pega a mano en el correo de destajo
    /// (cantidad por presentación y fecha de proceso).
    ///
    /// Se usa en dos sitios con los mismos datos: el cuadro HTML que va en el
    /// cuerpo del correo y la hoja "Resumen_IA" del Excel adjunto.
    /// </summary>
    public static class ResumenPaletasDestajo
    {
        // Nombres que puede traer la grilla para cada dato. Se busca por
        // nombre y no por posición: si el SP cambia de orden, esto no se rompe.
        // El reporte de producto terminado las llama PRESENTACION,
        // "FECHA PROCESO" (con espacio) y CAJAS. Los otros nombres son los del
        // archivo de Excel que se arma a mano, por si alguna vez se alimenta
        // de ahi.
        private static readonly string[] ColPresentacion = { "PRESENTACION", "Presentacion", "PRESENTACIÓN" };
        private static readonly string[] ColFecha = { "FECHA PROCESO", "FECHA_PROCESO", "FechaProceso" };
        private static readonly string[] ColCantidad = { "CAJAS", "CANTIDAD1", "Cantidad1", "CANTIDAD" };

        /// <summary>Una presentación con sus cantidades por fecha.</summary>
        public class Fila
        {
            public string Detalle;
            public string Presentacion;
            public Dictionary<DateTime, double> PorFecha = new Dictionary<DateTime, double>();
            public double Total;
        }

        public class Resumen
        {
            public List<DateTime> Fechas = new List<DateTime>();
            public List<Fila> Filas = new List<Fila>();
            public Dictionary<DateTime, double> TotalPorFecha = new Dictionary<DateTime, double>();
            public double TotalGeneral;
            public string Faltante;   // columna que no se encontró en la grilla
        }

        /// <summary>
        /// Agrupa la grilla por presentación y fecha de proceso sumando
        /// CANTIDAD1. Devuelve Faltante lleno si la grilla no trae alguna de
        /// las tres columnas que hacen falta.
        /// </summary>
        public static Resumen Calcular(DataGridView grilla)
        {
            var resumen = new Resumen();

            int iPres = Columna(grilla, ColPresentacion);
            int iFecha = Columna(grilla, ColFecha);
            int iCant = Columna(grilla, ColCantidad);

            if (iPres < 0) { resumen.Faltante = ColPresentacion[0]; return resumen; }
            if (iFecha < 0) { resumen.Faltante = ColFecha[0]; return resumen; }
            if (iCant < 0) { resumen.Faltante = ColCantidad[0]; return resumen; }

            var porPresentacion = new Dictionary<string, Fila>();
            var fechas = new SortedSet<DateTime>();

            foreach (DataGridViewRow fila in grilla.Rows)
            {
                if (fila.IsNewRow) continue;

                string presentacion = Texto(fila.Cells[iPres].Value);
                if (presentacion == "") continue;

                DateTime fecha;
                if (!FechaDe(fila.Cells[iFecha].Value, out fecha)) continue;

                double cantidad = Numero(fila.Cells[iCant].Value);

                Fila f;
                if (!porPresentacion.TryGetValue(presentacion, out f))
                {
                    f = new Fila
                    {
                        Presentacion = presentacion,
                        Detalle = DetalleDe(presentacion)
                    };
                    porPresentacion.Add(presentacion, f);
                }

                if (f.PorFecha.ContainsKey(fecha)) f.PorFecha[fecha] += cantidad;
                else f.PorFecha.Add(fecha, cantidad);

                f.Total += cantidad;
                fechas.Add(fecha);

                if (resumen.TotalPorFecha.ContainsKey(fecha)) resumen.TotalPorFecha[fecha] += cantidad;
                else resumen.TotalPorFecha.Add(fecha, cantidad);

                resumen.TotalGeneral += cantidad;
            }

            resumen.Fechas = fechas.ToList();
            resumen.Filas = porPresentacion.Values
                .OrderBy(f => f.Presentacion, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return resumen;
        }

        /// <summary>
        /// Clasificación de la columna Detalle a partir del envase que trae el
        /// nombre de la presentación: ... MAD ... es madera, ... JAB ... jaba y
        /// el resto caja.
        ///
        /// OJO: en el correo que se arma a mano hay presentaciones marcadas
        /// como CLAMS. 225 gr, 400 gr, 500 gr, 2 lb y 3 Lb. Eso no se puede
        /// deducir del texto de la presentación (por ejemplo CSU FF 8.2 KG CAR
        /// MAR es CLAMS. 3 Lb y DAY GQ 8.2 KG CAR MAR es CAJA, y los dos dicen
        /// CAR). Hace falta un maestro que diga que marca es clamshell y de
        /// que peso; mientras no exista, esas filas salen como CAJA.
        /// </summary>
        public static string DetalleDe(string presentacion)
        {
            string p = (presentacion ?? "").ToUpperInvariant();

            if (p.Contains(" MAD ")) return "MADERA";
            if (p.Contains(" JAB ")) return "JABA";
            return "CAJA";
        }

        // ------------------------------------------------------------ HTML

        /// <summary>El cuadro que se intercala en el cuerpo del correo.</summary>
        public static string Html(Resumen resumen)
        {
            if (resumen == null || resumen.Filas.Count == 0) return "";

            var sb = new StringBuilder();

            sb.Append("<table cellspacing='0' cellpadding='4' ");
            sb.Append("style='border-collapse:collapse;font-family:Calibri,Arial;font-size:11px;'>");

            // cabecera
            sb.Append("<tr>");
            sb.Append(Celda("Detalle", true, "#FFFF00", "#000000", "left"));
            sb.Append(Celda("Etiquetas de fila", true, "#BDD7EE", "#000000", "left"));
            foreach (DateTime f in resumen.Fechas)
                sb.Append(Celda(f.ToString("dd/MM/yyyy"), true, "#BDD7EE", "#000000", "right"));
            sb.Append(Celda("Total general", true, "#BDD7EE", "#000000", "right"));
            sb.Append("</tr>");

            // filas
            foreach (Fila fila in resumen.Filas)
            {
                sb.Append("<tr>");
                sb.Append(Celda(fila.Detalle, true, "#FFFFFF", "#000000", "left"));
                sb.Append(Celda(fila.Presentacion, false, "#FFFFFF", "#000000", "left"));

                foreach (DateTime f in resumen.Fechas)
                {
                    double v;
                    string texto = fila.PorFecha.TryGetValue(f, out v) ? Monto(v) : "";
                    sb.Append(Celda(texto, false, "#FFFFFF", "#000000", "right"));
                }

                sb.Append(Celda(Monto(fila.Total), false, "#FFFFFF", "#000000", "right"));
                sb.Append("</tr>");
            }

            // totales
            sb.Append("<tr>");
            sb.Append(Celda("", true, "#D9D9D9", "#000000", "left"));
            sb.Append(Celda("Total general", true, "#D9D9D9", "#000000", "left"));
            foreach (DateTime f in resumen.Fechas)
            {
                double v;
                string texto = resumen.TotalPorFecha.TryGetValue(f, out v) ? Monto(v) : "";
                sb.Append(Celda(texto, true, "#D9D9D9", "#000000", "right"));
            }
            sb.Append(Celda(Monto(resumen.TotalGeneral), true, "#D9D9D9", "#000000", "right"));
            sb.Append("</tr>");

            sb.Append("</table>");
            return sb.ToString();
        }

        private static string Celda(string texto, bool negrita, string fondo,
            string color, string alineacion)
        {
            return string.Format(
                "<td style='border:1px solid #808080;background:{0};color:{1};" +
                "text-align:{2};{3}white-space:nowrap;'>{4}</td>",
                fondo, color, alineacion, negrita ? "font-weight:bold;" : "",
                System.Net.WebUtility.HtmlEncode(texto ?? ""));
        }

        private static string Monto(double valor)
        {
            return valor.ToString("N2", CultureInfo.GetCultureInfo("es-PE"));
        }

        // ----------------------------------------------------------- Excel

        /// <summary>
        /// Vuelca el resumen en una hoja con el mismo formato del archivo que
        /// hoy se envia a mano: Detalle, presentacion, una columna por fecha y
        /// los totales.
        /// </summary>
        public static void VolcarEnHoja(ExcelWorksheet hoja, Resumen resumen)
        {
            hoja.Cells[1, 2].Value = "Suma de CANTIDAD1";
            hoja.Cells[1, 3].Value = "Etiquetas de columna";
            hoja.Cells[1, 2, 1, 3].Style.Font.Bold = true;

            hoja.Cells[2, 1].Value = "Detalle";
            hoja.Cells[2, 2].Value = "Etiquetas de fila";

            for (int i = 0; i < resumen.Fechas.Count; i++)
            {
                hoja.Cells[2, 3 + i].Value = resumen.Fechas[i];
                hoja.Cells[2, 3 + i].Style.Numberformat.Format = "dd/MM/yyyy";
            }

            int colTotal = 3 + resumen.Fechas.Count;
            hoja.Cells[2, colTotal].Value = "Total general";

            using (var cabecera = hoja.Cells[2, 1, 2, colTotal])
            {
                cabecera.Style.Font.Bold = true;
                cabecera.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cabecera.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                cabecera.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            hoja.Cells[2, 1].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            int fila = 3;
            foreach (Fila f in resumen.Filas)
            {
                hoja.Cells[fila, 1].Value = f.Detalle;
                hoja.Cells[fila, 1].Style.Font.Bold = true;
                hoja.Cells[fila, 2].Value = f.Presentacion;

                for (int i = 0; i < resumen.Fechas.Count; i++)
                {
                    double v;
                    if (f.PorFecha.TryGetValue(resumen.Fechas[i], out v))
                    {
                        hoja.Cells[fila, 3 + i].Value = v;
                        hoja.Cells[fila, 3 + i].Style.Numberformat.Format = "#,##0.00";
                    }
                }

                hoja.Cells[fila, colTotal].Value = f.Total;
                hoja.Cells[fila, colTotal].Style.Numberformat.Format = "#,##0.00";
                fila++;
            }

            hoja.Cells[fila, 2].Value = "Total general";

            for (int i = 0; i < resumen.Fechas.Count; i++)
            {
                double v;
                if (resumen.TotalPorFecha.TryGetValue(resumen.Fechas[i], out v))
                    hoja.Cells[fila, 3 + i].Value = v;
            }

            hoja.Cells[fila, colTotal].Value = resumen.TotalGeneral;

            using (var totales = hoja.Cells[fila, 1, fila, colTotal])
            {
                totales.Style.Font.Bold = true;
                totales.Style.Numberformat.Format = "#,##0.00";
                totales.Style.Fill.PatternType = ExcelFillStyle.Solid;
                totales.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217));
            }

            using (var todo = hoja.Cells[2, 1, fila, colTotal])
            {
                todo.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                todo.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                todo.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                todo.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }

            hoja.Cells.AutoFitColumns();
        }

        // -------------------------------------------------------- ayudantes

        private static int Columna(DataGridView grilla, string[] nombres)
        {
            foreach (string nombre in nombres)
                foreach (DataGridViewColumn c in grilla.Columns)
                    if (string.Equals(c.Name, nombre, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(c.HeaderText, nombre, StringComparison.OrdinalIgnoreCase))
                        return c.Index;

            return -1;
        }

        private static string Texto(object valor)
        {
            return valor == null || valor == DBNull.Value ? "" : valor.ToString().Trim();
        }

        private static bool FechaDe(object valor, out DateTime fecha)
        {
            fecha = DateTime.MinValue;
            if (valor == null || valor == DBNull.Value) return false;

            if (valor is DateTime)
            {
                fecha = ((DateTime)valor).Date;
                return true;
            }

            DateTime f;
            if (DateTime.TryParse(valor.ToString(), CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out f) ||
                DateTime.TryParse(valor.ToString(), CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out f))
            {
                fecha = f.Date;
                return true;
            }

            return false;
        }

        private static double Numero(object valor)
        {
            if (valor == null || valor == DBNull.Value) return 0;
            if (valor is double) return (double)valor;
            if (valor is decimal) return (double)(decimal)valor;
            if (valor is int) return (int)valor;

            double n;
            if (double.TryParse(valor.ToString(), NumberStyles.Any,
                    CultureInfo.CurrentCulture, out n)) return n;
            if (double.TryParse(valor.ToString(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out n)) return n;
            return 0;
        }
    }
}
