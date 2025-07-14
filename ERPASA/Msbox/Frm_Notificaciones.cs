using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Msbox
{
    public partial class Frm_Notificaciones : Form
    {
        public Frm_Notificaciones()
        {
            InitializeComponent();
        }
        private Panel panel_notificacion_titulo;
        private Panel panel_icin;
        private Panel panel_icon_alerta;
        private Panel panel_icon_actualizado;
        private Panel panel_icon_eliminar;
        private Label label_NotMensaje;
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        private Panel panel_icon_guardar;

        //cargar los border y botones a mostrar

        public Frm_Notificaciones(string Nmensaje, Color Ncolor, int Ntipo)
        {
            InitializeComponent();
            label_NotMensaje.Text = Nmensaje;
            label_NotMensaje.ForeColor = Ncolor;
            panel_notificacion_titulo.BackColor = Ncolor;

            if (Ntipo == 1) //GUARDAR
            {
                panel_icon_actualizado.Visible = false;
                panel_icon_eliminar.Visible = false;
                panel_icon_alerta.Visible = false;

            }
            else if (Ntipo == 2) //GUARDAR ACTUALIZADO
            {
                panel_icon_guardar.Visible = false;
                panel_icon_eliminar.Visible = false;
                panel_icon_alerta.Visible = false;
            }
            else if (Ntipo == 3) // ELIMINADO
            {
                panel_icon_guardar.Visible = false;
                panel_icon_actualizado.Visible = false;
                panel_icon_alerta.Visible = false;
            }
            else if (Ntipo == 4) // ALERTA
            {
                panel_icon_guardar.Visible = false;
                panel_icon_eliminar.Visible = false;
                panel_icon_actualizado.Visible = false;
            }
        }

        //EVENTO TIMER

        private int contar;

        private void timer1_Tick(object sender, EventArgs e)
        {
            contar++; //aumenta el conteo
            if (contar == 20) // cuando llega a 20 equivale 2 segundos la notificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Notificaciones));
            this.panel_notificacion_titulo = new System.Windows.Forms.Panel();
            this.panel_icin = new System.Windows.Forms.Panel();
            this.panel_icon_alerta = new System.Windows.Forms.Panel();
            this.panel_icon_actualizado = new System.Windows.Forms.Panel();
            this.panel_icon_eliminar = new System.Windows.Forms.Panel();
            this.label_NotMensaje = new System.Windows.Forms.Label();
            this.panel_icon_guardar = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_icin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_notificacion_titulo
            // 
            this.panel_notificacion_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(140)))));
            this.panel_notificacion_titulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel_notificacion_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_notificacion_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_notificacion_titulo.Margin = new System.Windows.Forms.Padding(6);
            this.panel_notificacion_titulo.Name = "panel_notificacion_titulo";
            this.panel_notificacion_titulo.Size = new System.Drawing.Size(434, 12);
            this.panel_notificacion_titulo.TabIndex = 19;
            // 
            // panel_icin
            // 
            this.panel_icin.BackColor = System.Drawing.Color.Transparent;
            this.panel_icin.Controls.Add(this.panel_icon_alerta);
            this.panel_icin.Controls.Add(this.panel_icon_actualizado);
            this.panel_icin.Controls.Add(this.panel_icon_eliminar);
            this.panel_icin.Controls.Add(this.label_NotMensaje);
            this.panel_icin.Controls.Add(this.panel_icon_guardar);
            this.panel_icin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_icin.Location = new System.Drawing.Point(0, 12);
            this.panel_icin.Margin = new System.Windows.Forms.Padding(6);
            this.panel_icin.Name = "panel_icin";
            this.panel_icin.Size = new System.Drawing.Size(434, 76);
            this.panel_icin.TabIndex = 22;
            // 
            // panel_icon_alerta
            // 
            this.panel_icon_alerta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_icon_alerta.BackgroundImage")));
            this.panel_icon_alerta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_icon_alerta.Location = new System.Drawing.Point(10, 10);
            this.panel_icon_alerta.Margin = new System.Windows.Forms.Padding(6);
            this.panel_icon_alerta.Name = "panel_icon_alerta";
            this.panel_icon_alerta.Size = new System.Drawing.Size(60, 58);
            this.panel_icon_alerta.TabIndex = 18;
            // 
            // panel_icon_actualizado
            // 
            this.panel_icon_actualizado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_icon_actualizado.BackgroundImage")));
            this.panel_icon_actualizado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_icon_actualizado.Location = new System.Drawing.Point(10, 10);
            this.panel_icon_actualizado.Margin = new System.Windows.Forms.Padding(6);
            this.panel_icon_actualizado.Name = "panel_icon_actualizado";
            this.panel_icon_actualizado.Size = new System.Drawing.Size(60, 58);
            this.panel_icon_actualizado.TabIndex = 17;
            // 
            // panel_icon_eliminar
            // 
            this.panel_icon_eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_icon_eliminar.BackgroundImage")));
            this.panel_icon_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_icon_eliminar.Location = new System.Drawing.Point(10, 10);
            this.panel_icon_eliminar.Margin = new System.Windows.Forms.Padding(6);
            this.panel_icon_eliminar.Name = "panel_icon_eliminar";
            this.panel_icon_eliminar.Size = new System.Drawing.Size(60, 58);
            this.panel_icon_eliminar.TabIndex = 18;
            // 
            // label_NotMensaje
            // 
            this.label_NotMensaje.AutoSize = true;
            this.label_NotMensaje.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NotMensaje.ForeColor = System.Drawing.Color.SeaGreen;
            this.label_NotMensaje.Location = new System.Drawing.Point(82, 23);
            this.label_NotMensaje.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_NotMensaje.Name = "label_NotMensaje";
            this.label_NotMensaje.Size = new System.Drawing.Size(337, 32);
            this.label_NotMensaje.TabIndex = 15;
            this.label_NotMensaje.Text = "USUARIO ACTUALIZADO";
            // 
            // panel_icon_guardar
            // 
            this.panel_icon_guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_icon_guardar.BackgroundImage")));
            this.panel_icon_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_icon_guardar.Location = new System.Drawing.Point(10, 10);
            this.panel_icon_guardar.Margin = new System.Windows.Forms.Padding(6);
            this.panel_icon_guardar.Name = "panel_icon_guardar";
            this.panel_icon_guardar.Size = new System.Drawing.Size(60, 58);
            this.panel_icon_guardar.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Notificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 88);
            this.Controls.Add(this.panel_icin);
            this.Controls.Add(this.panel_notificacion_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Notificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Notificaciones_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Notificaciones_Load);
            this.panel_icin.ResumeLayout(false);
            this.panel_icin.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
