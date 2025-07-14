using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_NuevaProgramacionPallets : Form
    {
        string pallet, cabezal, variedad, kilos;

        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_packing objcnpack = new cn_packing();
        cu_excel objexcel = new cu_excel();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;

        public Frm_NuevaProgramacionPallets()
        {
            InitializeComponent();
        }

        private void Frm_NuevaProgramacionPallets_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_variedad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Maquina.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Turno.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_detalle_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_variedad.DataSource = cn_packing.ListaVariedad();
            comboBox_variedad.DisplayMember = "desvar"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_variedad.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinaria();
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Turno.DataSource = cn_packing.ListaPackingTurno();
            comboBox_Turno.DisplayMember = "Turno"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Turno.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarRecepcionParaProgramar()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp, sed, cult,var,maq;
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_detalle_empresa.Text;
            }
            if (comboBox_detalle_sede.Text == "SELECCIONE")
            {
                sed = "%";
            }
            else
            {
                sed = comboBox_detalle_sede.Text;
            }
            if (comboBox_detalle_Cultivo.Text == "SELECCIONE")
            {
                cult = "%";
            }
            else
            {
                cult = comboBox_detalle_Cultivo.Text;
            }
            if (comboBox_variedad.Text == "SELECCIONE")
            {
                var = "%";
            }
            else
            {
                var = comboBox_variedad.SelectedValue.ToString();
            }
            if (comboBox_Maquina.Text == "SELECCIONE")
            {
                maq = "%";
            }
            else
            {
                maq = comboBox_Maquina.Text;
            }

            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();
            //MessageBox.Show("id " + comboBox_variedad.SelectedValue.ToString());
            //dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_sst.ListaRecepcionImprimir(dateTimePicker_FecInicio.Value.Date
            //    , dateTimePicker_FecFin.Value.Date, emp
            //    , sed);

            //dataGridView2.AllowUserToAddRows = false;
            ////OrigenColorfila();
            //dataGridView2.ClearSelection();


            //dataGridView3.ReadOnly = true;
            DataTable dt = new DataTable();
            dt = cn_sst.RecepcionProgVolcado(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecInicio.Value.Date, emp
                , sed, cult, var, maq);
            if (!dataGridView2.Columns.Contains("Selec"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.Name = "Selec";
                checkBoxColumn.HeaderText = "Selec";
                checkBoxColumn.ReadOnly = false;
                checkBoxColumn.FalseValue = false;
                checkBoxColumn.TrueValue = true;
                dataGridView2.Columns.Add(checkBoxColumn);
            }
            dataGridView2.DataSource = dt;

            int i;
            for (i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                //EMPRESA
                dataGridView2.Rows[i].Cells[0].Value
                    = dataGridView2.Rows[i].Cells[1].Value;
            }
            dataGridView2.Columns[1].Visible = false;
            //OrigenColorfila();
            dataGridView2.ClearSelection();
            //dataGridView2.Columns["Selec"].ReadOnly = false;

            //DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            //estado.HeaderText = "estado";
            //dataGridView2.Columns.Insert(0, estado);



        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarRecepcionParaProgramar();
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pallet = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cabezal = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            variedad = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            kilos = dataGridView2.CurrentRow.Cells[5].Value.ToString();

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarProgVolcado();
        }

        public void AlertaGuardarProgVolcado()
        {
            if (dataGridView2.Rows.Count < 1)
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("NO HAY LISTA DE PALETS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Turno.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE TURNO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            //else if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    Msbox.Frm_NotificacionesPeligro ng =
            //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
            //else if (comboBox_detalle_sede.Text == "SELECCIONE")
            //{
            //    Msbox.Frm_NotificacionesPeligro ng =
            //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
            else if (comboBox_detalle_Cultivo.Text == "CULTIVO")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE CULTIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_Maquina.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE MAQUINA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                GuardarProgVolcado();
            }
        }
        public void GuardarProgVolcado()
        {
            dateTimePicker_FecInicio.Focus();
            //textBox1.Focus();

            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > -1)
            {
                string MessageBoxTitle = "GUARDAR ";
                string MessageBoxContent = "¿Desea guardar programacion?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        //if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        //{
                        //var valPalet = cn_packing.BuscarPaletProgVolcado(
                        //        row.Cells[3].Value.ToString()//idRec
                        //);

                        //if (valPalet == true)
                        //{
                        //    MessageBox.Show("PALET " + row.Cells[4].Value.ToString() +
                        //        "YA FUE PROGRAMADO");
                        //}
                        //else
                        //{

                            objcnpack.GuardarActualizarProgVolcado(
                                    row.Cells[0].Value.ToString(),//programado
                                    row.Cells[3].Value.ToString(),//idRec
                                    row.Cells[4].Value.ToString(),//Num Palet
                                    dateTimePicker_FecInicio.Value.ToString(),//fecProgramado
                                    comboBox_Turno.Text.ToString().Trim(),//turno
                                    comboBox_Maquina.Text.ToString().Trim(),
                                    "",//linea
                                    "",//Obs
                                    "S", //estado
                                    ce_usuario.FechaSistema(),
                                    ce_usuario.usecod,
                                    ce_usuario.HostName(),
                                    ce_usuario.FechaSistema(),
                                    0,
                                    0
                                    );

                        //}
                    }
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();
                    //dataGridView2.DataSource = null;
                    //AgregarColumna();
                }

            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN PALLET");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (checkBox1.Checked == true)
                {
                    row.Cells[0].Value = true;
                }
                else
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void comboBox_Maquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarRecepcionParaProgramar();
        }

        private void comboBox_detalle_Cultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_variedad.DataSource = cn_packing.ListaVariedadCultivo(comboBox_detalle_Cultivo.Text);
            comboBox_variedad.DisplayMember = "desvar"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_variedad.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Maquina.DataSource = cn_packing.ListaTipoMaquinariaCultivo(comboBox_detalle_Cultivo.Text);
            comboBox_Maquina.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Maquina.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            dateTimePicker_FecInicio.Focus();
            //textBox1.Focus();

            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > 0)
            {
                ImprimirReporteDetalleAtencionASA();
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN PALLET");
            }
        }


        public void ImprimirReporteDetalleAtencionASA()
        {
            Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSetAcopio objDsRepAcopio = new DataSetAcopio();
            string empresa;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (row.Cells[7].Value.ToString() == "AGRICOLA SANTA AZUL S.R.L")
                    {
                        empresa = "ASA";
                    }
                    else if (row.Cells[7].Value.ToString() == "AGRICOLA INTERANDINA S.A.C")
                    {
                        empresa = "IA";
                    }
                    else
                    {
                        empresa = "TERCERO";
                    }

                    objDsRepAcopio.Tables[1].Rows.Add
                            (new object[]{
                        row.Cells[2].Value.ToString().ToUpper(), //PALLET
                        row.Cells[3].Value.ToString().ToUpper(), //CABEZAL
                        row.Cells[4].Value.ToString().ToUpper(), //VARIEDAD
                        row.Cells[5].Value.ToString(), //KILOS
                        row.Cells[6].Value.ToString(), //FECHA
                        empresa, //FECHA
                        row.Cells[9].Value.ToString()

                            });

                    objcnsst.ActualizarRecepcionImprimir(row.Cells[2].Value.ToString()
                , row.Cells[6].Value.ToString());

                }

            }

            Acopio.CrystalReportPalletPrint objCryRep = new Acopio.CrystalReportPalletPrint();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReportPalletPrint.rpt");
            objCryRep.SetDataSource(objDsRepAcopio);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }



    }
}
