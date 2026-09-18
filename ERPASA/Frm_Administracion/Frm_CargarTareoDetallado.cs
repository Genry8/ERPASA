using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Administracion
{
    public partial class Frm_CargarTareoDetallado : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_administracion objcnlog = new cn_administracion();
        string TipoAlimento;

        public Frm_CargarTareoDetallado()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarTareoDetallado_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

        }





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
            DataGridViewTextBoxColumn Apellidos = new DataGridViewTextBoxColumn();
            Apellidos.HeaderText = "APELLIDOS Y NOMBRES";
            Apellidos.Name = "Column2";
            Apellidos.Width = 85;
            dataGridView1.Columns.Add(Apellidos);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn FechaCese = new DataGridViewTextBoxColumn();
            FechaCese.HeaderText = "FECHA INGRESO";
            FechaCese.Name = "Column3";
            FechaCese.Width = 87;
            dataGridView1.Columns.Add(FechaCese);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Area = new DataGridViewTextBoxColumn();
            Area.HeaderText = "AREA";
            Area.Name = "Column3";
            Area.Width = 87;
            dataGridView1.Columns.Add(Area);
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
            dataGridView1.Columns.Add(Dni);
            //
            //
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "NOMBRES";
            Nombres.Name = "Column3";
            Nombres.Width = 85;
            dataGridView1.Columns.Add(Nombres);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "EMPRESA";
            Empresa.Name = "Column4";
            Empresa.Width = 87;
            dataGridView1.Columns.Add(Empresa);
            //
            // Column5
            // 
            DataGridViewTextBoxColumn Autorizacion = new DataGridViewTextBoxColumn();
            Autorizacion.HeaderText = "AUTORIZACION";
            Autorizacion.Name = "Column5";
            Autorizacion.Width = 87;
            dataGridView1.Columns.Add(Autorizacion);
        }

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
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
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    GuardarTareoDetallado();
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA CARGAR DATOS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        public void GuardarTareoDetalladoOF()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    var exrev = cn_administracion.BuscExisteTareoDetallado(
                        Convert.ToDateTime(dataGridView1[11, i].Value).Date, //Fecha
                        dataGridView1[18, i].Value.ToString().Trim(), //DNI
                        dataGridView1[4, i].Value.ToString().Trim() //GRUPO LABOR
                        );


                    if (exrev == true)
                    {
                        objcnlog.ActualizarTareoDetallado(
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Empresa
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Sede
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Fundo
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//@Cod_Grupo_Labor
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//@Grupo_Labor
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//@Cod_Labor
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//@Labor
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//@Labor_Correcta
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//@Uni_Med
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//@Cod_Cultivo
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//@Cultivo
                        Convert.ToDateTime(dataGridView1[11, i].Value).Date,//fecha
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//@DNI_Supervisor
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//@Supervisor
                        Convert.ToDateTime(dataGridView1[14, i].Value).Date,//@Fec_Inicio
                        Convert.ToDateTime(dataGridView1[15, i].Value).Date,//@Fec_Fin
                        dataGridView1[16, i].Value.ToString().Trim(),//@Horas_efectivas
                        dataGridView1[17, i].Value.ToString().Trim(),//@Total_Horas
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//@Dni Responsable
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//@Responsable
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//@Dni
                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//@Ape_Nom
                        Convert.ToDecimal(dataGridView1[22, i].Value),//@Avance
                        dataGridView1[23, i].Value.ToString().ToUpper().Trim(),//@Motivo_Salida
                        dataGridView1[24, i].Value.ToString().ToUpper().Trim(),//@Tipo_Labor
                        dataGridView1[25, i].Value.ToString().ToUpper().Trim(),//@Cabezal
                        dataGridView1[26, i].Value.ToString().ToUpper().Trim(),//@CodCentroCosto
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//@CentroCosto
                        dataGridView1[28, i].Value.ToString().ToUpper().Trim(),//@Observacion

                        comboBox_Hojas.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        //ce_usuario.HostName(),
                        //ce_usuario.FechaSistema(),
                        //0,
                        //0
                        );

                    }

                    else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    {

                        objcnlog.GuardarTareoDetallado(
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Empresa
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Sede
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Fundo
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//@Cod_Grupo_Labor
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//@Grupo_Labor
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//@Cod_Labor
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//@Labor
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//@Labor_Correcta
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//@Uni_Med
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//@Cod_Cultivo
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//@Cultivo
                        Convert.ToDateTime(dataGridView1[11, i].Value).Date,//fecha
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//@DNI_Supervisor
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//@Supervisor
                        Convert.ToDateTime(dataGridView1[14, i].Value).Date,//@Fec_Inicio
                        Convert.ToDateTime(dataGridView1[15, i].Value).Date,//@Fec_Fin
                        dataGridView1[16, i].Value.ToString().Trim(),//@Horas_efectivas
                        dataGridView1[17, i].Value.ToString().Trim(),//@Total_Horas
                        dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//@Dni Responsable
                        dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//@Responsable
                        dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//@Dni
                        dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//@Ape_Nom
                        Convert.ToDecimal(dataGridView1[22, i].Value),//@Avance
                        dataGridView1[23, i].Value.ToString().ToUpper().Trim(),//@Motivo_Salida
                        dataGridView1[24, i].Value.ToString().ToUpper().Trim(),//@Tipo_Labor
                        dataGridView1[25, i].Value.ToString().ToUpper().Trim(),//@Cabezal
                        dataGridView1[26, i].Value.ToString().ToUpper().Trim(),//@CodCentroCosto
                        dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//@CentroCosto
                        dataGridView1[28, i].Value.ToString().ToUpper().Trim(),//@Observacion

                        comboBox_Hojas.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0
                        );

                    }
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }


            dataGridView1.AllowUserToAddRows = true;

        }

        public void GuardarTareoDetallado()
        {
            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(
                MessageBoxContent,
                MessageBoxTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult != DialogResult.Yes)
                return;

            try
            {
                DataTable dt = CrearDataTableTareoDetallado();

                DateTime fechaSistema = ce_usuario.FechaSistema();
                int usuario = ce_usuario.usecod;
                string hostname = ce_usuario.HostName();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // No procesar la fila nueva
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataRow row = dt.NewRow();

                    row["Empresa"] = ValorString(dataGridView1[0, i].Value);
                    row["Sede"] = ValorString(dataGridView1[1, i].Value);
                    row["Fundo"] = ValorString(dataGridView1[2, i].Value);

                    // NUEVO
                    row["Grupo_Trabajo"] = ValorString(dataGridView1[3, i].Value);

                    row["Cod_Grupo_Labor"] = ValorString(dataGridView1[4, i].Value);
                    row["Grupo_Labor"] = ValorString(dataGridView1[5, i].Value);
                    row["Cod_Labor"] = ValorString(dataGridView1[6, i].Value);
                    row["Labor"] = ValorString(dataGridView1[7, i].Value);
                    row["Labor_Correcta"] = ValorString(dataGridView1[8, i].Value);
                    row["Uni_Med"] = ValorString(dataGridView1[9, i].Value);
                    row["Cod_Cultivo"] = ValorString(dataGridView1[10, i].Value);
                    row["Cultivo"] = ValorString(dataGridView1[11, i].Value);

                    row["Fecha"] = ValorDate(dataGridView1[12, i].Value);

                    row["DNI_Supervisor"] = ValorString(dataGridView1[13, i].Value);
                    row["Supervisor"] = ValorString(dataGridView1[14, i].Value);

                    row["Fec_Inicio"] = ValorDate(dataGridView1[15, i].Value);
                    row["Fec_Fin"] = ValorDate(dataGridView1[16, i].Value);

                    row["Horas_efectivas"] = ValorString(dataGridView1[17, i].Value);
                    row["Total_Horas"] = ValorString(dataGridView1[18, i].Value);

                    row["Dni_Responsable"] = ValorString(dataGridView1[19, i].Value);
                    row["Responsable"] = ValorString(dataGridView1[20, i].Value);

                    row["Dni"] = ValorString(dataGridView1[21, i].Value);
                    row["Ape_Nom"] = ValorString(dataGridView1[22, i].Value);

                    row["Avance"] = ValorDecimal(dataGridView1[23, i].Value);

                    row["Motivo_Salida"] = ValorString(dataGridView1[24, i].Value);
                    row["Tipo_Labor"] = ValorString(dataGridView1[25, i].Value);
                    row["Cabezal"] = ValorString(dataGridView1[26, i].Value);
                    row["CodCentroCosto"] = ValorString(dataGridView1[27, i].Value);
                    row["CentroCosto"] = ValorString(dataGridView1[28, i].Value);
                    row["Observacion"] = ValorString(dataGridView1[29, i].Value);

                    row["Hoja"] = comboBox_Hojas.Text.Trim();
                    row["Estado"] = "S";

                    row["FecEdit"] = fechaSistema;
                    row["UseEdit"] = usuario;

                    row["HostName"] = hostname;
                    row["FecCre"] = fechaSistema;
                    row["UseReg"] = usuario;

                    dt.Rows.Add(row);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No existen registros para guardar.",
                        "REGISTRO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                // BULK
                objcnlog.GuardarTareoDetalladoBulk(dt);

                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro(
                        $"GUARDADO ({dt.Rows.Count:N0} REGISTROS)",
                        Color.FromArgb(12, 19, 214),
                        1
                    );

                ng.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el tareo detallado:\n\n" +
                    ex.Message +
                    "\n\nDetalle:\n" +
                    ex.ToString(),
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dataGridView1.AllowUserToAddRows = true;
            }
        }

        private DataTable CrearDataTableTareoDetallado()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Empresa", typeof(string));
            dt.Columns.Add("Sede", typeof(string));
            dt.Columns.Add("Fundo", typeof(string));
            dt.Columns.Add("Grupo_Trabajo", typeof(string));
            dt.Columns.Add("Cod_Grupo_Labor", typeof(string));
            dt.Columns.Add("Grupo_Labor", typeof(string));
            dt.Columns.Add("Cod_Labor", typeof(string));
            dt.Columns.Add("Labor", typeof(string));
            dt.Columns.Add("Labor_Correcta", typeof(string));
            dt.Columns.Add("Uni_Med", typeof(string));
            dt.Columns.Add("Cod_Cultivo", typeof(string));
            dt.Columns.Add("Cultivo", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("DNI_Supervisor", typeof(string));
            dt.Columns.Add("Supervisor", typeof(string));
            dt.Columns.Add("Fec_Inicio", typeof(DateTime));
            dt.Columns.Add("Fec_Fin", typeof(DateTime));
            dt.Columns.Add("Horas_efectivas", typeof(string));
            dt.Columns.Add("Total_Horas", typeof(string));
            dt.Columns.Add("Dni_Responsable", typeof(string));
            dt.Columns.Add("Responsable", typeof(string));
            dt.Columns.Add("Dni", typeof(string));
            dt.Columns.Add("Ape_Nom", typeof(string));
            dt.Columns.Add("Avance", typeof(decimal));
            dt.Columns.Add("Motivo_Salida", typeof(string));
            dt.Columns.Add("Tipo_Labor", typeof(string));
            dt.Columns.Add("Cabezal", typeof(string));
            dt.Columns.Add("CodCentroCosto", typeof(string));
            dt.Columns.Add("CentroCosto", typeof(string));
            dt.Columns.Add("Observacion", typeof(string));
            dt.Columns.Add("Hoja", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("FecEdit", typeof(DateTime));
            dt.Columns.Add("UseEdit", typeof(int));
            dt.Columns.Add("HostName", typeof(string));
            dt.Columns.Add("FecCre", typeof(DateTime));
            dt.Columns.Add("UseReg", typeof(int));

            return dt;
        }

        private string ValorString(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return "";

            return valor.ToString().Trim().ToUpper();
        }

        private object ValorDate(object valor)
        {
            if (valor == null || valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                return DBNull.Value;

            DateTime fecha;

            if (DateTime.TryParse(valor.ToString(), out fecha))
                return fecha;

            return DBNull.Value;
        }

        private object ValorDecimal(object valor)
        {
            if (valor == null || valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                return DBNull.Value;

            decimal numero;

            if (decimal.TryParse(
                valor.ToString(),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.CurrentCulture,
                out numero))
            {
                return numero;
            }

            return DBNull.Value;
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
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

                reader.Close();
            }
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
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


        private void textBox_dni_agregar_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}
