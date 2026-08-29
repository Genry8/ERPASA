namespace ERPASA.Frm_TabMaestra.Usuario
{
    partial class RecuperarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperarContraseña));
            this.button_enviarCorreo = new System.Windows.Forms.Button();
            this.guna2TextBox_correo = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // button_enviarCorreo
            // 
            this.button_enviarCorreo.Location = new System.Drawing.Point(498, 11);
            this.button_enviarCorreo.Name = "button_enviarCorreo";
            this.button_enviarCorreo.Size = new System.Drawing.Size(97, 36);
            this.button_enviarCorreo.TabIndex = 3;
            this.button_enviarCorreo.Text = "Enviar";
            this.button_enviarCorreo.UseVisualStyleBackColor = true;
            this.button_enviarCorreo.Click += new System.EventHandler(this.button_enviarCorreo_Click);
            // 
            // guna2TextBox_correo
            // 
            this.guna2TextBox_correo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_correo.DefaultText = "";
            this.guna2TextBox_correo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_correo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_correo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_correo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_correo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_correo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_correo.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox_correo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_correo.Location = new System.Drawing.Point(13, 11);
            this.guna2TextBox_correo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_correo.Name = "guna2TextBox_correo";
            this.guna2TextBox_correo.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.guna2TextBox_correo.PlaceholderText = "Ingrese correo coorporativo";
            this.guna2TextBox_correo.SelectedText = "";
            this.guna2TextBox_correo.Size = new System.Drawing.Size(478, 36);
            this.guna2TextBox_correo.TabIndex = 2;
            // 
            // RecuperarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 55);
            this.Controls.Add(this.button_enviarCorreo);
            this.Controls.Add(this.guna2TextBox_correo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecuperarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperar Contraseña";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_enviarCorreo;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_correo;
    }
}