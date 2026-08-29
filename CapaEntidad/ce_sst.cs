using System;

namespace CapaEntidad
{
    public class ce_sst
    {
        public static string NumIdent { get; set; }
        public static DateTime FecCap { get; set; }
        public static int Codigo { get; set; }
        public static int UltCodigo { get; set; }
        public static string Est_Cese { get; set; }
        public static string Cab_Tipo_emp { get; set; }

        //CABECERA CAPACITACIONES

        public static string CabDoc { get; set; }
        public static DateTime CabFecIn { get; set; }
        public static string CabSem { get; set; }
        public static string CabNota { get; set; }
        public static string CabEmpCont { get; set; }
        public static string CabVencLic { get; set; }
        public static string CabEmpresa { get; set; }
        public static string CabSede { get; set; }
        public static string CabArea { get; set; }
        public static string CabEntLicInd { get; set; }
        public static string CabTipLic { get; set; }
        public static string CabUnidManj { get; set; }
        public static string CabFecMult { get; set; }
        public static string CabPuntConduct { get; set; }
        public static string CabEstado { get; set; }

        //DETALLE DE CAPACITACIONES

        public static string Tar_ta { get; set; }
        public static string Sem_ta { get; set; }
        public static string Nota_ta { get; set; }
        public static string Tar_ez { get; set; }
        public static string Sem_ez { get; set; }
        public static string Nota_ez { get; set; }
        public static string Tar_tc { get; set; }
        public static string Sem_tc { get; set; }
        public static string Nota_tc { get; set; }
        public static string Tar_ec { get; set; }
        public static string Sem_ec { get; set; }
        public static string Nota_ec { get; set; }
        //
        public static string Esp_map { get; set; }
        public static string Sem_map { get; set; }
        public static string Nota_map { get; set; }
        public static string Esp_rcs { get; set; }
        public static string Sem_rcs { get; set; }
        public static string Nota_rcs { get; set; }
        public static string Esp_hmp { get; set; }
        public static string Sem_hmp { get; set; }
        public static string Nota_hmp { get; set; }
        public static string Esp_vpp { get; set; }
        public static string Sem_vpp { get; set; }
        public static string Nota_vpp { get; set; }
        public static string Esp_ats { get; set; }
        public static string Sem_ast { get; set; }
        public static string Nota_ats { get; set; }

        //
        public static string Bas_iperc { get; set; }
        public static string Sem_iperc { get; set; }
        public static string Nota_iperc { get; set; }
        public static string Bas_scc { get; set; }
        public static string Sem_scc { get; set; }
        public static string Nota_scc { get; set; }
        public static string Bas_epp { get; set; }
        public static string Sem_epp { get; set; }
        public static string Nota_epp { get; set; }
        public static string Bas_aci { get; set; }
        public static string Sem_aci { get; set; }
        public static string Nota_aci { get; set; }

        //
        public static string Ext_er { get; set; }
        public static string Sem_er { get; set; }
        public static string Nota_er { get; set; }
        public static string Ext_ppi { get; set; }
        public static string Sem_ppi { get; set; }
        public static string Nota_ppi { get; set; }
        public static string Ext_eepp { get; set; }
        public static string Sem_eepp { get; set; }
        public static string Nota_eepp { get; set; }
        public static string Ext_rsa { get; set; }
        public static string Sem_rsa { get; set; }
        public static string Nota_rsa { get; set; }

        //
        public static string Otr_maptel { get; set; }
        public static string Sem_maptel { get; set; }
        public static string Nota_maptel { get; set; }
        public static string Otr_tea { get; set; }
        public static string Sem_tea { get; set; }
        public static string Nota_tea { get; set; }
        public static string Otr_risst { get; set; }
        public static string Sem_risst { get; set; }
        public static string Nota_risst { get; set; }

    }

    public class ce_sst_charla
    {
        public string id { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string area { get; set; }
        public string tipoevaluacion { get; set; }
        public int nrotrabajador { get; set; }
        public int nroejecutado { get; set; }
        public DateTime fecha { get; set; }
        public string semana { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_sst_actocondicion
    {
        public string id { get; set; }
        public int semana { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string area { get; set; }
        public string incidencia { get; set; }
        public string hallazgo { get; set; }
        public string peligro { get; set; }
        public string jerarquia { get; set; }
        public string hallazgo_desviacion { get; set; }
        public string medida_correctiva { get; set; }
        public string responsable { get; set; }
        public DateTime fecrep { get; set; }
        public string estado_insp { get; set; }
        public string medida_correctiva_2 { get; set; }
        public string evidencia { get; set; }
        public DateTime? feclevant { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_sst_inspeccion
    {
        public int id { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string area { get; set; }
        public string tipoevaluacion { get; set; }
        public float nroprogramados { get; set; }
        public float nroejecutados { get; set; }
        public DateTime? fecha { get; set; }
        public float semana { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_sst_capacitacion
    {
        public string codigo { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string apenom { get; set; }
        public string dni { get; set; }
        public string area { get; set; }
        public string ruc { get; set; }
        public string cargo { get; set; }
        public string sedecapacitacion { get; set; }
        public DateTime? fechainduccion { get; set; }
        public DateTime? trabajoaltura { get; set; }
        public float notatraalt { get; set; }
        public DateTime? excavacionzanja { get; set; }
        public float notaexcavzanja { get; set; }
        public DateTime? trabajocaliente { get; set; }
        public float notatrabcal { get; set; }
        public DateTime? espacioconfinado { get; set; }
        public float notaespconf { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_sst_ritran
    {
        public string codigo { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string apenom { get; set; }
        public string dni { get; set; }
        public string area { get; set; }
        public string ruc { get; set; }
        public string cargo { get; set; }
        public DateTime? fechavencmtc { get; set; }
        public DateTime? fechacapacitacion { get; set; }
        public DateTime? fechavencritran { get; set; }
        public float notaexamen { get; set; }
        public DateTime? fechaentrega { get; set; }
        public string unidadmanejar { get; set; }
        public DateTime? fechamulta { get; set; }
        public float puntosancionado { get; set; }
        public string obs { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_sst_cursos
    {
        public int Id { get; set; }

        public string Curso { get; set; }

        public string Descripcion { get; set; }

        public string Obs { get; set; }

        public bool? Sel { get; set; }

        public string Estado { get; set; }

        public string Tema { get; set; }

        public string Contenido { get; set; }

        public string TemaIA { get; set; }

        public string ContenidoIA { get; set; }
    }

    public class ce_sst_CursoExamenCab
    {
        public int Id { get; set; }

        public string ApeNom { get; set; }

        public string Dni { get; set; }

        public string Empresa { get; set; }

        public string Area { get; set; }

        public string Cargo { get; set; }

        public DateTime FechaCapacitacion { get; set; }

        public string Curso { get; set; }

        public decimal NotaCurso { get; set; }

        public string Hoja { get; set; }
    }

    public class ce_sst_CursoExamenDet
    {
        public int Item { get; set; }

        public string Pregunta { get; set; }

        public string Alternativa { get; set; }

        public bool Marcada { get; set; }
    }


}
