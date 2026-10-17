using System.Collections.Generic;

namespace CapaEntidad
{
    /// <summary>
    /// Modelos del API REST de NISIRA (ver "NISIRA - Manual del Programador",
    /// Nisira Systems S.A.C., 2024). Los nombres de propiedad respetan el
    /// mismo "case" que aparece en el manual para que el JSON generado sea
    /// idéntico al esperado por el servicio.
    /// </summary>
    public class ce_nisira_api
    {
        // ========================
        // 🔹 3. TOKEN (POST /loginb2b)
        // ========================
        public class NisiraTokenRequest
        {
            public string token { get; set; }
            public string datasourceid { get; set; }
        }

        public class NisiraTokenData
        {
            public string token { get; set; }
        }

        public class NisiraTokenResponse
        {
            public NisiraTokenData data { get; set; }
            public bool error { get; set; }
        }

        // ================================================================
        // 🔹 4. Listado - Ordenes de Liquidación de Gastos
        //     (GET /api/liquidacion-gasto/list/liquidacion-gasto)
        // ================================================================
        public class NisiraListadoFiltro
        {
            /// <summary>Opcional. Ej: "PE" pendiente, "AL" aplicado.</summary>
            public string idestado { get; set; } = "";
            /// <summary>Opcional.</summary>
            public string idarea { get; set; } = "";
            /// <summary>Opcional. Ej: "OLG 0001-0005983".</summary>
            public string documento { get; set; } = "";
            /// <summary>Obligatorio. Formato yyyyMMdd.</summary>
            public string fechaini { get; set; }
            /// <summary>Obligatorio. Formato yyyyMMdd.</summary>
            public string fechafin { get; set; }
        }

        public class NisiraLiquidacionListado
        {
            public string fecha { get; set; }
            public string suc_dsc { get; set; }
            public string idunico { get; set; }
            public string glosa { get; set; }
            public string area_dsc { get; set; }
            public string documento { get; set; }
            public string idclieprov { get; set; }
            public string est_dsc { get; set; }
            public string razon_social { get; set; }
            public string mon_dsc { get; set; }
            public decimal importe { get; set; }
            public string idestado { get; set; }
        }

        public class NisiraListadoResponse
        {
            public List<NisiraLiquidacionListado> data { get; set; }
            public bool error { get; set; }
        }

        // ================================================================
        // 🔹 6. Lista de sucursales (GET /api/lista/sucursales)
        // ================================================================
        public class NisiraSucursal
        {
            public string idempresa { get; set; }
            public string idsucursal { get; set; }
            public string direccion { get; set; }
            public string descripcion { get; set; }
            public int estado { get; set; }
        }

        public class NisiraSucursalResponse
        {
            public List<NisiraSucursal> data { get; set; }
            public bool error { get; set; }
        }

        // ================================================================
        // 🔹 15. Registro de orden liquidación de gasto
        //     (POST /api/liquidacion-gasto/save)
        // ================================================================
        public class NisiraLiquidacionDetalle
        {
            public string item { get; set; }
            public string glosa { get; set; }
            public string idclieprov { get; set; }
            public string idtipomov { get; set; }
            public string iddocumento { get; set; }
            public string serie { get; set; }
            public string numero { get; set; }
            /// <summary>Fecha del comprobante. Formato yyyyMMdd.</summary>
            public string Fecha_D { get; set; }
            public string idcuenta { get; set; }
            public string idccosto { get; set; }
            public string iddestino { get; set; }
            public string idmoneda { get; set; }
            public string idregimen { get; set; }
            public decimal afecto { get; set; }
            public decimal inafecto { get; set; }
            public decimal pimpuesto { get; set; }
            public decimal impuesto { get; set; }
            public decimal importe { get; set; }
        }

        public class NisiraLiquidacionRequest
        {
            /// <summary>Vacío al registrar un documento nuevo.</summary>
            public string idcobrarpagardoc { get; set; } = "";
            public string idsucursal { get; set; }
            public string idtipomov { get; set; }
            public string iddocumento { get; set; }
            public string serie { get; set; }
            /// <summary>Fecha de la liquidación. Formato yyyyMMdd.</summary>
            public string Fecha { get; set; }
            public string idclieprov { get; set; }
            public string idmoneda { get; set; }
            public string idarea { get; set; } = "";
            public string idmediopago { get; set; } = "";
            public string idunidadnegocio { get; set; } = "";
            public string glosa { get; set; }
            public List<NisiraLiquidacionDetalle> detalle { get; set; } = new List<NisiraLiquidacionDetalle>();
        }

        /// <summary>Respuesta cuando el documento se registra correctamente (200 OK).</summary>
        public class NisiraSaveResponse
        {
            public string id { get; set; }
            public bool error { get; set; }
            public string message { get; set; }
            /// <summary>Solo aparece al actualizar un documento existente.</summary>
            public string codigo { get; set; }
        }

        /// <summary>Un ítem de error de validación (400 BAD_REQUEST).</summary>
        public class NisiraErrorItem
        {
            public string codigo { get; set; }
            public int error { get; set; }
            public string message { get; set; }
        }

        /// <summary>Respuesta de error de validación (400) o excepción (500).</summary>
        public class NisiraErrorResponse
        {
            public string codigo { get; set; }
            public List<NisiraErrorItem> data { get; set; }
            public bool error { get; set; }
            public string message { get; set; }
        }

        /// <summary>
        /// Resultado de un envío a NISIRA para un documento (una fila del resumen
        /// de envío). Se usa solo en la capa de UI, no viaja al API.
        /// </summary>
        public class NisiraEnvioResultado
        {
            public string IdRend { get; set; }
            public string Documento { get; set; }
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
        }
    }
}
