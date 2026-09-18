using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_Logistica
{
    public partial class Frm_ProgramarCursos : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();
        cn_taller objcntaller = new cn_taller();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_ProgramarCursos()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ProgramarCursos_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //BuscarReporteListaVehiculos();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        public void CargarDatosComboBox()
        {
            comboBox_detalle_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_detalle_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMerma();
            //comboBox_TipoMerma.DisplayMember = "Merma"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_detalle_empresa.Text == comboBox_detalle_empresa.Text)
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_detalle_empresa.Text);
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                //CARGAR SEDE
                comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
                comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            //textBox_Dni.Text = "";

        }



        public void BuscarReporteLista()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{
            string emp, sed;
            if (comboBox_detalle_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_detalle_empresa.Text;
            }
            if (comboBox_detalle_sede.Text == "SELECCIONE")
            {
                sed = "%";
            }
            else
            {
                sed = comboBox_detalle_sede.Text;
            }


            Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
            ng.Show();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = cn_logistica.ListaReporteCursosProgramado(
                Convert.ToDateTime("2026-01-01").Date,
                Convert.ToDateTime("2026-01-01").Date, emp, sed, 2);

            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

            // AGREGAR DESCARGAR
            AgregarBotonDescarga();
            //}
            //else
            //{

            //}

        }

        private void AgregarBotonDescarga()
        {
            if (dataGridView2.Columns["btnDescarga"] != null)
                return;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "btnDescarga";
            img.HeaderText = "Descargar";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            // PNG desde recursos o archivo
            img.Image = Properties.Resources.descargar;

            dataGridView2.Columns.Add(img);
        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteLista();
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
            //AbrirFormularioHijo<Reportes.Acopio.frm_AgregarMerma>();

            Frm_AgregarCursos frbm = new Frm_AgregarCursos();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }


        public void AbrirFormularioHijo<MiForm>() where MiForm : Form, new()
        {
            Form fh;
            fh = frm_Menu.panel_contenedor.Controls.OfType<MiForm>().FirstOrDefault(); //busca en la colección del formulario

            //si el formulario no existe
            if (fh == null)
            {

                fh = new MiForm();
                fh.TopLevel = false;
                //fh.Dock = DockStyle.Fill;            
                this.frm_Menu.panel_contenedor.Controls.Add(fh);
                this.frm_Menu.panel_contenedor.Tag = fh;
                fh.Show();
                fh.BringToFront();

            }
            else
            {
                fh.BringToFront();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evita doble click en encabezados o filas inválidas
            if (e.RowIndex < 0)
                return;

            // Evita filas vacías
            if (dataGridView2.CurrentRow == null ||
                dataGridView2.CurrentRow.Cells[0].Value == null ||
                string.IsNullOrWhiteSpace(dataGridView2.CurrentRow.Cells[0].Value.ToString()))
                return;

            BuscarRegistroParaEditar();

        }

        public void BuscarRegistroParaEditar()
        {
            if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
            {
                Frm_AgregarCursos obj = new Frm_AgregarCursos();
                obj.PonerOscuroComboBox();
                obj.CargarDatosComboBox();
                obj.label_Id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                ce_empsede.empresa = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                ce_empsede.sede = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                ce_empsede.tipotrab = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                obj.textBox_Id.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                obj.textBox_Curso.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                obj.textBox_Duracion.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                obj.textBox_Descripcion.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                obj.textBox_Comentario.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                obj.textRuta.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();

                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO SE PUEDE EDITAR, PORQUE ESTA ELIMINADO");
            }

        }

        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
                {
                    ElimarFila();
                }
                else
                {
                    MessageBox.Show("ERROR -- SELECCIONE UN REGISTRO ACTIVO");
                }
            }
            else
            {
                MessageBox.Show("SELECCIONE UNA FILA");
            }
        }

        public void ElimarFila()
        {
            string MessageBoxTitle = "Eliminar";
            string MessageBoxContent = "¿Desea eliminar?";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                objcntaller.EliminarListaCurso(
                dataGridView2.CurrentRow.Cells[0].Value.ToString(),
                ce_usuario.FechaSistema(),
                ce_usuario.usecod
                 );

                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("REGISTRO ELIMINADO", Color.OrangeRed, 3);
                ng.ShowDialog();
                //Close();


                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    BuscarReporteLista();
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                //dataGridView2.ClearSelection();
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
                    dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }

        private async void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnDescarga")
            {
                string ruta =
                    dataGridView2.Rows[e.RowIndex]
                    .Cells["RutaServer"]
                    .Value
                    .ToString();

                await DescargarArchivo(ruta);
            }
        }

        public async Task DescargarArchivo(string ruta)
        {
            Cursor.Current = Cursors.WaitCursor;

            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            frbm.label1.Text = "DESCARGANDO ARCHIVO...";
            frbm.Show(this);

            try
            {
                // Validar ruta
                if (string.IsNullOrWhiteSpace(ruta))
                {
                    MessageBox.Show("No existe ruta del archivo");
                    return;
                }

                var api = new cn_apiservices();

                // Obtener nombre archivo limpio
                string nombreArchivo = Path.GetFileName(ruta);

                if (string.IsNullOrWhiteSpace(nombreArchivo))
                {
                    MessageBox.Show("Nombre de archivo inválido");
                    return;
                }

                // Descargar bytes desde API
                byte[] bytes = await api.ObtenerArchivoBytesAsync(ruta);

                // Validar bytes
                if (bytes == null || bytes.Length == 0)
                {
                    MessageBox.Show(
                        "❌ No se pudo descargar el archivo.\n\n" +
                        "Verifique:\n" +
                        "- Que el archivo exista en servidor\n" +
                        "- Que la API esté funcionando\n" +
                        "- Que RutaServer sea correcta");
                    return;
                }

                // Carpeta Descargas
                string downloadsPath =
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads");

                // Crear carpeta si no existe
                if (!Directory.Exists(downloadsPath))
                    Directory.CreateDirectory(downloadsPath);

                // Ruta final
                string fullPath = Path.Combine(downloadsPath, nombreArchivo);

                // Evitar sobrescribir archivos
                int count = 1;

                string nombreSinExtension =
                    Path.GetFileNameWithoutExtension(nombreArchivo);

                string extension =
                    Path.GetExtension(nombreArchivo);

                while (File.Exists(fullPath))
                {
                    fullPath = Path.Combine(
                        downloadsPath,
                        $"{nombreSinExtension}({count}){extension}");

                    count++;
                }

                // Guardar archivo
                File.WriteAllBytes(fullPath, bytes);

                MessageBox.Show(
                    "✅ Archivo descargado correctamente\n\n" +
                    fullPath,
                    "Descarga completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Abrir archivo automáticamente
                System.Diagnostics.Process.Start(new ProcessStartInfo()
                {
                    FileName = fullPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ Error al descargar archivo:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                if (frbm != null && !frbm.IsDisposed)
                    frbm.Close();
            }
        }


    }
}
