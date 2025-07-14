using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_TabMaestra
{

    public partial class frm_Registrar_usuario : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_logistica objcnlog = new cn_logistica();
        cn_apisperu objapi = new cn_apisperu();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 1;
        //private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        //Overridden methods

        public frm_Registrar_usuario()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;            
        }

        private void Frm_agregar_Load(object sender, EventArgs e)
        {

            textbox_apellidos.CharacterCasing = CharacterCasing.Upper;
            textbox_nombres.CharacterCasing = CharacterCasing.Upper;
            cmbox_sexo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbox_estado.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox_Obs.CharacterCasing = CharacterCasing.Upper;
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;

            button_cargar_foto.Enabled = false;

            bloqueartextbox();
            cargarcombobox();
            cn_logistica.ListaPersonalTI();

            pictureBox_fotoperfil.Image = pictureBox_titulo.Image;

            //DatagridFormato();

            this.Padding = new Padding(borderSize);//Border size
            //this.BackColor = Color.FromArgb(98, 102, 244);//Border color
            //
        }

        public void cargarcombobox()
        {
            //CARGAR GENERO
            cmbox_sexo.DataSource = cn_datoscliente.ListSex();
            cmbox_sexo.DisplayMember = "sexo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            cmbox_sexo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR GERENCIA
            comboBox_Empresa.DataSource = cn_logistica.ListaEmpresaTI();
            comboBox_Empresa.DisplayMember = "Empresa"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Empresa.ValueMember = "Codigo"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR SEDE
            cmbox_sede.DataSource = cn_logistica.ListaSedeTI();
            cmbox_sede.DisplayMember = "Sede"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            cmbox_sede.ValueMember = "Codigo"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR SEDE DADO LA CONDICION DE EMPRESA
            if (comboBox_Empresa.Text == comboBox_Empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                cmbox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_Empresa.Text);
                cmbox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                cmbox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }

            //CARGAR AREA
            cmbox_area.DataSource = cn_logistica.ListaAreaTI();
            cmbox_area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            cmbox_area.ValueMember = "Codigo"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR ESTADO
            cmbox_estado.DataSource = cn_regproducto.ListCond();
            cmbox_estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            cmbox_estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
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
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            if (textbox_dni.Text != "")

            {
                if (textbox_apellidos.Text != "")
                {
                    if (textbox_nombres.Text != "")
                    {

                        objcnlog.GuardPersonalTI(
                            textbox_dni.Text,
                            textbox_apellidos.Text,
                            textbox_nombres.Text,
                            cmbox_sexo.SelectedValue.ToString(),
                            comboBox_Empresa.SelectedValue.ToString(),
                            cmbox_sede.SelectedValue.ToString(),
                            cmbox_area.SelectedValue.ToString(),
                            dateTimePicker_F_Nacimiento.Value.Date,
                            textBox_gmail.Text,
                            textBox_Obs.Text,
                            ms.GetBuffer(),
                            cmbox_estado.SelectedValue.ToString(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                        textbox_dni.Text = "";
                        textbox_apellidos.Text = "";
                        textbox_nombres.Text = "";
                        pictureBox_fotoperfil.Image = pictureBox_titulo.Image;

                    }


                    else
                    {
                        MessageBox.Show("Ingrese nombre");
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese apellidos");
                }
            }
            else
            {
                MessageBox.Show("Ingrese dni");
            }

        }

        //BUSCAR USUARIO REGISTRADO
        private void UsuarioDni()
        {
            if (textbox_dni.Text == "")
            {

            }
            else
            {
                cn_logistica.ListaPersonalDniTI(textbox_dni.Text);
            }


        }

        //ELIMINAR USUARIO

        private void EliminarUsuarioDni()
        {
            objcnlog.ElimPersonalDniTI(textbox_dni.Text);
        }

        //GUARDAR MODIFICADO
        private void ActualizarUsuarioDni()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            objcnlog.ActualizarPersonalTI(
                textbox_dni.Text,
                textbox_apellidos.Text,
                textbox_nombres.Text,
                cmbox_sexo.SelectedValue.ToString(),
                comboBox_Empresa.SelectedValue.ToString(),
                cmbox_sede.SelectedValue.ToString(),
                cmbox_area.SelectedValue.ToString(),
                dateTimePicker_F_Nacimiento.Value.Date,
                textBox_gmail.Text,
                textBox_Obs.Text,
                ms.GetBuffer(),
                cmbox_estado.SelectedValue.ToString(),
                //ce_usuario.FechaSistema(),
                //ce_usuario.usecod,
                //ce_usuario.HostName(),
                ce_usuario.FechaSistema(),
                ce_usuario.usecod
                );
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //PASAR DATOS DE DATAGRIDVIEW A TEXTBOX
        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                toolStripButton_editar.Enabled = true;
                toolStripLabel_editar.Enabled = true;
                //DESACTIVAR BOTONES DE NUEVO, EDITAR Y ELIMINAR
                toolStripButton_buscar.Enabled = false;
                toolStripLabel_buscar.Enabled = false;
                toolStripButton_guardar.Enabled = false;
                toolStripLabel_guardar.Enabled = false;
                toolStripButton_aliminar.Enabled = false;
                toolStripLabel_aliminar.Enabled = false;

                bloqueartextbox();
                cargarcombobox();

                //DataGridViewRow dgv = dataGridView2.Rows[e.RowIndex];
                //ENVIAR DATOS A CADA TEXBOX
                textbox_dni.Text = dataGridView2.CurrentRow.Cells[0].Value?.ToString();
                textbox_apellidos.Text = dataGridView2.CurrentRow.Cells[1].Value?.ToString();
                textbox_nombres.Text = dataGridView2.CurrentRow.Cells[2].Value?.ToString();
                cmbox_sexo.Text = dataGridView2.CurrentRow.Cells[3].Value?.ToString();
                comboBox_Empresa.Text = dataGridView2.CurrentRow.Cells[4].Value?.ToString();
                cmbox_sede.Text = dataGridView2.CurrentRow.Cells[5].Value?.ToString();
                cmbox_area.Text = dataGridView2.CurrentRow.Cells[6].Value?.ToString();
                dateTimePicker_F_Nacimiento.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                textBox_gmail.Text = dataGridView2.CurrentRow.Cells[8].Value?.ToString();
                textBox_Obs.Text = dataGridView2.CurrentRow.Cells[9].Value?.ToString();
                //textbox_contraseña.Text = cu_encriptar.DesEncriptar(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                cmbox_estado.Text = dataGridView2.CurrentRow.Cells[10].Value?.ToString();
                pictureBox_fotoperfil.Image = pictureBox_titulo.Image;
                //ENVIAR IMAGEN DE DATAGRIDVIEW A PICTUREBOX
                DataTable dt = new DataTable();
                dt = objcnlog.FotoPersonalTI(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                byte[] img = (byte[])dt.Rows[0]["Foto"]; // BUSCAR "Foto_perfil" EN EL PROCEDIMIENTO ALMACENADO DE BUSCAR FOTO

                if (dt.Rows[0]["Foto"] != System.DBNull.Value)
                {
                    if (dt.Rows.Count > 0)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                        pictureBox_fotoperfil.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox_fotoperfil.Image = pictureBox_titulo.Image;
                }
            }
        }


        public void BuscarPersonaReniec()
        {
            try
            {
                dynamic respuesta = objapi.Get("https://api.apis.net.pe/v1/dni?numero=" + textbox_dni.Text + "");
                textbox_apellidos.Text = respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                textbox_nombres.Text = respuesta.nombres.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("No fue posible conectar con RENIEC");
            }
        }


        private void textbox_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_logistica.ListaPersonalDniTI(textbox_dni.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();
                toolStripButton_nuevo.Enabled = true;

                BuscarPersonaReniec();

                //dataGridView2.Columns.Clear();
                //dataGridView2.DataSource = cn_logistica.ListaPersonalDniTI(textbox_dni.Text);
                //dataGridView2.AllowUserToAddRows = false;
                //OrigenColorfila();
                //dataGridView2.ClearSelection();
                //toolStripButton_nuevo.Enabled = true;

            }


            else if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

        }

        private void button_cargar_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            DialogResult resultado = foto.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox_fotoperfil.Image = Image.FromFile(foto.FileName);
            }
        }

        public void buscar()
        {
            //UsuarioDni();
            //pictureBox_fotoperfil.Image = null;
            if (textbox_dni.Text != "")
            {
                UsuarioDni();
                //pictureBox_fotoperfil.Image = pictureBox_titulo.Image;

                cn_logistica.ListaPersonalDniTI(textbox_dni.Text);

                //BUSCAR USUARIO POR DNI Y LUEGO ENVIAR SU FOTO A PICTUREBOX
                DataTable dt = new DataTable();
                dt = objcnlog.FotoPersonalTI(textbox_dni.Text);

                if (dt.Rows[0][0] != System.DBNull.Value)
                {
                    if (dt.Rows.Count > 0)
                    {
                        byte[] img = (byte[])dt.Rows[0]["Foto"];

                        System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                        pictureBox_fotoperfil.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox_fotoperfil.Image = pictureBox_titulo.Image;
                }

            }


            else
            {
                MessageBox.Show("Ingrese dni");
            }
        }

        public void guardar()
        {
            if (textbox_dni.Text != "")
            {
                cn_logistica.ListaPersonalExistenteTI(textbox_dni.Text);
                if (textbox_dni.Text == ce_logistica.dni_userTI)
                {
                    string MessageBoxTitle = "Actualizar";
                    string MessageBoxContent = "¿Desea actualizar registro?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ActualizarUsuarioDni();

                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = cn_logistica.ListaPersonalTI();
                        dataGridView2.AllowUserToAddRows = false;
                        OrigenColorfila();
                        dataGridView2.ClearSelection();
                        toolStripButton_nuevo.Enabled = true;

                        toolStripButton_buscar.Enabled = true;
                        toolStripLabel_buscar.Enabled = true;
                        toolStripButton_editar.Enabled = false;
                        toolStripButton_guardar.Enabled = false;
                        toolStripButton_aliminar.Enabled = false;
                        button_cargar_foto.Enabled = false;

                        nuevo();
                        cargarcombobox();
                        bloqueartextbox();


                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL ACTUALIZADO", Color.SeaGreen, 2);
                        ng.ShowDialog();

                    }
                }

                else if (textbox_dni.Text != ce_logistica.dni_userTI)
                {
                    string MessageBoxTitle1 = "Nuevo";
                    string MessageBoxContent1 = "¿Registrar nuevo usuario?";
                    DialogResult dialogResult1 = MessageBox.Show(MessageBoxContent1, MessageBoxTitle1, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        GuardarUsuario();
                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = cn_logistica.ListaPersonalTI();
                        dataGridView2.AllowUserToAddRows = false;
                        OrigenColorfila();
                        dataGridView2.ClearSelection();
                        toolStripButton_nuevo.Enabled = true;

                        toolStripButton_buscar.Enabled = true;
                        toolStripLabel_buscar.Enabled = true;
                        toolStripButton_editar.Enabled = false;
                        toolStripButton_guardar.Enabled = false;
                        toolStripButton_aliminar.Enabled = false;
                        button_cargar_foto.Enabled = false;

                        nuevo();
                        cargarcombobox();
                        bloqueartextbox();

                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL GUARDADO", Color.FromArgb(13, 93, 140), 1);
                        ng.ShowDialog();

                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese dni");
            }
        }

        public void eliminar()
        {
            cn_logistica.ListaPersonalExistenteTI(textbox_dni.Text);

            string MessageBoxTitle = "Eliminar";
            string MessageBoxContent = "¿Desea eliminar usuario?";


            //do something
            if (textbox_dni.Text == ce_logistica.dni_userTI)
            {
                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    EliminarUsuarioDni();
                    //MessageBox.Show("Usuario eliminado");                   

                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaPersonalTI();
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                    toolStripButton_nuevo.Enabled = true;

                    nuevo();
                    cargarcombobox();
                    bloqueartextbox();
                    pictureBox_fotoperfil.Image = pictureBox_titulo.Image;

                    toolStripButton_buscar.Enabled = true;
                    toolStripButton_nuevo.Enabled = true;
                    toolStripButton_editar.Enabled = false;
                    toolStripButton_guardar.Enabled = false;
                    toolStripButton_aliminar.Enabled = false;
                    button_cargar_foto.Enabled = false;

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("USUARIO ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();


                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }

            else
            {
                //EliminarUsuarioDni();
                MessageBox.Show("Usuario no registrado");
            }

        }

        public void nuevo()
        {
            textbox_dni.Text = "";
            textbox_apellidos.Text = "";
            textbox_nombres.Text = "";
            textBox_gmail.Text = "";
            textBox_Obs.Text = "";

            pictureBox_fotoperfil.Image = pictureBox_titulo.Image;
        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            toolStripButton_buscar.Enabled = false;
            toolStripLabel_buscar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;
            toolStripLabel_aliminar.Enabled = false;
            toolStripButton_editar.Enabled = false;
            toolStripLabel_editar.Enabled = false;

            button_cargar_foto.Enabled = true;
            textbox_dni.Focus();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaPersonalTI();

            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

            //ColumnasDtgv();

            if (textbox_dni.Enabled == false)
            {
                toolStripButton_guardar.Enabled = true;
                toolStripLabel_guardar.Enabled = true;

                desbloqueartextbox();
                nuevo();
                textbox_dni.Focus();
            }
            else if (textbox_dni.Enabled == true)
            {
                nuevo();
            }


        }

        private void toolStripLabel_nuevo_Click(object sender, EventArgs e)
        {
            toolStripButton_buscar.Enabled = false;
            toolStripLabel_buscar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;
            toolStripLabel_aliminar.Enabled = false;
            toolStripButton_editar.Enabled = false;
            toolStripLabel_editar.Enabled = false;

            button_cargar_foto.Enabled = true;

            dataGridView2.Columns.Clear();

            if (textbox_dni.Enabled == false)
            {
                toolStripButton_guardar.Enabled = true;
                toolStripLabel_guardar.Enabled = true;

                desbloqueartextbox();
                nuevo();
                textbox_dni.Focus();
            }
            else if (textbox_dni.Enabled == true)
            {
                nuevo();
            }
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            button_cargar_foto.Enabled = false;
            toolStripButton_guardar.Enabled = false;
            toolStripButton_guardar.Enabled = false;

            toolStripButton_editar.Enabled = false;
            toolStripButton_editar.Enabled = false;

            toolStripButton_aliminar.Enabled = false;
            toolStripLabel_aliminar.Enabled = false;


            if (textbox_dni.Enabled == false)
            {
                textbox_dni.Enabled = true;
                textbox_dni.Focus();
                //bloqueartextbox();
                nuevo();
            }
            else if (textbox_dni.Enabled == true)
            {
                //textbox_dni.Text="";
                textbox_dni.Focus();
                buscar();
            }
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            guardar();

        }

        private void toolStripButton_aliminar_Click(object sender, EventArgs e)
        {
            eliminar();

        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            nuevo();

            toolStripButton_nuevo.Enabled = true;
            toolStripLabel_nuevo.Enabled = true;
            toolStripButton_buscar.Enabled = true;
            toolStripLabel_buscar.Enabled = true;
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;

            button_cargar_foto.Enabled = false;

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaPersonalTI();
            //ColumnasDtgv();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

            bloqueartextbox();
        }

        private void toolStripLabel_limpiar_Click(object sender, EventArgs e)
        {
            nuevo();

            toolStripButton_nuevo.Enabled = true;
            toolStripLabel_nuevo.Enabled = true;
            toolStripButton_buscar.Enabled = true;
            toolStripLabel_buscar.Enabled = true;
            toolStripButton_editar.Enabled = true;
            toolStripLabel_editar.Enabled = true;
            toolStripButton_guardar.Enabled = true;
            toolStripLabel_guardar.Enabled = true;
            toolStripButton_aliminar.Enabled = true;
            toolStripLabel_aliminar.Enabled = true;

            button_cargar_foto.Enabled = false;

            dataGridView2.Columns.Clear();

            bloqueartextbox();
        }

        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            if (textbox_dni.Text != "")
            {
                if (textbox_nombres.Text != "")
                {
                    toolStripButton_buscar.Enabled = false;
                    toolStripLabel_buscar.Enabled = false;
                    toolStripButton_guardar.Enabled = true;
                    toolStripLabel_guardar.Enabled = true;
                    toolStripButton_aliminar.Enabled = true;
                    toolStripLabel_aliminar.Enabled = true;
                    button_cargar_foto.Enabled = true;

                    desbloqueartextboxEdit();
                }
            }

        }

        private void toolStripLabel_editar_Click(object sender, EventArgs e)
        {

        }

        private void bloqueartextbox()
        {
            textbox_dni.Enabled = false;
            textbox_apellidos.Enabled = false;
            textbox_nombres.Enabled = false;
            textBox_gmail.Enabled = false;
            textBox_Obs.Enabled = false;
            //
            cmbox_sexo.Enabled = false;
            comboBox_Empresa.Enabled = false;
            cmbox_area.Enabled = false;
            cmbox_sede.Enabled = false;
            cmbox_estado.Enabled = false;
            //
            dateTimePicker_F_Nacimiento.Enabled = false;
        }

        private void desbloqueartextbox()
        {
            textbox_dni.Enabled = true;
            textbox_apellidos.Enabled = true;
            textbox_nombres.Enabled = true;
            textBox_gmail.Enabled = true;
            textBox_Obs.Enabled = true;
            //
            cmbox_sexo.Enabled = true;
            comboBox_Empresa.Enabled = true;
            cmbox_area.Enabled = true;
            cmbox_sede.Enabled = true;
            cmbox_estado.Enabled = true;
            //
            dateTimePicker_F_Nacimiento.Enabled = true;
        }

        private void desbloqueartextboxEdit()
        {
            textbox_dni.Enabled = false;
            textbox_apellidos.Enabled = true;
            textbox_nombres.Enabled = true;
            textBox_gmail.Enabled = true;
            textBox_Obs.Enabled = true;
            //
            cmbox_sexo.Enabled = true;
            comboBox_Empresa.Enabled = true;
            cmbox_area.Enabled = true;
            cmbox_sede.Enabled = true;
            cmbox_estado.Enabled = true;
            //
            dateTimePicker_F_Nacimiento.Enabled = true;
        }

        private void textbox_dni_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textbox_dni_TextChanged(object sender, EventArgs e)
        {

        }

        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[10].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 11f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private void comboBox_Empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Empresa.Text == comboBox_Empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                cmbox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_Empresa.Text);
                cmbox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                cmbox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void textbox_dni_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
