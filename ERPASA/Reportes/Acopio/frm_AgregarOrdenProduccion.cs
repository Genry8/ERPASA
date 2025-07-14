using CapaEntidad;
using CapaNegocio;
using ExcelDataReader;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class frm_AgregarOrdenProduccion : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_packing objcnpack = new cn_packing();
        cn_planilla objcnlog = new cn_planilla();

        public frm_AgregarOrdenProduccion()
        {
            InitializeComponent();
        }

        private void frm_AgregarOrdenProduccion_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            textRuta.Enabled = false;
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Campana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Campana.DataSource = cn_packing.ListaCampana();
            comboBox_Campana.DisplayMember = "Campana"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Campana.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMaquinaria();
            //comboBox_TipoMerma.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaMaquinariaFiler();
            //comboBox_TipoMerma.DisplayMember = "Filer"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            //if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    //CARGAR SEDE
            //    comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //    comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }


        private void AgregarColumna()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            // 
            // Column1
            // 
            DataGridViewComboBoxColumn Maquina = new DataGridViewComboBoxColumn();
            Maquina.HeaderText = "Maquina";
            Maquina.Name = "Maquina";
            Maquina.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList row = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dt = new DataTable();
            dt = cn_packing.ListaTipoMaquinaria();

            foreach (DataRow item in dt.Rows)
            {
                row.Add(item[1].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Maquina.Items.AddRange(row.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Maquina);

            // 
            // Column2
            // 
            DataGridViewComboBoxColumn Variedad = new DataGridViewComboBoxColumn();
            Variedad.HeaderText = "Variedad";
            Variedad.Name = "Variedad";
            Variedad.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            ArrayList rowv = new ArrayList();
            //declara una tabla donde se llama la lista de los estados
            DataTable dtv = new DataTable();
            dtv = cn_packing.ListaVariedad();

            foreach (DataRow itemv in dtv.Rows)
            {
                rowv.Add(itemv[0].ToString());
            }
            //AÑADIR LA LISTA AL COMBO
            Variedad.Items.AddRange(rowv.ToArray());
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Variedad);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn PesoNeto = new DataGridViewTextBoxColumn();
            PesoNeto.HeaderText = "PesoNeto";
            PesoNeto.Name = "PesoNeto";
            PesoNeto.Width = 87;
            dataGridView1.Columns.Add(PesoNeto);

        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
                {
                    e.Handled = true;
                }
                //else
                //{
                //    if (e.KeyChar == '.')
                //    {
                //        if (((TextBox)sender).Text.Contains('.'))
                //            e.Handled = true;
                //        else
                //            e.Handled = false;
                //    }
                //}
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView2_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView2_KeyPress);
                }
            }
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.Rows.Count > 0)
            {
                AlertaGuardarOrdenPRD();
            }
            else
            {
                MessageBox.Show("FALRA AGREGAR REGISTROS");
            }
            dataGridView1.AllowUserToAddRows = true;
        }

        public void AlertaGuardarOrdenPRD()
        {
            if (comboBox_Cultivo.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE CULTIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Campana.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE CAMPAÑA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_detalle_sede.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                //var exchar = cn_packing.BuscExisteOrdenPRD(
                //    comboBox_detalle_empresa.Text,//EMPRESA
                //    comboBox_detalle_sede.Text,//SEDE
                //    dateTimePicker_FechaInicio.Value.Date, //fecha Ini
                //    dateTimePicker_FechaFin.Value.Date //fecha Fin
                //    );

                //if (exchar == true)
                //{
                //    MessageBox.Show("YA EXISTE TIPO MERMA " + comboBox_TipoMerma.Text +
                //        " CON FECHA " + dateTimePicker_Fecha.Value.Date);
                //}
                //else
                //{
                //if (exchar == false)
                //{
                string MessageBoxTitle = "GUARDAR ";
                string MessageBoxContent = "¿Desea guardar registros? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    cn_packing.EliminarOrdenPRD(
                    comboBox_detalle_empresa.Text,//EMPRESA
                    comboBox_detalle_sede.Text,//SEDE
                    dateTimePicker_FechaInicio.Value.Date, //fecha Ini
                    dateTimePicker_FechaFin.Value.Date //fecha Fin
                    );

                    int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView2.Rows)
                    {

                        objcnpack.GuardarOrdenPRD(
                        dateTimePicker_FechaInicio.Value.Date.ToString(),//FEC INI
                        dateTimePicker_FechaFin.Value.Date.ToString(),//FEC FIN
                        comboBox_Cultivo.Text, //CULTIVO
                        comboBox_Campana.Text, //CAMPAÑA
                        comboBox_detalle_empresa.Text,//EMPRESA
                        comboBox_detalle_sede.Text,//SEDE
                        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//AÑO
                        dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//SEMANA
                        dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//NUM CONTAINERS
                        dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//PRIORIDAD
                        dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//ORDEN
                        dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//CLIENTE
                        dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//DESTINO
                        dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//PRESENTACION
                        dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//COMENTARIOS
                        dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//CALIDAD
                        dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//CALIBRE
                        dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//TIMBRADO
                        dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//CAJAS
                        dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//PALLETS
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//Fecha Despacho
                        "",
                        comboBox_Hojas.Text.Trim(), //hoja
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
                    dataGridView1.DataSource = null;
                    //AgregarColumna();
                }

                //}
                //else
                //{
                //    MessageBox.Show("RANGO DE FECHA SELECCIONADA YA CUENTA CON REGISTRO","NO GUARDADO");
                //    //Msbox.Frm_NotificacionesPeligro ng =
                //    //new Msbox.Frm_NotificacionesPeligro("RANGO DE FECHAS YA CUENTA CON REGISTRO", Color.FromArgb(238, 24, 24), 3);
                //    //ng.ShowDialog();
                //}

            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.Rows.Count > 0)
            {
                string MessageBoxTitle = "LIMPIAR";
                string MessageBoxContent = "¿Desea limpiar registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    AgregarColumna();
                }

            }
            dataGridView1.AllowUserToAddRows = true;

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal a;
            decimal b;

            for (int i = 0; i <= e.RowIndex; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null)
                {
                    dataGridView1.Rows[i].Cells[0].Value = "UNITEC";
                }
                if (dataGridView1.Rows[i].Cells[1].Value == null)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "BB3";
                }
                if (dataGridView1.Rows[i].Cells[2].Value == null)
                {
                    dataGridView1.Rows[i].Cells[2].Value = 0;
                }
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
    }
}
