using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class Frm_RegistrarVehiculos : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();
        cn_taller objcntaller = new cn_taller();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_RegistrarVehiculos()
        {
            InitializeComponent();
        }

        private void Frm_SaveOrdenProduccion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            BuscarReporteListaVehiculos();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_GrupoVehiculo.DataSource = cn_taller.ListaGrupoVehiculo();
            comboBox_GrupoVehiculo.DisplayMember = "Grupo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_GrupoVehiculo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMerma();
            //comboBox_TipoMerma.DisplayMember = "Merma"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_detalle_empresa.Text == comboBox_detalle_empresa.Text)
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_detalle_empresa.Text);
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarReporteListaVehiculos()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp, sed, grupo;
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_detalle_empresa.Text;
            }
            if (comboBox_detalle_sede.Text == "SELECCIONE")
            {
                sed = "%";
            }
            else
            {
                sed = comboBox_detalle_sede.Text;
            }
            if (comboBox_GrupoVehiculo.Text == "NO ESPECIFICA")
            {
                grupo = "%";
            }
            else
            {
                grupo = comboBox_GrupoVehiculo.Text;
            }


            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_taller.ListaReporteVehiculos(
                emp, sed, grupo);

            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

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
                BuscarReporteListaVehiculos();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {

        }



        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<Reportes.Acopio.frm_AgregarMerma>();

            frm_AgregarVehiculos frbm = new frm_AgregarVehiculos();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
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
            //frm_EditarMerma frbm = new frm_EditarMerma();
            //AddOwnedForm(frbm);
            //frbm.ShowDialog();
            BuscarRegistroParaEditar();

        }

        public void BuscarRegistroParaEditar()
        {
            if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
            {

                frm_EditarVehiculos obj = new frm_EditarVehiculos();
                obj.PonerOscuroComboBox();
                obj.CargarDatosComboBox();
                obj.label_Id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                ce_taller.empresa = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                ce_taller.sede = dataGridView2.CurrentRow.Cells[2].Value.ToString();

                //obj.comboBox_Cultivo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                //obj.comboBox_Campana.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();

                ce_taller.area = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                ce_taller.placa = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                ce_taller.DescripcionVehiculo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                ce_taller.marca = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                ce_taller.modelo = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                ce_taller.responsable = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                ce_taller.grupovehiculo = dataGridView2.CurrentRow.Cells[10].Value.ToString();

                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO SE PUEDE EDITAR, PORQUE ESTA ELIMINADO");
            }
        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
                {
                    ElimarFila();
                }
                else
                {
                    MessageBox.Show("ERROR -- SELECCIONE UN REGISTRO ACTIVO");
                }
            }
            else
            {
                MessageBox.Show("SELECCIONE UNA FILA");
            }
        }

        public void ElimarFila()
        {
            string MessageBoxTitle = "Eliminar";
            string MessageBoxContent = "¿Desea eliminar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                objcntaller.EliminarListaVehiculo(
                dataGridView2.CurrentRow.Cells[0].Value.ToString(),
                ce_usuario.FechaSistema(),
                ce_usuario.usecod
                 );

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
                ng.ShowDialog();
                //Close();


                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    BuscarReporteListaVehiculos();
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                //dataGridView2.ClearSelection();
            }
        }


        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells["Estado"].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }



    }
}
