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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_Registrar_FacViaje : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        string TipoAlimento;

        public Frm_Registrar_FacViaje()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_Registrar_FacViaje_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            comboBox_TipoProgramacion.SelectedIndex = 0;
            comboBox_empresa.SelectedIndex = 0;
            //comboBox_Sede.SelectedIndex = 0;
            //poner osucro

            //textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_TipoProgramacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sede.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE EMPRESA
                comboBox_Sede.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_empresa.Text);
                comboBox_Sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_Sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void ColumnasDtgv1()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView1.Columns.Add(Dni);
            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Apellidos = new DataGridViewTextBoxColumn();
            Apellidos.HeaderText = "APELLIDOS Y NOMBRES";
            Apellidos.Name = "Column2";
            Apellidos.Width = 85;
            dataGridView1.Columns.Add(Apellidos);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn FechaCese = new DataGridViewTextBoxColumn();
            FechaCese.HeaderText = "FECHA INGRESO";
            FechaCese.Name = "Column3";
            FechaCese.Width = 87;
            dataGridView1.Columns.Add(FechaCese);
            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Area = new DataGridViewTextBoxColumn();
            Area.HeaderText = "AREA";
            Area.Name = "Column3";
            Area.Width = 87;
            dataGridView1.Columns.Add(Area);
        }


        private void ColumnasDtgv2()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView1.Columns.Add(Dni);
            //
            //
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "NOMBRES";
            Nombres.Name = "Column3";
            Nombres.Width = 85;
            dataGridView1.Columns.Add(Nombres);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "EMPRESA";
            Empresa.Name = "Column4";
            Empresa.Width = 87;
            dataGridView1.Columns.Add(Empresa);
            //
            // Column5
            // 
            DataGridViewTextBoxColumn Autorizacion = new DataGridViewTextBoxColumn();
            Autorizacion.HeaderText = "AUTORIZACION";
            Autorizacion.Name = "Column5";
            Autorizacion.Width = 87;
            dataGridView1.Columns.Add(Autorizacion);
        }

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {

            if (textRuta.Text != "")
            {
                CargarDatos();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        private async void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this); // Mostrar como formulario hijo
            Application.DoEvents(); // 🔧 permite que el formulario se pinte

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    mostrarDatos();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AllowUserToAddRows = false;

                // Verificar si alguna columna contiene horas (tipo DateTime o TimeSpan)
                // Verificar si alguna columna contiene horas (tipo DateTime o TimeSpan)
                // Verificar si alguna columna contiene horas (tipo DateTime o TimeSpan)
                //foreach (DataGridViewColumn column in dataGridView1.Columns)
                //{
                //    // Verificar que la columna sea de tipo string o DateTime
                //    foreach (DataGridViewRow row in dataGridView1.Rows)
                //    {
                //        if (row.Cells[column.Index].Value != null)
                //        {
                //            string cellValue = row.Cells[column.Index].Value.ToString();

                //            // Verificar si los primeros 10 caracteres son "31/12/1899"
                //            if (cellValue.Length >= 10 && cellValue.Substring(0, 10).Trim() == "31/12/1899")
                //            {
                //                // Extraer solo la hora, que está en los caracteres después de "31/12/1899"
                //                string timePart = cellValue.Substring(11, 5); // Obtener solo la hora (hh:mm)

                //                // Asignar solo la hora a la celda
                //                row.Cells[column.Index].Value = timePart;

                //                // Formatear la columna para mostrar solo la hora
                //                column.DefaultCellStyle.Format = "HH:mm:ss"; // Formato solo hora (24h)
                //            }
                //            // Asignar valores de celdas según el tipo de columna
                //            else if (row.Cells[column.Index].ValueType == typeof(DateTime))
                //            {
                //                DateTime tempDate;
                //                // Si el valor es solo fecha, convertir a DateTime
                //                if (DateTime.TryParse(cellValue.ToString(), out tempDate))
                //                {
                //                    row.Cells[column.Index].Value = tempDate.Date; // Solo asignar la fecha, sin la parte de la hora
                //                }
                //                else
                //                {
                //                    row.Cells[column.Index].Value = DBNull.Value;
                //                }
                //            }

                //            else
                //            {
                //                // Si no es "31/12/1899", dejar el valor tal como está
                //                row.Cells[column.Index].Value = cellValue;
                //            }
                //        }
                //    }
                //}


                // Verificar el número de registros y mostrar un mensaje adecuado
                if (dataGridView1.Rows.Count > 1)
                {
                    label_cantreg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
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


        public void mostrarDatos()
        {
            string hojaText = string.Empty, hoja;
            ////////////////////////////////////
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

            // Cargar los datos desde el DataTable
            dtg = dtsTablas.Tables[hojaText];
            dataGridView1.ClearSelection();


            // Rellenar el DataGridView con los datos
            //dataGridView1.DataSource = dtg;
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            // Obtener datagridview
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new MethodInvoker(() =>
                {
                    dataGridView1.AllowUserToAddRows = false;
                }));
            }

            if (dataGridView1.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string MessageBoxTitle = "REGISTRO";
                    string MessageBoxContent = "¿Desea Guardar viaje?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        cn_logistica.BuscExisteTransporteViaje(
                            dateTimePicker_FecInicio.Value.Date,
                            dateTimePicker_FecFin.Value.Date);

                        GuardarDatosSync();
                        //GuardarFacViaje();
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
                    GuardarFacturacionViajeBulk();
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
            }
        }


        public void GuardarFacturacionViajeBulk()
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<sper_facviajes> listaTareo = ConvertirDataGridViewALista(dataGridView1);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_logistica datos = new cd_logistica();
            datos.GuardarReporteFacturacionBulk(dt);

            // Mostrar mensaje de éxito
            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();
        }


        public List<sper_facviajes> ConvertirDataGridViewALista(DataGridView dgv)
        {
            string hojaText = string.Empty;

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

            List<sper_facviajes> lista = new List<sper_facviajes>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // Evitar agregar la fila vacía
                {
                    string tipo = ""; decimal costo = 0;
                    if (row.Cells[14].Value.ToString().ToUpper().Trim() == "ASA PV1" ||
                        row.Cells[14].Value.ToString().ToUpper().Trim() == "IA EL ALTO" ||
                        row.Cells[14].Value.ToString().ToUpper().Trim() == "SAN TELMO PV1 IA")
                    {
                        tipo = "LLEGADA";
                    }
                    else
                    {
                        tipo = "SALIDA";
                    }

                    if (row.Cells[11].Value.ToString() == "")
                    {
                        row.Cells[11].Value = 1;
                    }

                    costo = (decimal)((double)Convert.ToDouble(row.Cells[9].Value) / (double)Convert.ToInt32(row.Cells[11].Value));


                    sper_facviajes entidad = new sper_facviajes
                    {
                        fecinicio = row.Cells[0].Value != null ? Convert.ToDateTime(row.Cells[0].Value) : default(DateTime), // "fecinicio"
                        dia = row.Cells[1].Value != null ? Convert.ToInt32(row.Cells[1].Value) : 0,  // "dia"
                        semana = row.Cells[2].Value != null ? Convert.ToInt32(row.Cells[2].Value) : 0,  // "semana" (tomado de la columna 2 del DataGridView)
                        nroreporte = row.Cells[3].Value?.ToString(),  // "nroreporte"
                        localidad = row.Cells[4].Value?.ToString(),  // "localidad"
                        unidad = row.Cells[5].Value?.ToString(),  // "unidad"
                        proveedor = row.Cells[6].Value?.ToString(),  // "proveedor"
                        ruc = row.Cells[7].Value?.ToString(),  // "ruc"
                        placa = row.Cells[8].Value?.ToString(),  // "placa"
                        costo = row.Cells[9].Value != null ? Convert.ToDecimal(row.Cells[9].Value) : 0m,  // "costo"
                        area = row.Cells[10].Value?.ToString(),  // "area"
                        cantreal = row.Cells[11].Value != null ? Convert.ToInt32(row.Cells[11].Value) : 0,  // "cantreal"
                        capacidad = row.Cells[12].Value != null ? Convert.ToInt32(row.Cells[12].Value) : 0,  // "capacidad"
                        porc_ocupa = row.Cells[13].Value != null ? Convert.ToDecimal(row.Cells[13].Value) : 0m,  // "porc_ocupa"
                        destino = row.Cells[14].Value?.ToString(),  // "destino"
                        comentario = row.Cells[15].Value?.ToString(),  // "comentario"
                        tipo = tipo,  // "tipo"
                        costo_percapita = costo,  // "costo_percapita"
                        empresa = "",  // "empresa"
                        sede = "",  // "sede"
                        hoja = hojaText,  // Utilizamos la variable hojaText previamente definida
                        feccre = ce_usuario.FechaSistema(),  // Fecha de creación
                        usereg = ce_usuario.usecod,  // Usuario que registra
                        hostname = ce_usuario.HostName(),  // Hostname del sistema
                        fecedit = ce_usuario.FechaSistema(),  // Fecha de edición
                        useedit = 0,  // Valor fijo o predeterminado
                        useelim = 0  // Valor por defecto
                    };

                    // Agregar la entidad a la lista
                    lista.Add(entidad);
                }
            }


            return lista;
        }

        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            // Crear el DataTable
            DataTable dt = new DataTable();

            // Obtener las propiedades de la clase T (MiEntidad)
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Crear las columnas del DataTable basadas en las propiedades de la clase
            foreach (var propiedad in propiedades)
            {
                // Definir la columna con el nombre de la propiedad y el tipo de datos correspondiente
                dt.Columns.Add(propiedad.Name, propiedad.PropertyType);
            }

            // Llenar el DataTable con los valores de la lista
            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                // Asignar valores de las propiedades a las columnas del DataTable
                foreach (var propiedad in propiedades)
                {
                    fila[propiedad.Name] = propiedad.GetValue(entidad) ?? DBNull.Value; // Maneja valores null
                }

                dt.Rows.Add(fila);
            }

            return dt;
        }


        public void GuardarFacViaje()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            string MessageBoxTitle = "REGISTRO";
            string MessageBoxContent = "¿Desea Guardar viaje?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                cn_logistica.BuscExisteTransporteViaje(dateTimePicker_FecInicio.Value.Date,
                    dateTimePicker_FecFin.Value.Date);

                int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
                int a;
                for (int i = 0; i <= filas - 1; i++)
                //foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string tipo = ""; decimal costo = 0;
                    if (dataGridView1[14, i].Value.ToString().ToUpper().Trim() == "ASA PV1" ||
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim() == "IA EL ALTO" ||
                        dataGridView1[14, i].Value.ToString().ToUpper().Trim() == "SAN TELMO PV1 IA")
                    {
                        tipo = "LLEGADA";
                    }
                    else
                    {
                        tipo = "SALIDA";
                    }

                    if (dataGridView1[11, i].Value.ToString() == "")
                    {
                        dataGridView1[11, i].Value = 1;
                    }

                    costo = (decimal)((double)Convert.ToDouble(dataGridView1[9, i].Value) / (double)Convert.ToInt32(dataGridView1[11, i].Value));

                    objcnlog.GuardarTransporteViaje(
                    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    Convert.ToDateTime(dataGridView1[0, i].Value),//FECHA INICIO
                    Convert.ToInt32(dataGridView1[1, i].Value),//DIA
                    Convert.ToInt32(dataGridView1[2, i].Value),//SEMANA
                    dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//NUM REPORTE
                    dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//LOCALIDAD
                    dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//UNIDAD
                    dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//PROVEEDOR
                    dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//RUC
                    dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//PLACA
                    Convert.ToDecimal(dataGridView1[9, i].Value),//COSTO
                    dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//AREA
                    Convert.ToInt32(dataGridView1[11, i].Value),//CANT REAL
                    Convert.ToInt32(dataGridView1[12, i].Value),//CAPACIDAD
                    Convert.ToDecimal(dataGridView1[13, i].Value).ToString().ToUpper().Trim(),//PORC OCUPABILIDAD
                    dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//DESTINO
                    dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//COMENTARIO
                    tipo,
                    costo,
                    comboBox_empresa.Text,
                    comboBox_Sede.Text,
                    comboBox_Hojas.Text,
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod,
                    ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    0,
                    0
                    );


                    //cn_logistica.BuscExisteTransporteViaje(dataGridView1[3, i].Value.ToString().Trim(), Convert.ToDateTime(dataGridView1[0, i].Value).Date);
                    //if (dataGridView1[3, i].Value.ToString().Trim() == ce_transporte.codigo & Convert.ToDateTime(dataGridView1[0, i].Value).Date == ce_transporte.FechaInicio.Date)
                    //{
                    //    string tipo = ""; decimal costo = 0;
                    //    if (dataGridView1[14, i].Value.ToString().ToUpper().Trim() == "ASA PV1" ||
                    //        dataGridView1[14, i].Value.ToString().ToUpper().Trim() == "IA EL ALTO" ||
                    //        dataGridView1[14, i].Value.ToString().ToUpper().Trim() == "SAN TELMO PV1 IA")
                    //    {
                    //        tipo = "LLEGADA";
                    //    }
                    //    else
                    //    {
                    //        tipo = "SALIDA";
                    //    }
                    //    if (dataGridView1[11, i].Value.ToString() == "")
                    //    {
                    //        dataGridView1[11, i].Value = 1;
                    //    }

                    //    costo = (decimal)((double)Convert.ToDouble(dataGridView1[9, i].Value) / (double)Convert.ToInt32(dataGridView1[11, i].Value));


                    //    objcnlog.ActualizarTransporteViaje(
                    //    //Convert.ToInt32(dataGridView1[0, i].Value).ToString("D8").Trim(),//DNI
                    //    Convert.ToDateTime(dataGridView1[0, i].Value),//FECHA INICIO
                    //    Convert.ToInt32(dataGridView1[1, i].Value),//DIA
                    //    Convert.ToInt32(dataGridView1[2, i].Value),//SEMANA
                    //    dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//NUM REPORTE
                    //    dataGridView1[4, i].Value.ToString().ToUpper().Trim(),//LOCALIDAD
                    //    dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//UNIDAD
                    //    dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//PROVEEDOR
                    //    dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//RUC
                    //    dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//PLACA
                    //    Convert.ToDecimal(dataGridView1[9, i].Value),//COSTO
                    //    dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//AREA
                    //    Convert.ToInt32(dataGridView1[11, i].Value),//CANT REAL
                    //    Convert.ToInt32(dataGridView1[12, i].Value),//CAPACIDAD
                    //    Convert.ToDecimal(dataGridView1[13, i].Value).ToString().ToUpper().Trim(),//PORC OCUPABILIDAD
                    //    dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//DESTINO
                    //    dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//COMENTARIO
                    //    tipo,
                    //    costo,
                    //    comboBox_empresa.Text,
                    //    comboBox_Sede.Text,
                    //    comboBox_Hojas.Text,
                    //    ce_usuario.FechaSistema(),
                    //    ce_usuario.usecod
                    //    //ce_usuario.HostName(),
                    //    //ce_usuario.FechaSistema(),
                    //    //0,
                    //    //0
                    //    );

                    //}

                    //else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                    //{

                    //}
                }

                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                ng.ShowDialog();
            }

            dataGridView1.AllowUserToAddRows = true;

        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;

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

    }
}
