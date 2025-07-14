using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class frm_AgregarPresentacion : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_packing objcnpack = new cn_packing();
        cn_planilla objcnlog = new cn_planilla();
        cd_nisira objnisira = new cd_nisira();

        public frm_AgregarPresentacion()
        {
            InitializeComponent();
        }

        private void frm_AgregarPresentacion_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //AgregarColumna();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Presentacion.DropDownStyle = ComboBoxStyle.DropDownList;
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


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

            if (textBox_Peso.Text.Trim() == "")
            {
                AlertaGuardarPresentacion();
            }
            else
            {
                MessageBox.Show("FALRA AGREGAR REGISTROS");
            }

        }

        public void AlertaGuardarPresentacion()
        {
            decimal pes;
            if (textBox_Peso.Text.Trim() == "")
            {
                pes = 0;
            }
            else { pes = Convert.ToDecimal(textBox_Peso.Text); }

            if (comboBox_Cultivo.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE CULTIVO", Color.FromArgb(238, 24, 24), 3);
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

                var exchar = cn_packing.BuscExistePresentacion(
                    comboBox_detalle_empresa.Text,//EMPRESA
                    comboBox_detalle_sede.Text,//SEDE
                    comboBox_Presentacion.Text//PRESENTACION
                    );

                //if (exchar == true)
                //{
                //    MessageBox.Show("YA EXISTE TIPO MERMA " + comboBox_TipoMerma.Text +
                //        " CON FECHA " + dateTimePicker_Fecha.Value.Date);
                //}
                //else
                //{
                if (exchar == false)
                {
                    string MessageBoxTitle = "GUARDAR ";
                    string MessageBoxContent = "¿Desea guardar registros? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        objcnpack.GuardarPresentacion(
                            comboBox_Presentacion.SelectedValue.ToString(),
                            comboBox_detalle_empresa.Text,//EMPRESA
                            comboBox_detalle_sede.Text,//SEDE
                            comboBox_Cultivo.Text, //CULTIVO
                            comboBox_Presentacion.Text.ToString(),
                            pes,
                            textBox_cajas.Text,
                            textBox_Comentario.Text,
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
                        //AgregarColumna();
                    }

                }
                else
                {
                    MessageBox.Show("YA EXISTE PRESENTACION");
                    //Msbox.Frm_NotificacionesPeligro ng =
                    //new Msbox.Frm_NotificacionesPeligro("RANGO DE FECHAS YA CUENTA CON REGISTRO", Color.FromArgb(238, 24, 24), 3);
                    //ng.ShowDialog();
                }

            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            textBox_Peso.Text = "";
            textBox_cajas.Text = "";
            textBox_Comentario.Text = "";

        }

        private void comboBox_Cultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Cultivo.Text == comboBox_Cultivo.Text)
            {
                //CARGAR PRESENTACION
                comboBox_Presentacion.DataSource = objnisira.ListaPresentacion(comboBox_Cultivo.Text);
                comboBox_Presentacion.DisplayMember = "Presentacion"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Presentacion.ValueMember = "IdPresentacion"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }

        }

        private void label_Id_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("l"+ comboBox_Presentacion.SelectedValue.ToString());
        }

        private void textBox_Peso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.'
                )
            {
                e.Handled = true;
            }
        }

        private void textBox_cajas_KeyPress(object sender, KeyPressEventArgs e)
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
}
