using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    public partial class Frm_RegAsignacion : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datoscliente objdatclienteneg = new cn_datoscliente();
        cn_logistica objdatlogisticaneg = new cn_logistica();
        cn_reportes objdatreporteneg = new cn_reportes();
        cu_excel objexcel = new cu_excel();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 2;
        public Frm_RegAsignacion()
        {
            InitializeComponent();
            dataGridView2.ClearSelection();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_RegAsignacion_Load(object sender, EventArgs e)
        {
            comboBox_TiposPerActivo.SelectedIndex = 0;
            comboBox_TiposPerActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            textbox_ActivoDesc.CharacterCasing = CharacterCasing.Upper;
            textbox_ActivoDesc.Focus();

            CargarPanelgeneral();
            BloquearTextboxCombobox();

            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
            toolStripButton_PrintQR.Visible = false;
            toolStripLabel_PrintQR.Visible = false;

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%");
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;

            OrigenColorfila();

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {

            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
            try
            {
                ImprimirReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ImprimirReporte()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Asignacion.Ds_RepAsignacion objDsRepVenta = new Reportes.Frm_Asignacion.Ds_RepAsignacion();
            string Tipo;
            string Descripcion;

            if (comboBox_TiposPerActivo.Text == "SELECCIONE")
            {
                Tipo = "TODOS";
                Descripcion = "TODOS";
            }
            else
            {
                Tipo = comboBox_TiposPerActivo.Text;
                Descripcion = textbox_ActivoDesc.Text;
                //string TotAnulado = textBox_TotalAnulado.Text;
                //string TotNoAnulado = textBox_TotalNoAnulado.Text;
                //string Total = textBox_total.Text;
                //DateTime FecIni = dateTimePicker_F_ini.Value.Date;
                //DateTime FecFin = dateTimePicker_F_ini.Value.Date;
            }

            objDsRepVenta.Tables[0].Rows.Add
            (new object[]{
                Tipo,
                Descripcion
            });

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    dataGridView2[1,i].Value.ToString(),
                    dataGridView2[2,i].Value.ToString(),
                    dataGridView2[3,i].Value.ToString(),
                    dataGridView2[4,i].Value.ToString(),
                    dataGridView2[5,i].Value.ToString(),
                    dataGridView2[6,i].Value.ToString(),
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString()
                    });
            }

            Reportes.Frm_Asignacion.CryRep_Asignacion objCryRep = new Reportes.Frm_Asignacion.CryRep_Asignacion();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRep_VentasUsuario.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }

        public void EliminarDatagrid12()
        {
            DataTable dtp = new DataTable();
            dtp = cn_datospersonal.BuscarPersForAcadem(int.Parse("123"));
            dataGridView2.DataSource = dtp;
            dtp.Rows.Clear();
            dtp.Columns.Clear();
            ColumnasDtgv();
        }

        public void Limpiartextbox()
        {

        }

        public void BloquearTextboxCombobox()
        {
            dataGridView2.ReadOnly = true;
        }


        public void DesbloquearTextboxCombobox()
        {
            //DATAGRIDVIEW
            dataGridView2.ReadOnly = true;
        }

        public void CargarPanelgeneral()
        {
            dataGridView2.Columns.Clear();
            //NO PERMITIR EDITAR COLUMAS
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            toolStripButton_eliminar.Enabled = false;
            //toolStripButton_imprimir.Enabled = false;
            toolStripButton_limpiar.Enabled = false;
            //LABEL            
            ColumnasDtgv();
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

        private void ColumnasDtgv()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Codigo = new DataGridViewTextBoxColumn();
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Column1";
            Codigo.Width = 85;
            dataGridView2.Columns.Add(Codigo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Item = new DataGridViewTextBoxColumn();
            Item.HeaderText = "Item";
            Item.Name = "Column2";
            Item.Width = 87;
            dataGridView2.Columns.Add(Item);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Column2";
            Empresa.Width = 85;
            dataGridView2.Columns.Add(Empresa);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Sede = new DataGridViewTextBoxColumn();
            Sede.HeaderText = "Sede";
            Sede.Name = "Column3";
            Sede.Width = 87;
            dataGridView2.Columns.Add(Sede);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Area = new DataGridViewTextBoxColumn();
            Area.HeaderText = "Area";
            Area.Name = "Column4";
            Area.Width = 87;
            dataGridView2.Columns.Add(Area);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "Dni";
            Dni.Name = "Column2";
            Dni.Width = 87;
            dataGridView2.Columns.Add(Dni);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Usuario = new DataGridViewTextBoxColumn();
            Usuario.HeaderText = "Usuario";
            Usuario.Name = "Column2";
            Usuario.Width = 87;
            dataGridView2.Columns.Add(Usuario);
            // 
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Activo = new DataGridViewTextBoxColumn();
            Activo.HeaderText = "Activo";
            Activo.Name = "Column2";
            Activo.Width = 87;
            dataGridView2.Columns.Add(Activo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn EstActivo = new DataGridViewTextBoxColumn();
            EstActivo.HeaderText = "Estado Activo";
            EstActivo.Name = "Column2";
            EstActivo.Width = 87;
            dataGridView2.Columns.Add(EstActivo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Origen = new DataGridViewTextBoxColumn();
            Origen.HeaderText = "Origen";
            Origen.Name = "Column2";
            Origen.Width = 87;
            dataGridView2.Columns.Add(Origen);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Serie = new DataGridViewTextBoxColumn();
            Serie.HeaderText = "Serie";
            Serie.Name = "Column2";
            Serie.Width = 87;
            dataGridView2.Columns.Add(Serie);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn IMEI = new DataGridViewTextBoxColumn();
            IMEI.HeaderText = "IMEI";
            IMEI.Name = "Column2";
            IMEI.Width = 87;
            dataGridView2.Columns.Add(IMEI);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn MacEther = new DataGridViewTextBoxColumn();
            MacEther.HeaderText = "Mac Ethernet";
            MacEther.Name = "Column2";
            MacEther.Width = 87;
            dataGridView2.Columns.Add(MacEther);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn MacWifi = new DataGridViewTextBoxColumn();
            MacWifi.HeaderText = "Mac Wifi";
            MacWifi.Name = "Column2";
            MacWifi.Width = 87;
            dataGridView2.Columns.Add(MacWifi);

            // 
            // Column2
            // 
            DataGridViewTextBoxColumn MacEquipo = new DataGridViewTextBoxColumn();
            MacEquipo.HeaderText = "Mac Equipo";
            MacEquipo.Name = "Column2";
            MacEquipo.Width = 87;
            dataGridView2.Columns.Add(MacEquipo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn FecEnt = new DataGridViewTextBoxColumn();
            FecEnt.HeaderText = "Fecha Entrega";
            FecEnt.Name = "Column2";
            FecEnt.Width = 87;
            dataGridView2.Columns.Add(FecEnt);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn FecDev = new DataGridViewTextBoxColumn();
            FecDev.HeaderText = "Fecha Devolucion";
            FecDev.Name = "Column2";
            FecDev.Width = 87;
            dataGridView2.Columns.Add(FecDev);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn obs1 = new DataGridViewTextBoxColumn();
            obs1.HeaderText = "Observacion1";
            obs1.Name = "Column2";
            obs1.Width = 87;
            dataGridView2.Columns.Add(obs1);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn obs2 = new DataGridViewTextBoxColumn();
            obs2.HeaderText = "Observacion2";
            obs2.Name = "Column2";
            obs2.Width = 87;
            dataGridView2.Columns.Add(obs2);

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

        //ELIMINAR FACTURA
        private void EliminarFac()
        {
            //objdatventaneg.EliminarFac(Int32.Parse(textbox_factura.Text));
        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;

            cn_logistica.BuscUltimoCodActivoTIMas();
            ce_logistica.codigo_ti = ce_logistica.codigo.ToString();
            ce_logistica.descripcion_ti = "";
            ce_logistica.comentario_ti = "";
            ce_logistica.estado_ti = "AC";

            Frm_AgregarAsignacion frbm = new Frm_AgregarAsignacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();

            /*
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
            */
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;

        }


        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        public struct Datos
        {
            public string codigo;
            public string descripcion;
            public string comentario;
            public string estado;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ce_logistica.codigo_ti = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //ce_logistica.descripcion_ti = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //ce_logistica.comentario_ti = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //ce_logistica.estado_ti = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            Frm_ModificarAsignacion obj = new Frm_ModificarAsignacion();
            obj.CargarDatosComboBox();
            obj.textBox_CodAsig.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            obj.textBox_item.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            obj.comboBox_CodEmp.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            obj.comboBox_CodSede.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            obj.comboBox_CodArea.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            obj.textBox_Dni.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            obj.textBox_Usuario.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            obj.comboBox_Activo.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            obj.comboBox_EstadoActivo.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();

            //CARGAR CONDICION DEL PRODUCTO
            obj.comboBox_Estado.DataSource = cn_regproducto.ListCond();
            obj.comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            obj.comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            obj.comboBox_Estado.Text = dataGridView2.CurrentRow.Cells[22].Value.ToString();

            obj.textBox_Cant.Text = dataGridView2.CurrentRow.Cells[25].Value.ToString();
            obj.textBox_Numero.Text = dataGridView2.CurrentRow.Cells[24].Value.ToString();
            obj.textBox_Ubicacion.Text = dataGridView2.CurrentRow.Cells[26].Value.ToString();
            //obj.dateTimePicker_F_Entrega.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            //obj.dateTimePicker_F_Deolucion.Text = dataGridView2.CurrentRow.Cells[19].Value.ToString();
            obj.textBox_Obs1.Text = dataGridView2.CurrentRow.Cells[20].Value.ToString();
            obj.textBox_Obs2.Text = dataGridView2.CurrentRow.Cells[21].Value.ToString();

            obj.toolStripButton_guardar.Enabled = false;

            if (obj.comboBox_Estado.Text == "ANULADO")
            {
                obj.toolStripButton_eliminar.Enabled = false;
            }

            //obj.dataGridView2.Columns.Clear();
            //obj.dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(dataGridView2.CurrentRow.Cells[27].Value.ToString());
            //obj.dataGridView2.AllowUserToAddRows = false;
            //obj.OrigenColorfila();
            //obj.dataGridView2.ClearSelection();

            obj.ShowDialog();

            /*dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;*/
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
            CargarPanelgeneral();
            DesbloquearTextboxCombobox();
            ////
            Limpiartextbox();
            EliminarDatagrid12();
            dataGridView2.Columns.Clear();
            ColumnasDtgv();
            dataGridView2.AllowUserToAddRows = true;
            //dataGridView2.Columns.Clear();
            //EliminarDatagrid12();
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_imprimir.Enabled = false;
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

        private void textBox_dniusuario_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button_calcular_Click(object sender, EventArgs e)
        {

        }

        private void button_calcular_Click_1(object sender, EventArgs e)
        {
            // SumarTotal();
        }

        //
        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[22].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private void textBox_dniusuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
            objexcel.ExportarExcel(dataGridView2);
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%");
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;

            toolStripButton_PrintQR.Visible = false;
            toolStripLabel_PrintQR.Visible = false;

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.ToString() == "ANULADO")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
            }

        }

        private void textbox_ActivoDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_TiposPerActivo_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ce_logistica.CodActAsigTI = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            ce_logistica.ItemTI = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            toolStripButton_eliminar.Enabled = true;

            toolStripButton_inventario.Visible = true;
            toolStripLabel_inventario.Visible = true;
            toolStripButton_PrintQR.Visible = true;
            toolStripLabel_PrintQR.Visible = true;

            //int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
            //int a;
            //for (int i = 0; i <= filas - 1; i++)
            ////foreach (DataGridViewRow dr in dataGridView1.Rows)
            //{
            //    if (dataGridView2[22, i].Value.ToString() == "ANULADO")
            //    {
            //        toolStripLabel_imprimir.Enabled = false;
            //        toolStripButton_imprimir.Enabled = false;
            //    }
            //    if (dataGridView2[22, i].Value.ToString() == "ACTIVO")
            //    {
            //        toolStripLabel_imprimir.Enabled = true;
            //        toolStripLabel_imprimir.Enabled = true;
            //    }
            //}            

        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
            cn_logistica.BuscExisteCodAsignacionTI(ce_logistica.CodActAsigTI);
            if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == ce_logistica.CodActAsigTI)
            {
                string MessageBoxTitle = "Eliminar";
                string MessageBoxContent = "¿Desea eliminar?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    objdatlogisticaneg.EliminAsignacionActTI(
                     ce_logistica.CodActAsigTI,
                     ce_logistica.ItemTI,
                     ce_usuario.FechaSistema(),
                     ce_usuario.usecod
                     );

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();
                    //Close();

                    //dataGridView2.Columns.Clear();
                    //dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
                    //dataGridView2.AllowUserToAddRows = false;
                    //OrigenColorfila();
                    //dataGridView2.ClearSelection();
                    toolStripButton_nuevo.Enabled = true;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ce_equipoti.AreaEquipo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            ce_equipoti.TipoEquipo = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            ce_equipoti.MarcaEquipo = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            ce_equipoti.ModeloEquipo = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            ce_equipoti.IMEIEquipo = dataGridView2.CurrentRow.Cells[14].Value.ToString();
            ce_equipoti.NumeroEquipo = dataGridView2.CurrentRow.Cells[28].Value.ToString();
            ce_equipoti.SerieEquipo = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            ce_equipoti.CodActivo = dataGridView2.CurrentRow.Cells[27].Value.ToString();

            Frm_InventarioActivo obj = new Frm_InventarioActivo();
            obj.CargarDatosComboBox();
            obj.textBox_CodAsig.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            obj.textBox_item.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            obj.comboBox_CodEmp.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            obj.comboBox_CodSede.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            obj.comboBox_CodArea.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            obj.textBox_Dni.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            obj.textBox_Usuario.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            obj.comboBox_EstadoActivo.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            obj.comboBox_Activo.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();

            //CARGAR CONDICION DEL PRODUCTO
            obj.comboBox_Estado.DataSource = cn_regproducto.ListCond();
            obj.comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            obj.comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            obj.comboBox_Estado.Text = dataGridView2.CurrentRow.Cells[22].Value.ToString();

            obj.textBox_DevEvent.Text = dataGridView2.CurrentRow.Cells[23].Value.ToString();
            obj.textBox_Cant.Text = dataGridView2.CurrentRow.Cells[25].Value.ToString();
            obj.textBox_Numero.Text = dataGridView2.CurrentRow.Cells[24].Value.ToString();
            obj.textBox_Ubicacion.Text = dataGridView2.CurrentRow.Cells[26].Value.ToString();
            //obj.dateTimePicker_F_Entrega.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            //obj.dateTimePicker_F_Deolucion.Text = dataGridView2.CurrentRow.Cells[19].Value.ToString();
            obj.textBox_Obs1.Text = dataGridView2.CurrentRow.Cells[20].Value.ToString();
            obj.textBox_Obs2.Text = dataGridView2.CurrentRow.Cells[21].Value.ToString();

            obj.toolStripButton_guardar.Enabled = false;

            //if (obj.comboBox_Estado.Text == "ANULADO")
            //{
            //    obj.toolStripButton_eliminar.Enabled = false;
            //}

            obj.dataGridView2.Columns.Clear();
            obj.dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(dataGridView2.CurrentRow.Cells[27].Value.ToString());
            obj.dataGridView2.AllowUserToAddRows = false;
            obj.OrigenColorfila();
            obj.dataGridView2.ClearSelection();

            obj.ShowDialog();

            //dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
            //dataGridView2.AllowUserToAddRows = false;
            //OrigenColorfila();
            //dataGridView2.ClearSelection();
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
        }

        private void textbox_ActivoDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                if (comboBox_TiposPerActivo.Text == "EMPRESA")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                textbox_ActivoDesc.Text, "%", "%", "%", "%", "%", "%", "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "SEDE")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", textbox_ActivoDesc.Text, "%", "%", "%", "%", "%", "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "GERENCIA")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", textbox_ActivoDesc.Text, "%", "%", "%", "%", "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "AREA")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", textbox_ActivoDesc.Text, "%", "%", "%", "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "DNI")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", textbox_ActivoDesc.Text, "%", "%", "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "USUARIO")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", textbox_ActivoDesc.Text, "%", "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "ACTIVO")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", textbox_ActivoDesc.Text, "%"
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "ESTADO ACTIVO")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", textbox_ActivoDesc.Text
                , "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "ORIGEN")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , textbox_ActivoDesc.Text, "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "MARCA")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , "%", textbox_ActivoDesc.Text, "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "MODELO")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , "%", "%", textbox_ActivoDesc.Text, "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "SERIE")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , "%", "%", "%", textbox_ActivoDesc.Text, "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "IMEI")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , "%", "%", "%", "%", textbox_ActivoDesc.Text, "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "MAC ETHERNET")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , "%", "%", "%", "%", "%", textbox_ActivoDesc.Text, "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
                if (comboBox_TiposPerActivo.Text == "MAC WIFI")
                {
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = cn_logistica.ListaAsignacionFiltroTI(
                "%", "%", "%", "%", "%", "%", "%", "%"
                , "%", "%", "%", "%", "%", "%", textbox_ActivoDesc.Text);
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                }
            }

        }

        private void toolStripButton_PrintQR_Click(object sender, EventArgs e)
        {
            ce_equipoti.EmpresaEquipo = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            ce_equipoti.SedeEquipo = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            ce_equipoti.AreaEquipo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            ce_equipoti.DniRespEquipo = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            ce_equipoti.UsuarioEquipo = dataGridView2.CurrentRow.Cells[7].Value.ToString();

            ce_equipoti.TipoEquipo = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            ce_equipoti.SerieEquipo = dataGridView2.CurrentRow.Cells[13].Value.ToString();

            //ce_equipoti.FechaEntregaEquipo = 
            //  Convert.ToDateTime(dataGridView2.CurrentRow.Cells[12].Value).Date;

            try
            {
                ImprimirQR();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void ImprimirQR()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Asignacion.Ds_RepAsignacion objDsRepVenta = new Reportes.Frm_Asignacion.Ds_RepAsignacion();
            string Tipo;
            string Descripcion;

            if (comboBox_TiposPerActivo.Text == "SELECCIONE")
            {
                Tipo = "TODOS";
                Descripcion = "TODOS";
            }
            else
            {
                Tipo = comboBox_TiposPerActivo.Text;
                Descripcion = textbox_ActivoDesc.Text;
                //string TotAnulado = textBox_TotalAnulado.Text;
                //string TotNoAnulado = textBox_TotalNoAnulado.Text;
                //string Total = textBox_total.Text;
                //DateTime FecIni = dateTimePicker_F_ini.Value.Date;
                //DateTime FecFin = dateTimePicker_F_ini.Value.Date;
            }

            objDsRepVenta.Tables[0].Rows.Add
            (new object[]{
                Tipo,
                Descripcion
            });

            //int filas = dataGridView2.Rows.Count;
            //for (int i = 0; i <= filas - 1; i++)
            //{

            //}

            objDsRepVenta.Tables[5].Rows.Add
                    (new object[]{
                    ce_equipoti.EmpresaEquipo ,
                    ce_equipoti.SedeEquipo ,
                    ce_equipoti.DniRespEquipo,
                    ce_equipoti.UsuarioEquipo ,
                    ce_equipoti.TipoEquipo ,
                    ce_equipoti.SerieEquipo,
                    ce_equipoti.AreaEquipo,

                    ce_equipoti.FechaEntregaEquipo
                    });


            Reportes.Frm_Asignacion.CrystalPrintSerieEquipo objCryRep = new Reportes.Frm_Asignacion.CrystalPrintSerieEquipo();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalPrintSerieEquipo.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }

        private void toolStripSeparator14_Click(object sender, EventArgs e)
        {

        }
    }

}
