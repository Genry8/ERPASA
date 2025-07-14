using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_logistica : cd_conexion
    {
        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaTallaProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_TALLA_PRODUCTO", conex);
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


        // MOSTRAR LISTA DE GRUPO 
        public DataTable ListaGrupoProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GRUPO_PRODUCTO", conex);
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

        // MOSTRAR LISTA DE TIPO 
        public DataTable ListaTipoProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_TIPO_PRODUCTO", conex);
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

        // MOSTRAR LISTA DE GRUPO 
        public DataTable ListaEmpresaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_EMPRESA_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoEmpresaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_EMPRESA_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoEmpresa(string codemp)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_EMPRESA_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codemp;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaSedeTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_SEDE_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoSedeMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_SEDE_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoSede(string codsed)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_SEDE_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codsed;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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



        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaGerenciaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GERENCIA_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoGerenciaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_GERENCIA_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoGerencia(string codger)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_GERENCIA_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodGer", SqlDbType.VarChar).Value = codger;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaAreaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_AREA_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoAreaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_AREA_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoArea(string codarea)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_AREA_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codarea;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaEstActivoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ESTACTIVO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoEstActivoMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ESTACTIVO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoEstActivo(string codEstActivo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ESTACTIVO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEst", SqlDbType.VarChar).Value = codEstActivo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaSisOperativoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_SISOPERATIVO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoSisOperativoMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_SISOPERATIVO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoSisOperativo(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_SISOPERATIVO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSisOpe", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaMemoriaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_MEMORIA_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoMemoriaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MEMORIA_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoMemoria(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MEMORIA_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMem", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaMarcaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_MARCA_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoMarcaTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MARCA_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoMarcaTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MARCA_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMar", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaOrigenActTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ORIGENACTIVO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoOrigenActTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ORIGENACTIVO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoOrigenActTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ORIGENACTIVO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodOrg", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaProcesadorTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PROCESADOR_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoProcesadorTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PROCESADOR_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoProcesadorTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PROCESADOR_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodProc", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaDiscoDuroTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_DISCODURO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoDiscoDuroTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_DISCODURO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoDiscoDuroTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_DISCODURO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodDD", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaModeloTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_MODELO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoModeloTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MODELO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoModeloTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MODELO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        //
        //EQUIPO TI PERIFERICO
        //

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaPerifericoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PERIFERICO_TI", conex);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaPerifericoActTI(string des)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PERIFERICOACT_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = des;
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoPerifericoTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PERIFERICO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoPerifericoTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PERIFERICO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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


        // MOSTRAR LISTA DE PLAN MOVIL
        public DataTable ListaPlanMovilTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PLANMOVIL_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE PLAN MOVIL
        public bool UltimoCodigoPlanMovilTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PLANMOVIL_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PLAN MOVIL
        public bool BuscExisteCodigoPlanMovilTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PLANMOVIL_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPln", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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


        // MOSTRAR LISTA ACTIVO FILTRO

        public DataTable ListaActivoFiltroTI(string desc, string marca, string modelo
            , string serie, string imei, string macether, string macwifi)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_FILTRO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@DesAct", SqlDbType.VarChar).Value = desc;
                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@modelo", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.AddWithValue("@serie", SqlDbType.VarChar).Value = serie;
                comando.Parameters.AddWithValue("@imei", SqlDbType.VarChar).Value = imei;
                comando.Parameters.AddWithValue("@macether", SqlDbType.VarChar).Value = macether;
                comando.Parameters.AddWithValue("@macwifi", SqlDbType.VarChar).Value = macwifi;
                comando.ExecuteNonQuery();
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


        // MOSTRAR LISTA activo
        public DataTable ListaActivoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE PLAN MOVIL
        public bool UltimoCodigoActivoTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ACTIVO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PLAN MOVIL
        public bool BuscExisteCodigoActivoTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ACTIVO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
                            ce_logistica.CodSerieExist = reader.GetString(1);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PLAN MOVIL
        public bool BuscExisteCodigoActivoTIS(string cod, string serie)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ACTIVO_EXISTENTE_REG"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodSerie", SqlDbType.VarChar).Value = serie;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
                            ce_logistica.CodSerieExist = reader.GetString(1);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PLAN MOVIL
        public bool BuscExisteCodigoActivoPerTI(string cod, string codper)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ACTIVOPER_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codper;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
                            ce_logistica.codperTI = reader.GetString(1);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PLAN MOVIL
        public bool BuscExisteCodigoActivoPerEstTI(string cod, string codper)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ACTIVOPEREST_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codper;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
                            ce_logistica.codperTI = reader.GetString(1);
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

        // MOSTRAR LISTA DE ASIGNACION
        public DataTable ListaAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACION_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE ASIGNACION
        public bool UltimoCodigoAsignacionTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ASIGNACION_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE ASIGNACION
        public bool BuscExisteCodigoAsignacionTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ASIGNACION_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
                            ce_logistica.CodSerieExist = reader.GetString(1);
                            ce_logistica.CodUsuarioExist = reader.GetString(2);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PLAN MOVIL
        public bool BuscExisteCodigoAsignacionActivoTI(string cod, int Item)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ASIGNACIONACTIVO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = Item;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodActAsigTI = reader.GetString(0);
                            ce_logistica.ItemAsigTI = reader.GetInt32(1);
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

        //
        //
        // MOSTRAR LISTA DE ASIGNACION
        public DataTable ListaAsignacionBuscTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_TI", conex);
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

        //
        //lista de asigancion general
        //


        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaAsignacionFiltroTI(string emp, string sed, string ger, string area, string dni, string user, string activo
            , string estact, string origen, string marca, string modelo, string serie, string imei, string macether, string macwifi)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACION_FILTROS_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@ger", SqlDbType.VarChar).Value = ger;
                comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = user;
                comando.Parameters.AddWithValue("@activo", SqlDbType.VarChar).Value = activo;
                comando.Parameters.AddWithValue("@estact", SqlDbType.VarChar).Value = estact;
                comando.Parameters.AddWithValue("@origen", SqlDbType.VarChar).Value = origen;
                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@modelo", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.AddWithValue("@serie", SqlDbType.VarChar).Value = serie;
                comando.Parameters.AddWithValue("@ime", SqlDbType.VarChar).Value = imei;
                comando.Parameters.AddWithValue("@macether", SqlDbType.VarChar).Value = macether;
                comando.Parameters.AddWithValue("@macwhifi", SqlDbType.VarChar).Value = macwifi;
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

        // MOSTRAR LISTA DE ASIGNACION POR EMPRESA
        public DataTable ListaAsignacionEmpTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONEMPRESA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR SEDE
        public DataTable ListaAsignacionSedeTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONSEDE_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR GERENCIA
        public DataTable ListaAsignacionGerenciaTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONGERENCIA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@ger", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR AREA
        public DataTable ListaAsignacionAreaTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONAREA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR DNI
        public DataTable ListaAsignacionDniTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONDNI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionUsuarioTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONUSUARIO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionActivoTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONACTIVO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@act", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionEstActivoTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONESTADOACTIVO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@estact", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionOrigenBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONORIGEN_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@org", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionMarcaBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONMARCA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@mar", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionModeloBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONMODELO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@mod", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionSerieBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONSERIE_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@serie", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionImeiBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONIMEI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@imei", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionMacEtherBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONETHER_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@ether", SqlDbType.VarChar).Value = desc;
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

        // MOSTRAR LISTA DE ASIGNACION POR USUARIO
        public DataTable ListaAsignacionMacWifiBuscTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONWIFI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@wifi", SqlDbType.VarChar).Value = desc;
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

        //LISTA DE ASIGANACION POR FILTRO


        public DataTable ListaAsignacionFiltroTI(string desc, string marca, string modelo
            , string serie, string imei, string macether, string macwifi)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACION_LISTA_ACTIVO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@DesAct", SqlDbType.VarChar).Value = desc;
                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@modelo", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.AddWithValue("@serie", SqlDbType.VarChar).Value = serie;
                comando.Parameters.AddWithValue("@imei", SqlDbType.VarChar).Value = imei;
                comando.Parameters.AddWithValue("@macether", SqlDbType.VarChar).Value = macether;
                comando.Parameters.AddWithValue("@macwifi", SqlDbType.VarChar).Value = macwifi;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR DESCRIPCION        
        //
        public DataTable ListaAsignacionDescripcionTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_ACTIVO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@DesAct", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR MARCA        
        //
        public DataTable ListaAsignacionMarcaTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_MARCA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@DesMar", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR MODELO        
        //
        public DataTable ListaAsignacionModeloTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_MODELO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@DesMod", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR SERIE        
        //
        public DataTable ListaAsignacionSerieTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_SERIE_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@serie", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR SERIE        
        //
        public DataTable ListaAsignacionIMEITI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_IMEI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@imei", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR SERIE        
        //
        public DataTable ListaAsignacionMacEtherTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_MACETHER_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@MacEther", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ASIGNACION POR SERIE        
        //
        public DataTable ListaAsignacionMacWifiTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONBUSC_MACWIFI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@MacWifi", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //

        // MOSTRAR LISTA DE PERSONAL POR DNI
        public DataTable ListaPersonalAsigTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPER_TI", conex);
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

        // MOSTRAR LISTA DE PERSONAL POR DNI
        public DataTable ListaPersonalAsigST()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPER_ST", conex);
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

        // MOSTRAR LISTA DE PERSONAL POR DNI
        public DataTable ListaPersonalAsigDniTI(string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERDNI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
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

        // MOSTRAR LISTA DE PERSONAL POR APELLIDO
        public DataTable ListaPersonalAsigApeTI(string ape)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERAPE_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@ape", SqlDbType.VarChar).Value = ape;
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

        // MOSTRAR LISTA DE PERSONAL POR NOMBRE
        public DataTable ListaPersonalAsigNomTI(string nom)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERNOM_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = nom;
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

        // MOSTRAR LISTA DE PERSONAL POR AREA
        public DataTable ListaPersonalAsigAreaTI(string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERAREA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
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
        //SSTT
        //

        // MOSTRAR LISTA DE PERSONAL POR DNI
        public DataTable ListaPersonalAsigDniST(string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERDNI_ST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
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

        // MOSTRAR LISTA DE PERSONAL POR APELLIDO
        public DataTable ListaPersonalAsigApeST(string ape)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERAPE_ST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@ape", SqlDbType.VarChar).Value = ape;
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

        // MOSTRAR LISTA DE PERSONAL POR NOMBRE
        public DataTable ListaPersonalAsigNomST(string nom)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERNOM_ST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = nom;
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

        // MOSTRAR LISTA DE PERSONAL POR AREA
        public DataTable ListaPersonalAsigAreaST(string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ASIGNACIONPERAREA_ST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
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
        //LISTA PERIFERICO POR DESCRIPCION        
        //
        public DataTable ListaPerifericoDescripcionTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PERIFERICO_DESCRIPCION_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@DesPer", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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

        // METODO PARA BUSCAR POR DNI AL USUARIO

        public DataTable ListaPersonalTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCARPERSONAL_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.ExecuteNonQuery();
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


        // METODO PARA BUSCAR POR DNI AL USUARIO

        public DataTable ListaPersonalDniTI(string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCARPERSONALDNI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                comando.ExecuteNonQuery();
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

        //LISTA PERSONAL EXISTENTE
        public bool ListaPersonalExistenteTI(string dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_DNI_DE_PERSONAL_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.cod_userTI = reader.GetInt32(0);
                            ce_logistica.dni_userTI = reader.GetString(1);
                            ce_logistica.dni_userCargoTI = reader.GetString(2);
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


        //
        //LISTA PERIFERICO POR SERIE        
        //
        public DataTable ListaPerifericoSerieTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PERIFERICO_SERIE_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA PERIFERICO POR IMEI        
        //
        public DataTable ListaPerifericoIMEITI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PERIFERICO_IMEI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@IMEI", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA PERIFERICO POR IMEI        
        //
        public DataTable ListaPerifericoModeloTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PERIFERICO_MODELO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //DATOS PARA BUSCAR ACTIVOS POR FILTRO
        //

        //
        //LISTA ACTIVO POR ACTIVO    
        //
        public DataTable ListaActivoActivoTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_ACTIVO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR ACTIVO    
        //
        public DataTable ListaActivoOrigenTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_ORIGEN_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR PROCESADOR    
        //
        public DataTable ListaActivoProcesadorTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_PROCESADOR_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR MEMORIA    
        //
        public DataTable ListaActivoMemoriaTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_MEMORIA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR MARCA    
        //
        public DataTable ListaActivoMarcaTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_MARCA_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR MODELO    
        //
        public DataTable ListaActivoModeloTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_MODELO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR SERIE    
        //
        public DataTable ListaActivoSerieTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_SERIE_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR IMEI    
        //
        public DataTable ListaActivoImeiTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_IMEI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR MACETHERNET 
        //
        public DataTable ListaActivoMacEthernetTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_MACETHERNET_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR MACWIFI
        //
        public DataTable ListaActivoMacWifiTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_MACWIFI_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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
        //LISTA ACTIVO POR MACEQUIPO
        //
        public DataTable ListaActivoMacEquipoTI(string desc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ACTIVO_MACEQUIPO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = desc;
                comando.ExecuteNonQuery();
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaTipoActivoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_TIPOACTIVO_TI", conex);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoTipoActivoTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TIPOACTIVO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscExisteCodigoTipoActivoTI(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TIPOACTIVO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodTA", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoProveedorTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PROVEEDOR_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        //
        //DATOS PARA COMBOBOX
        //

        // MOSTRAR LISTA DE CONDICION PRODUCTO
        public DataTable ListaGerencia()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_AREATI", conex);
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

        // MOSTRAR LISTA DE CONDICION PRODUCTO
        public DataTable ListaCBTipoActivoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_TIPOACTIVOTI", conex);
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

        // MOSTRAR LISTA DE CONDICION PRODUCTO
        public DataTable ListaCBTipoActivoTI2()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TIPOACTIVOTI_TI", conex);
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

        // MOSTRAR LISTA DE
        public DataTable ListaCBOrigenActivoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_ORIGENACTIVOTI", conex);
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

        // MOSTRAR LISTA DE SISTEMA OPERATIVO
        public DataTable ListaCBSisOperativoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_SISOPERATIVOTI", conex);
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

        // MOSTRAR LISTA DE PROCESADOR
        public DataTable ListaCBProcesadorTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_PROCESADORTI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaCBMemoriaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_MEMORIATI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaCBDiscoDuroTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_DISCODUROTI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaCBMarcaTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_MARCATI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaCBModeloTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_MODELOTI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaCBProveedorTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_PROVEEDORTI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaCBCabezal()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CABEZAL", conex);
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

        // MOSTRAR LISTA DE PLAN MOVIL
        public DataTable ListaCBPlanMovilTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_PLANMOVILTI", conex);
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

        //
        //COMBO BOX PAARA ASIGNACION DE ACTIVOS
        //

        // MOSTRAR LISTA DE EMPRESA
        public DataTable ListaCBEmpresaAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_EMPRESAASIGTI", conex);
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

        // MOSTRAR LISTA DE EMPRESA
        public DataTable ListaCBEmpresaComedor()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_EMPRESA_COMEDOR", conex);
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

        // MOSTRAR LISTA DE EMPRESA
        public DataTable ListaCBAreaComedor()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_AREA_COMEDOR", conex);
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

        // MOSTRAR LISTA SEDE COMEDOR
        public DataTable ListaSedeComedor()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_SEDE_COMEDOR", conex);
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


        // MOSTRAR LISTA TIPO PERSONAL
        public DataTable ListaTipoPersonal()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TipoPersonal", conex);
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


        // MOSTRAR LISTA SEDE COMEDOR
        public DataTable ListaSedeComedorEmpresa(string emp, string personal)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_SEDE_COMEDOR_EMPRESA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@personal", SqlDbType.VarChar).Value = personal;
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


        public DataTable ListaCBEmpresaTodoAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_EMPRESATODOASIGTI", conex);
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

        public DataTable ListaTransportistas()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_LISTATRANSPORTISTAS", conex);
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


        public DataTable ListaCBFundo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_FUNDO", conex);
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

        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBSedeAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_SEDEASIGTI", conex);
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

        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBSedeTodoAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_SEDETODOASIGTI", conex);
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


        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBSedeEmpresaAsignacionTI(string emp)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_SEDEEMPRESAASIGTI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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

        public DataTable ListaCBSedeEmpresaTodoAsignacionTI(string emp)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_SEDEEMPRETODOSAASIGTI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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


        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBAreaAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_AREAASIGTI", conex);
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

        public DataTable ListaCBAreaTodoAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_AREATODOASIGTI", conex);
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


        public DataTable ListaCBAreaTodoInspeccionSST()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_AREATODO_INSPECCIONSST", conex);
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


        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBTipoActAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_TIPOACTASIGTI", conex);
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

        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBEstActivoAsignacionTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_ESTACTIVOASIGTI", conex);
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

        // MOSTRAR LISTA DE SEDE
        public DataTable ListaCBEstCargoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CARGO_TI", conex);
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


        //ListaCBEstActivoAsignacionTI


























        // MOSTRAR LISTA DE ALMACEN 
        public DataTable ListaAlmacenProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GRUPO_ALMACEN", conex);
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

        // MOSTRAR LISTA DE ALMACEN 
        public DataTable ListaProveedorProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GRUPO_PROVEEDOR", conex);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE TALLA
        public bool BuscExisteCodigoTalla(string codtalla)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TALLA_PRODUCTO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codtalla;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE TALLA
        public bool BuscExisteCodigoMarca(string codmarca)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MARCA_PRODUCTO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codmarc", SqlDbType.VarChar).Value = codmarca;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE TALLA
        public bool BuscExisteCodigoGrupo(string codgrupo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_GRUPO_PRODUCTO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codgrup", SqlDbType.VarChar).Value = codgrupo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE TIPO
        public bool BuscExisteCodigoTipo(string codtipo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TIPO_PRODUCTO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtip", SqlDbType.VarChar).Value = codtipo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE GRUPO
        public bool BuscExisteCodigoAlm(string codalm)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ALMACEN_PRODUCTO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE PROVEEDOR
        public bool BuscExisteCodigoProveedor(string codprov)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PROVEEDOR_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codprv", SqlDbType.VarChar).Value = codprov;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiExist = reader.GetString(0);
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

        // METODO PARA LLAMAR EL ULTIMO REGISTRO DE PRODUCTO
        public bool UltimoCodigoTallaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TALLA_PRODUCTO_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodTiMas_Busc = reader.GetString(0);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE MARCA
        public bool UltimoCodigoMarcaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_MARCA_PRODUCTO_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE MARCA
        public bool UltimoCodigoGrupoMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_GRUPO_PRODUCTO_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE MARCA
        public bool UltimoCodigoTipoMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TIPO_PRODUCTO_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigo = reader.GetInt32(0);
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


        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodigoProveedorMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PROVEEDOR_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.codigoprv = reader.GetInt32(0);
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

        //
        // METODO PARA GUARDAR TALLA
        public void GuardarTalla(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALLA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;

                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR TALLA
        public void ActualizarTalla(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALLA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;

                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR TALLA
        public void EliminarTalla(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_TALLA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR MARCA
        public void GuardarMarca(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MARCA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;

                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR MARCA
        public void ActualizarMarca(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MARCA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;

                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR MARCA
        public void EliminarMarca(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_MARCA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GRUPO
        public void GuardarGrupo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_GRUPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;

                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GRUPO
        public void ActualizarGrupo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_GRUPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;

                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GRUPO
        public void EliminarGrupo(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_GRUPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GRUPO
        public void GuardarTipo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TIPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;

                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GRUPO
        public void ActualizarTipo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TIPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;

                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@abrund", SqlDbType.VarChar).Value = abrund;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GRUPO
        public void EliminarTipo(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_TIPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtIP", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR COLOR
        public void GuardarEmpresa(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_EMPRESATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GRUPO
        public void ActualizarEmpresa(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_EMPRESATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GRUPO
        public void EliminarEmpresa(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_EMPRESATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR SEDE
        public void GuardarSede(string codigo, string descripcion, string empresa, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_SEDETI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR SEDE
        public void ActualizarSede(string codigo, string descripcion, string empresa, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_SEDETI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR SEDE
        public void EliminarSede(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_SEDETI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarGerencia(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_GERENCIATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodGer", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesGer", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarGerencia(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_GERENCIATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodGer", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesGer", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarGerencia(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_GERENCIATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodGer", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarArea(string codigo, string descripcion, string CodGer, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_AREATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesArea", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@CodGer", SqlDbType.VarChar).Value = CodGer;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarArea(string codigo, string descripcion, string CodGer, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_AREATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesArea", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@CodGer", SqlDbType.VarChar).Value = CodGer;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarArea(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_AREATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarEstActivo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ESTACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEst", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesEst", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarEstActivo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ESTACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEst", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesEst", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarEstActivo(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ESTACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodEst", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarSisOperativo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_SISOPERATIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSisOpe", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesSisOpe", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarSisOperativo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_SISOPERATIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSisOpe", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesSisOpe", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarSisOperativo(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_SISOPERATIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodSisOpe", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarMemoria(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MEMORIATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMEm", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesMem", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarMemoria(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MEMORIATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMem", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesMem", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarMemoria(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_MEMORIATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMem", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR GERENCIA
        public void GuardarMarcaTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MARCATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMar", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesMar", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarMarcaTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MARCATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMar", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesMar", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarMarcaTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_MARCATI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMar", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarOrigenActTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ORIGENACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodOrg", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesOrg", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarOrigenActTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ORIGENACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodOrg", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesOrg", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarOrigenActTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ORIGENACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodOrg", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarProcesadorTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PROCESADORTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodProc", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesProc", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarProcesadorTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PROCESADORTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodProc", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesProc", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarProcesadorTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PROCESADORTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodProc", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR GERENCIA
        public void GuardarDiscoDuroTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_DISCODUROTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodDD", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesDD", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarDiscoDuroTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_DISCODUROTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodDD", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesDD", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarDiscoDuroTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_DISCODUROTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodDD", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR MODELO
        public void GuardarModeloTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MODELOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesMod", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarModeloTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MODELOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesMod", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarModeloTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_MODELOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodMod", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR PERIFERICO
        public void GuardarTipoActivoTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TIPOACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodTA", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesTA", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarTipoActivoTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TIPOACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodTA", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesTA", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarTipoActivoTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_TIPOACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodTA", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        //EQUIPO TI
        //

        // METODO PARA GUARDAR PERIFERICO
        public void GuardarPerifericoTI(string codigo, string descripcion, string serie, string imei, string modelo, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PERIFERICOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesPer", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = serie;
                    comando.Parameters.AddWithValue("@IMEI", SqlDbType.VarChar).Value = imei;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarPerifericoTI(string codigo, string descripcion, string serie, string imei, string modelo, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERIFERICOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesPer", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = serie;
                    comando.Parameters.AddWithValue("@IMEI", SqlDbType.VarChar).Value = imei;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarPerifericoTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PERIFERICOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarActPerifericoTI(string codigo, string descripcion, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ACTPERIFERICOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = descripcion;
                    //comando.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = serie;
                    //comando.Parameters.AddWithValue("@IMEI", SqlDbType.VarChar).Value = imei;
                    //comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    //comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR PLAN MOVIL
        public void GuardarPlanMovilTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PLANMOVILTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPln", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesPln", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GERENCIA
        public void ActualizarPlanMovilTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PLANMOVILTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPln", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesPln", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GERENCIA
        public void EliminarPlanMovilTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PLANMOVILTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodPln", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR ACTIVO
        public void GuardarActivoTI(string codigo, string descripcion, string estact, string codorg, string codsisope, string codproc, string codmem, string codDD
            , string codmar, string codmod, string codprv, string numord, string numcel, string plan, string serie, string imei, string macether
            , string macwifi, string macequipo, DateTime feccom, DateTime fecgar, string obs1, string obs2, string estado
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesAct", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@EstAct", SqlDbType.VarChar).Value = estact;
                    comando.Parameters.AddWithValue("@CodOrg", SqlDbType.VarChar).Value = codorg;
                    comando.Parameters.AddWithValue("@CodSisOpe", SqlDbType.VarChar).Value = codsisope;
                    comando.Parameters.AddWithValue("@CodProc", SqlDbType.VarChar).Value = codproc;
                    comando.Parameters.AddWithValue("@CodMem", SqlDbType.VarChar).Value = codmem;
                    comando.Parameters.AddWithValue("@CodDD", SqlDbType.VarChar).Value = codDD;
                    comando.Parameters.AddWithValue("@CodMar", SqlDbType.VarChar).Value = codmar;
                    comando.Parameters.AddWithValue("@CodMod", SqlDbType.VarChar).Value = codmod;
                    comando.Parameters.AddWithValue("@CodPrv", SqlDbType.VarChar).Value = codprv;
                    comando.Parameters.AddWithValue("@Numord", SqlDbType.VarChar).Value = numord;
                    comando.Parameters.AddWithValue("@NumCel", SqlDbType.VarChar).Value = numcel;
                    comando.Parameters.AddWithValue("@Plan", SqlDbType.VarChar).Value = plan;
                    comando.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = serie;
                    comando.Parameters.AddWithValue("@IMEI", SqlDbType.VarChar).Value = imei;
                    comando.Parameters.AddWithValue("@MacEther", SqlDbType.VarChar).Value = macether;
                    comando.Parameters.AddWithValue("@MacWifi", SqlDbType.VarChar).Value = macwifi;
                    comando.Parameters.AddWithValue("@MacEquipo", SqlDbType.VarChar).Value = macequipo;
                    comando.Parameters.AddWithValue("@FecCom", SqlDbType.DateTime).Value = feccom;
                    comando.Parameters.AddWithValue("@FecGar", SqlDbType.DateTime).Value = fecgar;
                    comando.Parameters.AddWithValue("@Obs1", SqlDbType.VarChar).Value = obs1;
                    comando.Parameters.AddWithValue("@Obs2", SqlDbType.VarChar).Value = obs2;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR DATAGRID ACTIVO - PERIFERICO
        public DataTable GuardarActivoPerTI(string codigo, int item, string codper, string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_edit, int useedit)
        {

            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ACTIVOPERTI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codper;
                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
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

        // METODO PARA ACTUALIZAR ACTIVO
        public void ActualizarActivoTI(string codigo, string descripcion, string estact, string codorg, string codsisope, string codproc, string codmem, string codDD
            , string codmar, string codmod, string codprv, string numord, string numcel, string plan, string serie, string imei, string macether
            , string macwifi, string macequipo, DateTime feccom, DateTime fecgar, string obs1, string obs2, string estado
            , DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesAct", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@EstAct", SqlDbType.VarChar).Value = estact;
                    comando.Parameters.AddWithValue("@CodOrg", SqlDbType.VarChar).Value = codorg;
                    comando.Parameters.AddWithValue("@CodSisOpe", SqlDbType.VarChar).Value = codsisope;
                    comando.Parameters.AddWithValue("@CodProc", SqlDbType.VarChar).Value = codproc;
                    comando.Parameters.AddWithValue("@CodMem", SqlDbType.VarChar).Value = codmem;
                    comando.Parameters.AddWithValue("@CodDD", SqlDbType.VarChar).Value = codDD;
                    comando.Parameters.AddWithValue("@CodMar", SqlDbType.VarChar).Value = codmar;
                    comando.Parameters.AddWithValue("@CodMod", SqlDbType.VarChar).Value = codmod;
                    comando.Parameters.AddWithValue("@CodPrv", SqlDbType.VarChar).Value = codprv;
                    comando.Parameters.AddWithValue("@Numord", SqlDbType.VarChar).Value = numord;
                    comando.Parameters.AddWithValue("@NumCel", SqlDbType.VarChar).Value = numcel;
                    comando.Parameters.AddWithValue("@Plan", SqlDbType.VarChar).Value = plan;
                    comando.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = serie;
                    comando.Parameters.AddWithValue("@IMEI", SqlDbType.VarChar).Value = imei;
                    comando.Parameters.AddWithValue("@MacEther", SqlDbType.VarChar).Value = macether;
                    comando.Parameters.AddWithValue("@MacWifi", SqlDbType.VarChar).Value = macwifi;
                    comando.Parameters.AddWithValue("@MacEquipo", SqlDbType.VarChar).Value = macequipo;
                    comando.Parameters.AddWithValue("@FecCom", SqlDbType.DateTime).Value = feccom;
                    comando.Parameters.AddWithValue("@FecGar", SqlDbType.DateTime).Value = fecgar;
                    comando.Parameters.AddWithValue("@Obs1", SqlDbType.VarChar).Value = obs1;
                    comando.Parameters.AddWithValue("@Obs2", SqlDbType.VarChar).Value = obs2;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR ACTIVO
        public void ActualizarActivoPerTI(string codigo, string codper, string obs, string estado, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@DesAct", SqlDbType.VarChar).Value = codper;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ELIMINAR ACTIVO
        public void EliminarActivoTI(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ACTIVOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        public void EliminarActivoPer2TI(string codigo, string codper)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ACTIVOPER2TI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@CodPer", SqlDbType.VarChar).Value = codper;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        //METODO PARA REGISTRAR ASIGNACION
        //

        // METODO PARA GUARDAR DATAGRID ACTIVO - PERIFERICO
        public DataTable GuardarAsignacionActTI(string codigo, int item, string codact, string codemp, string codsede, string area, string dni,
            string estact, string devevent, string obs1, string obs2, string num, string cant, string ubic, DateTime fecent, DateTime fecdev,
             string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {

            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ASIGNACIONACTIVOTI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codigo;
                comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codemp;
                comando.Parameters.AddWithValue("@CodSede", SqlDbType.VarChar).Value = codsede;
                comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@CodUser", SqlDbType.VarChar).Value = dni;
                comando.Parameters.AddWithValue("@CodEst", SqlDbType.VarChar).Value = estact;
                comando.Parameters.AddWithValue("@DevEvent", SqlDbType.VarChar).Value = devevent;
                comando.Parameters.AddWithValue("@Obs1", SqlDbType.VarChar).Value = obs1;
                comando.Parameters.AddWithValue("@Obs2", SqlDbType.VarChar).Value = obs2;
                comando.Parameters.AddWithValue("@Num", SqlDbType.VarChar).Value = num;
                comando.Parameters.AddWithValue("@Cant", SqlDbType.VarChar).Value = cant;
                comando.Parameters.AddWithValue("@Ubic", SqlDbType.VarChar).Value = ubic;
                comando.Parameters.AddWithValue("@FecEnt", SqlDbType.DateTime).Value = fecent;
                comando.Parameters.AddWithValue("@FecDev", SqlDbType.DateTime).Value = fecdev;

                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
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

        // METODO PARA ACTUALIZAR ACTIVO
        public void ActualizarAsignacionActTI(string codigo, int item, string codemp, string codsede, string area, string dni,
            string estact, string devevent, string obs1, string obs2, string num, string cant, string ubic, DateTime fecent, DateTime fecdev,
             string estado, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ASIGNACIONTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codemp;
                    comando.Parameters.AddWithValue("@CodSede", SqlDbType.VarChar).Value = codsede;
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@CodUser", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@CodEst", SqlDbType.VarChar).Value = estact;
                    comando.Parameters.AddWithValue("@DevEvent", SqlDbType.VarChar).Value = devevent;
                    comando.Parameters.AddWithValue("@Obs1", SqlDbType.VarChar).Value = obs1;
                    comando.Parameters.AddWithValue("@Obs2", SqlDbType.VarChar).Value = obs2;
                    comando.Parameters.AddWithValue("@Num", SqlDbType.VarChar).Value = num;
                    comando.Parameters.AddWithValue("@Cant", SqlDbType.VarChar).Value = cant;
                    comando.Parameters.AddWithValue("@Ubic", SqlDbType.VarChar).Value = ubic;
                    comando.Parameters.AddWithValue("@FecEnt", SqlDbType.DateTime).Value = fecent;
                    comando.Parameters.AddWithValue("@FecDev", SqlDbType.DateTime).Value = fecdev;

                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ELIMINAR ACTIVO
        public void EliminarAsignacionActTI(string codigo, string item, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ASIGANCIONTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@item", SqlDbType.VarChar).Value = item;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodEntregaDevolucionTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_ENTREGADEVOLUCION_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodEntDevTI = reader.GetInt32(0);
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

        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE COLOR
        public bool UltimoCodMantenimientoEquipoTIMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MANTENIMIENTOEQUIPO_TI_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodMantTI = reader.GetInt32(0);
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

        //
        //METODO PARA REGISTRAR ENTREGA DEVOLUCION
        //

        // MOSTRAR LISTA DE TIPO 
        public DataTable ListaDevolucionEntregaAsigTI(string codasig, string codact, int dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_ENTREGADEVOLUCION_ASIGACT_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE ASIGNACION
        public bool BuscExisteCodEntregaDevolucionAsigTI(string cod, string codasig, string codact, int dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCARCODIGO_ENTREGADEVOLUCION_ASIGACT_TI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodAsigEntDevTI = reader.GetString(0);
                            ce_logistica.CodActEntDevTI = reader.GetString(1);
                            ce_logistica.DniEntDevTI = reader.GetInt32(2);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE ASIGNACION
        public bool EliminarCodEntregaDevolucionAsigTI(string cod, string codasig, string codact, int dni, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ENTREGADEVOLUCION_ASIGACT_TI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodAsigMantTI = reader.GetString(0);
                            ce_logistica.CodActMantTI = reader.GetString(1);
                            ce_logistica.DniMantTI = reader.GetInt32(2);
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

        // METODO PARA GUARDAR DATAGRID ACTIVO - PERIFERICO
        public DataTable GuardarEntregaDevolucionAsigActTI(string cod, string codasig, string codact, int dni, string tipmov, DateTime fecha,
             string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {

            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ENTREGADEVOLUCION_ASIGACT_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                comando.Parameters.AddWithValue("@TipMov", SqlDbType.VarChar).Value = tipmov;
                comando.Parameters.AddWithValue("@Fec", SqlDbType.DateTime).Value = fecha;

                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
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

        // METODO PARA ACTUALIZAR ACTIVO
        public void ActualizarEntregaDevolucionAsigActTI(string cod, string codasig, string codact, int dni, string tipmov, DateTime fecha,
             string estado, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ENTREGADEVOLUCION_ASIGACT_TI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                    comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                    comando.Parameters.AddWithValue("@TipMov", SqlDbType.VarChar).Value = tipmov;
                    comando.Parameters.AddWithValue("@Fec", SqlDbType.DateTime).Value = fecha;

                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR MANTENIMIENTO DE EQUIPO
        public DataTable GuardarMantenimientoEquipoAsigActTI(string cod, string codasig, string codact, int dni, string tipmant, DateTime fecha,
             string estado, string obs, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {

            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_MANTENIMIENTO_EQUIPO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                comando.Parameters.AddWithValue("@TipMant", SqlDbType.VarChar).Value = tipmant;
                comando.Parameters.AddWithValue("@Fec", SqlDbType.DateTime).Value = fecha;

                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
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

        // MOSTRAR LISTA DE TIPO 
        public DataTable ListaMantenimientoEquipoAsigTI(string codasig, string codact, int dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_MANTENIMIENTOEQUIPO_TI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE ASIGNACION
        public bool EliminarCodMantenimientoEquipoAsigTI(string cod, string codasig, int dni, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_MANTENIMIENTOEQUIPO_TI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@CodAsig", SqlDbType.VarChar).Value = codasig;
                    //comando.Parameters.AddWithValue("@CodAct", SqlDbType.VarChar).Value = codact;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodAsigMantTI = reader.GetString(0);
                            ce_logistica.CodActMantTI = reader.GetString(1);
                            ce_logistica.DniMantTI = reader.GetInt32(2);
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

        //
        //GUARDAR USUARIO
        //

        // METODO PARA GUARDAR BILLITERITA
        public void GuardarPersonalTI(string dni, string apellidos, string nombres, string sexo, string codemp
            , string codsed, string codarea, DateTime FecNac, string Email, string obs, Byte[] imagen, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PERSONALTI"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Ape", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@Nom", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = sexo;
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codemp;
                    comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codsed;
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codarea;
                    comando.Parameters.AddWithValue("@FecNac", SqlDbType.DateTime).Value = FecNac;
                    comando.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = Email;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //BUSCAR FOTO DE PERSONAL
        public DataTable FotoPersonalTI(string dni)
        {
            using (var conexion = leerconexion())
            {
                conexion.Open();
                using (SqlDataAdapter comando = new SqlDataAdapter("SP_PERSONALTI_FOTO '" + dni + "'", conexion))
                {

                    DataTable tb = new DataTable();
                    comando.Fill(tb);
                    return tb;

                }
            }

        }


        // METODO PARA GUARDAR BILLITERITA
        public void ActualizarPersonalTI(string dni, string apellidos, string nombres, string sexo, string codemp
            , string codsed, string codarea, DateTime FecNac, string Email, string obs, Byte[] imagen, string estado,
            DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONALTI"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Ape", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@Nom", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = sexo;
                    comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codemp;
                    comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codsed;
                    comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codarea;
                    comando.Parameters.AddWithValue("@FecNac", SqlDbType.DateTime).Value = FecNac;
                    comando.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = Email;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR PERSONAL
        public void ActualizarPersonal(string dni, string Email, string obs, string estado,
            DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONALNU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    //comando.Parameters.AddWithValue("@Ape", SqlDbType.VarChar).Value = apellidos;
                    //comando.Parameters.AddWithValue("@Nom", SqlDbType.VarChar).Value = nombres;
                    //comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = sexo;
                    //comando.Parameters.AddWithValue("@CodEmp", SqlDbType.VarChar).Value = codemp;
                    //comando.Parameters.AddWithValue("@CodSed", SqlDbType.VarChar).Value = codsed;
                    //comando.Parameters.AddWithValue("@CodArea", SqlDbType.VarChar).Value = codarea;
                    //comando.Parameters.AddWithValue("@FecNac", SqlDbType.DateTime).Value = FecNac;
                    comando.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = Email;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    //comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        public void ActualizarPersonalFoto(Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_FOTOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Foto", SqlDbType.Image).Value = imagen;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR REGISTRO POR USUARIO
        public void eliminarPersonalDniTI(string dni)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PERSONALTI"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ACTUALIZAR PERSONAL COMEDOR
        public void ActualizarPersonalComedor(string dni, string apellidos, DateTime FecCese, string Tipo
            , string Empresa, string Sede, string Area, string est_des, string desayuno, string est_alm
            , string almuerzo, string est_cen, string cena, string hoja, string obs, string estado,
            DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_COMEDOR_ADICIONAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecCese;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Est_des", SqlDbType.VarChar).Value = est_des;
                    comando.Parameters.AddWithValue("@Desayuno", SqlDbType.VarChar).Value = desayuno;
                    comando.Parameters.AddWithValue("@Est_alm", SqlDbType.VarChar).Value = est_alm;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.VarChar).Value = almuerzo;
                    comando.Parameters.AddWithValue("@Est_cen", SqlDbType.VarChar).Value = est_cen;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.VarChar).Value = cena;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    //comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }


        }


        // METODO PARA ACTUALIZAR PERSONAL COMEDOR
        public void ActualizarPedidoComedor(DateTime FecIng, string Empresa, string Sede,
            string PedDes, string PedAlm, string PedCen, string ConDes, string ConAlm
            , string ConCen, string obs, string estado,
            DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PEDIDO_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecIng;
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@PedDes", SqlDbType.VarChar).Value = PedDes;
                    comando.Parameters.AddWithValue("@PedAlm", SqlDbType.VarChar).Value = PedAlm;
                    comando.Parameters.AddWithValue("@PedCen", SqlDbType.VarChar).Value = PedCen;
                    comando.Parameters.AddWithValue("@ConDes", SqlDbType.VarChar).Value = ConDes;
                    comando.Parameters.AddWithValue("@ConAlm", SqlDbType.VarChar).Value = ConAlm;
                    comando.Parameters.AddWithValue("@ConCen", SqlDbType.VarChar).Value = ConCen;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    //comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }


        }


        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void ActualizarTransporteViajes(DateTime fecha, int dia, int semana
            , string num_reporte, string localidad, string unidad, string proveedor, string ruc, string placa
            , decimal costo, string area, int cant_real, int capacidad, string porc_ocupa, string destino
            , string comentario, string tipo, decimal costo_percapita, string empresa, string sede, string hoja
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_TRANSPORTE_VIAJE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Dia", SqlDbType.Int).Value = dia;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = semana;
                    comando.Parameters.AddWithValue("@Num_reporte", SqlDbType.VarChar).Value = num_reporte;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Unidad", SqlDbType.VarChar).Value = unidad;
                    comando.Parameters.AddWithValue("@Proveedor", SqlDbType.VarChar).Value = proveedor;
                    comando.Parameters.AddWithValue("@Ruc", SqlDbType.VarChar).Value = ruc;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
                    comando.Parameters.AddWithValue("@Costo", SqlDbType.Decimal).Value = costo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cant_real", SqlDbType.Int).Value = cant_real;
                    comando.Parameters.AddWithValue("@Capacidad", SqlDbType.Int).Value = capacidad;
                    comando.Parameters.AddWithValue("@Porc_ocupa", SqlDbType.Decimal).Value = porc_ocupa;
                    comando.Parameters.AddWithValue("@Destino", SqlDbType.VarChar).Value = destino;
                    comando.Parameters.AddWithValue("@Comentario", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@Costo_percapita", SqlDbType.Decimal).Value = costo_percapita;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ACTUALIZAR PERSONAL COMEDOR
        public void ActualizarPersonalComedorEliminar(string dni, DateTime fecing, string des, string alm, string cen
            , DateTime fec_edit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_COMEDOR_ELIMINAR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = fecing;
                    comando.Parameters.AddWithValue("@Desayuno", SqlDbType.DateTime).Value = des;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.DateTime).Value = alm;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.DateTime).Value = cen;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }


        }



        // METODO PARA ACTUALIZAR PERSONAL COMEDOR AGREAGAR 1
        public void ActualizarPersonalComedorAgregar(string dni, DateTime fecing, string des, string alm, string cen
            , DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_COMEDOR_AGREGAR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = fecing;
                    comando.Parameters.AddWithValue("@Desayuno", SqlDbType.DateTime).Value = des;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.DateTime).Value = alm;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.DateTime).Value = cen;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }


        }


        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExistePersonalComedor(string cod, string tipo, string sede, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_USUARIOREG_EXISTENTE_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@TipoAlimento", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_comedor.Dni = reader.GetString(0);
                            ce_comedor.ApeNom = reader.GetString(1);
                            ce_comedor.TipoPersonal = reader.GetString(2);
                            ce_comedor.FechaProgramado = reader.GetDateTime(3);
                            ce_comedor.Area = reader.GetString(4);
                            ce_comedor.Empresa = reader.GetString(5);
                            ce_comedor.SedeComedor = reader.GetString(6);
                            ce_comedor.TipoHoja = reader.GetString(7);
                            ce_comedor.TipoAlimentoProg = reader.GetString(8);
                            ce_comedor.PrecioAlimento = reader.GetDecimal(9);
                            ce_comedor.TipoAlimentoMarcado = reader.GetString(10);
                            ce_comedor.TipoPersonalMarcado = reader.GetString(11);

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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExistePersonalProgramado(string cod, string sede, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_USUARIOREG_PROGRAMADO_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_comedor.Dni = reader.GetString(0);
                            ce_comedor.ApeNom = reader.GetString(1);
                            ce_comedor.TipoPersonal = reader.GetString(2);
                            ce_comedor.FechaProgramado = reader.GetDateTime(3);
                            ce_comedor.Area = reader.GetString(4);
                            ce_comedor.Empresa = reader.GetString(5);
                            ce_comedor.SedeComedor = reader.GetString(6);
                            ce_comedor.TipoHoja = reader.GetString(7);

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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteTransporteViaje(string cod, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TRANSPORTE_VIAJE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_transporte.codigo = reader.GetString(0);
                            ce_transporte.FechaInicio = reader.GetDateTime(1);
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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExistePedidoComedor(string emp, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PEDIDO_EXISTENTE_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    //comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sede;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.FecPedido = reader.GetDateTime(0);
                            ce_logistica.EmpPedido = reader.GetString(1);
                            ce_logistica.SedePedido = reader.GetString(2);
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


        public bool BuscExistePedateoPersonalComedor(string cod, DateTime FecReg, string Tipo)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PEDATEO_EXISTENTE_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@FecReg", SqlDbType.DateTime).Value = FecReg;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodPedateoExist = reader.GetString(0);
                            ce_logistica.CodUsuarioPedateoExist = reader.GetString(1);
                            ce_logistica.CodPedateoTiExist = reader.GetString(2);
                            ce_logistica.FechaPedateoExist = reader.GetDateTime(3);
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


        public bool BuscExistePedateoPersonalComedorAlimento(string cod, DateTime FecReg, string Tipo)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PEDATEO_EXISTENTE_TIPO_ALIMENTO_USER"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecReg;
                    comando.Parameters.AddWithValue("@TipoAlimento", SqlDbType.VarChar).Value = Tipo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_logistica.CodPedateoExistAlimento = reader.GetString(0);
                            ce_logistica.CodPedateoTipoAlimentoExist = reader.GetString(4);
                            ce_logistica.PrecioMar = reader.GetDecimal(5);
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


        // METODO PARA ACTUALIZAR PERSONAL COMEDOR
        public void GuardarPersonalComedor(string dni, string apellidos, DateTime FecCese, string Tipo
            , string Empresa, string Sede, string Area, string est_des, string desayuno, string est_alm
            , string almuerzo, string est_cen, string cena, string hoja, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PERSONAL_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecCese;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Est_des", SqlDbType.VarChar).Value = est_des;
                    comando.Parameters.AddWithValue("@Desayuno", SqlDbType.VarChar).Value = desayuno;
                    comando.Parameters.AddWithValue("@Est_alm", SqlDbType.VarChar).Value = est_alm;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.VarChar).Value = almuerzo;
                    comando.Parameters.AddWithValue("@Est_cen", SqlDbType.VarChar).Value = est_cen;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.VarChar).Value = cena;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
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


        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void GuardarTransporteViajes(DateTime fecha, int dia, int semana
            , string num_reporte, string localidad, string unidad, string proveedor, string ruc, string placa
            , decimal costo, string area, int cant_real, int capacidad, string porc_ocupa, string destino
            , string comentario, string tipo, decimal costo_percapita, string empresa, string sede, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_TRANSPORTE_VIAJE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Dia", SqlDbType.Int).Value = dia;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = semana;
                    comando.Parameters.AddWithValue("@Num_reporte", SqlDbType.VarChar).Value = num_reporte;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Unidad", SqlDbType.VarChar).Value = unidad;
                    comando.Parameters.AddWithValue("@Proveedor", SqlDbType.VarChar).Value = proveedor;
                    comando.Parameters.AddWithValue("@Ruc", SqlDbType.VarChar).Value = ruc;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
                    comando.Parameters.AddWithValue("@Costo", SqlDbType.Decimal).Value = costo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cant_real", SqlDbType.Int).Value = cant_real;
                    comando.Parameters.AddWithValue("@Capacidad", SqlDbType.Int).Value = capacidad;
                    comando.Parameters.AddWithValue("@Porc_ocupa", SqlDbType.Decimal).Value = porc_ocupa;
                    comando.Parameters.AddWithValue("@Destino", SqlDbType.VarChar).Value = destino;
                    comando.Parameters.AddWithValue("@Comentario", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@Costo_percapita", SqlDbType.Decimal).Value = costo_percapita;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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







        // METODO PARA GUARDAR REGISTRO PEDIDO
        public void GuardarRegistroPedido(DateTime FecIng, string Empresa, string Sede,
            string personal,string PedDes, string PedAlm, string PedCen, string ConDes, string ConAlm
            , string ConCen, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PEDIDO_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecIng;
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Personal", SqlDbType.VarChar).Value = personal;
                    comando.Parameters.AddWithValue("@PedDes", SqlDbType.VarChar).Value = PedDes;
                    comando.Parameters.AddWithValue("@PedAlm", SqlDbType.VarChar).Value = PedAlm;
                    comando.Parameters.AddWithValue("@PedCen", SqlDbType.VarChar).Value = PedCen;
                    comando.Parameters.AddWithValue("@ConDes", SqlDbType.VarChar).Value = ConDes;
                    comando.Parameters.AddWithValue("@ConAlm", SqlDbType.VarChar).Value = ConAlm;
                    comando.Parameters.AddWithValue("@ConCen", SqlDbType.VarChar).Value = ConCen;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
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


        // METODO PARA ACTUALIZAR PERSONAL COMEDOR
        public void GuardarPedateoPersonalComedor(string dni, string apellidos, DateTime FecIng, string Tipo, string hoja
            , string TipoPer, DateTime FecReg, string Empresa, string Sede, string Area, decimal precio, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PEDATEO_PERSONAL_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecIng;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@TipoPer", SqlDbType.VarChar).Value = TipoPer;
                    comando.Parameters.AddWithValue("@FecReg", SqlDbType.DateTime).Value = FecReg;
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Precio", SqlDbType.Decimal).Value = precio;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
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


        // METODO PARA ACTUALIZAR PERSONAL COMEDOR
        public DataTable BuscarPedateoPersonalComedor(string dni, string Tipo
            , DateTime FecReg, string Sede)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PEDATEO_PERSONAL_COMEDOR", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                comando.Parameters.AddWithValue("@FecReg", SqlDbType.DateTime).Value = FecReg;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
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

        public DataTable BuscarPedateoPersonalComedorJustificado(string dni, string Tipo
            , DateTime FecReg, string Sede)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PEDATEO_PERSONAL_COMEDOR_JUSTIFICADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                comando.Parameters.AddWithValue("@FecReg", SqlDbType.DateTime).Value = FecReg;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
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


        public DataTable BuscarPedateoPersonalComedorReporte(DateTime FecIni, DateTime FecFin, string adicional
            , string tipoalimento, string TipoPer, string Empresa, string area, string Sede, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PEDATEO_PERSONAL_COMEDOR_REPORTE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Adicional", SqlDbType.VarChar).Value = adicional;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipoalimento;
                comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = TipoPer;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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



        public DataTable BuscarPedateoPersonalComedorReporteJustificacion(DateTime FecIni, DateTime FecFin, string adicional
            , string tipoalimento, string TipoPer, string Empresa, string area, string Sede, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PEDATEO_PERSONAL_COMEDOR_REPORTE_JUSTIFICADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Adicional", SqlDbType.VarChar).Value = adicional;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipoalimento;
                comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = TipoPer;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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



        //PERSONAL COMEDOR
        public DataTable BuscarPedateoPersonalComedorProgramado(DateTime FecIni, DateTime FecFin, string adicional
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PROGRAMACION_PERSONAL_COMEDOR_PROGRAMADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Adicional", SqlDbType.VarChar).Value = adicional;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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

        //PERSONAL COMEDOR
        public DataTable BuscarRegistroPedido(
            DateTime FecIng, DateTime FecFin, string empresa, string id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_REGISTRO_PERSONAL", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecIng;
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




        public void EliminarRegistroComedorFecha(DateTime FecIng, string Tipo, string Emp, string sede)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_REGISTRO_COMIDA_SP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@FecIng", SqlDbType.DateTime).Value = FecIng;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.ExecuteNonQuery();

                }
            }

        }



        //INASISTENCIA
        public DataTable BuscarPedateoPersonalComedorInasistencia(DateTime FecIni, DateTime FecFin, string adicional
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PROGRAMACION_PERSONAL_COMEDOR_INASISTENCIA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Adicional", SqlDbType.VarChar).Value = adicional;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                comando.CommandTimeout = 300;
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


        //RESUMEN

        public DataTable BuscarPedateoPersonalComedorResumen(DateTime FecIni, DateTime FecFin
            , string tipopersonal, string Empresa, string Sede)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PROGRAMACION_PERSONAL_COMEDOR_RESUMEN", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Personal", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                comando.CommandTimeout = 300;
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

        //RESUMEN PEDIDO PROGRAMADO MERMA TEORICA MERMA REAL

        public DataTable BuscarPedidoProgramadoComedorResumen(DateTime FecIni, DateTime FecFin
            , string tipopersonal, string Empresa, string Sede)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PEDIDO_PROGRAMADO_COMEDOR_RESUMEN", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Personal", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                comando.CommandTimeout = 300;
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


        //RESUMEN PEDIDO COMEDORES
        public DataTable BuscarPedidoRegistro(DateTime FecIni, DateTime FecFin
            , string Empresa)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PEDIDO_REGISTRO_RESUMEN", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
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


        //RESUMEN DETALLE

        public DataTable BuscarPedateoPersonalComedorResumen_Detalle(DateTime FecIni, DateTime FecFin
            , string tipopersonal, string Empresa, string Sede)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PROGRAMACION_PERSONAL_COMEDOR_RESUMEN_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Personal", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
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















        // METODO PARA GUARDAR GRUPO
        public void GuardarAlmacen(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string siscod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ALMACEN"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;

                    comando.Parameters.AddWithValue("@siscod", SqlDbType.VarChar).Value = siscod;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GRUPO
        public void ActualizarAlmacen(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string siscod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ALMACEN"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;

                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.VarChar).Value = siscod;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GRUPO
        public void EliminarAlmacen(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_ALMACEN"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR PROVEEDOR
        public void GuardarProveedor(string codigo, string descripcion, string comentario, string ruc, string direccion
            , string telefono, string estado, string distrito
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, int siscod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PROVEEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@ruc", SqlDbType.VarChar).Value = ruc;
                    comando.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = direccion;
                    comando.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@ubicod", SqlDbType.VarChar).Value = distrito;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR GRUPO
        public void ActualizarProveedor(string codigo, string descripcion, string comentario, string ruc, string direccion
            , string telefono, string estado, string distrito
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, int siscod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PROVEEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@destall", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obstall", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@ruc", SqlDbType.VarChar).Value = ruc;
                    comando.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = direccion;
                    comando.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@ubicod", SqlDbType.VarChar).Value = distrito;

                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR GRUPO
        public void EliminarProveedor(string codigo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PROVEEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codprv", SqlDbType.VarChar).Value = codigo;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
    }
}
