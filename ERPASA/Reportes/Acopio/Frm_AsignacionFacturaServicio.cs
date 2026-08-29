using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_SST;
using ERPASA.Msbox;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_AsignacionFacturaServicio : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cn_contabilidad objcncont = new cn_contabilidad();
        private CheckBox chkHeader = new CheckBox();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg2;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        public Frm_AsignacionFacturaServicio()
        {
            InitializeComponent();
        }

        private void Frm_AsignacionFacturaServicio_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //textBox_Dni.Focus();
            HabilitarBoton();
            dataGridView2.AllowUserToAddRows = false;

            //
            guna2TextBox_fecha_remision.MaxLength = 10;

            //
            AgregarCheckHeader();

        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_detalle_empresa.Text == comboBox_detalle_empresa.Text)
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_detalle_empresa.Text);
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void AgregarCheckHeader()
        {
            Rectangle rect = dataGridView2.GetCellDisplayRectangle(0, -1, true);

            chkHeader.Size = new Size(15, 15);
            chkHeader.Location = new Point(
                rect.X + 5,
                rect.Y + (rect.Height - chkHeader.Height) / 2);

            chkHeader.CheckedChanged -= chkHeader_CheckedChanged;
            chkHeader.CheckedChanged += chkHeader_CheckedChanged;

            dataGridView2.Controls.Add(chkHeader);
        }


        private void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.SuspendLayout();

            try
            {
                foreach (DataGridViewRow fila in dataGridView2.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        fila.Cells[0].Value = chkHeader.Checked;
                    }
                }

                dataGridView2.Refresh();
                HabilitarBoton();
                ActualizarTotales();
                guna2TextBox_guia_remision.Focus();

            }
            finally
            {
                dataGridView2.ResumeLayout();
            }
        }

        public void BuscarReporte()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{

            string emp, sed, cult, empText = string.Empty, sedText = string.Empty
                , cultText = string.Empty
                ;

            ////////////////////////////////////
            if (comboBox_detalle_empresa.InvokeRequired)
            {
                comboBox_detalle_empresa.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_detalle_empresa.Text;
                }));
            }
            else
            {
                empText = comboBox_detalle_empresa.Text;
            }
            ////////////////////////////////////
            if (comboBox_detalle_sede.InvokeRequired)
            {
                comboBox_detalle_sede.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_detalle_sede.Text;
                }));
            }
            else
            {
                sedText = comboBox_detalle_sede.Text;
            }

            ////////////////////////////////////
            if (comboBox_Cultivo.InvokeRequired)
            {
                comboBox_Cultivo.Invoke(new MethodInvoker(() =>
                {
                    cultText = comboBox_Cultivo.Text;
                }));
            }
            else
            {
                cultText = comboBox_Cultivo.Text;
            }
            ///////7
            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }
            if (sedText == "SELECCIONE")
            {
                sed = "%";
            }
            else
            {
                sed = sedText;
            }
            if (cultText == "SELECCIONE")
            {
                cult = "%";
            }
            else
            {
                cult = cultText;
            }

            dtg2 = cn_packing.ListaGuiaPallet(3, dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult);

        }


        //
        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells["Estado"].Value.ToString() == "ELIMINADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Red; //DarkRed              
                }

            }
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
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    BuscarReporte();
                });

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg2;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();

                // Reiniciar Check encabezado
                //chkHeader.Checked = false;

                OrigenColorfila();
                HabilitarBoton();
                ActualizarTotales();
                foreach (DataColumn column in dtg2.Columns)
                {
                    column.ReadOnly = false; // Deshabilita el solo lectura en todas las columnas
                }
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                }
                // Habilitar la edición solo para la primera columna
                if (dataGridView2.Columns.Count > 0)
                {
                    dataGridView2.Columns[0].ReadOnly = false; // Permitir la edición solo de la primera columna
                }
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //INMOVILIZAR LAS COLUMNAS PARA SU ORDENAMIENTO
                foreach (DataGridViewColumn columna in dataGridView2.Columns)
                {
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Centrar encabezados
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // Centrar la columna Check
                if (dataGridView2.Columns.Count > 0)
                {
                    dataGridView2.Columns[0].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }


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
                    OrigenColorfila();
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg2.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                    OrigenColorfila();
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clic en encabezados
            if (e.RowIndex < 0) return;

            // Columna del CheckBox
            int colCheck = 0;

            // Obtener el valor actual
            bool valorActual = Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[colCheck].Value ?? false);

            // Invertir el valor
            dataGridView2.Rows[e.RowIndex].Cells[colCheck].Value = !valorActual;

            // Actualizar contador y suma
            ActualizarTotales();
            HabilitarBoton();
        }

        private void ActualizarTotales()
        {
            int cantidad = 0;
            decimal totalPeso = 0;
            decimal totalJabas = 0;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                bool seleccionado = Convert.ToBoolean(fila.Cells[0].Value);

                if (seleccionado)
                {
                    cantidad++;

                    decimal peso;
                    decimal.TryParse(fila.Cells["PesoNeto"].Value?.ToString(), out peso);
                    totalPeso += peso;

                    decimal jabas;
                    decimal.TryParse(fila.Cells["jabas"].Value?.ToString(), out jabas);
                    totalJabas += jabas;
                }
            }

            label_catidad_registros.Text = $"Registros: {cantidad} ";
            label_cant_jabas.Text = $"Jabas: {totalJabas:N2} ";
            label_total_peso.Text = $"Peso Neto: {totalPeso:N2}";
        }

        private void HabilitarBoton()
        {
            bool habilitar = dataGridView2.Rows
                .Cast<DataGridViewRow>()
                .Where(f => !f.IsNewRow)
                .Any(f => Convert.ToBoolean(f.Cells[0].Value ?? false));

            // Solo cuando se deshabilita
            if (!habilitar)
            {
                guna2TextBox_guia_remision.Clear();
                guna2TextBox_fecha_remision.Clear();
                guna2Button_EliminarGuia.Visible = false;
            }
            else
            {
                guna2Button_EliminarGuia.Visible = true;
            }

            groupBox_Guia.Enabled = habilitar;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frm_ReporteFacturaServicio frbm = new Frm_ReporteFacturaServicio();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void guna2TextBox_fecha_remision_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, Ctrl+C, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo números y guión
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox_fecha_remision_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox_fecha_remision.Text))
                return;

            if (!DateTime.TryParseExact(
                    guna2TextBox_fecha_remision.Text,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Ingrese una fecha válida con el formato: yyyy-MM-dd");

                e.Cancel = true;
                guna2TextBox_fecha_remision.SelectAll();
            }
        }

        private void guna2Button_SaveGuia_Click(object sender, EventArgs e)
        {
            validarFactura();
        }

        public void validarFactura()
        {
            if (guna2TextBox_guia_remision.Text == "")
            {
                MessageBox.Show("INGRESE FACTURA DE SERVICIO");
            }

            else if (guna2TextBox_fecha_remision.Text == "")
            {
                MessageBox.Show("INGRESE FECHA DE FACTURA");
            }
            else
            {
                GuardarDatos();
            }

        }

        public void GuardarDatos()
        {
            int filasSeleccionadas = dataGridView2.Rows.Cast<DataGridViewRow>()
                .Count(r => Convert.ToBoolean(r.Cells[0].Value) == true);

            if (filasSeleccionadas == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar al menos un registro.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Desea guardar la Factura de servicio?",
                "Guardar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[0].Value))
                    continue;

                string mensaje = objcncont.GuardarActualizarGuiaPalets(
                    Convert.ToBoolean(row.Cells[0].Value),          // Programado
                    Convert.ToInt32(row.Cells[2].Value),            // IdRec
                    row.Cells[3].Value.ToString(),                  // NumeroPallet
                    dateTimePicker_FecInicio.Value.Date,            // FecProgramado
                    guna2TextBox_guia_remision.Text.Trim(),                      // NumeroGuia
                    Convert.ToDateTime(guna2TextBox_fecha_remision.Text).Date, // FechaGuia
                    "PT",                                           // Documento
                    null,                                           // Obs
                    "S",                                            // Estado
                    ce_usuario.FechaSistema(),                      // FecCre
                    ce_usuario.usecod,                              // UseReg
                    ce_usuario.HostName(),                          // Hostname
                    ce_usuario.FechaSistema(),                      // FecEdit
                    ce_usuario.usecod,                              // UseEdit
                    0);                                             // UseElim


                if (mensaje.Contains("Ya cerro el proceso"))
                {
                    MessageBox.Show(
                        mensaje,
                        "PROCESO CERRADO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
                else if (mensaje == "Registro guardado correctamente." ||
                    mensaje == "Registro actualizado correctamente.")
                {
                    //MessageBox.Show(
                    //    mensaje,
                    //    "Save/Update",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);

                    //return;
                }
                else
                {
                    MessageBox.Show(
                        mensaje,
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }
            }

            MessageBox.Show(
                "GUARDADO CORRECTAMENTE",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CargarDatosSync();
            // Si deseas, aquí puedes volver a cargar el DataGridView
            // ListarDatos();
        }


        private void guna2Button_EliminarGuia_Click(object sender, EventArgs e)
        {
            int filasSeleccionadas = dataGridView2.Rows.Cast<DataGridViewRow>()
                .Count(r => Convert.ToBoolean(r.Cells[0].Value) == true);

            if (filasSeleccionadas == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar al menos un registro.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Desea Eliminar Factura de servicio?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (resultado != DialogResult.Yes)
                return;


            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[0].Value))
                    continue;

                string mensaje = objcncont.GuardarActualizarGuiaPalets(
                    Convert.ToBoolean(0),          // Programado
                    Convert.ToInt32(row.Cells[2].Value),            // IdRec
                    row.Cells[3].Value.ToString(),                  // NumeroPallet
                    dateTimePicker_FecInicio.Value.Date,            // FecProgramado
                    null,                      // NumeroGuia
                    null, // FechaGuia
                    "PT",                       // Documento
                    null,                     // Obs
                    "S",                                            // Estado
                    ce_usuario.FechaSistema(),                      // FecCre
                    ce_usuario.usecod,                              // UseReg
                    ce_usuario.HostName(),                          // Hostname
                    ce_usuario.FechaSistema(),                      // FecEdit
                    ce_usuario.usecod,                              // UseEdit
                    0);                                             // UseElim

                if (mensaje.Contains("Ya cerro el proceso"))
                {
                    MessageBox.Show(
                        mensaje,
                        "PROCESO CERRADO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
                else if (mensaje != "Registro guardado correctamente." &&
                    mensaje != "Registro actualizado correctamente.")
                {
                    MessageBox.Show(
                        "REGISTRO ELIMINADO CORRECTAMENTE",//mensaje,
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            MessageBox.Show(
                "ELIMINADO CORRECTAMENTE",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            CargarDatosSync();

        }


    }
}
