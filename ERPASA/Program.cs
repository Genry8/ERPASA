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
            //Application.Run(new Frm_Taller.frm_BuscarVehiculo());
            Application.Run(new Frm_Login());
        }
    }
}
