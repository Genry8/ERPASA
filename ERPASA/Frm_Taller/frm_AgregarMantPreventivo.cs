using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_AgregarMantPreventivo : Form, VarDatosEntroFormVehiculo
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();

        public frm_AgregarMantPreventivo()
        {
            InitializeComponent();
        }

        private void frm_AgregarMantPreventivo_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            //textBox_Id.Enabled = false;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            textBox_KmInicial.Text = "0";
            textBox_KmFinal.Text = "0";

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



        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            CalcularResultado();
            AlertaGuardarVehiculos();
        }

        public void AlertaGuardarVehiculos()
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
            else if (textBox_Id.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE VEHICULO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_KmInicial.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KM INICIAL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Vehiculo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DESCRIPCION DE VEHICULO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_KmFinal.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KM FINAL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                string MessageBoxTitle = "GUARDAR ";
                string MessageBoxContent = "¿Desea guardar? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcntaller.GuardarMantenimientoVehiculos(
                    dateTimePicker_Fecha.Text,
                    comboBox_empresa.Text,//EMPRESA
                    comboBox_sede.Text,//SEDE
                    "",//Area
                    textBox_Id.Text.Trim(),//idveh
                    textBox_KmInicial.Text.Trim(),//kmIni
                    textBox_KmFinal.Text.Trim(),//kmFinal
                    textBox_Diferencia.Text.Trim(),//difKm
                    textBox_Implemento.Text.Trim(),//implemento
                    textBox_CabezalArea.Text.Trim(),//cabezal area

                    "S", //estado
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod,
                    ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    0,
                    0
                    );

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    LimpiarTextBox();
                    ////AgregarColumna();
                }


            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {


        }


        private void textBox_Vehiculo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        public void TablaAgregarDatosFila(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a)
        {
            bool EncontrarFilaRepetida = false;
            string valoritem = fila1a.Cells[0].Value.ToString();
            //string valoSTOCK = fila1a.Cells[8].Value.ToString();
            //if(dataGridView2.RowCount > 0)
            //{
            textBox_Id.Text = fila1a.Cells[0].Value.ToString();
            textBox_Vehiculo.Text = fila1a.Cells[4].Value.ToString();
        }

        private void pictureBox_SeachVehiculo_Click(object sender, EventArgs e)
        {
            frm_BuscarVehiculo frbm = new frm_BuscarVehiculo();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
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


        private void textBox_Diferencia_MouseEnter(object sender, EventArgs e)
        {
            CalcularResultado();
        }

        public void CalcularResultado()
        {
            if (textBox_KmInicial.Text.Trim() == "")
            {
                textBox_KmInicial.Text = "0";
            }
            if (textBox_KmFinal.Text.Trim() == "")
            {
                textBox_KmFinal.Text = "0";
            }
            else
            {
                decimal kmIni, kmFin, Diferencia;
                kmIni = Convert.ToDecimal(textBox_KmInicial.Text);
                kmFin = Convert.ToDecimal(textBox_KmFinal.Text);
                //Diferencia = Convert.ToDecimal(textBox_Diferencia.Text);

                textBox_Diferencia.Text = Convert.ToString(kmFin - kmIni);

                ColorResultado();
            }
        }

        public void ColorResultado()
        {
            decimal kmIni, kmFin, Diferencia;
            kmIni = Convert.ToDecimal(textBox_KmInicial.Text);
            kmFin = Convert.ToDecimal(textBox_KmFinal.Text);
            Diferencia = Convert.ToDecimal(textBox_Diferencia.Text);

            if (Diferencia < 0)
            {
                textBox_Diferencia.ForeColor = Color.Red;
            }
            else
            {
                textBox_Diferencia.ForeColor = Color.Black;
            }
        }

        public void LimpiarTextBox()
        {
            textBox_KmInicial.Text = "0";
            textBox_KmFinal.Text = "0";
            textBox_Id.Text = "";
            textBox_Vehiculo.Text = "";
            textBox_Diferencia.Text = "";
            textBox_Implemento.Text = "";
            textBox_CabezalArea.Text = "";
        }

    }
    internal interface VarDatosEntroFormVehiculo
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a);
    }

}
