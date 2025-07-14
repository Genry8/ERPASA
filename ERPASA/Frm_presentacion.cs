using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace ERPASA
{
    public partial class Frm_presentacion : Form
    {
        Frm_Menu menu = new Frm_Menu();
        Frm_Login login = new Frm_Login();
        cn_usuario objcuserneg = new cn_usuario();

        public Frm_presentacion()
        {
            InitializeComponent();
            label_presentacion.Text = ce_usuario.grudes;
            label_nombre.Text = ce_usuario.usenam;

            //CARAGAR IMAGEN CON UN DNI CAPTURADO AL INICIAR SESION A PICTUREBOX
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUser(ce_usuario.usedoc);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0] != System.DBNull.Value)
                {
                    byte[] img = (byte[])dt.Rows[0]["Foto_perfil"];

                    System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                    pictureBox_foto_inisecion.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBox_foto_inisecion.Image = pictureBox_titulo.Image;
                }

            }
            else
            {
                pictureBox_foto_inisecion.Image = pictureBox_titulo.Image;
            }
            //

            timer1.Start();
            //this.Close();

        }

        private void Frm_presentacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (circularProgressBar1.Value < 100)
            {

                circularProgressBar1.Value += 5;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";
                //label_porcentaje.Text = progressBar1.Value.ToString() + "%";
            }

            else
            {
                timer1.Stop();
                //MessageBox.Show("biz");

                menu = new Frm_Menu();
                this.Hide();
                menu.ShowDialog();
            }

        }

    }
}
