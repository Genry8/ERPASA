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
    public partial class Frm_RolesUser : Form, VarDatosEntroFormUsuarioAP
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
        int IdRol;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 0;
        public Frm_RolesUser()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_RolesUser_Load(object sender, EventArgs e)
        {
            comboBox_Rol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_menu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_RolUser.DropDownStyle = ComboBoxStyle.DropDownList;

            cargarpanel();

            //dataGridView4.ReadOnly = false;
            //dataGridView4.Columns[1].ReadOnly = true;

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        public void cargarpanel()
        {

            comboBox_menu.DataSource = cn_rolesuser.ListaERP_MENU();
            comboBox_menu.DisplayMember = "Nombre"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_menu.ValueMember = "IdMenu"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //
            comboBox_Rol.DataSource = cn_rolesuser.ListaERP_ROL();
            comboBox_Rol.DisplayMember = "Nombre"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Rol.ValueMember = "IdRol"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            ///
            comboBox_RolUser.DataSource = cn_rolesuser.ListaERP_ROL();
            comboBox_RolUser.DisplayMember = "Nombre"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_RolUser.ValueMember = "IdRol"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            ///

            ///
            //comboBox_Usuario_APP.DataSource = cn_rolesuser.ListaERP_Usuario();
            //comboBox_Usuario_APP.DisplayMember = "Nombres"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Usuario_APP.ValueMember = "IdUsuario"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR ROL
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_rolesuser.ListaERP_ROL();
            dataGridView1.ClearSelection();
            //CARGAR MENU
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = cn_rolesuser.ListaERP_MENU();
            dataGridView3.ClearSelection();
            //CARGAR SUB MENU FILTRO MENU
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = cn_rolesuser.ListaOpcionSubMenu(Convert.ToInt32(comboBox_menu.SelectedValue));
            dataGridView4.ClearSelection();
            //CARGAR PERMISO ROL
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = cn_rolesuser.ListaOpcionSubMenuRol(Convert.ToInt32(comboBox_Rol.SelectedValue));
            dataGridView5.ClearSelection();

            DataGridViewCheckBoxColumn esta = new DataGridViewCheckBoxColumn();
            esta.HeaderText = "Check";
            dataGridView5.Columns.Insert(0, esta);


            int i;
            //List<int> ChkedRow = new List<int>();
            for (i = 0; i <= dataGridView5.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView5.Rows[i].Cells[1].Value))
                {
                    dataGridView5.Rows[i].Cells[0].Value = true;
                }
            }
            dataGridView5.Columns[1].Visible = false;

            dataGridView5.AllowUserToAddRows = false;

            //CARGAR MENU APP
            dataGridView7.Columns.Clear();
            dataGridView7.DataSource = cn_rolesuser.ListaERP_MENU_APP();
            dataGridView7.ClearSelection();

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


        private void button_guardar_pagina_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var exrol = cn_rolesuser.BuscExisteROL(Convert.ToInt32(dataGridView1[0, i].Value.ToString()));

                    if (exrol == true)
                    {
                        objrolesbicn.ActualizaROL(
                            Convert.ToInt32(dataGridView1[0, i].Value.ToString()),
                            dataGridView1[1, i].Value.ToString()
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardarROL(
                            Convert.ToInt32(dataGridView1[0, i].Value.ToString()),
                            dataGridView1[1, i].Value.ToString()
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            dataGridView1.AllowUserToAddRows = true;

            cargarpanel();
        }

        private void button_guardar_grupo_Click(object sender, EventArgs e)
        {
            dataGridView3.AllowUserToAddRows = false;
            cn_rolesuser.BuscExisteOpcionMasunoROL();
            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                int filas = dataGridView3.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var extmenu = cn_rolesuser.BuscExisteMenu(Convert.ToInt32(dataGridView3[0, i].Value.ToString()));

                    if (extmenu == true)
                    {
                        objrolesbicn.ActualizarMenu(
                            Convert.ToInt32(dataGridView3[0, i].Value),
                            dataGridView3[1, i].Value.ToString(),
                            dataGridView3[2, i].Value.ToString()
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {

                        objrolesbicn.GuardarMenu(
                            Convert.ToInt32(dataGridView3[0, i].Value),
                            dataGridView3[1, i].Value.ToString(),
                            dataGridView3[2, i].Value.ToString()
                            );
                    }



                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            dataGridView3.AllowUserToAddRows = true;

            cargarpanel();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
        }

        private void dataGridView4_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dataGridView4.IsCurrentCellDirty)
            //{
            //    dataGridView4.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }



        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex != -1 && e.ColumnIndex==dataGridView4.Columns["Estado"].Index)
            //{
            //    DataGridViewCheckBoxCell checkBoxCell =
            //        (DataGridViewCheckBoxCell)dataGridView4.Rows[e.RowIndex].Cells["Estado"];
            //    checkBoxCell.Value = !Convert.ToBoolean(checkBoxCell.Value);

            //}
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


                int filas = dataGridView4.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var extmensub = cn_rolesuser.BuscExisteMenuSubMenu(Convert.ToInt32(comboBox_menu.SelectedValue.ToString()), Convert.ToInt32(dataGridView4[0, i].Value.ToString()));

                    if (extmensub == true)
                    {
                        objrolesbicn.ActualizarMenuSubmenu(
                            Convert.ToInt32(dataGridView4[0, i].Value.ToString()),
                            Convert.ToInt32(comboBox_menu.SelectedValue.ToString()),
                            dataGridView4[1, i].Value.ToString(),
                            dataGridView4[2, i].Value.ToString()
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardarMenuSubmenu(
                            Convert.ToInt32(dataGridView4[0, i].Value.ToString()),
                            Convert.ToInt32(comboBox_menu.SelectedValue.ToString()),
                            dataGridView4[1, i].Value.ToString(),
                            dataGridView4[2, i].Value.ToString()
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            dataGridView4.AllowUserToAddRows = true;

            //cargarpanel();
        }

        private void comboBox_menu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_menu.Text != "")
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = cn_rolesuser.ListaOpcionSubMenu(Convert.ToInt32(comboBox_menu.SelectedValue));
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
                    objrolesbicn.ActualizarUsuarioRol(
                int.Parse(textBox_CodUsuario.Text.ToString())
                , int.Parse(comboBox_RolUser.SelectedValue.ToString())
                );

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("ROL ACTUALIZADO", Color.FromArgb(13, 93, 140), 1);
                    ng.ShowDialog();
                }

                dataGridView6.Columns.Clear();
                dataGridView6.DataSource = cn_rolesuser.ListaOpcionSubMenuUsuario(Convert.ToInt32(textBox_CodUsuario.Text));
                dataGridView6.ClearSelection();
            }
        }

        private void comboBox_Rol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = cn_rolesuser.ListaOpcionSubMenuRol(Convert.ToInt32(comboBox_Rol.SelectedValue));
            dataGridView5.ClearSelection();


            DataGridViewCheckBoxColumn esta = new DataGridViewCheckBoxColumn();
            esta.HeaderText = "Check";
            dataGridView5.Columns.Insert(0, esta);


            int i;
            //List<int> ChkedRow = new List<int>();
            for (i = 0; i <= dataGridView5.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView5.Rows[i].Cells[1].Value))
                {
                    dataGridView5.Rows[i].Cells[0].Value = true;
                }
            }
            dataGridView5.Columns[1].Visible = false;


        }

        private void button_Rol_SubMenu_Click(object sender, EventArgs e)
        {
            dataGridView5.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                int filas = dataGridView5.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var extmensub = cn_rolesuser.BuscExisteMenuSubMenuRol(Convert.ToInt32(comboBox_Rol.SelectedValue.ToString()), Convert.ToInt32(dataGridView5[3, i].Value.ToString()));

                    if (extmensub == true)
                    {
                        objrolesbicn.ActualizarMenuSubmenuRol(
                            Convert.ToInt32(comboBox_Rol.SelectedValue.ToString()),
                            Convert.ToInt32(dataGridView5[3, i].Value.ToString()),
                            Convert.ToBoolean(dataGridView5[0, i].Value)
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardarMenuSubmenuRol(
                            Convert.ToInt32(comboBox_Rol.SelectedValue.ToString()),
                            Convert.ToInt32(dataGridView5[3, i].Value.ToString()),
                            Convert.ToBoolean(dataGridView5[0, i].Value)
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            //cargarpanel();

        }

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView5.ReadOnly = false;
            for (int a = 0; a <= e.RowIndex; a++)
            {
                dataGridView5.Rows[a].Cells[0].ReadOnly = false;
                dataGridView5.Rows[a].Cells[1].ReadOnly = true;
                dataGridView5.Rows[a].Cells[2].ReadOnly = true;
                dataGridView5.Rows[a].Cells[3].ReadOnly = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (checkBox1.Checked == true)
                {
                    row.Cells[0].Value = true;
                }
                else
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void comboBox_RolUser_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button_Guardar_APP_Click(object sender, EventArgs e)
        {
            dataGridView7.AllowUserToAddRows = false;
            //cn_rolesuser.BuscExisteOpcionMasunoROL();
            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                int filas = dataGridView7.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var extmenu = cn_rolesuser.BuscExisteMenuAPP(Convert.ToInt32(dataGridView7[0, i].Value.ToString()));

                    if (extmenu == true)
                    {
                        objrolesbicn.ActualizarMenuAPP(
                            Convert.ToInt32(dataGridView7[0, i].Value),
                            dataGridView7[1, i].Value.ToString(),
                            dataGridView7[2, i].Value.ToString()
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {

                        objrolesbicn.GuardarMenuAPP(
                            Convert.ToInt32(dataGridView7[0, i].Value),
                            dataGridView7[1, i].Value.ToString(),
                            dataGridView7[2, i].Value.ToString()
                            );
                    }



                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            dataGridView7.AllowUserToAddRows = true;

            cargarpanel();
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

                int filas = dataGridView8.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var extmensub = cn_rolesuser.BuscExisteMenuAPP_Usuario(Convert.ToInt32(textBox_CodUsuario_APP.Text.ToString()), Convert.ToInt32(dataGridView8[2, i].Value.ToString()));

                    if (extmensub == true)
                    {
                        objrolesbicn.ActualizarMenuAPP_Usuario(
                            Convert.ToInt32(dataGridView8[2, i].Value.ToString()),
                            Convert.ToInt32(textBox_CodUsuario_APP.Text.ToString()),
                            Convert.ToBoolean(dataGridView8[0, i].Value)
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardarMenuAPP_Usuario(
                            Convert.ToInt32(dataGridView8[2, i].Value.ToString()),
                            Convert.ToInt32(textBox_CodUsuario_APP.Text.ToString()),
                            Convert.ToBoolean(dataGridView8[0, i].Value)
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            //cargarpanel();
        }

        private void comboBox_Usuario_APP_SelectionChangeCommitted(object sender, EventArgs e)
        {


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
            //string valoSTOCK = fila1a.Cells[8].Value.ToString();
            //if(dataGridView2.RowCount > 0)
            //{


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

            comboBox_RolUser.SelectedValue = ce_rolesuser.IdRolSelect;

        }

        private void textBox_CodUsuario_TextChanged(object sender, EventArgs e)
        {

            if (textBox_CodUsuario.Text != "")
            {
                dataGridView6.Columns.Clear();
                dataGridView6.DataSource = cn_rolesuser.ListaOpcionSubMenuUsuario(Convert.ToInt32(textBox_CodUsuario.Text));
                dataGridView6.ClearSelection();

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
    }


    internal interface VarDatosEntroFormUsuarioAP
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaD2(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigD2(DataGridViewRow fila1a);
    }

}
