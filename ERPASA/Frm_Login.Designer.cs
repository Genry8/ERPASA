
namespace ERPASA
{
    partial class Frm_Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.pictureBox_VerContraseña = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox_MostrarContraseña = new System.Windows.Forms.CheckBox();
            this.label_version_call = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TEXT_USUARIO = new System.Windows.Forms.TextBox();
            this.TEXT_CONTRASEÑA = new System.Windows.Forms.TextBox();
            this.panel_login2 = new System.Windows.Forms.Panel();
            this.button_login = new Guna.UI2.WinForms.Guna2Button();
            this.label_desarrollo = new System.Windows.Forms.Label();
            this.label_version_actual = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VerContraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_login2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_VerContraseña
            // 
            this.pictureBox_VerContraseña.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_VerContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_VerContraseña.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_VerContraseña.Image")));
            this.pictureBox_VerContraseña.Location = new System.Drawing.Point(350, 397);
            this.pictureBox_VerContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_VerContraseña.Name = "pictureBox_VerContraseña";
            this.pictureBox_VerContraseña.Size = new System.Drawing.Size(18, 18);
            this.pictureBox_VerContraseña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_VerContraseña.TabIndex = 32;
            this.pictureBox_VerContraseña.TabStop = false;
            this.pictureBox_VerContraseña.Visible = false;
            this.pictureBox_VerContraseña.MouseLeave += new System.EventHandler(this.pictureBox_VerContraseña_MouseLeave);
            this.pictureBox_VerContraseña.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_VerContraseña_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(92, 85);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(214, 186);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // checkBox_MostrarContraseña
            // 
            this.checkBox_MostrarContraseña.AutoSize = true;
            this.checkBox_MostrarContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.checkBox_MostrarContraseña.Location = new System.Drawing.Point(382, 397);
            this.checkBox_MostrarContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_MostrarContraseña.Name = "checkBox_MostrarContraseña";
            this.checkBox_MostrarContraseña.Size = new System.Drawing.Size(22, 21);
            this.checkBox_MostrarContraseña.TabIndex = 4;
            this.checkBox_MostrarContraseña.UseVisualStyleBackColor = true;
            this.checkBox_MostrarContraseña.Visible = false;
            // 
            // label_version_call
            // 
            this.label_version_call.AutoSize = true;
            this.label_version_call.BackColor = System.Drawing.Color.Transparent;
            this.label_version_call.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_version_call.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_version_call.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_version_call.ForeColor = System.Drawing.Color.Black;
            this.label_version_call.Location = new System.Drawing.Point(135, 268);
            this.label_version_call.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_version_call.Name = "label_version_call";
            this.label_version_call.Size = new System.Drawing.Size(0, 22);
            this.label_version_call.TabIndex = 20;
            this.label_version_call.Click += new System.EventHandler(this.label_version_call_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label4.Location = new System.Drawing.Point(42, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(341, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Para continuar, inicia sesión";
            // 
            // TEXT_USUARIO
            // 
            this.TEXT_USUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEXT_USUARIO.ForeColor = System.Drawing.Color.DarkGray;
            this.TEXT_USUARIO.Location = new System.Drawing.Point(66, 325);
            this.TEXT_USUARIO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TEXT_USUARIO.Name = "TEXT_USUARIO";
            this.TEXT_USUARIO.Size = new System.Drawing.Size(278, 28);
            this.TEXT_USUARIO.TabIndex = 2;
            this.TEXT_USUARIO.Text = "Ingrese su usuario";
            this.TEXT_USUARIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TEXT_USUARIO.Enter += new System.EventHandler(this.TEXT_USUARIO_Enter);
            this.TEXT_USUARIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXT_USUARIO_KeyPress);
            this.TEXT_USUARIO.Leave += new System.EventHandler(this.TEXT_USUARIO_Leave);
            // 
            // TEXT_CONTRASEÑA
            // 
            this.TEXT_CONTRASEÑA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEXT_CONTRASEÑA.ForeColor = System.Drawing.Color.DarkGray;
            this.TEXT_CONTRASEÑA.Location = new System.Drawing.Point(66, 390);
            this.TEXT_CONTRASEÑA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TEXT_CONTRASEÑA.Name = "TEXT_CONTRASEÑA";
            this.TEXT_CONTRASEÑA.Size = new System.Drawing.Size(278, 28);
            this.TEXT_CONTRASEÑA.TabIndex = 3;
            this.TEXT_CONTRASEÑA.Text = "Ingrese su contraseña";
            this.TEXT_CONTRASEÑA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TEXT_CONTRASEÑA.TextChanged += new System.EventHandler(this.TEXT_CONTRASEÑA_TextChanged);
            this.TEXT_CONTRASEÑA.Enter += new System.EventHandler(this.TEXT_CONTRASEÑA_Enter);
            this.TEXT_CONTRASEÑA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXT_CONTRASEÑA_KeyPress);
            this.TEXT_CONTRASEÑA.Leave += new System.EventHandler(this.TEXT_CONTRASEÑA_Leave);
            // 
            // panel_login2
            // 
            this.panel_login2.BackColor = System.Drawing.Color.White;
            this.panel_login2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_login2.Controls.Add(this.button_login);
            this.panel_login2.Controls.Add(this.pictureBox_VerContraseña);
            this.panel_login2.Controls.Add(this.pictureBox2);
            this.panel_login2.Controls.Add(this.label_desarrollo);
            this.panel_login2.Controls.Add(this.checkBox_MostrarContraseña);
            this.panel_login2.Controls.Add(this.label_version_call);
            this.panel_login2.Controls.Add(this.label_version_actual);
            this.panel_login2.Controls.Add(this.linkLabel1);
            this.panel_login2.Controls.Add(this.label4);
            this.panel_login2.Controls.Add(this.TEXT_USUARIO);
            this.panel_login2.Controls.Add(this.progressBar1);
            this.panel_login2.Controls.Add(this.TEXT_CONTRASEÑA);
            this.panel_login2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_login2.Location = new System.Drawing.Point(0, 0);
            this.panel_login2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_login2.Name = "panel_login2";
            this.panel_login2.Size = new System.Drawing.Size(421, 606);
            this.panel_login2.TabIndex = 2;
            // 
            // button_login
            // 
            this.button_login.BorderRadius = 5;
            this.button_login.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.button_login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_login.FillColor = System.Drawing.Color.SteelBlue;
            this.button_login.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(110, 458);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(168, 41);
            this.button_login.TabIndex = 33;
            this.button_login.Text = "LOGIN";
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label_desarrollo
            // 
            this.label_desarrollo.AutoSize = true;
            this.label_desarrollo.BackColor = System.Drawing.Color.Transparent;
            this.label_desarrollo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_desarrollo.Font = new System.Drawing.Font("Sitka Small", 7.25F);
            this.label_desarrollo.ForeColor = System.Drawing.Color.DimGray;
            this.label_desarrollo.Location = new System.Drawing.Point(3, 580);
            this.label_desarrollo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_desarrollo.Name = "label_desarrollo";
            this.label_desarrollo.Size = new System.Drawing.Size(0, 23);
            this.label_desarrollo.TabIndex = 21;
            // 
            // label_version_actual
            // 
            this.label_version_actual.AutoSize = true;
            this.label_version_actual.BackColor = System.Drawing.Color.Transparent;
            this.label_version_actual.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_version_actual.Font = new System.Drawing.Font("Sitka Banner", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_version_actual.ForeColor = System.Drawing.Color.Black;
            this.label_version_actual.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_version_actual.Location = new System.Drawing.Point(361, 578);
            this.label_version_actual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_version_actual.Name = "label_version_actual";
            this.label_version_actual.Size = new System.Drawing.Size(58, 24);
            this.label_version_actual.TabIndex = 22;
            this.label_version_actual.Text = "v.01.80";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.linkLabel1.Location = new System.Drawing.Point(81, 538);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(243, 22);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Ha olvidado su contraseña?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(123)))));
            this.progressBar1.Location = new System.Drawing.Point(4, 546);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(26, 15);
            this.progressBar1.TabIndex = 17;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 606);
            this.Controls.Add(this.panel_login2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VerContraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_login2.ResumeLayout(false);
            this.panel_login2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_VerContraseña;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox_MostrarContraseña;
        private System.Windows.Forms.Label label_version_call;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TEXT_USUARIO;
        private System.Windows.Forms.TextBox TEXT_CONTRASEÑA;
        private System.Windows.Forms.Panel panel_login2;
        private System.Windows.Forms.Label label_desarrollo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label_version_actual;
        private Guna.UI2.WinForms.Guna2Button button_login;
    }
}