using System;
using System.Configuration;
using System.Data;
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

        // =============================
        // 🔹 CARGA MASIVA (SqlBulkCopy)
        // =============================

        /// <summary>
        /// Sube la tabla de golpe con SqlBulkCopy a una tabla temporal y deja
        /// que el SP haga el MERGE. Los tres pasos van sobre la MISMA conexión:
        /// la tabla temporal solo existe mientras esa conexión siga abierta.
        /// Para cuando hay que insertar o actualizar según una clave.
        /// </summary>
        protected void CargaMasiva(DataTable datos, string tabla, string ddl, string sp)
        {
            if (datos == null || datos.Rows.Count == 0)
                return;

            using (var conexion = leerconexion())
            {
                conexion.Open();

                // 1) tabla temporal de la sesion
                using (var crear = new SqlCommand(ddl, conexion))
                {
                    crear.ExecuteNonQuery();
                }

                // 2) carga masiva
                using (var bulk = new SqlBulkCopy(conexion))
                {
                    bulk.DestinationTableName = tabla;
                    bulk.BulkCopyTimeout = 0;
                    foreach (DataColumn columna in datos.Columns)
                    {
                        bulk.ColumnMappings.Add(columna.ColumnName, columna.ColumnName);
                    }
                    bulk.WriteToServer(datos);
                }

                // 3) un solo MERGE contra la tabla real
                using (var comando = new SqlCommand(sp, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 0;
                    comando.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Inserta la tabla directamente en su destino real, sin temporal ni SP.
        /// Para las pantallas que primero borran y después vuelven a insertar
        /// todo: ahí no hay nada que comparar, solo filas nuevas.
        /// </summary>
        protected void CargaMasivaDirecta(DataTable datos, string tablaDestino)
        {
            if (datos == null || datos.Rows.Count == 0)
                return;

            using (var conexion = leerconexion())
            {
                conexion.Open();

                using (var bulk = new SqlBulkCopy(conexion))
                {
                    bulk.DestinationTableName = tablaDestino;
                    bulk.BulkCopyTimeout = 0;
                    foreach (DataColumn columna in datos.Columns)
                    {
                        bulk.ColumnMappings.Add(columna.ColumnName, columna.ColumnName);
                    }
                    bulk.WriteToServer(datos);
                }
            }
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
        /// Base URL del API REST de NISIRA (ver Manual del Programador - NISIRA API).
        /// </summary>
        public const string baseUrlNisira = "http://172.22.1.89:8081";

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
