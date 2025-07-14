using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Reportes.Frm_Comedor
{
    public partial class Frm_ImprimirQRVehiculo : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;

        public Frm_ImprimirQRVehiculo()
        {
            InitializeComponent();
        }

        private void Frm_ImprimirQRVehiculo_Load(object sender, EventArgs e)
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
            comboBox_transportista.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_transportista.DataSource = cn_logistica.ListaTransportistas();
            comboBox_transportista.DisplayMember = "Transporte"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_transportista.ValueMember = "Transporte"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarReporteQRTransportista()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string trans;
            if (comboBox_transportista.Text == "SELECCIONE")
            {
                trans = "%";
            }
            else
            {
                trans = comboBox_transportista.Text;
            }

            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            //dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_sst.ListaRecepcionImprimir(dateTimePicker_FecInicio.Value.Date
            //    , dateTimePicker_FecFin.Value.Date, emp
            //    , sed);

            //dataGridView2.AllowUserToAddRows = false;
            ////OrigenColorfila();
            //dataGridView2.ClearSelection();


            //dataGridView3.ReadOnly = true;
            DataTable dt = new DataTable();
            dt = cn_servpersonal.ListaReporteQRTransportista(trans);
            dataGridView2.DataSource = dt;
            //OrigenColorfila();
            dataGridView2.ClearSelection();

            //DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            //estado.HeaderText = "estado";
            //dataGridView2.Columns.Insert(0, estado);

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                checkBox1.Checked = false;
                BuscarReporteQRTransportista();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            comboBox_transportista.Focus();

            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > 0)
            {
                ImprimirQRVehiculoPlaca();
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
            }
        }


        public void ImprimirQRVehiculoPlaca()
        {
            Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetComedor objDsRepFotosheck = new DataSetComedor();

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {

                    objDsRepFotosheck.Tables[5].Rows.Add
                        (new object[]{
                        row.Cells[1].Value.ToString().ToUpper(), //placa
                        row.Cells[2].Value.ToString().ToUpper(), //ruc
                        row.Cells[3].Value.ToString().ToUpper(), //transporte
                        row.Cells[4].Value.ToString().ToUpper(), //estado

                        });

                    Frm_Comedor.CryRepFotosheckCampamento objCryRep = new Frm_Comedor.CryRepFotosheckCampamento();
                    //string dir = @"~\CryRep_VentasUsuario.rpt";
                    objCryRep.Load(@"~\CryRepFotosheckCampamento.rpt");
                    objCryRep.SetDataSource(objDsRepFotosheck);
                    objImpresion.crystalReportViewer1.ReportSource = objCryRep;
                }
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
    }
}
