using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_AgregarInsumo : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();

        public frm_AgregarInsumo()
        {
            InitializeComponent();
        }

        private void frm_AgregarInsumo_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            CargaDatos();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_MetaKM.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_GrupoVehiculo.DataSource = cn_taller.ListaGrupoVehiculo();
            comboBox_GrupoVehiculo.DisplayMember = "Grupo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_GrupoVehiculo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_MetaKM.DataSource = cn_taller.ListaMetaKm();
            comboBox_MetaKM.DisplayMember = "Km"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_MetaKM.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMaquinaria();
            //comboBox_TipoMerma.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaMaquinariaFiler();
            //comboBox_TipoMerma.DisplayMember = "Filer"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        public void CargaDatos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
        }


        private void ColumnasDtgv1()
        {
            //DataGridViewComboBoxColumn SEDE = new DataGridViewComboBoxColumn();
            //SEDE.HeaderText = "SEDE";
            //SEDE.Name = "Column1";
            //SEDE.Width = 180;
            ////LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            //ArrayList row = new ArrayList();
            ////declara una tabla donde se llama la lista de los estados
            //DataTable dt = new DataTable();
            //dt = cn_logistica.ListaSedeComedor();

            //foreach (DataRow item in dt.Rows)
            //{
            //    row.Add(item[1].ToString());
            //}
            ////AÑADIR LA LISTA AL COMBO
            //SEDE.Items.AddRange(row.ToArray());
            ////AÑADIR EL COMBO AL DATAGRIDVIEW
            //dataGridView1.Columns.Add(SEDE);

            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Codigo = new DataGridViewTextBoxColumn();
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Codigo";
            Codigo.Width = 180;
            dataGridView1.Columns.Add(Codigo);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Descripcion = new DataGridViewTextBoxColumn();
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.Width = 280;
            dataGridView1.Columns.Add(Descripcion);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Unidad = new DataGridViewTextBoxColumn();
            Unidad.HeaderText = "Unidad";
            Unidad.Name = "Unidad";
            Unidad.Width = 87;
            dataGridView1.Columns.Add(Unidad);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Cantidad = new DataGridViewTextBoxColumn();
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 85;
            dataGridView1.Columns.Add(Cantidad);

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


        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            if (comboBox_GrupoVehiculo.Text == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE GRUPO VEHICULO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Marca.Text == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MARCA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Modelo.Text == "NO ESPECIFICA")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MODELO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            else
            {

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    BuscarReporteMantenimientoPreventivo();
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }

        }

        public void BuscarReporteMantenimientoPreventivo()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp, sed, grupo, vehiculo, marca, modelo, km;
            //if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    emp = "%";
            //}
            //else
            //{
            //    emp = comboBox_detalle_empresa.Text;
            //}
            //if (comboBox_detalle_sede.Text == "SELECCIONE")
            //{
            //    sed = "%";
            //}
            //else
            //{
            //    sed = comboBox_detalle_sede.Text;
            //}
            if (comboBox_GrupoVehiculo.Text == "NO ESPECIFICA")
            {
                grupo = "%";
            }
            else
            {
                grupo = comboBox_GrupoVehiculo.Text;
            }
            if (comboBox_Marca.Text == "NO ESPECIFICA")
            {
                marca = "%";
            }
            else
            {
                marca = comboBox_Marca.Text;
            }
            if (comboBox_Modelo.Text == "NO ESPECIFICA")
            {
                modelo = "%";
            }
            else
            {
                modelo = comboBox_Modelo.Text;
            }
            if (comboBox_MetaKM.Text == "NO ESPECIFICA")
            {
                km = "%";
            }
            else
            {
                km = comboBox_MetaKM.Text;
            }

            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_taller.ListaReporteMantemientoInsumo(
                grupo, marca, modelo, km);

            //dataGridView1.AllowUserToAddRows = false;
            //OrigenColorfila();
            dataGridView1.ClearSelection();

            //}
            //else
            //{

            //}

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarVehiculos();
        }

        public void AlertaGuardarVehiculos()
        {
            dataGridView1.AllowUserToAddRows = false;
            comboBox_GrupoVehiculo.Focus();

            if (dataGridView1.Rows.Count >= 1)
            {
                //if (comboBox_empresa.Text == "SELECCIONE")
                //{
                //    Msbox.Frm_NotificacionesPeligro ng =
                //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                //    ng.ShowDialog();
                //}
                //else if (comboBox_sede.Text == "SELECCIONE")
                //{
                //    Msbox.Frm_NotificacionesPeligro ng =
                //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                //    ng.ShowDialog();
                //}
                if (comboBox_GrupoVehiculo.Text == "NO ESPECIFICA")
                {
                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("SELECCIONE GRUPO VEHICULO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_Marca.Text == "NO ESPECIFICA")
                {
                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("SELECCIONE MARCA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_Modelo.Text == "NO ESPECIFICA")
                {
                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("SELECCIONE MODELO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else
                {
                    objcntaller.EliminarMantenimientoInsumos(
                        comboBox_GrupoVehiculo.Text.Trim(),
                        comboBox_Marca.Text.Trim(),
                        comboBox_Modelo.Text.Trim(),
                        comboBox_MetaKM.Text.Trim()
                        );

                    string MessageBoxTitle = "GUARDAR ";
                    string MessageBoxContent = "¿Desea guardar Insumo? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {

                        int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                        int a;
                        for (int i = 0; i <= filas - 1; i++)
                        //foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {

                            objcntaller.GuardarListaInsumos(
                            comboBox_empresa.Text,//EMPRESA
                            comboBox_sede.Text,//SEDE
                            comboBox_GrupoVehiculo.Text,//GRUPO
                            comboBox_Marca.Text.Trim(),//marca
                            comboBox_Modelo.Text.Trim(),//modelo

                            dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Codigo
                            dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Descripcion
                            dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Unidad
                            dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//Cantidad
                            "",//KmInicial
                            comboBox_MetaKM.Text.Trim(),//kmFinal
                            "S", //estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            0,
                            0
                            );


                        }

                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                        ng.ShowDialog();

                        dataGridView1.AllowUserToAddRows = true;

                    }

                    dataGridView1.AllowUserToAddRows = true;
                    //Cursor.Current = Cursors.WaitCursor;
                    //try
                    //{
                    //    BuscarReporteMantenimientoPreventivo();
                    //}

                    //finally
                    //{
                    //    Cursor.Current = Cursors.Default;
                    //}

                }
            }

            else
            {
                Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("FALTA AGREGAR INSUMOS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;

        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            //CargaDatos();
        }


        private void comboBox_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Marca.Text == comboBox_Marca.Text)
            {
                //CARGAR MODELO
                comboBox_Modelo.DataSource = cn_taller.ListaModeloVehiculo("1", comboBox_Marca.Text);
                comboBox_Modelo.DisplayMember = "Modelo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Modelo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void comboBox_GrupoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_GrupoVehiculo.Text == comboBox_GrupoVehiculo.Text)
            {
                comboBox_Marca.DataSource = cn_taller.ListaMarcaVehiculo("1", comboBox_GrupoVehiculo.Text);
                comboBox_Marca.DisplayMember = "Marca"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Marca.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0) // CANT-E
            {
                if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back
                )
                {
                    e.Handled = true;
                }

            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3) // CANT-E
            {
                if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
                {
                    e.Handled = true;
                }

            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
        }

        private void textBox_KmInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_KmFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView1);
        }

        public void copiar_portapapeles(DataGridView datagrid)
        {
            DataObject objeto_datos = datagrid.GetClipboardContent();
            Clipboard.SetDataObject(objeto_datos);
        }

        public void pegar_portapapeles(DataGridView datagrid)
        {
            try
            {
                string texto_copiado = Clipboard.GetText();
                string[] lineas = texto_copiado.Split('\n');
                int error = 0;
                int fila = datagrid.CurrentCell.RowIndex;
                int columna = datagrid.CurrentCell.ColumnIndex;
                DataGridViewCell objeto_celda;

                foreach (string linea in lineas)
                {
                    if (fila < datagrid.RowCount && linea.Length > 0)
                    {
                        string[] celdas = linea.Split('\t');

                        for (int indice = 0; indice < celdas.GetLength(0); ++indice)
                        {
                            if (columna + indice < datagrid.ColumnCount)
                            {
                                objeto_celda = datagrid[columna + indice, fila];

                                //Mientras celda sea Diferente de ReadOnly
                                if (!objeto_celda.ReadOnly)
                                {
                                    if (objeto_celda.Value.ToString() != celdas[indice])
                                    {
                                        objeto_celda.Value = Convert.ChangeType(celdas[indice], objeto_celda.ValueType);
                                    }
                                }
                                else
                                {
                                    // solo intercepta un error si los datos que está pegando es en una celda de solo lectura.
                                    error++;
                                }
                            }
                            else
                            { break; }
                        }
                        fila++;
                    }
                    else
                    { break; }

                    if (error > 0)
                        MessageBox.Show(string.Format("{0}  La celda no puede ser actualizada, debido a que la configuración de la columna es de solo lectura.", error),
                                                  "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException fexcepcion)
            {
                MessageBox.Show("Los datos que pegó están en el formato incorrecto para la celda." + "\n\nDETALLES: \n\n" + fexcepcion.Message,
                                "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.C)
            //{
            //    copiar_portapapeles(dataGridView1);
            //    e.Handled = true;
            //}
            //if (e.Control && e.KeyCode == Keys.V)
            //{
            //    pegar_portapapeles(dataGridView1);
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                CargaDatos();
                //dataGridView1.DataSource = null;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string MessageBoxTitle = "CARGAR INSUMOS";
            string MessageBoxContent = "¿Desea reemplazar la lista de insumos?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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


        }
    }
}
