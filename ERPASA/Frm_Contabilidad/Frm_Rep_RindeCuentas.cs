using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Comercial;
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
    public partial class Frm_Rep_RindeCuentas : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg2, dtGerencia, dtArea, dtEstado;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        public Frm_Rep_RindeCuentas()
        {
            InitializeComponent();
        }

        private void Frm_Rep_RindeCuentas_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            dataGridView2.AllowUserToAddRows = false;
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Gerencia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_estado.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            dtGerencia = cn_logistica.ListaGerencia();
            dtArea = cn_logistica.ListaAreaTI();
            dtEstado = cn_contabilidad.RendEstadoGasto();
            // Crear una nueva fila al inicio
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
            dtGerencia.Rows.InsertAt(row3, 0);
            dtArea.Rows.InsertAt(row4, 0);
            dtEstado.Rows.InsertAt(row5, 0);

            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            string emp, politica, empText = string.Empty
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
                , "%", "%", ger, area, estado, 6);

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
            if (e.RowIndex < 0) return;

            // Obtenemos la fila en la que se hizo el doble clic
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

            // Asignamos los valores de las celdas a las propiedades de la clase
            ce_informegastos.IdInf = Convert.ToInt32(row.Cells[0].Value);  // Columna 0 para IdInf
            ce_informegastos.gastopara = row.Cells[1].Value?.ToString();       // Columna 1 para RazonSocial
            ce_informegastos.gastode = row.Cells[2].Value?.ToString();       // Columna 2 para Ruc
            ce_informegastos.gastoasunto = row.Cells[3].Value?.ToString();       // Columna 3 para FechaEmision
            ce_informegastos.fechapresentacion = row.Cells[4].Value?.ToString();       // Columna 4 para HoraEmision
            ce_informegastos.fecharendir = row.Cells[5].Value?.ToString();       // Columna 5 para Periodo
            ce_informegastos.descripcion_gasto = row.Cells[6].Value?.ToString();       // Columna 6 para Dni
            ce_informegastos.Dni = row.Cells[7].Value?.ToString();       // Columna 7 para ApeNom
            ce_informegastos.Cantidad = row.Cells[8].Value?.ToString();  // Columna 8
            ce_informegastos.Total = row.Cells[9].Value?.ToString(); // Columna 9 
            ce_informegastos.CantidadSoles = row.Cells[10].Value?.ToString();  // Columna 8
            ce_informegastos.MontoSoles = row.Cells[11].Value?.ToString(); // Columna 9 
            ce_informegastos.CantidadDolares = row.Cells[12].Value?.ToString();  // Columna 8
            ce_informegastos.MontoDolares = row.Cells[13].Value?.ToString(); // Columna 9 

            Frm_DetalleGastoPrint frbm = new Frm_DetalleGastoPrint();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
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
