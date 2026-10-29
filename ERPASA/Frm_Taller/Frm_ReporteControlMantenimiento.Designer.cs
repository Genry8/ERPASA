namespace ERPASA.Frm_Taller
{
    partial class Frm_ReporteControlMantenimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_buscar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2TextBoxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaIni = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.comboBox_detalle_sede = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBox_detalle_empresa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            //
            // toolStrip2
            //
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_buscar,
            this.toolStripLabel_buscar,
            this.toolStripSeparator7,
            this.toolStripButton_excel,
            this.toolStripLabel3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1277, 41);
            this.toolStrip2.TabIndex = 264;
            this.toolStrip2.Text = "toolStrip2";
            //
            // toolStripButton_buscar
            //
            this.toolStripButton_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_buscar.Name = "toolStripButton_buscar";
            this.toolStripButton_buscar.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_buscar.ToolTipText = "Buscar";
            this.toolStripButton_buscar.Click += new System.EventHandler(this.toolStripButton_buscar_Click);
            //
            // toolStripLabel_buscar
            //
            this.toolStripLabel_buscar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripLabel_buscar.Name = "toolStripLabel_buscar";
            this.toolStripLabel_buscar.Size = new System.Drawing.Size(81, 36);
            this.toolStripLabel_buscar.Text = "Buscar";
            //
            // toolStripSeparator7
            //
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
            //
            // toolStripButton_excel
            //
            this.toolStripButton_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_excel.Name = "toolStripButton_excel";
            this.toolStripButton_excel.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_excel.ToolTipText = "Excel";
            this.toolStripButton_excel.Click += new System.EventHandler(this.toolStripButton_excel_Click);
            //
            // toolStripLabel3
            //
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(100, 36);
            this.toolStripLabel3.Text = "Exportar";
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.guna2TextBoxSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker_FechaFin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimePicker_FechaIni);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.comboBox_detalle_sede);
            this.groupBox1.Controls.Add(this.comboBox_detalle_empresa);
            this.groupBox1.Location = new System.Drawing.Point(10, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(969, 167);
            this.groupBox1.TabIndex = 314;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos principales";
            //
            // guna2TextBoxSearch
            //
            this.guna2TextBoxSearch.BorderRadius = 2;
            this.guna2TextBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxSearch.DefaultText = "";
            this.guna2TextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxSearch.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBoxSearch.Location = new System.Drawing.Point(133, 119);
            this.guna2TextBoxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBoxSearch.Name = "guna2TextBoxSearch";
            this.guna2TextBoxSearch.PlaceholderText = "Search";
            this.guna2TextBoxSearch.SelectedText = "";
            this.guna2TextBoxSearch.Size = new System.Drawing.Size(629, 34);
            this.guna2TextBoxSearch.TabIndex = 383;
            this.guna2TextBoxSearch.TextChanged += new System.EventHandler(this.guna2TextBoxSearch_TextChanged);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(362, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 365;
            this.label2.Text = "FECHA FIN";
            //
            // dateTimePicker_FechaFin
            //
            this.dateTimePicker_FechaFin.Checked = false;
            this.dateTimePicker_FechaFin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_FechaFin.Location = new System.Drawing.Point(464, 31);
            this.dateTimePicker_FechaFin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_FechaFin.Name = "dateTimePicker_FechaFin";
            this.dateTimePicker_FechaFin.Size = new System.Drawing.Size(154, 31);
            this.dateTimePicker_FechaFin.TabIndex = 364;
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label8.Location = new System.Drawing.Point(30, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 363;
            this.label8.Text = "FECHA INI";
            //
            // dateTimePicker_FechaIni
            //
            this.dateTimePicker_FechaIni.Checked = false;
            this.dateTimePicker_FechaIni.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker_FechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_FechaIni.Location = new System.Drawing.Point(133, 31);
            this.dateTimePicker_FechaIni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_FechaIni.Name = "dateTimePicker_FechaIni";
            this.dateTimePicker_FechaIni.Size = new System.Drawing.Size(154, 31);
            this.dateTimePicker_FechaIni.TabIndex = 362;
            //
            // label46
            //
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label46.Location = new System.Drawing.Point(475, 78);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(54, 20);
            this.label46.TabIndex = 355;
            this.label46.Text = "SEDE";
            //
            // label45
            //
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label45.Location = new System.Drawing.Point(31, 78);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(88, 20);
            this.label45.TabIndex = 354;
            this.label45.Text = "EMPRESA";
            //
            // comboBox_detalle_sede
            //
            this.comboBox_detalle_sede.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_detalle_sede.FormattingEnabled = true;
            this.comboBox_detalle_sede.Location = new System.Drawing.Point(537, 72);
            this.comboBox_detalle_sede.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_detalle_sede.Name = "comboBox_detalle_sede";
            this.comboBox_detalle_sede.Size = new System.Drawing.Size(225, 32);
            this.comboBox_detalle_sede.TabIndex = 353;
            //
            // comboBox_detalle_empresa
            //
            this.comboBox_detalle_empresa.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_detalle_empresa.FormattingEnabled = true;
            this.comboBox_detalle_empresa.Location = new System.Drawing.Point(133, 72);
            this.comboBox_detalle_empresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_detalle_empresa.Name = "comboBox_detalle_empresa";
            this.comboBox_detalle_empresa.Size = new System.Drawing.Size(305, 32);
            this.comboBox_detalle_empresa.TabIndex = 352;
            this.comboBox_detalle_empresa.SelectedIndexChanged += new System.EventHandler(this.comboBox_detalle_empresa_SelectedIndexChanged);
            //
            // dataGridView2
            //
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeight = 22;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView2.Location = new System.Drawing.Point(10, 234);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1255, 284);
            this.dataGridView2.TabIndex = 384;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView2_Scroll);
            this.dataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView2.ThemeStyle.HeaderStyle.Height = 22;
            this.dataGridView2.ThemeStyle.ReadOnly = true;
            this.dataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView2.ThemeStyle.RowsStyle.Height = 28;
            this.dataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            //
            // Frm_ReporteControlMantenimiento
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 523);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_ReporteControlMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE CONTROL DE MANTENIMIENTO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_ReporteControlMantenimiento_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_buscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton_excel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxSearch;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker_FechaFin;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker_FechaIni;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_detalle_sede;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_detalle_empresa;
        public Guna.UI2.WinForms.Guna2DataGridView dataGridView2;
    }
}
