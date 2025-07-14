using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_SST
{
    public partial class Frm_Cargar_SSTScorcard : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        public Frm_Cargar_SSTScorcard()
        {
            InitializeComponent();
        }

        private void Frm_Cargar_SSTScorcard_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            comboBox_area.SelectedIndex = 0;

            textRuta.Enabled = false;
            textBox_ruta_ReglaOro.Enabled = false;
            textBox_ruta_acto.Enabled = false;
            textBox_ruta_percepcion.Enabled = false;
            textBox_ruta_inspecciones.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_ReglaOro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_Acto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_Percepcion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_Inspecciones.DropDownStyle = ComboBoxStyle.DropDownList;


            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_emp_acto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_acto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            comboBox_emp_reglaoro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_reglaoro.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            comboBox_emp_percepcion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_percepcion.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            comboBox_emp_inspecciones.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_inspecciones.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA CHARLA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA ACTO
            comboBox_emp_acto.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_acto.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_acto.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA REGLA ORO
            comboBox_emp_reglaoro.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_reglaoro.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_reglaoro.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA PERCEPCION
            comboBox_emp_percepcion.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_percepcion.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_percepcion.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR EMPRESA INSPECCION
            comboBox_emp_inspecciones.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_emp_inspecciones.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_emp_inspecciones.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


            //CARGAR AREA

            //comboBox_area.DataSource = cn_logistica.ListaCBAreaTodoAsignacionTI();
            //comboBox_area.DisplayMember = "DesArea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_area.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


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
                    if (comboBox_empresa.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_CodSede.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarCharla();
                    }
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

        public void GuardarCharla()
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

                    var exchar = cn_planilla.BuscExisteCharla(
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_CodSede.Text,//SEDE
                        dataGridView1[1, i].Value.ToString(),//area
                        Convert.ToDateTime(dataGridView1[5, i].Value), //fecha
                        dataGridView1[2, i].Value.ToString() //TIPO
                        );

                    if (exchar == true)
                    {

                        objcnlog.ActualizarCharla(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//ID
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_CodSede.Text,//SEDE
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION
                        Convert.ToInt32(dataGridView1[3, i].Value),//NUM TRAB
                        Convert.ToInt32(dataGridView1[4, i].Value),//NUM EJECUTADO
                        Convert.ToDateTime(dataGridView1[5, i].Value),//FECHA
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas.Text,
                        "",
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

                        objcnlog.GuardarCharla(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//ID
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_CodSede.Text,//SEDE
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION
                        Convert.ToInt32(dataGridView1[3, i].Value),//NUM TRAB
                        Convert.ToInt32(dataGridView1[4, i].Value),//NUM EJECUTADO
                        Convert.ToDateTime(dataGridView1[5, i].Value),//FECHA
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas.Text,
                        "",
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

        private void toolStripButton_MostarAccidenteIncidente_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_ReglaOro.Text != "")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtsTablas.Tables[comboBox_Hojas_ReglaOro.SelectedIndex];
                dataGridView2.ClearSelection();
                if (dataGridView2.Rows.Count > 1)
                {
                    label_cantreg_reglaOro.Text = (dataGridView2.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        private void btnBuscar_accidente_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView2.DataSource = null;

                textBox_ruta_ReglaOro.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_ReglaOro.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_ReglaOro.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_ReglaOro.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton_GuardarAccidenteIncidente_Click(object sender, EventArgs e)
        {

            dataGridView2.AllowUserToAddRows = false;

            if (dataGridView2.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_reglaoro.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_reglaoro.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarReglaOro();
                    }
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

        private void toolStripButton_LimpiarAccidenteIncidente_Click(object sender, EventArgs e)
        {

        }


        public void GuardarReglaOro()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarReglaOro(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        Convert.ToInt32(dataGridView2[0, i].Value.ToString().Trim()),//ID
                        comboBox_emp_reglaoro.Text,//EMPRESA
                        comboBox_sede_reglaoro.Text,//SEDE
                        dataGridView2[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView2[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION

                        dataGridView2[3, i].Value.ToString().Trim(),//NUM TRAB
                        dataGridView2[4, i].Value.ToString().Trim(),//NUM COMPROMISO
                        Convert.ToDateTime(dataGridView2[5, i].Value),//FECHA
                        dataGridView2[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas_ReglaOro.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();

            }


            dataGridView2.AllowUserToAddRows = true;

        }



        private void toolStripButton_MostarActoCondicion_Click(object sender, EventArgs e)
        {
            if (textBox_ruta_acto.Text != "")
            {
                dataGridView3.Columns.Clear();
                dataGridView3.DataSource = dtsTablas.Tables[comboBox_Hojas_Acto.SelectedIndex];
                dataGridView3.ClearSelection();
                if (dataGridView3.Rows.Count > 1)
                {
                    label_cantreg_acto.Text = (dataGridView3.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_GuardarActoCondicion_Click(object sender, EventArgs e)
        {

            dataGridView3.AllowUserToAddRows = false;

            if (dataGridView3.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    GuardarActoCondicion();
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

        private void btnBuscar_Acto_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView3.DataSource = null;

                textBox_ruta_acto.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_Acto.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_Acto.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Acto.SelectedIndex = 0;

                reader.Close();
            }
        }



        public void GuardarActoCondicion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView3.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    var exchar = cn_planilla.BuscExisteActoCondicion(
                        dataGridView3[0, i].Value.ToString().Trim(), //Cod
                        Convert.ToDateTime(dataGridView3[9, i].Value).Date,//Fecha
                        comboBox_emp_acto.Text, comboBox_sede_acto.Text,
                        dataGridView3[1, i].Value.ToString().Trim()
                        );
                    if (exchar == true)
                    {
                        if (dataGridView3[13, i].Value.ToString() == "")
                        {
                            dataGridView3[13, i].Value = "1990-01-01";
                        }
                        else
                        {
                            dataGridView3[13, i].Value = dataGridView3[13, i].Value;
                        }

                        objcnlog.ActualizarActoCondicion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView3[0, i].Value.ToString().ToUpper().Trim(),//ID
                        Convert.ToInt32(dataGridView3[14, i].Value),//SEMANA
                        comboBox_emp_acto.Text,//EMPRESA
                        comboBox_sede_acto.Text,//SEDE
                        dataGridView3[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView3[2, i].Value.ToString().ToUpper().Trim(),//INCIDENCIA
                        dataGridView3[3, i].Value.ToString().ToUpper().Trim(),//HALLAZGO
                        dataGridView3[4, i].Value.ToString().ToUpper().Trim(),//PELIGRO
                        dataGridView3[5, i].Value.ToString().ToUpper().Trim(),//TIPO JERARAQUIA
                        dataGridView3[6, i].Value.ToString().ToUpper().Trim(),//HALLAZGO_DESVIACION --
                        dataGridView3[7, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA ---
                        dataGridView3[8, i].Value.ToString().ToUpper().Trim(),//RESPONSABLE
                        Convert.ToDateTime(dataGridView3[9, i].Value),//FEC REP
                        dataGridView3[10, i].Value.ToString().ToUpper().Trim(),//ESTADO INSPECCION
                        dataGridView3[11, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA 2 ---
                        dataGridView3[12, i].Value.ToString().ToUpper().Trim(),//EVIDENCIA
                        Convert.ToDateTime(dataGridView3[13, i].Value),//FEC LEVANT

                        comboBox_Hojas_Acto.Text,
                        "",
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
                        if (dataGridView3[13, i].Value.ToString() == "")
                        {
                            dataGridView3[13, i].Value = "1990-01-01";
                        }
                        else
                        {
                            dataGridView3[13, i].Value = dataGridView3[13, i].Value;
                        }

                        objcnlog.GuardarActoCondicion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        dataGridView3[0, i].Value.ToString().ToUpper().Trim(),//ID
                        Convert.ToInt32(dataGridView3[14, i].Value),//SEMANA
                        comboBox_emp_acto.Text,//EMPRESA
                        comboBox_sede_acto.Text,//SEDE
                        dataGridView3[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView3[2, i].Value.ToString().ToUpper().Trim(),//INCIDENCIA
                        dataGridView3[3, i].Value.ToString().ToUpper().Trim(),//HALLAZGO
                        dataGridView3[4, i].Value.ToString().ToUpper().Trim(),//PELIGRO
                        dataGridView3[5, i].Value.ToString().ToUpper().Trim(),//TIPO JERARAQUIA
                        dataGridView3[6, i].Value.ToString().ToUpper().Trim(),//HALLAZGO_DESVIACION
                        dataGridView3[7, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA
                        dataGridView3[8, i].Value.ToString().ToUpper().Trim(),//RESPONSABLE
                        Convert.ToDateTime(dataGridView3[9, i].Value),//FEC REP
                        dataGridView3[10, i].Value.ToString().ToUpper().Trim(),//ESTADO INSPECCION
                        dataGridView3[11, i].Value.ToString().ToUpper().Trim(),//MEDIDA CORRECTIVA 2
                        dataGridView3[12, i].Value.ToString().ToUpper().Trim(),//EVIDENCIA
                        Convert.ToDateTime(dataGridView3[13, i].Value),//FEC LEVANT

                        comboBox_Hojas_Acto.Text,
                        "",
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


            dataGridView3.AllowUserToAddRows = true;

        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_CodSede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_CodSede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_CodSede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_emp_acto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_acto.Text == comboBox_emp_acto.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_acto.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_acto.Text);
                comboBox_sede_acto.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_acto.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void btnBuscar_Percepcion_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView4.DataSource = null;

                textBox_ruta_percepcion.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_Percepcion.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_Percepcion.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Percepcion.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton_Mostrar_PercepcionRiesgo_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_percepcion.Text != "")
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = dtsTablas.Tables[comboBox_Hojas_Percepcion.SelectedIndex];
                dataGridView4.ClearSelection();
                if (dataGridView4.Rows.Count > 1)
                {
                    label_cantreg_Percepcion.Text = (dataGridView4.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_Guardar_PercepcionRiesgo_Click(object sender, EventArgs e)
        {

            dataGridView4.AllowUserToAddRows = false;

            if (dataGridView4.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_percepcion.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_percepcion.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarPercepcion();
                    }
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



        public void GuardarPercepcion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView4.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarPercepcion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        Convert.ToInt32(dataGridView4[0, i].Value.ToString().Trim()),//ID
                        comboBox_emp_percepcion.Text,//EMPRESA
                        comboBox_sede_percepcion.Text,//SEDE
                        dataGridView4[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView4[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION

                        dataGridView4[3, i].Value.ToString().Trim(),//NUM TRAB
                        dataGridView4[4, i].Value.ToString().Trim(),//NUM COMPROMISO
                        Convert.ToDateTime(dataGridView4[5, i].Value),//FECHA
                        dataGridView4[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas_Percepcion.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();

            }


            dataGridView4.AllowUserToAddRows = true;

        }


        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Inspecciones_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView5.DataSource = null;

                textBox_ruta_inspecciones.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_Inspecciones.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_Inspecciones.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_Inspecciones.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton_Mostrar_Inspecciones_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_inspecciones.Text != "")
            {
                dataGridView5.Columns.Clear();
                dataGridView5.DataSource = dtsTablas.Tables[comboBox_Hojas_Inspecciones.SelectedIndex];
                dataGridView5.ClearSelection();
                if (dataGridView5.Rows.Count > 1)
                {
                    label_cantreg_Inspecciones.Text = (dataGridView5.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_Guardar_Inspecciones_Click(object sender, EventArgs e)
        {

            dataGridView5.AllowUserToAddRows = false;

            if (dataGridView5.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_emp_inspecciones.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_inspecciones.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarInspeccion();
                    }
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

        public void GuardarInspeccion()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView5.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    objcnlog.GuardarInspeccion(
                        //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                        Convert.ToInt32(dataGridView5[0, i].Value.ToString().Trim()),//ID
                        comboBox_emp_inspecciones.Text,//EMPRESA
                        comboBox_sede_inspecciones.Text,//SEDE
                        dataGridView5[1, i].Value.ToString().ToUpper().Trim(),//AREA
                        dataGridView5[2, i].Value.ToString().ToUpper().Trim(),//TIPO EVALUACION

                        dataGridView5[3, i].Value.ToString().Trim(),//NUM TRAB
                        dataGridView5[4, i].Value.ToString().Trim(),//NUM COMPROMISO
                        Convert.ToDateTime(dataGridView5[5, i].Value),//FECHA
                        dataGridView5[6, i].Value.ToString().ToUpper().Trim(),//SEMANA

                        comboBox_Hojas_Percepcion.Text,
                        "S",
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();

            }


            dataGridView5.AllowUserToAddRows = true;

        }


        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_emp_reglaoro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_reglaoro.Text == comboBox_emp_reglaoro.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_reglaoro.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_reglaoro.Text);
                comboBox_sede_reglaoro.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_reglaoro.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_emp_percepcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_percepcion.Text == comboBox_emp_percepcion.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_percepcion.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_percepcion.Text);
                comboBox_sede_percepcion.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_percepcion.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_emp_inspecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_emp_inspecciones.Text == comboBox_emp_inspecciones.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_inspecciones.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_emp_inspecciones.Text);
                comboBox_sede_inspecciones.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_inspecciones.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }
    }
}
