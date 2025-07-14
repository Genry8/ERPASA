using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    public partial class Frm_RegInventarios : Form, VarDatosEntroFormInv
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datoscliente objdatclienteneg = new cn_datoscliente();
        cu_excel objexcel = new cu_excel();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 2;
        public Frm_RegInventarios()
        {
            InitializeComponent();
        }

        private void Frm_RegOrdenVenta_Load(object sender, EventArgs e)
        {
            comboBox_Tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Gerencia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Area.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarPanelgeneral();
            BloquearTextboxCombobox();

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
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
            //textBox_comentario.Text = "";
        }

        public void BloquearTextboxCombobox()
        {

        }

        public void DesbloquearTextboxCombobox()
        {

        }

        public void CargarPanelgeneral()
        {
            dataGridView2.Columns.Clear();
            //NO PERMITIR EDITAR COLUMAS
            dataGridView2.ReadOnly = true;

            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;

            //LLAMAR EN TEXBOX LA ULTIMA FACTURA Y SECUENCIA +1 
            objdatventaDAT.UltimaSecuenciaText();

            //ColumnasDtgv();
            dataGridView2.DataSource = cn_equipoti.BuscaEquipoTI(comboBox_Tipo.Text, comboBox_Empresa.Text, comboBox_Sede.Text, comboBox_Gerencia.Text, comboBox_Area.Text);
            dataGridView2.ClearSelection();
            //CARGAR LOS COMBOS Y OTROS DATOS AL INICIAR EL FORMULARIO 

            //CARGAR TIPO EQUIPO
            comboBox_Tipo.DataSource = cn_equipoti.ListTipoEquipoTI();
            comboBox_Tipo.DisplayMember = "TipoEquipo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Tipo.ValueMember = "CodTipo"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA
            comboBox_Empresa.DataSource = cn_equipoti.ListEmpresaEquipoTI();
            comboBox_Empresa.DisplayMember = "CodEmpresa"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Empresa.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR SEDE
            comboBox_Sede.DataSource = cn_equipoti.ListSedeEquipoTI();
            comboBox_Sede.DisplayMember = "NombreSede"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Sede.ValueMember = "CodSede"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR GERENCIA
            comboBox_Gerencia.DataSource = cn_equipoti.ListGerenciaEquipoTI();
            comboBox_Gerencia.DisplayMember = "NombreGerencia"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Gerencia.ValueMember = "CodGerencia"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR AREA
            comboBox_Area.DataSource = cn_equipoti.ListAreaEquipoTI();
            comboBox_Area.DisplayMember = "NombreArea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Area.ValueMember = "CodArea"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR ESTADO DOCUMENTO
            //comboBox_estadodocumento.DataSource = cn_datoscliente.ListEstDoc();
            //comboBox_estadodocumento.DisplayMember = "EstadoDoc"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_estadodocumento.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void cmbox_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_tipo_doc.Text == comboBox_tipo_doc.Text)
            //{
            //    comboBox_DocumentoSerie.DataSource = cn_datosventa.ListDocSerie(comboBox_tipo_doc.Text);
            //    comboBox_DocumentoSerie.DisplayMember = "documentos_serie"; //NOMBRE DE LA TABLA
            //    comboBox_DocumentoSerie.ValueMember = "documento_serie"; // NOMBRE DE LA COLUMNA
            //}
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
            DataGridViewTextBoxColumn Item = new DataGridViewTextBoxColumn();
            Item.HeaderText = "ID";
            Item.Name = "Column1";
            Item.Width = 58;
            dataGridView2.Columns.Add(Item);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Cod = new DataGridViewTextBoxColumn();
            Cod.HeaderText = "Empresa";
            Cod.Name = "Column2";
            Cod.Width = 85;
            dataGridView2.Columns.Add(Cod);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Producto = new DataGridViewTextBoxColumn();
            Producto.HeaderText = "Sede";
            Producto.Name = "Column3";
            Producto.Width = 87;
            dataGridView2.Columns.Add(Producto);

            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Marca = new DataGridViewTextBoxColumn();
            Marca.HeaderText = "Gerencia";
            Marca.Name = "Column4";
            Marca.Width = 56;
            dataGridView2.Columns.Add(Marca);
            // 
            // Column5
            // 
            DataGridViewTextBoxColumn Talla = new DataGridViewTextBoxColumn();
            Talla.HeaderText = "Area";
            Talla.Name = "Column5";
            Talla.Width = 73;
            dataGridView2.Columns.Add(Talla);


            // 
            // Column15 AGREGAR NUEVA
            dataGridView2.AllowUserToAddRows = true;
            //dataGridView2.Columns[15].Visible = false;
            // 
            //
        }

        public void SumarTotal()
        {
            decimal total = 0;
            decimal igv = 0;
            decimal subtotal = 0;
            //decimal otros = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                total += Math.Round(Convert.ToDecimal(row.Cells[11].Value), 2);
                igv += Math.Round((Convert.ToDecimal(row.Cells[11].Value)) - (Convert.ToDecimal(row.Cells[11].Value) / (Convert.ToDecimal(1.18))), 2);
                subtotal += Math.Round((Convert.ToDecimal(row.Cells[11].Value) / (Convert.ToDecimal(1.18))), 2);
            }

            //textBox_paaga_con.Text = otros.ToString();
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
            Frm_AgregarEquipo frbm = new Frm_AgregarEquipo();
            AddOwnedForm(frbm);
            frbm.ShowDialog();

        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            ////dataGridView2.AllowUserToAddRows = false;
            //frm_BuscarOrdenVenta frbm = new frm_BuscarOrdenVenta();
            //AddOwnedForm(frbm);
            //frbm.ShowDialog();
        }


        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ce_equipoti.CodigoEquipo = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                ce_equipoti.TipoEquipo = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                ce_equipoti.EmpresaEquipo = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                ce_equipoti.SedeEquipo = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                ce_equipoti.GerenciaEquipo = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                ce_equipoti.AreaEquipo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                ce_equipoti.MarcaEquipo = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                ce_equipoti.ModeloEquipo = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                ce_equipoti.SerieEquipo = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                ce_equipoti.IMEIEquipo = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                ce_equipoti.CargadorEquipo = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                ce_equipoti.MACEthernetEquipo = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                ce_equipoti.MACWifiEquipo = dataGridView2.CurrentRow.Cells[12].Value.ToString();

                Frm_AgregarEquipo obj = new Frm_AgregarEquipo();
                obj.ShowDialog();

                //dataGridView2.AllowUserToAddRows = false;
                //frm_BuscarMedicina frbm = new frm_BuscarMedicina();
                //AddOwnedForm(frbm);
                //frbm.ShowDialog();
                //dataGridView2.AllowUserToAddRows = true;
            }
        }

        private void toolStripButton_aliminar_Click(object sender, EventArgs e)
        {
            EliminarOrden();
        }

        private void EliminarOrden()
        {

        }

        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {

        }

        public void CalcularVuelto()
        {

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
                    break;
                }
            }

            if (EncontrarFilaRepetida != true)
            {
                dataGridView2.Rows.Add(
                    "",
                    fila1a.Cells[0].Value, //Cod_pro
                    fila1a.Cells[1].Value, //Producto
                    fila1a.Cells[2].Value, //Marca
                    fila1a.Cells[3].Value, //Talla
                    fila1a.Cells[4].Value, //Genero
                    "NO ESPECIFICA",//fila1a.Cells[4].Value, //color
                    0, //Cant_f
                    fila1a.Cells[6].Value, //P_unit
                    fila1a.Cells[7].Value, //Des
                    18.0, //Igv
                    0.0, //Tot
                    0.0, //Totbrt
                    "Ninguna", //Obs
                    fila1a.Cells[9].Value, //Estado
                    fila1a.Cells[8].Value //Estado
                    );

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.ReadOnly = true;

            }

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount != 0)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    try
                    {
                        int cant = Convert.ToInt32(row.Cells[7].Value);
                        decimal p_unit = Convert.ToDecimal(row.Cells[8].Value);
                        decimal desc = (Convert.ToDecimal((row.Cells[9].Value)) / (Convert.ToDecimal(100)));

                        row.Cells[11].Value = Math.Round((cant * (p_unit - (p_unit * desc))), 2);
                        row.Cells[12].Value = Math.Round(((cant * (p_unit - (p_unit * desc))) / Convert.ToDecimal(1.18)), 2);

                        button_calcular_Click(this, new KeyPressEventArgs((char)(Keys.Down)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    try
                    {
                        if (e.ColumnIndex == 7)
                        {
                            for (int i = 0; i <= e.RowIndex; i++)
                            {
                                if (dataGridView2.Rows[i].Cells[7].Value == null)
                                {
                                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = 0;
                                }
                                else if (dataGridView2.Rows[i].Cells[7].Value != null)
                                {
                                    if (Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[7].Value) > Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[15].Value))
                                    {
                                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("STOCK MÁXIMO " + int.Parse(dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString()), Color.FromArgb(192, 0, 0), 4);
                                        ng.ShowDialog();
                                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = 0;
                                        dataGridView2.Rows[e.RowIndex].Cells[11].Value = 0.00;
                                        dataGridView2.Rows[e.RowIndex].Cells[12].Value = 0.00;
                                    }

                                }

                                //bool isdouble = double.TryParse(e.FormattedValue.ToString(), out double resultnumerico);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

        }

        private void button_calcular_Click(object sender, EventArgs e)
        {

        }


        private void label_desadc_Click(object sender, EventArgs e)
        {

        }

        private void label_paga_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BuscarClientePorDni();

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

        private void button_buscarcliente_Click(object sender, EventArgs e)
        {
            BuscarClientePorDni();
        }

        private void BuscarClientePorDni()
        {

        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 7)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView2_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView2_KeyPress);
                }
            }

        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 7)
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


        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void textBox_paaga_con_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                SumarTotal();

            }

            else if (!Char.IsDigit(e.KeyChar) &&
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

        private void comboBox_tipoalmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ce_datosventa.Select_almacen = comboBox_Empresa.SelectedValue.ToString();
        }

        private void comboBox_tipoalmacen_DrawItem(object sender, DrawItemEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(Brushes.Red, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    e.Graphics.DrawString(comboBox_Empresa.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(Brushes.Green, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    e.Graphics.DrawString(comboBox_Empresa.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                    break;
                case 2:
                    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    e.Graphics.DrawString(comboBox_Empresa.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                    break;
            }

        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }
    }
    internal interface VarDatosEntroFormInv
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
    }
}
