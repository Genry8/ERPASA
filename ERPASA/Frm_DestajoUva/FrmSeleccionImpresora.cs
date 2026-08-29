using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ERPASA.Frm_DestajoUva
{
    public partial class FrmSeleccionImpresora : Form
    {
        // ✅ Propiedad para devolver la impresora seleccionada
        public string ImpresoraSeleccionada { get; private set; }
        public FrmSeleccionImpresora()
        {
            InitializeComponent();
        }

        private void FrmSeleccionImpresora_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox de impresoras cuando carga el formulario
            comboBoxImpresoras.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarImpresoras();
            button_imprimir.Focus();
        }

        // ✅ Método para cargar impresoras disponibles
        private void CargarImpresoras()
        {
            comboBoxImpresoras.Items.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxImpresoras.Items.Add(printer);
            }

            if (comboBoxImpresoras.Items.Count > 0)
            {
                PrintDocument pd = new PrintDocument();
                comboBoxImpresoras.SelectedItem = pd.PrinterSettings.PrinterName;
            }
        }


        private void button_imprimir_Click(object sender, EventArgs e)
        {
            if (comboBoxImpresoras.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una impresora.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ImpresoraSeleccionada = comboBoxImpresoras.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
