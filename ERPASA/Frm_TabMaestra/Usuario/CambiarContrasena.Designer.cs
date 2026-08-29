namespace ERPASA.Frm_TabMaestra.Usuario
{
    partial class CambiarContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContrasena));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_actualizarContraseña = new System.Windows.Forms.Button();
            this.textBox_ContraseñaActual = new System.Windows.Forms.TextBox();
            this.textBox_NuevaContraseña = new System.Windows.Forms.TextBox();
            this.textBox_ConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.label_coincide_contraseña = new System.Windows.Forms.Label();
            this.pictureBox_ConfirmaContra = new System.Windows.Forms.PictureBox();
            this.pictureBox_NuevaCont = new System.Windows.Forms.PictureBox();
            this.pictureBox_contActual = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConfirmaContra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NuevaCont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_contActual)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nueva Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirmar Contraseña";
            // 
            // button_actualizarContraseña
            // 
            this.button_actualizarContraseña.Location = new System.Drawing.Point(173, 259);
            this.button_actualizarContraseña.Name = "button_actualizarContraseña";
            this.button_actualizarContraseña.Size = new System.Drawing.Size(142, 38);
            this.button_actualizarContraseña.TabIndex = 3;
            this.button_actualizarContraseña.Text = "GUARDAR";
            this.button_actualizarContraseña.UseVisualStyleBackColor = true;
            this.button_actualizarContraseña.Click += new System.EventHandler(this.button_actualizarContraseña_Click);
            // 
            // textBox_ContraseñaActual
            // 
            this.textBox_ContraseñaActual.Location = new System.Drawing.Point(206, 41);
            this.textBox_ContraseñaActual.Name = "textBox_ContraseñaActual";
            this.textBox_ContraseñaActual.Size = new System.Drawing.Size(263, 26);
            this.textBox_ContraseñaActual.TabIndex = 4;
            this.textBox_ContraseñaActual.TextChanged += new System.EventHandler(this.textBox_ContraseñaActual_TextChanged);
            // 
            // textBox_NuevaContraseña
            // 
            this.textBox_NuevaContraseña.Location = new System.Drawing.Point(206, 106);
            this.textBox_NuevaContraseña.Name = "textBox_NuevaContraseña";
            this.textBox_NuevaContraseña.Size = new System.Drawing.Size(263, 26);
            this.textBox_NuevaContraseña.TabIndex = 5;
            this.textBox_NuevaContraseña.TextChanged += new System.EventHandler(this.textBox_NuevaContraseña_TextChanged);
            // 
            // textBox_ConfirmarContraseña
            // 
            this.textBox_ConfirmarContraseña.Location = new System.Drawing.Point(206, 175);
            this.textBox_ConfirmarContraseña.Name = "textBox_ConfirmarContraseña";
            this.textBox_ConfirmarContraseña.Size = new System.Drawing.Size(263, 26);
            this.textBox_ConfirmarContraseña.TabIndex = 6;
            this.textBox_ConfirmarContraseña.TextChanged += new System.EventHandler(this.textBox_ConfirmarContraseña_TextChanged);
            // 
            // label_coincide_contraseña
            // 
            this.label_coincide_contraseña.AutoSize = true;
            this.label_coincide_contraseña.Location = new System.Drawing.Point(12, 227);
            this.label_coincide_contraseña.Name = "label_coincide_contraseña";
            this.label_coincide_contraseña.Size = new System.Drawing.Size(151, 20);
            this.label_coincide_contraseña.TabIndex = 7;
            this.label_coincide_contraseña.Text = "coincide contraseña";
            // 
            // pictureBox_ConfirmaContra
            // 
            this.pictureBox_ConfirmaContra.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ConfirmaContra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_ConfirmaContra.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_ConfirmaContra.Image")));
            this.pictureBox_ConfirmaContra.Location = new System.Drawing.Point(476, 178);
            this.pictureBox_ConfirmaContra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_ConfirmaContra.Name = "pictureBox_ConfirmaContra";
            this.pictureBox_ConfirmaContra.Size = new System.Drawing.Size(18, 18);
            this.pictureBox_ConfirmaContra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ConfirmaContra.TabIndex = 33;
            this.pictureBox_ConfirmaContra.TabStop = false;
            this.pictureBox_ConfirmaContra.MouseLeave += new System.EventHandler(this.pictureBox_ConfirmaContra_MouseLeave);
            this.pictureBox_ConfirmaContra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ConfirmaContra_MouseMove);
            // 
            // pictureBox_NuevaCont
            // 
            this.pictureBox_NuevaCont.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_NuevaCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_NuevaCont.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_NuevaCont.Image")));
            this.pictureBox_NuevaCont.Location = new System.Drawing.Point(476, 111);
            this.pictureBox_NuevaCont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_NuevaCont.Name = "pictureBox_NuevaCont";
            this.pictureBox_NuevaCont.Size = new System.Drawing.Size(18, 18);
            this.pictureBox_NuevaCont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_NuevaCont.TabIndex = 34;
            this.pictureBox_NuevaCont.TabStop = false;
            this.pictureBox_NuevaCont.MouseLeave += new System.EventHandler(this.pictureBox_NuevaCont_MouseLeave);
            this.pictureBox_NuevaCont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_NuevaCont_MouseMove);
            // 
            // pictureBox_contActual
            // 
            this.pictureBox_contActual.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_contActual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_contActual.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_contActual.Image")));
            this.pictureBox_contActual.Location = new System.Drawing.Point(476, 46);
            this.pictureBox_contActual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_contActual.Name = "pictureBox_contActual";
            this.pictureBox_contActual.Size = new System.Drawing.Size(18, 18);
            this.pictureBox_contActual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_contActual.TabIndex = 35;
            this.pictureBox_contActual.TabStop = false;
            this.pictureBox_contActual.MouseLeave += new System.EventHandler(this.pictureBox_contActual_MouseLeave);
            this.pictureBox_contActual.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_contActual_MouseMove);
            // 
            // CambiarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 320);
            this.Controls.Add(this.pictureBox_contActual);
            this.Controls.Add(this.pictureBox_NuevaCont);
            this.Controls.Add(this.pictureBox_ConfirmaContra);
            this.Controls.Add(this.label_coincide_contraseña);
            this.Controls.Add(this.textBox_ConfirmarContraseña);
            this.Controls.Add(this.textBox_NuevaContraseña);
            this.Controls.Add(this.textBox_ContraseñaActual);
            this.Controls.Add(this.button_actualizarContraseña);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CambiarContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contrasena";
            this.Load += new System.EventHandler(this.CambiarContrasena_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConfirmaContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NuevaCont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_contActual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_actualizarContraseña;
        private System.Windows.Forms.TextBox textBox_ContraseñaActual;
        private System.Windows.Forms.TextBox textBox_NuevaContraseña;
        private System.Windows.Forms.TextBox textBox_ConfirmarContraseña;
        private System.Windows.Forms.Label label_coincide_contraseña;
        private System.Windows.Forms.PictureBox pictureBox_ConfirmaContra;
        private System.Windows.Forms.PictureBox pictureBox_NuevaCont;
        private System.Windows.Forms.PictureBox pictureBox_contActual;
    }
}