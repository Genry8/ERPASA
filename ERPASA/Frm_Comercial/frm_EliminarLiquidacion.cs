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

namespace ERPASA.Frm_Comercial
{
    public partial class frm_EliminarLiquidacion : Form,
        VarDatosEntroFormLiquidacion
    {
        public frm_EliminarLiquidacion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void guna2TextBox_liquidacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_liquidacion_DoubleClick(object sender, EventArgs e)
        {
            frm_BuscarLiquidacion frbm = new frm_BuscarLiquidacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        public void TablaAgregarDatosFilaLiquidacion(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigLiquidacion(DataGridViewRow fila1a)
        {
            string fecha = ((DateTime)fila1a.Cells[0].Value).ToString("yyyy-MM-dd");
            string liquidacion = (string)fila1a.Cells[1].Value;
            guna2TextBox_fecha.Text = fecha;
            guna2TextBox_liquidacion.Text = liquidacion;
        }

        private void pictureBox_EliminarLiq_Click(object sender, EventArgs e)
        {
            if (guna2TextBox_fecha.Text.Trim() == "")
            {
                MessageBox.Show("SELECCIONE LIQUIDACION");
            }
            else if (guna2TextBox_liquidacion.Text.Trim() == "")
            {
                MessageBox.Show("SELECCIONE LIQUIDACION");
            }
            else
            {
                string MessageBoxTitle = "ELIMINAR";
                string MessageBoxContent = "¿Desea eliminar liquidacion? \n" +
                    guna2TextBox_liquidacion.Text.Trim().ToString() +
                    "\n De fecha: " + guna2TextBox_fecha.Text.Trim();

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    EliminarLiquidacion();
                }

            }

        }

        public void EliminarLiquidacion()
        {
            cn_comercial.BuscarReporteLiquidacion(
            Convert.ToDateTime(guna2TextBox_fecha.Text.ToString()),
            Convert.ToDateTime(guna2TextBox_fecha.Text.ToString())
            , guna2TextBox_liquidacion.Text.Trim(), "3");
            MessageBox.Show("LIQUIDACION ELIMINADO");
            guna2TextBox_fecha.Text = "";
            guna2TextBox_liquidacion.Text = "";
        }

        private void frm_EliminarLiquidacion_Load(object sender, EventArgs e)
        {
            guna2TextBox_liquidacion.Focus();
        }

        private void guna2TextBox_fecha_DoubleClick(object sender, EventArgs e)
        {
            frm_BuscarLiquidacion frbm = new frm_BuscarLiquidacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }
    }

    internal interface VarDatosEntroFormLiquidacion
    {
        void TablaAgregarDatosFilaLiquidacion(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigLiquidacion(DataGridViewRow fila1a);
    }

}
