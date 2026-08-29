using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_EditarMantCorrectivo : Form, VarDatosEntroFormVehiculo
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();

        public frm_EditarMantCorrectivo()
        {
            InitializeComponent();
        }

        private void frm_EditarMantCorrectivo_Load(object sender, EventArgs e)
        {
            comboBox_empresa.Text = ce_taller.empresa;
            comboBox_sede.Text = ce_taller.sede;
            //PonerOscuroComboBox();
            //CargarDatosComboBox();
            //AgregarColumna();
            textBox_Id.Text = ce_taller.idVeh;
            textBox_Vehiculo.Text = ce_taller.DescripcionVehiculo;
            dateTimePicker_FechaIng.Value = ce_taller.FecIng;
            dateTimePicker_FechaSal.Value = ce_taller.FecSal;
            textBox_DiasInoperativo.Text = ce_taller.diasInop;
            textBox_HrsInoperativo.Text = ce_taller.hrsInop;
            comboBox_Status.Text = ce_taller.status;
            comboBox_Sistema.Text = ce_taller.sistema;
            comboBox_Sustento.Text = ce_taller.sustento;
            comboBox_TipoCorrectivo.Text = ce_taller.tipocorrectivo;
            comboBox_TipoFalla.Text = ce_taller.tipofalla;
            textBox_Costo.Text = ce_taller.costo;
            comboBox_labor.Text = ce_taller.labor;
            comboBox_implemento.Text = ce_taller.implemento;

            textBox_DetalleMotivo.Text = ce_taller.detalleObs;

        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Status.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sistema.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sustento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoCorrectivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoFalla.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_labor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_implemento.DropDownStyle = ComboBoxStyle.DropDownList;
            //textBox_Id.Enabled = false;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            textBox_DiasInoperativo.Text = "0";
            textBox_HrsInoperativo.Text = "0";

            comboBox_Status.DataSource = cn_taller.ListaStatusCorrectivo();
            comboBox_Status.DisplayMember = "Status"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Status.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Sistema.DataSource = cn_taller.ListaSistemaCorrectivo();
            comboBox_Sistema.DisplayMember = "Sistema"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Sistema.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Sustento.DataSource = cn_taller.ListaSustentoCorrectivo();
            comboBox_Sustento.DisplayMember = "Sustento"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Sustento.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_TipoCorrectivo.DataSource = cn_taller.ListaTipoCorrectivo();
            comboBox_TipoCorrectivo.DisplayMember = "Tipo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_TipoCorrectivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_TipoFalla.DataSource = cn_taller.ListaTipoFallaCorrectivo();
            comboBox_TipoFalla.DisplayMember = "TipoFalla"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_TipoFalla.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_labor.DataSource = cn_taller.ListaLabor();
            comboBox_labor.DisplayMember = "Labor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_labor.ValueMember = "Labor"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            AlertaGuardarCorrectivo();
        }

        public void AlertaGuardarCorrectivo()
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
            else if (textBox_DiasInoperativo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DIAS INOPERATIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Kilometraje.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KILOMETRAJE", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Vehiculo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DESCRIPCION DE VEHICULO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_HrsInoperativo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA HORAS INOPERATIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Costo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE COSTO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_DetalleMotivo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE DETALLE MOTIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                string MessageBoxTitle = "ACTUALIZAR";
                string MessageBoxContent = "¿Desea actualizar?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcntaller.ActualizarMantenimientoCorrectivo(
                        label_Id.Text,
                    dateTimePicker_FechaIng.Text,
                    dateTimePicker_FechaSal.Text,
                    comboBox_empresa.Text,//EMPRESA
                    comboBox_sede.Text,//SEDE
                    textBox_Id.Text.Trim(),//idveh
                    textBox_DiasInoperativo.Text.Trim(),//dias
                    textBox_HrsInoperativo.Text.Trim(),//horas
                    textBox_Kilometraje.Text.Trim(),//Kilometraje
                    comboBox_Status.Text.Trim(),//status
                    comboBox_Sistema.Text.Trim(),//sistema
                    comboBox_Sustento.Text.Trim(),//sustento
                    comboBox_TipoCorrectivo.Text.Trim(),//tipo
                    comboBox_TipoFalla.Text.Trim(),//falla
                    textBox_Costo.Text.Trim(),//costo
                    comboBox_labor.Text.Trim(),
                    comboBox_implemento.Text.Trim(),
                    textBox_DetalleMotivo.Text.Trim(),//obs

                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    );

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    this.Close();
                    //LimpiarTextBox();
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



        public void CalcularResultado()
        {
            if (dateTimePicker_FechaIng.Value.Date == dateTimePicker_FechaSal.Value.Date)
            {
                textBox_DiasInoperativo.Text = "0";
            }
            else
            {

                DateTime fecIni, fecFin;
                TimeSpan result;
                int dias; double hrs;

                fecIni = dateTimePicker_FechaIng.Value.Date;
                fecFin = dateTimePicker_FechaSal.Value.Date;
                result = fecFin - fecIni;
                dias = result.Days;
                hrs = result.Days * 8;

                textBox_DiasInoperativo.Text = dias.ToString();
                textBox_HrsInoperativo.Text = hrs.ToString();

            }
        }

        public void ColorResultado()
        {
            decimal kmIni, kmFin, Diferencia;
            kmIni = Convert.ToDecimal(textBox_DiasInoperativo.Text);
            kmFin = Convert.ToDecimal(textBox_HrsInoperativo.Text);
            //Diferencia = Convert.ToDecimal(textBox_Diferencia.Text);

            //if (Diferencia < 0)
            //{
            //    textBox_Diferencia.ForeColor = Color.Red;
            //}
            //else
            //{
            //    textBox_Diferencia.ForeColor = Color.Black;
            //}
        }

        public void LimpiarTextBox()
        {
            textBox_DiasInoperativo.Text = "0";
            textBox_HrsInoperativo.Text = "0";
            textBox_Id.Text = "";
            textBox_Vehiculo.Text = "";
            textBox_Costo.Text = "";
            textBox_DetalleMotivo.Text = "";
        }

        private void textBox_Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }


        private void textBox_HrsInoperativo_MouseEnter(object sender, EventArgs e)
        {
            CalcularResultado();
        }

        private void textBox_HrsInoperativo_MouseMove(object sender, MouseEventArgs e)
        {
            CalcularResultado();
        }

        private void textBox_HrsInoperativo_TabIndexChanged(object sender, EventArgs e)
        {
            CalcularResultado();
        }

        private void comboBox_labor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_implemento.DataSource = cn_taller.ListaLaborImplemento(comboBox_labor.Text);
            comboBox_implemento.DisplayMember = "Implemento"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_implemento.ValueMember = "Implemento"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }
    }
    internal interface VarDatosEntroFormVehiculoCoE
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a);
    }

}
