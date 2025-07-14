using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace ERPASA.Frm_TabMaestra
{
    public partial class Frm_RegistroPersonal : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datospersonal objcndatpers = new cn_datospersonal();
        cn_rolesuser objrolesbicn = new cn_rolesuser();
        cn_apisperu objapi = new cn_apisperu();
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _rectan;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 1;
        public Frm_RegistroPersonal()
        {
            InitializeComponent();
        }

        private void Frm_RegOrdenVenta_Load(object sender, EventArgs e)
        {
            textBox_apellidopat.CharacterCasing = CharacterCasing.Upper;
            textbox_apellidomat.CharacterCasing = CharacterCasing.Upper;
            textbox_nombres.CharacterCasing = CharacterCasing.Upper;
            textBox_desuser.CharacterCasing = CharacterCasing.Upper;
            textBox_domicilio.CharacterCasing = CharacterCasing.Upper;
            textBox_observacionesdg.CharacterCasing = CharacterCasing.Upper;
            //BLOQUEAR BUTONES ARRIBA
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;
            //CARGAR LAS COLUMNAS DE LAS DATAGRIDVIEW
            ColumnasDtgv1();
            ColumnasDtgv2();
            ColumnasDtgv3();
            //CheckboxColum0();
            //lipar datos
            LipiarTextbox();
            //esconder paneles
            esconderpaneles();
            //BLOQUEAR TODOS LOS CAMPOS
            BloquearTextbox();
            //CARGAR LOS COMBOS Y OTROS DATOS AL INICIAR EL FORMULARIO 
            //DATOS GENERALES
            CargarPanelDatosGenerales();
            //DATOS LABORALES
            CargarPanelesDatosLaborales();
            //CARGAR PLANILLA
            CargarPanelesDatosPlanilla();

            //dataGridView4.EndEdit();
            //dataGridView4.AllowUserToAddRows = false;

            this.Padding = new Padding(borderSize);
        }

        public void LipiarTextbox()
        {
            //textbox
            textBox_apellidopat.Text = "";
            textbox_apellidomat.Text = "";
            textbox_nombres.Text = "";
            textBox_desuser.Text = "";
            textBox_domicilio.Text = "";
            textBox_gmail.Text = "";
            textBox_observacionesdg.Text = "";
            textBox_doc_ident.Text = "";
            textBox_Telefono.Text = "";
            textBox_Clave.Text = "";
            textBox_Comentario.Text = "";
            textBox_CodFondoPensiones.Text = "";
        }

        public void BloquearTextbox()
        {
            //Bloquear datagridview
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            dataGridView3.Enabled = false;
            //bloquear button
            button_cargar_foto.Enabled = false;
            button_EliminarFormAcademica.Enabled = false;
            button_vercontraseña.Enabled = false;
            //bloquear text
            textBox_apellidopat.Enabled = false;
            textbox_apellidomat.Enabled = false;
            textbox_nombres.Enabled = false;
            textBox_desuser.Enabled = false;
            textBox_domicilio.Enabled = false;
            textBox_gmail.Enabled = false;
            textBox_observacionesdg.Enabled = false;
            textBox_doc_ident.Enabled = false;
            textBox_Telefono.Enabled = false;
            textBox_Clave.Enabled = false;
            textBox_Comentario.Enabled = false;
            textBox_CodFondoPensiones.Enabled = false;
            textBox_HorasContratadas.Enabled = false;
            textBox_ToleranciaMin.Enabled = false;
            //bloquear combobox
            comboBox_sexo.Enabled = false;
            comboBox_estadocivil.Enabled = false;
            dateTimePicker_FecNacimiento.Enabled = false;
            comboBox_tipo_docIdent.Enabled = false;
            comboBox_TipoProfesional.Enabled = false;
            comboBox_Grupo.Enabled = false;
            comboBox_Establecimiento.Enabled = false;
            comboBox_estado.Enabled = false;
            comboBox_Area.Enabled = false;
            comboBox_Cargo.Enabled = false;
            comboBox_Condicion.Enabled = false;
            comboBox_JefeInmediato.Enabled = false;
            comboBox_FormaDepositoSalarial.Enabled = false;
            dateTimePicker_FecCese.Enabled = false;
            comboBox_RegimenLaboral.Enabled = false;
            comboBox_FondoPensiones.Enabled = false;
            dateTimePicker_hringreso.Enabled = false;
            dateTimePicker_hrsalida.Enabled = false;
            dateTimePicker_VacInicio.Enabled = false;
            dateTimePicker_VacFin.Enabled = false;
        }

        public void DesbloquearTextbox()
        {
            //Bloquear datagridview
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;
            dataGridView3.Enabled = true;
            //bloquear button
            button_cargar_foto.Enabled = true;
            button_EliminarFormAcademica.Enabled = true;
            button_vercontraseña.Enabled = true;
            //bloquear text
            textBox_apellidopat.Enabled = true;
            textbox_apellidomat.Enabled = true;
            textbox_nombres.Enabled = true;
            textBox_desuser.Enabled = true;
            textBox_domicilio.Enabled = true;
            textBox_gmail.Enabled = true;
            textBox_observacionesdg.Enabled = true;
            textBox_Telefono.Enabled = true;
            textBox_Clave.Enabled = true;
            textBox_Comentario.Enabled = true;
            textBox_CodFondoPensiones.Enabled = true;
            textBox_HorasContratadas.Enabled = true;
            textBox_ToleranciaMin.Enabled = true;
            //desbloquear combobox
            comboBox_sexo.Enabled = true;
            comboBox_estadocivil.Enabled = true;
            dateTimePicker_FecNacimiento.Enabled = true;
            comboBox_tipo_docIdent.Enabled = true;
            comboBox_TipoProfesional.Enabled = true;
            comboBox_Grupo.Enabled = true;
            comboBox_Establecimiento.Enabled = true;
            comboBox_estado.Enabled = true;
            comboBox_Area.Enabled = true;
            comboBox_Cargo.Enabled = true;
            comboBox_Condicion.Enabled = true;
            comboBox_JefeInmediato.Enabled = true;
            comboBox_FormaDepositoSalarial.Enabled = true;
            dateTimePicker_FecCese.Enabled = true;
            comboBox_RegimenLaboral.Enabled = true;
            comboBox_FondoPensiones.Enabled = true;
            dateTimePicker_hringreso.Enabled = true;
            dateTimePicker_hrsalida.Enabled = true;
            dateTimePicker_VacInicio.Enabled = true;
            dateTimePicker_VacFin.Enabled = true;
        }

        public void datapikeriniciar()
        {
            dataGridView2.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(datapikercargar);
        }

        public void datapikercargar(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = dtp.Value.ToString();
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "Column2":
                    _rectan = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_rectan.Width, _rectan.Height);
                    dtp.Location = new Point(_rectan.X, _rectan.Y);
                    dtp.Visible = true;
                    break;
            }
        }

        public void CargarPanelDatosGenerales()
        {
            //
            //DATOS GENERALES
            //
            //INICIAR TIMEPIKER EN LA SEGUNDA COLUMNA
            datapikeriniciar();
            //LLAMAR EN TEXBOX AL ULTIMO USUARIO REGISTRADO +1 
            cn_datospersonal.BuscUltimoUser();
            textbox_coduser.Text = ce_datospersonal.CodUser_Max.ToString();
            //MOSTRAR FOTO POR DEFECTO
            pictureBox_fotoperfil.Image = pictureBox_titulo.Image;
            //NO EDITAR LOS COMBOBOX
            comboBox_sexo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_estadocivil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tipo_docIdent.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoProfesional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Grupo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Establecimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_estado.DropDownStyle = ComboBoxStyle.DropDownList;
            //CARGAR GENERO
            comboBox_sexo.DataSource = cn_datoscliente.ListSex();
            comboBox_sexo.DisplayMember = "sexo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_sexo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR ESTADO CIVIL
            comboBox_estadocivil.DataSource = cn_datospersonal.ListEstCivil();
            comboBox_estadocivil.DisplayMember = "EstadoCivil"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_estadocivil.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR TIPO DOCUMENTO DE IDENTIDAD
            comboBox_tipo_docIdent.DataSource = cn_datoscliente.ListDocIdent();
            comboBox_tipo_docIdent.DisplayMember = "TipoDocIdentidad"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_tipo_docIdent.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR TIPO PROFESIONAL
            comboBox_TipoProfesional.DataSource = cn_datospersonal.ListTipProfesion();
            comboBox_TipoProfesional.DisplayMember = "TipoProfesional"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_TipoProfesional.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR GRUPO PROFESIONAL
            comboBox_Grupo.DataSource = cn_datospersonal.ListGrupoProfesion();
            comboBox_Grupo.DisplayMember = "grupoprofesion"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Grupo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR SEDE
            comboBox_Establecimiento.DataSource = cn_datospersonal.ListSede();
            comboBox_Establecimiento.DisplayMember = "Sede"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Establecimiento.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR ESTADO DEL PERSONAL
            comboBox_estado.DataSource = cn_datospersonal.ListEst();
            comboBox_estado.DisplayMember = "EstadoDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        public void CargarPanelesDatosLaborales()
        {
            //
            //DATOS LABORALES
            //
            comboBox_Area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Cargo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Condicion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_JefeInmediato.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FormaDepositoSalarial.DropDownStyle = ComboBoxStyle.DropDownList;
            //CARGAR FECHA DE REGISTRO
            textBox_fecharegistro.Text = ce_usuario.FechaSistema().ToString();
            //CARGAR ÁREA LABORAL
            comboBox_Area.DataSource = cn_datospersonal.ListAreaLab();
            comboBox_Area.DisplayMember = "AreaDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Area.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR CARGO LABORAL
            comboBox_Cargo.DataSource = cn_datospersonal.ListCargaLab();
            comboBox_Cargo.DisplayMember = "CargoDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cargo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR CONDICION LABORAL
            comboBox_Condicion.DataSource = cn_datospersonal.ListConLab();
            comboBox_Condicion.DisplayMember = "CondLaboralDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Condicion.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR JEFE INMEDIATO
            comboBox_JefeInmediato.DataSource = cn_datospersonal.ListJefInmed();
            comboBox_JefeInmediato.DisplayMember = "UsuarioDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_JefeInmediato.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR FORMA DE DEPOSITO SALARIAL
            comboBox_FormaDepositoSalarial.DataSource = cn_datospersonal.ListDepSalario();
            comboBox_FormaDepositoSalarial.DisplayMember = "DepositoDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_FormaDepositoSalarial.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        public void CargarPanelesDatosPlanilla()
        {
            //
            //PLANILLA
            dataGridView2.Columns.Clear();
            ColumnasDtgv2();
            //
            comboBox_RegimenLaboral.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FondoPensiones.DropDownStyle = ComboBoxStyle.DropDownList;
            //CARGAR FORMA DE DEPOSITO SALARIAL
            comboBox_RegimenLaboral.DataSource = cn_datospersonal.ListRegLaboral();
            comboBox_RegimenLaboral.DisplayMember = "RegLaboralDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_RegimenLaboral.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR FONDO PENSIONES
            comboBox_FondoPensiones.DataSource = cn_datospersonal.ListFondoPens();
            comboBox_FondoPensiones.DisplayMember = "PensionesDes"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_FondoPensiones.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //HORAS CONTRATADAS
            textBox_HorasContratadas.Text = "48";
            //MINUTOS DE TOLERANCIA
            textBox_ToleranciaMin.Text = "10";
            //
            //OTROS DATOS DE ALAMCEN
            AgregarColumnaAlmacen();
        }

        private void AgregarColumnaAlmacen()
        {
            dataGridView3.Columns.Clear();
            //dataGridView3.ReadOnly = true;
            DataTable dt = new DataTable();
            dt = cn_datospersonal.ListAlmcen();
            dataGridView3.DataSource = dt;

            DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            estado.HeaderText = "estado";
            dataGridView3.Columns.Insert(0, estado);

            dataGridView3.Columns[2].Visible = false;
            //dataGridView3.Columns[0].DisplayIndex = 3;
            dataGridView3.AllowUserToAddRows = false;
        }

        //DATAGRIDVIEW COLUMNA CHECK BOX

        private void CheckboxColum0()
        {
            //dataGridView3.Enabled = true;
            DataGridViewCheckBoxColumn Item = new DataGridViewCheckBoxColumn();
            Item.HeaderText = "Item";
            Item.Name = "Column1";
            Item.Width = 58;
            dataGridView3.Columns.Insert(0, Item);

            Rectangle rect = dataGridView3.GetCellDisplayRectangle(0, -1, false);
            rect.X = rect.Location.X + (rect.Width / 2);
            rect.Y = rect.Location.Y + (rect.Width / 4);

        }

        //LLENAR DATAGRIDVIEW 1
        private void ColumnasDtgv1()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Item = new DataGridViewTextBoxColumn();
            Item.HeaderText = "Item";
            Item.Name = "Column1";
            Item.Width = 58;
            dataGridView1.Columns.Add(Item);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Descripción = new DataGridViewTextBoxColumn();
            Descripción.HeaderText = "Descripción";
            Descripción.Name = "Column2";
            Descripción.Width = 85;
            dataGridView1.Columns.Add(Descripción);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Observaciones = new DataGridViewTextBoxColumn();
            Observaciones.HeaderText = "Observaciones";
            Observaciones.Name = "Column3";
            Observaciones.Width = 87;
            dataGridView1.Columns.Add(Observaciones);

        }

        //LLENAR DATAGRIDVIEW 2
        private void ColumnasDtgv2()
        {
            // 
            // Column1
            // 
            DataGridViewComboBoxColumn Escolaridad = new DataGridViewComboBoxColumn();
            Escolaridad.HeaderText = "Escolaridad";
            Escolaridad.Name = "Column1";
            Escolaridad.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_datospersonal.ListEscolaridad();

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Escolaridad.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView2.Columns.Add(Escolaridad);

            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Fecha_final = new DataGridViewTextBoxColumn();
            Fecha_final.HeaderText = "Fecha_final";
            Fecha_final.Name = "Column2";
            Fecha_final.Width = 180;
            dataGridView2.Columns.Add(Fecha_final);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Carrera = new DataGridViewTextBoxColumn();
            Carrera.HeaderText = "Observaciones";
            Carrera.Name = "Column3";
            Carrera.Width = 180;
            dataGridView2.Columns.Add(Carrera);
            // 
            // Column4
            //             
            DataGridViewComboBoxColumn Entidad = new DataGridViewComboBoxColumn();
            Entidad.HeaderText = "Entidad";
            Entidad.Name = "Column14";
            Entidad.Width = 280;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row1 = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt1 = new DataTable();
            dt1 = cn_datospersonal.ListEntidad();

            foreach (DataRow item in dt1.Rows)
            {
                row1.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Entidad.Items.AddRange(row1.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView2.Columns.Add(Entidad);

            // 
            // Column15 AGREGAR NUEVA
            //dataGridView2.AllowUserToAddRows = true;
            // 
            //
        }


        //LLENAR DATAGRIDVIEW 1
        private void ColumnasDtgv3()
        {
            // 
            // Column1
            // 
            DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            estado.HeaderText = "estado";
            estado.Name = "Column1";
            estado.Width = 58;
            //estado.ReadOnly = true;            
            dataGridView3.Columns.Add(estado);

            // 
            // Column2
            // 
            DataGridViewTextBoxColumn item = new DataGridViewTextBoxColumn();
            item.HeaderText = "Descripción";
            item.Name = "Column2";
            item.Width = 85;
            dataGridView3.Columns.Add(item);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn AlmacenDes = new DataGridViewTextBoxColumn();
            AlmacenDes.HeaderText = "AlmacenDes";
            AlmacenDes.Name = "Column3";
            AlmacenDes.Width = 87;
            dataGridView3.Columns.Add(AlmacenDes);

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

        //metodo para ESCONDER PANELES
        //METODO PARA DESPLEGAR LOS PANELES
        private void esconderpaneles()
        {
            panel_costos.Visible = false;
            panel_stock.Visible = false;
            panel_codigos.Visible = false;
            panel_otrosdatos.Visible = false;
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
            panel_costos.Visible = false;
            panel_stock.Visible = false;
            panel_codigos.Visible = false;
            panel_otrosdatos.Visible = false;
            if (panel_costos.Visible == true)
                panel_costos.Visible = false;
            panel_general.Visible = false;
            panel_stock.Visible = false;
            panel_codigos.Visible = false;
            panel_otrosdatos.Visible = false;
            if (panel_stock.Visible == true)
                panel_stock.Visible = false;
            panel_general.Visible = false;
            panel_costos.Visible = false;
            panel_codigos.Visible = false;
            panel_otrosdatos.Visible = false;
            if (panel_codigos.Visible == true)
                panel_codigos.Visible = false;
            panel_general.Visible = false;
            panel_costos.Visible = false;
            panel_stock.Visible = false;
            panel_otrosdatos.Visible = false;
            if (panel_otrosdatos.Visible == true)
                panel_otrosdatos.Visible = false;
            panel_general.Visible = false;
            panel_costos.Visible = false;
            panel_stock.Visible = false;
            panel_codigos.Visible = false;
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

        private void textbox_coduser_KeyPress(object sender, KeyPressEventArgs e)
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


        public void BuscarPersonaReniec()
        {
            try
            {
                dynamic respuesta = objapi.Get("https://api.apis.net.pe/v1/dni?numero=" + textBox_doc_ident.Text + "");
                textBox_apellidopat.Text = respuesta.apellidoPaterno.ToString();
                textbox_apellidomat.Text = respuesta.apellidoMaterno.ToString();
                textbox_nombres.Text = respuesta.nombres.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("No fue posible conectar con RENIEC");
            }
        }


        private void textBox_doc_ident_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BuscarPersonalPorDni();
                if (textbox_nombres.Text == "")
                {
                    BuscarPersonaReniec();
                    DesbloquearTextbox();
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

        private void textBox_Telefono_KeyPress(object sender, KeyPressEventArgs e)
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

        public void buscarfactura()
        {
            if (textbox_coduser.Text != "")
            {
                objdatventaneg.BuscaFacturaText(int.Parse(textbox_coduser.Text));
                if (int.Parse(textbox_coduser.Text) == ce_datosventa.fac_buscar)
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("FACTURA ENCONTRADA", Color.YellowGreen, 2);
                    ng.ShowDialog();

                    dataGridView2.DataSource = cn_datosventa.BuscarVentaFac(int.Parse(textbox_coduser.Text));
                    dataGridView2.AllowUserToAddRows = true;

                }

                else if (int.Parse(textbox_coduser.Text) != ce_datosventa.fac_buscar)
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("FACTURA NO REGISTRADA", Color.FromArgb(192, 0, 0), 4);
                    ng.ShowDialog();
                    dataGridView2.Columns.Clear();
                }

            }
            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE FACTURA", Color.Goldenrod, 4);
                ng.ShowDialog();
            }
        }

        public void EliminarFactura()
        {
            if (textbox_coduser.Text != "")
            {
                objdatventaneg.BuscaFacturaText(Int32.Parse(textbox_coduser.Text));
                if (int.Parse(textbox_coduser.Text) != ce_datosventa.fac_buscar)
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("FACTURA NO REGISTRADA", Color.FromArgb(192, 0, 0), 4);
                    ng.ShowDialog();
                }
                else if (int.Parse(textbox_coduser.Text) == ce_datosventa.fac_buscar)
                {
                    string MessageBoxTitle = "Eliminar";
                    string MessageBoxContent = "¿Desea eliminar factura?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something

                        //EliminarFac();                        
                        ce_datosventa.fac_buscar = 0;

                        toolStripButton_buscar.Enabled = true;
                        toolStripLabel_buscar.Enabled = true;

                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("FACTURA ELIMINADO", Color.OrangeRed, 3);
                        ng.ShowDialog();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
            }

            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE FACTURA", Color.Goldenrod, 4);
                ng.ShowDialog();
            }
        }

        public void TablaAgregarDatosFila(DataGridViewRow fila1a)
        {
            bool EncontrarFilaRepetida = false;
            string valoritem = fila1a.Cells[0].Value.ToString();
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
                //foreach (DataGridViewRow dt2 in dataGridView2.Rows)
                //{                 

                dataGridView2.Rows.Add(
                    "",
                    fila1a.Cells[0].Value, //Cod_pro
                    fila1a.Cells[1].Value, //Producto
                    fila1a.Cells[2].Value, //Lab
                    0, //Cant_e
                    0, //Cant_f
                    fila1a.Cells[5].Value, //P_unit
                    fila1a.Cells[6].Value, //Des
                    18.0, //Igv
                    0.0, //Tot
                    0.0, //Totbrt
                    "Ninguna", //Obs
                    "GE",// Estafo_f
                    ""
                    //dataGridView2.CurrentRow.Cells[7].Value //Estado
                    );

                dataGridView2.AllowUserToAddRows = true;
                //}

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
                        int cant_e = Convert.ToInt32(row.Cells[4].Value);
                        decimal p_unit = Convert.ToDecimal(row.Cells[6].Value);

                        row.Cells[9].Value = Math.Round((cant_e * p_unit), 2);
                        row.Cells[10].Value = Math.Round((cant_e * p_unit) - ((cant_e * p_unit) / Convert.ToDecimal(1.18)), 2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_general);
        }

        private void button_datoslaborales_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_costos);
        }

        private void button_formacionacademica_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_stock);
        }

        private void button_planilla_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_codigos);
        }

        private void button_otrosdatos_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_otrosdatos);
        }

        private void button_vercontraseña_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_Clave.PasswordChar == '*')
            {
                textBox_Clave.PasswordChar = '\0';
            }

        }

        private void button_vercontraseña_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_Clave.PasswordChar == '\0')
            {
                textBox_Clave.PasswordChar = '*';
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

        private void textBox_Tolerancia_KeyPress(object sender, KeyPressEventArgs e)
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
            textBox_doc_ident.Enabled = true;
            toolStripButton_buscar.Enabled = false;
            toolStripButton_editar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;
            toolStripButton_guardar.Enabled = true;
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            //
            LipiarTextbox();
            //
            EliminarDatagrid12();
            //DATOS GENERALES            
            CargarPanelDatosGenerales();
            //DATOS LABORALES
            CargarPanelesDatosLaborales();
            //CARGAR PLANILLA
            CargarPanelesDatosPlanilla();
            //DESBLOQUEAR TEXT
            DesbloquearTextbox();
            textBox_doc_ident.Focus();
        }

        public void EliminarDatagrid12()
        {
            DataTable dtp = new DataTable();
            DataTable dtp1 = new DataTable();
            DataTable dtp2 = new DataTable();
            dtp = cn_datospersonal.BuscarPersForAcadem(int.Parse("123"));
            dtp1 = cn_datospersonal.BuscarPersForAcadem(int.Parse("123"));
            dtp2 = cn_datospersonal.BuscarPersForAcadem(int.Parse("123"));
            dataGridView1.DataSource = dtp;
            dataGridView2.DataSource = dtp1;
            dataGridView3.DataSource = dtp2;
            dtp.Rows.Clear();
            dtp.Columns.Clear();
            dtp1.Rows.Clear();
            dtp1.Columns.Clear();
            dtp2.Rows.Clear();
            dtp2.Columns.Clear();
            ColumnasDtgv1();
            ColumnasDtgv2();
            ColumnasDtgv3();
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            BuscarPersonalPorDni();

        }

        private void BuscarPersonalPorDni()
        {
            if (textBox_doc_ident.Enabled == false)
            {
                toolStripButton_aliminar.Enabled = false;
                toolStripButton_guardar.Enabled = false;
                textBox_doc_ident.Enabled = true;
                textBox_doc_ident.Text = "";
                textBox_doc_ident.Focus();
            }

            else if (textBox_doc_ident.Enabled == true)
            {
                if (textBox_doc_ident.Text != "")
                {
                    //textBox_doc_ident.Focus();
                    objcndatpers.BuscaPersExist(Int32.Parse(textBox_doc_ident.Text));
                    objcndatpers.BuscaPersDni(Int32.Parse(textBox_doc_ident.Text));
                    if (textBox_doc_ident.Text == ce_datospersonal.Busc_usedoc.ToString())
                    {
                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL ENCONTRADO", Color.SeaGreen, 2);
                        ng.ShowDialog();
                        //
                        BuscarPersonal();
                        toolStripButton_editar.Enabled = true;
                        toolStripButton_aliminar.Enabled = true;
                        textBox_doc_ident.Enabled = false;
                    }
                    else
                    {
                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL NO REGISTRADO", Color.Goldenrod, 4);
                        ng.ShowDialog();
                    }
                }
                else
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE DNI", Color.Goldenrod, 4);
                    ng.ShowDialog();
                }
            }
        }

        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {
            if (textBox_doc_ident.Text != "123")
            {
                DesbloquearTextbox();
                toolStripButton_guardar.Enabled = true;
            }

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            textBox_paraesconder.Focus();
            if (textbox_coduser.Text != "" | textbox_coduser.Enabled == false)
            {
                //MessageBox.Show("GUARDADO");
                guardarpersonal();
            }

            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE USUARIO", Color.Goldenrod, 4);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_aliminar_Click(object sender, EventArgs e)
        {
            EliminarPersonal();
        }

        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            textBox_doc_ident.Enabled = false;
            toolStripButton_buscar.Enabled = true;
            toolStripButton_editar.Enabled = false;
            toolStripButton_guardar.Enabled = false;
            toolStripButton_aliminar.Enabled = false;
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            //
            LipiarTextbox();
            //
            EliminarDatagrid12();
            //DATOS GENERALES            
            CargarPanelDatosGenerales();
            //DATOS LABORALES
            CargarPanelesDatosLaborales();
            //CARGAR PLANILLA
            CargarPanelesDatosPlanilla();
            //DESBLOQUEAR TEXT
            BloquearTextbox();
            //
        }

        //ELIMINAR FACTURA
        private void EliminarPersonal()
        {

            objcndatpers.BuscaPersExist(Int32.Parse(textBox_doc_ident.Text));
            if (textBox_doc_ident.Text == "123")
            {
                Msbox.Frm_Notificaciones_IS ng = new Msbox.Frm_Notificaciones_IS("ADMI NO PUEDE SER ELIMININADO", Color.OrangeRed, 3);
                ng.ShowDialog();
            }
            else if (textBox_doc_ident.Text == ce_datospersonal.Busc_usedoc.ToString())
            {
                string MessageBoxTitle = "Eliminar";
                string MessageBoxContent = "¿Desea eliminar al personal?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcndatpers.EliminarPerson(Int32.Parse(textBox_doc_ident.Text));

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();

                    toolStripButton_buscar.Enabled = true;
                    toolStripButton_editar.Enabled = false;
                    toolStripButton_guardar.Enabled = false;
                    toolStripButton_aliminar.Enabled = false;

                    //
                    LipiarTextbox();
                    //DATOS GENERALES
                    CargarPanelDatosGenerales();
                    //DATOS LABORALES
                    CargarPanelesDatosLaborales();
                    //CARGAR PLANILLA
                    CargarPanelesDatosPlanilla();
                    //BLOQUEAR LOS TEXTBOX
                    BloquearTextbox();
                    //
                    EliminarDatagrid12();
                }
                //else if (dialogResult == DialogResult.No)
                //{
                //    dataGridView2.Columns.Clear();
                //    ColumnasDtgv();
                //}
            }
            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL NO REGISTRADO", Color.Goldenrod, 4);
                ng.ShowDialog();
            }
        }

        //ELIMINAR FACTURA
        private void BuscarPersonal()
        {
            textbox_coduser.Text = ce_datospersonal.usecod.ToString();
            textBox_apellidopat.Text = ce_datospersonal.useapepat;
            textbox_apellidomat.Text = ce_datospersonal.useapemat;
            textbox_nombres.Text = ce_datospersonal.usenam;
            textBox_desuser.Text = ce_datospersonal.useusr;
            comboBox_sexo.SelectedValue = ce_datospersonal.usesex;
            comboBox_estadocivil.SelectedValue = ce_datospersonal.useestciv;
            textBox_domicilio.Text = ce_datospersonal.usedom;
            textBox_gmail.Text = ce_datospersonal.useemail;
            textBox_observacionesdg.Text = ce_datospersonal.useobs;
            textBox_fecharegistro.Text = ce_datospersonal.fec_cre.ToString();
            dateTimePicker_FecNacimiento.Value = ce_datospersonal.fec_nac.Date;
            comboBox_tipo_docIdent.SelectedValue = ce_datospersonal.tipo_doc;
            //textBox_doc_ident.Text = ce_datospersonal.usedoc.ToString();
            comboBox_TipoProfesional.SelectedValue = ce_datospersonal.grupro;
            comboBox_Grupo.SelectedValue = ce_datospersonal.grucod;
            comboBox_Establecimiento.SelectedValue = ce_datospersonal.siscod;
            textBox_Telefono.Text = ce_datospersonal.usetel;
            textBox_Clave.Text = ce_datospersonal.usepas;
            comboBox_estado.SelectedValue = ce_datospersonal.estado;
            comboBox_Area.SelectedValue = ce_datospersonal.codarea;
            comboBox_Cargo.SelectedValue = ce_datospersonal.codcar;
            comboBox_Condicion.SelectedValue = ce_datospersonal.codcond;
            comboBox_JefeInmediato.SelectedValue = ce_datospersonal.codjef;
            comboBox_FormaDepositoSalarial.SelectedValue = ce_datospersonal.fordepsal;
            dateTimePicker_FecCese.Value = ce_datospersonal.fec_cece;
            textBox_Comentario.Text = ce_datospersonal.coment;
            comboBox_RegimenLaboral.SelectedValue = ce_datospersonal.reglab;
            comboBox_FondoPensiones.SelectedValue = ce_datospersonal.fondpen;
            textBox_CodFondoPensiones.Text = ce_datospersonal.codfondpen;
            textBox_HorasContratadas.Text = ce_datospersonal.hr_contr.ToString();
            //dateTimePicker_hringreso.Value = ce_datospersonal.hr_ing;
            //dateTimePicker_hrsalida.Value = ce_datospersonal.hr_sal;
            textBox_ToleranciaMin.Text = ce_datospersonal.toler.ToString();
            dateTimePicker_VacInicio.Value = ce_datospersonal.vac_ini;
            dateTimePicker_VacFin.Value = ce_datospersonal.vac_fin;

            //LLENAR FORMACION ACADEMICA
            dataGridView2.Columns.Clear();
            DataTable dtp = new DataTable();
            dtp = cn_datospersonal.BuscarPersForAcadem(int.Parse(textBox_doc_ident.Text));
            dataGridView2.DataSource = dtp;

            //dataGridView2.DataSource = dtp;
            //BUSCAR PERSONAL POR DNI Y LUEGO ENVIAR SU FOTO A PICTUREBOX
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUser(int.Parse(textBox_doc_ident.Text));

            if (dt.Rows[0][0] != System.DBNull.Value)
            {
                if (dt.Rows.Count > 0)
                {
                    byte[] img = (byte[])dt.Rows[0]["foto_perfil"];

                    System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                    pictureBox_fotoperfil.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBox_fotoperfil.Image = pictureBox_titulo.Image;
            }

            //LLENAR DATAGRIDVIEW CON ESTADO ALMACEN
            //OTROS DATOS DE ALAMCEN
            dataGridView3.Columns.Clear();
            //dataGridView3.ReadOnly = false;
            DataTable dt1 = new DataTable();
            dt1 = cn_datospersonal.ListAlmPersonCkeck(ce_datospersonal.usecod);
            dataGridView3.DataSource = dt1;

            DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            estado.HeaderText = "estado";
            dataGridView3.Columns.Insert(0, estado);
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[3].Visible = false;
            dataGridView3.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                //DataGridViewRow i = new DataGridViewRow();
                int i;
                //List<int> ChkedRow = new List<int>();
                for (i = 0; i <= dataGridView3.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView3.Rows[i].Cells[1].Value))
                    {
                        dataGridView3.Rows[i].Cells[0].Value = true;
                    }
                }
            }

        }

        //GUARDAR PERSONAL
        public void guardarpersonal()
        {
            if (textbox_coduser.Text != "")
            {
                if (textBox_apellidopat.Text != "")
                {
                    if (textbox_apellidomat.Text != "")
                    {
                        if (textbox_nombres.Text != "")
                        {
                            if (textBox_desuser.Text != "")
                            {
                                if (textBox_domicilio.Text != "")
                                {
                                    if (textBox_doc_ident.Text != "")
                                    {
                                        if (textBox_Telefono.Text != "")
                                        {
                                            if (textBox_Clave.Text != "")
                                            {
                                                if (textBox_HorasContratadas.Text != "")
                                                {
                                                    if (textBox_ToleranciaMin.Text != "")
                                                    {
                                                        objcndatpers.BuscaPersExist(Int32.Parse(textBox_doc_ident.Text));
                                                        if (textBox_doc_ident.Text == ce_datospersonal.Busc_usedoc.ToString())
                                                        {
                                                            string MessageBoxTitle = "Actualizar";
                                                            string MessageBoxContent = "¿Desea actualizar datos del personal?";

                                                            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                            if (dialogResult == DialogResult.Yes)
                                                            {

                                                                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                                                pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                                                                //ELIMINAR ESCOLARIDAD
                                                                objcndatpers.EliminarPersonFormAcademica(int.Parse(textBox_doc_ident.Text));
                                                                ////GUARDAR ESCOLARIDAD
                                                                //dataGridView2.AllowUserToAddRows = false;

                                                                //foreach (DataGridViewRow row in dataGridView2.Rows)
                                                                //{
                                                                //    ce_datospersonal.usecod_esc = int.Parse(textbox_coduser.Text); //@@usecod
                                                                //    ce_datospersonal.siscod_esc = int.Parse(comboBox_Establecimiento.SelectedValue.ToString()); //@@siscod                                                                    
                                                                //    ce_datospersonal.useusr_esc = textBox_desuser.Text; //@@useusr
                                                                //    ce_datospersonal.usedesc_esc = row.Cells[0].Value?.ToString(); //@@desesc
                                                                //    ce_datospersonal.fec_fin_esc = Convert.ToDateTime(row.Cells[1].Value?.ToString()); //@@fec_fin
                                                                //    ce_datospersonal.obsesc_esc = row.Cells[2].Value?.ToString(); //@@obsesc
                                                                //    ce_datospersonal.entesc_esc = row.Cells[3].Value?.ToString(); //@@entesc  
                                                                //    ce_datospersonal.estado_esc = comboBox_estado.SelectedValue.ToString();
                                                                //    ce_datospersonal.usedoc_esc = int.Parse(textBox_doc_ident.Text);

                                                                //    cn_datospersonal.GuardPersonalEsco(
                                                                //    ce_datospersonal.usecod_esc,
                                                                //    ce_datospersonal.siscod_esc,
                                                                //    ce_datospersonal.useusr_esc,
                                                                //    ce_datospersonal.usedesc_esc,
                                                                //    ce_datospersonal.fec_fin_esc,
                                                                //    ce_datospersonal.obsesc_esc,
                                                                //    ce_datospersonal.entesc_esc,
                                                                //    ce_datospersonal.estado_esc,
                                                                //    ce_datospersonal.fec_cre,
                                                                //    ce_usuario.FechaSistema(),
                                                                //    ce_usuario.usecod,
                                                                //    ce_usuario.useusr,
                                                                //    ce_usuario.HostName(),
                                                                //    ce_usuario.IpMostrar(),
                                                                //    ce_datospersonal.usedoc_esc
                                                                //    );
                                                                //}
                                                                //dataGridView2.AllowUserToAddRows = true;

                                                                objcndatpers.ActuaPersonal(
                                                                            int.Parse(textbox_coduser.Text),
                                                                            int.Parse(comboBox_Establecimiento.SelectedValue.ToString()),
                                                                            textBox_Clave.Text,
                                                                            string.Concat(textBox_apellidopat.Text, " ", textbox_apellidomat.Text, " ", textbox_nombres.Text),
                                                                            textBox_desuser.Text,
                                                                            textBox_observacionesdg.Text,
                                                                            comboBox_TipoProfesional.SelectedValue.ToString(),
                                                                            comboBox_Grupo.SelectedValue.ToString(),
                                                                            comboBox_estado.SelectedValue.ToString(),
                                                                            //ce_usuario.FechaSistema(),
                                                                            ce_usuario.FechaSistema(),
                                                                            //ce_usuario.usecod,
                                                                            //ce_usuario.useusr,
                                                                            //ce_usuario.HostName(),
                                                                            //ce_usuario.IpMostrar(),
                                                                            textBox_Telefono.Text,
                                                                            int.Parse(textBox_doc_ident.Text),
                                                                            ms.GetBuffer()
                                                                            );

                                                                objcndatpers.ActuaPersonalDetalle(
                                                                            int.Parse(textbox_coduser.Text),
                                                                            int.Parse(comboBox_Establecimiento.SelectedValue.ToString()),
                                                                            textBox_apellidopat.Text,
                                                                            textbox_apellidomat.Text,
                                                                            textbox_nombres.Text,
                                                                            textBox_desuser.Text,
                                                                            comboBox_sexo.SelectedValue.ToString(),
                                                                            comboBox_estadocivil.SelectedValue.ToString(),
                                                                            textBox_domicilio.Text,
                                                                            textBox_gmail.Text, //FALTA EN ADELANTE
                                                                            textBox_observacionesdg.Text,
                                                                            //ce_usuario.FechaSistema(),
                                                                            dateTimePicker_FecNacimiento.Value.Date,
                                                                            comboBox_tipo_docIdent.SelectedValue.ToString(),
                                                                            int.Parse(textBox_doc_ident.Text),
                                                                            comboBox_TipoProfesional.SelectedValue.ToString(),
                                                                            comboBox_Grupo.SelectedValue.ToString(),
                                                                            textBox_Telefono.Text,
                                                                            comboBox_estado.SelectedValue.ToString(),
                                                                            comboBox_Area.SelectedValue.ToString(),
                                                                            comboBox_Cargo.SelectedValue.ToString(),
                                                                            comboBox_Condicion.SelectedValue.ToString(),
                                                                            comboBox_JefeInmediato.SelectedValue.ToString(),
                                                                            comboBox_FormaDepositoSalarial.SelectedValue.ToString(),
                                                                            dateTimePicker_FecCese.Value.Date,
                                                                            textBox_Comentario.Text,
                                                                            comboBox_RegimenLaboral.SelectedValue.ToString(),
                                                                            comboBox_FondoPensiones.SelectedValue.ToString(),
                                                                            textBox_CodFondoPensiones.Text,
                                                                            int.Parse(textBox_HorasContratadas.Text),
                                                                            dateTimePicker_hringreso.Value.Date,
                                                                            dateTimePicker_hrsalida.Value.Date,
                                                                            int.Parse(textBox_ToleranciaMin.Text),
                                                                            dateTimePicker_VacInicio.Value.Date,
                                                                            dateTimePicker_VacFin.Value.Date
                                                                            //ce_usuario.usecod,
                                                                            //ce_usuario.useusr,
                                                                            //ce_usuario.HostName(),
                                                                            //ce_usuario.IpMostrar()
                                                                            );

                                                                objrolesbicn.ActualizarUsuario(
                                                                int.Parse(textbox_coduser.Text),
                                                                textBox_apellidopat.Text + " " + textbox_apellidomat.Text + " " + textbox_nombres.Text,
                                                                textBox_doc_ident.Text,
                                                                textBox_Clave.Text
                                                                );
                                                                //PRIMERO SE ELIMINA
                                                                cn_datospersonal.EliminarAlmacenUser(int.Parse(textbox_coduser.Text));
                                                                //LUEGO SE GUARDA
                                                                foreach (DataGridViewRow row in dataGridView3.Rows)
                                                                {
                                                                    ce_datospersonal.estado_almc = Convert.ToBoolean(row.Cells[0].Value); //@@entesc  
                                                                    ce_datospersonal.codalm_almc = row.Cells[3].Value.ToString(); //@@entesc  

                                                                    dataGridView3.EndEdit();
                                                                    cn_datospersonal.GuardarAlmacenUser(
                                                                    int.Parse(textbox_coduser.Text),
                                                                    ce_datospersonal.codalm_almc, //@@obsesc
                                                                    ce_datospersonal.estado_almc //@@obsesc
                                                                    );
                                                                }

                                                                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL ACTUALIZADO", Color.SeaGreen, 2);
                                                                ng.ShowDialog();

                                                                ce_datospersonal.Busc_usedoc = 0;
                                                                toolStripButton_buscar.Enabled = true;
                                                                toolStripButton_editar.Enabled = false;
                                                                toolStripButton_guardar.Enabled = false;
                                                                toolStripButton_aliminar.Enabled = false;

                                                                //
                                                                LipiarTextbox();
                                                                //
                                                                dataGridView1.Columns.Clear();
                                                                dataGridView2.Columns.Clear();
                                                                EliminarDatagrid12();
                                                                //DATOS GENERALES
                                                                CargarPanelDatosGenerales();
                                                                //DATOS LABORALES
                                                                CargarPanelesDatosLaborales();
                                                                //CARGAR PLANILLA
                                                                CargarPanelesDatosPlanilla();

                                                                //BLOQUEAR LOS TEXTBOX
                                                                BloquearTextbox();

                                                            }
                                                            //else if (dialogResult == DialogResult.No)
                                                            //{
                                                            //    dataGridView2.Columns.Clear();
                                                            //    ColumnasDtgv();
                                                            //}
                                                        }

                                                        else if (textbox_coduser.Text != ce_datosventa.fac_buscar.ToString())
                                                        {
                                                            string MessageBoxTitle1 = "Nuevo";
                                                            string MessageBoxContent1 = "¿Registrar nuevo personal?";
                                                            DialogResult dialogResult1 = MessageBox.Show(MessageBoxContent1, MessageBoxTitle1, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                            if (dialogResult1 == DialogResult.Yes)
                                                            {
                                                                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                                                pictureBox_fotoperfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                                                                ////GUARDAR ESCOLARIDAD
                                                                //dataGridView2.AllowUserToAddRows = false;

                                                                //foreach (DataGridViewRow row in dataGridView2.Rows)
                                                                //{
                                                                //    ce_datospersonal.usecod_esc = int.Parse(textbox_coduser.Text); //@@usecod
                                                                //    ce_datospersonal.siscod_esc = int.Parse(comboBox_Establecimiento.SelectedValue.ToString()); //@@siscod                                                                    
                                                                //    ce_datospersonal.useusr_esc = textBox_desuser.Text; //@@useusr
                                                                //    ce_datospersonal.usedesc_esc = row.Cells[0].Value?.ToString(); //@@desesc
                                                                //    ce_datospersonal.fec_fin_esc = Convert.ToDateTime(row.Cells[1].Value?.ToString()); //@@fec_fin
                                                                //    ce_datospersonal.obsesc_esc = row.Cells[2].Value?.ToString(); //@@obsesc
                                                                //    ce_datospersonal.entesc_esc = row.Cells[3].Value?.ToString(); //@@entesc  
                                                                //    ce_datospersonal.estado_esc = comboBox_estado.SelectedValue.ToString();
                                                                //    ce_datospersonal.usedoc_esc = int.Parse(textBox_doc_ident.Text);

                                                                //    cn_datospersonal.GuardPersonalEsco(
                                                                //    ce_datospersonal.usecod_esc,
                                                                //    ce_datospersonal.siscod_esc,
                                                                //    ce_datospersonal.useusr_esc,
                                                                //    ce_datospersonal.usedesc_esc,
                                                                //    ce_datospersonal.fec_fin_esc,
                                                                //    ce_datospersonal.obsesc_esc,
                                                                //    ce_datospersonal.entesc_esc,
                                                                //    ce_datospersonal.estado_esc,
                                                                //    ce_usuario.FechaSistema(),
                                                                //    ce_usuario.FechaSistema(),
                                                                //    ce_usuario.usecod,
                                                                //    ce_usuario.useusr,
                                                                //    ce_usuario.HostName(),
                                                                //    ce_usuario.IpMostrar(),
                                                                //    ce_datospersonal.usedoc_esc
                                                                //    );
                                                                //}
                                                                //dataGridView2.AllowUserToAddRows = true;

                                                                objcndatpers.GuardPersonal(
                                                                            int.Parse(textbox_coduser.Text),
                                                                            int.Parse(comboBox_Establecimiento.SelectedValue.ToString()),
                                                                            textBox_Clave.Text,
                                                                            string.Concat(textBox_apellidopat.Text, " ", textbox_apellidomat.Text, " ", textbox_nombres.Text),
                                                                            textBox_desuser.Text,
                                                                            textBox_observacionesdg.Text,
                                                                            comboBox_TipoProfesional.SelectedValue.ToString(),
                                                                            comboBox_Grupo.SelectedValue.ToString(),
                                                                            comboBox_estado.SelectedValue.ToString(),
                                                                            ce_usuario.FechaSistema(),
                                                                            ce_usuario.FechaSistema(),
                                                                            ce_usuario.usecod,
                                                                            ce_usuario.useusr,
                                                                            ce_usuario.HostName(),
                                                                            ce_usuario.IpMostrar(),
                                                                            textBox_Telefono.Text,
                                                                            int.Parse(textBox_doc_ident.Text),
                                                                            ms.GetBuffer()
                                                                            );

                                                                objcndatpers.GuardPersonalDetalle(
                                                                            int.Parse(textbox_coduser.Text),
                                                                            int.Parse(comboBox_Establecimiento.SelectedValue.ToString()),
                                                                            textBox_apellidopat.Text,
                                                                            textbox_apellidomat.Text,
                                                                            textbox_nombres.Text,
                                                                            textBox_desuser.Text,
                                                                            comboBox_sexo.SelectedValue.ToString(),
                                                                            comboBox_estadocivil.SelectedValue.ToString(),
                                                                            textBox_domicilio.Text,
                                                                            textBox_gmail.Text, //FALTA EN ADELANTE
                                                                            textBox_observacionesdg.Text,
                                                                            ce_usuario.FechaSistema(),
                                                                            dateTimePicker_FecNacimiento.Value.Date,
                                                                            comboBox_tipo_docIdent.SelectedValue.ToString(),
                                                                            int.Parse(textBox_doc_ident.Text),
                                                                            comboBox_TipoProfesional.SelectedValue.ToString(),
                                                                            comboBox_Grupo.SelectedValue.ToString(),
                                                                            textBox_Telefono.Text,
                                                                            comboBox_estado.SelectedValue.ToString(),
                                                                            comboBox_Area.SelectedValue.ToString(),
                                                                            comboBox_Cargo.SelectedValue.ToString(),
                                                                            comboBox_Condicion.SelectedValue.ToString(),
                                                                            comboBox_JefeInmediato.SelectedValue.ToString(),
                                                                            comboBox_FormaDepositoSalarial.SelectedValue.ToString(),
                                                                            dateTimePicker_FecCese.Value.Date,
                                                                            textBox_Comentario.Text,
                                                                            comboBox_RegimenLaboral.SelectedValue.ToString(),
                                                                            comboBox_FondoPensiones.SelectedValue.ToString(),
                                                                            textBox_CodFondoPensiones.Text,
                                                                            int.Parse(textBox_HorasContratadas.Text),
                                                                            dateTimePicker_hringreso.Value.Date,
                                                                            dateTimePicker_hrsalida.Value.Date,
                                                                            int.Parse(textBox_ToleranciaMin.Text),
                                                                            dateTimePicker_VacInicio.Value.Date,
                                                                            dateTimePicker_VacFin.Value.Date,
                                                                            ce_usuario.usecod,
                                                                            ce_usuario.useusr,
                                                                            ce_usuario.HostName(),
                                                                            ce_usuario.IpMostrar()
                                                                            );

                                                                foreach (DataGridViewRow row in dataGridView3.Rows)
                                                                {
                                                                    ce_datospersonal.estado_almc = Convert.ToBoolean(row.Cells[0].Value); //@@entesc  
                                                                    ce_datospersonal.codalm_almc = row.Cells[2].Value.ToString(); //@@entesc  

                                                                    cn_datospersonal.GuardarAlmacenUser(
                                                                    int.Parse(textbox_coduser.Text),
                                                                    ce_datospersonal.codalm_almc, //@@obsesc
                                                                    ce_datospersonal.estado_almc //@@obsesc
                                                                    );
                                                                }

                                                                objrolesbicn.GuardarUsuario(
                                                                int.Parse(textbox_coduser.Text),
                                                                            textBox_apellidopat.Text + " " + textbox_apellidomat.Text + " " + textbox_nombres.Text,
                                                                            textBox_doc_ident.Text,
                                                                            textBox_Clave.Text,
                                                                            0
                                                                );

                                                                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PERSONAL REGISTRADO", Color.FromArgb(13, 93, 140), 1);
                                                                ng.ShowDialog();

                                                                ce_datospersonal.Busc_usedoc = 0;
                                                                toolStripButton_buscar.Enabled = true;
                                                                toolStripButton_editar.Enabled = false;
                                                                toolStripButton_guardar.Enabled = false;
                                                                toolStripButton_aliminar.Enabled = false;
                                                                //
                                                                LipiarTextbox();
                                                                //
                                                                dataGridView1.Columns.Clear();
                                                                dataGridView2.Columns.Clear();
                                                                EliminarDatagrid12();
                                                                //DATOS GENERALES
                                                                CargarPanelDatosGenerales();
                                                                //DATOS LABORALES
                                                                CargarPanelesDatosLaborales();
                                                                //CARGAR PLANILLA
                                                                CargarPanelesDatosPlanilla();

                                                                //BLOQUEAR LOS TEXTBOX
                                                                BloquearTextbox();

                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE MIN TOLE..", Color.Goldenrod, 4);
                                                        ng.ShowDialog();
                                                    }
                                                }
                                                else
                                                {
                                                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE HR CONTRA..", Color.Goldenrod, 4);
                                                    ng.ShowDialog();
                                                }
                                            }
                                            else
                                            {
                                                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE CLAVE", Color.Goldenrod, 4);
                                                ng.ShowDialog();
                                            }
                                        }
                                        else
                                        {
                                            Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE TELEFONO", Color.Goldenrod, 4);
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
                                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE DOMICILIO", Color.Goldenrod, 4);
                                    ng.ShowDialog();
                                }
                            }
                            else
                            {
                                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE USUARIO", Color.Goldenrod, 4);
                                ng.ShowDialog();
                            }
                        }
                        else
                        {
                            Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE NOMBRES", Color.Goldenrod, 4);
                            ng.ShowDialog();
                        }
                    }
                    else
                    {
                        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE APELLIDO MAT", Color.Goldenrod, 4);
                        ng.ShowDialog();
                    }
                }
                else
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE APELLIDO PAT", Color.Goldenrod, 4);
                    ng.ShowDialog();
                }
            }

            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE COD USUARIO", Color.Goldenrod, 4);
                ng.ShowDialog();
            }
        }

        private void button_EliminarFormAcademica_Click(object sender, EventArgs e)
        {
            EliminarDatagrid12();
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView3.ReadOnly = false;
            //dataGridView3.Enabled = false;
            for (int i = 0; i <= e.RowIndex; i++)
            {
                dataGridView3.Rows[i].Cells[0].ReadOnly = false;
                dataGridView3.Rows[i].Cells[1].ReadOnly = true;
                dataGridView3.Rows[i].Cells[2].ReadOnly = true;
                //dataGridView3.Rows[i].Cells[3].ReadOnly = false;
            }
        }
    }

}
