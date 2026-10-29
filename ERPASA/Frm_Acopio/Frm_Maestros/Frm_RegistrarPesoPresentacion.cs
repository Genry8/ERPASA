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
    /// Maestro de peso por presentación (PACK_PesoPresentacion): filtros de
    /// empresa, sede y cultivo arriba, grilla abajo, alta con el botón de la
    /// barra y edición con doble clic.
    ///
    /// "Buscar" trae de la base una sola vez y deja el resultado en un
    /// DataTable; el cuadro de texto filtra sobre esa copia en memoria.
    /// </summary>
    public partial class Frm_RegistrarPesoPresentacion : Form
    {
        cu_excel objexcel = new cu_excel();
        cn_packing objcnpacking = new cn_packing();

        // Resultado de la última búsqueda: sobre él trabaja el filtro de texto.
        private DataTable dtg = new DataTable();

        public Frm_RegistrarPesoPresentacion()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_RegistrarPesoPresentacion_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            BuscarReportePesoPresentacion();
        }

        public void PonerOscuroComboBox()
        {
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_cultivo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_cultivo.DataSource = cn_packing.ListaCultivo();
            comboBox_detalle_cultivo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_cultivo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            }
            else
            {
                comboBox_detalle_sede.DataSource =
                    cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_detalle_empresa.Text);
            }

            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        public void BuscarReportePesoPresentacion()
        {
            string emp = comboBox_detalle_empresa.Text == "SELECCIONE"
                ? "%" : comboBox_detalle_empresa.Text;

            string sed = comboBox_detalle_sede.Text == "SELECCIONE"
                ? "%" : comboBox_detalle_sede.Text;

            string cultivo = (comboBox_detalle_cultivo.Text == "SELECCIONE" ||
                              comboBox_detalle_cultivo.Text == "NO ESPECIFICA" ||
                              comboBox_detalle_cultivo.Text == "")
                ? "%" : comboBox_detalle_cultivo.Text;

            // Se guarda el resultado completo: el cuadro de búsqueda filtra
            // sobre esta tabla sin volver a ir a la base.
            dtg = cn_packing.ListaReportePesoPresentacion(emp, sed, cultivo);

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dtg;
            dataGridView2.AllowUserToAddRows = false;

            AplicarFiltroBusqueda();

            OrigenColorfila();
            dataGridView2.ClearSelection();

            Msbox.Frm_NotificacionesGuardar ng =
                new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();
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
                .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

            dv.RowFilter = string.Join(" OR ", condiciones);
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReportePesoPresentacion();
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

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            frm_AgregarPesoPresentacion frbm = new frm_AgregarPesoPresentacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();

            // Al volver del alta se refresca para ver lo recién registrado.
            BuscarReportePesoPresentacion();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BuscarRegistroParaEditar();
        }

        public void BuscarRegistroParaEditar()
        {
            if (dataGridView2.CurrentRow == null) return;

            if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() != "ACTIVO")
            {
                MessageBox.Show("NO SE PUEDE EDITAR, PORQUE ESTA ELIMINADO");
                return;
            }

            // Columnas: 0 Id, 1 DesEmp, 2 DesSed, 3 Cultivo, 4 Presentacion,
            //           5 Peso, 6 PorcentajeMin, 7 Porcentaje, 8 Obs, 9 Estado
            frm_AgregarPesoPresentacion obj = new frm_AgregarPesoPresentacion();
            obj.label_Id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            ce_pesopresentacion.empresa = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            ce_pesopresentacion.sede = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            ce_pesopresentacion.cultivo = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            ce_pesopresentacion.presentacion = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            ce_pesopresentacion.peso = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            ce_pesopresentacion.porcentajemin = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            ce_pesopresentacion.porcentaje = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            ce_pesopresentacion.obs = dataGridView2.CurrentRow.Cells[8].Value.ToString();

            AddOwnedForm(obj);
            obj.ShowDialog();

            BuscarReportePesoPresentacion();
        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("SELECCIONE UNA FILA");
                return;
            }

            if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() != "ACTIVO")
            {
                MessageBox.Show("ERROR -- SELECCIONE UN REGISTRO ACTIVO");
                return;
            }

            ElimarFila();
        }

        public void ElimarFila()
        {
            string MessageBoxTitle = "Eliminar";
            string MessageBoxContent = "¿Desea eliminar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes) return;

            objcnpacking.EliminarPesoPresentacion(
                Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString()),
                ce_usuario.FechaSistema(),
                ce_usuario.usecod
                );

            Msbox.Frm_Notificaciones ng =
                new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
            ng.ShowDialog();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReportePesoPresentacion();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void OrigenColorfila()
        {
            int c = dataGridView2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView2.Rows[i].Cells["Estado"].Value.ToString() == "ANULADO")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold);
                }
            }
        }
    }
}
