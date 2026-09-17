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
