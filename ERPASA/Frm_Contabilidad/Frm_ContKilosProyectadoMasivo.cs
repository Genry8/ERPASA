using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_Contabilidad
{
    public partial class Frm_ContKilosProyectadoMasivo : Form
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_contabilidad objcnlog = new cn_contabilidad();
        cu_excel objexcel = new cu_excel();

        public Frm_ContKilosProyectadoMasivo()
        {
            InitializeComponent();
        }

        private void Frm_ContKilosProyectadoMasivo_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargaDatos();
            Cargar_Empresa();
            //AgregarColumna();
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR CULTIVO
            comboBox_Cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_Cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void CargaDatos()
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            label_cantreg.Text = "0 REGISTROS";
            //ColumnasDtgv1();
        }


        private void ColumnasDtgv1()
        {
            //DataGridViewComboBoxColumn SEDE = new DataGridViewComboBoxColumn();
            //SEDE.HeaderText = "SEDE";
            //SEDE.Name = "Column1";
            //SEDE.Width = 180;
            ////LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            //ArrayList row = new ArrayList();
            ////declara una tabla donde se llama la lista de los estados
            //DataTable dt = new DataTable();
            //dt = cn_logistica.ListaSedeComedor();

            //foreach (DataRow item in dt.Rows)
            //{
            //    row.Add(item[1].ToString());
            //}
            ////AÑADIR LA LISTA AL COMBO
            //SEDE.Items.AddRange(row.ToArray());
            ////AÑADIR EL COMBO AL DATAGRIDVIEW
            //dataGridView1.Columns.Add(SEDE);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "Empresa";
            Empresa.Name = "Empresa";
            Empresa.Width = 280;
            dataGridView1.Columns.Add(Empresa);
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Codigo = new DataGridViewTextBoxColumn();
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Codigo";
            Codigo.Width = 180;
            dataGridView1.Columns.Add(Codigo);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Partida = new DataGridViewTextBoxColumn();
            Partida.HeaderText = "Partida";
            Partida.Name = "Partida";
            Partida.Width = 87;
            dataGridView1.Columns.Add(Partida);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn PartidaFinal = new DataGridViewTextBoxColumn();
            PartidaFinal.HeaderText = "PartidaFinal";
            PartidaFinal.Name = "PartidaFinal";
            PartidaFinal.Width = 85;
            dataGridView1.Columns.Add(PartidaFinal);

        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (comboBox_empresa.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE AÑO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_Cultivo.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE MES", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else
                {
                    GuardarDatosSync();
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("CARGUE AL MENOS 1 REGISTRO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }



        private async void GuardarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            //frbm.label1.Text = "GUARDANDO DATOS..."; // Actualizar el texto del formulario de carga

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarReporteKilosProyectadoBulk();
                });


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              // Mostrar mensaje de éxito
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }
        }

        public void GuardarReporteKilosProyectadoBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<ce_kilos_proyectado> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_selecdesarrollo datos = new cd_selecdesarrollo();
            datos.GuardarKilosProyectadoMerge(dt);

        }

        public List<ce_kilos_proyectado> ConvertirDataGridViewALista(DataGridView dgv)
        {

            string hojaText = string.Empty
                , empText = string.Empty
                , sedText = string.Empty
                , culText = string.Empty;

            // Obtener el valor de la hojaText
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas.Text;
            }
            // Obtener empresa
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
            // Obtener sede
            if (comboBox_Sucursal.InvokeRequired)
            {
                comboBox_Sucursal.Invoke(new MethodInvoker(() =>
                {
                    sedText = comboBox_Sucursal.Text;
                }));
            }
            else
            {
                sedText = comboBox_Sucursal.Text;
            }

            // Obtener cultivo
            if (comboBox_Cultivo.InvokeRequired)
            {
                comboBox_Cultivo.Invoke(new MethodInvoker(() =>
                {
                    culText = comboBox_Cultivo.Text;
                }));
            }
            else
            {
                culText = comboBox_Cultivo.Text;
            }

            List<ce_kilos_proyectado> lista = new List<ce_kilos_proyectado>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_kilos_proyectado entidad = new ce_kilos_proyectado
                    {
                        empresa = empText,
                        sucursal = sedText,
                        Fecha = DateTime.TryParse(row.Cells[0].Value?.ToString(), out DateTime fechaVal) ? fechaVal : (DateTime?)null,
                        cultivo = row.Cells[3].Value?.ToString(),
                        etapa = row.Cells[4].Value?.ToString(),
                        KilosCosecha = decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal kilosVal) ? kilosVal : (decimal?)null,
                        KilosExpo = decimal.TryParse(row.Cells[6].Value?.ToString(), out decimal kilosExp) ? kilosExp : (decimal?)null,
                        mes = "",
                        Año = null,
                        hoja = hojaText,
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        hostname = ce_usuario.HostName(),
                        fecedit = ce_usuario.FechaSistema(),
                        useedit = 0
                    };

                    lista.Add(entidad);
                }
            }

            return lista;
        }

        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Crear columnas
            foreach (var propiedad in propiedades)
            {
                Type tipo = propiedad.PropertyType;

                if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipo = Nullable.GetUnderlyingType(tipo);
                }

                dt.Columns.Add(propiedad.Name, tipo);
            }

            // Llenar filas
            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                foreach (var propiedad in propiedades)
                {
                    var valor = propiedad.GetValue(entidad);
                    fila[propiedad.Name] = valor ?? DBNull.Value;
                }

                dt.Rows.Add(fila);
            }

            return dt;
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0) // CANT-E
            {
                if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back
                )
                {
                    e.Handled = true;
                }

            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3) // CANT-E
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.C)
            //{
            //    copiar_portapapeles(dataGridView1);
            //    e.Handled = true;
            //}
            //if (e.Control && e.KeyCode == Keys.V)
            //{
            //    pegar_portapapeles(dataGridView1);
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                CargaDatos();
                //dataGridView1.DataSource = null;

                textRuta.Text = oOpenFileDialog.FileName;

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                //convierte todas las hojas a un DataSet
                dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                comboBox_Hojas.Items.Clear();
                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    comboBox_Hojas.Items.Add(tabla.TableName);
                }
                comboBox_Hojas.SelectedIndex = 0;

                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            string MessageBoxTitle = "CARGAR KILOS PROY";
            string MessageBoxContent = "¿Desea mostrar los kilos proyectado?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                label_cantreg.Text = "0 REGISTROS";

                if (textRuta.Text != "")
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
                    dataGridView1.ClearSelection();
                    if (dataGridView1.Rows.Count > 1)
                    {
                        label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                    }
                }
                else
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
            }


        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {

            //CARGAR SUCURSAL
            comboBox_Sucursal.DataSource = cn_contabilidad.ListaSucursal(comboBox_empresa.Text);
            comboBox_Sucursal.DisplayMember = "Sucursal"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Sucursal.ValueMember = "Sucursal"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }
    }
}
