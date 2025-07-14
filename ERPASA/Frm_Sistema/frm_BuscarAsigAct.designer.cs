
namespace ERPASA.Frm_Sistema
{
    partial class frm_BuscarAsigAct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BuscarAsigAct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.pictureBox_titulo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_TiposAsig = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textbox_ActivoDesc = new System.Windows.Forms.TextBox();
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
            this.panel_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(1267, 86);
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
            this.label1.Location = new System.Drawing.Point(62, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 36);
            this.label1.TabIndex = 33;
            this.label1.Text = "Añadir Activo";
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
            this.button_cerrar.Location = new System.Drawing.Point(1221, 27);
            this.button_cerrar.Margin = new System.Windows.Forms.Padding(6);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(40, 38);
            this.button_cerrar.TabIndex = 29;
            this.button_cerrar.UseVisualStyleBackColor = false;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // pictureBox_titulo
            // 
            this.pictureBox_titulo.BackColor = System.Drawing.Color.White;
            this.pictureBox_titulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_titulo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_titulo.Image")));
            this.pictureBox_titulo.Location = new System.Drawing.Point(6, 32);
            this.pictureBox_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox_titulo.Name = "pictureBox_titulo";
            this.pictureBox_titulo.Size = new System.Drawing.Size(44, 42);
            this.pictureBox_titulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_titulo.TabIndex = 30;
            this.pictureBox_titulo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_TiposAsig);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.textbox_ActivoDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 710);
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
            this.label2.Location = new System.Drawing.Point(47, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 36);
            this.label2.TabIndex = 34;
            this.label2.Text = "Buscar Por:";
            // 
            // comboBox_TiposAsig
            // 
            this.comboBox_TiposAsig.FormattingEnabled = true;
            this.comboBox_TiposAsig.Items.AddRange(new object[] {
            "SELECCIONE",
            "ACTIVO",
            "MARCA",
            "MODELO",
            "SERIE",
            "IMEI",
            "MAC ETHERNET",
            "MAC WIFI"});
            this.comboBox_TiposAsig.Location = new System.Drawing.Point(227, 40);
            this.comboBox_TiposAsig.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_TiposAsig.Name = "comboBox_TiposAsig";
            this.comboBox_TiposAsig.Size = new System.Drawing.Size(274, 33);
            this.comboBox_TiposAsig.TabIndex = 177;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column6,
            this.Column7});
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridView2.Location = new System.Drawing.Point(12, 110);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1249, 550);
            this.dataGridView2.TabIndex = 126;
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentDoubleClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Item";
            this.Column8.MinimumWidth = 10;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 107;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Codigo";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 139;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Activo";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 128;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Marca";
            this.Column9.MinimumWidth = 10;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 130;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Modelo";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 103;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Serie";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 118;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "IMEI";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 109;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Mac Ethernet";
            this.Column10.MinimumWidth = 10;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 210;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Mac Wifi";
            this.Column11.MinimumWidth = 10;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 158;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Mac Equipo";
            this.Column12.MinimumWidth = 10;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 193;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Comentario";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 191;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Estado";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 137;
            // 
            // textbox_ActivoDesc
            // 
            this.textbox_ActivoDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_ActivoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_ActivoDesc.ForeColor = System.Drawing.Color.Black;
            this.textbox_ActivoDesc.Location = new System.Drawing.Point(532, 40);
            this.textbox_ActivoDesc.Margin = new System.Windows.Forms.Padding(6);
            this.textbox_ActivoDesc.Name = "textbox_ActivoDesc";
            this.textbox_ActivoDesc.Size = new System.Drawing.Size(578, 32);
            this.textbox_ActivoDesc.TabIndex = 1;
            this.textbox_ActivoDesc.Click += new System.EventHandler(this.textbox_productodesc_Click);
            this.textbox_ActivoDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_ActivoDesc_KeyPress);
            this.textbox_ActivoDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox_factura_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Location = new System.Drawing.Point(0, 771);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1267, 25);
            this.toolStrip1.TabIndex = 126;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frm_BuscarAsigAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1267, 796);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(30, 50);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "frm_BuscarAsigAct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_BuscarAsigAct_Load);
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
        private System.Windows.Forms.TextBox textbox_ActivoDesc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox_TiposAsig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}