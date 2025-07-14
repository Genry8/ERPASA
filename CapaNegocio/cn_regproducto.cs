using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_regproducto
    {
        //metodo para buscar ultimo producto registrado +1
        public static bool BuscUltimoProd()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.UltimoPorducto();
        }

        //metodo para listar el grupo de producto
        public static DataTable ListGrupPro()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaGrupoProducto();
        }

        //metodo para listar el grupo de producto para descuento
        public static DataTable ListGrupProDesc()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaGrupoProductoDescuento();
        }

        //metodo para listar el tipo de producto
        public static DataTable ListTipPro()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaTipoProducto();
        }

        //metodo para listar el tipo de producto para descuento
        public static DataTable ListTipProDesc()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaTipoProductoDescuento();
        }

        //metodo para listar la marca de producto
        public static DataTable ListMarcProd()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaMarcaProducto();
        }

        //metodo para listar la marca de producto para descuento
        public static DataTable ListMarcProdDesc()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaMarcaProductoDescuento();
        }

        //metodo para listar la talla de producto
        public static DataTable ListTallProd()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaTallaProducto();
        }

        //metodo para listar la talla de producto para descuento
        public static DataTable ListTallProdDesc()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaTallaProductoDescuento();
        }

        //metodo para listar la condicion de producto
        public static DataTable ListCond()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaCondicion();
        }

        public static DataTable ListCondST()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaCondicionST();
        }









        //metodo para listar proveedores
        public static DataTable ListProvee()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaProveedores();
        }






        //metodo para listar la condicion del almacen
        public static DataTable ListCondAlm()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaCondicionAlmacen();
        }

        //metodo para listar moneda
        public static DataTable ListMoneda()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaMoneda();
        }

        //metodo para listar centro de costo
        public static DataTable ListCenCos()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaCentroCosto();
        }

        //metodo para listar Fabricantes
        public static DataTable ListFabric()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaFabricantes();
        }

        //metodo para listar Fabricantes
        public static DataTable ListColor()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaColores();
        }

        //metodo para listar ABC
        public static DataTable ListABCD()
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.ListaABCDARIO();
        }

        //BUSCAR PRODUCTO PARA EDITAR DATPOS
        public bool BuscaProdCod(string codpro)
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.BuscarProductoCpd(codpro);
        }

        //BUSCAR SI EXISTE EL PRODUCTO
        public bool BuscaProdExist(string codpro)
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.BuscarPproductoExistente(codpro);
        }

        //BUSCAR PRODUCTO DATABLE
        public static DataTable BuscarProductoRegistrado(string despro)
        {
            cd_regproducto datos = new cd_regproducto();
            return datos.BuscarProductoRegistrado(despro);
        }

        //metodo para guardar producto 
        public void GuardProducto(int codpro, string codgru, string codtip, string despro, string despro_l, string codprov, string obsprod,
            string comentpro, string marcpro, string tallpro, string condpro, string monpro, string fabpro, decimal cospro, decimal impcompro,
             decimal impvenpro, decimal fracpro, decimal ultbspro, decimal descvenpro, decimal ultvtapro, decimal frac, decimal prefnpro, string cencos, decimal cosbspro,
             decimal coscmpro, decimal cosprpro, int stkpro, string genpro, string fampro, string admpro, int cantpro, string abc, string desabc,
             string codabc, DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            cd_regproducto datos = new cd_regproducto();
            datos.GuardarProducto(codpro, codgru, codtip, despro, despro_l, codprov, obsprod,
             comentpro, marcpro, tallpro, condpro, monpro, fabpro, cospro, impcompro,
              impvenpro, fracpro, ultbspro, descvenpro, ultvtapro, frac, prefnpro, cencos, cosbspro,
              coscmpro, cosprpro, stkpro, genpro, fampro, admpro, cantpro, abc, desabc,
              codabc, fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc);
        }

        //metodo para actualizar producto 
        public void ActualiProducto(int codpro, string codgru, string codtip, string despro, string despro_l, string codprov, string obsprod,
            string comentpro, string marcpro, string tallpro, string condpro, string monpro, string fabpro, decimal cospro, decimal impcompro,
             decimal impvenpro, decimal fracpro, decimal frac, decimal ultbspro, decimal descvenpro, decimal ultvtapro, decimal prefnpro, string cencos, decimal cosbspro,
             decimal coscmpro, decimal cosprpro, int stkpro, string genpro, string fampro, string admpro, int cantpro, string abc, string desabc,
             string codabc, DateTime fec_mov)
        {
            cd_regproducto datos = new cd_regproducto();
            datos.ActualizarProducto(codpro, codgru, codtip, despro, despro_l, codprov, obsprod,
             comentpro, marcpro, tallpro, condpro, monpro, fabpro, cospro, impcompro,
              impvenpro, fracpro, frac, ultbspro, descvenpro, ultvtapro, prefnpro, cencos, cosbspro,
              coscmpro, cosprpro, stkpro, genpro, fampro, admpro, cantpro, abc, desabc,
              codabc, fec_mov);
        }

        //ELIMINAR PRODUCTO
        public void EliminarProd(string codpro)
        {
            cd_regproducto datos = new cd_regproducto();
            datos.EliminarProducto(codpro);
        }

        //GUARDAR DESCEUNTO POR PRODUCTO
        public void GuarDescProd(string codgru, string codmar, string codtall, decimal desc)
        {
            cd_regproducto datos = new cd_regproducto();
            datos.GuardarDescuentoDeProductos(codgru, codmar, codtall, desc);
        }

    }
}
