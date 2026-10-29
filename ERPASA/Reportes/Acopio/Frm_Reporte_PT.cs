using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_Reporte_PT : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_sst objcnlog = new cn_sst();
        List<ce_packingPT> listaPacking = new List<ce_packingPT>();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg1, dtg2, dtg3;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        public Frm_Reporte_PT()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_Reporte_PT_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA

            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;

            PonerOscuroComboBox();
            CargarDatosComboBox();
            //textBox_Dni.Focus();
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

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarReportePT()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp, sed, empText = string.Empty, sedText = string.Empty
                , cult, cultText = string.Empty;

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

            dtg2 = cn_sst.ListaReportePT(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult, "%");

            dtg1 = cn_sst.ListaReportePTMaquina(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult);

            dtg3 = cn_sst.ListaReportePTPresentacion(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult);


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

        public async void CargarDatosSync()
        {
            checkBox1.Checked = false;
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
                    BuscarReportePT();
                    dataGridView1.ClearSelection();
                    dataGridView2.ClearSelection();
                    dataGridView3.ClearSelection();
                });

                dataGridView2.Columns.Clear();
                dataGridView1.Columns.Clear();
                dataGridView3.Columns.Clear();
                dataGridView1.DataSource = dtg1;
                dataGridView2.DataSource = dtg2;
                MostrarTotalCajas();
                dataGridView3.DataSource = dtg3;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView3.AllowUserToAddRows = false;
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void MostrarTotalCajas()
        {
            if (dtg2 == null)
            {
                label_cajas.Text = "CAJAS: 0";
                label_equiv.Text = "EQUIV: 0.00";
                return;
            }

            var dv = dtg2.DefaultView;

            if (dv.Count == 0)
            {
                label_cajas.Text = "CAJAS: 0";
                label_equiv.Text = "EQUIV: 0.00";
                return;
            }

            decimal totalCajas = dv.Cast<DataRowView>()
                .Where(r => r["cajas"] != DBNull.Value)
                .Sum(r => Convert.ToDecimal(r["cajas"]));

            decimal totalEquiv = dv.Cast<DataRowView>()
                .Where(r => r["equiv"] != DBNull.Value)
                .Sum(r => Convert.ToDecimal(r["equiv"]));

            label_cajas.Text = $"CAJAS: {totalCajas:N0}";
            label_equiv.Text = $"EQUIV: {totalEquiv:N2}"; // 🔥 CON DECIMALES
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ExportarExcel1();
            //objexcel.ExportarExcel(dataGridView2);
        }

        private async void ExportarExcel1()
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

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            if (dtg2 != null)
            {
                DataView dv2 = dtg2.DefaultView;
                DataView dv3 = dtg3.DefaultView;
                DataView dv1 = dtg1.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv2.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                    dv3.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                    dv1.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para la columna dtg2
                    var condiciones_dg2 = dtg2.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");
                    dv2.RowFilter = string.Join(" OR ", condiciones_dg2);

                    // Generar condiciones para la columna dtg3
                    var condiciones_dg3 = dtg3.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");
                    dv3.RowFilter = string.Join(" OR ", condiciones_dg3);

                    // Generar condiciones para la columna dtg1
                    var condiciones_dg1 = dtg1.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");
                    dv1.RowFilter = string.Join(" OR ", condiciones_dg1);


                    MostrarTotalCajas();
                }
            }
        }

        private void toolStripButton_Estados_Click(object sender, EventArgs e)
        {
            dateTimePicker_FecInicio.Focus();
            //textBox1.Focus();

            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > 0)
            {
                listaPacking.Clear();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        ce_packingPT item = new ce_packingPT
                        {
                            id = row.Cells[2].Value?.ToString(),
                            palet = row.Cells[5].Value?.ToString(),
                            pucho = row.Cells[6].Value?.ToString(),
                            cajas = row.Cells[14].Value?.ToString()
                        };
                        //MessageBox.Show("Id "+ row.Cells[2].Value?.ToString());
                        listaPacking.Add(item);
                    }
                }

                Frm_EstadosPT frbm = new Frm_EstadosPT(listaPacking);
                AddOwnedForm(frbm);
                frbm.ShowDialog();
                //CargarDatosSync();

            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN PALLET");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
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

        private string ValorCombo(ComboBox combo)
        {
            string valor = combo.Text.Trim();
            return valor.Equals("SELECCIONE", StringComparison.OrdinalIgnoreCase) || valor == ""
                ? "TODOS"
                : valor;
        }

        // Generar Excel del reporte
        private async void toolStripButton_EnviarCorreo_Click(object sender, EventArgs e)
        {

            if (dataGridView2.RowCount > 0)
            {
                ce_correo.fechaProcesoIni = dateTimePicker_FecInicio.Value.Date;
                ce_correo.fechaProcesoFin = dateTimePicker_FecFin.Value.Date;
                ce_correo.empresaProceso = ValorCombo(comboBox_detalle_empresa);
                ce_correo.sedeProceso = ValorCombo(comboBox_detalle_sede);
                ce_correo.cultivoProceso = ValorCombo(comboBox_Cultivo);

                ce_correo.codCorreo = 1;

                string titulo = "Reporte_Producto_Terminado_";
                _cts = new CancellationTokenSource();

                var frbm = new frm_dowloadExcel();

                frbm.Show(this);


                string rutaExcel = await Task.Run(() =>
                {
                    return objexcel_progress.exportarexcelCorreo(
                        dataGridView2,
                        frbm,
                        _cts.Token,
                        titulo,
                        ce_correo.fechaProcesoIni.Value,
                        ce_correo.fechaProcesoFin.Value
                    );

                });


                frbm.Close();


                ce_correo.rutaArchivoAdjunto = rutaExcel;


                Frm_Correo.EnviarCorreo frm = new Frm_Correo.EnviarCorreo();

                AddOwnedForm(frm);

                frm.ShowDialog();
            }
            else
            {
                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("NO HAY REPORTE A ENVIAR", Color.FromArgb(238, 24, 24), 3);
                ng.Show();
            }
        }

        /// <summary>
        /// Correo de destajo (PACK_EnviarCorreo Id = 6). A diferencia del
        /// anterior, el cuerpo lleva el cuadro de cajas por presentacion y
        /// fecha, y el Excel adjunto trae dos hojas: el detalle y ese mismo
        /// resumen.
        /// </summary>
        private async void toolStripButton_EnviarCorreoDestajo_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
            {
                Msbox.Frm_NotificacionesGuardar ng =
                    new Msbox.Frm_NotificacionesGuardar("NO HAY REPORTE A ENVIAR",
                        Color.FromArgb(238, 24, 24), 3);
                ng.Show();
                return;
            }

            var resumen = ResumenPaletasDestajo.Calcular(dataGridView2);

            if (resumen.Faltante != null)
            {
                MessageBox.Show(
                    "El reporte no trae la columna " + resumen.Faltante + ", que hace " +
                    "falta para armar el cuadro de cajas.\n\n" +
                    "Se necesitan PRESENTACION, FECHA PROCESO y CAJAS.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ce_correo.fechaProcesoIni = dateTimePicker_FecInicio.Value.Date;
            ce_correo.fechaProcesoFin = dateTimePicker_FecFin.Value.Date;
            ce_correo.empresaProceso = ValorCombo(comboBox_detalle_empresa);
            ce_correo.sedeProceso = ValorCombo(comboBox_detalle_sede);
            ce_correo.cultivoProceso = ValorCombo(comboBox_Cultivo);

            ce_correo.codCorreo = 6;
            ce_correo.tablaHtmlResumen = ResumenPaletasDestajo.Html(resumen);

            string titulo = "Reg_PaletasProceso_";
            _cts = new CancellationTokenSource();

            var frbm = new frm_dowloadExcel();
            frbm.Show(this);

            string rutaExcel = await Task.Run(() =>
            {
                return objexcel_progress.exportarexcelCorreoDestajo(
                    dataGridView2, frbm, _cts.Token, titulo,
                    ce_correo.fechaProcesoIni.Value,
                    ce_correo.fechaProcesoFin.Value,
                    resumen);
            });

            frbm.Close();

            ce_correo.rutaArchivoAdjunto = rutaExcel;

            Frm_Correo.EnviarCorreoDestajo frm = new Frm_Correo.EnviarCorreoDestajo();
            AddOwnedForm(frm);
            frm.ShowDialog();
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExportarExcel3();
            //objexcel.ExportarExcel(dataGridView2);
        }

        private async void ExportarExcel3()
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
                        objexcel_progress.exportarexcelTimer(dataGridView3, frbm, token);
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

    }
}
