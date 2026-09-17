using CapaDatos;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Contabilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Logistica
{
    public partial class Frm_BuscarCursosProg : Form
    {
        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;
        cd_nisira objnisira = new cd_nisira();
        cd_logistica objlogistica = new cd_logistica();

        public Frm_BuscarCursosProg()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            textbox_Desc.Focus();
        }

        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string filtro = textbox_Desc.Text.Trim().Replace("'", "''");

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

        private void Frm_BuscarCursosProg_Load(object sender, EventArgs e)
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
                    BuscarLista();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AllowUserToAddRows = false;
                // Asegúrate de que la primera columna sea editable
                // Establecer ReadOnly en false para permitir la edición de todas las columnas
                // Asegúrate de que las columnas sean editables (ReadOnly = false)
                // OCULTAR PRIMERA COLUMNA (ID)
                //if (dataGridView1.Columns.Count > 0)
                //{
                //    dataGridView1.Columns[0].Visible = false;
                //}
                dataGridView1.ClearSelection();

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
                dtg = objlogistica.ListaCursosProgSST(); //cn_logistica.ListaCBAreaTodoAsignacionTI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VarDatosEntroFormPreguntas var1 = Owner as VarDatosEntroFormPreguntas;
            DataGridViewRow fila = dataGridView1.SelectedRows[0] as DataGridViewRow;
            var1.TablaAgregarDatosFilaAsigPreguntas(fila);
            this.Close();
        }
    }
}
