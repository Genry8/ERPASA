using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class cn_nisira : cd_conexionNisira
    {
        //metodo para listar personal nisira
        public static DataTable ListaPersonalNisira()
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaPersonalNisira();
        }

        //metodo para listar personal update
        public static DataTable ListaPersonalUpdate()
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaPersonalUpdate();
        }


        //metodo para listar personal nisira por dni
        public static DataTable ListaPersonalNisiraDni(string dni)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaPersonalNisiraDni(dni);
        }

        //metodo para listar personal nisira por dni
        public static DataTable ListaPersonalNisiraApellido(string apellido)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaPersonalNisiraApellido(apellido);
        }

        //metodo para listar personal nisira por dni
        public static DataTable ListaPersonalNisiraNombre(string nombre)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaPersonalNisiraNombre(nombre);
        }

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExisteCodUsuario(string cod)
        {
            cd_nisira datos = new cd_nisira();
            return datos.BuscExisteCodigoUsuario(cod);
        }

        //metodo para listar personal nisira por dni
        public static DataTable ListaLoteNisira(string id)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaLoteNisira(id);
        }

        //metodo para listar cultivo
        public static DataTable ListaCultivoNisira(string id)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaCultivoNisira(id);
        }

        //metodo para listar cultivo
        public static DataTable ListaVariedadNisira(string id)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaVariedadNisira(id);
        }


    }
}
