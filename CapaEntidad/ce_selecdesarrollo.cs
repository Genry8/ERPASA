using System;

namespace CapaEntidad
{
    public class ce_selecdesarrollo
    {
        public static DateTime FechaInicio { get; set; }
        public static string codigo { get; set; }
    }

    public class ce_coberturaprog
    {
        public DateTime? fecha { get; set; }
        public string turno { get; set; }
        public string jefatura { get; set; }
        public string fundo { get; set; }
        public string cultivo { get; set; }
        public string area { get; set; }
        public string recurso { get; set; }
        public string tipo_recurso { get; set; }
        public string labor_sistema { get; set; }
        public string cant_prog { get; set; }
        public string observaciones { get; set; }
        public string total_prog { get; set; }
        public string area_extech { get; set; }
        public string area_ { get; set; }
        public int año { get; set; }
        public string semana { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_productividad
    {
        public string empresa { get; set; }
        public string sede { get; set; }
        public DateTime? fecha { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string cabezal { get; set; }
        public string variedad { get; set; }
        public string presentacion { get; set; }
        public string grupo_labor { get; set; }
        public string labor { get; set; }
        public decimal avance { get; set; }
        public decimal meta { get; set; }
        public string tipoprod { get; set; }
        public string obs { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
        public int useelim { get; set; }
    }

    public class ce_eficiencia
    {
        public string id { get; set; }
        public int semana { get; set; }
        public string posicion { get; set; }
        public string area { get; set; }
        public string nivel { get; set; }
        public string estadoproceso { get; set; }
        public string año { get; set; }
        public DateTime? fechareq { get; set; }
        public string tiporeq { get; set; }
        public string sede { get; set; }
        public string tiempoproceso { get; set; }
        public string tipopersonal { get; set; }
        public DateTime? fechaterna { get; set; }
        public DateTime? fecharpta { get; set; }
        public int dias { get; set; }
        public DateTime? fecharesp { get; set; }
        public DateTime? fechacierreproc { get; set; }
        public DateTime? fechaing { get; set; }
        public int diasduracion { get; set; }
        public int vencimiento { get; set; }
        public string tipoefectivo { get; set; }
        public string obs { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_kilos_proyectado
    {
        public string empresa { get; set; }
        public string sucursal { get; set; }
        public DateTime? Fecha { get; set; }
        public string cultivo { get; set; }
        public string etapa { get; set; }
        public decimal? KilosCosecha { get; set; }
        public decimal? KilosExpo { get; set; }
        public string mes { get; set; }
        public int? Año { get; set; }
        public string hoja { get; set; }
        public DateTime FecCre { get; set; }
        public int UseReg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }
}
