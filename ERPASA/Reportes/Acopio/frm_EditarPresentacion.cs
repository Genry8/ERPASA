using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class frm_EditarPresentacion : Form
    {
        cn_packing objcnpack = new cn_packing();
        cn_planilla objcnlog = new cn_planilla();
        cd_nisira objnisira = new cd_nisira();

        public frm_EditarPresentacion()
        {
            InitializeComponent();
        }

        private void frm_EditarPresentacion_Load(object sender, EventArgs e)
        {
            //comboBox_Presentacion.DataSource = objnisira.ListaPresentacion(label_Cultivo.Text);
            //comboBox_Presentacion.DisplayMember = "Presentacion"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Presentacion.ValueMember = "IdPresentacion"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_Presentacion.SelectedText=label_presentacion.Text;
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Campana.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Presentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox_Cultivo.Enabled = false;
            comboBox_Campana.Enabled = false;
            //comboBox_TipoMerma.Enabled = false;
            comboBox_detalle_empresa.Enabled = false;
            comboBox_detalle_sede.Enabled = false;

        }

        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Campana.DataSource = cn_packing.ListaCampana();
            comboBox_Campana.DisplayMember = "Campana"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Campana.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMerma();
            //comboBox_TipoMerma.DisplayMember = "Merma"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinaria();
            //comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_Variedad.DataSource = cn_packing.ListaVariedad();
            //comboBox_Variedad.DisplayMember = "Id"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Variedad.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarPresentacion();
        }

        public void AlertaGuardarPresentacion()
        {
            decimal pes;
            if (textBox_Peso.Text.Trim() == "")
            {
                pes = 0;
            }
            else { pes = Convert.ToDecimal(textBox_Peso.Text); }
            if (textBox_Peso.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE PESO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_cajas.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE CAJAS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                string MessageBoxTitle = "ACTUALIZAR ";
                string MessageBoxContent = "¿Desea actualizar registros? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcnpack.ActualizarPresentacion(
                    Convert.ToInt32(label_Id.Text.ToString()),
                    label_codPre.Text.ToString(),
                    label_presentacion.Text.ToString(),
                    pes,//prioridad
                    textBox_cajas.Text,//prioridad

                    textBox_Obs.Text,
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod

                    );

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_Peso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_cajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }
    }
}
