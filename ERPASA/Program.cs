using System;
using System.Windows.Forms;

namespace ERPASA
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Frm_TabMaestra.Frm_RolesUserAppMovil());
            //Application.Run(new Frm_Contabilidad.Frm_RindeGastoNisiraAPI());
            //Application.Run(new Reportes.Acopio.Frm_Reporte_RecepcionAcopio());
            Application.Run(new Frm_Login());
        }

    }

}
