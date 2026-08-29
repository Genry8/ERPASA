using System.Runtime.InteropServices;

namespace CapaUtilidad
{

    class MinMaxClose
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);


        //BOTONES PARA MAXIMINIZAR, MINIMIZAR Y CERRAR
        //private void button_min_max_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Maximized;
        //    }
        //    else if (WindowState == FormWindowState.Maximized)
        //    {
        //        StartPosition = FormStartPosition.CenterScreen;
        //        WindowState = FormWindowState.Normal;
        //    }

        //}

        //private void button_minimizar_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Minimized;
        //    }
        //    else if (WindowState == FormWindowState.Maximized)
        //    {
        //        WindowState = FormWindowState.Minimized;
        //    }
        //}

        //private void panel_superior_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (WindowState != FormWindowState.Maximized)
        //    {
        //        ReleaseCapture();
        //        SendMessage(this.Handle, 0x112, 0xf012, 0);

        //    }
        //    else
        //        WindowState = FormWindowState.Maximized;

        //}

        //private void panel_titulo2_DoubleClick(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Maximized)
        //    {
        //        WindowState = FormWindowState.Normal;
        //    }
        //    else if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Maximized;
        //    }
        //}

    }
}
