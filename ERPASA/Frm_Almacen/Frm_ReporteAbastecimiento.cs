using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Almacen
{
    public partial class Frm_ReporteAbastecimiento : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_ReporteAbastecimiento()
        {
            InitializeComponent();
            //BuscarUsuarioPedateado();
            //dataGridView1.ClearSelection();
        }

        private void Frm_ReporteAbastecimiento_Load(object sender, EventArgs e)
        {

            //ALTO RIESGO
            //comboBox_empresa.Items.Add("SELECCIONE");
            comboBox_area.SelectedIndex = 0;
            comboBox_Tipo_Combustible.SelectedIndex = 0;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Tipo_Combustible.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR AREA
            comboBox_area.DataSource = cn_logistica.ListaCBAreaTodoAsignacionTI();
            comboBox_area.DisplayMember = "DesArea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_area.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_CodSede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_CodSede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_CodSede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CargarDatosSync();
                //Thread.Sleep(5000);  // wait for a while
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

            //BuscarUsuarioPedateado();
            //dataGridView1.ClearSelection();
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
                    BuscarUsuarioAbastecimiento();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                OrigenColorfila();
                SumarTotal();

                //CONTAR LA CANTIDAD DE REGISTROS
                if (dataGridView1.Rows.Count > 0)
                {
                    label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";

                    //Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(3, 151, 43), 2);
                    //ng.Show();
                }
                else
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
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


        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    if (comboBox_Tipo_Combustible.Text == "TODOS")
            //    {
            //        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE TIPO COMBUSTIBLE", Color.FromArgb(238, 24, 24), 3);
            //        ng.ShowDialog();
            //    }
            //    else if (comboBox_empresa.Text == "SELECCIONE")
            //    {
            //        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
            //        ng.ShowDialog();
            //    }
            //    else if (comboBox_Tipo_Combustible.Text == "PETROLEO")
            //    {
            //        cn_equipoti.BuscPaginaParaHoja(18, dateTimePicker_Comedor_F_Inicio.Value.Date);
            //        ImprimirReporteDetalleAbastecimiento();
            //    }
            //    else if (comboBox_Tipo_Combustible.Text == "PREMIUN")
            //    {
            //        cn_equipoti.BuscPaginaParaHoja(19, dateTimePicker_Comedor_F_Inicio.Value.Date);
            //        ImprimirReporteDetalleAbastecimiento();
            //    }
            //}
            //else
            //{
            //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA IMPRIMIR", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}

        }


        public void ImprimirReporteDetalleAbastecimiento()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_almacen.DataSetAlmacen objDsRepVenta = new Reportes.Frm_almacen.DataSetAlmacen();

            string fechainicio = dateTimePicker_Comedor_F_Inicio.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_Comedor_F_Inicio.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_Comedor_F_Inicio.Value.Date.Day.ToString("D2"));
            string fechafin = dateTimePicker_Fecha_Final.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_Fecha_Final.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_Fecha_Final.Value.Date.Day.ToString("D2"));
            string nombreH = ce_equipoti.NombreHoja;
            string TipoH = ce_equipoti.TipoHoja;
            string CodigoH = ce_equipoti.CodigoHoja;
            string VersionH = ce_equipoti.VersionHoja;
            DateTime FechaH = ce_equipoti.FechaHoja;
            int PaginaH = ce_equipoti.PaginaHoja;
            string EmpH = ce_equipoti.EmpresaHoja;
            string RucH = ce_equipoti.RucHoja;
            string DireccionH = ce_equipoti.DireccionHoja;
            string InspectoH = ce_equipoti.InspectorHoja;
            int DniInspectoH = ce_equipoti.DniInspectorHoja;

            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];

            objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    label_regular.Text+label_petroleo.Text+label_premiun.Text,
                    label_regular.Text,
                    label_petroleo.Text,
                    label_premiun.Text
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });

            objDsRepVenta.Tables[0].Rows.Add
            (new object[]{
                nombreH,
                TipoH,
                CodigoH,
                VersionH,
                FechaH.ToString("dd/MM/yyyy"),
                PaginaH,
                EmpH,
                RucH,
                DireccionH,
                InspectoH,
                FirmaH
            });

            int filas = dataGridView1.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[2].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//N°
                    Convert.ToString( Convert.ToDateTime(dataGridView1[1,i].Value.ToString()).Year + "-" + Convert.ToString(Convert.ToDateTime(dataGridView1[1,i].Value.ToString()).Month.ToString("D2")) + "-" + Convert.ToString(Convert.ToDateTime(dataGridView1[1,i].Value.ToString()).Day.ToString("D2")) ),
                    //dataGridView1[1,i].Value.ToString(),//FECHA
                    dataGridView1[2,i].Value.ToString(),//COMBUSTIBLE
                    dataGridView1[3,i].Value.ToString(),//USUARIO DESPACHA
                    dataGridView1[4,i].Value.ToString(),//N° PRECINTO
                    dataGridView1[5,i].Value.ToString(),//HORA
                    dataGridView1[6,i].Value.ToString(),//APELLIDOS Y NOMBRES
                    dataGridView1[7,i].Value.ToString(),//PLACA
                    dataGridView1[8,i].Value.ToString(),//KILOMETRAJE
                    dataGridView1[9,i].Value.ToString(),//CONSUMO
                    dataGridView1[10,i].Value.ToString(),//VISTO BUENO
                    dataGridView1[11,i].Value.ToString(),//OBSERVACION
                    comboBox_empresa.Text,
                    comboBox_CodSede.Text,
                    fechainicio,
                    fechafin
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_almacen.CrystalReport_Almacen_ASA objCryRep = new Reportes.Frm_almacen.CrystalReport_Almacen_ASA();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReport_Almacen_ASA.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BuscarUsuarioAbastecimiento();
            }

            else if (char.IsWhiteSpace(e.KeyChar))
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



        public void BuscarUsuarioAbastecimiento()
        {

            string empText = string.Empty
                , sedeText = string.Empty
                , areaText = string.Empty, tipocombustibleText = string.Empty;
            string emp, sede, area, tipocombustible;
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
            if (comboBox_CodSede.InvokeRequired)
            {
                comboBox_CodSede.Invoke(new MethodInvoker(() =>
                {
                    sedeText = comboBox_CodSede.Text;
                }));
            }
            else
            {
                sedeText = comboBox_CodSede.Text;
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
            if (comboBox_Tipo_Combustible.InvokeRequired)
            {
                comboBox_Tipo_Combustible.Invoke(new MethodInvoker(() =>
                {
                    tipocombustibleText = comboBox_Tipo_Combustible.Text;
                }));
            }
            else
            {
                tipocombustibleText = comboBox_Tipo_Combustible.Text;
            }
            //////////////////
            //////////////////
            //////////////////
            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }
            //////////////////
            if (sedeText == "SELECCIONE")
            {
                sede = "%";
            }
            else
            {
                sede = sedeText;
            }
            //////////////////
            if (areaText == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = areaText;
            }
            //////////////////
            if (tipocombustibleText == "TODOS")
            {
                tipocombustible = "%";
            }
            else
            {
                tipocombustible = tipocombustibleText;
            }


            dtg = cn_almacen.BuscarPedateoAbastecimientoGrifo(
            dateTimePicker_Comedor_F_Inicio.Value.Date, dateTimePicker_Fecha_Final.Value.Date, area
            , tipocombustible, emp, sede, "%");

            /////////////////////////////
            //textBox_Dni.Text = "";
        }


        //
        public void OrigenColorfila()
        {
            int c = dataGridView1.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "ANULADO")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }


        public void SumarTotal()
        {
            double regular = 0;
            double petroleo = 0;
            double premiun = 0;
            //decimal otros = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //int c = dataGridView2.Rows.Count;
                //for (int i = 0; i < c; i++)
                //{
                //regular += Convert.ToDouble(item.Cells["COMBUSTIBLE"].Value.ToString().Contains("REGULAR"));//desayuno + 1;
                //petroleo += Convert.ToDouble(item.Cells["COMBUSTIBLE"].Value.ToString().Contains("PETROLEO"));//desayuno + 1;
                //premiun += Convert.ToDouble(item.Cells["COMBUSTIBLE"].Value.ToString().Contains("PREMIUN"));//desayuno + 1;

                if (item.Cells["COMBUSTIBLE"].Value.ToString().Contains("REGULAR"))
                {
                    regular += Convert.ToDouble(item.Cells["CONSUMO"].Value);//desayuno + 1;
                }
                if (item.Cells["COMBUSTIBLE"].Value.ToString().Contains("PETROLEO"))
                {
                    petroleo += Convert.ToDouble(item.Cells["CONSUMO"].Value);//desayuno + 1;
                }
                if (item.Cells["COMBUSTIBLE"].Value.ToString().Contains("PREMIUN"))
                {
                    premiun += Convert.ToDouble(item.Cells["CONSUMO"].Value);//desayuno + 1;
                }
            }
            label_regular.Text = regular.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_petroleo.Text = petroleo.ToString();//"S/. " + NoAnulado.ToString("0,0.00");
            label_premiun.Text = premiun.ToString();//"S/. " + total.ToString("0,0.00");
            //textBox_igv.Text = igv.ToString();
            //textBox_subtotal.Text = subtotal.ToString();
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel_imprimir_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            label_cantreg.Text = "";
        }
    }
}
