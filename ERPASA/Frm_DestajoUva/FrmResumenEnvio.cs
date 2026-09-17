using CapaEntidad;
using CapaUtilidad;
using ERPASA.Msbox;
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

namespace ERPASA.Frm_DestajoUva
{
    public partial class FrmResumenEnvio : Form
    {
        private CancellationTokenSource _cts;
        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();

        public FrmResumenEnvio(List<ResumenEnvioDto> resumen)
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dgvResumen.CellFormatting += dgvResumen_CellFormatting;

            dgvResumen.AutoGenerateColumns = false;
            dgvResumen.DataSource = resumen;

            ConfigurarGrid();
        }


        private void FrmResumenEnvio_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurarGrid()
        {
            dgvResumen.Columns.Clear();

            dgvResumen.ColumnHeadersVisible = true;
            dgvResumen.RowHeadersVisible = false;
            dgvResumen.EnableHeadersVisualStyles = false;

            dgvResumen.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvResumen.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                DefaultCellStyle = {
            Format = "yyyy-MM-dd",
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Presentacion",
                HeaderText = "Presentación",
                DefaultCellStyle = {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Seleccion",
                HeaderText = "Selección",
                DefaultCellStyle = {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Pesado",
                HeaderText = "Pesado",
                DefaultCellStyle = {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Empaque",
                HeaderText = "Empaque",
                DefaultCellStyle = {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                DefaultCellStyle =
    {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        Font = new Font("Segoe UI", 9, FontStyle.Bold)
    }
            });


        }

        private void dgvResumen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResumen.Rows[e.RowIndex].DataBoundItem is ResumenEnvioDto item &&
                item.Presentacion == "TOTAL")
            {
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                e.CellStyle.BackColor = Color.LightGray;
            }
        }

        private void pictureBox_Excel_Click(object sender, EventArgs e)
        {
            ExportarExcel2();
        }
        private async void ExportarExcel2()
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
                        objexcel_progress.exportarexcelTimer(dgvResumen, frbm, token);
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


    }
}
