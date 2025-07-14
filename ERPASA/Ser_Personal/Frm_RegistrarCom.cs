using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_RegistrarCom : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;

        public Frm_RegistrarCom()
        {
            InitializeComponent();
        }

        private void Frm_RegistrarCom_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_TipoProgramacion.SelectedIndex = 0;
            comboBox_tipo.SelectedIndex = 0;
            comboBox_eliminar_tipo_alimento.SelectedIndex = 0;
            comboBox_agregar_tipo_alimento.SelectedIndex = 0;
            //poner osucro

            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_TipoProgramacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_eliminar_tipo_alimento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_agregar_tipo_alimento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede_Comedor.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA

                comboBox_Sede_Comedor.DataSource = cn_logistica.ListaSedeComedorEmpresa(
                    comboBox_empresa.Text, comboBox_tipo.Text);
                comboBox_Sede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Sede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
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
            if (comboBox_Sede_Comedor.Text == "COMEDOR")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE COMEDOR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            else if (comboBox_tipo.Text == "EMPLEADO" & comboBox_Sede_Comedor.Text.Substring(0, 8) != "PARRILLA")
            {
                Msbox.Frm_NotificacionesPeligroImg ng = new Msbox.Frm_NotificacionesPeligroImg("EMPLEADO NO PUEDE CARGARSE A PRINCIPAL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_tipo.Text == "OBRERO" & comboBox_Sede_Comedor.Text.Substring(0, 8) == "PARRILLA")
            {
                Msbox.Frm_NotificacionesPeligroImg ng = new Msbox.Frm_NotificacionesPeligroImg("OBRERO NO PUEDE CARGARSE A PARRILLA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                dataGridView1.AllowUserToAddRows = false;

                if (dataGridView1.Rows.Count >= 1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        GuardarAlmuerzo();
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
        }

        public void GuardarAlmuerzo()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            if (dateTimePicker_Comedor_F_Prog.Value.Date >= currentDateTime.Date)
            {
                if (comboBox_tipo.Text != "SELECCIONE")
                {
                    if (comboBox_Sede_Comedor.Text != "COMEDOR")
                    {
                        if (comboBox_TipoProgramacion.Text == "PROGRAMADO")
                        {

                            if (comboBox_Hojas.Text.Substring(0, 9) == "ADICIONAL")
                            {
                                if (dateTimePicker_Comedor_F_Prog.Value.Date == currentDateTime.Date) //==
                                {
                                    string MessageBoxTitle = "REGISTRO";
                                    string MessageBoxContent = "¿Desea Guardar Adicional?";

                                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                                        int a;
                                        for (int i = 0; i <= filas - 1; i++)
                                        //foreach (DataGridViewRow dr in dataGridView1.Rows)
                                        {
                                            //cn_logistica.BuscExistePersonalComedor(textBox_Dni.Text.Trim(), comboBox_tipo.Text, comboBox_CodSede_Comedor.Text, currentDateTime);
                                            var existePro = cn_logistica.BuscExistePersonalProgramado(Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(), comboBox_Sede_Comedor.Text, dateTimePicker_Comedor_F_Prog.Value.Date);
                                            if (existePro == true)
                                            {
                                                objcnlog.ActualizarPersonalComedor(
                                                    Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                                                    dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//APELLIDOS Y NOMBRES
                                                    dateTimePicker_Comedor_F_Prog.Value.Date,//FECHA
                                                    comboBox_tipo.Text,
                                                    comboBox_empresa.Text,
                                                    comboBox_Sede_Comedor.Text,
                                                    dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//AREA
                                                    comboBox_TipoProgramacion.Text.Trim(),//EST_DES
                                                    dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//DESAYUNO
                                                    comboBox_TipoProgramacion.Text.Trim(),//EST_ALM
                                                    dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ALMUERZO
                                                    comboBox_TipoProgramacion.Text.Trim(),//EST_CEN
                                                    dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//CENA
                                                    comboBox_Hojas.Text,//TIPO HOJA
                                                    "", //OBS
                                                    "S",
                                                    ce_usuario.FechaSistema(),
                                                    ce_usuario.usecod
                                                );

                                            }

                                            else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                                            {
                                                objcnlog.GuardarPersonalComedor(
                                                Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                                                dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//APELLIDOS Y NOMBRES
                                                dateTimePicker_Comedor_F_Prog.Value.Date,//FECHA
                                                comboBox_tipo.Text,
                                                comboBox_empresa.Text,
                                                comboBox_Sede_Comedor.Text,
                                                dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//AREA
                                                comboBox_TipoProgramacion.Text.Trim(),//EST_DES
                                                dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//DESAYUNO
                                                comboBox_TipoProgramacion.Text.Trim(),//EST_ALM
                                                dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ALMUERZO
                                                comboBox_TipoProgramacion.Text.Trim(),//EST_CEN
                                                dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//CENA
                                                comboBox_Hojas.Text,//TIPO HOJA
                                                "",
                                                "S",
                                                ce_usuario.FechaSistema(),
                                                ce_usuario.usecod,
                                                ce_usuario.HostName(),
                                                ce_usuario.FechaSistema(),
                                                0,
                                                0
                                                );

                                            }
                                        }

                                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ADICIONAL GUARDADO", Color.FromArgb(12, 19, 214), 1);
                                        ng.ShowDialog();
                                    }
                                }
                                else
                                {
                                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SOLO ADMITE LA FECHA DE HOY", Color.FromArgb(238, 24, 24), 3);
                                    ng.ShowDialog();
                                }

                            }

                            else
                            {
                                if (dateTimePicker_Comedor_F_Prog.Value.Date >= currentDateTime.Date)
                                {
                                    string MessageBoxTitle = "REGISTRO";
                                    string MessageBoxContent = "¿Desea Guardar Registros?";

                                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        objcnlog.EliminarRegistroComedorFecha(dateTimePicker_Comedor_F_Prog.Value.Date, comboBox_tipo.Text, comboBox_empresa.Text, comboBox_Sede_Comedor.Text);
                                        int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                                        int a;
                                        for (int i = 0; i <= filas - 1; i++)
                                        //foreach (DataGridViewRow dr in dataGridView1.Rows)
                                        {
                                            if (dataGridView1[3, i].Value.ToString().ToUpper().Trim() != "SI")
                                            {
                                                dataGridView1[3, i].Value = "";
                                            }
                                            if (dataGridView1[4, i].Value.ToString().ToUpper().Trim() != "SI")
                                            {
                                                dataGridView1[4, i].Value = "";
                                            }
                                            if (dataGridView1[5, i].Value.ToString().ToUpper().Trim() != "SI")
                                            {
                                                dataGridView1[5, i].Value = "";
                                            }
                                            objcnlog.GuardarPersonalComedor(
                                                    Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                                                    dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//APELLIDOS Y NOMBRES
                                                    dateTimePicker_Comedor_F_Prog.Value.Date,//FECHA
                                                    comboBox_tipo.Text,
                                                    comboBox_empresa.Text,
                                                    comboBox_Sede_Comedor.Text,
                                                    dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//AREA
                                                    comboBox_TipoProgramacion.Text.Trim(),//EST_DES
                                                    dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//DESAYUNO
                                                    comboBox_TipoProgramacion.Text.Trim(),//EST_ALM
                                                    dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ALMUERZO
                                                    comboBox_TipoProgramacion.Text.Trim(),//EST_CEN
                                                    dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//CENA
                                                    comboBox_Hojas.Text,//TIPO HOJA
                                                    "",
                                                    "S",
                                                    ce_usuario.FechaSistema(),
                                                    ce_usuario.usecod,
                                                    ce_usuario.HostName(),
                                                    ce_usuario.FechaSistema(),
                                                    0,
                                                    0
                                                    );
                                        }

                                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("DATOS GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                                        ng.ShowDialog();
                                    }
                                }

                                else
                                {
                                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FECHA NO VALIDO", Color.FromArgb(238, 24, 24), 3);
                                    ng.ShowDialog();
                                }

                            }
                        }
                        else
                        {
                            if (dateTimePicker_Comedor_F_Prog.Value.Date == currentDateTime.Date) //==
                            {

                                string MessageBoxTitle = "REGISTRO";
                                string MessageBoxContent = "¿Desea Guardar NO PROGRAMADO?";

                                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                                    int a;
                                    for (int i = 0; i <= filas - 1; i++)
                                    //foreach (DataGridViewRow dr in dataGridView1.Rows)
                                    {

                                        var existePr = cn_logistica.BuscExistePersonalProgramado(dataGridView1[0, i].Value.ToString().Trim(), comboBox_Sede_Comedor.Text, dateTimePicker_Comedor_F_Prog.Value.Date);
                                        if (existePr == true)
                                        {
                                            objcnlog.ActualizarPersonalComedor(
                                                Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                                                dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//APELLIDOS Y NOMBRES
                                                dateTimePicker_Comedor_F_Prog.Value.Date,//FECHA
                                                comboBox_tipo.Text,
                                                comboBox_empresa.Text,
                                                comboBox_Sede_Comedor.Text,
                                                dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//AREA
                                                comboBox_TipoProgramacion.Text.Trim(),//EST_DES
                                                dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//DESAYUNO
                                                comboBox_TipoProgramacion.Text.Trim(),//EST_ALM
                                                dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ALMUERZO
                                                comboBox_TipoProgramacion.Text.Trim(),//EST_CEN
                                                dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//CENA
                                                comboBox_Hojas.Text,//TIPO HOJA
                                                "", //OBS
                                                "S",
                                                ce_usuario.FechaSistema(),
                                                ce_usuario.usecod
                                            );

                                        }

                                        else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                                        {
                                            objcnlog.GuardarPersonalComedor(
                                            Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                                            dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//APELLIDOS Y NOMBRES
                                            dateTimePicker_Comedor_F_Prog.Value.Date,//FECHA
                                            comboBox_tipo.Text,
                                            comboBox_empresa.Text,
                                            comboBox_Sede_Comedor.Text,
                                            dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//AREA
                                            comboBox_TipoProgramacion.Text.Trim(),//EST_DES
                                            dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//DESAYUNO
                                            comboBox_TipoProgramacion.Text.Trim(),//EST_ALM
                                            dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ALMUERZO
                                            comboBox_TipoProgramacion.Text.Trim(),//EST_CEN
                                            dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//CENA
                                            comboBox_Hojas.Text,//TIPO HOJA
                                            "",
                                            "S",
                                            ce_usuario.FechaSistema(),
                                            ce_usuario.usecod,
                                            ce_usuario.HostName(),
                                            ce_usuario.FechaSistema(),
                                            0,
                                            0
                                            );

                                        }

                                        if (dataGridView1[3, i].Value.ToString().ToUpper().Trim() == "SI")
                                        {
                                            TipoAlimento = "DESAYUNO";
                                        }
                                        else if (dataGridView1[4, i].Value.ToString().ToUpper().Trim() == "SI")
                                        {
                                            TipoAlimento = "ALMUERZO";
                                        }
                                        else if (dataGridView1[5, i].Value.ToString().ToUpper().Trim() == "SI")
                                        {
                                            TipoAlimento = "CENA";
                                        }

                                        cn_logistica.BuscExistePedateoPersonalComedor(Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(), currentDateTime, TipoAlimento);
                                        if (Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim() == ce_logistica.CodPedateoExist & TipoAlimento == ce_logistica.CodPedateoTiExist)
                                        {
                                            //
                                        }
                                        else
                                        {

                                            cn_logistica.BuscExistePedateoPersonalComedorAlimento(Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(), currentDateTime, TipoAlimento);
                                            if (Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim() == ce_logistica.CodPedateoExistAlimento & TipoAlimento == ce_logistica.CodPedateoTipoAlimentoExist)
                                            {
                                                objcnlog.GuardarPedateoPersonalComedor(
                                                Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                                                dataGridView1[1, i].Value.ToString(),//ce_logistica.NombresUsuario,//APELLIDOS Y NOMBRES
                                                ce_logistica.FechaIngreso,//FECHA
                                                TipoAlimento, //TIPO ALIMENTO
                                                ce_logistica.TipoHoja,//TIPO HOJA
                                                ce_logistica.CodTiExist,
                                                currentDateTime,
                                                ce_logistica.UsuarioEmpresa,
                                                comboBox_Sede_Comedor.Text,
                                                ce_logistica.UsuarioArea,
                                                ce_logistica.PrecioMar,
                                                "NO PROGRAMADO",//OBS
                                                "S",
                                                ce_usuario.FechaSistema(),
                                                ce_usuario.usecod,
                                                ce_usuario.HostName(),
                                                ce_usuario.FechaSistema(),
                                                0,
                                                0
                                                );
                                            }

                                        }
                                    }

                                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                                    ng.ShowDialog();
                                }
                            }
                            else
                            {
                                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SOLO ADMITE LA FECHA DE HOY", Color.FromArgb(238, 24, 24), 3);
                                ng.ShowDialog();
                            }
                        }

                    }
                    else
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE COMEDOR", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                }
                else
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE TIPO PERSONAL", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FECHA NO VALIDO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;

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


        private void button_eliminar_alimento_Click(object sender, EventArgs e)
        {
            if (comboBox_eliminar_tipo_alimento.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE TIPO ALIMENTO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            if (comboBox_Sede_Comedor.Text == "COMEDOR")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                if (textBox_Dni_eliminar.TextLength < 8)
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("EL DNI DEBE TENER 8 DIGITOS ", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }
                else
                {
                    EliminarRegistroComidaPersonal();
                }
            }
        }


        public void EliminarRegistroComidaPersonal()
        {
            string des, alm, cen;
            if (comboBox_eliminar_tipo_alimento.Text == "DESAYUNO")
            {
                des = "SI";
            }
            else
            {
                des = "NO";
            }
            if (comboBox_eliminar_tipo_alimento.Text == "ALMUERZO")
            {
                alm = "SI";
            }
            else
            {
                alm = "NO";
            }
            if (comboBox_eliminar_tipo_alimento.Text == "CENA")
            {
                cen = "SI";
            }
            else
            {
                cen = "NO";
            }
            string MessageBoxTitle = "ELIMINAR";
            string MessageBoxContent = "¿Desea Eliminar Alimento?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                var existeP = cn_logistica.BuscExistePersonalProgramado(textBox_Dni_eliminar.Text.Trim(), comboBox_Sede_Comedor.Text, ce_usuario.FechaSistema().Date);
                if (existeP == true)
                {
                    objcnlog.ActualizarPersonalComedorEliminar(
                        textBox_Dni_eliminar.Text.Trim(),//DNI
                        ce_usuario.FechaSistema().Date,//FECHA
                        des,
                        alm,
                        cen,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                    );

                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar(comboBox_eliminar_tipo_alimento.Text + " ELIMINADO CORRECTAMENTE ", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }
                else
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("USUARIO NO TIENE PROGRAMACION", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }


            }

        }

        private void textBox_Dni_TextChanged(object sender, EventArgs e)
        {
            ce_logistica.NombresUsuario = "...";
            if (comboBox_Sede_Comedor.Text == "COMEDOR")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Dni_eliminar.TextLength == 8)
            {
                //ce_logistica.NombresUsuario = "";
                cn_logistica.BuscExistePersonalProgramado(textBox_Dni_eliminar.Text.Trim(), comboBox_Sede_Comedor.Text, ce_usuario.FechaSistema().Date);
                label_nombre_eliminado.Text = ce_comedor.ApeNom;
            }
            else
            {

                label_nombre_eliminado.Text = "...";
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

        private void button_agregar_alimento_Click(object sender, EventArgs e)
        {
            if (comboBox_agregar_tipo_alimento.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE TIPO ALIMENTO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            if (comboBox_Sede_Comedor.Text == "COMEDOR")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                if (textBox_dni_agregar.TextLength < 8)
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("EL DNI DEBE TENER 8 DIGITOS ", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }
                else
                {
                    AgregarRegistroComidaPersonal();
                }
            }
        }


        public void AgregarRegistroComidaPersonal()
        {
            string desa, almu, cena;
            if (comboBox_agregar_tipo_alimento.Text == "DESAYUNO")
            {
                desa = "SI";
            }
            else
            {
                desa = "NO";
            }
            if (comboBox_agregar_tipo_alimento.Text == "ALMUERZO")
            {
                almu = "SI";
            }
            else
            {
                almu = "NO";
            }
            if (comboBox_agregar_tipo_alimento.Text == "CENA")
            {
                cena = "SI";
            }
            else
            {
                cena = "NO";
            }
            string MessageBoxTitle = "AGREGAR";
            string MessageBoxContent = "¿Desea Agregar Alimento?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                var existeProg = cn_logistica.BuscExistePersonalProgramado(textBox_dni_agregar.Text.Trim(), comboBox_Sede_Comedor.Text, ce_usuario.FechaSistema().Date);
                if (existeProg == true)
                {
                    objcnlog.ActualizarPersonalComedorAgregar(
                        textBox_dni_agregar.Text.Trim(),//DNI
                        ce_usuario.FechaSistema().Date,//FECHA
                        desa,
                        almu,
                        cena,
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                    );

                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar(comboBox_agregar_tipo_alimento.Text + " AGREGADO CORRECTAMENTE ", Color.FromArgb(12, 19, 214), 1);
                    ng.Show();

                }
                else
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("USUARIO NO TIENE PROGRAMACION", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }

            }

        }

        private void textBox_dni_agregar_TextChanged(object sender, EventArgs e)
        {
            ce_logistica.NombresUsuario = "...";
            if (comboBox_Sede_Comedor.Text == "COMEDOR")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_dni_agregar.TextLength == 8)
            {
                //ce_logistica.NombresUsuario = "";
                cn_logistica.BuscExistePersonalProgramado(textBox_dni_agregar.Text.Trim(), comboBox_Sede_Comedor.Text, ce_usuario.FechaSistema().Date);
                label_nombre_agregar.Text = ce_comedor.ApeNom;
            }
            else
            {

                label_nombre_agregar.Text = "...";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Empresa();
        }
    }
}
