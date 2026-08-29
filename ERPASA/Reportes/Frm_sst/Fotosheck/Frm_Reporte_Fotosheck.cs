
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Reportes

{
    public partial class Frm_Reporte_Fotosheck : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();

        public Frm_Reporte_Fotosheck()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_Fotosheck_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_tipo_alto_riesgo.SelectedIndex = 0;
            comboBox_empresa_alto_riesgo.SelectedIndex = 0;
            //LICENCIA
            comboBox_empresa_licencia.SelectedIndex = 0;
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            textRuta_Licencia.Enabled = false;
            comboBox_Hojas_Licencia.DropDownStyle = ComboBoxStyle.DropDownList;

            PonerOscuroComboBox();
            esconderpaneles();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_tipo_alto_riesgo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa_alto_riesgo.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
            comboBox_empresa_licencia.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void esconderpaneles()
        {
            //panel_general.Visible = false;
            panel_licencia.Visible = false;
        }

        //private void mostrarbotones()
        //{
        //    button_general.Visible = true;
        //    button_datoslaborales.Visible = true;
        //    button_formacionacademica.Visible = true;
        //    button_planilla.Visible = true;
        //    button_otrosdatos.Visible = true;
        //}


        private void ColumnasDtgv1()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView1.Columns.Add(Dni);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "NOMBRES";
            Nombres.Name = "Column2";
            Nombres.Width = 85;
            dataGridView1.Columns.Add(Nombres);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "EMPRESA";
            Empresa.Name = "Column3";
            Empresa.Width = 87;
            dataGridView1.Columns.Add(Empresa);
        }


        private void ColumnasDtgv2()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView2.Columns.Add(Dni);
            //
            //
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "NOMBRES";
            Nombres.Name = "Column3";
            Nombres.Width = 85;
            dataGridView2.Columns.Add(Nombres);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "EMPRESA";
            Empresa.Name = "Column4";
            Empresa.Width = 87;
            dataGridView2.Columns.Add(Empresa);
            //
            // Column5
            // 
            DataGridViewTextBoxColumn Autorizacion = new DataGridViewTextBoxColumn();
            Autorizacion.HeaderText = "AUTORIZACION";
            Autorizacion.Name = "Column5";
            Autorizacion.Width = 87;
            dataGridView2.Columns.Add(Autorizacion);
        }


        private void HideSubMenu()
        {
            if (panel_general.Visible == true)
                panel_general.Visible = false;
            panel_licencia.Visible = false;
            panel_licencia.Visible = false;
            if (panel_licencia.Visible == true)
                panel_licencia.Visible = false;
            panel_general.Visible = false;
        }

        private void ShowSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
        }

        private void button_credenciales_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_general);
        }

        private void toolStripButton_imprimirHombreNuevo_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (comboBox_empresa_alto_riesgo.Text == "SELECCIONE")
            {
                MessageBox.Show("PARA IMPRIMIR SELECCIONE EMPRESA", "SELECCIONAR EMPRESA");
            }
            if (comboBox_empresa_alto_riesgo.Text == "SANTA AZUL")
            {
                ImprimirFotosheckTrabajoAltoRiesgoSantaAzul();
            }
            if (comboBox_empresa_alto_riesgo.Text == "INTERANDINA")
            {
                ImprimirFotosheckTrabajoAltoRiesgoInterandina();
            }
            if (comboBox_empresa_alto_riesgo.Text == "TERCEROS")
            {
                ImprimirFotosheckTrabajoAltoRiesgoContratista();
            }
            dataGridView1.AllowUserToAddRows = true;
        }


        public void ImprimirFotosheckTrabajoAltoRiesgoContratista()
        {
            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

            string TipoTrabajo = "CREDENCIAL DE " + comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_AltoRiesgo_F_Ini.Value.Date;
            String FechaInduccion = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.Year);
            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.AddYears(1).Year);

            //MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView1.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepFotosheck.Tables[0].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//DNI
                    dataGridView1[1,i].Value.ToString(),//USUARIO
                    FechaInduccion,//FECHA
                    dataGridView1[0,i].Value.ToString(),//SEMANA
                    dataGridView1[1,i].Value.ToString(),//NOTA
                    dataGridView1[2,i].Value.ToString(),//EMPRESA
                    resultfecha
                    //(byte[])dataGridView2[36,i].Value //Foto
                        
                    });
            }

            objDsRepFotosheck.Tables[1].Rows.Add
            (new object[]{
                TipoTrabajo
            });

            Frm_sst.CryRepFTrabajoAltoRiesgo_Contratista objCryRep = new Frm_sst.CryRepFTrabajoAltoRiesgo_Contratista();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFTrabajoAltoRiesgo_Contratista.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirFotosheckTrabajoAltoRiesgoSantaAzul()
        {
            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

            string TipoTrabajo = "CREDENCIAL DE " + comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_AltoRiesgo_F_Ini.Value.Date;
            String FechaInduccion = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.Year);
            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.AddYears(1).Year);

            //MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView1.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepFotosheck.Tables[0].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//DNI
                    dataGridView1[1,i].Value.ToString(),//USUARIO
                    FechaInduccion,//FECHA
                    dataGridView1[0,i].Value.ToString(),//SEMANA
                    dataGridView1[1,i].Value.ToString(),//NOTA
                    dataGridView1[2,i].Value.ToString(),//EMPRESA
                    resultfecha
                    //(byte[])dataGridView2[36,i].Value //Foto
                        
                    });
            }

            objDsRepFotosheck.Tables[1].Rows.Add
            (new object[]{
                TipoTrabajo
            });

            Frm_sst.CryRepFTrabajoAltoRiesgo_SantaAzul objCryRep = new Frm_sst.CryRepFTrabajoAltoRiesgo_SantaAzul();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFTrabajoAltoRiesgo_SantaAzul.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirFotosheckTrabajoAltoRiesgoInterandina()
        {
            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

            string TipoTrabajo = "CREDENCIAL DE " + comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_AltoRiesgo_F_Ini.Value.Date;
            String FechaInduccion = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.Year);
            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.AddYears(1).Year);

            //MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView1.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepFotosheck.Tables[0].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//DNI
                    dataGridView1[1,i].Value.ToString(),//USUARIO
                    FechaInduccion,//FECHA
                    dataGridView1[0,i].Value.ToString(),//SEMANA
                    dataGridView1[1,i].Value.ToString(),//NOTA
                    dataGridView1[2,i].Value.ToString(),//EMPRESA
                    resultfecha
                    //(byte[])dataGridView2[36,i].Value //Foto
                        
                    });
            }

            objDsRepFotosheck.Tables[1].Rows.Add
            (new object[]{
                TipoTrabajo
            });

            Frm_sst.CryRepFTrabajoAltoRiesgo_Interandina objCryRep = new Frm_sst.CryRepFTrabajoAltoRiesgo_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFTrabajoAltoRiesgo_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }

        private void toolStripButton_Credenciales_CargarDatos_Click_1(object sender, EventArgs e)
        {
            if (textRuta.Text != "")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
                dataGridView1.ClearSelection();
                if (dataGridView1.Rows.Count > 1)
                {
                    label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                MessageBox.Show("ELIJA UN EXCEL");
            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
        }

        private void button_Licencia_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_licencia);
        }

        private void toolStripButton_Imprimir_Licencia_Click(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;
            if (comboBox_empresa_licencia.Text == "SELECCIONE")
            {
                MessageBox.Show("PARA IMPRIMIR SELECCIONE EMPRESA", "SELECCINAR EMPRESA");
            }
            if (comboBox_empresa_licencia.Text == "SANTA AZUL")
            {
                ImprimirFotosheckLicenciaSantaAzul();
            }
            if (comboBox_empresa_licencia.Text == "INTERANDINA")
            {
                ImprimirFotosheckLicenciaInterandina();
            }
            if (comboBox_empresa_licencia.Text == "TERCEROS")
            {
                ImprimirFotosheckLicenciaContratista();
            }
            dataGridView2.AllowUserToAddRows = true;

        }


        public void ImprimirFotosheckLicenciaContratista()
        {
            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

            string TipoTrabajo = "CREDENCIAL DE "; //+ comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_Licencia_F_Ini.Value.Date;
            String FechaInduccion = Convert.ToString(dateTimePicker_Licencia_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_Licencia_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_Licencia_F_Ini.Value.Year);
            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepFotosheck.Tables[2].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//DNI
                    dataGridView2[1,i].Value.ToString(),//USUARIO APELLIDO
                    dataGridView2[1,i].Value.ToString(),//USUARIO NOMBRE
                    dataGridView2[2,i].Value.ToString(),//EMPRESA
                    dataGridView2[3,i].Value.ToString(),//VEHICULO AUTORIZADO
                    FechaInduccion,//FECHA
                    dataGridView2[4,i].Value.ToString() //FECHA VENC RITRAN
                    //(byte[])dataGridView2[36,i].Value //Foto
                        
                    });
            }

            objDsRepFotosheck.Tables[1].Rows.Add
            (new object[]{
                TipoTrabajo
            });

            Frm_sst.CryRepFTLicencia_Contratista objCryRep = new Frm_sst.CryRepFTLicencia_Contratista();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFTLicencia_Contratista.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirFotosheckLicenciaSantaAzul()
        {
            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

            string TipoTrabajo = "CREDENCIAL DE "; //+ comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_Licencia_F_Ini.Value.Date;
            String FechaInduccion = Convert.ToString(dateTimePicker_Licencia_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_Licencia_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_Licencia_F_Ini.Value.Year);
            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepFotosheck.Tables[2].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//DNI
                    dataGridView2[1,i].Value.ToString(),//USUARIO APELLIDO
                    dataGridView2[1,i].Value.ToString(),//USUARIO NOMBRE
                    dataGridView2[2,i].Value.ToString(),//EMPRESA
                    dataGridView2[3,i].Value.ToString(),//VEHICULO AUTORIZADO
                    FechaInduccion,//FECHA
                    dataGridView2[4,i].Value.ToString()
                    //(byte[])dataGridView2[36,i].Value //Foto
                        
                    });
            }

            objDsRepFotosheck.Tables[1].Rows.Add
            (new object[]{
                TipoTrabajo
            });

            Frm_sst.CryRepFTLicencia_SantaAzul objCryRep = new Frm_sst.CryRepFTLicencia_SantaAzul();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFTLicencia_SantaAzul.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirFotosheckLicenciaInterandina()
        {
            Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

            string TipoTrabajo = "CREDENCIAL DE "; //+ comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_Licencia_F_Ini.Value.Date;
            String FechaInduccion = Convert.ToString(dateTimePicker_Licencia_F_Ini.Value.Day.ToString("D2") + "/" +
                dateTimePicker_Licencia_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_Licencia_F_Ini.Value.Year);
            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepFotosheck.Tables[2].Rows.Add
                    (new object[]{
                    dataGridView2[0,i].Value.ToString(),//DNI
                    dataGridView2[1,i].Value.ToString(),//USUARIO APELLIDO
                    dataGridView2[1,i].Value.ToString(),//USUARIO NOMBRE
                    dataGridView2[2,i].Value.ToString(),//EMPRESA
                    dataGridView2[3,i].Value.ToString(),//VEHICULO AUTORIZADO
                    FechaInduccion,//FECHA
                    dataGridView2[4,i].Value.ToString()
                    //(byte[])dataGridView2[36,i].Value //Foto
                        
                    });
            }

            objDsRepFotosheck.Tables[1].Rows.Add
            (new object[]{
                TipoTrabajo
            });

            Frm_sst.CryRepFTLicencia_Interandina objCryRep = new Frm_sst.CryRepFTLicencia_Interandina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFTLicencia_Interandina.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }

        private void toolStripButton_Excel_Licencia_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Licencia_CargarDatos_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_licencia_limpiar_Click(object sender, EventArgs e)
        {
            textRuta_Licencia.Text = "";
            comboBox_Hojas_Licencia.Text = "";
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            ColumnasDtgv2();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                comboBox_Hojas_Licencia.Items.Clear();
                dataGridView1.DataSource = null;

                textRuta.Text = oOpenFileDialog.FileName;

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                //convierte todas las hojas a un DataSet
                dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                comboBox_Hojas.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas.Items.Add(tabla.TableName);
                }
                comboBox_Hojas.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
            dataGridView1.ClearSelection();
            if (dataGridView1.Rows.Count > 1)
            {
                label_cantreg.Text = (dataGridView1.RowCount - 1).ToString();
            }

        }

        private void btnBuscar_Licencia_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                comboBox_Hojas_Licencia.Items.Clear();
                dataGridView2.DataSource = null;

                textRuta_Licencia.Text = oOpenFileDialog.FileName;

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);


                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);
                comboBox_Hojas_Licencia.Items.Clear();
                //convierte todas las hojas a un DataSet
                dtsTablasLicencia = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablasLicencia.Tables)
                {
                    comboBox_Hojas_Licencia.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Licencia.SelectedIndex = 0;

                reader.Close();

            }
        }

        private void toolStripButton_Licencia_CargarDatos_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dtsTablasLicencia.Tables[comboBox_Hojas_Licencia.SelectedIndex];
            dataGridView2.ClearSelection();
            if (dataGridView2.Rows.Count > 1)
            {
                label_cantreg_licencia.Text = (dataGridView2.RowCount - 1).ToString() + " REGISTROS";
            }
        }

        private void panel_licencia_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
