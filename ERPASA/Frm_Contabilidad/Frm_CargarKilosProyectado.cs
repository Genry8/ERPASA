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
    public partial class Frm_CargarKilosProyectado : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();
        DataTable dtKl = new DataTable();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_CargarKilosProyectado()
        {
            InitializeComponent();
        }

        private void Frm_CargarKilosProyectado_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            comboBox_año.SelectedIndex = 0;
            comboBox_año.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargar_Empresa();
            //textBox_Dni.Focus();
        }


        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR CULTIVO
            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            string emp, año, cult;
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }

            if (comboBox_año.Text == "SELECCIONE")
            {
                año = "%";
            }
            else
            {
                año = comboBox_año.Text;
            }
            if (comboBox_Cultivo.Text == "SELECCIONE")
            {
                cult = "%";
            }
            else
            {
                cult = comboBox_Cultivo.Text;
            }

            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            dataGridView1.Columns.Clear();

            dtKl = cn_contabilidad.ListaReporteKilosProyectado(
                    1, emp, año, cult);
            dataGridView1.DataSource = dtKl;
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

        private void toolStripButton_CargaMasiva_Click(object sender, EventArgs e)
        {
            Frm_ContKilosProyectadoMasivo frbm = new Frm_ContKilosProyectadoMasivo();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = guna2TextBox1.Text.Trim().Replace("'", "''");

            if (dtKl != null)
            {
                DataView dv = dtKl.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtKl.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }
    }
}
