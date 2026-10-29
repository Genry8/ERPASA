using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Contabilidad;
using ERPASA.Msbox;
using ERPASA.Reportes;
using ERPASA.Reportes.Frm_sst;
using ERPASA.Reportes.Frm_sst.Cursos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ERPASA.Frm_Logistica
{
    public partial class Frm_ReporteRegistroAsistencia : Form
    {

        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        cd_logistica objlogistica = new cd_logistica();

        string TipoAlimento, emp = string.Empty;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        BaseColor verdeOscuro = new BaseColor(0, 100, 0); // Dark Green
        BaseColor verdeBosque = new BaseColor(34, 139, 34); // 
        BaseColor verdeOscElegante = new BaseColor(0, 128, 0); // 
        BaseColor verdeCoorpOscuro = new BaseColor(0, 102, 51); // 
        BaseColor verdeMuyOscuro = new BaseColor(0, 80, 0); // 
        BaseColor verdeFluorescente = new BaseColor(0, 102, 51); // 
        public Frm_ReporteRegistroAsistencia()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ReporteRegistroAsistencia_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.SelectedIndex = 0;

            //poner osucro

            //CargaDatos();

            Cargar_Empresa();
            PonerOscuroComboBox();
            CargaDatos();
        }

        public void CargaDatos()
        {
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.DataSource = null;
            dateTimePicker_Fecha_Ini.Value = DateTime.Now.AddDays(-30);
            dateTimePicker_Fecha_Fin.Value = DateTime.Now;
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox_Curso.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            guna2ComboBox_Curso.DataSource = objlogistica.ListaCursosSST();
            guna2ComboBox_Curso.DisplayMember = "Curso"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            guna2ComboBox_Curso.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    BuscarReporte();
                    guna2DataGridView1.ClearSelection();
                });

                guna2DataGridView1.Columns.Clear();
                guna2DataGridView1.DataSource = dtg;
                //guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                guna2DataGridView1.AllowUserToAddRows = false;


                // AGREGAR DESCARGAR
                AgregarBotonDescarga();

                //CONTAR LA CANTIDAD DE REGISTROS
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    label_cantreg.Text = (guna2DataGridView1.RowCount).ToString() + " REGISTROS";

                    //Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(3, 151, 43), 2);
                    //ng.Show();
                }
                else
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", System.Drawing.Color.FromArgb(238, 24, 24), 3);
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


        private void AgregarBotonDescarga()
        {
            if (guna2DataGridView1.Columns["btnDescarga"] != null)
                return;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "btnDescarga";
            img.HeaderText = "Descagar Examen";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            // PNG desde recursos o archivo
            img.Image = Properties.Resources.descargar;

            guna2DataGridView1.Columns.Add(img);
        }

        public void BuscarReporte()
        {
            string empText = string.Empty, emp;
            string trabText = string.Empty, trab;
            string cursoText = string.Empty, curso;

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

            if (comboBox_TipoTrabajador.InvokeRequired)
            {
                comboBox_TipoTrabajador.Invoke(new MethodInvoker(() =>
                {
                    trabText = comboBox_TipoTrabajador.Text;
                }));
            }
            else
            {
                trabText = comboBox_TipoTrabajador.Text;
            }
            ////////////////////
            if (trabText == "SELECCIONE")
            {
                trab = "%";
            }
            else
            {
                trab = trabText;
            }

            if (guna2ComboBox_Curso.InvokeRequired)
            {
                guna2ComboBox_Curso.Invoke(new MethodInvoker(() =>
                {
                    cursoText = guna2ComboBox_Curso.Text;
                }));
            }
            else
            {
                cursoText = guna2ComboBox_Curso.Text;
            }
            ////////////////////
            if (cursoText == "SELECCIONE")
            {
                curso = "%";
            }
            else
            {
                curso = cursoText;
            }

            dtg = cn_sst.BuscarReporteCursosSST(
            dateTimePicker_Fecha_Ini.Value.Date, dateTimePicker_Fecha_Fin.Value.Date
            , emp, trab, curso, 1);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox_marc.Focus();
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToAddRows = true;
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
                        objexcel_progress.exportarexcelTimer(guna2DataGridView1, frbm, token);
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

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            string empText = string.Empty, sedText = string.Empty;
            //string areaText = string.Empty, tipoText = string.Empty;

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

            //MessageBox.Show("" + ce_equipoti.DniInspectorHoja);
            try
            {
                if (guna2DataGridView1.RowCount > 0)
                {
                    if (empText == "SELECCIONE")
                    {
                        MessageBox.Show("SELECCIONE EMPRESA Y HAGA CLICK EN BUSCAR", "EMPRESA");
                    }

                    else if (empText == "AGRICOLA SANTA AZUL S.R.L")
                    {
                        cn_equipoti.BuscPaginaParaHoja(31, dateTimePicker_Fecha_Fin.Value.Date);
                        //cn_equipoti.BuscTemaCurso(1, guna2ComboBox_Curso.Text.Trim());
                        ImprimirReporteASA();
                    }
                    else if (empText == "AGRICOLA INTERANDINA S.A.C")
                    {
                        cn_equipoti.BuscPaginaParaHoja(32, dateTimePicker_Fecha_Fin.Value.Date);
                        //cn_equipoti.BuscTemaCurso(1, guna2ComboBox_Curso.Text.Trim());
                        ImprimirReporteIA();
                    }
                }
                else
                {
                    MessageBox.Show("NO HAY REPORTES REGISTRADOS", "ALERTA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async void ImprimirReporteASA()
        {
            var api = new cn_apiservices();

            Frm_CrpVetaUsuario objImpresion = new Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSet_Cursos objDs = new DataSet_Cursos();

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
            string responsable = ce_usuario.usenam;
            string cargo = ce_usuario.grudes;

            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = null;

            if (dt.Rows.Count > 0 && dt.Rows[0]["Foto"] != DBNull.Value)
            {
                FirmaH = (byte[])dt.Rows[0]["Foto"];
            }

            objDs.Tables[2].Rows.Add
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
                FirmaH,
                responsable,
                cargo
            });
            //DATOS DEL CURSO
            ce_sst_cursos curso = cn_equipoti.BuscTemaCurso(
                1,
                guna2ComboBox_Curso.Text.Trim()
            );

            if (curso != null)
            {
                //MessageBox.Show(
                //    "Id: " + curso.Id + Environment.NewLine +
                //    "Curso: " + curso.Curso + Environment.NewLine +
                //    "Descripcion: " + curso.Descripcion + Environment.NewLine +
                //    "Obs: " + curso.Obs + Environment.NewLine +
                //    "Estado: " + curso.Estado + Environment.NewLine +
                //    "Tema: " + curso.Tema + Environment.NewLine +
                //    "Contenido: " + curso.Contenido + Environment.NewLine +
                //    "TemaIA: " + curso.TemaIA + Environment.NewLine +
                //    "ContenidoIA: " + curso.ContenidoIA,
                //    "Datos del Curso"
                //);

                objDs.Tables[0].Rows.Add(
                    new object[]
                    {
            curso.Id,
            curso.Curso,
            curso.Descripcion,
            curso.Obs,
            curso.Estado,
            curso.Tema,
            curso.Contenido,
            curso.TemaIA,
            curso.ContenidoIA,
            guna2DataGridView1.Rows.Count,
            dateTimePicker_Fecha_Ini.Value.Date.ToString("yyyy-MM-dd"),
            dateTimePicker_Fecha_Fin.Value.Date.ToString("yyyy-MM-dd"),
                    }
                );
            }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow) // evita la última fila vacía
                {
                    // 1. Recuperar el nombre de archivo desde la columna 8
                    string intentoFileName = Path.GetFileName(row.Cells[5].Value?.ToString());

                    byte[] imagenBytes = null;

                    // 2. Llamar a tu API para traer la imagen
                    if (!string.IsNullOrEmpty(intentoFileName))
                    {
                        imagenBytes = await api.ObtenerFirmaBytesAsync(intentoFileName);
                        Console.WriteLine(
                        imagenBytes == null
                            ? "Imagen NULL"
                            : $"Imagen OK: {imagenBytes.Length} bytes");

                    }

                    objDs.Tables[1].Rows.Add(new object[]
                    {
                            row.Cells[0].Value, //num
                            row.Cells[1].Value, //apenom
                            row.Cells[2].Value,//empresa
                            row.Cells[3].Value, // puesto trabajo
                            row.Cells[4].Value,// dni
                            imagenBytes,//AQUI VA FIRMA
                            //row.Cells[5].Value,//firma
                            row.Cells[6].Value, //nota
                            Convert.ToDateTime(row.Cells[10].Value).ToString("yyyy-MM-dd") //FECHA PROGRAMADO
                    });
                }
            }


            var objCryRep = new CryRepReporteAsistenciaCursos();
            objCryRep.Load(@"~\CryRepReporteAsistenciaCursos.rpt");
            objCryRep.SetDataSource(objDs);

            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }

        public async void ImprimirReporteIA()
        {
            var api = new cn_apiservices();

            Frm_CrpVetaUsuario objImpresion = new Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSet_Cursos objDs = new DataSet_Cursos();

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
            string responsable = ce_usuario.usenam;
            string cargo = ce_usuario.grudes;

            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = null;

            if (dt.Rows.Count > 0 && dt.Rows[0]["Foto"] != DBNull.Value)
            {
                FirmaH = (byte[])dt.Rows[0]["Foto"];
            }

            objDs.Tables[2].Rows.Add
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
                FirmaH,
                responsable,
                cargo
            });
            //DATOS DEL CURSO
            ce_sst_cursos curso = cn_equipoti.BuscTemaCurso(
                1,
                guna2ComboBox_Curso.Text.Trim()
            );

            if (curso != null)
            {
                //MessageBox.Show(
                //    "Id: " + curso.Id + Environment.NewLine +
                //    "Curso: " + curso.Curso + Environment.NewLine +
                //    "Descripcion: " + curso.Descripcion + Environment.NewLine +
                //    "Obs: " + curso.Obs + Environment.NewLine +
                //    "Estado: " + curso.Estado + Environment.NewLine +
                //    "Tema: " + curso.Tema + Environment.NewLine +
                //    "Contenido: " + curso.Contenido + Environment.NewLine +
                //    "TemaIA: " + curso.TemaIA + Environment.NewLine +
                //    "ContenidoIA: " + curso.ContenidoIA,
                //    "Datos del Curso"
                //);

                objDs.Tables[0].Rows.Add(
                    new object[]
                    {
            curso.Id,
            curso.Curso,
            curso.Descripcion,
            curso.Obs,
            curso.Estado,
            curso.Tema,
            curso.Contenido,
            curso.TemaIA,
            curso.ContenidoIA,
            guna2DataGridView1.Rows.Count,
            dateTimePicker_Fecha_Ini.Value.Date.ToString("yyyy-MM-dd"),
            dateTimePicker_Fecha_Fin.Value.Date.ToString("yyyy-MM-dd"),
                    }
                );
            }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow) // evita la última fila vacía
                {
                    // 1. Recuperar el nombre de archivo desde la columna 8
                    string intentoFileName = Path.GetFileName(row.Cells[5].Value?.ToString());

                    byte[] imagenBytes = null;

                    // 2. Llamar a tu API para traer la imagen
                    if (!string.IsNullOrEmpty(intentoFileName))
                    {
                        imagenBytes = await api.ObtenerFirmaBytesAsync(intentoFileName);
                        Console.WriteLine(
                        imagenBytes == null
                            ? "Imagen NULL"
                            : $"Imagen OK: {imagenBytes.Length} bytes");

                    }

                    objDs.Tables[1].Rows.Add(new object[]
                    {
                            row.Cells[0].Value, //num
                            row.Cells[1].Value, //apenom
                            row.Cells[2].Value,//empresa
                            row.Cells[3].Value, // puesto trabajo
                            row.Cells[4].Value,// dni
                            imagenBytes,//AQUI VA FIRMA
                            //row.Cells[5].Value,//firma
                            row.Cells[6].Value //nota
                    });
                }
            }


            var objCryRep = new CryRepReporteAsistenciaCursosIA();
            objCryRep.Load(@"~\CryRepReporteAsistenciaCursosIA.rpt");
            objCryRep.SetDataSource(objDs);

            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("IdCurso " + guna2ComboBox_Curso.SelectedIndex + "\n" +
            //    "IdCurso " + guna2ComboBox_Curso.SelectedValue + "\n"+
            //    "curso " + guna2ComboBox_Curso.Text +" H"+ "\n");
        }

        private async void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "btnDescarga")
            {

                string empText = string.Empty, sedText = string.Empty;
                //string areaText = string.Empty, tipoText = string.Empty;

                ////////////////////////////////////
                if (comboBox_empresa.InvokeRequired)
                {
                    comboBox_empresa.Invoke(new MethodInvoker(() =>
                    {
                        empText = comboBox_empresa.Text;
                        emp = comboBox_empresa.Text;
                    }));
                }
                else
                {
                    empText = comboBox_empresa.Text;
                    emp = comboBox_empresa.Text;
                }


                if (empText == "SELECCIONE")
                {
                    MessageBox.Show("SELECCIONE EMPRESA");
                    return;
                }

                int id = Convert.ToInt32(
                    guna2DataGridView1.Rows[e.RowIndex]
                    .Cells["Id"]
                    .Value
                    .ToString());

                string rutafirma =
                    guna2DataGridView1.Rows[e.RowIndex]
                    .Cells["Firma"]
                    .Value
                    .ToString();


                if (empText == "AGRICOLA SANTA AZUL S.R.L")
                {
                    emp = "ASA";
                }
                else
                {
                    emp = "IA";
                }

                if (empText == "AGRICOLA SANTA AZUL S.R.L")
                {
                    cn_equipoti.BuscPaginaParaHoja(34, dateTimePicker_Fecha_Fin.Value.Date);
                    //cn_equipoti.BuscTemaCurso(1, guna2ComboBox_Curso.Text.Trim());
                    GenerarPDF(id, rutafirma);
                }
                else if (empText == "AGRICOLA INTERANDINA S.A.C")
                {
                    cn_equipoti.BuscPaginaParaHoja(33, dateTimePicker_Fecha_Fin.Value.Date);
                    //cn_equipoti.BuscTemaCurso(1, guna2ComboBox_Curso.Text.Trim());
                    GenerarPDF_IA(id, rutafirma);
                }

            }
        }

        private async Task GenerarPDF(int idCapacitado, string rutafirma)
        {
            var api = new cn_apiservices();
            cn_sst obj = new cn_sst();

            DataSet ds = obj.ObtenerExamenPDF(idCapacitado);

            if (ds == null || ds.Tables.Count < 2)
            {
                MessageBox.Show("Error al obtener datos");
                return;
            }

            DataTable cab = ds.Tables[0];
            DataTable det = ds.Tables[1];

            if (cab.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de cabecera");
                return;
            }
            DataRow rw = cab.Rows[0];

            string nombreArchivo =
                $"{rw["Dni"]}_{emp}_{rw["ApeNom"]}_{rw["Curso"]}_{Convert.ToDateTime(rw["FechaCapacitacion"]):yyyyMMdd}.pdf";

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "PDF|*.pdf";
            sd.FileName = nombreArchivo;

            if (sd.ShowDialog() != DialogResult.OK)
                return;

            iTextSharp.text.Document doc =
                new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sd.FileName, FileMode.Create));

            //PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(rutaCompleta, FileMode.Create));

            doc.Open();

            // =========================
            // HEADER MEJORADO (CORREGIDO)
            // =========================

            PdfPTable head = new PdfPTable(3);
            head.WidthPercentage = 105;
            head.SetWidths(new float[] { 20f, 55f, 25f });

            // =========================
            // LOGO
            // =========================
            Bitmap bmp = Properties.Resources.logo_asa;

            byte[] imgBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imgBytes = ms.ToArray();
            }

            iTextSharp.text.Image logo =
                iTextSharp.text.Image.GetInstance(imgBytes);

            logo.ScaleToFit(60f, 60f);

            PdfPCell c1 = new PdfPCell(logo);
            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
            c1.Padding = 5;

            // =========================
            // CENTRO
            // =========================
            iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
            iTextSharp.text.Font fontSub = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPCell c2 = new PdfPCell();
            //c2.AddElement(new Phrase(ce_equipoti.NombreHoja, fontTitulo));
            //c2.AddElement(new Phrase(ce_equipoti.TipoHoja, fontSub));


            Paragraph pTitulo = new Paragraph(ce_equipoti.NombreHoja, fontTitulo);

            pTitulo.Alignment = Element.ALIGN_LEFT;
            pTitulo.SpacingAfter = 8f;

            Paragraph pSubTitulo = new Paragraph(ce_equipoti.TipoHoja, fontSub);

            pSubTitulo.Alignment = Element.ALIGN_LEFT;

            c2.AddElement(pTitulo);
            c2.AddElement(pSubTitulo);


            c2.HorizontalAlignment = Element.ALIGN_CENTER;
            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
            c2.Padding = 5;

            // =========================
            // DERECHA (TABLA)
            // =========================
            iTextSharp.text.Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable datos = new PdfPTable(2);
            datos.WidthPercentage = 100;

            datos.AddCell(new PdfPCell(new Phrase("Código", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.CodigoHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Versión", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.VersionHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Fecha", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.FechaHoja.ToString("dd/MM/yyyy"), fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Página", fontData)));
            datos.AddCell(new PdfPCell(new Phrase("1 de 1", fontData)));

            PdfPCell c3 = new PdfPCell(datos);
            c3.Padding = 1;

            // =========================
            // ARMADO FINAL
            // =========================
            head.AddCell(c1);
            head.AddCell(c2);
            head.AddCell(c3);

            doc.Add(head);


            // =========================
            // TITULO DE LOS NOMBRES
            // =========================

            DataRow rt = cab.Rows[0];

            iTextSharp.text.Font fontExamen =
            FontFactory.GetFont(
            FontFactory.HELVETICA_BOLD,
            14);

            Paragraph titulo =
                new Paragraph(
                    "EXAMEN ESCRITO: " + rt["Curso"].ToString(),
            fontExamen);

            titulo.Alignment =
                Element.ALIGN_CENTER;

            titulo.SpacingBefore = 5f;
            titulo.SpacingAfter = 10f;

            doc.Add(titulo);
            // =========================
            // CABECERA DATOS (FORMATO EXAMEN)
            // =========================
            DataRow r = cab.Rows[0];

            iTextSharp.text.Font fontLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            iTextSharp.text.Font fontValue = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPTable tablaInfo = new PdfPTable(2);
            tablaInfo.WidthPercentage = 100;
            tablaInfo.SetWidths(new float[] { 30f, 70f });

            // helper local
            void AddInfo(string label, string value)
            {
                PdfPCell cLabel = new PdfPCell(new Phrase(label, fontLabel));
                cLabel.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cLabel.PaddingBottom = 4;

                PdfPCell cValue = new PdfPCell(new Phrase(value, fontValue));
                cValue.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cValue.PaddingBottom = 4;

                tablaInfo.AddCell(cLabel);
                tablaInfo.AddCell(cValue);
            }

            AddInfo("APELLIDOS Y NOMBRES:", r["ApeNom"].ToString());
            AddInfo("PUESTO DE TRABAJO:", r["Cargo"].ToString());
            AddInfo("EMPRESA:", r["RazonSocial"].ToString());
            AddInfo("FECHA:", Convert.ToDateTime(r["FechaCapacitacion"]).ToString("dd/MM/yyyy"));
            AddInfo("DNI:", r["Dni"].ToString());
            //AddInfo("NOTA:", r["NotaCurso"].ToString());

            doc.Add(tablaInfo);

            PdfContentByte cb = writer.DirectContent;

            // Título NOTA
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase("NOTA", fontLabel),
                535,
                700,
                0);

            // círculo
            cb.Circle(535, 665, 28);
            cb.Stroke();

            // nota dentro
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase(
                    r["NotaCurso"].ToString(),
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        16)),
                535,
                660,
                0);


            // Instrucción del examen
            iTextSharp.text.Font fontInstruccion =
                FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD,
                    9);

            Paragraph instruccion = new Paragraph(
                "Marque las respuestas que Ud. crea que son correctas",
                fontInstruccion);

            instruccion.SpacingBefore = 0f;
            instruccion.SpacingAfter = 3f;

            doc.Add(instruccion);

            // =========================
            // PREGUNTAS (FORMATO 2 COLUMNAS COMO EXAMEN)
            // =========================

            iTextSharp.text.Font fontPregunta = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            iTextSharp.text.Font fontAlt = FontFactory.GetFont(FontFactory.HELVETICA, 7);

            // 2 columnas como tu examen
            PdfPTable tablaPreguntas = new PdfPTable(2);
            tablaPreguntas.WidthPercentage = 100;
            tablaPreguntas.SetWidths(new float[] { 50f, 50f });

            int contador = 1;

            var preguntas = det.AsEnumerable()
                .GroupBy(x => x["Pregunta"]);
            //MessageBox.Show($"Preguntas agrupadas: {preguntas.Count()}");

            foreach (var pregunta in preguntas)
            {
                //Debug.WriteLine(pregunta.Key);

                string texto = pregunta.Key.ToString();

                // contenedor de pregunta completa (columna izquierda o derecha)
                PdfPCell cellPregunta = new PdfPCell();
                cellPregunta.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellPregunta.PaddingBottom = 3f;
                cellPregunta.PaddingTop = 0f;
                cellPregunta.PaddingLeft = 2f;
                cellPregunta.PaddingRight = 2f;

                //Paragraph pPregunta = new Paragraph(contador + ". " + texto, fontPregunta);
                int puntos = Convert.ToInt32(pregunta.First()["Puntos"]);

                Paragraph pPregunta = new Paragraph(
                    $"{contador}. {texto} ({puntos} pts.)",
                    fontPregunta);

                pPregunta.SpacingBefore = 0;
                pPregunta.SpacingAfter = 2;
                cellPregunta.AddElement(pPregunta);

                char letra = 'A';

                foreach (var alt in pregunta)
                {
                    string alternativa = alt["Alternativa"].ToString();
                    bool marcada = Convert.ToInt32(alt["Marcada"]) == 1;
                    string estado = alt["Esado"].ToString();

                    string marca = marcada ? "X " : "  ";

                    Phrase ph = new Phrase();

                    ph.Add(new Chunk($"{marca}{letra}) {alternativa} ", fontAlt));

                    if (marcada)
                    {
                        iTextSharp.text.Font estadoFont = FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            8,
                            estado.Trim().Equals("Correcto", StringComparison.OrdinalIgnoreCase)
                                ? verdeOscuro
                                : BaseColor.RED);

                        ph.Add(new Chunk($"({estado})", estadoFont));
                    }

                    Paragraph pAlt = new Paragraph(ph);
                    pAlt.Leading = 11f; // altura entre líneas

                    cellPregunta.AddElement(pAlt);

                    letra++;
                }

                tablaPreguntas.AddCell(cellPregunta);

                contador++;
            }

            // completar celda vacía si impar
            if (preguntas.Count() % 2 != 0)
            {
                PdfPCell empty = new PdfPCell(new Phrase(" "));
                empty.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tablaPreguntas.AddCell(empty);
            }

            doc.Add(tablaPreguntas);

            // =========================
            // FIRMAS
            // =========================

            byte[] firmaBytes = null;

            string intentoFileName = Path.GetFileName(rutafirma);

            if (!string.IsNullOrEmpty(intentoFileName))
            {
                firmaBytes = await api.ObtenerFirmaBytesAsync(intentoFileName);
            }

            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;
            tablaFirmas.SpacingBefore = 30f;
            tablaFirmas.SetWidths(new float[] { 50f, 50f });

            // =========================
            // FIRMA TRABAJADOR
            // =========================
            PdfPCell firmaTrabajador = new PdfPCell();
            firmaTrabajador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaTrabajador.HorizontalAlignment = Element.ALIGN_CENTER;

            if (firmaBytes != null)
            {
                iTextSharp.text.Image imgFirma =
                    iTextSharp.text.Image.GetInstance(firmaBytes);

                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaTrabajador.AddElement(imgFirma);
            }
            else
            {
                firmaTrabajador.AddElement(new Paragraph("\n\n\n"));
            }

            firmaTrabajador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            firmaTrabajador.AddElement(
                new Paragraph(
                    "FIRMA DEL TRABAJADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });


            // =========================
            // OBTENER FIRMA CAPACITADOR
            // =========================
            //Console.WriteLine("dni "+ ce_usuario.usedoc);
            //Console.WriteLine("cod " + ce_usuario.usecod);
            DataTable dt = objcuserneg.FotoUserFirma(Convert.ToString(ce_usuario.usedoc));
            byte[] FirmaIn = null;

            if (dt.Rows.Count > 0 && dt.Rows[0]["Foto"] != DBNull.Value)
            {
                FirmaIn = (byte[])dt.Rows[0]["Foto"];
            }

            // =========================
            // FIRMA CAPACITADOR
            // =========================
            PdfPCell firmaCapacitador = new PdfPCell();
            firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            // Agregar imagen de la firma si existe
            if (FirmaIn != null && FirmaIn.Length > 0)
            {
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(FirmaIn);
                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaCapacitador.AddElement(imgFirma);
            }
            else
            {
                // Dejar espacio si no hay firma
                firmaCapacitador.AddElement(new Paragraph("\n\n\n"));
            }

            // Línea de firma
            firmaCapacitador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            // Texto
            firmaCapacitador.AddElement(
                new Paragraph(
                    "FIRMA CAPACITADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            tablaFirmas.AddCell(firmaTrabajador);
            tablaFirmas.AddCell(firmaCapacitador);

            doc.Add(tablaFirmas);

            //// =========================
            //// FIRMA CAPACITADOR
            //// =========================
            //PdfPCell firmaCapacitador = new PdfPCell();
            //firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            //// espacio para firma manual
            //firmaCapacitador.AddElement(new Paragraph("\n\n\n"));

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "__________________________",
            //        fontValue)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "FIRMA CAPACITADOR",
            //        fontLabel)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //tablaFirmas.AddCell(firmaTrabajador);
            //tablaFirmas.AddCell(firmaCapacitador);

            //doc.Add(tablaFirmas);


            // =========================
            // DATOS EMPRESA
            // =========================

            //doc.Add(new Paragraph("\n"));

            iTextSharp.text.Font fontEmp =
                FontFactory.GetFont(
                    FontFactory.HELVETICA,
                    7);

            doc.Add(new Paragraph("Empresa y/o contratista: " +
                ce_equipoti.EmpresaHoja,
                fontEmp));

            doc.Add(new Paragraph("RUC: " +
                ce_equipoti.RucHoja,
                fontEmp));

            doc.Add(new Paragraph("DIRECCIÓN: " +
                ce_equipoti.DireccionHoja,
                fontEmp));

            doc.Close();

            MessageBox.Show("PDF generado correctamente");
        }

        private async Task GenerarPDF_IA(int idCapacitado, string rutafirma)
        {
            var api = new cn_apiservices();
            cn_sst obj = new cn_sst();

            DataSet ds = obj.ObtenerExamenPDF(idCapacitado);

            if (ds == null || ds.Tables.Count < 2)
            {
                MessageBox.Show("Error al obtener datos");
                return;
            }

            DataTable cab = ds.Tables[0];
            DataTable det = ds.Tables[1];

            if (cab.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de cabecera");
                return;
            }
            DataRow rw = cab.Rows[0];

            string nombreArchivo =
                $"{rw["Dni"]}_{emp}_{rw["ApeNom"]}_{rw["Curso"]}_{Convert.ToDateTime(rw["FechaCapacitacion"]):yyyyMMdd}.pdf";

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "PDF|*.pdf";
            sd.FileName = nombreArchivo;

            if (sd.ShowDialog() != DialogResult.OK)
                return;

            iTextSharp.text.Document doc =
                new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sd.FileName, FileMode.Create));

            doc.Open();

            // =========================
            // HEADER MEJORADO (CORREGIDO)
            // =========================

            PdfPTable head = new PdfPTable(3);
            head.WidthPercentage = 105;
            head.SetWidths(new float[] { 20f, 55f, 25f });

            // =========================
            // LOGO
            // =========================
            Bitmap bmp = Properties.Resources.logo_ia;

            byte[] imgBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imgBytes = ms.ToArray();
            }

            iTextSharp.text.Image logo =
                iTextSharp.text.Image.GetInstance(imgBytes);

            logo.ScaleToFit(60f, 60f);

            PdfPCell c1 = new PdfPCell(logo);
            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
            c1.Padding = 5;

            // =========================
            // CENTRO
            // =========================
            iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
            iTextSharp.text.Font fontSub = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPCell c2 = new PdfPCell();
            //c2.AddElement(new Phrase(ce_equipoti.NombreHoja, fontTitulo));
            //c2.AddElement(new Phrase(ce_equipoti.TipoHoja, fontSub));


            Paragraph pTitulo = new Paragraph(ce_equipoti.NombreHoja, fontTitulo);

            pTitulo.Alignment = Element.ALIGN_LEFT;
            pTitulo.SpacingAfter = 8f;

            Paragraph pSubTitulo = new Paragraph(ce_equipoti.TipoHoja, fontSub);

            pSubTitulo.Alignment = Element.ALIGN_LEFT;

            c2.AddElement(pTitulo);
            c2.AddElement(pSubTitulo);


            c2.HorizontalAlignment = Element.ALIGN_CENTER;
            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
            c2.Padding = 5;

            // =========================
            // DERECHA (TABLA)
            // =========================
            iTextSharp.text.Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable datos = new PdfPTable(2);
            datos.WidthPercentage = 100;

            datos.AddCell(new PdfPCell(new Phrase("Código", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.CodigoHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Versión", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.VersionHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Fecha", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.FechaHoja.ToString("dd/MM/yyyy"), fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Página", fontData)));
            datos.AddCell(new PdfPCell(new Phrase("1 de 1", fontData)));

            PdfPCell c3 = new PdfPCell(datos);
            c3.Padding = 1;

            // =========================
            // ARMADO FINAL
            // =========================
            head.AddCell(c1);
            head.AddCell(c2);
            head.AddCell(c3);

            doc.Add(head);


            // =========================
            // TITULO DE LOS NOMBRES
            // =========================

            DataRow rt = cab.Rows[0];

            iTextSharp.text.Font fontExamen =
            FontFactory.GetFont(
            FontFactory.HELVETICA_BOLD,
            14);

            Paragraph titulo =
                new Paragraph(
                    "EXAMEN ESCRITO: " + rt["Curso"].ToString(),
                    fontExamen);

            titulo.Alignment =
                Element.ALIGN_CENTER;

            titulo.SpacingBefore = 5f;
            titulo.SpacingAfter = 10f;

            doc.Add(titulo);
            // =========================
            // CABECERA DATOS (FORMATO EXAMEN)
            // =========================
            DataRow r = cab.Rows[0];

            iTextSharp.text.Font fontLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            iTextSharp.text.Font fontValue = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPTable tablaInfo = new PdfPTable(2);
            tablaInfo.WidthPercentage = 100;
            tablaInfo.SetWidths(new float[] { 30f, 70f });

            // helper local
            void AddInfo(string label, string value)
            {
                PdfPCell cLabel = new PdfPCell(new Phrase(label, fontLabel));
                cLabel.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cLabel.PaddingBottom = 4;

                PdfPCell cValue = new PdfPCell(new Phrase(value, fontValue));
                cValue.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cValue.PaddingBottom = 4;

                tablaInfo.AddCell(cLabel);
                tablaInfo.AddCell(cValue);
            }

            AddInfo("APELLIDOS Y NOMBRES:", r["ApeNom"].ToString());
            AddInfo("PUESTO DE TRABAJO:", r["Cargo"].ToString());
            AddInfo("EMPRESA:", r["RazonSocial"].ToString());
            AddInfo("FECHA:", Convert.ToDateTime(r["FechaCapacitacion"]).ToString("dd/MM/yyyy"));
            AddInfo("DNI:", r["Dni"].ToString());
            //AddInfo("NOTA:", r["NotaCurso"].ToString());

            doc.Add(tablaInfo);

            PdfContentByte cb = writer.DirectContent;

            // Título NOTA
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase("NOTA", fontLabel),
                535,
                700,
                0);

            // círculo
            cb.Circle(535, 665, 28);
            cb.Stroke();

            // nota dentro
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase(
                    r["NotaCurso"].ToString(),
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        16)),
                535,
                660,
                0);


            // Instrucción del examen
            iTextSharp.text.Font fontInstruccion =
                FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD,
                    9);

            Paragraph instruccion = new Paragraph(
                "Marque las respuestas que Ud. crea que son correctas",
                fontInstruccion);

            instruccion.SpacingBefore = 0f;
            instruccion.SpacingAfter = 3f;

            doc.Add(instruccion);

            // =========================
            // PREGUNTAS (FORMATO 2 COLUMNAS COMO EXAMEN)
            // =========================

            iTextSharp.text.Font fontPregunta = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            iTextSharp.text.Font fontAlt = FontFactory.GetFont(FontFactory.HELVETICA, 7);

            // 2 columnas como tu examen
            PdfPTable tablaPreguntas = new PdfPTable(2);
            tablaPreguntas.WidthPercentage = 100;
            tablaPreguntas.SetWidths(new float[] { 50f, 50f });

            int contador = 1;

            var preguntas = det.AsEnumerable()
                .GroupBy(x => x["Pregunta"]);

            foreach (var pregunta in preguntas)
            {
                string texto = pregunta.Key.ToString();

                // contenedor de pregunta completa (columna izquierda o derecha)
                PdfPCell cellPregunta = new PdfPCell();
                cellPregunta.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellPregunta.PaddingBottom = 3f;
                cellPregunta.PaddingTop = 0f;
                cellPregunta.PaddingLeft = 2f;
                cellPregunta.PaddingRight = 2f;

                //Paragraph pPregunta = new Paragraph(contador + ". " + texto, fontPregunta);
                int puntos = Convert.ToInt32(pregunta.First()["Puntos"]);

                Paragraph pPregunta = new Paragraph(
                    $"{contador}. {texto} ({puntos} pts.)",
                    fontPregunta);


                pPregunta.SpacingBefore = 0;
                pPregunta.SpacingAfter = 2;
                cellPregunta.AddElement(pPregunta);

                char letra = 'A';

                foreach (var alt in pregunta)
                {
                    string alternativa = alt["Alternativa"].ToString();
                    bool marcada = Convert.ToInt32(alt["Marcada"]) == 1;
                    string estado = alt["Esado"].ToString();

                    string marca = marcada ? "X " : "  ";

                    Phrase ph = new Phrase();

                    ph.Add(new Chunk($"{marca}{letra}) {alternativa} ", fontAlt));

                    if (marcada)
                    {
                        iTextSharp.text.Font estadoFont = FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        8,
                        estado.Trim().Equals("Correcto", StringComparison.OrdinalIgnoreCase)
                            ? verdeOscuro
                            : BaseColor.RED);

                        ph.Add(new Chunk($"({estado})", estadoFont));
                    }

                    Paragraph pAlt = new Paragraph(ph);
                    pAlt.Leading = 11f; // altura entre líneas

                    cellPregunta.AddElement(pAlt);

                    letra++;
                }

                tablaPreguntas.AddCell(cellPregunta);

                contador++;
            }

            // completar celda vacía si impar
            if (preguntas.Count() % 2 != 0)
            {
                PdfPCell empty = new PdfPCell(new Phrase(" "));
                empty.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tablaPreguntas.AddCell(empty);
            }

            doc.Add(tablaPreguntas);

            // =========================
            // FIRMAS
            // =========================

            byte[] firmaBytes = null;

            string intentoFileName = Path.GetFileName(rutafirma);

            if (!string.IsNullOrEmpty(intentoFileName))
            {
                firmaBytes = await api.ObtenerFirmaBytesAsync(intentoFileName);
            }

            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;
            tablaFirmas.SpacingBefore = 10f;
            tablaFirmas.SetWidths(new float[] { 50f, 50f });

            // =========================
            // FIRMA TRABAJADOR
            // =========================
            PdfPCell firmaTrabajador = new PdfPCell();
            firmaTrabajador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaTrabajador.HorizontalAlignment = Element.ALIGN_CENTER;

            if (firmaBytes != null)
            {
                iTextSharp.text.Image imgFirma =
                    iTextSharp.text.Image.GetInstance(firmaBytes);

                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaTrabajador.AddElement(imgFirma);
            }
            else
            {
                firmaTrabajador.AddElement(new Paragraph("\n\n\n"));
            }

            firmaTrabajador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            firmaTrabajador.AddElement(
                new Paragraph(
                    "FIRMA DEL TRABAJADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });


            // =========================
            // OBTENER FIRMA CAPACITADOR
            // =========================
            //Console.WriteLine("dni " + ce_usuario.usedoc);
            //Console.WriteLine("cod " + ce_usuario.usecod);
            DataTable dt = objcuserneg.FotoUserFirma(Convert.ToString(ce_usuario.usedoc));
            byte[] FirmaIn = null;

            if (dt.Rows.Count > 0 && dt.Rows[0]["Foto"] != DBNull.Value)
            {
                FirmaIn = (byte[])dt.Rows[0]["Foto"];
            }

            // =========================
            // FIRMA CAPACITADOR
            // =========================
            PdfPCell firmaCapacitador = new PdfPCell();
            firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            // Agregar imagen de la firma si existe
            if (FirmaIn != null && FirmaIn.Length > 0)
            {
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(FirmaIn);
                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaCapacitador.AddElement(imgFirma);
            }
            else
            {
                // Dejar espacio si no hay firma
                firmaCapacitador.AddElement(new Paragraph("\n\n\n"));
            }

            // Línea de firma
            firmaCapacitador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            // Texto
            firmaCapacitador.AddElement(
                new Paragraph(
                    "FIRMA CAPACITADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            tablaFirmas.AddCell(firmaTrabajador);
            tablaFirmas.AddCell(firmaCapacitador);

            doc.Add(tablaFirmas);

            //// =========================
            //// FIRMA CAPACITADOR
            //// =========================
            //PdfPCell firmaCapacitador = new PdfPCell();
            //firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            //// espacio para firma manual
            //firmaCapacitador.AddElement(new Paragraph("\n\n\n"));

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "__________________________",
            //        fontValue)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "FIRMA CAPACITADOR",
            //        fontLabel)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //tablaFirmas.AddCell(firmaTrabajador);
            //tablaFirmas.AddCell(firmaCapacitador);

            //doc.Add(tablaFirmas);


            // =========================
            // DATOS EMPRESA
            // =========================

            //doc.Add(new Paragraph("\n"));

            iTextSharp.text.Font fontEmp =
                FontFactory.GetFont(
                    FontFactory.HELVETICA,
                    7);

            doc.Add(new Paragraph("Empresa y/o contratista: " +
                ce_equipoti.EmpresaHoja,
                fontEmp));

            doc.Add(new Paragraph("RUC: " +
                ce_equipoti.RucHoja,
                fontEmp));

            doc.Add(new Paragraph("DIRECCIÓN: " +
                ce_equipoti.DireccionHoja,
                fontEmp));

            doc.Close();

            MessageBox.Show("PDF generado correctamente");
        }

        private async void pictureBox_DescargarExamenes_Click(object sender, EventArgs e)
        {

            string empText = string.Empty, sedText = string.Empty;
            //string areaText = string.Empty, tipoText = string.Empty;

            ////////////////////////////////////
            if (comboBox_empresa.InvokeRequired)
            {
                comboBox_empresa.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_empresa.Text;
                    emp = comboBox_empresa.Text;
                }));
            }
            else
            {
                empText = comboBox_empresa.Text;
                emp = comboBox_empresa.Text;
            }

            if (empText == "SELECCIONE")
            {
                MessageBox.Show("SELECCIONE EMPRESA");
                return;
            }

            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros.");
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() != DialogResult.OK)
                return;

            string carpetaDestino = folder.SelectedPath;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                try
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);

                    string rutafirma =
                        row.Cells["Firma"].Value?.ToString() ?? "";

                    string dni =
                        row.Cells["Dni"].Value?.ToString() ?? id.ToString();

                    string emp = "";

                    if (empText == "AGRICOLA SANTA AZUL S.R.L")
                    {
                        emp = "ASA";
                    }
                    else
                    {
                        emp = "IA";
                    }

                    string nombreArchivo =
                $"{row.Cells["Dni"].Value?.ToString()}" +
                $"_{emp}" +
                $"_{row.Cells["ApeNom"].Value?.ToString()}" +
                $"_{row.Cells["Curso"].Value?.ToString()}" +
                $"_{Convert.ToDateTime(row.Cells["FechaCapacitacion"].Value?.ToString()):yyyyMMdd}.pdf";

                    string rutaCompleta =
                        Path.Combine(carpetaDestino, nombreArchivo);

                    if (empText == "AGRICOLA SANTA AZUL S.R.L")
                    {
                        cn_equipoti.BuscPaginaParaHoja(34, dateTimePicker_Fecha_Fin.Value.Date);
                        //cn_equipoti.BuscTemaCurso(1, guna2ComboBox_Curso.Text.Trim());
                        await GenerarPDFMasivo(id, rutafirma, rutaCompleta);
                    }
                    else if (empText == "AGRICOLA INTERANDINA S.A.C")
                    {
                        cn_equipoti.BuscPaginaParaHoja(33, dateTimePicker_Fecha_Fin.Value.Date);
                        //cn_equipoti.BuscTemaCurso(1, guna2ComboBox_Curso.Text.Trim());
                        await GenerarPDF_IAMasivo(id, rutafirma, rutaCompleta);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error en registro {row.Index}: {ex.Message}");
                }
            }

            MessageBox.Show("Todos los exámenes fueron descargados.");
        }

        private async Task GenerarPDFMasivo(int idCapacitado, string rutafirma, string rutaCompleta)
        {
            var api = new cn_apiservices();
            cn_sst obj = new cn_sst();

            DataSet ds = obj.ObtenerExamenPDF(idCapacitado);

            if (ds == null || ds.Tables.Count < 2)
            {
                MessageBox.Show("Error al obtener datos");
                return;
            }

            DataTable cab = ds.Tables[0];
            DataTable det = ds.Tables[1];

            if (cab.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de cabecera");
                return;
            }
            DataRow rw = cab.Rows[0];

            // Crear carpeta si no existe
            Directory.CreateDirectory(
                Path.GetDirectoryName(rutaCompleta));

            iTextSharp.text.Document doc =
                new iTextSharp.text.Document(
                    iTextSharp.text.PageSize.A4,
                    25, 25, 25, 25);

            PdfWriter writer =
                PdfWriter.GetInstance(
                    doc,
                    new FileStream(
                        rutaCompleta,
                        FileMode.Create));
            doc.Open();

            // =========================
            // HEADER MEJORADO (CORREGIDO)
            // =========================

            PdfPTable head = new PdfPTable(3);
            head.WidthPercentage = 105;
            head.SetWidths(new float[] { 20f, 55f, 25f });

            // =========================
            // LOGO
            // =========================
            Bitmap bmp = Properties.Resources.logo_asa;

            byte[] imgBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imgBytes = ms.ToArray();
            }

            iTextSharp.text.Image logo =
                iTextSharp.text.Image.GetInstance(imgBytes);

            logo.ScaleToFit(60f, 60f);

            PdfPCell c1 = new PdfPCell(logo);
            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
            c1.Padding = 5;

            // =========================
            // CENTRO
            // =========================
            iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
            iTextSharp.text.Font fontSub = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPCell c2 = new PdfPCell();
            //c2.AddElement(new Phrase(ce_equipoti.NombreHoja, fontTitulo));
            //c2.AddElement(new Phrase(ce_equipoti.TipoHoja, fontSub));


            Paragraph pTitulo = new Paragraph(ce_equipoti.NombreHoja, fontTitulo);

            pTitulo.Alignment = Element.ALIGN_LEFT;
            pTitulo.SpacingAfter = 8f;

            Paragraph pSubTitulo = new Paragraph(ce_equipoti.TipoHoja, fontSub);

            pSubTitulo.Alignment = Element.ALIGN_LEFT;

            c2.AddElement(pTitulo);
            c2.AddElement(pSubTitulo);


            c2.HorizontalAlignment = Element.ALIGN_CENTER;
            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
            c2.Padding = 5;

            // =========================
            // DERECHA (TABLA)
            // =========================
            iTextSharp.text.Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable datos = new PdfPTable(2);
            datos.WidthPercentage = 100;

            datos.AddCell(new PdfPCell(new Phrase("Código", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.CodigoHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Versión", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.VersionHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Fecha", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.FechaHoja.ToString("dd/MM/yyyy"), fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Página", fontData)));
            datos.AddCell(new PdfPCell(new Phrase("1 de 1", fontData)));

            PdfPCell c3 = new PdfPCell(datos);
            c3.Padding = 1;

            // =========================
            // ARMADO FINAL
            // =========================
            head.AddCell(c1);
            head.AddCell(c2);
            head.AddCell(c3);

            doc.Add(head);


            // =========================
            // TITULO DE LOS NOMBRES
            // =========================

            DataRow rt = cab.Rows[0];

            iTextSharp.text.Font fontExamen =
            FontFactory.GetFont(
            FontFactory.HELVETICA_BOLD,
            14);

            Paragraph titulo =
                new Paragraph(
                    "EXAMEN ESCRITO: " + rt["Curso"].ToString(),
                    fontExamen);

            titulo.Alignment =
                Element.ALIGN_CENTER;

            titulo.SpacingBefore = 5f;
            titulo.SpacingAfter = 10f;

            doc.Add(titulo);
            // =========================
            // CABECERA DATOS (FORMATO EXAMEN)
            // =========================
            DataRow r = cab.Rows[0];

            iTextSharp.text.Font fontLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            iTextSharp.text.Font fontValue = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPTable tablaInfo = new PdfPTable(2);
            tablaInfo.WidthPercentage = 100;
            tablaInfo.SetWidths(new float[] { 30f, 70f });

            // helper local
            void AddInfo(string label, string value)
            {
                PdfPCell cLabel = new PdfPCell(new Phrase(label, fontLabel));
                cLabel.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cLabel.PaddingBottom = 4;

                PdfPCell cValue = new PdfPCell(new Phrase(value, fontValue));
                cValue.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cValue.PaddingBottom = 4;

                tablaInfo.AddCell(cLabel);
                tablaInfo.AddCell(cValue);
            }

            AddInfo("APELLIDOS Y NOMBRES:", r["ApeNom"].ToString());
            AddInfo("PUESTO DE TRABAJO:", r["Cargo"].ToString());
            AddInfo("EMPRESA:", r["RazonSocial"].ToString());
            AddInfo("FECHA:", Convert.ToDateTime(r["FechaCapacitacion"]).ToString("dd/MM/yyyy"));
            AddInfo("DNI:", r["Dni"].ToString());
            //AddInfo("NOTA:", r["NotaCurso"].ToString());

            doc.Add(tablaInfo);

            PdfContentByte cb = writer.DirectContent;

            // Título NOTA
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase("NOTA", fontLabel),
                535,
                700,
                0);

            // círculo
            cb.Circle(535, 665, 28);
            cb.Stroke();

            // nota dentro
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase(
                    r["NotaCurso"].ToString(),
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        16)),
                535,
                660,
                0);

            // Instrucción del examen
            iTextSharp.text.Font fontInstruccion =
                FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD,
                    9);

            Paragraph instruccion = new Paragraph(
                "Marque las respuestas que Ud. crea que son correctas",
                fontInstruccion);

            instruccion.SpacingBefore = 0f;
            instruccion.SpacingAfter = 3f;

            doc.Add(instruccion);

            // =========================
            // PREGUNTAS (FORMATO 2 COLUMNAS COMO EXAMEN)
            // =========================

            iTextSharp.text.Font fontPregunta = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            iTextSharp.text.Font fontAlt = FontFactory.GetFont(FontFactory.HELVETICA, 7);

            // 2 columnas como tu examen
            PdfPTable tablaPreguntas = new PdfPTable(2);
            tablaPreguntas.WidthPercentage = 100;
            tablaPreguntas.SetWidths(new float[] { 50f, 50f });

            int contador = 1;

            var preguntas = det.AsEnumerable()
                .GroupBy(x => x["Pregunta"]);

            foreach (var pregunta in preguntas)
            {
                string texto = pregunta.Key.ToString();

                // contenedor de pregunta completa (columna izquierda o derecha)
                PdfPCell cellPregunta = new PdfPCell();
                cellPregunta.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellPregunta.PaddingBottom = 3f;
                cellPregunta.PaddingTop = 0f;
                cellPregunta.PaddingLeft = 2f;
                cellPregunta.PaddingRight = 2f;

                //Paragraph pPregunta = new Paragraph(contador + ". " + texto, fontPregunta);
                int puntos = Convert.ToInt32(pregunta.First()["Puntos"]);

                Paragraph pPregunta = new Paragraph(
                    $"{contador}. {texto} ({puntos} pts.)",
                    fontPregunta);

                pPregunta.SpacingBefore = 0;
                pPregunta.SpacingAfter = 2;
                cellPregunta.AddElement(pPregunta);

                char letra = 'A';

                foreach (var alt in pregunta)
                {
                    string alternativa = alt["Alternativa"].ToString();
                    bool marcada = Convert.ToInt32(alt["Marcada"]) == 1;
                    string estado = alt["Esado"].ToString();

                    string marca = marcada ? "X " : "  ";

                    Phrase ph = new Phrase();

                    ph.Add(new Chunk($"{marca}{letra}) {alternativa} ", fontAlt));

                    if (marcada)
                    {
                        iTextSharp.text.Font estadoFont = FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        8,
                        estado.Trim().Equals("Correcto", StringComparison.OrdinalIgnoreCase)
                            ? verdeOscuro
                            : BaseColor.RED);

                        ph.Add(new Chunk($"({estado})", estadoFont));
                    }

                    Paragraph pAlt = new Paragraph(ph);
                    pAlt.Leading = 11f; // altura entre líneas

                    cellPregunta.AddElement(pAlt);

                    letra++;
                }

                tablaPreguntas.AddCell(cellPregunta);

                contador++;
            }

            // completar celda vacía si impar
            if (preguntas.Count() % 2 != 0)
            {
                PdfPCell empty = new PdfPCell(new Phrase(" "));
                empty.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tablaPreguntas.AddCell(empty);
            }

            doc.Add(tablaPreguntas);

            // =========================
            // FIRMAS
            // =========================

            byte[] firmaBytes = null;

            string intentoFileName = Path.GetFileName(rutafirma);

            if (!string.IsNullOrEmpty(intentoFileName))
            {
                firmaBytes = await api.ObtenerFirmaBytesAsync(intentoFileName);
            }

            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;
            tablaFirmas.SpacingBefore = 30f;
            tablaFirmas.SetWidths(new float[] { 50f, 50f });

            // =========================
            // FIRMA TRABAJADOR
            // =========================
            PdfPCell firmaTrabajador = new PdfPCell();
            firmaTrabajador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaTrabajador.HorizontalAlignment = Element.ALIGN_CENTER;

            if (firmaBytes != null)
            {
                iTextSharp.text.Image imgFirma =
                    iTextSharp.text.Image.GetInstance(firmaBytes);

                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaTrabajador.AddElement(imgFirma);
            }
            else
            {
                firmaTrabajador.AddElement(new Paragraph("\n\n\n"));
            }

            firmaTrabajador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            firmaTrabajador.AddElement(
                new Paragraph(
                    "FIRMA DEL TRABAJADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });



            // =========================
            // OBTENER FIRMA CAPACITADOR
            // =========================
            //Console.WriteLine("dni "+ ce_usuario.usedoc);
            //Console.WriteLine("cod " + ce_usuario.usecod);
            DataTable dt = objcuserneg.FotoUserFirma(Convert.ToString(ce_usuario.usedoc));
            byte[] FirmaIn = null;

            if (dt.Rows.Count > 0 && dt.Rows[0]["Foto"] != DBNull.Value)
            {
                FirmaIn = (byte[])dt.Rows[0]["Foto"];
            }

            // =========================
            // FIRMA CAPACITADOR
            // =========================
            PdfPCell firmaCapacitador = new PdfPCell();
            firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            // Agregar imagen de la firma si existe
            if (FirmaIn != null && FirmaIn.Length > 0)
            {
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(FirmaIn);
                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaCapacitador.AddElement(imgFirma);
            }
            else
            {
                // Dejar espacio si no hay firma
                firmaCapacitador.AddElement(new Paragraph("\n\n\n"));
            }

            // Línea de firma
            firmaCapacitador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            // Texto
            firmaCapacitador.AddElement(
                new Paragraph(
                    "FIRMA CAPACITADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            tablaFirmas.AddCell(firmaTrabajador);
            tablaFirmas.AddCell(firmaCapacitador);

            doc.Add(tablaFirmas);


            //// =========================
            //// FIRMA CAPACITADOR
            //// =========================
            //PdfPCell firmaCapacitador = new PdfPCell();
            //firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            //// espacio para firma manual
            //firmaCapacitador.AddElement(new Paragraph("\n\n\n"));

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "__________________________",
            //        fontValue)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "FIRMA CAPACITADOR",
            //        fontLabel)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //tablaFirmas.AddCell(firmaTrabajador);
            //tablaFirmas.AddCell(firmaCapacitador);

            //doc.Add(tablaFirmas);


            // =========================
            // DATOS EMPRESA
            // =========================

            //doc.Add(new Paragraph("\n"));

            iTextSharp.text.Font fontEmp =
                FontFactory.GetFont(
                    FontFactory.HELVETICA,
                    7);

            doc.Add(new Paragraph("Empresa y/o contratista: " +
                ce_equipoti.EmpresaHoja,
                fontEmp));

            doc.Add(new Paragraph("RUC: " +
                ce_equipoti.RucHoja,
                fontEmp));

            doc.Add(new Paragraph("DIRECCIÓN: " +
                ce_equipoti.DireccionHoja,
                fontEmp));

            doc.Close();

            //MessageBox.Show("PDF generado correctamente");
        }

        private async Task GenerarPDF_IAMasivo(int idCapacitado, string rutafirma, string rutaCompleta)
        {
            var api = new cn_apiservices();
            cn_sst obj = new cn_sst();

            DataSet ds = obj.ObtenerExamenPDF(idCapacitado);

            if (ds == null || ds.Tables.Count < 2)
            {
                MessageBox.Show("Error al obtener datos");
                return;
            }

            DataTable cab = ds.Tables[0];
            DataTable det = ds.Tables[1];

            if (cab.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de cabecera");
                return;
            }
            DataRow rw = cab.Rows[0];

            // Crear carpeta si no existe
            Directory.CreateDirectory(
                Path.GetDirectoryName(rutaCompleta));

            iTextSharp.text.Document doc =
                new iTextSharp.text.Document(
                    iTextSharp.text.PageSize.A4,
                    25, 25, 25, 25);

            PdfWriter writer =
                PdfWriter.GetInstance(
                    doc,
                    new FileStream(
                        rutaCompleta,
                        FileMode.Create));
            doc.Open();

            // =========================
            // HEADER MEJORADO (CORREGIDO)
            // =========================

            PdfPTable head = new PdfPTable(3);
            head.WidthPercentage = 105;
            head.SetWidths(new float[] { 20f, 55f, 25f });

            // =========================
            // LOGO
            // =========================
            Bitmap bmp = Properties.Resources.logo_ia;

            byte[] imgBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imgBytes = ms.ToArray();
            }

            iTextSharp.text.Image logo =
                iTextSharp.text.Image.GetInstance(imgBytes);

            logo.ScaleToFit(60f, 60f);

            PdfPCell c1 = new PdfPCell(logo);
            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
            c1.Padding = 5;

            // =========================
            // CENTRO
            // =========================
            iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
            iTextSharp.text.Font fontSub = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPCell c2 = new PdfPCell();
            //c2.AddElement(new Phrase(ce_equipoti.NombreHoja, fontTitulo));
            //c2.AddElement(new Phrase(ce_equipoti.TipoHoja, fontSub));


            Paragraph pTitulo = new Paragraph(ce_equipoti.NombreHoja, fontTitulo);

            pTitulo.Alignment = Element.ALIGN_LEFT;
            pTitulo.SpacingAfter = 8f;

            Paragraph pSubTitulo = new Paragraph(ce_equipoti.TipoHoja, fontSub);

            pSubTitulo.Alignment = Element.ALIGN_LEFT;

            c2.AddElement(pTitulo);
            c2.AddElement(pSubTitulo);


            c2.HorizontalAlignment = Element.ALIGN_CENTER;
            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
            c2.Padding = 5;

            // =========================
            // DERECHA (TABLA)
            // =========================
            iTextSharp.text.Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable datos = new PdfPTable(2);
            datos.WidthPercentage = 100;

            datos.AddCell(new PdfPCell(new Phrase("Código", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.CodigoHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Versión", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.VersionHoja, fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Fecha", fontData)));
            datos.AddCell(new PdfPCell(new Phrase(ce_equipoti.FechaHoja.ToString("dd/MM/yyyy"), fontData)));

            datos.AddCell(new PdfPCell(new Phrase("Página", fontData)));
            datos.AddCell(new PdfPCell(new Phrase("1 de 1", fontData)));

            PdfPCell c3 = new PdfPCell(datos);
            c3.Padding = 1;

            // =========================
            // ARMADO FINAL
            // =========================
            head.AddCell(c1);
            head.AddCell(c2);
            head.AddCell(c3);

            doc.Add(head);


            // =========================
            // TITULO DE LOS NOMBRES
            // =========================

            DataRow rt = cab.Rows[0];

            iTextSharp.text.Font fontExamen =
            FontFactory.GetFont(
            FontFactory.HELVETICA_BOLD,
            14);

            Paragraph titulo =
                new Paragraph(
                    "EXAMEN ESCRITO: " + rt["Curso"].ToString(),
                    fontExamen);

            titulo.Alignment =
                Element.ALIGN_CENTER;

            titulo.SpacingBefore = 5f;
            titulo.SpacingAfter = 10f;

            doc.Add(titulo);
            // =========================
            // CABECERA DATOS (FORMATO EXAMEN)
            // =========================
            DataRow r = cab.Rows[0];

            iTextSharp.text.Font fontLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            iTextSharp.text.Font fontValue = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPTable tablaInfo = new PdfPTable(2);
            tablaInfo.WidthPercentage = 100;
            tablaInfo.SetWidths(new float[] { 30f, 70f });

            // helper local
            void AddInfo(string label, string value)
            {
                PdfPCell cLabel = new PdfPCell(new Phrase(label, fontLabel));
                cLabel.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cLabel.PaddingBottom = 4;

                PdfPCell cValue = new PdfPCell(new Phrase(value, fontValue));
                cValue.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cValue.PaddingBottom = 4;

                tablaInfo.AddCell(cLabel);
                tablaInfo.AddCell(cValue);
            }

            AddInfo("APELLIDOS Y NOMBRES:", r["ApeNom"].ToString());
            AddInfo("PUESTO DE TRABAJO:", r["Cargo"].ToString());
            AddInfo("EMPRESA:", r["RazonSocial"].ToString());
            AddInfo("FECHA:", Convert.ToDateTime(r["FechaCapacitacion"]).ToString("dd/MM/yyyy"));
            AddInfo("DNI:", r["Dni"].ToString());
            //AddInfo("NOTA:", r["NotaCurso"].ToString());

            doc.Add(tablaInfo);

            PdfContentByte cb = writer.DirectContent;

            // Título NOTA
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase("NOTA", fontLabel),
                535,
                700,
                0);

            // círculo
            cb.Circle(535, 665, 28);
            cb.Stroke();

            // nota dentro
            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                new Phrase(
                    r["NotaCurso"].ToString(),
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        16)),
                535,
                660,
                0);

            // Instrucción del examen
            iTextSharp.text.Font fontInstruccion =
                FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD,
                    9);

            Paragraph instruccion = new Paragraph(
                "Marque las respuestas que Ud. crea que son correctas",
                fontInstruccion);

            instruccion.SpacingBefore = 0f;
            instruccion.SpacingAfter = 3f;

            doc.Add(instruccion);

            // =========================
            // PREGUNTAS (FORMATO 2 COLUMNAS COMO EXAMEN)
            // =========================

            iTextSharp.text.Font fontPregunta = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            iTextSharp.text.Font fontAlt = FontFactory.GetFont(FontFactory.HELVETICA, 7);

            // 2 columnas como tu examen
            PdfPTable tablaPreguntas = new PdfPTable(2);
            tablaPreguntas.WidthPercentage = 100;
            tablaPreguntas.SetWidths(new float[] { 50f, 50f });

            int contador = 1;

            var preguntas = det.AsEnumerable()
                .GroupBy(x => x["Pregunta"]);

            foreach (var pregunta in preguntas)
            {
                string texto = pregunta.Key.ToString();

                // contenedor de pregunta completa (columna izquierda o derecha)
                PdfPCell cellPregunta = new PdfPCell();
                cellPregunta.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellPregunta.PaddingBottom = 3f;
                cellPregunta.PaddingTop = 0f;
                cellPregunta.PaddingLeft = 2f;
                cellPregunta.PaddingRight = 2f;

                //Paragraph pPregunta = new Paragraph(contador + ". " + texto, fontPregunta);
                int puntos = Convert.ToInt32(pregunta.First()["Puntos"]);

                Paragraph pPregunta = new Paragraph(
                    $"{contador}. {texto} ({puntos} pts.)",
                    fontPregunta);

                pPregunta.SpacingBefore = 0;
                pPregunta.SpacingAfter = 2;
                cellPregunta.AddElement(pPregunta);

                char letra = 'A';

                foreach (var alt in pregunta)
                {
                    string alternativa = alt["Alternativa"].ToString();
                    bool marcada = Convert.ToInt32(alt["Marcada"]) == 1;
                    string estado = alt["Esado"].ToString();

                    string marca = marcada ? "X " : "  ";

                    Phrase ph = new Phrase();

                    ph.Add(new Chunk($"{marca}{letra}) {alternativa} ", fontAlt));

                    if (marcada)
                    {
                        iTextSharp.text.Font estadoFont = FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        8,
                        estado.Trim().Equals("Correcto", StringComparison.OrdinalIgnoreCase)
                            ? verdeOscuro
                            : BaseColor.RED);

                        ph.Add(new Chunk($"({estado})", estadoFont));
                    }

                    Paragraph pAlt = new Paragraph(ph);
                    pAlt.Leading = 11f; // altura entre líneas

                    cellPregunta.AddElement(pAlt);

                    letra++;
                }

                tablaPreguntas.AddCell(cellPregunta);

                contador++;
            }

            // completar celda vacía si impar
            if (preguntas.Count() % 2 != 0)
            {
                PdfPCell empty = new PdfPCell(new Phrase(" "));
                empty.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tablaPreguntas.AddCell(empty);
            }

            doc.Add(tablaPreguntas);

            // =========================
            // FIRMAS
            // =========================

            byte[] firmaBytes = null;

            string intentoFileName = Path.GetFileName(rutafirma);

            if (!string.IsNullOrEmpty(intentoFileName))
            {
                firmaBytes = await api.ObtenerFirmaBytesAsync(intentoFileName);
            }

            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;
            tablaFirmas.SpacingBefore = 30f;
            tablaFirmas.SetWidths(new float[] { 50f, 50f });

            // =========================
            // FIRMA TRABAJADOR
            // =========================
            PdfPCell firmaTrabajador = new PdfPCell();
            firmaTrabajador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaTrabajador.HorizontalAlignment = Element.ALIGN_CENTER;

            if (firmaBytes != null)
            {
                iTextSharp.text.Image imgFirma =
                    iTextSharp.text.Image.GetInstance(firmaBytes);

                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaTrabajador.AddElement(imgFirma);
            }
            else
            {
                firmaTrabajador.AddElement(new Paragraph("\n\n\n"));
            }

            firmaTrabajador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            firmaTrabajador.AddElement(
                new Paragraph(
                    "FIRMA DEL TRABAJADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });



            // =========================
            // OBTENER FIRMA CAPACITADOR
            // =========================
            //Console.WriteLine("dni "+ ce_usuario.usedoc);
            //Console.WriteLine("cod " + ce_usuario.usecod);
            DataTable dt = objcuserneg.FotoUserFirma(Convert.ToString(ce_usuario.usedoc));
            byte[] FirmaIn = null;

            if (dt.Rows.Count > 0 && dt.Rows[0]["Foto"] != DBNull.Value)
            {
                FirmaIn = (byte[])dt.Rows[0]["Foto"];
            }

            // =========================
            // FIRMA CAPACITADOR
            // =========================
            PdfPCell firmaCapacitador = new PdfPCell();
            firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            // Agregar imagen de la firma si existe
            if (FirmaIn != null && FirmaIn.Length > 0)
            {
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(FirmaIn);
                imgFirma.ScaleToFit(120f, 60f);
                imgFirma.Alignment = Element.ALIGN_CENTER;

                firmaCapacitador.AddElement(imgFirma);
            }
            else
            {
                // Dejar espacio si no hay firma
                firmaCapacitador.AddElement(new Paragraph("\n\n\n"));
            }

            // Línea de firma
            firmaCapacitador.AddElement(
                new Paragraph(
                    "__________________________",
                    fontValue)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            // Texto
            firmaCapacitador.AddElement(
                new Paragraph(
                    "FIRMA CAPACITADOR",
                    fontLabel)
                {
                    Alignment = Element.ALIGN_CENTER
                });

            tablaFirmas.AddCell(firmaTrabajador);
            tablaFirmas.AddCell(firmaCapacitador);

            doc.Add(tablaFirmas);

            //// =========================
            //// FIRMA CAPACITADOR
            //// =========================
            //PdfPCell firmaCapacitador = new PdfPCell();
            //firmaCapacitador.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //firmaCapacitador.HorizontalAlignment = Element.ALIGN_CENTER;

            //// espacio para firma manual
            //firmaCapacitador.AddElement(new Paragraph("\n\n\n"));

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "__________________________",
            //        fontValue)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //firmaCapacitador.AddElement(
            //    new Paragraph(
            //        "FIRMA CAPACITADOR",
            //        fontLabel)
            //    {
            //        Alignment = Element.ALIGN_CENTER
            //    });

            //tablaFirmas.AddCell(firmaTrabajador);
            //tablaFirmas.AddCell(firmaCapacitador);

            //doc.Add(tablaFirmas);


            // =========================
            // DATOS EMPRESA
            // =========================

            //doc.Add(new Paragraph("\n"));

            iTextSharp.text.Font fontEmp =
                FontFactory.GetFont(
                    FontFactory.HELVETICA,
                    7);

            doc.Add(new Paragraph("Empresa y/o contratista: " +
                ce_equipoti.EmpresaHoja,
                fontEmp));

            doc.Add(new Paragraph("RUC: " +
                ce_equipoti.RucHoja,
                fontEmp));

            doc.Add(new Paragraph("DIRECCIÓN: " +
                ce_equipoti.DireccionHoja,
                fontEmp));

            doc.Close();

            //MessageBox.Show("PDF generado correctamente");
        }


    }
}
