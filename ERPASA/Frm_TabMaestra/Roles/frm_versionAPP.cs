using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Msbox;
using Guna.UI2.WinForms;
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

namespace ERPASA.Frm_TabMaestra.Roles
{
    public partial class frm_versionAPP : Form
    {
        cn_equipoti cnequiti = new cn_equipoti();

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public frm_versionAPP()
        {
            InitializeComponent();
        }

        private void frm_versionAPP_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        //private void CentrarImagenCargando()
        //{
        //    guna2PictureBox1.Left = (this.ClientSize.Width - guna2PictureBox1.Width) / 2;
        //    guna2PictureBox1.Top = (this.ClientSize.Height - guna2PictureBox1.Height) / 2;
        //}

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
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


        private void gn2ImgBtn_Buscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Método para cargar los datos una sola vez (desde la base de datos)
        private async void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo

            try
            {
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.Columns.Clear();

                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    dtg = cn_equipoti.ListVersionAPP();
                });

                guna2DataGridView1.DataSource = dtg;
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

        private void gn2ImgBtn_Excel_Click(object sender, EventArgs e)
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
                        objexcel_progress.exportarexcelTimer(guna2DataGridView1, frbm, token);
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

        private void gn2ImgBtn_Guardar_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                GuardarDatosSync();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("NO TIENE REGISTROS PARA GUARDAR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        private async void GuardarDatosSync()
        {
            string MessageBoxTitle = "GUARDAR ";
            string MessageBoxContent = "¿Desea guardar programacion?";

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
                        GuardarVersionAPP();
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
        }


        public void GuardarVersionAPP()
        {
            if (guna2DataGridView1.InvokeRequired)
            {
                guna2DataGridView1.Invoke(new MethodInvoker(delegate
                {
                    guna2DataGridView1.AllowUserToAddRows = false;
                }));
            }
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {

                cnequiti.GuardarActualizarVersionAPP(
                        Convert.ToInt32(row.Cells[0].Value.ToString()),//id
                        row.Cells[1].Value.ToString(),//nombre
                        row.Cells[2].Value.ToString(),//icono
                        row.Cells[3].Value.ToString(),//ver_ant
                        row.Cells[4].Value.ToString(),//vers_act
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
            if (guna2DataGridView1.InvokeRequired)
            {
                guna2DataGridView1.Invoke(new MethodInvoker(delegate
                {
                    guna2DataGridView1.AllowUserToAddRows = true;
                }));
            }
            //Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
            //ng.ShowDialog();
            //dataGridView2.DataSource = null;
            //AgregarColumna();

        }

        private void gn2ImgBtn_Nuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
