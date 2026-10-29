using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Patrimonial
{
    /// <summary>
    /// REPORTE DE VISITAS (PV_Visitas).
    ///
    /// Misma mecanica que Frm_ReporteOrdenTrabajo: los filtros de arriba
    /// acotan la consulta, "Buscar" trae los datos en segundo plano y el
    /// cuadro Search filtra sobre lo ya traido sin volver a la base.
    /// </summary>
    public partial class Frm_ReporteVisitasPv1 : Form
    {

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();

        // Resultado de la ultima busqueda: sobre el trabaja el filtro de texto.
        DataTable dtg2;
        private CancellationTokenSource _cts;

        public Frm_ReporteVisitasPv1()
        {
            InitializeComponent();
            // Los iconos de la barra se toman de otras pantallas: asi este
            // formulario no necesita su propio archivo de recursos.
            Frm_Acopio.Frm_Maestros.IconosMaestro.Aplicar(toolStrip2);
            // El de PDF no existe en las otras pantallas, asi que se dibuja.
            toolStripButton_pdf.Image = IconoPdf(32);
            // Identidad visual del ERP (barra de titulo, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ReporteVisitasPv1_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();

            // Arranca mostrando el mes en curso.
            dateTimePicker_FechaIni.Value = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            dateTimePicker_FechaFin.Value = DateTime.Today;
        }

        public void PonerOscuroComboBox()
        {
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            }
            else
            {
                comboBox_detalle_sede.DataSource =
                    cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_detalle_empresa.Text);
            }

            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        /// <summary>
        /// Trae los datos. Corre en un hilo aparte, por eso lee los controles
        /// con Invoke cuando hace falta.
        /// </summary>
        public void BuscarReporte()
        {
            string empText = string.Empty, sedText = string.Empty;
            DateTime fecIni = DateTime.Today, fecFin = DateTime.Today;

            if (comboBox_detalle_empresa.InvokeRequired)
                comboBox_detalle_empresa.Invoke(new MethodInvoker(() =>
                { empText = comboBox_detalle_empresa.Text; }));
            else
                empText = comboBox_detalle_empresa.Text;

            if (comboBox_detalle_sede.InvokeRequired)
                comboBox_detalle_sede.Invoke(new MethodInvoker(() =>
                { sedText = comboBox_detalle_sede.Text; }));
            else
                sedText = comboBox_detalle_sede.Text;

            if (dateTimePicker_FechaIni.InvokeRequired)
                dateTimePicker_FechaIni.Invoke(new MethodInvoker(() =>
                { fecIni = dateTimePicker_FechaIni.Value.Date; }));
            else
                fecIni = dateTimePicker_FechaIni.Value.Date;

            if (dateTimePicker_FechaFin.InvokeRequired)
                dateTimePicker_FechaFin.Invoke(new MethodInvoker(() =>
                { fecFin = dateTimePicker_FechaFin.Value.Date; }));
            else
                fecFin = dateTimePicker_FechaFin.Value.Date;

            string emp = empText == "SELECCIONE" ? "%" : empText;
            string sed = sedText == "SELECCIONE" ? "%" : sedText;

            dtg2 = cn_rrhh.ListaReporteVisitasPv1(fecIni, fecFin, emp, sed);
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CargarDatosSync();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;

            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this);

            try
            {
                await Task.Run(() =>
                {
                    BuscarReporte();
                    dataGridView2.ClearSelection();
                });

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg2;
                dataGridView2.AllowUserToAddRows = false;

                // Si quedo texto en el buscador se respeta al recargar.
                AplicarFiltroBusqueda();
                OrigenColorfila();

                if (dataGridView2.Rows.Count == 0)
                {
                    Msbox.Frm_NotificacionesGuardar ng =
                        new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO",
                            Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close();
            }
        }

        // ------------------------------------------------------- EXCEL

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private async void ExportarExcel()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var frbm = new Msbox.frm_dowloadExcel();
            frbm.OnCancelRequested = () => { _cts?.Cancel(); };
            frbm.Show(this);

            try
            {
                await Task.Run(() =>
                {
                    objexcel_progress.exportarexcelTimer(dataGridView2, frbm, token);
                }, token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Exportación cancelada por el usuario.", "Cancelado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        // --------------------------------------------------------- PDF

        private void toolStripButton_pdf_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("PRIMERO BUSQUE LOS REGISTROS",
                        Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
                return;
            }

            ExportarPdf();
        }

        /// <summary>
        /// Lleva a PDF lo que esta viendose en la grilla, con todas sus
        /// columnas y respetando el filtro del buscador.
        ///
        /// El reporte tiene mas de cuarenta columnas, asi que la hoja es A3
        /// apaisada y la letra pequena; los anchos salen de los de la grilla,
        /// para que el PDF se parezca a lo que el usuario tiene en pantalla.
        /// </summary>
        private void ExportarPdf()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "PDF|*.pdf";
            sd.FileName = "ReporteVisitas_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (sd.ShowDialog() != DialogResult.OK) return;

            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;

            try
            {
                List<DataGridViewColumn> columnas = dataGridView2.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (columnas.Count == 0)
                {
                    MessageBox.Show("NO HAY COLUMNAS QUE EXPORTAR");
                    return;
                }

                var documento = new Document(PageSize.A3.Rotate(), 18f, 18f, 22f, 28f);

                using (var archivo = new FileStream(sd.FileName, FileMode.Create))
                {
                    PdfWriter escritor = PdfWriter.GetInstance(documento, archivo);
                    escritor.PageEvent = new PiePagina();

                    documento.Open();
                    documento.Add(Titulo(dataGridView2.Rows.Count));
                    documento.Add(Cuadro(columnas));
                    documento.Close();
                }

                Msbox.Frm_NotificacionesGuardar ng =
                    new Msbox.Frm_NotificacionesGuardar("PDF GENERADO", Color.FromArgb(0, 179, 78), 2);
                ng.Show();

                // Se abre con el lector que tenga el equipo.
                System.Diagnostics.Process.Start(sd.FileName);
            }
            catch (IOException)
            {
                MessageBox.Show("No se pudo escribir el archivo.\n\n" +
                    "Si lo tiene abierto en el lector de PDF, cierrelo y vuelva a intentar.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>Encabezado del documento: titulo, filtros y cantidad.</summary>
        private IElement Titulo(int cantidad)
        {
            var titulo = new Paragraph();

            titulo.Add(new Chunk("REPORTE DE VISITAS\n",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1252, 12f)));

            string empresa = comboBox_detalle_empresa.Text == "SELECCIONE"
                ? "TODAS" : comboBox_detalle_empresa.Text;
            string sede = comboBox_detalle_sede.Text == "SELECCIONE"
                ? "TODAS" : comboBox_detalle_sede.Text;

            string detalle = string.Format(
                "Del {0:dd/MM/yyyy} al {1:dd/MM/yyyy}   |   Empresa: {2}   |   Sede: {3}   |   {4} registros",
                dateTimePicker_FechaIni.Value.Date, dateTimePicker_FechaFin.Value.Date,
                empresa, sede, cantidad);

            titulo.Add(new Chunk(detalle,
                FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1252, 7.5f)));

            titulo.SpacingAfter = 8f;
            return titulo;
        }

        /// <summary>La grilla, con sus encabezados repetidos en cada hoja.</summary>
        private PdfPTable Cuadro(List<DataGridViewColumn> columnas)
        {
            var tabla = new PdfPTable(columnas.Count);
            tabla.WidthPercentage = 100f;
            tabla.HeaderRows = 1;

            // Los anchos de la grilla sirven de proporcion para el PDF.
            float[] anchos = columnas.Select(c => (float)Math.Max(c.Width, 20)).ToArray();
            tabla.SetWidths(anchos);

            var fuenteCabecera = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, BaseFont.CP1252,
                false, 5.5f, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            var fuenteFila = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1252, 5f);
            var fondoCabecera = new BaseColor(45, 66, 90);

            foreach (DataGridViewColumn columna in columnas)
            {
                var celda = new PdfPCell(new Phrase(columna.HeaderText, fuenteCabecera));
                celda.BackgroundColor = fondoCabecera;
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                celda.Padding = 2f;
                tabla.AddCell(celda);
            }

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;

                foreach (DataGridViewColumn columna in columnas)
                {
                    object valor = fila.Cells[columna.Index].Value;
                    string texto = valor == null || valor == DBNull.Value
                        ? "" : valor.ToString().Trim();

                    var celda = new PdfPCell(new Phrase(texto, fuenteFila));
                    celda.Padding = 2f;
                    celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tabla.AddCell(celda);
                }
            }

            return tabla;
        }

        /// <summary>Numero de pagina al pie de cada hoja.</summary>
        private class PiePagina : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter escritor, Document documento)
            {
                var fuente = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1252, 7f);

                ColumnText.ShowTextAligned(escritor.DirectContent, Element.ALIGN_RIGHT,
                    new Phrase("Pagina " + escritor.PageNumber, fuente),
                    documento.PageSize.Width - documento.RightMargin,
                    documento.BottomMargin - 12f, 0);

                ColumnText.ShowTextAligned(escritor.DirectContent, Element.ALIGN_LEFT,
                    new Phrase(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuente),
                    documento.LeftMargin, documento.BottomMargin - 12f, 0);
            }
        }

        /// <summary>
        /// Dibuja el icono de PDF de la barra. Es el unico boton de la
        /// aplicacion que lo usa, asi que se arma aca en vez de agregar un
        /// archivo de recursos solo para una imagen.
        /// </summary>
        private static Bitmap IconoPdf(int lado)
        {
            var mapa = new Bitmap(lado, lado);

            using (Graphics g = Graphics.FromImage(mapa))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.Clear(Color.Transparent);

                // la hoja
                int margen = Math.Max(2, lado / 10);
                var hoja = new System.Drawing.Rectangle(margen, 1, lado - margen * 2, lado - 3);
                int doblez = Math.Max(5, lado / 4);

                using (var camino = new GraphicsPath())
                {
                    camino.AddLines(new[]
                    {
                        new Point(hoja.Left, hoja.Top),
                        new Point(hoja.Right - doblez, hoja.Top),
                        new Point(hoja.Right, hoja.Top + doblez),
                        new Point(hoja.Right, hoja.Bottom),
                        new Point(hoja.Left, hoja.Bottom)
                    });
                    camino.CloseFigure();

                    using (var relleno = new SolidBrush(Color.White))
                    using (var borde = new Pen(Color.FromArgb(150, 150, 150)))
                    {
                        g.FillPath(relleno, camino);
                        g.DrawPath(borde, camino);
                    }
                }

                // la esquina doblada
                using (var esquina = new SolidBrush(Color.FromArgb(210, 210, 210)))
                {
                    g.FillPolygon(esquina, new[]
                    {
                        new Point(hoja.Right - doblez, hoja.Top),
                        new Point(hoja.Right, hoja.Top + doblez),
                        new Point(hoja.Right - doblez, hoja.Top + doblez)
                    });
                }

                // la banda roja con las letras
                var banda = new System.Drawing.Rectangle(hoja.Left, hoja.Bottom - lado / 3,
                                          hoja.Width, lado / 3);
                using (var rojo = new SolidBrush(Color.FromArgb(197, 40, 40)))
                {
                    g.FillRectangle(rojo, banda);
                }

                using (var letra = new System.Drawing.Font("Arial", lado / 4.6f, System.Drawing.FontStyle.Bold,
                           GraphicsUnit.Pixel))
                using (var blanco = new SolidBrush(Color.White))
                using (var centrado = new StringFormat
                       {
                           Alignment = StringAlignment.Center,
                           LineAlignment = StringAlignment.Center
                       })
                {
                    g.DrawString("PDF", letra, blanco, banda, centrado);
                }
            }

            return mapa;
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
            OrigenColorfila();
        }

        /// <summary>
        /// Filtra la tabla ya cargada buscando el texto en cualquiera de sus
        /// columnas de texto. Al borrar el texto vuelve a verse todo.
        /// </summary>
        private void AplicarFiltroBusqueda()
        {
            if (dtg2 == null || dtg2.Columns.Count == 0) return;

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");
            DataView dv = dtg2.DefaultView;

            if (string.IsNullOrEmpty(filtro))
            {
                dv.RowFilter = "";
                return;
            }

            var condiciones = dtg2.Columns
                .Cast<DataColumn>()
                .Where(col => col.DataType == typeof(string))
                .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

            dv.RowFilter = string.Join(" OR ", condiciones);
        }

        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells["Estado"].Value.ToString() == "ELIMINADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10f, System.Drawing.FontStyle.Bold);
                }
            }
        }
    }
}
