using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;

namespace CapaDatos
{
    // =============================
    // 🔹 CONEXIÓN A BASE DE DATOS
    // =============================
    public class cd_conexion
    {
        private static string conexionstring;
        private static cd_conexion con = null;
        public cd_conexion()
        {
            string srtserver = ConfigurationManager.AppSettings["server"];
            conexionstring = "server=10.250.200.9;DataBase=BD_ASA; Integrated Security = false; uid=app; pwd=Asa2026.C@r@l";
        }

        public static cd_conexion CrearInstancia()
        {
            if (con == null)
            {
                con = new cd_conexion();
            }

            return con;
        }

        public SqlConnection leerconexion()
        {
            return new SqlConnection(conexionstring);
        }
    }

    // =============================
    // 🔹 CONEXIÓN A API EXTERNA
    // =============================
    public class cd_conexionApi : IDisposable
    {
        /// <summary>
        /// Base URL del servidor principal.
        /// </summary>
        public const string baseUrl = "https://app.agsantaazul.com:45490";
        //public const string baseUrl = "http://190.119.200.124:45490";

        public const string baseUrlExtech = "http://35.190.132.15:8989";
        /// <summary>
        /// Base URL del API (por ejemplo apiperu.dev).
        /// </summary>
        public const string baseUrlApi = "https://apiperu.dev";

        public const string baseUrlIndustrial = "http://101.44.10.88:8098";

        /// <summary>
        /// Tiempo máximo de espera para peticiones.
        /// </summary>
        public static readonly TimeSpan timeout = TimeSpan.FromMinutes(20);

        /// <summary>
        /// Cliente HTTP reutilizable.
        /// </summary>
        public readonly HttpClient client;

        public cd_conexionApi()
        {
            client = new HttpClient
            {
                Timeout = timeout
            };
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }

}
