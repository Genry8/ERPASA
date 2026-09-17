using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_TabMaestra.Usuario
{
    public partial class RecuperarContraseña : Form
    {
        string contraActual;
        cn_usuario objnegUsuarios = new cn_usuario();
        public RecuperarContraseña()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void button_enviarCorreo_Click(object sender, EventArgs e)
        {

            string correoDestino = guna2TextBox_correo.Text.Trim();
            // Lista de dominios permitidos
            string[] dominiosPermitidos = { "@agsantaazul.com", "@aginterandina.com", "@agnorsur.com" };

            // Verificar si el correo termina con alguno de los dominios permitidos
            bool dominioValido = dominiosPermitidos.Any(d => correoDestino.EndsWith(d, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(correoDestino))
            {
                MessageBox.Show("Por favor, ingrese un correo corporativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox_correo.Focus();
                return;
            }

            // Aquí puedes validar que el dominio sea correcto, por ejemplo:
            if (!dominioValido)
            {
                MessageBox.Show("Debe ingresar un correo corporativo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox_correo.Focus();
                return;
            }

            objnegUsuarios.ListUser(correoDestino);
            string asunto = "Recuperación de contraseña";
            string cuerpo = "Este es un mensaje para recuperar tu contraseña.\n" +
            "Nombres: " + ce_usuario.nombreOlvidada + "\n" +
            "Usuario: " + ce_usuario.usuarioOlvidada + "\n" +
            "Contraseña: " + ce_usuario.contrasenaOlvidada + "\n" +
            "Porfavor no vuelvas a olvidar, Gracias.\n\n" +
            "Solicitado por hostname: " + ce_usuario.HostName() + "\n" +
            "Solicitado por la ip: " + ce_usuario.IpMostrar() + "\n"
            ;

            EnviarCorreo(correoDestino, asunto, cuerpo);

        }

        bool EsCorreoValido(string correo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(correo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void EnviarCorreo(string destino, string asunto, string cuerpo)
        {
            var valUser = objnegUsuarios.ListUser(guna2TextBox_correo.Text);
            if (valUser == true)
            {
                string MessageBoxTitle = "CORREO";
                string MessageBoxContent = "¿Desea Enviar Correo?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        MailMessage mensaje = new MailMessage();
                        mensaje.From = new MailAddress("administradorti@agsantaazul.com");
                        mensaje.To.Add(destino);
                        mensaje.Subject = asunto;
                        mensaje.Body = cuerpo;
                        mensaje.IsBodyHtml = false;

                        SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
                        smtp.Credentials = new NetworkCredential("administradorti@agsantaazul.com", "S@nt@2024*");
                        smtp.EnableSsl = true;

                        smtp.Send(mensaje);

                        MessageBox.Show("Correo enviado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuario no existe", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }
    }
}
