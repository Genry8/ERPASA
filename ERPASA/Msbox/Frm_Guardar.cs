using System;
using System.Windows.Forms;

namespace ERPASA.Msbox
{
    public partial class Frm_Guardar : Form
    {
        private Label label1;
        private Panel panel1;
        private Button button_cancelar;
        private Button button_ok;
        private Panel panel_titulo;
        private Button button_cerrar;

        public Frm_Guardar()
        {
            InitializeComponent();
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void button_ok_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("SALIR", "OK", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            //result = MessageBox.Show("SALIR", "OK", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //MessageBox.Show("Hola");
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Guardar));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(175, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Desea Guardar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.button_cancelar);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 155);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 70);
            this.panel1.TabIndex = 14;
            // 
            // button_cancelar
            // 
            this.button_cancelar.BackColor = System.Drawing.Color.DarkRed;
            this.button_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cancelar.FlatAppearance.BorderSize = 0;
            this.button_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_cancelar.Location = new System.Drawing.Point(310, 11);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(6);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(174, 46);
            this.button_cancelar.TabIndex = 11;
            this.button_cancelar.Text = "CANCELAR";
            this.button_cancelar.UseVisualStyleBackColor = false;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.Color.SteelBlue;
            this.button_ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ok.BackgroundImage")));
            this.button_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ok.FlatAppearance.BorderSize = 0;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ok.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_ok.Location = new System.Drawing.Point(100, 11);
            this.button_ok.Margin = new System.Windows.Forms.Padding(6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(110, 46);
            this.button_ok.TabIndex = 10;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // panel_titulo
            // 
            this.panel_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(140)))));
            this.panel_titulo.Controls.Add(this.button_cerrar);
            this.panel_titulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(525, 60);
            this.panel_titulo.TabIndex = 13;
            // 
            // button_cerrar
            // 
            this.button_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cerrar.BackColor = System.Drawing.Color.White;
            this.button_cerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cerrar.BackgroundImage")));
            this.button_cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cerrar.FlatAppearance.BorderSize = 0;
            this.button_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_cerrar.Location = new System.Drawing.Point(475, 10);
            this.button_cerrar.Margin = new System.Windows.Forms.Padding(6);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(40, 38);
            this.button_cerrar.TabIndex = 29;
            this.button_cerrar.UseVisualStyleBackColor = false;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // Frm_Guardar
            // 
            this.ClientSize = new System.Drawing.Size(525, 225);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Guardar";
            this.panel1.ResumeLayout(false);
            this.panel_titulo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
