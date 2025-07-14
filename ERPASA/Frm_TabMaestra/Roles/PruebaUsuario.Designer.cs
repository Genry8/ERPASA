namespace ERPASA.Frm_TabMaestra.Roles
{
    partial class PruebaUsuario
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_correo = new System.Windows.Forms.TextBox();
            this.textBox_comentario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(134, 110);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(356, 26);
            this.textBox_id.TabIndex = 1;
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(134, 165);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(356, 26);
            this.textBox_usuario.TabIndex = 2;
            // 
            // textBox_correo
            // 
            this.textBox_correo.Location = new System.Drawing.Point(134, 220);
            this.textBox_correo.Name = "textBox_correo";
            this.textBox_correo.Size = new System.Drawing.Size(356, 26);
            this.textBox_correo.TabIndex = 3;
            // 
            // textBox_comentario
            // 
            this.textBox_comentario.Location = new System.Drawing.Point(134, 277);
            this.textBox_comentario.Name = "textBox_comentario";
            this.textBox_comentario.Size = new System.Drawing.Size(356, 26);
            this.textBox_comentario.TabIndex = 4;
            // 
            // PruebaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_comentario);
            this.Controls.Add(this.textBox_correo);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.button1);
            this.Name = "PruebaUsuario";
            this.Text = "PruebaUsuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PruebaUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_correo;
        private System.Windows.Forms.TextBox textBox_comentario;
    }
}