using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_reportes : cd_conexion
    {
        //LISTA DE USUARIOS
        public DataTable BuscarListaUsuariosVenta(string usuario)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_REPORTES_USUARIO_VENTA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = usuario;
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

        //LISTA DE VENTA USUARIO
        public DataTable ListaVentaPorUsuarios(int user, DateTime fecini, DateTime fecfin)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_REPORTES_VENTA_POR_USUARIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@user", SqlDbType.Int).Value = user;
                comando.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = fecfin;
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

        //LISTA DE COMPRA POR USUARIO
        public DataTable ListaCompraPorUsuarios(int user, DateTime fecini, DateTime fecfin)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_REPORTES_COMPRA_POR_USUARIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@user", SqlDbType.Int).Value = user;
                comando.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = fecfin;
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

        //VENTAS EN DATA SET
        public DataSet MostrarVentasPorUser_Dst(int user, DateTime fecini, DateTime fecfin)
        {
            DataSet dst = new DataSet();
            SqlConnection conex = new SqlConnection();
            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_REPORTES_VENTA_POR_USUARIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@user", SqlDbType.Int).Value = user;
                comando.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = fecfin;
                comando.ExecuteNonQuery();
                return dst;
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


        //LISTA DE USUARIO 
        public bool BuscarUsuariosPorVenta(int user)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_USUARIOS_POR_VENTA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@user", SqlDbType.Int).Value = user;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_reportes.user = reader.GetInt32(0);
                            ce_reportes.nombres = reader.GetString(1);
                            ce_reportes.sede = reader.GetString(2);
                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }

        }

        //LISTA DE producto almacen
        public DataTable ListStockPorAlmacen(string almacen, string producto, string talla)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_STOCK_PRODUCTO_ALMACENES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@almacen", SqlDbType.VarChar).Value = almacen;
                comando.Parameters.AddWithValue("@producto", SqlDbType.VarChar).Value = producto;
                comando.Parameters.AddWithValue("@talla", SqlDbType.VarChar).Value = talla;
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


        //LISTA DE producto 
        public DataTable ListStockProducto(string almacen, string producto, string talla)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_STOCK_PRODUCTO_", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@almacen", SqlDbType.VarChar).Value = almacen;
                comando.Parameters.AddWithValue("@producto", SqlDbType.VarChar).Value = producto;
                comando.Parameters.AddWithValue("@talla", SqlDbType.VarChar).Value = talla;
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



        //
    }
}
