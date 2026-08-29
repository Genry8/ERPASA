namespace ERPASA.Frm_DestajoUva
{
    partial class frm_AgregarSticker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AgregarSticker));
            this.pictureBox_GuardarDestajo = new System.Windows.Forms.PictureBox();
            this.guna2TextBox_seleccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox_presentacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox_pesado = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox_empaque = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_estado_reg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_GuardarDestajo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_GuardarDestajo
            // 
            this.pictureBox_GuardarDestajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_GuardarDestajo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_GuardarDestajo.Image")));
            this.pictureBox_GuardarDestajo.Location = new System.Drawing.Point(0, -1);
            this.pictureBox_GuardarDestajo.Name = "pictureBox_GuardarDestajo";
            this.pictureBox_GuardarDestajo.Size = new System.Drawing.Size(52, 51);
            this.pictureBox_GuardarDestajo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_GuardarDestajo.TabIndex = 410;
            this.pictureBox_GuardarDestajo.TabStop = false;
            this.pictureBox_GuardarDestajo.Click += new System.EventHandler(this.pictureBox_EliminarLiq_Click);
            // 
            // guna2TextBox_seleccion
            // 
            this.guna2TextBox_seleccion.BorderRadius = 2;
            this.guna2TextBox_seleccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_seleccion.DefaultText = "";
            this.guna2TextBox_seleccion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_seleccion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_seleccion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_seleccion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_seleccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_seleccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox_seleccion.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_seleccion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_seleccion.Location = new System.Drawing.Point(262, 125);
            this.guna2TextBox_seleccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_seleccion.Name = "guna2TextBox_seleccion";
            this.guna2TextBox_seleccion.PlaceholderText = "Seleccion";
            this.guna2TextBox_seleccion.SelectedText = "";
            this.guna2TextBox_seleccion.Size = new System.Drawing.Size(176, 42);
            this.guna2TextBox_seleccion.TabIndex = 409;
            this.guna2TextBox_seleccion.TextChanged += new System.EventHandler(this.guna2TextBox_liquidacion_TextChanged);
            this.guna2TextBox_seleccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox_seleccion_KeyPress);
            // 
            // guna2TextBox_presentacion
            // 
            this.guna2TextBox_presentacion.BorderRadius = 2;
            this.guna2TextBox_presentacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_presentacion.DefaultText = "";
            this.guna2TextBox_presentacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_presentacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_presentacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_presentacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_presentacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_presentacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox_presentacion.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_presentacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_presentacion.Location = new System.Drawing.Point(30, 125);
            this.guna2TextBox_presentacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_presentacion.Name = "guna2TextBox_presentacion";
            this.guna2TextBox_presentacion.PlaceholderText = "Presentacion";
            this.guna2TextBox_presentacion.SelectedText = "";
            this.guna2TextBox_presentacion.Size = new System.Drawing.Size(178, 42);
            this.guna2TextBox_presentacion.TabIndex = 408;
            this.guna2TextBox_presentacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox_presentacion_KeyPress);
            // 
            // guna2TextBox_pesado
            // 
            this.guna2TextBox_pesado.BorderRadius = 2;
            this.guna2TextBox_pesado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_pesado.DefaultText = "";
            this.guna2TextBox_pesado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_pesado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_pesado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_pesado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_pesado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_pesado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox_pesado.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_pesado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_pesado.Location = new System.Drawing.Point(477, 125);
            this.guna2TextBox_pesado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_pesado.Name = "guna2TextBox_pesado";
            this.guna2TextBox_pesado.PlaceholderText = "Pesado";
            this.guna2TextBox_pesado.SelectedText = "";
            this.guna2TextBox_pesado.Size = new System.Drawing.Size(170, 42);
            this.guna2TextBox_pesado.TabIndex = 411;
            this.guna2TextBox_pesado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox_pesado_KeyPress);
            // 
            // guna2TextBox_empaque
            // 
            this.guna2TextBox_empaque.BorderRadius = 2;
            this.guna2TextBox_empaque.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_empaque.DefaultText = "";
            this.guna2TextBox_empaque.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_empaque.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_empaque.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_empaque.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_empaque.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_empaque.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox_empaque.ForeColor = System.Drawing.Color.Teal;
            this.guna2TextBox_empaque.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_empaque.Location = new System.Drawing.Point(691, 125);
            this.guna2TextBox_empaque.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox_empaque.Name = "guna2TextBox_empaque";
            this.guna2TextBox_empaque.PlaceholderText = "Empaque";
            this.guna2TextBox_empaque.SelectedText = "";
            this.guna2TextBox_empaque.Size = new System.Drawing.Size(156, 42);
            this.guna2TextBox_empaque.TabIndex = 412;
            this.guna2TextBox_empaque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox_empaque_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 413;
            this.label1.Text = "PRESENTACION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 29);
            this.label2.TabIndex = 414;
            this.label2.Text = "SELECCION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(482, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 29);
            this.label3.TabIndex = 415;
            this.label3.Text = "PESADO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(686, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 29);
            this.label4.TabIndex = 416;
            this.label4.Text = "EMPAQUE";
            // 
            // label_estado_reg
            // 
            this.label_estado_reg.AutoSize = true;
            this.label_estado_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_estado_reg.Location = new System.Drawing.Point(166, 20);
            this.label_estado_reg.Name = "label_estado_reg";
            this.label_estado_reg.Size = new System.Drawing.Size(31, 29);
            this.label_estado_reg.TabIndex = 417;
            this.label_estado_reg.Text = "...";
            // 
            // frm_AgregarSticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 209);
            this.Controls.Add(this.label_estado_reg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2TextBox_empaque);
            this.Controls.Add(this.guna2TextBox_pesado);
            this.Controls.Add(this.pictureBox_GuardarDestajo);
            this.Controls.Add(this.guna2TextBox_seleccion);
            this.Controls.Add(this.guna2TextBox_presentacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_AgregarSticker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Sticker";
            this.Load += new System.EventHandler(this.frm_AgregarSticker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_GuardarDestajo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_GuardarDestajo;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_seleccion;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_presentacion;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_pesado;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_empaque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_estado_reg;
    }
}