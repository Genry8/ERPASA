using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_ClasificacionPartidas : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_ClasificacionPartidas()
        {
            InitializeComponent();
        }

        private void Frm_ClasificacionPartidas_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            BuscarPartidaSinClasificar();
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargar_Empresa();
            //textBox_Dni.Focus();
        }


        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR AREA
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaPartida("%", "%", "%");
            comboBox_Area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Area.ValueMember = "Area"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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


        public void BuscarPartidaSinClasificar()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{


            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            //DataTable dt = new DataTable();
            //dt = cn_contabilidad.ListaPartidasNisira();

            //dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = dt;
            //dataGridView1.AllowUserToAddRows = false;
            ////dataGridView2.Columns.Clear();
            ////dataGridView2.DataSource = dt;

            //objcnlog.EliminarPartida();

            //int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
            //int a;
            //for (int i = 0; i <= filas - 1; i++)
            ////foreach (DataGridViewRow dr in dataGridView1.Rows)
            //{
            //    objcnlog.GuardarPartidasNisira(
            //        dataGridView1[0,i].Value.ToString(),
            //        dataGridView1[1,i].Value.ToString(),
            //        dataGridView1[2,i].Value.ToString(),

            //        ce_usuario.FechaSistema(),
            //        ce_usuario.usecod,
            //        ce_usuario.HostName(),
            //        ce_usuario.FechaSistema(),
            //        ce_usuario.usecod
            //        );
            //}

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource =
                cn_contabilidad.ListaReportePartidasPendientes(1, "%", "%", "%", "%");

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ClearSelection();
            //dataGridView2.AllowUserToAddRows = true;

            //}
            //else
            //{

            //}

        }


        public void BuscarPartidaClasificar()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp,suc,cultivo, area;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            if (comboBox_sucursal.Text == "SELECCIONE")
            {
                suc = "%";
            }
            else
            {
                suc = comboBox_sucursal.Text;
            }
            if (comboBox_cultivo.Text == "SELECCIONE")
            {
                cultivo = "%";
            }
            else
            {
                cultivo = comboBox_cultivo.Text;
            }
            if (comboBox_Area.Text == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = comboBox_Area.Text;
            }


            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();


            dataGridView1.Columns.Clear();
            dataGridView1.DataSource =
                cn_contabilidad.ListaReportePartidasPendientes(2, emp,suc,cultivo, area);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ClearSelection();

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




        private void toolStripButton_buscarPend_Click_1(object sender, EventArgs e)
        {
            BuscarPartidaSinClasificar();
        }

        private void toolStripButton_excelPend_Click_1(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }

        private void toolStripButton_guardarPend_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {

                textBox1.Focus();

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
                        objcnlog.GuardActualizarPartidasConta(
                            dataGridView2[0, i].Value.ToString(),//empresa
                            "",//area sistema
                            dataGridView2[1, i].Value.ToString(),//cod
                            dataGridView2[2, i].Value.ToString(),//partida
                            dataGridView2[3, i].Value.ToString(),//partida_final
                            dataGridView2[4, i].Value.ToString(),//sucursal
                            dataGridView2[5, i].Value.ToString(),//cultivo
                            dataGridView2[6, i].Value.ToString(),//etapa
                            "",//valid
                            dataGridView2[7, i].Value.ToString(),//tipo gasto
                            dataGridView2[8, i].Value.ToString(),//tipo estr
                            dataGridView2[9, i].Value.ToString(),//Area
                            "",//etiqueta
                            dataGridView2[10, i].Value.ToString(),//tipo recur
                            dataGridView2[11, i].Value.ToString(),//recurso
                            dataGridView2[12, i].Value.ToString(),//clasific
                            dataGridView2[13, i].Value.ToString(),//gerencia
                            "",//agrup

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

            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("CARGUE AL MENOS 1 REGISTRO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscarClasif_Click(object sender, EventArgs e)
        {
            BuscarPartidaClasificar();
        }

        private void toolStripButton_ExcelClasif_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView1);
        }

        private void toolStripButtonGuardarClasif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                textBox1.Focus();

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
                        objcnlog.GuardActualizarPartidasConta(
                            dataGridView1[0, i].Value.ToString(),//empresa
                            "",//area sistema
                            dataGridView1[1, i].Value.ToString(),//cod
                            dataGridView1[2, i].Value.ToString(),//partida
                            dataGridView1[3, i].Value.ToString(),//partida_final
                            dataGridView1[4, i].Value.ToString(),//sucursal
                            dataGridView1[5, i].Value.ToString(),//cultivo
                            dataGridView1[6, i].Value.ToString(),//etapa
                            "",//valid
                            dataGridView1[7, i].Value.ToString(),//tipo gasto
                            dataGridView1[8, i].Value.ToString(),//tipo estr
                            dataGridView1[9, i].Value.ToString(),//Area
                            "",//etiqueta
                            dataGridView1[10, i].Value.ToString(),//tipo recur
                            dataGridView1[11, i].Value.ToString(),//recurso
                            dataGridView1[12, i].Value.ToString(),//clasific
                            dataGridView1[13, i].Value.ToString(),//gerencia
                            "",//agrup

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

            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("CARGUE AL MENOS 1 REGISTRO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emp;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //CARGAR AREA
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaPartida(emp, "%", "%");
                comboBox_Area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Area.ValueMember = "Area"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

                //CARGAR SUCURSAL
                comboBox_sucursal.DataSource = cn_contabilidad.ListaSucursal(emp);
                comboBox_sucursal.DisplayMember = "Sucursal"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sucursal.ValueMember = "Sucursal"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
                
            //}
        }

        private void toolStripButton_CargaMasiva_Click(object sender, EventArgs e)
        {
            frm_PartidasCargaMasiva frbm = new frm_PartidasCargaMasiva();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void comboBox_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emp, suc;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            if (comboBox_sucursal.Text == "SELECCIONE")
            {
                suc = "%";
            }
            else
            {
                suc = comboBox_sucursal.Text;
            }
            //if (comboBox_sucursal.Text == comboBox_sucursal.Text)
            //{
            //CARGAR AREA
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaPartida(
                    emp, suc, "%");
                comboBox_Area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Area.ValueMember = "Area"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

                //CARGAR CULTIVO
                comboBox_cultivo.DataSource = cn_contabilidad.ListaCultivo(emp,suc);
                comboBox_cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_cultivo.ValueMember = "Cultivo"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            
            //}
        }


        private void comboBox_cultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emp, suc, cultivo;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            if (comboBox_sucursal.Text == "SELECCIONE")
            {
                suc = "%";
            }
            else
            {
                suc = comboBox_sucursal.Text;
            }
            if (comboBox_cultivo.Text == "SELECCIONE")
            {
                cultivo = "%";
            }
            else
            {
                cultivo = comboBox_cultivo.Text;
            }
            //if (comboBox_cultivo.Text == comboBox_cultivo.Text)
            //{
            //CARGAR AREA
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaPartida(
                emp, suc, cultivo);
                comboBox_Area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Area.ValueMember = "Area"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}

        }
    }
}
