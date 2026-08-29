using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_compraproducto
    {
        //metodo para buscar lista almacen
        public static DataTable ListAlm()
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.ListaAlmacenes();
        }

        //metodo para listar tipo orden
        public static DataTable ListTipOrd()
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.ListaTipoOrden();
        }

        //metodo para buscar lista proveedor
        public static DataTable ListProvee()
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.ListaProveedores();
        }

        //metodo para lista condicion compra
        public static DataTable ListCondCompra()
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.ListaCondicionCompra();
        }

        //BUSCAR COD ORDEN PRODUCTO
        public bool BuscaSecuenciaOrd(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarSecuenciaOrden(sec);
        }

        //BUSCAR COD ORDEN PRODUCTO
        public bool BuscaCompProdOrd(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarCompraProductoOrden(sec);
        }

        //BUSCAR COD COMPRA PRODUCTO
        public bool BuscaSecuenciaComProd(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarSecuenciaCompraProducto(sec);
        }

        //GUARDAR VENTA ORDEN COMPRA CABECERA
        public static DataTable GuardarCompProdCabc(int invnum, int ordsec, string tipord, string codalm, string codprov, string codtcos,
            string codarea, DateTime fecvig, string tippago, string tipdoc, string numdoc1, string numdoc2, string medcont, string moneda, DateTime feccom, DateTime fecentr,
            int plazo_d, string coment, decimal totpar, decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto, decimal envio, string itmsta,
            string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.GuardarCompraProductoCabecera(invnum, ordsec, tipord, codalm, codprov, codtcos,
             codarea, fecvig, tippago, tipdoc, numdoc1, numdoc2, medcont, moneda, feccom, fecentr,
             plazo_d, coment, totpar, igv_par, totpar_brt, reb_par, pagcon, vuelto, envio, itmsta,
             estado, feccre, fecmov, siscod, userreg, usenamreg, hostname, ipcre);
        }

        //GUARDAR VENTA ORDEN COMPRA CABECERA
        public static DataTable GuardarOrdenCompCabc(int ordsec, string tipord, string codalm, string codprov, string codtcos,
            string codarea, DateTime fecvig, string tippago, string tiptarj, string medcont, string moneda, DateTime feccom, DateTime fecentr,
            int plazo_d, string coment, decimal totpar, decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto, decimal envio, string itmsta,
            string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.GuardarOrdenCompraCabecera(ordsec, tipord, codalm, codprov, codtcos,
             codarea, fecvig, tippago, tiptarj, medcont, moneda, feccom, fecentr,
             plazo_d, coment, totpar, igv_par, totpar_brt, reb_par, pagcon, vuelto, envio, itmsta,
             estado, feccre, fecmov, siscod, userreg, usenamreg, hostname, ipcre);
        }

        //GUARDAR VENTA ORDEN COMPRA DETALL
        public static DataTable GuardarCompProdDetall(int secord, int numitm, string tipord, string codalm, string codprov, string codarea,
            string codpro, string despro, string marca, string genero, string talla, string color, int stock_e, decimal stock_K, int cant_e, decimal cant_K, decimal qtypro,
            decimal desc1, decimal desc2, decimal desc3, decimal igv, decimal totpar, decimal totpar_brt, decimal cos_com, decimal bas_com, decimal prec_com,
            decimal parcial, string obsprod, string itmsta, string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg,
            string hostname, string ipcre)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.GuardarCompraProductoDetalle(secord, numitm, tipord, codalm, codprov, codarea,
             codpro, despro, marca, genero, talla, color, stock_e, stock_K, cant_e, cant_K, qtypro,
             desc1, desc2, desc3, igv, totpar, totpar_brt, cos_com, bas_com, prec_com,
             parcial, obsprod, itmsta, estado, feccre, fecmov, siscod, userreg, usenamreg,
             hostname, ipcre);
        }

        //GUARDAR VENTA ORDEN COMPRA DETALL
        public static DataTable GuardarOrdenCompDetall(int ordsec, int numitm, string tipord, string codalm, string codprov, string codarea,
            string codpro, string despro, string marca, string genero, string talla, string color, int stock_e, decimal stock_K, int cant_e, decimal cant_K, decimal qtypro,
            decimal desc1, decimal desc2, decimal desc3, decimal igv, decimal totpar, decimal totpar_brt, decimal cos_com, decimal bas_com, decimal prec_com,
            decimal parcial, string obsprod, string itmsta, string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg,
            string hostname, string ipcre)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.GuardarOrdenCompraDetalle(ordsec, numitm, tipord, codalm, codprov, codarea,
             codpro, despro, marca, genero, talla, color, stock_e, stock_K, cant_e, cant_K, qtypro,
             desc1, desc2, desc3, igv, totpar, totpar_brt, cos_com, bas_com, prec_com,
             parcial, obsprod, itmsta, estado, feccre, fecmov, siscod, userreg, usenamreg,
             hostname, ipcre);
        }

        //BUSCAR DATABLE DE ORDEN
        public static DataTable BuscarOrdVent(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarOrdenCompra(sec);
        }

        //
        //BUSCAR DATABLE DE ORDEN
        public static DataTable BuscarCompProd_Ord(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarCompraProducto_ord(sec);
        }

        //BUSCAR DATOS DE ORDEN DE COMPRA
        public bool BuscaDatOrdCompra(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarDatosOrdenCompra(sec);
        }

        //BUSCAR DATOS DE ORDEN DE COMPRA
        public bool BuscaDatComppraProdOrd(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarDatosCompraProducto_ord(sec);
        }

        //BUSCAR DETALLE DE COMPRA PRODUCTO DETALLE
        public static DataTable BuscarCompProdDetalle(int fac)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarCompraProductoDetalle(fac);
        }

        //BUSCAR DATOS DE COMPRA PRODUCTO CABECERA
        public bool BuscaDatCompraProducto(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            return datos.BuscarDatosCompraProducto(sec);
        }

        //ELIMINAR ORDEN
        public void EliminarOrdenComProd(int sec)
        {
            cd_compraproducto datos = new cd_compraproducto();
            datos.EliminarOrdenCompraProducto(sec);
        }

        //Eliminar compra producto
        public void EliminarCompraProd(int invnum)
        {
            cd_compraproducto datos = new cd_compraproducto();
            datos.EliminarCompraProducto(invnum);
        }

        //Eliminar compra producto detalle
        public void EliminarCompraProdDetalle(int secord)
        {
            cd_compraproducto datos = new cd_compraproducto();
            datos.EliminarCompraProductoDetalle(secord);
        }

        //Eliminar compra producto detalle
        public void FacturarOrdCompProd(int secord)
        {
            cd_compraproducto datos = new cd_compraproducto();
            datos.FacturarOrdenCompraProducto(secord);
        }

        //

    }
}
