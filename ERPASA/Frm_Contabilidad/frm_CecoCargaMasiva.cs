using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Contabilidad
{
    public partial class frm_CecoCargaMasiva : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        public frm_CecoCargaMasiva()
        {
            InitializeComponent();
        }

        private void frm_CecoCargaMasiva_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargaDatos();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void CargaDatos()
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            label_cantreg.Text = "0 REGISTROS";
            //ColumnasDtgv1();
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
            // Column3
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Empresa";
            Empresa.Width = 280;
            dataGridView1.Columns.Add(Empresa);
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
            DataGridViewTextBoxColumn Partida = new DataGridViewTextBoxColumn();
            Partida.HeaderText = "Partida";
            Partida.Name = "Partida";
            Partida.Width = 87;
            dataGridView1.Columns.Add(Partida);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn PartidaFinal = new DataGridViewTextBoxColumn();
            PartidaFinal.HeaderText = "PartidaFinal";
            PartidaFinal.Name = "PartidaFinal";
            PartidaFinal.Width = 85;
            dataGridView1.Columns.Add(PartidaFinal);

        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                AlertaGuardarPartidas();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("CARGUE AL MENOS 1 REGISTRO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }

        public void AlertaGuardarPartidas()
        {
            dataGridView1.AllowUserToAddRows = false;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar Registros?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    objcnlog.GuardActualizarCecoConta(
                        dataGridView1[0, i].Value.ToString(),//empresa
                        "",//area sistema
                        dataGridView1[1, i].Value.ToString(),//IDCCOS
                        dataGridView1[2, i].Value.ToString(),//CCOS
                        dataGridView1[3, i].Value.ToString(),//IDCUENTA
                        dataGridView1[4, i].Value.ToString(),//partida
                        dataGridView1[5, i].Value.ToString(),//partida_final
                        dataGridView1[6, i].Value.ToString(),//sucursal
                        dataGridView1[7, i].Value.ToString(),//cultivo
                        dataGridView1[8, i].Value.ToString(),//etapa
                        "",//valid
                        dataGridView1[9, i].Value.ToString(),//tipo gasto
                        dataGridView1[10, i].Value.ToString(),//tipo estr
                        dataGridView1[11, i].Value.ToString(),//Area
                        "",//etiqueta
                        dataGridView1[12, i].Value.ToString(),//tipo recur
                        dataGridView1[13, i].Value.ToString(),//recurso
                        dataGridView1[14, i].Value.ToString(),//clasific
                        dataGridView1[15, i].Value.ToString(),//gerencia
                        "",//agrup

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


        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            CargaDatos();
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
            dataGridView1.AllowUserToAddRows = false;
            string MessageBoxTitle = "CARGAR CENTRO COSTO";
            string MessageBoxContent = "¿Desea mostrar lista de CECO?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                label_cantreg.Text = "0 REGISTROS";

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


        }
    }
}
