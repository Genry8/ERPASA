using System.Windows.Forms;

namespace ERPASA.Reportes
{
    public partial class Frm_CrpVetaUsuario : Form
    {
        public Frm_CrpVetaUsuario()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CrpVetaUsuario_Load(object sender, System.EventArgs e)
        {

        }
    }
}
