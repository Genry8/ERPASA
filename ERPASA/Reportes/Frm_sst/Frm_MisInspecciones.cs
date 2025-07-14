
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Reportes.Frm_sst
{
    public partial class Frm_MisInspecciones : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        cd_datosventa objdatventaDAT = new cd_datosventa();
        cn_datoscliente objdatclienteneg = new cn_datoscliente();
        cn_reportes objdatreporteneg = new cn_reportes();
        cu_excel objexcel = new cu_excel();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private string año, emp, sed, area, sem, doc, tipemp;
        private int borderSize = 2;
        public Frm_MisInspecciones()
        {
            InitializeComponent();
        }

        //DsRepVentas dst = new DsRepVentas();
        //DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter _VentaUsuarioAdap = new DataSetTableAdapters.SP_REPORTES_VENTA_POR_USUARIOTableAdapter();

        private void Frm_MisVentas_Load(object sender, EventArgs e)
        {

            CargarPanelgeneral();
            BloquearTextboxCombobox();
            PonerOscuroComboBox();
            CargarDatosComboBox();
            comboBox_detalle_tipo_inspeccion.SelectedIndex = 0;
            toolStripButton_imprimir.Enabled = false;
            toolStripButton_excel.Enabled = false;

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + ce_equipoti.DniInspectorHoja);
            try
            {
                if (comboBox_detalle_empresa.Text == "SELECCIONE")
                {
                    MessageBox.Show("SELECCIONE EMPRESA Y HAGA CLICK EN BUSCAR", "EMPRESA");
                }

                else if (comboBox_detalle_empresa.Text == "AGRICOLA SANTA AZUL S.R.L")
                {
                    if (comboBox_detalle_tipo_inspeccion.Text == "EXTINTOR")
                    {
                        cn_equipoti.BuscPaginaParaHoja(4, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteExtintor();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "DUCHA LAVA OJOS")
                    {
                        cn_equipoti.BuscPaginaParaHoja(29, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteDuchaLavaOjos();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "LAVA OJOS PORTATIL")
                    {
                        cn_equipoti.BuscPaginaParaHoja(5, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteLavaOjosPortatil();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "KIT ANTIDERRAME")
                    {
                        cn_equipoti.BuscPaginaParaHoja(8, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteKitAntiderrame();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "LUCES EMERGENCIA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(9, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteLucesEmergencia();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ESTACIONES EMERGENCIA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(10, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteEstacionesEmergencia();
                    }

                    else if (comboBox_detalle_tipo_inspeccion.Text == "ALARMAS EMERGENCIA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(10, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteAlarmasEmergencia();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "SEGURIDAD DE RESERVORIO")
                    {
                        cn_equipoti.BuscPaginaParaHoja(22, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteSeguridadReservorio();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ARNES")
                    {
                        cn_equipoti.BuscPaginaParaHoja(24, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteArnes();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ESCALERA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(26, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteEscalera();
                    }
                }
                else if (comboBox_detalle_empresa.Text == "AGRICOLA INTERANDINA S.A.C")
                {
                    if (comboBox_detalle_tipo_inspeccion.Text == "EXTINTOR")
                    {
                        cn_equipoti.BuscPaginaParaHoja(11, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteExtintor_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "DUCHA LAVA OJOS")
                    {
                        cn_equipoti.BuscPaginaParaHoja(28, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteDuchaLavaOjos_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "LAVA OJOS PORTATIL")
                    {
                        cn_equipoti.BuscPaginaParaHoja(12, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteLavaOjosPortatil_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "KIT ANTIDERRAME")
                    {
                        cn_equipoti.BuscPaginaParaHoja(13, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteKitAntiderrame_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "LUCES EMERGENCIA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(14, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteLucesEmergencia_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ESTACIONES EMERGENCIA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(15, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteEstacionesEmergencia_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ALARMAS EMERGENCIA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(15, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteAlarmasEmergencia_Interandina();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "SEGURIDAD DE RESERVORIO")
                    {
                        cn_equipoti.BuscPaginaParaHoja(23, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteSeguridadReservorio();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ARNES")
                    {
                        cn_equipoti.BuscPaginaParaHoja(30, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteArnes();
                    }
                    else if (comboBox_detalle_tipo_inspeccion.Text == "ESCALERA")
                    {
                        cn_equipoti.BuscPaginaParaHoja(27, dateTimePicker_F_Fin.Value.Date);
                        ImprimirReporteEscalera();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ImprimirReporteExtintor()
        {
            Frm_CrpVetaUsuario objImpresion = new Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();

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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[0].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),
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
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),
                    dataGridView2[15,i].Value.ToString(),//
                    dataGridView2[16,i].Value.ToString(),
                    dataGridView2[17,i].Value.ToString(),
                    dataGridView2[18,i].Value.ToString(),
                    dataGridView2[19,i].Value.ToString(),
                    dataGridView2[20,i].Value.ToString(),
                    dataGridView2[21,i].Value.ToString(),
                    dataGridView2[22,i].Value.ToString(),
                    dataGridView2[23,i].Value.ToString(),
                    dataGridView2[24,i].Value.ToString(),
                    dataGridView2[25,i].Value.ToString(),
                    dataGridView2[26,i].Value.ToString(),
                    dataGridView2[27,i].Value.ToString(),
                    dataGridView2[28,i].Value.ToString(),
                    dataGridView2[29,i].Value.ToString(),
                    dataGridView2[30,i].Value.ToString(),
                    dataGridView2[31,i].Value.ToString(),
                    dataGridView2[32,i].Value.ToString(),
                    dataGridView2[33,i].Value.ToString(),
                    dataGridView2[34,i].Value.ToString(),
                    dataGridView2[35,i].Value.ToString()
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            CrystalReport_InspExtintor objCryRep = new CrystalReport_InspExtintor();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReport_InspExtintor.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteExtintor_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();

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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[0].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),
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
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),
                    dataGridView2[15,i].Value.ToString(),//
                    dataGridView2[16,i].Value.ToString(),
                    dataGridView2[17,i].Value.ToString(),
                    dataGridView2[18,i].Value.ToString(),
                    dataGridView2[19,i].Value.ToString(),
                    dataGridView2[20,i].Value.ToString(),
                    dataGridView2[21,i].Value.ToString(),
                    dataGridView2[22,i].Value.ToString(),
                    dataGridView2[23,i].Value.ToString(),
                    dataGridView2[24,i].Value.ToString(),
                    dataGridView2[25,i].Value.ToString(),
                    dataGridView2[26,i].Value.ToString(),
                    dataGridView2[27,i].Value.ToString(),
                    dataGridView2[28,i].Value.ToString(),
                    dataGridView2[29,i].Value.ToString(),
                    dataGridView2[30,i].Value.ToString(),
                    dataGridView2[31,i].Value.ToString(),
                    dataGridView2[32,i].Value.ToString(),
                    dataGridView2[33,i].Value.ToString(),
                    dataGridView2[34,i].Value.ToString(),
                    dataGridView2[35,i].Value.ToString(),
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            CrystalReport_InspExtintor_Interandina objCryRep = new CrystalReport_InspExtintor_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReport_InspExtintor_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteDuchaLavaOjos()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Tipo
                    dataGridView2[6,i].Value.ToString(),//Area
                    dataGridView2[7,i].Value.ToString(),//Ubic
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),//item 7
                    dataGridView2[15,i].Value.ToString(),
                    dataGridView2[16,i].Value.ToString(),//item 9
                    dataGridView2[17,i].Value.ToString(),
                    dataGridView2[18,i].Value.ToString(),
                    //(byte[])dataGridView2[19,i].Value //Foto
                    });
            }

            CryRepDuchaLavaOjos objCryRep = new CryRepDuchaLavaOjos();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepDuchaLavaOjos.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteDuchaLavaOjos_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Tipo
                    dataGridView2[6,i].Value.ToString(),//Area
                    dataGridView2[7,i].Value.ToString(),//Ubic
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),//item 7
                    dataGridView2[15,i].Value.ToString(),
                    dataGridView2[16,i].Value.ToString(),//item 9
                    dataGridView2[17,i].Value.ToString(),
                    dataGridView2[18,i].Value.ToString(),
                    //(byte[])dataGridView2[19,i].Value //Foto
                    });
            }

            CryRepDuchaLavaOjos_Interandina objCryRep = new CryRepDuchaLavaOjos_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepDuchaLavaOjos_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteLavaOjosPortatil()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();

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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[6].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),//item 7
                    dataGridView2[14,i].Value.ToString(),//item 8
                    dataGridView2[15,i].Value.ToString(),
                    dataGridView2[16,i].Value.ToString(),
                    //(byte[])dataGridView2[17,i].Value //Foto
                    });
            }

            CryRepLavaOjosPortatil objCryRep = new CryRepLavaOjosPortatil();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepLavaOjosPortatil.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteLavaOjosPortatil_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[6].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),//item 7
                    dataGridView2[14,i].Value.ToString(),//item 8
                    dataGridView2[15,i].Value.ToString(),
                    dataGridView2[16,i].Value.ToString(),
                    //(byte[])dataGridView2[17,i].Value //Foto
                    });
            }

            CryRepLavaOjosPortatil_Interandina objCryRep = new CryRepLavaOjosPortatil_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepLavaOjosPortatil_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteKitAntiderrame()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),//item 7
                    dataGridView2[14,i].Value.ToString(),
                    dataGridView2[15,i].Value.ToString(),//item 9
                    dataGridView2[16,i].Value.ToString(),//item 10
                    dataGridView2[17,i].Value.ToString(),//item 11
                    dataGridView2[18,i].Value.ToString(),//item 12
                    dataGridView2[19,i].Value.ToString(),
                    dataGridView2[20,i].Value.ToString(),
                    //(byte[])dataGridView2[21,i].Value //Foto
                    });
            }

            CryRepKitAntiderrame objCryRep = new CryRepKitAntiderrame();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepKitAntiderrame.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteKitAntiderrame_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),//item 7
                    dataGridView2[14,i].Value.ToString(),
                    dataGridView2[15,i].Value.ToString(),//item 9
                    dataGridView2[16,i].Value.ToString(),//item 10
                    dataGridView2[17,i].Value.ToString(),//item 11
                    dataGridView2[18,i].Value.ToString(),//item 12
                    dataGridView2[19,i].Value.ToString(),
                    dataGridView2[20,i].Value.ToString(),
                    //(byte[])dataGridView2[21,i].Value //Foto
                    });
            }

            CryRepKitAntiderrame_Interandina objCryRep = new CryRepKitAntiderrame_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepKitAntiderrame_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteLucesEmergencia()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[3].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),//item 7
                    dataGridView2[15,i].Value.ToString(),
                    dataGridView2[16,i].Value.ToString(),
                    //(byte[])dataGridView2[17,i].Value //Foto
                    });
            }

            CryRepLucesEmergencia objCryRep = new CryRepLucesEmergencia();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepLucesEmergencia.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteLucesEmergencia_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[3].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),//item 7
                    dataGridView2[15,i].Value.ToString(),
                    dataGridView2[16,i].Value.ToString(),
                    //(byte[])dataGridView2[17,i].Value //Foto
                    });
            }

            CryRepLucesEmergencia_Interandina objCryRep = new CryRepLucesEmergencia_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepLucesEmergencia_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteEstacionesEmergencia()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[4].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),//item 7
                    dataGridView2[14,i].Value.ToString(),
                    dataGridView2[15,i].Value.ToString(),
                    //(byte[])dataGridView2[16,i].Value //Foto
                    });
            }

            CryRepEstacionesEmergencia objCryRep = new CryRepEstacionesEmergencia();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepEstacionesEmergencia.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteEstacionesEmergencia_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[4].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),//item 7
                    dataGridView2[14,i].Value.ToString(),
                    dataGridView2[15,i].Value.ToString(),
                    //(byte[])dataGridView2[16,i].Value //Foto
                    });
            }

            CryRepEstacionesEmergencia_Interandina objCryRep = new CryRepEstacionesEmergencia_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepEstacionesEmergencia_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }

        //
        //
        //


        public void ImprimirReporteAlarmasEmergencia()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[7].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),//item 6
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),
                    //(byte[])dataGridView2[16,i].Value //Foto
                    });
            }

            CryRepAlarmasEmergencia objCryRep = new CryRepAlarmasEmergencia();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepAlarmasEmergencia.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        //
        //
        //


        public void ImprimirReporteSeguridadReservorio()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[8].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),//item 5
                    dataGridView2[12,i].Value.ToString(),
                    dataGridView2[13,i].Value.ToString(),
                    //(byte[])dataGridView2[14,i].Value //Foto
                    });
            }

            CryRepSeguridadReservorio objCryRep = new CryRepSeguridadReservorio();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepSeguridadReservorio.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        //
        //
        //


        public void ImprimirReporteArnes()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[9].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),//item 6
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),//EST CALIF
                    dataGridView2[15,i].Value.ToString(),//SERIE ARNES
                    dataGridView2[16,i].Value.ToString(),//COD LINEA ANCLAJE
                    dataGridView2[17,i].Value.ToString(),//MARCA
                    dataGridView2[18,i].Value.ToString(),//FEC FAB
                    dataGridView2[19,i].Value.ToString(),//COMENTARIO
                    //(byte[])dataGridView2[16,i].Value //Foto
                    });
            }

            CryRepArnes objCryRep = new CryRepArnes();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepArnes.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteEscalera()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();

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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[10].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),//item 1
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),//item 5
                    dataGridView2[12,i].Value.ToString(),//item 
                    dataGridView2[13,i].Value.ToString(),//item 
                    dataGridView2[14,i].Value.ToString(),//item 
                    dataGridView2[15,i].Value.ToString(),//item 
                    dataGridView2[16,i].Value.ToString(),//item 10
                    dataGridView2[17,i].Value.ToString(),//item 11
                    dataGridView2[18,i].Value.ToString(),
                    dataGridView2[19,i].Value.ToString(),//EST CALIF
                    dataGridView2[20,i].Value.ToString(),//obs 1
                    dataGridView2[21,i].Value.ToString(),//obs 
                    dataGridView2[22,i].Value.ToString(),//obs 
                    dataGridView2[23,i].Value.ToString(),//obs 
                    dataGridView2[24,i].Value.ToString(),//obs 5
                    dataGridView2[25,i].Value.ToString(),//obs 
                    dataGridView2[26,i].Value.ToString(),//obs 
                    dataGridView2[27,i].Value.ToString(),//obs 
                    dataGridView2[28,i].Value.ToString(),//obs 
                    dataGridView2[29,i].Value.ToString(),//obs 
                    dataGridView2[30,i].Value.ToString(),//obs 11
                    dataGridView2[31,i].Value.ToString(),//TIPO
                    dataGridView2[32,i].Value.ToString(),//PASOS
                    dataGridView2[33,i].Value.ToString(),//CODIGO
                    dataGridView2[34,i].Value.ToString(),//EST OPERATIVO
                    dataGridView2[35,i].Value.ToString(),//COMENTARIO
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            CryRepEscalera objCryRep = new CryRepEscalera();
            //string dir = @"~\CryRepEscalera.rpt";
            objCryRep.Load(@"~\CryRepEscalera.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



        public void ImprimirReporteAlarmasEmergencia_Interandina()
        {
            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetInspecciones objDsRepVenta = new DataSetInspecciones();


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

            objDsRepVenta.Tables[5].Rows.Add
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
                objDsRepVenta.Tables[7].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//Estado
                    dataGridView2[1,i].Value.ToString(),//FechaInsp
                    dataGridView2[2,i].Value.ToString(),//Numero
                    dataGridView2[3,i].Value.ToString(),//Emp
                    dataGridView2[4,i].Value.ToString(),//Sed
                    dataGridView2[5,i].Value.ToString(),//Area
                    dataGridView2[6,i].Value.ToString(),//Ubic
                    dataGridView2[7,i].Value.ToString(),
                    dataGridView2[8,i].Value.ToString(),
                    dataGridView2[9,i].Value.ToString(),
                    dataGridView2[10,i].Value.ToString(),
                    dataGridView2[11,i].Value.ToString(),
                    dataGridView2[12,i].Value.ToString(),//item 6
                    dataGridView2[13,i].Value.ToString(),
                    dataGridView2[14,i].Value.ToString(),
                    //(byte[])dataGridView2[16,i].Value //Foto
                    });
            }

            CryRepAlarmasEmergencia_Interandina objCryRep = new CryRepAlarmasEmergencia_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepAlarmasEmergencia_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void EliminarDatagrid12()
        {
            DataTable dtp = new DataTable();
            dtp = cn_datospersonal.BuscarPersForAcadem(int.Parse("123"));
            dataGridView2.DataSource = dtp;
            dtp.Rows.Clear();
            dtp.Columns.Clear();
        }

        public void Limpiartextbox()
        {
            textBox_TotalAnulado.Text = "";
            textBox_TotalNoAnulado.Text = "";
            textBox_total.Text = "";
        }

        public void BloquearTextboxCombobox()
        {
            textBox_total.ReadOnly = true;
            textBox_TotalAnulado.ReadOnly = true;
            textBox_TotalNoAnulado.ReadOnly = true;
        }

        public void DesbloquearTextboxCombobox()
        {
            //DATAGRIDVIEW
            //TEXTBOX
        }

        public void CargarPanelgeneral()
        {
            dataGridView2.Columns.Clear();
            //NO PERMITIR EDITAR COLUMAS

        }


        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            //const int WM_SYSCOMMAND = 0x0112;
            //const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            //const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            //#region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            //#endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            //if (m.Msg == WM_SYSCOMMAND)
            //{
            //    //MAND messages, the four low - order bits of the wParam parameter 
            //    /// are used internally by the system.To obtain the correct result when testing 
            //    /// the value of wParam, an application must combine the value 0xFFF0 with the 
            //    /// wParam value by using the bitwise AND operator.
            //    int wParam = (m.WParam.ToInt32() & 0xFFF0);

            //    if (wParam == SC_MINIMIZE)  //Before
            //        formSize = this.ClientSize;
            //    if (wParam == SC_RESTORE)// Restored form(Before)
            //        this.Size = formSize;
            //}
            base.WndProc(ref m);
        }


        private void panel_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);

            }
            else
                WindowState = FormWindowState.Maximized;
        }

        private void button_minimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void button_min_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textbox_factura_KeyPress(object sender, KeyPressEventArgs e)
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

        //ELIMINAR FACTURA
        private void EliminarFac()
        {
            //objdatventaneg.EliminarFac(Int32.Parse(textbox_factura.Text));
        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            CargarPanelgeneral();
            DesbloquearTextboxCombobox();
            ////
            Limpiartextbox();
            EliminarDatagrid12();
            dataGridView2.Columns.Clear();
            dataGridView2.AllowUserToAddRows = true;
            //dataGridView2.Columns.Clear();
            //EliminarDatagrid12();
            toolStripButton_buscar.Enabled = false;
            toolStripButton_editar.Enabled = false;
            toolStripButton_imprimir.Enabled = false;
        }


        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            CargarPanelgeneral();
            DesbloquearTextboxCombobox();
            ////
            Limpiartextbox();
            EliminarDatagrid12();
            dataGridView2.Columns.Clear();
            dataGridView2.AllowUserToAddRows = true;
            //dataGridView2.Columns.Clear();
            //EliminarDatagrid12();
        }

        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_tipo_inspeccion.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR AREA

            comboBox_detalle_area.DataSource = cn_logistica.ListaCBAreaTodoInspeccionSST();
            comboBox_detalle_area.DisplayMember = "DesArea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_area.ValueMember = "DesArea"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


        }


        public void TablaAgregarDatosFila(DataGridViewRow coduser)
        {

        }


        private void button_buscarcliente_Click(object sender, EventArgs e)
        {


        }


        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if(e.ColumnIndex == 6)
            //{
            //    //bool isdouble = double.TryParse(e.FormattedValue.ToString(), out double resultnumerico);
            //    if(int.Parse(dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString()) > int.Parse(dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString()))
            //    {
            //        Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("NO DEBE SER MAYOR A STOCK", Color.DarkRed, 3);
            //        ng.ShowDialog();
            //        dataGridView2.Rows[e.RowIndex].Cells[6].Value = "0";
            //    }

            //}
        }

        private void textBox_dniusuario_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button_calcular_Click(object sender, EventArgs e)
        {

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

        private void button_calcular_Click_1(object sender, EventArgs e)
        {
            // SumarTotal();
        }

        public void SumarTotal()
        {
            decimal total = 0;
            decimal NoAnulado = 0;
            decimal Anulado = 0;
            //decimal otros = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //int c = dataGridView2.Rows.Count;
                //for (int i = 0; i < c; i++)
                //{
                if (row.Cells[3].Value.ToString() == "AN")
                {
                    Anulado += Math.Round(Convert.ToDecimal(row.Cells[5].Value), 2);
                }
                if (row.Cells[3].Value.ToString() != "AN")
                {
                    NoAnulado += Math.Round(Convert.ToDecimal(row.Cells[5].Value), 2);
                }
                total += Math.Round(Convert.ToDecimal(row.Cells[5].Value), 2);
                //}
            }
            textBox_TotalAnulado.Text = "S/. " + Anulado.ToString("0,0.00");
            textBox_TotalNoAnulado.Text = "S/. " + NoAnulado.ToString("0,0.00");
            textBox_total.Text = "S/. " + total.ToString("0,0.00");
            //textBox_igv.Text = igv.ToString();
            //textBox_subtotal.Text = subtotal.ToString();
        }

        //
        public void OrigenColorfila()
        {
            if (dataGridView2.Rows.Count > 0)
            {

                int c = dataGridView2.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "N")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                        dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 11f, FontStyle.Bold); //DarkRed
                                                                                                                //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                    }
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
            objexcel.ExportarExcelInsp(dataGridView2);
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

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
            if (comboBox_detalle_area.Text == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = comboBox_detalle_area.Text;
            }



            //textBox_detalle_dni.Text = emp.ToString();

            if (comboBox_detalle_tipo_inspeccion.Text == "EXTINTOR")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_Extintor(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }
            else if (comboBox_detalle_tipo_inspeccion.Text == "DUCHA LAVA OJOS")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_DuchaLavaOjos(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }

            else if (comboBox_detalle_tipo_inspeccion.Text == "LAVA OJOS PORTATIL")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_LavaOjosPortatil(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }

            else if (comboBox_detalle_tipo_inspeccion.Text == "LUCES EMERGENCIA")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_LucesEmergencia(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }

            else if (comboBox_detalle_tipo_inspeccion.Text == "ALARMAS EMERGENCIA")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_AlarmasEmergencia(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }


            else if (comboBox_detalle_tipo_inspeccion.Text == "KIT ANTIDERRAME")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_KitAntiDerrame(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }

            else if (comboBox_detalle_tipo_inspeccion.Text == "SEGURIDAD DE RESERVORIO")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_SeguridadReservorio(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }
            else if (comboBox_detalle_tipo_inspeccion.Text == "ARNES")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_Arnes(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }
            else if (comboBox_detalle_tipo_inspeccion.Text == "ESCALERA")
            {

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaInspeccionFiltroSST_Escalera(
                    dateTimePicker_F_ini.Value.Date, dateTimePicker_F_Fin.Value.Date.AddHours(23.99999),
                    comboBox_detalle_empresa.Text = emp,
                    comboBox_detalle_sede.Text = sed,
                    comboBox_detalle_area.Text = area);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();
                OrigenColorfila();
            }
            else
            {
                dataGridView2.Columns.Clear();
            }

            dataGridView2.ReadOnly = false;

            if (dataGridView2.Rows.Count > 0)
            {
                toolStripButton_imprimir.Enabled = true;
                toolStripButton_excel.Enabled = true;
            }
            else
            {
                toolStripButton_imprimir.Enabled = false;
                toolStripButton_excel.Enabled = false;
            }

        }
    }

}
