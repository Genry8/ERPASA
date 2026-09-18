using System.Windows.Forms;

namespace ERPASA.Reportes
{
    public partial class Frm_CrpPanel_imprimir : Form
    {
        public Frm_CrpPanel_imprimir()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }
    }
}
