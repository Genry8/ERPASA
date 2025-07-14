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
    public partial class Frm_CampanaConsumidor : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_CampanaConsumidor()
        {
            InitializeComponent();
        }

        private void Frm_CampanaConsumidor_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargar_Empresa();
            //
            //BuscarReporteCapaña();
            //textBox_Dni.Focus();
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarReporteCapaña()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{


            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_contabilidad.ListaReporteCampaña(
                "%", "%", "%");

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ClearSelection();
            dataGridView1.AllowUserToAddRows = true;


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

            // 
            // Column3
            // 
            DataGridViewComboBoxColumn Cultivo = new DataGridViewComboBoxColumn();
            Cultivo.HeaderText = "Cultivo";
            Cultivo.Name = "Cultivo";
            Cultivo.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rowc = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dtc = new DataTable();
            dtc = cn_contabilidad.ListaCultivo("%", "%");
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow itemc in dtc.Rows)
            {
                rowc.Add(itemc[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Cultivo.Items.AddRange(rowc.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Insert(3, Cultivo);
            // 
            // Column3
            // 
            DataGridViewComboBoxColumn Etapa = new DataGridViewComboBoxColumn();
            Etapa.HeaderText = "Etapa";
            Etapa.Name = "Etapa";
            Etapa.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rowe = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dte = new DataTable();
            dte = cn_contabilidad.ListaEtapa();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow iteme in dte.Rows)
            {
                rowe.Add(iteme[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Etapa.Items.AddRange(rowe.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Insert(4, Etapa);

            int i;
            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                //EMPRESA
                dataGridView1.Rows[i].Cells[1].Value
                    = dataGridView1.Rows[i].Cells[5].Value;
                //SUCURAL
                dataGridView1.Rows[i].Cells[2].Value
                    = dataGridView1.Rows[i].Cells[6].Value;
                //CULTIVO
                dataGridView1.Rows[i].Cells[3].Value
                    = dataGridView1.Rows[i].Cells[7].Value;
                //ETAPA
                dataGridView1.Rows[i].Cells[4].Value
                    = dataGridView1.Rows[i].Cells[8].Value;
            }

            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[8].Visible = false;

            dataGridView1.Columns.RemoveAt(8);
            dataGridView1.Columns.RemoveAt(7);
            dataGridView1.Columns.RemoveAt(6);
            dataGridView1.Columns.RemoveAt(5);

            //}
            //else
            //{

            //}

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteCapaña();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView1);
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {

        }



        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<Reportes.Acopio.frm_AgregarMerma>();

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

        public void BuscarRegistroParaEditar()
        {
            if (dataGridView1.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
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

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.SelectedRows.Count > 0)
            //{
            //    if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
            //    {
            //        ElimarFila();
            //    }
            //    else
            //    {
            //        MessageBox.Show("ERROR -- SELECCIONE UN REGISTRO ACTIVO");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("SELECCIONE UNA FILA");
            //}
        }

        public void ElimarFila()
        {
            string MessageBoxTitle = "Eliminar";
            string MessageBoxContent = "¿Desea eliminar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {



            }
        }



        private void comboBox_campaña_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
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
                    objcnlog.GuardCampañaConta(
                        Convert.ToInt32(dataGridView1[0, i].Value.ToString()),
                        dataGridView1[2, i].Value.ToString(),
                        dataGridView1[3, i].Value.ToString(),
                        dataGridView1[4, i].Value.ToString(),
                        dataGridView1[5, i].Value.ToString(),
                        dataGridView1[6, i].Value.ToString(),
                        dataGridView1[7, i].Value.ToString(),
                        dataGridView1[8, i].Value.ToString(),

                        dataGridView1[1, i].Value.ToString(),//emp
                        "",//sede

                        "HOJA",//comboBox_Hojas.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );

                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();

            }

            BuscarReporteCapaña();

        }

        private void toolStripLabel_buscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
        }

        private void ColumnasDtgv1()
        {
            string emp, suc, cult;
            if (comboBox_empresa.Text == "SELECCIONE")
            { emp = "%"; }
            else { emp = comboBox_empresa.Text; }
            if (comboBox_sucursal.Text == "SELECCIONE")
            { suc = "%"; }
            else { suc = comboBox_sucursal.Text; }
            if (comboBox_cultivo.Text == "SELECCIONE")
            { cult = "%"; }
            else { cult = comboBox_cultivo.Text; }

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
            dts = cn_contabilidad.ListaSucursal(suc);
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
            DataGridViewComboBoxColumn Cultivo = new DataGridViewComboBoxColumn();
            Cultivo.HeaderText = "Cultivo";
            Cultivo.Name = "Cultivo";
            Cultivo.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rowc = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dtc = new DataTable();
            dtc = cn_contabilidad.ListaCultivo("%","%");
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow itemc in dtc.Rows)
            {
                rowc.Add(itemc[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Cultivo.Items.AddRange(rowc.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Cultivo);
            // 
            // Column3
            // 
            DataGridViewComboBoxColumn Etapa = new DataGridViewComboBoxColumn();
            Etapa.HeaderText = "Etapa";
            Etapa.Name = "Etapa";
            Etapa.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rowe = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dte = new DataTable();
            dte = cn_contabilidad.ListaEtapa();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow iteme in dte.Rows)
            {
                rowe.Add(iteme[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Etapa.Items.AddRange(rowe.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Etapa);


            // 
            // Column2
            // 

            DataGridViewComboBoxColumn IdConsumidor = new DataGridViewComboBoxColumn();
            IdConsumidor.HeaderText = "IdConsumidor";
            IdConsumidor.Name = "IdConsumidor";
            IdConsumidor.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rowic = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dtic = new DataTable();
            dtic = cn_contabilidad.ListaConsumidor("%","%","%");
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            foreach (DataRow items in dtic.Rows)
            {
                rowic.Add(items[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            IdConsumidor.Items.AddRange(rowic.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(IdConsumidor);


            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Campaña = new DataGridViewTextBoxColumn();
            Campaña.HeaderText = "Campaña";
            Campaña.Name = "Campaña";
            Campaña.Width = 85;
            dataGridView1.Columns.Add(Campaña);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn FechaInicio = new DataGridViewTextBoxColumn();
            FechaInicio.HeaderText = "FechaInicio";
            FechaInicio.Name = "FechaInicio";
            FechaInicio.Width = 87;
            dataGridView1.Columns.Add(FechaInicio);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn FechaFin = new DataGridViewTextBoxColumn();
            FechaFin.HeaderText = "FechaFin";
            FechaFin.Name = "FechaFin";
            FechaFin.Width = 87;
            dataGridView1.Columns.Add(FechaFin);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Factor = new DataGridViewTextBoxColumn();
            Factor.HeaderText = "Factor";
            Factor.Name = "Factor";
            Factor.Width = 87;
            dataGridView1.Columns.Add(Factor);

        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                comboBox_sucursal.DataSource = cn_contabilidad.ListaSucursal(comboBox_empresa.Text);
                comboBox_sucursal.DisplayMember = "Sucursal"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sucursal.ValueMember = "Sucursal"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            }
        }


    }
}
