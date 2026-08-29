
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox_titulo = new System.Windows.Forms.PictureBox();
            this.label_titulo = new System.Windows.Forms.Label();
            this.pictureBox_foto_inisecion = new System.Windows.Forms.PictureBox();
            this.label_presentacion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.label_nombre = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_foto_inisecion)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.pictureBox_titulo);
            this.panel3.Controls.Add(this.label_titulo);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1269, 85);
            this.panel3.TabIndex = 10;
            // 
            // pictureBox_titulo
            // 
            this.pictureBox_titulo.BackColor = System.Drawing.Color.White;
            this.pictureBox_titulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_titulo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_titulo.Image")));
            this.pictureBox_titulo.Location = new System.Drawing.Point(24, 13);
            this.pictureBox_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox_titulo.Name = "pictureBox_titulo";
            this.pictureBox_titulo.Size = new System.Drawing.Size(62, 56);
            this.pictureBox_titulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_titulo.TabIndex = 24;
            this.pictureBox_titulo.TabStop = false;
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.BackColor = System.Drawing.Color.Transparent;
            this.label_titulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_titulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_titulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo.ForeColor = System.Drawing.Color.White;
            this.label_titulo.Location = new System.Drawing.Point(98, 25);
            this.label_titulo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(202, 39);
            this.label_titulo.TabIndex = 23;
            this.label_titulo.Text = "BIENVENIDO";
            // 
            // pictureBox_foto_inisecion
            // 
            this.pictureBox_foto_inisecion.BackColor = System.Drawing.Color.White;
            this.pictureBox_foto_inisecion.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_foto_inisecion.Image")));
            this.pictureBox_foto_inisecion.Location = new System.Drawing.Point(33, 111);
            this.pictureBox_foto_inisecion.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox_foto_inisecion.Name = "pictureBox_foto_inisecion";
            this.pictureBox_foto_inisecion.Size = new System.Drawing.Size(316, 375);
            this.pictureBox_foto_inisecion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_foto_inisecion.TabIndex = 23;
            this.pictureBox_foto_inisecion.TabStop = false;
            // 
            // label_presentacion
            // 
            this.label_presentacion.AutoSize = true;
            this.label_presentacion.BackColor = System.Drawing.Color.Transparent;
            this.label_presentacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_presentacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_presentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_presentacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.label_presentacion.Location = new System.Drawing.Point(37, 508);
            this.label_presentacion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_presentacion.Name = "label_presentacion";
            this.label_presentacion.Size = new System.Drawing.Size(77, 26);
            this.label_presentacion.TabIndex = 24;
            this.label_presentacion.Text = "Grupo";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.circularProgressBar1);
            this.panel2.Controls.Add(this.label_nombre);
            this.panel2.Location = new System.Drawing.Point(409, 96);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 454);
            this.panel2.TabIndex = 22;
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.CubicEaseOut;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(93)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(298, 120);
            this.circularProgressBar1.Margin = new System.Windows.Forms.Padding(6);
            this.circularProgressBar1.MarqueeAnimationSpeed = 4500;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(69)))));
            this.circularProgressBar1.OuterMargin = -20;
            this.circularProgressBar1.OuterWidth = 20;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(180)))));
            this.circularProgressBar1.ProgressWidth = 20;
            this.circularProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.circularProgressBar1.Size = new System.Drawing.Size(260, 250);
            this.circularProgressBar1.StartAngle = 290;
            this.circularProgressBar1.Step = 2;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 23;
            this.circularProgressBar1.Text = "0";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 5;
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.BackColor = System.Drawing.Color.Transparent;
            this.label_nombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_nombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.label_nombre.Location = new System.Drawing.Point(24, 32);
            this.label_nombre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(135, 37);
            this.label_nombre.TabIndex = 22;
            this.label_nombre.Text = "Usuario";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(361, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 403);
            this.panel1.TabIndex = 25;
            // 
            // Frm_presentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox_foto_inisecion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label_presentacion);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_presentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_presentacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_presentacion_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_titulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_foto_inisecion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox_titulo;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.PictureBox pictureBox_foto_inisecion;
        private System.Windows.Forms.Label label_presentacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Timer timer1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Panel panel1;
    }
}