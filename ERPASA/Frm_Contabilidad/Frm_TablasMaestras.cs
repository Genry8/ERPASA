using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_TablasMaestras : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_TablasMaestras()
        {
            InitializeComponent();
        }

        private void Frm_TablasMaestras_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            cargarcolumnasDTGv();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            //comboBox_campaña.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_sucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void CargarDatosComboBox()
        {
            //comboBox_campaña.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //comboBox_campaña.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_campaña.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_sucursal.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //comboBox_sucursal.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_sucursal.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_Cultivo.DataSource = cn_taller.ListaGrupoVehiculo();
            //comboBox_Cultivo.DisplayMember = "Grupo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMerma();
            //comboBox_TipoMerma.DisplayMember = "Merma"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }



        public void AbrirFormularioHijo<MiForm>() where MiForm : Form, new()
        {
            Form fh;
            fh = frm_Menu.panel_contenedor.Controls.OfType<MiForm>().FirstOrDefault(); //busca en la colección del formulario

            //si el formulario no existe
            if (fh == null)
            {

                fh = new MiForm();
                fh.TopLevel = false;
                //fh.Dock = DockStyle.Fill;            
                this.frm_Menu.panel_contenedor.Controls.Add(fh);
                this.frm_Menu.panel_contenedor.Tag = fh;
                fh.Show();
                fh.BringToFront();

            }
            else
            {
                fh.BringToFront();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //BuscarRegistroParaEditar();

        }

        public void cargarcolumnasDTGv()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            //ColumnasDtgvSucursal();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            //ColumnasDtgvCultivo();
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = null;
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = null;
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = null;
            dataGridView6.Columns.Clear();
            dataGridView6.DataSource = null;
            dataGridView7.Columns.Clear();
            dataGridView7.DataSource = null;
            dataGridView8.Columns.Clear();
            dataGridView8.DataSource = null;
            dataGridView9.Columns.Clear();
            dataGridView9.DataSource = null;
            dataGridView10.Columns.Clear();
            dataGridView10.DataSource = null;
        }

        public void BuscarRegistroParaEditar()
        {
            if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
            {

                //frm_EditarMantPreventivo obj = new frm_EditarMantPreventivo();
                //obj.PonerOscuroComboBox();
                //obj.CargarDatosComboBox();
                //obj.label_Id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                //ce_taller.empresa = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                //ce_taller.sede = dataGridView2.CurrentRow.Cells[2].Value.ToString();

                ////obj.comboBox_Cultivo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                ////obj.comboBox_Campana.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();

                //ce_taller.idVeh = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                //ce_taller.DescripcionVehiculo = dataGridView2.CurrentRow.Cells[4].Value.ToString();

                //ce_taller.kmIni = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                //ce_taller.kmFin = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                //ce_taller.kmDif = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                //ce_taller.implemento = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                //ce_taller.area_cabezal = dataGridView2.CurrentRow.Cells[14].Value.ToString();

                //obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO SE PUEDE EDITAR, PORQUE ESTA ELIMINADO");
            }
        }



        private void ColumnasDtgvSucursal()
        {
            // 
            // Column1
            // 
            //DataGridViewTextBoxColumn SEDE = new DataGridViewTextBoxColumn();
            //SEDE.HeaderText = "SEDE";
            //SEDE.Name = "Column1";
            //SEDE.Width = 85;
            //dataGridView1.Columns.Add(SEDE);

            DataGridViewComboBoxColumn Empresa = new DataGridViewComboBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Empresa";
            Empresa.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Empresa.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Empresa);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Sucursal = new DataGridViewTextBoxColumn();
            Sucursal.HeaderText = "Sucursal";
            Sucursal.Name = "Sucursal";
            Sucursal.Width = 87;
            dataGridView1.Columns.Add(Sucursal);

        }


        private void ColumnasDtgvCultivo()
        {
            // 
            // Column1
            // 
            //DataGridViewTextBoxColumn SEDE = new DataGridViewTextBoxColumn();
            //SEDE.HeaderText = "SEDE";
            //SEDE.Name = "Column1";
            //SEDE.Width = 85;
            //dataGridView1.Columns.Add(SEDE);

            DataGridViewComboBoxColumn Empresa = new DataGridViewComboBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Empresa";
            Empresa.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Empresa.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Empresa);

            // 
            // Column2
            // 

            DataGridViewComboBoxColumn Sucursal = new DataGridViewComboBoxColumn();
            Sucursal.HeaderText = "Sucursal";
            Sucursal.Name = "Sucursal";
            Sucursal.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rows = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dts = new DataTable();
            dts = cn_contabilidad.ListaSucursal("%");
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow items in dts.Rows)
            {
                rows.Add(items[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Sucursal.Items.AddRange(rows.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Sucursal);


            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Cultivo = new DataGridViewTextBoxColumn();
            Cultivo.HeaderText = "Cultivo";
            Cultivo.Name = "Cultivo";
            Cultivo.Width = 87;
            dataGridView1.Columns.Add(Cultivo);

        }

        private void toolStripButton_buscarSucursal_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteSucursal();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        public void BuscarReporteSucursal()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = cn_contabilidad.ReporteSucursal("%");
            dataGridView2.ClearSelection();


            DataGridViewComboBoxColumn Empresa = new DataGridViewComboBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Empresa_";
            Empresa.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Empresa.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView2.Columns.Insert(1, Empresa);

            int i;
            for (i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                //EMPRESA
                dataGridView2.Rows[i].Cells[1].Value
                    = dataGridView2.Rows[i].Cells[2].Value;
                //SUCURAL
                //dataGridView1.Rows[i].Cells[2].Value
                //    = dataGridView1.Rows[i].Cells[6].Value;

            }
            dataGridView2.Columns.RemoveAt(2);

        }

        private void toolStripButton_excelSucursal_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView2);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_guardarSucursal_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (dataGridView2.Rows.Count > 0)
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
                        objcnlog.GuardSucursalConta(
                            Convert.ToInt32(dataGridView2[0, i].Value.ToString()),//id
                            dataGridView2[1, i].Value.ToString(),//emp
                            dataGridView2[2, i].Value.ToString(),//suc
                            "",//suc nisira
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView2.AllowUserToAddRows = true;

                }
                dataGridView2.AllowUserToAddRows = true;

                //BuscarReporteSucursal();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscarCultivo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteCultivo();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        public void BuscarReporteCultivo()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_contabilidad.ReporteCultivo("%", "%");
            dataGridView1.ClearSelection();


            DataGridViewComboBoxColumn Empresa = new DataGridViewComboBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Empresa_";
            Empresa.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Empresa.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Insert(1, Empresa);


            DataGridViewComboBoxColumn Sucursal = new DataGridViewComboBoxColumn();
            Sucursal.HeaderText = "Sucursal";
            Sucursal.Name = "Sucursal_";
            Sucursal.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rows = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dts = new DataTable();
            dts = cn_contabilidad.ListaSucursal("%");
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow items in dts.Rows)
            {
                rows.Add(items[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Sucursal.Items.AddRange(rows.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Insert(2, Sucursal);

            int i;
            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                //EMPRESA
                dataGridView1.Rows[i].Cells[1].Value
                    = dataGridView1.Rows[i].Cells[3].Value;
                //SUCURAL
                dataGridView1.Rows[i].Cells[2].Value
                    = dataGridView1.Rows[i].Cells[4].Value;

            }
            dataGridView1.Columns.RemoveAt(4);
            dataGridView1.Columns.RemoveAt(3);

        }

        private void toolStripButton_ExcelCultivo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView1);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButtonGuardarCultivo_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (dataGridView1.Rows.Count > 0)
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
                        objcnlog.GuardCultivoConta(
                            Convert.ToInt32(dataGridView1[0, i].Value.ToString()),
                            dataGridView1[1, i].Value.ToString(),
                            dataGridView1[2, i].Value.ToString(),
                            dataGridView1[3, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView1.AllowUserToAddRows = true;

                }
                dataGridView1.AllowUserToAddRows = true;

                //BuscarReporteSucursal();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }


        }

        private void toolStripButton_BuscarEtapa_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteEtapa();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        public void BuscarReporteEtapa()
        {
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = cn_contabilidad.ReporteEtapa();
            dataGridView3.ClearSelection();
        }

        private void toolStripButton_ExportarEtapa_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView3);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarEtapa_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView3.Rows.Count > 0)
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
                        objcnlog.GuardEtapaConta(
                            Convert.ToInt32(dataGridView3[0, i].Value.ToString()),
                            dataGridView3[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView3.AllowUserToAddRows = true;

                }
                dataGridView3.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscTipoGasto_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteTipoGasto();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteTipoGasto()
        {
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = cn_contabilidad.ReporteTipoGasto();
            dataGridView4.ClearSelection();
        }

        private void toolStripButton_ExcelTipoGasto_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView4);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarTipoGasto_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView4.Rows.Count > 0)
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
                        objcnlog.GuardarTipoGasto(
                            Convert.ToInt32(dataGridView4[0, i].Value.ToString()),
                            dataGridView4[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView4.AllowUserToAddRows = true;

                }
                dataGridView4.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscTipoEstructura_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteTipoEstructura();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteTipoEstructura()
        {
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = cn_contabilidad.ReporteTipoEstructura();
            dataGridView5.ClearSelection();
        }

        private void toolStripButton_ExcelTipoEstructura_Click(object sender, EventArgs e)
        {
            if (dataGridView5.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView5);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarTipoEstructura_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView5.Rows.Count > 0)
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
                        objcnlog.GuardarTipoEstructura(
                            Convert.ToInt32(dataGridView5[0, i].Value.ToString()),
                            dataGridView5[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView5.AllowUserToAddRows = true;

                }
                dataGridView5.AllowUserToAddRows = true;
            }

            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscArea_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteArea();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteArea()
        {
            dataGridView6.Columns.Clear();
            dataGridView6.DataSource = null;
            dataGridView6.DataSource = cn_contabilidad.ReporteArea();
            dataGridView6.ClearSelection();
        }

        private void toolStripButton_ExcelArea_Click(object sender, EventArgs e)
        {
            if (dataGridView6.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView6);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarArea_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView6.Rows.Count > 0)
            {
                dataGridView6.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView6.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarArea(
                            Convert.ToInt32(dataGridView6[0, i].Value.ToString()),
                            dataGridView6[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView6.AllowUserToAddRows = true;

                }
                dataGridView6.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_BuscarTipoRecurso_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteTipoRecurso();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteTipoRecurso()
        {
            dataGridView7.Columns.Clear();
            dataGridView7.DataSource = null;
            dataGridView7.DataSource = cn_contabilidad.ReporteTipoRecurso();
            dataGridView7.ClearSelection();
        }

        private void toolStripButton_ExcelTipoRecurso_Click(object sender, EventArgs e)
        {
            if (dataGridView7.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView7);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarTipoRecurso_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (dataGridView7.Rows.Count > 0)
            {
                dataGridView7.AllowUserToAddRows = false;

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
                        objcnlog.GuardarTipoRecurso(
                            Convert.ToInt32(dataGridView7[0, i].Value.ToString()),
                            dataGridView7[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView7.AllowUserToAddRows = true;

                }
                dataGridView7.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscRecurso_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteRecurso();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteRecurso()
        {
            dataGridView8.Columns.Clear();
            dataGridView8.DataSource = null;
            dataGridView8.DataSource = cn_contabilidad.ReporteRecurso();
            dataGridView8.ClearSelection();
        }

        private void toolStripButton_ExcelRecurso_Click(object sender, EventArgs e)
        {
            if (dataGridView8.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView8);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarRecurso_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView8.Rows.Count > 0)
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
                        objcnlog.GuardarRecurso(
                            Convert.ToInt32(dataGridView8[0, i].Value.ToString()),
                            dataGridView8[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView8.AllowUserToAddRows = true;

                }
                dataGridView8.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscarClasificador_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteClasificar();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteClasificar()
        {
            dataGridView9.Columns.Clear();
            dataGridView9.DataSource = null;
            dataGridView9.DataSource = cn_contabilidad.ReporteClasificar();
            dataGridView9.ClearSelection();
        }

        private void toolStripButton_ExcelClasificador_Click(object sender, EventArgs e)
        {
            if (dataGridView9.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView9);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarClasificador_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (dataGridView9.Rows.Count > 0)
            {
                dataGridView9.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView9.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarClasificador(
                            Convert.ToInt32(dataGridView9[0, i].Value.ToString()),
                            dataGridView9[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView9.AllowUserToAddRows = true;

                }
                dataGridView9.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }


        }

        private void toolStripButton_BuscarGerencia_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteGerencia();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReporteGerencia()
        {
            dataGridView10.Columns.Clear();
            dataGridView10.DataSource = null;
            dataGridView10.DataSource = cn_contabilidad.ReporteGerencia();
            dataGridView10.ClearSelection();
        }

        private void toolStripButton_ExcelGerencia_Click(object sender, EventArgs e)
        {
            if (dataGridView10.Rows.Count > 0)
            {
                objexcel.ExportarExcel(dataGridView10);
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA EXPORTAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarGerencia_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (dataGridView10.Rows.Count > 0)
            {
                dataGridView10.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView10.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarGerencia(
                            Convert.ToInt32(dataGridView10[0, i].Value.ToString()),
                            dataGridView10[1, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView10.AllowUserToAddRows = true;

                }
                dataGridView10.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }


        }
    }

}
