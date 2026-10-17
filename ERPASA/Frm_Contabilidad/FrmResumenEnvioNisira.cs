using ERPASA.Estilos;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Frm_Contabilidad
{
    /// <summary>
    /// Previsualización genérica antes de enviar/validar registros contra un
    /// API externo. Se construye 100% por código (sin Designer/.resx), igual
    /// que otros formularios auxiliares de este proyecto (ver "viewer" en
    /// Frm_RindeGastoNisiraAPI.cargarFoto).
    ///
    /// Muestra TODAS las columnas reales de las filas seleccionadas - no
    /// depende de conocer de antemano los nombres de columna del origen.
    /// </summary>
    public class FrmResumenEnvioNisira : Form
    {
        private readonly Guna2DataGridView dgv;
        private readonly Label lblTotales;
        private readonly Button btnEnviar;
        private readonly Button btnCancelar;
        private readonly Button btnVerJson;

        /// <param name="obtenerJson">
        /// Devuelve el cuerpo JSON que se mandaria al API. Si viene, aparece el
        /// boton "Ver JSON" al costado de Cancelar. Se pasa como funcion y no
        /// como texto para armarlo solo si el usuario lo pide: con muchas filas
        /// serializar todo cuesta.
        /// </param>
        public FrmResumenEnvioNisira(DataTable resumen, string titulo, string textoBoton = "Enviar",
            string columnaImporte = null, Func<string> obtenerJson = null)
        {
            Text = titulo;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(820, 420);
            MinimumSize = new Size(560, 300);

            dgv = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                DataSource = resumen
            };

            var panelInferior = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 56
            };

            lblTotales = new Label
            {
                Dock = DockStyle.Left,
                Width = 500,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            int filas = resumen?.Rows.Count ?? 0;
            string totalTxt = $"Registros seleccionados: {filas}";

            if (!string.IsNullOrEmpty(columnaImporte) && resumen != null && resumen.Columns.Contains(columnaImporte))
            {
                decimal total = 0;
                foreach (DataRow r in resumen.Rows)
                {
                    decimal.TryParse(r[columnaImporte]?.ToString(), out decimal val);
                    total += val;
                }
                totalTxt += $"      Importe total: {total:N2}";
            }

            lblTotales.Text = totalTxt;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Dock = DockStyle.Right,
                Width = 110
            };

            btnEnviar = new Button
            {
                Text = textoBoton,
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Right,
                Width = 130
            };

            panelInferior.Controls.Add(lblTotales);

            // Se agrega antes que Cancelar para que quede a su izquierda: con
            // Dock.Right, el ultimo agregado es el que va mas a la derecha.
            if (obtenerJson != null)
            {
                // Separador: deja aire entre el texto de totales y el boton.
                panelInferior.Controls.Add(new Panel
                {
                    Dock = DockStyle.Right,
                    Width = 24
                });

                btnVerJson = new Button
                {
                    Text = "Ver JSON",
                    Dock = DockStyle.Right,
                    Width = 130
                };

                btnVerJson.Click += delegate { MostrarJson(obtenerJson); };
                panelInferior.Controls.Add(btnVerJson);
            }

            panelInferior.Controls.Add(btnCancelar);
            panelInferior.Controls.Add(btnEnviar);

            Controls.Add(dgv);
            Controls.Add(panelInferior);

            AcceptButton = btnEnviar;
            CancelButton = btnCancelar;

            // Identidad visual del ERP (misma línea que el resto de formularios).
            // El color va DESPUES del estilizador: el estilizador pinta todos
            // los botones con texto del mismo acento, y aca cada uno necesita
            // el suyo para distinguirse de un vistazo.
            Load += delegate
            {
                EstilizadorErp.Aplicar(this);
                ColorearBotones();
            };
        }

        /// <summary>
        /// Un color por tipo de acción: la confirmación en el acento del ERP,
        /// la consulta en petróleo y cancelar en gris, que no compite.
        /// </summary>
        private void ColorearBotones()
        {
            Pintar(btnEnviar, PaletaErp.Acento, Color.White, PaletaErp.AcentoClaro);
            Pintar(btnVerJson, PaletaErp.Petroleo, Color.White, PaletaErp.PetroleoClaro);
            Pintar(btnCancelar, PaletaErp.Borde, PaletaErp.Texto, PaletaErp.BordeFuerte);
        }

        private static void Pintar(Button boton, Color fondo, Color texto, Color hover)
        {
            if (boton == null) return;

            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.UseVisualStyleBackColor = false;
            boton.BackColor = fondo;
            boton.ForeColor = texto;
            boton.FlatAppearance.MouseOverBackColor = hover;
            boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Abre el cuerpo JSON en una ventana aparte, con opcion de copiarlo o
        /// guardarlo como archivo de texto.
        /// </summary>
        private void MostrarJson(Func<string> obtenerJson)
        {
            string json;

            try
            {
                Cursor = Cursors.WaitCursor;
                json = obtenerJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo armar el JSON:\n\n" + ex.Message,
                    "VER JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            using (var visor = new Form())
            {
                visor.Text = "JSON que se enviará al API de NISIRA";
                visor.StartPosition = FormStartPosition.CenterParent;
                visor.ClientSize = new Size(900, 600);
                visor.MinimumSize = new Size(500, 350);

                var caja = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Both,
                    WordWrap = false,
                    Font = new Font("Consolas", 9.5F),
                    Text = json
                };

                var barra = new Panel { Dock = DockStyle.Bottom, Height = 48 };

                var btnCerrar = new Button
                {
                    Text = "Cerrar",
                    Dock = DockStyle.Right,
                    Width = 110,
                    DialogResult = DialogResult.OK
                };

                var btnGuardar = new Button { Text = "Guardar .txt", Dock = DockStyle.Right, Width = 120 };
                btnGuardar.Click += delegate { GuardarJson(json); };

                var btnCopiar = new Button { Text = "Copiar", Dock = DockStyle.Right, Width = 110 };
                btnCopiar.Click += delegate
                {
                    if (!string.IsNullOrEmpty(json)) Clipboard.SetText(json);
                };

                barra.Controls.Add(btnCopiar);
                barra.Controls.Add(btnGuardar);
                barra.Controls.Add(btnCerrar);

                visor.Controls.Add(caja);
                visor.Controls.Add(barra);
                visor.CancelButton = btnCerrar;

                caja.Select(0, 0);
                visor.ShowDialog(this);
            }
        }

        private void GuardarJson(string json)
        {
            using (var guardar = new SaveFileDialog())
            {
                guardar.Title = "Guardar el JSON de envío";
                guardar.Filter = "Texto (*.txt)|*.txt|JSON (*.json)|*.json|Todos los archivos|*.*";
                guardar.FileName = "nisira_liquidacion_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

                if (guardar.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    System.IO.File.WriteAllText(guardar.FileName, json, System.Text.Encoding.UTF8);
                    MessageBox.Show("Guardado en:\n" + guardar.FileName,
                        "VER JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar:\n\n" + ex.Message,
                        "VER JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
