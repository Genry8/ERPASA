
namespace ERPASA.Frm_SST
{
    partial class frm_BuscarMedicamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BuscarMedicamento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.pictureBox_titulo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Tipos = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textbox_DescMedicamento = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_titulo
            // 
            this.panel_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.panel_titulo.Controls.Add(this.label1);
            this.panel_titulo.Controls.Add(this.button_cerrar);
            this.panel_titulo.Controls.Add(this.pictureBox_titulo);
            this.panel_titulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_titulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(950, 69);
            this.panel_titulo.TabIndex = 2;
            this.panel_titulo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel_titulo_MouseDoubleClick);
            this.panel_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_titulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 28);
            this.label1.TabIndex = 33;
            this.label1.Text = "Buscar Medicamento";
            // 
            // button_cerrar
            // 
            this.button_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cerrar.BackColor = System.Drawing.Color.White;
            this.button_cerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cerrar.BackgroundImage")));
            this.button_cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cerrar.FlatAppearance.BorderSize = 0;
            this.button_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_cerrar.Location = new System.Drawing.Point(916, 26);
            this.button_cerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(30, 30);
            this.button_cerrar.TabIndex = 29;
            this.button_cerrar.UseVisualStyleBackColor = false;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // pictureBox_titulo
            // 
            this.pictureBox_titulo.BackColor = System.Drawing.Color.White;
            this.pictureBox_titulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_titulo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_titulo.Image")));
            this.pictureBox_titulo.Location = new System.Drawing.Point(4, 26);
            this.pictureBox_titulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_titulo.Name = "pictureBox_titulo";
            this.pictureBox_titulo.Size = new System.Drawing.Size(33, 34);
            this.pictureBox_titulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_titulo.TabIndex = 30;
            this.pictureBox_titulo.TabStop = false;
            this.pictureBox_titulo.Click += new System.EventHandler(this.pictureBox_titulo_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_Tipos);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.textbox_DescMedicamento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 568);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(35, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 28);
            this.label2.TabIndex = 34;
            this.label2.Text = "Buscar Por:";
            // 
            // comboBox_Tipos
            // 
            this.comboBox_Tipos.FormattingEnabled = true;
            this.comboBox_Tipos.Items.AddRange(new object[] {
            "DESCRIPCION",
            "CODIGO"});
            this.comboBox_Tipos.Location = new System.Drawing.Point(170, 32);
            this.comboBox_Tipos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_Tipos.Name = "comboBox_Tipos";
            this.comboBox_Tipos.Size = new System.Drawing.Size(206, 28);
            this.comboBox_Tipos.TabIndex = 177;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column6,
            this.Column7,
            this.Column3});
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridView2.Location = new System.Drawing.Point(9, 88);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(911, 385);
            this.dataGridView2.TabIndex = 126;
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentDoubleClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Codigo";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 111;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripcion";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "UnidMed";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 127;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Precio";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 103;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha_med";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 152;
            // 
            // textbox_DescMedicamento
            // 
            this.textbox_DescMedicamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_DescMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_DescMedicamento.ForeColor = System.Drawing.Color.Black;
            this.textbox_DescMedicamento.Location = new System.Drawing.Point(399, 32);
            this.textbox_DescMedicamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textbox_DescMedicamento.Name = "textbox_DescMedicamento";
            this.textbox_DescMedicamento.Size = new System.Drawing.Size(434, 26);
            this.textbox_DescMedicamento.TabIndex = 1;
            this.textbox_DescMedicamento.Click += new System.EventHandler(this.textbox_productodesc_Click);
            this.textbox_DescMedicamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_ActivoDesc_KeyPress);
            this.textbox_DescMedicamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox_factura_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Location = new System.Drawing.Point(0, 612);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(950, 25);
            this.toolStrip1.TabIndex = 126;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frm_BuscarMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(950, 637);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(30, 50);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frm_BuscarMedicamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_BuscarMedicamento_Load);
            this.Resize += new System.EventHandler(this.Frm_agregar_Resize);
            this.panel_titulo.ResumeLayout(false);
            this.panel_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.PictureBox pictureBox_titulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textbox_DescMedicamento;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox_Tipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}