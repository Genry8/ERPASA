namespace CapaEntidad
{
    public class ce_informerendicion
    {
        public static int IdInf { get; set; }
        public static string RazonSocial { get; set; }
        public static string Ruc { get; set; }
        public static string FechaEmision { get; set; }     // si deseas DateTime, avísame
        public static string HoraEmision { get; set; }      // viene formateada (03:55 a. m.)
        public static string Periodo { get; set; }
        public static string Dni { get; set; }
        public static string ApeNom { get; set; }
        public static string Cantidad { get; set; }
        public static string Total { get; set; }
        public static string CantidadSoles { get; set; }
        public static string MontoSoles { get; set; }
        public static string CantidadDolares { get; set; }
        public static string MontoDolares { get; set; }
    }

    public class ce_informegastos
    {
        public static int IdInf { get; set; }
        public static string gastopara { get; set; }
        public static string gastode { get; set; }
        public static string gastoasunto { get; set; }     // si deseas DateTime, avísame
        public static string fechapresentacion { get; set; }      // viene formateada (03:55 a. m.)
        public static string fecharendir { get; set; }
        public static string descripcion_gasto { get; set; }
        public static string Dni { get; set; }
        public static string Cantidad { get; set; }
        public static string Total { get; set; }
        public static string CantidadSoles { get; set; }
        public static string MontoSoles { get; set; }
        public static string CantidadDolares { get; set; }
        public static string MontoDolares { get; set; }
    }

}

