using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_datosventa : cd_conexion
    {
        /// <summary>
        /// ////////////////////////////////////
        /// ///QUERY PARA CARGAR LOS COMBOS EN EL FORMULARIO ORDEN DE VENTA
        /// ///////////////////////////////////
        /// </summary>
        /// 
         //metodo para listar almacenes por usuario
        public static DataTable ListAlmcenuser(int usecod)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaAlmacenesUsuario(usecod);
        }

        //metodo para listar almacenes
        public static DataTable ListAlmcen()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaAlmacenes();
        }

        //metodo para listar almacenes
        public static DataTable ListAlmcenStock()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaAlmacenesStock();
        }

        //metodo para productos de almacen con stock
        public static DataTable ListProd()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaProductos();
        }

        //metodo para productos TALLA con stock
        public static DataTable ListProdTalla()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaProductosTalla();
        }

        //metodo para listar tipo documento
        public static DataTable ListDoc()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaDocumento();
        }

        //metodo para listar tipo documento-serie
        public static DataTable ListDocSerie(string codoc)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaDocumentoSerie(codoc);
        }


        /// 
        /// ////////////////////////////////////
        /// ////////////////////////////////////
        /// QUERY PARA LLAMAR FACTURA
        /// ///////////////////////////////////
        /// ///////////////////////////////////
        /// 
        /// 
        //metodo para listar usuarios
        public static DataTable ListEstadFac()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.EstadoFac();
        }

        //BUSCAR VENTA POR FAC DATABLE
        public static DataTable BuscarVentaFac(int fac)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarFactura(fac);
        }

        //BUSCAR VENTA POR FAC DATABLE
        public static DataTable BuscarVentaSec_Ord(int invnum)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarVentaSecuencia_Ord(invnum);
        }

        //BUSCAR VENTA POR MOVIMIENTO DETALLE
        public static DataTable BuscarMovDetalle(int fac)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarMovimientoDetalle(fac);
        }

        //BUSCAR DATOS DE ORDEN DE VENTA 
        public bool BuscaDatVent(int sec)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarDatosVenta(sec);
        }

        //BUSCAR DATOS DE MOVIMIENTO DE VENTA POR ORDEN
        public bool BuscaDatMovVent_Ord(int invnum)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarDatosVenta_PorOrden(invnum);
        }

        //BUSCAR DATOS DE MOVIMIENTO DE VENTA 
        public bool BuscaDatVentMov(int fac)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarDatosVentaMov(fac);
        }

        //BUSCAR VENTA POR FAC TEXT
        public bool BuscaFacturaText(int fac)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarFacturaText(fac);
        }

        //BUSCAR VENTA POR FAC TEXT
        public bool BuscaSecuenciaText(int sec)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarSecuenciaText(sec);
        }

        //BUSCAR VENTA POR ORDEN DE COMPRA TEXT
        public bool BuscaMovimientoOrdText(int invnum)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarMovimientoOrdenText(invnum);
        }

        //BUSCAR VENTA POR FAC TEXT
        public bool BuscaSecuenciaMov(int sec)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarSecuenciaMovimiento(sec);
        }

        //GUARDAR VENTA ORDEN COMPRA CABECERA
        public static DataTable GuardarOrdenCompCabc(int sec, int docclient, string desclient, string codalm, decimal totpar,
            decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto, string estado,
            string coddoc, string sexclient, string doc_fa, string doc_ser, string doc_pag, string tarj_cod, int codcontac,
            string obs_fac, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.GuardarOrdenCompraCabecera(sec, docclient, desclient, codalm, totpar,
             igv_par, totpar_brt, reb_par, pagcon, vuelto, estado,
             coddoc, sexclient, doc_fa, doc_ser, doc_pag, tarj_cod, codcontac,
             obs_fac, feccre, fecmov, siscod, userreg, usenamreg, hostname, ipcre);
        }

        //GUARDAR VENTA ORDEN COMPRA DETALL
        public static DataTable GuardarOrdenCompDetall(int sec, int item, int docclient, string desclient, string codalm, string codpro,
            string despro, string marca, string talla, string genero, string color, int cantpro, decimal precio, decimal descpro, decimal igv, decimal totpar,
            decimal totpar_brt, string itmsta, decimal pordsc1, decimal pordsc2, string estado, decimal coscom, int stkalm,
            decimal qtypro_m, int qtysal, int qtysalm, string obsprod, DateTime feccre, DateTime fecmov, int siscod, int userreg,
            string usenamreg, string hostname, string ipcre)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.GuardarOrdenCompraDetalle(sec, item, docclient, desclient, codalm, codpro,
             despro, marca, talla, genero, color, cantpro, precio, descpro, igv, totpar,
             totpar_brt, itmsta, pordsc1, pordsc2, estado, coscom, stkalm,
             qtypro_m, qtysal, qtysalm, obsprod, feccre, fecmov, siscod, userreg,
             usenamreg, hostname, ipcre);
        }

        //GUARDAR VENTA MOVIMIENTOS CABECERA
        public static DataTable GuardarMovCabecera(int numfac, int sec, int docclient, string desclient, string codalm, decimal totpar,
            decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto, string estado,
            string coddoc, string sexclient, string doc_fa, string doc_ser, string doc_pag, string tarj_cod, int codcontac,
            string obs_fac, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.GuardarMovimientosCabecera(numfac, sec, docclient, desclient, codalm, totpar,
             igv_par, totpar_brt, reb_par, pagcon, vuelto, estado,
             coddoc, sexclient, doc_fa, doc_ser, doc_pag, tarj_cod, codcontac,
             obs_fac, feccre, fecmov, siscod, userreg, usenamreg, hostname, ipcre);
        }

        //GUARDAR VENTA MOVIMIENTOS DETALL
        public static DataTable GuardarMovDetalle(int sec, int item, int docclient, string desclient, string codalm, string codpro,
            string despro, string marca, string talla, string genero, string color, int cantpro, decimal precio, decimal descpro, decimal igv, decimal totpar,
            decimal totpar_brt, string itmsta, decimal pordsc1, decimal pordsc2, string estado, decimal coscom, int stkalm,
            decimal qtypro_m, int qtysal, int qtysalm, string obsprod, DateTime feccre, DateTime fecmov, int siscod, int userreg,
            string usenamreg, string hostname, string ipcre)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.GuardarMovimientoDetalle(sec, item, docclient, desclient, codalm, codpro,
             despro, marca, talla, genero, color, cantpro, precio, descpro, igv, totpar,
             totpar_brt, itmsta, pordsc1, pordsc2, estado, coscom, stkalm,
             qtypro_m, qtysal, qtysalm, obsprod, feccre, fecmov, siscod, userreg,
             usenamreg, hostname, ipcre);
        }

        //Eliminar factura
        public void EliminarFac(int sec)
        {
            cd_datosventa datos = new cd_datosventa();
            datos.EliminarFactura(sec);
        }

        //Facturar orden
        public void FacturarOrdn(int sec)
        {
            cd_datosventa datos = new cd_datosventa();
            datos.FacturarOrden(sec);
        }

        //Eliminar factura movimiento
        public void EliminarMovimiento(int fac)
        {
            cd_datosventa datos = new cd_datosventa();
            datos.EliminarMovimiento(fac);
        }

        //////////////////////////////
        ////BUSCAR PRODUCTO
        /////////////////////////////
        ///
        //BUSCAR PRODUCTO DATABLE
        public static DataTable BuscarProducto(string despro, string codalm)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarProductoParaVenta(despro, codalm);
        }

        //BUSCAR PRODUCTO PARA COMPRA
        public static DataTable BuscarProductoCompra(string despro, string codalm)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.BuscarProductoParaCompra(despro, codalm);
        }

        //GUARDAR CLIENTE
        //metodo para guardar cliente
        public void GuardCliente(string codcli, string apellcli, string namcli, string tipdoc, string sexo,
            string pacobs, string apcdoc, string ubicod, string pactel, string pacdir, string estado, DateTime fec_cre,
            DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            cd_datosventa datos = new cd_datosventa();
            datos.GuardarCliente(codcli, apellcli, namcli, tipdoc, sexo,
             pacobs, apcdoc, ubicod, pactel, pacdir, estado, fec_cre,
             fec_mov, usereg, usenamreg, hostname, ip_pc);
        }

        //metodo para actualizar cliente
        public void ActuaCliente(string codcli, string apellcli, string namcli, string tipdoc, string sexo,
            string pacobs, string apcdoc, string ubicod, string pactel, string pacdir, string estado,
            DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            cd_datosventa datos = new cd_datosventa();
            datos.ActualizarCliente(codcli, apellcli, namcli, tipdoc, sexo,
             pacobs, apcdoc, ubicod, pactel, pacdir, estado,
             fec_mov, usereg, usenamreg, hostname, ip_pc);
        }

        //BUSCAR SI EXISTE EL PERSONAL
        public bool CodigoClienteMasUno()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.CodigoClienteMasUno();
        }

        //metodo para listar ord Pend
        public static DataTable ListOrdPendiente()
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaOrdenPendiente();
        }

        //metodo para listar ordenes pend user
        public static DataTable ListOrdPendienteUser(int user)
        {
            cd_datosventa datos = new cd_datosventa();
            return datos.ListaOrdenPendientePorUsuario(user);
        }

    }
}
