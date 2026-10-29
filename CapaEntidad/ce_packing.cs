namespace CapaEntidad
{
    public class ce_packingPT
    {
        public string id { get; set; }
        public string palet { get; set; }
        public string pucho { get; set; }
        public string cajas { get; set; }

    }

    /// <summary>
    /// Fila elegida en el reporte de peso por presentación, para que la
    /// ventana de edición la lea (PACK_PesoPresentacion).
    /// </summary>
    public class ce_pesopresentacion
    {
        public static string empresa { get; set; }
        public static string sede { get; set; }
        public static string cultivo { get; set; }
        public static string presentacion { get; set; }
        public static string peso { get; set; }
        public static string porcentajemin { get; set; }
        public static string porcentaje { get; set; }
        public static string obs { get; set; }
    }

    /// <summary>
    /// Fila elegida en el reporte de configuración de correos, para que la
    /// ventana de edición la lea (PACK_EnviarCorreo).
    /// </summary>
    public class ce_enviarcorreo
    {
        public static string fecha { get; set; }
        public static string empresa { get; set; }
        public static string sede { get; set; }
        public static string gerencia { get; set; }
        public static string area { get; set; }
        public static string responsable { get; set; }
        public static string formulario { get; set; }
        public static string tipocorreo { get; set; }
        public static string de { get; set; }
        public static string para { get; set; }
        public static string cc { get; set; }
        public static string asunto { get; set; }
        public static string cuerpo { get; set; }
        public static string uuid { get; set; }
    }
}
