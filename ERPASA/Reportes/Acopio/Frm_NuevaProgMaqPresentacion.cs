using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_NuevaProgMaqPresentacion : Form
    {
        string pallet, cabezal, variedad, kilos;

        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_packing objcnpack = new cn_packing();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;
        // Lista para almacenar los estados de los checkboxes (si están marcados o no)
        private List<bool> checkBoxStates = new List<bool>();


        public Frm_NuevaProgMaqPresentacion()
        {
            InitializeComponent();
        }

        private void Frm_NuevaProgMaqPresentacion_Load(object sender, EventArgs e)
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
            comboBox_Filer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_presentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Maquina.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_Filer.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_Filer.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Filer.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_detalle_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinaria();
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";
        }

        public void BuscarRecepcionParaProgramar()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{

            string empText = string.Empty, sedText = string.Empty,
                cultText = string.Empty,
                maqText = string.Empty;
            string emp, sed, cult, maq;

            ////////////////////////////////////
            if (comboBox_Filer.InvokeRequired)
            {
                comboBox_Filer.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_Filer.Text;
                }));
            }
            else
            {
                empText = comboBox_Filer.Text;
            }
            ////////////////////////////////////
            if (comboBox_presentacion.InvokeRequired)
            {
                comboBox_presentacion.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_presentacion.Text;
                }));
            }
            else
            {
                sedText = comboBox_presentacion.Text;
            }
            ////////////////////////////////////
            if (comboBox_detalle_Cultivo.InvokeRequired)
            {
                comboBox_detalle_Cultivo.Invoke(new MethodInvoker(() =>
                {
                    cultText = comboBox_detalle_Cultivo.Text;
                }));
            }
            else
            {
                cultText = comboBox_detalle_Cultivo.Text;
            }
            ////////////////////////////////////
            if (comboBox_Maquina.InvokeRequired)
            {
                comboBox_Maquina.Invoke(new MethodInvoker(() =>
                {
                    maqText = comboBox_Maquina.Text;
                }));
            }
            else
            {
                maqText = comboBox_Maquina.Text;
            }

            /////
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
            if (maqText == "SELECCIONE")
            {
                maq = "%";
            }
            else
            {
                maq = maqText;
            }

            //dataGridView3.ReadOnly = true;
            dtg = cn_sst.ListaProgMaqPresentacion(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecInicio.Value.Date, "%"
                , "%", cult, "%", 2);


            //DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            //estado.HeaderText = "estado";
            //dataGridView2.Columns.Insert(0, estado);



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
                    BuscarRecepcionParaProgramar();
                    dataGridView2.ClearSelection();
                });

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg;
                dataGridView2.AllowUserToAddRows = false;
                // Asegúrate de que la primera columna sea editable
                // Establecer ReadOnly en false para permitir la edición de todas las columnas
                // Asegúrate de que las columnas sean editables (ReadOnly = false)
                foreach (DataColumn column in dtg.Columns)
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
            ExportarExcel();
        }

        private async void ExportarExcel()
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



        private void comboBox_Maquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Filer.DataSource = cn_packing.ListaFiltroMaquinariaFiler(comboBox_Maquina.Text);
            comboBox_Filer.DisplayMember = "Filer"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Filer.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox_detalle_Cultivo.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE CULTIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Maquina.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MAQUINA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Filer.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE FILER", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_presentacion.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE PRESENTACION", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                GuardarDatosSync();
                //AsyncRegistroDTGAsync();
            }
        }

        public async Task AsyncRegistroDTGAsync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            //fr
            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //MessageBox.Show("Hola");
                    AgregarRegistroDTGAsync();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar agregar: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                //Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("AGREGADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                //ng.ShowDialog();
            }
        }

        public void AgregarRegistroDTGAsync()
        {
            // Ejecutar toda la lógica en el hilo principal (UI)
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(AgregarRegistroInterno));
            }
            else
            {
                AgregarRegistroInterno();
            }
        }

        private void AgregarRegistroInterno()
        {
            // Obtener los textos de los ComboBoxes
            string cultivo = comboBox_detalle_Cultivo.Text;
            string maquina = comboBox_Maquina.Text;
            string filer = comboBox_Filer.Text;
            string presentacion = comboBox_presentacion.Text;

            // Verificar si el DataSource está inicializado
            if (dataGridView2.DataSource == null || !(dataGridView2.DataSource is DataTable))
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Cultivo");
                tabla.Columns.Add("Maquina");
                tabla.Columns.Add("Filer");
                tabla.Columns.Add("Presentacion");

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = tabla;
            }

            // Obtener el DataTable desde el DataGridView
            DataTable dt;

            if (dataGridView2.DataSource is BindingSource bindingSource &&
                bindingSource.DataSource is DataTable bindingTable)
            {
                dt = bindingTable;
            }
            else if (dataGridView2.DataSource is DataTable dataTable)
            {
                dt = dataTable;
            }
            else
            {
                MessageBox.Show("No se pudo acceder al DataTable del DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si la fila ya existe
            bool filaExistente = dt.AsEnumerable().Any(row =>
                row.Field<string>("Cultivo") == cultivo &&
                row.Field<string>("Maquina") == maquina &&
                row.Field<string>("Filer") == filer &&
                row.Field<string>("Presentacion") == presentacion);

            if (filaExistente)
            {
                MessageBox.Show("La fila ya existe en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // No agregar la fila si ya existe
            }

            // Crear y agregar la nueva fila
            DataRow nuevaFila = dt.NewRow();
            nuevaFila["Cultivo"] = cultivo;
            nuevaFila["Maquina"] = maquina;
            nuevaFila["Filer"] = filer;
            nuevaFila["Presentacion"] = presentacion;

            dt.Rows.Add(nuevaFila);

            // Actualizar bindings si corresponde
            if (dataGridView2.DataSource is BindingSource bs)
            {
                bs.ResetBindings(false);
            }
        }


        private async void GuardarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            //frbm.label1.Text = "GUARDANDO DATOS..."; // Actualizar el texto del formulario de carga

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //MessageBox.Show("Hola");
                    GuardarProgPresentacion();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              //Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                              //ng.ShowDialog();

                CargarDatosSync();
            }
        }



        public void GuardarProgPresentacion()
        {

            string empText = string.Empty, sedText = string.Empty,
                cultText = string.Empty, filerText = string.Empty,
                maqText = string.Empty, presentText = string.Empty;
            string emp, sed, cult, maq, filer, present;

            ////////////////////////////////////
            if (comboBox_Filer.InvokeRequired)
            {
                comboBox_Filer.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_Filer.Text;
                }));
            }
            else
            {
                empText = comboBox_Filer.Text;
            }
            ////////////////////////////////////
            if (comboBox_presentacion.InvokeRequired)
            {
                comboBox_presentacion.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_presentacion.Text;
                }));
            }
            else
            {
                sedText = comboBox_presentacion.Text;
            }
            ////////////////////////////////////
            if (comboBox_detalle_Cultivo.InvokeRequired)
            {
                comboBox_detalle_Cultivo.Invoke(new MethodInvoker(() =>
                {
                    cultText = comboBox_detalle_Cultivo.Text;
                }));
            }
            else
            {
                cultText = comboBox_detalle_Cultivo.Text;
            }
            ////////////////////////////////////
            if (comboBox_Maquina.InvokeRequired)
            {
                comboBox_Maquina.Invoke(new MethodInvoker(() =>
                {
                    maqText = comboBox_Maquina.Text;
                }));
            }
            else
            {
                maqText = comboBox_Maquina.Text;
            }
            ////////////////////////////////////
            if (comboBox_Filer.InvokeRequired)
            {
                comboBox_Filer.Invoke(new MethodInvoker(() =>
                {
                    filerText = comboBox_Filer.Text;
                }));
            }
            else
            {
                filerText = comboBox_Filer.Text;
            }
            ////////////////////////////////////
            if (comboBox_presentacion.InvokeRequired)
            {
                comboBox_presentacion.Invoke(new MethodInvoker(() =>
                {
                    presentText = comboBox_presentacion.Text;
                }));
            }
            else
            {
                presentText = comboBox_presentacion.Text;
            }

            /////
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
            if (maqText == "SELECCIONE")
            {
                maq = "%";
            }
            else
            {
                maq = maqText;
            }
            if (filerText == "SELECCIONE")
            {
                filer = "%";
            }
            else
            {
                filer = filerText;
            }
            if (presentText == "SELECCIONE")
            {
                present = "%";
            }
            else
            {
                present = presentText;
            }


            objcnpack.GuardarActualizarProgPresentacion(
                    "",//empresa
                    "",//sede
                    dateTimePicker_FecInicio.Value.ToString(),//fecProgramado
                    cultText.Trim(),//cultivo
                    maqText.Trim(),//maq
                    "",//turno
                    filerText.Trim(),//linea
                    presentText.Trim(),//presentacion
                    "",//Obs
                    "S", //estado
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod,
                    ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    0,
                    0
                    );

        }


        private void comboBox_detalle_Cultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosSync();

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinariaCultivo(comboBox_detalle_Cultivo.Text);
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_presentacion.DataSource = cn_logistica.ListaCBPresentacion(comboBox_detalle_Cultivo.Text);
            comboBox_presentacion.DisplayMember = "Presentacion"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_presentacion.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


    }
}
