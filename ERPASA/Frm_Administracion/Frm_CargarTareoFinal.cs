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
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace ERPASA.Frm_Administracion
{
    public partial class Frm_CargarTareoFinal : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_administracion objcnlog = new cn_administracion();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_CargarTareoFinal()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarTareoFinal_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            //textRuta.Enabled = false;
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;

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
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    // Verificar que la columna sea de tipo string o DateTime
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[column.Index].Value != null)
                        {
                            string cellValue = row.Cells[column.Index].Value.ToString();

                            // Verificar si los primeros 10 caracteres son "31/12/1899"
                            if (cellValue.Length >= 10 && cellValue.Substring(0, 10).Trim() == "31/12/1899")
                            {
                                // Extraer solo la hora, que está en los caracteres después de "31/12/1899"
                                string timePart = cellValue.Substring(11, 5); // Obtener solo la hora (hh:mm)

                                // Asignar solo la hora a la celda
                                row.Cells[column.Index].Value = timePart;

                                // Formatear la columna para mostrar solo la hora
                                column.DefaultCellStyle.Format = "HH:mm:ss"; // Formato solo hora (24h)
                            }
                            // Asignar valores de celdas según el tipo de columna
                            else if (row.Cells[column.Index].ValueType == typeof(DateTime))
                            {
                                DateTime tempDate;
                                // Si el valor es solo fecha, convertir a DateTime
                                if (DateTime.TryParse(cellValue.ToString(), out tempDate))
                                {
                                    row.Cells[column.Index].Value = tempDate.Date; // Solo asignar la fecha, sin la parte de la hora
                                }
                                else
                                {
                                    row.Cells[column.Index].Value = DBNull.Value;
                                }
                            }

                            else
                            {
                                // Si no es "31/12/1899", dejar el valor tal como está
                                row.Cells[column.Index].Value = cellValue;
                            }
                        }
                    }
                }


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
                    string MessageBoxContent = "¿Desea Guardar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GuardarDatosSync();
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
                    GuardarTareoFinalBulk();
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

        public void GuardarTareoFinalBulk()
        {
            // Convertir el DataGridView a una lista de TareoFinal
            List<TareoFinal> listaTareo = ConvertirDataGridViewALista(dataGridView1);

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);
            // ---- Imprimir en consola los primeros 5 registros ----
            int max = Math.Min(1, dt.Rows.Count);
            for (int i = 0; i < max; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine($"Registro {i + 1}:");
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine($"  {col.ColumnName}: {row[col] ?? "NULL"}");
                }
                Console.WriteLine(new string('-', 50));
            }

            // Pasar el DataTable a la capa de datos para inserción masiva
            cd_administracion datos = new cd_administracion();
            datos.GuardarTareoFinalBulk(dt);
        }

        public List<TareoFinal> ConvertirDataGridViewALista(DataGridView dgv)
        {
            string hojaText = string.Empty;

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

            List<TareoFinal> lista = new List<TareoFinal>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    TareoFinal entidad = new TareoFinal
                    {
                        Codigo = row.Cells[0].Value?.ToString(),
                        Ape_Nom = row.Cells[1].Value?.ToString(),
                        Dni = row.Cells[2].Value?.ToString(),
                        Cod_Planilla = row.Cells[3].Value?.ToString(),
                        Fecha_Ing = row.Cells[4].Value != null && DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime fechaIng) ? fechaIng : (DateTime?)null,
                        Empresa = row.Cells[5].Value?.ToString(),
                        Sede = row.Cells[6].Value?.ToString(),
                        Fundo = row.Cells[7].Value?.ToString(),
                        Cargo = row.Cells[8].Value?.ToString(),
                        Area = row.Cells[9].Value?.ToString(),
                        Gerencia = row.Cells[10].Value?.ToString(),
                        Actividad = row.Cells[11].Value?.ToString(),
                        Labor = row.Cells[12].Value?.ToString(),
                        Labor_Correcta = row.Cells[13].Value?.ToString(),
                        Centro_Costo = row.Cells[14].Value?.ToString(),
                        Jornada = row.Cells[15].Value?.ToString(),
                        Fecha_Tareo = row.Cells[16].Value != null && DateTime.TryParse(row.Cells[16].Value.ToString(), out DateTime fechaTareo) ? fechaTareo : (DateTime?)null,
                        Hora_Tareo = ConvertirHora(row.Cells[17].Value),
                        DniSupervisor = row.Cells[18].Value?.ToString(),
                        NombreSupervisor = row.Cells[19].Value?.ToString(),
                        Fecha_Ingreso_Tareo = row.Cells[20].Value != null && DateTime.TryParse(row.Cells[20].Value.ToString(), out DateTime fechaIngresoTareo) ? fechaIngresoTareo : (DateTime?)null,
                        Hora_Ingreso_Tareo = ConvertirHora(row.Cells[21].Value),
                        Fecha_Salida_Tareo = row.Cells[22].Value != null && DateTime.TryParse(row.Cells[22].Value.ToString(), out DateTime fechaSalidaTareo) ? fechaSalidaTareo : (DateTime?)null,
                        Hora_Salida_Tareo = ConvertirHora(row.Cells[23].Value),
                        Horas_En_Sede = ConvertirHora(row.Cells[24].Value),
                        Refrigerio = ConvertirHora(row.Cells[25].Value),
                        Horas_Normales = ConvertirHora(row.Cells[26].Value),
                        Fecha_Ingreso_Real = row.Cells[27].Value != null && DateTime.TryParse(row.Cells[27].Value.ToString(), out DateTime fechaIngresoReal) ? fechaIngresoReal : (DateTime?)null,
                        Hora_Ingreso_Real = ConvertirHora(row.Cells[28].Value),
                        Fecha_Salida_Real = row.Cells[29].Value != null && DateTime.TryParse(row.Cells[29].Value.ToString(), out DateTime fechaSalidaReal) ? fechaSalidaReal : (DateTime?)null,
                        Hora_Salida_Real = ConvertirHora(row.Cells[30].Value),
                        Horas_Pagar = ConvertirHora(row.Cells[31].Value),
                        Horas_Compensadas = ConvertirHora(row.Cells[32].Value),
                        Devolucion_Horas = ConvertirHora(row.Cells[33].Value),
                        Dia_Tareo = row.Cells[34].Value != null && DateTime.TryParse(row.Cells[34].Value.ToString(), out DateTime diaTareo) ? diaTareo : (DateTime?)null,
                        Horas_Nocturnas = ConvertirHora(row.Cells[35].Value),
                        Turno = row.Cells[36].Value?.ToString(),
                        Usuario_Registro = row.Cells[37].Value?.ToString(),
                        Fecha_Registro = row.Cells[38].Value != null && DateTime.TryParse(row.Cells[38].Value.ToString(), out DateTime fechaRegistro) ? fechaRegistro : (DateTime?)null,
                        Usuario_Modificacion = row.Cells[39].Value?.ToString(),
                        Fecha_Modificacion = row.Cells[40].Value != null && DateTime.TryParse(row.Cells[40].Value.ToString(), out DateTime fechaModificacion) ? fechaModificacion : (DateTime?)null,
                        Num_Hora_Ingreso_Tareo = row.Cells[41].Value != null ? Convert.ToDouble(row.Cells[41].Value) : (double?)null,
                        Num_Hora_Ingreso_Real = row.Cells[42].Value != null ? Convert.ToDouble(row.Cells[42].Value) : (double?)null,
                        Num_Hora_Salida_Tareo = row.Cells[43].Value != null ? Convert.ToDouble(row.Cells[43].Value) : (double?)null,
                        Num_Hora_Salida_Real = row.Cells[44].Value != null ? Convert.ToDouble(row.Cells[44].Value) : (double?)null,
                        Horas_No_Validadas_Ingreso = row.Cells[45].Value != null ? Convert.ToDouble(row.Cells[45].Value) : (double?)null,
                        Horas_No_Validadas_Ingreso_Final = row.Cells[46].Value != null ? Convert.ToDouble(row.Cells[46].Value) : (double?)null,
                        Horas_No_Validadas_Salida = row.Cells[47].Value != null ? Convert.ToDouble(row.Cells[47].Value) : (double?)null,
                        Horas_No_Validadas_Salida_Final = row.Cells[48].Value != null ? Convert.ToDouble(row.Cells[48].Value) : (double?)null,
                        HH_NO_Validadas_Final = row.Cells[49].Value != null ? Convert.ToDouble(row.Cells[49].Value) : (double?)null,
                        Horas_extra = row.Cells[50].Value != null ? Convert.ToDouble(row.Cells[50].Value) : (double?)null,
                        Num_Horas_Compensadas = row.Cells[51].Value != null ? Convert.ToDouble(row.Cells[51].Value) : (double?)null,
                        Num_Devolucion_Horas = row.Cells[52].Value != null ? Convert.ToDouble(row.Cells[52].Value) : (double?)null,
                        Almuerzo = row.Cells[53].Value != null ? Convert.ToDouble(row.Cells[53].Value) : (double?)null,
                        Cena = row.Cells[54].Value != null ? Convert.ToDouble(row.Cells[54].Value) : (double?)null,
                        Alimentacion_Total = row.Cells[55].Value != null ? Convert.ToDouble(row.Cells[55].Value) : (double?)null,
                        Horas_Efectivas_Fundo = row.Cells[56].Value != null ? Convert.ToDouble(row.Cells[56].Value) : (double?)null,
                        Sobretiempo_Ingresado = row.Cells[57].Value != null ? Convert.ToDouble(row.Cells[57].Value) : (double?)null,
                        Sobretiempo_Final = row.Cells[58].Value != null ? Convert.ToDouble(row.Cells[58].Value) : (double?)null,
                        Hoja = hojaText,
                        Estado = "S",
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = 0
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

            foreach (var propiedad in propiedades)
            {
                Type tipo = propiedad.PropertyType;

                // Si es Nullable<T>, obtener tipo subyacente T
                if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipo = Nullable.GetUnderlyingType(tipo);
                }

                // Si es TimeSpan, convertirlo a string
                if (tipo == typeof(TimeSpan))
                {
                    dt.Columns.Add(propiedad.Name, typeof(string));
                }
                else
                {
                    dt.Columns.Add(propiedad.Name, tipo);
                }
            }

            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                foreach (var propiedad in propiedades)
                {
                    object valor = propiedad.GetValue(entidad);

                    if (valor is TimeSpan ts)
                    {
                        fila[propiedad.Name] = ts.ToString(@"hh\:mm\:ss");
                    }
                    else
                    {
                        fila[propiedad.Name] = valor ?? DBNull.Value;
                    }
                }

                dt.Rows.Add(fila);
            }

            return dt;
        }

        public TimeSpan? ConvertirHora(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            // Caso 1: ya es TimeSpan
            if (value is TimeSpan ts)
                return ts;

            // Caso 2: Excel envió DateTime (muy común cuando viene 07:00:00)
            if (value is DateTime dt)
                return dt.TimeOfDay;

            // Convertido a texto
            string s = value.ToString().Trim();

            // Caso 3: texto "07:00:00"
            if (TimeSpan.TryParse(s, out TimeSpan ts1))
                return ts1;

            // Caso 4: texto fecha completa
            if (DateTime.TryParse(s, out DateTime dt2))
                return dt2.TimeOfDay;

            // Caso 5: número Excel (0.333333 = 8 am)
            if (double.TryParse(s, out double num))
            {
                if (num >= 0 && num < 1)
                    return TimeSpan.FromDays(num);
            }

            return null;
        }


        public void GuardarTareoFinal()
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

            DateTime currentDateTime = DateTime.Now.Date;

            int filas = dataGridView1.Rows.Count; //Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString())
            int a;
            for (int i = 0; i <= filas - 1; i++)
            //foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                var exrev = cn_administracion.BuscExisteTareoFinal(
                    dataGridView1[38, i].Value.ToString().Trim(), //Fecha
                    dataGridView1[2, i].Value.ToString().Trim() //DNI
                    );

                if (exrev == true)
                {
                    objcnlog.ActualizarTareoFinal(
                    dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Codigo
                    dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Ape_Nom
                    dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Dni
                    dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//Cod_Planilla
                    dataGridView1[4, i].Value.ToString().Trim(),//Fecha_Ing
                    dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//Empresa
                    dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//Cargo
                    dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//

                    dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//Actividad
                    dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//Labor
                    dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//Labor_Correcta
                    dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//Centro_Costo
                    dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//Jornada
                    dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//Fecha_Tareo
                    dataGridView1[17, i].Value.ToString().Trim(),//time7
                    dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//dnisup
                    dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//nombsup
                    dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//fecingtarea

                    dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//Hora_Ingreso_Tareo
                    dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//fecha salida tareo
                    dataGridView1[23, i].Value.ToString().Trim(),//Hora_Salida_Tareo
                    dataGridView1[24, i].Value.ToString().Trim(),//Horas_En_Sede
                    dataGridView1[25, i].Value.ToString().Trim(),//Refrigerio
                    dataGridView1[26, i].Value.ToString().Trim(),//Horas_Normales
                    dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[28, i].Value.ToString().Trim(),//Hora_Ingreso_Real
                    dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[31, i].Value.ToString().Trim(),//Horas_Pagar

                    dataGridView1[32, i].Value.ToString().Trim(),//Horas_Compensadas
                    dataGridView1[33, i].Value.ToString().Trim(),//Devolución_Horas
                    dataGridView1[34, i].Value.ToString().Trim(),//Día_Tareo
                    dataGridView1[35, i].Value.ToString().Trim(),//Horas_Nocturnas
                    dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[38, i].Value.ToString().Trim(),//Fecha_Registro
                    dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[41, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Tareo

                    dataGridView1[42, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Real
                    dataGridView1[43, i].Value.ToString().Trim(),//Num_Hora_Salida_Tareo
                    dataGridView1[44, i].Value.ToString().Trim(),//Num_Hora_Salida_Real
                    dataGridView1[45, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso
                    dataGridView1[46, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso_Final
                    dataGridView1[47, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida
                    dataGridView1[48, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida_Final
                    dataGridView1[49, i].Value.ToString().Trim(),//HH_NO_Validadas_Final
                    dataGridView1[50, i].Value.ToString().Trim(),//Horas_extra
                    dataGridView1[51, i].Value.ToString().Trim(),//Num_Horas_Compensadas

                    dataGridView1[52, i].Value.ToString().Trim(),//Num_Devolución_Horas
                    dataGridView1[53, i].Value.ToString().Trim(),//Almuerzo
                    dataGridView1[54, i].Value.ToString().Trim(),//Cena
                    dataGridView1[55, i].Value.ToString().Trim(),//Alimentación_Total
                    dataGridView1[56, i].Value.ToString().Trim(),//Horas_Efectivas_Fundo
                    dataGridView1[57, i].Value.ToString().Trim(),//Sobretiempo_Ingresado
                    dataGridView1[58, i].Value.ToString().Trim(),//Sobretiempo_Final

                    hojaText,
                    "S",
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod
                    //ce_usuario.HostName(),
                    //ce_usuario.FechaSistema(),
                    //0,
                    //0
                    );

                }

                else //if (dataGridView2[0, i].Value.ToString() != ce_nisira.CodUsuarioExiste) //if (dr.Cells[0].Value.ToString() != ce_rolesbi.CodExiste)
                {

                    //if (dataGridView1[14, i].Value.ToString() == "")
                    //{
                    //    dataGridView1[14, i].Value = 0;
                    //}
                    //else
                    //{
                    //    dataGridView1[14, i].Value.ToString();
                    //}
                    //if (dataGridView1[17, i].Value.ToString() == "")
                    //{
                    //    dataGridView1[17, i].Value = 0;
                    //}
                    //else
                    //{
                    //    dataGridView1[17, i].Value.ToString();
                    //}

                    objcnlog.GuardarTareoFinal(
                    dataGridView1[0, i].Value.ToString().ToUpper().Trim(),//Codigo
                    dataGridView1[1, i].Value.ToString().ToUpper().Trim(),//Ape_Nom
                    dataGridView1[2, i].Value.ToString().ToUpper().Trim(),//Dni
                    dataGridView1[3, i].Value.ToString().ToUpper().Trim(),//Cod_Planilla
                    dataGridView1[4, i].Value.ToString().Trim(),//Fecha_Ing
                    dataGridView1[5, i].Value.ToString().ToUpper().Trim(),//Empresa
                    dataGridView1[6, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[7, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[8, i].Value.ToString().ToUpper().Trim(),//Cargo
                    dataGridView1[9, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[10, i].Value.ToString().ToUpper().Trim(),//

                    dataGridView1[11, i].Value.ToString().ToUpper().Trim(),//Actividad
                    dataGridView1[12, i].Value.ToString().ToUpper().Trim(),//Labor
                    dataGridView1[13, i].Value.ToString().ToUpper().Trim(),//Labor_Correcta
                    dataGridView1[14, i].Value.ToString().ToUpper().Trim(),//Centro_Costo
                    dataGridView1[15, i].Value.ToString().ToUpper().Trim(),//Jornada
                    dataGridView1[16, i].Value.ToString().ToUpper().Trim(),//Fecha_Tareo
                    dataGridView1[17, i].Value.ToString().Trim(),//time7
                    dataGridView1[18, i].Value.ToString().ToUpper().Trim(),//dnisup
                    dataGridView1[19, i].Value.ToString().ToUpper().Trim(),//nombsup
                    dataGridView1[20, i].Value.ToString().ToUpper().Trim(),//fecingtarea

                    dataGridView1[21, i].Value.ToString().ToUpper().Trim(),//Hora_Ingreso_Tareo
                    dataGridView1[22, i].Value.ToString().ToUpper().Trim(),//fecha salida tareo 
                    dataGridView1[23, i].Value.ToString().Trim(),//Hora_Salida_Tareo
                    dataGridView1[24, i].Value.ToString().Trim(),//Horas_En_Sede
                    dataGridView1[25, i].Value.ToString().Trim(),//Refrigerio
                    dataGridView1[26, i].Value.ToString().Trim(),//Horas_Normales
                    dataGridView1[27, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[28, i].Value.ToString().Trim(),//Hora_Ingreso_Real
                    dataGridView1[29, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[30, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[31, i].Value.ToString().Trim(),//Horas_Pagar

                    dataGridView1[32, i].Value.ToString().Trim(),//Horas_Compensadas
                    dataGridView1[33, i].Value.ToString().Trim(),//Devolución_Horas
                    dataGridView1[34, i].Value.ToString().Trim(),//Día_Tareo
                    dataGridView1[35, i].Value.ToString().Trim(),//Horas_Nocturnas
                    dataGridView1[36, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[37, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[38, i].Value.ToString().Trim(),//Fecha_Registro
                    dataGridView1[39, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[40, i].Value.ToString().ToUpper().Trim(),//
                    dataGridView1[41, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Tareo

                    dataGridView1[42, i].Value.ToString().Trim(),//Num_Hora_Ingreso_Real
                    dataGridView1[43, i].Value.ToString().Trim(),//Num_Hora_Salida_Tareo
                    dataGridView1[44, i].Value.ToString().Trim(),//Num_Hora_Salida_Real
                    dataGridView1[45, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso
                    dataGridView1[46, i].Value.ToString().Trim(),//Horas_No_Validadas_Ingreso_Final
                    dataGridView1[47, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida
                    dataGridView1[48, i].Value.ToString().Trim(),//Horas_No_Validadas_Salida_Final
                    dataGridView1[49, i].Value.ToString().Trim(),//HH_NO_Validadas_Final
                    dataGridView1[50, i].Value.ToString().Trim(),//Horas_extra
                    dataGridView1[51, i].Value.ToString().Trim(),//Num_Horas_Compensadas

                    dataGridView1[52, i].Value.ToString().Trim(),//Num_Devolución_Horas
                    dataGridView1[53, i].Value.ToString().Trim(),//Almuerzo
                    dataGridView1[54, i].Value.ToString().Trim(),//Cena
                    dataGridView1[55, i].Value.ToString().Trim(),//Alimentación_Total
                    dataGridView1[56, i].Value.ToString().Trim(),//Horas_Efectivas_Fundo
                    dataGridView1[57, i].Value.ToString().Trim(),//Sobretiempo_Ingresado
                    dataGridView1[58, i].Value.ToString().Trim(),//Sobretiempo_Final

                    hojaText,
                    "S",
                    ce_usuario.FechaSistema(),
                    ce_usuario.usecod,
                    ce_usuario.HostName(),
                    ce_usuario.FechaSistema(),
                    0
                    );

                }
            }

            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();

            //dataGridView1.AllowUserToAddRows = true;

        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox_Hojas.SelectedIndex = -1;
            comboBox_Hojas.Text = "";

            textRuta.Text = "";
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
