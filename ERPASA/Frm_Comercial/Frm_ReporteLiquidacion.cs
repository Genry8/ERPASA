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

namespace ERPASA.Frm_Comercial
{
    public partial class Frm_ReporteLiquidacion : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtEmpresa;
        private CancellationTokenSource _cts;

        public Frm_ReporteLiquidacion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ReporteLiquidacion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker_Fecha_Ini.Value = DateTime.Now.Date.AddDays(-5);
            dateTimePicker_Fecha_Fin.Value = DateTime.Now.Date;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            guna2ComboBox_TipoCarga.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox_TipoCarga.SelectedIndex = 0;

            //poner osucro

            //CargaDatos();

            Cargar_Empresa();
            PonerOscuroComboBox();
            CargaDatos();
        }

        public void CargaDatos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {

            dtEmpresa = cn_comercial.ListaEmpresa();
            // Crear una nueva fila al inicio
            DataRow row = dtEmpresa.NewRow();
            row["growername"] = "SELECCIONE";
            row["id"] = 0; // valor por defecto o nulo

            dtEmpresa.Rows.InsertAt(row, 0);

            //CARGAR EMPRESA
            comboBox_empresa.DataSource = dtEmpresa;
            comboBox_empresa.DisplayMember = "growername"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //    //CARGAR SEDE EMPRESA
            //    comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_empresa.Text);
            //    comboBox_CodSede_Comedor.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_CodSede_Comedor.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {

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

            label_cantreg.Text = "";

            try
            {
                string tipoCarga = guna2ComboBox_TipoCarga.Text;
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //if (tipoCarga == "CARGA ORIGINAL")
                    if (tipoCarga == "CARGA AJUSTADO")
                    {
                        BuscarReporteLiquidacion("5");
                    }
                    else
                    {
                        BuscarReporteLiquidacion("1");
                    }


                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;

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


        public void BuscarReporteLiquidacion(string id)
        {
            string empText = string.Empty, emp;

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
            ////////////////////
            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }

            dtg = cn_comercial.BuscarReporteLiquidacion(
            dateTimePicker_Fecha_Ini.Value.Date, dateTimePicker_Fecha_Fin.Value.Date
            , emp, id);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox_marc.Focus();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToAddRows = true;
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
