using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_comercial : cd_conexion
    {
        /// <summary>
        /// Guarda las liquidaciones en la tabla CMX_Liquidaciones usando un procedimiento almacenado con TVP.
        /// </summary>
        /// <param name="dt">DataTable con la estructura de CMX_Liquidaciones</param>
        /// <returns>Tupla con IdLiquidacion y Mensaje devuelto por el SP</returns>
        public static (int? IdLiq, string Mensaje) UpsertLiquidacionesSave(DataTable dt)
        {
            // Usa el método de la clase base para obtener la conexión
            using (var conexion = new cd_conexion().leerconexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GuardarLiquidacionesBulk", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter param = cmd.Parameters.AddWithValue("@Datos", dt);
                        param.SqlDbType = SqlDbType.Structured;
                        param.TypeName = "dbo.TP_CMX_Liquidaciones";

                        cmd.CommandTimeout = 300;

                        conexion.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int? idLiq = reader["IdLiq"] != DBNull.Value
                                    ? Convert.ToInt32(reader["IdLiq"])
                                    : (int?)null;

                                string mensaje = reader["Mensaje"]?.ToString() ?? "Operación completada.";

                                return (idLiq, mensaje);
                            }
                        }

                        return (null, "No se obtuvo respuesta del procedimiento almacenado.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error SQL al ejecutar el procedimiento de liquidaciones.", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error general al guardar las liquidaciones.", ex);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                        conexion.Close();
                }
            }
        }


        //PERSONAL COMEDOR
        public DataTable BuscarReporteLiquidacion(
            DateTime FecIng, DateTime FecFin, string empresa, string id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_REPORTE_LIQUIDACION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIng;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = empresa;
                comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }
        }



        // MOSTRAR LISTA DE GRUPO 
        public DataTable ListaEmpresa()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // 🔹 Consulta directa en lugar del procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT DISTINCT 1 id,growername FROM CMX_Liquidaciones", conex);
                comando.CommandType = CommandType.Text; // IMPORTANTE: es texto, no SP
                conex.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar conexión
            }
        }

        // MOSTRAR LISTA LIQUIDACION
        public DataTable ListaLiquidacion()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // 🔹 Consulta directa en lugar del procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT DISTINCT " +
                    " Fecha,ShipmentCode FROM CMX_Liquidaciones" +
                    " where estado='S' order by fecha desc ", conex);
                comando.CommandType = CommandType.Text; // IMPORTANTE: es texto, no SP
                conex.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar conexión
            }
        }


        // METODO PARA GUARDAR ACTUALIZAR PROG VOLCADO
        public void GuardarPesoPresentacion(
            int id, string descripcion, decimal peso, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_COMERCIAL_PESO_PRESENTACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Peso", SqlDbType.Decimal).Value = peso;

                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA GUARDAR HOMOLOGACION
        public void GuardarHomologacionPresentacionDestajo(
            int id, string descripcion, string extech
            , string codextech, string tipo, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_HOMOLOGACION_PRESENTACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Extech", SqlDbType.VarChar).Value = extech;
                    comando.Parameters.AddWithValue("@CodExtech", SqlDbType.VarChar).Value = codextech;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = codextech;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = codextech;

                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        //AGREGAR DESTAJO
        public DataTable AgregarDestajoUva(
            string codSticker, string tipo, string sessionId, string id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_INSERTAR_STICKER_PEDATEO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@CodSticker", SqlDbType.VarChar).Value = codSticker;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipo;
                comando.Parameters.AddWithValue("@SessionId", SqlDbType.VarChar).Value = sessionId;
                comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }
        }



        public DataTable ListaProveedorLiq()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PROVEEDOR_LIQUIDACION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }



    }
}
