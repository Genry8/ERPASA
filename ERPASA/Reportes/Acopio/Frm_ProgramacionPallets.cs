using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Taller;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_ProgramacionPallets : Form
    {
        string pallet, cabezal, variedad, kilos;

        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;

        public Frm_ProgramacionPallets()
        {
            InitializeComponent();
        }

        private void Frm_ProgramacionPallets_Load(object sender, EventArgs e)
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
            comboBox_Maquina.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_variedad.DropDownStyle = ComboBoxStyle.DropDownList;

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

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinaria();
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            string emp, sed, cult,var,maq;
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_detalle_empresa.Text;
            }
            if (comboBox_detalle_sede.Text == "SELECCIONE")
            {
                sed = "%";
            }
            else
            {
                sed = comboBox_detalle_sede.Text;
            }
            if (comboBox_detalle_Cultivo.Text == "SELECCIONE")
            {
                cult = "%";
            }
            else
            {
                cult = comboBox_detalle_Cultivo.Text;
            }
            if (comboBox_variedad.Text == "SELECCIONE")
            {
                var = "%";
            }
            else
            {
                var = comboBox_variedad.Text;
            }
            if (comboBox_Maquina.Text == "SELECCIONE")
            {
                maq = "%";
            }
            else
            {
                maq = comboBox_Maquina.Text;
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
            dt = cn_sst.ListaRecepcionProgVolcado(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult,var, maq);
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
                BuscarRecepcionAcopio();
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
            pallet = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cabezal = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            variedad = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            kilos = dataGridView2.CurrentRow.Cells[5].Value.ToString();

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            Frm_NuevaProgramacionPallets frbm = new Frm_NuevaProgramacionPallets();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
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


        public void ImprimirReporteDetalleAtencionIA()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Topico.DataSetTopico objDsRepVenta = new Reportes.Frm_Topico.DataSetTopico();

            string fechainicio = dateTimePicker_FecInicio.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_FecInicio.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_FecInicio.Value.Date.Day.ToString("D2"));
            string fechafin = dateTimePicker_FecFin.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_FecFin.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_FecFin.Value.Date.Day.ToString("D2"));
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
                    0,
                    0,
                    0,
                    0
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

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[2].Rows.Add
                    (new object[]{
                    "1",//N°
                    Convert.ToString( Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Year + "-" + Convert.ToString(Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Month.ToString("D2")) + "-" + Convert.ToString(Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Day.ToString("D2")) ),
                    //dataGridView1[1,i].Value.ToString(),//FECHA
                    dataGridView2[1,i].Value.ToString(),//QUINCENA
                    dataGridView2[2,i].Value.ToString(),//MES
                    dataGridView2[3,i].Value.ToString(),//DNI
                    dataGridView2[4,i].Value.ToString(),//APE NOM
                    dataGridView2[5,i].Value.ToString(),//AREA
                    dataGridView2[6,i].Value.ToString(),//JEFE AREA
                    dataGridView2[7,i].Value.ToString(),//PATOLOGIA
                    dataGridView2[8,i].Value.ToString(),//DIAGNOSTICO
                    dataGridView2[10,i].Value.ToString(),//TRATAMIENTO
                    dataGridView2[11,i].Value.ToString(),//CANTIDAD
                    dataGridView2[12,i].Value.ToString(),//ACCION REALIZADA
                    dataGridView2[13,i].Value.ToString(),//HR_ENTRADA
                    dataGridView2[14,i].Value.ToString(),//HR_SALIDA
                    comboBox_detalle_empresa.Text,
                    comboBox_detalle_sede.Text,
                    fechainicio,
                    fechafin,
                    dataGridView2[9,i].Value.ToString()//SINTOMAS
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_Topico.CrystalReport_AtenMed_IA objCryRep = new Reportes.Frm_Topico.CrystalReport_AtenMed_IA();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReport_AtenMed_IA.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


    }
}
