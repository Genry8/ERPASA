using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ERPASA.Estilos
{
    /// <summary>
    /// Paleta única del ERP. La comparten el login, la bienvenida, el menú
    /// principal y los formularios de mantenimiento.
    /// </summary>
    public static class PaletaErp
    {
        // Petróleo: barras de título, cabeceras de sección y de tabla.
        public static readonly Color Petroleo = Color.FromArgb(18, 74, 94);
        public static readonly Color PetroleoClaro = Color.FromArgb(23, 96, 122);
        // Teal medio para rellenos, selección y bordes de foco; lleva texto blanco.
        public static readonly Color Acento = Color.FromArgb(46, 139, 163);
        public static readonly Color AcentoClaro = Color.FromArgb(61, 163, 189);
        // Teal profundo, solo para texto, enlaces y flechas sobre fondo claro:
        // el teal de arriba no contrasta lo suficiente en blanco.
        public static readonly Color AcentoTexto = Color.FromArgb(31, 107, 128);

        // Fondo celeste muy claro: las tarjetas blancas se despegan sobre él.
        public static readonly Color Fondo = Color.FromArgb(233, 240, 246);
        public static readonly Color Tarjeta = Color.White;
        public static readonly Color Campo = Color.FromArgb(247, 249, 252);
        public static readonly Color Borde = Color.FromArgb(221, 227, 235);
        public static readonly Color BordeSuave = Color.FromArgb(233, 238, 244);
        public static readonly Color BordeFuerte = Color.FromArgb(172, 188, 208);

        public static readonly Color Texto = Color.FromArgb(37, 48, 66);
        public static readonly Color Etiqueta = Color.FromArgb(74, 85, 104);
        public static readonly Color TextoApagado = Color.FromArgb(166, 175, 188);

        // Cabecera de las tablas y resaltado suave de la fila seleccionada.
        public static readonly Color CabeceraGrilla = Color.FromArgb(27, 165, 184);
        public static readonly Color FilaSeleccionada = Color.FromArgb(210, 234, 240);

        public static readonly Color Hover = Color.FromArgb(228, 241, 244);
        public static readonly Color Presionado = Color.FromArgb(210, 232, 237);
        public static readonly Color Peligro = Color.FromArgb(224, 62, 62);

        /// <summary>
        /// Dibuja una lupa para usarla como icono de las cajas de búsqueda,
        /// así no hace falta agregar imágenes a los .resx.
        /// </summary>
        public static Bitmap IconoBuscar(Color color, int tamano)
        {
            var bmp = new Bitmap(tamano, tamano);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float grosor = System.Math.Max(1.4f, tamano / 9f);

                using (var p = new Pen(color, grosor))
                {
                    p.StartCap = LineCap.Round;
                    p.EndCap = LineCap.Round;

                    float d = tamano * 0.56f;
                    g.DrawEllipse(p, grosor, grosor, d, d);
                    g.DrawLine(p, grosor + d * 0.80f, grosor + d * 0.80f,
                        tamano - grosor, tamano - grosor);
                }
            }

            return bmp;
        }

        /// <summary>Rectángulo con esquinas redondeadas, para los fondos de hover.</summary>
        public static GraphicsPath Redondeado(Rectangle r, int radio)
        {
            var path = new GraphicsPath();
            int d = radio * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    /// <summary>
    /// Barra de acciones plana (Nuevo / Buscar / Editar / Guardar / …):
    /// fondo blanco, línea de separación y resaltado teal redondeado.
    /// </summary>
    public class BarraAccionesRenderer : ToolStripProfessionalRenderer
    {
        public BarraAccionesRenderer()
        {
            this.RoundedEdges = false;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (var b = new SolidBrush(PaletaErp.Tarjeta))
                e.Graphics.FillRectangle(b, e.AffectedBounds);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            using (var p = new Pen(PaletaErp.Borde))
            {
                e.Graphics.DrawLine(p, 0, e.ToolStrip.Height - 1,
                    e.ToolStrip.Width, e.ToolStrip.Height - 1);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Enabled || (!e.Item.Selected && !e.Item.Pressed)) return;

            var r = new Rectangle(0, 2, e.Item.Width, e.Item.Height - 4);
            var color = e.Item.Pressed ? PaletaErp.Presionado : PaletaErp.Hover;
            var g = e.Graphics;
            var modo = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = PaletaErp.Redondeado(r, 6))
            using (var b = new SolidBrush(color))
                g.FillPath(b, path);

            g.SmoothingMode = modo;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (!e.Item.Enabled)
                e.TextColor = PaletaErp.TextoApagado;
            else if (e.Item.Selected || e.Item.Pressed)
                e.TextColor = PaletaErp.AcentoTexto;
            else
                e.TextColor = PaletaErp.Texto;

            base.OnRenderItemText(e);
        }
    }
}
