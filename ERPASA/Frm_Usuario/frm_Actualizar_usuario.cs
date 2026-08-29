using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_Usuario
{

    public partial class frm_Actualizar_usuario : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 2;
        //private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        //Overridden methods

        public frm_Actualizar_usuario()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;            
        }

        private void frm_Actualizar_usuario_Load(object sender, EventArgs e)
        {
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;
            pictureBox_fotoperfil.Image = pictureBox_titulo.Image;

            //cn_logistica.ListaPersonalTI();


            //DatagridFormato();

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

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
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

        private void button_minimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void button_min_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ColumnasDtgv()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "Dni";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView2.Columns.Add(Dni);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Apellidos = new DataGridViewTextBoxColumn();
            Apellidos.HeaderText = "Apellidos";
            Apellidos.Name = "Column2";
            Apellidos.Width = 87;
            dataGridView2.Columns.Add(Apellidos);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "Nombres";
            Nombres.Name = "Column2";
            Nombres.Width = 87;
            dataGridView2.Columns.Add(Nombres);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Sexo = new DataGridViewTextBoxColumn();
            Sexo.HeaderText = "Sexo";
            Sexo.Name = "Column2";
            Sexo.Width = 87;
            dataGridView2.Columns.Add(Sexo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Column2";
            Empresa.Width = 87;
            dataGridView2.Columns.Add(Empresa);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Sede = new DataGridViewTextBoxColumn();
            Sede.HeaderText = "Sede";
            Sede.Name = "Column2";
            Sede.Width = 87;
            dataGridView2.Columns.Add(Sede);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Area = new DataGridViewTextBoxColumn();
            Area.HeaderText = "Area";
            Area.Name = "Column2";
            Area.Width = 87;
            dataGridView2.Columns.Add(Area);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn FecNac = new DataGridViewTextBoxColumn();
            FecNac.HeaderText = "Fecha Nacimiento";
            FecNac.Name = "Column2";
            FecNac.Width = 87;
            dataGridView2.Columns.Add(FecNac);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Email = new DataGridViewTextBoxColumn();
            Email.HeaderText = "Email";
            Email.Name = "Column2";
            Email.Width = 87;
            dataGridView2.Columns.Add(Email);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Comentario = new DataGridViewTextBoxColumn();
            Comentario.HeaderText = "Comentario";
            Comentario.Name = "Column3";
            Comentario.Width = 56;
            dataGridView2.Columns.Add(Comentario);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
            Estado.HeaderText = "Estado";
            Estado.Name = "Column4";
            Estado.Width = 73;
            dataGridView2.Columns.Add(Estado);

            // 
            // Column14
            //             
            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            //combo.HeaderText = "Opcion";
            //combo.Name = "Column14";
            //combo.Width = 88;
            ////LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            //ArrayList row = new ArrayList();

            ////declara una tabla donde se llama la lista de los estados
            //DataTable dt = new DataTable();
            //dt = cn_datosventa.ListEstadFac();

            //foreach (DataRow item in dt.Rows)
            //{
            //    row.Add(item[0].ToString());
            //}

            ////AÑADIR LA LISTA AL COMBO
            //combo.Items.AddRange(row.ToArray());
            ////AÑADIR EL COMBO AL DATAGRIDVIEW
            //dataGridView2.Columns.Add(combo);

            // 
            // Column15 AGREGAR NUEVA
            // 
            //
        }

        //GUARDAR NUEVO USUARIO
        private void GuardarUsuario()
        {

        }

        public void buscar()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_nisira.ListaPersonalNisira();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
        }

        public void guardar()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox_fotoperfil.Image.Size.Width.Equals(200);
            pictureBox_fotoperfil.Image.Size.Width.Equals(200);
            pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            dataGridView2.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                cn_nisira.ListaPersonalUpdate();
                int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    cn_nisira.BuscExisteCodUsuario(dataGridView2[0, i].Value.ToString());

                    if (dataGridView2[0, i].Value.ToString() == ce_nisira.CodUsuarioExiste)
                    {
                        objcnlog.ActualizarPersonal(
                            dataGridView2[0, i].Value.ToString(),//DNI
                                                                 //dataGridView2[1, i].Value.ToString(),//APELLIDOS
                                                                 //dataGridView2[2, i].Value.ToString(),//NOMBRES
                                                                 //dataGridView2[3, i].Value.ToString(),//SEXO
                                                                 //dataGridView2[4, i].Value.ToString(),//EMPRESA
                                                                 //dataGridView2[5, i].Value.ToString(),//SEDE
                                                                 //dataGridView2[6, i].Value.ToString(),//AREA
                                                                 //Convert.ToDateTime(dataGridView2[7, i].Value),//FECHA NACIMIENTO
                            dataGridView2[8, i].Value.ToString(),//EMAIL
                            dataGridView2[9, i].Value.ToString(),//CARGO
                                                                 //ms.GetBuffer(),
                            dataGridView2[10, i].Value.ToString(),//ESTADO
                                                                  //ce_usuario.FechaSistema(),
                                                                  //ce_usuario.usecod,
                                                                  //ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                        );

                    }

                    else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {

                        objcnlog.GuardPersonalTI(
                            dataGridView2[0, i].Value.ToString(),//DNI
                            dataGridView2[1, i].Value.ToString(),//APELLIDOS
                            dataGridView2[2, i].Value.ToString(),//NOMBRES
                            dataGridView2[3, i].Value.ToString(),//SEXO
                            dataGridView2[4, i].Value.ToString(),//EMPRESA
                            dataGridView2[5, i].Value.ToString(),//SEDE
                            dataGridView2[6, i].Value.ToString(),//AREA
                            Convert.ToDateTime(dataGridView2[7, i].Value),//FECHA NACIMIENTO
                            dataGridView2[8, i].Value.ToString(),//EMAIL
                            dataGridView2[9, i].Value.ToString(),//CARGO
                            ms.GetBuffer(),
                            dataGridView2[10, i].Value.ToString(),//ESTADO
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );
                    }

                    objcnsst.CeseCapacitacionesCabeceraSST(dataGridView2[0, i].Value.ToString());

                }

                //cn_sst.BuscExisteUserCapacitacionSST(dataGridView2[0, i].Value.ToString());

                MessageBox.Show("DATOS GUARDADO CORRECTAMENTE");
                //Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                //ng.ShowDialog();

            }

            dataGridView2.AllowUserToAddRows = true;


        }


        public void guardarFotosMenorTamañ()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox_fotoperfil.Image.Size.Width.Equals(200);
            pictureBox_fotoperfil.Image.Size.Width.Equals(200);
            pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            dataGridView2.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                cn_nisira.ListaPersonalUpdate();
                int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;

                objcnlog.ActualizarPersonalFoto(
                                 ms.GetBuffer()
                    );

                //cn_sst.BuscExisteUserCapacitacionSST(dataGridView2[0, i].Value.ToString());

                //objcnsst.CeseCapacitacionesCabeceraSST();

                MessageBox.Show("DATOS GUARDADO CORRECTAMENTE");
                //Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                //ng.ShowDialog();

            }

            dataGridView2.AllowUserToAddRows = true;


        }


        //GUARDAR MODIFICADO
        private void ActualizarUsuarioDni()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);


        }

        public void nuevo()
        {
            dataGridView2.DataSource = null;
        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            toolStripButton_buscar.Enabled = false;
            toolStripLabel_buscar.Enabled = false;
            toolStripButton_editar.Enabled = false;
            toolStripLabel_editar.Enabled = false;


            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_nisira.ListaPersonalNisira();

            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

            //ColumnasDtgv();

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            toolStripButton_guardar.Enabled = true;
            toolStripButton_editar.Enabled = true;

            buscar();
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            //guardarFotosMenorTamaño();
            guardar();

        }

        private void toolStripButton_aliminar_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            nuevo();

            toolStripButton_buscar.Enabled = true;
            toolStripLabel_buscar.Enabled = true;
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_nisira.ListaPersonalNisira();
            //ColumnasDtgv();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

        }

        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {
            //guardarFotosMenorTamañ();

        }


        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[8].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 11f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

    }
}
