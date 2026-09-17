using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_RepDetalle_RindeGastoNisira : Form
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

        public Frm_RepDetalle_RindeGastoNisira()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_RepDetalle_RindeGastoNisira_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            dataGridView2.AllowUserToAddRows = false;
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
            guna2TextBox_voucher.CharacterCasing = CharacterCasing.Upper;
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
                , politica, tipogasto, ger, area, estado, 3);

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

        private void guna2Button_SaveVoucher_Click(object sender, EventArgs e)
        {
            GuardarVoucher();
        }

        private void guna2Button_EliminarVoucher_Click(object sender, EventArgs e)
        {
            EliminarVoucher();
        }

        public void GuardarVoucher()
        {
            guna2Button_SaveVoucher.Focus();
            if (guna2TextBox_voucher.Text == string.Empty)
            {
                MessageBox.Show("INGRESE NUMERO VOUCHER");
                return;
            }

            bool existeSeleccionado = false;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool seleccionado = row.Cells[0].Value != null &&
                                    Convert.ToBoolean(row.Cells[0].Value);

                if (seleccionado)
                {
                    existeSeleccionado = true;
                    break;
                }
            }

            if (!existeSeleccionado)
            {
                MessageBox.Show("DEBE SELECCIONAR AL MENOS UN GASTO");
                return;
            }

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "SE GUARDARAN SOLO REGISTROS SELECCIONADOS";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Guardar solo los gastos seleccionados
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        bool seleccionado = row.Cells[0].Value != null &&
                                            Convert.ToBoolean(row.Cells[0].Value);

                        if (seleccionado)
                        {
                            int gasto = Convert.ToInt32(
                                row.Cells[1].Value?.ToString().Trim()
                                );

                            objcncont.GuardarVoucherRindeGasto(
                        1,//id
                        gasto,//id rend
                        guna2TextBox_voucher.Text.Trim(),//voucher

                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );

                            // Aquí llamas tu método de guardado
                            // GuardarGasto(gasto, guna2TextBox_voucher.Text);

                            //MessageBox.Show($"Guardando gasto: {gasto}");
                        }
                    }
                }
                finally
                {
                    MessageBox.Show("REGISTROS GUARDADOS CORRECTAMENTE");

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        CargarDatosSync();
                    }

                    finally
                    {
                        Cursor.Current = Cursors.Default;
                        guna2TextBox_voucher.Text = string.Empty;
                    }
                }
            }

        }

        public void EliminarVoucher()
        {
            guna2Button_SaveVoucher.Focus();

            bool existeSeleccionado = false;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool seleccionado = row.Cells[0].Value != null &&
                                    Convert.ToBoolean(row.Cells[0].Value);

                if (seleccionado)
                {
                    existeSeleccionado = true;
                    break;
                }
            }

            if (!existeSeleccionado)
            {
                MessageBox.Show("DEBE SELECCIONAR AL MENOS UN GASTO");
                return;
            }

            string MessageBoxTitle = "ELIMINAR";
            string MessageBoxContent = "SE ELIMINARAN VOUCHER DE LOS REGISTROS SELECCIONADOS";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Guardar solo los gastos seleccionados
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        bool seleccionado = row.Cells[0].Value != null &&
                                            Convert.ToBoolean(row.Cells[0].Value);

                        if (seleccionado)
                        {
                            int gasto = Convert.ToInt32(
                                row.Cells[1].Value?.ToString().Trim()
                                );

                            objcncont.GuardarVoucherRindeGasto(
                        2,//id
                        gasto,//id rend
                        guna2TextBox_voucher.Text.Trim(),//voucher

                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );

                            //MessageBox.Show($"Eliminado gasto: {gasto}");
                        }
                    }
                }
                finally
                {
                    MessageBox.Show("VOUCHER ELIMINADOS CORRECTAMENTE");

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        CargarDatosSync();
                    }

                    finally
                    {
                        Cursor.Current = Cursors.Default;
                        guna2TextBox_voucher.Text = string.Empty;
                    }
                }
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

                // Agregar checkbox editable
                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //chk.Name = "Seleccionar";
                //chk.HeaderText = "";
                //chk.Width = 40;
                //chk.ReadOnly = false;

                //dataGridView2.Columns.Insert(0, chk);

                //// Habilitar edición únicamente en la primera columna
                //dataGridView2.Columns[0].ReadOnly = false;

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
    }
}
