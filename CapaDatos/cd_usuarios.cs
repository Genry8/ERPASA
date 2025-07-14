using CapaEntidad;
using CapaUtilidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_usuarios : cd_conexion
    {
        ce_usuario objentUsuarios = new ce_usuario();
        // MOSTRAR TODA LA LISTA DE USUARIOS
        public DataTable listausuario()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_USUARIOS", conex);
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

        // BUSCAR FOTO DE USUARIO
        public DataTable fotousuario(int dni)
        {
            using (var conexion = leerconexion())
            {
                conexion.Open();
                using (SqlDataAdapter comando = new SqlDataAdapter("SP_PERSONAL_FOTO_PERFIL '" + dni + "'", conexion))
                {

                    DataTable tb = new DataTable();
                    comando.Fill(tb);
                    return tb;

                }
            }

        }

        // BUSCAR FOTO DE USUARIO
        public DataTable fotousuarioFirma(string dni)
        {
            using (var conexion = leerconexion())
            {
                conexion.Open();
                using (SqlDataAdapter comando = new SqlDataAdapter("SP_PERSONAL_FOTO_FIRMA '" + dni + "'", conexion))
                {
                    DataTable tb = new DataTable();
                    comando.Fill(tb);
                    return tb;

                }
            }

        }

        // MOSTRAR TODA LA LISTA DE PERFILES
        public DataTable listaperfil()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_USUARIOS_PERFIL", conex);
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

        // MOSTRAR TODA LA LISTA DE USUARIOS EN DATAGRIDVIEW POR LIKE
        public DataTable listausuario_prueba(string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();
            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_USUARIOS_PARA_DATAGRID", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
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

        // MOSTRAR LA VERSION DE ACTUALIZACION VESION_IPRESSREPORTE       
        public void VESION_IPRESSREPORTE()
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("sp_version_IpressReporte"))
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
                            ce_usuario.version_ipress = reader.GetString(0);
                        }
                        conexion.Dispose();
                        conexion.Close();
                        return;
                    }


                }
            }

        }

        // METODO PARA BUSCAR POR DNI Y CONTRASEÑA AL USUARIO
        public bool BuscarUsuario(int dni, string contraseña, string app)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_INICIO_SESION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@user", SqlDbType.Int).Value = dni;
                    comando.Parameters.AddWithValue("@contraseña", SqlDbType.VarChar).Value = contraseña;
                    comando.Parameters.AddWithValue("@app", SqlDbType.VarChar).Value = app;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_usuario.usecod = reader.GetInt32(0);
                            ce_usuario.usenam = reader.GetString(1);
                            ce_usuario.usedoc = reader.GetInt32(2);
                            ce_usuario.useusr = reader.GetString(3);
                            ce_usuario.usepas = reader.GetString(4);
                            ce_usuario.estado = reader.GetString(5);
                            ce_usuario.siscod = reader.GetInt32(6);
                            ce_usuario.grucod = reader.GetString(7);
                            ce_usuario.sede_user = reader.GetString(8);
                            ce_usuario.grudes = reader.GetString(9);
                            ce_usuario.permiso_app = reader.GetString(10);
                            ce_usuario.useestado = reader.GetString(11);
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

        // METODO PARA BUSCAR POR DNI AL USUARIO
        public bool BuscarPersonalTI()
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_BUSCARPERSONAL_TI"))
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
                            ce_usuario.dni_buscar = reader.GetInt32(4);
                            ce_usuario.Apellido_buscar = reader.GetString(0);
                            ce_usuario.Nombre_buscar = reader.GetString(1);
                            ce_usuario.Sexo_buscar = reader.GetString(2);
                            ce_usuario.Grupo_buscar = reader.GetString(3);
                            ce_usuario.Contraseña_buscar = cu_encriptar.DesEncriptar(reader.GetString(5));
                            ce_usuario.Estado_buscar = reader.GetString(6);
                            ce_usuario.Planilla_buscar = reader.GetString(7);

                            //Memorys
                            //ce_usuario.foto_perfil_buscar = reader.GetString(11);
                            //ce_usuario.foto_perfil_buscar
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



        // METODO PARA GUARDAR USUARIO QUE INICIA SESION
        public void GuardarUsuario(int usecod, int siscod, int usedoc, string usenam, string useusr, string estado, string hostname, string ip_pc, DateTime fecha_acceso)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_USUARIOS_INIC_SESION"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                    comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;
                    comando.Parameters.AddWithValue("@usenam", SqlDbType.VarChar).Value = usenam;
                    comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = useusr;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_pc", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@fecha_acceso", SqlDbType.DateTime).Value = fecha_acceso;
                    comando.ExecuteNonQuery();


                }
            }

        }

        // METODO PARA GUARDAR BILLITERITA
        public void GuardarUsuario_Billiterita(string apellidos, string nombres, string sexo, string grupo, int dni, string contraseña, string estado, string planilla, int usercre, string ip_pc, DateTime fecha_creacion, Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_USUARIOS_BILLITERITA_GUARDAR"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@apellidos", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@sexo", SqlDbType.VarChar).Value = sexo;
                    comando.Parameters.AddWithValue("@grupo_profesional", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.Parameters.AddWithValue("@contraseña", SqlDbType.VarChar).Value = contraseña;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@planilla", SqlDbType.VarChar).Value = planilla;
                    comando.Parameters.AddWithValue("@user_cre", SqlDbType.Int).Value = usercre;
                    comando.Parameters.AddWithValue("@ip_pc", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@fecha_creacion", SqlDbType.DateTime).Value = fecha_creacion;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ELIMINAR REGISTRO POR USUARIO
        public void eliminarUsuarioDni(int dni)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_USUARIOS_ELIMINAR_BILIITERITA"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ACTUALIZAR MODIFICACION DE REGISTRO POR USUARIO
        public void ActualizarUsuarioDni(string apellidos, string nombres, string sexo, string grupo, int dni, string contraseña, string estado, string planilla, Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_USUARIOS_UPDATE_BILIITERITA"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@apellidos", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@sexo", SqlDbType.VarChar).Value = sexo;
                    comando.Parameters.AddWithValue("@grupo_profesional", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.Parameters.AddWithValue("@contraseña", SqlDbType.VarChar).Value = contraseña;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@planilla", SqlDbType.VarChar).Value = planilla;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.ExecuteNonQuery();

                }
            }

        }

    }
}
