
namespace ERPASA.Frm_DestajoUva
{
    partial class Frm_RegistrarLecturaDestajo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegistrarLecturaDestajo));
            this.label_estado_reg = new System.Windows.Forms.Label();
            this.dataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_linea = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_nave = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2TextBox_LecturaSticker = new Guna.UI2.WinForms.Guna2TextBox();
            this.Fecha_Proceso = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pictureBox_agregarErrores = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_totalCajas = new System.Windows.Forms.Label();
            this.label_CajasErradas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_total_sticker = new System.Windows.Forms.Label();
            this.label_sticker_incorrectos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_agregarErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // label_estado_reg
            // 
            this.label_estado_reg.AutoSize = true;
            this.label_estado_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_estado_reg.ForeColor = System.Drawing.Color.Crimson;
            this.label_estado_reg.Location = new System.Drawing.Point(875, 57);
            this.label_estado_reg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_estado_reg.Name = "label_estado_reg";
            this.label_estado_reg.Size = new System.Drawing.Size(53, 46);
            this.label_estado_reg.TabIndex = 313;
            this.label_estado_reg.Text = "...";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(9, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1897, 356);
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
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label3.Location = new System.Drawing.Point(589, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 407;
            this.label3.Text = "LINEA";
            // 
            // comboBox_linea
            // 
            this.comboBox_linea.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_linea.FormattingEnabled = true;
            this.comboBox_linea.Location = new System.Drawing.Point(666, 11);
            this.comboBox_linea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_linea.Name = "comboBox_linea";
            this.comboBox_linea.Size = new System.Drawing.Size(179, 37);
            this.comboBox_linea.TabIndex = 406;
            this.comboBox_linea.SelectedValueChanged += new System.EventHandler(this.comboBox_linea_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(245, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 405;
            this.label2.Text = "NAVE";
            // 
            // comboBox_nave
            // 
            this.comboBox_nave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_nave.FormattingEnabled = true;
            this.comboBox_nave.Location = new System.Drawing.Point(320, 11);
            this.comboBox_nave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_nave.Name = "comboBox_nave";
            this.comboBox_nave.Size = new System.Drawing.Size(200, 37);
            this.comboBox_nave.TabIndex = 404;
            this.comboBox_nave.SelectedValueChanged += new System.EventHandler(this.comboBox_nave_SelectedValueChanged);
            // 
            // guna2TextBox_LecturaSticker
            // 
            this.guna2TextBox_LecturaSticker.BorderRadius = 2;
            this.guna2TextBox_LecturaSticker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_LecturaSticker.DefaultText = "";
            this.guna2TextBox_LecturaSticker.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_LecturaSticker.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_LecturaSticker.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_LecturaSticker.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_LecturaSticker.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_LecturaSticker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2TextBox_LecturaSticker.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_LecturaSticker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_LecturaSticker.Location = new System.Drawing.Point(23, 59);
            this.guna2TextBox_LecturaSticker.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2TextBox_LecturaSticker.Name = "guna2TextBox_LecturaSticker";
            this.guna2TextBox_LecturaSticker.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox_LecturaSticker.PlaceholderText = "LECTURA STICKER";
            this.guna2TextBox_LecturaSticker.SelectedText = "";
            this.guna2TextBox_LecturaSticker.Size = new System.Drawing.Size(822, 38);
            this.guna2TextBox_LecturaSticker.TabIndex = 408;
            this.guna2TextBox_LecturaSticker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox_LecturaSticker_KeyPress);
            // 
            // Fecha_Proceso
            // 
            this.Fecha_Proceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha_Proceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha_Proceso.Location = new System.Drawing.Point(23, 12);
            this.Fecha_Proceso.Name = "Fecha_Proceso";
            this.Fecha_Proceso.Size = new System.Drawing.Size(135, 30);
            this.Fecha_Proceso.TabIndex = 409;
            this.Fecha_Proceso.ValueChanged += new System.EventHandler(this.Fecha_Proceso_ValueChanged);
            // 
            // pictureBox_agregarErrores
            // 
            this.pictureBox_agregarErrores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_agregarErrores.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_agregarErrores.Image")));
            this.pictureBox_agregarErrores.Location = new System.Drawing.Point(1167, 5);
            this.pictureBox_agregarErrores.Name = "pictureBox_agregarErrores";
            this.pictureBox_agregarErrores.Size = new System.Drawing.Size(37, 36);
            this.pictureBox_agregarErrores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_agregarErrores.TabIndex = 416;
            this.pictureBox_agregarErrores.TabStop = false;
            this.pictureBox_agregarErrores.Click += new System.EventHandler(this.pictureBox_agregarErrores_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 32);
            this.label1.TabIndex = 417;
            this.label1.Text = "TOTAL CAJAS:";
            // 
            // label_totalCajas
            // 
            this.label_totalCajas.AutoSize = true;
            this.label_totalCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalCajas.ForeColor = System.Drawing.Color.Green;
            this.label_totalCajas.Location = new System.Drawing.Point(225, 103);
            this.label_totalCajas.Name = "label_totalCajas";
            this.label_totalCajas.Size = new System.Drawing.Size(47, 52);
            this.label_totalCajas.TabIndex = 418;
            this.label_totalCajas.Text = "0";
            // 
            // label_CajasErradas
            // 
            this.label_CajasErradas.AutoSize = true;
            this.label_CajasErradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CajasErradas.ForeColor = System.Drawing.Color.Firebrick;
            this.label_CajasErradas.Location = new System.Drawing.Point(698, 103);
            this.label_CajasErradas.Name = "label_CajasErradas";
            this.label_CajasErradas.Size = new System.Drawing.Size(47, 52);
            this.label_CajasErradas.TabIndex = 420;
            this.label_CajasErradas.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 32);
            this.label5.TabIndex = 419;
            this.label5.Text = "CAJAS ERRADAS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(922, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 32);
            this.label4.TabIndex = 421;
            this.label4.Text = "TOTAL STICKERS:";
            // 
            // label_total_sticker
            // 
            this.label_total_sticker.AutoSize = true;
            this.label_total_sticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_total_sticker.ForeColor = System.Drawing.Color.Green;
            this.label_total_sticker.Location = new System.Drawing.Point(1188, 102);
            this.label_total_sticker.Name = "label_total_sticker";
            this.label_total_sticker.Size = new System.Drawing.Size(47, 52);
            this.label_total_sticker.TabIndex = 422;
            this.label_total_sticker.Text = "0";
            // 
            // label_sticker_incorrectos
            // 
            this.label_sticker_incorrectos.AutoSize = true;
            this.label_sticker_incorrectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sticker_incorrectos.ForeColor = System.Drawing.Color.Firebrick;
            this.label_sticker_incorrectos.Location = new System.Drawing.Point(1766, 98);
            this.label_sticker_incorrectos.Name = "label_sticker_incorrectos";
            this.label_sticker_incorrectos.Size = new System.Drawing.Size(47, 52);
            this.label_sticker_incorrectos.TabIndex = 424;
            this.label_sticker_incorrectos.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1460, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 32);
            this.label7.TabIndex = 423;
            this.label7.Text = "STICKERS ERRADOS";
            // 
            // Frm_RegistrarLecturaDestajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1918, 533);
            this.Controls.Add(this.label_sticker_incorrectos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_total_sticker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_CajasErradas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_totalCajas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_agregarErrores);
            this.Controls.Add(this.Fecha_Proceso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_linea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_nave);
            this.Controls.Add(this.guna2TextBox_LecturaSticker);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_estado_reg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_RegistrarLecturaDestajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LECTURA DESTAJO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_RegistrarLecturaDestajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_agregarErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_estado_reg;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_linea;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_nave;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_LecturaSticker;
        private Guna.UI2.WinForms.Guna2DateTimePicker Fecha_Proceso;
        private System.Windows.Forms.PictureBox pictureBox_agregarErrores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_totalCajas;
        private System.Windows.Forms.Label label_CajasErradas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_total_sticker;
        private System.Windows.Forms.Label label_sticker_incorrectos;
        private System.Windows.Forms.Label label7;
    }
}