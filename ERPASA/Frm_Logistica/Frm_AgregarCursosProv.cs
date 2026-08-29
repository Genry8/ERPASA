using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using ERPASA.Frm_Contabilidad;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Logistica
{
    public partial class Frm_AgregarCursosProv : Form, VarDatosEntroFormProveedor
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();
        cd_nisira objnisira = new cd_nisira();
        cn_logistica objcnlogistica = new cn_logistica();
        DataTable dtg;

        public Frm_AgregarCursosProv()
        {
            InitializeComponent();
        }

        private void Frm_AgregarCursos_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            CargarDatosSync();
            //AgregarColumna();
            if (label_Id.Text != "0")
            {
                toolStripButton_limpiar.Enabled = false;
                comboBox_empresa.Text = ce_empsede.empresa;
                comboBox_sede.Text = ce_empsede.sede;
                comboBox_TipoTrabajador.Text = ce_empsede.tipotrab;
            }
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.SelectedIndex = 0;

            //MessageBox.Show(""+ ce_empsede.empresa);
            if (label_Id.Text != "0")
            {
                textBox_Dni.Enabled = false;
                textBox_apellidopat.Enabled = false;
                textbox_apellidomat.Enabled = false;
                textbox_nombres.Enabled = false;
                dateTimePicker_FechaInd.Enabled = false;
            }

            //comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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


        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    BuscarLista();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AllowUserToAddRows = false;
                // Asegúrate de que la primera columna sea editable
                // Establecer ReadOnly en false para permitir la edición de todas las columnas
                // Asegúrate de que las columnas sean editables (ReadOnly = false)
                foreach (DataColumn column in dtg.Columns)
                {
                    column.ReadOnly = false; // Deshabilita el solo lectura en todas las columnas
                }
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                }
                // Habilitar la edición solo para la primera columna
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].ReadOnly = false; // Permitir la edición solo de la primera columna
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
            }
        }

        private void BuscarLista()
        {
            try
            {
                if (label_Id.Text == "0")
                {
                    dtg = cn_logistica.ListaCursosSST(); //cn_logistica.ListaCBAreaTodoAsignacionTI();
                }
                else
                {
                    dtg = cn_logistica.ListaCursosSSTDniFecha(
                        textBox_Dni.Text, dateTimePicker_FechaInd.Value.Date
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
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


        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            textBox_Area.Focus();
            AlertaGuardar();
        }

        public void AlertaGuardar()
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

            else if (textBox_Dni.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DNI", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Ruc.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA RUC", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Proveedor.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA PROVEEDOR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Cargo.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA CARGO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Area.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA AREA TRABAJO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                if (label_Id.Text == "0")
                {
                    var exchar = cn_logistica.BuscExisteCursoProgramado(
                        textBox_Dni.Text, dateTimePicker_FechaInd.Value.Date, 1
                        );

                    if (exchar == true)
                    {
                        Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("USUARIO YA FUE PROGRAMADO", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    //{
                    //if (exchar == false)
                    {
                        string MessageBoxTitle = "GUARDAR ";
                        string MessageBoxContent = "¿Desea guardar registro? ";

                        DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                objcnlogistica.GuardarCursosProveedorProgramados(
                                    "0",
                            comboBox_empresa.Text,//EMPRESA
                            comboBox_sede.Text,//SEDE
                            textBox_Dni.Text.Trim(),//dni
                            textBox_apellidopat.Text.Trim(),
                            textbox_apellidomat.Text.Trim(),
                            textbox_nombres.Text.Trim(),
                            textBox_apellidopat.Text + " " +
                            textbox_apellidomat.Text + " " + textbox_nombres.Text,
                            textBox_Ruc.Text.Trim(),//
                            textBox_Proveedor.Text.Trim(),//
                            textBox_Cargo.Text.Trim(),//
                            dateTimePicker_FechaInd.Value.Date,
                            textBox_Area.Text.Trim(),//
                            Convert.ToInt32(row.Cells[1].Value),   // IdCurso
                            Convert.ToBoolean(row.Cells[0].Value), // EstadoCurso
                            comboBox_TipoTrabajador.Text, //tipo trab
                            "S", //estado
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            0
                            );
                            }
                            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                            ng.ShowDialog();
                            LimiparCampos();
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
                else
                {
                    string MessageBoxTitle = "ACTUALIZAR";
                    string MessageBoxContent = "¿Desea actualizar registro? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            objcnlogistica.GuardarCursosProveedorProgramados(
                                label_Id.Text,
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        textBox_Dni.Text.Trim(),//dni
                        textBox_apellidopat.Text.Trim(),
                        textbox_apellidomat.Text.Trim(),
                        textbox_nombres.Text.Trim(),
                        textBox_apellidopat.Text + " " +
                        textbox_apellidomat.Text + " " + textbox_nombres.Text,
                        textBox_Ruc.Text.Trim(),//
                        textBox_Proveedor.Text.Trim(),//
                        textBox_Cargo.Text.Trim(),//
                        dateTimePicker_FechaInd.Value.Date,
                        textBox_Area.Text.Trim(),//
                        Convert.ToInt32(row.Cells[1].Value),   // IdCurso
                        Convert.ToBoolean(row.Cells[0].Value), // EstadoCurso
                        comboBox_TipoTrabajador.Text, //tipo trab
                        "S", //estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0
                        );
                        }
                        Msbox.Frm_NotificacionesPeligro ng =
                            new Msbox.Frm_NotificacionesPeligro(
                                "ACTUALIZADO CORRECTAMENTE",
                                Color.FromArgb(12, 19, 214), 1);
                        ng.ShowDialog();
                        //LimiparCampos();
                    }
                }
            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimiparCampos();
        }

        public void LimiparCampos()
        {
            textBox_Dni.Text = string.Empty;
            textBox_apellidopat.Text = string.Empty;
            textbox_apellidomat.Text = string.Empty;
            textbox_nombres.Text = string.Empty;
            //textBox_Cargo.Text = string.Empty;
            //textBox_Area.Text = string.Empty;
        }


        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BuscarPersonaReniec();
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


        public async Task BuscarPersonaReniec()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Token
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue(
                            "Bearer",
                            "a22c04e4b06e3244195120f8f0d20b7be66de8688ced6124f89d9f63dae98ddc"
                        );

                    // Headers
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );

                    // Body JSON
                    var data = new
                    {
                        dni = textBox_Dni.Text
                    };

                    string json = JsonConvert.SerializeObject(data);

                    HttpContent content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                    // POST
                    HttpResponseMessage response = await client.PostAsync(
                        "https://apiperu.dev/api/dni",
                        content
                    );

                    string resultado = await response.Content.ReadAsStringAsync();

                    dynamic respuesta = JsonConvert.DeserializeObject(resultado);

                    // Datos
                    textBox_apellidopat.Text =
                        respuesta.data.apellido_paterno.ToString(); // + " " +
                    textbox_apellidomat.Text =
                        respuesta.data.apellido_materno.ToString();

                    textbox_nombres.Text =
                        respuesta.data.nombres.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible conectar con RENIEC");
            }
        }

        private void textBox_Proveedor_DoubleClick(object sender, EventArgs e)
        {
            Frm_BuscarProveedor frbm = new Frm_BuscarProveedor();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void textBox_Ruc_DoubleClick(object sender, EventArgs e)
        {
            Frm_BuscarProveedor frbm = new Frm_BuscarProveedor();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }


        public void TablaAgregarDatosFilaProveedor(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigProveedor(DataGridViewRow fila1a)
        {
            string ruc = (string)fila1a.Cells[0].Value;
            string razonsocial = (string)fila1a.Cells[1].Value;
            textBox_Ruc.Text = ruc;
            textBox_Proveedor.Text = razonsocial;
        }

        private void textBox_Ruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox_Proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {

            Frm_AgregarCursosProvMasivo frbm = new Frm_AgregarCursosProvMasivo();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }
    }

    internal interface VarDatosEntroFormProveedor
    {
        void TablaAgregarDatosFilaProveedor(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigProveedor(DataGridViewRow fila1a);
    }
}
