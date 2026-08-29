using System;

namespace CapaEntidad
{
    public class ce_taller
    {
        public static DateTime FechaInicio { get; set; }
        public static string codigo { get; set; }
        public static string empresa { get; set; }
        public static string sede { get; set; }
        public static string area { get; set; }
        public static string placa { get; set; }
        public static string DescripcionVehiculo { get; set; }
        public static string marca { get; set; }
        public static string modelo { get; set; }
        public static string responsable { get; set; }
        public static string grupovehiculo { get; set; }
        public static string idVeh { get; set; }

        /// <summary>
        /// MANTENIMIENTO PREVENTIVO
        /// </summary>
        public static DateTime Fecha { get; set; }
        public static string kmIni { get; set; }
        public static string kmFin { get; set; }
        public static string kmDif { get; set; }
        public static string implemento { get; set; }
        public static string area_cabezal { get; set; }

        /// <summary>
        /// MANTENIMIENTO CORRECTIVO
        /// </summary>
        public static DateTime FecIng { get; set; }
        public static DateTime FecSal { get; set; }
        public static string diasInop { get; set; }
        public static string hrsInop { get; set; }
        public static string status { get; set; }
        public static string sistema { get; set; }
        public static string sustento { get; set; }
        public static string tipocorrectivo { get; set; }
        public static string tipofalla { get; set; }
        public static string costo { get; set; }
        public static string detalleObs { get; set; }
        public static string km { get; set; }

        /// <summary>
        /// EFICIENCIA MAQUINARIA
        /// </summary>        
        public static string turno { get; set; }
        public static string operador { get; set; }
        public static string cabezal { get; set; }
        public static string labor { get; set; }
        public static string tipolabor { get; set; }
        public static string objtancada { get; set; }
        public static string hectarea { get; set; }
        public static string galones { get; set; }
        public static string kmini { get; set; }
        public static string kmfin { get; set; }
        public static string kmini_efe { get; set; }
        public static string kmfin_efe { get; set; }
        public static string horaini { get; set; }
        public static string horafin { get; set; }
        public static string obj_aplicacion { get; set; }
        public static string observacion { get; set; }
        public static string indicador { get; set; }
        public static string descripcion { get; set; }


    }
}
