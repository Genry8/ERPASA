using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_EstadosPT : Form
    {
        cn_sst objcnlog = new cn_sst();
        private List<ce_packingPT> datosRecibidos;
        Frm_Reporte_PT frm_Reporte_PT = new Frm_Reporte_PT();

        public Frm_EstadosPT(List<ce_packingPT> lista)
        {
            InitializeComponent();
            datosRecibidos = lista;
        }

        private void Frm_EstadosPT_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            CargarDatosDataGridView();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_EstadoPT.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_EstadoPT.DataSource = cn_logistica.ListaEstadoPT();
            comboBox_EstadoPT.DisplayMember = "Estado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_EstadoPT.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        public void CargarDatosDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = datosRecibidos;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            GuardarEstadoPT();
        }

        public void GuardarEstadoPT()
        {
            if (comboBox_EstadoPT.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE ESTADO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                if (dataGridView1.RowCount < 1)
                {
                    MessageBox.Show("SIN DATOS REVISE PALETS");
                }
                else
                {
                    string MessageBoxTitle = "ACTUALIZAR";
                    string MessageBoxContent = "¿Desea actualizar registros?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            objcnlog.ActualizarEstadoPT(
                                row.Cells[0].Value.ToString(),
                                comboBox_EstadoPT.Text.Trim(),
                                ce_usuario.usecod,
                                ce_usuario.FechaSistema()
                                );
                            Cursor.Current = Cursors.WaitCursor;
                        }
                        //frm_Reporte_PT.CargarDatosSync();
                        MessageBox.Show("ESTADO ACTUALIZADO CORRECTAMENTE");
                        this.Close();
                    }
                }
            }
        }

    }
}
