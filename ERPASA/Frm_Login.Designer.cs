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
            this.panel_marca = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label_titulo = new System.Windows.Forms.Label();
            this.panel_divisor = new System.Windows.Forms.Panel();
            this.label_subtitulo = new System.Windows.Forms.Label();
            this.label_version_call = new System.Windows.Forms.Label();
            this.label_desarrollo = new System.Windows.Forms.Label();
            this.label_version_actual = new System.Windows.Forms.Label();
            this.panel_login2 = new System.Windows.Forms.Panel();
            this.button_minimizar = new Guna.UI2.WinForms.Guna2ControlBox();
            this.button_cerrar = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label_bienvenido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_cap_usuario = new System.Windows.Forms.Label();
            this.TEXT_USUARIO = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_cap_contrasena = new System.Windows.Forms.Label();
            this.TEXT_CONTRASEÑA = new Guna.UI2.WinForms.Guna2TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button_login = new Guna.UI2.WinForms.Guna2GradientButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.elipse_form = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.sombra_form = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.arrastrar_form = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.arrastrar_marca = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_marca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_login2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_marca
            // 
            this.panel_marca.Controls.Add(this.pictureBox2);
            this.panel_marca.Controls.Add(this.label_titulo);
            this.panel_marca.Controls.Add(this.panel_divisor);
            this.panel_marca.Controls.Add(this.label_subtitulo);
            this.panel_marca.Controls.Add(this.label_version_call);
            this.panel_marca.Controls.Add(this.label_desarrollo);
            this.panel_marca.Controls.Add(this.label_version_actual);
            this.panel_marca.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_marca.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.panel_marca.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(163)))));
            this.panel_marca.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.panel_marca.Location = new System.Drawing.Point(0, 0);
            this.panel_marca.Name = "panel_marca";
            this.panel_marca.Size = new System.Drawing.Size(380, 340);
            this.panel_marca.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImageRotate = 0F;
            this.pictureBox2.Location = new System.Drawing.Point(146, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(88, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label_titulo
            // 
            this.label_titulo.BackColor = System.Drawing.Color.Transparent;
            this.label_titulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label_titulo.ForeColor = System.Drawing.Color.White;
            this.label_titulo.Location = new System.Drawing.Point(0, 140);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(380, 45);
            this.label_titulo.TabIndex = 1;
            this.label_titulo.Text = "ERP ASA";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_divisor
            // 
            this.panel_divisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(186)))), ((int)(((byte)(203)))));
            this.panel_divisor.Location = new System.Drawing.Point(160, 194);
            this.panel_divisor.Name = "panel_divisor";
            this.panel_divisor.Size = new System.Drawing.Size(60, 3);
            this.panel_divisor.TabIndex = 2;
            // 
            // label_subtitulo
            // 
            this.label_subtitulo.BackColor = System.Drawing.Color.Transparent;
            this.label_subtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_subtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(206)))), ((int)(((byte)(214)))));
            this.label_subtitulo.Location = new System.Drawing.Point(40, 210);
            this.label_subtitulo.Name = "label_subtitulo";
            this.label_subtitulo.Size = new System.Drawing.Size(300, 50);
            this.label_subtitulo.TabIndex = 3;
            this.label_subtitulo.Text = "Sistema de gestión empresarial\r\nAgrícola Santa Azul";
            this.label_subtitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_version_call
            // 
            this.label_version_call.BackColor = System.Drawing.Color.Transparent;
            this.label_version_call.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_version_call.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label_version_call.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(196)))), ((int)(((byte)(208)))));
            this.label_version_call.Location = new System.Drawing.Point(20, 270);
            this.label_version_call.Name = "label_version_call";
            this.label_version_call.Size = new System.Drawing.Size(340, 20);
            this.label_version_call.TabIndex = 4;
            this.label_version_call.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_version_call.Click += new System.EventHandler(this.label_version_call_Click);
            // 
            // label_desarrollo
            // 
            this.label_desarrollo.BackColor = System.Drawing.Color.Transparent;
            this.label_desarrollo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label_desarrollo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.label_desarrollo.Location = new System.Drawing.Point(20, 300);
            this.label_desarrollo.Name = "label_desarrollo";
            this.label_desarrollo.Size = new System.Drawing.Size(230, 20);
            this.label_desarrollo.TabIndex = 5;
            this.label_desarrollo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_version_actual
            // 
            this.label_version_actual.BackColor = System.Drawing.Color.Transparent;
            this.label_version_actual.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_version_actual.ForeColor = System.Drawing.Color.White;
            this.label_version_actual.Location = new System.Drawing.Point(250, 300);
            this.label_version_actual.Name = "label_version_actual";
            this.label_version_actual.Size = new System.Drawing.Size(110, 20);
            this.label_version_actual.TabIndex = 6;
            this.label_version_actual.Text = "v.01.90";
            this.label_version_actual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_login2
            // 
            this.panel_login2.BackColor = System.Drawing.Color.White;
            this.panel_login2.Controls.Add(this.button_minimizar);
            this.panel_login2.Controls.Add(this.button_cerrar);
            this.panel_login2.Controls.Add(this.label_bienvenido);
            this.panel_login2.Controls.Add(this.label4);
            this.panel_login2.Controls.Add(this.label_cap_usuario);
            this.panel_login2.Controls.Add(this.TEXT_USUARIO);
            this.panel_login2.Controls.Add(this.label_cap_contrasena);
            this.panel_login2.Controls.Add(this.TEXT_CONTRASEÑA);
            this.panel_login2.Controls.Add(this.linkLabel1);
            this.panel_login2.Controls.Add(this.button_login);
            this.panel_login2.Controls.Add(this.progressBar1);
            this.panel_login2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_login2.Location = new System.Drawing.Point(380, 0);
            this.panel_login2.Name = "panel_login2";
            this.panel_login2.Size = new System.Drawing.Size(500, 340);
            this.panel_login2.TabIndex = 1;
            // 
            // button_minimizar
            // 
            this.button_minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_minimizar.BackColor = System.Drawing.Color.Transparent;
            this.button_minimizar.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.button_minimizar.FillColor = System.Drawing.Color.White;
            this.button_minimizar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.button_minimizar.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.button_minimizar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(165)))));
            this.button_minimizar.Location = new System.Drawing.Point(408, 10);
            this.button_minimizar.Name = "button_minimizar";
            this.button_minimizar.Size = new System.Drawing.Size(34, 30);
            this.button_minimizar.TabIndex = 10;
            this.button_minimizar.TabStop = false;
            // 
            // button_cerrar
            // 
            this.button_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cerrar.BackColor = System.Drawing.Color.Transparent;
            this.button_cerrar.FillColor = System.Drawing.Color.White;
            this.button_cerrar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.button_cerrar.HoverState.IconColor = System.Drawing.Color.White;
            this.button_cerrar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(165)))));
            this.button_cerrar.Location = new System.Drawing.Point(450, 10);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(34, 30);
            this.button_cerrar.TabIndex = 11;
            this.button_cerrar.TabStop = false;
            // 
            // label_bienvenido
            // 
            this.label_bienvenido.AutoSize = true;
            this.label_bienvenido.BackColor = System.Drawing.Color.Transparent;
            this.label_bienvenido.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label_bienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.label_bienvenido.Location = new System.Drawing.Point(66, 44);
            this.label_bienvenido.Name = "label_bienvenido";
            this.label_bienvenido.Size = new System.Drawing.Size(234, 54);
            this.label_bienvenido.TabIndex = 0;
            this.label_bienvenido.Text = "Bienvenido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.label4.Location = new System.Drawing.Point(69, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Para continuar, inicia sesión";
            // 
            // label_cap_usuario
            // 
            this.label_cap_usuario.AutoSize = true;
            this.label_cap_usuario.BackColor = System.Drawing.Color.Transparent;
            this.label_cap_usuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_cap_usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(82)))), ((int)(((byte)(99)))));
            this.label_cap_usuario.Location = new System.Drawing.Point(69, 122);
            this.label_cap_usuario.Name = "label_cap_usuario";
            this.label_cap_usuario.Size = new System.Drawing.Size(77, 25);
            this.label_cap_usuario.TabIndex = 2;
            this.label_cap_usuario.Text = "Usuario";
            // 
            // TEXT_USUARIO
            // 
            this.TEXT_USUARIO.Animated = true;
            this.TEXT_USUARIO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(235)))));
            this.TEXT_USUARIO.BorderRadius = 8;
            this.TEXT_USUARIO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TEXT_USUARIO.DefaultText = "";
            this.TEXT_USUARIO.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TEXT_USUARIO.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TEXT_USUARIO.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TEXT_USUARIO.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TEXT_USUARIO.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.TEXT_USUARIO.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(163)))));
            this.TEXT_USUARIO.FocusedState.FillColor = System.Drawing.Color.White;
            this.TEXT_USUARIO.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TEXT_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.TEXT_USUARIO.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.TEXT_USUARIO.Location = new System.Drawing.Point(69, 140);
            this.TEXT_USUARIO.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TEXT_USUARIO.Name = "TEXT_USUARIO";
            this.TEXT_USUARIO.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(168)))), ((int)(((byte)(180)))));
            this.TEXT_USUARIO.PlaceholderText = "Ingrese su usuario";
            this.TEXT_USUARIO.SelectedText = "";
            this.TEXT_USUARIO.Size = new System.Drawing.Size(360, 40);
            this.TEXT_USUARIO.TabIndex = 3;
            this.TEXT_USUARIO.TextOffset = new System.Drawing.Point(6, 0);
            this.TEXT_USUARIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXT_USUARIO_KeyPress);
            // 
            // label_cap_contrasena
            // 
            this.label_cap_contrasena.AutoSize = true;
            this.label_cap_contrasena.BackColor = System.Drawing.Color.Transparent;
            this.label_cap_contrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_cap_contrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(82)))), ((int)(((byte)(99)))));
            this.label_cap_contrasena.Location = new System.Drawing.Point(69, 190);
            this.label_cap_contrasena.Name = "label_cap_contrasena";
            this.label_cap_contrasena.Size = new System.Drawing.Size(108, 25);
            this.label_cap_contrasena.TabIndex = 4;
            this.label_cap_contrasena.Text = "Contraseña";
            // 
            // TEXT_CONTRASEÑA
            // 
            this.TEXT_CONTRASEÑA.Animated = true;
            this.TEXT_CONTRASEÑA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(235)))));
            this.TEXT_CONTRASEÑA.BorderRadius = 8;
            this.TEXT_CONTRASEÑA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TEXT_CONTRASEÑA.DefaultText = "";
            this.TEXT_CONTRASEÑA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TEXT_CONTRASEÑA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TEXT_CONTRASEÑA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TEXT_CONTRASEÑA.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TEXT_CONTRASEÑA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.TEXT_CONTRASEÑA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(163)))));
            this.TEXT_CONTRASEÑA.FocusedState.FillColor = System.Drawing.Color.White;
            this.TEXT_CONTRASEÑA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TEXT_CONTRASEÑA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.TEXT_CONTRASEÑA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.TEXT_CONTRASEÑA.IconRight = ((System.Drawing.Image)(resources.GetObject("TEXT_CONTRASEÑA.IconRight")));
            this.TEXT_CONTRASEÑA.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.TEXT_CONTRASEÑA.IconRightOffset = new System.Drawing.Point(-8, 0);
            this.TEXT_CONTRASEÑA.IconRightSize = new System.Drawing.Size(18, 18);
            this.TEXT_CONTRASEÑA.Location = new System.Drawing.Point(69, 208);
            this.TEXT_CONTRASEÑA.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TEXT_CONTRASEÑA.Name = "TEXT_CONTRASEÑA";
            this.TEXT_CONTRASEÑA.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(168)))), ((int)(((byte)(180)))));
            this.TEXT_CONTRASEÑA.PlaceholderText = "Ingrese su contraseña";
            this.TEXT_CONTRASEÑA.SelectedText = "";
            this.TEXT_CONTRASEÑA.Size = new System.Drawing.Size(360, 40);
            this.TEXT_CONTRASEÑA.TabIndex = 5;
            this.TEXT_CONTRASEÑA.TextOffset = new System.Drawing.Point(6, 0);
            this.TEXT_CONTRASEÑA.UseSystemPasswordChar = true;
            this.TEXT_CONTRASEÑA.IconRightClick += new System.EventHandler(this.TEXT_CONTRASEÑA_IconRightClick);
            this.TEXT_CONTRASEÑA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXT_CONTRASEÑA_KeyPress);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(107)))), ((int)(((byte)(128)))));
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(107)))), ((int)(((byte)(128)))));
            this.linkLabel1.Location = new System.Drawing.Point(229, 254);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(200, 20);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Ha olvidado su contraseña?";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(107)))), ((int)(((byte)(128)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button_login
            // 
            this.button_login.Animated = true;
            this.button_login.BorderRadius = 8;
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_login.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(163)))));
            this.button_login.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.button_login.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(163)))), ((int)(((byte)(189)))));
            this.button_login.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(105)))), ((int)(((byte)(130)))));
            this.button_login.HoverState.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(69, 278);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(360, 44);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "INICIAR SESIÓN";
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(69, 328);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 6);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.TabStop = false;
            this.progressBar1.Visible = false;
            // 
            // elipse_form
            // 
            this.elipse_form.BorderRadius = 16;
            this.elipse_form.TargetControl = this;
            // 
            // sombra_form
            // 
            this.sombra_form.BorderRadius = 16;
            this.sombra_form.TargetForm = this;
            // 
            // arrastrar_form
            // 
            this.arrastrar_form.DockIndicatorTransparencyValue = 0.6D;
            this.arrastrar_form.TargetControl = this.panel_login2;
            this.arrastrar_form.UseTransparentDrag = true;
            // 
            // arrastrar_marca
            // 
            this.arrastrar_marca.DockIndicatorTransparencyValue = 0.6D;
            this.arrastrar_marca.TargetControl = this.panel_marca;
            this.arrastrar_marca.UseTransparentDrag = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 340);
            this.Controls.Add(this.panel_login2);
            this.Controls.Add(this.panel_marca);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.panel_marca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_login2.ResumeLayout(false);
            this.panel_login2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel panel_marca;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBox2;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Panel panel_divisor;
        private System.Windows.Forms.Label label_subtitulo;
        private System.Windows.Forms.Label label_version_call;
        private System.Windows.Forms.Label label_desarrollo;
        public System.Windows.Forms.Label label_version_actual;
        private System.Windows.Forms.Panel panel_login2;
        private Guna.UI2.WinForms.Guna2ControlBox button_minimizar;
        private Guna.UI2.WinForms.Guna2ControlBox button_cerrar;
        private System.Windows.Forms.Label label_bienvenido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_cap_usuario;
        private Guna.UI2.WinForms.Guna2TextBox TEXT_USUARIO;
        private System.Windows.Forms.Label label_cap_contrasena;
        private Guna.UI2.WinForms.Guna2TextBox TEXT_CONTRASEÑA;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2GradientButton button_login;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Guna.UI2.WinForms.Guna2Elipse elipse_form;
        private Guna.UI2.WinForms.Guna2ShadowForm sombra_form;
        private Guna.UI2.WinForms.Guna2DragControl arrastrar_form;
        private Guna.UI2.WinForms.Guna2DragControl arrastrar_marca;
        private System.Windows.Forms.Timer timer1;
    }
}
