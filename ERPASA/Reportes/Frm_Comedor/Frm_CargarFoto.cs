using CapaEntidad;
using CapaNegocio;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Reportes.Frm_Comedor
{
    public partial class Frm_CargarFoto : Form
    {

        cn_datospersonal objcndatpers = new cn_datospersonal();

        public Frm_CargarFoto()
        {
            InitializeComponent();
        }

        private void Frm_CargarFoto_Load(object sender, EventArgs e)
        {

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (textBox_dni.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE DNI", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (pictureBox1.Image == null)
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA FOTO TAMAÑO CARNET", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                GuardarFotoFostosheck();
            }
        }

        private void button_nuevo_Click(object sender, EventArgs e)
        {
            limipartodo();
            textBox_dni.Focus();
        }

        public void limipartodo()
        {
            textBox_dni.Text = "";
            textBox_apellidos.Text = "";
            textBox_nombres.Text = "";
            pictureBox1.Image = null;
        }

        public void GuardarFotoFostosheck()
        {
            var extfoto = objcndatpers.BuscaPersExistFotoFotosheck(textBox_dni.Text);
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            if (extfoto == true)
            {
                string MessageBoxTitle = "Actualizar";
                string MessageBoxContent = "¿Desea actualizar foto?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcndatpers.ActuaFotoFotosheck(
                        textBox_dni.Text,
                        textBox_apellidos.Text,
                        textBox_nombres.Text,
                    ms.GetBuffer()
                    );

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    limipartodo();
                }

            }
            else
            {
                string MessageBoxTitle = "Guardar";
                string MessageBoxContent = "¿Desea guardar foto?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcndatpers.GuardarFotoFotosheck(
                        textBox_dni.Text.Trim(),
                        textBox_apellidos.Text.Trim().ToUpper(),
                        textBox_nombres.Text.Trim().ToUpper(),
                ms.GetBuffer()
                );

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    limipartodo();
                }

            }
        }

        private void button_elegir_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "archivos de imagen (*jpg; *png;) | *jpg; *png; ";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            buscarfotofotosheck();
        }

        private void buscarfotofotosheck()
        {
            if (textBox_dni.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE DNI", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                var extfoto = objcndatpers.BuscaFotoFotosheck(textBox_dni.Text);
                if (extfoto == true)
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("USUARIO ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
                    ng.Show();

                    textBox_dni.Text = ce_fotofotosheck.dni;
                    textBox_apellidos.Text = ce_fotofotosheck.apellidos;
                    textBox_nombres.Text = ce_fotofotosheck.nombres;

                    byte[] img = ce_fotofotosheck.foto;
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("DNI NO REGISTRADO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
            }
        }

        private void textBox_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                buscarfotofotosheck();
            }

            else if (char.IsWhiteSpace(e.KeyChar))
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
