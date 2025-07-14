using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_rolesbi : cd_conexion
    {
        //
        //
        // PAGINA BI
        //
        //
        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoUsuarioPB(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_USUARIOBI_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesbi.CodExiste = reader.GetString(0);
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

        // METODO PARA GUARDAR USUARIO BI
        public void GuardarUsuarioBI(string codigo, string usuario, string correo, string comentario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_USUARIOBI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = usuario;
                    comando.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = correo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarUsuarioBI(string codigo, string usuario, string correo, string comentario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_USUARIOBI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = usuario;
                    comando.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = correo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaUsuarioBI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_USUARIO_BI", conex);
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
        //
        // PAGINA BI
        //
        //
        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoPaginaPB(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PAGINABI_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesbi.CodExiste = reader.GetString(0);
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

        // METODO PARA GUARDAR USUARIO BI
        public void GuardarPaginaBI(string codigo, string pagina, string comentario, int index)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PAGINABI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Pag", SqlDbType.VarChar).Value = pagina;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Ind", SqlDbType.Int).Value = index;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarPaginaBI(string codigo, string pagina, string comentario, int index)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PAGINABI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Pag", SqlDbType.VarChar).Value = pagina;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Ind", SqlDbType.Int).Value = index;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaPaginaBI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PAGINA_BI", conex);
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
        //
        // GRUPO BI
        //
        //
        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoGrupoPB(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_GRUPOBI_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesbi.CodExiste = reader.GetString(0);
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

        // METODO PARA GUARDAR USUARIO BI
        public void GuardarGrupoBI(string codigo, string grupo, string comentario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_GRUPOBI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarGrupoBI(string codigo, string grupo, string comentario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_GRUPOBI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaGrupoBI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GRUPO_BI", conex);
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
        //
        //MOSTRAR GRUPO PAGINA
        //
        //

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoGrupoPaginaPB(string cod, string idpag)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_GRUPOPAGINABI_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Id_pg", SqlDbType.VarChar).Value = idpag;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesbi.CodExiste = reader.GetString(0);
                            ce_rolesbi.CodPagExiste = reader.GetString(1);
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

        // METODO PARA GUARDAR USUARIO BI
        public void GuardarGrupoPaginaBI(string codigo, string grupo, string idpag, string indice, bool acceso)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_GRUPOPAGINABI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Id_pg", SqlDbType.VarChar).Value = idpag;
                    comando.Parameters.AddWithValue("@Indice", SqlDbType.VarChar).Value = indice;
                    comando.Parameters.AddWithValue("@Acceso", SqlDbType.Bit).Value = acceso;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarGrupoPaginaBI(string codigo, string grupo, string idpag, string indice, bool acceso)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_GRUPOPAGINABI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Id_pg", SqlDbType.VarChar).Value = idpag;
                    comando.Parameters.AddWithValue("@Indice", SqlDbType.VarChar).Value = indice;
                    comando.Parameters.AddWithValue("@Acceso", SqlDbType.Bit).Value = acceso;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE GRUPO PAGINA
        public DataTable ListaGrupoPaginaBI(string grupo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GRUPOPAGINA_BI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
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
        //MOSTRAR ROL USUARIO
        //
        //

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoRolUsuarioPB(string cod, string rol)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ROLUSUARIOBI_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@IdUser", SqlDbType.VarChar).Value = rol;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesbi.CodExiste = reader.GetString(0);
                            ce_rolesbi.CodPagExiste = reader.GetString(1);
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
        public bool BuscExisteCorreoUsuarioPB(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_CORREOUSUARIOBI_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesbi.UserCorreo = reader.GetString(0);
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

        // METODO PARA GUARDAR USUARIO BI
        public void GuardarRolUsuarioBI(string codigo, string grupo, string iduser, string user, bool acceso)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ROLUSUARIOBI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@IdUser", SqlDbType.VarChar).Value = iduser;
                    comando.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = user;
                    comando.Parameters.AddWithValue("@Acceso", SqlDbType.Bit).Value = acceso;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarRolUsuarioBI(string codigo, string grupo, string iduser, string user, bool acceso)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ROLUSUARIOBI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Grup", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@IdUser", SqlDbType.VarChar).Value = iduser;
                    comando.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = user;
                    comando.Parameters.AddWithValue("@Acceso", SqlDbType.Bit).Value = acceso;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // MOSTRAR LISTA DE GRUPO PAGINA
        public DataTable ListaRolUsuarioBI(string user)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ROLUSUARIO_BI", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = user;
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
