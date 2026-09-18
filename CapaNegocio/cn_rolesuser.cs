using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class cn_rolesuser : cd_conexion
    {
        public static bool BuscExistePermisoRol(int idrol)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExistePermisoRol(idrol);
        }

        public static bool BuscExisteUsuarioRol(int idusuario)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteUsuarioRol(idusuario);
        }




        //metodo para guardar usuario 
        public void GuardarUsuario(int cod, string nombre, string usuario, string clave, int idrol)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarUsuario(cod, nombre, usuario, clave, idrol);
        }

        //
        //metodo para actualizar menu submenu
        public void ActualizarUsuario(int cod, string nombre, string usuario, string clave)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarUsuario(cod, nombre, usuario, clave);
        }

        //
        //metodo para actualizar menu submenu
        public void ActualizarUsuarioRol(int cod, int idrol)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarUsuarioRol(cod, idrol);
        }


        //
        //metodo para listar ROL
        public static DataTable ListaERP_ROL()
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaERP_ROL();
        }


        //
        //metodo para listar ROL
        public static bool ListaERP_ROL_Usuario(string nombre)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaERP_ROL_Usuario(nombre);
        }



        //
        //metodo para listar usuarios
        public static DataTable ListaERP_Usuario()
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaERP_Usuario();
        }



        //
        //metodo para listar usuarios
        public static DataTable ListaERP_MENU()
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaERP_MENU();
        }

        //
        //metodo para listar menu app
        public static DataTable ListaERP_MENU_APP()
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaERP_MENU_APP();
        }

        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteOpcionMasunoROL()
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCodigoOpcionMasUnoROL();
        }


        //
        //metodo para listar usuarios
        public static DataTable ListaOpcionSubMenu(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaOpcionSubMenu(cod);
        }
        //

        //
        //metodo para listar usuarios
        public static DataTable ListaOpcionSubMenuUsuario(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaOpcionSubMenuUsuario(cod);
        }
        //

        //
        //metodo para listar submenu rol
        public static DataTable ListaOpcionSubMenuRol(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaOpcionSubMenuRol(cod);
        }


        //LISTA PERIFERICO POR FILTRO
        //
        public static DataTable ListaBuscarUsuarioAPP(string cod, string apenom)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaBuscarUsuarioAPP(cod, apenom);
        }


        //metodo para listar menu
        public static DataTable ListaOpcionMenuAPP_Usuario(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaOpcionMenuAPP_Usuario(cod);
        }
        //
        //
        //
        //MOSTRAR GRUPO PAGINA
        //
        //

        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteGrupoPaginaROL(string cod, string idpag)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCodigoGrupoPaginaROL(cod, idpag);
        }



        //
        //metodo para listar 
        public static DataTable ListaGrupoModuloopcionROL(string grupo)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaGrupoModuloOpcionRol(grupo);
        }

        //metodo para correo usuarios
        public static bool BuscExisteCorreoUsuarioROL(string cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCorreoUsuarioROL(cod);

        }
        //BuscExisteCorreoUsuarioPB


        //
        //
        //MOSTRAR ROL USUARIO
        //
        //

        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteRolUsuarioROL(string cod, string rol)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCodigoRolUsuarioROL(cod, rol);
        }

        //
        //metodo para guardar usuario 
        public void GuardRolUsuarioROL(string codigo, string grupo, string iduser, string user, bool acceso)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarRolUsuarioROL(codigo, grupo, iduser, user, acceso);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaRolUsuarioROL(string codigo, string grupo, string iduser, string user, bool acceso)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarRolUsuarioROL(codigo, grupo, iduser, user, acceso);
        }


        //
        //metodo para listar usuarios
        public static DataTable ListaRolUsuarioROL(string user)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaRolUsuarioROL(user);
        }

        //
        //metodos para guardar o actualizar en bloque (SqlBulkCopy)
        public void GuardarActualizarROLMasivo(DataTable roles)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarROLMasivo(roles);
        }

        public void GuardarActualizarMenuMasivo(DataTable menus)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarMenuMasivo(menus);
        }

        public void GuardarActualizarMenuSubmenuMasivo(DataTable submenus)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarMenuSubmenuMasivo(submenus);
        }

        public void GuardarActualizarMenuSubmenuRolMasivo(DataTable permisos)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarMenuSubmenuRolMasivo(permisos);
        }

        public void GuardarActualizarMenuAPPMasivo(DataTable apps)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarMenuAPPMasivo(apps);
        }

        public void GuardarActualizarMenuAPP_UsuarioMasivo(DataTable permisos)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarMenuAPP_UsuarioMasivo(permisos);
        }

        //
        //metodo para guardar o actualizar las opciones de app en bloque (SqlBulkCopy)
        public void GuardarActualizarAppOpcionesMasivo(DataTable opciones)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarAppOpcionesMasivo(opciones);
        }

        //
        //metodo para listar las opciones de una app
        public static DataTable ListaOpcionApp(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaOpcionApp(cod);
        }

        //
        //metodo para guardar o actualizar los permisos en bloque (SqlBulkCopy)
        public void GuardarActualizarPermisoAppMovilMasivo(DataTable permisos)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarActualizarPermisoAppMovilMasivo(permisos);
        }

        //
        //metodo para listar las opciones de app con el acceso de un usuario
        public static DataTable ListaAppOpciones(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.ListaAppOpciones(cod);
        }

    }
}
