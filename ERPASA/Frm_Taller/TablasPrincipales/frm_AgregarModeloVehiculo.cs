using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_AgregarModeloVehiculo : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();

        public frm_AgregarModeloVehiculo()
        {
            InitializeComponent();
        }

        private void frm_AgregarModeloVehiculo_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_MarcaVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox_Modelo.CharacterCasing = CharacterCasing.Upper;
            textBox_Obs.CharacterCasing = CharacterCasing.Upper;

        }

        public void CargarDatosComboBox()
        {
            comboBox_MarcaVehiculo.DataSource = cn_taller.ListaMarcaVehiculo("3", "%");
            comboBox_MarcaVehiculo.DisplayMember = "Marca"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_MarcaVehiculo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarVehiculos();
        }

        public void AlertaGuardarVehiculos()
        {
            if (comboBox_MarcaVehiculo.Text.Trim() == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MARCA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Modelo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DESCRIPCION DE MODELO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                var exchar = cn_taller.BuscExisteModeloVehiculo(
                    comboBox_MarcaVehiculo.Text,
                    textBox_Modelo.Text.Trim()
                    );

                if (exchar == true)
                {
                    MessageBox.Show("YA EXISTE MARCA Y MODELO INGRESADO");
                }
                else
                //{
                //if (exchar == false)
                {
                    string MessageBoxTitle = "GUARDAR";
                    string MessageBoxContent = "¿Desea guardar modelo? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {

                        objcntaller.GuardarModeloVehiculo(
                        comboBox_MarcaVehiculo.Text.Trim(), //marca
                        textBox_Modelo.Text.Trim(),//modelo
                        textBox_Obs.Text.Trim(),//obs

                        "S", //estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0,
                        0
                        );

                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                        ng.ShowDialog();

                        LimpiarCampos();
                        //AgregarColumna();
                    }

                    //}
                    //else
                    //{
                    //    MessageBox.Show("RANGO DE FECHA SELECCIONADA YA CUENTA CON REGISTRO","NO GUARDADO");
                    //    //Msbox.Frm_NotificacionesPeligro ng =
                    //    //new Msbox.Frm_NotificacionesPeligro("RANGO DE FECHAS YA CUENTA CON REGISTRO", Color.FromArgb(238, 24, 24), 3);
                    //    //ng.ShowDialog();
                    //}
                }

            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }

        public void LimpiarCampos()
        {
            textBox_Modelo.Text = "";
            textBox_Obs.Text = "";
        }

        private void comboBox_GrupoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_GrupoVehiculo.Text == comboBox_GrupoVehiculo.Text)
            //{
            //    comboBox_Marca.DataSource = cn_taller.ListaMarcaVehiculo(comboBox_GrupoVehiculo.Text);
            //    comboBox_Marca.DisplayMember = "Marca"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_Marca.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }
    }
}
