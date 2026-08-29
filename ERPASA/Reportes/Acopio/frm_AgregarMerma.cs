using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class frm_AgregarMerma : Form
    {
        cn_packing objcnpack = new cn_packing();
        cn_planilla objcnlog = new cn_planilla();

        public frm_AgregarMerma()
        {
            InitializeComponent();
        }

        private void frm_AgregarMerma_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Campana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoMerma.DropDownStyle = ComboBoxStyle.DropDownList;
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

            comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMerma();
            comboBox_TipoMerma.DisplayMember = "Merma"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
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
            dataGridView2.Columns.Add(Maquina);

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
            dataGridView2.Columns.Add(Variedad);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn PesoNeto = new DataGridViewTextBoxColumn();
            PesoNeto.HeaderText = "PesoNeto";
            PesoNeto.Name = "PesoNeto";
            PesoNeto.Width = 87;
            dataGridView2.Columns.Add(PesoNeto);

        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 2)
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
            if (dataGridView2.CurrentCell.ColumnIndex == 2)
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
            textBox_Obs.Focus();
            dataGridView2.AllowUserToAddRows = false;
            if (dataGridView2.Rows.Count > 0)
            {
                AlertaGuardarMermas();

            }
            else
            {
                MessageBox.Show("FALRA AGREGAR REGISTROS");
            }
            dataGridView2.AllowUserToAddRows = true;
        }

        public void AlertaGuardarMermas()
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
            else if (comboBox_TipoMerma.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE TIPO MERMA", Color.FromArgb(238, 24, 24), 3);
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

                var exchar = cn_packing.BuscExisteMerma(
                    comboBox_detalle_empresa.Text,//EMPRESA
                    comboBox_detalle_sede.Text,//SEDE
                    dateTimePicker_Fecha.Value.Date, //fecha
                    comboBox_TipoMerma.Text //TIPO
                    );

                //if (exchar == true)
                //{
                //    MessageBox.Show("YA EXISTE TIPO MERMA " + comboBox_TipoMerma.Text +
                //        " CON FECHA " + dateTimePicker_Fecha.Value.Date);
                //}
                //else
                //{

                string MessageBoxTitle = "GUARDAR " + comboBox_TipoMerma.Text;
                string MessageBoxContent = "¿Desea guardar registros? " + comboBox_TipoMerma.Text;

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int filas = dataGridView2.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                    int a;
                    for (int i = 0; i <= filas - 1; i++)
                    //foreach (DataGridViewRow dr in dataGridView2.Rows)
                    {

                        objcnpack.GuardarMerma(
                        dateTimePicker_FechaPorceso.Value.Date,//FEC PROCESO
                        dateTimePicker_Fecha.Value.Date,//FEC COSECHA
                        comboBox_TipoMerma.Text, //TIPO MATERIA
                        comboBox_detalle_empresa.Text,//EMPRESA
                        comboBox_detalle_sede.Text,//SEDE
                        comboBox_Cultivo.Text, //CULTIVO
                        comboBox_Campana.Text, //CAMPAÑA
                        dataGridView2[0, i].Value.ToString().ToUpper().Trim(),//MAQUINA
                        dataGridView2[1, i].Value.ToString().ToUpper().Trim(),//VARIEDAD
                        0,//PESO BRUTO
                        0,//PESO TARA
                        Convert.ToDecimal(dataGridView2[2, i].Value.ToString().Trim()),//PESO NETO

                        textBox_Obs.Text,
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
                    AgregarColumna();
                }

                //}

            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;
            if (dataGridView2.Rows.Count > 0)
            {
                string MessageBoxTitle = "LIMPIAR";
                string MessageBoxContent = "¿Desea limpiar registros?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    AgregarColumna();
                }

            }
            dataGridView2.AllowUserToAddRows = true;

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal a;
            decimal b;

            for (int i = 0; i <= e.RowIndex; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value == null)
                {
                    dataGridView2.Rows[i].Cells[0].Value = "UNITEC";
                }
                if (dataGridView2.Rows[i].Cells[1].Value == null)
                {
                    dataGridView2.Rows[i].Cells[1].Value = "BB3";
                }
                if (dataGridView2.Rows[i].Cells[2].Value == null)
                {
                    dataGridView2.Rows[i].Cells[2].Value = 0;
                }
            }
        }
    }
}
