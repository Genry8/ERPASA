using System;

namespace CapaEntidad
{
    public partial class ce_datospersonal
    {
        //DATOS DEL PERSONAL PARA ALMACENAR AL BUSCAR
        public static int usecod { get; set; }
        public static int siscod { get; set; }
        public static string useapepat { get; set; }
        public static string useapemat { get; set; }
        public static string usenam { get; set; }
        public static string useusr { get; set; }
        public static string usesex { get; set; }
        public static string useestciv { get; set; }
        public static string usedom { get; set; }
        public static string useemail { get; set; }
        public static string useobs { get; set; }
        public static DateTime fec_cre { get; set; }
        public static DateTime fec_nac { get; set; }
        public static string tipo_doc { get; set; }
        public static int usedoc { get; set; }
        public static string grupro { get; set; }
        public static string grucod { get; set; }
        public static string usetel { get; set; }
        public static string usepas { get; set; }
        public static string estado { get; set; }
        public static string codarea { get; set; }
        public static string codcar { get; set; }
        public static string codcond { get; set; }
        public static string codjef { get; set; }
        public static string fordepsal { get; set; }
        public static DateTime fec_cece { get; set; }
        public static string coment { get; set; }
        public static string reglab { get; set; }
        public static string fondpen { get; set; }
        public static string codfondpen { get; set; }
        public static int hr_contr { get; set; }
        public static DateTime hr_ing { get; set; }
        public static DateTime hr_sal { get; set; }
        public static int toler { get; set; }
        public static DateTime vac_ini { get; set; }
        public static DateTime vac_fin { get; set; }

        //DATOS PARA GUARDAR ESCOLARIDAD
        public static int usecod_esc { get; set; }
        public static int siscod_esc { get; set; }
        public static string useusr_esc { get; set; }
        public static string usedesc_esc { get; set; }
        public static DateTime fec_fin_esc { get; set; }
        public static string obsesc_esc { get; set; }
        public static string entesc_esc { get; set; }
        public static string estado_esc { get; set; }
        public static int usedoc_esc { get; set; }

        //GUARDAR DATOS ALMACEN USUARIO
        public static Boolean estado_almc { get; set; }
        public static string codalm_almc { get; set; }

        //GUARDAR DATOS ALMACEN USUARIO
        public static int user_almc_busc { get; set; }
        public static int estado_almc_busc { get; set; }
        public static string codalm_almc_bubsc { get; set; }

        //DATOS OTROS PARA PERSONAL
        public static int CodUser_Max { get; set; }
        public static int CodUser { get; set; }
        public static int Busc_usedoc { get; set; }


    }
}
