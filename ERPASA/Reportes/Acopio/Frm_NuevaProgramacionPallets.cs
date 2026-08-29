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
    public partial class Frm_NuevaProgramacionPallets : Form
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


        public Frm_NuevaProgramacionPallets()
        {
            InitializeComponent();
        }

        private void Frm_NuevaProgramacionPallets_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_variedad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Maquina.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Turno.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_detalle_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_variedad.DataSource = cn_packing.ListaVariedad();
            comboBox_variedad.DisplayMember = "desvar"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_variedad.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinaria();
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Turno.DataSource = cn_packing.ListaPackingTurno();
            comboBox_Turno.DisplayMember = "Turno"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Turno.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
                cultText = string.Empty, varText = string.Empty,
                maqText = string.Empty, turnoText = string.Empty;
            string emp, sed, cult, var, maq, turno;

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
            if (comboBox_variedad.InvokeRequired)
            {
                comboBox_variedad.Invoke(new MethodInvoker(() =>
                {
                    varText = comboBox_variedad.Text;
                }));
            }
            else
            {
                varText = comboBox_variedad.Text;
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
            if (comboBox_Turno.InvokeRequired)
            {
                comboBox_Turno.Invoke(new MethodInvoker(() =>
                {
                    turnoText = comboBox_Turno.Text;
                }));
            }
            else
            {
                turnoText = comboBox_Turno.Text;
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
            if (varText == "SELECCIONE")
            {
                var = "%";
            }
            else
            {
                var = varText;
            }
            if (maqText == "SELECCIONE")
            {
                maq = "%";
            }
            else
            {
                maq = maqText;
            }
            if (turnoText == "SELECCIONE")
            {
                turno = "%";
            }
            else
            {
                turno = turnoText;
            }


            //dataGridView3.ReadOnly = true;
            dtg = cn_sst.RecepcionProgVolcado(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecInicio.Value.Date, emp
                , sed, cult, var, maq, turno);


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
                    checkBox1.Invoke(new Action(() =>
                    {
                        checkBox1.Checked = false;
                    }));
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
                //foreach (DataGridViewColumn column in dataGridView2.Columns)
                //{
                //    column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                //}
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pallet = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cabezal = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            variedad = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            kilos = dataGridView2.CurrentRow.Cells[5].Value.ToString();

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarProgVolcado();
        }

        public void AlertaGuardarProgVolcado()
        {
            if (dataGridView2.Rows.Count < 1)
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("NO HAY LISTA DE PALETS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Turno.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE TURNO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            //else if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    Msbox.Frm_NotificacionesPeligro ng =
            //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
            //else if (comboBox_detalle_sede.Text == "SELECCIONE")
            //{
            //    Msbox.Frm_NotificacionesPeligro ng =
            //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
            else if (comboBox_detalle_Cultivo.Text == "CULTIVO")
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
            else
            {
                GuardarDatosSync();
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
                    GuardarProgVolcado();
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



        public void GuardarProgVolcado()
        {
            if (guna2TextBoxSearch.InvokeRequired)
            {
                guna2TextBoxSearch.Invoke(new MethodInvoker(delegate
                {
                    guna2TextBoxSearch.Focus();
                }));
            }
            //dateTimePicker_FecInicio.Focus();
            //textBox1.Focus();

            string empText = string.Empty, sedText = string.Empty,
                cultText = string.Empty, varText = string.Empty,
                maqText = string.Empty, turnoText = string.Empty;

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
            if (comboBox_variedad.InvokeRequired)
            {
                comboBox_variedad.Invoke(new MethodInvoker(() =>
                {
                    varText = comboBox_variedad.Text;
                }));
            }
            else
            {
                varText = comboBox_variedad.Text;
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
            if (comboBox_Turno.InvokeRequired)
            {
                comboBox_Turno.Invoke(new MethodInvoker(() =>
                {
                    turnoText = comboBox_Turno.Text;
                }));
            }
            else
            {
                turnoText = comboBox_Turno.Text;
            }


            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > -1)
            {
                string MessageBoxTitle = "GUARDAR ";
                string MessageBoxContent = "¿Desea guardar programacion?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        //if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        //{
                        //var valPalet = cn_packing.BuscarPaletProgVolcado(
                        //        row.Cells[3].Value.ToString()//idRec
                        //);

                        //if (valPalet == true)
                        //{
                        //    MessageBox.Show("PALET " + row.Cells[4].Value.ToString() +
                        //        "YA FUE PROGRAMADO");
                        //}
                        //else
                        //{

                        objcnpack.GuardarActualizarProgVolcado(
                                row.Cells[0].Value.ToString(),//programado
                                row.Cells[2].Value.ToString(),//idRec
                                row.Cells[3].Value.ToString(),//Num Palet
                                dateTimePicker_FecInicio.Value.ToString(),//fecProgramado
                                turnoText.Trim(),//turno
                                maqText.Trim(),
                                "",//linea
                                "",//Obs
                                "S", //estado
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                0
                                );

                        //}
                    }
                    //dataGridView2.DataSource = null;
                    //AgregarColumna();
                    // Cerrar el formulario de carga
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN PALLET");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (checkBox1.Checked == true)
                {
                    row.Cells[0].Value = true;
                }
                else
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void comboBox_Maquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosSync();
            //BuscarRecepcionParaProgramar();
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

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

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {

        }

        private void comboBox_Turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosSync();
        }

        private void comboBox_detalle_Cultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_variedad.DataSource = cn_packing.ListaVariedadCultivo(comboBox_detalle_Cultivo.Text);
            comboBox_variedad.DisplayMember = "desvar"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_variedad.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinariaCultivo(comboBox_detalle_Cultivo.Text);
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            dateTimePicker_FecInicio.Focus();
            //textBox1.Focus();

            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > 0)
            {
                ImprimirReporteDetalleAtencionASA();
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN PALLET");
            }
        }


        public void ImprimirReporteDetalleAtencionASA()
        {
            Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetAcopio objDsRepAcopio = new DataSetAcopio();
            string empresa;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (row.Cells[7].Value.ToString() == "AGRICOLA SANTA AZUL S.R.L")
                    {
                        empresa = "ASA";
                    }
                    else if (row.Cells[7].Value.ToString() == "AGRICOLA INTERANDINA S.A.C")
                    {
                        empresa = "IA";
                    }
                    else
                    {
                        empresa = "TERCERO";
                    }

                    objDsRepAcopio.Tables[1].Rows.Add
                            (new object[]{
                        row.Cells[2].Value.ToString().ToUpper(), //PALLET
                        row.Cells[3].Value.ToString().ToUpper(), //CABEZAL
                        row.Cells[4].Value.ToString().ToUpper(), //VARIEDAD
                        row.Cells[5].Value.ToString(), //KILOS
                        row.Cells[6].Value.ToString(), //FECHA
                        empresa, //FECHA
                        row.Cells[9].Value.ToString()

                            });

                    objcnsst.ActualizarRecepcionImprimir(row.Cells[2].Value.ToString()
                , row.Cells[6].Value.ToString());

                }

            }

            Acopio.CrystalReportPalletPrint objCryRep = new Acopio.CrystalReportPalletPrint();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReportPalletPrint.rpt");
            objCryRep.SetDataSource(objDsRepAcopio);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



    }
}
