using System;

namespace CapaEntidad
{
    public class ce_prodkilosproy
    {
        public int campaña { get; set; }
        public string mes { get; set; }
        public int sem { get; set; }
        public DateTime? fecha { get; set; }
        public string variedad { get; set; }
        public decimal kg_prog { get; set; }
        public string sede { get; set; }
        public string empresa { get; set; }
        public string obs { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
        public int useelim { get; set; }

    }

    public class ce_proghectarea
    {
        public string mes { get; set; }
        public int sem { get; set; }
        public DateTime? fecha { get; set; }
        public string cabezal { get; set; }
        public string variedad { get; set; }
        public decimal ha_prog { get; set; }
        public decimal ha_ejec { get; set; }
        public string sede { get; set; }
        public int campaña { get; set; }
        public decimal kg_prog { get; set; }
        public string empresa { get; set; }
        public string obs { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
        public int useelim { get; set; }

    }

}
