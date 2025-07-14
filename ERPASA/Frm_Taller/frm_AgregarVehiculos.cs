using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_AgregarVehiculos : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();

        public frm_AgregarVehiculos()
        {
            InitializeComponent();
        }

        private void frm_AgregarOrdenProduccion_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_GrupoVehiculo.DataSource = cn_taller.ListaGrupoVehiculo();
            comboBox_GrupoVehiculo.DisplayMember = "Grupo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_GrupoVehiculo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMaquinaria();
            //comboBox_TipoMerma.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaMaquinariaFiler();
            //comboBox_TipoMerma.DisplayMember = "Filer"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            //if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    //CARGAR SEDE
            //    comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //    comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }


        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            else if (textBoxArea.Text.Trim() == "")
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
                var exchar = cn_taller.BuscExistePlacaVehiculo(
                    textBox_Placa.Text
                    );

                if (exchar == true)
                {
                    Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("PLACA YA EXISTE, VERIFIQUE NUEVAMENTE", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else
                //{
                //if (exchar == false)
                {
                    string MessageBoxTitle = "GUARDAR ";
                    string MessageBoxContent = "¿Desea guardar vehiculo? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {

                        objcntaller.GuardarListaVehiculos(
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        textBoxArea.Text.Trim(),//area
                        textBox_Placa.Text.Trim(),//placa
                        textBox_Vehiculo.Text.Trim(),//vehiculo
                        comboBox_Marca.Text.Trim(),//marca
                        comboBox_Modelo.Text.Trim(),//modelo
                        textBox_Responsable.Text.Trim(),//responsable
                        "",
                        comboBox_GrupoVehiculo.Text.Trim(),//grupo 
                        textBox_Vehiculo.Text.Trim(),//nombre maquina
                        "",//potencia

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

        private void comboBox_GrupoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_GrupoVehiculo.Text == comboBox_GrupoVehiculo.Text)
            {
                comboBox_Marca.DataSource = cn_taller.ListaMarcaVehiculo("1", comboBox_GrupoVehiculo.Text);
                comboBox_Marca.DisplayMember = "Marca"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Marca.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }
    }
}
