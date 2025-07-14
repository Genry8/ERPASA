using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_reportes
    {
        //metodo para listar usuarios venta
        public static DataTable BuscListUserVent(string usuario)
        {
            cd_reportes datos = new cd_reportes();
            return datos.BuscarListaUsuariosVenta(usuario);
        }

        //metodo para listar ventas del usuario
        public static DataTable ListVentPorUser(int user, DateTime fecini, DateTime fecfin)
        {
            cd_reportes datos = new cd_reportes();
            return datos.ListaVentaPorUsuarios(user, fecini, fecfin);
        }

        //metodo para listar compras del usuario
        public static DataTable ListCompPorUser(int user, DateTime fecini, DateTime fecfin)
        {
            cd_reportes datos = new cd_reportes();
            return datos.ListaCompraPorUsuarios(user, fecini, fecfin);
        }

        //metodo para listar ventas del usuario
        public DataSet ListVentPrueba(int user, DateTime fecini, DateTime fecfin)
        {
            cd_reportes datos = new cd_reportes();
            return datos.MostrarVentasPorUser_Dst(user, fecini, fecfin);
        }

        //metodo para mostrar el nombre del usuario y sede
        public bool BuscarUserVent(int user)
        {
            cd_reportes datos = new cd_reportes();
            return datos.BuscarUsuariosPorVenta(user);
        }

        //metodo para listar stock por almacen
        public static DataTable ListStockPorAlm(string almacen, string producto, string talla)
        {
            cd_reportes datos = new cd_reportes();
            return datos.ListStockPorAlmacen(almacen, producto, talla);
        }

        //metodo para listar stock por producto
        public static DataTable ListStockProd(string almacen, string producto, string talla)
        {
            cd_reportes datos = new cd_reportes();
            return datos.ListStockProducto(almacen, producto, talla);
        }

        //
    }
}
