
namespace ERPASA.Frm_DestajoUva
{
    partial class Frm_ProrrateoCajasPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ProrrateoCajasPersona));
            this.label_estado_reg = new System.Windows.Forms.Label();
            this.dataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Cultivo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2TextBox_Buscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.Fecha_Inicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pictureBox_Excel = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Search = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_linea = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureBox_prorrateo_usuarios = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prorrateo_usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label_estado_reg
            // 
            this.label_estado_reg.AutoSize = true;
            this.label_estado_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_estado_reg.ForeColor = System.Drawing.Color.Crimson;
            this.label_estado_reg.Location = new System.Drawing.Point(568, 93);
            this.label_estado_reg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_estado_reg.Name = "label_estado_reg";
            this.label_estado_reg.Size = new System.Drawing.Size(53, 46);
            this.label_estado_reg.TabIndex = 313;
            this.label_estado_reg.Text = "...";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(9, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1185, 323);
            this.dataGridView1.TabIndex = 403;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.ThemeStyle.HeaderStyle.Height = 22;
            this.dataGridView1.ThemeStyle.ReadOnly = false;
            this.dataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView1.ThemeStyle.RowsStyle.Height = 28;
            this.dataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(342, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 405;
            this.label2.Text = "CULTIVO";
            // 
            // comboBox_Cultivo
            // 
            this.comboBox_Cultivo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_Cultivo.FormattingEnabled = true;
            this.comboBox_Cultivo.Location = new System.Drawing.Point(421, 56);
            this.comboBox_Cultivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_Cultivo.Name = "comboBox_Cultivo";
            this.comboBox_Cultivo.Size = new System.Drawing.Size(200, 32);
            this.comboBox_Cultivo.TabIndex = 404;
            this.comboBox_Cultivo.SelectedValueChanged += new System.EventHandler(this.comboBox_nave_SelectedValueChanged);
            // 
            // guna2TextBox_Buscar
            // 
            this.guna2TextBox_Buscar.BorderRadius = 2;
            this.guna2TextBox_Buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_Buscar.DefaultText = "";
            this.guna2TextBox_Buscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_Buscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_Buscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_Buscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_Buscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_Buscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2TextBox_Buscar.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_Buscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_Buscar.Location = new System.Drawing.Point(162, 99);
            this.guna2TextBox_Buscar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2TextBox_Buscar.Name = "guna2TextBox_Buscar";
            this.guna2TextBox_Buscar.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox_Buscar.PlaceholderText = "Search...";
            this.guna2TextBox_Buscar.SelectedText = "";
            this.guna2TextBox_Buscar.Size = new System.Drawing.Size(399, 38);
            this.guna2TextBox_Buscar.TabIndex = 408;
            this.guna2TextBox_Buscar.TextChanged += new System.EventHandler(this.guna2TextBox_LecturaSticker_TextChanged);
            this.guna2TextBox_Buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox_LecturaSticker_KeyPress);
            // 
            // Fecha_Inicio
            // 
            this.Fecha_Inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha_Inicio.Location = new System.Drawing.Point(178, 32);
            this.Fecha_Inicio.Name = "Fecha_Inicio";
            this.Fecha_Inicio.Size = new System.Drawing.Size(135, 30);
            this.Fecha_Inicio.TabIndex = 409;
            this.Fecha_Inicio.ValueChanged += new System.EventHandler(this.Fecha_Inicio_ValueChanged);
            // 
            // pictureBox_Excel
            // 
            this.pictureBox_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Excel.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Excel.Image")));
            this.pictureBox_Excel.Location = new System.Drawing.Point(739, 14);
            this.pictureBox_Excel.Name = "pictureBox_Excel";
            this.pictureBox_Excel.Size = new System.Drawing.Size(45, 48);
            this.pictureBox_Excel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Excel.TabIndex = 416;
            this.pictureBox_Excel.TabStop = false;
            this.pictureBox_Excel.Click += new System.EventHandler(this.pictureBox_agregarErrores_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 417;
            this.label1.Text = "FECHA PROCESO";
            // 
            // pictureBox_Search
            // 
            this.pictureBox_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Search.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Search.Image")));
            this.pictureBox_Search.Location = new System.Drawing.Point(670, 14);
            this.pictureBox_Search.Name = "pictureBox_Search";
            this.pictureBox_Search.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Search.TabIndex = 420;
            this.pictureBox_Search.TabStop = false;
            this.pictureBox_Search.Click += new System.EventHandler(this.pictureBox_Search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label3.Location = new System.Drawing.Point(364, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 422;
            this.label3.Text = "LINEA";
            // 
            // comboBox_linea
            // 
            this.comboBox_linea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox_linea.FormattingEnabled = true;
            this.comboBox_linea.Location = new System.Drawing.Point(421, 14);
            this.comboBox_linea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_linea.Name = "comboBox_linea";
            this.comboBox_linea.Size = new System.Drawing.Size(200, 32);
            this.comboBox_linea.TabIndex = 421;
            // 
            // pictureBox_prorrateo_usuarios
            // 
            this.pictureBox_prorrateo_usuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_prorrateo_usuarios.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_prorrateo_usuarios.Image")));
            this.pictureBox_prorrateo_usuarios.Location = new System.Drawing.Point(951, 42);
            this.pictureBox_prorrateo_usuarios.Name = "pictureBox_prorrateo_usuarios";
            this.pictureBox_prorrateo_usuarios.Size = new System.Drawing.Size(55, 58);
            this.pictureBox_prorrateo_usuarios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_prorrateo_usuarios.TabIndex = 423;
            this.pictureBox_prorrateo_usuarios.TabStop = false;
            this.pictureBox_prorrateo_usuarios.Click += new System.EventHandler(this.pictureBox_prorrateo_usuarios_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label4.Location = new System.Drawing.Point(935, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 424;
            this.label4.Text = "PRORRATEO";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(45, 108);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 29);
            this.checkBox1.TabIndex = 425;
            this.checkBox1.Text = "Todos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Frm_ProrrateoCajasPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 483);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox_prorrateo_usuarios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_linea);
            this.Controls.Add(this.pictureBox_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Excel);
            this.Controls.Add(this.Fecha_Inicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Cultivo);
            this.Controls.Add(this.guna2TextBox_Buscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_estado_reg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_ProrrateoCajasPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE PRORRATEO CAJAS - NISIRA - DESTAJO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_ProrrateoCajasPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prorrateo_usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_estado_reg;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_Cultivo;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_Buscar;
        private Guna.UI2.WinForms.Guna2DateTimePicker Fecha_Inicio;
        private System.Windows.Forms.PictureBox pictureBox_Excel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Search;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_linea;
        private System.Windows.Forms.PictureBox pictureBox_prorrateo_usuarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}