using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms;
using OfficeOpenXml;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading; // <-- el namespace real
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_Sistema
{
    public partial class Frm_RegAsignacion : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datoscliente objdatclienteneg = new cn_datoscliente();
        cn_logistica objdatlogisticaneg = new cn_logistica();
        cn_reportes objdatreporteneg = new cn_reportes();
        cu_excel objexcel = new cu_excel();
        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;
        public Frm_RegAsignacion()
        {
            InitializeComponent();
            dataGridView2.ClearSelection();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_RegAsignacion_Load(object sender, EventArgs e)
        {
            //comboBox_TiposPerActivo.SelectedIndex = 0;
            //comboBox_TiposPerActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            //textbox_ActivoDesc.CharacterCasing = CharacterCasing.Upper;
            //textbox_ActivoDesc.Focus();

            gn2FechaInicio.Value = DateTime.Now.Date.AddDays(-5);
            gn2FechaFin.Value = DateTime.Now.Date;

            CargarPanelgeneral();
            BloquearTextboxCombobox();

            CargarDatosInicio();
            OrigenColorfila();

            //this.Padding = new Padding(borderSize);
            //this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {

            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
            try
            {
                ImprimirReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ImprimirReporte()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Asignacion.Ds_RepAsignacion objDsRepVenta = new Reportes.Frm_Asignacion.Ds_RepAsignacion();
            string Tipo;
            string Descripcion;

            Tipo = "TODOS";
            Descripcion = "TODOS";

            objDsRepVenta.Tables[0].Rows.Add
            (new object[]{
                Tipo,
                Descripcion
            });

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    dataGridView2[1,i].Value.ToString(),
                    dataGridView2[2,i].Value.ToString(),
                    dataGridView2[3,i].Value.ToString(),
                    dataGridView2[4,i].Value.ToString(),
                    dataGridView2[5,i].Value.ToString(),
                    dataGridView2[6,i].Value.ToString(),
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString()
                    });
            }

            Reportes.Frm_Asignacion.CryRep_Asignacion objCryRep = new Reportes.Frm_Asignacion.CryRep_Asignacion();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRep_VentasUsuario.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }


        public void BloquearTextboxCombobox()
        {
            dataGridView2.ReadOnly = true;
        }


        public void DesbloquearTextboxCombobox()
        {
            //DATAGRIDVIEW
            dataGridView2.ReadOnly = true;
        }

        public void CargarPanelgeneral()
        {
            dataGridView2.Columns.Clear();
            //NO PERMITIR EDITAR COLUMAS
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            //BLOQUEAR BOTONES DE ARRIBA
            //toolStripButton_buscar.Enabled = false;
            toolStripButton_eliminar.Enabled = false;
            //toolStripButton_imprimir.Enabled = false;
            toolStripButton_limpiar.Enabled = false;
            //LABEL           
        }


        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;

            cn_logistica.BuscUltimoCodActivoTIMas();
            ce_logistica.codigo_ti = ce_logistica.codigo.ToString();
            ce_logistica.descripcion_ti = "";
            ce_logistica.comentario_ti = "";
            ce_logistica.estado_ti = "AC";

            Frm_AgregarAsignacion frbm = new Frm_AgregarAsignacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();

            /*
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
            */
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;

        }



        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            toolStripButton_eliminar.Enabled = false;
            CargarPanelgeneral();
            DesbloquearTextboxCombobox();
            ////
            dataGridView2.Columns.Clear();
            dataGridView2.AllowUserToAddRows = true;
            //dataGridView2.Columns.Clear();
            //EliminarDatagrid12();
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_imprimir.Enabled = false;
        }


        //
        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[22].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private void textBox_dniusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            CargarDatos();

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.ToString() == "ANULADO")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
            }

        }
        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
            cn_logistica.BuscExisteCodAsignacionTI(ce_logistica.CodActAsigTI);
            if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == ce_logistica.CodActAsigTI)
            {
                string MessageBoxTitle = "Eliminar";
                string MessageBoxContent = "¿Desea eliminar?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    objdatlogisticaneg.EliminAsignacionActTI(
                     ce_logistica.CodActAsigTI,
                     ce_logistica.ItemTI,
                     ce_usuario.FechaSistema(),
                     ce_usuario.usecod
                     );

                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
                    ng.ShowDialog();
                    //Close();

                    //dataGridView2.Columns.Clear();
                    //dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
                    //dataGridView2.AllowUserToAddRows = false;
                    //OrigenColorfila();
                    //dataGridView2.ClearSelection();
                    toolStripButton_nuevo.Enabled = true;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ce_equipoti.AreaEquipo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            ce_equipoti.TipoEquipo = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            ce_equipoti.MarcaEquipo = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            ce_equipoti.ModeloEquipo = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            ce_equipoti.IMEIEquipo = dataGridView2.CurrentRow.Cells[14].Value.ToString();
            ce_equipoti.NumeroEquipo = dataGridView2.CurrentRow.Cells[28].Value.ToString();
            ce_equipoti.SerieEquipo = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            ce_equipoti.CodActivo = dataGridView2.CurrentRow.Cells[27].Value.ToString();

            Frm_InventarioActivo obj = new Frm_InventarioActivo();
            obj.CargarDatosComboBox();
            obj.textBox_CodAsig.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            obj.textBox_item.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            obj.comboBox_CodEmp.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            obj.comboBox_CodSede.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            obj.comboBox_CodArea.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            obj.textBox_Dni.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            obj.textBox_Usuario.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            obj.comboBox_EstadoActivo.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            obj.comboBox_Activo.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();

            //CARGAR CONDICION DEL PRODUCTO
            obj.comboBox_Estado.DataSource = cn_regproducto.ListCond();
            obj.comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            obj.comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            obj.comboBox_Estado.Text = dataGridView2.CurrentRow.Cells[22].Value.ToString();

            obj.textBox_DevEvent.Text = dataGridView2.CurrentRow.Cells[23].Value.ToString();
            obj.textBox_Cant.Text = dataGridView2.CurrentRow.Cells[25].Value.ToString();
            obj.textBox_Numero.Text = dataGridView2.CurrentRow.Cells[24].Value.ToString();
            obj.textBox_Ubicacion.Text = dataGridView2.CurrentRow.Cells[26].Value.ToString();
            //obj.dateTimePicker_F_Entrega.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            //obj.dateTimePicker_F_Deolucion.Text = dataGridView2.CurrentRow.Cells[19].Value.ToString();
            obj.textBox_Obs1.Text = dataGridView2.CurrentRow.Cells[20].Value.ToString();
            obj.textBox_Obs2.Text = dataGridView2.CurrentRow.Cells[21].Value.ToString();

            obj.toolStripButton_guardar.Enabled = false;

            //if (obj.comboBox_Estado.Text == "ANULADO")
            //{
            //    obj.toolStripButton_eliminar.Enabled = false;
            //}

            obj.dataGridView2.Columns.Clear();
            obj.dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(dataGridView2.CurrentRow.Cells[27].Value.ToString());
            obj.dataGridView2.AllowUserToAddRows = false;
            obj.OrigenColorfila();
            obj.dataGridView2.ClearSelection();

            obj.ShowDialog();

            //dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
            //dataGridView2.AllowUserToAddRows = false;
            //OrigenColorfila();
            //dataGridView2.ClearSelection();
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;
        }

        private void toolStripButton_PrintQR_Click(object sender, EventArgs e)
        {
            ce_equipoti.EmpresaEquipo = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            ce_equipoti.SedeEquipo = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            ce_equipoti.AreaEquipo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            ce_equipoti.DniRespEquipo = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            ce_equipoti.UsuarioEquipo = dataGridView2.CurrentRow.Cells[7].Value.ToString();

            ce_equipoti.TipoEquipo = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            ce_equipoti.SerieEquipo = dataGridView2.CurrentRow.Cells[13].Value.ToString();

            //ce_equipoti.FechaEntregaEquipo = 
            //  Convert.ToDateTime(dataGridView2.CurrentRow.Cells[12].Value).Date;

            try
            {
                ImprimirQR();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void ImprimirQR()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Asignacion.Ds_RepAsignacion objDsRepVenta = new Reportes.Frm_Asignacion.Ds_RepAsignacion();
            string Tipo;
            string Descripcion;
            Tipo = "TODOS";
            Descripcion = "TODOS";

            objDsRepVenta.Tables[0].Rows.Add
            (new object[]{
                Tipo,
                Descripcion
            });

            //int filas = dataGridView2.Rows.Count;
            //for (int i = 0; i <= filas - 1; i++)
            //{

            //}

            objDsRepVenta.Tables[5].Rows.Add
                    (new object[]{
                    ce_equipoti.EmpresaEquipo ,
                    ce_equipoti.SedeEquipo ,
                    ce_equipoti.DniRespEquipo,
                    ce_equipoti.UsuarioEquipo ,
                    ce_equipoti.TipoEquipo ,
                    ce_equipoti.SerieEquipo,
                    ce_equipoti.AreaEquipo,

                    ce_equipoti.FechaEntregaEquipo
                    });


            Reportes.Frm_Asignacion.CrystalPrintSerieEquipo objCryRep = new Reportes.Frm_Asignacion.CrystalPrintSerieEquipo();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalPrintSerieEquipo.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }

        private void toolStripSeparator14_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.ToString() == "ANULADO")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ce_logistica.CodActAsigTI = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            ce_logistica.ItemTI = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            toolStripButton_eliminar.Enabled = true;

            toolStripButton_inventario.Visible = true;
            toolStripLabel_inventario.Visible = true;
            toolStripButton_PrintQR.Visible = true;
            toolStripLabel_PrintQR.Visible = true;

        }

        private async void CargarDatosInicio()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();
                toolStripButton_inventario.Visible = false;
                toolStripLabel_inventario.Visible = false;
                toolStripButton_PrintQR.Visible = false;
                toolStripLabel_PrintQR.Visible = false;

                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    dtg = cn_logistica.ListaAsignacionTI();
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                    toolStripButton_nuevo.Enabled = true;
                    toolStripButton_inventario.Visible = false;
                    toolStripLabel_inventario.Visible = false;
                });

                dataGridView2.DataSource = dtg;
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

        private async void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();
                toolStripButton_inventario.Visible = false;
                toolStripLabel_inventario.Visible = false;
                toolStripButton_PrintQR.Visible = false;
                toolStripLabel_PrintQR.Visible = false;

                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    dtg = cn_logistica.ListaAsignacionFiltroTI(
                    gn2FechaInicio.Value.Date, gn2FechaFin.Value.Date, "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%", "%");
                    dataGridView2.AllowUserToAddRows = false;
                    OrigenColorfila();
                    dataGridView2.ClearSelection();
                    toolStripButton_nuevo.Enabled = true;
                    toolStripButton_inventario.Visible = false;
                    toolStripLabel_inventario.Visible = false;
                });
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg;
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
                toolStripButton_eliminar.Enabled = false;

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
                toolStripButton_eliminar.Enabled = true;
            }
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

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ce_logistica.codigo_ti = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //ce_logistica.descripcion_ti = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //ce_logistica.comentario_ti = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //ce_logistica.estado_ti = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            Frm_ModificarAsignacion obj = new Frm_ModificarAsignacion();
            obj.CargarDatosComboBox();
            obj.textBox_CodAsig.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            obj.textBox_item.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            obj.comboBox_CodEmp.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            obj.comboBox_CodSede.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            obj.comboBox_CodArea.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            obj.textBox_Dni.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            obj.textBox_Usuario.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            obj.comboBox_Activo.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            obj.comboBox_EstadoActivo.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();

            //CARGAR CONDICION DEL PRODUCTO
            obj.comboBox_Estado.DataSource = cn_regproducto.ListCond();
            obj.comboBox_Estado.DisplayMember = "DesEstado"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            obj.comboBox_Estado.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            obj.comboBox_Estado.Text = dataGridView2.CurrentRow.Cells[22].Value.ToString();

            obj.textBox_Cant.Text = dataGridView2.CurrentRow.Cells[25].Value.ToString();
            obj.textBox_Numero.Text = dataGridView2.CurrentRow.Cells[24].Value.ToString();
            obj.textBox_Ubicacion.Text = dataGridView2.CurrentRow.Cells[26].Value.ToString();
            //obj.dateTimePicker_F_Entrega.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            //obj.dateTimePicker_F_Deolucion.Text = dataGridView2.CurrentRow.Cells[19].Value.ToString();
            obj.textBox_Obs1.Text = dataGridView2.CurrentRow.Cells[20].Value.ToString();
            obj.textBox_Obs2.Text = dataGridView2.CurrentRow.Cells[21].Value.ToString();

            obj.toolStripButton_guardar.Enabled = false;

            if (obj.comboBox_Estado.Text == "ANULADO")
            {
                obj.toolStripButton_eliminar.Enabled = false;
            }

            //obj.dataGridView2.Columns.Clear();
            //obj.dataGridView2.DataSource = cn_logistica.ListaPerifericoActTI(dataGridView2.CurrentRow.Cells[27].Value.ToString());
            //obj.dataGridView2.AllowUserToAddRows = false;
            //obj.OrigenColorfila();
            //obj.dataGridView2.ClearSelection();

            obj.ShowDialog();

            /*dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaAsignacionTI();
            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();
            toolStripButton_nuevo.Enabled = true;
            toolStripButton_eliminar.Enabled = false;
            toolStripButton_inventario.Visible = false;
            toolStripLabel_inventario.Visible = false;*/
        }
    }

}
