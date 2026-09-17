using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using ERPASA.Frm_Contabilidad;
using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ERPASA.Frm_Logistica
{
    public partial class Frm_AgregarPreguntas : Form, VarDatosEntroFormPreguntas
    {
        private DataSet dtsTablas = new DataSet();
        cn_taller objcntaller = new cn_taller();
        cn_planilla objcnlog = new cn_planilla();
        cd_nisira objnisira = new cd_nisira();
        cn_logistica objcnlogistica = new cn_logistica();
        private cn_apiservices apiService =
    new cn_apiservices();
        DataTable dtg;

        private string rutaArchivo = "";
        private string nombreArchivo = "";
        private bool _formateando = false;

        public Frm_AgregarPreguntas()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_AgregarPreguntas_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            AgregarColumna();

            //MessageBox.Show(label_Id.Text);
            BuscarLista(Convert.ToInt32(label_Id.Text));

        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            textRuta.Enabled = false;
            //comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_TipoTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_TipoTrabajador.SelectedIndex = 0;
            //comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        private void AgregarColumna()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Item = new DataGridViewTextBoxColumn();
            Item.HeaderText = "Item";
            Item.Name = "Item";
            Item.Width = 60;
            dataGridView1.Columns.Add(Item);
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Pregunta = new DataGridViewTextBoxColumn();
            Pregunta.HeaderText = "Pregunta";
            Pregunta.Name = "Pregunta";
            Pregunta.Width = 380;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            dataGridView1.Columns.Add(Pregunta);

            // 
            // Column2
            // 
            DataGridViewTextBoxColumn Respuesta = new DataGridViewTextBoxColumn();
            Respuesta.HeaderText = "Respuesta";
            Respuesta.Name = "Respuesta";
            Respuesta.Width = 180;
            //LLENAR EL COMBO CON LOS DATOS DE UNA COLUMA
            //AÑADIR EL COMBO AL DATAGRIDVIEW
            dataGridView1.Columns.Add(Respuesta);

            // 
            // Column3
            // 
            DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            Estado.Width = 100;
            dataGridView1.Columns.Add(Estado);

            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Puntaje = new DataGridViewTextBoxColumn();
            Puntaje.HeaderText = "Puntaje";
            Puntaje.Name = "Puntaje";
            Puntaje.Width = 100;
            dataGridView1.Columns.Add(Puntaje);

        }


        private void BuscarLista(int cod)
        {
            try
            {
                if (label_Id.Text == "0")
                {
                    //dtg = cn_logistica.ListaCursosSST(); //cn_logistica.ListaCBAreaTodoAsignacionTI();
                }
                else
                {
                    toolStripButton_limpiar.Enabled = false;

                    dtg = cn_logistica.ListaCursosSSTCodPregunta(
                        cod
                        );
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dtg;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }


        public void CargarDatosComboBox()
        {
            //comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            //comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaTipoMaquinaria();
            //comboBox_TipoMerma.DisplayMember = "Maquina"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //comboBox_TipoMerma.DataSource = cn_packing.ListaMaquinariaFiler();
            //comboBox_TipoMerma.DisplayMember = "Filer"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_TipoMerma.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }



        private void comboBox_detalle_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //    //CARGAR SEDE
            //    comboBox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
            //    comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
            //if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    //CARGAR SEDE
            //    comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //    comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }



        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            textBox_Comentario.Focus();
            EliminarFilasVaciasDT1();
            if (ValidarFilasCompletasDT1())
            {
                AlertaGuardar();
            }
            else
            {
                // ❌ Hay celdas vacías, se cancela el guardado
            }

        }


        private bool ValidarFilasCompletasDT1()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int filaVisible = row.Index + 1;

                    // Recorrer todas las columnas
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Opcional: ignorar columnas ocultas
                        if (!cell.Visible)
                            continue;

                        string valor = cell.FormattedValue?.ToString().Trim() ?? "";

                        // Obtener nombre automático de la columna
                        string nombreColumna =
                            dataGridView1.Columns[cell.ColumnIndex].HeaderText;

                        // Validar vacío
                        if (string.IsNullOrWhiteSpace(valor))
                        {
                            dataGridView1.CurrentCell = cell;

                            MessageBox.Show(
                                $"La columna '{nombreColumna}' no puede estar vacía en la fila {filaVisible}.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void EliminarFilasVaciasDT1()
        {
            // Recorrer de abajo hacia arriba
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                // Ignorar la fila nueva
                if (row.IsNewRow)
                    continue;

                bool filaVacia = true;

                // Verificar todas las celdas de la fila
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string valor = cell.FormattedValue?.ToString().Trim() ?? "";

                    // Si encuentra algún dato, la fila NO está vacía
                    if (!string.IsNullOrWhiteSpace(valor))
                    {
                        filaVacia = false;
                        break;
                    }
                }

                // Eliminar fila completamente vacía
                if (filaVacia)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }

        public async Task AlertaGuardar()
        {
            dataGridView1.AllowUserToAddRows = false;
            //if (comboBox_empresa.Text == "SELECCIONE")
            //{
            //    Msbox.Frm_NotificacionesPeligro ng =
            //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
            if (dataGridView1.RowCount < 1)
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("AGREGUE AL MENOS 1 PREGUNTA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Id.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA CURSO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (textBox_Curso.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA CURSO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            //else if (textRuta.Text.Trim() == "")
            //{
            //    Msbox.Frm_NotificacionesPeligro ng =
            //        new Msbox.Frm_NotificacionesPeligro("SELECCIONE UN ARCHIVO", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
            else
            {
                if (label_Id.Text == "0")
                {

                    string MessageBoxTitle = "GUARDAR ";
                    string MessageBoxContent = "¿Desea guardar registro? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int idCabecera =
                            objcnlogistica.GuardarCursosProgPreguntasCab(
                                0,
                                Convert.ToInt32(textBox_Id.Text.Trim()),
                                textBox_Curso.Text.Trim(),
                                label_TipoTrabajador.Text,
                                textBox_CantPreguntas.Text.Trim(),
                                textBox_NotaMin.Text.Trim(),
                                textBox_Comentario.Text.Trim(),
                                Convert.ToInt32(dataGridView1.RowCount),
                                textRuta.Text.Trim(),
                                comboBox_Hojas.Text.Trim(),
                                "S",
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                0
                            );

                        // RECORRER GRID Y GUARDAR DETALLE
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string pregunta = Convert.ToString(row.Cells[1].Value);
                            string respuesta = Convert.ToString(row.Cells[2].Value);
                            string estadoPregunta = Convert.ToString(row.Cells[3].Value);

                            int item = 0;
                            int puntaje = 0;

                            int.TryParse(
                                Convert.ToString(row.Cells[0].Value),
                                out item
                            );
                            int.TryParse(
                                Convert.ToString(row.Cells[4].Value),
                                out puntaje
                            );

                            objcnlogistica.GuardarCursosProgPreguntasDet(
                                0,
                                idCabecera,
                                Convert.ToInt32(textBox_Id.Text.Trim()),
                                textBox_Curso.Text.Trim(),
                                textBox_Comentario.Text.Trim(),
                                item,
                                pregunta,
                                respuesta,
                                estadoPregunta,
                                puntaje,
                                textRuta.Text.Trim(),
                                "S",
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                0
                            );
                        }

                        Msbox.Frm_NotificacionesPeligro ng =
                                new Msbox.Frm_NotificacionesPeligro(
                                    "GUARDADO CORRECTAMENTE " + idCabecera,
                                    Color.FromArgb(12, 19, 214),
                                    1);

                        ng.ShowDialog();

                        LimiparCampos();
                    }

                }

                else
                {
                    string MessageBoxTitle = "ACTUALIZAR";
                    string MessageBoxContent = "¿Desea actualizar registro? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int idCabecera =
                            objcnlogistica.GuardarCursosProgPreguntasCab(
                                Convert.ToInt32(label_Id.Text.Trim()),
                                Convert.ToInt32(textBox_Id.Text.Trim()),
                                textBox_Curso.Text.Trim(),
                                label_TipoTrabajador.Text,
                                textBox_CantPreguntas.Text.Trim(),
                                textBox_NotaMin.Text.Trim(),
                                textBox_Comentario.Text.Trim(),
                                Convert.ToInt32(dataGridView1.RowCount),
                                textRuta.Text.Trim(),
                                comboBox_Hojas.Text.Trim(),
                                "S",
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                0
                            );

                        objcnlogistica.EliminarCursosProgPreguntasDet(idCabecera);

                        // RECORRER GRID Y GUARDAR DETALLE
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;


                            string pregunta = Convert.ToString(row.Cells[1].Value);
                            string respuesta = Convert.ToString(row.Cells[2].Value);
                            string estadoPregunta = Convert.ToString(row.Cells[3].Value);

                            int item = 0;
                            int puntaje = 0;

                            int.TryParse(
                                Convert.ToString(row.Cells[0].Value),
                                out item
                            );
                            int.TryParse(
                                Convert.ToString(row.Cells[4].Value),
                                out puntaje
                            );

                            objcnlogistica.GuardarCursosProgPreguntasDet(
                                Convert.ToInt32(label_Id.Text.Trim()),
                                idCabecera,
                                Convert.ToInt32(textBox_Id.Text.Trim()),
                                textBox_Curso.Text.Trim(),
                                textBox_Comentario.Text.Trim(),
                                item,
                                pregunta,
                                respuesta,
                                estadoPregunta,
                                puntaje,
                                textRuta.Text.Trim(),
                                "S",
                                ce_usuario.FechaSistema(),
                                ce_usuario.usecod,
                                ce_usuario.HostName(),
                                ce_usuario.FechaSistema(),
                                0
                            );
                        }


                        Msbox.Frm_NotificacionesPeligro ng =
                                    new Msbox.Frm_NotificacionesPeligro(
                                        "ACTUALIZADO CORRECTAMENTE",
                                        Color.FromArgb(12, 19, 214),
                                        1);

                        ng.ShowDialog();
                    }

                    //LimiparCampos();



                }

            }

            dataGridView1.AllowUserToAddRows = true;
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimiparCampos();
            AgregarColumna();
        }

        public void LimiparCampos()
        {
            textBox_Id.Text = string.Empty;
            textBox_Curso.Text = string.Empty;
            textRuta.Text = string.Empty;
            textBox_CantPreguntas.Text = string.Empty;
            textBox_NotaMin.Text = string.Empty;
            textBox_Comentario.Text = string.Empty;
            dataGridView1.DataSource = "";
            AgregarColumna();
            //textBox_Area.Text = string.Empty;
        }



        public void TablaAgregarDatosFilaPreguntas(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigPreguntas(DataGridViewRow fila1a)
        {
            string id = (string)fila1a.Cells[0].Value.ToString();
            string curso = (string)fila1a.Cells[1].Value.ToString();
            string tipotrab = (string)fila1a.Cells[2].Value.ToString();
            textBox_Id.Text = id;
            textBox_Curso.Text = curso;
            label_TipoTrabajador.Text = tipotrab;
        }

        private void textBox_Ruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox_Proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textRuta.Text != "")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtsTablas.Tables[comboBox_Hojas.SelectedIndex];
                dataGridView1.ClearSelection();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("ELIJA UN EXCEL", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }

        private void textBox_Curso_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Curso_DoubleClick(object sender, EventArgs e)
        {
            Frm_BuscarCursosProg frbm = new Frm_BuscarCursosProg();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void textBox_Id_DoubleClick(object sender, EventArgs e)
        {
            Frm_BuscarCursosProg frbm = new Frm_BuscarCursosProg();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void textBox_NotaMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir teclas de control (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }



        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;

            if (txt != null)
            {
                // Siempre desuscribir primero
                txt.KeyPress -= Txt_KeyPress_Numeros;

                // Solo suscribir en la columna 4
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    txt.KeyPress += Txt_KeyPress_Numeros;
                }
                // Solo suscribir en la columna 4
                if (dataGridView1.CurrentCell.ColumnIndex == 4)
                {
                    txt.KeyPress += Txt_KeyPress_Numeros;
                }
            }
        }

        private void Txt_KeyPress_Numeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_CantPreguntas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir teclas de control (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }
    }

    internal interface VarDatosEntroFormPreguntas
    {
        void TablaAgregarDatosFilaPreguntas(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigPreguntas(DataGridViewRow fila1a);
    }
}
