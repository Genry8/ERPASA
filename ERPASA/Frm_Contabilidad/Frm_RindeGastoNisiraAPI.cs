using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidad.ce_nisira_api;

namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_RindeGastoNisiraAPI : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cn_contabilidad objcncont = new cn_contabilidad();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg2, dtPolitica, dtTipoGasto, dtGerencia, dtArea, dtEstado;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        private CheckBox headerCheckBox = new CheckBox();

        public Frm_RindeGastoNisiraAPI()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_RindeGastoNisiraAPI_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            dataGridView2.AllowUserToAddRows = false;
            pictureBox_Enviar_NisiraQA.Visible = true;
            pictureBox_Enviar_NisiraQA.Click += pictureBox_Enviar_NisiraQA_Click;
            pictureBox_enviardatos_Nisira.Click += pictureBox_enviardatos_Nisira_Click;
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_politica.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tipogasto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Gerencia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            dtPolitica = cn_contabilidad.ReportePolitica();
            dtTipoGasto = cn_contabilidad.RendTipoGasto();
            dtGerencia = cn_logistica.ListaGerencia();
            dtArea = cn_logistica.ListaAreaTI();
            dtEstado = cn_contabilidad.RendEstadoGasto();
            // Crear una nueva fila al inicio
            DataRow row = dtPolitica.NewRow();
            row["Politica"] = "SELECCIONE";
            row["Id"] = 0; // valor por defecto o nulo
            DataRow row2 = dtTipoGasto.NewRow();
            row2["TipoGasto"] = "SELECCIONE";
            row2["Id"] = 0; // valor por defecto o nulo
            DataRow row3 = dtGerencia.NewRow();
            row3["DesGer"] = "SELECCIONE";
            row3["Id"] = 0; // valor por defecto o nulo
            DataRow row4 = dtArea.NewRow();
            row4["Area"] = "SELECCIONE";
            row4["Codigo"] = 0; // valor por defecto o nulo
            DataRow row5 = dtEstado.NewRow();
            row5["EstadoGasto"] = "SELECCIONE";
            row5["Id"] = 0; // valor por defecto o nulo


            // Insertar al inicio
            dtPolitica.Rows.InsertAt(row, 0);
            dtTipoGasto.Rows.InsertAt(row2, 0);
            dtGerencia.Rows.InsertAt(row3, 0);
            dtArea.Rows.InsertAt(row4, 0);
            dtEstado.Rows.InsertAt(row5, 0);

            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_politica.DataSource = dtPolitica;
            comboBox_politica.DisplayMember = "Politica"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_politica.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_tipogasto.DataSource = dtTipoGasto;
            comboBox_tipogasto.DisplayMember = "TipoGasto"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_tipogasto.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Gerencia.DataSource = dtGerencia;
            comboBox_Gerencia.DisplayMember = "desger"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Gerencia.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_area.DataSource = dtArea;
            comboBox_area.DisplayMember = "area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_area.ValueMember = "Codigo"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_estado.DataSource = dtEstado;
            comboBox_estado.DisplayMember = "EstadoGasto"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarReporteRendicionGasto()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp, politica, empText = string.Empty, politicaText = string.Empty
                , tipogasto, tipogastoText = string.Empty
                , ger, gerText = string.Empty
            , area, areaText = string.Empty
            , estado, estadoText = string.Empty;

            ////////////////////////////////////
            if (comboBox_empresa.InvokeRequired)
            {
                comboBox_empresa.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_empresa.Text;
                }));
            }
            else
            {
                empText = comboBox_empresa.Text;
            }
            ////////////////////////////////////
            if (comboBox_politica.InvokeRequired)
            {
                comboBox_politica.Invoke(new MethodInvoker(() =>
                {
                    politicaText = comboBox_politica.Text;
                }));
            }
            else
            {
                politicaText = comboBox_politica.Text;
            }
            ////////////////////////////////////
            if (comboBox_Gerencia.InvokeRequired)
            {
                comboBox_Gerencia.Invoke(new MethodInvoker(() =>
                {
                    gerText = comboBox_Gerencia.Text;
                }));
            }
            else
            {
                gerText = comboBox_Gerencia.Text;
            }

            ////////////////////////////////////
            if (comboBox_tipogasto.InvokeRequired)
            {
                comboBox_tipogasto.Invoke(new MethodInvoker(() =>
                {
                    tipogastoText = comboBox_tipogasto.Text;
                }));
            }
            else
            {
                tipogastoText = comboBox_tipogasto.Text;
            }

            ////////////////////////////////////
            if (comboBox_area.InvokeRequired)
            {
                comboBox_area.Invoke(new MethodInvoker(() =>
                {
                    areaText = comboBox_area.Text;
                }));
            }
            else
            {
                areaText = comboBox_area.Text;
            }
            ////////////////////////////////////
            if (comboBox_estado.InvokeRequired)
            {
                comboBox_estado.Invoke(new MethodInvoker(() =>
                {
                    estadoText = comboBox_estado.Text;
                }));
            }
            else
            {
                estadoText = comboBox_estado.Text;
            }

            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }
            if (politicaText == "SELECCIONE")
            {
                politica = "%";
            }
            else
            {
                politica = politicaText;
            }

            if (tipogastoText == "SELECCIONE")
            {
                tipogasto = "%";
            }
            else
            {
                tipogasto = tipogastoText;
            }
            if (gerText == "SELECCIONE")
            {
                ger = "%";
            }
            else
            {
                ger = gerText;
            }
            if (areaText == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = areaText;
            }
            if (estadoText == "SELECCIONE")
            {
                estado = "%";
            }
            else
            {
                estado = estadoText;
            }

            dtg2 = cn_contabilidad.ListaReporteDetalleGasto(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , politica, tipogasto, ger, area, estado, 8);

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

        private async void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ReadOnly = true;
            //cargarFoto(sender,e);
        }

        public async void cargarFoto(object sender, DataGridViewCellEventArgs e)
        {
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
                string ruc = dataGridView2.Rows[e.RowIndex].Cells["Ruc"].Value.ToString();
                string serie = dataGridView2.Rows[e.RowIndex].Cells["Serie"].Value.ToString();
                string numero = dataGridView2.Rows[e.RowIndex].Cells["Numero"].Value.ToString();

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


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                bool valor = false;

                if (dataGridView2.Rows[e.RowIndex].Cells[0].Value != DBNull.Value &&
                    dataGridView2.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    valor = Convert.ToBoolean(
                        dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                }

                dataGridView2.Rows[e.RowIndex].Cells[0].Value = !valor;
            }
        }

        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool estado = headerCheckBox.Checked;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = estado;
            }

            dataGridView2.EndEdit();
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //if (checkBox1.Checked == true)
                //{
                //    row.Cells[0].Value = true;
                //}
                //else
                //{
                //    row.Cells[0].Value = false;
                //}
            }
        }

        private async void CargarDatosSync()
        {
            //checkBox1.Checked = false;

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

                // El grid puede ser solo lectura
                dataGridView2.ReadOnly = true;

                // Agregar checkbox editable para seleccionar registros a enviar/validar en NISIRA
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "Seleccionar";
                chk.HeaderText = "";
                chk.Width = 40;
                chk.ReadOnly = false;

                dataGridView2.Columns.Insert(0, chk);

                // Habilitar edición únicamente en la primera columna (el checkbox)
                dataGridView2.Columns[0].ReadOnly = false;

                CrearCheckTodosNisira();
                UbicarCheckTodosNisira();

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
                // 🔥 OCULTAR COLUMNA CHECK
                //dataGridView2.Columns[0].Visible = false;

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
                // 🔥 VOLVER A MOSTRAR
                //dataGridView2.Columns[0].Visible = true;

                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }


        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                cn_equipoti.BuscPaginaParaHoja(18, dateTimePicker_FecFin.Value.Date);
                if (comboBox_empresa.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_empresa.Text == "AGRICOLA SANTA AZUL S.R.L")
                {
                    cn_equipoti.BuscPaginaParaHoja(20, dateTimePicker_FecInicio.Value.Date);
                    //ImprimirReporteDetalleAtencionASA();
                }
                else if (comboBox_empresa.Text == "AGRICOLA INTERANDINA S.A.C")
                {
                    cn_equipoti.BuscPaginaParaHoja(21, dateTimePicker_FecInicio.Value.Date);
                    //ImprimirReporteDetalleAtencionIA();
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA IMPRIMIR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }




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

        //=====================================================================
        //  ENVÍO A NISIRA (API REST) - mismo patrón de 3 pasos que Extech:
        //  1) Seleccionar filas en el grid (checkbox)
        //  2) Previsualizar en un resumen (FrmResumenEnvioNisira)
        //  3) Enviar y mostrar un resumen final de resultado
        //=====================================================================

        /// <summary>Filas marcadas con el checkbox de la primera columna.</summary>
        private List<DataRow> ObtenerFilasSeleccionadasNisira()
        {
            dataGridView2.EndEdit();

            var filas = new List<DataRow>();
            if (!(dataGridView2.DataSource is DataTable tabla)) return filas;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;

                bool seleccionado = fila.Cells[0].Value != null &&
                                     fila.Cells[0].Value != DBNull.Value &&
                                     Convert.ToBoolean(fila.Cells[0].Value);

                if (seleccionado)
                {
                    filas.Add(tabla.Rows[fila.Index]);
                }
            }

            return filas;
        }

        /// <summary>Copia solo los datos reales (sin el checkbox) de las filas elegidas, para la previsualización.</summary>
        private DataTable ConstruirResumenPreviewNisira(List<DataRow> filas)
        {
            var origen = filas.FirstOrDefault()?.Table ?? dtg2;
            var copia = origen.Clone();
            foreach (var fila in filas)
            {
                copia.ImportRow(fila);
            }
            return copia;
        }

        /// <summary>
        /// Lee una columna del DataRow por nombre tolerando que no exista.
        /// Acumula en <paramref name="faltantes"/> cualquier columna NISIRA que
        /// no se pudo ubicar en el resultado local, para avisar antes de enviar.
        /// </summary>
        private string ColNisira(DataRow fila, string nombreColumna, string porDefecto, string campoNisira, HashSet<string> faltantes)
        {
            if (fila.Table.Columns.Contains(nombreColumna))
            {
                var valor = fila[nombreColumna]?.ToString().Trim();
                return string.IsNullOrEmpty(valor) ? porDefecto : valor;
            }

            faltantes.Add($"{campoNisira} (se esperaba la columna '{nombreColumna}')");
            return porDefecto;
        }

        private decimal ColNisiraDecimal(DataRow fila, string nombreColumna, string campoNisira, HashSet<string> faltantes)
        {
            var texto = ColNisira(fila, nombreColumna, "0", campoNisira, faltantes);
            return decimal.TryParse(texto, out decimal val) ? val : 0;
        }

        // ----------------------------------------------------------------
        // CHECK DE CABECERA: marcar o desmarcar todos los gastos de una vez
        // ----------------------------------------------------------------
        // WinForms no admite una casilla real dentro del encabezado, asi que
        // se apoya un CheckBox encima de la celda de cabecera y se lo reubica
        // cuando la grilla se desplaza o cambia de tamaño.
        private CheckBox check_TodosNisira;

        private void CrearCheckTodosNisira()
        {
            if (check_TodosNisira != null)
            {
                check_TodosNisira.Checked = false;
                return;
            }

            check_TodosNisira = new CheckBox();
            check_TodosNisira.Size = new Size(16, 16);
            check_TodosNisira.BackColor = Color.Transparent;
            check_TodosNisira.Cursor = Cursors.Hand;
            check_TodosNisira.Click += delegate { MarcarTodosNisira(check_TodosNisira.Checked); };

            dataGridView2.Controls.Add(check_TodosNisira);

            dataGridView2.Scroll += delegate { UbicarCheckTodosNisira(); };
            dataGridView2.ColumnWidthChanged += delegate { UbicarCheckTodosNisira(); };
            dataGridView2.SizeChanged += delegate { UbicarCheckTodosNisira(); };
        }

        private void UbicarCheckTodosNisira()
        {
            if (check_TodosNisira == null || dataGridView2.Columns.Count == 0) return;

            Rectangle celda = dataGridView2.GetCellDisplayRectangle(0, -1, true);
            if (celda.Width == 0) return;

            check_TodosNisira.Location = new Point(
                celda.X + (celda.Width - check_TodosNisira.Width) / 2,
                celda.Y + (celda.Height - check_TodosNisira.Height) / 2);
            check_TodosNisira.BringToFront();
        }

        private void MarcarTodosNisira(bool marcar)
        {
            dataGridView2.EndEdit();

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;
                fila.Cells[0].Value = marcar;
            }
        }

        /// <summary>
        /// Parte las filas seleccionadas en documentos de NISIRA. La clave es
        /// IdAd (el id del informe de auditoria): es unico por informe, y todas
        /// las lineas de un mismo informe comparten cabecera y viajan en un
        /// solo POST. Si esa columna no viniera, se cae a la glosa de cabecera
        /// y, en ultimo caso, cada fila va como su propio documento.
        /// </summary>
        private List<IGrouping<string, DataRow>> AgruparDocumentosNisira(List<DataRow> filas)
        {
            var columnas = filas.First().Table.Columns;

            if (columnas.Contains("IdAd"))
                return filas.GroupBy(f => f["IdAd"].ToString()).ToList();

            if (columnas.Contains("glosa_Cab"))
                return filas.GroupBy(f => f["glosa_Cab"].ToString()).ToList();

            return filas.Select((f, i) => new { f, i })
                        .GroupBy(x => x.i.ToString(), x => x.f)
                        .ToList();
        }

        /// <summary>
        /// Devuelve, en texto, el o los cuerpos JSON tal cual se enviarian al
        /// POST de NISIRA. Es exactamente el mismo armado que usa el envio
        /// real, asi que lo que se ve aca es lo que viaja.
        /// </summary>
        private string ConstruirJsonPreviewNisira(List<DataRow> filas)
        {
            var grupos = AgruparDocumentosNisira(filas);
            var texto = new System.Text.StringBuilder();

            texto.AppendLine("POST " + CapaDatos.cd_conexionApi.baseUrlNisira + "/api/liquidacion-gasto/save");
            texto.AppendLine("Content-Type: application/json");
            texto.AppendLine("Authorization: Bearer <token de loginb2b>");
            texto.AppendLine();
            texto.AppendLine("Documentos a enviar: " + grupos.Count +
                             "   (un POST por documento)");
            texto.AppendLine(new string('=', 70));

            int n = 1;
            foreach (var grupo in grupos)
            {
                var faltantes = new HashSet<string>();
                var documento = ConstruirSolicitudNisira(grupo.ToList(), faltantes);

                texto.AppendLine();
                texto.AppendLine("----- POST " + n + " de " + grupos.Count +
                                 "   IdAd: " + grupo.Key +
                                 "   lineas: " + documento.detalle.Count + " -----");

                if (faltantes.Count > 0)
                {
                    texto.AppendLine("// ATENCION, columnas que no se encontraron:");
                    foreach (var f in faltantes) texto.AppendLine("//   - " + f);
                }

                texto.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(
                    documento, Newtonsoft.Json.Formatting.Indented));
                n++;
            }

            return texto.ToString();
        }

        /// <summary>
        /// Arma el documento (cabecera + detalle) que exige NISIRA para
        /// "api/liquidacion-gasto/save".
        ///
        /// Desde la versión 8 de SP_MOSTRAR_REPORTE_RENDICION_DETALLEGASTOS el
        /// propio SP devuelve las columnas ya con el nombre del campo NISIRA y
        /// el sufijo _Cab o _Det, así que acá no se traduce nada: se lee la
        /// columna que corresponde. Si el SP cambia un nombre, el aviso de
        /// "faltantes" lo señala antes de enviar.
        /// </summary>
        private NisiraLiquidacionRequest ConstruirSolicitudNisira(List<DataRow> filasDocumento, HashSet<string> faltantes)
        {
            DataRow cab = filasDocumento[0]; //la cabecera se repite en cada fila

            var doc = new NisiraLiquidacionRequest
            {
                idcobrarpagardoc = ColNisira(cab, "idcobrarpagardoc_Cab", "", "idcobrarpagardoc", faltantes),
                idsucursal = ColNisira(cab, "idsucursal_Cab", "001", "idsucursal", faltantes),
                idtipomov = ColNisira(cab, "idtipomov_Cab", "0001", "idtipomov", faltantes),
                iddocumento = ColNisira(cab, "iddocumento_Cab", "LGS", "iddocumento", faltantes),
                serie = ColNisira(cab, "serie_Cab", "0001", "serie", faltantes),
                Fecha = FormatearFechaNisira(cab, "Fecha_Cab", faltantes),
                idclieprov = ColNisira(cab, "idclieprov_Cab", "", "idclieprov (cabecera)", faltantes),
                idmoneda = ColNisira(cab, "idmoneda_Cab", "", "idmoneda (cabecera)", faltantes),
                idarea = ColNisira(cab, "idarea_Cab", "", "idarea", faltantes),
                idmediopago = ColNisira(cab, "idmediopago_Cab", "", "idmediopago", faltantes),
                idunidadnegocio = ColNisira(cab, "idunidadnegocio_Cab", "", "idunidadnegocio", faltantes),
                glosa = ColNisira(cab, "glosa_Cab", "", "glosa (cabecera)", faltantes)
            };

            foreach (var fila in filasDocumento)
            {
                // pimpuesto_Det trae el MONTO del IGV, no el porcentaje. NISIRA
                // pide los dos campos, asi que el porcentaje se deriva.
                decimal afecto = ColNisiraDecimal(fila, "afecto_Det", "afecto", faltantes);
                decimal impuesto = ColNisiraDecimal(fila, "pimpuesto_Det", "impuesto", faltantes);
                decimal pimpuesto = afecto != 0 ? Math.Round(impuesto / afecto * 100, 4) : 0;

                doc.detalle.Add(new NisiraLiquidacionDetalle
                {
                    item = ColNisira(fila, "Item_Det", "", "item", faltantes),
                    glosa = ColNisira(fila, "glosa_Det", "", "glosa (detalle)", faltantes),
                    idclieprov = ColNisira(fila, "idclieprov_Det", "", "idclieprov (detalle)", faltantes),
                    idtipomov = ColNisira(fila, "idtipomov_Det", "001", "idtipomov (detalle)", faltantes),
                    iddocumento = ColNisira(fila, "iddocumento_Det", "OTR", "iddocumento (detalle)", faltantes),
                    serie = ColNisira(fila, "Serie_Det", "", "serie (detalle)", faltantes),
                    numero = ColNisira(fila, "Numero_Det", "", "numero (detalle)", faltantes),
                    // Fecha_Det ya viene como yyyyMMdd desde el CONVERT(...,112).
                    Fecha_D = ColNisira(fila, "Fecha_Det", "", "Fecha (detalle)", faltantes),
                    idcuenta = ColNisira(fila, "idcuenta_Det", "", "idcuenta", faltantes),
                    idccosto = ColNisira(fila, "idccosto_Det", "", "idccosto", faltantes),
                    iddestino = ColNisira(fila, "iddestino_Det", "001", "iddestino", faltantes),
                    idmoneda = ColNisira(fila, "idmoneda_Det", "01", "idmoneda (detalle)", faltantes),
                    idregimen = RegimenNisira(fila, faltantes),
                    afecto = afecto,
                    inafecto = ColNisiraDecimal(fila, "Inafecto_Det", "inafecto", faltantes),
                    pimpuesto = pimpuesto,
                    impuesto = impuesto,
                    importe = ColNisiraDecimal(fila, "Importe_Det", "importe", faltantes)
                });
            }

            return doc;
        }

        /// <summary>
        /// El SELECT del SP trae idregimen_Det DOS VECES: el primero es la
        /// constante '01' y el segundo es el calculado (03 para planilla de
        /// movilidad o cuando el IGV es cero). ADO.NET renombra el repetido a
        /// idregimen_Det1, y ese es el que vale.
        /// </summary>
        private string RegimenNisira(DataRow fila, HashSet<string> faltantes)
        {
            if (fila.Table.Columns.Contains("idregimen_Det1"))
                return ColNisira(fila, "idregimen_Det1", "01", "idregimen", faltantes);

            return ColNisira(fila, "idregimen_Det", "01", "idregimen", faltantes);
        }

        private string FormatearFechaNisira(DataRow fila, string nombreColumna, HashSet<string> faltantes)
        {
            var texto = ColNisira(fila, nombreColumna, "", nombreColumna, faltantes);

            // Las fechas locales vienen como "23/09/2026" o "1/09/2026" (día primero);
            // DateTime.TryParse normal puede interpretarlas mal según la configuración
            // regional del servidor, así que se fuerza el formato día/mes/año.
            // Fecha_Cab llega como fecha real del SP; las de texto pueden venir
            // en dia/mes/año o en el ISO que arma SQL Server.
            if (fila.Table.Columns.Contains(nombreColumna) &&
                fila[nombreColumna] is DateTime)
            {
                return ((DateTime)fila[nombreColumna]).ToString("yyyyMMdd");
            }

            if (texto.Length == 8 && texto.All(char.IsDigit))
                return texto; //ya viene en yyyyMMdd

            string[] formatos = { "dd/MM/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy",
                                  "yyyy-MM-dd", "yyyyMMdd" };
            if (DateTime.TryParseExact(texto, formatos, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                return fecha.ToString("yyyyMMdd");
            }

            return dateTimePicker_FecInicio.Value.ToString("yyyyMMdd");
        }

        //---------------------------------------------------------------
        //  QA NISIRA: validación de solo lectura contra el API real
        //  (login + listado), sin registrar nada todavía.
        //---------------------------------------------------------------
        private async void pictureBox_Enviar_NisiraQA_Click(object sender, EventArgs e)
        {
            var filas = ObtenerFilasSeleccionadasNisira();

            if (filas.Count == 0)
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
                return;
            }

            var resumen = ConstruirResumenPreviewNisira(filas);

            using (var frm = new FrmResumenEnvioNisira(resumen, "VALIDACIÓN QA - NISIRA", "Validar", "Total",
                () => ConstruirJsonPreviewNisira(filas)))
            {
                if (frm.ShowDialog() != DialogResult.OK) return;
            }

            Cursor.Current = Cursors.WaitCursor;
            var frbm = new Msbox.frm_cargando();
            frbm.Show(this);
            frbm.label1.Text = "VALIDANDO EN NISIRA...";

            try
            {
                var api = new cn_apinisira();
                var login = await api.LoginAsync();

                if (!login.Success)
                {
                    MessageBox.Show($"❌ No se pudo autenticar en NISIRA:\n{login.Message}\n\n{login.RawResponse}");
                    return;
                }

                var listado = await api.ListarLiquidacionesAsync(
                    login.Data, dateTimePicker_FecInicio.Value, dateTimePicker_FecFin.Value);

                if (!listado.Success)
                {
                    MessageBox.Show($"❌ Error al consultar NISIRA:\n{listado.Message}\n\n{listado.RawResponse}");
                    return;
                }

                MessageBox.Show(
                    "✅ Conexión validada con NISIRA.\n" +
                    $"Liquidaciones ya registradas entre {dateTimePicker_FecInicio.Value:dd/MM/yyyy} y {dateTimePicker_FecFin.Value:dd/MM/yyyy}: {listado.Data.Count}\n\n" +
                    $"Registros seleccionados localmente: {filas.Count}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al validar en NISIRA:\n" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close();
            }
        }

        //---------------------------------------------------------------
        //  ENVIAR A NISIRA: envío real (login + registro de liquidación).
        //---------------------------------------------------------------
        private async void pictureBox_enviardatos_Nisira_Click(object sender, EventArgs e)
        {
            var filas = ObtenerFilasSeleccionadasNisira();

            if (filas.Count == 0)
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
                return;
            }

            var resumen = ConstruirResumenPreviewNisira(filas);

            using (var frm = new FrmResumenEnvioNisira(resumen, "RESUMEN DE ENVÍO A NISIRA", "Enviar", "Total",
                () => ConstruirJsonPreviewNisira(filas)))
            {
                if (frm.ShowDialog() != DialogResult.OK) return;
            }

            var grupos = AgruparDocumentosNisira(filas);

            Cursor.Current = Cursors.WaitCursor;
            var frbm = new Msbox.frm_cargando();
            frbm.Show(this);
            frbm.label1.Text = "ENVIANDO DATOS A NISIRA...";

            var resultados = new List<NisiraEnvioResultado>();

            try
            {
                var api = new cn_apinisira();
                var login = await api.LoginAsync();

                if (!login.Success)
                {
                    MessageBox.Show($"❌ No se pudo autenticar en NISIRA:\n{login.Message}\n\n{login.RawResponse}");
                    return;
                }

                foreach (var grupo in grupos)
                {
                    var filasGrupo = grupo.ToList();
                    var faltantes = new HashSet<string>();
                    var documento = ConstruirSolicitudNisira(filasGrupo, faltantes);

                    if (faltantes.Count > 0)
                    {
                        MessageBox.Show(
                            "⚠️ No se pudo armar el documento para NISIRA: faltan columnas por confirmar.\n\n" +
                            "Campos NISIRA sin columna reconocida:\n- " + string.Join("\n- ", faltantes) +
                            "\n\nRevise los encabezados reales del grid (clic en 'Buscar') y actualice " +
                            "ConstruirSolicitudNisira en Frm_RindeGastoNisiraAPI.cs con los nombres correctos."
                        );
                        return;
                    }

                    var resp = await api.GuardarLiquidacionAsync(login.Data, documento);

                    resultados.Add(new NisiraEnvioResultado
                    {
                        IdRend = grupo.Key,
                        Documento = resp.Data?.id ?? resp.Data?.codigo ?? "",
                        Exito = resp.Success,
                        Mensaje = resp.Success ? (resp.Data?.message ?? "OK") : resp.Message
                    });
                }

                int exitosos = resultados.Count(r => r.Exito);
                int errores = resultados.Count(r => !r.Exito);

                string detalle = string.Join("\n", resultados.Select(r =>
                    (r.Exito ? "✅ " : "❌ ") + $"Rendición {r.IdRend}: {r.Mensaje}"));

                MessageBox.Show(
                    $"ENVÍO A NISIRA FINALIZADO\n\n" +
                    $"Documentos procesados: {resultados.Count}\n" +
                    $"Exitosos: {exitosos}\n" +
                    $"Con errores: {errores}\n\n" +
                    detalle
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al enviar datos a NISIRA:\n" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close();
            }
        }
    }
}
