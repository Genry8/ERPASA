namespace ERPASA.Frm_Sistema
{
    partial class frm_AgregarCorreo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_guardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_guardar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_limpiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_limpiar = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_Fecha = new System.Windows.Forms.Label();
            this.dateTimePicker_Fecha = new System.Windows.Forms.DateTimePicker();
            this.label_TipoCorreo = new System.Windows.Forms.Label();
            this.textBox_TipoCorreo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Empresa = new System.Windows.Forms.Label();
            this.comboBox_empresa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Formulario = new System.Windows.Forms.Label();
            this.textBox_Formulario = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Sede = new System.Windows.Forms.Label();
            this.comboBox_sede = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Responsable = new System.Windows.Forms.Label();
            this.textBox_Responsable = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Gerencia = new System.Windows.Forms.Label();
            this.textBox_Gerencia = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Area = new System.Windows.Forms.Label();
            this.textBox_Area = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_De = new System.Windows.Forms.Label();
            this.textBox_De = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Para = new System.Windows.Forms.Label();
            this.textBox_Para = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_CC = new System.Windows.Forms.Label();
            this.textBox_CC = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Asunto = new System.Windows.Forms.Label();
            this.textBox_Asunto = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Cuerpo = new System.Windows.Forms.Label();
            this.textBox_Cuerpo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_UUID = new System.Windows.Forms.Label();
            this.textBox_UUID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Id = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_guardar,
            this.toolStripLabel_guardar,
            this.toolStripSeparator1,
            this.toolStripButton_limpiar,
            this.toolStripLabel_limpiar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1424, 40);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_guardar
            // 
            this.toolStripButton_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_guardar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_guardar.Name = "toolStripButton_guardar";
            this.toolStripButton_guardar.Size = new System.Drawing.Size(101, 35);
            this.toolStripButton_guardar.Text = "Guardar";
            this.toolStripButton_guardar.Click += new System.EventHandler(this.toolStripButton_guardar_Click);
            // 
            // toolStripLabel_guardar
            // 
            this.toolStripLabel_guardar.Name = "toolStripLabel_guardar";
            this.toolStripLabel_guardar.Size = new System.Drawing.Size(0, 35);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton_limpiar
            // 
            this.toolStripButton_limpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_limpiar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_limpiar.Name = "toolStripButton_limpiar";
            this.toolStripButton_limpiar.Size = new System.Drawing.Size(95, 35);
            this.toolStripButton_limpiar.Text = "Limpiar";
            this.toolStripButton_limpiar.Click += new System.EventHandler(this.toolStripButton_limpiar_Click);
            // 
            // toolStripLabel_limpiar
            // 
            this.toolStripLabel_limpiar.Name = "toolStripLabel_limpiar";
            this.toolStripLabel_limpiar.Size = new System.Drawing.Size(0, 35);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label_Fecha);
            this.groupBox1.Controls.Add(this.dateTimePicker_Fecha);
            this.groupBox1.Controls.Add(this.label_TipoCorreo);
            this.groupBox1.Controls.Add(this.textBox_TipoCorreo);
            this.groupBox1.Controls.Add(this.label_Empresa);
            this.groupBox1.Controls.Add(this.comboBox_empresa);
            this.groupBox1.Controls.Add(this.label_Formulario);
            this.groupBox1.Controls.Add(this.textBox_Formulario);
            this.groupBox1.Controls.Add(this.label_Sede);
            this.groupBox1.Controls.Add(this.comboBox_sede);
            this.groupBox1.Controls.Add(this.label_Responsable);
            this.groupBox1.Controls.Add(this.textBox_Responsable);
            this.groupBox1.Controls.Add(this.label_Gerencia);
            this.groupBox1.Controls.Add(this.textBox_Gerencia);
            this.groupBox1.Controls.Add(this.label_Area);
            this.groupBox1.Controls.Add(this.textBox_Area);
            this.groupBox1.Controls.Add(this.label_De);
            this.groupBox1.Controls.Add(this.textBox_De);
            this.groupBox1.Controls.Add(this.label_Para);
            this.groupBox1.Controls.Add(this.textBox_Para);
            this.groupBox1.Controls.Add(this.label_CC);
            this.groupBox1.Controls.Add(this.textBox_CC);
            this.groupBox1.Controls.Add(this.label_Asunto);
            this.groupBox1.Controls.Add(this.textBox_Asunto);
            this.groupBox1.Controls.Add(this.label_Cuerpo);
            this.groupBox1.Controls.Add(this.textBox_Cuerpo);
            this.groupBox1.Controls.Add(this.label_UUID);
            this.groupBox1.Controls.Add(this.textBox_UUID);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1400, 645);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del correo";
            // 
            // label_Fecha
            // 
            this.label_Fecha.AutoSize = true;
            this.label_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Fecha.Location = new System.Drawing.Point(20, 36);
            this.label_Fecha.Name = "label_Fecha";
            this.label_Fecha.Size = new System.Drawing.Size(64, 20);
            this.label_Fecha.TabIndex = 0;
            this.label_Fecha.Text = "FECHA";
            // 
            // dateTimePicker_Fecha
            // 
            this.dateTimePicker_Fecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker_Fecha.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Fecha.Location = new System.Drawing.Point(165, 30);
            this.dateTimePicker_Fecha.Name = "dateTimePicker_Fecha";
            this.dateTimePicker_Fecha.Size = new System.Drawing.Size(230, 32);
            this.dateTimePicker_Fecha.TabIndex = 1;
            // 
            // label_TipoCorreo
            // 
            this.label_TipoCorreo.AutoSize = true;
            this.label_TipoCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_TipoCorreo.Location = new System.Drawing.Point(480, 36);
            this.label_TipoCorreo.Name = "label_TipoCorreo";
            this.label_TipoCorreo.Size = new System.Drawing.Size(119, 20);
            this.label_TipoCorreo.TabIndex = 2;
            this.label_TipoCorreo.Text = "TIPO CORREO";
            // 
            // textBox_TipoCorreo
            // 
            this.textBox_TipoCorreo.BorderRadius = 6;
            this.textBox_TipoCorreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_TipoCorreo.DefaultText = "";
            this.textBox_TipoCorreo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_TipoCorreo.Location = new System.Drawing.Point(625, 30);
            this.textBox_TipoCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_TipoCorreo.MaxLength = 180;
            this.textBox_TipoCorreo.Name = "textBox_TipoCorreo";
            this.textBox_TipoCorreo.PlaceholderText = "";
            this.textBox_TipoCorreo.SelectedText = "";
            this.textBox_TipoCorreo.Size = new System.Drawing.Size(300, 36);
            this.textBox_TipoCorreo.TabIndex = 3;
            // 
            // label_Empresa
            // 
            this.label_Empresa.AutoSize = true;
            this.label_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Empresa.Location = new System.Drawing.Point(20, 82);
            this.label_Empresa.Name = "label_Empresa";
            this.label_Empresa.Size = new System.Drawing.Size(88, 20);
            this.label_Empresa.TabIndex = 4;
            this.label_Empresa.Text = "EMPRESA";
            // 
            // comboBox_empresa
            // 
            this.comboBox_empresa.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_empresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_empresa.FocusedColor = System.Drawing.Color.Empty;
            this.comboBox_empresa.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_empresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_empresa.FormattingEnabled = true;
            this.comboBox_empresa.ItemHeight = 30;
            this.comboBox_empresa.Location = new System.Drawing.Point(165, 76);
            this.comboBox_empresa.Name = "comboBox_empresa";
            this.comboBox_empresa.Size = new System.Drawing.Size(290, 36);
            this.comboBox_empresa.TabIndex = 5;
            this.comboBox_empresa.SelectedIndexChanged += new System.EventHandler(this.comboBox_empresa_SelectedIndexChanged);
            // 
            // label_Formulario
            // 
            this.label_Formulario.AutoSize = true;
            this.label_Formulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Formulario.Location = new System.Drawing.Point(480, 82);
            this.label_Formulario.Name = "label_Formulario";
            this.label_Formulario.Size = new System.Drawing.Size(117, 20);
            this.label_Formulario.TabIndex = 6;
            this.label_Formulario.Text = "FORMULARIO";
            // 
            // textBox_Formulario
            // 
            this.textBox_Formulario.BorderRadius = 6;
            this.textBox_Formulario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Formulario.DefaultText = "";
            this.textBox_Formulario.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Formulario.Location = new System.Drawing.Point(625, 76);
            this.textBox_Formulario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Formulario.MaxLength = 180;
            this.textBox_Formulario.Name = "textBox_Formulario";
            this.textBox_Formulario.PlaceholderText = "";
            this.textBox_Formulario.SelectedText = "";
            this.textBox_Formulario.Size = new System.Drawing.Size(300, 36);
            this.textBox_Formulario.TabIndex = 7;
            // 
            // label_Sede
            // 
            this.label_Sede.AutoSize = true;
            this.label_Sede.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Sede.Location = new System.Drawing.Point(20, 128);
            this.label_Sede.Name = "label_Sede";
            this.label_Sede.Size = new System.Drawing.Size(54, 20);
            this.label_Sede.TabIndex = 8;
            this.label_Sede.Text = "SEDE";
            // 
            // comboBox_sede
            // 
            this.comboBox_sede.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_sede.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_sede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sede.FocusedColor = System.Drawing.Color.Empty;
            this.comboBox_sede.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_sede.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_sede.FormattingEnabled = true;
            this.comboBox_sede.ItemHeight = 30;
            this.comboBox_sede.Location = new System.Drawing.Point(165, 122);
            this.comboBox_sede.Name = "comboBox_sede";
            this.comboBox_sede.Size = new System.Drawing.Size(290, 36);
            this.comboBox_sede.TabIndex = 9;
            // 
            // label_Responsable
            // 
            this.label_Responsable.AutoSize = true;
            this.label_Responsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Responsable.Location = new System.Drawing.Point(480, 128);
            this.label_Responsable.Name = "label_Responsable";
            this.label_Responsable.Size = new System.Drawing.Size(129, 20);
            this.label_Responsable.TabIndex = 10;
            this.label_Responsable.Text = "RESPONSABLE";
            // 
            // textBox_Responsable
            // 
            this.textBox_Responsable.BorderRadius = 6;
            this.textBox_Responsable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Responsable.DefaultText = "";
            this.textBox_Responsable.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Responsable.Location = new System.Drawing.Point(625, 122);
            this.textBox_Responsable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Responsable.MaxLength = 180;
            this.textBox_Responsable.Name = "textBox_Responsable";
            this.textBox_Responsable.PlaceholderText = "";
            this.textBox_Responsable.SelectedText = "";
            this.textBox_Responsable.Size = new System.Drawing.Size(300, 36);
            this.textBox_Responsable.TabIndex = 11;
            // 
            // label_Gerencia
            // 
            this.label_Gerencia.AutoSize = true;
            this.label_Gerencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Gerencia.Location = new System.Drawing.Point(947, 36);
            this.label_Gerencia.Name = "label_Gerencia";
            this.label_Gerencia.Size = new System.Drawing.Size(94, 20);
            this.label_Gerencia.TabIndex = 12;
            this.label_Gerencia.Text = "GERENCIA";
            // 
            // textBox_Gerencia
            // 
            this.textBox_Gerencia.BorderRadius = 6;
            this.textBox_Gerencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Gerencia.DefaultText = "";
            this.textBox_Gerencia.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Gerencia.Location = new System.Drawing.Point(1092, 30);
            this.textBox_Gerencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Gerencia.MaxLength = 180;
            this.textBox_Gerencia.Name = "textBox_Gerencia";
            this.textBox_Gerencia.PlaceholderText = "";
            this.textBox_Gerencia.SelectedText = "";
            this.textBox_Gerencia.Size = new System.Drawing.Size(290, 36);
            this.textBox_Gerencia.TabIndex = 13;
            // 
            // label_Area
            // 
            this.label_Area.AutoSize = true;
            this.label_Area.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Area.Location = new System.Drawing.Point(947, 82);
            this.label_Area.Name = "label_Area";
            this.label_Area.Size = new System.Drawing.Size(54, 20);
            this.label_Area.TabIndex = 14;
            this.label_Area.Text = "AREA";
            // 
            // textBox_Area
            // 
            this.textBox_Area.BorderRadius = 6;
            this.textBox_Area.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Area.DefaultText = "";
            this.textBox_Area.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Area.Location = new System.Drawing.Point(1092, 76);
            this.textBox_Area.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Area.MaxLength = 180;
            this.textBox_Area.Name = "textBox_Area";
            this.textBox_Area.PlaceholderText = "";
            this.textBox_Area.SelectedText = "";
            this.textBox_Area.Size = new System.Drawing.Size(290, 36);
            this.textBox_Area.TabIndex = 15;
            // 
            // label_De
            // 
            this.label_De.AutoSize = true;
            this.label_De.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_De.Location = new System.Drawing.Point(20, 180);
            this.label_De.Name = "label_De";
            this.label_De.Size = new System.Drawing.Size(32, 20);
            this.label_De.TabIndex = 16;
            this.label_De.Text = "DE";
            // 
            // textBox_De
            // 
            this.textBox_De.BorderRadius = 6;
            this.textBox_De.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_De.DefaultText = "";
            this.textBox_De.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_De.Location = new System.Drawing.Point(165, 174);
            this.textBox_De.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_De.Name = "textBox_De";
            this.textBox_De.PlaceholderText = "remitente@agsantaazul.com";
            this.textBox_De.SelectedText = "";
            this.textBox_De.Size = new System.Drawing.Size(760, 36);
            this.textBox_De.TabIndex = 17;
            // 
            // label_Para
            // 
            this.label_Para.AutoSize = true;
            this.label_Para.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Para.Location = new System.Drawing.Point(20, 226);
            this.label_Para.Name = "label_Para";
            this.label_Para.Size = new System.Drawing.Size(53, 20);
            this.label_Para.TabIndex = 18;
            this.label_Para.Text = "PARA";
            // 
            // textBox_Para
            // 
            this.textBox_Para.BorderRadius = 6;
            this.textBox_Para.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Para.DefaultText = "";
            this.textBox_Para.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Para.Location = new System.Drawing.Point(165, 220);
            this.textBox_Para.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Para.Multiline = true;
            this.textBox_Para.Name = "textBox_Para";
            this.textBox_Para.PlaceholderText = "Separe los destinatarios con ;";
            this.textBox_Para.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Para.SelectedText = "";
            this.textBox_Para.Size = new System.Drawing.Size(760, 70);
            this.textBox_Para.TabIndex = 19;
            // 
            // label_CC
            // 
            this.label_CC.AutoSize = true;
            this.label_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_CC.Location = new System.Drawing.Point(20, 346);
            this.label_CC.Name = "label_CC";
            this.label_CC.Size = new System.Drawing.Size(31, 20);
            this.label_CC.TabIndex = 20;
            this.label_CC.Text = "CC";
            // 
            // textBox_CC
            // 
            this.textBox_CC.BorderRadius = 6;
            this.textBox_CC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_CC.DefaultText = "";
            this.textBox_CC.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_CC.Location = new System.Drawing.Point(165, 300);
            this.textBox_CC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_CC.Multiline = true;
            this.textBox_CC.Name = "textBox_CC";
            this.textBox_CC.PlaceholderText = "Separe las copias con ;";
            this.textBox_CC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CC.SelectedText = "";
            this.textBox_CC.Size = new System.Drawing.Size(760, 110);
            this.textBox_CC.TabIndex = 21;
            // 
            // label_Asunto
            // 
            this.label_Asunto.AutoSize = true;
            this.label_Asunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Asunto.Location = new System.Drawing.Point(20, 426);
            this.label_Asunto.Name = "label_Asunto";
            this.label_Asunto.Size = new System.Drawing.Size(75, 20);
            this.label_Asunto.TabIndex = 22;
            this.label_Asunto.Text = "ASUNTO";
            // 
            // textBox_Asunto
            // 
            this.textBox_Asunto.BorderRadius = 6;
            this.textBox_Asunto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Asunto.DefaultText = "";
            this.textBox_Asunto.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Asunto.Location = new System.Drawing.Point(165, 420);
            this.textBox_Asunto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Asunto.Name = "textBox_Asunto";
            this.textBox_Asunto.PlaceholderText = "";
            this.textBox_Asunto.SelectedText = "";
            this.textBox_Asunto.Size = new System.Drawing.Size(760, 36);
            this.textBox_Asunto.TabIndex = 23;
            // 
            // label_Cuerpo
            // 
            this.label_Cuerpo.AutoSize = true;
            this.label_Cuerpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Cuerpo.Location = new System.Drawing.Point(20, 472);
            this.label_Cuerpo.Name = "label_Cuerpo";
            this.label_Cuerpo.Size = new System.Drawing.Size(77, 20);
            this.label_Cuerpo.TabIndex = 24;
            this.label_Cuerpo.Text = "CUERPO";
            // 
            // textBox_Cuerpo
            // 
            this.textBox_Cuerpo.BorderRadius = 6;
            this.textBox_Cuerpo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Cuerpo.DefaultText = "";
            this.textBox_Cuerpo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Cuerpo.Location = new System.Drawing.Point(165, 466);
            this.textBox_Cuerpo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Cuerpo.Multiline = true;
            this.textBox_Cuerpo.Name = "textBox_Cuerpo";
            this.textBox_Cuerpo.PlaceholderText = "";
            this.textBox_Cuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Cuerpo.SelectedText = "";
            this.textBox_Cuerpo.Size = new System.Drawing.Size(760, 110);
            this.textBox_Cuerpo.TabIndex = 25;
            // 
            // label_UUID
            // 
            this.label_UUID.AutoSize = true;
            this.label_UUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_UUID.Location = new System.Drawing.Point(20, 592);
            this.label_UUID.Name = "label_UUID";
            this.label_UUID.Size = new System.Drawing.Size(50, 20);
            this.label_UUID.TabIndex = 26;
            this.label_UUID.Text = "UUID";
            // 
            // textBox_UUID
            // 
            this.textBox_UUID.BorderRadius = 6;
            this.textBox_UUID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_UUID.DefaultText = "";
            this.textBox_UUID.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_UUID.Location = new System.Drawing.Point(165, 586);
            this.textBox_UUID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_UUID.MaxLength = 1000;
            this.textBox_UUID.Name = "textBox_UUID";
            this.textBox_UUID.PlaceholderText = "";
            this.textBox_UUID.SelectedText = "";
            this.textBox_UUID.Size = new System.Drawing.Size(760, 36);
            this.textBox_UUID.TabIndex = 27;
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Location = new System.Drawing.Point(930, 20);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(18, 20);
            this.label_Id.TabIndex = 2;
            this.label_Id.Text = "0";
            this.label_Id.Visible = false;
            // 
            // frm_AgregarCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1424, 710);
            this.Controls.Add(this.label_Id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_AgregarCorreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURAR CORREO";
            this.Load += new System.EventHandler(this.frm_AgregarCorreo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_guardar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_limpiar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_limpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Fecha;
        private System.Windows.Forms.Label label_TipoCorreo;
        private System.Windows.Forms.Label label_Empresa;
        private System.Windows.Forms.Label label_Formulario;
        private System.Windows.Forms.Label label_Sede;
        private System.Windows.Forms.Label label_Responsable;
        private System.Windows.Forms.Label label_Gerencia;
        private System.Windows.Forms.Label label_Area;
        private System.Windows.Forms.Label label_De;
        private System.Windows.Forms.Label label_Para;
        private System.Windows.Forms.Label label_CC;
        private System.Windows.Forms.Label label_Asunto;
        private System.Windows.Forms.Label label_Cuerpo;
        private System.Windows.Forms.Label label_UUID;
        public System.Windows.Forms.DateTimePicker dateTimePicker_Fecha;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_empresa;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_sede;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Gerencia;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Area;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Responsable;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Formulario;
        public Guna.UI2.WinForms.Guna2TextBox textBox_TipoCorreo;
        public Guna.UI2.WinForms.Guna2TextBox textBox_De;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Para;
        public Guna.UI2.WinForms.Guna2TextBox textBox_CC;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Asunto;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Cuerpo;
        public Guna.UI2.WinForms.Guna2TextBox textBox_UUID;
        public System.Windows.Forms.Label label_Id;
    }
}
