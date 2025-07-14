
namespace ERPASA.Frm_Sistema
{
    partial class Frm_AgregarEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AgregarEquipo));
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.button_min_max = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_minimizar = new System.Windows.Forms.Button();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.pictureBox_titulo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.cboHojas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_nuevo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_guardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_guardar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_editar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_editar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_aliminar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_limpiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_limpiar = new System.Windows.Forms.ToolStripLabel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnRegistrarData = new System.Windows.Forms.Button();
            this.panel_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_titulo
            // 
            this.panel_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.panel_titulo.Controls.Add(this.button_min_max);
            this.panel_titulo.Controls.Add(this.label1);
            this.panel_titulo.Controls.Add(this.button_minimizar);
            this.panel_titulo.Controls.Add(this.button_cerrar);
            this.panel_titulo.Controls.Add(this.pictureBox_titulo);
            this.panel_titulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(1924, 96);
            this.panel_titulo.TabIndex = 3;
            this.panel_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_titulo_MouseDown);
            // 
            // button_min_max
            // 
            this.button_min_max.Location = new System.Drawing.Point(0, 0);
            this.button_min_max.Name = "button_min_max";
            this.button_min_max.Size = new System.Drawing.Size(75, 23);
            this.button_min_max.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "Registrar datos en Excel";
            // 
            // button_minimizar
            // 
            this.button_minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_minimizar.BackColor = System.Drawing.Color.White;
            this.button_minimizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_minimizar.BackgroundImage")));
            this.button_minimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_minimizar.FlatAppearance.BorderSize = 0;
            this.button_minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_minimizar.Location = new System.Drawing.Point(1772, 46);
            this.button_minimizar.Margin = new System.Windows.Forms.Padding(6);
            this.button_minimizar.Name = "button_minimizar";
            this.button_minimizar.Size = new System.Drawing.Size(40, 38);
            this.button_minimizar.TabIndex = 1;
            this.button_minimizar.UseVisualStyleBackColor = false;
            this.button_minimizar.Click += new System.EventHandler(this.button_minimizar_Click);
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
            this.button_cerrar.Location = new System.Drawing.Point(1876, 46);
            this.button_cerrar.Margin = new System.Windows.Forms.Padding(6);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(40, 38);
            this.button_cerrar.TabIndex = 3;
            this.button_cerrar.UseVisualStyleBackColor = false;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // pictureBox_titulo
            // 
            this.pictureBox_titulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_titulo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_titulo.Image")));
            this.pictureBox_titulo.Location = new System.Drawing.Point(14, 44);
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
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 96);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 858);
            this.panel1.TabIndex = 104;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegistrarData);
            this.groupBox1.Controls.Add(this.btnMostrar);
            this.groupBox1.Controls.Add(this.cboHojas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtRuta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(31, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1662, 183);
            this.groupBox1.TabIndex = 190;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS PRINCIPALES";
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnMostrar.ForeColor = System.Drawing.Color.White;
            this.btnMostrar.Location = new System.Drawing.Point(862, 106);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(6);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(150, 44);
            this.btnMostrar.TabIndex = 8;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // cboHojas
            // 
            this.cboHojas.FormattingEnabled = true;
            this.cboHojas.Location = new System.Drawing.Point(414, 110);
            this.cboHojas.Margin = new System.Windows.Forms.Padding(6);
            this.cboHojas.Name = "cboHojas";
            this.cboHojas.Size = new System.Drawing.Size(432, 33);
            this.cboHojas.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.875F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.label3.Location = new System.Drawing.Point(174, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hoja Encontradas:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(862, 30);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 44);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(416, 33);
            this.txtRuta.Margin = new System.Windows.Forms.Padding(6);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(430, 31);
            this.txtRuta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(312, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ruta:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_nuevo,
            this.toolStripLabel_nuevo,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton_guardar,
            this.toolStripLabel_guardar,
            this.toolStripSeparator3,
            this.toolStripSeparator9,
            this.toolStripButton_editar,
            this.toolStripLabel_editar,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.toolStripButton_eliminar,
            this.toolStripLabel_aliminar,
            this.toolStripSeparator5,
            this.toolStripSeparator8,
            this.toolStripButton_limpiar,
            this.toolStripLabel_limpiar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1924, 51);
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
            this.toolStripButton_nuevo.Size = new System.Drawing.Size(46, 45);
            this.toolStripButton_nuevo.ToolTipText = "Nuevo";
            this.toolStripButton_nuevo.Click += new System.EventHandler(this.toolStripButton_nuevo_Click);
            // 
            // toolStripLabel_nuevo
            // 
            this.toolStripLabel_nuevo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_nuevo.Name = "toolStripLabel_nuevo";
            this.toolStripLabel_nuevo.Size = new System.Drawing.Size(105, 45);
            this.toolStripLabel_nuevo.Text = "Nuevo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripButton_guardar
            // 
            this.toolStripButton_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_guardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_guardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_guardar.Image")));
            this.toolStripButton_guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_guardar.Name = "toolStripButton_guardar";
            this.toolStripButton_guardar.Size = new System.Drawing.Size(46, 45);
            this.toolStripButton_guardar.ToolTipText = "Guardar";
            this.toolStripButton_guardar.Click += new System.EventHandler(this.toolStripButton_guardar_Click);
            // 
            // toolStripLabel_guardar
            // 
            this.toolStripLabel_guardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_guardar.Name = "toolStripLabel_guardar";
            this.toolStripLabel_guardar.Size = new System.Drawing.Size(133, 45);
            this.toolStripLabel_guardar.Text = "Guardar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripButton_editar
            // 
            this.toolStripButton_editar.Name = "toolStripButton_editar";
            this.toolStripButton_editar.Size = new System.Drawing.Size(46, 45);
            // 
            // toolStripLabel_editar
            // 
            this.toolStripLabel_editar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_editar.Name = "toolStripLabel_editar";
            this.toolStripLabel_editar.Size = new System.Drawing.Size(93, 45);
            this.toolStripLabel_editar.Text = "Editar";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripButton_eliminar
            // 
            this.toolStripButton_eliminar.Name = "toolStripButton_eliminar";
            this.toolStripButton_eliminar.Size = new System.Drawing.Size(46, 45);
            // 
            // toolStripLabel_aliminar
            // 
            this.toolStripLabel_aliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_aliminar.Name = "toolStripLabel_aliminar";
            this.toolStripLabel_aliminar.Size = new System.Drawing.Size(133, 45);
            this.toolStripLabel_aliminar.Text = "Eliminar";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripButton_limpiar
            // 
            this.toolStripButton_limpiar.Name = "toolStripButton_limpiar";
            this.toolStripButton_limpiar.Size = new System.Drawing.Size(46, 45);
            // 
            // toolStripLabel_limpiar
            // 
            this.toolStripLabel_limpiar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_limpiar.Name = "toolStripLabel_limpiar";
            this.toolStripLabel_limpiar.Size = new System.Drawing.Size(115, 45);
            this.toolStripLabel_limpiar.Text = "Limpiar";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(31, 270);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(6);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 82;
            this.dgvDatos.Size = new System.Drawing.Size(1817, 533);
            this.dgvDatos.TabIndex = 191;
            // 
            // btnRegistrarData
            // 
            this.btnRegistrarData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnRegistrarData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarData.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarData.Location = new System.Drawing.Point(1341, 63);
            this.btnRegistrarData.Margin = new System.Windows.Forms.Padding(6);
            this.btnRegistrarData.Name = "btnRegistrarData";
            this.btnRegistrarData.Size = new System.Drawing.Size(201, 44);
            this.btnRegistrarData.TabIndex = 9;
            this.btnRegistrarData.Text = "Registrar Data";
            this.btnRegistrarData.UseVisualStyleBackColor = false;
            this.btnRegistrarData.Click += new System.EventHandler(this.btnRegistrarData_Click);
            // 
            // Frm_AgregarEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 954);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(10, 10);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Frm_AgregarEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_AgregarEquipo_Load);
            this.panel_titulo.ResumeLayout(false);
            this.panel_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_minimizar;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.PictureBox pictureBox_titulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_nuevo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButton_editar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_editar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton_limpiar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_limpiar;
        private System.Windows.Forms.ToolStripButton toolStripButton_guardar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton_eliminar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_aliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_min_max;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.ComboBox cboHojas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnRegistrarData;
    }
}