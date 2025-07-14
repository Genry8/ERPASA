using System;

namespace CapaEntidad
{
    public partial class ce_compraproducto
    {
        //DATOS DEL CLIENTE PARA GUARDAR
        public static int invnum_prod { get; set; }
        public static int invnum_prod_ultimo { get; set; }
        public static int invnum_ordpro { get; set; }
        public static int invnum_sec_ordpro { get; set; } //invnum_sec_ordpro
        public static int invnum_ordpro_ultimo { get; set; }

        //DATOS DEL CLIENTE PARA GUARDAR +1
        public static int invnum_prod_mas { get; set; }
        public static int invnum_ordpro_mas { get; set; }

        //DATOS QUE SE GUARDAN DE DATAGRIDDVIEW ORDEN DE COMPRA DETALLE
        public static int invnum { get; set; }
        public static int Item { get; set; }
        public static string Codpro { get; set; }
        public static string Producto { get; set; }
        public static string marca { get; set; }
        public static string genero { get; set; }
        public static string talla { get; set; }
        public static string color { get; set; }
        public static int stock_e { get; set; }
        public static decimal stock_k { get; set; }
        public static int cant_e { get; set; }
        public static decimal cant_k { get; set; }
        public static Decimal qtypro { get; set; }
        public static Decimal Desc1 { get; set; }
        public static Decimal desc2 { get; set; }
        public static Decimal desc3 { get; set; }
        public static Decimal Igv { get; set; }
        public static Decimal Tot_par { get; set; }
        public static Decimal Tot_brt { get; set; }
        public static Decimal cos_com { get; set; }
        public static Decimal bas_com { get; set; }
        public static Decimal pre_com { get; set; }
        public static Decimal parcial { get; set; }
        public static string obsprod { get; set; }
        public static string estado { get; set; }

        //BUSCAR DATOS DEL CLIENTE Y MONTO PAGO EN ORDEN DE COMPRA
        public static int factura_busc { get; set; }
        public static int secuencia_busc { get; set; }
        public static string TipoOrden_busc { get; set; }
        public static string Almacen_busc { get; set; }
        public static string Proveedor_busc { get; set; }
        public static string TipoCosto_busc { get; set; }
        public static string Area_busc { get; set; }
        public static DateTime FechaVigencia_busc { get; set; }
        public static string TipoPago_Busc { get; set; }
        public static string TarjetaPago_Busc { get; set; }
        public static string TipoDocumento_Busc { get; set; }
        public static int MedioContacto_busc { get; set; }
        public static string Moneda_Busc { get; set; }
        public static DateTime FechaCompra_busc { get; set; }
        public static DateTime FechaEntrega_busc { get; set; }
        public static int DiasPlazo_busc { get; set; }
        public static decimal Total_busc { get; set; }
        public static decimal Igv_busc { get; set; }
        public static decimal SubTotal_busc { get; set; }
        public static decimal rebaja_pagar_busc { get; set; }
        public static decimal Pagacon_busc { get; set; }
        public static decimal Vuelto_busc { get; set; }
        public static decimal CosEnvio_busc { get; set; }
        public static string Observaciones_busc { get; set; }
        public static string Documento_busc { get; set; }
        public static string Documento1_busc { get; set; }
        public static string Documento2_busc { get; set; }


    }
}
