using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_rolesuser : cd_conexion
    {
        //
        //
        //USUARIO BI
        //
        //
        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteMenuSubMenu(int idmenu, int idsubmenu)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCodigoUsuarioROL(idmenu, idsubmenu);
        }

        public static bool BuscExisteMenuSubMenuRol(int idrol, int idsubmenu)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteMenuSubMenuRol(idrol, idsubmenu);
        }

        public static bool BuscExisteMenuAPP_Usuario(int idusuario, int idapp)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteMenuAPP_Usuario(idusuario, idapp);
        }


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




        //
        //metodo para guardar menu submenu 
        public void GuardarMenuSubmenu(int idsubmenu, int idmenu, string nombre, string nombreformulario)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarMenuSubmenu(idsubmenu, idmenu, nombre, nombreformulario);
        }
        //
        //metodo para guardar menu submenu rol  
        public void GuardarMenuSubmenuRol(int idrol, int idsubmenu, Boolean activo)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarMenuSubmenuRol(idrol, idsubmenu, activo);
        }


        //metodo para guardar menu usuario 
        public void GuardarMenuAPP_Usuario(int idapp, int iduser, Boolean activo)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarMenuAPP_Usuario(idapp, iduser, activo);
        }


        //metodo para guardar usuario 
        public void GuardarUsuario(int cod, string nombre, string usuario, string clave, int idrol)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarUsuario(cod, nombre, usuario, clave, idrol);
        }

        //
        //metodo para actualizar menu submenu
        public void ActualizarMenuSubmenu(int idsubmenu, int idmenu, string nombre, string nombreformulario)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarMenuSubmenu(idsubmenu, idmenu, nombre, nombreformulario);
        }


        //
        //metodo para actualizar menu submenu rol
        public void ActualizarMenuSubmenuRol(int idrol, int idsubmenu, Boolean activo)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarMenuSubmenuRol(idrol, idsubmenu, activo);
        }

        //
        //metodo para actualizar menu submenu app
        public void ActualizarMenuAPP_Usuario(int idapp, int idusuario, Boolean activo)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarMenuAPP_Usuario(idapp, idusuario, activo);
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
        //
        //MODULO USER
        //
        //
        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteROL(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCodigoROL(cod);
        }

        //
        //metodo para guardar usuario 
        public void GuardarROL(int codigo, string nombre)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarROL(codigo, nombre);
        }

        //
        //metodo para actualizar usuario 
        public void ActualizaROL(int codigo, string nombre)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarROL(codigo, nombre);
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

        //
        //
        //GRUPO BI
        //
        //
        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteMenu(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteMenu(cod);
        }
        public static bool BuscExisteMenuAPP(int cod)
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteMenuAPP(cod);
        }

        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteOpcionMasunoROL()
        {
            cd_rolesuser datos = new cd_rolesuser();
            return datos.BuscExisteCodigoOpcionMasUnoROL();
        }


        //
        //metodo para guardar usuario 
        public void GuardarMenu(int codigo, string des, string icono)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarMenu(codigo, des, icono);
        }

        //
        //metodo para guardar menu app
        public void GuardarMenuAPP(int codigo, string des, string icono)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.GuardarMenuAPP(codigo, des, icono);
        }

        //
        //metodo para actualizar usuario 
        public void ActualizarMenu(int codigo, string des, string icono)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarMenu(codigo, des, icono);
        }

        //
        //metodo para actualizar usuario 
        public void ActualizarMenuAPP(int codigo, string des, string icono)
        {
            cd_rolesuser datos = new cd_rolesuser();
            datos.ActualizarMenuAPP(codigo, des, icono);
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


    }
}
