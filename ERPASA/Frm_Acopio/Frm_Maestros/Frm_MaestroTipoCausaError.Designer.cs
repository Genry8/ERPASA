
namespace ERPASA.Frm_Acopio.Frm_Maestros
{
    partial class Frm_MaestroTipoCausaError
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_editar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_eliminar = new System.Windows.Forms.ToolStripButton();
            this.textBox_Buscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            //
            // toolStrip2
            //
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_buscar,
            this.toolStripButton_excel,
            this.toolStripButton_nuevo,
            this.toolStripButton_editar,
            this.toolStripButton_eliminar});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1213, 41);
            this.toolStrip2.TabIndex = 0;
            //
            // toolStripButton_buscar
            //
            this.toolStripButton_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton_buscar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_buscar.Name = "toolStripButton_buscar";
            this.toolStripButton_buscar.Size = new System.Drawing.Size(100, 36);
            this.toolStripButton_buscar.Text = "Buscar";
            this.toolStripButton_buscar.Click += new System.EventHandler(this.toolStripButton_buscar_Click);
            //
            // toolStripButton_excel
            //
            this.toolStripButton_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton_excel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_excel.Name = "toolStripButton_excel";
            this.toolStripButton_excel.Size = new System.Drawing.Size(110, 36);
            this.toolStripButton_excel.Text = "Exportar";
            this.toolStripButton_excel.Click += new System.EventHandler(this.toolStripButton_excel_Click);
            //
            // toolStripButton_nuevo
            //
            this.toolStripButton_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton_nuevo.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_nuevo.Name = "toolStripButton_nuevo";
            this.toolStripButton_nuevo.Size = new System.Drawing.Size(100, 36);
            this.toolStripButton_nuevo.Text = "Nuevo";
            this.toolStripButton_nuevo.Click += new System.EventHandler(this.toolStripButton_nuevo_Click);
            //
            // toolStripButton_editar
            //
            this.toolStripButton_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton_editar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_editar.Name = "toolStripButton_editar";
            this.toolStripButton_editar.Size = new System.Drawing.Size(100, 36);
            this.toolStripButton_editar.Text = "Editar";
            this.toolStripButton_editar.Click += new System.EventHandler(this.toolStripButton_editar_Click);
            //
            // toolStripButton_eliminar
            //
            this.toolStripButton_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton_eliminar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.toolStripButton_eliminar.Name = "toolStripButton_eliminar";
            this.toolStripButton_eliminar.Size = new System.Drawing.Size(110, 36);
            this.toolStripButton_eliminar.Text = "Eliminar";
            this.toolStripButton_eliminar.Click += new System.EventHandler(this.toolStripButton_eliminar_Click);
            //
            // textBox_Buscar
            //
            this.textBox_Buscar.BorderRadius = 6;
            this.textBox_Buscar.DefaultText = "";
            this.textBox_Buscar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_Buscar.Location = new System.Drawing.Point(12, 55);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.PlaceholderText = "Buscar en los resultados...";
            this.textBox_Buscar.SelectedText = "";
            this.textBox_Buscar.Size = new System.Drawing.Size(560, 36);
            this.textBox_Buscar.TabIndex = 1;
            this.textBox_Buscar.TextChanged += new System.EventHandler(this.textBox_Buscar_TextChanged);
            //
            // dataGridView2
            //
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.Location = new System.Drawing.Point(12, 100);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1188, 590);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            //
            // Frm_MaestroTipoCausaError
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 706);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.toolStrip2);
            this.Name = "Frm_MaestroTipoCausaError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAESTRO - TIPO DE CAUSA DE ERROR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_MaestroTipoCausaError_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_buscar;
        private System.Windows.Forms.ToolStripButton toolStripButton_excel;
        private System.Windows.Forms.ToolStripButton toolStripButton_nuevo;
        private System.Windows.Forms.ToolStripButton toolStripButton_editar;
        private System.Windows.Forms.ToolStripButton toolStripButton_eliminar;
        private Guna.UI2.WinForms.Guna2TextBox textBox_Buscar;
        public System.Windows.Forms.DataGridView dataGridView2;
    }
}
