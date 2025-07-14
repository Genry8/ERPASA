using System;

namespace CapaEntidad
{
    public class ce_planilla
    {
        //COMPENSACION DEVOLUCION
        public static DateTime FechaAlta { get; set; }
        public static DateTime FechaMovimiento { get; set; }
        public static DateTime FechaCompen { get; set; }
        public static DateTime FechaTareado { get; set; }
        public static string codAlta { get; set; }
        public static string DniAlta { get; set; }
        public static string DniCompen { get; set; }
        public static string DniTareado { get; set; }

        //HORAS EXTRAS

        public static string Dni_Extra { get; set; }
        public static DateTime FechaIni_Extra { get; set; }
        public static DateTime FechaFin_Extra { get; set; }
    }
}
