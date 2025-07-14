using CapaEntidad;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_EditarVehiculos : Form
    {
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();

        public frm_EditarVehiculos()
        {
            InitializeComponent();
        }

        private void frm_EditarOrdenPoduccion_Load(object sender, EventArgs e)
        {
            comboBox_empresa.Text = ce_taller.empresa;
            comboBox_sede.Text = ce_taller.sede;
            //PonerOscuroComboBox();
            //CargarDatosComboBox();
            comboBox_GrupoVehiculo.Text = ce_taller.grupovehiculo;
            comboBox_Marca.Text = ce_taller.marca;
            comboBox_Modelo.Text = ce_taller.modelo;
            textBox_Area.Text = ce_taller.area;
            textBox_Placa.Text = ce_taller.placa;
            textBox_Vehiculo.Text = ce_taller.DescripcionVehiculo;
            textBox_Responsable.Text = ce_taller.responsable;

        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_TipoMerma.Enabled = false;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_GrupoVehiculo.DataSource = cn_taller.ListaGrupoVehiculo();
            comboBox_GrupoVehiculo.DisplayMember = "Grupo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_GrupoVehiculo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


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
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE
                comboBox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                //CARGAR SEDE
                comboBox_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
                comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaActualizarVehiculos();
        }

        public void AlertaActualizarVehiculos()
        {
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_sede.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_GrupoVehiculo.Text == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE GRUPO VEHICULO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Marca.Text == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MARCA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Modelo.Text == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MODELO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Area.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("COMPLETE AREA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Placa.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA PLACA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Vehiculo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DESCRIPCION DE VEHICULO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Responsable.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA RESPONSABLE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {

                string MessageBoxTitle = "ACTUALIZAR";
                string MessageBoxContent = "¿Desea actualizar registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    ////MessageBox.Show(""+ Convert.ToInt32(label_Id.Text.ToString()));
                    objcntaller.ActualizarListaVehiculos(
                        Convert.ToInt32(label_Id.Text.Trim()),
                    comboBox_empresa.Text,//EMPRESA
                    comboBox_sede.Text,//SEDE
                    textBox_Area.Text.Trim(),//area
                    textBox_Placa.Text.Trim(),//placa
                    textBox_Vehiculo.Text.Trim(),//vehiculo
                    comboBox_Marca.Text.Trim(),//marca
                    comboBox_Modelo.Text.Trim(),//modelo
                    textBox_Responsable.Text.Trim(),//responsable
                    "",
                    comboBox_GrupoVehiculo.Text.Trim(),//grupo 
                    textBox_Vehiculo.Text.Trim(),//nombre maquina
                    "",//potencia

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

        private void comboBox_GrupoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_GrupoVehiculo.Text == comboBox_GrupoVehiculo.Text)
            {
                comboBox_Marca.DataSource = cn_taller.ListaMarcaVehiculo("1", comboBox_GrupoVehiculo.Text);
                comboBox_Marca.DisplayMember = "Marca"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Marca.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Marca.Text == comboBox_Marca.Text)
            {
                //CARGAR MODELO
                comboBox_Modelo.DataSource = cn_taller.ListaModeloVehiculo("1", comboBox_Marca.Text);
                comboBox_Modelo.DisplayMember = "Modelo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Modelo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }
    }
}
