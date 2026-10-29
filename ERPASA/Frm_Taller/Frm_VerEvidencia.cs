using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    /// <summary>
    /// Muestra la foto de evidencia que llega del aplicativo movil, con zoom.
    ///
    /// La imagen va dentro de un panel con barras de desplazamiento y el
    /// PictureBox se redimensiona segun el factor: asi se puede acercar sin
    /// perder calidad de encuadre y arrastrar para moverse por la foto.
    ///
    /// Se arma por codigo y no con el diseñador: son pocos controles y asi el
    /// formulario vive en un solo archivo.
    /// </summary>
    public class Frm_VerEvidencia : Form
    {
        private const double FactorMinimo = 0.05;
        private const double FactorMaximo = 8.0;
        private const double Paso = 1.25;

        private readonly Panel lienzo;
        private readonly PictureBox imagen;
        private readonly Label etiquetaZoom;
        private readonly byte[] bytes;
        private readonly string nombreArchivo;

        private double factor = 1.0;
        private bool arrastrando;
        private Point inicioArrastre;
        private Point inicioScroll;

        public Frm_VerEvidencia(byte[] contenido, string nombre)
        {
            bytes = contenido;
            nombreArchivo = nombre;

            Text = "EVIDENCIA - " + (nombre ?? "");
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(900, 700);
            MinimumSize = new Size(460, 360);
            BackColor = Color.White;
            KeyPreview = true;

            lienzo = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(60, 60, 60)
            };

            imagen = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };

            lienzo.Controls.Add(imagen);

            var barra = new Panel { Dock = DockStyle.Bottom, Height = 54 };

            var menos = Boton("–", 12, delegate { Acercar(1 / Paso, CentroVisible()); });
            var mas = Boton("+", 60, delegate { Acercar(Paso, CentroVisible()); });
            var ajustar = Boton("Ajustar", 112, delegate { AjustarAVentana(); });
            var real = Boton("100%", 212, delegate { Aplicar(1.0, CentroVisible()); });
            var guardar = Boton("Guardar como...", 312, delegate { Guardar(); });
            var cerrar = Boton("Cerrar", 462, delegate { Close(); });
            cerrar.DialogResult = DialogResult.Cancel;

            etiquetaZoom = new Label
            {
                AutoSize = true,
                Location = new Point(566, 19),
                Text = "100%"
            };

            barra.Controls.AddRange(new Control[]
            { menos, mas, ajustar, real, guardar, cerrar, etiquetaZoom });

            Controls.Add(lienzo);
            Controls.Add(barra);
            CancelButton = cerrar;

            // La rueda hace zoom sobre el punto donde esta el cursor.
            lienzo.MouseWheel += Lienzo_MouseWheel;
            imagen.MouseWheel += Lienzo_MouseWheel;

            // Arrastrar mueve la foto cuando no entra en la ventana.
            imagen.MouseDown += Imagen_MouseDown;
            imagen.MouseMove += Imagen_MouseMove;
            imagen.MouseUp += delegate { arrastrando = false; imagen.Cursor = Cursors.Hand; };
            imagen.DoubleClick += delegate
            {
                if (Math.Abs(factor - 1.0) < 0.001) AjustarAVentana();
                else Aplicar(1.0, CentroVisible());
            };

            KeyDown += Frm_VerEvidencia_KeyDown;
            Resize += delegate { if (imagen.Image != null) Centrar(); };

            Cargar();

            // Identidad visual del ERP (barra de titulo y botones).
            this.Load += delegate
            {
                Estilos.EstilizadorErp.Aplicar(this);
                AjustarAVentana();
                lienzo.Focus();
            };
        }

        private Button Boton(string texto, int x, EventHandler alPresionar)
        {
            var b = new Button
            {
                Text = texto,
                Size = new Size(texto.Length <= 1 ? 40 : (texto.Length > 10 ? 140 : 90), 36),
                Location = new Point(x, 9)
            };
            b.Click += alPresionar;
            return b;
        }

        private void Cargar()
        {
            try
            {
                // El MemoryStream no se libera a proposito: Image.FromStream
                // necesita que siga vivo mientras la imagen este en pantalla.
                imagen.Image = Image.FromStream(new MemoryStream(bytes));
                imagen.Cursor = Cursors.Hand;
            }
            catch
            {
                imagen.Image = null;

                Controls.Add(new Label
                {
                    Text = "El archivo recibido no es una imagen que se pueda mostrar.\n" +
                           "Use \"Guardar como...\" para revisarlo.",
                    Dock = DockStyle.Top,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(197, 40, 40)
                });
            }
        }

        // ------------------------------------------------------------ zoom

        /// <summary>Deja la foto completa dentro de la ventana.</summary>
        private void AjustarAVentana()
        {
            if (imagen.Image == null) return;

            double porAncho = (double)lienzo.ClientSize.Width / imagen.Image.Width;
            double porAlto = (double)lienzo.ClientSize.Height / imagen.Image.Height;

            Aplicar(Math.Min(porAncho, porAlto), Point.Empty);
        }

        private Point CentroVisible()
        {
            return new Point(lienzo.ClientSize.Width / 2, lienzo.ClientSize.Height / 2);
        }

        private void Acercar(double proporcion, Point puntoDelLienzo)
        {
            Aplicar(factor * proporcion, puntoDelLienzo);
        }

        /// <summary>
        /// Cambia el factor manteniendo quieto el punto de la foto que estaba
        /// bajo el cursor; sin esto, al acercar la imagen se "escapa".
        /// </summary>
        private void Aplicar(double nuevoFactor, Point puntoDelLienzo)
        {
            if (imagen.Image == null) return;

            nuevoFactor = Math.Max(FactorMinimo, Math.Min(FactorMaximo, nuevoFactor));

            // Que punto de la imagen esta hoy bajo ese pixel del lienzo.
            double enImagenX = (puntoDelLienzo.X - imagen.Left) / factor;
            double enImagenY = (puntoDelLienzo.Y - imagen.Top) / factor;

            factor = nuevoFactor;

            imagen.Size = new Size(
                Math.Max(1, (int)Math.Round(imagen.Image.Width * factor)),
                Math.Max(1, (int)Math.Round(imagen.Image.Height * factor)));

            if (puntoDelLienzo == Point.Empty)
            {
                Centrar();
            }
            else
            {
                // Se recoloca el scroll para que ese punto siga donde estaba.
                int destinoX = (int)Math.Round(enImagenX * factor) - puntoDelLienzo.X;
                int destinoY = (int)Math.Round(enImagenY * factor) - puntoDelLienzo.Y;

                Centrar();
                lienzo.AutoScrollPosition = new Point(Math.Max(0, destinoX), Math.Max(0, destinoY));
            }

            etiquetaZoom.Text = Math.Round(factor * 100) + "%";
        }

        /// <summary>Si la foto es mas chica que el lienzo, va al centro.</summary>
        private void Centrar()
        {
            int x = imagen.Width < lienzo.ClientSize.Width
                ? (lienzo.ClientSize.Width - imagen.Width) / 2
                : 0;

            int y = imagen.Height < lienzo.ClientSize.Height
                ? (lienzo.ClientSize.Height - imagen.Height) / 2
                : 0;

            imagen.Location = new Point(
                x + (imagen.Width < lienzo.ClientSize.Width ? 0 : lienzo.AutoScrollPosition.X),
                y + (imagen.Height < lienzo.ClientSize.Height ? 0 : lienzo.AutoScrollPosition.Y));
        }

        private void Lienzo_MouseWheel(object sender, MouseEventArgs e)
        {
            var puntoDelLienzo = lienzo.PointToClient(Cursor.Position);
            Acercar(e.Delta > 0 ? Paso : 1 / Paso, puntoDelLienzo);
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Imagen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            arrastrando = true;
            inicioArrastre = Cursor.Position;
            inicioScroll = new Point(-lienzo.AutoScrollPosition.X, -lienzo.AutoScrollPosition.Y);
            imagen.Cursor = Cursors.SizeAll;
        }

        private void Imagen_MouseMove(object sender, MouseEventArgs e)
        {
            if (!arrastrando) return;

            lienzo.AutoScrollPosition = new Point(
                inicioScroll.X - (Cursor.Position.X - inicioArrastre.X),
                inicioScroll.Y - (Cursor.Position.Y - inicioArrastre.Y));
        }

        private void Frm_VerEvidencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                Acercar(Paso, CentroVisible());
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                Acercar(1 / Paso, CentroVisible());
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                Aplicar(1.0, CentroVisible());
            else if (e.KeyCode == Keys.F)
                AjustarAVentana();
        }

        // -------------------------------------------------------- guardado

        private void Guardar()
        {
            var sd = new SaveFileDialog
            {
                Filter = "Imagen JPG|*.jpg|Imagen PNG|*.png|Todos los archivos|*.*",
                FileName = string.IsNullOrWhiteSpace(nombreArchivo)
                    ? "evidencia.jpg"
                    : Path.GetFileName(nombreArchivo)
            };

            if (sd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                File.WriteAllBytes(sd.FileName, bytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar:\n\n" + ex.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
