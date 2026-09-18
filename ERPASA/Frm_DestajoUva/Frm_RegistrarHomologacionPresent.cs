using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_RegistrarHomologacionPresent : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_comercial objcncomer = new cn_comercial();
        cn_sst objcnsst = new cn_sst();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtEmpresa;
        private CancellationTokenSource _cts;

        public Frm_RegistrarHomologacionPresent()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_RegistrarPesoPresentacionDest_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //dateTimePicker_Fecha_Ini.Value = DateTime.Now.Date.AddDays(-30);
            //dateTimePicker_Fecha_Fin.Value = DateTime.Now.Date;

            //poner osucro

            //CargaDatos();

            Cargar_Empresa();
            PonerOscuroComboBox();
            CargaDatos();
        }

        public void CargaDatos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            CargarDatosSync();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            //comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {

            dtEmpresa = cn_comercial.ListaEmpresa();
            // Crear una nueva fila al inicio
            DataRow row = dtEmpresa.NewRow();
            row["growername"] = "SELECCIONE";
            row["id"] = 0; // valor por defecto o nulo

            dtEmpresa.Rows.InsertAt(row, 0);

            ////CARGAR EMPRESA
            //comboBox_empresa.DataSource = dtEmpresa;
            //comboBox_empresa.DisplayMember = "growername"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }


        private void comboBox_empresa_alto_riesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //    //CARGAR SEDE EMPRESA
            //    comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaCBSedeEmpresaAsignacionTI(comboBox_empresa.Text);
            //    comboBox_CodSede_Comedor.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_CodSede_Comedor.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }


        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            CargarDatosSync();

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
                    BuscarPresentacionDestajo();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                // Primero hacer todas las columnas de solo lectura
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.ReadOnly = true;
                }

                // Luego hacer editable solo la segunda columna (índice 1)
                if (dataGridView1.Columns.Count > 1)
                {
                    dataGridView1.Columns[1].ReadOnly = false;
                    dataGridView1.Columns[2].ReadOnly = false;
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


        public void BuscarPresentacionDestajo()
        {
            //string empText = string.Empty, emp;

            //////////////////////////////////////
            //if (comboBox_empresa.InvokeRequired)
            //{
            //    comboBox_empresa.Invoke(new MethodInvoker(() =>
            //    {
            //        empText = comboBox_empresa.Text;
            //    }));
            //}
            //else
            //{
            //    empText = comboBox_empresa.Text;
            //}
            //////////////////////
            //if (empText == "SELECCIONE")
            //{
            //    emp = "%";
            //}
            //else
            //{
            //    emp = empText;
            //}

            dtg = cn_comercial.BuscarReporteLiquidacion(
            Convert.ToDateTime("2025-10-10"),
            Convert.ToDateTime("2025-10-10"), "%", "4");

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
                        objexcel_progress.exportarexcelTimer(dataGridView1, frbm, token);
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
            guna2TextBoxSearch.Focus();
            GuardarDatosSync();

            //if (ValidarFilasCompletasDT1())
            //{
            //    GuardarDatosSync();
            //}
            //else
            //{
            //    // ❌ Hay celdas vacías, se cancela el guardado
            //}
        }


        private bool ValidarFilasCompletasDT1()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int filaVisible = row.Index + 1;

                    // Obtener el valor de la columna [1]
                    var valor = row.Cells[1].FormattedValue?.ToString().Trim() ?? "";

                    // Validar que no esté vacío
                    if (string.IsNullOrEmpty(valor))
                    {
                        dataGridView1.CurrentCell = row.Cells[1];
                        MessageBox.Show(
                            $"La columna PESO no puede estar vacía en la fila {filaVisible}.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                        return false;
                    }
                }
            }

            return true;
        }


        private async void GuardarDatosSync()
        {
            string MessageBoxTitle = "GUARDAR ";
            string MessageBoxContent = "¿Desea guardar registro?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                        //MessageBox.Show("Hola");
                        GuardarHomologacionPresentacion();
                    });


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar datos: " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    frbm.Close();
                }
            }
        }

        public void GuardarHomologacionPresentacion()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                objcncomer.GuardarHomologacionPresentacionDestajo(
                        0,//id
                        row.Cells[0].Value.ToString().Trim(),//descripcion
                        row.Cells[1].Value.ToString().Trim(),//extech
                        row.Cells[2].Value.ToString().Trim(),//codExtech
                        "",//tipo
                        "",//obs
                        "S", //estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        0
                        );
            }

            Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            ng.ShowDialog();


        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1) // CANT-E
            {
                char c = e.KeyChar;

                if (char.IsDigit(c) || char.IsSeparator(c) || char.IsControl(c) || c == '.')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2) // CANT-E
            {
                char c = e.KeyChar;

                if (char.IsDigit(c) || char.IsSeparator(c) || char.IsControl(c) || c == '.')
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
            //if (dataGridView1.CurrentCell.ColumnIndex == 1)
            //{
            //    TextBox txt = e.Control as TextBox;
            //    if (txt != null)
            //    {
            //        txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
            //        txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
            //    }
            //}

        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
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
    }
}
