using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Correo
{
    public partial class EnviarCorreo : Form
    {
        cn_correo objcncorreo = new cn_correo();
        public EnviarCorreo()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, campos y botón).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void EnviarCorreo_Load(object sender, EventArgs e)
        {
            label_IDCorreo.Text = ce_correo.codCorreo.ToString();
            ///
            CargarDatos();
            guna2TextBox_Asunto.Focus();
            ///
            DivirCorreo();

        }

        public void CargarDatos()
        {
            cn_correo.BuscDatosCorreo(ce_correo.codCorreo);
            label_formulario.Text = ce_correo.formulario;
            guna2TextBox_De.Text = ce_correo.de;
            guna2TextBox_Para.Text = ce_correo.para;
            guna2TextBox_CC.Text = ce_correo.cc;
            guna2TextBox_Asunto.Text = ce_correo.asunto;
            guna2TextBox_Cuerpo.Text = ce_correo.cuerpo;
        }

        public void DivirCorreo()
        {
            string[] correos = ce_correo.cc
    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < correos.Length; i++)
            {
                sb.Append(correos[i] + ";");

                // Salto de línea cada 2 correos
                if ((i + 1) % 2 == 0)
                    sb.AppendLine();
                else
                    sb.Append(" "); // Espacios entre los 2 correos de la misma línea
            }

            guna2TextBox_CC.Multiline = true;
            guna2TextBox_CC.ScrollBars = ScrollBars.Vertical;
            guna2TextBox_CC.Text = sb.ToString();

            //PARA EL ASUNTO
            guna2TextBox_Asunto.Multiline = true;
            guna2TextBox_Asunto.WordWrap = true;
            guna2TextBox_Asunto.ScrollBars = ScrollBars.Vertical;

            //PARA EL CUERPO
            guna2TextBox_Cuerpo.Multiline = true;
            guna2TextBox_Cuerpo.WordWrap = true;
            guna2TextBox_Cuerpo.ScrollBars = ScrollBars.Vertical;

        }

        private void pictureBox_EnviarCorreo_Click(object sender, EventArgs e)
        {
            validarEnvio();
        }

        public void validarEnvio()
        {
            if (guna2TextBox_De.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA USUARIO QUE ENVIE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (guna2TextBox_Para.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE AL MENOS UN CORREO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (guna2TextBox_Asunto.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA ASUNTO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (guna2TextBox_Cuerpo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE UNA DESCRIPCION DE CORREO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                GuardarDatos();
                //AsyncRegistroDTGAsync();
            }
        }

        public void GuardarDatos()
        {
            string MessageBoxTitle = "ENVIAR";
            string MessageBoxContent = "¿Desea enviar correo?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (SendCorreo())
                {
                    objcncorreo.GuardarActualizarDatosCorreo(
                        ce_correo.codCorreo,
                        guna2TextBox_De.Text.Trim(),
                        guna2TextBox_Para.Text.Trim(),
                        guna2TextBox_CC.Text.Trim(),
                        guna2TextBox_Asunto.Text.Trim(),
                        guna2TextBox_Cuerpo.Text.Trim(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                    );

                    MessageBox.Show("Correo enviado");
                }
                else
                {
                    MessageBox.Show("ERROR AL ENVIAR");
                }

            }

        }

        public bool SendCorreo()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (MailMessage correo = new MailMessage())
                {
                    // Remitente
                    correo.From = new MailAddress(
                        ce_correo.UsuarioSMTP,
                        "Sistema ERPASA"
                    );


                    // PARA
                    string[] destinatarios = guna2TextBox_Para.Text
                        .Split(new[] { ';', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string email in destinatarios)
                    {
                        string correoDestino = email.Trim();

                        if (!string.IsNullOrWhiteSpace(correoDestino))
                        {
                            correo.To.Add(correoDestino);
                        }
                    }


                    // Validar destinatarios
                    if (correo.To.Count == 0)
                    {
                        MessageBox.Show(
                            "No existe un destinatario válido.",
                            "Correo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return false;
                    }


                    // CC
                    if (!string.IsNullOrWhiteSpace(guna2TextBox_CC.Text))
                    {
                        string[] copias = guna2TextBox_CC.Text
                            .Split(new[] { ';', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string email in copias)
                        {
                            string correoCC = email.Trim();

                            if (!string.IsNullOrWhiteSpace(correoCC))
                            {
                                correo.CC.Add(correoCC);
                            }
                        }
                    }


                    // Datos del correo
                    DateTime fechaInicio = ce_correo.fechaProcesoIni ?? DateTime.Now;
                    DateTime fechaFin = ce_correo.fechaProcesoFin ?? DateTime.Now;
                    string rangoFecha = "", usuarioEnvia = "";

                    if (fechaInicio.Date == fechaFin.Date)
                    {
                        rangoFecha = " DIA - " + fechaInicio.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        rangoFecha = " De " + fechaInicio.ToString("yyyy-MM-dd")
                            + " hasta "
                            + fechaFin.ToString("yyyy-MM-dd");
                    }
                    usuarioEnvia += ce_usuario.usenam;

                    correo.Subject = guna2TextBox_Asunto.Text.Trim() + rangoFecha;
                    correo.Body =
                    guna2TextBox_Cuerpo.Text +
                    rangoFecha +
                    "<br><br>" +
                    "Slds,<br>" +
                    usuarioEnvia;

                    correo.IsBodyHtml = true;

                    // ADJUNTO EXCEL
                    if (!string.IsNullOrEmpty(ce_correo.rutaArchivoAdjunto))
                    {
                        if (File.Exists(ce_correo.rutaArchivoAdjunto))
                        {
                            Attachment adjunto = new Attachment(
                                ce_correo.rutaArchivoAdjunto
                            );

                            correo.Attachments.Add(adjunto);
                        }
                    }

                    // SMTP Office365
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = ce_correo.ServidorSMTP;
                        smtp.Port = ce_correo.PuertoSMTP;
                        smtp.EnableSsl = true;

                        smtp.Credentials = new NetworkCredential(
                            ce_correo.UsuarioSMTP,
                            ce_correo.PasswordSMTP
                        );

                        smtp.Send(correo);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error enviando correo:\n\n" + ex.Message,
                    "Correo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
