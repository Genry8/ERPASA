namespace ERPASA.Frm_DestajoUva
{
    partial class FrmSeleccionImpresora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionImpresora));
            this.comboBoxImpresoras = new Guna.UI2.WinForms.Guna2ComboBox();
            this.button_imprimir = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxImpresoras
            // 
            this.comboBoxImpresoras.FormattingEnabled = true;
            this.comboBoxImpresoras.Location = new System.Drawing.Point(9, 34);
            this.comboBoxImpresoras.Name = "comboBoxImpresoras";
            this.comboBoxImpresoras.Size = new System.Drawing.Size(493, 28);
            this.comboBoxImpresoras.TabIndex = 0;
            // 
            // button_imprimir
            // 
            this.button_imprimir.Location = new System.Drawing.Point(93, 101);
            this.button_imprimir.Name = "button_imprimir";
            this.button_imprimir.Size = new System.Drawing.Size(112, 33);
            this.button_imprimir.TabIndex = 1;
            this.button_imprimir.Text = "Imprimir";
            this.button_imprimir.UseVisualStyleBackColor = true;
            this.button_imprimir.Click += new System.EventHandler(this.button_imprimir_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(300, 101);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(112, 33);
            this.button_cancelar.TabIndex = 2;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // FrmSeleccionImpresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 173);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_imprimir);
            this.Controls.Add(this.comboBoxImpresoras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSeleccionImpresora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione Impresora";
            this.Load += new System.EventHandler(this.FrmSeleccionImpresora_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBoxImpresoras;
        private System.Windows.Forms.Button button_imprimir;
        private System.Windows.Forms.Button button_cancelar;
    }
}