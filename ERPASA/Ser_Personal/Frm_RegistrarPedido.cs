using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_RegistrarPedido : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;


        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        private Dictionary<int, Tuple<object, object>> valoresGuardados = new Dictionary<int, Tuple<object, object>>();

        public Frm_RegistrarPedido()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_RegistrarPedido_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            //CargaDatos();
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;

            Cargar_Empresa();
            PonerOscuroComboBox();
            CargaDatos();
            // Asegúrate de suscribirte al evento de 'EditingControlShowing'
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            //dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // Suscribir al evento Sorted
            dataGridView1.Sorted += dataGridView1_Sorted;// Deshabilitar el ordenamiento en todo el DataGridView

        }

        public void CargaDatos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
        }

        static DataTable GetTable()
        {
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            ds.Tables.Add(tabla);
            tabla.Columns.Add("SEDE", typeof(string)).SetOrdinal(0);
            //tabla.Columns.Add("Cantidad", typeof(Int32));
            tabla.Rows.Add("COMEDOR A");
            tabla.Rows.Add("COMEDOR B");
            tabla.Rows.Add("COMEDOR C");
            tabla.Rows.Add("COMEDOR D");
            tabla.Rows.Add("PARRILLA");
            tabla.Rows.Add("PRINCIPAL");

            return tabla;
        }

        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR


        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                ColumnasDtgv1();
                //CARGAR SEDE EMPRESA
                //comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_empresa.Text);
                //comboBox_CodSede_Comedor.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                //comboBox_CodSede_Comedor.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void ColumnasDtgv1()
        {
            // 
            // Column1
            // 
            //DataGridViewTextBoxColumn SEDE = new DataGridViewTextBoxColumn();
            //SEDE.HeaderText = "SEDE";
            //SEDE.Name = "Column1";
            //SEDE.Width = 85;
            //dataGridView1.Columns.Add(SEDE);

            //DataGridViewComboBoxColumn SEDE = new DataGridViewComboBoxColumn();
            //SEDE.HeaderText = "SEDE";
            //SEDE.Name = "Column1";
            //SEDE.Width = 180;
            ////LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            //ArrayList row = new ArrayList();
            ////declara una tabla donde se llama la lista de los estados
            //DataTable dt = new DataTable();
            //dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            //foreach (DataRow item in dt.Rows)
            //{
            //    row.Add(item[1].ToString());
            //}
            ////AÑADIR LA LISTA AL COMBO
            //SEDE.Items.AddRange(row.ToArray());
            ////AÑADIR EL COMBO AL DATAGRIDVIEW
            //dataGridView1.Columns.Add(SEDE);

            DataTable dt = new DataTable();
            dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");

            DataGridViewComboBoxColumn SEDE = new DataGridViewComboBoxColumn();
            SEDE.HeaderText = "SEDE";  // El título de la columna
            SEDE.Name = "SEDE";      // El nombre de la columna
            SEDE.DataSource = dt; // Asignar los datos al ComboBox (puede ser una lista o un DataTable)
            SEDE.DisplayMember = "Comedor"; // El campo a mostrar en el ComboBox
            SEDE.ValueMember = "id";          // El valor asociado con el item del ComboBox (lo que se almacena)
            SEDE.DefaultCellStyle.NullValue = "SELECCIONE";  // Valor predeterminado si la celda está vacía
            dataGridView1.Columns.Add(SEDE);

            ///
            //COLUMNA TIPO EMPLEADO
            ///
            DataTable dt2 = new DataTable();
            dt2 = cn_logistica.ListaTipoPersonal();

            DataGridViewComboBoxColumn PERSONAL = new DataGridViewComboBoxColumn();
            PERSONAL.HeaderText = "PERSONAL";  // El título de la columna
            PERSONAL.Name = "PERSONAL";      // El nombre de la columna
            PERSONAL.DataSource = dt2; // Asignar los datos al ComboBox (puede ser una lista o un DataTable)
            PERSONAL.DisplayMember = "TipoPersonal"; // El campo a mostrar en el ComboBox
            PERSONAL.ValueMember = "TipoPersonal";          // El valor asociado con el item del ComboBox (lo que se almacena)
            PERSONAL.DefaultCellStyle.NullValue = "SELECCIONE";  // Valor predeterminado si la celda está vacía
            dataGridView1.Columns.Add(PERSONAL);


            // 
            // Column2
            // 
            DataGridViewTextBoxColumn PROGDES = new DataGridViewTextBoxColumn();
            PROGDES.HeaderText = "PROG DES";
            PROGDES.Name = "Column2";
            PROGDES.Width = 85;
            dataGridView1.Columns.Add(PROGDES);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn PROGALM = new DataGridViewTextBoxColumn();
            PROGALM.HeaderText = "PROG ALM";
            PROGALM.Name = "Column3";
            PROGALM.Width = 87;
            dataGridView1.Columns.Add(PROGALM);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn PROGCEN = new DataGridViewTextBoxColumn();
            PROGCEN.HeaderText = "PROG CEN";
            PROGCEN.Name = "Column3";
            PROGCEN.Width = 87;
            dataGridView1.Columns.Add(PROGCEN);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn CONDES = new DataGridViewTextBoxColumn();
            CONDES.HeaderText = "CON DES";
            CONDES.Name = "Column2";
            CONDES.Width = 85;
            dataGridView1.Columns.Add(CONDES);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn CONALM = new DataGridViewTextBoxColumn();
            CONALM.HeaderText = "CON ALM";
            CONALM.Name = "Column3";
            CONALM.Width = 87;
            dataGridView1.Columns.Add(CONALM);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn CONCEN = new DataGridViewTextBoxColumn();
            CONCEN.HeaderText = "CON CEN";
            CONCEN.Name = "Column3";
            CONCEN.Width = 87;
            dataGridView1.Columns.Add(CONCEN);
        }


        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            textBox_marc.Focus();
            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (comboBox_empresa.Text == "SELECCIONE")
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        if (ValidarFilasCompletasDT1())
                        {
                            // ✅ Todas las celdas están llenas, procede a guardar
                            GuardarPedido();
                        }
                        else
                        {
                            // ❌ Hay celdas vacías, se cancela el guardado
                        }
                    }
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA CARGAR DATOS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
                dataGridView1.AllowUserToAddRows = true;
            }


        }


        private bool ValidarFilasCompletasDT1()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int filaVisible = row.Index + 1;

                    // Validar columna SEDE (índice 0)
                    var sedeDisplay = row.Cells[0].FormattedValue?.ToString().Trim().ToUpper() ?? "";
                    if (sedeDisplay == "SELECCIONE" || sedeDisplay == "COMEDOR")
                    {
                        dataGridView1.CurrentCell = row.Cells[0];
                        MessageBox.Show($"Por favor, seleccione una SEDE válida en la fila {filaVisible}.",
                                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Validar columna PERSONAL (índice 1)
                    var personalDisplay = row.Cells[1].FormattedValue?.ToString().Trim().ToUpper() ?? "";
                    if (personalDisplay == "SELECCIONE")
                    {
                        dataGridView1.CurrentCell = row.Cells[1];
                        MessageBox.Show($"Por favor, seleccione un PERSONAL válido en la fila {filaVisible}.",
                                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }


        public void GuardarPedido()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            int proddes, prodalm, prodcen, condes, conalm, concen;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar pedido?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                cn_logistica.BuscExistePedidoComedor(comboBox_empresa.Text, dateTimePicker_Comedor_F_Prog.Value.Date);

                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    //ce_logistica.EmpPedido = "";
                    //ce_logistica.SedePedido = "";
                    if (dataGridView1[2, i].Value == null)
                    {
                        proddes = 0;
                    }
                    else
                    {
                        proddes = Convert.ToInt32(dataGridView1[2, i].Value.ToString().Trim());
                    }
                    if (dataGridView1[3, i].Value == null)
                    {
                        prodalm = 0;
                    }
                    else
                    {
                        prodalm = Convert.ToInt32(dataGridView1[3, i].Value.ToString().Trim());
                    }
                    if (dataGridView1[4, i].Value == null)
                    {
                        prodcen = 0;
                    }
                    else
                    {
                        prodcen = Convert.ToInt32(dataGridView1[4, i].Value.ToString().Trim());
                    }
                    if (dataGridView1[5, i].Value == null)
                    {
                        condes = 0;
                    }
                    else
                    {
                        condes = Convert.ToInt32(dataGridView1[5, i].Value.ToString().Trim());
                    }
                    if (dataGridView1[6, i].Value == null)
                    {
                        conalm = 0;
                    }
                    else
                    {
                        conalm = Convert.ToInt32(dataGridView1[6, i].Value.ToString().Trim());
                    }
                    if (dataGridView1[7, i].Value == null)
                    {
                        concen = 0;
                    }
                    else
                    {
                        concen = Convert.ToInt32(dataGridView1[7, i].Value.ToString().Trim());
                    }

                    objcnlog.GuardarRegistroPedido(
                            dateTimePicker_Comedor_F_Prog.Value.Date, //FECHA
                            comboBox_empresa.Text, //EMPRESA
                            dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//SEDE
                            dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//TIPO PERSONAL
                            proddes.ToString(),//proddes.ToString(),//PROD DES
                            prodalm.ToString(),//prodalm.ToString(),//PROD ALM
                            prodcen.ToString(),//prodcen.ToString(),//PROD CEN
                            condes.ToString(),//condes.ToString(),//CON DES
                            conalm.ToString(),//conalm.ToString(),//CON ALM
                            concen.ToString(),//concen.ToString(),//CON CEN
                            "",
                            "S",
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            0,
                            0
                            );

                    //if (comboBox_empresa.Text == ce_logistica.EmpPedido & dateTimePicker_Comedor_F_Prog.Value.Date == ce_logistica.FecPedido.Date & ce_logistica.SedePedido== dataGridView1[0, i].Value.ToString().ToUpper().Trim())
                    //{
                    //    objcnlog.ActualizarPedidoComedor(
                    //        dateTimePicker_Comedor_F_Prog.Value.Date, //FECHA
                    //        comboBox_empresa.Text, //EMPRESA
                    //        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//SEDE
                    //        Convert.ToInt32(dataGridView1[1, i].Value).ToString().Trim(),//PROD DES
                    //        Convert.ToInt32(dataGridView1[2, i].Value).ToString().Trim(),//PROD ALM
                    //        Convert.ToInt32(dataGridView1[3, i].Value).ToString().Trim(),//PROD CEN
                    //        Convert.ToInt32(dataGridView1[4, i].Value).ToString().Trim(),//CON DES
                    //        Convert.ToInt32(dataGridView1[5, i].Value).ToString().Trim(),//CON ALM
                    //        Convert.ToInt32(dataGridView1[6, i].Value).ToString().Trim(),//CON CEN
                    //        "", //OBS
                    //        "S",
                    //        ce_usuario.FechaSistema(),
                    //        ce_usuario.usecod
                    //    );

                    //}

                    //else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    //{
                    //    objcnlog.GuardarRegistroPedido(
                    //        dateTimePicker_Comedor_F_Prog.Value.Date, //FECHA
                    //        comboBox_empresa.Text, //EMPRESA
                    //        dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//SEDE
                    //        Convert.ToInt32(dataGridView1[1, i].Value).ToString().Trim(),//PROD DES
                    //        Convert.ToInt32(dataGridView1[2, i].Value).ToString().Trim(),//PROD ALM
                    //        Convert.ToInt32(dataGridView1[3, i].Value).ToString().Trim(),//PROD CEN
                    //        Convert.ToInt32(dataGridView1[4, i].Value).ToString().Trim(),//CON DES
                    //        Convert.ToInt32(dataGridView1[5, i].Value).ToString().Trim(),//CON ALM
                    //        Convert.ToInt32(dataGridView1[6, i].Value).ToString().Trim(),//CON CEN
                    //        "",
                    //        "S",
                    //        ce_usuario.FechaSistema(),
                    //        ce_usuario.usecod,
                    //        ce_usuario.HostName(),
                    //        ce_usuario.FechaSistema(),
                    //        0,
                    //        0
                    //        );

                    //}
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("PEDIDO GUARDADO", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;

        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
            label_prog_des.Text = "0";
            label_prog_alm.Text = "0";
            label_prog_cen.Text = "0";
            label_con_des.Text = "0";
            label_con_alm.Text = "0";
            label_con_cen.Text = "0";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (comboBox_empresa.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else
                {
                    CargarDatosSync();
                }

            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

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
                    BuscarReportePedido();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.AllowUserToAddRows = false;
                SumarTotal();
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToOrderColumns = false;

                ConvertirColumnaEnComboBox();

                //CONTAR LA CANTIDAD DE REGISTROS
                if (dataGridView1.Rows.Count > 0)
                {
                    //label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";

                    //Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(3, 151, 43), 2);
                    //ng.Show();
                }
                else
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
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

        private void ConvertirColumnaEnComboBox()
        {
            // Obtener los valores de las dos primeras columnas antes de eliminar
            var valoresColumna1 = new List<string>();
            var valoresColumna2 = new List<string>();

            // Asumiendo que las columnas contienen valores en formato de texto o cadena
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Evitamos la fila nueva que está vacía
                if (!row.IsNewRow)
                {
                    valoresColumna1.Add(row.Cells[0].Value?.ToString());
                    valoresColumna2.Add(row.Cells[1].Value?.ToString());
                }
            }

            // Obtener datos para los ComboBox
            DataTable dt = cn_logistica.ListaSedeComedorEmpresa(comboBox_empresa.Text.Trim(), "%");
            DataTable dt2 = cn_logistica.ListaTipoPersonal();

            // Eliminar las dos primeras columnas
            dataGridView1.Columns.RemoveAt(1);
            dataGridView1.Columns.RemoveAt(0);  // El índice vuelve a ser 0 porque ya hemos eliminado la primera

            // Crear la columna ComboBox para SEDE
            DataGridViewComboBoxColumn SEDE = new DataGridViewComboBoxColumn
            {
                HeaderText = "SEDE",  // Título de la columna
                Name = "SEDE",  // Nombre de la columna
                DataSource = dt,  // Fuente de datos para el ComboBox
                DisplayMember = "Comedor",  // Campo a mostrar en el ComboBox
                ValueMember = "Comedor",  // Valor a almacenar
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = "SELECCIONE" }
            };

            // Crear la columna ComboBox para PERSONAL
            DataGridViewComboBoxColumn PERSONAL = new DataGridViewComboBoxColumn
            {
                HeaderText = "PERSONAL",  // Título de la columna
                Name = "PERSONAL",  // Nombre de la columna
                DataSource = dt2,  // Fuente de datos para el ComboBox
                DisplayMember = "TipoPersonal",  // Campo a mostrar en el ComboBox
                ValueMember = "TipoPersonal",  // Valor a almacenar
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = "SELECCIONE" }
            };

            // Agregar las nuevas columnas
            dataGridView1.Columns.Insert(0, SEDE);
            dataGridView1.Columns.Insert(1, PERSONAL);

            // Restaurar los valores de las dos primeras columnas a las nuevas celdas de ComboBox
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Evitamos la fila nueva que está vacía
                if (!row.IsNewRow)
                {
                    // Asignamos los valores que teníamos antes a las celdas del ComboBox
                    row.Cells[0].Value = valoresColumna1[row.Index];
                    row.Cells[1].Value = valoresColumna2[row.Index];
                }
            }
        }

        public void BuscarReportePedido()
        {
            string empText = string.Empty, emp;

            ////////////////////////////////////
            if (comboBox_empresa.InvokeRequired)
            {
                comboBox_empresa.Invoke(new MethodInvoker(() =>
                {
                    empText = comboBox_empresa.Text;
                }));
            }
            else
            {
                empText = comboBox_empresa.Text;
            }
            ////////////////////
            if (empText == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = empText;
            }

            dtg = cn_logistica.BuscarRegistroPedido(
            dateTimePicker_Comedor_F_Prog.Value.Date
            , dateTimePicker_Comedor_F_Prog.Value.Date
            , emp, "1");


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        if (e.ColumnIndex == 1)
                        {
                            for (int i = 0; i <= e.RowIndex; i++)
                            {
                                //if (dataGridView1.Rows[i].Cells[1].Value == null)
                                //{
                                //    //dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                                //    row.Cells[2].Value = 0;
                                //    row.Cells[3].Value = 0;
                                //    row.Cells[4].Value = 0;
                                //    row.Cells[5].Value = 0;
                                //    row.Cells[6].Value = 0;
                                //}
                                //if (dataGridView1.Rows[i].Cells[2].Value == null)
                                //{
                                //    //dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                                //    row.Cells[1].Value = 0;
                                //    row.Cells[3].Value = 0;
                                //    row.Cells[4].Value = 0;
                                //    row.Cells[5].Value = 0;
                                //    row.Cells[6].Value = 0;
                                //}
                                //if (dataGridView1.Rows[i].Cells[3].Value == null)
                                //{
                                //    //dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                                //    row.Cells[1].Value = 0;
                                //    row.Cells[2].Value = 0;
                                //    row.Cells[4].Value = 0;
                                //    row.Cells[5].Value = 0;
                                //    row.Cells[6].Value = 0;
                                //}
                                //if (dataGridView1.Rows[i].Cells[4].Value == null)
                                //{
                                //    //dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                                //    row.Cells[1].Value = 0;
                                //    row.Cells[2].Value = 0;
                                //    row.Cells[3].Value = 0;
                                //    row.Cells[5].Value = 0;
                                //    row.Cells[6].Value = 0;
                                //}
                                //if (dataGridView1.Rows[i].Cells[5].Value == null)
                                //{
                                //    //dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                                //    row.Cells[1].Value = 0;
                                //    row.Cells[2].Value = 0;
                                //    row.Cells[3].Value = 0;
                                //    row.Cells[4].Value = 0;
                                //    row.Cells[6].Value = 0;
                                //}
                                //if (dataGridView1.Rows[i].Cells[6].Value == null)
                                //{
                                //    //dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                                //    row.Cells[1].Value = 0;
                                //    row.Cells[2].Value = 0;
                                //    row.Cells[3].Value = 0;
                                //    row.Cells[4].Value = 0;
                                //    row.Cells[5].Value = 0;
                                //}

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

            if (dataGridView1.CurrentCell.ColumnIndex == 3) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

            if (dataGridView1.CurrentCell.ColumnIndex == 4) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

            if (dataGridView1.CurrentCell.ColumnIndex == 5) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

            if (dataGridView1.CurrentCell.ColumnIndex == 6) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

            if (dataGridView1.CurrentCell.ColumnIndex == 7) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

            if (dataGridView1.CurrentCell.ColumnIndex == 8) // CANT-E
            {
                if (char.IsDigit(e.KeyChar))
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

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }


            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 5)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 7)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }

        }

        public void SumarTotal()
        {
            int proddes = 0;
            int prodalm = 0;
            int prodcen = 0;
            //decimal otros = 0;

            int condes = 0, conalm = 0, concen = 0;

            int filas = dataGridView1.Rows.Count;
            int a;
            for (int i = 0; i <= filas - 1; i++)
            //foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                //ce_logistica.EmpPedido = "";
                //ce_logistica.SedePedido = "";
                if (dataGridView1[1, i].Value == null)
                {
                    dataGridView1[1, i].Value = 0;
                }

                if (dataGridView1[2, i].Value == null)
                {
                    dataGridView1[2, i].Value = 0;
                }

                if (dataGridView1[3, i].Value == null)
                {
                    dataGridView1[3, i].Value = 0;
                }
                if (dataGridView1[4, i].Value == null)
                {
                    dataGridView1[4, i].Value = 0;
                }

                if (dataGridView1[5, i].Value == null)
                {
                    dataGridView1[5, i].Value = 0;
                }

                if (dataGridView1[6, i].Value == null)
                {
                    dataGridView1[6, i].Value = 0;
                }

            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value != null)
                    proddes += (Int32)row.Cells[2].Value;
                if (row.Cells[3].Value != null)
                    prodalm += (Int32)row.Cells[3].Value;
                if (row.Cells[4].Value != null)
                    prodcen += (Int32)row.Cells[4].Value;
                if (row.Cells[5].Value != null)
                    condes += (Int32)row.Cells[5].Value;
                if (row.Cells[6].Value != null)
                    conalm += (Int32)row.Cells[6].Value;
                if (row.Cells[7].Value != null)
                    concen += (Int32)row.Cells[7].Value;
            }


            label_prog_des.Text = proddes.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_prog_alm.Text = prodalm.ToString();//"S/. " + NoAnulado.ToString("0,0.00");
            label_prog_cen.Text = prodcen.ToString();//"S/. " + total.ToString("0,0.00");

            label_con_des.Text = condes.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_con_alm.Text = conalm.ToString();//"S/. " + NoAnulado.ToString("0,0.00");
            label_con_cen.Text = concen.ToString();//"S/. " + total.ToString("0,0.00");
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            // Guardar los valores de los ComboBox antes de ordenar
            GuardarValoresComboBox();

            // Restaurar los valores de los ComboBox después de ordenar
            RestaurarValoresComboBox();
        }

        private void GuardarValoresComboBox()
        {
            // Limpiar la lista de valores guardados
            valoresGuardados.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Evitar la fila nueva que está vacía
                if (!row.IsNewRow)
                {
                    // Guardar el valor seleccionado de la celda SEDE (columna 0) y PERSONAL (columna 1)
                    valoresGuardados[row.Index] = new Tuple<object, object>(
                        row.Cells[0].Value,  // Valor de la celda SEDE
                        row.Cells[1].Value   // Valor de la celda PERSONAL
                    );
                }
            }
        }

        private void RestaurarValoresComboBox()
        {
            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Verificar si el índice de la fila existe en los valores guardados
                    if (valoresGuardados.ContainsKey(row.Index))
                    {
                        // Restaurar los valores guardados en las celdas correspondientes
                        var valores = valoresGuardados[row.Index];
                        row.Cells[0].Value = valores.Item1;  // Restaurar el valor de SEDE
                        row.Cells[1].Value = valores.Item2;  // Restaurar el valor de PERSONAL
                    }
                }
            }
        }

    }
}
