using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    public partial class Frm_AgregarActivo : Form, VarDatosEntroFormBP
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
        public Frm_AgregarActivo()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_AgregarActivo_Load(object sender, EventArgs e)
        {
            if (textBox_CodAct.Text == "")
            {
                toolStripButton_guardar.Enabled = false;
                toolStripButton_editar.Enabled = false;
                toolStripButton_eliminar.Enabled = false;
                toolStripButton_limpiar.Enabled = false;
                toolStripButton_nuevo.Enabled = true;
                CargarDatosComboBox();
                CargarPanelgeneral();
                toolStripButton_nuevo_Click(this, new KeyPressEventArgs((char)(Keys.Enter)));
            }

            //LLAMAR EN TEXBOX AL ULTIMO CODIGO DE MARCA +1 

            //LABEL            
            comboBox_generacion.SelectedIndex = 0;
            PonerOscuroComboBox();
            PonerMayusculaTexBox();
            BloquearTextboxCombobox();
            esconderpaneles();
            dataGridView2.ClearSelection();

            dataGridView2.ReadOnly = true;

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        public void CargarPanelgeneralActivo()
        {
            dataGridView2.Columns.Clear();
            //NO PERMITIR EDITAR COLUMAS
            dataGridView2.ReadOnly = true;
            //dataGridView2.AllowUserToAddRows = false;

            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            toolStripButton_PerifericoEditar.Enabled = false;
            toolStripButton_PerifericoEliminar.Enabled = false;
            //LABEL            
            PonerOscuroComboBox();
            PonerMayusculaTexBox();
            ColumnasDtgv();
        }


        private void ColumnasDtgv()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Item = new DataGridViewTextBoxColumn();
            Item.HeaderText = "Item";
            Item.Name = "Column1";
            Item.Width = 85;
            dataGridView2.Columns.Add(Item);
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
            DataGridViewTextBoxColumn Color = new DataGridViewTextBoxColumn();
            Color.HeaderText = "Periferico";
            Color.Name = "Column3";
            Color.Width = 87;
            dataGridView2.Columns.Add(Color);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Serie = new DataGridViewTextBoxColumn();
            Serie.HeaderText = "Serie";
            Serie.Name = "Column4";
            Serie.Width = 87;
            dataGridView2.Columns.Add(Serie);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Imei = new DataGridViewTextBoxColumn();
            Imei.HeaderText = "IMEI";
            Imei.Name = "Column5";
            Imei.Width = 87;
            dataGridView2.Columns.Add(Imei);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Modelo = new DataGridViewTextBoxColumn();
            Modelo.HeaderText = "Modelo";
            Modelo.Name = "Column6";
            Modelo.Width = 87;
            dataGridView2.Columns.Add(Modelo);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Comentario = new DataGridViewTextBoxColumn();
            Comentario.HeaderText = "Comentario";
            Comentario.Name = "Column7";
            Comentario.Width = 56;
            dataGridView2.Columns.Add(Comentario);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
            Estado.HeaderText = "Estado";
            Estado.Name = "Column8";
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

        private void esconderpaneles()
        {
            panel_secundario.Visible = false;
            panel_periferico.Visible = false;
        }

        //private void mostrarbotones()
        //{
        //    button_general.Visible = true;
        //    button_datoslaborales.Visible = true;
        //    button_formacionacademica.Visible = true;
        //    button_planilla.Visible = true;
        //    button_otrosdatos.Visible = true;
        //}

        private void HideSubMenu()
        {
            if (panel_general.Visible == true)
                panel_general.Visible = false;
            panel_secundario.Visible = false;
            panel_periferico.Visible = false;
            if (panel_secundario.Visible == true)
                panel_secundario.Visible = false;
            panel_general.Visible = false;
            panel_periferico.Visible = false;
            if (panel_periferico.Visible == true)
                panel_periferico.Visible = false;
            panel_general.Visible = false;
            panel_secundario.Visible = false;
        }

        private void ShowSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
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
            textBox_NumOrd.Text = "";
            textBox_Serie.Text = "";
            textBox_IMEI.Text = "";
            textBox_MACEther.Text = "";
            textbox_MACWifi.Text = "";
            textBox_MACEquipo.Text = "";
            textBox_NumCelular.Text = "";
            textBox_Obs1.Text = "";
            textBox_Obs2.Text = "";
        }

        public void BloquearTextboxCombobox()
        {
            textBox_CodAct.Enabled = false;
            textBox_NumOrd.Enabled = false;
            textBox_Serie.Enabled = false;
            textBox_IMEI.Enabled = false;
            textBox_MACEther.Enabled = false;
            textbox_MACWifi.Enabled = false;
            textBox_MACEquipo.Enabled = false;
            textBox_NumCelular.Enabled = false;
            textBox_Obs1.Enabled = false;
            textBox_Obs2.Enabled = false;
            comboBox_generacion.Enabled = false;
            //
            comboBox_TipAct.Enabled = false;
            comboBox_CodOrg.Enabled = false;
            comboBox_CodSisOpe.Enabled = false;
            comboBox_CodProc.Enabled = false;
            comboBox_CodMem.Enabled = false;
            comboBox_CodDD.Enabled = false;
            comboBox_CodMar.Enabled = false;
            comboBox_CodMod.Enabled = false;
            comboBox_CodProv.Enabled = false;
            comboBox_PlanMovil.Enabled = false;
            comboBox_Estado.Enabled = false;
            comboBox_EstActivo.Enabled = false;
            //
            dateTimePicker_F_Compra.Enabled = false;
            dateTimePicker_F_Garantia.Enabled = false;
            //
            dataGridView2.Enabled = false;
            //
            toolStripButton_PerifericoAgregar.Enabled = false;
        }

        public void DesbloquearTextboxCombobox()
        {
            textBox_NumOrd.Enabled = true;
            textBox_Serie.Enabled = true;
            textBox_IMEI.Enabled = true;
            textBox_MACEther.Enabled = true;
            textbox_MACWifi.Enabled = true;
            textBox_MACEquipo.Enabled = true;
            textBox_NumCelular.Enabled = true;
            textBox_Obs1.Enabled = true;
            textBox_Obs2.Enabled = true;
            comboBox_generacion.Enabled = true;
            //
            comboBox_TipAct.Enabled = true;
            comboBox_CodOrg.Enabled = true;
            comboBox_CodSisOpe.Enabled = true;
            comboBox_CodProc.Enabled = true;
            comboBox_CodMem.Enabled = true;
            comboBox_CodDD.Enabled = true;
            comboBox_CodMar.Enabled = true;
            comboBox_CodMod.Enabled = true;
            comboBox_CodProv.Enabled = true;
            comboBox_PlanMovil.Enabled = true;
            comboBox_Estado.Enabled = true;
            comboBox_EstActivo.Enabled = true;
            //
            dateTimePicker_F_Compra.Enabled = true;
            dateTimePicker_F_Garantia.Enabled = true;
            //
            dataGridView2.Enabled = true;
            //
            toolStripButton_PerifericoAgregar.Enabled = true;
        }

        public void PonerOscuroComboBox()
        {
            comboBox_TipAct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodOrg.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSisOpe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodProc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodMem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodDD.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodMar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodMod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodProv.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_PlanMovil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_EstActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_generacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void PonerMayusculaTexBox()
        {
            textBox_NumOrd.CharacterCasing = CharacterCasing.Upper;
            textBox_Serie.CharacterCasing = CharacterCasing.Upper;
            textBox_IMEI.CharacterCasing = CharacterCasing.Upper;
            //textBox_MACEther.CharacterCasing = CharacterCasing.Upper;
            //textbox_MACWifi.CharacterCasing = CharacterCasing.Upper;
            //textBox_MACEquipo.CharacterCasing = CharacterCasing.Upper;
            textBox_Obs1.CharacterCasing = CharacterCasing.Upper;
            textBox_Obs2.CharacterCasing = CharacterCasing.Upper;
        }

        public void CargarDatosComboBox()
        {
            //CARGAR ESTADO
            comboBox_Estado.DataSource = cn_regproducto.ListCond();
            comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR TIPO ACTIVO
            comboBox_TipAct.DataSource = cn_logistica.ListaCBTipoActivoTI2();
            comboBox_TipAct.DisplayMember = "DesTA"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_TipAct.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR ORIGEN ACTIVO
            comboBox_CodOrg.DataSource = cn_logistica.ListaCBOrigenActivoTI();
            comboBox_CodOrg.DisplayMember = "DesOrg"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodOrg.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR SISTEMA OPERATIVO
            comboBox_CodSisOpe.DataSource = cn_logistica.ListaCBSisOperativoTI();
            comboBox_CodSisOpe.DisplayMember = "DesSisOpe"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodSisOpe.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR PROCESADOR
            comboBox_CodProc.DataSource = cn_logistica.ListaCBProcesadorTI();
            comboBox_CodProc.DisplayMember = "DesProc"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodProc.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR MEMORIA
            comboBox_CodMem.DataSource = cn_logistica.ListaCBMemoriaTI();
            comboBox_CodMem.DisplayMember = "DesMem"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodMem.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR DISCO DURO
            comboBox_CodDD.DataSource = cn_logistica.ListaCBDiscoDuroTI();
            comboBox_CodDD.DisplayMember = "DesDD"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodDD.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR MARCA
            comboBox_CodMar.DataSource = cn_logistica.ListaCBMarcaTI();
            comboBox_CodMar.DisplayMember = "DesMar"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodMar.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR MODELO
            comboBox_CodMod.DataSource = cn_logistica.ListaCBModeloTI();
            comboBox_CodMod.DisplayMember = "DesMod"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodMod.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR PROVEEDOR
            comboBox_CodProv.DataSource = cn_logistica.ListaCBProveedorTI();
            comboBox_CodProv.DisplayMember = "DesPrv"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodProv.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //ESTADO ACTIVO
            comboBox_EstActivo.DataSource = cn_logistica.ListaCBEstActivoAsignacionTI();
            comboBox_EstActivo.DisplayMember = "DesEst"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_EstActivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR PLAN MOVIL
            comboBox_PlanMovil.DataSource = cn_logistica.ListaCBPlanMovilTI();
            comboBox_PlanMovil.DisplayMember = "DesPln"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_PlanMovil.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        public void CargarPanelgeneral()
        {
            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            //toolStripButton_editar.Enabled = false;
            if (textBox_CodAct.Text == "")
            {
                toolStripButton_guardar.Enabled = false;
                toolStripButton_editar.Enabled = false;
                toolStripButton_eliminar.Enabled = false;
                toolStripButton_limpiar.Enabled = false;
                toolStripButton_nuevo.Enabled = true;
            }

            //LLAMAR EN TEXBOX AL ULTIMO CODIGO DE MARCA +1 
            cn_logistica.BuscUltimoCodActivoTIMas();
            if (ce_logistica.codigo.ToString() == "")
            {
                textBox_CodAct.Text = "A0000001";
            }
            else
            {
                textBox_CodAct.Text = "A" + ce_logistica.codigo.ToString("D7");
            }
            //LABEL            
            PonerOscuroComboBox();
            PonerMayusculaTexBox();
            dataGridView2.ClearSelection();
            //
            //CARGAR CONDICION DEL PRODUCTO
            comboBox_Estado.DataSource = cn_regproducto.ListCond();
            comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        public void ConsultaCodigoNuevo()
        {
            cn_logistica.BuscUltimoCodActivoTIMas();
            if (ce_logistica.codigo.ToString() == "")
            {
                textBox_CodAct.Text = "A0000001";
            }
            else
            {
                textBox_CodAct.Text = "A" + ce_logistica.codigo.ToString("D7");
            }
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
            textBox_MACEquipo.Focus();
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            Guardar();

        }

        private void Guardar()
        {

            if (textBox_Serie.Text != "")
            {
                cn_logistica.BuscExisteCodActivoTIS(textBox_CodAct.Text, textBox_Serie.Text);

                if (textBox_CodAct.Text == ce_logistica.CodTiExist && textBox_Serie.Text == ce_logistica.CodSerieExist)
                {
                    string MessageBoxTitle = "Actualizar";
                    string MessageBoxContent = "¿Desea actualizar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objdatlogisticaneg.ActuaActivoTI(
                        textBox_CodAct.Text,
                        comboBox_TipAct.Text,
                        comboBox_EstActivo.SelectedValue.ToString(),
                        comboBox_CodOrg.SelectedValue.ToString(),
                        comboBox_CodSisOpe.SelectedValue.ToString(),
                        comboBox_CodProc.SelectedValue.ToString(),
                        comboBox_CodMem.SelectedValue.ToString(),
                        comboBox_CodDD.SelectedValue.ToString(),
                        comboBox_CodMar.SelectedValue.ToString(),
                        comboBox_CodMod.SelectedValue.ToString(),
                        comboBox_CodProv.SelectedValue.ToString(),
                        textBox_NumOrd.Text,
                        textBox_NumCelular.Text,
                        comboBox_PlanMovil.SelectedValue.ToString(),
                        textBox_Serie.Text,
                        textBox_IMEI.Text,
                        textBox_MACEther.Text,
                        textbox_MACWifi.Text,
                        textBox_MACEquipo.Text,
                        dateTimePicker_F_Compra.Value,
                        dateTimePicker_F_Garantia.Value,
                        textBox_Obs1.Text,
                        textBox_Obs2.Text,
                        comboBox_Estado.SelectedValue.ToString(),
                        //ce_usuario.FechaSistema(),
                        //ce_usuario.useusr,
                        //ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                    );

                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ACTUALIZADO", Color.FromArgb(13, 93, 140), 1);
                        ng.ShowDialog();
                        this.Close();

                    }
                }

                else //if (textBox_CodAct.Text != ce_logistica.CodTiExist)
                {
                    if (textBox_Serie.Text != ce_logistica.CodSerieExist)
                    {
                        string MessageBoxTitle = "Guardar";
                        string MessageBoxContent = "¿Desea Guardar?";

                        DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ConsultaCodigoNuevo();

                            objdatlogisticaneg.GuardActivoTI(
                            textBox_CodAct.Text,
                            comboBox_TipAct.Text,
                            comboBox_EstActivo.SelectedValue.ToString(),
                            comboBox_CodOrg.SelectedValue.ToString(),
                            comboBox_CodSisOpe.SelectedValue.ToString(),
                            comboBox_CodProc.SelectedValue.ToString(),
                            comboBox_CodMem.SelectedValue.ToString(),
                            comboBox_CodDD.SelectedValue.ToString(),
                            comboBox_CodMar.SelectedValue.ToString(),
                            comboBox_CodMod.SelectedValue.ToString(),
                            comboBox_CodProv.SelectedValue.ToString(),
                            textBox_NumOrd.Text,
                            textBox_NumCelular.Text,
                            comboBox_PlanMovil.SelectedValue.ToString(),
                            textBox_Serie.Text,
                            textBox_IMEI.Text,
                            textBox_MACEther.Text,
                            textbox_MACWifi.Text,
                            textBox_MACEquipo.Text,
                            dateTimePicker_F_Compra.Value,
                            dateTimePicker_F_Garantia.Value,
                            textBox_Obs1.Text,
                            textBox_Obs2.Text,
                            comboBox_Estado.SelectedValue.ToString(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                        );

                            dataGridView2.AllowUserToAddRows = false;

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                ce_logistica.itemTI = Convert.ToInt32(row.Cells[0].Value?.ToString()); //@Item
                                ce_logistica.codperTI = row.Cells[1].Value?.ToString(); //@codper
                                ce_logistica.EstadoTI = row.Cells[7].Value?.ToString(); //@codper

                                cn_logistica.GuardActivoPerTI(
                                    textBox_CodAct.Text,
                                ce_logistica.itemTI,//@item
                                ce_logistica.codperTI, //@codper  
                                ce_logistica.EstadoTI,
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod

                                );

                            }
                            dataGridView2.AllowUserToAddRows = true;


                            Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                            ng.ShowDialog();
                            this.Close();

                            CargarPanelgeneral();
                            Limpiartextbox();
                        }
                    }
                    else
                    {
                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("SERIE YA FUE REGISTRADO", Color.Goldenrod, 4);
                        ng.ShowDialog();
                    }
                }

            }
            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE SERIE", Color.Goldenrod, 4);
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
            Eliminar();
        }

        private void Eliminar()
        {
            cn_logistica.BuscExisteCodActivoTIS(textBox_CodAct.Text, textBox_Serie.Text);
            if (textBox_CodAct.Text == ce_logistica.CodTiExist && textBox_Serie.Text == ce_logistica.CodSerieExist)
            {
                string MessageBoxTitle = "Eliminar";
                string MessageBoxContent = "¿Desea eliminar?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objdatlogisticaneg.EliminActivoTI(textBox_CodAct.Text);
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();
                    Close();
                    CargarPanelgeneral();
                    Limpiartextbox();
                    BloquearTextboxCombobox();
                }
            }

            else //if (textBox_CodAct.Text != ce_logistica.CodTiExist)
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO NO ENCONTRADO", Color.OrangeRed, 3);
                ng.ShowDialog();
            }
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
            toolStripButton_limpiar.Enabled = true;
            textBox_NumOrd.Focus();
        }


        public void TablaAgregarDatosFila(DataGridViewRow fila1a)
        {
            bool EncontrarFilaRepetida = false;
            string valoritem = fila1a.Cells[0].Value.ToString();
            //string valoSTOCK = fila1a.Cells[8].Value.ToString();
            //if(dataGridView2.RowCount > 0)
            //{
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(valoritem))
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("YA FUE AÑADIDO", Color.Goldenrod, 4);
                    ng.ShowDialog();
                    dataGridView2.AllowUserToAddRows = true;
                    EncontrarFilaRepetida = true;
                    dataGridView2.ClearSelection();
                    toolStripButton_PerifericoEditar.Enabled = false;
                    toolStripButton_PerifericoEliminar.Enabled = false;
                    break;
                }
            }

            if (EncontrarFilaRepetida != true)
            {
                dataGridView2.Rows.Add(
                    "",
                    fila1a.Cells[0].Value, //Cod_pro
                    fila1a.Cells[1].Value, //Producto
                    fila1a.Cells[2].Value, //
                    fila1a.Cells[3].Value, //
                    fila1a.Cells[4].Value, //                    
                    fila1a.Cells[5].Value, //
                    fila1a.Cells[6].Value //Estado
                    );

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.ReadOnly = true;
                dataGridView2.ClearSelection();
                toolStripButton_PerifericoEditar.Enabled = false;
                toolStripButton_PerifericoEliminar.Enabled = false;
            }

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

        private void button_general_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_general);
        }

        private void button_datossecundarios_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_secundario);
        }

        private void button_Perifericos_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_periferico);
            toolStripButton_PerifericoEditar.Enabled = false;
            toolStripButton_PerifericoEliminar.Enabled = false;
            cn_logistica.BuscExisteCodActivoTIS(textBox_CodAct.Text, textBox_Serie.Text);
            if (textBox_CodAct.Text == ce_logistica.CodTiExist && textBox_Serie.Text == ce_logistica.CodSerieExist)
            {
                OrigenColorfila();
            }
        }

        private void dataGridView2_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void toolStripButton_PerifericoAgregar_Click(object sender, EventArgs e)
        {
            cn_logistica.BuscExisteCodActivoTIS(textBox_CodAct.Text, textBox_Serie.Text);
            if (textBox_CodAct.Text != ce_logistica.CodTiExist && textBox_Serie.Text != ce_logistica.CodSerieExist)
            {
                dataGridView2.AllowUserToAddRows = false;
                frm_BuscarPeriferico frbm = new frm_BuscarPeriferico();
                AddOwnedForm(frbm);
                frbm.ShowDialog();
                dataGridView2.AllowUserToAddRows = true;

                toolStripButton_PerifericoEditar.Enabled = false;
                toolStripButton_PerifericoEliminar.Enabled = false;

            }
            else if (textBox_CodAct.Text == ce_logistica.CodTiExist)
            {
                ce_logistica.CodActTI = textBox_CodAct.Text;
                ce_logistica.ContGridTI = dataGridView2.Rows.Count + 1;
                frm_BuscarPerAct frbm = new frm_BuscarPerAct();
                AddOwnedForm(frbm);
                frbm.ShowDialog();

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAct.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();

            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cn_logistica.BuscExisteCodActivoTIS(textBox_CodAct.Text, textBox_Serie.Text);
            for (int a = 0; a <= e.RowIndex; a++)
            {
                if (dataGridView2.Rows[a].Cells[1].Value == null)
                {
                    if (textBox_CodAct.Text != ce_logistica.CodTiExist)
                    {
                        if (e.ColumnIndex == 1)
                        {
                            dataGridView2.AllowUserToAddRows = false;
                            frm_BuscarPeriferico frbm = new frm_BuscarPeriferico();
                            AddOwnedForm(frbm);
                            frbm.ShowDialog();
                            dataGridView2.AllowUserToAddRows = true;
                        }
                    }
                    else if (textBox_CodAct.Text == ce_logistica.CodTiExist)
                    {
                        ce_logistica.CodActTI = textBox_CodAct.Text;

                        Frm_ModificarPeriferico obj = new Frm_ModificarPeriferico();
                        obj.textBox_CodPer.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                        obj.textBox_DesPer.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                        obj.textBox_DesPerSerie.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                        obj.textBox_DesPerIMEI.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                        obj.textBox_DesPerMod.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                        obj.textbox_ObsPer.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

                        //CARGAR CONDICION DEL PRODUCTO
                        obj.comboBox_Est.DataSource = cn_regproducto.ListCond();
                        obj.comboBox_Est.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                        obj.comboBox_Est.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

                        obj.comboBox_Est.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                        obj.toolStripButton_guardar_edtiper.Enabled = false;

                        if (obj.comboBox_Est.Text == "ANULADO")
                        {
                            obj.toolStripButton_eliminar_edit_per.Enabled = false;
                        }
                        obj.ShowDialog();

                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAct.Text);
                        dataGridView2.AllowUserToAddRows = false;
                        OrigenColorfila();
                        dataGridView2.ClearSelection();

                    }
                }
            }
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButton_PerifericoEditar.Enabled = true;
            toolStripButton_PerifericoEliminar.Enabled = true;

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView2.RowCount != 0)
            //{
            //    if (e.ColumnIndex != 0)
            //    {
            //        for (int i = 0; i <= e.RowIndex; i++)
            //        {
            //            if (dataGridView2.Rows[i].Cells[1].Value != null)
            //            {
            //                toolStripButton_PerifericoEditar.Enabled = true;
            //                toolStripButton_PerifericoEliminar.Enabled = true;
            //            }
            //            if (dataGridView2.Rows[i].Cells[1].Value == null)
            //            {
            //                toolStripButton_PerifericoEditar.Enabled = false;
            //                toolStripButton_PerifericoEliminar.Enabled = false;
            //            }
            //        }
            //    }
            //}
        }

        private void textBox_NumCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.')
            {
                //e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
        }

        private void dataGridView2_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void toolStripButton_PerifericoEditar_Click(object sender, EventArgs e)
        {
            cn_logistica.BuscExisteCodActivoTIS(textBox_CodAct.Text, textBox_Serie.Text);
            if (textBox_CodAct.Text == ce_logistica.CodTiExist && textBox_Serie.Text == ce_logistica.CodSerieExist)
            {
                ce_logistica.CodActTI = textBox_CodAct.Text;

                Frm_ModificarPeriferico obj = new Frm_ModificarPeriferico();
                obj.textBox_CodPer.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.textBox_DesPer.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                obj.textBox_DesPerSerie.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                obj.textBox_DesPerIMEI.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                obj.textBox_DesPerMod.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                obj.textbox_ObsPer.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

                //CARGAR CONDICION DEL PRODUCTO
                obj.comboBox_Est.DataSource = cn_regproducto.ListCond();
                obj.comboBox_Est.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                obj.comboBox_Est.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

                obj.comboBox_Est.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                obj.toolStripButton_guardar_edtiper.Enabled = false;

                if (obj.comboBox_Est.Text == "ANULADO")
                {
                    obj.toolStripButton_eliminar_edit_per.Enabled = false;
                }
                obj.ShowDialog();

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAct.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();

            }
        }

        private void toolStripButton_PerifericoEliminar_Click(object sender, EventArgs e)
        {
            cn_logistica.BuscExisteCodActivoPerTI(textBox_CodAct.Text, dataGridView2.CurrentRow.Cells[1].Value.ToString());

            if (textBox_CodAct.Text == ce_logistica.CodTiExist
            && dataGridView2.CurrentRow.Cells[1].Value.ToString() == ce_logistica.codperTI)
            {
                objdatlogisticaneg.EliminActivoPer2TI(ce_logistica.CodTiExist, dataGridView2.CurrentRow.Cells[1].Value.ToString());
                //Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("YA FUE AÑADIDO", Color.Red, 3);
                //ng.ShowDialog();

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAct.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();
            }

        }

        private void textBox_Serie_TextChanged(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode QRCode = new QrCode();
            qrEncoder.TryEncode(textBox_Serie.Text.Trim(), out QRCode);

            GraphicsRenderer graphicsRenderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            graphicsRenderer.WriteToStream(QRCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(40, 40)));
            pictureBox_Activo_QR.BackgroundImage = imagen;
            imagen.Save("imagen.png", ImageFormat.Png);

        }
    }

    internal interface VarDatosEntroFormBP
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
    }

}
