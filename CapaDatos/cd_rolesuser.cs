using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class cd_rolesuser : cd_conexion
    {
        //
        //
        // PAGINA BI
        //
        //
        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoUsuarioROL(int idmenu, int idsubmenu)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MENU_SUBMENU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdMenu", SqlDbType.Int).Value = idmenu;
                    comando.Parameters.AddWithValue("@IdSubmenu", SqlDbType.Int).Value = idsubmenu;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_rolesbi.CodExiste = reader.GetString(0);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB BuscExisteMenuAPP_Usuario
        public bool BuscExisteMenuSubMenuRol(int idrol, int idsubmenu)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MENU_SUBMENU_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = idrol;
                    comando.Parameters.AddWithValue("@IdSubMenu", SqlDbType.Int).Value = idsubmenu;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_rolesbi.CodExiste = reader.GetString(0);
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
        public bool BuscExisteMenuAPP_Usuario(int idusuario, int idapp)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MENU_USUARIO_APP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdUser", SqlDbType.Int).Value = idusuario;
                    comando.Parameters.AddWithValue("@IdAPP", SqlDbType.Int).Value = idapp;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_rolesbi.CodExiste = reader.GetString(0);
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



        // METODO PARA LLAMAR EXISTE PERMISO ROL USUARIO
        public bool BuscExistePermisoRol(int idrol)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PERMISO_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = idrol;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesuser.IdPermiso = reader.GetInt32(0);
                            ce_rolesuser.IdRol = reader.GetInt32(1);
                            ce_rolesuser.IdSubMenu = reader.GetInt32(2);
                            ce_rolesuser.Activo = reader.GetBoolean(3);
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



        // METODO PARA LLAMAR EXISTE PERMISO ROL USUARIO
        public List<ce_rolespermiso> BuscExistePermiso(int idrol)
        {
            DataTable dt = new DataTable();
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PERMISO_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = idrol;
                    comando.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(dt);

                    List<ce_rolespermiso> Opcion =
                        (from row in dt.AsEnumerable()
                         select new ce_rolespermiso()
                         {
                             IdPermiso = int.Parse(row[0].ToString()),
                             IdRol = int.Parse(row[1].ToString()),
                             IdSubMenu = int.Parse(row[2].ToString()),
                             Activo = Boolean.Parse(row[3].ToString())
                         }
                        ).ToList();

                    return Opcion;

                }
            }
        }




        // METODO PARA LLAMAR EXISTE PERMISO ROL USUARIO
        public bool BuscExisteUsuarioRol(int idusuario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_ROL_USUARIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = idusuario;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesuser.IdRolUsuario = reader.GetInt32(0);
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
        public void GuardarMenuSubmenu(int idsubmenu, int idmenu, string nombre, string nombreformulario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MENU_SUBMENU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@idsubmenu", SqlDbType.Int).Value = idsubmenu;
                    comando.Parameters.AddWithValue("@idmenu", SqlDbType.Int).Value = idmenu;
                    comando.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@nombreformulario", SqlDbType.VarChar).Value = nombreformulario;

                    comando.ExecuteNonQuery();

                }
            }
        }



        // METODO PARA GUARDAR USUARIO
        public void GuardarMenuSubmenuRol(int idrol, int idsubmenu, Boolean activo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MENU_SUBMENU_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@idrol", SqlDbType.Int).Value = idrol;
                    comando.Parameters.AddWithValue("@idsubmenu", SqlDbType.Int).Value = idsubmenu;
                    comando.Parameters.AddWithValue("@activo", SqlDbType.Bit).Value = activo;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR USUARIO BI GuardarMenuAPP_Usuario
        public void GuardarMenuAPP_Usuario(int idapp, int iduser, Boolean activo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MENU_USUARIO_APP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@idapp", SqlDbType.Int).Value = idapp;
                    comando.Parameters.AddWithValue("@iduser", SqlDbType.Int).Value = iduser;
                    comando.Parameters.AddWithValue("@activo", SqlDbType.Bit).Value = activo;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR USUARIO BI
        public void GuardarUsuario(int cod, string nombre, string usuario, string clave, int idrol)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ERP_USUARIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = usuario;
                    comando.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = clave;
                    comando.Parameters.AddWithValue("@IdRol", SqlDbType.VarChar).Value = idrol;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarMenuSubmenu(int idsubmenu, int idmenu, string nombre, string nombreformulario)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MENU_SUBMENU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@idsubmenu", SqlDbType.Int).Value = idsubmenu;
                    comando.Parameters.AddWithValue("@idmenu", SqlDbType.Int).Value = idmenu;
                    comando.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@nombreformulario", SqlDbType.VarChar).Value = nombreformulario;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR Menu rol 
        public void ActualizarMenuSubmenuRol(int idrol, int idsubmenu, Boolean activo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MENU_SUBMENU_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@idrol", SqlDbType.Int).Value = idrol;
                    comando.Parameters.AddWithValue("@idsubmenu", SqlDbType.Int).Value = idsubmenu;
                    comando.Parameters.AddWithValue("@activo", SqlDbType.Bit).Value = activo;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR Menu rol ActualizarMenuAPP_Usuario
        public void ActualizarMenuAPP_Usuario(int idapp, int idusuario, Boolean activo)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MENU_USUARIO_APP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@idapp", SqlDbType.Int).Value = idapp;
                    comando.Parameters.AddWithValue("@iduser", SqlDbType.Int).Value = idusuario;
                    comando.Parameters.AddWithValue("@activo", SqlDbType.Bit).Value = activo;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarUsuario(int cod, string nombre, string usuario, string clave)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ERP_USUARIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = usuario;
                    comando.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = clave;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarUsuarioRol(int cod, int idrol)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ERP_USUARIO_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = idrol;

                    comando.ExecuteNonQuery();

                }
            }
        }



        // MOSTRAR LISTA DE ROL
        public DataTable ListaERP_ROL()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_USUARIO_ROL", conex);
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

        // MOSTRAR LISTA DE ROL

        public bool ListaERP_ROL_Usuario(string nombres)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_MOSTRAR_USUARIO_ROL_USUARIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Nombres", SqlDbType.Int).Value = nombres;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rolesuser.IdRolSelect = reader.GetInt32(0);
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


        // MOSTRAR LISTA DE ROL
        public DataTable ListaERP_Usuario()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_ERP_USUARIO", conex);
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
        public bool BuscExisteCodigoROL(int cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_USUARIO_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_rolesuser.CodExiste = reader.GetInt32(0);
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
        public void GuardarROL(int codigo, string nombre)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = nombre;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarROL(int codigo, string nombre)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = nombre;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaERP_MENU()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_MENU_ROL", conex);
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

        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaERP_MENU_APP()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_MENU_APP", conex);
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
        public bool BuscExisteMenu(int cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MENU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_rolesuser.CodExiste = reader.GetInt32(0);
                            //ce_rolesuser.CodExisteOpc = reader.GetString(1);
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
        public bool BuscExisteMenuAPP(int cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MENU_APP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_rolesuser.CodExiste = reader.GetInt32(0);
                            //ce_rolesuser.CodExisteOpc = reader.GetString(1);
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
        public bool BuscExisteCodigoOpcionMasUnoROL()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_OPCIONUSER_MASUNO"))
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
                            //ce_rolesuser.CodExisteMasUno = reader.GetInt32(0);
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
        public void GuardarMenu(int codigo, string des, string icono)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MENU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = des;
                    comando.Parameters.AddWithValue("@Icono", SqlDbType.Int).Value = icono;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR USUARIO BI
        public void GuardarMenuAPP(int codigo, string des, string icono)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_MENU_APP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = des;
                    comando.Parameters.AddWithValue("@Icono", SqlDbType.Int).Value = icono;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarMenu(int codigo, string des, string icono)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MENU"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = des;
                    comando.Parameters.AddWithValue("@Icono", SqlDbType.VarChar).Value = icono;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR MENU APP
        public void ActualizarMenuAPP(int codigo, string des, string icono)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_MENU_APP"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Des", SqlDbType.VarChar).Value = des;
                    comando.Parameters.AddWithValue("@Icono", SqlDbType.VarChar).Value = icono;

                    comando.ExecuteNonQuery();

                }
            }
        }
        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaModuloOPCROL()
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



        // MOSTRAR LISTA DE OPCION
        public DataTable ListaOpcionSubMenu(int cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_OPCION_SUBMENU", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
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


        // MOSTRAR LISTA DE OPCION
        public DataTable ListaOpcionSubMenuUsuario(int cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_OPCION_SUBMENU_USUARIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = cod;
                // comando.Parameters.AddWithValue("@Activo", SqlDbType.Bit).Value = activo;
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


        // MOSTRAR LISTA DE OPCION SUBMENU ROL 
        public DataTable ListaOpcionSubMenuRol(int cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_OPCION_SUBMENU_ROL", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
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




        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaBuscarUsuarioAPP(string cod, string apenom)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_USUARIO_APP", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@cod", SqlDbType.VarChar).Value = cod;
                comando.Parameters.AddWithValue("@apenom", SqlDbType.VarChar).Value = apenom;
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



        // MOSTRAR LISTA DE OPCION SUBMENU ROL 
        public DataTable ListaOpcionMenuAPP_Usuario(int cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_OPCION_MENU_USUARIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
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
        public bool BuscExisteCodigoGrupoPaginaROL(string cod, string idpag)
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
        public void GuardarGrupoModuloOpcionROL(ce_rolespermiso perpPermiso)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_GRUPO_MODULOOPCION_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = perpPermiso.RolUsuarioId;
                    //comando.Parameters.AddWithValue("@IdOpc", SqlDbType.Int).Value = perpPermiso.OpcionId;
                    //comando.Parameters.AddWithValue("@Permiso", SqlDbType.Bit).Value = perpPermiso.Permitido;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarGrupoModuloOpcionRol(ce_rolespermiso perpPermiso)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_GRUPO_MODULOOPCION_ROL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = perpPermiso.RolUsuarioId;
                    //comando.Parameters.AddWithValue("@IdOpc", SqlDbType.Int).Value = perpPermiso.OpcionId;
                    //comando.Parameters.AddWithValue("@Permiso", SqlDbType.Bit).Value = perpPermiso.Permitido;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE GRUPO PAGINA
        public DataTable ListaGrupoModuloOpcionRol(string grupo)
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
        public bool BuscExisteCodigoRolUsuarioROL(string cod, string rol)
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
        public bool BuscExisteCorreoUsuarioROL(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_DNIUSUARIO_ROL"))
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
                            //ce_rolesuser.UserDni = reader.GetString(0);
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
        public void GuardarRolUsuarioROL(string codigo, string grupo, string iduser, string user, bool acceso)
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
        public void ActualizarRolUsuarioROL(string codigo, string grupo, string iduser, string user, bool acceso)
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
        public DataTable ListaRolUsuarioROL(string user)
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
