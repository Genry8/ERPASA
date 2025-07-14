using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Sistema
{
    public partial class Frm_Cargar_Contrato : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_equipoti objcnlog = new cn_equipoti();
        string TipoAlimento;

        public Frm_Cargar_Contrato()
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
        }

        private void Frm_Cargar_Contrato_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            textRuta_Contrato.Enabled = false;
            textBox_CodContrato.Enabled = false;
            ToolStripButton_Descargar_Contratos.Enabled = false;
            toolStripLabel_Descargar_Contratos.Enabled = false;

            //textRuta_Contrato.CharacterCasing = CharacterCasing.Upper;
            textBox_Proveedor.CharacterCasing = CharacterCasing.Upper;
            textBox_Contrato.CharacterCasing = CharacterCasing.Upper;
            textBox_CodContrato.CharacterCasing = CharacterCasing.Upper;
            textBox_filtro_proveedor.CharacterCasing = CharacterCasing.Upper;

            comboBox_Renovar_Contrato.SelectedIndex = 0;
            comboBox_Renovar_Contrato.DropDownStyle = ComboBoxStyle.DropDownList;
            //CargarDTG();
            toolStripButton_buscar.PerformClick();
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

            //if (textRuta_Contrato.Text != "")
            //{
            //    dataGridView1.Columns.Clear();
            //    dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
            //    dataGridView1.ClearSelection();
            //    if (dataGridView1.Rows.Count > 1)
            //    {
            //        label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
            //    }
            //}
            //else
            //{
            //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

            //dataGridView1.AllowUserToAddRows = false;

            if (textRuta_Contrato.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA RUTA DE DOCUMENTO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Proveedor.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA PROVEEDOR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Contrato.Text == "")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA NOMBRE CONTRATO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    GuardarContrato(textRuta_Contrato.Text);
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

        }

        public void GuardarContrato(string filepath)
        {
            DateTime currentDateTime = DateTime.Now.Date;


            using (Stream stream = File.OpenRead(filepath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                var fi = new FileInfo(filepath);
                string exth = fi.Extension;
                string filename = fi.Name;

                string idDoc = textBox_CodContrato.Text;
                if (idDoc == "")
                {
                    idDoc = "0";
                }
                else
                {
                    idDoc = textBox_CodContrato.Text;
                }

                var extcont = cn_equipoti.BuscExisteDocContrato(Convert.ToInt32(idDoc));

                if (extcont == true)
                {
                    string MessageBoxTitle = "ACTUALIZAR";
                    string MessageBoxContent = "¿Desea Actualizar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objcnlog.ActualizarContratoDocumento(
                    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    Convert.ToInt32(textBox_CodContrato.Text),//Id
                    buffer,//DATA
                    exth,//EXTENSION
                    filename,
                    textBox_Proveedor.Text.ToString().Trim(),//Proveedor
                    textBox_Contrato.Text.ToString().Trim(),//Contrato
                    textRuta_Contrato.Text.ToString().Trim(),//ruta
                    dateTimePicker_Fec_Inicio_Contrato.Value.Date,
                    dateTimePicker_Fec_Fin_Contrato.Value.Date,
                    comboBox_Renovar_Contrato.Text,
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    //ce_usuario.HostName(),
                    //ce_usuario.FechaSistema(),
                    //0,
                    //0
                    );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    textBox_CodContrato.Text = "";

                    label_renovar_contrato.Visible = false;
                    comboBox_Renovar_Contrato.Visible = false;

                }

                else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                {
                    string MessageBoxTitle = "GUARDAR";
                    string MessageBoxContent = "¿Desea Guardar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objcnlog.GuardarContratoDocumento(
                    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    buffer,//DATA
                    exth,//EXTENSION
                    filename,
                    textBox_Proveedor.Text.ToString().Trim(),//Proveedor
                    textBox_Contrato.Text.ToString().Trim(),//Contrato
                    textRuta_Contrato.Text.ToString().Trim(),//ruta
                    dateTimePicker_Fec_Inicio_Contrato.Value.Date,
                    dateTimePicker_Fec_Fin_Contrato.Value.Date,
                    "NO",
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod,
                    ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    0
                    );

                    }

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                }
            }


            CargarDTG();
            LimpiarTodo();
        }

        public void CargarDTG()
        {
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_equipoti.ListaContratoDocumento("%"); //Filtrar por proveedor

            dataGridView1.Columns[6].Visible = false;
            //OrigenColorfila();
            dataGridView1.ClearSelection();

            if (dataGridView1.Rows.Count > 0)
            {
                label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
            }
            else
            {
                label_cantreg.Text = "0 REGISTROS";
            }

        }

        public void OrigenColorfila()
        {
            int c = dataGridView1.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView1.Rows[i].Cells[22].Value.ToString() == "ANULADO")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        public void LimpiarTodo()
        {
            textRuta_Contrato.Text = "";
            textBox_Proveedor.Text = "";
            textBox_Contrato.Text = "";
            textBox_CodContrato.Text = "";
            toolStripLabel_Descargar_Contratos.Enabled = false;
            ToolStripButton_Descargar_Contratos.Enabled = false;
            label_renovar_contrato.Visible = false;
            comboBox_Renovar_Contrato.Visible = false;
            dateTimePicker_Fec_Inicio_Contrato.Value = DateTime.Now;
            dateTimePicker_Fec_Fin_Contrato.Value = DateTime.Now;
            //dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = null;
            //ColumnasDtgv1();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            toolStripLabel_Descargar_Contratos.Enabled = false;
            ToolStripButton_Descargar_Contratos.Enabled = false;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            textRuta_Contrato.Text = dlg.FileName;

            dataGridView1.ClearSelection();
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

        private void textBox_filtro_proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = cn_equipoti.ListaContratoDocumento(textBox_filtro_proveedor.Text); //Filtrar por proveedor
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.Columns[6].Visible = false;
                //OrigenColorfila();
                dataGridView1.ClearSelection();

                ToolStripButton_Descargar_Contratos.Enabled = false;
                toolStripLabel_Descargar_Contratos.Enabled = false;


                if (dataGridView1.Rows.Count > 0)
                {
                    label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
                }
                else
                {
                    label_cantreg.Text = "0 REGISTROS";
                }

            }
        }

        private void textBox_filtro_proveedor_Enter(object sender, EventArgs e)
        {
            if (textBox_filtro_proveedor.Text == "FILTRO POR PROVEEDOR")
            {
                textBox_filtro_proveedor.Text = "";
                textBox_filtro_proveedor.ForeColor = Color.Black;
                textBox_filtro_proveedor.Font = new Font(textBox_filtro_proveedor.Font, FontStyle.Regular);
            }
        }

        private void textBox_filtro_proveedor_Leave(object sender, EventArgs e)
        {
            if (textBox_filtro_proveedor.Text == "")
            {
                textBox_filtro_proveedor.Text = "FILTRO POR PROVEEDOR";
                textBox_filtro_proveedor.ForeColor = Color.DarkGray;
                textBox_filtro_proveedor.Font = new Font(textBox_filtro_proveedor.Font, FontStyle.Regular);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ToolStripButton_Descargar_Contratos.Enabled = true;
            toolStripLabel_Descargar_Contratos.Enabled = true;
        }

        private void ToolStripButton_Descargar_Contratos_Click(object sender, EventArgs e)
        {
            var selectdrow = dataGridView1.SelectedRows;
            foreach (var row in selectdrow)
            {
                int id = (int)((DataGridViewRow)row).Cells[0].Value;
                cn_equipoti.BuscarDocumentoContrato(Convert.ToInt32(id));
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_CodContrato.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textRuta_Contrato.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_Proveedor.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_Contrato.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            dateTimePicker_Fec_Inicio_Contrato.Value =
                Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value).Date;

            dateTimePicker_Fec_Fin_Contrato.Value =
                Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value).Date;

            comboBox_Renovar_Contrato.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FILA SELECCIONADO", Color.FromArgb(238, 24, 24), 3);
            //ng.ShowDialog();
            label_renovar_contrato.Visible = true;
            comboBox_Renovar_Contrato.Visible = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "DiasVencimiento")
            {
                if (Convert.ToInt32(e.Value.ToString()) <= 60)
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.DarkRed;
                    //e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
                else
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            //textBox_filtro_proveedor.Text = "";
            CargarDTG();
            LimpiarTodo();
            dataGridView1.ClearSelection();
        }

        private void comboBox_Renovar_Contrato_SelectionChangeCommitted(object sender, EventArgs e)
        {
            objcnlog.ActualizarContratoDocumentoEstado(
                    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    Convert.ToInt32(textBox_CodContrato.Text),//Id
                    comboBox_Renovar_Contrato.Text, //Estado
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    //ce_usuario.HostName(),
                    //ce_usuario.FechaSistema(),
                    //0,
                    //0
                    );
        }
    }
}
