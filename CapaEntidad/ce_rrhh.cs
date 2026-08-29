using System;

namespace CapaEntidad
{
    public class ce_rrhh
    {
        public static int NumIdent { get; set; }
        public static DateTime FecVist { get; set; }
        public static string NomApe { get; set; }
        public static string CodigoV { get; set; }

    }

    public class StickerData
    {
        public string Dni { get; set; }
        public string Correlativo { get; set; }
        public string DataMatrix { get; set; }
        public string Codigo { get; set; }
        public string Numero { get; set; }
        public string ApeNom { get; set; }
        public string Presentacion { get; set; }
    }

    public class PresentacionModel
    {
        public bool Selec { get; set; }
        public int Id { get; set; }
        public string Cod { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
    }



}
