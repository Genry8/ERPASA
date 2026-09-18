using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_SST;
using ERPASA.Frm_TabMaestra;
using ERPASA.Msbox;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_TablasMaestrasRendicion : Form,
        VarDatosEntroFormUsuarioAP3, VarDatosEntroFormUsuarioAP4,
        VarDatosEntroFormUsuarioAP5,
        VarDatosEntroFormUsuarioEmpresa, VarDatosEntroFormUsuarioEmpresa2,
        VarDatosEntroFormUsuarioTipoGasto, VarDatosEntroFormUsuarioEstado
        , VarDatosEntroFormUsuarioConsumidor
        , VarDatosEntroFormUsuarioConsumidor2, VarDatosEntroFormUsuarioPolitica
        , VarDatosEntroFormUsuarioCategoria, VarDatosEntroFormUsuarioEmpresa3
        , VarDatosEntroFormUsuarioTipoGasto2, VarDatosEntroFormUsuarioEstado2
        , VarDatosEntroFormUsuarioEstado3
        , VarDatosEntroFormUsuarioGerencia, VarDatosEntroFormUsuarioArea
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtgUCon, dtgUEmp;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_TablasMaestrasRendicion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_TablasMaestrasRendicion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosDGV();

            // También evita que se editen con doble clic
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView3.CellBeginEdit += dataGridView3_CellBeginEdit;
            dataGridView6.CellBeginEdit += dataGridView6_CellBeginEdit;
            dataGridView7.CellBeginEdit += dataGridView7_CellBeginEdit;
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            //comboBox_campaña.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_sucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void CargarDatosDGV()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dtgUEmp = cn_contabilidad.ReporteUsuarioConsumidor();
            dataGridView1.DataSource = dtgUEmp;
            dataGridView1.ClearSelection();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = cn_contabilidad.ReportePolitica();
            dataGridView2.ClearSelection();

            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = cn_contabilidad.ReporteCategoria();
            dataGridView3.ClearSelection();

            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = cn_contabilidad.ReporteMovilidad();
            dataGridView4.ClearSelection();

            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = cn_contabilidad.RendTipoGasto();
            dataGridView5.ClearSelection();

            dataGridView6.Columns.Clear();
            dataGridView6.DataSource = null;
            dataGridView6.DataSource = cn_contabilidad.RendCuentaCategoria();
            dataGridView6.ClearSelection();

            dataGridView7.Columns.Clear();
            dataGridView7.DataSource = null;
            dtgUCon = cn_contabilidad.ReporteUsuarioCeco();
            dataGridView7.DataSource = dtgUCon;
            dataGridView7.ClearSelection();

        }



        public void AbrirFormularioHijo<MiForm>() where MiForm : Form, new()
        {
            Form fh;
            fh = frm_Menu.panel_contenedor.Controls.OfType<MiForm>().FirstOrDefault(); //busca en la colección del formulario

            //si el formulario no existe
            if (fh == null)
            {

                fh = new MiForm();
                fh.TopLevel = false;
                //fh.Dock = DockStyle.Fill;            
                this.frm_Menu.panel_contenedor.Controls.Add(fh);
                this.frm_Menu.panel_contenedor.Tag = fh;
                fh.Show();
                fh.BringToFront();

            }
            else
            {
                fh.BringToFront();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //BuscarRegistroParaEditar();

        }


        private void toolStripButton_BuscarUserCons_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dtgUEmp = cn_contabilidad.ReporteUsuarioConsumidor();
            dataGridView1.DataSource = dtgUEmp;
            dataGridView1.ClearSelection();

        }

        private void toolStripButton_ExcelUserCons_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView1);
        }

        private void toolStripButtonGuardarUserCons_Click(object sender, EventArgs e)
        {
            LimpiarFilasInvalidas();
            if (ValidarFilasCompletas(dataGridView1))
            {
                // ✅ Todas las celdas están llenas, procede a guardar
                GuardarDatosSync();
            }
            else
            {
                // ❌ Hay celdas vacías, se cancela el guardado
            }
        }
        private bool ValidarFilasCompletas(DataGridView dt)
        {
            foreach (DataGridViewRow row in dt.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // ❗ Ignorar columna Placa
                        if (dt.Columns[cell.ColumnIndex].Name == "Placa")
                            continue;

                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            MessageBox.Show(
                                "Por favor, completa todas las celdas obligatorias antes de guardar.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            dt.CurrentCell = cell;
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private async void GuardarDatosSync()
        {
            string MessageBoxTitle = "GUARDAR ";
            string MessageBoxContent = "¿Desea guardar registro?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                        GuardarUsuarioRendicion();
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
                }
            }
        }


        public void GuardarUsuarioRendicion()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new MethodInvoker(delegate
                {
                    dataGridView1.AllowUserToAddRows = false;
                }));
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                LimpiarFilasInvalidas();
                objcnlog.GuardarActualizarUsuarioConsumidorCont(
                        Convert.ToInt32(row.Cells[0].Value.ToString()),//id
                        Convert.ToInt32(row.Cells[1].Value.ToString()),//idUser
                        row.Cells[2].Value.ToString().Trim(),//dni
                        row.Cells[3].Value.ToString().Trim(),//apenom
                        row.Cells[4].Value.ToString().Trim(),//empresa
                        "",//Sucursal
                        row.Cells[5].Value.ToString().Trim(),//gerencia
                        row.Cells[6].Value.ToString().Trim(),//area
                        "",//row.Cells[7].Value.ToString().Trim(),//tipo gasto
                        "",//row.Cells[8].Value.ToString().Trim(),//consumidor
                        "",//Regimen
                        "",//Destino
                        "",//row.Cells[9].Value.ToString().Trim(),//placa
                        Convert.ToInt32(row.Cells[7].Value.ToString()),//id Aud
                        row.Cells[8].Value.ToString().Trim(),//Auditor
                        row.Cells[10].Value.ToString().Trim(),//Obs
                        row.Cells[9].Value.ToString().Trim(),//estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0,
                        0
                        );
                //}
            }
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new MethodInvoker(delegate
                {
                    dataGridView1.AllowUserToAddRows = true;
                }));
            }
            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();
            //dataGridView2.DataSource = null;
            //AgregarColumna();

        }



        private bool ValidarFilasCompletasDT3()
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (!row.IsNewRow) // Ignora la fila vacía automática
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            dataGridView3.AllowUserToAddRows = false;
                            MessageBox.Show("Por favor, completa todas las celdas antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridView3.CurrentCell = cell; // Llevar el foco a la celda vacía

                            dataGridView3.AllowUserToAddRows = true;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private async void GuardarDatosDT3Sync()
        {
            string MessageBoxTitle = "GUARDAR ";
            string MessageBoxContent = "¿Desea guardar registro?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                        GuardarPolitica();
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
                }
            }
        }

        public void GuardarPolitica()
        {
            textBox1.Focus();
            if (dataGridView3.Rows.Count > 0)
            {
                dataGridView3.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView3.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarRendicionCategoria(
                            Convert.ToInt32(dataGridView3[0, i].Value.ToString()),
                            dataGridView3[1, i].Value.ToString(),
                            dataGridView3[2, i].Value.ToString(),
                            dataGridView3[3, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView3.AllowUserToAddRows = true;

                }
                dataGridView3.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_ExportarPolitica_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView2);
        }

        private void toolStripButton_BuscarPolitica_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReportePolitica();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void BuscarReportePolitica()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = cn_contabilidad.ReportePolitica();
            dataGridView2.ClearSelection();
        }

        private void toolStripButton_GuardarPolitica_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarRendicionPolitica(
                            Convert.ToInt32(dataGridView2[0, i].Value.ToString()),
                            dataGridView2[1, i].Value.ToString(),
                            dataGridView2[2, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView2.AllowUserToAddRows = true;

                }
                dataGridView2.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void toolStripButton_BuscCategoria_Click(object sender, EventArgs e)
        {
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = cn_contabilidad.ReporteCategoria();
            dataGridView3.ClearSelection();
        }

        private void toolStripButton_ExcelCategoria_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView3);
        }

        private void toolStripButton_GuardarCategoria_Click(object sender, EventArgs e)
        {

            LimpiarFilasInvalidasDT3();
            if (ValidarFilasCompletasDT3())
            {
                // ✅ Todas las celdas están llenas, procede a guardar
                GuardarDatosDT3Sync();
            }
            else
            {
                // ❌ Hay celdas vacías, se cancela el guardado
            }

        }

        private void toolStripButton_BuscarMovilidad_Click(object sender, EventArgs e)
        {
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = cn_contabilidad.ReporteMovilidad();
            dataGridView4.ClearSelection();
        }

        private void toolStripButton_ExcelMovilidad_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView4);
        }

        private void toolStripButton_GuardarMovilidad_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView4.Rows.Count > 0)
            {
                dataGridView4.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView4.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarRendicionPolitica(
                            Convert.ToInt32(dataGridView4[0, i].Value.ToString()),
                            dataGridView4[1, i].Value.ToString(),
                            dataGridView4[2, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView4.AllowUserToAddRows = true;

                }
                dataGridView4.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }


        private async void ExportarExcelDgv(DataGridView dt)
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
                        objexcel_progress.exportarexcelTimer(dt, frbm, token);
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void TablaAgregarDatosFilaD3(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigD3(DataGridViewRow fila1a)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            DataRow nuevaFila = dt.NewRow();
            nuevaFila["IdUser"] = fila1a.Cells[0].Value;
            nuevaFila["Dni"] = fila1a.Cells[1].Value;
            nuevaFila["ApeNom"] = fila1a.Cells[2].Value;
            nuevaFila["Gerencia"] = fila1a.Cells[4].Value;
            nuevaFila["Area"] = fila1a.Cells[5].Value;
            nuevaFila["Obs"] = "NINGUNO";

            dt.Rows.Add(nuevaFila);
        }


        public void TablaAgregarDatosFilaD4(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigD4(DataGridViewRow fila1a)
        {
            DataTable dt = (DataTable)dataGridView7.DataSource;

            DataRow nuevaFila = dt.NewRow();
            nuevaFila["IdUser"] = fila1a.Cells[0].Value;
            nuevaFila["Dni"] = fila1a.Cells[1].Value;
            nuevaFila["ApeNom"] = fila1a.Cells[2].Value;
            //nuevaFila["Gerencia"] = fila1a.Cells[4].Value;
            //nuevaFila["Area"] = fila1a.Cells[5].Value;
            nuevaFila["Obs"] = "NINGUNO";

            dt.Rows.Add(nuevaFila);
        }


        public void TablaAgregarDatosFilaD5(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigD5(DataGridViewRow fila1a)
        {

            int idAudSel = (int)fila1a.Cells[0].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value = idAudSel;

            string AudSel = (string)fila1a.Cells[2].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value = AudSel;

        }


        public void TablaAgregarDatosFilaEmpresa(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigEmpresa(DataGridViewRow fila1a)
        {
            string empresaSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value = empresaSeleccionada;
        }

        public void TablaAgregarDatosFilaGerencia(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigArea(DataGridViewRow fila1a)
        {
            string areaSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value = areaSeleccionada;
        }

        public void TablaAgregarDatosFilaArea(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigGerencia(DataGridViewRow fila1a)
        {
            string gerenciaSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value = gerenciaSeleccionada;
        }

        public void TablaAgregarDatosFilaTipoGasto(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigTipoGasto(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[5].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaConsumidor(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigConsumidor(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[0].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaConsumidor2(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigConsumidor2(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[0].Value;
            dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[6].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaEstado(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigEstado(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[0].Value;
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value = gastoSeleccionada;
        }

        /// <summary>
        /// ////POLITICA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void TablaAgregarDatosFilaPolitica(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigPolitica(DataGridViewRow fila1a)
        {
            DataTable dt = (DataTable)dataGridView3.DataSource;

            DataRow nuevaFila = dt.NewRow();
            nuevaFila["Politica"] = fila1a.Cells[1].Value;

            dt.Rows.Add(nuevaFila);
            //string gastoSeleccionada = (string)fila1a.Cells[1].Value;
            //dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaCategoria(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigCategoria(DataGridViewRow fila1a)
        {
            DataTable dt = (DataTable)dataGridView6.DataSource;

            DataRow nuevaFila = dt.NewRow();
            nuevaFila["IdCat"] = fila1a.Cells[0].Value;
            nuevaFila["Categoria"] = fila1a.Cells[2].Value;
            nuevaFila["Obs"] = "NINGUNO";

            dt.Rows.Add(nuevaFila);
            //string gastoSeleccionada = (string)fila1a.Cells[1].Value;
            //dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaEmpresa2(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigEmpresa2(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView6.Rows[dataGridView6.CurrentRow.Index].Cells[3].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaEmpresa3(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigEmpresa3(DataGridViewRow fila1a)
        {
            string empSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[4].Value = empSeleccionada;
        }


        public void TablaAgregarDatosFilaTipoGasto2(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigTipoGasto2(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[1].Value;
            dataGridView6.Rows[dataGridView6.CurrentRow.Index].Cells[4].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaEstado2(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigEstado2(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[0].Value;
            dataGridView6.Rows[dataGridView6.CurrentRow.Index].Cells[6].Value = gastoSeleccionada;
        }

        public void TablaAgregarDatosFilaEstado3(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigEstado3(DataGridViewRow fila1a)
        {
            string gastoSeleccionada = (string)fila1a.Cells[0].Value;
            dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[8].Value = gastoSeleccionada;
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    // Abrir el formulario de búsqueda
                    dataGridView1.AllowUserToAddRows = false;
                    frm_BuscarUsuarioAPP_3 frbm = new frm_BuscarUsuarioAPP_3();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidas();

                    dataGridView1.AllowUserToAddRows = true;
                }
                else
                {
                    MessageBox.Show("La celda no está vacía");
                }
            }

            if (e.ColumnIndex == 4) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarEmpresa frbm = new frm_BuscarEmpresa();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            if (e.ColumnIndex == 5) // GERENCIA
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarGerencia frbm = new frm_BuscarGerencia();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            if (e.ColumnIndex == 6) // AREA
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarArea frbm = new frm_BuscarArea();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            if (e.ColumnIndex == 7) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarUsuarioAPP_5 frbm = new frm_BuscarUsuarioAPP_5();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            /*
            if (e.ColumnIndex == 7) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarTipoGasto frbm = new frm_BuscarTipoGasto();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }
            

            if (e.ColumnIndex == 7) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarConsumidor frbm = new frm_BuscarConsumidor();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }
            */

            if (e.ColumnIndex == 9) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarEstado frbm = new frm_BuscarEstado();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

        }

        private void LimpiarFilasInvalidas()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var idUserCell = row.Cells["IdUser"].Value;
                    if (idUserCell == null || string.IsNullOrWhiteSpace(idUserCell.ToString()))
                    {
                        dataGridView1.Rows.Remove(row);
                        break; // Salir porque se modificó la colección
                    }
                }
            }
        }


        private void LimpiarFilasInvalidasDg7()
        {
            foreach (DataGridViewRow row in dataGridView7.Rows)
            {
                if (!row.IsNewRow)
                {
                    var idUserCell = row.Cells["IdUser"].Value;
                    if (idUserCell == null || string.IsNullOrWhiteSpace(idUserCell.ToString()))
                    {
                        dataGridView7.Rows.Remove(row);
                        break; // Salir porque se modificó la colección
                    }
                }
            }
        }

        private void LimpiarFilasInvalidasDT3()
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (!row.IsNewRow)
                {
                    var idUserCell = row.Cells[1].Value;
                    if (idUserCell == null || string.IsNullOrWhiteSpace(idUserCell.ToString()))
                    {
                        dataGridView3.Rows.Remove(row);
                        break; // Salir porque se modificó la colección
                    }
                }
            }
        }

        private void LimpiarFilasInvalidasDT6()
        {
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                if (!row.IsNewRow)
                {
                    var idUserCell = row.Cells[1].Value;
                    if (idUserCell == null || string.IsNullOrWhiteSpace(idUserCell.ToString()))
                    {
                        dataGridView6.Rows.Remove(row);
                        break; // Salir porque se modificó la colección
                    }
                }
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarFilasInvalidas();
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 10)
            {
                e.Cancel = true; // bloquea otras columnas
            }
        }

        private void toolStripButton_BuscarTipoGasto_Click(object sender, EventArgs e)
        {
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = cn_contabilidad.RendTipoGasto();
            dataGridView5.ClearSelection();
        }

        private void toolStripButton_ExcelTipoGasto_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView5);
        }

        private void toolStripButton_GuardarTipoGasto_Click(object sender, EventArgs e)
        {

            textBox1.Focus();
            if (dataGridView5.Rows.Count > 0)
            {
                dataGridView5.AllowUserToAddRows = false;

                string MessageBoxTitle = "REGISTRO";
                string MessageBoxContent = "¿Desea Guardar Registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView5.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        objcnlog.GuardarRendicionTipoGasto(
                            Convert.ToInt32(dataGridView5[0, i].Value.ToString()),
                            dataGridView5[1, i].Value.ToString(),
                            dataGridView5[2, i].Value.ToString(),
                            "S",//Estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod
                            );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    dataGridView5.AllowUserToAddRows = true;

                }
                dataGridView5.AllowUserToAddRows = true;
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView3.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    // Abrir el formulario de búsqueda
                    dataGridView3.AllowUserToAddRows = false;
                    frm_BuscarPolitica frbm = new frm_BuscarPolitica();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidasDT3();

                    dataGridView3.AllowUserToAddRows = true;
                }
                else
                {
                    MessageBox.Show("La celda no está vacía");
                }
            }



        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarFilasInvalidasDT3();

            if (e.ColumnIndex == 2) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView3.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija politica");
                }
                else
                {

                }
            }
        }

        private void toolStripButton_BuscarCuentaCategoria_Click(object sender, EventArgs e)
        {
            dataGridView6.Columns.Clear();
            dataGridView6.DataSource = null;
            dataGridView6.DataSource = cn_contabilidad.RendCuentaCategoria();
            dataGridView6.ClearSelection();
        }

        private void toolStripButton_ExcelCuentaCategoria_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView6);
        }

        private void toolStripButton_GuardarCuentaCategoria_Click(object sender, EventArgs e)
        {
            LimpiarFilasInvalidasDT6();
            if (ValidarFilasCompletas(dataGridView6))
            {
                // ✅ Todas las celdas están llenas, procede a guardar
                GuardarDatosCuentaCategoriaSync();
            }
            else
            {
                // ❌ Hay celdas vacías, se cancela el guardado
            }
        }


        private async void GuardarDatosCuentaCategoriaSync()
        {
            string MessageBoxTitle = "GUARDAR ";
            string MessageBoxContent = "¿Desea guardar registro?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                        GuardarCuentaCategoria();
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
                }
            }
        }


        public void GuardarCuentaCategoria()
        {
            if (dataGridView6.InvokeRequired)
            {
                dataGridView6.Invoke(new MethodInvoker(delegate
                {
                    dataGridView6.AllowUserToAddRows = false;
                }));
            }
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                LimpiarFilasInvalidasDT6();
                objcnlog.GuardarActualizarCuentaCategoriaCont(
                        Convert.ToInt32(row.Cells[0].Value.ToString()),//id
                        Convert.ToInt32(row.Cells[1].Value.ToString()),//idCat
                        row.Cells[2].Value.ToString().Trim(),//Categoria
                        row.Cells[3].Value.ToString().Trim(),//empresa
                        row.Cells[4].Value.ToString().Trim(),//tipo gasto
                        row.Cells[5].Value.ToString().Trim(),//cuenta
                        row.Cells[7].Value.ToString().Trim(),//Obs
                        row.Cells[6].Value.ToString().Trim(),//estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0,
                        0
                        );
                //}
            }
            if (dataGridView6.InvokeRequired)
            {
                dataGridView6.Invoke(new MethodInvoker(delegate
                {
                    dataGridView6.AllowUserToAddRows = true;
                }));
            }
            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();
            //dataGridView2.DataSource = null;
            //AgregarColumna();

        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView6.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    // Abrir el formulario de búsqueda
                    dataGridView6.AllowUserToAddRows = false;
                    frm_BuscarCategoria frbm = new frm_BuscarCategoria();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidasDT6();

                    dataGridView6.AllowUserToAddRows = true;
                }
                else
                {
                    MessageBox.Show("La celda no está vacía");
                }
            }

            if (e.ColumnIndex == 3) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView6.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija categoria");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarEmpresa2 frbm = new frm_BuscarEmpresa2();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            if (e.ColumnIndex == 4) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView6.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija categoria");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarTipoGasto2 frbm = new frm_BuscarTipoGasto2();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            if (e.ColumnIndex == 6) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView6.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija categoria");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarEstado2 frbm = new frm_BuscarEstado2();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }


        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView7.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    // Abrir el formulario de búsqueda
                    dataGridView7.AllowUserToAddRows = false;
                    frm_BuscarUsuarioAPP_4 frbm = new frm_BuscarUsuarioAPP_4();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidasDg7();

                    dataGridView7.AllowUserToAddRows = true;
                }
                else
                {
                    MessageBox.Show("La celda no está vacía");
                }
            }

            if (e.ColumnIndex == 4) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView7.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarEmpresa3 frbm = new frm_BuscarEmpresa3();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidasDg7();

                }
            }

            if (e.ColumnIndex == 5) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView7.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarTipoGasto frbm = new frm_BuscarTipoGasto();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();
                }
            }

            if (e.ColumnIndex == 6) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView7.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarConsumidor2 frbm = new frm_BuscarConsumidor2();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidasDg7();

                }
            }

            if (e.ColumnIndex == 8) // Verifica que la columna clickeada sea la segunda
            {
                // Verificar si la celda está vacía o solo contiene espacios en blanco
                var cellValue = dataGridView7.Rows[e.RowIndex].Cells[2].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("Primero elija usuario");
                }
                else
                {
                    // Abrir el formulario de búsqueda
                    frm_BuscarEstado3 frbm = new frm_BuscarEstado3();
                    AddOwnedForm(frbm);
                    frbm.ShowDialog();

                    LimpiarFilasInvalidasDg7();

                }
            }

        }

        private void dataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView6_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView7_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 7 && e.ColumnIndex != 9)
            {
                e.Cancel = true; // bloquea otras columnas
            }
        }

        private void dataGridView7_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void dataGridView7_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarFilasInvalidasDg7();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataGridView7.Columns.Clear();
            dataGridView7.DataSource = null;
            dtgUCon = cn_contabilidad.ReporteUsuarioCeco();
            dataGridView7.DataSource = dtgUCon;
            dataGridView7.ClearSelection();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportarExcelDgv(dataGridView7);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LimpiarFilasInvalidasDg7();
            if (ValidarFilasCompletas(dataGridView7))
            {
                // ✅ Todas las celdas están llenas, procede a guardar
                GuardarDatosCecoSync();
            }
            else
            {
                // ❌ Hay celdas vacías, se cancela el guardado
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = guna2TextBox1.Text.Trim().Replace("'", "''");

            if (dtgUEmp != null)
            {
                DataView dv = dtgUEmp.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtgUEmp.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            if (dtgUCon != null)
            {
                DataView dv = dtgUCon.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtgUCon.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }

        private async void GuardarDatosCecoSync()
        {
            string MessageBoxTitle = "GUARDAR ";
            string MessageBoxContent = "¿Desea guardar registro?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                        GuardarUsuarioCeco();
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
                }
            }
        }


        public void GuardarUsuarioCeco()
        {
            if (dataGridView7.InvokeRequired)
            {
                dataGridView7.Invoke(new MethodInvoker(delegate
                {
                    dataGridView7.AllowUserToAddRows = false;
                }));
            }
            foreach (DataGridViewRow row in dataGridView7.Rows)
            {
                LimpiarFilasInvalidasDg7();
                objcnlog.GuardarActualizarUsuarioCecoCont(
                        Convert.ToInt32(row.Cells[0].Value.ToString()),//id
                        Convert.ToInt32(row.Cells[1].Value.ToString()),//idUser
                        row.Cells[2].Value.ToString().Trim(),//dni
                        row.Cells[3].Value.ToString().Trim(),//apenom
                        row.Cells[4].Value.ToString().Trim(),//empresa
                        "",//Sucursal
                        row.Cells[5].Value.ToString().Trim(),//tipo gasto
                        row.Cells[6].Value.ToString().Trim(),//consumidor
                        row.Cells[7].Value.ToString().Trim(),//placa
                        row.Cells[9].Value.ToString().Trim(),//Obs
                        row.Cells[8].Value.ToString().Trim(),//estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0,
                        0
                        );
                //}
            }
            if (dataGridView7.InvokeRequired)
            {
                dataGridView7.Invoke(new MethodInvoker(delegate
                {
                    dataGridView7.AllowUserToAddRows = true;
                }));
            }
            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();
            //dataGridView2.DataSource = null;
            //AgregarColumna();

        }


    }


    internal interface VarDatosEntroFormUsuarioAP3
    {
        void TablaAgregarDatosFilaD3(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigD3(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaEmpresa(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEmpresa(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioAP4
    {
        void TablaAgregarDatosFilaD4(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigD4(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioAP5
    {
        void TablaAgregarDatosFilaD5(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigD5(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioEmpresa
    {
        void TablaAgregarDatosFilaEmpresa(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEmpresa(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioGerencia
    {
        void TablaAgregarDatosFilaGerencia(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigGerencia(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioArea
    {
        void TablaAgregarDatosFilaArea(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigArea(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioTipoGasto
    {
        void TablaAgregarDatosFilaTipoGasto(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigTipoGasto(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioEstado
    {
        void TablaAgregarDatosFilaEstado(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEstado(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioConsumidor
    {
        void TablaAgregarDatosFilaConsumidor(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigConsumidor(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioConsumidor2
    {
        void TablaAgregarDatosFilaConsumidor2(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigConsumidor2(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioPolitica
    {
        void TablaAgregarDatosFilaPolitica(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigPolitica(DataGridViewRow fila1a);
    }
    internal interface VarDatosEntroFormUsuarioCategoria
    {
        void TablaAgregarDatosFilaCategoria(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigCategoria(DataGridViewRow fila1a);
    }
    internal interface VarDatosEntroFormUsuarioEmpresa2
    {
        void TablaAgregarDatosFilaEmpresa2(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEmpresa2(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioEmpresa3
    {
        void TablaAgregarDatosFilaEmpresa3(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEmpresa3(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioTipoGasto2
    {
        void TablaAgregarDatosFilaTipoGasto2(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigTipoGasto2(DataGridViewRow fila1a);
    }
    internal interface VarDatosEntroFormUsuarioEstado2
    {
        void TablaAgregarDatosFilaEstado2(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEstado2(DataGridViewRow fila1a);
    }

    internal interface VarDatosEntroFormUsuarioEstado3
    {
        void TablaAgregarDatosFilaEstado3(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigEstado3(DataGridViewRow fila1a);
    }


}
