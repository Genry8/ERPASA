using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
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

namespace ERPASA.Frm_Taller
{
    /// <summary>
    /// REPORTE CONTROL DE LIMPIEZA (TALL_ControlLimpieza).
    ///
    /// Misma mecanica que Frm_ReporteOrdenTrabajo: los filtros de arriba
    /// acotan la consulta, "Buscar" trae los datos en segundo plano y el
    /// cuadro Search filtra sobre lo ya traido sin volver a la base.
    /// </summary>
    public partial class Frm_ReporteControlLimpieza : Form
    {
        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();

        // Resultado de la ultima busqueda: sobre el trabaja el filtro de texto.
        DataTable dtg2;
        private CancellationTokenSource _cts;

        public Frm_ReporteControlLimpieza()
        {
            InitializeComponent();
            // Los iconos de la barra se toman de otras pantallas: asi este
            // formulario no necesita su propio archivo de recursos.
            Frm_Acopio.Frm_Maestros.IconosMaestro.Aplicar(toolStrip2);
            // Identidad visual del ERP (barra de titulo, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ReporteControlLimpieza_Load(object sender, EventArgs e)
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

            dtg2 = cn_taller.ListaReporteControlLimpieza(fecIni, fecFin, emp, sed);
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
                AgregarColumnaEvidencia();
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

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private async void ExportarExcel()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var frbm = new frm_dowloadExcel();
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

        // ------------------------------------------------------- impresion

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("PRIMERO BUSQUE LOS REGISTROS A IMPRIMIR");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ImprimirControlLimpieza();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Pasa a Crystal lo que esta viendose en la grilla (ya filtrado) con
        /// el formato del papel ASA-SSGG-R-00022.
        ///
        /// La tabla se arma a mano, con el mismo nombre y las mismas columnas
        /// que DataSetTaller.xsd, que es contra lo que se diseño el .rpt.
        /// </summary>
        public void ImprimirControlLimpieza()
        {
            DataSet ds = new DataSet("DataSetTaller");
            DataTable tabla = new DataTable("TableControlLimpieza");

            foreach (string columna in new string[]
            {
                "Empresa", "Sede", "Cabezal", "Valvula", "Mes", "Fecha", "NroBano",
                "JabonNeutro", "PapelHigienico", "PapelToalla", "Cal", "Inodoro",
                "Lavadero", "Cano", "TanqueAgua", "PozaCal", "PozoSeptico",
                "Responsable", "Firma", "Obs"
            })
            {
                tabla.Columns.Add(columna, typeof(string));
            }

            ds.Tables.Add(tabla);
            ds.Tables.Add(CabeceraDelFormato());

            // El mes de la cabecera sale de la primera fecha que se imprime.
            string mes = MesDeLaPrimeraFila();

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;

                tabla.Rows.Add(
                    Celda(fila, "Empresa"),
                    Celda(fila, "Sede"),
                    Celda(fila, "Cabezal"),
                    Celda(fila, "Valvula"),
                    mes,
                    FechaCorta(Celda(fila, "Fecha")),
                    Celda(fila, "NroBano"),
                    // Los suministros son si/no: en el papel van con visto.
                    Visto(Celda(fila, "JabonNeutro")),
                    Visto(Celda(fila, "PapelHigienico")),
                    Visto(Celda(fila, "PapelToalla")),
                    Visto(Celda(fila, "Cal")),
                    Visto(Celda(fila, "Inodoro")),
                    // Los aparatos guardan una letra (B de bueno) y va tal cual.
                    Celda(fila, "Lavadero"),
                    Celda(fila, "Cano"),
                    Celda(fila, "TanqueAgua"),
                    Celda(fila, "PozaCal"),
                    Celda(fila, "PozoSeptico"),
                    Celda(fila, "UseReg"),   // Responsable: la tabla no lo guarda, se firma a mano
                    "",   // Firma: se firma a mano
                    Celda(fila, "Obs"));
            }

            var objCryRep = new CrystalReportPrintLimpieza();
            objCryRep.SetDataSource(ds);

            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
            objImpresion.Show();
        }

        /// <summary>
        /// La tabla de la cabecera del formato: el recuadro de codigo,
        /// version, fecha y pagina, mas los datos de la empresa. Son valores
        /// fijos del documento ASA-SSGG-R-00022, no salen de la base.
        /// </summary>
        private DataTable CabeceraDelFormato()
        {
            DataTable cabecera = new DataTable("DataTable3");

            foreach (string columna in new string[]
            {
                "Nombre", "Tip", "Codigo", "Version", "Fecha", "Pag",
                "Empresa", "Ruc", "Direccion", "Inspector", "Firma",
                "Responsable", "Cargo"
            })
            {
                cabecera.Columns.Add(columna, typeof(string));
            }

            cabecera.Rows.Add(
                "SERVICIOS GENERALES",                   // Nombre
                "Mantenimiento y verificación de baños", // Tip
                "ASA-SSGG-R-00022",                      // Codigo
                "4",                                     // Version
                "21/05/2026",                            // Fecha
                "1 de 1",                                // Pag
                EmpresaDelFiltro(),                      // Empresa
                "", "", "", "", "", "");                 // Ruc, direccion y firmas: a mano

            return cabecera;
        }

        /// <summary>La empresa del filtro, o la de la primera fila si no se eligio.</summary>
        private string EmpresaDelFiltro()
        {
            if (comboBox_detalle_empresa.Text != "SELECCIONE")
                return comboBox_detalle_empresa.Text;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;
                return Celda(fila, "Empresa");
            }

            return "";
        }

        /// <summary>Lee una celda por nombre; si la columna no vino, cadena vacia.</summary>
        private static string Celda(DataGridViewRow fila, string columna)
        {
            if (!fila.DataGridView.Columns.Contains(columna)) return "";
            object valor = fila.Cells[columna].Value;
            return valor == null || valor == DBNull.Value ? "" : valor.ToString().Trim();
        }

        /// <summary>En el papel la fecha va como 01-08-26.</summary>
        private static string FechaCorta(string valor)
        {
            DateTime fecha;
            return DateTime.TryParse(valor, out fecha)
                ? fecha.ToString("dd-MM-yy")
                : valor;
        }

        private static string Visto(string valor)
        {
            return valor == "SI" ? "X" : "";
        }

        private string MesDeLaPrimeraFila()
        {
            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;

                DateTime fecha;
                if (DateTime.TryParse(Celda(fila, "Fecha"), out fecha))
                    return fecha.ToString("MMMM").ToUpper();
            }

            return "";
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

        // ---------------------------------------------------- evidencia

        // Nombre de la columna que guarda el archivo de la foto.
        private static readonly string[] ColumnasFoto = { "RutaFoto", "Foto" };

        private static readonly Size TamMiniatura = new Size(110, 80);
        private const int AltoFila = 72;

        // Cuantas fotos se descargan a la vez. Mas de tres no acelera nada y
        // satura al servidor cuando el usuario arrastra la barra rapido.
        private readonly SemaphoreSlim turnos = new SemaphoreSlim(3);

        // Miniaturas ya resueltas, por nombre de archivo. Se limita el tamaño
        // porque el reporte puede traer miles de filas y cada imagen ocupa
        // memoria: al pasarse, se sueltan las mas antiguas.
        private readonly Dictionary<string, Image> miniaturas =
            new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> ordenCache = new List<string>();
        private const int MaxEnCache = 300;

        // Archivos que ya se estan pidiendo o que ya se sabe que no estan,
        // para no volver a preguntar por ellos en cada desplazamiento.
        private readonly HashSet<string> pedidos =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Agrega al final de la grilla la columna con la foto que tomo el
        /// aplicativo movil. Se llama despues de cada busqueda porque al
        /// reasignar el DataSource la grilla rehace sus columnas.
        /// </summary>
        private void AgregarColumnaEvidencia()
        {
            if (ColumnaFoto() < 0) return;   // el reporte no trae la ruta

            if (!dataGridView2.Columns.Contains("Evidencia"))
            {
                var columna = new DataGridViewImageColumn
                {
                    Name = "Evidencia",
                    HeaderText = "EVIDENCIA",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 120,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = { NullValue = null }
                };

                dataGridView2.Columns.Add(columna);
                columna.DisplayIndex = dataGridView2.Columns.Count - 1;
            }

            // Filas mas altas para que la foto se vea.
            dataGridView2.RowTemplate.Height = AltoFila;
            foreach (DataGridViewRow fila in dataGridView2.Rows)
                fila.Height = AltoFila;

            PedirMiniaturasVisibles();
        }

        private int ColumnaFoto()
        {
            foreach (string nombre in ColumnasFoto)
                foreach (DataGridViewColumn c in dataGridView2.Columns)
                    if (string.Equals(c.Name, nombre, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(c.HeaderText, nombre, StringComparison.OrdinalIgnoreCase))
                        return c.Index;

            return -1;
        }

        private string ArchivoDe(DataGridViewRow fila, int columna)
        {
            object valor = fila.Cells[columna].Value;
            return valor == null || valor == DBNull.Value ? "" : valor.ToString().Trim();
        }

        // ------------------------------------------- carga bajo demanda

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            PedirMiniaturasVisibles();
        }

        /// <summary>
        /// Pide al servidor solo las fotos de las filas que se estan viendo.
        /// Es lo que hace viable el reporte con miles de registros: en vez de
        /// miles de descargas, se hacen las diez o quince de la pantalla, y el
        /// resto va saliendo conforme el usuario baja.
        /// </summary>
        private void PedirMiniaturasVisibles()
        {
            if (IsDisposed) return;
            if (!dataGridView2.Columns.Contains("Evidencia")) return;

            int columnaFoto = ColumnaFoto();
            if (columnaFoto < 0) return;

            int primera = dataGridView2.FirstDisplayedScrollingRowIndex;
            if (primera < 0) return;

            // Un par de filas de margen arriba y abajo: cuando el usuario
            // sigue bajando, la foto ya esta lista antes de aparecer.
            int desde = Math.Max(0, primera - 2);
            int hasta = Math.Min(dataGridView2.Rows.Count - 1,
                                 primera + dataGridView2.DisplayedRowCount(true) + 2);

            for (int i = desde; i <= hasta; i++)
            {
                DataGridViewRow fila = dataGridView2.Rows[i];
                if (fila.IsNewRow) continue;

                string archivo = ArchivoDe(fila, columnaFoto);
                if (archivo == "") continue;

                Image miniatura;
                if (miniaturas.TryGetValue(archivo, out miniatura))
                {
                    // Ya estaba descargada: solo se vuelve a poner si la fila
                    // perdio la imagen (por ejemplo tras reordenar).
                    if (!ReferenceEquals(fila.Cells["Evidencia"].Value, miniatura))
                        fila.Cells["Evidencia"].Value = miniatura;
                    continue;
                }

                if (pedidos.Contains(archivo)) continue;

                pedidos.Add(archivo);
                DescargarMiniatura(archivo);
            }
        }

        private async void DescargarMiniatura(string archivo)
        {
            await turnos.WaitAsync();

            try
            {
                var api = new cn_apiservices();
                byte[] bytes = await api.ObtenerEvidenciaLimpiezaBytesAsync(archivo);

                if (IsDisposed || bytes == null || bytes.Length == 0) return;

                Image miniatura = Miniatura(bytes);
                if (miniatura == null) return;

                Guardar(archivo, miniatura);
                MostrarEnFilas(archivo, miniatura);
            }
            catch
            {
                // Si falla una foto el reporte sigue andando: la celda queda
                // vacia y no se vuelve a pedir ese archivo.
            }
            finally
            {
                turnos.Release();
            }
        }

        /// <summary>Pone la miniatura en todas las filas que usan ese archivo.</summary>
        private void MostrarEnFilas(string archivo, Image miniatura)
        {
            if (IsDisposed) return;

            int columnaFoto = ColumnaFoto();
            if (columnaFoto < 0 || !dataGridView2.Columns.Contains("Evidencia")) return;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;

                if (string.Equals(ArchivoDe(fila, columnaFoto), archivo,
                        StringComparison.OrdinalIgnoreCase))
                {
                    fila.Cells["Evidencia"].Value = miniatura;
                }
            }
        }

        private void Guardar(string archivo, Image miniatura)
        {
            miniaturas[archivo] = miniatura;
            ordenCache.Add(archivo);

            // Se sueltan las mas viejas para no acumular memoria sin limite.
            while (ordenCache.Count > MaxEnCache)
            {
                string vieja = ordenCache[0];
                ordenCache.RemoveAt(0);

                Image imagen;
                if (miniaturas.TryGetValue(vieja, out imagen))
                {
                    miniaturas.Remove(vieja);
                    pedidos.Remove(vieja);   // si vuelve a verse, se pide de nuevo
                    LimpiarCeldas(imagen);
                    imagen.Dispose();
                }
            }
        }

        /// <summary>Quita de la grilla una imagen que se va a liberar.</summary>
        private void LimpiarCeldas(Image imagen)
        {
            if (!dataGridView2.Columns.Contains("Evidencia")) return;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;

                if (ReferenceEquals(fila.Cells["Evidencia"].Value, imagen))
                    fila.Cells["Evidencia"].Value = null;
            }
        }

        /// <summary>Reduce la foto al tamaño de la celda.</summary>
        private static Image Miniatura(byte[] bytes)
        {
            try
            {
                using (var memoria = new MemoryStream(bytes))
                using (Image original = Image.FromStream(memoria))
                {
                    double escala = Math.Min(
                        (double)TamMiniatura.Width / original.Width,
                        (double)TamMiniatura.Height / original.Height);

                    int ancho = Math.Max(1, (int)Math.Round(original.Width * escala));
                    int alto = Math.Max(1, (int)Math.Round(original.Height * escala));

                    var destino = new Bitmap(ancho, alto);

                    using (Graphics g = Graphics.FromImage(destino))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, ancho, alto);
                    }

                    return destino;
                }
            }
            catch
            {
                return null;   // el archivo no era una imagen
            }
        }

        // ------------------------------------------------ foto completa

        private async void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!dataGridView2.Columns.Contains("Evidencia")) return;
            if (e.ColumnIndex != dataGridView2.Columns["Evidencia"].Index) return;

            int col = ColumnaFoto();
            if (col < 0) return;

            string archivo = ArchivoDe(dataGridView2.Rows[e.RowIndex], col);

            if (archivo == "")
            {
                MessageBox.Show("Ese registro no tiene evidencia cargada.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            dataGridView2.Enabled = false;

            try
            {
                // Para la ventana grande se pide la foto completa: en la celda
                // solo vive la miniatura.
                var api = new cn_apiservices();
                byte[] bytes = await api.ObtenerEvidenciaLimpiezaBytesAsync(archivo);

                if (bytes == null || bytes.Length == 0)
                {
                    MessageBox.Show(
                        "No se pudo traer la evidencia del servidor.\n\nArchivo: " + archivo,
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var ver = new Frm_VerEvidencia(bytes, archivo))
                {
                    ver.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la evidencia:\n\n" + ex.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataGridView2.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells["Estado"].Value.ToString() == "ELIMINADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold);
                }
            }
        }

        private void toolStripLabel_imprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
