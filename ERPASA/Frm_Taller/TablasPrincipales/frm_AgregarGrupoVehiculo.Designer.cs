namespace ERPASA.Frm_Taller
{
    partial class frm_AgregarGrupoVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AgregarGrupoVehiculo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_GrupoVehiculo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Obs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Grupo = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_buscar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_guardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_imprimir = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_limpiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_GrupoVehiculo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_Obs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Grupo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(650, 206);
            this.groupBox1.TabIndex = 211;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DETALLES";
            // 
            // comboBox_GrupoVehiculo
            // 
            this.comboBox_GrupoVehiculo.FormattingEnabled = true;
            this.comboBox_GrupoVehiculo.Location = new System.Drawing.Point(126, 124);
            this.comboBox_GrupoVehiculo.Name = "comboBox_GrupoVehiculo";
            this.comboBox_GrupoVehiculo.Size = new System.Drawing.Size(246, 30);
            this.comboBox_GrupoVehiculo.TabIndex = 16;
            this.comboBox_GrupoVehiculo.Visible = false;
            this.comboBox_GrupoVehiculo.SelectedIndexChanged += new System.EventHandler(this.comboBox_GrupoVehiculo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 13;
            this.label9.Text = "Grupo";
            this.label9.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Observacion";
            // 
            // textBox_Obs
            // 
            this.textBox_Obs.Location = new System.Drawing.Point(126, 78);
            this.textBox_Obs.Name = "textBox_Obs";
            this.textBox_Obs.Size = new System.Drawing.Size(408, 28);
            this.textBox_Obs.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupo";
            // 
            // textBox_Grupo
            // 
            this.textBox_Grupo.Location = new System.Drawing.Point(126, 32);
            this.textBox_Grupo.Name = "textBox_Grupo";
            this.textBox_Grupo.Size = new System.Drawing.Size(408, 28);
            this.textBox_Grupo.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_buscar,
            this.toolStripLabel_buscar,
            this.toolStripSeparator7,
            this.toolStripSeparator9,
            this.toolStripButton_guardar,
            this.toolStripLabel_imprimir,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.toolStripButton_limpiar,
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(701, 41);
            this.toolStrip2.TabIndex = 265;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_buscar
            // 
            this.toolStripButton_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_buscar.Enabled = false;
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
            this.toolStripLabel_buscar.Enabled = false;
            this.toolStripLabel_buscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_buscar.Name = "toolStripLabel_buscar";
            this.toolStripLabel_buscar.Size = new System.Drawing.Size(81, 36);
            this.toolStripLabel_buscar.Text = "Buscar";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton_guardar
            // 
            this.toolStripButton_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_guardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_guardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_guardar.Image")));
            this.toolStripButton_guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_guardar.Name = "toolStripButton_guardar";
            this.toolStripButton_guardar.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_guardar.ToolTipText = "Guardar";
            this.toolStripButton_guardar.Click += new System.EventHandler(this.toolStripButton_guardar_Click);
            // 
            // toolStripLabel_imprimir
            // 
            this.toolStripLabel_imprimir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel_imprimir.Name = "toolStripLabel_imprimir";
            this.toolStripLabel_imprimir.Size = new System.Drawing.Size(97, 36);
            this.toolStripLabel_imprimir.Text = "Guardar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
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
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(91, 36);
            this.toolStripLabel2.Text = "Limpiar";
            // 
            // frm_AgregarGrupoVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 309);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_AgregarGrupoVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR GRUPO VEHICULO";
            this.Load += new System.EventHandler(this.frm_AgregarGrupoVehiculo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton toolStripButton_limpiar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton_buscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripButton toolStripButton_guardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Obs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Grupo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_GrupoVehiculo;
    }
}