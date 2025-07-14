using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_TabMaestra
{
    public partial class Frm_AgregarEmpresa : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_logistica objdatlogisticaneg = new cn_logistica();
        cn_reportes objdatreporteneg = new cn_reportes();
        cu_excel objexcel = new cu_excel();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 2;
        public Frm_AgregarEmpresa()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_AgregarEmpresa_Load(object sender, EventArgs e)
        {
            if (textBox_CodEmpresa.Text == "")
            {
                CargarPanelgeneral();
                BloquearTextboxCombobox();
                //BloquearTextboxCombobox();

                //textBox_CodEmpresa.Text = ce_logistica.codigo_ti;
                //textBox_descripcion.Text = ce_logistica.descripcion_ti;
                //textbox_comentario.Text = ce_logistica.comentario_ti;
                //comboBox_estado.SelectedValue = ce_logistica.estado_ti;

                //CARGAR CONDICION DEL PRODUCTO
                comboBox_EstEmpresa.DataSource = cn_regproducto.ListCond();
                comboBox_EstEmpresa.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_EstEmpresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            BloquearTextboxCombobox();


            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //ImprimirReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void ImprimirReporte()
        //{
        //    Frm_CrpVetaUsuario objImpresion = new Frm_CrpVetaUsuario();
        //    AddOwnedForm(objImpresion);
        //    objImpresion.Show();

        //    Frm_VentasPorUsuario.Ds_RepVentas objDsRepVenta = new Frm_VentasPorUsuario.Ds_RepVentas();
        //    string Nombres = textbox_datosusuario.Text;
        //    string Sede = textBox_sedeuser.Text;
        //    string TotAnulado = textBox_TotalAnulado.Text;
        //    string TotNoAnulado = textBox_TotalNoAnulado.Text;
        //    string Total = textBox_total.Text;
        //    DateTime FecIni = dateTimePicker_F_ini.Value.Date;
        //    DateTime FecFin = dateTimePicker_F_ini.Value.Date;

        //    objDsRepVenta.Tables[0].Rows.Add
        //    (new object[]{
        //        Nombres,
        //        Sede,
        //        TotAnulado,
        //        TotNoAnulado,
        //        Total,
        //        FecIni,
        //        FecFin

        //    });

        //    int filas = dataGridView2.Rows.Count;
        //    for (int i = 0; i <= filas - 1; i++)
        //    {
        //        objDsRepVenta.Tables[1].Rows.Add
        //            (new object[]{
        //            dataGridView2[0,i].Value.ToString(),
        //            dataGridView2[1,i].Value.ToString(),
        //            dataGridView2[2,i].Value.ToString(),
        //            dataGridView2[3,i].Value.ToString(),
        //            dataGridView2[4,i].Value.ToString(),
        //            dataGridView2[5,i].Value.ToString(),
        //            dataGridView2[6,i].Value.ToString()
        //            });
        //    }

        //    Frm_VentasPorUsuario.CryRep_VentasUsuario objCryRep = new Frm_VentasPorUsuario.CryRep_VentasUsuario();
        //    //string dir = @"~\CryRep_VentasUsuario.rpt";
        //    objCryRep.Load(@"~\CryRep_VentasUsuario.rpt");
        //    objCryRep.SetDataSource(objDsRepVenta);
        //    objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        //}

        public void Limpiartextbox()
        {
            textBox_DesEmpresa.Text = "";
            textbox_ObsEmpresa.Text = "";
        }

        public void BloquearTextboxCombobox()
        {
            textBox_CodEmpresa.Enabled = false;
            textBox_DesEmpresa.Enabled = false;
            textbox_ObsEmpresa.Enabled = false;
            comboBox_EstEmpresa.Enabled = false;
            comboBox_EstEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void DesbloquearTextboxCombobox()
        {
            textBox_DesEmpresa.Enabled = true;
            textbox_ObsEmpresa.Enabled = true;
            comboBox_EstEmpresa.Enabled = true;
            comboBox_EstEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarPanelgeneral()
        {
            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            //toolStripButton_editar.Enabled = false;
            if (textBox_DesEmpresa.Text == "")
            {
                toolStripButton_guardar.Enabled = false;
                toolStripButton_editar.Enabled = false;
                toolStripButton_eliminar.Enabled = false;
                toolStripButton_limpiar.Enabled = false;
                toolStripButton_nuevo.Enabled = true;
            }

            //LLAMAR EN TEXBOX AL ULTIMO CODIGO DE MARCA +1 
            cn_logistica.BuscUltimoCodEmpresaMas();
            if (ce_logistica.codigo.ToString() == "")
            {
                textBox_CodEmpresa.Text = "CE001";
            }
            else
            {
                textBox_CodEmpresa.Text = "CE" + ce_logistica.codigo.ToString("D3");
            }
            //LABEL            
            comboBox_EstEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox_DesEmpresa.CharacterCasing = CharacterCasing.Upper;
            textbox_ObsEmpresa.CharacterCasing = CharacterCasing.Upper;
            //
            //CARGAR CONDICION DEL PRODUCTO
            comboBox_EstEmpresa.DataSource = cn_regproducto.ListCond();
            comboBox_EstEmpresa.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_EstEmpresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
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

        private void textbox_factura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
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


        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            CargarPanelgeneral();
            Limpiartextbox();
            DesbloquearTextboxCombobox();
            toolStripButton_guardar.Enabled = true;
            toolStripButton_limpiar.Enabled = true;
            textBox_DesEmpresa.Focus();
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            GuardarEmpresa();

        }

        private void GuardarEmpresa()
        {
            if (textBox_DesEmpresa.Text != "")
            {

                cn_logistica.BuscExisteCodEmpresa(textBox_CodEmpresa.Text);
                if (textBox_CodEmpresa.Text == ce_logistica.CodTiExist)
                {
                    string MessageBoxTitle = "Actualizar";
                    string MessageBoxContent = "¿Desea actualizar Empresa?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objdatlogisticaneg.ActuaEmpresa(
                        textBox_CodEmpresa.Text,
                        textBox_DesEmpresa.Text,
                        textbox_ObsEmpresa.Text,
                        comboBox_EstEmpresa.SelectedValue.ToString(),
                        //ce_usuario.FechaSistema(),
                        //ce_usuario.useusr,
                        //ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.useusr
                    );

                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("EMPRESA ACTUALIZADO", Color.FromArgb(13, 93, 140), 1);
                        ng.ShowDialog();
                        this.Close();

                    }
                }

                else if (textBox_CodEmpresa.Text != ce_logistica.CodTiExist)
                {
                    string MessageBoxTitle = "Guardar";
                    string MessageBoxContent = "¿Desea Guardar Empresa?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objdatlogisticaneg.GuardEmpresa(
                        textBox_CodEmpresa.Text,
                        textBox_DesEmpresa.Text,
                        textbox_ObsEmpresa.Text,
                        comboBox_EstEmpresa.SelectedValue.ToString(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.useusr,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.useusr
                    );

                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("EMPRESA AGREGADO", Color.FromArgb(13, 93, 140), 1);
                        ng.ShowDialog();
                        this.Close();
                    }
                }

                CargarPanelgeneral();
                Limpiartextbox();

            }
            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE DESCRIPCION", Color.Goldenrod, 4);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {
            DesbloquearTextboxCombobox();
            toolStripButton_guardar.Enabled = true;
        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            EliminarGrupo();
        }

        private void EliminarGrupo()
        {
            cn_logistica.BuscExisteCodEmpresa(textBox_CodEmpresa.Text);
            if (textBox_CodEmpresa.Text == ce_logistica.CodTiExist)
            {
                string MessageBoxTitle = "Eliminar";
                string MessageBoxContent = "¿Desea eliminar Empresa?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objdatlogisticaneg.EliminEmpresa(textBox_CodEmpresa.Text);
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("EMPRESA ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();
                    Close();
                    CargarPanelgeneral();
                    Limpiartextbox();
                    BloquearTextboxCombobox();
                }
            }

            else if (textBox_CodEmpresa.Text != ce_logistica.CodTiExist)
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("EMPRESA NO ENCONTRADO", Color.OrangeRed, 3);
                ng.ShowDialog();
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            CargarPanelgeneral();
            ////
            Limpiartextbox();
            DesbloquearTextboxCombobox();
            toolStripButton_guardar.Enabled = true;
            toolStripButton_limpiar.Enabled = true;
            textBox_DesEmpresa.Focus();
        }


        public void TablaAgregarDatosFila(DataGridViewRow coduser)
        {
            //textBox_user.Text = coduser.Cells[0].Value.ToString();
            //textbox_datosusuario.Text = coduser.Cells[2].Value.ToString();
            //textBox_sedeuser.Text = coduser.Cells[4].Value.ToString();
            //textBox_user.Enabled = true;
            //textbox_datosusuario.Enabled = false;
        }


        private void button_buscarcliente_Click(object sender, EventArgs e)
        {


        }


        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if(e.ColumnIndex == 6)
            //{
            //    //bool isdouble = double.TryParse(e.FormattedValue.ToString(), out double resultnumerico);
            //    if(int.Parse(dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString()) > int.Parse(dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString()))
            //    {
            //        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("NO DEBE SER MAYOR A STOCK", Color.DarkRed, 3);
            //        ng.ShowDialog();
            //        dataGridView2.Rows[e.RowIndex].Cells[6].Value = "0";
            //    }

            //}
        }

        private void button_calcular_Click(object sender, EventArgs e)
        {

        }

        private void button_calcular_Click_1(object sender, EventArgs e)
        {
            // SumarTotal();
        }


        private void textBox_dniusuario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Estado")
            //{
            //    if (e.Value.ToString() == "S")
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 11.0f);
            //        e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }
            //}

        }


    }

}
