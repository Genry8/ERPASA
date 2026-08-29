using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using ERPASA.Frm_Contabilidad;
using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Logistica
{
    public partial class Frm_AgregarCursosProvMasivo : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();
        cd_nisira objnisira = new cd_nisira();
        cn_logistica objcnlogistica = new cn_logistica();
        DataTable dtg;

        public Frm_AgregarCursosProvMasivo()
        {
            InitializeComponent();
        }

        private void Frm_AgregarCursosProvMasivo_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            dataGridView1.AllowUserToAddRows = false;
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.SelectedIndex = 0;

            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            textRuta.Enabled = false;
            //comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMaquinaria();
            //comboBox_TipoMerma.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaMaquinariaFiler();
            //comboBox_TipoMerma.DisplayMember = "Filer"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE
                comboBox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            //if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    //CARGAR SEDE
            //    comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //    comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardar();
        }

        public void AlertaGuardar()
        {
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_sede.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            else
            {
                //Msbox.Frm_NotificacionesPeligro ng =
                //new Msbox.Frm_NotificacionesPeligro("USUARIO YA FUE PROGRAMADO", Color.FromArgb(238, 24, 24), 3);
                //ng.ShowDialog();
                // Columna del Excel -> IdCurso
                Dictionary<int, int> cursos = new Dictionary<int, int>()
                {
                    {8, 1},   // HombreNuevo
                    {9, 2},   // TrabajosEnAltura
                    {10,3},   // TrabajosEnCaliente
                    {11,4},   // ExcavacionZanjas
                    {12,5}    // RITRAN
                };

                string MessageBoxTitle = "GUARDAR ";
                string MessageBoxContent = "¿Desea guardar registro? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        // Datos del trabajador
                        string dni = row.Cells[0].Value?.ToString().Trim();
                        string apePat = row.Cells[1].Value?.ToString().Trim();
                        string apeMat = row.Cells[2].Value?.ToString().Trim();
                        string nombres = row.Cells[3].Value?.ToString().Trim();
                        string ruc = row.Cells[4].Value?.ToString().Trim();
                        string razonSocial = row.Cells[5].Value?.ToString().Trim();
                        string cargo = row.Cells[6].Value?.ToString().Trim();
                        string area = row.Cells[7].Value?.ToString().Trim();

                        string nombreCompleto = $"{apePat} {apeMat} {nombres}";

                        foreach (var item in cursos)
                        {
                            int columnaCurso = item.Key;
                            int idCurso = item.Value;

                            // Solo guardar cursos marcados con X
                            bool estadoCurso = row.Cells[columnaCurso].Value?.ToString().Trim().ToUpper() == "X";

                            //if (!estadoCurso)
                            //    continue;

                            bool existe = cn_logistica.BuscExisteCursoProgramado(
                                                dni+""+idCurso,
                                                dateTimePicker_FechaInd.Value.Date,
                                                3);

                            string idOperacion = "0";

                            if (existe)
                            {
                                idOperacion = "1";
                            }

                            objcnlogistica.GuardarCursosProveedorProgramados(
                                idOperacion,
                                comboBox_empresa.Text,
                                comboBox_sede.Text,
                                dni,
                                apePat,
                                apeMat,
                                nombres,
                                nombreCompleto,
                                ruc,
                                razonSocial,
                                cargo,
                                dateTimePicker_FechaInd.Value.Date,
                                area,
                                idCurso,
                                estadoCurso,
                                comboBox_TipoTrabajador.Text,
                                "S",
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod
                            );


                        }
                    }

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro(
                            "GUARDADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214),
                            1);

                    ng.ShowDialog();

                }
            
            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimiparCampos();
        }

        public void LimiparCampos()
        {
            AgregarColumna();
            //textBox_Cargo.Text = string.Empty;
            //textBox_Area.Text = string.Empty;
        }


        public async Task BuscarPersonaReniec()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Token
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue(
                            "Bearer",
                            "a22c04e4b06e3244195120f8f0d20b7be66de8688ced6124f89d9f63dae98ddc"
                        );

                    // Headers
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );

                    // Body JSON
                    var data = new
                    {
                        //dni = textBox_Dni.Text
                    };

                    string json = JsonConvert.SerializeObject(data);

                    HttpContent content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                    // POST
                    HttpResponseMessage response = await client.PostAsync(
                        "https://apiperu.dev/api/dni",
                        content
                    );

                    string resultado = await response.Content.ReadAsStringAsync();

                    dynamic respuesta = JsonConvert.DeserializeObject(resultado);

                    // Datos
                    //textBox_apellidopat.Text =
                    //    respuesta.data.apellido_paterno.ToString(); // + " " +
                    //textbox_apellidomat.Text =
                    //    respuesta.data.apellido_materno.ToString();

                    //textbox_nombres.Text =
                    //    respuesta.data.nombres.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible conectar con RENIEC");
            }
        }


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

                AgregarColumna();
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textRuta.Text != "")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
                dataGridView1.ClearSelection();
                if (dataGridView1.Rows.Count > 1)
                {
                    //label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }


        private void AgregarColumna()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            // 
            // Column4
            // 
            DataGridViewTextBoxColumn DNI = new DataGridViewTextBoxColumn();
            DNI.HeaderText = "DNI";
            DNI.Name = "DNI";
            DNI.Width = 80;
            dataGridView1.Columns.Add(DNI);
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn ApellidoPat = new DataGridViewTextBoxColumn();
            ApellidoPat.HeaderText = "ApellidoPat";
            ApellidoPat.Name = "ApellidoPat";
            ApellidoPat.Width = 80;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            dataGridView1.Columns.Add(ApellidoPat);

            // 
            // Column2
            // 
            DataGridViewTextBoxColumn ApellidoMat = new DataGridViewTextBoxColumn();
            ApellidoMat.HeaderText = "ApellidoMat";
            ApellidoMat.Name = "ApellidoMat";
            ApellidoMat.Width = 80;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(ApellidoMat);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "Nombres";
            Nombres.Name = "Nombres";
            Nombres.Width = 100;
            dataGridView1.Columns.Add(Nombres);

            // 
            // Column4
            // 
            DataGridViewTextBoxColumn RUC = new DataGridViewTextBoxColumn();
            RUC.HeaderText = "RUC";
            RUC.Name = "RUC";
            RUC.Width = 100;
            dataGridView1.Columns.Add(RUC);

        }



    }

}
