using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class cn_rolesbi : cd_conexion
    {
        //
        //
        //USUARIO BI
        //
        //
        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteCodUsuarioPB(string cod)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.BuscExisteCodigoUsuarioPB(cod);
        }

        //
        //metodo para guardar usuario 
        public void GuardUsuarioBI(string codigo, string usuario, string correo, string comentario)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.GuardarUsuarioBI(codigo, usuario, correo, comentario);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaUsuarioBI(string codigo, string usuario, string correo, string comentario)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.ActualizarUsuarioBI(codigo, usuario, correo, comentario);
        }

        //
        //metodo para listar usuarios
        public static DataTable ListaUsuarioBI()
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.ListaUsuarioBI();
        }


        //
        //
        //PAGINA BI
        //
        //
        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExistePaginaPB(string cod)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.BuscExisteCodigoPaginaPB(cod);
        }

        //
        //metodo para guardar usuario 
        public void GuardPaginaBI(string codigo, string pagina, string comentario, int index)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.GuardarPaginaBI(codigo, pagina, comentario, index);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaPaginaBI(string codigo, string pagina, string comentario, int index)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.ActualizarPaginaBI(codigo, pagina, comentario, index);
        }

        //
        //metodo para listar usuarios
        public static DataTable ListaPaginaBI()
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.ListaPaginaBI();
        }

        //
        //
        //GRUPO BI
        //
        //
        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteGrupoPB(string cod)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.BuscExisteCodigoGrupoPB(cod);
        }

        //
        //metodo para guardar usuario 
        public void GuardGrupoBI(string codigo, string grupo, string comentario)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.GuardarGrupoBI(codigo, grupo, comentario);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaGrupoBI(string codigo, string grupo, string comentario)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.ActualizarGrupoBI(codigo, grupo, comentario);
        }

        //
        //metodo para listar GRUPO
        public static DataTable ListaGrupoBI()
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.ListaGrupoBI();
        }

        //
        //
        //MOSTRAR GRUPO PAGINA
        //
        //

        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteGrupoPaginaPB(string cod, string idpag)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.BuscExisteCodigoGrupoPaginaPB(cod, idpag);
        }

        //
        //metodo para guardar usuario 
        public void GuardGrupoPaginaBI(string codigo, string grupo, string idpag, string indice, bool acceso)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.GuardarGrupoPaginaBI(codigo, grupo, idpag, indice, acceso);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaGrupoPaginaBI(string codigo, string grupo, string idpag, string indice, bool acceso)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.ActualizarGrupoPaginaBI(codigo, grupo, idpag, indice, acceso);
        }

        //
        //metodo para listar usuarios
        public static DataTable ListaGrupoPaginaBI(string grupo)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.ListaGrupoPaginaBI(grupo);
        }

        //metodo para correo usuarios
        public static bool BuscExisteCorreoUsuarioPB(string cod)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.BuscExisteCorreoUsuarioPB(cod);

        }
        //BuscExisteCorreoUsuarioPB


        //
        //
        //MOSTRAR ROL USUARIO
        //
        //

        //metodo para buscar si existe codigo de pagina PowerBI
        public static bool BuscExisteRolUsuarioPB(string cod, string rol)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.BuscExisteCodigoRolUsuarioPB(cod, rol);
        }

        //
        //metodo para guardar usuario 
        public void GuardRolUsuarioBI(string codigo, string grupo, string iduser, string user, bool acceso)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.GuardarRolUsuarioBI(codigo, grupo, iduser, user, acceso);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaRolUsuarioBI(string codigo, string grupo, string iduser, string user, bool acceso)
        {
            cd_rolesbi datos = new cd_rolesbi();
            datos.ActualizarRolUsuarioBI(codigo, grupo, iduser, user, acceso);
        }


        //
        //metodo para listar usuarios
        public static DataTable ListaRolUsuarioBI(string user)
        {
            cd_rolesbi datos = new cd_rolesbi();
            return datos.ListaRolUsuarioBI(user);
        }


    }
}
