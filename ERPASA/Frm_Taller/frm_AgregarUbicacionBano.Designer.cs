
namespace ERPASA.Frm_Taller
{
    partial class frm_AgregarUbicacionBano
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
            this.label_Empresa = new System.Windows.Forms.Label();
            this.comboBox_empresa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Sede = new System.Windows.Forms.Label();
            this.comboBox_sede = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Cabezal = new System.Windows.Forms.Label();
            this.textBox_Cabezal = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Valvula = new System.Windows.Forms.Label();
            this.textBox_Valvula = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_NroBano = new System.Windows.Forms.Label();
            this.textBox_NroBano = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Genero = new System.Windows.Forms.Label();
            this.comboBox_Genero = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Foto = new System.Windows.Forms.Label();
            this.textBox_Foto = new Guna.UI2.WinForms.Guna2TextBox();
            this.button_Foto = new System.Windows.Forms.Button();
            this.label_Obs = new System.Windows.Forms.Label();
            this.textBox_Obs = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.toolStrip1.Size = new System.Drawing.Size(694, 40);
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
            this.groupBox1.Controls.Add(this.label_Empresa);
            this.groupBox1.Controls.Add(this.comboBox_empresa);
            this.groupBox1.Controls.Add(this.label_Sede);
            this.groupBox1.Controls.Add(this.comboBox_sede);
            this.groupBox1.Controls.Add(this.label_Cabezal);
            this.groupBox1.Controls.Add(this.textBox_Cabezal);
            this.groupBox1.Controls.Add(this.label_Valvula);
            this.groupBox1.Controls.Add(this.textBox_Valvula);
            this.groupBox1.Controls.Add(this.label_NroBano);
            this.groupBox1.Controls.Add(this.textBox_NroBano);
            this.groupBox1.Controls.Add(this.label_Genero);
            this.groupBox1.Controls.Add(this.comboBox_Genero);
            this.groupBox1.Controls.Add(this.label_Foto);
            this.groupBox1.Controls.Add(this.textBox_Foto);
            this.groupBox1.Controls.Add(this.button_Foto);
            this.groupBox1.Controls.Add(this.label_Obs);
            this.groupBox1.Controls.Add(this.textBox_Obs);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 366);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del baño";
            // 
            // label_Empresa
            // 
            this.label_Empresa.AutoSize = true;
            this.label_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Empresa.Location = new System.Drawing.Point(24, 36);
            this.label_Empresa.Name = "label_Empresa";
            this.label_Empresa.Size = new System.Drawing.Size(88, 20);
            this.label_Empresa.TabIndex = 0;
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
            this.comboBox_empresa.Location = new System.Drawing.Point(140, 30);
            this.comboBox_empresa.Name = "comboBox_empresa";
            this.comboBox_empresa.Size = new System.Drawing.Size(320, 36);
            this.comboBox_empresa.TabIndex = 1;
            this.comboBox_empresa.SelectedIndexChanged += new System.EventHandler(this.comboBox_empresa_SelectedIndexChanged);
            // 
            // label_Sede
            // 
            this.label_Sede.AutoSize = true;
            this.label_Sede.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Sede.Location = new System.Drawing.Point(24, 82);
            this.label_Sede.Name = "label_Sede";
            this.label_Sede.Size = new System.Drawing.Size(54, 20);
            this.label_Sede.TabIndex = 2;
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
            this.comboBox_sede.Location = new System.Drawing.Point(140, 76);
            this.comboBox_sede.Name = "comboBox_sede";
            this.comboBox_sede.Size = new System.Drawing.Size(320, 36);
            this.comboBox_sede.TabIndex = 3;
            // 
            // label_Cabezal
            // 
            this.label_Cabezal.AutoSize = true;
            this.label_Cabezal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Cabezal.Location = new System.Drawing.Point(24, 128);
            this.label_Cabezal.Name = "label_Cabezal";
            this.label_Cabezal.Size = new System.Drawing.Size(83, 20);
            this.label_Cabezal.TabIndex = 4;
            this.label_Cabezal.Text = "CABEZAL";
            // 
            // textBox_Cabezal
            // 
            this.textBox_Cabezal.BackColor = System.Drawing.Color.Transparent;
            this.textBox_Cabezal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.textBox_Cabezal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBox_Cabezal.FocusedColor = System.Drawing.Color.Empty;
            this.textBox_Cabezal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Cabezal.FormattingEnabled = true;
            this.textBox_Cabezal.ItemHeight = 30;
            this.textBox_Cabezal.Location = new System.Drawing.Point(140, 122);
            this.textBox_Cabezal.Name = "textBox_Cabezal";
            this.textBox_Cabezal.Size = new System.Drawing.Size(320, 36);
            this.textBox_Cabezal.TabIndex = 5;
            // 
            // label_Valvula
            // 
            this.label_Valvula.AutoSize = true;
            this.label_Valvula.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Valvula.Location = new System.Drawing.Point(24, 174);
            this.label_Valvula.Name = "label_Valvula";
            this.label_Valvula.Size = new System.Drawing.Size(83, 20);
            this.label_Valvula.TabIndex = 6;
            this.label_Valvula.Text = "VALVULA";
            // 
            // textBox_Valvula
            // 
            this.textBox_Valvula.BorderRadius = 6;
            this.textBox_Valvula.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Valvula.DefaultText = "";
            this.textBox_Valvula.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Valvula.Location = new System.Drawing.Point(140, 168);
            this.textBox_Valvula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Valvula.MaxLength = 80;
            this.textBox_Valvula.Name = "textBox_Valvula";
            this.textBox_Valvula.PlaceholderText = "";
            this.textBox_Valvula.SelectedText = "";
            this.textBox_Valvula.Size = new System.Drawing.Size(320, 36);
            this.textBox_Valvula.TabIndex = 7;
            // 
            // label_NroBano
            // 
            this.label_NroBano.AutoSize = true;
            this.label_NroBano.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_NroBano.Location = new System.Drawing.Point(24, 220);
            this.label_NroBano.Name = "label_NroBano";
            this.label_NroBano.Size = new System.Drawing.Size(101, 20);
            this.label_NroBano.TabIndex = 8;
            this.label_NroBano.Text = "N° DE BAÑO";
            // 
            // textBox_NroBano
            // 
            this.textBox_NroBano.BorderRadius = 6;
            this.textBox_NroBano.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_NroBano.DefaultText = "";
            this.textBox_NroBano.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_NroBano.Location = new System.Drawing.Point(140, 214);
            this.textBox_NroBano.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_NroBano.MaxLength = 20;
            this.textBox_NroBano.Name = "textBox_NroBano";
            this.textBox_NroBano.PlaceholderText = "";
            this.textBox_NroBano.SelectedText = "";
            this.textBox_NroBano.Size = new System.Drawing.Size(150, 36);
            this.textBox_NroBano.TabIndex = 9;
            // 
            // label_Genero
            // 
            this.label_Genero.AutoSize = true;
            this.label_Genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Genero.Location = new System.Drawing.Point(310, 220);
            this.label_Genero.Name = "label_Genero";
            this.label_Genero.Size = new System.Drawing.Size(79, 20);
            this.label_Genero.TabIndex = 10;
            this.label_Genero.Text = "GENERO";
            // 
            // comboBox_Genero
            // 
            this.comboBox_Genero.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_Genero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Genero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Genero.FocusedColor = System.Drawing.Color.Empty;
            this.comboBox_Genero.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_Genero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_Genero.FormattingEnabled = true;
            this.comboBox_Genero.ItemHeight = 30;
            this.comboBox_Genero.Location = new System.Drawing.Point(400, 214);
            this.comboBox_Genero.Name = "comboBox_Genero";
            this.comboBox_Genero.Size = new System.Drawing.Size(200, 36);
            this.comboBox_Genero.TabIndex = 11;
            // 
            // label_Foto
            // 
            this.label_Foto.AutoSize = true;
            this.label_Foto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Foto.Location = new System.Drawing.Point(24, 266);
            this.label_Foto.Name = "label_Foto";
            this.label_Foto.Size = new System.Drawing.Size(52, 20);
            this.label_Foto.TabIndex = 12;
            this.label_Foto.Text = "FOTO";
            this.label_Foto.Visible = false;
            // 
            // textBox_Foto
            // 
            this.textBox_Foto.BorderRadius = 6;
            this.textBox_Foto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Foto.DefaultText = "";
            this.textBox_Foto.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Foto.Location = new System.Drawing.Point(140, 260);
            this.textBox_Foto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Foto.MaxLength = 200;
            this.textBox_Foto.Name = "textBox_Foto";
            this.textBox_Foto.PlaceholderText = "";
            this.textBox_Foto.SelectedText = "";
            this.textBox_Foto.Size = new System.Drawing.Size(400, 36);
            this.textBox_Foto.TabIndex = 13;
            this.textBox_Foto.Visible = false;
            // 
            // button_Foto
            // 
            this.button_Foto.Location = new System.Drawing.Point(550, 260);
            this.button_Foto.Name = "button_Foto";
            this.button_Foto.Size = new System.Drawing.Size(50, 36);
            this.button_Foto.TabIndex = 14;
            this.button_Foto.Text = "...";
            this.button_Foto.UseVisualStyleBackColor = true;
            this.button_Foto.Visible = false;
            this.button_Foto.Click += new System.EventHandler(this.button_Foto_Click);
            // 
            // label_Obs
            // 
            this.label_Obs.AutoSize = true;
            this.label_Obs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Obs.Location = new System.Drawing.Point(24, 312);
            this.label_Obs.Name = "label_Obs";
            this.label_Obs.Size = new System.Drawing.Size(127, 20);
            this.label_Obs.TabIndex = 15;
            this.label_Obs.Text = "OBSERVACION";
            // 
            // textBox_Obs
            // 
            this.textBox_Obs.BorderRadius = 6;
            this.textBox_Obs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Obs.DefaultText = "";
            this.textBox_Obs.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Obs.Location = new System.Drawing.Point(160, 306);
            this.textBox_Obs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Obs.Multiline = true;
            this.textBox_Obs.Name = "textBox_Obs";
            this.textBox_Obs.PlaceholderText = "";
            this.textBox_Obs.SelectedText = "";
            this.textBox_Obs.Size = new System.Drawing.Size(440, 46);
            this.textBox_Obs.TabIndex = 16;
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Location = new System.Drawing.Point(640, 20);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(18, 20);
            this.label_Id.TabIndex = 2;
            this.label_Id.Text = "0";
            this.label_Id.Visible = false;
            // 
            // frm_AgregarUbicacionBano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 430);
            this.Controls.Add(this.label_Id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_AgregarUbicacionBano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UBICACION DE BAÑO";
            this.Load += new System.EventHandler(this.frm_AgregarUbicacionBano_Load);
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
        private System.Windows.Forms.Label label_Empresa;
        private System.Windows.Forms.Label label_Sede;
        private System.Windows.Forms.Label label_Cabezal;
        private System.Windows.Forms.Label label_Valvula;
        private System.Windows.Forms.Label label_NroBano;
        private System.Windows.Forms.Label label_Genero;
        private System.Windows.Forms.Label label_Obs;
        private System.Windows.Forms.Label label_Foto;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_empresa;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_sede;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_Genero;
        public Guna.UI2.WinForms.Guna2ComboBox textBox_Cabezal;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Valvula;
        public Guna.UI2.WinForms.Guna2TextBox textBox_NroBano;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Obs;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Foto;
        private System.Windows.Forms.Button button_Foto;
        public System.Windows.Forms.Label label_Id;
    }
}
