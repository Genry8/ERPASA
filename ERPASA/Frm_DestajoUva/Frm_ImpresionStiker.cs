using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using CrystalDecisions.CrystalReports.Engine;
using ERPASA.Msbox;
using ERPASA.Reportes;
using ERPASA.Reportes.Acopio;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Datamatrix;
using ZXing.Presentation;

namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_ImpresionStiker : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_packing objcnpack = new cn_packing();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtgCampos;
        private List<bool> checkBoxStates = new List<bool>();
        DataTable dniTable = new DataTable();

        private CancellationTokenSource _cts;

        cn_sst objcnsst = new cn_sst();
        string codImpresion, codQR;
        // Lista para almacenar los estados de los checkboxes (si están marcados o no)


        public Frm_ImpresionStiker()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dataGridView2.EditingControlShowing += dataGridView2_EditingControlShowing;
        }

        private void Frm_ImpresionStiker_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            CargarImpresoras();
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //Fecha_Proceso.Value = DateTime.Parse("2025-09-24").Date;
            comboBox_Puestotrabajo.Text = "SELECCION";
            guna2TextBox_Cantidad.Focus();
            guna2TextBox_Cantidad.Text = "30";
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            //comboBox_nave.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_linea.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Puestotrabajo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImpresoras.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarDatosComboBox()
        {
            //comboBox_nave.DataSource = cn_packing.ListaNave();
            //comboBox_nave.DisplayMember = "Nave"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_nave.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_linea.DataSource = cn_packing.ListaLinea();
            //comboBox_linea.DisplayMember = "Linea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_linea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_Puestotrabajo.DataSource = cn_packing.ListaPuestoTrabajo();
            comboBox_Puestotrabajo.DisplayMember = "PuestoTrabajo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_Puestotrabajo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void CargarImpresoras()
        {
            comboBoxImpresoras.Items.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxImpresoras.Items.Add(printer);
            }

            if (comboBoxImpresoras.Items.Count > 0)
            {
                PrintDocument pd = new PrintDocument();
                comboBoxImpresoras.SelectedItem = pd.PrinterSettings.PrinterName;
            }
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarParaImprimirSticker()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{

            //string naveText = string.Empty, lineaText = string.Empty,
            string trabajoText = string.Empty;
            //string nave, linea, 
            string trabajo;

            ////////////////////////////////////
            //if (comboBox_nave.InvokeRequired)
            //{
            //    comboBox_nave.Invoke(new MethodInvoker(() =>
            //    {
            //        naveText = comboBox_nave.Text;
            //    }));
            //}
            //else
            //{
            //    naveText = comboBox_nave.Text;
            //}
            //////////////////////////////////////
            //if (comboBox_linea.InvokeRequired)
            //{
            //    comboBox_linea.Invoke(new MethodInvoker(() =>
            //    {
            //        lineaText = comboBox_linea.Text;
            //    }));
            //}
            //else
            //{
            //    lineaText = comboBox_linea.Text;
            //}
            ////////////////////////////////////
            if (comboBox_Puestotrabajo.InvokeRequired)
            {
                comboBox_Puestotrabajo.Invoke(new MethodInvoker(() =>
                {
                    trabajoText = comboBox_Puestotrabajo.Text;
                }));
            }
            else
            {
                trabajoText = comboBox_Puestotrabajo.Text;
            }

            //if (naveText == "SELECCIONE")
            //{
            //    nave = "%";
            //}
            //else
            //{
            //    nave = naveText;
            //}
            //if (lineaText == "SELECCIONE")
            //{
            //    linea = "%";
            //}
            //else
            //{
            //    linea = lineaText;
            //}

            if (trabajoText == "SELECCIONE")
            {
                trabajo = "%";
            }
            else
            {
                trabajo = trabajoText;
            }


            //dataGridView3.ReadOnly = true;

            dtg = cn_planilla.PlanillaProgTareo(
                Convert.ToDateTime("2025-12-01").Date
                , "%", "%", trabajo);

            //DataGridViewCheckBoxColumn estado = new DataGridViewCheckBoxColumn();
            //estado.HeaderText = "estado";
            //dataGridView2.Columns.Insert(0, estado);

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            CargarDatosSync();
        }

        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (comboBox_Puestotrabajo.Text.Trim().Equals("SELECCIONE"))
                {
                    MessageBox.Show("SELECCIONE PUESTO TRABAJO");
                }
                else if (guna2TextBox_Cantidad.Text.Trim().Equals(""))
                {
                    MessageBox.Show("FALTA CANTIDAD");
                }
                else
                {
                    checkBox1.Checked = false;
                    //CargarDatosSync();

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
                            BuscarParaImprimirSticker();
                            dataGridView2.ClearSelection();
                        });

                        // 3. Actualizar UI
                        dataGridView2.SuspendLayout();
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = dtg;
                        dataGridView2.AllowUserToAddRows = false;
                        // Asegúrate de que la primera columna sea editable
                        // Establecer ReadOnly en false para permitir la edición de todas las columnas
                        // Asegúrate de que las columnas sean editables (ReadOnly = false)
                        foreach (DataColumn column in dtg.Columns)
                        {
                            column.ReadOnly = false; // Deshabilita el solo lectura en todas las columnas
                        }
                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            column.ReadOnly = true; // Establecer todas las columnas como solo lectura
                        }
                        // Habilitar la edición solo para la primera columna
                        if (dataGridView2.Columns.Count > 0)
                        {
                            dataGridView2.Columns[0].ReadOnly = false; // Permitir la edición solo de la primera columna
                        }

                        foreach (DataGridViewColumn col in dataGridView2.Columns)
                        {
                            col.MinimumWidth = 60;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //col.ReadOnly = true;
                        }

                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView2.AutoResizeColumns();
                        // 👉 Agregar nueva columna al final del DataTable
                        DataColumn nuevaColumna = new DataColumn("Cantidad", typeof(string));
                        nuevaColumna.DefaultValue = guna2TextBox_Cantidad.Text.ToString().Trim(); // Valor por defecto si lo deseas
                        nuevaColumna.ReadOnly = false;  // Asegúrate de que sea editable
                        dtg.Columns.Add(nuevaColumna);

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
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }


        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private async void ExportarExcel()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var frbm = new frm_dowloadExcel();

            frbm.OnCancelRequested = () =>
            {
                _cts?.Cancel();
            };

            frbm.Show(this);

            try
            {

                await Task.Run(() =>
                {
                    try
                    {
                        objexcel_progress.exportarexcelTimer(dataGridView2, frbm, token);
                    }
                    catch (OperationCanceledException)
                    {
                        // Re-lanzamos para que el catch externo lo maneje
                        throw;
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Exportación cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frbm.Close();
                Cursor.Current = Cursors.Default;
            }
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            //AlertaGuardarProgVolcado();
        }


        private async void GuardarDatosSync(DataTable table, string sessionId, string nombreImpresora)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                await Task.Run(() =>
                {
                    GuardarImpresionPersonasBulk(table, sessionId, nombreImpresora);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar datos repetidos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /*
        public void GuardarImpresionPersonasBulk(DataTable table)
        {

            // Convertir el DataGridView a una lista de ce_tareofinal (si es necesario)
            List<CeImpresionStickerPersona> listaTareo = ConvertirDataGridViewALista(table);  // Aquí pasas tu DataGridView

            // Convertir la lista a un DataTable
            DataTable dt = ConvertirListaADataTable(listaTareo);

            // Ahora, pasamos el DataTable a la capa de datos para que se realice la inserción masiva
            cd_administracion datos = new cd_administracion();
            datos.GuardarStickerPersonasBulk(dt);
        }
        */

        public void GuardarImpresionPersonasBulk(DataTable table, string sessionId, string nombreImpresora)
        {
            List<CeImpresionStickerPersona> listaTareo = ConvertirDataGridViewALista(table, sessionId);
            DataTable dt = ConvertirListaADataTable(listaTareo);

            cd_administracion datos = new cd_administracion();
            datos.GuardarStickerPersonasBulk(dt);

            // 🔁 Obtener datos insertados y mostrarlos
            DataTable datosInsertados = datos.ObtenerStickersPorSessionId(sessionId);

            // Mostrar en un DataGridView o retornarlo como prefieras
            // Por ejemplo:
            MostrarDatosInsertadosParaImprimir(datosInsertados, nombreImpresora);
        }

        private async void MostrarDatosInsertadosParaImprimir(DataTable datos, string nombreImpresora)
        {
            if (datos != null && datos.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;

                // Crear instancia del formulario de carga
                Msbox.frm_cargando frbm = null;

                // Mostrar el formulario en el hilo principal
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        frbm = new Msbox.frm_cargando();
                        frbm.Show(this); // Mostrar como formulario hijo
                        frbm.label1.Text = "IMPRIMIENDO..."; // imprimir

                    }));
                }
                else
                {
                    frbm = new Msbox.frm_cargando();
                    frbm.Show(this);
                    frbm.label1.Text = "IMPRIMIENDO..."; // imprimir

                }

                try
                {
                    // Procesar en segundo plano
                    await Task.Run(() =>
                    {
                        dtg = datos;
                        //// Actualizar el DataGridView en el hilo principal
                        //DataGridView1.Invoke(new Action(() =>
                        //{
                        //    DataGridView1.Columns.Clear();
                        //    DataGridView1.DataSource = dtg;
                        //    DataGridView1.AllowUserToAddRows = false;
                        //    DataGridView1.ClearSelection();
                        //}));
                    });

                    // Ejecutar en el hilo principal
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            ImprimirReporteDestajo(nombreImpresora);
                        }));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al devolver datos: " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;

                    // Cerrar el formulario de carga en el hilo principal
                    if (frbm != null)
                    {
                        if (frbm.InvokeRequired)
                        {
                            frbm.Invoke(new Action(() => frbm.Close()));
                        }
                        else
                        {
                            frbm.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos insertados.");
            }
        }

        public List<CeImpresionStickerPersona> ConvertirDataGridViewALista(DataTable dgv, string sessionId)
        {


            //string naveText = string.Empty, lineaText = string.Empty,
            string trabajoText = string.Empty;
            //string nave, linea, 
            string trabajo //idnave = string.Empty
                           //, idlinea = string.Empty, 
              , idtrabajo = string.Empty;

            //////////////////////////////////////
            //if (comboBox_nave.InvokeRequired)
            //{
            //    comboBox_nave.Invoke(new MethodInvoker(() =>
            //    {
            //        naveText = comboBox_nave.Text;
            //        idnave = comboBox_nave.SelectedValue.ToString();
            //    }));
            //}
            //else
            //{
            //    naveText = comboBox_nave.Text;
            //}
            //////////////////////////////////////
            //if (comboBox_linea.InvokeRequired)
            //{
            //    comboBox_linea.Invoke(new MethodInvoker(() =>
            //    {
            //        lineaText = comboBox_linea.Text;
            //        idlinea = comboBox_linea.SelectedValue.ToString();
            //    }));
            //}
            //else
            //{
            //    lineaText = comboBox_linea.Text;
            //}
            ////////////////////////////////////
            if (comboBox_Puestotrabajo.InvokeRequired)
            {
                comboBox_Puestotrabajo.Invoke(new MethodInvoker(() =>
                {
                    trabajoText = comboBox_Puestotrabajo.Text;
                    idtrabajo = comboBox_Puestotrabajo.SelectedValue.ToString();
                }));
            }
            else
            {
                trabajoText = comboBox_Puestotrabajo.Text;
            }

            //if (naveText == "SELECCIONE")
            //{
            //    nave = "%";
            //}
            //else
            //{
            //    nave = naveText;
            //}
            //if (lineaText == "SELECCIONE")
            //{
            //    linea = "%";
            //}
            //else
            //{
            //    linea = lineaText;
            //}

            if (trabajoText == "SELECCIONE")
            {
                trabajo = "%";
            }
            else
            {
                trabajo = trabajoText;
            }

            List<CeImpresionStickerPersona> lista = new List<CeImpresionStickerPersona>();

            foreach (DataRow row in dgv.Rows)
            {
                // No existe IsNewRow ni CheckBox directamente en DataTable.
                // Si tienes una columna booleana "Seleccionado" para filtrar, valida así:
                // if (row.Field<bool>("Seleccionado") == true)
                // Si no, procesa todas las filas o agrega tu lógica de filtrado aquí.

                CeImpresionStickerPersona entidad = new CeImpresionStickerPersona
                {
                    Id = 0,
                    FecProceso = Convert.ToDateTime("2025-12-01").Date,
                    IdGrupoPersona = row[0] != DBNull.Value ? Convert.ToInt32(row[0]) : (int?)null,

                    IdNave = "00",
                    Nave = "S/N",

                    IdLinea = "00",
                    Linea = "S/L",

                    IdPuestoTrabajo = idtrabajo != null ? idtrabajo : string.Empty,
                    PuestoTrabajo = trabajoText?.ToString(),

                    Dni = row[1]?.ToString(),
                    IdCodigo = "0".ToString(),
                    Codigo = row[2]?.ToString(),

                    Cantidad = row[3] != DBNull.Value ? Convert.ToInt32(row[3]) : (int?)null,

                    Obs = "--",

                    Estado = "S",

                    FecCre = ce_usuario.FechaSistema(),
                    UseReg = ce_usuario.usecod,
                    Hostname = ce_usuario.HostName(),

                    FecEdit = ce_usuario.FechaSistema(),
                    UseEdit = 0,
                    UseElim = 0,
                    SessionId = sessionId,
                };

                lista.Add(entidad);
            }


            return lista;
        }

        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {
                Type tipoColumna = propiedad.PropertyType;

                if (tipoColumna.IsGenericType && tipoColumna.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipoColumna = Nullable.GetUnderlyingType(tipoColumna);
                }

                dt.Columns.Add(propiedad.Name, tipoColumna);
            }

            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();
                foreach (var propiedad in propiedades)
                {
                    fila[propiedad.Name] = propiedad.GetValue(entidad) ?? DBNull.Value;
                }
                dt.Rows.Add(fila);
            }

            return dt;
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

        private void guna2TextBoxSearch_TextChanged3(object sender, EventArgs e)
        {

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            if (dtg != null)
            {
                DataView dv = dtg.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            // Obtener el DataTable del dataGridView2
            DataTable dt = dataGridView2.DataSource as DataTable;

            if (dt != null)
            {
                DataView dv = dt.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Sin filtro si el textbox está vacío
                }
                else
                {
                    // Generar condiciones para todas las columnas de tipo string
                    var condiciones = dt.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Filtrar solo texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                }
            }
        }


        private void toolStripButton_imprimir_Click_1(object sender, EventArgs e)
        {
            guna2TextBox_Cantidad.Focus();

            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>()
                .Where(p => Convert.ToBoolean(p.Cells[0].Value) == true)
                .Count();

            if (filas1 > 0)
            {
                GenerarDniPorCantidad(comboBoxImpresoras.Text);

            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
            }
        }

        /*
        private void toolStripButton_imprimir_Click_1(object sender, EventArgs e)
        {
            Fecha_Proceso.Focus();
            int filas1 = dataGridView2.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells[0].Value) == true).Count();

            if (filas1 > 0)
            {
                GenerarDniPorCantidad();
            }
            else
            {
                MessageBox.Show("ELIJA AL MENOS UN REGISTRO");
            }
        }
        */

        public void GenerarDniPorCantidad(string nombreImpresora)
        {
            // Crear DataTable con las columnas necesarias
            dniTable = new DataTable();
            dniTable.Columns.Add("Id", typeof(int));         // o string, si tu Id es textual
            dniTable.Columns.Add("Dni", typeof(string));
            dniTable.Columns.Add("Codigo", typeof(string));
            dniTable.Columns.Add("Cantidad", typeof(int));

            // Iterar por las filas del DataGridView
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    // Suponiendo que las columnas están en estas posiciones:
                    // Id -> columna 1
                    // Dni -> columna 3
                    // Codigo -> columna 5
                    // Cantidad -> columna 4
                    int cantidad = Convert.ToInt32(row.Cells[5].Value);

                    for (int i = 0; i < cantidad; i++)
                    {
                        dniTable.Rows.Add(
                            row.Cells[1].Value //id
                        , row.Cells[3].Value?.ToString() //dni
                        , row.Cells[2].Value?.ToString() //cosigo
                        , row.Cells[5].Value); // Cantidad = 1 por fila repetida

                    }

                }
            }

            string sessionId = Guid.NewGuid().ToString();
            GuardarDatosSync(dniTable, sessionId, nombreImpresora);

            //MessageBox.Show("Filas generadas: " + dniTable.Rows.Count);
            //GuardarDatosSync(dniTable);

        }

        private void guna2TextBox_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;  // Previene la entrada de caracteres no numéricos
            }
            // Verifica si se presionó Enter (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido "beep" al presionar Enter
                CargarDatosSync(); // Llama a tu método
                return;
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 5)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(Cantidad_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(Cantidad_KeyPress);
                }
            }
        }

        private void Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Asegurarse que sea la columna "Cantidad"
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("La cantidad no puede estar vacía.");
                    e.Cancel = true;
                    return;
                }

                //if (!int.TryParse(e.FormattedValue.ToString(), out int cantidad) || cantidad <= 0)
                //{
                //    MessageBox.Show("La cantidad debe ser un número mayor a cero.");
                //    e.Cancel = true;
                //}
            }
        }

        public void ImprimirReporteDestajoOr(string nombreImpresora)
        {
            // Verificar que la impresora esté en la lista de impresoras instaladas
            if (!ImpresoraActiva(nombreImpresora))
            {
                MessageBox.Show("Impresora no encontrada o no está disponible/activa.",
                                "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataSet_DestajoUva objDs = new DataSet_DestajoUva();

                foreach (DataRow row in dtg.Rows)
                {
                    string codImpresion =
                        //row[3].ToString().Trim() + "-" + row[5].ToString().Trim()+ "-" + 
                        row[11].ToString().Trim() + "-"
                        + row[0].ToString().Trim().PadLeft(10, '0');

                    string codQR = row[11].ToString().Trim() + "-"
                        + row[0].ToString().Trim();

                    objDs.Tables[0].Rows.Add(new object[]
                    {
                row[0],                           // ID
                codImpresion,                    // Código
                row[9].ToString().ToUpper(),     // DNI
                row["Nave"].ToString().Trim(),   // Nave
                row["Linea"].ToString().Trim(),  // Línea
                codQR,                           // Correlativo 
                Convert.ToDateTime(row[1]).ToShortDateString(), // Fecha
                row["PuestoTrabajo"].ToString().Substring(0,1)   // Primera letra del puesto
                    });
                }

                Frm_DestajoUva.CrystalReportDestajoUva objCryRep = new Frm_DestajoUva.CrystalReportDestajoUva();

                objCryRep.Load(@"~\CrystalReportDestajoUva.rpt");
                objCryRep.SetDataSource(objDs);

                objCryRep.PrintOptions.PrinterName = nombreImpresora;
                objCryRep.PrintToPrinter(1, false, 0, 0);

                objCryRep.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImprimirReporteDestajoOF(string nombreImpresora)
        {
            if (!ImpresoraActiva(nombreImpresora))
            {
                MessageBox.Show("Impresora no encontrada o no está disponible/activa.",
                                "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // --- PREPARAR DATOS ---
                DataTable dtOrigen = dtg;
                DataSet_DestajoUva objDs = new DataSet_DestajoUva();
                DataTable tablaDestino = objDs.Tables[0];

                int colID = 0, colFecha = 1, colDNI = 9, colCod = 11;
                foreach (DataRow row in dtOrigen.Rows)
                {
                    string cod = row[colCod].ToString().Trim();
                    string id = row[colID].ToString().Trim();

                    tablaDestino.Rows.Add(new object[]
                    {
                row[colID],
                $"{cod}-{id.PadLeft(10,'0')}",           // CodImpresion
                row[colDNI].ToString().ToUpper(),        // DNI
                "",//row["Nave"].ToString().Trim(), 
                "",//row["Linea"].ToString().Trim(),
                "",//$"{cod}-{id}",                           // CodQR
                "", //FECHA HORA
                row["PuestoTrabajo"].ToString().Substring(0,1), // PuestoTrabajo
                GenerarDataMatrix($"{cod}-{id}")         // columna Matrix (byte[])
                    });
                }

                // --- CONFIGURAR CRYSTAL ---
                using (var objCryRep = new Frm_DestajoUva.CrystalReportDestajoSticker())
                {
                    objCryRep.Load(@"~\CrystalReportDestajoSticker.rpt");

                    objCryRep.SetDataSource(objDs);

                    objCryRep.PrintOptions.PrinterName = nombreImpresora;
                    objCryRep.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;

                    // 🔥 Aquí van tus dos líneas nuevas:
                    objCryRep.PrintOptions.NoPrinter = false;        // Usar impresora real

                    objCryRep.PrintToPrinter(1, false, 0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message,
                                "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public byte[] GenerarDataMatrix(string texto)
        {
            var writer = new ZXing.BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 200,
                    Height = 200,
                    Margin = 0,
                    PureBarcode = true
                }
            };

            using (Bitmap img = writer.Write(texto))
            {
                // DPI correcto para Zebra
                img.SetResolution(203, 203);

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        public void ImprimirReporteDestajo(string zebraIP)
        {
            List<StickerData> lista = new List<StickerData>();

            int colID = 0, colFecha = 1, colDNI = 9, colNombre = 22, colCod = 11;


            foreach (DataRow row in dtg.Rows)
            {
                string cod = row[colCod].ToString().Trim();
                string id = row[colID].ToString().Trim();
                // Separar todas las palabras
                string apenom = row[colNombre].ToString().Trim();

                //MessageBox.Show("apenom "+apenom);
                // Separar por espacio usando la sobrecarga correcta
                string[] partes = apenom.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                // Primer apellido
                string primerApellido = partes[0];

                // Primer nombre (asumiendo 2 apellidos)
                string primerNombre = partes.Length > 2 ? partes[2] : "";

                // Inicial del nombre
                string inicialNombre = primerNombre.Length > 0 ? primerNombre.Substring(0, 1) : "";


                lista.Add(new StickerData
                {
                    Dni = row[colDNI].ToString().ToUpper(),                       // Para DataMatrix
                    Correlativo = row[colID].ToString(),                       // Para DataMatrix
                    DataMatrix = $"{cod}-{id}",    // Para DataMatrix
                    Codigo = row["PuestoTrabajo"].ToString().Substring(0, 1),         // Código visible
                    Numero = $"{cod}-{id.PadLeft(7, '0')}", // Puesto
                    ApeNom = $"{primerApellido} {primerNombre}" // 
                });
            }

            string zpl = GenerarZPL_3porFila(lista);

            ImprimirPorNombre(zebraIP, zpl);
            //ListarPuertosTCPIP();
            //EnviarZPL_porIP("10.51.51.17", 9100, zpl);
            //EnviarZPL_porIP(zebraIP, 9100, zpl);
        }

        public bool ImpresoraActiva(string nombreImpresora)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (string.Equals(printer, nombreImpresora, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public string ObtenerPuertoDeImpresora(string printerName)
        {
            try
            {
                string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName.Replace("\\", "\\\\")}'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject printer in searcher.Get())
                {
                    var portName = printer["PortName"]?.ToString();
                    if (!string.IsNullOrEmpty(portName))
                        return portName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obteniendo puerto de impresora: " + ex.Message);
            }
            return null;
        }

        public void ImprimirPorNombreOF(string printerName, string zpl, int puerto = 9100)
        {
            string ip = ObtenerPuertoDeImpresora(printerName);

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("No se pudo encontrar la IP de la impresora: " + printerName);
                return;
            }

            EnviarZPL_porIP(ip, puerto, zpl);
        }


        public void ImprimirPorNombre(string printerName, string zpl, int puerto = 9100)
        {
            string ip = ObtenerPuertoDeImpresora(printerName);

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("No se pudo encontrar la IP de la impresora: " + printerName);
                return;
            }

            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ip, 10000); // Timeout = 2000 ms (2 segundos)

                    if (reply.Status != IPStatus.Success)
                    {
                        MessageBox.Show("La impresora: " + printerName + " no esta conectado");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la impresora: " + ex.Message);
                return;
            }

            // Si pasó el ping, enviamos el ZPL
            EnviarZPL_porIP(ip, puerto, zpl);
        }

        public void EnviarZPL_porIP(string ip, int puerto, string zpl)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect(ip, puerto);

                    using (var stream = client.GetStream())
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(zpl);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                }

                //MessageBox.Show("ZPL enviado a la Zebra correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando a la Zebra: " + ex.Message);
            }
        }

        public bool EnviarZPL_porUSB(string printerName, string zpl)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(zpl); // ASCII o UTF8 funcionan para ZPL

                IntPtr printerHandle;

                // Abrir impresora
                if (!RawPrinterHelper.OpenPrinter(printerName, out printerHandle, IntPtr.Zero))
                    return false;

                // Empezar documento RAW
                RawPrinterHelper.StartDocPrinter(printerHandle, 1, IntPtr.Zero);
                RawPrinterHelper.StartPagePrinter(printerHandle);

                IntPtr unmanagedPointer = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, unmanagedPointer, bytes.Length);

                RawPrinterHelper.WritePrinter(printerHandle, unmanagedPointer, bytes.Length, out int written);

                RawPrinterHelper.EndPagePrinter(printerHandle);
                RawPrinterHelper.EndDocPrinter(printerHandle);
                RawPrinterHelper.ClosePrinter(printerHandle);

                Marshal.FreeHGlobal(unmanagedPointer);

                return written == bytes.Length;
            }
            catch
            {
                return false;
            }
        }

        /*
        public void EnviarZPL_porIP(string ip, int puerto, string zpl)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect(ip, puerto);

                    using (var stream = client.GetStream())
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(zpl);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                }

                MessageBox.Show("ZPL enviado a la Zebra correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando a la Zebra: " + ex.Message);
            }
        }
        */

        public class RawPrinterHelper
        {
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA",
                SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter",
                SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA",
                SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, int level, IntPtr di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter",
                SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter",
                SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter",
                SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter",
                SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

            public static bool SendStringToPrinter(string printerName, string content)
            {
                IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(content);
                int count = content.Length;

                bool success = false;
                IntPtr hPrinter = IntPtr.Zero;

                try
                {
                    if (OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                    {
                        if (StartDocPrinter(hPrinter, 1, IntPtr.Zero))
                        {
                            if (StartPagePrinter(hPrinter))
                            {
                                WritePrinter(hPrinter, pBytes, count, out int dwWritten);
                                EndPagePrinter(hPrinter);
                            }
                            EndDocPrinter(hPrinter);
                        }
                        ClosePrinter(hPrinter);
                        success = true;
                    }
                }
                finally
                {
                    Marshal.FreeCoTaskMem(pBytes);
                }

                return success;
            }
        }

        private void comboBox_Puestotrabajo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_Puestotrabajo.Equals(null))
            {
                return;
            }
            else if (comboBox_Puestotrabajo.Text == "SELECCIONE")
            {
                return;
            }
            else if (guna2TextBox_Cantidad.Text == "")
            {
                return;
            }
            else
            {
                CargarDatosSync();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clic en encabezados
            if (e.RowIndex < 0) return;

            // Primera columna (checkbox)
            int colCheck = 0;

            // Obtener el valor actual del checkbox
            bool valorActual = Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[colCheck].Value);

            // Invertir el valor al hacer clic
            dataGridView2.Rows[e.RowIndex].Cells[colCheck].Value = !valorActual;
        }


        public bool EsPuertoIP(string portName)
        {
            // Casos típicos de IP en Windows:
            // "10.10.10.5"
            // "10.10.10.5_1"
            // "IP_10.10.10.5"
            // "TCP_10.10.10.5"

            if (string.IsNullOrEmpty(portName))
                return false;

            // si comienza con "IP_" o "TCP_" → seguro es IP
            if (portName.StartsWith("IP_", StringComparison.OrdinalIgnoreCase)) return true;
            if (portName.StartsWith("TCP_", StringComparison.OrdinalIgnoreCase)) return true;

            // si parece una IP numérica
            string soloIP = portName.Replace("IP_", "")
                                    .Replace("TCP_", "")
                                    .Split('_')[0];

            System.Net.IPAddress dummy;
            return System.Net.IPAddress.TryParse(soloIP, out dummy);
        }

        /*
         * 
^FO{xBottom},{yBottom}
^A0N,20,20
^FD{s.Numero}^FS
         */
        public string GenerarZPL_3porFila(List<StickerData> items)
        {
            StringBuilder zpl = new StringBuilder();

            int anchoEtiqueta = 240; // 32mm -- 256  30 -- 240
            int altoEtiqueta = 160;  // 20mm
            int espacio = 16;        // 0.3 cm = 24 dots

            for (int i = 0; i < items.Count; i += 3)
            {
                zpl.Append("^XA\n^PW840\n^LH0,0\n"); // 3 etiquetas

                for (int col = 0; col < 3; col++)
                {
                    if (i + col >= items.Count) break;

                    var s = items[i + col];

                    // ESPACIO ENTRE ETIQUETAS
                    int x = 0 + (col * (anchoEtiqueta + espacio));

                    // BASES
                    int xDM = x + 80;
                    int yDM = 56; // 1mm más abajo

                    // === CENTRADO DNI (y más abajo) ===
                    int charWidth = 18;  //MAS A LA IZQUIERDA , MENOS A LA DERECHA
                    int textWidth = s.Dni.Length * charWidth;
                    int dataMatrixWidth = 80;

                    int xTop = xDM + (dataMatrixWidth / 2) - (textWidth / 2);
                    int yTop = 5 + 24;   // 2mm más abajo

                    // === CORRELATIVO IZQUIERDO ===
                    int xLeft = xDM - 50;  //AUMENTA A LA DERECHA , DISMINUYE A LA IZQUIERDA
                    int yLeft = yDM + 0;

                    // === CORRELATIVO DNI ===
                    int xLeftDni = xDM - 80;  //AUMENTA A LA DERECHA , DISMINUYE A LA IZQUIERDA
                    int yLeftDni = yDM - 10;

                    // === CÓDIGO CENTRADO VERTICALMENTE ===
                    int alturaDM = 98;
                    int alturaCodigo = 20;

                    int xRight = xDM + 100;
                    int yRight = yDM + (alturaDM / 2) - (alturaCodigo / 2);

                    // === TEXTO INFERIOR ===
                    int xBottom = xDM - 40; //AUMENTA A LA DERECHA , DISMINUYE A LA IZQUIERDA
                    int yBottom = yDM + 100;

                    zpl.Append($@"
^FO{xTop},{yTop}
^A0N,20,20
^FD{s.ApeNom}^FS

^FO{xDM},{yDM}
^BXN,6,200,0,0
^FD{s.DataMatrix}^FS

^FO{xLeft},{yLeft}
^A0R,24,24
^FD{s.Correlativo}^FS


^FO{xLeftDni},{yLeftDni}
^A0R,20,20
^FD{s.Dni}^FS

^FO{xRight},{yRight}
^A0R,40,40
^FD{s.Codigo}^FS

");
                }

                zpl.Append("^XZ\n");
            }

            return zpl.ToString();
        }

        /*
        public void ImprimirReporteDestajo(string impresora)
        {
            // ✅ Asegúrate de que dtg ya está lleno antes de llamar a este método

            Frm_CrpPanel_imprimir objImpresion = new Frm_CrpPanel_imprimir();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            DataSet_DestajoUva objDs = new DataSet_DestajoUva();

            foreach (DataRow row in dtg.Rows)
            {
                codImpresion = row[3].ToString().Trim() + "-" + row[5].ToString().Trim()
                    + "-" + row[11].ToString().Trim() + "-"
                    + row[0].ToString().Trim().PadLeft(10, '0');
                codQR = row[11].ToString().Trim() + "-"
                    + row[0].ToString().Trim();
                objDs.Tables[0].Rows.Add(new object[]
                {
            row[0],                           // ID
            codImpresion,              // Código
            row[9].ToString().ToUpper(),                 // DNI
            row["Nave"].ToString().Trim(),                   // Nave
            row["Linea"].ToString().Trim(),                  // Línea
            codQR,              // Correlativo 
            Convert.ToDateTime(row[1]).ToShortDateString(), // Fecha
            row["PuestoTrabajo"].ToString().Substring(0,1)   // Primera letra del puesto
                });
            }

            Frm_DestajoUva.CrystalReportDestajoUva objCryRep =
                new Frm_DestajoUva.CrystalReportDestajoUva();

            objCryRep.Load(@"~\CrystalReportDestajoUva.rpt");
            objCryRep.SetDataSource(objDs);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;
        }
        */


    }
}
