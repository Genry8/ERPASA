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

namespace ERPASA.Frm_TabMaestra.Usuario
{
    public partial class CambiarContrasena : Form
    {
        cn_usuario objnegUsuarios = new cn_usuario();

        public CambiarContrasena()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void CambiarContrasena_Load(object sender, EventArgs e)
        {
            textBox_ContraseñaActual.UseSystemPasswordChar = true;
            textBox_NuevaContraseña.UseSystemPasswordChar = true;
            textBox_ConfirmarContraseña.UseSystemPasswordChar = true;
            label_coincide_contraseña.Text = string.Empty;

        }

        private void button_actualizarContraseña_Click(object sender, EventArgs e)
        {
            ActualizarContraseña();
        }

        public void ActualizarContraseña()
        {
            //var login = objnegUsuarios.BuscUser(ce_usuario.usedoc, ce_usuario.usepas, "APP ASA");
            string password = textBox_NuevaContraseña.Text;

            // Validación de longitud, mayúsculas, números y caracteres especiales
            bool isValidLength = password.Length >= 8;
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            // Si todos los requisitos se cumplen
            if (isValidLength && hasUpperCase && hasDigit && hasSpecialChar)
            {
                if (ce_usuario.usepas.ToUpper() == textBox_ContraseñaActual.Text.ToUpper().Trim())
                {
                    if (textBox_NuevaContraseña.Text.Trim()
                    == textBox_ConfirmarContraseña.Text.Trim())
                    {
                        string MessageBoxTitle = "CONTRASEÑA";
                        string MessageBoxContent = "¿Actualizar Contraseña?";

                        DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            objnegUsuarios.GuardUser(ce_usuario.usecod
                                , textBox_NuevaContraseña.Text.Trim()
                                );
                            MessageBox.Show("Contraseña actualizada con exito");
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseñas no coinciden");
                    }
                }
                else
                {
                    MessageBox.Show("Contraseñas actual incorrecto");
                }
            }
            else
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres, una mayúscula, un número y un carácter especial");
            }
        }

        private void textBox_NuevaContraseña_TextChanged(object sender, EventArgs e)
        {
            string password = textBox_NuevaContraseña.Text;
            // Validación de longitud, mayúsculas, números y caracteres especiales
            bool isValidLength = password.Length >= 8;
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));


            if (isValidLength && hasUpperCase && hasDigit && hasSpecialChar)
            {

                if (textBox_NuevaContraseña.Text.Trim() == ""
                    || textBox_ConfirmarContraseña.Text.Trim() == "")
                {
                    label_coincide_contraseña.ForeColor = Color.Red;
                    label_coincide_contraseña.Text = "no coinciden contraseñas";

                }
                else if (textBox_NuevaContraseña.Text.Trim()
                    == textBox_ConfirmarContraseña.Text.Trim())
                {
                    label_coincide_contraseña.ForeColor = Color.DarkGreen;
                    label_coincide_contraseña.Text = "Las contraseñas coinciden";

                }
                else
                {
                    label_coincide_contraseña.ForeColor = Color.Red;
                    label_coincide_contraseña.Text = "no coinciden contraseñas";

                }
            }
            else
            {
                label_coincide_contraseña.ForeColor = Color.Red;
                label_coincide_contraseña.Text = "minimo 8 caracteres, una mayúscula, un número y un carácter especial";
            }
        }

        private void textBox_ConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            string password = textBox_NuevaContraseña.Text;
            // Validación de longitud, mayúsculas, números y caracteres especiales
            bool isValidLength = password.Length >= 8;
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));


            if (isValidLength && hasUpperCase && hasDigit && hasSpecialChar)
            {
                if (textBox_NuevaContraseña.Text.Trim() == ""
                || textBox_ConfirmarContraseña.Text.Trim() == "")
                {
                    label_coincide_contraseña.ForeColor = Color.Red;
                    label_coincide_contraseña.Text = "no coinciden contraseñas";

                }
                else if (textBox_NuevaContraseña.Text.Trim()
                    == textBox_ConfirmarContraseña.Text.Trim())
                {
                    label_coincide_contraseña.ForeColor = Color.DarkGreen;
                    label_coincide_contraseña.Text = "Las contraseñas coinciden";

                }
                else
                {
                    label_coincide_contraseña.ForeColor = Color.Red;
                    label_coincide_contraseña.Text = "no coinciden contraseñas";

                }
            }
            else
            {
                label_coincide_contraseña.ForeColor = Color.Red;
                label_coincide_contraseña.Text = "minimo 8 caracteres, una mayúscula, un número y un carácter especial";
            }

        }

        private void textBox_ContraseñaActual_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_contActual_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_ContraseñaActual.Text.Trim() != "")
            {
                textBox_ContraseñaActual.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox_contActual_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_ContraseñaActual.Text.Trim() != "")
            {
                textBox_ContraseñaActual.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox_NuevaCont_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_NuevaContraseña.Text.Trim() != "")
            {
                textBox_NuevaContraseña.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox_NuevaCont_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_NuevaContraseña.Text.Trim() != "")
            {
                textBox_NuevaContraseña.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox_ConfirmaContra_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_ConfirmarContraseña.Text.Trim() != "")
            {
                textBox_ConfirmarContraseña.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox_ConfirmaContra_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_ConfirmarContraseña.Text.Trim() != "")
            {
                textBox_ConfirmarContraseña.UseSystemPasswordChar = false;
            }
        }

    }
}
