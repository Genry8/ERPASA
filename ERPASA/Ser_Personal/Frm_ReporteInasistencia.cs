using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using CrystalDecisions.CrystalReports.Engine;
using ERPASA.Msbox;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_ReporteInasistencia : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        cu_excel objexcel = new cu_excel();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_ReporteInasistencia()
        {
            InitializeComponent();
            //BuscarUsuarioPedateado();
            //dataGridView1.ClearSelection();
        }

        private void Frm_ReporteInasistencia_Load(object sender, EventArgs e)
        {

            //ALTO RIESGO
            //comboBox_empresa.Items.Add("SELECCIONE");
            ComboBox_Adicional.SelectedIndex = 0;
            comboBox_area.SelectedIndex = 0;
            comboBox_TipoPersonal.SelectedIndex = 0;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            ComboBox_Adicional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoPersonal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede_Comedor.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaComedor();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR AREA
            comboBox_area.DataSource = cn_logistica.ListaCBAreaComedor();
            comboBox_area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_area.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaSedeComedor();
            comboBox_CodSede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodSede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string empText = string.Empty, tipopersonalText = string.Empty
                , emp, tipopersonal;
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
            if (comboBox_TipoPersonal.InvokeRequired)
            {
                comboBox_TipoPersonal.Invoke(new MethodInvoker(() =>
                {
                    tipopersonalText = comboBox_TipoPersonal.Text;
                }));
            }
            else
            {
                tipopersonalText = comboBox_TipoPersonal.Text;
            }
            //////////////////
            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }

            if (tipopersonalText == "TODOS")
            {
                tipopersonal = "%";
            }
            else
            {
                tipopersonal = tipopersonalText;
            }

            comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaSedeComedorEmpresa(
                    emp, tipopersonal);
            comboBox_CodSede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodSede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CargarDatossync();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }


        private async void CargarDatossync()
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
                    BuscarUsuarioPedateadoInasistencia();
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
            if (dataGridView1.Rows.Count > 0)
            {
                cn_equipoti.BuscPaginaParaHoja(16, ce_usuario.Fecha_Entrega);
                ImprimirReporteComedor();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA IMPRIMIR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }


        public void ImprimirReporteComedor()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Comedor.DataSetComedor objDsRepVenta = new Reportes.Frm_Comedor.DataSetComedor();

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

            objDsRepVenta.Tables[2].Rows.Add
                    (new object[]{
                    Convert.ToInt32(label_cant_desayuno.Text)+Convert.ToInt32(label_cant_almuerzo.Text)+Convert.ToInt32(label_cant_cena.Text),
                    label_cant_desayuno.Text,
                    label_cant_almuerzo.Text,
                    label_cant_cena.Text
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });

            objDsRepVenta.Tables[1].Rows.Add
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
                objDsRepVenta.Tables[3].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//NRO
                    dataGridView1[1,i].Value.ToString(),//DNI, DESPUES DE DNI SIGUE FECHA
                    //dataGridView1[2,i].Value.ToString(),//FECHA
                    Convert.ToString( Convert.ToDateTime(dataGridView1[2,i].Value.ToString()).Year + "-" + Convert.ToString(Convert.ToDateTime(dataGridView1[2,i].Value.ToString()).Month.ToString("D2")) + "-" + Convert.ToString(Convert.ToDateTime(dataGridView1[2,i].Value.ToString()).Day.ToString("D2")) ),
                    dataGridView1[3,i].Value.ToString(),//APE NOM
                    dataGridView1[4,i].Value.ToString(),//AREA
                    dataGridView1[5,i].Value.ToString(),//EMPRESA
                    dataGridView1[6,i].Value.ToString(),//TIP PERSONAL
                    dataGridView1[7,i].Value.ToString(),//ADICIONAL
                    dataGridView1[8,i].Value.ToString(),//DESAYUNO
                    dataGridView1[9,i].Value.ToString(),//ALM
                    dataGridView1[10,i].Value.ToString(),//CENA
                    comboBox_CodSede_Comedor.Text,
                    fechainicio,
                    fechafin
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_Comedor.CryRep_Com_MarcProg objCryRep = new Reportes.Frm_Comedor.CryRep_Com_MarcProg();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRep_Com_MarcProg.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }

        public void BuscarUsuarioPedateadoInasistencia()
        {
            String adicionalText = string.Empty,
                areaText = string.Empty,
                tipopersonalText = string.Empty, empText = string.Empty,
                sedeText = string.Empty,
                adicional, area, tipopersonal, emp, sede;
            ////////////////////////////////////
            if (ComboBox_Adicional.InvokeRequired)
            {
                ComboBox_Adicional.Invoke(new MethodInvoker(() =>
                {
                    adicionalText = ComboBox_Adicional.Text;
                }));
            }
            else
            {
                adicionalText = ComboBox_Adicional.Text;
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
            if (comboBox_TipoPersonal.InvokeRequired)
            {
                comboBox_TipoPersonal.Invoke(new MethodInvoker(() =>
                {
                    tipopersonalText = comboBox_TipoPersonal.Text;
                }));
            }
            else
            {
                tipopersonalText = comboBox_TipoPersonal.Text;
            }
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
            if (comboBox_CodSede_Comedor.InvokeRequired)
            {
                comboBox_CodSede_Comedor.Invoke(new MethodInvoker(() =>
                {
                    sedeText = comboBox_CodSede_Comedor.Text;
                }));
            }
            else
            {
                sedeText = comboBox_CodSede_Comedor.Text;
            }

            ////////////////////////
            ///adic
            ///////////////////////
            //MessageBox.Show(" " + adicionalText);


            if (adicionalText == "TODOS")
            {
                adicional = "%";
            }
            else
            {
                adicional = adicionalText;
            }
            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }
            if (areaText == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = areaText;
            }

            if (tipopersonalText == "TODOS")
            {
                tipopersonal = "%";
            }
            else
            {
                tipopersonal = tipopersonalText;
            }
            if (sedeText == "COMEDOR")
            {
                sede = "%";
            }
            else
            {
                sede = sedeText;
            }


            dtg = cn_logistica.BuscarPedateoPersonalComedorInasistencia(
            dateTimePicker_Comedor_F_Inicio.Value.Date
            , dateTimePicker_Fecha_Final.Value.Date, adicional, area
            , tipopersonal, emp, sede, "%");

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
            int desayuno = 0;
            int almuerzo = 0;
            int cena = 0;
            int tot = 0;

            Decimal solesdesayuno = 0;
            Decimal solesalmuerzo = 0;
            Decimal solescena = 0;
            Decimal total = 0;
            //decimal otros = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //int c = dataGridView2.Rows.Count;
                //for (int i = 0; i < c; i++)
                //{
                if (item.Cells["DESAYUNO"].Value.ToString().Contains("NO"))
                {
                    desayuno = desayuno + 1;
                }
                if (item.Cells["ALMUERZO"].Value.ToString().Contains("NO"))
                {
                    almuerzo = almuerzo + 1;
                }
                if (item.Cells["CENA"].Value.ToString().Contains("NO"))
                {
                    cena = cena + 1;
                }
                //int suma = 0;               
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["S/.DES"].Value != null)
                    solesdesayuno += (Decimal)row.Cells["S/.DES"].Value;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["S/.ALM"].Value != null)
                    solesalmuerzo += (Decimal)row.Cells["S/.ALM"].Value;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["S/.CENA"].Value != null)
                    solescena += (Decimal)row.Cells["S/.CENA"].Value;
            }

            label_cant_desayuno.Text = desayuno.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_cant_almuerzo.Text = almuerzo.ToString();//"S/. " + NoAnulado.ToString("0,0.00");
            label_cant_cena.Text = cena.ToString();//"S/. " + total.ToString("0,0.00");
            label_cantidad_total.Text = (desayuno + almuerzo + cena).ToString();

            label_soles_desayuno.Text = "S/. " + solesdesayuno.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_soles_almuerzo.Text = "S/. " + solesalmuerzo.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_soles_cena.Text = "S/. " + solescena.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_soles_total.Text = "S/. " + (solesdesayuno + solesalmuerzo + solescena).ToString();
            //textBox_igv.Text = igv.ToString();
            //textBox_subtotal.Text = subtotal.ToString();
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_TipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Empresa();
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
    }
}
