using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    public partial class frm_EditarEficienciaMaquinaria : Form, VarDatosEntroFormVehiculo
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();

        public frm_EditarEficienciaMaquinaria()
        {
            InitializeComponent();
        }

        private void frm_EditarEficienciaMaquinaria_Load(object sender, EventArgs e)
        {
            comboBox_empresa.Text = ce_taller.empresa;
            comboBox_sede.Text = ce_taller.sede;
            //PonerOscuroComboBox();
            //CargarDatosComboBox();
            //AgregarColumna();
            textBox_Id.Text = ce_taller.idVeh;
            textBox_Vehiculo.Text = ce_taller.DescripcionVehiculo;
            comboBox_Turno.Text = ce_taller.turno;
            textBox_Operador.Text = ce_taller.operador;
            textBox_Cabezal.Text = ce_taller.cabezal;
            comboBox_labor.Text = ce_taller.labor;
            comboBox_implemento.Text = ce_taller.implemento;
            comboBox_tipo_labores.Text = ce_taller.tipolabor;
            textBox_Obj_Tancada.Text = ce_taller.objtancada;
            textBox_Hectarea.Text = ce_taller.hectarea;
            textBox_Galones.Text = ce_taller.galones;
            textBox_KilometrajeIni.Text = ce_taller.kmIni;
            textBox_KilometrajeFin.Text = ce_taller.kmFin;
            textBox_KmIniEfec.Text = ce_taller.kmini_efe;
            textBox_KmFinEfec.Text = ce_taller.kmfin_efe;
            textBox_HoraInicio.Text = ce_taller.horaini;
            textBox_HoraFin.Text = ce_taller.horafin;
            textBox_ObjetivoAplicacion.Text = ce_taller.obj_aplicacion;
            textBox_Observacion.Text = ce_taller.observacion;
            textBox_Indicador.Text = ce_taller.indicador;
            textBox_Descripcion.Text = ce_taller.descripcion;

        }


        public void PonerOscuroComboBox()
        {
            comboBox_Turno.SelectedIndex = 1;
            //DETALLE DE REPORTE
            comboBox_Turno.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_labor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_implemento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tipo_labores.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_labor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_implemento.DropDownStyle = ComboBoxStyle.DropDownList;
            //textBox_Id.Enabled = false;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_labor.DataSource = cn_taller.ListaLabor();
            comboBox_labor.DisplayMember = "Labor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_labor.ValueMember = "Labor"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_tipo_labores.DataSource = cn_taller.ListaTipoLabor();
            comboBox_tipo_labores.DisplayMember = "TipoLabor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_tipo_labores.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            else if (textBox_Operador.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("INGRESE OPERADOR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_implemento.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE IMPLEMENTO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Hectarea.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA CANTIDAD DE HECTAREAS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Galones.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA CANTIDAD DE GALONES", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_KilometrajeIni.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KILOMETRAJE INICIO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_KilometrajeFin.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KILOMETRAJE FINAL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_KmIniEfec.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KILOMETRAJE INICIO EFECTIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_KmFinEfec.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA KILOMETRAJE FIN EFECTIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_HoraInicio.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA HORA INICIO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_HoraFin.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA HORA FIN", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                string MessageBoxTitle = "GUARDAR";
                string MessageBoxContent = "¿Desea guardar?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    objcntaller.ActualizarEficienciaMaquinaria(
                        label_Id.Text,
                    comboBox_empresa.Text,//EMPRESA
                    comboBox_sede.Text,//SEDE
                    dateTimePicker_Fecha.Text,
                    textBox_Id.Text.Trim(),//idveh
                    comboBox_Turno.Text.Trim(),//turno
                    textBox_Operador.Text.Trim().ToUpper(),//operador
                    textBox_Cabezal.Text.Trim().ToUpper(),//cabezal
                    comboBox_labor.Text.Trim().ToUpper(),//labor
                    comboBox_implemento.Text.Trim().ToUpper(),//implemento
                    comboBox_tipo_labores.Text.Trim().ToUpper(),//tipo labor
                    textBox_Obj_Tancada.Text.Trim().ToUpper(),//obj tancada
                    textBox_Hectarea.Text.Trim(),//hectarea
                    textBox_Galones.Text.Trim(),//galones
                    textBox_KilometrajeIni.Text.Trim(),//Kilometraje ini
                    textBox_KilometrajeFin.Text.Trim(),//Kilometraje fin
                    textBox_KmIniEfec.Text.Trim(),//km ini efec
                    textBox_KmFinEfec.Text.Trim(),//km fin efec
                    textBox_HoraInicio.Text.Trim(),//hora ini
                    textBox_HoraFin.Text.Trim(),//hora fin

                    textBox_ObjetivoAplicacion.Text.Trim().ToUpper(),//obj aplicacion
                    textBox_Observacion.Text.Trim().ToUpper(),//obs
                    textBox_Indicador.Text.Trim().ToUpper(),//indicador
                    "",//sector
                    textBox_Descripcion.Text.Trim().ToUpper(),//descripcion

                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    );

                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

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
                e.KeyChar != ':'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_KmInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != ':'
                )
            {
                e.Handled = true;
            }
        }


        public void ColorResultado()
        {
            decimal kmIni, kmFin, Diferencia;
            kmIni = Convert.ToDecimal(textBox_HoraInicio.Text);
            kmFin = Convert.ToDecimal(textBox_HoraFin.Text);
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



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox_Hectarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_Galones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_KilometrajeFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_KmIniEfec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_KmFinEfec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void comboBox_labor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_implemento.DataSource = cn_taller.ListaLaborImplemento(comboBox_labor.Text);
            comboBox_implemento.DisplayMember = "Implemento"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_implemento.ValueMember = "Implemento"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }
    }

    internal interface VarDatosEntroFormVehiculoEfiActu
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a);
    }

}
