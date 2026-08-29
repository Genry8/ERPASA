using CapaDatos;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{

    public partial class frm_DetalleInsumosVehiculo : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cu_excel objexcel = new cu_excel();

        public frm_DetalleInsumosVehiculo()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;            
        }

        private void frm_DetalleInsumosVehiculo_Load(object sender, EventArgs e)
        {
            textbox_Vehiculo.Focus();

            textbox_Vehiculo.CharacterCasing = CharacterCasing.Upper;
            dataGridView2.Columns.Clear();

            BuscarInsumo();
        }

        public void BuscarInsumo()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_taller.ListaDetalleInsumos(
                textBox_Grupo.Text, textBox_Marca.Text, textBox_Modelo.Text,
                textBox_KmProx.Text);
            dataGridView2.AllowUserToAddRows = false;
            //OrigenColorfila();
            dataGridView2.ClearSelection();
        }

        private void Frm_agregar_Resize(object sender, EventArgs e)
        {
            //AdjustForm();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BuscarInsumo();
        }

        private void toolStripButton_Refrescar_Click(object sender, EventArgs e)
        {
            BuscarInsumo();
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }
    }
}
