using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Estilos
{
    /// <summary>
    /// Aplica la identidad visual del ERP a un formulario completo recorriendo su
    /// árbol de controles. Los formularios de mantenimiento comparten estructura
    /// (barra de título, barra de acciones, campos y una grilla), así que se
    /// estilizan con una sola llamada en lugar de tocar cada diseñador.
    /// </summary>
    public static class EstilizadorErp
    {
        /// <summary>Permite desactivar el reacomodo de filas para comparar layouts.</summary>
        public static bool MoverFilas = true;

        private const int AltoMinCampo = 24;
        private const int AltoMaxCampo = 30;

        public static void Aplicar(Form f)
        {
            if (f == null) return;

            f.BackColor = PaletaErp.Fondo;

            foreach (Control c in f.Controls)
                Recorrer(c);
        }

        private static void Recorrer(Control c)
        {
            if (EsBarraTitulo(c))
            {
                EstilizarBarraTitulo((Panel)c);
                return;
            }

            var barra = c as ToolStrip;
            if (barra != null)
            {
                EstilizarBarraAcciones(barra);
                return;
            }

            Estilizar(c);

            // Los controles Guna2 de edición llevan dentro un control nativo. Si se
            // recorre hacia adentro, ese hijo recibe borde y fondo propios y aparece
            // un recuadro alrededor del texto dentro del campo redondeado.
            if (c.HasChildren && !EsCompuestoGuna(c))
            {
                foreach (Control hijo in c.Controls)
                    Recorrer(hijo);
            }
        }

        private static bool EsCompuestoGuna(Control c)
        {
            return c is Guna.UI2.WinForms.Guna2TextBox
                || c is Guna.UI2.WinForms.Guna2ComboBox
                || c is Guna.UI2.WinForms.Guna2DateTimePicker
                || c is Guna.UI2.WinForms.Guna2NumericUpDown;
        }

        private static bool EsBarraTitulo(Control c)
        {
            return c is Panel && c.Name == "panel_titulo";
        }

        // ---------------------------------------------------------------- barra de título

        private static void EstilizarBarraTitulo(Panel panel)
        {
            panel.BackColor = PaletaErp.Petroleo;

            Button cerrar = null, maximizar = null, minimizar = null;

            foreach (Control c in panel.Controls)
            {
                var etiqueta = c as Label;
                if (etiqueta != null)
                {
                    etiqueta.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    etiqueta.ForeColor = Color.White;
                    etiqueta.BackColor = Color.Transparent;
                    continue;
                }

                var boton = c as Button;
                if (boton == null) continue;

                if (boton.Name == "button_cerrar") cerrar = boton;
                else if (boton.Name == "button_min_max") maximizar = boton;
                else if (boton.Name == "button_minimizar") minimizar = boton;
            }

            // Se alinean pegados en la esquina, de derecha a izquierda. No todos los
            // formularios tienen los tres, así que se colocan solo los que existan.
            var botones = new System.Collections.Generic.List<Button>();
            var iconos = new System.Collections.Generic.List<IconoVentana>();

            if (cerrar != null) { botones.Add(cerrar); iconos.Add(IconoVentana.Cerrar); }
            if (maximizar != null) { botones.Add(maximizar); iconos.Add(IconoVentana.Maximizar); }
            if (minimizar != null) { botones.Add(minimizar); iconos.Add(IconoVentana.Minimizar); }

            if (botones.Count == 0) return;

            const int ancho = 46, alto = 30;
            int y = Math.Max(0, (panel.Height - alto) / 2);
            int derecha = botones[0].Right;

            for (int i = 0; i < botones.Count; i++)
            {
                botones[i].SetBounds(derecha - ancho * (i + 1), y, ancho, alto);
                EstilizarBotonVentana(botones[i], iconos[i]);
            }
        }

        private enum IconoVentana { Minimizar, Maximizar, Cerrar }

        /// <summary>
        /// Los glifos de texto (— ❐ ✕) salen finos y de tamaños distintos según la
        /// fuente, así que los iconos se dibujan con líneas.
        /// </summary>
        private static void EstilizarBotonVentana(Button b, IconoVentana icono)
        {
            bool esCerrar = icono == IconoVentana.Cerrar;

            b.BackgroundImage = null;
            b.Text = "";
            b.BackColor = PaletaErp.Petroleo;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = esCerrar ? PaletaErp.Peligro : PaletaErp.PetroleoClaro;
            b.FlatAppearance.MouseDownBackColor = esCerrar ? Color.FromArgb(180, 40, 40) : PaletaErp.Acento;
            b.Cursor = Cursors.Hand;
            b.TabStop = false;
            b.UseVisualStyleBackColor = false;
            b.Tag = icono;

            b.Paint -= BotonVentanaPaint;
            b.Paint += BotonVentanaPaint;
        }

        private static void BotonVentanaPaint(object sender, PaintEventArgs e)
        {
            var b = (Button)sender;
            if (!(b.Tag is IconoVentana)) return;

            var icono = (IconoVentana)b.Tag;
            var g = e.Graphics;

            const int lado = 10;
            int x = (b.Width - lado) / 2;
            int y = (b.Height - lado) / 2;

            var modo = g.SmoothingMode;
            g.SmoothingMode = icono == IconoVentana.Cerrar
                ? System.Drawing.Drawing2D.SmoothingMode.AntiAlias
                : System.Drawing.Drawing2D.SmoothingMode.None;

            using (var p = new Pen(Color.White, 1.2f))
            {
                switch (icono)
                {
                    case IconoVentana.Minimizar:
                        g.DrawLine(p, x, y + lado / 2, x + lado, y + lado / 2);
                        break;
                    case IconoVentana.Maximizar:
                        g.DrawRectangle(p, x, y, lado - 1, lado - 1);
                        break;
                    case IconoVentana.Cerrar:
                        g.DrawLine(p, x, y, x + lado, y + lado);
                        g.DrawLine(p, x + lado, y, x, y + lado);
                        break;
                }
            }

            g.SmoothingMode = modo;
        }

        // ---------------------------------------------------------------- barra de acciones

        private static void EstilizarBarraAcciones(ToolStrip barra)
        {
            barra.Renderer = new BarraAccionesRenderer();
            barra.BackColor = PaletaErp.Tarjeta;
            barra.GripStyle = ToolStripGripStyle.Hidden;
            barra.ImageScalingSize = new Size(22, 22);
            barra.Font = new Font("Segoe UI", 9.5F);
            barra.Padding = new Padding(10, 3, 10, 3);

            // Cada icono venía como botón y su texto como etiqueta aparte, así que
            // el resaltado solo cubría el icono. Aquí se juntan en un mismo botón.
            ToolStripButton ultimo = null;

            foreach (ToolStripItem item in barra.Items)
            {
                if (item is ToolStripButton)
                {
                    ultimo = (ToolStripButton)item;
                    ultimo.Font = new Font("Segoe UI", 9.5F);
                    ultimo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    ultimo.TextImageRelation = TextImageRelation.ImageBeforeText;
                    ultimo.Padding = new Padding(8, 0, 12, 0);
                    ultimo.Margin = new Padding(0, 1, 4, 2);
                    ultimo.AutoSize = true;
                }
                else if (item is ToolStripLabel)
                {
                    if (ultimo != null && !string.IsNullOrEmpty(item.Text))
                        ultimo.Text = item.Text;

                    item.Visible = false;
                }
                else if (item is ToolStripSeparator)
                {
                    item.Visible = false;
                }
            }
        }

        // ---------------------------------------------------------------- contenido

        private static void Estilizar(Control c)
        {
            var grilla = c as DataGridView;
            if (grilla != null) { EnmarcarGrilla(grilla); EstilizarGrilla(grilla); return; }

            var cajaGuna = c as Guna.UI2.WinForms.Guna2TextBox;
            if (cajaGuna != null) { EstilizarCajaGuna(cajaGuna); return; }

            var comboGuna = c as Guna.UI2.WinForms.Guna2ComboBox;
            if (comboGuna != null) { EstilizarComboGuna(comboGuna); return; }

            var fechaGuna = c as Guna.UI2.WinForms.Guna2DateTimePicker;
            if (fechaGuna != null) { EstilizarFechaGuna(fechaGuna); return; }

            var botonGuna = c as Guna.UI2.WinForms.Guna2Button;
            if (botonGuna != null) { EstilizarBotonGuna(botonGuna); return; }

            var caja = c as TextBox;
            if (caja != null)
            {
                caja.BorderStyle = BorderStyle.FixedSingle;
                caja.BackColor = Color.White;
                caja.ForeColor = PaletaErp.Texto;
                caja.Font = new Font("Segoe UI", 9F);
                AjustarAlto(caja);
                return;
            }

            var combo = c as ComboBox;
            if (combo != null)
            {
                combo.FlatStyle = FlatStyle.Flat;
                combo.BackColor = Color.White;
                combo.ForeColor = PaletaErp.Texto;
                combo.Font = new Font("Segoe UI", 9F);
                return;
            }

            var fecha = c as DateTimePicker;
            if (fecha != null)
            {
                fecha.Font = new Font("Segoe UI", 9F);
                fecha.CalendarMonthBackground = Color.White;
                fecha.CalendarTitleBackColor = PaletaErp.Petroleo;
                fecha.CalendarTitleForeColor = Color.White;
                return;
            }

            var interruptor = c as Guna.UI2.WinForms.Guna2ToggleSwitch;
            if (interruptor != null)
            {
                interruptor.CheckedState.FillColor = PaletaErp.Acento;
                interruptor.CheckedState.InnerColor = Color.White;
                interruptor.UncheckedState.FillColor = Color.FromArgb(205, 213, 222);
                interruptor.UncheckedState.InnerColor = Color.White;
                return;
            }

            var check = c as CheckBox;
            if (check != null)
            {
                check.Font = new Font("Segoe UI", 9F);
                check.ForeColor = PaletaErp.Texto;
                return;
            }

            var radio = c as RadioButton;
            if (radio != null)
            {
                radio.Font = new Font("Segoe UI", 9F);
                radio.ForeColor = PaletaErp.Texto;
                return;
            }

            var grupo = c as GroupBox;
            if (grupo != null)
            {
                grupo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                grupo.ForeColor = PaletaErp.Petroleo;
                grupo.BackColor = PaletaErp.Tarjeta;
                return;
            }

            var pestanas = c as TabControl;
            if (pestanas != null)
            {
                pestanas.Font = new Font("Segoe UI", 9.5F);
                foreach (TabPage pagina in pestanas.TabPages)
                    pagina.BackColor = PaletaErp.Tarjeta;
                return;
            }

            var etiqueta2 = c as Label;
            if (etiqueta2 != null)
            {
                etiqueta2.Font = new Font("Segoe UI", 9F);
                etiqueta2.ForeColor = PaletaErp.Etiqueta;
                return;
            }

            var panel = c as Panel;
            if (panel != null)
            {
                // Fondo celeste claro; lo que va encima (grillas, grupos) es blanco.
                if (panel.BackColor == SystemColors.Control || panel.BackColor == Color.White)
                    panel.BackColor = PaletaErp.Fondo;
                return;
            }

            var boton = c as Button;
            if (boton != null)
            {
                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.Cursor = Cursors.Hand;

                // Solo los botones con texto reciben relleno; los de puro icono
                // conservan su imagen.
                if (!string.IsNullOrWhiteSpace(boton.Text) && boton.BackgroundImage == null)
                {
                    bool destructivo = boton.Text.IndexOf("ELIMINAR", StringComparison.OrdinalIgnoreCase) >= 0;

                    boton.BackColor = destructivo ? PaletaErp.Peligro : PaletaErp.Acento;
                    boton.ForeColor = Color.White;
                    boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    boton.FlatAppearance.MouseOverBackColor = destructivo
                        ? Color.FromArgb(200, 48, 48)
                        : PaletaErp.AcentoClaro;
                    boton.UseVisualStyleBackColor = false;
                }
                return;
            }
        }

        private static void AjustarAlto(Control c)
        {
            int alto = Math.Max(AltoMinCampo, Math.Min(AltoMaxCampo, EspacioAbajo(c) - 4));
            if (c.Height < alto) c.Height = alto;
        }

        /// <summary>
        /// Espacio libre hasta el siguiente control que se cruza en horizontal, para
        /// no encimar los campos al darles más alto.
        /// </summary>
        private static int EspacioAbajo(Control c)
        {
            if (c.Parent == null) return AltoMaxCampo;

            int libre = Math.Max(c.Height, c.Parent.ClientSize.Height - c.Top);

            foreach (Control o in c.Parent.Controls)
            {
                if (o == c) continue;
                if (o.Top <= c.Top) continue;
                if (!MismaColumna(c, o)) continue;

                libre = Math.Min(libre, o.Top - c.Top);
            }

            return libre;
        }

        private static void EstilizarCajaGuna(Guna.UI2.WinForms.Guna2TextBox caja)
        {
            caja.BorderRadius = 6;
            caja.BorderThickness = 1;
            caja.BorderColor = PaletaErp.Borde;
            caja.FillColor = Color.White;
            caja.ForeColor = PaletaErp.Texto;
            caja.Font = new Font("Segoe UI", 9F);
            caja.Animated = true;
            caja.HoverState.BorderColor = PaletaErp.BordeFuerte;
            caja.FocusedState.BorderColor = PaletaErp.Acento;
            caja.FocusedState.FillColor = Color.White;
            caja.DisabledState.FillColor = Color.White;
            caja.DisabledState.BorderColor = PaletaErp.BordeSuave;
            caja.DisabledState.ForeColor = PaletaErp.TextoApagado;
            AjustarAlto(caja);
        }

        private static void EstilizarComboGuna(Guna.UI2.WinForms.Guna2ComboBox combo)
        {
            combo.BorderRadius = 6;
            combo.BorderThickness = 1;
            combo.BorderColor = PaletaErp.Borde;
            combo.FillColor = Color.White;
            combo.BackColor = Color.Transparent;
            combo.ForeColor = PaletaErp.Texto;
            combo.Font = new Font("Segoe UI", 9F);
            combo.ItemHeight = 24;
            combo.HoverState.BorderColor = PaletaErp.BordeFuerte;
            combo.FocusedState.BorderColor = PaletaErp.Acento;
            combo.FocusedColor = PaletaErp.Acento;
            combo.DisabledState.FillColor = Color.White;
            combo.DisabledState.BorderColor = PaletaErp.BordeSuave;
            combo.DisabledState.ForeColor = PaletaErp.TextoApagado;

            // El alto del combo de Guna lo manda ItemHeight, así que no basta con
            // asignar Height: hay que bajar ItemHeight o se queda con su mínimo y
            // termina pisando lo que tenga debajo.
            int alto = Math.Max(AltoMinCampo, Math.Min(AltoMaxCampo, EspacioAbajo(combo) - 4));
            combo.ItemHeight = Math.Max(16, alto - 6);
            if (combo.Height > alto) combo.Height = alto;

            AjustarAnchoCombo(combo);
        }

        private static void EstilizarFechaGuna(Guna.UI2.WinForms.Guna2DateTimePicker fecha)
        {
            fecha.BorderRadius = 6;
            fecha.BorderThickness = 1;
            fecha.BorderColor = PaletaErp.Borde;
            fecha.FillColor = Color.White;
            fecha.ForeColor = PaletaErp.Texto;
            fecha.Font = new Font("Segoe UI", 9F);
            fecha.HoverState.BorderColor = PaletaErp.BordeFuerte;
            AjustarAlto(fecha);

            // Guna dibuja un icono de calendario a la izquierda y la flecha a la
            // derecha, así que necesita más ancho que el DateTimePicker nativo.
            const int adornos = 52;

            int necesario = TextRenderer.MeasureText(fecha.Text ?? "", fecha.Font).Width + adornos;
            int ancho = Math.Min(necesario, EspacioDerecha(fecha) - 8);
            if (ancho > fecha.Width) fecha.Width = ancho;

            // Si aun así no cabe (filas con la etiqueta siguiente pegada), se baja
            // el tamaño de letra antes que dejar la fecha cortada.
            float puntos = fecha.Font.Size;
            while (puntos > 7.5f &&
                   TextRenderer.MeasureText(fecha.Text ?? "", fecha.Font).Width + adornos > fecha.Width)
            {
                puntos -= 0.5f;
                fecha.Font = new Font(fecha.Font.FontFamily, puntos, fecha.Font.Style);
            }
        }

        /// <summary>
        /// El combo de Guna reserva más ancho para la flecha que el nativo, así que
        /// se ensancha lo necesario para su opción más larga, sin pasarse del control
        /// que tenga al lado.
        /// </summary>
        /// <summary>
        /// Espacio que el combo de Guna reserva para la flecha y los márgenes.
        /// Medido a ojo comparando renders: por debajo de 40 empieza a recortar.
        /// </summary>
        private const int AdornosCombo = 42;

        /// <summary>Ancho del texto más largo que puede mostrar el combo.</summary>
        private static int TextoMasLargo(Guna.UI2.WinForms.Guna2ComboBox combo)
        {
            int ancho = TextRenderer.MeasureText(combo.Text ?? "", combo.Font).Width;

            var tabla = combo.DataSource as System.Data.DataTable;
            if (tabla != null && !string.IsNullOrEmpty(combo.DisplayMember)
                && tabla.Columns.Contains(combo.DisplayMember))
            {
                foreach (System.Data.DataRow fila in tabla.Rows)
                {
                    int w = TextRenderer.MeasureText(Convert.ToString(fila[combo.DisplayMember]), combo.Font).Width;
                    if (w > ancho) ancho = w;
                }
            }
            else
            {
                foreach (object item in combo.Items)
                {
                    int w = TextRenderer.MeasureText(combo.GetItemText(item), combo.Font).Width;
                    if (w > ancho) ancho = w;
                }
            }

            return ancho;
        }

        private static void AjustarAnchoCombo(Guna.UI2.WinForms.Guna2ComboBox combo)
        {
            int necesario = TextoMasLargo(combo) + AdornosCombo;

            // 1) Ensanchar hasta donde llegue el hueco libre de la fila.
            int ancho = Math.Min(necesario, EspacioDerecha(combo) - 8);
            if (ancho > combo.Width) combo.Width = ancho;

            // 2) Si no basta, correr hacia la derecha lo que va después en la misma
            //    fila. Es lo que haría cualquiera a mano y casi siempre sobra sitio.
            if (necesario > combo.Width) CorrerFila(combo, necesario - combo.Width);

            // 3) Si la caja es estrecha y no hay a dónde crecer, se ajusta la letra
            //    al valor que se está mostrando, que es lo que el usuario ve.
            AjustarLetraCombo(combo);

            // 4) Si algún otro valor de la lista sigue sin entrar, se mantiene el
            //    texto completo accesible y se reajusta al cambiar de selección.
            if (TextoMasLargo(combo) + AdornosCombo > combo.Width)
            {
                _pistas.SetToolTip(combo, combo.Text);
                combo.SelectedIndexChanged -= ComboCambio;
                combo.SelectedIndexChanged += ComboCambio;
            }
        }

        /// <summary>Reduce la letra lo justo para que el valor mostrado entre entero.</summary>
        private static void AjustarLetraCombo(Guna.UI2.WinForms.Guna2ComboBox combo)
        {
            float puntos = combo.Font.Size;

            while (puntos > 7.75f &&
                   TextRenderer.MeasureText(combo.Text ?? "", combo.Font).Width + AdornosCombo > combo.Width)
            {
                puntos -= 0.25f;
                combo.Font = new Font(combo.Font.FontFamily, puntos, combo.Font.Style);
            }
        }

        private static readonly ToolTip _pistas = new ToolTip();

        private static void ComboCambio(object sender, EventArgs e)
        {
            var combo = (Guna.UI2.WinForms.Guna2ComboBox)sender;
            _pistas.SetToolTip(combo, combo.Text);
            AjustarLetraCombo(combo);
        }

        /// <summary>
        /// Desplaza a la derecha los controles que siguen en la misma fila para
        /// hacerle sitio al campo. Si el movimiento acaba encimando algo (hay
        /// diseños donde las "filas" no son tan regulares como parecen), se deshace:
        /// es preferible un texto recortado a dos controles superpuestos.
        /// </summary>
        private static void CorrerFila(Control campo, int falta)
        {
            var padre = campo.Parent;
            if (!MoverFilas || padre == null || falta <= 0) return;

            var derecha = new System.Collections.Generic.List<Control>();
            int masDerecha = campo.Right;

            foreach (Control o in padre.Controls)
            {
                if (o == campo) continue;
                if (o.Left < campo.Right) continue;   // no está después
                if (!MismaFila(campo, o)) continue;   // otra fila

                derecha.Add(o);
                if (o.Right > masDerecha) masDerecha = o.Right;
            }

            int mover = Math.Min(falta, padre.ClientSize.Width - 10 - masDerecha);
            if (mover <= 0) return;

            int solapesAntes = ContarSolapes(padre);
            var posiciones = new System.Collections.Generic.List<int>();
            foreach (Control o in derecha) posiciones.Add(o.Left);
            int anchoAntes = campo.Width;

            foreach (Control o in derecha) o.Left += mover;
            campo.Width += mover;

            if (ContarSolapes(padre) > solapesAntes)
            {
                for (int i = 0; i < derecha.Count; i++) derecha[i].Left = posiciones[i];
                campo.Width = anchoAntes;
            }
        }

        /// <summary>Pares de controles visibles que se pisan dentro del contenedor.</summary>
        private static int ContarSolapes(Control padre)
        {
            var hijos = new System.Collections.Generic.List<Control>();
            foreach (Control c in padre.Controls)
                if (c.Visible) hijos.Add(c);

            int n = 0;
            for (int i = 0; i < hijos.Count; i++)
                for (int j = i + 1; j < hijos.Count; j++)
                {
                    var r = Rectangle.Intersect(hijos[i].Bounds, hijos[j].Bounds);
                    if (r.Width > 1 && r.Height > 1) n++;
                }

            return n;
        }

        private static void EstilizarBotonGuna(Guna.UI2.WinForms.Guna2Button boton)
        {
            bool destructivo = boton.Text.IndexOf("ELIMINAR", StringComparison.OrdinalIgnoreCase) >= 0;

            boton.BorderRadius = 6;
            boton.Animated = true;
            boton.Cursor = Cursors.Hand;
            boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            boton.ForeColor = Color.White;
            boton.FillColor = destructivo ? PaletaErp.Peligro : PaletaErp.Acento;
            boton.HoverState.FillColor = destructivo ? Color.FromArgb(200, 48, 48) : PaletaErp.AcentoClaro;
            boton.HoverState.ForeColor = Color.White;
            boton.DisabledState.FillColor = Color.FromArgb(226, 230, 236);
            boton.DisabledState.ForeColor = PaletaErp.TextoApagado;
        }


        // ------------------------------------------- cabeceras de sección (chips)

        private static readonly Color CabezaFondo = Color.FromArgb(227, 237, 240);
        private static readonly Color CabezaFondoHover = Color.FromArgb(211, 228, 233);
        private static readonly Color CabezaFranja = Color.FromArgb(210, 166, 46);
        private static readonly Color CabezaTexto = Color.FromArgb(23, 90, 107);

        private static readonly System.Collections.Generic.HashSet<Button> _cabecerasEncima =
            new System.Collections.Generic.HashSet<Button>();

        /// <summary>
        /// Convierte un botón que hace de cabecera de sección en un chip claro con
        /// una franja dorada a la izquierda. Un Button no puede dibujar esa forma,
        /// así que se pinta a mano.
        /// </summary>
        public static void EstilizarCabeceraSeccion(Button b)
        {
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = PaletaErp.Fondo;
            b.ForeColor = CabezaTexto;
            b.Cursor = Cursors.Hand;
            b.TabStop = false;
            b.UseVisualStyleBackColor = false;
            if (b.Height < 40) b.Height = 40;

            b.MouseEnter -= CabeceraMouseEnter;
            b.MouseLeave -= CabeceraMouseLeave;
            b.Paint -= CabeceraPaint;

            b.MouseEnter += CabeceraMouseEnter;
            b.MouseLeave += CabeceraMouseLeave;
            b.Paint += CabeceraPaint;
        }

        private static void CabeceraMouseEnter(object sender, EventArgs e)
        {
            var b = (Button)sender;
            _cabecerasEncima.Add(b);
            b.Invalidate();
        }

        private static void CabeceraMouseLeave(object sender, EventArgs e)
        {
            var b = (Button)sender;
            _cabecerasEncima.Remove(b);
            b.Invalidate();
        }

        private static void CabeceraPaint(object sender, PaintEventArgs e)
        {
            var b = (Button)sender;
            var g = e.Graphics;

            // Se tapa lo que dibujó el Button (fondo y texto) y se repinta todo.
            using (var fondo = new SolidBrush(PaletaErp.Fondo))
                g.FillRectangle(fondo, b.ClientRectangle);

            var chip = new Rectangle(10, 2, b.Width - 20, b.Height - 4);
            if (chip.Width <= 12 || chip.Height <= 4) return;

            var modo = g.SmoothingMode;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var path = PaletaErp.Redondeado(chip, 6))
            {
                var color = _cabecerasEncima.Contains(b) ? CabezaFondoHover : CabezaFondo;
                using (var relleno = new SolidBrush(color))
                    g.FillPath(relleno, path);

                // La franja se recorta contra el chip para heredar sus esquinas.
                var recorte = g.Clip;
                g.SetClip(path);
                using (var franja = new SolidBrush(CabezaFranja))
                    g.FillRectangle(franja, chip.X, chip.Y, 5, chip.Height);
                g.Clip = recorte;
            }

            g.SmoothingMode = modo;

            var texto = new Rectangle(chip.X + 18, chip.Y, chip.Width - 26, chip.Height);
            TextRenderer.DrawText(g, b.Text, b.Font, texto, CabezaTexto,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        // ---------------------------------------------------------------- grilla


        /// <summary>
        /// Mete la grilla en una tarjeta blanca de borde redondeado, la estira hasta
        /// donde haya sitio libre y la ancla a los cuatro lados para que acompañe al
        /// tamaño de la ventana. El borde de la tarjeta es lo que le da los extremos
        /// definidos a la cabecera.
        /// </summary>
        private static void EnmarcarGrilla(DataGridView g)
        {
            var padre = g.Parent;
            if (padre == null || padre is Guna.UI2.WinForms.Guna2Panel) return;

            const int margen = 14;

            // Si algún campo de arriba creció al estilizarlo y ahora invade el borde
            // de la grilla, esta arranca más abajo en lugar de quedar pisada.
            int techo = 0;
            foreach (Control o in padre.Controls)
            {
                if (o == g || o.Top >= g.Top) continue;
                if (!MismaColumna(g, o)) continue;
                if (o.Bottom > techo) techo = o.Bottom;
            }

            int arriba = g.Top;
            if (techo > 0 && techo + 6 > arriba) arriba = techo + 6;
            int recorte = arriba - g.Top;

            // Se mide antes de reparentar, mientras la grilla sigue entre sus hermanos.
            int ancho = Math.Max(g.Width, EspacioDerecha(g) - margen);
            int alto = Math.Max(g.Height, EspacioAbajo(g) - margen) - recorte;

            var tarjeta = new Guna.UI2.WinForms.Guna2Panel();
            tarjeta.Name = g.Name + "_tarjeta";
            tarjeta.Location = new Point(g.Left, arriba);
            tarjeta.Size = new Size(ancho, alto);
            tarjeta.BorderRadius = 8;
            tarjeta.BorderThickness = 1;
            tarjeta.BorderColor = PaletaErp.BordeSuave;
            tarjeta.CustomBorderColor = PaletaErp.BordeSuave;
            tarjeta.FillColor = Color.White;
            tarjeta.Padding = new Padding(1);
            tarjeta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                           | AnchorStyles.Left | AnchorStyles.Right;

            int indice = padre.Controls.GetChildIndex(g);

            padre.Controls.Remove(g);
            g.Dock = DockStyle.Fill;
            tarjeta.Controls.Add(g);

            padre.Controls.Add(tarjeta);
            padre.Controls.SetChildIndex(tarjeta, indice);
        }


        /// <summary>
        /// Dos controles están en la misma fila si se cruzan en vertical de forma
        /// apreciable. Un roce de unos píxeles entre filas contiguas no cuenta: si
        /// contara, mover una fila arrastraría controles de la de al lado.
        /// </summary>
        private static bool MismaFila(Control a, Control b)
        {
            int cruce = Math.Min(a.Bottom, b.Bottom) - Math.Max(a.Top, b.Top);
            return cruce > Math.Min(a.Height, b.Height) * 0.6;
        }

        /// <summary>Se cruzan en horizontal lo suficiente como para estorbarse.</summary>
        private static bool MismaColumna(Control a, Control b)
        {
            int cruce = Math.Min(a.Right, b.Right) - Math.Max(a.Left, b.Left);
            return cruce > 8;
        }

        /// <summary>Espacio libre hacia la derecha hasta el siguiente control de la fila.</summary>
        private static int EspacioDerecha(Control c)
        {
            if (c.Parent == null) return c.Width;

            int libre = Math.Max(c.Width, c.Parent.ClientSize.Width - c.Left);

            foreach (Control o in c.Parent.Controls)
            {
                if (o == c) continue;
                if (o.Left < c.Right) continue;
                if (!MismaFila(c, o)) continue;

                libre = Math.Min(libre, o.Left - c.Left);
            }

            return libre;
        }

        public static void EstilizarGrilla(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.EnableHeadersVisualStyles = false;
            g.GridColor = PaletaErp.BordeSuave;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.RowHeadersVisible = false;
            g.AllowUserToResizeRows = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.RowTemplate.Height = 30;

            g.ColumnHeadersDefaultCellStyle.BackColor = PaletaErp.CabeceraGrilla;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = PaletaErp.CabeceraGrilla;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            g.ColumnHeadersHeight = 36;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.ForeColor = PaletaErp.Texto;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            g.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            // Selección suave: fondo celeste claro y el texto en su color normal.
            g.DefaultCellStyle.SelectionBackColor = PaletaErp.FilaSeleccionada;
            g.DefaultCellStyle.SelectionForeColor = PaletaErp.Texto;
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 250);
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = PaletaErp.FilaSeleccionada;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = PaletaErp.Texto;

            // Las columnas reparten el ancho de la tarjeta en vez de dejar un hueco
            // blanco a la derecha. Con un ancho mínimo por columna, si no entran
            // todas aparece la barra horizontal en lugar de quedar ilegibles.
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in g.Columns)
                AnchoMinimoColumna(col);

            g.ColumnAdded -= GrillaColumnaAgregada;
            g.ColumnAdded += GrillaColumnaAgregada;

            // Al abrir, la fila de nueva entrada aparecía seleccionada y dejaba una
            // banda de color bajo la cabecera en las grillas vacías.
            g.ClearSelection();
        }

        private static void GrillaColumnaAgregada(object sender, DataGridViewColumnEventArgs e)
        {
            AnchoMinimoColumna(e.Column);
        }

        private static void AnchoMinimoColumna(DataGridViewColumn col)
        {
            if (col.MinimumWidth < 90) col.MinimumWidth = 90;
        }
    }
}
