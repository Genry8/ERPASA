using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_DestajoUva;
using ERPASA.Msbox;
using ERPASA.Reportes;
using ERPASA.Reportes.Acopio;
using Ghostscript.NET.Rasterizer;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_DetalleGastoPrint : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg2, dtGerencia, dtArea, dtEstado;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        public Frm_DetalleGastoPrint()
        {
            InitializeComponent();
        }

        private void Frm_DetalleGastoPrint_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            CargarDatosLabel();
            dataGridView2.AllowUserToAddRows = false;
            CargarDatosSync();
            //textBox_Dni.Focus();
        }


        public void CargarDatosLabel()
        {
            //DETALLE DE REPORTE
            label_gasto_para.Text = ce_informegastos.gastopara;
            label_gasto_de.Text = ce_informegastos.gastode;
            label_gasto_asunto.Text = ce_informegastos.gastoasunto;
            label_gasto_fechapresentacion.Text = ce_informegastos.fechapresentacion;
            label_gasto_fecharendir.Text = ce_informegastos.fecharendir;
            label_montosoles.Text = ce_informegastos.MontoSoles;
            label_montodolares.Text = ce_informegastos.MontoDolares;
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }


        public void BuscarReporteRendicionGasto()
        {


            dtg2 = cn_contabilidad.ListaReporteDetalleGasto(
                Convert.ToDateTime("2025-01-01").Date
                , Convert.ToDateTime("2025-01-01").Date
                , Convert.ToString(ce_informegastos.IdInf)
                , "%", "%", "%", "%", "%", 7);

        }


        private async void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "CARGANDO IMAGEN..."; // Actualizar el texto del formulario de carga

            try
            {
                var api = new cn_apiservices();

                string idrend = dataGridView2.Rows[e.RowIndex].Cells["IdRend"].Value.ToString();
                string ruc = "";//dataGridView2.Rows[e.RowIndex].Cells["Ruc"].Value.ToString();
                string serie = "";// dataGridView2.Rows[e.RowIndex].Cells["Serie"].Value.ToString();
                string numero = "";// dataGridView2.Rows[e.RowIndex].Cells["Numero"].Value.ToString();

                // Lista de extensiones candidatas
                string[] posiblesExtensiones = { ".png", ".jpg", ".jpeg", ".pdf", ".bmp", ".gif", ".tiff" };

                byte[] bytes = null;
                string fileName = null;

                foreach (var ext in posiblesExtensiones)
                {
                    string intentoFileName = $"{idrend}_{ruc}_{serie}_{numero}{ext}";
                    bytes = await api.ObtenerImagenBytesAsync(intentoFileName);

                    if (bytes != null && bytes.Length > 0)
                    {
                        fileName = intentoFileName;
                        break;
                    }
                }

                if (bytes == null || bytes.Length == 0)
                {
                    MessageBox.Show("⚠️ No se pudo descargar el archivo o no existe en el servidor.", "Error");
                    return;
                }

                string extArchivo = Path.GetExtension(fileName)?.ToLowerInvariant();
                string[] extensionesImagen = { ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".tiff" };

                if (extensionesImagen.Contains(extArchivo))
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        using (var originalImg = Image.FromStream(ms))
                        {
                            // Corregir orientación
                            Image img = CorregirOrientacionImagen((Image)originalImg.Clone());

                            // Obtener área de trabajo (pantalla sin barra de tareas)
                            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

                            // Crear el formulario ajustado al área de trabajo
                            Form viewer = new Form
                            {
                                Text = $"Vista previa - {fileName}",
                                StartPosition = FormStartPosition.CenterScreen,
                                MaximizeBox = false,          // Deshabilitar maximizar para evitar maximizar encima de barra
                                MinimizeBox = true,
                                Width = Math.Min(600, workingArea.Width),
                                Height = Math.Min(800, workingArea.Height)
                            };

                            // Limitar altura del PictureBox para que no se pase del formulario
                            PictureBox pb = new PictureBox
                            {
                                Dock = DockStyle.Top,
                                Height = viewer.ClientSize.Height - 40, // dejar espacio para el botón
                                Image = img,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            // === 🔍 Agregar Zoom con la rueda del mouse ===
                            float zoomFactor = 1.0f;

                            pb.MouseWheel += (s, ev) =>
                            {
                                if (ev.Delta > 0)
                                    zoomFactor *= 1.1f; // Acercar
                                else
                                    zoomFactor /= 1.1f; // Alejar

                                zoomFactor = Math.Max(0.1f, Math.Min(zoomFactor, 5f)); // Limitar el rango de zoom

                                pb.Width = (int)(img.Width * zoomFactor);
                                pb.Height = (int)(img.Height * zoomFactor);
                                pb.SizeMode = PictureBoxSizeMode.Zoom;
                            };

                            // Permitir que el PictureBox reciba el evento del scroll del mouse
                            pb.MouseEnter += (s, e2) => pb.Focus();


                            // Botón de descarga abajo
                            Button btnDownload = new Button
                            {
                                Text = "💾 Descargar",
                                Dock = DockStyle.Bottom,
                                Height = 40
                            };

                            btnDownload.Click += (s, ev) =>
                            {
                                using (SaveFileDialog save = new SaveFileDialog())
                                {
                                    save.FileName = fileName;
                                    save.Filter = "Todos los archivos|*.*";
                                    if (save.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            File.WriteAllBytes(save.FileName, bytes);
                                            MessageBox.Show("✅ Archivo descargado correctamente", "Éxito");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show($"❌ Error al guardar: {ex.Message}", "Error");
                                        }
                                    }
                                }
                            };

                            viewer.Controls.Add(pb);
                            viewer.Controls.Add(btnDownload);
                            viewer.ShowDialog();

                            // Liberar la imagen al cerrar el formulario para evitar bloqueo de archivo
                            img.Dispose();
                        }
                    }

                }
                else
                {
                    AbrirConProgramaPredeterminado(bytes, fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"🔥 Error mostrando archivo: {ex.Message}");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              // Mostrar mensaje de éxito

            }
            */
        }

        private void AbrirConProgramaPredeterminado(byte[] bytes, string fileName)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(tempPath, bytes);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });

                Console.WriteLine($"📂 Archivo abierto: {tempPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ No se pudo abrir el archivo: {ex.Message}", "Error");
            }
        }

        private Image CorregirOrientacionImagen(Image img)
        {
            const int OrientationId = 0x0112;

            if (img.PropertyIdList.Contains(OrientationId))
            {
                var prop = img.GetPropertyItem(OrientationId);
                int val = BitConverter.ToUInt16(prop.Value, 0);

                RotateFlipType rotateFlip = RotateFlipType.RotateNoneFlipNone;

                switch (val)
                {
                    case 1: // No rotar
                        rotateFlip = RotateFlipType.RotateNoneFlipNone;
                        break;
                    case 2:
                        rotateFlip = RotateFlipType.RotateNoneFlipX;
                        break;
                    case 3:
                        rotateFlip = RotateFlipType.Rotate180FlipNone;
                        break;
                    case 4:
                        rotateFlip = RotateFlipType.Rotate180FlipX;
                        break;
                    case 5:
                        rotateFlip = RotateFlipType.Rotate90FlipX;
                        break;
                    case 6:
                        rotateFlip = RotateFlipType.Rotate90FlipNone;
                        break;
                    case 7:
                        rotateFlip = RotateFlipType.Rotate270FlipX;
                        break;
                    case 8:
                        rotateFlip = RotateFlipType.Rotate270FlipNone;
                        break;
                    default:
                        rotateFlip = RotateFlipType.RotateNoneFlipNone;
                        break;
                }

                if (rotateFlip != RotateFlipType.RotateNoneFlipNone)
                {
                    img.RotateFlip(rotateFlip);
                    // Eliminar el tag para que no aplique dos veces
                    img.RemovePropertyItem(OrientationId);
                }
            }

            return img;
        }

        private async void toolStripButton_DescargaMasiva_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                string MessageBoxTitle = "DESCARGAR";
                string MessageBoxContent = "¿Desea Descargar Archivos Masicamente?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DescargaMasivaImagenes();
                }
            }
            else
            {
                MessageBox.Show("Primero busque reporte");
            }
        }


        /*
        public async void DescargaMasivaImagenes()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "DESCARGANDO ARCHIVOS..."; // Actualizar el texto del formulario de carga

            try
            {
                var api = new cn_apiservices();
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                string[] posiblesExtensiones = { ".png", ".jpg", ".jpeg", ".pdf", ".bmp", ".gif", ".tiff" };

                var rows = dataGridView2.Rows.Cast<DataGridViewRow>()
                             .Where(r => !r.IsNewRow)
                             .ToList();

                int total = rows.Count;
                int descargados = 0;

                // Lista de tareas para descarga paralela
                var tasks = rows.Select(async row =>
                {
                    string idrend = row.Cells["IdRend"].Value.ToString();
                    string ruc = row.Cells["Ruc"].Value.ToString();
                    string serie = row.Cells["Serie"].Value.ToString();
                    string numero = row.Cells["Numero"].Value.ToString();

                    byte[] bytes = null;
                    string fileName = null;

                    foreach (var ext in posiblesExtensiones)
                    {
                        string intentoFileName = $"{idrend}_{ruc}_{serie}_{numero}{ext}";
                        bytes = await api.ObtenerImagenBytesAsync(intentoFileName);
                        if (bytes != null && bytes.Length > 0)
                        {
                            fileName = intentoFileName;
                            break;
                        }
                    }

                    if (bytes != null && fileName != null)
                    {
                        string fullPath = Path.Combine(downloadsPath, fileName);

                        int count = 1;
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(fullPath);
                        string extFile = Path.GetExtension(fullPath);
                        while (File.Exists(fullPath))
                        {
                            fullPath = Path.Combine(downloadsPath, $"{nameWithoutExt}({count}){extFile}");
                            count++;
                        }

                        File.WriteAllBytes(fullPath, bytes);

                        // Actualizar contador de archivos descargados en UI
                        this.Invoke(new Action(() => descargados++));
                    }
                });

                await Task.WhenAll(tasks); // Esperar a que todas las descargas terminen

                MessageBox.Show($"✅ Descarga completa. Archivos descargados: {descargados}/{total}", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error en descarga masiva: {ex.Message}", "Error");
            }

            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              // Mostrar mensaje de éxito

            }

        }
        */
        public async void DescargaMasivaImagenes()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "DESCARGANDO ARCHIVOS..."; // Actualizar el texto del formulario de carga

            try
            {
                var api = new cn_apiservices();
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                string[] posiblesExtensiones = { ".png", ".jpg", ".jpeg", ".pdf", ".bmp", ".gif", ".tiff" };

                var rows = dataGridView2.Rows.Cast<DataGridViewRow>()
                             .Where(r => !r.IsNewRow)
                             .ToList();

                int total = rows.Count;
                int descargados = 0;

                // Lista de tareas para descarga paralela
                var tasks = rows.Select(async row =>
                {
                    string idrend = row.Cells["IdRend"].Value.ToString();
                    string ruc = "";//row.Cells["Ruc"].Value.ToString();
                    string serie = "";//row.Cells["Serie"].Value.ToString();
                    string numero = "";//row.Cells["Numero"].Value.ToString();

                    byte[] bytes = null;
                    string fileName = null;

                    foreach (var ext in posiblesExtensiones)
                    {
                        string intentoFileName = $"{idrend}_{ruc}_{serie}_{numero}{ext}";
                        bytes = await api.ObtenerImagenBytesAsync(intentoFileName);
                        if (bytes != null && bytes.Length > 0)
                        {
                            fileName = intentoFileName;
                            break;
                        }
                    }

                    if (bytes != null && fileName != null)
                    {
                        string fullPath = Path.Combine(downloadsPath, fileName);

                        int count = 1;
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(fullPath);
                        string extFile = Path.GetExtension(fullPath);
                        while (File.Exists(fullPath))
                        {
                            fullPath = Path.Combine(downloadsPath, $"{nameWithoutExt}({count}){extFile}");
                            count++;
                        }

                        File.WriteAllBytes(fullPath, bytes);

                        // Actualizar contador de archivos descargados en UI
                        this.Invoke(new Action(() => descargados++));
                    }
                });

                await Task.WhenAll(tasks); // Esperar a que todas las descargas terminen

                MessageBox.Show($"✅ Descarga completa. Archivos descargados: {descargados}/{total}", "Éxito");

                // Abrir carpeta Descargas automáticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = downloadsPath,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error en descarga masiva: {ex.Message}", "Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
            }
        }


        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    BuscarReporteRendicionGasto();
                    dataGridView2.ClearSelection();
                });

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg2;
                dataGridView2.AllowUserToAddRows = false;

                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
            }
        }


        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel2();
            //objexcel.ExportarExcel(dataGridView2);
        }

        private void toolStripButton_ExportarPdf_Click(object sender, EventArgs e)
        {
            ExportarMovilidadPDF();
        }

        private async void ExportarExcel2()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var frbm = new frm_dowloadExcel();

            frbm.OnCancelRequested = () =>
            {
                _cts?.Cancel();
            };

            frbm.Show(this);

            try
            {

                await Task.Run(() =>
                {
                    try
                    {
                        objexcel_progress.exportarexcelTimer(dataGridView2, frbm, token);
                    }
                    catch (OperationCanceledException)
                    {
                        // Re-lanzamos para que el catch externo lo maneje
                        throw;
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Exportación cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            ImprimirCabeceraMovilidad();
        }

        public async void ImprimirCabeceraMovilidad()
        {
            try
            {
                var api = new cn_apiservices();

                Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
                AddOwnedForm(objImpresion);
                objImpresion.Show();

                Dts_RendicionGasto objDs = new Dts_RendicionGasto();

                objDs.Tables[0].Rows.Add(new object[]
                  {
                "LIQUIDACIÓN DE CAJA CHICA Y /O ENTREGA A RENDIR", // titulo
                label_gasto_asunto.Text,  // Decreto o asunto
                "",     // Razon social
                "",   // ruc
                ce_informegastos.descripcion_gasto.ToString(),  // periodo O descripcion
                label_gasto_fechapresentacion.Text,// fecha emision o presentacion
                label_gasto_fecharendir.Text, // hora emisio o fecha rendir
                "",   // Dni
                label_gasto_de.Text,   // apenom
                "",   // area
                label_gasto_para.Text,  // gerencia
                "S/ "+label_montosoles.Text,  // total
                label_montosoles.Text,  // total soles
                label_montodolares.Text  // total dolar
                  });


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow) // evita la última fila vacía
                    {
                        // 1. Recuperar el nombre de archivo desde la columna 8
                        string intentoFileName = row.Cells[9].Value?.ToString();

                        byte[] imagenBytes = null;

                        // 2. Llamar a tu API para traer la imagen
                        if (!string.IsNullOrEmpty(intentoFileName))
                        {
                            imagenBytes = await api.ObtenerImagenBytesAsync(intentoFileName);
                        }

                        objDs.Tables[1].Rows.Add(new object[]
                        {
                            row.Cells[0].Value, //dia
                            row.Cells[1].Value, //mes
                            row.Cells[2].Value,//año
                            row.Cells[4].Value, // motivo o politica
                            row.Cells[9].Value,// FACTURA
                            row.Cells[5].Value,//viaje
                            "S/ "+row.Cells[6].Value, //soles
                            row.Cells[7].Value,    // Moneda
                            row.Cells[8].Value, //
                            imagenBytes,//AQUI VA LA IMAGEN
                        });
                    }
                }


                var objCryRep = new CrystalReportRindeCuenta();
                objCryRep.Load(@"~\CrystalReportRindeCuenta.rpt");
                objCryRep.SetDataSource(objDs);

                objImpresion.crystalReportViewer1.ReportSource = objCryRep;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async void ExportarMovilidadPDF()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "EXPORTANDO A PDF..."; // Actualizar el texto del formulario de carga
            try
            {
                var api = new cn_apiservices();

                //Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
                //AddOwnedForm(objImpresion);
                //objImpresion.Show();

                Dts_RendicionGasto objDs = new Dts_RendicionGasto();

                objDs.Tables[0].Rows.Add(new object[]
                  {
                "LIQUIDACIÓN DE CAJA CHICA Y /O ENTREGA A RENDIR", // titulo
                label_gasto_asunto.Text,  // Decreto o asunto
                "",     // Razon social
                "",   // ruc
                ce_informegastos.descripcion_gasto.ToString(),  // periodo O descripcion
                label_gasto_fechapresentacion.Text,// fecha emision o presentacion
                label_gasto_fecharendir.Text, // hora emisio o fecha rendir
                "",   // Dni
                label_gasto_de.Text,   // apenom
                "",   // area
                label_gasto_para.Text,  // gerencia
                "S/ "+label_montosoles.Text,  // total
                label_montosoles.Text,  // total soles
                label_montodolares.Text  // total dolar
                  });


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow) // evita la última fila vacía
                    {
                        // 1. Recuperar el nombre de archivo desde la columna 8
                        string intentoFileName = row.Cells[9].Value?.ToString();
                        byte[] archivoBytes = null;

                        if (!string.IsNullOrEmpty(intentoFileName))
                        {
                            string extension = Path.GetExtension(intentoFileName)?.ToLower();  // Obtener la extensión del archivo

                            // Si es una imagen (png, jpg, jpeg)
                            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                            {
                                // Llamar a la API para obtener la imagen
                                archivoBytes = await api.ObtenerImagenBytesAsync(intentoFileName);
                            }
                            // Si es un PDF, lo convertimos a imagen
                            //else if (extension == ".pdf")
                            //{
                            //    // Guardar el archivo PDF temporalmente
                            //    string tempPdfPath = Path.GetTempFileName() + ".pdf";
                            //    byte[] pdfBytes = await api.ObtenerImagenBytesAsync(intentoFileName);
                            //    File.WriteAllBytes(tempPdfPath, pdfBytes);

                            //    // Convertir PDF a PNG usando Ghostscript
                            //    archivoBytes = ConvertPdfToPngBytes(tempPdfPath);

                            //    // Eliminar el archivo temporal
                            //    File.Delete(tempPdfPath);
                            //}


                        }

                        // Agregar la imagen (o la imagen convertida) al DataTable
                        objDs.Tables[1].Rows.Add(new object[]
                        {
                            row.Cells[0].Value,  // Día
                            row.Cells[1].Value,  // Mes
                            row.Cells[2].Value,  // Año
                            row.Cells[4].Value,  // Motivo o política
                            row.Cells[9].Value,  // Factura
                            row.Cells[5].Value,  // Viaje
                            "S/ " + row.Cells[6].Value, // Soles
                            row.Cells[7].Value,  // Moneda
                            row.Cells[8].Value,  // (Otro dato)
                            archivoBytes         // Imagen (o imagen convertida desde PDF)
                        });

                    }
                }


                var objCryRep = new CrystalReportRindeCuenta();
                objCryRep.Load(@"~\CrystalReportRindeCuenta.rpt");
                objCryRep.SetDataSource(objDs);

                //objImpresion.crystalReportViewer1.ReportSource = objCryRep;

                // ============================
                //  NOMBRE AUTOMÁTICO DEL PDF
                // ============================
                // Generar nombre de archivo
                // Convertir fecha a formato válido (YYYY-MM-DD)
                string fechaOriginal = label_gasto_fechapresentacion.Text;
                DateTime fecha;
                string fechaLimpia = "";
                int semanaISO = 0;
                int año = 0;

                // Intentar convertir la fecha
                if (DateTime.TryParse(fechaOriginal, out fecha))
                {
                    // Año
                    año = fecha.Year;

                    // Semana ISO (norma ISO 8601)
                    System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InvariantCulture;
                    semanaISO = ci.Calendar.GetWeekOfYear(
                                    fecha,
                                    System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                                    DayOfWeek.Monday);

                    fechaLimpia = fecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    // Si no convierte, solo limpia caracteres inválidos
                    fechaLimpia = fechaOriginal.Replace("/", "-").Replace("\\", "-");
                }

                // Generar nombre de archivo seguro
                string fileName = $"GASTOS SEM {semanaISO} AÑO {año} {label_gasto_de.Text}.pdf";

                // Ruta Descargas
                // ========================================
                //   CUADRO DE DIÁLOGO PARA ELEGIR UBICACIÓN
                // ========================================
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Guardar PDF";
                    sfd.FileName = fileName;
                    sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Operación cancelada.", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Cancela guardado
                    }

                    string fullPath = sfd.FileName;

                    // Exportar PDF
                    objCryRep.ExportToDisk(
                        CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                        fullPath
                    );

                    // Abrir carpeta
                    //System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{fullPath}\"");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
            }
        }

        public static byte[] ConvertPdfToPngBytes(string pdfPath)
        {
            using (var rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.Open(pdfPath);

                // Renderizar la primera página a 300 DPI (GetPage(dpi, pageNumber))
                var img = rasterizer.GetPage(300, 1);

                using (var ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
        /*
        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            if (dtg2 != null)
            {
                DataView dv = dtg2.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg2.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }
    */

    }
}
