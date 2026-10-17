using System;
using System.Globalization;

namespace CapaUtilidad
{
    /// <summary>
    /// Conversión tolerante de las celdas de un DataGridView a los tipos que
    /// espera la base. Hace falta para las cargas masivas: los SP dejaban que
    /// SQL Server convirtiera el texto por su cuenta, pero SqlBulkCopy escribe
    /// la columna tal cual, así que el tipo tiene que salir correcto de C#.
    /// Una celda vacía o con basura no revienta el guardado: queda en cero o
    /// en nulo, igual que antes quedaba cuando el SP no podía convertirla.
    /// </summary>
    public static class cu_valores
    {
        public static string Texto(object valor)
        {
            return valor == null ? "" : valor.ToString().Trim();
        }

        public static string TextoMayus(object valor)
        {
            return valor == null ? "" : valor.ToString().ToUpper().Trim();
        }

        public static double Numero(object valor)
        {
            double n;
            if (valor == null) return 0;
            if (valor is double) return (double)valor;
            if (double.TryParse(valor.ToString().Trim(), NumberStyles.Any,
                    CultureInfo.CurrentCulture, out n)) return n;
            if (double.TryParse(valor.ToString().Trim(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out n)) return n;
            return 0;
        }

        public static decimal Decimal(object valor)
        {
            decimal n;
            if (valor == null) return 0;
            if (valor is decimal) return (decimal)valor;
            if (decimal.TryParse(valor.ToString().Trim(), NumberStyles.Any,
                    CultureInfo.CurrentCulture, out n)) return n;
            if (decimal.TryParse(valor.ToString().Trim(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out n)) return n;
            return 0;
        }

        public static int Entero(object valor)
        {
            return (int)Math.Round(Decimal(valor), MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Hora del día a partir de una celda de Excel.
        ///
        /// Excel no tiene un tipo "hora": guarda la hora como la fracción de un
        /// día (0,99495 = 23:52) y solo le aplica el formato h:mm. ExcelDataReader
        /// convierte esa fracción a DateTime sobre la fecha base de Excel, así
        /// que la celda llega como 31/12/1899 23:52:44 y un TimeSpan.Parse sobre
        /// ese texto falla. Acá se toma solo la parte horaria.
        /// </summary>
        public static TimeSpan Hora(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return TimeSpan.Zero;

            if (valor is TimeSpan)
                return (TimeSpan)valor;

            if (valor is DateTime)
                return ((DateTime)valor).TimeOfDay;

            // Fracción de día, por si la celda llega como número.
            if (valor is double || valor is float || valor is decimal)
                return TimeSpan.FromSeconds(Math.Round(Numero(valor) * 86400d));

            string texto = valor.ToString().Trim();
            if (texto == "")
                return TimeSpan.Zero;

            TimeSpan hora;
            if (TimeSpan.TryParse(texto, CultureInfo.CurrentCulture, out hora)) return hora;
            if (TimeSpan.TryParse(texto, CultureInfo.InvariantCulture, out hora)) return hora;

            DateTime f;
            if (DateTime.TryParse(texto, CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out f)) return f.TimeOfDay;
            if (DateTime.TryParse(texto, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out f)) return f.TimeOfDay;

            double fraccion;
            if (double.TryParse(texto, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out fraccion))
                return TimeSpan.FromSeconds(Math.Round(fraccion * 86400d));

            return TimeSpan.Zero;
        }

        /// <summary>
        /// Devuelve DBNull cuando la celda no trae una fecha reconocible, para
        /// que la columna quede nula en vez de frenar toda la carga.
        /// </summary>
        public static object Fecha(object valor)
        {
            DateTime f;
            if (valor == null) return DBNull.Value;
            if (valor is DateTime) return ((DateTime)valor).Date;

            string texto = valor.ToString().Trim();
            if (texto == "") return DBNull.Value;

            if (DateTime.TryParse(texto, CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out f)) return f.Date;
            if (DateTime.TryParse(texto, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out f)) return f.Date;
            return DBNull.Value;
        }
    }
}
