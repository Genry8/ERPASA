namespace ERPASA.Frm_Comercial
{
    partial class frm_EliminarLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EliminarLiquidacion));
            this.pictureBox_EliminarLiq = new System.Windows.Forms.PictureBox();
            this.guna2TextBox_liquidacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox_fecha = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EliminarLiq)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_EliminarLiq
            // 
            this.pictureBox_EliminarLiq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_EliminarLiq.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_EliminarLiq.Image")));
            this.pictureBox_EliminarLiq.Location = new System.Drawing.Point(453, 43);
            this.pictureBox_EliminarLiq.Name = "pictureBox_EliminarLiq";
            this.pictureBox_EliminarLiq.Size = new System.Drawing.Size(37, 34);
            this.pictureBox_EliminarLiq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_EliminarLiq.TabIndex = 410;
            this.pictureBox_EliminarLiq.TabStop = false;
            this.pictureBox_EliminarLiq.Click += new System.EventHandler(this.pictureBox_EliminarLiq_Click);
            // 
            // guna2TextBox_liquidacion
            // 
            this.guna2TextBox_liquidacion.BorderRadius = 2;
            this.guna2TextBox_liquidacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_liquidacion.DefaultText = "";
            this.guna2TextBox_liquidacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_liquidacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_liquidacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_liquidacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_liquidacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_liquidacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_liquidacion.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_liquidacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_liquidacion.Location = new System.Drawing.Point(215, 43);
            this.guna2TextBox_liquidacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_liquidacion.Name = "guna2TextBox_liquidacion";
            this.guna2TextBox_liquidacion.PlaceholderText = "Liquidacion";
            this.guna2TextBox_liquidacion.ReadOnly = true;
            this.guna2TextBox_liquidacion.SelectedText = "";
            this.guna2TextBox_liquidacion.Size = new System.Drawing.Size(228, 34);
            this.guna2TextBox_liquidacion.TabIndex = 409;
            this.guna2TextBox_liquidacion.TextChanged += new System.EventHandler(this.guna2TextBox_liquidacion_TextChanged);
            this.guna2TextBox_liquidacion.DoubleClick += new System.EventHandler(this.guna2TextBox_liquidacion_DoubleClick);
            // 
            // guna2TextBox_fecha
            // 
            this.guna2TextBox_fecha.BorderRadius = 2;
            this.guna2TextBox_fecha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_fecha.DefaultText = "";
            this.guna2TextBox_fecha.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_fecha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_fecha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_fecha.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_fecha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_fecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_fecha.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_fecha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_fecha.Location = new System.Drawing.Point(33, 43);
            this.guna2TextBox_fecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_fecha.Name = "guna2TextBox_fecha";
            this.guna2TextBox_fecha.PlaceholderText = "Fecha";
            this.guna2TextBox_fecha.ReadOnly = true;
            this.guna2TextBox_fecha.SelectedText = "";
            this.guna2TextBox_fecha.Size = new System.Drawing.Size(174, 34);
            this.guna2TextBox_fecha.TabIndex = 408;
            this.guna2TextBox_fecha.DoubleClick += new System.EventHandler(this.guna2TextBox_fecha_DoubleClick);
            // 
            // frm_EliminarLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 156);
            this.Controls.Add(this.pictureBox_EliminarLiq);
            this.Controls.Add(this.guna2TextBox_liquidacion);
            this.Controls.Add(this.guna2TextBox_fecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_EliminarLiquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Liquidacion";
            this.Load += new System.EventHandler(this.frm_EliminarLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EliminarLiq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_EliminarLiq;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_liquidacion;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_fecha;
    }
}