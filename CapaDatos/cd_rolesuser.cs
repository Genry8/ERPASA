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

        //
        //
        // CARGAS MASIVAS DE ROLES, MENUS Y PERMISOS
        //
        //
        // Todas siguen el mismo esquema: SqlBulkCopy a una tabla temporal de la
        // sesion y un solo MERGE en el SP. Reemplazan al ciclo que hacia una
        // consulta de existencia y un INSERT/UPDATE por cada fila de la grilla.

        // ERP_Rol
        public void GuardarActualizarROLMasivo(DataTable roles)
        {
            CargaMasiva(roles, "#Rol", @"CREATE TABLE #Rol(
                        IdRol  int,
                        Nombre varchar(80))", "SP_GUARDAR_ACTUALIZAR_ROL_MASIVO");
        }


        // ERP_Menu
        public void GuardarActualizarMenuMasivo(DataTable menus)
        {
            CargaMasiva(menus, "#Menu", @"CREATE TABLE #Menu(
                        IdMenu int,
                        Nombre varchar(80),
                        Icono  varchar(80),
                        IdApp  int,
                        App    varchar(80))", "SP_GUARDAR_ACTUALIZAR_MENU_MASIVO");
        }


        // ERP_SubMenu
        public void GuardarActualizarMenuSubmenuMasivo(DataTable submenus)
        {
            CargaMasiva(submenus, "#SubMenu", @"CREATE TABLE #SubMenu(
                        IdSubMenu        int,
                        IdMenu           int,
                        Nombre           varchar(150),
                        NombreFormulario varchar(150))", "SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_MASIVO");
        }


        // ERP_Permiso (submenus habilitados por rol)
        public void GuardarActualizarMenuSubmenuRolMasivo(DataTable permisos)
        {
            CargaMasiva(permisos, "#PermisoRol", @"CREATE TABLE #PermisoRol(
                        IdRol     int,
                        IdSubMenu int,
                        Activo    bit)", "SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_ROL_MASIVO");
        }


        // ERP_Menu_APP
        public void GuardarActualizarMenuAPPMasivo(DataTable apps)
        {
            CargaMasiva(apps, "#MenuApp", @"CREATE TABLE #MenuApp(
                        Id_APP int,
                        Nombre varchar(80),
                        Icono  varchar(80))", "SP_GUARDAR_ACTUALIZAR_MENU_APP_MASIVO");
        }


        // ERP_Permiso_APP (apps habilitadas por usuario)
        public void GuardarActualizarMenuAPP_UsuarioMasivo(DataTable permisos)
        {
            CargaMasiva(permisos, "#PermisoApp", @"CREATE TABLE #PermisoApp(
                        Id_APP  int,
                        Id_User int,
                        Activo  bit)", "SP_GUARDAR_ACTUALIZAR_MENU_USUARIO_APP_MASIVO");
        }


        //
        //
        // APP OPCIONES (ERP_AppOpciones)
        //
        //
        // METODO PARA GUARDAR O ACTUALIZAR LAS OPCIONES DE APP EN BLOQUE
        // Se suben todas las filas con SqlBulkCopy a una tabla temporal de la
        // sesion y el SP resuelve las altas y actualizaciones en un solo MERGE.
        public void GuardarActualizarAppOpcionesMasivo(DataTable opciones)
        {
            CargaMasiva(opciones, "#AppOpciones", @"CREATE TABLE #AppOpciones(
                        IdAppOpc   int,
                        IdApp      int,
                        Nombre     varchar(180),
                        Comentario varchar(500),
                        Obs        varchar(1000),
                        Estado     varchar(1),
                        EstadoP    varchar(80),
                        FecCre     datetime2(7),
                        UseReg     int,
                        Hostname   varchar(50),
                        FecEdit    datetime2(7),
                        UseEdit    int,
                        UseElim    int)", "SP_GUARDAR_ACTUALIZAR_APP_OPCIONES_MASIVO");
        }


        // MOSTRAR LAS OPCIONES DE UNA APP
        public DataTable ListaOpcionApp(int cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_OPCION_APP", conex);
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
        // PERMISO APP MOVIL (ERP_PermisoAppMovil)
        //
        //
        // METODO PARA GUARDAR O ACTUALIZAR LOS PERMISOS EN BLOQUE
        // Mismo esquema que las opciones de app: SqlBulkCopy + un solo MERGE.
        public void GuardarActualizarPermisoAppMovilMasivo(DataTable permisos)
        {
            CargaMasiva(permisos, "#PermisoAppMovil", @"CREATE TABLE #PermisoAppMovil(
                        IdUser   int,
                        IdAppOpc int,
                        Activo   bit,
                        Obs      varchar(1000),
                        Estado   varchar(1),
                        EstadoP  varchar(80),
                        FecCre   datetime2(7),
                        UseReg   int,
                        Hostname varchar(50),
                        FecEdit  datetime2(7),
                        UseEdit  int,
                        UseElim  int)", "SP_GUARDAR_ACTUALIZAR_PERMISO_APP_MOVIL_MASIVO");
        }


        // MOSTRAR LAS OPCIONES DE APP CON EL ACCESO DE UN USUARIO
        public DataTable ListaAppOpciones(int cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_APP_OPCIONES_USUARIO", conex);
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


    }

}
