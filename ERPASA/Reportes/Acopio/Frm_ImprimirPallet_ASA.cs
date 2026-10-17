using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Datamatrix;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_ImprimirPallet_ASA : Form
    {
        string pallet, cabezal, variedad, kilos;

        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();
        cn_sst objcnsst = new cn_sst();
        DataTable dtg = new DataTable();

        string TipoAlimento;

        public Frm_ImprimirPallet_ASA()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ImprimirPallet_ASA_Load(object sender, EventArgs e)
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

        public DataTable BuscarRecepcionAcopio(DateTime fechaIni, DateTime fechaFin,
                                       string emp, string sed, string cult)
        {
            // SOLO carga datos — SIN acceso a controles, SIN INVOKE
            return cn_sst.ListaRecepcionImprimir(fechaIni, fechaFin, emp, sed, cult);
        }

        /*
        public void BuscarRecepcionAcopio()
        {
            string emp, sed, empText = string.Empty, sedText = string.Empty
                , cult, cultText = string.Empty;

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
            if (comboBox_detalle_Cultivo.InvokeRequired)
            {
                comboBox_detalle_Cultivo.Invoke(new MethodInvoker(() =>
                {
                    cultText = comboBox_detalle_Cultivo.Text;
                }));
            }
            else
            {
                cultText = comboBox_detalle_Cultivo.Text;
            }

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

            //dataGridView3.ReadOnly = true;
            dtg = cn_sst.ListaRecepcionImprimir(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed, cult);

            //DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            //estado.HeaderText = "estado";
            //dataGridView2.Columns.Insert(0, estado);



        }
        */

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

        public async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            var frbm = new Msbox.frm_cargando();
            frbm.Show(this);

            try
            {
                // 1. Guardar parámetros antes de async
                string empText = comboBox_detalle_empresa.Text;
                string sedText = comboBox_detalle_sede.Text;
                string cultText = comboBox_detalle_Cultivo.Text;

                string emp = empText == "SELECCIONE" ? "%" : empText;
                string sed = sedText == "SELECCIONE" ? "%" : sedText;
                string cult = cultText == "SELECCIONE" ? "%" : cultText;

                DateTime fechaIni = dateTimePicker_FecInicio.Value.Date;
                DateTime fechaFin = dateTimePicker_FecFin.Value.Date;

                // 2. Ejecutar solo la consulta en ThreadPool
                DataTable resultado = await Task.Run(() =>
                {
                    return BuscarRecepcionAcopio(fechaIni, fechaFin, emp, sed, cult);
                });

                // 3. Actualizar UI
                dataGridView2.SuspendLayout();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                dataGridView2.DataSource = resultado;
                dataGridView2.ClearSelection();

                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.MinimumWidth = 60;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.ReadOnly = true;
                }

                if (dataGridView2.Columns.Count > 0)
                    dataGridView2.Columns[0].ReadOnly = false;

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
                dataGridView2.ResumeLayout();
            }
        }

        /*
        public async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {

                dataGridView2.Invoke(new Action(() =>
                {
                    dataGridView2.SuspendLayout();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }));
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    BuscarRecepcionAcopio();
                    dataGridView2.ClearSelection();
                });
                // 2) Actualizar controles en UI thread
                dataGridView2.Invoke(new Action(() =>
                {
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // 🔓 Hacer todas las columnas editables

                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                    {
                        col.MinimumWidth = 60;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // CENTRAR VALORES
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // CENTRAR CABECERAS                        
                    }
                }));

                //dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtg;
                dataGridView2.AllowUserToAddRows = false;
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataColumn column in dtg.Columns)
                {
                    column.ReadOnly = false; // Deshabilita el solo lectura en todas las columnas
                }
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                }
                // Habilitar la edición solo para la primera columna
                if (dataGridView2.Columns.Count > 0)
                {
                    dataGridView2.Columns[0].ReadOnly = false; // Permitir la edición solo de la primera columna
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
        */

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

            // Reutilizar writer (MUY IMPORTANTE)
            var barcodeWriter = new ZXing.BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 120,
                    Width = 120,
                    Margin = 0
                }
            };

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    continue;

                // Cachear valores (evita miles de accesos lentos)
                string sede = row.Cells[8].Value?.ToString();
                string presentacionOriginal = row.Cells[13].Value?.ToString();
                string presentacionCampo = row.Cells[14].Value?.ToString();
                string idRec = row.Cells[9].Value?.ToString();
                string pallet = row.Cells[2].Value?.ToString();
                string fecha = row.Cells[6].Value?.ToString();
                string destino = row.Cells[15].Value?.ToString();
                string idcabezal = row.Cells[16].Value?.ToString();

                string inicial = "";
                string empresa;
                switch (sede)
                {
                    case "Fundo Santa Azul":
                        inicial = "A";
                        empresa = "ASA";
                        break;

                    case "Fundo San Telmo":
                        inicial = "S";
                        empresa = "IA ST";
                        break;

                    case "Fundo Huacache":
                        inicial = "H";
                        empresa = "IA HC";
                        break;

                    case "Fundo El Alto":
                        inicial = "A";
                        empresa = "IA ALTO";
                        break;

                    case "Fundo Los Gallos":
                        inicial = "G";
                        empresa = "IA GALLOS";
                        break;

                    case "Fundo Nonaka":
                        inicial = "N";
                        empresa = "IA NONAKA";
                        break;

                    case "Fundo Playa Baja":
                        inicial = "PB";
                        empresa = "IA PlayaBaja";
                        break;

                    case "FAMILY FARMS":
                        inicial = "FF";
                        empresa = "FF";
                        break;

                    default:
                        inicial = "T";
                        empresa = "TERCERO";
                        break;
                }


                string presentacion = (presentacionOriginal == "EMPAQUE CAMPO")
                                        ? presentacionCampo
                                        : presentacionOriginal;

                // Generar DataMatrix (rápido porque se reutiliza el writer)
                byte[] dm = GenerarDataMatrixRapida(barcodeWriter, idRec);

                objDsRepAcopio.Tables[1].Rows.Add(
                    inicial + "-" + pallet?.ToUpper(),
                    row.Cells[3].Value?.ToString().ToUpper(),
                    row.Cells[4].Value?.ToString().ToUpper(),
                    row.Cells[5].Value,
                    fecha,
                    empresa,
                    idRec,
                    row.Cells[12].Value,
                    presentacion,
                    destino,
                    dm,
                    idcabezal
                );


                //    objcnsst.ActualizarRecepcionImprimir(row.Cells[2].Value.ToString()
                //, row.Cells[6].Value.ToString());

                // ⚠ RECOMENDADO: sacar fuera del bucle
                objcnsst.ActualizarRecepcionImprimir(pallet, fecha);
            }

            // Cargar reporte (ideal: precargar fuera de esta función)
            var objCryRep = new Acopio.CrystalReportPalletPrint();
            objCryRep.Load(@"~\CrystalReportPalletPrint.rpt");
            objCryRep.SetDataSource(objDsRepAcopio);

            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }

        public byte[] GenerarDataMatrixRapida(BarcodeWriter writer, string texto)
        {
            using (Bitmap img = writer.Write(texto))
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /*
        public void ImprimirReporteDetalleAtencionASA()
        {
            Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetAcopio objDsRepAcopio = new DataSetAcopio();
            string empresa, inicial = "", presentacion;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (row.Cells[8].Value.ToString() == "Fundo Santa Azul")
                    {
                        empresa = "ASA";
                        inicial = "A";
                    }
                    else if (row.Cells[8].Value.ToString() == "Fundo San Telmo")
                    {
                        empresa = "IA ST";
                        inicial = "S";
                    }
                    else if (row.Cells[8].Value.ToString() == "Fundo Huacache")
                    {
                        empresa = "IA HC";
                        inicial = "H";
                    }
                    else if (row.Cells[8].Value.ToString() == "Fundo Los Gallos")
                    {
                        empresa = "F. GALLOS";
                        inicial = "G";
                    }
                    else
                    {
                        empresa = "TERCERO";
                    }
                    if (row.Cells[13].Value.ToString() == "EMPAQUE CAMPO")
                    {
                        presentacion = row.Cells[14].Value.ToString();
                    }
                    else
                    {
                        presentacion = row.Cells[13].Value.ToString();
                    }

                    objDsRepAcopio.Tables[1].Rows.Add
                            (new object[]{
                        inicial+"-"+row.Cells[2].Value.ToString().ToUpper(), //PALLET
                        row.Cells[3].Value.ToString().ToUpper(), //CABEZAL
                        row.Cells[4].Value.ToString().ToUpper(), //VARIEDAD
                        row.Cells[5].Value.ToString(), //KILOS
                        row.Cells[6].Value.ToString(), //FECHA
                        empresa, //EMPRESA/sede -- CABECERA
                        row.Cells[9].Value.ToString(), //ID_REC
                        row.Cells[12].Value.ToString(), //JABAS
                        row.Cells[13].Value.ToString(), //PRESENTACION
                        row.Cells[15].Value.ToString(), //DESTINO
                        GenerarDataMatrix(row.Cells[9].Value.ToString())
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

        public byte[] GenerarDataMatrix(string texto)
        {
            var writer = new DataMatrixWriter();

            var matrix = writer.encode(texto,
                                       BarcodeFormat.DATA_MATRIX,
                                       0, 0);

            var barcodeWriter = new ZXing.BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 120,
                    Width = 120,
                    Margin = 0
                }
            };

            using (Bitmap img = barcodeWriter.Write(texto))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
        */

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
