using System;
using System.Configuration;

namespace CapaEntidad
{
    public static class ce_correo
    {
        public static int codCorreo { get; set; }
        public static DateTime? fechaProcesoIni { get; set; }
        public static DateTime? fechaProcesoFin { get; set; }
        public static DateTime? fecha { get; set; }
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
        public static string rutaArchivoAdjunto { get; set; }


        public static string ServidorSMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTP_Server"];
            }
        }

        public static int PuertoSMTP
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            }
        }

        public static string UsuarioSMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTP_User"];
            }
        }

        public static string PasswordSMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTP_Password"];
            }
        }
    }

}
