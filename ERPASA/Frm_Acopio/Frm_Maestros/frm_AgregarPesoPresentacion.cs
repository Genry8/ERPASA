using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Acopio.Frm_Maestros
{
    /// <summary>
    /// Alta y edición de un peso por presentación (PACK_PesoPresentacion).
    ///
    /// Un solo formulario para los dos casos: lo que los distingue es
    /// label_Id, donde "0" significa alta.
    /// </summary>
    public partial class frm_AgregarPesoPresentacion : Form
    {
        cn_packing objcnpacking = new cn_packing();

        public frm_AgregarPesoPresentacion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void frm_AgregarPesoPresentacion_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();

            // En edición los valores llegan por ce_pesopresentacion desde el reporte.
            if (label_Id.Text != "0")
            {
                Text = "EDITAR PESO POR PRESENTACION";
                CargarDatosParaEditar();
            }
        }

        public void PonerOscuroComboBox()
        {
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CARGAR SEDE
            comboBox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
            comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        /// <summary>
        /// Rellena la pantalla con el registro elegido en el reporte. La sede
        /// se asigna después de la empresa porque su lista depende de ella.
        /// </summary>
        private void CargarDatosParaEditar()
        {
            comboBox_empresa.Text = ce_pesopresentacion.empresa;
            comboBox_sede.Text = ce_pesopresentacion.sede;
            comboBox_Cultivo.Text = ce_pesopresentacion.cultivo;

            textBox_Presentacion.Text = ce_pesopresentacion.presentacion;
            textBox_Peso.Text = ce_pesopresentacion.peso;
            textBox_PorcentajeMin.Text = ce_pesopresentacion.porcentajemin;
            textBox_Porcentaje.Text = ce_pesopresentacion.porcentaje;
            textBox_Obs.Text = ce_pesopresentacion.obs;
        }

        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            textBox_Presentacion.Text = "";
            textBox_Peso.Text = "";
            textBox_PorcentajeMin.Text = "";
            textBox_Porcentaje.Text = "";
            textBox_Obs.Text = "";
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarPesoPresentacion();
        }

        public void AlertaGuardarPesoPresentacion()
        {
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE EMPRESA");
            }
            else if (comboBox_sede.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE SEDE");
            }
            else if (comboBox_Cultivo.Text == "SELECCIONE" || comboBox_Cultivo.Text.Trim() == "")
            {
                Avisar("SELECCIONE CULTIVO");
            }
            else if (textBox_Presentacion.Text.Trim() == "")
            {
                Avisar("FALTA PRESENTACION");
            }
            else if (cu_valores.Decimal(textBox_Peso.Text) <= 0)
            {
                Avisar("EL PESO DEBE SER MAYOR A CERO");
            }
            else
            {
                int id = Convert.ToInt32(label_Id.Text.Trim());

                // En edición se excluye el propio registro de la verificación.
                var existe = cn_packing.BuscExistePesoPresentacion(
                    comboBox_empresa.Text,
                    comboBox_sede.Text,
                    comboBox_Cultivo.Text,
                    textBox_Presentacion.Text.Trim(),
                    id);

                if (existe == true)
                {
                    Avisar("ESA PRESENTACION YA ESTA REGISTRADA, VERIFIQUE NUEVAMENTE");
                    return;
                }

                string MessageBoxTitle = id == 0 ? "GUARDAR" : "ACTUALIZAR";
                string MessageBoxContent = id == 0
                    ? "¿Desea guardar la presentación? "
                    : "¿Desea actualizar la presentación? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult != DialogResult.Yes) return;

                // Los tres importes se leen con cu_valores: una celda vacía o
                // con texto queda en cero en vez de tumbar el guardado.
                decimal peso = cu_valores.Decimal(textBox_Peso.Text);
                decimal porcentajeMin = cu_valores.Decimal(textBox_PorcentajeMin.Text);
                decimal porcentaje = cu_valores.Decimal(textBox_Porcentaje.Text);

                if (id == 0)
                {
                    objcnpacking.GuardarPesoPresentacion(
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        comboBox_Cultivo.Text,//cultivo
                        textBox_Presentacion.Text.Trim(),//presentacion
                        peso,
                        porcentajeMin,
                        porcentaje,
                        textBox_Obs.Text.Trim(),//obs

                        "S", //estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0,
                        0
                        );

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    LimpiarCampos();
                }
                else
                {
                    objcnpacking.ActualizarPesoPresentacion(
                        id,
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        comboBox_Cultivo.Text,//cultivo
                        textBox_Presentacion.Text.Trim(),//presentacion
                        peso,
                        porcentajeMin,
                        porcentaje,
                        textBox_Obs.Text.Trim(),//obs
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    Close();
                }
            }
        }

        private void Avisar(string mensaje)
        {
            Msbox.Frm_NotificacionesPeligro ng =
                new Msbox.Frm_NotificacionesPeligro(mensaje, Color.FromArgb(238, 24, 24), 3);
            ng.ShowDialog();
        }
    }
}
