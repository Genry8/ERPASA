using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    /// <summary>
    /// Reporte y mantenimiento de las ubicaciones de baño (TALL_UbicacionBaños).
    /// Mismo esquema que el registro de vehículos: filtros arriba, grilla
    /// abajo, alta con el botón de la barra y edición con doble clic.
    ///
    /// La diferencia es el buscador: "Buscar" trae de la base una sola vez y
    /// deja el resultado en un DataTable; el cuadro de texto filtra sobre esa
    /// copia en memoria, sin volver a consultar.
    /// </summary>
    public partial class Frm_RegistrarUbicacionBano : Form
    {
        cu_excel objexcel = new cu_excel();
        cn_taller objcntaller = new cn_taller();

        // Resultado de la última búsqueda: sobre él trabaja el filtro de texto.
        private DataTable dtg = new DataTable();

        public Frm_RegistrarUbicacionBano()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_RegistrarUbicacionBano_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            BuscarReporteUbicacionBanos();
        }

        public void PonerOscuroComboBox()
        {
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
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

        public void BuscarReporteUbicacionBanos()
        {
            string emp = comboBox_detalle_empresa.Text == "SELECCIONE"
                ? "%" : comboBox_detalle_empresa.Text;

            string sed = comboBox_detalle_sede.Text == "SELECCIONE"
                ? "%" : comboBox_detalle_sede.Text;

            // Se guarda el resultado completo: el cuadro de búsqueda filtra
            // sobre esta tabla sin volver a ir a la base.
            dtg = cn_taller.ListaReporteUbicacionBano(emp, sed);

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
        /// columnas de texto. Se arma sobre la vista, así que no se pierde
        /// ningún dato: al borrar el texto vuelve a verse todo.
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
                BuscarReporteUbicacionBanos();
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
            frm_AgregarUbicacionBano frbm = new frm_AgregarUbicacionBano();
            AddOwnedForm(frbm);
            frbm.ShowDialog();

            // Al volver del alta se refresca para ver lo recién registrado.
            BuscarReporteUbicacionBanos();
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

            // Columnas: 0 Id, 1 Empresa, 2 Sede, 3 Cabezal, 4 Valvula,
            //           5 NroBano, 6 Genero, 7 Obs, 8 Foto, 9 Estado
            frm_AgregarUbicacionBano obj = new frm_AgregarUbicacionBano();
            obj.label_Id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            ce_taller.empresa = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            ce_taller.sede = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            ce_taller.bano_cabezal = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            ce_taller.bano_valvula = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            ce_taller.bano_numero = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            ce_taller.bano_genero = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            ce_taller.bano_obs = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            ce_taller.bano_foto = dataGridView2.CurrentRow.Cells[8].Value.ToString();

            AddOwnedForm(obj);
            obj.ShowDialog();

            BuscarReporteUbicacionBanos();
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

            objcntaller.EliminarUbicacionBano(
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
                BuscarReporteUbicacionBanos();
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
