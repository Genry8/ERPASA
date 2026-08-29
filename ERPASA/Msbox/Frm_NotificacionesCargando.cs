using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Msbox
{
    public partial class Frm_NotificacionesCargando : Form
    {
        public Frm_NotificacionesCargando()
        {
            InitializeComponent();
        }
        private Panel panel_notificacion_titulo;
        private Panel panel_icin;
        private Timer timer1;
        private Label label_NotMensaje;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.ComponentModel.IContainer components;

        //cargar los border y botones a mostrar

        public Frm_NotificacionesCargando(string Nmensaje, Color Ncolor, int Ntipo)
        {
            InitializeComponent();
            label_NotMensaje.Text = Nmensaje;
            label_NotMensaje.ForeColor = Ncolor;
            panel_notificacion_titulo.BackColor = Ncolor;

            if (Ntipo == 1) //GUARDAR
            {
                //panel_icon_actualizado.Visible = false;
                //panel_icon_eliminar.Visible = false;
                //panel_icon_alerta.Visible = false;

            }
            else if (Ntipo == 2) //GUARDAR ACTUALIZADO
            {
                //panel_icon_guardar.Visible = false;
                //panel_icon_eliminar.Visible = false;
                //panel_icon_alerta.Visible = false;
            }
            else if (Ntipo == 3) // ELIMINADO
            {
                //panel_icon_guardar.Visible = false;
                //panel_icon_actualizado.Visible = false;
                //panel_icon_alerta.Visible = false;
            }
            else if (Ntipo == 4) // ALERTA
            {
                //panel_icon_guardar.Visible = false;
                //panel_icon_eliminar.Visible = false;
                //panel_icon_actualizado.Visible = false;
            }
        }

        //EVENTO TIMER

        private int contar;

        private void timer1_Tick(object sender, EventArgs e)
        {
            contar++; //aumenta el conteo
            if (contar == 2000000) // cuando llega a 20 equivale 2 segundos la notificacion
                this.Close(); // se detiene
        }
        //evento cuando abre el from
        private void Frm_Notificaciones_Load(object sender, EventArgs e)
        {
            timer1.Start(); //inicia el conteo de timer
        }

        //evento cuando cierra el form
        private void Frm_Notificaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false; //se detiene el timer
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_notificacion_titulo = new System.Windows.Forms.Panel();
            this.label_NotMensaje = new System.Windows.Forms.Label();
            this.panel_icin = new System.Windows.Forms.Panel();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_notificacion_titulo.SuspendLayout();
            this.panel_icin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_notificacion_titulo
            // 
            this.panel_notificacion_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(140)))));
            this.panel_notificacion_titulo.Controls.Add(this.label_NotMensaje);
            this.panel_notificacion_titulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel_notificacion_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_notificacion_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_notificacion_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.panel_notificacion_titulo.Name = "panel_notificacion_titulo";
            this.panel_notificacion_titulo.Size = new System.Drawing.Size(466, 53);
            this.panel_notificacion_titulo.TabIndex = 19;
            // 
            // label_NotMensaje
            // 
            this.label_NotMensaje.AutoSize = true;
            this.label_NotMensaje.Font = new System.Drawing.Font("Verdana", 14F);
            this.label_NotMensaje.ForeColor = System.Drawing.Color.White;
            this.label_NotMensaje.Location = new System.Drawing.Point(67, 1);
            this.label_NotMensaje.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_NotMensaje.Name = "label_NotMensaje";
            this.label_NotMensaje.Size = new System.Drawing.Size(320, 46);
            this.label_NotMensaje.TabIndex = 15;
            this.label_NotMensaje.Text = "DESCARGANDO";
            // 
            // panel_icin
            // 
            this.panel_icin.BackColor = System.Drawing.Color.Transparent;
            this.panel_icin.Controls.Add(this.circularProgressBar1);
            this.panel_icin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_icin.Location = new System.Drawing.Point(0, 53);
            this.panel_icin.Margin = new System.Windows.Forms.Padding(6);
            this.panel_icin.Name = "panel_icin";
            this.panel_icin.Size = new System.Drawing.Size(466, 258);
            this.panel_icin.TabIndex = 22;
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
            this.circularProgressBar1.Location = new System.Drawing.Point(93, 2);
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
            this.circularProgressBar1.TabIndex = 24;
            this.circularProgressBar1.Text = "0";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 5;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_NotificacionesCargando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 311);
            this.Controls.Add(this.panel_icin);
            this.Controls.Add(this.panel_notificacion_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_NotificacionesCargando";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Notificaciones_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Notificaciones_Load);
            this.panel_notificacion_titulo.ResumeLayout(false);
            this.panel_notificacion_titulo.PerformLayout();
            this.panel_icin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
