using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_ReportePedido : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;
        cu_excel_progress objexcel_progress = new cu_excel_progress();

        public Frm_ReportePedido()
        {
            InitializeComponent();
        }

        private void Frm_ReportePedido_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;

            //poner osucro

            //CargaDatos();

            Cargar_Empresa();
            PonerOscuroComboBox();
            CargaDatos();
        }

        public void CargaDatos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //    //CARGAR SEDE EMPRESA
            //    comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_empresa.Text);
            //    comboBox_CodSede_Comedor.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_CodSede_Comedor.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                textBox_marc.Focus();
                BuscarReportePedido();
                dataGridView1.ClearSelection();

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToAddRows = true;
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        public void BuscarReportePedido()
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

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_logistica.BuscarRegistroPedido(
            dateTimePicker_Fecha_Ini.Value.Date, dateTimePicker_Fecha_Fin.Value.Date
            , emp, "2");

            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.Rows.Count > 0)
            {
                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(3, 151, 43), 2);
                ng.Show();
            }
            else
            {
                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                ng.Show();
            }

            dataGridView1.AllowUserToAddRows = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox_marc.Focus();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToAddRows = true;
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            progressBar1.Visible = true;
            label_exportar_excel.Visible = true;

            dataGridView1.AllowUserToAddRows = false;
            objexcel_progress.exportarexcelTimer(dataGridView1, progressBar1);
            progressBar1.Visible = false;
            label_exportar_excel.Visible = false;

        }
    }
}
