using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_SST
{
    public partial class Frm_Registrar_AtenMed : Form, VarDatosEntroFormMed
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        public Frm_Registrar_AtenMed()
        {
            InitializeComponent();
        }

        private void Frm_Registrar_AtenMed_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            textBox_ApeNom.CharacterCasing = CharacterCasing.Upper;
            textBox_Area.CharacterCasing = CharacterCasing.Upper;
            textBox_JefeArea.CharacterCasing = CharacterCasing.Upper;
            textBox_Patologia.CharacterCasing = CharacterCasing.Upper;
            textBox_Diagnóstico.CharacterCasing = CharacterCasing.Upper;
            textBox_Sintomas.CharacterCasing = CharacterCasing.Upper;
            textBox_CantMedicamento.CharacterCasing = CharacterCasing.Upper;
            textBox_AccionRealizada.CharacterCasing = CharacterCasing.Upper;
            label_ParteAfectada.Visible = false;
            label_Labor.Visible = false;
            textBox_ParteAfectada.Visible = false;
            textBox_Labor.Visible = false;
            textBox_Dni.Focus();

            PonerOscuroComboBox();
            CargarDatosComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


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


        public void ColumnasDTG()
        {

            DataGridViewTextBoxColumn Codigo = new DataGridViewTextBoxColumn();
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Column1";
            Codigo.Width = 87;
            dataGridView2.Columns.Add(Codigo);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Descripcion = new DataGridViewTextBoxColumn();
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Column2";
            Descripcion.Width = 56;
            dataGridView2.Columns.Add(Descripcion);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn UniMed = new DataGridViewTextBoxColumn();
            UniMed.HeaderText = "UniMed";
            UniMed.Name = "Column7";
            UniMed.Width = 56;
            dataGridView2.Columns.Add(UniMed);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Cantidad = new DataGridViewTextBoxColumn();
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Column7";
            Cantidad.Width = 56;
            dataGridView2.Columns.Add(Cantidad);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Precio = new DataGridViewTextBoxColumn();
            Precio.HeaderText = "Precio";
            Precio.Name = "Column7";
            Precio.Width = 56;
            dataGridView2.Columns.Add(Precio);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Fecha = new DataGridViewTextBoxColumn();
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Column8";
            Fecha.Width = 73;
            dataGridView2.Columns.Add(Fecha);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Total = new DataGridViewTextBoxColumn();
            Total.HeaderText = "Total";
            Total.Name = "Column8";
            Total.Width = 73;
            dataGridView2.Columns.Add(Total);


        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("da "+ checkBox_Incidencia.Checked);
            textBox_Dni.Focus();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (checkBox_Incidencia.Checked == true &&
                    textBox_ParteAfectada.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE PARTE DE CUERPO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (checkBox_Incidencia.Checked == true &&
                    textBox_Labor.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE LABOR", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }

                else if (textBox_Dni.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE DNI", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_detalle_empresa.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_detalle_sede.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_ApeNom.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE NOMBRE PACIENTE", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_Area.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE AREA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_JefeArea.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE JEFE DE AREA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_HoraEntrada.Text.Trim() == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE HORA ENTRADA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_HoraSalida.Text == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE HORA DE SALIDA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_Patologia.Text == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE PATOLOGIA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_Diagnóstico.Text == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE DIAGNOSTICO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_Sintomas.Text == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE SINTOMAS", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_AccionRealizada.Text == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE ACCION REALIZADA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (textBox_Localidad.Text == "")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("INGRESE LOCALIDAD", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (dataGridView2.RowCount < 2)
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA RECETA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else
                {
                    GuardarAtenMed();
                }

            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }


        public void GuardarAtenMed()
        {
            DateTime currentDateTime = DateTime.Now.Date;


            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date, textBox_HoraEntrada.Text);
                if (val == true)
                {
                    objcnlog.ActualizarAtenMedica(
                    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    dateTimePicker_FecAtencion.Value.Date,//FECHA INICIO
                    checkBox_Incidencia.Checked,//INCIDENCIA
                    dateTimePicker_FecAtencion.Value.Month.ToString(),//MES
                    comboBox_detalle_empresa.Text,
                    comboBox_detalle_sede.Text,
                    textBox_Dni.Text,//DNI
                    textBox_ApeNom.Text,//APENOM
                    textBox_Area.Text,//AREA
                    textBox_JefeArea.Text,//JEFEAREA
                    textBox_Patologia.Text,//PATOLOGIA
                    textBox_Diagnóstico.Text,//DIAGNOSTICO
                    textBox_Sintomas.Text,//SINTOMAS
                    textBox_Localidad.Text,//LOCALIDAD
                    Convert.ToDecimal(0),//CANT MEDICAMENTO
                    textBox_AccionRealizada.Text,//ACCION REALIZADA
                    textBox_ParteAfectada.Text,//PARTE DE CUERPO
                    textBox_Labor.Text,//LABOR
                    Convert.ToDateTime(textBox_HoraEntrada.Text),//HR_ENT
                    Convert.ToDateTime(textBox_HoraSalida.Text),//HR_SAL

                    "",
                    "S",
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    //ce_usuario.HostName(),
                    //ce_usuario.FechaSistema(),
                    //0,
                    //0
                    );

                    cn_sst.EliminarRecetaMedica(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date, textBox_HoraEntrada.Text);
                    GuardarRecetaDGV();

                }

                else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                {

                    objcnlog.GuardarAtenMedica(
                    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    dateTimePicker_FecAtencion.Value.Date,//FECHA INICIO
                    checkBox_Incidencia.Checked,//INCIDENCIA
                    dateTimePicker_FecAtencion.Value.Month.ToString(),//MES
                    comboBox_detalle_empresa.Text,
                    comboBox_detalle_sede.Text,
                    textBox_Dni.Text,//DNI
                    textBox_ApeNom.Text,//APENOM
                    textBox_Area.Text,//AREA
                    textBox_JefeArea.Text,//JEFEAREA
                    textBox_Patologia.Text,//PATOLOGIA
                    textBox_Diagnóstico.Text,//DIAGNOSTICO
                    textBox_Sintomas.Text,//SINTOMAS
                    textBox_Localidad.Text,//LOCALIDAD
                    Convert.ToDecimal(0),//CANT MEDICAMENTO
                    textBox_AccionRealizada.Text,//ACCION REALIZADA
                    textBox_ParteAfectada.Text,//PARTE DE CUERPO
                    textBox_Labor.Text,//LABOR
                    Convert.ToDateTime(textBox_HoraEntrada.Text),//HR_ENT
                    Convert.ToDateTime(textBox_HoraSalida.Text),//HR_SAL

                    "",
                    "S",
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod,
                    ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    0
                    );

                    GuardarRecetaDGV();


                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();

                textBox_Dni.Text = "";
                LimpiarText();
                LimpiarGridView();
                textBox_Dni.Focus();
            }

        }

        public void GuardarRecetaDGV()
        {
            dataGridView2.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                cn_sst.GuardRecetaMedica(
                    dateTimePicker_FecAtencion.Value.Date,
                                textBox_Dni.Text,
                    Convert.ToDateTime(textBox_HoraEntrada.Text),//HR_ENT
                    Convert.ToDateTime(textBox_HoraSalida.Text),//HR_SAL
                                row.Cells[0].Value?.ToString(),//Cod med
                                row.Cells[1].Value?.ToString(),//Des Med
                                row.Cells[2].Value?.ToString(),//Unid Med
                                Convert.ToDecimal(row.Cells[3].Value?.ToString()),//Cantidad
                                Convert.ToDecimal(row.Cells[4].Value?.ToString()),//Precio
                                Convert.ToDateTime(row.Cells[5].Value?.ToString()).Date,//Fecha Med
                                Convert.ToDecimal(row.Cells[6].Value?.ToString()),//Total
                                "S",

                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod

                            );

            }
            dataGridView2.AllowUserToAddRows = true;
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textBox_Dni.Text = "";
            LimpiarText();
            LimpiarGridView();
        }

        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void textBox_dni_agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (textBox_Dni.Text == "")
                    {
                        Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("INGRESE DNI", Color.FromArgb(238, 24, 24), 3);
                        ng.Show();
                    }
                    else
                    {
                        BuscarPacienteAtendido();

                    }
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }

            else if (char.IsWhiteSpace(e.KeyChar))
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

        public void BuscarPacienteAtendido()
        {
            var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date, textBox_HoraEntrada.Text);
            if (val == true)
            {
                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("ATENCION ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
                ng.Show();

                textBox_ApeNom.Text = ce_topico.apenom_paciente;
                textBox_Area.Text = ce_topico.area_paciente;
                textBox_JefeArea.Text = ce_topico.jefearea_paciente;
                textBox_HoraEntrada.Text = ce_topico.hrentrada_paciente;
                textBox_HoraSalida.Text = ce_topico.hrsalida_paciente;
                textBox_Patologia.Text = ce_topico.patologia_paciente;
                textBox_Diagnóstico.Text = ce_topico.diagnostico_paciente;
                textBox_Sintomas.Text = ce_topico.tratamiento_paciente;
                textBox_Localidad.Text = ce_topico.localidad_paciente;
                textBox_CantMedicamento.Text = ce_topico.cantmedicamento_paciente;
                textBox_AccionRealizada.Text = ce_topico.accionrealizada_paciente;
                textBox_ParteAfectada.Text = ce_topico.parte_cuerpo;
                textBox_Labor.Text = ce_topico.labor;
                checkBox_Incidencia.Checked = ce_topico.incidencia_paciente;

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = cn_sst.ListaRecetaAtencion(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date, textBox_HoraEntrada.Text);
                dataGridView2.AllowUserToAddRows = true;
                //OrigenColorfila();
                dataGridView2.ClearSelection();

            }
            else
            {
                LimpiarText();
                cn_sst.BuscDatosPersonalASA(textBox_Dni.Text);
                textBox_ApeNom.Text = ce_usuario.apenom_asa;
                textBox_Area.Text = ce_usuario.area_asa;
                ce_usuario.apenom_asa = "";
                ce_usuario.area_asa = "";
                ce_topico.jefearea_paciente = "";
            }

        }

        public void LimpiarText()
        {
            //textBox_Dni.Text = "";
            textBox_ApeNom.Text = "";
            textBox_Area.Text = "";
            textBox_JefeArea.Text = "";
            textBox_HoraEntrada.Text = "";
            textBox_HoraSalida.Text = "";
            textBox_Diagnóstico.Text = "";
            textBox_Patologia.Text = "";
            textBox_Sintomas.Text = "";
            textBox_CantMedicamento.Text = "";
            textBox_AccionRealizada.Text = "";
            textBox_Localidad.Text = "";
            textBox_ParteAfectada.Text = "";
            textBox_Labor.Text = "";
            checkBox_Incidencia.Checked = false;
            pictureBox_HoraEntrada.Enabled = true;

            label_ParteAfectada.Visible = false;
            label_Labor.Visible = false;
            textBox_ParteAfectada.Visible = false;
            textBox_Labor.Visible = false;

        }

        public void LimpiarGridView()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            ColumnasDTG();
        }

        private void pictureBox_HoraEntrada_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            textBox_HoraEntrada.Text = hoy.ToShortTimeString();
        }

        private void pictureBox_horaSalida_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            textBox_HoraSalida.Text = hoy.ToShortTimeString();
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (textBox_Dni.Text == "")
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("INGRESE DNI", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }
                else
                {
                    BuscarPacienteAtendido();

                }
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int a = 0; a <= e.RowIndex; a++)
            {
                if (dataGridView2.Rows[a].Cells[1].Value == null)
                {
                    if (e.ColumnIndex == 1)
                    {
                        dataGridView2.AllowUserToAddRows = false;
                        frm_BuscarMedicamento frbm = new frm_BuscarMedicamento();
                        AddOwnedForm(frbm);
                        frbm.ShowDialog();
                        dataGridView2.AllowUserToAddRows = true;
                    }
                }
            }
            /*
            VarDatosEntroFormMed var1 = Owner as VarDatosEntroFormMed;
            DataGridViewRow fila = dataGridView2.SelectedRows[0] as DataGridViewRow;
            var1.TablaAgregarDatosFilaAsig(fila);
            this.Close();
            */
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.ReadOnly = false;
            for (int a = 0; a <= e.RowIndex; a++)
            {
                if (dataGridView2.Rows[a].Cells[2].Value == null)
                {
                    dataGridView2.Rows[a].Cells[0].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[1].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[2].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[3].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[4].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[5].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[6].ReadOnly = true;
                }

                else if (dataGridView2.Rows[a].Cells[2].Value != null)
                {
                    dataGridView2.Rows[a].Cells[0].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[1].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[2].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[3].ReadOnly = false;
                    dataGridView2.Rows[a].Cells[4].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[5].ReadOnly = true;
                    dataGridView2.Rows[a].Cells[6].ReadOnly = true;
                }
            }
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
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(valoritem))
                {
                    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("YA FUE AÑADIDO", Color.Goldenrod, 4);
                    ng.ShowDialog();
                    dataGridView2.AllowUserToAddRows = true;
                    EncontrarFilaRepetida = true;
                    dataGridView2.ClearSelection();
                    break;
                }
            }

            if (EncontrarFilaRepetida != true)
            {
                dataGridView2.Rows.Add(
                    fila1a.Cells[0].Value, //Codigo
                    fila1a.Cells[1].Value, //Des
                    fila1a.Cells[2].Value, //UniMed
                    "0", //UniMed
                    fila1a.Cells[3].Value, //Precio
                    Convert.ToDateTime(fila1a.Cells[4].Value).Date, //Fecha_med
                    "0.00"
                    );

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.ReadOnly = true;
                dataGridView2.ClearSelection();
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal a;
            decimal b;

            for (int i = 0; i <= e.RowIndex; i++)
            {
                if (dataGridView2.Rows[i].Cells[1].Value != null)
                {
                    dataGridView2.Rows[i].Cells[6].Value =
                        Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value) *
                        Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value);
                }
            }
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 3)
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
            if (dataGridView2.CurrentCell.ColumnIndex == 3)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView2_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView2_KeyPress);
                }
            }
        }

        private void textBox_HoraEntrada_TextChanged(object sender, EventArgs e)
        {
            pictureBox_HoraEntrada.Enabled = false;
        }

        private void checkBox_Incidencia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Incidencia.Checked == true)
            {
                label_ParteAfectada.Visible = true;
                label_Labor.Visible = true;
                textBox_ParteAfectada.Visible = true;
                textBox_Labor.Visible = true;
            }
            else
            {
                label_ParteAfectada.Visible = false;
                label_Labor.Visible = false;
                textBox_ParteAfectada.Visible = false;
                textBox_Labor.Visible = false;
            }
        }
    }

    internal interface VarDatosEntroFormMed
    {
        void TablaAgregarDatosFila(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsig(DataGridViewRow fila1a);
    }
}
