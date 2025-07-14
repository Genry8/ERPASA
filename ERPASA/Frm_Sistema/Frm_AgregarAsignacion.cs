using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    public partial class Frm_AgregarAsignacion : Form, VarDatosEntroFormBPA
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
        public Frm_AgregarAsignacion()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_AgregarAsignacion_Load(object sender, EventArgs e)
        {
            if (textBox_CodAsig.Text == "")
            {
                toolStripButton_guardar.Enabled = false;
                toolStripButton_editar.Enabled = false;
                toolStripButton_eliminar.Enabled = false;
                toolStripButton_limpiar.Enabled = false;
                toolStripButton_nuevo.Enabled = true;
                CargarDatosComboBox();
                CargarPanelgeneral();
                //toolStripButton_nuevo_Click(this, new KeyPressEventArgs((char)(Keys.Enter)));
            }

            //LLAMAR EN TEXBOX AL ULTIMO CODIGO DE MARCA +1 

            //LABEL            
            PonerOscuroComboBox();
            PonerMayusculaTexBox();
            BloquearTextboxCombobox();
            esconderpaneles();
            dataGridView2.ClearSelection();

            dataGridView2.Columns.Clear();
            ColumnasDtgv();

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
            toolStripButton_ActivoEditar.Enabled = false;
            toolStripButton_ActivoEliminar.Enabled = false;
            //LABEL            
            PonerOscuroComboBox();
            PonerMayusculaTexBox();
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
            DataGridViewTextBoxColumn Activo = new DataGridViewTextBoxColumn();
            Activo.HeaderText = "Activo";
            Activo.Name = "Column3";
            Activo.Width = 87;
            dataGridView2.Columns.Add(Activo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn marca = new DataGridViewTextBoxColumn();
            marca.HeaderText = "Marca";
            marca.Name = "Column3";
            marca.Width = 87;
            dataGridView2.Columns.Add(marca);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Modelo = new DataGridViewTextBoxColumn();
            Modelo.HeaderText = "Modelo";
            Modelo.Name = "Column6";
            Modelo.Width = 87;
            dataGridView2.Columns.Add(Modelo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Serie = new DataGridViewTextBoxColumn();
            Serie.HeaderText = "Serie";
            Serie.Name = "Column4";
            Serie.Width = 87;
            dataGridView2.Columns.Add(Serie);
            //
            //
            //
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Estado Activo";
            combo.Name = "Column6";
            combo.Width = 88;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();

            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_logistica.ListaCBEstActivoAsignacionTI(); //ListaCBEstActivoAsignacionTI();

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }

            //AÑADIR LA LISTA AL COMBO
            combo.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView2.Columns.Add(combo);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Accesorios = new DataGridViewTextBoxColumn();
            Accesorios.HeaderText = "Accesorios";
            Accesorios.Name = "Column5";
            Accesorios.Width = 87;
            dataGridView2.Columns.Add(Accesorios);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Obs2 = new DataGridViewTextBoxColumn();
            Obs2.HeaderText = "Obs";
            Obs2.Name = "Column7";
            Obs2.Width = 56;
            dataGridView2.Columns.Add(Obs2);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Numero = new DataGridViewTextBoxColumn();
            Numero.HeaderText = "Numero";
            Numero.Name = "Column7";
            Numero.Width = 56;
            dataGridView2.Columns.Add(Numero);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Cantidad = new DataGridViewTextBoxColumn();
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Column7";
            Cantidad.Width = 56;
            dataGridView2.Columns.Add(Cantidad);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Ubic = new DataGridViewTextBoxColumn();
            Ubic.HeaderText = "Ubicacion";
            Ubic.Name = "Column7";
            Ubic.Width = 56;
            dataGridView2.Columns.Add(Ubic);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
            Estado.HeaderText = "Estado";
            Estado.Name = "Column8";
            Estado.Width = 73;
            dataGridView2.Columns.Add(Estado);


            //Column14

            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            // combo.HeaderText = "Opcion";
            // combo.Name = "Column14";
            // combo.Width = 88;
            // //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            // ArrayList row = new ArrayList();

            // //declara una tabla donde se llama la lista de los estados
            // DataTable dt = new DataTable();
            // dt = cn_datosventa.ListEstadFac();

            // foreach (DataRow item in dt.Rows)
            // {
            //     row.Add(item[0].ToString());
            // }

            // //AÑADIR LA LISTA AL COMBO
            // combo.Items.AddRange(row.ToArray());
            // //AÑADIR EL COMBO AL DATAGRIDVIEW
            // dataGridView2.Columns.Add(combo);


            //Column15 AGREGAR NUEVA



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
            textBox_DevEvent.Text = "";
            textBox_Dni.Text = "";
            textBox_Usuario.Text = "";
        }

        public void BloquearTextboxCombobox()
        {
            textBox_CodAsig.Enabled = false;
            textBox_DevEvent.Enabled = false;
            textBox_Dni.Enabled = false;
            textBox_Usuario.Enabled = false;
            //
            comboBox_CodEmp.Enabled = false;
            comboBox_CodSede.Enabled = false;
            comboBox_CodArea.Enabled = false;
            //
            button_BuscarUsuario.Enabled = false;
            //
            dateTimePicker_F_Entrega.Enabled = false;
            dateTimePicker_F_Deolucion.Enabled = false;
            //
            dataGridView2.Enabled = false;
            //
            toolStripButton_ActivoAgregar.Enabled = false;
        }

        public void DesbloquearTextboxCombobox()
        {
            textBox_DevEvent.Enabled = true;
            textBox_Dni.Enabled = true;
            //textBox_Usuario.Enabled = true;
            //
            comboBox_CodEmp.Enabled = true;
            comboBox_CodSede.Enabled = true;
            comboBox_CodArea.Enabled = true;
            //
            button_BuscarUsuario.Enabled = true;
            //
            dateTimePicker_F_Entrega.Enabled = true;
            dateTimePicker_F_Deolucion.Enabled = true;
            //
            dataGridView2.Enabled = true;
            //
            toolStripButton_ActivoAgregar.Enabled = true;
        }

        public void PonerOscuroComboBox()
        {
            comboBox_CodEmp.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodArea.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void PonerMayusculaTexBox()
        {
            textBox_DevEvent.CharacterCasing = CharacterCasing.Upper;
            textBox_Usuario.CharacterCasing = CharacterCasing.Upper;
            //textBox_MACEther.CharacterCasing = CharacterCasing.Upper;
            //textbox_MACWifi.CharacterCasing = CharacterCasing.Upper;
            //textBox_MACEquipo.CharacterCasing = CharacterCasing.Upper;
        }

        public void CargarDatosComboBox()
        {
            ////CARGAR ESTADO
            //comboBox_Estado.DataSource = cn_regproducto.ListCond();
            //comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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

            ////CARGAR ESTADO ACTIVO
            //comboBox_EstadoActivo.DataSource = cn_logistica.ListaCBEstActivoAsignacionTI();
            //comboBox_EstadoActivo.DisplayMember = "DesEst"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_EstadoActivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        public void CargarPanelgeneral()
        {
            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            //toolStripButton_editar.Enabled = false;
            if (textBox_CodAsig.Text == "")
            {
                toolStripButton_guardar.Enabled = false;
                toolStripButton_editar.Enabled = false;
                toolStripButton_eliminar.Enabled = false;
                toolStripButton_limpiar.Enabled = false;
                toolStripButton_nuevo.Enabled = true;
            }

            //LLAMAR EN TEXBOX AL ULTIMO CODIGO DE MARCA +1 
            cn_logistica.BuscUltimoCodAsignacionTIMas();
            if (ce_logistica.codigo.ToString() == "")
            {
                textBox_CodAsig.Text = "M0000001";
            }
            else
            {
                textBox_CodAsig.Text = "M" + ce_logistica.codigo.ToString("D7");
            }
            //LABEL            
            PonerOscuroComboBox();
            PonerMayusculaTexBox();
            dataGridView2.ClearSelection();
            //
            //CARGAR CONDICION DEL PRODUCTO
            //comboBox_Estado.DataSource = cn_regproducto.ListCond();
            //comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR SEDE DADO LA CONDICION DE EMPRESA
            if (comboBox_CodEmp.Text == comboBox_CodEmp.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_CodSede.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_CodEmp.Text);
                comboBox_CodSede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_CodSede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        public void CargarNuevoCodigo()
        {
            cn_logistica.BuscUltimoCodAsignacionTIMas();
            if (ce_logistica.codigo.ToString() == "")
            {
                textBox_CodAsig.Text = "M0000001";
            }
            else
            {
                textBox_CodAsig.Text = "M" + ce_logistica.codigo.ToString("D7");
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
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            textBox_salida.Focus();
            Guardar();

        }

        private void Guardar()
        {
            if (dataGridView2.RowCount > 1)
            {
                if (textBox_Dni.Text != "")
                {
                    if (textBox_Usuario.Text != "")
                    {

                        cn_logistica.BuscExisteCodAsignacionTI(textBox_CodAsig.Text);
                        if (textBox_CodAsig.Text == ce_logistica.CodTiExist)
                        {
                            string MessageBoxTitle = "Actualizar";
                            string MessageBoxContent = "¿Desea actualizar?";

                            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dataGridView2.AllowUserToAddRows = false;

                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    ce_logistica.itemTI = Convert.ToInt32(row.Cells[0].Value?.ToString()); //@Item
                                    ce_logistica.codperTI = row.Cells[1].Value?.ToString(); //@codper
                                    ce_logistica.EstadoTI = row.Cells[7].Value?.ToString(); //@codper

                                    //objdatlogisticaneg.ActuaAsignacionActTI(
                                    //    textBox_CodAsig.Text,
                                    //    ce_logistica.itemTI,
                                    //    ce_logistica.codperTI,
                                    //    comboBox_CodEmp.SelectedValue.ToString(),
                                    //    comboBox_CodSede.SelectedValue.ToString(),
                                    //    comboBox_CodArea.SelectedValue.ToString(),
                                    //    textBox_Dni.Text,
                                    //    comboBox_EstadoActivo.SelectedValue.ToString(),
                                    //    textBox_DevEvent.Text,
                                    //    textBox_Obs1.Text,
                                    //    textBox_Obs2.Text,
                                    //    textBox_Numero.Text,
                                    //    textBox_Cant.Text,
                                    //    textBox_Ubicacion.Text,
                                    //    dateTimePicker_F_Entrega.Value,
                                    //    dateTimePicker_F_Deolucion.Value,
                                    //    comboBox_Estado.SelectedValue.ToString(),
                                    //    //ce_usuario.FechaSistema(),
                                    //    //ce_usuario.usecod,
                                    //    //ce_usuario.HostName(),
                                    //    ce_usuario.FechaSistema(),
                                    //    ce_usuario.usecod

                                    //);

                                }
                                dataGridView2.AllowUserToAddRows = true;

                                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ACTUALIZADO", Color.FromArgb(13, 93, 140), 1);
                                ng.ShowDialog();
                                this.Close();

                            }
                        }

                        else if (textBox_CodAsig.Text != ce_logistica.CodTiExist)
                        {
                            string MessageBoxTitle = "Guardar";
                            string MessageBoxContent = "¿Desea Guardar?";

                            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {

                                dataGridView2.AllowUserToAddRows = false;
                                CargarNuevoCodigo();

                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    ce_logistica.itemTI = Convert.ToInt32(row.Cells[0].Value?.ToString()); //@Item
                                    ce_logistica.CodActAsigTI = row.Cells[1].Value?.ToString(); //@codasig
                                    ce_logistica.EstAsigTI = row.Cells[6].Value?.ToString(); //@estasig
                                    ce_logistica.Obs1AsigTI = row.Cells[7].Value?.ToString(); //@estasig
                                    ce_logistica.Obs2AsigTI = row.Cells[8].Value?.ToString(); //@estasig
                                    ce_logistica.NumAsigTI = row.Cells[9].Value?.ToString(); //@estasig
                                    ce_logistica.CantAsigTI = row.Cells[10].Value?.ToString(); //@estasig
                                    ce_logistica.UbicAsigTI = row.Cells[11].Value?.ToString(); //@estasig
                                    ce_logistica.EstadoTI = row.Cells[12].Value?.ToString(); //@codper

                                    cn_logistica.GuardAsignacionActTI(
                                        textBox_CodAsig.Text,
                                        ce_logistica.itemTI,
                                        ce_logistica.CodActAsigTI,
                                        comboBox_CodEmp.SelectedValue.ToString(),
                                        comboBox_CodSede.SelectedValue.ToString(),
                                        comboBox_CodArea.SelectedValue.ToString(),
                                        textBox_Dni.Text,
                                        ce_logistica.EstAsigTI,
                                        textBox_DevEvent.Text,
                                        ce_logistica.Obs1AsigTI,
                                        ce_logistica.Obs2AsigTI,
                                        ce_logistica.NumAsigTI,
                                        ce_logistica.CantAsigTI,
                                        ce_logistica.UbicAsigTI,
                                        dateTimePicker_F_Entrega.Value,
                                        dateTimePicker_F_Deolucion.Value,
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

                    }


                    else
                    {
                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE NOMBRE USUARIO", Color.Goldenrod, 4);
                        ng.ShowDialog();
                    }
                }
                else
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE DNI", Color.Goldenrod, 4);
                    ng.ShowDialog();
                }
            }
            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("AGREGUE ACTIVO", Color.Goldenrod, 4);
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
                        "%",
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

            else if (textBox_CodAsig.Text != ce_logistica.CodTiExist)
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
            textBox_DevEvent.Focus();
        }


        public void TablaAgregarDatosFila(DataGridViewRow fila1a)
        {
            textBox_Dni.Text = fila1a.Cells[0].Value.ToString();
            textBox_Usuario.Text = fila1a.Cells[1].Value.ToString() + ' ' + fila1a.Cells[2].Value.ToString();

        }

        public void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a)
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
                    toolStripButton_ActivoEditar.Enabled = false;
                    toolStripButton_ActivoEliminar.Enabled = false;
                    break;
                }
            }

            if (EncontrarFilaRepetida != true)
            {
                dataGridView2.Rows.Add(
                    "",
                    fila1a.Cells[0].Value, //Codigo
                    fila1a.Cells[1].Value, //Activo
                    fila1a.Cells[3].Value, //Marca
                    fila1a.Cells[4].Value, //Modelo
                    fila1a.Cells[5].Value, //Serie 
                    fila1a.Cells[2].Value,                 //EstaActivo
                    "NINGUNO",             //Obs2
                    "NINGUNO",             //Obs1
                    "NINGUNO",             //Numero
                    "1",                  //Cantidad
                    "S/U",                //Ubicacion
                    "S"                   //Estado
                    );

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.ReadOnly = true;
                dataGridView2.ClearSelection();
                toolStripButton_ActivoEditar.Enabled = false;
                toolStripButton_ActivoEliminar.Enabled = false;
            }

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
            toolStripButton_ActivoEditar.Enabled = false;
            toolStripButton_ActivoEliminar.Enabled = false;
            cn_logistica.BuscExisteCodActivoTI(textBox_CodAsig.Text);
            if (textBox_CodAsig.Text == ce_logistica.CodTiExist)
            {
                OrigenColorfila();
            }

        }

        private void dataGridView2_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cn_logistica.BuscExisteCodAsignacionTI(textBox_CodAsig.Text);
            for (int a = 0; a <= e.RowIndex; a++)
            {
                if (dataGridView2.Rows[a].Cells[1].Value == null)
                {
                    if (textBox_CodAsig.Text != ce_logistica.CodTiExist)
                    {
                        if (e.ColumnIndex == 1)
                        {
                            dataGridView2.AllowUserToAddRows = false;
                            frm_BuscarAsignacion frbm = new frm_BuscarAsignacion();
                            AddOwnedForm(frbm);
                            frbm.ShowDialog();
                            dataGridView2.AllowUserToAddRows = true;
                        }
                    }
                    else if (textBox_CodAsig.Text == ce_logistica.CodTiExist)
                    {
                        ce_logistica.CodActTI = textBox_CodAsig.Text;

                        Frm_ModificarAsignacion obj = new Frm_ModificarAsignacion();
                        obj.textBox_CodAsig.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                        obj.comboBox_CodEmp.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                        obj.comboBox_CodSede.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                        obj.comboBox_CodArea.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                        obj.textBox_Dni.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                        obj.textBox_Usuario.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

                        //CARGAR CONDICION DEL PRODUCTO
                        obj.comboBox_Estado.DataSource = cn_regproducto.ListCond();
                        obj.comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                        obj.comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

                        obj.comboBox_Estado.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                        obj.toolStripButton_guardar.Enabled = false;

                        if (obj.comboBox_Estado.Text == "ANULADO")
                        {
                            obj.toolStripButton_eliminar.Enabled = false;
                        }
                        obj.ShowDialog();

                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAsig.Text);
                        dataGridView2.AllowUserToAddRows = false;
                        OrigenColorfila();
                        dataGridView2.ClearSelection();

                    }
                }
            }
        }


        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.ReadOnly = false;
            for (int a = 0; a <= e.RowIndex; a++)
            {
                if (dataGridView2.Rows[a].Cells[2].Value == null)
                {
                    dataGridView2.Rows[a].Cells[0].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[1].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[2].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[3].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[4].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[5].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[6].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[7].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[8].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[9].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[10].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[11].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[12].ReadOnly = true;
                }

                else if (dataGridView2.Rows[a].Cells[2].Value != null)
                {
                    dataGridView2.Rows[a].Cells[0].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[1].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[2].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[3].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[4].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[5].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[6].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[7].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[8].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[9].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[10].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[11].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[12].ReadOnly = true;
                }
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i <= e.RowIndex; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].Value == null)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = "NINGUNO";
                }
                if (dataGridView2.Rows[i].Cells[8].Value == null)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[8].Value = "NINGUNO";
                }
                if (dataGridView2.Rows[i].Cells[9].Value == null)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[9].Value = 0;
                }
                if (dataGridView2.Rows[i].Cells[10].Value == null)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[10].Value = 1;
                }
                if (dataGridView2.Rows[i].Cells[11].Value == null)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[11].Value = "S/U";
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
            toolStripButton_ActivoEditar.Enabled = true;
            toolStripButton_ActivoEliminar.Enabled = true;

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
                e.Handled = true;
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

        private void toolStripButton_ActivoAgregar_Click(object sender, EventArgs e)
        {
            cn_logistica.BuscExisteCodAsignacionTI(textBox_CodAsig.Text);
            if (textBox_CodAsig.Text != ce_logistica.CodTiExist)
            {
                dataGridView2.AllowUserToAddRows = false;
                frm_BuscarAsignacion frbm = new frm_BuscarAsignacion();
                AddOwnedForm(frbm);
                frbm.ShowDialog();
                dataGridView2.AllowUserToAddRows = true;

                toolStripButton_ActivoEditar.Enabled = false;
                toolStripButton_ActivoEliminar.Enabled = false;

            }
            else if (textBox_CodAsig.Text == ce_logistica.CodTiExist)
            {
                ce_logistica.CodActTI = textBox_CodAsig.Text;
                ce_logistica.ContGridTI = dataGridView2.Rows.Count + 1;
                frm_BuscarAsigAct frbm = new frm_BuscarAsigAct();
                AddOwnedForm(frbm);
                frbm.ShowDialog();

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAsig.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();

            }
        }

        private void toolStripButton_ActivoEditar_Click(object sender, EventArgs e)
        {
            cn_logistica.BuscExisteCodAsignacionTI(textBox_CodAsig.Text);
            if (textBox_CodAsig.Text == ce_logistica.CodTiExist)
            {
                ce_logistica.CodActTI = textBox_CodAsig.Text;

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
                dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAsig.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();

            }
        }

        private void toolStripButton_ActivoEliminar_Click(object sender, EventArgs e)
        {
            cn_logistica.BuscExisteCodActivoPerTI(textBox_CodAsig.Text, dataGridView2.CurrentRow.Cells[1].Value.ToString());

            if (textBox_CodAsig.Text == ce_logistica.CodTiExist
            && dataGridView2.CurrentRow.Cells[1].Value.ToString() == ce_logistica.codperTI)
            {
                objdatlogisticaneg.EliminActivoPer2TI(ce_logistica.CodTiExist, dataGridView2.CurrentRow.Cells[1].Value.ToString());
                //Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("YA FUE AÑADIDO", Color.Red, 3);
                //ng.ShowDialog();

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(textBox_CodAsig.Text);
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                dataGridView2.ClearSelection();
            }
        }

        private void button_BuscarUsuario_Click(object sender, EventArgs e)
        {
            frm_BuscarPersonal frbm = new frm_BuscarPersonal();
            AddOwnedForm(frbm);
            frbm.ShowDialog();

        }

        private void textBox_Dni_DoubleClick(object sender, EventArgs e)
        {
            //frm_BuscarPersonal frbm = new frm_BuscarPersonal();
            //AddOwnedForm(frbm);
            //frbm.ShowDialog();
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
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
                        MessageBox.Show("Usuario no encontrado");
                    }
                }
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

        private void textBox_Dni_TextChanged(object sender, EventArgs e)
        {

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

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 10)
            {
                if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back //&&
                //e.KeyChar != '.'
                )
                {
                    e.Handled = true;
                }
                //else
                //{
                //    if (e.KeyChar == '.')
                //    {
                //        if (((TextBox)sender).Text.Contains('.'))
                //            e.Handled = true;
                //        else
                //            e.Handled = false;
                //    }
                //}
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 10)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView2_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView2_KeyPress);
                }
            }
        }

        private void panel_titulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    internal interface VarDatosEntroFormBPA
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a);
    }

}
