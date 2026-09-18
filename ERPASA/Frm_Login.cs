using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA
{
    public partial class Frm_Login : Form
    {

        Frm_presentacion log;
        cn_usuario objnegUsuarios = new cn_usuario();
        cd_usuarios objdatUsuarios = new cd_usuarios();
        cd_conexion Conexio = new cd_conexion();


        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            //MOSTRAR LA VERSION DE ACTUALIZACION VESION_IPRESSREPORTE
            CargarVersion();

            TEXT_USUARIO.Focus();
        }

        private void CargarVersion()
        {
            using (var con = Conexio.leerconexion())
            using (var comando = new SqlCommand("[sp_version_DaPro]", con))
            {
                comando.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        label_version_call.Text = reader.GetString(0);
                        label_desarrollo.Text = reader.GetString(1);
                        ce_usuario.version_actual = reader.GetString(2);
                    }
                }
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            logear();
        }


        private void logear()
        {
            if (string.IsNullOrWhiteSpace(TEXT_USUARIO.Text))
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE USUARIO", Color.Goldenrod, 4);
                ng.ShowDialog();
                TEXT_USUARIO.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TEXT_CONTRASEÑA.Text))
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE CONTRASEÑA", Color.Goldenrod, 4);
                ng.ShowDialog();
                TEXT_CONTRASEÑA.Focus();
                return;
            }

            int codigoUsuario;
            if (!Int32.TryParse(TEXT_USUARIO.Text.Trim(), out codigoUsuario))
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("USUARIO NO VÁLIDO", Color.Goldenrod, 4);
                ng.ShowDialog();
                TEXT_USUARIO.Focus();
                return;
            }

            var login = objnegUsuarios.BuscUser(codigoUsuario, TEXT_CONTRASEÑA.Text, "APP ASA");
            ce_version.version_act = label_version_actual.Text;

            if (ce_usuario.permiso_app == "")
            {
                Msbox.Frm_Notificaciones_IS ng = new Msbox.Frm_Notificaciones_IS("USUARIO SIN ACCESO", Color.Goldenrod, 4);
                ng.ShowDialog();
                return;
            }

            if (ce_usuario.estado == "N")
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("Usuario Cesado", Color.OrangeRed, 3);
                ng.ShowDialog();
                ce_usuario.estado = "";
                return;
            }

            if (login != true)
            {
                Msbox.Frm_Notificaciones_IS ng = new Msbox.Frm_Notificaciones_IS("Usuario o contraseña incorrecta", Color.Goldenrod, 4);
                ng.ShowDialog();

                TEXT_CONTRASEÑA.Focus();
                return;
            }

            if (label_version_actual.Text == ce_usuario.version_actual)
            {
                log = new Frm_presentacion();
                this.Hide();
                log.ShowDialog();
            }
            else
            {
                DialogResult result = MessageBox.Show("Hay una nueva versión disponible. ¿Deseas descargarla?",
                                  "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Frm_Actualizacion frbm = new Frm_Actualizacion();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            //timer1.Start(); USAR PARA BARRA DE CARGA EN LA PARTE INFERIOR DE INICIO DE SESION
        }

        private void TEXT_USUARIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                logear();
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

        private void TEXT_CONTRASEÑA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                logear();
            }
        }

        private void TEXT_CONTRASEÑA_IconRightClick(object sender, EventArgs e)
        {
            TEXT_CONTRASEÑA.UseSystemPasswordChar = !TEXT_CONTRASEÑA.UseSystemPasswordChar;
            TEXT_CONTRASEÑA.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value += 1;
            }

            else
            {
                timer1.Stop();
                log = new Frm_presentacion();
                this.Hide();
                log.ShowDialog();
            }
        }


        private void label_version_call_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para actualizar póngase en contacto con el administrador");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_TabMaestra.Usuario.RecuperarContraseña frbm =
                new Frm_TabMaestra.Usuario.RecuperarContraseña();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }
    }
}
