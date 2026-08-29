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
    public partial class Frm_RolesBI : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datoscliente objdatclienteneg = new cn_datoscliente();
        cn_reportes objdatreporteneg = new cn_reportes();
        cn_rolesbi objrolesbicn = new cn_rolesbi();
        cu_excel objexcel = new cu_excel();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 0;
        public Frm_RolesBI()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_RolesBI_Load(object sender, EventArgs e)
        {
            cargarpanel();
            comboBox_grupo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_usuario.DropDownStyle = ComboBoxStyle.DropDownList;

            //dataGridView4.ReadOnly = false;
            //dataGridView4.Columns[1].ReadOnly = true;

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        public void cargarpanel()
        {
            comboBox_grupo.DataSource = cn_rolesbi.ListaGrupoBI();
            comboBox_grupo.DisplayMember = "grupo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_grupo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_usuario.DataSource = cn_rolesbi.ListaUsuarioBI();
            comboBox_usuario.DisplayMember = "Usuario"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_usuario.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_rolesbi.ListaUsuarioBI();
            dataGridView2.ClearSelection();
            //
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_rolesbi.ListaPaginaBI();
            dataGridView1.ClearSelection();
            //
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = cn_rolesbi.ListaGrupoBI();
            dataGridView3.ClearSelection();
            //
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = cn_rolesbi.ListaGrupoPaginaBI(comboBox_grupo.SelectedValue.ToString());
            dataGridView4.ClearSelection();

            DataGridViewCheckBoxColumn esta = new DataGridViewCheckBoxColumn();
            esta.HeaderText = "Check";
            dataGridView4.Columns.Insert(0, esta);

            dataGridView4.AllowUserToAddRows = false;

            int i;
            //List<int> ChkedRow = new List<int>();
            for (i = 0; i <= dataGridView4.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView4.Rows[i].Cells[1].Value))
                {
                    dataGridView4.Rows[i].Cells[0].Value = true;
                }
            }
            dataGridView4.Columns[1].Visible = false;

            //
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = cn_rolesbi.ListaRolUsuarioBI(comboBox_usuario.SelectedValue.ToString());
            dataGridView5.ClearSelection();

            DataGridViewCheckBoxColumn est = new DataGridViewCheckBoxColumn();
            est.HeaderText = "Check";
            dataGridView5.Columns.Insert(0, est);

            dataGridView5.AllowUserToAddRows = false;

            int a;
            //List<int> ChkedRow = new List<int>();
            for (a = 0; a <= dataGridView5.Rows.Count - 1; a++)
            {
                if (Convert.ToBoolean(dataGridView5.Rows[a].Cells[1].Value))
                {
                    dataGridView5.Rows[a].Cells[0].Value = true;
                }
            }
            dataGridView5.Columns[1].Visible = false;

            //
            cn_rolesbi.BuscExisteCorreoUsuarioPB(comboBox_usuario.SelectedValue.ToString());
            textBox_Usuario.Text = ce_rolesbi.UserCorreo;

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
                if (dataGridView2.Rows[i].Cells[6].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
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

        private void button_guardar_usuario_Click(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {


                int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var extuser = cn_rolesbi.BuscExisteCodUsuarioPB(dataGridView2[0, i].Value.ToString());

                    if (extuser == true)
                    {
                        objrolesbicn.ActuaUsuarioBI(
                            dataGridView2[0, i].Value.ToString(),
                            dataGridView2[1, i].Value.ToString(),
                            dataGridView2[2, i].Value.ToString(),
                            dataGridView2[3, i].Value.ToString()
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardUsuarioBI(
                            dataGridView2[0, i].Value.ToString(),
                            dataGridView2[1, i].Value.ToString(),
                            dataGridView2[2, i].Value.ToString(),
                            dataGridView2[3, i].Value.ToString()
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

            }

            dataGridView2.AllowUserToAddRows = true;

            cargarpanel();
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
                    cn_rolesbi.BuscExistePaginaPB(dataGridView1[0, i].Value.ToString());

                    if (dataGridView1[0, i].Value.ToString() == ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.ActuaPaginaBI(
                            dataGridView1[0, i].Value.ToString(),
                            dataGridView1[1, i].Value.ToString(),
                            dataGridView1[2, i].Value.ToString(),
                            Convert.ToInt32(dataGridView1[3, i].Value.ToString())
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardPaginaBI(
                            dataGridView1[0, i].Value.ToString(),
                            dataGridView1[1, i].Value.ToString(),
                            dataGridView1[2, i].Value.ToString(),
                            Convert.ToInt32(dataGridView1[3, i].Value.ToString())
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
                    cn_rolesbi.BuscExisteGrupoPB(dataGridView3[0, i].Value.ToString());

                    if (dataGridView3[0, i].Value.ToString() == ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.ActuaGrupoBI(
                            dataGridView3[0, i].Value.ToString(),
                            dataGridView3[1, i].Value.ToString(),
                            dataGridView3[2, i].Value.ToString()
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardGrupoBI(
                            dataGridView3[0, i].Value.ToString(),
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

        private void button_guardar_GrupoPagina_Click(object sender, EventArgs e)
        {
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
                    cn_rolesbi.BuscExisteGrupoPaginaPB(comboBox_grupo.SelectedValue.ToString(), dataGridView4[2, i].Value.ToString());

                    if (comboBox_grupo.SelectedValue.ToString() == ce_rolesbi.CodExiste & dataGridView4[2, i].Value.ToString() == ce_rolesbi.CodPagExiste)
                    {
                        objrolesbicn.ActuaGrupoPaginaBI(
                            comboBox_grupo.SelectedValue.ToString(),
                            comboBox_grupo.Text,
                            dataGridView4[2, i].Value.ToString(),
                            dataGridView4[2, i].Value.ToString(),
                            Convert.ToBoolean(dataGridView4[0, i].Value)
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardGrupoPaginaBI(
                            comboBox_grupo.SelectedValue.ToString(),
                            comboBox_grupo.Text,
                            dataGridView4[2, i].Value.ToString(),
                            dataGridView4[2, i].Value.ToString(),
                            Convert.ToBoolean(dataGridView4[0, i].Value)
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

                //cargarpanel();
            }
        }

        private void button_guardar_RolUsuario_Click(object sender, EventArgs e)
        {
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
                    cn_rolesbi.BuscExisteRolUsuarioPB(dataGridView5[2, i].Value.ToString(), comboBox_usuario.SelectedValue.ToString());

                    if (dataGridView5[2, i].Value.ToString() == ce_rolesbi.CodExiste & comboBox_usuario.SelectedValue.ToString() == ce_rolesbi.CodPagExiste)
                    {
                        objrolesbicn.ActuaRolUsuarioBI(
                            dataGridView5[2, i].Value.ToString(),
                            dataGridView5[3, i].Value.ToString(),
                            comboBox_usuario.SelectedValue.ToString(),
                            comboBox_usuario.Text,
                            Convert.ToBoolean(dataGridView5[0, i].Value)
                            );
                    }

                    else //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {
                        objrolesbicn.GuardRolUsuarioBI(
                            dataGridView5[2, i].Value.ToString(),
                            dataGridView5[3, i].Value.ToString(),
                            comboBox_usuario.SelectedValue.ToString(),
                            comboBox_usuario.Text,
                            Convert.ToBoolean(dataGridView5[0, i].Value)
                            );
                    }


                }

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO AGREGADO", Color.FromArgb(13, 93, 140), 1);
                ng.ShowDialog();

                //cargarpanel();
            }
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

        private void comboBox_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_grupo.Text == comboBox_grupo.Text)
            {
                //CARGAR SEDE EMPRESA
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = cn_rolesbi.ListaGrupoPaginaBI(comboBox_grupo.SelectedValue.ToString());
                dataGridView4.ClearSelection();

                DataGridViewCheckBoxColumn esta = new DataGridViewCheckBoxColumn();
                esta.HeaderText = "Check";
                dataGridView4.Columns.Insert(0, esta);

                dataGridView4.Columns[1].Visible = false;

                int i;
                //List<int> ChkedRow = new List<int>();
                for (i = 0; i <= dataGridView4.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView4.Rows[i].Cells[1].Value))
                    {
                        dataGridView4.Rows[i].Cells[0].Value = true;
                    }
                }

            }

        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView4.ReadOnly = false;
            for (int a = 0; a <= e.RowIndex; a++)
            {
                dataGridView4.Rows[a].Cells[0].ReadOnly = false;
                dataGridView4.Rows[a].Cells[1].ReadOnly = true;
                dataGridView4.Rows[a].Cells[2].ReadOnly = true;
                dataGridView4.Rows[a].Cells[3].ReadOnly = true;
                dataGridView4.Rows[a].Cells[4].ReadOnly = true;
            }
        }

        private void dataGridView4_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dataGridView4.IsCurrentCellDirty)
            //{
            //    dataGridView4.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.Rows)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.Rows)
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

        private void comboBox_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn_rolesbi.BuscExisteCorreoUsuarioPB(comboBox_usuario.SelectedValue.ToString());
            textBox_Usuario.Text = ce_rolesbi.UserCorreo;

            if (comboBox_usuario.Text == comboBox_usuario.Text)
            {
                //CARGAR USUARIO
                dataGridView5.Columns.Clear();
                dataGridView5.DataSource = cn_rolesbi.ListaRolUsuarioBI(comboBox_usuario.SelectedValue.ToString());
                dataGridView5.ClearSelection();

                DataGridViewCheckBoxColumn est = new DataGridViewCheckBoxColumn();
                est.HeaderText = "Check";
                dataGridView5.Columns.Insert(0, est);

                dataGridView5.Columns[1].Visible = false;

                int a;
                //List<int> ChkedRow = new List<int>();
                for (a = 0; a <= dataGridView5.Rows.Count - 1; a++)
                {
                    if (Convert.ToBoolean(dataGridView5.Rows[a].Cells[1].Value))
                    {
                        dataGridView5.Rows[a].Cells[0].Value = true;
                    }
                }
            }
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

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView5.ReadOnly = false;
            for (int a = 0; a <= e.RowIndex; a++)
            {
                dataGridView5.Rows[a].Cells[0].ReadOnly = false;
                dataGridView5.Rows[a].Cells[1].ReadOnly = true;
                dataGridView5.Rows[a].Cells[2].ReadOnly = true;
                dataGridView5.Rows[a].Cells[3].ReadOnly = true;
                dataGridView5.Rows[a].Cells[4].ReadOnly = true;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            cargarpanel();
        }
    }

}
