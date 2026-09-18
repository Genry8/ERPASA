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
            //Application.Run(new Frm_Comunicacion.Frm_CargarSaldoPuntos());
            Application.Run(new Frm_Login());
        }

    }

}
