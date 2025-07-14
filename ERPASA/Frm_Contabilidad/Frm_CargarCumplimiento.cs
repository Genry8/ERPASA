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
    public partial class Frm_CargarCumplimiento : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_CargarCumplimiento()
        {
            InitializeComponent();
        }

        private void Frm_CargarCumplimiento_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            comboBox_mes.SelectedIndex = 0;
            comboBox_año.SelectedIndex = 0;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_gerencia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_año.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_mes.DropDownStyle = ComboBoxStyle.DropDownList;
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
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaCumplimiento("%", "%");
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


        public void BuscarPartidaClasificar()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp,ger, area,año,mes;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            if (comboBox_gerencia.Text == "SELECCIONE")
            {
                ger = "%";
            }
            else
            {
                ger = comboBox_gerencia.Text;
            }
            if (comboBox_Area.Text == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = comboBox_Area.Text;
            }
            if (comboBox_año.Text == "SELECCIONE")
            {
                año = "%";
            }
            else
            {
                año = comboBox_año.Text;
            }
            if (comboBox_mes.Text == "SELECCIONE")
            {
                mes = "%";
            }
            else
            {
                mes = comboBox_mes.Text;
            }

            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource =
                cn_contabilidad.ListaReporteControlCumplimiento(
                    1, emp,ger,area, año,mes);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ClearSelection();

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
                        objcnlog.GuardActualizarControlCumplimientoConta(
                            Convert.ToInt32(dataGridView1[0, i].Value.ToString()),//id
                            dataGridView1[1, i].Value.ToString(),//empresa
                            "",//sede
                            dataGridView1[2, i].Value.ToString(),//gerencia
                            dataGridView1[3, i].Value.ToString(),//area
                            dataGridView1[4, i].Value.ToString(),//actividad
                            dataGridView1[5, i].Value.ToString(),//responsable  
                            dataGridView1[6, i].Value.ToString(),//clasificacion
                            dataGridView1[7, i].Value.ToString(),//fechaInicio
                            dataGridView1[8, i].Value.ToString(),//fecha obligacion
                            dataGridView1[9, i].Value.ToString(),//fecha cumplimiento
                            dataGridView1[10, i].Value.ToString(),//año
                            dataGridView1[11, i].Value.ToString(),//mes
                            "",//hoja
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
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaCumplimiento(emp, "%");
                comboBox_Area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Area.ValueMember = "Area"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

                //CARGAR SUCURSAL
                comboBox_gerencia.DataSource = cn_contabilidad.ListaGerenciaCumplimiento(emp);
                comboBox_gerencia.DisplayMember = "Gerencia"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_gerencia.ValueMember = "Gerencia"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
                
            //}
        }

        private void toolStripButton_CargaMasiva_Click(object sender, EventArgs e)
        {
            frm_ContCumplimientoMasivo frbm = new frm_ContCumplimientoMasivo();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void comboBox_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emp, ger;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            if (comboBox_gerencia.Text == "SELECCIONE")
            {
                ger = "%";
            }
            else
            {
                ger = comboBox_gerencia.Text;
            }
            //if (comboBox_sucursal.Text == comboBox_sucursal.Text)
            //{
            //CARGAR AREA
            comboBox_Area.DataSource = cn_contabilidad.ListaAreaCumplimiento(
                    emp, ger);
                comboBox_Area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Area.ValueMember = "Area"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //}
        }


    }
}
