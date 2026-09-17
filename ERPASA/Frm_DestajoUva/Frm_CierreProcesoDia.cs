using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Comercial;
using ERPASA.Msbox;
using ExcelDataReader;
using Google.Apis.Util;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_CierreProcesoDia : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;
        cn_comercial objcncomer = new cn_comercial();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        List<RegistroQR> lista = new List<RegistroQR>();
        DataTable dtgCampos;


        public static DataTable dtgTodosCampos = new DataTable();

        private CancellationTokenSource _cts;


        public Frm_CierreProcesoDia()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void Frm_CierreProcesoDia_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            PonerOscuroComboBox();
            CargarDatosComboBox();
            guna2TextBox_Buscar.Text = guna2TextBox_Buscar.Text.ToUpper();
            guna2TextBox_Buscar.Focus();
            inicializarDtgCampos();
            CargarDatosSync();
            //comboBox_nave.Text = "NAVE 01";
        }

        public void inicializarDtgCampos()
        {
            dtgCampos = new DataTable();

            dtgCampos.Columns.Add("TramaReal", typeof(string));
            dtgCampos.Columns.Add("CodPre", typeof(int));
            dtgCampos.Columns.Add("Detalle", typeof(string));
            dtgCampos.Columns.Add("CodSticker", typeof(int));

        }

        public void PonerOscuroComboBox()
        {
            ////ALTO RIESGO
            //comboBox_nave.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_linea.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Puestotrabajo.DropDownStyle = ComboBoxStyle.DropDownList;
            ////DATAGRIDVIEW
        }


        public void CargarDatosComboBox()
        {
            //comboBox_nave.DataSource = cn_packing.ListaNave();
            //comboBox_nave.DisplayMember = "Nave"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_nave.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_linea.DataSource = cn_packing.ListaLinea();
            //comboBox_linea.DisplayMember = "Linea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_linea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_Puestotrabajo.DataSource = cn_packing.ListaPuestoTrabajo();
            //comboBox_Puestotrabajo.DisplayMember = "PuestoTrabajo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Puestotrabajo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void guna2TextBox_LecturaSticker_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "BUSCANDO REPORTE...";

            try
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.SuspendLayout();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }));

                // 1) Procesar datos sin tocar controles
                await Task.Run(() =>
                {
                    BuscarReporteDestajo();   // ❗ DEBE trabajar solo con dtg (DataTable)
                });

                // 2) Actualizar controles en UI thread
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dtg;
                    dataGridView1.AllowUserToAddRows = false;

                    label_estado_reg.Text = "Registros: " + dtg.Rows.Count.ToString();
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    // 🔓 Hacer todas las columnas editables

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.MinimumWidth = 80;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // CENTRAR VALORES
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // CENTRAR CABECERAS                        
                    }

                }));

                dataGridView1.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.ResumeLayout();
                }));
                Cursor.Current = Cursors.Default;
                frbm.Close();
            }
        }


        public void BuscarReporteDestajo()
        {
            //////var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //////if (val == true)
            //////{

            //string naveText = string.Empty, lineaText = string.Empty
            //    , trabajoText = string.Empty;
            //string nave, linea, trabajo;

            //////////////////////////////////////
            //if (comboBox_nave.InvokeRequired)
            //{
            //    comboBox_nave.Invoke(new MethodInvoker(() =>
            //    {
            //        naveText = comboBox_nave.Text;
            //    }));
            //}
            //else
            //{
            //    naveText = comboBox_nave.Text;
            //}
            //////////////////////////////////////
            //if (comboBox_linea.InvokeRequired)
            //{
            //    comboBox_linea.Invoke(new MethodInvoker(() =>
            //    {
            //        lineaText = comboBox_linea.Text;
            //    }));
            //}
            //else
            //{
            //    lineaText = comboBox_linea.Text;
            //}
            //////////////////////////////////////
            //if (comboBox_Puestotrabajo.InvokeRequired)
            //{
            //    comboBox_Puestotrabajo.Invoke(new MethodInvoker(() =>
            //    {
            //        trabajoText = comboBox_Puestotrabajo.Text;
            //    }));
            //}
            //else
            //{
            //    trabajoText = comboBox_Puestotrabajo.Text;
            //}


            //if (naveText == "SELECCIONE")
            //{
            //    nave = "%";
            //}
            //else
            //{
            //    nave = naveText;
            //}
            //if (lineaText == "SELECCIONE")
            //{
            //    linea = "%";
            //}
            //else
            //{
            //    linea = lineaText;
            //}
            //if (trabajoText == "SELECCIONE")
            //{
            //    trabajo = "%";
            //}
            //else
            //{
            //    trabajo = trabajoText;
            //}


            //dataGridView3.ReadOnly = true;

            var resultado = cn_planilla.ReporteCierreProcesoDia(
                                        Fecha_Inicio.Value.Date);

            // Mostrar detalle en DataGridView
            dtg = resultado;
            /*
            dtg = cn_planilla.DestajoLecturaSticker(Fecha_Proceso.Value.Date
                , nave, linea);
            */
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar fila válida
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            // ===== COLUMNA 2 → FECHA =====
            if (fila.Cells[1].Value != null &&
                DateTime.TryParse(fila.Cells[1].Value.ToString(), out DateTime fecha))
            {
                Fecha_Inicio.Value = fecha;
            }

            // ===== COLUMNA 3 → BOOL / TOGGLE =====
            if (fila.Cells[2].Value != null)
            {
                bool estado = Convert.ToBoolean(fila.Cells[2].Value);
                guna2ToggleSwitch1.Checked = estado;
            }
        }


        private void comboBox_linea_SelectedValueChanged(object sender, EventArgs e)
        {
            //CargarDatosSync();
            guna2TextBox_Buscar.Focus();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string value = cell.Value?.ToString().Trim();

            // ✔ Permitir editar SI:
            //   - está vacío
            //   - es exactamente "0"
            if (value == "0")
            {
                e.Cancel = false; // permitir edición
            }
            else
            {
                e.Cancel = true; // ❌ bloquear edición
            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (txt != null)
            {
                txt.KeyPress -= Txt_KeyPress; // evitar múltiples suscripciones
                txt.KeyPress += Txt_KeyPress;
            }
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y teclas de control (borrar, flechas, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // bloquea la tecla
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Fecha_Proceso_ValueChanged(object sender, EventArgs e)
        {
            guna2TextBox_Buscar.Focus();
            CargarDatosSync();
            //MessageBox.Show("Fecha de proceso cambiada a: " + Fecha_Proceso.Value.ToString("yyyy-MM-dd"));
        }

        private void comboBox_nave_SelectedValueChanged(object sender, EventArgs e)
        {
            guna2TextBox_Buscar.Focus();
        }

        private void pictureBox_agregarErrores_Click(object sender, EventArgs e)
        {

            ExportarExcel2();
        }

        private void pictureBox_Search_Click(object sender, EventArgs e)
        {
            CargarDatosSync();
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
                        objexcel_progress.exportarexcelTimer(dataGridView1, frbm, token);
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

        private void guna2TextBox_LecturaSticker_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBox_Buscar.Text.Trim().Replace("'", "''");

            if (dtg != null)
            {
                DataView dv = dtg.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void GuardarDatosSync()
        {

            string MessageBoxTitle = "CERRAR PROCESO";
            string MessageBoxContent = "¿Desea cerrar Proceso del dia: \n" +
                Fecha_Inicio.Value.ToString("yyyy/MM/dd") + " ?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                // Mostrar el formulario de carga de manera no modal
                Msbox.frm_guardando frbm = new Msbox.frm_guardando();
                //frbm.StartPosition = FormStartPosition.CenterParent;
                frbm.Show(this); // Mostrar como formulario hijo
                frbm.label1.Text = "GUARDANDO DATOS..."; // Actualizar el texto del formulario de carga

                try
                {
                    // Cargar datos en segundo plano
                    await Task.Run(() =>
                    {
                        //MessageBox.Show("Hola");
                        GuardarCierreProcesoDia();
                    });


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar datos: " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    frbm.Close();
                }
            }
        }

        public void GuardarCierreProcesoDia()
        {

            bool estado = guna2ToggleSwitch1.Checked;

            objcnlog.GuardarCierreProcesoDestajo(
                        0,//id
                        Fecha_Inicio.Value.Date,//fecha
                        estado,//status
                        "",//id nave
                        "",//nave
                        "",//id linea
                        "",//linea
                        "",//obs
                        "S", //estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        0,
                        ""
                        );


            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();
            //guna2ToggleSwitch1.Checked = false;
            // Usar Invoke para llamar a CargarDatosSync en el hilo principal
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CargarDatosSync));
            }
            else
            {
                CargarDatosSync();
            }
        }


        private async void AbrirDatosSync()
        {

            string MessageBoxTitle = "ABRIR PROCESO";
            string MessageBoxContent = "¿Desea abrir Proceso del dia: \n" +
                Fecha_Inicio.Value.ToString("yyyy/MM/dd") + " ?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                // Mostrar el formulario de carga de manera no modal
                Msbox.frm_guardando frbm = new Msbox.frm_guardando();
                //frbm.StartPosition = FormStartPosition.CenterParent;
                frbm.Show(this); // Mostrar como formulario hijo
                frbm.label1.Text = "GUARDANDO DATOS..."; // Actualizar el texto del formulario de carga

                try
                {
                    // Cargar datos en segundo plano
                    await Task.Run(() =>
                    {
                        //MessageBox.Show("Hola");
                        GuardarCierreProcesoDia();
                    });


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar datos: " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    frbm.Close();
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ToggleSwitch1_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                GuardarDatosSync();
            }
            else
            {
                AbrirDatosSync();
            }
        }

        private void Fecha_Inicio_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada en el DateTimePicker
            DateTime fechaSeleccionada = Fecha_Inicio.Value.Date;
            //MessageBox.Show("Fecha seleccionada: " + fechaSeleccionada);

            // Buscar la fila donde la fecha coincida con la fecha seleccionada
            DataGridViewRow fila = dataGridView1.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => Convert.ToDateTime(r.Cells["FechaProceso"].Value).Date == fechaSeleccionada);

            // Si se encontró una fila
            if (fila != null)
            {
                // Verificar el estado de la fila
                string estado = fila.Cells["Status"].Value.ToString(); // Asumiendo que la columna se llama "Estatus"

                //MessageBox.Show("estado: " + estado);
                // Activar o desactivar el ToggleSwitch según el estado
                if (estado == "CERRADO")
                {
                    guna2ToggleSwitch1.Checked = true; // Activar
                }
                else if (estado == "ABIERTO")
                {
                    guna2ToggleSwitch1.Checked = false; // Desactivar
                }
            }
            else
            {
                // Si no se encontró ninguna fila, desactivar el ToggleSwitch o manejar la lógica adecuada
                guna2ToggleSwitch1.Checked = false; // Por ejemplo, desactivar el toggle si no se encuentra la fecha
            }
        }

    }
}
