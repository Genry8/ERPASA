namespace ERPASA.Frm_Correo
{
    partial class EnviarCorreoDestajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnviarCorreoDestajo));
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.pictureBox_EnviarCorreoDestajo = new System.Windows.Forms.PictureBox();
            this.label_formulario = new System.Windows.Forms.Label();
            this.label_IDCorreo = new System.Windows.Forms.Label();
            this.panel_cuerpo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2TextBox_De = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2TextBox_Para = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2TextBox_CC = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2TextBox_Asunto = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2TextBox_Cuerpo = new Guna.UI2.WinForms.Guna2TextBox();
            this.button_enviar = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EnviarCorreoDestajo)).BeginInit();
            this.panel_cuerpo.SuspendLayout();
            this.SuspendLayout();
            //
            // panel_titulo
            //
            this.panel_titulo.Controls.Add(this.pictureBox_EnviarCorreoDestajo);
            this.panel_titulo.Controls.Add(this.label_formulario);
            this.panel_titulo.Controls.Add(this.label_IDCorreo);
            this.panel_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(780, 64);
            this.panel_titulo.TabIndex = 0;
            //
            // pictureBox_EnviarCorreoDestajo
            //
            this.pictureBox_EnviarCorreoDestajo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_EnviarCorreoDestajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_EnviarCorreoDestajo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_EnviarCorreoDestajo.Image")));
            this.pictureBox_EnviarCorreoDestajo.Location = new System.Drawing.Point(18, 13);
            this.pictureBox_EnviarCorreoDestajo.Name = "pictureBox_EnviarCorreoDestajo";
            this.pictureBox_EnviarCorreoDestajo.Size = new System.Drawing.Size(40, 38);
            this.pictureBox_EnviarCorreoDestajo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_EnviarCorreoDestajo.TabIndex = 0;
            this.pictureBox_EnviarCorreoDestajo.TabStop = false;
            this.pictureBox_EnviarCorreoDestajo.Click += new System.EventHandler(this.pictureBox_EnviarCorreoDestajo_Click);
            //
            // label_formulario
            //
            this.label_formulario.BackColor = System.Drawing.Color.Transparent;
            this.label_formulario.Location = new System.Drawing.Point(72, 0);
            this.label_formulario.Name = "label_formulario";
            this.label_formulario.Size = new System.Drawing.Size(560, 64);
            this.label_formulario.TabIndex = 1;
            this.label_formulario.Text = "Correo";
            this.label_formulario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // label_IDCorreo
            //
            this.label_IDCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IDCorreo.BackColor = System.Drawing.Color.Transparent;
            this.label_IDCorreo.Location = new System.Drawing.Point(644, 0);
            this.label_IDCorreo.Name = "label_IDCorreo";
            this.label_IDCorreo.Size = new System.Drawing.Size(120, 64);
            this.label_IDCorreo.TabIndex = 2;
            this.label_IDCorreo.Text = "1";
            this.label_IDCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // panel_cuerpo
            //
            this.panel_cuerpo.Controls.Add(this.label3);
            this.panel_cuerpo.Controls.Add(this.guna2TextBox_De);
            this.panel_cuerpo.Controls.Add(this.label4);
            this.panel_cuerpo.Controls.Add(this.guna2TextBox_Para);
            this.panel_cuerpo.Controls.Add(this.label5);
            this.panel_cuerpo.Controls.Add(this.guna2TextBox_CC);
            this.panel_cuerpo.Controls.Add(this.label6);
            this.panel_cuerpo.Controls.Add(this.guna2TextBox_Asunto);
            this.panel_cuerpo.Controls.Add(this.label7);
            this.panel_cuerpo.Controls.Add(this.guna2TextBox_Cuerpo);
            this.panel_cuerpo.Controls.Add(this.button_enviar);
            this.panel_cuerpo.Controls.Add(this.label2);
            this.panel_cuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cuerpo.Location = new System.Drawing.Point(0, 64);
            this.panel_cuerpo.Name = "panel_cuerpo";
            this.panel_cuerpo.Size = new System.Drawing.Size(780, 536);
            this.panel_cuerpo.TabIndex = 1;
            //
            // label3
            //
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "De";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // guna2TextBox_De
            //
            this.guna2TextBox_De.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox_De.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_De.DefaultText = "";
            this.guna2TextBox_De.Enabled = false;
            this.guna2TextBox_De.Location = new System.Drawing.Point(98, 18);
            this.guna2TextBox_De.Name = "guna2TextBox_De";
            this.guna2TextBox_De.PasswordChar = '\0';
            this.guna2TextBox_De.PlaceholderText = "";
            this.guna2TextBox_De.SelectedText = "";
            this.guna2TextBox_De.ShadowDecoration.Parent = this.guna2TextBox_De;
            this.guna2TextBox_De.Size = new System.Drawing.Size(666, 32);
            this.guna2TextBox_De.TabIndex = 1;
            this.guna2TextBox_De.TextOffset = new System.Drawing.Point(4, 0);
            //
            // label4
            //
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Para";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // guna2TextBox_Para
            //
            this.guna2TextBox_Para.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox_Para.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_Para.DefaultText = "";
            this.guna2TextBox_Para.Location = new System.Drawing.Point(98, 60);
            this.guna2TextBox_Para.Multiline = true;
            this.guna2TextBox_Para.Name = "guna2TextBox_Para";
            this.guna2TextBox_Para.PasswordChar = '\0';
            this.guna2TextBox_Para.PlaceholderText = "correo@dominio.com; otro@dominio.com";
            this.guna2TextBox_Para.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.guna2TextBox_Para.SelectedText = "";
            this.guna2TextBox_Para.ShadowDecoration.Parent = this.guna2TextBox_Para;
            this.guna2TextBox_Para.Size = new System.Drawing.Size(666, 56);
            this.guna2TextBox_Para.TabIndex = 3;
            this.guna2TextBox_Para.TextOffset = new System.Drawing.Point(4, 0);
            //
            // label5
            //
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(16, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "CC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // guna2TextBox_CC
            //
            this.guna2TextBox_CC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox_CC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_CC.DefaultText = "";
            this.guna2TextBox_CC.Location = new System.Drawing.Point(98, 126);
            this.guna2TextBox_CC.Multiline = true;
            this.guna2TextBox_CC.Name = "guna2TextBox_CC";
            this.guna2TextBox_CC.PasswordChar = '\0';
            this.guna2TextBox_CC.PlaceholderText = "";
            this.guna2TextBox_CC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.guna2TextBox_CC.SelectedText = "";
            this.guna2TextBox_CC.ShadowDecoration.Parent = this.guna2TextBox_CC;
            this.guna2TextBox_CC.Size = new System.Drawing.Size(666, 76);
            this.guna2TextBox_CC.TabIndex = 5;
            this.guna2TextBox_CC.TextOffset = new System.Drawing.Point(4, 0);
            //
            // label6
            //
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(16, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "Asunto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // guna2TextBox_Asunto
            //
            this.guna2TextBox_Asunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox_Asunto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_Asunto.DefaultText = "";
            this.guna2TextBox_Asunto.Location = new System.Drawing.Point(98, 212);
            this.guna2TextBox_Asunto.Name = "guna2TextBox_Asunto";
            this.guna2TextBox_Asunto.PasswordChar = '\0';
            this.guna2TextBox_Asunto.PlaceholderText = "";
            this.guna2TextBox_Asunto.SelectedText = "";
            this.guna2TextBox_Asunto.ShadowDecoration.Parent = this.guna2TextBox_Asunto;
            this.guna2TextBox_Asunto.Size = new System.Drawing.Size(666, 32);
            this.guna2TextBox_Asunto.TabIndex = 7;
            this.guna2TextBox_Asunto.TextOffset = new System.Drawing.Point(4, 0);
            //
            // label7
            //
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(16, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 28);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cuerpo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // guna2TextBox_Cuerpo
            //
            this.guna2TextBox_Cuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox_Cuerpo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_Cuerpo.DefaultText = "";
            this.guna2TextBox_Cuerpo.Location = new System.Drawing.Point(98, 254);
            this.guna2TextBox_Cuerpo.Multiline = true;
            this.guna2TextBox_Cuerpo.Name = "guna2TextBox_Cuerpo";
            this.guna2TextBox_Cuerpo.PasswordChar = '\0';
            this.guna2TextBox_Cuerpo.PlaceholderText = "";
            this.guna2TextBox_Cuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.guna2TextBox_Cuerpo.SelectedText = "";
            this.guna2TextBox_Cuerpo.ShadowDecoration.Parent = this.guna2TextBox_Cuerpo;
            this.guna2TextBox_Cuerpo.Size = new System.Drawing.Size(666, 186);
            this.guna2TextBox_Cuerpo.TabIndex = 9;
            this.guna2TextBox_Cuerpo.TextOffset = new System.Drawing.Point(4, 0);
            //
            // button_enviar
            //
            this.button_enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_enviar.CheckedState.Parent = this.button_enviar;
            this.button_enviar.CustomImages.Parent = this.button_enviar;
            this.button_enviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_enviar.Location = new System.Drawing.Point(600, 460);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.ShadowDecoration.Parent = this.button_enviar;
            this.button_enviar.Size = new System.Drawing.Size(164, 42);
            this.button_enviar.TabIndex = 10;
            this.button_enviar.Text = "ENVIAR CORREO";
            this.button_enviar.Click += new System.EventHandler(this.pictureBox_EnviarCorreoDestajo_Click);
            //
            // label2
            //
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(16, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(560, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "El reporte se adjunta automáticamente al enviar.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // EnviarCorreoDestajo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.panel_cuerpo);
            this.Controls.Add(this.panel_titulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(660, 520);
            this.Name = "EnviarCorreoDestajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enviar correo";
            this.Load += new System.EventHandler(this.EnviarCorreoDestajo_Load);
            this.panel_titulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EnviarCorreoDestajo)).EndInit();
            this.panel_cuerpo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_titulo;
        private System.Windows.Forms.Panel panel_cuerpo;
        private System.Windows.Forms.Label label_formulario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_IDCorreo;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_CC;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_Para;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_Asunto;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_Cuerpo;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_De;
        private Guna.UI2.WinForms.Guna2Button button_enviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox_EnviarCorreoDestajo;
    }
}
