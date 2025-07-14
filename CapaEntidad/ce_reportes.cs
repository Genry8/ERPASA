namespace CapaEntidad
{
    public partial class ce_reportes
    {
        //DATOS DEL CLIENTE PARA GUARDAR
        public static int user { get; set; }
        public static string nombres { get; set; }
        public static string sede { get; set; }

    }

    public class Datos
    {
        //DATOS TOTAL DE VENTA
        public string TotAnulado { get; set; }
        public string TotNoAnulado { get; set; }
        public string Total { get; set; }
        public string Nombres_cry { get; set; }
        public string Sede_cry { get; set; }
    }
}
