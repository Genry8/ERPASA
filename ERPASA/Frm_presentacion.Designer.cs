
namespace ERPASA
{
    partial class Frm_presentacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_presentacion));
            this.panel_fondo = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox_foto_inisecion = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label_titulo = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.label_presentacion = new System.Windows.Forms.Label();
            this.panel_divisor = new System.Windows.Forms.Panel();
            this.progress_carga = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label_carga = new System.Windows.Forms.Label();
            this.pictureBox_titulo = new System.Windows.Forms.PictureBox();
            this.elipse_form = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.sombra_form = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_fondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_foto_inisecion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).BeginInit();
            this.SuspendLayout();
            //
            // panel_fondo
            //
            this.panel_fondo.BorderThickness = 0;
            this.panel_fondo.Controls.Add(this.pictureBox_foto_inisecion);
            this.panel_fondo.Controls.Add(this.label_titulo);
            this.panel_fondo.Controls.Add(this.label_nombre);
            this.panel_fondo.Controls.Add(this.label_presentacion);
            this.panel_fondo.Controls.Add(this.panel_divisor);
            this.panel_fondo.Controls.Add(this.progress_carga);
            this.panel_fondo.Controls.Add(this.label_carga);
            this.panel_fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fondo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.panel_fondo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(163)))));
            this.panel_fondo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.panel_fondo.Location = new System.Drawing.Point(0, 0);
            this.panel_fondo.Name = "panel_fondo";
            this.panel_fondo.ShadowDecoration.Parent = this.panel_fondo;
            this.panel_fondo.Size = new System.Drawing.Size(760, 460);
            this.panel_fondo.TabIndex = 0;
            this.panel_fondo.TabStop = false;
            //
            // pictureBox_foto_inisecion
            //
            this.pictureBox_foto_inisecion.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_foto_inisecion.FillColor = System.Drawing.Color.White;
            this.pictureBox_foto_inisecion.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_foto_inisecion.Image")));
            this.pictureBox_foto_inisecion.ImageRotate = 0F;
            this.pictureBox_foto_inisecion.Location = new System.Drawing.Point(318, 56);
            this.pictureBox_foto_inisecion.Name = "pictureBox_foto_inisecion";
            this.pictureBox_foto_inisecion.ShadowDecoration.Parent = this.pictureBox_foto_inisecion;
            this.pictureBox_foto_inisecion.Size = new System.Drawing.Size(124, 124);
            this.pictureBox_foto_inisecion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_foto_inisecion.TabIndex = 0;
            this.pictureBox_foto_inisecion.TabStop = false;
            //
            // label_titulo
            //
            this.label_titulo.BackColor = System.Drawing.Color.Transparent;
            this.label_titulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label_titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(201)))), ((int)(((byte)(211)))));
            this.label_titulo.Location = new System.Drawing.Point(0, 204);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(760, 24);
            this.label_titulo.TabIndex = 1;
            this.label_titulo.Text = "Bienvenido";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label_nombre
            //
            this.label_nombre.BackColor = System.Drawing.Color.Transparent;
            this.label_nombre.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label_nombre.ForeColor = System.Drawing.Color.White;
            this.label_nombre.Location = new System.Drawing.Point(30, 230);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(700, 44);
            this.label_nombre.TabIndex = 2;
            this.label_nombre.Text = "Usuario";
            this.label_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label_presentacion
            //
            this.label_presentacion.BackColor = System.Drawing.Color.Transparent;
            this.label_presentacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_presentacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(183)))), ((int)(((byte)(196)))));
            this.label_presentacion.Location = new System.Drawing.Point(30, 278);
            this.label_presentacion.Name = "label_presentacion";
            this.label_presentacion.Size = new System.Drawing.Size(700, 24);
            this.label_presentacion.TabIndex = 3;
            this.label_presentacion.Text = "Grupo";
            this.label_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panel_divisor
            //
            this.panel_divisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(186)))), ((int)(((byte)(203)))));
            this.panel_divisor.Location = new System.Drawing.Point(350, 322);
            this.panel_divisor.Name = "panel_divisor";
            this.panel_divisor.Size = new System.Drawing.Size(60, 2);
            this.panel_divisor.TabIndex = 4;
            //
            // progress_carga
            //
            this.progress_carga.BackColor = System.Drawing.Color.Transparent;
            this.progress_carga.BorderRadius = 3;
            this.progress_carga.FillColor = System.Drawing.Color.FromArgb(70, 255, 255, 255);
            this.progress_carga.Location = new System.Drawing.Point(230, 362);
            this.progress_carga.Name = "progress_carga";
            this.progress_carga.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(171)))), ((int)(((byte)(192)))));
            this.progress_carga.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(214)))), ((int)(((byte)(228)))));
            this.progress_carga.ShadowDecoration.Parent = this.progress_carga;
            this.progress_carga.Size = new System.Drawing.Size(300, 7);
            this.progress_carga.TabIndex = 5;
            this.progress_carga.Text = "";
            this.progress_carga.UseTransparentBackground = true;
            this.progress_carga.Value = 0;
            //
            // label_carga
            //
            this.label_carga.BackColor = System.Drawing.Color.Transparent;
            this.label_carga.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label_carga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(183)))), ((int)(((byte)(196)))));
            this.label_carga.Location = new System.Drawing.Point(230, 378);
            this.label_carga.Name = "label_carga";
            this.label_carga.Size = new System.Drawing.Size(300, 22);
            this.label_carga.TabIndex = 6;
            this.label_carga.Text = "Preparando el sistema...";
            this.label_carga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pictureBox_titulo
            //
            this.pictureBox_titulo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_titulo.Image")));
            this.pictureBox_titulo.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_titulo.Name = "pictureBox_titulo";
            this.pictureBox_titulo.Size = new System.Drawing.Size(1, 1);
            this.pictureBox_titulo.TabIndex = 7;
            this.pictureBox_titulo.TabStop = false;
            this.pictureBox_titulo.Visible = false;
            //
            // elipse_form
            //
            this.elipse_form.BorderRadius = 16;
            this.elipse_form.TargetControl = this;
            //
            // sombra_form
            //
            this.sombra_form.BorderRadius = 16;
            this.sombra_form.TargetForm = this;
            //
            // timer1
            //
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //
            // Frm_presentacion
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(760, 460);
            this.Controls.Add(this.pictureBox_titulo);
            this.Controls.Add(this.panel_fondo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_presentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_presentacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_presentacion_FormClosed);
            this.panel_fondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_foto_inisecion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel panel_fondo;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBox_foto_inisecion;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Label label_presentacion;
        private System.Windows.Forms.Panel panel_divisor;
        private Guna.UI2.WinForms.Guna2ProgressBar progress_carga;
        private System.Windows.Forms.Label label_carga;
        private System.Windows.Forms.PictureBox pictureBox_titulo;
        private Guna.UI2.WinForms.Guna2Elipse elipse_form;
        private Guna.UI2.WinForms.Guna2ShadowForm sombra_form;
        private System.Windows.Forms.Timer timer1;
    }
}
