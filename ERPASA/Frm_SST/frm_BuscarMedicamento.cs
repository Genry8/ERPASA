using CapaDatos;
using CapaNegocio;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_SST
{

    public partial class frm_BuscarMedicamento : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 2;
        //private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        //Overridden methods

        public frm_BuscarMedicamento()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;            
        }

        private void frm_BuscarMedicamento_Load(object sender, EventArgs e)
        {
            comboBox_Tipos.SelectedIndex = 0;
            comboBox_Tipos.DropDownStyle = ComboBoxStyle.DropDownList;
            textbox_DescMedicamento.Focus();

            textbox_DescMedicamento.CharacterCasing = CharacterCasing.Upper;
            dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI("%",
            //        "%", "%", "%", "%", "%", "%");
            //dataGridView2.AllowUserToAddRows = false;
            //OrigenColorfila();
            //dataGridView2.ClearSelection();

            this.Padding = new Padding(borderSize);//Border size
            //this.BackColor = Color.FromArgb(98, 102, 244);//Border color
            //
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            //const int WM_SYSCOMMAND = 0x0112;
            //const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            //const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            //#region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            //#endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            //if (m.Msg == WM_SYSCOMMAND)
            //{
            //    //MAND messages, the four low - order bits of the wParam parameter 
            //    /// are used internally by the system.To obtain the correct result when testing 
            //    /// the value of wParam, an application must combine the value 0xFFF0 with the 
            //    /// wParam value by using the bitwise AND operator.
            //    int wParam = (m.WParam.ToInt32() & 0xFFF0);

            //    if (wParam == SC_MINIMIZE)  //Before
            //        formSize = this.ClientSize;
            //    if (wParam == SC_RESTORE)// Restored form(Before)
            //        this.Size = formSize;
            //}
            base.WndProc(ref m);
        }


        private void panel_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);

            }
            else
                WindowState = FormWindowState.Maximized;
        }

        private void Frm_agregar_Resize(object sender, EventArgs e)
        {
            //AdjustForm();
        }

        private void panel_titulo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textbox_factura_KeyUp(object sender, KeyEventArgs e)
        {
            //dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_datosventa.BuscarProducto(textbox_Perifericodesc.Text, ce_datosventa.Select_almacen);
            //dataGridView2.ClearSelection();
            //OrigenColorfila();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int minstk = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());

            if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == "EN USO")
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("ACTIVO EN USO, VERIFICAR", Color.Red, 3);
                ng.ShowDialog();
                //break;
            }

            //else if (dataGridView2.CurrentRow.Cells[8].Value.ToString() == "0")
            //{
            //    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PRODUCTO SIN STOCK", Color.DarkRed, 3);
            //    ng.ShowDialog();
            //    //break;
            //}

            else
            {

                /////////
                VarDatosEntroFormMed var1 = Owner as VarDatosEntroFormMed;
                DataGridViewRow fila = dataGridView2.SelectedRows[0] as DataGridViewRow;
                var1.TablaAgregarDatosFilaAsig(fila);
                this.Close();

            }
        }
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Modo")
            {
                if (Convert.ToString(e.Value) == "EN USO")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 11.0f);
                    e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
                if (Convert.ToString(e.Value) == "LIBRE")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.MediumSeaGreen;
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
            }

            //if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Stock")
            //{
            //    if (Convert.ToInt32(e.Value) <= 0)
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 11.0f);
            //        e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }

            //    else if (Convert.ToInt32(e.Value) <= 5)
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 10.0f);
            //        e.CellStyle.ForeColor = Color.FromArgb(255, 128, 0);
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }

            //    else
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 10.0f);
            //        e.CellStyle.ForeColor = Color.MediumSeaGreen;
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }

            //}
        }

        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Red; //DarkRed FromArgb(252, 70, 0)
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Verdana", 9.0f);
                    //dataGridView2.Rows[i].DefaultCellStyle.Font = new Color.FromArgb(192, 12, 0);
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void textbox_productodesc_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            OrigenColorfila();
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void textbox_Perifericodesc_TextChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox_titulo_Click(object sender, EventArgs e)
        {

        }

        private void textbox_ActivoDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (comboBox_Tipos.Text == "DESCRIPCION")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_sst.ListaMedicamentoTopico("%", textbox_DescMedicamento.Text);
                    dataGridView2.AllowUserToAddRows = false;
                    //OrigenColorfila();
                    dataGridView2.ClearSelection();
                }

            }
        }
    }
}
