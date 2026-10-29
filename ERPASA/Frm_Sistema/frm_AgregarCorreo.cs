using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    /// <summary>
    /// Alta y edición de una configuración de correo (PACK_EnviarCorreo).
    ///
    /// Un solo formulario para los dos casos: lo que los distingue es
    /// label_Id, donde "0" significa alta.
    /// </summary>
    public partial class frm_AgregarCorreo : Form
    {
        cn_packing objcnpacking = new cn_packing();

        public frm_AgregarCorreo()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            // Va después del estilizador: se mide lo que quedó en pantalla.
            this.Load += delegate { AjustarVentanaAlContenido(); };
        }

        /// <summary>
        /// Deja la ventana del tamaño que piden los campos.
        ///
        /// El escalado automático de WinForms no encoge la caja de datos en la
        /// misma proporción que el formulario, así que la columna de la derecha
        /// (gerencia y área) quedaba cortada. Se mide el borde real de los
        /// campos y se agranda la ventana hasta donde alcance la pantalla; si
        /// no alcanza, el contenido se puede desplazar.
        /// </summary>
        private void AjustarVentanaAlContenido()
        {
            // Mientras se mide, la caja no debe seguir al tamaño del formulario.
            AnchorStyles anclaje = groupBox1.Anchor;
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            int derecha = 0;
            int abajo = 0;
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Right > derecha) derecha = c.Right;
                if (c.Bottom > abajo) abajo = c.Bottom;
            }

            groupBox1.Size = new Size(derecha + 20, abajo + 20);

            int anchoPedido = groupBox1.Right + groupBox1.Left;
            int altoPedido = groupBox1.Bottom + groupBox1.Top;

            Rectangle util = Screen.FromControl(this).WorkingArea;
            int ancho = Math.Min(anchoPedido, util.Width - 60);
            int alto = Math.Min(altoPedido, util.Height - 80);

            // Si la pantalla no da para tanto, la ventana se desplaza.
            AutoScroll = ancho < anchoPedido || alto < altoPedido;

            ClientSize = new Size(ancho, alto);
            groupBox1.Anchor = anclaje;

            CenterToScreen();
        }

        private void frm_AgregarCorreo_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();

            // En edición los valores llegan por ce_enviarcorreo desde el reporte.
            if (label_Id.Text != "0")
            {
                Text = "EDITAR CONFIGURACION DE CORREO";
                CargarDatosParaEditar();
            }
            else
            {
                // Un alta nace con su propio identificador de envío.
                textBox_UUID.Text = Guid.NewGuid().ToString();
            }
        }

        public void PonerOscuroComboBox()
        {
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
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
            comboBox_empresa.Text = ce_enviarcorreo.empresa;
            comboBox_sede.Text = ce_enviarcorreo.sede;

            // La fecha llega como texto desde la grilla; si no se puede leer se
            // deja la de hoy en vez de reventar la pantalla.
            DateTime fecha;
            if (DateTime.TryParse(ce_enviarcorreo.fecha, out fecha))
                dateTimePicker_Fecha.Value = fecha;

            textBox_Gerencia.Text = ce_enviarcorreo.gerencia;
            textBox_Area.Text = ce_enviarcorreo.area;
            textBox_Responsable.Text = ce_enviarcorreo.responsable;
            textBox_Formulario.Text = ce_enviarcorreo.formulario;
            textBox_TipoCorreo.Text = ce_enviarcorreo.tipocorreo;
            textBox_De.Text = ce_enviarcorreo.de;
            textBox_Para.Text = ce_enviarcorreo.para;
            textBox_CC.Text = ce_enviarcorreo.cc;
            textBox_Asunto.Text = ce_enviarcorreo.asunto;
            textBox_Cuerpo.Text = ce_enviarcorreo.cuerpo;
            textBox_UUID.Text = ce_enviarcorreo.uuid;
        }

        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            textBox_Gerencia.Text = "";
            textBox_Area.Text = "";
            textBox_Responsable.Text = "";
            textBox_Formulario.Text = "";
            textBox_TipoCorreo.Text = "";
            textBox_De.Text = "";
            textBox_Para.Text = "";
            textBox_CC.Text = "";
            textBox_Asunto.Text = "";
            textBox_Cuerpo.Text = "";
            textBox_UUID.Text = Guid.NewGuid().ToString();
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarCorreo();
        }

        public void AlertaGuardarCorreo()
        {
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE EMPRESA");
            }
            else if (comboBox_sede.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE SEDE");
            }
            else if (textBox_Formulario.Text.Trim() == "")
            {
                Avisar("FALTA EL FORMULARIO");
            }
            else if (textBox_TipoCorreo.Text.Trim() == "")
            {
                Avisar("FALTA EL TIPO DE CORREO");
            }
            else if (textBox_De.Text.Trim() == "")
            {
                Avisar("FALTA EL REMITENTE (DE)");
            }
            else if (textBox_Para.Text.Trim() == "")
            {
                Avisar("FALTA EL DESTINATARIO (PARA)");
            }
            else if (textBox_Asunto.Text.Trim() == "")
            {
                Avisar("FALTA EL ASUNTO");
            }
            else
            {
                int id = Convert.ToInt32(label_Id.Text.Trim());

                // En edición se excluye el propio registro de la verificación.
                var existe = cn_packing.BuscExisteEnviarCorreo(
                    comboBox_empresa.Text,
                    comboBox_sede.Text,
                    textBox_Formulario.Text.Trim(),
                    textBox_TipoCorreo.Text.Trim(),
                    id);

                if (existe == true)
                {
                    Avisar("ESE CORREO YA ESTA REGISTRADO, VERIFIQUE NUEVAMENTE");
                    return;
                }

                string MessageBoxTitle = id == 0 ? "GUARDAR" : "ACTUALIZAR";
                string MessageBoxContent = id == 0
                    ? "¿Desea guardar la configuración? "
                    : "¿Desea actualizar la configuración? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult != DialogResult.Yes) return;

                // Si el identificador de envío quedó vacío se genera uno: la
                // tabla lo usa para reconocer cada correo.
                string uuid = textBox_UUID.Text.Trim();
                if (uuid == "") uuid = Guid.NewGuid().ToString();

                if (id == 0)
                {
                    objcnpacking.GuardarEnviarCorreo(
                        dateTimePicker_Fecha.Value,
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        textBox_Gerencia.Text.Trim(),
                        textBox_Area.Text.Trim(),
                        textBox_Responsable.Text.Trim(),
                        textBox_Formulario.Text.Trim(),
                        textBox_TipoCorreo.Text.Trim(),
                        textBox_De.Text.Trim(),
                        textBox_Para.Text.Trim(),
                        textBox_CC.Text.Trim(),
                        textBox_Asunto.Text.Trim(),
                        textBox_Cuerpo.Text.Trim(),
                        uuid,

                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName()
                        );

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    LimpiarCampos();
                }
                else
                {
                    objcnpacking.ActualizarEnviarCorreo(
                        id,
                        dateTimePicker_Fecha.Value,
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        textBox_Gerencia.Text.Trim(),
                        textBox_Area.Text.Trim(),
                        textBox_Responsable.Text.Trim(),
                        textBox_Formulario.Text.Trim(),
                        textBox_TipoCorreo.Text.Trim(),
                        textBox_De.Text.Trim(),
                        textBox_Para.Text.Trim(),
                        textBox_CC.Text.Trim(),
                        textBox_Asunto.Text.Trim(),
                        textBox_Cuerpo.Text.Trim(),
                        uuid,
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
