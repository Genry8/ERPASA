using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPASA.Frm_DestajoUva
{
    public class DestajoStickerModel
    {
        public string Id { get; set; }
        public string CodImpresion { get; set; }
        public string DNI { get; set; }
        public string Nave { get; set; }
        public string Linea { get; set; }
        public string CodQr { get; set; }
        public string Fecha { get; set; }
        public string PuestoTrabajo { get; set; }
        public byte[] RutaMatrix { get; set; }
    }

    public class RegistroQR
    {
        public string TramaReal { get; set; }
        public int CodPre { get; set; }
        public string Detalle { get; set; }
        public int CodSticker { get; set; }

        // 🔹 NUEVO
        public DateTime FechaProceso { get; set; }
    }


}
