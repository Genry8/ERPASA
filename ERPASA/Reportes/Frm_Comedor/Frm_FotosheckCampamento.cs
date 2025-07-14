
using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Reportes.Frm_Comedor

{
    public partial class Frm_FotosheckCampamento : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();

        cn_datospersonal objcndatpers = new cn_datospersonal();

        public Frm_FotosheckCampamento()
        {
            InitializeComponent();
        }

        private void Frm_FotosheckCampamento_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_tipo_alto_riesgo.SelectedIndex = 0;
            comboBox_empresa_alto_riesgo.SelectedIndex = 0;
            //LICENCIA
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;


            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_tipo_alto_riesgo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa_alto_riesgo.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        private void toolStripButton_imprimirHombreNuevo_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.RowCount > 0)
            {
                ImprimirFotosheckCampamento();
            }
            else
            {
                MessageBox.Show("NO TIENE DATOS PARA IMPRIMIR");
            }
            //if (comboBox_empresa_alto_riesgo.Text == "SELECCIONE")
            //{
            //    MessageBox.Show("PARA IMPRIMIR SELECCIONE EMPRESA", "SELECCIONAR EMPRESA");
            //}
            //if (comboBox_empresa_alto_riesgo.Text == "SANTA AZUL")
            //{
            //    ImprimirFotosheckTrabajoAltoRiesgoSantaAzul();
            //}
            //if (comboBox_empresa_alto_riesgo.Text == "INTERANDINA")
            //{
            //    ImprimirFotosheckTrabajoAltoRiesgoInterandina();
            //}
            //if (comboBox_empresa_alto_riesgo.Text == "TERCEROS")
            //{
            //    ImprimirFotosheckTrabajoAltoRiesgoContratista();
            //}

            dataGridView1.AllowUserToAddRows = true;
        }


        public void ImprimirFotosheckCampamento()
        {
            Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetComedor objDsRepFotosheck = new DataSetComedor();

            string TipoTrabajo = "CREDENCIAL DE " + comboBox_tipo_alto_riesgo.Text.ToUpper();
            DateTime FechaEntrega = dateTimePicker_AltoRiesgo_F_Ini.Value.Date;

            String MesInd = FechaEntrega.ToString("MMMM");
            string resultfecha = MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

            /*
            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
            */

            int filas = dataGridView1.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objcndatpers.BuscaFotoFotosheck(dataGridView1[2, i].Value.ToString().Trim());
                byte[] img = ce_fotofotosheck.foto;
                MemoryStream ms2 = new MemoryStream();
                pictureBox1.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imagen;
                if (img == null)
                {
                    imagen = ms2.ToArray();
                }
                else
                {
                    //MemoryStream ms = new MemoryStream(img);
                    imagen = img;
                    ce_fotofotosheck.foto = null;
                }
                //pictureBox1.Image = Image.FromStream(ms);

                //String FechaIngreso = Convert.ToString(Convert.ToDateTime(dataGridView1[3, i]).Date.ToString());
                //String FechaIngreso = Convert.ToString( Convert.ToDateTime(dataGridView1[3, i]).Year) + "/" +
                //    Convert.ToString( Convert.ToDateTime(dataGridView1[3, i]).Month.ToString("D2") )+ "/" +
                //    Convert.ToString(Convert.ToDateTime(dataGridView1[3, i]).Day.ToString("D2") );

                objDsRepFotosheck.Tables[4].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString().ToUpper(),//BLOQUE
                    dataGridView1[1,i].Value.ToString().ToUpper(),//CARPA
                    dataGridView1[2,i].Value.ToString().ToUpper(),//DNI
                    dataGridView1[3,i].Value.ToString().ToUpper(),//APELLIDOS NOMBRES
                    //FechaIngreso,
                    Convert.ToDateTime(dataGridView1[4,i].Value).Date.ToString(),//FECHA INGRESO
                    dataGridView1[5,i].Value.ToString().ToUpper(),//LUGAR
                    dataGridView1[6,i].Value.ToString().ToUpper(),//PUESTO
                    dataGridView1[7,i].Value.ToString().ToUpper(),//CAMPAMENTO
                    dataGridView1[7,i].Value.ToString().ToUpper(),//EMPRESA
                    dataGridView1[7,i].Value.ToString().ToUpper(),//SEDE
                    dataGridView1[7,i].Value.ToString().ToUpper(),//AREA
                    //resultfecha
                    imagen //Foto
                        
                    });
            }

            //objDsRepFotosheck.Tables[4].Rows.Add
            //(new object[]{
            //    TipoTrabajo
            //});

            Frm_Comedor.CryRepFotosheckCampamento objCryRep = new Frm_Comedor.CryRepFotosheckCampamento();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRepFotosheckCampamento.rpt");
            objCryRep.SetDataSource(objDsRepFotosheck);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        //public void ImprimirFotosheckTrabajoAltoRiesgoSantaAzul()
        //{
        //    Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
        //    AddOwnedForm(objImpresion);
        //    objImpresion.Show();

        //    Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

        //    string TipoTrabajo = "CREDENCIAL DE " + comboBox_tipo_alto_riesgo.Text.ToUpper();
        //    DateTime FechaEntrega = dateTimePicker_AltoRiesgo_F_Ini.Value.Date;
        //    String FechaInduccion = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
        //        dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.Year);
        //    String MesInd = FechaEntrega.ToString("MMMM");
        //    string resultfecha = MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

        //    /*
        //    DataTable dt = new DataTable();
        //    dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
        //    byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
        //    */

        //    int filas = dataGridView1.Rows.Count;
        //    for (int i = 0; i <= filas - 1; i++)
        //    {
        //        objDsRepFotosheck.Tables[0].Rows.Add
        //            (new object[]{
        //            dataGridView1[0,i].Value.ToString(),//DNI
        //            dataGridView1[1,i].Value.ToString(),//USUARIO
        //            FechaInduccion,//FECHA
        //            dataGridView1[0,i].Value.ToString(),//SEMANA
        //            dataGridView1[1,i].Value.ToString(),//NOTA
        //            dataGridView1[2,i].Value.ToString(),//EMPRESA
        //            resultfecha
        //            //(byte[])dataGridView2[36,i].Value //Foto

        //            });
        //    }

        //    objDsRepFotosheck.Tables[1].Rows.Add
        //    (new object[]{
        //        TipoTrabajo
        //    });

        //    Frm_sst.CryRepFTrabajoAltoRiesgo_SantaAzul objCryRep = new Frm_sst.CryRepFTrabajoAltoRiesgo_SantaAzul();
        //    //string dir = @"~\CryRep_VentasUsuario.rpt";
        //    objCryRep.Load(@"~\CryRepFTrabajoAltoRiesgo_SantaAzul.rpt");
        //    objCryRep.SetDataSource(objDsRepFotosheck);
        //    objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        //}


        //public void ImprimirFotosheckTrabajoAltoRiesgoInterandina()
        //{
        //    Reportes.Frm_CrpPanel_imprimir objImpresion = new Reportes.Frm_CrpPanel_imprimir();
        //    AddOwnedForm(objImpresion);
        //    objImpresion.Show();

        //    Frm_sst.DataSetFotoshecks objDsRepFotosheck = new Frm_sst.DataSetFotoshecks();

        //    string TipoTrabajo = "CREDENCIAL DE " + comboBox_tipo_alto_riesgo.Text.ToUpper();
        //    DateTime FechaEntrega = dateTimePicker_AltoRiesgo_F_Ini.Value.Date;
        //    String FechaInduccion = Convert.ToString(dateTimePicker_AltoRiesgo_F_Ini.Value.Day.ToString("D2") + "/" +
        //        dateTimePicker_AltoRiesgo_F_Ini.Value.Month.ToString("D2") + "/" + dateTimePicker_AltoRiesgo_F_Ini.Value.Year);
        //    String MesInd = FechaEntrega.ToString("MMMM");
        //    string resultfecha = MesInd.Substring(0, 3).ToUpper() + " " + FechaEntrega.AddYears(1).Year;

        //    /*
        //    DataTable dt = new DataTable();
        //    dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
        //    byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];
        //    */

        //    int filas = dataGridView1.Rows.Count;
        //    for (int i = 0; i <= filas - 1; i++)
        //    {
        //        objDsRepFotosheck.Tables[0].Rows.Add
        //            (new object[]{
        //            dataGridView1[0,i].Value.ToString(),//DNI
        //            dataGridView1[1,i].Value.ToString(),//USUARIO
        //            FechaInduccion,//FECHA
        //            dataGridView1[0,i].Value.ToString(),//SEMANA
        //            dataGridView1[1,i].Value.ToString(),//NOTA
        //            dataGridView1[2,i].Value.ToString(),//EMPRESA
        //            resultfecha
        //            //(byte[])dataGridView2[36,i].Value //Foto

        //            });
        //    }

        //    objDsRepFotosheck.Tables[1].Rows.Add
        //    (new object[]{
        //        TipoTrabajo
        //    });

        //    Frm_sst.CryRepFTrabajoAltoRiesgo_Interandina objCryRep = new Frm_sst.CryRepFTrabajoAltoRiesgo_Interandina();
        //    //string dir = @"~\CryRep_VentasUsuario.rpt";
        //    objCryRep.Load(@"~\CryRepFTrabajoAltoRiesgo_Interandina.rpt");
        //    objCryRep.SetDataSource(objDsRepFotosheck);
        //    objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        //}


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
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

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }


    }
}
