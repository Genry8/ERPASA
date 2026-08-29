using System;

namespace CapaEntidad
{
    public class sig_documentos
    {
        public int id { get; set; }
        public int año { get; set; }
        public int semana { get; set; }
        public string codigo { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public float revision { get; set; }
        public string titulo { get; set; }
        public string solicitante { get; set; }
        public DateTime? fechasolicitud { get; set; }
        public string tipodocumento { get; set; }
        public string gerencia { get; set; }
        public string area { get; set; }
        public string tipoactividad { get; set; }
        public string responsableflujo { get; set; }
        public string etapaflujo { get; set; }
        public DateTime? fecharegistro { get; set; }
        public string condicion { get; set; }
        public string detalle { get; set; }
        public DateTime? fechapublicacion { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }

    }

}
