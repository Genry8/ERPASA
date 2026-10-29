using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Frm_Acopio.Frm_Maestros
{
    /// <summary>
    /// Maestro de MOTIVO DE PARADAS (tabla PACK_MotivoParadas).
    ///
    /// "Buscar" trae de la base una sola vez y deja el resultado en un
    /// DataTable; el cuadro de texto filtra sobre esa copia en memoria.
    /// </summary>
    public partial class Frm_MaestroMotivoParadas : Form
    {
        cu_excel objexcel = new cu_excel();
        cn_packing objcnpacking = new cn_packing();

        // Resultado de la ultima busqueda: sobre el trabaja el filtro de texto.
        private DataTable dtg = new DataTable();

        public Frm_MaestroMotivoParadas()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_MaestroMotivoParadas_Load(object sender, EventArgs e)
        {
            IconosMaestro.Aplicar(toolStrip2);
            BuscarReporteMotivoParadas();
        }

        public void BuscarReporteMotivoParadas()
        {
            dtg = cn_packing.ListaMaestroMotivoParadas();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dtg;
            dataGridView2.AllowUserToAddRows = false;

            if (dataGridView2.Columns.Contains("EstadoReg"))
                dataGridView2.Columns["EstadoReg"].HeaderText = "Estado";

            AplicarFiltroBusqueda();
            OrigenColorfila();
            dataGridView2.ClearSelection();
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
            OrigenColorfila();
        }

        /// <summary>
        /// Filtra la tabla ya cargada buscando el texto en cualquiera de sus
        /// columnas de texto. Al borrar el texto vuelve a verse todo.
        /// </summary>
        private void AplicarFiltroBusqueda()
        {
            if (dtg == null || dtg.Columns.Count == 0) return;

            string filtro = textBox_Buscar.Text.Trim().Replace("'", "''");
            DataView dv = dtg.DefaultView;

            if (string.IsNullOrEmpty(filtro))
            {
                dv.RowFilter = "";
                return;
            }

            var condiciones = dtg.Columns
                .Cast<DataColumn>()
                .Where(col => col.DataType == typeof(string))
                .Select(col => "[" + col.ColumnName + "] LIKE '%" + filtro + "%'");

            dv.RowFilter = string.Join(" OR ", condiciones);
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteMotivoParadas();

                Msbox.Frm_NotificacionesGuardar ng =
                    new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
                ng.Show();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            objexcel.ExportarExcel(dataGridView2);
        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            frm_AgregarMotivoParadas frbm = new frm_AgregarMotivoParadas(0, null);
            frbm.ShowDialog();

            BuscarReporteMotivoParadas();
        }

        private void toolStripButton_editar_Click(object sender, EventArgs e)
        {
            BuscarRegistroParaEditar();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BuscarRegistroParaEditar();
        }

        public void BuscarRegistroParaEditar()
        {
            DataRowView fila = FilaSeleccionada();
            if (fila == null) return;

            if (fila["EstadoReg"].ToString() != "ACTIVO")
            {
                MessageBox.Show("NO SE PUEDE EDITAR, PORQUE ESTA ELIMINADO");
                return;
            }

            frm_AgregarMotivoParadas obj =
                new frm_AgregarMotivoParadas(Convert.ToInt32(fila["Id"]), fila.Row);
            obj.ShowDialog();

            BuscarReporteMotivoParadas();
        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            DataRowView fila = FilaSeleccionada();
            if (fila == null) return;

            if (fila["EstadoReg"].ToString() != "ACTIVO")
            {
                MessageBox.Show("ERROR -- SELECCIONE UN REGISTRO ACTIVO");
                return;
            }

            ElimarFila(Convert.ToInt32(fila["Id"]));
        }

        public void ElimarFila(int id)
        {
            string MessageBoxTitle = "Eliminar";
            string MessageBoxContent = "¿Desea eliminar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes) return;

            objcnpacking.EliminarMaestroMotivoParadas(id, ce_usuario.FechaSistema(), ce_usuario.usecod);

            Msbox.Frm_Notificaciones ng =
                new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
            ng.ShowDialog();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteMotivoParadas();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private DataRowView FilaSeleccionada()
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("SELECCIONE UNA FILA");
                return null;
            }

            return dataGridView2.CurrentRow.DataBoundItem as DataRowView;
        }

        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells["EstadoReg"].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold);
                }
            }
        }
    }
}
