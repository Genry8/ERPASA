using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class ce_liquidaciones
    {
        // Identificador
        public int? idliq { get; set; }  // Nullable para inserciones por TVP

        // Datos de embarque
        public string ShipmentCode { get; set; }

        // Datos del bloque
        public string growerblockid { get; set; }
        public string blockname { get; set; }

        // Información de transacción
        public decimal? trxtype { get; set; }
        public decimal? chargeorderby { get; set; }
        public string chargeid { get; set; }
        public string chargedescr { get; set; }
        public decimal? chargeratetype { get; set; }
        public decimal? invcqnt { get; set; }

        // Montos
        public decimal? saleamt { get; set; }
        public decimal? chgqnt { get; set; }
        public decimal? chgamt { get; set; }

        // Descripción del producto
        public string gwrproductdescr { get; set; }
        public string cmtyinvc { get; set; }
        public string vrtyinvc { get; set; }

        // Clasificación
        public decimal? styleorderby { get; set; }
        public string gradeinvc { get; set; }
        public decimal? gradeorderby { get; set; }
        public decimal? sizeorderby { get; set; }

        // Unidad y factores de cargo
        public string uom { get; set; }
        public string fcchargeidx { get; set; }
        public decimal? invcicqnt { get; set; }

        // Información de compañía
        public string astitle { get; set; }
        public string ascompanyname { get; set; }

        // Fechas de reporte
        public DateTime? reportdate { get; set; }
        public DateTime? date11 { get; set; }
        public DateTime? date12 { get; set; }

        // Datos del agricultor / productor
        public string growerid { get; set; }
        public string growername { get; set; }
        public DateTime? fecha { get; set; }

        // Datos del archivo origen
        public string Hoja { get; set; }
        public string NombreExcel { get; set; }
        public string Ruta { get; set; }

        // Estado y trazabilidad
        public string Estado { get; set; }
        public DateTime FecCre { get; set; }
        public int UseReg { get; set; }
        public string Hostname { get; set; }
        public DateTime? FecEdit { get; set; }
        public int? UseEdit { get; set; }
        public int? UseElim { get; set; }
    }

    public class OCRResponse
    {
        public List<ParsedResult> ParsedResults { get; set; }
        public bool IsErroredOnProcessing { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ParsedResult
    {
        public string ParsedText { get; set; }
    }

    public class VentaPdf
    {
        // =========================
        // IDENTIFICACIÓN
        // =========================
        public int Numero { get; set; }
        public string Documento { get; set; }
        public string Contenedor { get; set; }

        // =========================
        // CLIENTE / LOGÍSTICA
        // =========================
        public string Cliente { get; set; }
        public string Destino { get; set; }
        public string Naviera { get; set; }
        public string Nave { get; set; }

        public DateTime? FechaEmbarque { get; set; }
        public DateTime? FechaArribo { get; set; }

        public decimal TotalKg { get; set; }
        public string Variedad { get; set; }
        public string var_desc { get; set; }

        // =========================
        // VENTAS (INPUTS OCR)
        // =========================
        public int Cajas { get; set; }
        public decimal Sales { get; set; }
        public decimal PricePerBox { get; set; }

        // =========================
        // COMISIONES (INPUTS OCR)
        // =========================
        public decimal Commission { get; set; }

        // =========================
        // COSTOS OPERATIVOS (INPUTS OCR)
        // =========================
        public decimal ChepPallet { get; set; }
        public decimal ColdStorage { get; set; }
        public decimal CustomsClearing { get; set; }
        public decimal ImportTariff { get; set; }
        public decimal InlandFreight { get; set; }
        public decimal Inspections { get; set; }
        public decimal OceanFreight { get; set; }
        public decimal OperationsHandling { get; set; }
        public decimal Repacking { get; set; }

        // =========================
        // KPIs / DERIVADOS (SOLO GET)
        // =========================

        public decimal CommissionPct =>
            Sales > 0 ? Commission / Sales : 0;

        public decimal TotalExpenses =>
            ChepPallet +
            ColdStorage +
            Commission +
            CustomsClearing +
            ImportTariff +
            InlandFreight +
            Inspections +
            OceanFreight +
            OperationsHandling +
            Repacking;

        public decimal CostPerBox =>
            Cajas > 0 ? Math.Round(TotalExpenses / Cajas, 2) : 0;

        public decimal FOB =>
            Sales - TotalExpenses;

        public decimal FOBxKg =>
            TotalKg > 0 ? FOB / TotalKg : 0;

        // =========================
        // FLAGS
        // =========================
        public decimal PctPeso { get; set; } = 1m;
        public decimal PctVenta { get; set; } = 1m;
    }

    public class VentaPdf_SP
    {
        // =========================
        // IDENTIFICACIÓN
        // =========================
        public int Numero { get; set; }
        public string Documento { get; set; }
        public string Contenedor { get; set; }

        // =========================
        // DATOS GENERALES
        // =========================
        public decimal TotalKg { get; set; }

        public string Variedad { get; set; }
        public string VarDesc { get; set; }

        // =========================
        // VENTA
        // =========================
        public int Cajas { get; set; }

        public decimal Sales { get; set; }

        public decimal PricePerBox =>
            Cajas > 0 ? Math.Round(Sales / Cajas, 2) : 0;

        // =========================
        // PORCENTAJES
        // =========================
        public decimal PctPeso { get; set; } = 1m;
        public decimal PctVenta { get; set; } = 1m;
        public decimal CommissionPct { get; set; }

        // =========================
        // COSTOS
        // =========================

        public decimal Commission { get; set; }

        public decimal CustomBroker { get; set; }

        public decimal ExpeditorFees { get; set; }

        public decimal InlandFreight { get; set; }

        public decimal PortFees { get; set; }

        public decimal Inspection { get; set; }

        public decimal ExamFee { get; set; }

        public decimal MaterialBoxes { get; set; }

        public decimal MaterialFilm { get; set; }

        public decimal MaterialShipping { get; set; }

        public decimal MaterialPallets { get; set; }

        public decimal OceanFreight { get; set; }

        public decimal PackingFees { get; set; }

        public decimal StorageFee { get; set; }

        public decimal CutiesMarketingAccrual { get; set; }

        public decimal Tariff { get; set; }

        public decimal HarborMaintenanceFee { get; set; }

        // =========================
        // TOTALES
        // =========================

        public decimal TotalExpenses =>
            Commission +
            CustomBroker +
            ExpeditorFees +
            InlandFreight +
            PortFees +
            Inspection +
            ExamFee +
            MaterialBoxes +
            MaterialFilm +
            MaterialShipping +
            MaterialPallets +
            OceanFreight +
            PackingFees +
            StorageFee +
            CutiesMarketingAccrual +
            Tariff +
            HarborMaintenanceFee;

        public decimal FOB =>
            Sales - TotalExpenses;

        public decimal FOBxKg =>
            TotalKg > 0
                ? Math.Round(FOB / TotalKg, 2)
                : 0;
    }

    public class VentaPdf_LGS
    {
        // =========================
        // IDENTIFICACIÓN
        // =========================
        public string Contenedor { get; set; }
        public string Documento { get; set; }

        // =========================
        // PRODUCTO
        // =========================
        public string Variedad { get; set; }
        public string Var_Desc { get; set; }

        // =========================
        // VENTAS
        // =========================
        public int Cajas { get; set; }
        public decimal TotalKg { get; set; }   // 🔴 FALTABA
        public decimal Sales { get; set; }
        public decimal SalesPerBox { get; set; }

        // =========================
        // PORCENTAJES
        // =========================
        public decimal PctPeso { get; set; }    // 🔴 FALTABA
        public decimal PctVenta { get; set; }   // 🔴 FALTABA
        public decimal Pct { get; set; }       // 🔴 FALTABA

        // =========================
        // COSTOS
        // =========================
        public decimal Commission { get; set; }
        public decimal ContainerFreight { get; set; }
        public decimal CustomsClearance { get; set; }
        public decimal Duty { get; set; }
        public decimal Expeditor { get; set; }
        public decimal Inspections { get; set; }
        public decimal LoadingStorage { get; set; }
        public decimal OceanFreight { get; set; }
        public decimal Repacking { get; set; }

        // =========================
        // DERIVADOS
        // =========================
        public decimal TotalExpenses =>
            Commission +
            ContainerFreight +
            CustomsClearance +
            Duty +
            Expeditor +
            Inspections +
            LoadingStorage +
            OceanFreight +
            Repacking;

        public decimal FOB =>
            Sales - TotalExpenses;

        public decimal FOBxKg =>
            TotalKg > 0 ? FOB / TotalKg : 0;   // 🔴 antes usabas Cajas (ERROR conceptual)
    }

}
