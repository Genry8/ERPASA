using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class cn_datoscliente
    {
        /// <summary>
        /// ////////////////////////////////////
        /// ///QUERY PARA CARGAR TODOS LOS DATOS DEL CLIENTE
        /// ///////////////////////////////////
        /// </summary>
        /// 

        //metodo para listar tipo de almacenes
        public static DataTable ListAlm()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaAlmacenes();
        }

        //metodo para listar tipo documento de identidad
        public static DataTable ListDocIdent()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaDocIdentidad();
        }

        //metodo para listar tipo de sexo
        public static DataTable ListSex()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaSexo();
        }

        //metodo para listar tipo de pago
        public static DataTable ListTipPag()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaTipoPago();
        }

        //metodo para listar tipo de tarjeta
        public static DataTable ListTipTarjet()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaTipoTarjeta();
        }

        //metodo para listar estado documento
        public static DataTable ListEstDoc()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaEstadoDocumento();
        }

        //metodo para listar estado documento
        public static DataTable MedioContact()
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.ListaMedioContacto();
        }


        //metodo para buscar cliente
        public bool BuscClient(string dni)
        {
            cd_datoscliente datos = new cd_datoscliente();
            return datos.BuscarCliente(dni);
        }
    }
}
