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
            var con = Conexio.leerconexion();
            //CapaPresentacion.Msbox.Frm_NotificacionesPeligro ng = new CapaPresentacion.Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            //ng.ShowDialog();

            var comando = new SqlCommand("[sp_version_DaPro]", con);
            comando.Connection = con;
            comando.CommandType = CommandType.StoredProcedure;
            con.Open();
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    label_version_call.Text = reader.GetString(0);
                    label_desarrollo.Text = reader.GetString(1);
                    label_version_actual.Text = reader.GetString(2);
                    ce_usuario.version_actual = reader.GetString(2);
                }
                con.Dispose();
                con.Close();
                return;
            }

            TEXT_USUARIO.Focus();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            logear();
        }


        private void logear()
        {
            if (TEXT_USUARIO.Text != "Ingrese su usuario")

            {
                if (TEXT_CONTRASEÑA.Text != "Ingrese su contraseña")

                {
                    var login = objnegUsuarios.BuscUser(Int32.Parse(TEXT_USUARIO.Text), TEXT_CONTRASEÑA.Text, "APP ASA");
                    //MessageBox.Show(" " + ce_usuario.permiso_app);
                    if (ce_usuario.permiso_app != "")
                    {
                        if (ce_usuario.estado == "N")
                        {
                            Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("Usuario Cesado", Color.OrangeRed, 3);
                            ng.ShowDialog();
                            ce_usuario.estado = "";
                        }
                        else if (login == true)
                        {
                            //GuardarUser();

                            log = new Frm_presentacion();
                            this.Hide();
                            log.ShowDialog();

                            //timer1.Start(); USAR PARA BARRA DE CARGA EN LA PARTE INFERIOR DE INICIO DE SESION

                            //nuevo1.ActualizarMedicamento();

                        }
                        else
                        {
                            //MessageBox.Show("Usuario o contraseña incorrecta");
                            Msbox.Frm_Notificaciones_IS ng = new Msbox.Frm_Notificaciones_IS("Usuario o contraseña incorrecta", Color.Goldenrod, 4);
                            ng.ShowDialog();

                            //TEXT_USUARIO.Text = "Ingrese su usuario";
                            //TEXT_USUARIO.ForeColor = Color.DarkGray;

                            //TEXT_CONTRASEÑA.UseSystemPasswordChar = false;
                            //TEXT_CONTRASEÑA.Text = "Ingrese su contraseña";
                            //TEXT_CONTRASEÑA.ForeColor = Color.DarkGray;

                            TEXT_CONTRASEÑA.Focus();
                        }
                    }
                    else
                    {
                        Msbox.Frm_Notificaciones_IS ng = new Msbox.Frm_Notificaciones_IS("USUARIO SIN ACCESO", Color.Goldenrod, 4);
                        ng.ShowDialog();
                    }
                }
                else
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE CONTRASEÑA", Color.Goldenrod, 4);
                    ng.ShowDialog();
                }
            }
            else
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("INGRESE USUARIO", Color.Goldenrod, 4);
                ng.ShowDialog();

            }

        }
        private void TEXT_USUARIO_Enter(object sender, EventArgs e)
        {
            if (TEXT_USUARIO.Text == "Ingrese su usuario")
            {
                TEXT_USUARIO.Text = "";
                TEXT_USUARIO.ForeColor = Color.FromArgb(35, 66, 90);
                TEXT_USUARIO.Font = new Font(TEXT_USUARIO.Font, FontStyle.Regular);
            }
        }

        private void TEXT_USUARIO_Leave(object sender, EventArgs e)
        {
            if (TEXT_USUARIO.Text == "")
            {
                TEXT_USUARIO.Text = "Ingrese su usuario";
                TEXT_USUARIO.ForeColor = Color.DarkGray;
                TEXT_USUARIO.Font = new Font(TEXT_USUARIO.Font, FontStyle.Italic);
            }
        }

        private void TEXT_USUARIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            /// if (char.IsLetter(e.KeyChar)) { e.Handled = true;}
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

        private void TEXT_CONTRASEÑA_Enter(object sender, EventArgs e)
        {
            if (TEXT_CONTRASEÑA.Text == "Ingrese su contraseña")
            {
                TEXT_CONTRASEÑA.Text = "";
                TEXT_CONTRASEÑA.ForeColor = Color.FromArgb(35, 66, 90);
                TEXT_CONTRASEÑA.Font = new Font(TEXT_CONTRASEÑA.Font, FontStyle.Regular);
                TEXT_CONTRASEÑA.UseSystemPasswordChar = true;
                //pictureBox_VerContraseña.Visible = true;

            }
        }

        private void TEXT_CONTRASEÑA_Leave(object sender, EventArgs e)
        {
            if (TEXT_CONTRASEÑA.Text == "")
            {
                TEXT_CONTRASEÑA.Text = "Ingrese su contraseña";
                TEXT_CONTRASEÑA.ForeColor = Color.DarkGray;
                TEXT_CONTRASEÑA.Font = new Font(TEXT_CONTRASEÑA.Font, FontStyle.Italic);
                TEXT_CONTRASEÑA.UseSystemPasswordChar = false;
                pictureBox_VerContraseña.Visible = false;
            }
        }

        private void TEXT_CONTRASEÑA_TextChanged(object sender, EventArgs e)
        {
            if (TEXT_CONTRASEÑA.Text == "")
            {
                pictureBox_VerContraseña.Visible = false;
            }

            else if (TEXT_CONTRASEÑA.Text != "")
            {
                pictureBox_VerContraseña.Visible = true;
            }
        }
        private void TEXT_CONTRASEÑA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                logear();
            }
        }

        private void pictureBox_VerContraseña_MouseLeave(object sender, EventArgs e)
        {
            if (TEXT_CONTRASEÑA.Text != "Ingrese su contraseña")
            {
                TEXT_CONTRASEÑA.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox_VerContraseña_MouseMove(object sender, MouseEventArgs e)
        {
            if (TEXT_CONTRASEÑA.Text != "Ingrese su contraseña")
            {
                TEXT_CONTRASEÑA.UseSystemPasswordChar = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value += 1;

                //label1.Text = progressBar1.Value.ToString() + "%";

            }

            else
            {
                timer1.Stop();
                //MessageBox.Show("biz");
                log = new Frm_presentacion();
                this.Hide();
                log.ShowDialog();
            }
        }


        private void label_version_call_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para actualizar póngase en contacto con el administrador");
        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Nosotros tampoco recordamos, siga pensando gracias.");
        }
    }
}
