
namespace ERPASA.Frm_Sistema
{
    partial class Frm_RegAsignacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegAsignacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.gn2FechaFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gn2FechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2TextBoxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_nuevo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_buscar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_editar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_imprimir = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_Excel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_limpiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_limpiar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_inventario = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_inventario = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_PrintQR = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_PrintQR = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gn2FechaFin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gn2FechaInicio);
            this.panel1.Controls.Add(this.guna2TextBoxSearch);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1460, 441);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(320, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 186;
            this.label2.Text = "FEC. FIN:";
            // 
            // gn2FechaFin
            // 
            this.gn2FechaFin.BorderRadius = 2;
            this.gn2FechaFin.Checked = true;
            this.gn2FechaFin.FillColor = System.Drawing.Color.Teal;
            this.gn2FechaFin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gn2FechaFin.ForeColor = System.Drawing.SystemColors.Control;
            this.gn2FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.gn2FechaFin.Location = new System.Drawing.Point(407, 65);
            this.gn2FechaFin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.gn2FechaFin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.gn2FechaFin.Name = "gn2FechaFin";
            this.gn2FechaFin.Size = new System.Drawing.Size(188, 36);
            this.gn2FechaFin.TabIndex = 185;
            this.gn2FechaFin.Value = new System.DateTime(2025, 7, 21, 23, 20, 37, 38);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 184;
            this.label1.Text = "FEC. INI:";
            // 
            // gn2FechaInicio
            // 
            this.gn2FechaInicio.BorderRadius = 2;
            this.gn2FechaInicio.Checked = true;
            this.gn2FechaInicio.FillColor = System.Drawing.Color.Teal;
            this.gn2FechaInicio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gn2FechaInicio.ForeColor = System.Drawing.SystemColors.Control;
            this.gn2FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.gn2FechaInicio.Location = new System.Drawing.Point(97, 65);
            this.gn2FechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.gn2FechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.gn2FechaInicio.Name = "gn2FechaInicio";
            this.gn2FechaInicio.Size = new System.Drawing.Size(188, 36);
            this.gn2FechaInicio.TabIndex = 183;
            this.gn2FechaInicio.Value = new System.DateTime(2025, 7, 21, 23, 20, 37, 38);
            // 
            // guna2TextBoxSearch
            // 
            this.guna2TextBoxSearch.BorderRadius = 2;
            this.guna2TextBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxSearch.DefaultText = "";
            this.guna2TextBoxSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxSearch.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBoxSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxSearch.Location = new System.Drawing.Point(640, 68);
            this.guna2TextBoxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBoxSearch.Name = "guna2TextBoxSearch";
            this.guna2TextBoxSearch.PlaceholderText = "Search";
            this.guna2TextBoxSearch.SelectedText = "";
            this.guna2TextBoxSearch.Size = new System.Drawing.Size(621, 34);
            this.guna2TextBoxSearch.TabIndex = 182;
            this.guna2TextBoxSearch.TextChanged += new System.EventHandler(this.guna2TextBoxSearch_TextChanged);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeight = 22;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView2.Location = new System.Drawing.Point(3, 109);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1445, 329);
            this.dataGridView2.TabIndex = 181;
            this.dataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView2.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView2.ThemeStyle.HeaderStyle.Height = 22;
            this.dataGridView2.ThemeStyle.ReadOnly = false;
            this.dataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView2.ThemeStyle.RowsStyle.Height = 28;
            this.dataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.guna2DataGridView1_CellFormatting);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 481;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 482;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 481;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_nuevo,
            this.toolStripLabel_nuevo,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton_buscar,
            this.toolStripLabel_buscar,
            this.toolStripSeparator3,
            this.toolStripSeparator9,
            this.toolStripButton_eliminar,
            this.toolStripLabel_editar,
            this.toolStripSeparator10,
            this.toolStripSeparator4,
            this.toolStripButton_imprimir,
            this.toolStripLabel_imprimir,
            this.toolStripSeparator5,
            this.toolStripSeparator6,
            this.toolStripButton_excel,
            this.toolStripLabel_Excel,
            this.toolStripSeparator7,
            this.toolStripSeparator8,
            this.toolStripButton_limpiar,
            this.toolStripLabel_limpiar,
            this.toolStripSeparator11,
            this.toolStripButton_inventario,
            this.toolStripLabel_inventario,
            this.toolStripSeparator14,
            this.toolStripButton_PrintQR,
            this.toolStripLabel_PrintQR});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1460, 41);
            this.toolStrip1.TabIndex = 146;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_nuevo
            // 
            this.toolStripButton_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_nuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_nuevo.Image")));
            this.toolStripButton_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_nuevo.Name = "toolStripButton_nuevo";
            this.toolStripButton_nuevo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_nuevo.ToolTipText = "Agregar";
            this.toolStripButton_nuevo.Click += new System.EventHandler(this.toolStripButton_nuevo_Click);
            // 
            // toolStripLabel_nuevo
            // 
            this.toolStripLabel_nuevo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_nuevo.Name = "toolStripLabel_nuevo";
            this.toolStripLabel_nuevo.Size = new System.Drawing.Size(97, 36);
            this.toolStripLabel_nuevo.Text = "Agregar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_buscar
            // 
            this.toolStripButton_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_buscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_buscar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_buscar.Image")));
            this.toolStripButton_buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_buscar.Name = "toolStripButton_buscar";
            this.toolStripButton_buscar.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_buscar.ToolTipText = "Buscar";
            this.toolStripButton_buscar.Click += new System.EventHandler(this.toolStripButton_buscar_Click);
            // 
            // toolStripLabel_buscar
            // 
            this.toolStripLabel_buscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_buscar.Name = "toolStripLabel_buscar";
            this.toolStripLabel_buscar.Size = new System.Drawing.Size(81, 36);
            this.toolStripLabel_buscar.Text = "Buscar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_eliminar
            // 
            this.toolStripButton_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_eliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_eliminar.Image")));
            this.toolStripButton_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_eliminar.Name = "toolStripButton_eliminar";
            this.toolStripButton_eliminar.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_eliminar.ToolTipText = "Eliminar";
            this.toolStripButton_eliminar.Click += new System.EventHandler(this.toolStripButton_eliminar_Click);
            // 
            // toolStripLabel_editar
            // 
            this.toolStripLabel_editar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_editar.Name = "toolStripLabel_editar";
            this.toolStripLabel_editar.Size = new System.Drawing.Size(97, 36);
            this.toolStripLabel_editar.Text = "Eliminar";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_imprimir
            // 
            this.toolStripButton_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_imprimir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_imprimir.Image")));
            this.toolStripButton_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_imprimir.Name = "toolStripButton_imprimir";
            this.toolStripButton_imprimir.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_imprimir.ToolTipText = "Imprimir";
            this.toolStripButton_imprimir.Click += new System.EventHandler(this.toolStripButton_imprimir_Click);
            // 
            // toolStripLabel_imprimir
            // 
            this.toolStripLabel_imprimir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_imprimir.Name = "toolStripLabel_imprimir";
            this.toolStripLabel_imprimir.Size = new System.Drawing.Size(102, 36);
            this.toolStripLabel_imprimir.Text = "Imprimir";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_excel
            // 
            this.toolStripButton_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_excel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_excel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_excel.Image")));
            this.toolStripButton_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_excel.Name = "toolStripButton_excel";
            this.toolStripButton_excel.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_excel.ToolTipText = "Excel";
            this.toolStripButton_excel.Click += new System.EventHandler(this.toolStripButton_excel_Click);
            // 
            // toolStripLabel_Excel
            // 
            this.toolStripLabel_Excel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_Excel.Name = "toolStripLabel_Excel";
            this.toolStripLabel_Excel.Size = new System.Drawing.Size(66, 36);
            this.toolStripLabel_Excel.Text = "Excel";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_limpiar
            // 
            this.toolStripButton_limpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_limpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_limpiar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_limpiar.Image")));
            this.toolStripButton_limpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_limpiar.Name = "toolStripButton_limpiar";
            this.toolStripButton_limpiar.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_limpiar.ToolTipText = "Limpiar";
            this.toolStripButton_limpiar.Click += new System.EventHandler(this.toolStripButton_limpiar_Click);
            // 
            // toolStripLabel_limpiar
            // 
            this.toolStripLabel_limpiar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_limpiar.Name = "toolStripLabel_limpiar";
            this.toolStripLabel_limpiar.Size = new System.Drawing.Size(91, 36);
            this.toolStripLabel_limpiar.Text = "Limpiar";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_inventario
            // 
            this.toolStripButton_inventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_inventario.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_inventario.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_inventario.Image")));
            this.toolStripButton_inventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_inventario.Name = "toolStripButton_inventario";
            this.toolStripButton_inventario.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_inventario.ToolTipText = "Limpiar";
            this.toolStripButton_inventario.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel_inventario
            // 
            this.toolStripLabel_inventario.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripLabel_inventario.Name = "toolStripLabel_inventario";
            this.toolStripLabel_inventario.Size = new System.Drawing.Size(116, 36);
            this.toolStripLabel_inventario.Text = "Inventario";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 41);
            this.toolStripSeparator14.Click += new System.EventHandler(this.toolStripSeparator14_Click);
            // 
            // toolStripButton_PrintQR
            // 
            this.toolStripButton_PrintQR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PrintQR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_PrintQR.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PrintQR.Image")));
            this.toolStripButton_PrintQR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PrintQR.Name = "toolStripButton_PrintQR";
            this.toolStripButton_PrintQR.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_PrintQR.ToolTipText = "Imprimir";
            this.toolStripButton_PrintQR.Click += new System.EventHandler(this.toolStripButton_PrintQR_Click);
            // 
            // toolStripLabel_PrintQR
            // 
            this.toolStripLabel_PrintQR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_PrintQR.Name = "toolStripLabel_PrintQR";
            this.toolStripLabel_PrintQR.Size = new System.Drawing.Size(118, 36);
            this.toolStripLabel_PrintQR.Text = "Print Serie";
            // 
            // Frm_RegAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1460, 441);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_RegAsignacion";
            this.Text = "REGISTRAR ASIGNACION";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_RegAsignacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_nuevo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_buscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButton_eliminar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_editar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_imprimir;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton_limpiar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_limpiar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton_excel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Excel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton toolStripButton_inventario;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_inventario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton toolStripButton_PrintQR;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_PrintQR;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxSearch;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker gn2FechaFin;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker gn2FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}