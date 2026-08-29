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
            //Application.Run(new Reportes.Acopio.Frm_ReporteGuiaRecepcion());
            //Application.Run(new Frm_Logistica.Frm_ProgramarCursoProveedor());
            //Application.Run(new Frm_Logistica.Frm_ProgramarCursos());
            //Application.Run(new Reportes.AcopioRRHH.Frm_CargarReqPersonalSemanal());
            //Application.Run(new Reportes.AcopioRRHH.Frm_CargarReqPersonalAnual());
            //Application.Run(new Frm_TabMaestra.Frm_RegistroPersonal());
            Application.Run(new Frm_Login());
        }

    }

}
