using System;

namespace CapaEntidad
{
    public partial class ce_datosventa
    {
        //USUARIOS DE BUSQUEDA POR DNI PARA AGREGAR SI EXISTE
        public static int fac_buscar { get; set; }
        public static int invnum_buscar { get; set; }
        public static int sec_buscar { get; set; }
        public static int secmov_buscar { get; set; }
        public static int facmov_buscar { get; set; }

        //DATOS QUE SE GUARDAN DE DATAGRIDDVIEW EN ORDEN DE COMPRA CABECERA

        public static Decimal Tot_par_c { get; set; }
        public static Decimal igv_par_c { get; set; }
        public static Decimal Tot_brt_c { get; set; }
        public static Decimal rebpar_c { get; set; }
        public static Decimal pagacon_c { get; set; }
        public static Decimal vuelto_c { get; set; }
        public static string estado_c { get; set; }
        public static string sexclient_c { get; set; }
        public static string doc_fa_c { get; set; }
        public static string doc_ser_c { get; set; }
        public static string doc_pag_c { get; set; }
        public static string tarjet_c { get; set; }
        public static int codcontact_c { get; set; }
        public static string obsprod_c { get; set; }


        //DATOS QUE SE GUARDAN DE DATAGRIDDVIEW ORDEN DE COMPRA DETALLE
        public static int NumFac { get; set; }
        public static int Sec { get; set; }
        public static int Item { get; set; }
        public static int docclient { get; set; }
        public static string desclient { get; set; }
        public static string Codpro { get; set; }
        public static string Producto { get; set; }
        public static string marca { get; set; }
        public static string talla { get; set; }
        public static string genero { get; set; }
        public static string color { get; set; }
        public static int cant_pro { get; set; }
        public static Decimal qtypro { get; set; }
        public static Decimal Descpro { get; set; }
        public static Decimal Igv { get; set; }
        public static Decimal Tot_par { get; set; }
        public static Decimal Tot_brt { get; set; }
        public static string itmsta { get; set; }
        public static Decimal pordsc1 { get; set; }
        public static Decimal pordsc2 { get; set; }
        public static string estado { get; set; }
        public static Decimal coscom { get; set; }
        public static int stkalm { get; set; }
        public static Decimal qtypro_m { get; set; }
        public static int qtysal { get; set; }
        public static int qtysal_m { get; set; }
        public static string obsprod { get; set; }

        //AGREGAR DATOS A UN DATAGRID ENLAZADO
        public static string codpro_adt { get; set; }
        public static string producto_adt { get; set; }
        public static string marca_adt { get; set; }
        public static string talla_adt { get; set; }
        public static string color_adt { get; set; }
        public static string tipouso_adt { get; set; }
        public static int cant_adt { get; set; }
        public static decimal precio_unit_adt { get; set; }
        public static decimal descuento_adt { get; set; }
        public static decimal totpar_adt { get; set; }
        public static decimal igv_adt { get; set; }
        public static decimal totparbrt_adt { get; set; }
        public static decimal stock_adt { get; set; }
        public static string obsprod_adt { get; set; }
        public static string estado_adt { get; set; }

        //BUSCAR DATOS DEL CLIENTE Y MONTO PAGO EN ORDEN DE COMPRA
        public static string Almacen_busc { get; set; }
        public static string TipoDocumento_busc { get; set; }
        public static string SerieDocumento_busc { get; set; }
        public static int MedioContacto_busc { get; set; }
        public static string TipoPago_Busc { get; set; }
        public static string TarjetaPago_Busc { get; set; }
        public static string Comentario_Busc { get; set; }
        public static int Factura_Busc { get; set; }
        public static int Secuencia_Busc { get; set; }
        public static string TipDocIdent_busc { get; set; }
        public static int DniCliente_busc { get; set; }
        public static string Cliente_busc { get; set; }
        public static string ApellidoCliente_busc { get; set; }
        public static string NombresCliente_busc { get; set; }
        public static string Dirección_busc { get; set; }
        public static string ClienteSexo_busc { get; set; }
        public static string TelefonoCliente_busc { get; set; }
        public static decimal Total_busc { get; set; }
        public static decimal Igv_busc { get; set; }
        public static decimal SubTotal_busc { get; set; }
        public static decimal Rebaja_busc { get; set; }
        public static decimal Pagacon_busc { get; set; }
        public static decimal Vuelto_busc { get; set; }
        public static string Observacion_busc { get; set; }
        public static string Usr_Busc { get; set; }

        //ULTIMA FACTURA Y SECUENCIA PARA MOSTRAR EN PANEL DE VENTA
        public static int Ult_NumFac { get; set; }
        public static int Ult_Sec { get; set; }

        //SELECCIONAR UN ALMACEN Y ENVIAR A LA SIGUIENTE VARIABLE
        public static string Select_almacen { get; set; }

        //BUSCAR CODIGO DE CLIENTE
        public static int Codigo_Cliente { get; set; }

    }
    public class ce_datosventa_OrdPend
    {
        //LISTAR DATOS DE ORDENES PENDIENTES
        public static int Secuencia_OrdenPendiente { get; set; }
        public int Secuencia_OrdPend { get; set; }
        public string Documento_OrdPend { get; set; }
        public string Dni_OrdPend { get; set; }
        public string Cliente_OrdPend { get; set; }
        public Decimal Total_OrdPend { get; set; }
        public string Estado_OrdPend { get; set; }
        public string Estado1_OrdPend { get; set; }

        public static string Total { get; set; }
    }

}
