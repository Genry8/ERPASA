using CapaDatos;
using CapaEntidad;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_usuario
    {
        ce_usuario objentUsuarios = new ce_usuario();
        //metodo para listar usuarios
        public static DataTable ListUser()
        {
            cd_usuarios datos = new cd_usuarios();
            return datos.listausuario();
        }

        //metodo para listar usuarios en datagrid
        public static DataTable ListUser_prueba(string dni)
        {
            cd_usuarios datos = new cd_usuarios();
            return datos.listausuario_prueba(dni);
        }


        //metodo para buscar foto
        public DataTable FotoUser(int usecod)
        {
            cd_usuarios datos = new cd_usuarios();
            return datos.fotousuario(usecod);
        }

        //metodo para buscar foto firma
        public DataTable FotoUserFirma(string usecod)
        {
            cd_usuarios datos = new cd_usuarios();
            return datos.fotousuarioFirma(usecod);
        }

        //metodo para listar perfiles
        public static DataTable ListPerfil()
        {
            cd_usuarios datos = new cd_usuarios();
            return datos.listaperfil();
        }

        public void VersionIpress()
        {
            cd_usuarios datos = new cd_usuarios();
            datos.VESION_IPRESSREPORTE();
        }

        //metodo para buscar usuarios
        public bool BuscUser(int dni, string constraseña, string app)
        {
            cd_usuarios datos = new cd_usuarios();
            return datos.BuscarUsuario(dni, constraseña, app);
        }

        public void GuardUser(int usecod, int siscod, int usedoc, string usenam, string useusr, string estado, string hostname, string ip_pc, DateTime fecha_acceso)
        {
            cd_usuarios datos = new cd_usuarios();
            datos.GuardarUsuario(usecod, siscod, usedoc, usenam, useusr, estado, hostname, ip_pc, fecha_acceso);
        }

        public void GuardUserBillit(string apellidos, string nombres, string sexo, string grupo, int dni, string contraseña, string estado, string planilla, int usercre, string ip_pc, DateTime fechacre, Byte[] imagen)
        {
            cd_usuarios datos = new cd_usuarios();
            datos.GuardarUsuario_Billiterita(apellidos, nombres, sexo, grupo, dni, contraseña, estado, planilla, usercre, ip_pc, fechacre, imagen);
        }

        //public bool BuscarUserBillitDni(int dni)
        //{
        //    cd_usuarios datos = new cd_usuarios();
        //    return datos.BuscarUsuario(dni);
        //}

        public void ElimUserBillitDni(int dni)
        {
            cd_usuarios datos = new cd_usuarios();
            datos.eliminarUsuarioDni(dni);
        }

        public void ActualizarUserBillit(string apellidos, string nombres, string sexo, string grupo, int dni, string contraseña, string estado, string planilla, Byte[] imagen)
        {
            cd_usuarios datos = new cd_usuarios();
            datos.ActualizarUsuarioDni(apellidos, nombres, sexo, grupo, dni, contraseña, estado, planilla, imagen);
        }

    }
}
