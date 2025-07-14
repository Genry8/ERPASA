
namespace ERPASA
{
    partial class Frm_presentacion_cargando
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_titulo = new System.Windows.Forms.Label();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label_titulo);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1269, 85);
            this.panel3.TabIndex = 10;
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
            this.label_titulo.Size = new System.Drawing.Size(181, 39);
            this.label_titulo.TabIndex = 23;
            this.label_titulo.Text = "CARGANDO";
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
            this.circularProgressBar1.Location = new System.Drawing.Point(161, 97);
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_presentacion_cargando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 379);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_presentacion_cargando";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_presentacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_presentacion_cargando_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Timer timer1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
    }
}