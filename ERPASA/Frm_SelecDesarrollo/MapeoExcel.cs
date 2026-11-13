using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERPASA.Frm_SelecDesarrollo
{
    internal enum TipoCampo { Texto, Entero, Fecha }

    /// <summary>
    /// Una columna del Excel, en el orden en que viene, y la columna de la
    /// tabla SQL donde va.
    /// </summary>
    internal class CampoExcel
    {
        public readonly string Columna;      // nombre en la tabla SQL
        public readonly TipoCampo Tipo;
        public readonly int Largo;           // maximo de caracteres de la columna SQL (0 = sin limite)

        /// <summary>
        /// 0 = la hoja siempre la trae. Un numero (1, 2...) identifica un
        /// grupo de columnas opcionales que vienen o faltan JUNTAS: asi cada
        /// combinacion posible da un ancho de hoja distinto y el ancho dice
        /// cual es.
        /// </summary>
        public readonly int Grupo;

        /// <summary>
        /// La hoja trae esta columna pero la tabla no la guarda: ocupa su
        /// lugar en el orden y se salta al leer.
        /// </summary>
        public readonly bool NoSeGuarda;

        public bool Opcional { get { return Grupo != 0; } }

        public CampoExcel(string columna, TipoCampo tipo, int largo, int grupo = 0)
        {
            Columna = columna;
            Tipo = tipo;
            Largo = largo;
            Grupo = grupo;
        }

        private CampoExcel(int grupo)
        {
            Columna = "(no se guarda)";
            Tipo = TipoCampo.Texto;
            NoSeGuarda = true;
            Grupo = grupo;
        }

        /// <summary>Una columna de la hoja que no va a la tabla.</summary>
        public static CampoExcel Omitida(int grupo)
        {
            return new CampoExcel(grupo);
        }
    }

    internal class ResultadoMapeo
    {
        /// <summary>Columna SQL -> posicion de la columna en la grilla.</summary>
        public readonly Dictionary<string, int> Indices = new Dictionary<string, int>();

        /// <summary>Columnas SQL que la hoja no trae (quedaran vacias).</summary>
        public readonly List<string> NoEncontradas = new List<string>();

        /// <summary>Columnas de mas al final de la hoja, que se ignoran.</summary>
        public int Sobrantes;

        /// <summary>Si no es null, la hoja no sirve y este es el motivo.</summary>
        public string Problema;
    }

    /// <summary>
    /// Lee un Excel por la POSICION de sus columnas.
    ///
    /// Los encabezados del Excel no se llaman como las columnas de la tabla,
    /// asi que lo unico que une a una con otra es el orden. Ese orden es el de
    /// la tabla SQL, sin las columnas que completa la carga (año, semana, hoja)
    /// ni las de auditoria.
    /// </summary>
    internal static class MapeoExcel
    {
        private static readonly Regex EncabezadoVacio = new Regex(@"^Column\d+$", RegexOptions.Compiled);

        /// <summary>
        /// Asigna a cada campo la columna que le toca por su lugar en la hoja.
        ///
        ///   - Con al menos tantas columnas como campos: uno a uno, y lo que
        ///     sobre al final se ignora.
        ///   - Con menos: se prueba cada combinacion de grupos opcionales
        ///     presentes o ausentes. Cada una da un ancho distinto, asi que el
        ///     ancho de la hoja identifica cual es.
        ///   - Si ninguna da ese ancho no se adivina: se devuelve el problema.
        ///
        /// Las columnas vacias del final no cuentan: ExcelDataReader las
        /// incluye cuando la hoja tiene formato mas alla de los datos.
        /// </summary>
        public static ResultadoMapeo BuscarPorPosicion(DataGridView grilla, IList<CampoExcel> campos)
        {
            var resultado = new ResultadoMapeo();

            int ancho = AnchoUtil(grilla);
            int completo = campos.Count;

            // Cuantas columnas aporta cada grupo opcional.
            var tamanos = new SortedDictionary<int, int>();
            foreach (CampoExcel c in campos)
            {
                if (c.Grupo == 0) continue;
                int actual;
                tamanos.TryGetValue(c.Grupo, out actual);
                tamanos[c.Grupo] = actual + 1;
            }

            var grupos = new List<int>(tamanos.Keys);
            int todos = (1 << grupos.Count) - 1;

            if (ancho >= completo)
            {
                Asignar(resultado, campos, grupos, todos);
                resultado.Sobrantes = ancho - completo;
                return resultado;
            }

            // Una mascara es una combinacion: el bit encendido = el grupo viene.
            var coinciden = new List<int>();
            var anchosValidos = new List<int> { completo };

            for (int mascara = 0; mascara <= todos; mascara++)
            {
                int w = completo;
                for (int g = 0; g < grupos.Count; g++)
                    if ((mascara & (1 << g)) == 0) w -= tamanos[grupos[g]];

                if (mascara != todos && !anchosValidos.Contains(w)) anchosValidos.Add(w);
                if (w == ancho) coinciden.Add(mascara);
            }

            if (coinciden.Count == 1)
            {
                Asignar(resultado, campos, grupos, coinciden[0]);
                return resultado;
            }

            anchosValidos.Sort();
            anchosValidos.Reverse();

            var sb = new StringBuilder();
            sb.Append("La hoja trae " + ancho + " columnas (sin contar las vacias del final) y se esperan ");
            sb.Append(string.Join(", ", anchosValidos.ConvertAll(x => x.ToString()).ToArray()));
            sb.Append(" segun traiga o no las opcionales.\n\nOrden esperado:\n");

            for (int i = 0; i < campos.Count; i++)
            {
                sb.Append((i + 1) + ". " + (campos[i].NoSeGuarda ? "(no se guarda)" : campos[i].Columna));
                if (campos[i].Opcional) sb.Append(" (opcional)");
                sb.Append(i < campos.Count - 1 ? "   " : "");
                if ((i + 1) % 4 == 0) sb.Append("\n");
            }

            sb.Append("\n\nEncabezados que trae la hoja:\n");
            for (int i = 0; i < grilla.Columns.Count && i < 30; i++)
                sb.Append((i + 1) + ". " + grilla.Columns[i].HeaderText + "   " + ((i + 1) % 4 == 0 ? "\n" : ""));

            resultado.Problema = sb.ToString();
            return resultado;
        }

        /// <summary>Reparte las posiciones segun que grupos opcionales vengan.</summary>
        private static void Asignar(ResultadoMapeo resultado, IList<CampoExcel> campos,
            List<int> grupos, int mascara)
        {
            int posicion = 0;

            foreach (CampoExcel c in campos)
            {
                bool viene = c.Grupo == 0 || (mascara & (1 << grupos.IndexOf(c.Grupo))) != 0;

                if (!viene)
                {
                    // Una omitida que no esta no deja nada vacio: no se reporta.
                    if (!c.NoSeGuarda) resultado.NoEncontradas.Add(c.Columna);
                    continue;
                }

                if (!c.NoSeGuarda) resultado.Indices[c.Columna] = posicion;
                posicion++;
            }
        }

        /// <summary>Cantidad de columnas hasta la ultima que tiene encabezado o algun dato.</summary>
        private static int AnchoUtil(DataGridView grilla)
        {
            for (int c = grilla.Columns.Count - 1; c >= 0; c--)
            {
                string encabezado = grilla.Columns[c].HeaderText ?? "";
                if (encabezado.Trim() != "" && !EncabezadoVacio.IsMatch(encabezado)) return c + 1;

                foreach (DataGridViewRow fila in grilla.Rows)
                {
                    if (fila.IsNewRow) continue;

                    object v = fila.Cells[c].Value;
                    if (v != null && v != DBNull.Value && v.ToString().Trim() != "") return c + 1;
                }
            }

            return 0;
        }

        /// <summary>Numero de semana a partir del nombre de la hoja ("Sem. 40" = 40).</summary>
        public static int? SemanaDeHoja(string nombreHoja)
        {
            if (string.IsNullOrWhiteSpace(nombreHoja)) return null;

            var digitos = new StringBuilder();
            foreach (char c in nombreHoja)
            {
                if (char.IsDigit(c)) digitos.Append(c);
                else if (digitos.Length > 0) break;
            }

            int semana;
            return digitos.Length > 0 && int.TryParse(digitos.ToString(), out semana) ? semana : (int?)null;
        }

        public static bool FilaVacia(DataGridViewRow fila)
        {
            foreach (DataGridViewCell celda in fila.Cells)
            {
                object v = celda.Value;
                if (v != null && v != DBNull.Value && v.ToString().Trim() != "") return false;
            }

            return true;
        }

        public static object Convertir(object valor, TipoCampo tipo)
        {
            if (valor == null || valor == DBNull.Value) return DBNull.Value;

            switch (tipo)
            {
                case TipoCampo.Entero: return Entero(valor);
                case TipoCampo.Fecha: return Fecha(valor);
                default:
                    string texto = valor.ToString().Trim();
                    return texto == "" ? (object)DBNull.Value : texto;
            }
        }

        // Vacio o ilegible queda NULL, no 0: un 0 en "Vencimiento" o en
        // "Dias" seria un dato falso.
        private static object Entero(object valor)
        {
            if (valor is double) return (int)Math.Round((double)valor, MidpointRounding.AwayFromZero);
            if (valor is decimal) return (int)Math.Round((decimal)valor, MidpointRounding.AwayFromZero);
            if (valor is int) return valor;

            string texto = valor.ToString().Trim();
            if (texto == "") return DBNull.Value;

            decimal n;
            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.CurrentCulture, out n) ||
                decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out n))
                return (int)Math.Round(n, MidpointRounding.AwayFromZero);

            return DBNull.Value;
        }

        private static object Fecha(object valor)
        {
            if (valor is DateTime) return ((DateTime)valor).Date;

            // Una fecha sin formato llega como numero de serie de Excel.
            if (valor is double)
            {
                double serie = (double)valor;
                return serie > 20000 && serie < 80000
                    ? (object)DateTime.FromOADate(serie).Date
                    : DBNull.Value;
            }

            string texto = valor.ToString().Trim();
            if (texto == "") return DBNull.Value;

            DateTime f;
            if (DateTime.TryParse(texto, CultureInfo.CurrentCulture, DateTimeStyles.None, out f) ||
                DateTime.TryParse(texto, CultureInfo.InvariantCulture, DateTimeStyles.None, out f))
                return f.Date;

            double numero;
            if (double.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out numero) &&
                numero > 20000 && numero < 80000)
                return DateTime.FromOADate(numero).Date;

            return DBNull.Value;
        }
    }
}
