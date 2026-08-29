using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    public partial class Frm_ModificarAsignacion : Form
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
        public Frm_ModificarAsignacion()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_ModificarAsignacion_Load(object sender, EventArgs e)
        {
            BloquearTextboxCombobox();
            //CargarDatosComboBox();
            PonerOscuroComboBox();

            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }


        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        public void CargarDatosComboBox()
        {
            //CARGAR ESTADO
            comboBox_Estado.DataSource = cn_regproducto.ListCond();
            comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA
            comboBox_CodEmp.DataSource = cn_logistica.ListaCBEmpresaAsignacionTI();
            comboBox_CodEmp.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodEmp.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR SEDE
            comboBox_CodSede.DataSource = cn_logistica.ListaCBSedeAsignacionTI();
            comboBox_CodSede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodSede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR AREA
            comboBox_CodArea.DataSource = cn_logistica.ListaCBAreaAsignacionTI();
            comboBox_CodArea.DisplayMember = "DesArea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodArea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR ESTADO ACTIVO
            comboBox_EstadoActivo.DataSource = cn_logistica.ListaCBEstActivoAsignacionTI();
            comboBox_EstadoActivo.DisplayMember = "DesEst"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_EstadoActivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR TIPO ACTIVO
            comboBox_Activo.DataSource = cn_logistica.ListaCBTipoActivoTI();
            comboBox_Activo.DisplayMember = "DesTA"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Activo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
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
            textBox_Dni.Text = "";
            textBox_Usuario.Text = "";
            textBox_Obs1.Text = "";
            textBox_Obs2.Text = "";
            textBox_Ubicacion.Text = "";
        }

        public void PonerOscuroComboBox()
        {
            comboBox_CodEmp.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodArea.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Activo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_EstadoActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void BloquearTextboxCombobox()
        {
            textBox_CodAsig.Enabled = false;
            comboBox_Activo.Enabled = false;
            textBox_Dni.Enabled = false;
            textBox_Usuario.Enabled = false;
            textBox_Numero.Enabled = false;
            textBox_Cant.Enabled = false;
            textBox_Ubicacion.Enabled = false;
            textBox_Obs1.Enabled = false;
            textBox_Obs2.Enabled = false;
            //
            comboBox_CodEmp.Enabled = false;
            comboBox_CodSede.Enabled = false;
            comboBox_CodArea.Enabled = false;
            comboBox_EstadoActivo.Enabled = false;
            comboBox_Estado.Enabled = false;
            //
            dateTimePicker_F_Entrega.Enabled = false;
            dateTimePicker_F_Deolucion.Enabled = false;
            comboBox_Estado.Enabled = false;
            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void DesbloquearTextboxCombobox()
        {
            textBox_CodAsig.Enabled = false;
            textBox_Dni.Enabled = true;
            //textBox_Usuario.Enabled = true;
            textBox_Numero.Enabled = true;
            textBox_Cant.Enabled = true;
            textBox_Ubicacion.Enabled = true;
            textBox_Obs1.Enabled = true;
            textBox_Obs2.Enabled = true;
            //
            comboBox_CodEmp.Enabled = true;
            comboBox_CodSede.Enabled = true;
            comboBox_CodArea.Enabled = true;
            //comboBox_Activo.Enabled = true;
            comboBox_EstadoActivo.Enabled = true;
            comboBox_Estado.Enabled = true;
            //
            dateTimePicker_F_Entrega.Enabled = true;
            dateTimePicker_F_Deolucion.Enabled = true;
            comboBox_Estado.Enabled = true;
            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarPanelgeneral()
        {

            //LABEL            
            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox_Usuario.CharacterCasing = CharacterCasing.Upper;
            //
            //CARGAR CONDICION DEL PRODUCTO
            comboBox_Estado.DataSource = cn_regproducto.ListCond();
            comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
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
            textBox_CodAsig.Focus();
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {



        }

        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {
            DesbloquearTextboxCombobox();
            toolStripButton_guardar.Enabled = true;
        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            cn_logistica.BuscExisteCodAsignacionTI(textBox_CodAsig.Text);
            if (textBox_CodAsig.Text == ce_logistica.CodTiExist)
            {
                string MessageBoxTitle = "Eliminar";
                string MessageBoxContent = "¿Desea eliminar?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objdatlogisticaneg.EliminAsignacionActTI(
                        textBox_CodAsig.Text,
                        textBox_item.Text,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();
                    Close();
                    CargarPanelgeneral();
                    Limpiartextbox();
                    BloquearTextboxCombobox();
                }
            }

            //else if (textBox_CodPer.Text != ce_logistica.CodTiExist)
            //{
            //    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO NO ENCONTRADO", Color.OrangeRed, 3);
            //    ng.ShowDialog();
            //}
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            CargarPanelgeneral();
            ////
            Limpiartextbox();
            DesbloquearTextboxCombobox();
            toolStripButton_guardar.Enabled = true;
            textBox_CodAsig.Focus();
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

        private void toolStripButton_guardar_edtiper_Click(object sender, EventArgs e)
        {
            string UltCod;
            //LLAMAR EN TEXBOX AL ULTIMO CODIGO DE MARCA +1 
            cn_logistica.BuscUltimoCodAsignacionTIMas();
            if (ce_logistica.codigo.ToString() == "")
            {
                UltCod = "M0000001";
            }
            else
            {
                UltCod = "M" + ce_logistica.codigo.ToString("D7");
            }
            //LABEL       

            cn_logistica.BuscExisteCodAsignacionActivoTI(textBox_CodAsig.Text, Convert.ToInt32(textBox_item.Text));
            if (textBox_CodAsig.Text == ce_logistica.CodActAsigTI
                && Convert.ToInt32(textBox_item.Text) == ce_logistica.ItemAsigTI)
            {
                objdatlogisticaneg.ActuaAsignacionActTI(
                    textBox_CodAsig.Text,
                    Convert.ToInt32(textBox_item.Text),
                    comboBox_CodEmp.SelectedValue.ToString(),
                    comboBox_CodSede.SelectedValue.ToString(),
                    comboBox_CodArea.SelectedValue.ToString(),
                    textBox_Dni.Text,
                    comboBox_EstadoActivo.Text,
                    "",
                    textBox_Obs1.Text,
                    textBox_Obs2.Text,
                    textBox_Numero.Text,
                    textBox_Cant.Text,
                    textBox_Ubicacion.Text,
                    dateTimePicker_F_Entrega.Value,
                    dateTimePicker_F_Deolucion.Value,
                    comboBox_Estado.SelectedValue.ToString(),
                    //ce_usuario.FechaSistema(),
                    //ce_usuario.usecod,
                    //ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    );
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ACTUALIZADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();
                this.Close();
            }
        }

        private void comboBox_CodEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_CodEmp.Text == comboBox_CodEmp.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_CodSede.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_CodEmp.Text);
                comboBox_CodSede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_CodSede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void textBox_Dni_TextChanged(object sender, EventArgs e)
        {
            cn_equipoti.BuscExisteEmpleador(textBox_Dni.Text);
            if (textBox_Dni.Text == "")
            {
                textBox_Usuario.Text = "";
            }
            else
            {
                if (textBox_Dni.Text == ce_equipoti.CodTrabajadorExist)
                {
                    textBox_Usuario.Text = ce_equipoti.EmpleadorExist.ToString();
                }
                else
                {
                    textBox_Usuario.Text = "";
                    //MessageBox.Show("Usuario no encontrado");
                }
            }
        }

        private void dataGridView2_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.ToString() == "ACTIVO")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.MediumSeaGreen;
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
            }
        }
    }

}
