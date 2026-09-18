using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Contabilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_TabMaestra
{
    public partial class Frm_RolesUserAppMovil : Form, VarDatosEntroFormUsuarioAP
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datoscliente objdatclienteneg = new cn_datoscliente();
        cn_reportes objdatreporteneg = new cn_reportes();
        ce_rolespermiso permisoEntidad = new ce_rolespermiso();
        cn_rolesuser objrolesbicn = new cn_rolesuser();
        cd_rolesuser datos = new cd_rolesuser();
        cu_excel objexcel = new cu_excel();
        DataTable dtg = new DataTable();
        int IdRol;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 0;
        public Frm_RolesUserAppMovil()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_RolesUserAppMovil_Load(object sender, EventArgs e)
        {
            comboBox_app.DropDownStyle = ComboBoxStyle.DropDownList;

            cargarpanel();

            //dataGridView4.ReadOnly = false;
            //dataGridView4.Columns[1].ReadOnly = true;

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        public void cargarpanel()
        {

            //comboBox_app.DataSource = cn_rolesuser.ListaERP_MENU();
            comboBox_app.DataSource = cn_rolesuser.ListaOpcionMenuAPP_Usuario(Convert.ToInt32("0"));
            comboBox_app.DisplayMember = "Nombre"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_app.ValueMember = "Id_APP"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            ///

            ///
            //comboBox_Usuario_APP.DataSource = cn_rolesuser.ListaERP_Usuario();
            //comboBox_Usuario_APP.DisplayMember = "Nombres"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Usuario_APP.ValueMember = "IdUsuario"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR OPCIONES PARA CADA APP
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = cn_rolesuser.ListaOpcionApp(Convert.ToInt32(comboBox_app.SelectedValue));
            dataGridView4.ClearSelection();


            ///////////
            ///////////
            ///CARGAR PERMISO USUARIO APP
            dataGridView8.Columns.Clear();
            dataGridView8.DataSource = cn_rolesuser.ListaOpcionMenuAPP_Usuario(Convert.ToInt32("0"));
            dataGridView8.ClearSelection();

            DataGridViewCheckBoxColumn estas = new DataGridViewCheckBoxColumn();
            estas.HeaderText = "Check";
            dataGridView8.Columns.Insert(0, estas);


            int a;
            //List<int> ChkedRow = new List<int>();
            for (a = 0; a <= dataGridView8.Rows.Count - 1; a++)
            {
                if (Convert.ToBoolean(dataGridView8.Rows[a].Cells[1].Value))
                {
                    dataGridView8.Rows[a].Cells[0].Value = true;
                }
            }
            dataGridView8.Columns[1].Visible = false;

            dataGridView8.AllowUserToAddRows = false;

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


        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {

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
            int c = dataGridView6.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView6.Rows[i].Cells[6].Value.ToString() == "ANULADO")
                {
                    dataGridView6.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView6.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView6);
        }


        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Estado")
            //{
            //    if (e.Value.ToString() == "ANULADO")
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 10.0f);
            //        e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }
            //}

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            cargarpanel();
            //
        }

        private void button_guardar_submenu_Click(object sender, EventArgs e)
        {
            dataGridView4.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {


                Cursor = Cursors.WaitCursor;

                // Toda la tanda se arma en memoria y se manda de una sola vez
                // con SqlBulkCopy, en lugar de una llamada al SP por fila.
                DataTable opciones = new DataTable();
                opciones.Columns.Add("IdAppOpc", typeof(int));
                opciones.Columns.Add("IdApp", typeof(int));
                opciones.Columns.Add("Nombre", typeof(string));
                opciones.Columns.Add("Comentario", typeof(string));
                opciones.Columns.Add("Obs", typeof(string));
                opciones.Columns.Add("Estado", typeof(string));
                opciones.Columns.Add("EstadoP", typeof(string));
                opciones.Columns.Add("FecCre", typeof(DateTime));
                opciones.Columns.Add("UseReg", typeof(int));
                opciones.Columns.Add("Hostname", typeof(string));
                opciones.Columns.Add("FecEdit", typeof(DateTime));
                opciones.Columns.Add("UseEdit", typeof(int));
                opciones.Columns.Add("UseElim", typeof(int));

                int idapp = Convert.ToInt32(comboBox_app.SelectedValue.ToString());
                DateTime fecha = ce_usuario.FechaSistema();
                string hostname = ce_usuario.HostName();

                int filas = dataGridView4.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    // Fila en blanco (la de nuevo registro): no hay nada que grabar.
                    if (dataGridView4[0, i].Value == null ||
                        dataGridView4[0, i].Value.ToString().Trim() == "")
                        continue;

                    opciones.Rows.Add(
                        Convert.ToInt32(dataGridView4[0, i].Value.ToString()),   //IdAppOpc
                        idapp,                                                   //IdApp
                        dataGridView4[1, i].Value == null ? "" : dataGridView4[1, i].Value.ToString(), //Nombre
                        dataGridView4[2, i].Value == null ? "" : dataGridView4[2, i].Value.ToString(), //Comentario
                        "",//Obs
                        "S", //estado
                        "", //estadop
                        fecha,
                        ce_usuario.usecod,
                        hostname,
                        fecha,
                        ce_usuario.usecod,
                        0
                        );
                }

                // El SP resuelve si inserta o actualiza según el IdAppOpc.
                objrolesbicn.GuardarActualizarAppOpcionesMasivo(opciones);

                Cursor = Cursors.Default;

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            dataGridView4.AllowUserToAddRows = true;

            //cargarpanel();
        }

        private void comboBox_menu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_app.Text != "")
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = cn_rolesuser.ListaOpcionApp(Convert.ToInt32(comboBox_app.SelectedValue));
                dataGridView4.ClearSelection();

            }
        }



        private void button_guardar_UsuarioRol_Click(object sender, EventArgs e)
        {
            string MessageBoxTitle = "USUARIO ROL";
            string MessageBoxContent = "¿Desea Actualizar Rol?";

            if (textBox_CodUsuario.Text == "")
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("FALTA CODIGO DE USUARIO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView6.AllowUserToAddRows = false;
                    Cursor = Cursors.WaitCursor;

                    // Se arma toda la tanda en memoria y se manda de una sola vez
                    // con SqlBulkCopy: una llamada por fila se vuelve muy lenta
                    // cuando son cientos o miles de opciones.
                    DataTable permisos = new DataTable();
                    permisos.Columns.Add("IdUser", typeof(int));
                    permisos.Columns.Add("IdAppOpc", typeof(int));
                    permisos.Columns.Add("Activo", typeof(Boolean));
                    permisos.Columns.Add("Obs", typeof(string));
                    permisos.Columns.Add("Estado", typeof(string));
                    permisos.Columns.Add("EstadoP", typeof(string));
                    permisos.Columns.Add("FecCre", typeof(DateTime));
                    permisos.Columns.Add("UseReg", typeof(int));
                    permisos.Columns.Add("Hostname", typeof(string));
                    permisos.Columns.Add("FecEdit", typeof(DateTime));
                    permisos.Columns.Add("UseEdit", typeof(int));
                    permisos.Columns.Add("UseElim", typeof(int));

                    int iduser = Convert.ToInt32(textBox_CodUsuario.Text);
                    DateTime fecha = ce_usuario.FechaSistema();
                    string hostname = ce_usuario.HostName();

                    // Se recorre el DataTable y no la grilla: si el buscador
                    // dejo un filtro puesto, la grilla solo muestra parte de las
                    // filas y las demas se quedarian sin grabar.
                    dataGridView6.EndEdit();

                    foreach (DataRow opcion in dtg.Rows)
                    {
                        if (opcion["IdAppOpc"] == null ||
                            opcion["IdAppOpc"].ToString().Trim() == "")
                            continue;

                        // El check marcado es el que va a la columna Activo.
                        Boolean activo = opcion["Activo"] != DBNull.Value &&
                                         Convert.ToBoolean(opcion["Activo"]);

                        permisos.Rows.Add(
                            iduser,                                                  //IdUser
                            Convert.ToInt32(opcion["IdAppOpc"].ToString()),          //IdAppOpc
                            activo,                                                  //Activo
                            "",//Obs
                            "S", //estado
                            "", //estadop
                            fecha,
                            ce_usuario.usecod,
                            hostname,
                            fecha,
                            ce_usuario.usecod,
                            0
                            );
                    }

                    // El SP resuelve si inserta o actualiza segun IdUser + IdAppOpc.
                    objrolesbicn.GuardarActualizarPermisoAppMovilMasivo(permisos);

                    Cursor = Cursors.Default;
                    dataGridView6.AllowUserToAddRows = true;

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("ROL ACTUALIZADO", Color.FromArgb(13, 93, 140), 1);
                    ng.ShowDialog();
                }

                CargarPermisoUsuarioApp();
            }
        }

        private void comboBox_RolUser_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView8.Rows)
            {
                if (checkBox2.Checked == true)
                {
                    row.Cells[0].Value = true;
                }
                else
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void button_guardar_permiso_app_Click(object sender, EventArgs e)
        {
            dataGridView8.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                Cursor = Cursors.WaitCursor;

                DataTable permisosapp = new DataTable();
                permisosapp.Columns.Add("Id_APP", typeof(int));
                permisosapp.Columns.Add("Id_User", typeof(int));
                permisosapp.Columns.Add("Activo", typeof(Boolean));

                int iduserapp = Convert.ToInt32(textBox_CodUsuario_APP.Text.ToString());

                int filas = dataGridView8.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    // Fila en blanco (la de nuevo registro): no hay nada que grabar.
                    if (dataGridView8[2, i].Value == null ||
                        dataGridView8[2, i].Value.ToString().Trim() == "")
                        continue;

                    permisosapp.Rows.Add(
                        Convert.ToInt32(dataGridView8[2, i].Value.ToString()),
                        iduserapp,
                        dataGridView8[0, i].Value != null && Convert.ToBoolean(dataGridView8[0, i].Value)
                        );
                }

                objrolesbicn.GuardarActualizarMenuAPP_UsuarioMasivo(permisosapp);

                Cursor = Cursors.Default;

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            //cargarpanel();
        }



        public void TablaAgregarDatosFilaAPP(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFila(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a)
        {

            //bool EncontrarFilaRepetida = false;
            string valoritem = fila1a.Cells[0].Value.ToString();
            textBox_ApellidosNombres.Text = fila1a.Cells[2].Value.ToString();
            textBox_CodUsuario.Text = fila1a.Cells[0].Value.ToString();
        }
        private void textBox_ApellidosNombres_DoubleClick(object sender, EventArgs e)
        {
            frm_BuscarUsuarioAPP frbm = new frm_BuscarUsuarioAPP();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void textBox_ApellidosNombres_TextChanged(object sender, EventArgs e)
        {
            cn_rolesuser.ListaERP_ROL_Usuario(textBox_ApellidosNombres.Text);
        }

        /// <summary>
        /// Arma dataGridView6 con el check al inicio y deja marcadas las
        /// opciones que el usuario ya tiene activas.
        /// Columnas: Activo (el check), IdApp, App, IdAppOpc, Nombre.
        /// </summary>
        // Check que va en la cabecera de dataGridView6 para marcar toda la columna.
        private CheckBox check_TodosPermiso;
        // Mientras se repuebla la grilla el check de cabecera no debe propagarse.
        private bool cargandoPermiso;

        public void CargarPermisoUsuarioApp()
        {
            if (textBox_CodUsuario.Text == "")
                return;

            cargandoPermiso = true;

            dtg = cn_rolesuser.ListaAppOpciones(Convert.ToInt32(textBox_CodUsuario.Text));

            // Activo sale de una expresion del SELECT (CAST(ISNULL(...))), asi
            // que DataTable.Load la marca de solo lectura y la casilla no se
            // dejaria marcar. Aca es un campo editable.
            dtg.Columns["Activo"].ReadOnly = false;

            dataGridView6.Columns.Clear();
            dataGridView6.DataSource = dtg;
            dataGridView6.ClearSelection();

            // El check es la columna Activo que ya trae la consulta, no una
            // columna agregada aparte. Una columna sin enlazar pierde sus
            // valores cada vez que el buscador cambia el RowFilter, porque el
            // enlace rearma las filas; guardandolo en el propio DataTable las
            // marcas sobreviven al filtro.
            dataGridView6.Columns["Activo"].HeaderText = "Check";
            dataGridView6.Columns["Activo"].DisplayIndex = 0;
            dataGridView6.Columns["Activo"].Visible = true;

            dataGridView6.AllowUserToAddRows = false;

            CrearCheckTodosPermiso();
            check_TodosPermiso.Checked = false;
            UbicarCheckTodosPermiso();

            cargandoPermiso = false;
        }

        /// <summary>
        /// Coloca un CheckBox sobre la cabecera de la columna Check. WinForms no
        /// permite un check real en el encabezado, asi que se apoya un control
        /// encima y se lo reubica cuando la grilla se mueve o cambia de tamaño.
        /// </summary>
        private void CrearCheckTodosPermiso()
        {
            if (check_TodosPermiso != null)
                return;

            check_TodosPermiso = new CheckBox();
            check_TodosPermiso.Size = new Size(16, 16);
            check_TodosPermiso.BackColor = Color.Transparent;
            check_TodosPermiso.Cursor = Cursors.Hand;
            check_TodosPermiso.CheckedChanged += check_TodosPermiso_CheckedChanged;
            dataGridView6.Controls.Add(check_TodosPermiso);

            dataGridView6.Scroll += delegate { UbicarCheckTodosPermiso(); };
            dataGridView6.ColumnWidthChanged += delegate { UbicarCheckTodosPermiso(); };
            dataGridView6.SizeChanged += delegate { UbicarCheckTodosPermiso(); };

            // La grilla es EditMode.EditProgrammatically, asi que el clic no
            // marca la casilla por si solo: hay que alternarla a mano.
            dataGridView6.CellClick += dataGridView6_CellClick;
        }

        /// <summary>
        /// Un clic en cualquier celda de la fila alterna su casilla.
        /// </summary>
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) //cabecera
                return;

            DataGridViewRow fila = dataGridView6.Rows[e.RowIndex];
            Boolean marcado = fila.Cells["Activo"].Value != null &&
                              Convert.ToBoolean(fila.Cells["Activo"].Value);
            fila.Cells["Activo"].Value = !marcado;
        }

        private void UbicarCheckTodosPermiso()
        {
            if (check_TodosPermiso == null || dataGridView6.Columns.Count == 0)
                return;

            DataGridViewColumn columna = dataGridView6.Columns["Activo"];
            if (columna == null)
                return;

            Rectangle celda = dataGridView6.GetCellDisplayRectangle(columna.Index, -1, true);
            if (celda.Width == 0)
                return;

            // Al costado del texto "Check" de la cabecera.
            int ancho = TextRenderer.MeasureText(columna.HeaderText,
                dataGridView6.ColumnHeadersDefaultCellStyle.Font).Width;

            check_TodosPermiso.Location = new Point(
                celda.X + ancho + 12,
                celda.Y + (celda.Height - check_TodosPermiso.Height) / 2);
            check_TodosPermiso.BringToFront();
        }

        private void check_TodosPermiso_CheckedChanged(object sender, EventArgs e)
        {
            if (cargandoPermiso)
                return;

            dataGridView6.EndEdit();

            // Solo las filas visibles: si hay un filtro activo, las que quedaron
            // fuera conservan su marca.
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                row.Cells["Activo"].Value = check_TodosPermiso.Checked;
            }
        }

        private void textBox_CodUsuario_TextChanged(object sender, EventArgs e)
        {

            if (textBox_CodUsuario.Text != "")
            {
                CargarPermisoUsuarioApp();
            }
        }



        public void TablaAgregarDatosFilaD2(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigD2(DataGridViewRow fila1a)
        {

            //bool EncontrarFilaRepetida = false;
            string valoritem = fila1a.Cells[0].Value.ToString();
            textBox_ApellidosNombres_APP.Text = fila1a.Cells[2].Value.ToString();
            textBox_CodUsuario_APP.Text = fila1a.Cells[0].Value.ToString();
            //string valoSTOCK = fila1a.Cells[8].Value.ToString();
            //if(dataGridView2.RowCount > 0)
            //{


        }

        private void textBox_ApellidosNombres_APP_DoubleClick(object sender, EventArgs e)
        {
            frm_BuscarUsuarioAPP_2 frbm = new frm_BuscarUsuarioAPP_2();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void textBox_ApellidosNombres_APP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_CodUsuario_APP_TextChanged(object sender, EventArgs e)
        {
            /////CARGAR PERMISO USUARIO APP
            dataGridView8.Columns.Clear();
            dataGridView8.DataSource = cn_rolesuser.ListaOpcionMenuAPP_Usuario(Convert.ToInt32(textBox_CodUsuario_APP.Text));
            dataGridView8.ClearSelection();



            DataGridViewCheckBoxColumn esta = new DataGridViewCheckBoxColumn();
            esta.HeaderText = "Check";
            dataGridView8.Columns.Insert(0, esta);


            int i;
            //List<int> ChkedRow = new List<int>();
            for (i = 0; i <= dataGridView8.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView8.Rows[i].Cells[1].Value))
                {
                    dataGridView8.Rows[i].Cells[0].Value = true;
                }
            }

            dataGridView8.Columns[1].Visible = false;
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            if (dtg != null)
            {
                DataView dv = dtg.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }
    }



}
