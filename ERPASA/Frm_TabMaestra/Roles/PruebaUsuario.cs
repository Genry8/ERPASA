using CapaNegocio;
using System;
using System.Windows.Forms;

namespace ERPASA.Frm_TabMaestra.Roles
{
    public partial class PruebaUsuario : Form
    {

        cn_apisperu objapi = new cn_apisperu();

        public PruebaUsuario()
        {
            InitializeComponent();
        }

        private void PruebaUsuario_Load(object sender, EventArgs e)
        {

        }


        public void BuscarPersonaReniec()
        {
            try
            {
                //dynamic respuesta = objapi.Get("https://api.apis.net.pe/v1/dni?numero="+textBox_id.Text+"");
                dynamic respuesta = objapi.Get("https://localhost:7279/cliente/listar");
                textBox_id.Text = respuesta.id.ToString();
                textBox_usuario.Text = respuesta.usuario.ToString();
                textBox_correo.Text = respuesta.correo.ToString();
                textBox_comentario.Text = respuesta.comentario.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("No fue posible conectar con API");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarPersonaReniec();
        }
    }
}
