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

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_Reporte_EstadoPallet : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg2;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        public Frm_Reporte_EstadoPallet()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_EstadoPallet_Load(object sender, EventArgs e)
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



        public void BuscarRecepcionAcopio()
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


            dtg2 = cn_sst.ListaEstadoPallet(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult);

        }


        //
        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "PENDIENTE")
                {
                    dataGridView2.Rows[i].Cells[7].Style.ForeColor = Color.Red; //DarkRed              
                }
                if (dataGridView2.Rows[i].Cells[8].Value.ToString() == "PENDIENTE")
                {
                    dataGridView2.Rows[i].Cells[8].Style.ForeColor = Color.Red; //DarkRed              
                }
                if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "PENDIENTE")
                {
                    dataGridView2.Rows[i].Cells[9].Style.ForeColor = Color.Red; //DarkRed              
                }
                if (dataGridView2.Rows[i].Cells[10].Value.ToString() == "PENDIENTE")
                {
                    dataGridView2.Rows[i].Cells[10].Style.ForeColor = Color.Red; //DarkRed              
                }
            }
        }


        public void SumarTotal()
        {
            int total = 0;
            int gasificado = 0;
            int prefrio = 0;
            int volcado = 0;

            //Decimal total = 0;
            //Decimal gasificado = 0;
            //Decimal prefrio = 0;
            //Decimal volcado = 0;

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                //int c = dataGridView2.Rows.Count;
                //for (int i = 0; i < c; i++)
                //{
                if (!item.Cells[7].Value.ToString().Contains("PENDIENTE"))
                {
                    total = total + 1;
                }
                if (!item.Cells[8].Value.ToString().Contains("PENDIENTE"))
                {
                    gasificado = gasificado + 1;
                }
                if (!item.Cells[9].Value.ToString().Contains("PENDIENTE"))
                {
                    prefrio = prefrio + 1;
                }
                if (!item.Cells[10].Value.ToString().Contains("PENDIENTE"))
                {
                    volcado = volcado + 1;
                }
                //int suma = 0;               
            }
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells["S/.DES"].Value != null)
            //        solesdesayuno += (Decimal)row.Cells["S/.DES"].Value;
            //}
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells["S/.ALM"].Value != null)
            //        solesalmuerzo += (Decimal)row.Cells["S/.ALM"].Value;
            //}
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells["S/.CENA"].Value != null)
            //        solescena += (Decimal)row.Cells["S/.CENA"].Value;
            //}

            label_total_rec.Text = total.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_total_gasificado.Text = gasificado.ToString();//"S/. " + NoAnulado.ToString("0,0.00");
            label_total_prefrio.Text = prefrio.ToString();//"S/. " + total.ToString("0,0.00");
            label_total_volcado.Text = volcado.ToString();

            //label_soles_desayuno.Text = "S/. " + solesdesayuno.ToString();//"S/. " + Anulado.ToString("0,0.00");
            //label_soles_almuerzo.Text = "S/. " + solesalmuerzo.ToString();//"S/. " + Anulado.ToString("0,0.00");
            //label_soles_cena.Text = "S/. " + solescena.ToString();//"S/. " + Anulado.ToString("0,0.00");
            //label_soles_total.Text = "S/. " + (solesdesayuno + solesalmuerzo + solescena).ToString();
            //textBox_igv.Text = igv.ToString();
            //textBox_subtotal.Text = subtotal.ToString();
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
                    BuscarRecepcionAcopio();
                    dataGridView2.ClearSelection();
                });

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg2;
                dataGridView2.AllowUserToAddRows = false;
                OrigenColorfila();
                SumarTotal();

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
    }
}
