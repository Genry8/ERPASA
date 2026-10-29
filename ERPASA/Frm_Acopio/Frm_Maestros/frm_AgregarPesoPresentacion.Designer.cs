
namespace ERPASA.Frm_Acopio.Frm_Maestros
{
    partial class frm_AgregarPesoPresentacion
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
            this.label_Cultivo = new System.Windows.Forms.Label();
            this.comboBox_Cultivo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_Presentacion = new System.Windows.Forms.Label();
            this.textBox_Presentacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Peso = new System.Windows.Forms.Label();
            this.textBox_Peso = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_PorcentajeMin = new System.Windows.Forms.Label();
            this.textBox_PorcentajeMin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Porcentaje = new System.Windows.Forms.Label();
            this.textBox_Porcentaje = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.groupBox1.Controls.Add(this.label_Cultivo);
            this.groupBox1.Controls.Add(this.comboBox_Cultivo);
            this.groupBox1.Controls.Add(this.label_Presentacion);
            this.groupBox1.Controls.Add(this.textBox_Presentacion);
            this.groupBox1.Controls.Add(this.label_Peso);
            this.groupBox1.Controls.Add(this.textBox_Peso);
            this.groupBox1.Controls.Add(this.label_PorcentajeMin);
            this.groupBox1.Controls.Add(this.textBox_PorcentajeMin);
            this.groupBox1.Controls.Add(this.label_Porcentaje);
            this.groupBox1.Controls.Add(this.textBox_Porcentaje);
            this.groupBox1.Controls.Add(this.label_Obs);
            this.groupBox1.Controls.Add(this.textBox_Obs);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 366);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la presentacion";
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
            this.comboBox_empresa.Location = new System.Drawing.Point(180, 30);
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
            this.comboBox_sede.Location = new System.Drawing.Point(180, 76);
            this.comboBox_sede.Name = "comboBox_sede";
            this.comboBox_sede.Size = new System.Drawing.Size(320, 36);
            this.comboBox_sede.TabIndex = 3;
            // 
            // label_Cultivo
            // 
            this.label_Cultivo.AutoSize = true;
            this.label_Cultivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Cultivo.Location = new System.Drawing.Point(24, 128);
            this.label_Cultivo.Name = "label_Cultivo";
            this.label_Cultivo.Size = new System.Drawing.Size(83, 20);
            this.label_Cultivo.TabIndex = 4;
            this.label_Cultivo.Text = "CULTIVO";
            // 
            // comboBox_Cultivo
            // 
            this.comboBox_Cultivo.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_Cultivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Cultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Cultivo.FocusedColor = System.Drawing.Color.Empty;
            this.comboBox_Cultivo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_Cultivo.FormattingEnabled = true;
            this.comboBox_Cultivo.ItemHeight = 30;
            this.comboBox_Cultivo.Location = new System.Drawing.Point(180, 122);
            this.comboBox_Cultivo.Name = "comboBox_Cultivo";
            this.comboBox_Cultivo.Size = new System.Drawing.Size(320, 36);
            this.comboBox_Cultivo.TabIndex = 5;
            // 
            // label_Presentacion
            // 
            this.label_Presentacion.AutoSize = true;
            this.label_Presentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Presentacion.Location = new System.Drawing.Point(24, 174);
            this.label_Presentacion.Name = "label_Presentacion";
            this.label_Presentacion.Size = new System.Drawing.Size(83, 20);
            this.label_Presentacion.TabIndex = 6;
            this.label_Presentacion.Text = "PRESENTACION";
            // 
            // textBox_Presentacion
            // 
            this.textBox_Presentacion.BorderRadius = 6;
            this.textBox_Presentacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Presentacion.DefaultText = "";
            this.textBox_Presentacion.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Presentacion.Location = new System.Drawing.Point(180, 168);
            this.textBox_Presentacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Presentacion.MaxLength = 80;
            this.textBox_Presentacion.Name = "textBox_Presentacion";
            this.textBox_Presentacion.PlaceholderText = "";
            this.textBox_Presentacion.SelectedText = "";
            this.textBox_Presentacion.Size = new System.Drawing.Size(320, 36);
            this.textBox_Presentacion.TabIndex = 7;
            // 
            // label_Peso
            // 
            this.label_Peso.AutoSize = true;
            this.label_Peso.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Peso.Location = new System.Drawing.Point(24, 220);
            this.label_Peso.Name = "label_Peso";
            this.label_Peso.Size = new System.Drawing.Size(101, 20);
            this.label_Peso.TabIndex = 8;
            this.label_Peso.Text = "PESO";
            // 
            // textBox_Peso
            // 
            this.textBox_Peso.BorderRadius = 6;
            this.textBox_Peso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Peso.DefaultText = "";
            this.textBox_Peso.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Peso.Location = new System.Drawing.Point(180, 214);
            this.textBox_Peso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Peso.MaxLength = 20;
            this.textBox_Peso.Name = "textBox_Peso";
            this.textBox_Peso.PlaceholderText = "0.00";
            this.textBox_Peso.SelectedText = "";
            this.textBox_Peso.Size = new System.Drawing.Size(150, 36);
            this.textBox_Peso.TabIndex = 9;
            // 
            // label_PorcentajeMin
            // 
            this.label_PorcentajeMin.AutoSize = true;
            this.label_PorcentajeMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_PorcentajeMin.Location = new System.Drawing.Point(360, 220);
            this.label_PorcentajeMin.Name = "label_PorcentajeMin";
            this.label_PorcentajeMin.Size = new System.Drawing.Size(79, 20);
            this.label_PorcentajeMin.TabIndex = 10;
            this.label_PorcentajeMin.Text = "% MINIMO";
            // 
            // textBox_PorcentajeMin
            // 
            this.textBox_PorcentajeMin.BorderRadius = 6;
            this.textBox_PorcentajeMin.DefaultText = "";
            this.textBox_PorcentajeMin.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_PorcentajeMin.Location = new System.Drawing.Point(460, 214);
            this.textBox_PorcentajeMin.MaxLength = 20;
            this.textBox_PorcentajeMin.Name = "textBox_PorcentajeMin";
            this.textBox_PorcentajeMin.PlaceholderText = "0.00";
            this.textBox_PorcentajeMin.SelectedText = "";
            this.textBox_PorcentajeMin.Size = new System.Drawing.Size(150, 36);
            this.textBox_PorcentajeMin.TabIndex = 11;
            // 
            // label_Porcentaje
            // 
            this.label_Porcentaje.AutoSize = true;
            this.label_Porcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label_Porcentaje.Location = new System.Drawing.Point(24, 266);
            this.label_Porcentaje.Name = "label_Porcentaje";
            this.label_Porcentaje.Size = new System.Drawing.Size(52, 20);
            this.label_Porcentaje.TabIndex = 12;
            this.label_Porcentaje.Text = "PORCENTAJE";
            // 
            // textBox_Porcentaje
            // 
            this.textBox_Porcentaje.BorderRadius = 6;
            this.textBox_Porcentaje.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Porcentaje.DefaultText = "";
            this.textBox_Porcentaje.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Porcentaje.Location = new System.Drawing.Point(180, 260);
            this.textBox_Porcentaje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Porcentaje.MaxLength = 20;
            this.textBox_Porcentaje.Name = "textBox_Porcentaje";
            this.textBox_Porcentaje.PlaceholderText = "0.00";
            this.textBox_Porcentaje.SelectedText = "";
            this.textBox_Porcentaje.Size = new System.Drawing.Size(150, 36);
            this.textBox_Porcentaje.TabIndex = 13;
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
            this.textBox_Obs.Location = new System.Drawing.Point(180, 306);
            this.textBox_Obs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Obs.Multiline = true;
            this.textBox_Obs.Name = "textBox_Obs";
            this.textBox_Obs.PlaceholderText = "";
            this.textBox_Obs.SelectedText = "";
            this.textBox_Obs.Size = new System.Drawing.Size(430, 46);
            this.textBox_Obs.TabIndex = 16;
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Location = new System.Drawing.Point(672, 20);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(18, 20);
            this.label_Id.TabIndex = 2;
            this.label_Id.Text = "0";
            this.label_Id.Visible = false;
            // 
            // frm_AgregarPesoPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(726, 430);
            this.Controls.Add(this.label_Id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_AgregarPesoPresentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PESO POR PRESENTACION";
            this.Load += new System.EventHandler(this.frm_AgregarPesoPresentacion_Load);
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
        private System.Windows.Forms.Label label_Cultivo;
        private System.Windows.Forms.Label label_Presentacion;
        private System.Windows.Forms.Label label_Peso;
        private System.Windows.Forms.Label label_PorcentajeMin;
        private System.Windows.Forms.Label label_Obs;
        private System.Windows.Forms.Label label_Porcentaje;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_empresa;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_sede;
        public Guna.UI2.WinForms.Guna2TextBox textBox_PorcentajeMin;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_Cultivo;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Presentacion;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Peso;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Obs;
        public Guna.UI2.WinForms.Guna2TextBox textBox_Porcentaje;
        public System.Windows.Forms.Label label_Id;
    }
}
