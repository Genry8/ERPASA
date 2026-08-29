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
    public partial class Frm_Cargar_Metas : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_administracion objcnlog = new cn_administracion();

        public Frm_Cargar_Metas()
        {
            InitializeComponent();
        }

        private void Frm_Cargar_Metas_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro
            comboBox_cabezal_localidad.SelectedIndex = 0;
            textRuta.Enabled = false;
            textBox_ruta_accidente.Enabled = false;
            textBox_ruta_MetaSector.Enabled = false;
            textBox_ruta_localidad.Enabled = false;
            textBox_Ruta_Meta_Pers_TempFijo.Enabled = false;
            textBox_ruta_meta_avance.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_meta_labor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas_MetaSector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_hojas_localidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_cabezal_localidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hoja__Meta_Pers_TempFijo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_hoja_meta_avance.DropDownStyle = ComboBoxStyle.DropDownList;


            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa_variedad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa_meta_avance.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Empresa_Sector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede_Variedad.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Sede_Sector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_fundo_labor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Empresa_Meta_Pers_TempFijo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede_Meta_Pers_TempFijo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede_meta_avance.DropDownStyle = ComboBoxStyle.DropDownList;

            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA CHARLA
            comboBox_empresa_variedad.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa_variedad.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa_variedad.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            ////CARGAR EMPRESA ACTO
            //comboBox_Empresa_Sector.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //comboBox_Empresa_Sector.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_Empresa_Sector.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


            //CARGAR FUNDO
            comboBox_fundo_labor.DataSource = cn_logistica.ListaCBFundo();
            comboBox_fundo_labor.DisplayMember = "Fundo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_fundo_labor.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR META PERSONAL
            comboBox_Empresa_Meta_Pers_TempFijo.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_Empresa_Meta_Pers_TempFijo.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Empresa_Meta_Pers_TempFijo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //CARGAR META AVANCE
            comboBox_empresa_meta_avance.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa_meta_avance.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa_meta_avance.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
                    //if (comboBox_empresa_variedad.Text == "SELECCIONE")
                    //{
                    //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    //    ng.ShowDialog();
                    //}
                    //else if (comboBox_Sede_Variedad.Text == "SELECCIONE")
                    //{
                    //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                    //    ng.ShowDialog();
                    //}
                    //else {

                    //}
                    GuardarMetaVariedad();
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

        public void GuardarMetaVariedad()
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

                    var exchar = cn_administracion.BuscExisteMetaVariedad(
                        dataGridView1[0, i].Value.ToString(), //ID ACTIVIDAD
                        dataGridView1[2, i].Value.ToString(), //CODIGO
                        Convert.ToDateTime(dataGridView1[7, i].Value) //SEMANA
                        );

                    if (exchar == true)
                    {
                        if (dataGridView1[5, i].Value.ToString() == "")
                        {
                            dataGridView1[5, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView1[5, i].Value);
                        }
                        if (dataGridView1[6, i].Value.ToString() == "")
                        {
                            dataGridView1[6, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView1[6, i].Value);
                        }
                        if (dataGridView1[9, i].Value.ToString() == "")
                        {
                            dataGridView1[9, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView1[9, i].Value);
                        }
                        objcnlog.ActualizarMetaVariedad(
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//ID
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//CABEZAL
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//CODIGO
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//VARIEDAD
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//PRESENTACION
                        Convert.ToDecimal(dataGridView1[5, i].Value),//JAB
                        Convert.ToDecimal(dataGridView1[6, i].Value),//KG
                        Convert.ToDateTime(dataGridView1[7, i].Value),//FECHA INI
                        Convert.ToDateTime(dataGridView1[8, i].Value),//FECHA FIN
                        Convert.ToDecimal(dataGridView1[9, i].Value),//KG JAB
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//SEMANA

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
                        if (dataGridView1[5, i].Value.ToString() == "")
                        {
                            dataGridView1[5, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView1[5, i].Value);
                        }
                        if (dataGridView1[6, i].Value.ToString() == "")
                        {
                            dataGridView1[6, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView1[6, i].Value);
                        }
                        if (dataGridView1[9, i].Value.ToString() == "")
                        {
                            dataGridView1[9, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView1[9, i].Value);
                        }

                        objcnlog.GuardarMetaVariedad(
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//ID
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//CABEZAL
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//CODIGO
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//VARIEDAD
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//PRESENTACION
                        Convert.ToDecimal(dataGridView1[5, i].Value),//JAB
                        Convert.ToDecimal(dataGridView1[6, i].Value),//KG
                        Convert.ToDateTime(dataGridView1[7, i].Value),//FECHA INI
                        Convert.ToDateTime(dataGridView1[8, i].Value),//FECHA FIN
                        Convert.ToDecimal(dataGridView1[9, i].Value),//KG JAB
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//SEMANA

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

            if (textBox_ruta_accidente.Text != "")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = dtsTablas.Tables[comboBox_meta_labor.SelectedIndex];
                dataGridView2.ClearSelection();
                if (dataGridView2.Rows.Count > 1)
                {
                    label_cantreg_accidente.Text = (dataGridView2.RowCount - 1).ToString() + " REGISTROS";
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

                textBox_ruta_accidente.Text = oOpenFileDialog.FileName;

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

                comboBox_meta_labor.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_meta_labor.Items.Add(tabla.TableName);
                }
                comboBox_meta_labor.SelectedIndex = 0;

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
                    GuardarMetaLabor();
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


        public void GuardarMetaLabor()
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

                    var exchar = cn_administracion.BuscExisteMetaLabor(
                        comboBox_fundo_labor.Text, //FUNDO
                        dataGridView2[0, i].Value.ToString(), //LABOR
                        Convert.ToDateTime(dataGridView2[1, i].Value) //FECHA INI
                        );

                    if (exchar == true)
                    {

                        if (dataGridView2[4, i].Value.ToString() == "")
                        {
                            dataGridView2[4, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView2[4, i].Value);
                        }
                        objcnlog.ActualizarMetaLabor(
                        comboBox_fundo_labor.Text,//CABEZAL
                        dataGridView2[0, i].Value.ToString().ToUpper().Trim(),//LABOR
                        Convert.ToDateTime(dataGridView2[1, i].Value),//FECHA INI
                        Convert.ToDateTime(dataGridView2[2, i].Value),//FECHA FIN
                        dataGridView2[3, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView2[4, i].Value),//META

                        comboBox_meta_labor.Text,
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

                        if (dataGridView2[4, i].Value.ToString() == "")
                        {
                            dataGridView2[4, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView2[4, i].Value);
                        }

                        objcnlog.GuardarMetaLabor(
                        comboBox_fundo_labor.Text,//CABEZAL
                        dataGridView2[0, i].Value.ToString().ToUpper().Trim(),//LABOR
                        Convert.ToDateTime(dataGridView2[1, i].Value),//FECHA INI
                        Convert.ToDateTime(dataGridView2[2, i].Value),//FECHA FIN
                        dataGridView2[3, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView2[4, i].Value),//META

                        comboBox_meta_labor.Text,
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


            dataGridView2.AllowUserToAddRows = true;

        }


        private void toolStripButton_MostarActoCondicion_Click(object sender, EventArgs e)
        {
            if (textBox_ruta_MetaSector.Text != "")
            {
                dataGridView3.Columns.Clear();
                dataGridView3.DataSource = dtsTablas.Tables[comboBox_Hojas_MetaSector.SelectedIndex];
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
                    GuardarMetaSector();
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

                textBox_ruta_MetaSector.Text = oOpenFileDialog.FileName;

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

                comboBox_Hojas_MetaSector.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas_MetaSector.Items.Add(tabla.TableName);
                }
                comboBox_Hojas_MetaSector.SelectedIndex = 0;

                reader.Close();
            }
        }



        public void GuardarMetaSector()
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
                    var exchar = cn_administracion.BuscExisteMetaSector(
                        dataGridView3[0, i].Value.ToString(), //labor
                        dataGridView3[1, i].Value.ToString(), //sector
                        dataGridView3[2, i].Value.ToString(), //fundo
                        Convert.ToInt32(dataGridView3[5, i].Value) //semana
                        );

                    if (exchar == true)
                    {

                        if (dataGridView3[6, i].Value.ToString() == "")
                        {
                            dataGridView3[6, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView3[6, i].Value);
                        }

                        objcnlog.ActualizarMetaSector(
                        dataGridView3[0, i].Value.ToString().ToUpper().Trim(),//labor
                        dataGridView3[1, i].Value.ToString().ToUpper().Trim(),//sector
                        dataGridView3[2, i].Value.ToString().ToUpper().Trim(),//fundo
                        Convert.ToDateTime(dataGridView3[3, i].Value),//FECHA ini
                        Convert.ToDateTime(dataGridView3[4, i].Value),//FECHA fin
                        dataGridView3[5, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView3[6, i].Value),//cantidad

                        comboBox_hojas_localidad.Text,
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

                        if (dataGridView3[6, i].Value.ToString() == "")
                        {
                            dataGridView3[6, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView3[6, i].Value);
                        }

                        objcnlog.GuardarMetaSector(
                        dataGridView3[0, i].Value.ToString().ToUpper().Trim(),//labor
                        dataGridView3[1, i].Value.ToString().ToUpper().Trim(),//sector
                        dataGridView3[2, i].Value.ToString().ToUpper().Trim(),//fundo
                        Convert.ToDateTime(dataGridView3[3, i].Value),//FECHA ini
                        Convert.ToDateTime(dataGridView3[4, i].Value),//FECHA fin
                        dataGridView3[5, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView3[6, i].Value),//cantidad

                        comboBox_hojas_localidad.Text,
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
            if (comboBox_empresa_variedad.Text == comboBox_empresa_variedad.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_Sede_Variedad.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa_variedad.Text);
                comboBox_Sede_Variedad.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Sede_Variedad.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }


        private void toolStripButton_localidad_Click(object sender, EventArgs e)
        {

            if (textBox_ruta_localidad.Text != "")
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = dtsTablas.Tables[comboBox_hojas_localidad.SelectedIndex];
                dataGridView4.ClearSelection();
                if (dataGridView4.Rows.Count > 1)
                {
                    label_cantidad_localidad.Text = (dataGridView4.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_guardar_localidad_Click(object sender, EventArgs e)
        {

            dataGridView4.AllowUserToAddRows = false;

            if (dataGridView4.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    //if (comboBox_empresa_variedad.Text == "SELECCIONE")
                    //{
                    //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    //    ng.ShowDialog();
                    //}
                    //else if (comboBox_Sede_Variedad.Text == "SELECCIONE")
                    //{
                    //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                    //    ng.ShowDialog();
                    //}
                    //else {

                    //}
                    GuardarMetaLocalidad();
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


        public void GuardarMetaLocalidad()
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

                    var exchar = cn_administracion.BuscExisteMetaLocalidad(
                        comboBox_cabezal_localidad.Text, //CABEZAL
                        dataGridView4[0, i].Value.ToString(), //CODIGO
                        Convert.ToDateTime(dataGridView4[1, i].Value) //FECHA
                        );

                    if (exchar == true)
                    {

                        if (dataGridView4[3, i].Value.ToString() == "")
                        {
                            dataGridView4[3, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView4[3, i].Value);
                        }
                        objcnlog.ActualizarMetaLocalidad(
                        comboBox_cabezal_localidad.Text,//CABEZAL
                        dataGridView4[0, i].Value.ToString().ToUpper().Trim(),//LOCALIDAD
                        Convert.ToDateTime(dataGridView4[1, i].Value),//FECHA
                        dataGridView4[2, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView4[3, i].Value),//HORAS

                        comboBox_hojas_localidad.Text,
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

                        if (dataGridView4[3, i].Value.ToString() == "")
                        {
                            dataGridView4[3, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView4[3, i].Value);
                        }

                        objcnlog.GuardarMetaLocalidad(
                        comboBox_cabezal_localidad.Text,//CABEZAL
                        dataGridView4[0, i].Value.ToString().ToUpper().Trim(),//LOCALIDAD
                        Convert.ToDateTime(dataGridView4[1, i].Value),//FECHA
                        dataGridView4[2, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView4[3, i].Value),//HORAS

                        comboBox_hojas_localidad.Text,
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


            dataGridView4.AllowUserToAddRows = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView4.DataSource = null;

                textBox_ruta_localidad.Text = oOpenFileDialog.FileName;

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

                comboBox_hojas_localidad.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_hojas_localidad.Items.Add(tabla.TableName);
                }
                comboBox_hojas_localidad.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void button_buscar__Meta_Pers_TempFijo_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView5.DataSource = null;

                textBox_Ruta_Meta_Pers_TempFijo.Text = oOpenFileDialog.FileName;

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

                comboBox_Hoja__Meta_Pers_TempFijo.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hoja__Meta_Pers_TempFijo.Items.Add(tabla.TableName);
                }
                comboBox_Hoja__Meta_Pers_TempFijo.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (textBox_Ruta_Meta_Pers_TempFijo.Text != "")
            {
                dataGridView5.Columns.Clear();
                dataGridView5.DataSource = dtsTablas.Tables[comboBox_Hoja__Meta_Pers_TempFijo.SelectedIndex];
                dataGridView5.ClearSelection();
                if (dataGridView5.Rows.Count > 1)
                {
                    label_Meta_Pers_TempFijo.Text = (dataGridView5.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void comboBox_Empresa_Meta_Pers_TempFijo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Empresa_Meta_Pers_TempFijo.Text == comboBox_Empresa_Meta_Pers_TempFijo.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_Sede_Meta_Pers_TempFijo.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_Empresa_Meta_Pers_TempFijo.Text);
                comboBox_Sede_Meta_Pers_TempFijo.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Sede_Meta_Pers_TempFijo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }


        private void comboBox_empresa_meta_avance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa_meta_avance.Text == comboBox_empresa_meta_avance.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_sede_meta_avance.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa_meta_avance.Text);
                comboBox_sede_meta_avance.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede_meta_avance.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            dataGridView5.AllowUserToAddRows = false;

            if (dataGridView5.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_Empresa_Meta_Pers_TempFijo.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_Sede_Meta_Pers_TempFijo.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarMetaPersFijoTemporal();
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


        public void GuardarMetaPersFijoTemporal()
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

                    var exchar = cn_administracion.BuscExistePersFijoTemporal(
                        comboBox_Empresa_Meta_Pers_TempFijo.Text, //empresa
                        comboBox_Sede_Meta_Pers_TempFijo.Text, //sede
                        dataGridView5[0, i].Value.ToString(), //area
                        dataGridView5[1, i].Value.ToString(), //tipo personal
                        Convert.ToInt32(dataGridView5[4, i].Value) //semana
                        );

                    if (exchar == true)
                    {

                        if (dataGridView5[5, i].Value.ToString() == "")
                        {
                            dataGridView5[5, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView5[5, i].Value);
                        }

                        objcnlog.ActualizarMetaPersFijoTemporal(
                        comboBox_Empresa_Meta_Pers_TempFijo.Text,//empresa
                        comboBox_Sede_Meta_Pers_TempFijo.Text,//sede
                        dataGridView5[0, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView5[1, i].Value.ToString().ToUpper().Trim(),//tipo personal
                        Convert.ToDateTime(dataGridView5[2, i].Value),//FECHA ini
                        Convert.ToDateTime(dataGridView5[3, i].Value),//FECHA fin
                        dataGridView5[4, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView5[5, i].Value),//cantidad

                        comboBox_hojas_localidad.Text,
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

                        if (dataGridView5[5, i].Value.ToString() == "")
                        {
                            dataGridView5[5, i].Value = 0;
                        }
                        else
                        {
                            Convert.ToDecimal(dataGridView5[5, i].Value);
                        }

                        objcnlog.GuardarMetaPersFijoTemporal(
                        comboBox_Empresa_Meta_Pers_TempFijo.Text,//empresa
                        comboBox_Sede_Meta_Pers_TempFijo.Text,//sede
                        dataGridView5[0, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView5[1, i].Value.ToString().ToUpper().Trim(),//tipo personal
                        Convert.ToDateTime(dataGridView5[2, i].Value),//FECHA ini
                        Convert.ToDateTime(dataGridView5[3, i].Value),//FECHA fin
                        dataGridView5[4, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        Convert.ToDecimal(dataGridView5[5, i].Value),//cantidad

                        comboBox_hojas_localidad.Text,
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


            dataGridView5.AllowUserToAddRows = true;

        }

        private void button_buscar_meta_avance_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView6.DataSource = null;

                textBox_ruta_meta_avance.Text = oOpenFileDialog.FileName;

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

                comboBox_hoja_meta_avance.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_hoja_meta_avance.Items.Add(tabla.TableName);
                }
                comboBox_hoja_meta_avance.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (textBox_ruta_meta_avance.Text != "")
            {
                dataGridView6.Columns.Clear();
                dataGridView6.DataSource = dtsTablas.Tables[comboBox_hoja_meta_avance.SelectedIndex];
                dataGridView6.ClearSelection();
                if (dataGridView6.Rows.Count > 1)
                {
                    label_meta_avance.Text = (dataGridView5.RowCount - 1).ToString() + " REGISTROS";
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        private void toolStripButton_guardar_meta_avance_Click(object sender, EventArgs e)
        {

            dataGridView6.AllowUserToAddRows = false;

            if (dataGridView6.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_empresa_meta_avance.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else if (comboBox_sede_meta_avance.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        GuardarMetaAvance();
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



        public void GuardarMetaAvance()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView6.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    var exchar = cn_administracion.BuscExisteMetaAvance(
                        comboBox_empresa_meta_avance.Text,//empresa
                        comboBox_sede_meta_avance.Text,//sede
                        dataGridView6[0, i].Value.ToString(), //labor
                        dataGridView6[1, i].Value.ToString(), //area
                        Convert.ToInt32(dataGridView6[7, i].Value) //semana
                        );

                    if (dataGridView6[5, i].Value.ToString() == "")
                    {
                        dataGridView6[5, i].Value = 0;
                    }
                    if (dataGridView6[6, i].Value.ToString() == "")
                    {
                        dataGridView6[6, i].Value = 0;
                    }

                    if (exchar == true)
                    {

                        objcnlog.ActualizarMetaAvance(
                        comboBox_empresa_meta_avance.Text,//empresa
                        comboBox_sede_meta_avance.Text,//sede
                        dataGridView6[0, i].Value.ToString().ToUpper().Trim(),//labor
                        dataGridView6[1, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView6[2, i].Value.ToString().ToUpper().Trim(),//tipo bono
                        Convert.ToDateTime(dataGridView6[3, i].Value),//FECHA ini
                        Convert.ToDateTime(dataGridView6[4, i].Value),//FECHA fin
                        Convert.ToDecimal(dataGridView6[5, i].Value),//meta
                        Convert.ToDecimal(dataGridView6[6, i].Value),//horas
                        Convert.ToInt32(dataGridView6[7, i].Value),//semana

                        comboBox_hoja_meta_avance.Text,
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

                        objcnlog.GuardarMetaAvance(
                        comboBox_empresa_meta_avance.Text,//empresa
                        comboBox_sede_meta_avance.Text,//sede
                        dataGridView6[0, i].Value.ToString().ToUpper().Trim(),//labor
                        dataGridView6[1, i].Value.ToString().ToUpper().Trim(),//area
                        dataGridView6[2, i].Value.ToString().ToUpper().Trim(),//tipo bono
                        Convert.ToDateTime(dataGridView6[3, i].Value),//FECHA ini
                        Convert.ToDateTime(dataGridView6[4, i].Value),//FECHA fin
                        Convert.ToDecimal(dataGridView6[5, i].Value),//meta
                        Convert.ToDecimal(dataGridView6[6, i].Value),//horas
                        Convert.ToInt32(dataGridView6[7, i].Value),//semana

                        comboBox_hoja_meta_avance.Text,
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


            dataGridView6.AllowUserToAddRows = true;

        }




    }
}
