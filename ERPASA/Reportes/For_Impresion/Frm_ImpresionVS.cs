using ERPASA.Reportes.Report_RDLC.Transporte;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Reportes.For_Impresion
{
    public partial class Frm_ImpresionVS : Form
    {
        public Frm_ImpresionVS()
        {
            InitializeComponent();
        }
        // Este método recibe el DataSet que le pasas desde el otro formulario
        public void CargarReporte(DataSetQrPlaca objDsRepFotosheck)
        {
            // Crear el ReportDataSource
            ReportDataSource rds = new ReportDataSource("DataSetQrPlaca", objDsRepFotosheck.Tables[1]);

            // Configurar el ReportViewer y asignarle el ReportDataSource
            this.reportViewer1.LocalReport.ReportPath = @"ruta_a_tu_informe.rdlc"; // Asegúrate de poner la ruta correcta del archivo RDLC
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            // Refrescar el reporte para que se muestren los datos
            this.reportViewer1.RefreshReport();
        }

        private void Frm_ImpresionVS_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
