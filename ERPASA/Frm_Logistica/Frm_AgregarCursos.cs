using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using ERPASA.Frm_Contabilidad;
using Newtonsoft.Json;
using System;
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
    public partial class Frm_AgregarCursos : Form, VarDatosEntroFormCursos
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

        public Frm_AgregarCursos()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_ProgramarCursos_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //AgregarColumna();

            if (label_Id.Text != "0")
            {
                toolStripButton_limpiar.Enabled = false;
                comboBox_empresa.Text = ce_empsede.empresa;
                comboBox_sede.Text = ce_empsede.sede;
                comboBox_TipoTrabajador.Text = ce_empsede.tipotrab;
            }
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoTrabajador.SelectedIndex = 0;
            //comboBox_GrupoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Marca.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_Modelo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

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
            if (comboBox_empresa.Text == comboBox_empresa.Text)
            {
                //CARGAR SEDE
                comboBox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
                comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            }
            //if (comboBox_detalle_empresa.Text == "SELECCIONE")
            //{
            //    //CARGAR SEDE
            //    comboBox_detalle_sede.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
            //    comboBox_detalle_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_detalle_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }


        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardar();
        }

        public async Task AlertaGuardar()
        {
            string idTrabCurso;
            idTrabCurso = textBox_Id.Text + "_" +
                comboBox_sede.Text + "_" +
                comboBox_TipoTrabajador.Text + "_" +
                textBox_Curso.Text + "_";

            if (comboBox_empresa.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else if (comboBox_sede.Text == "SELECCIONE")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE", Color.FromArgb(238, 24, 24), 3);
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
            else if (textBox_Descripcion.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("FALTA DESCRIPCION", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

            else if (textRuta.Text.Trim() == "")
            {
                Msbox.Frm_NotificacionesPeligro ng =
                    new Msbox.Frm_NotificacionesPeligro("SELECCIONE UN ARCHIVO", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                if (label_Id.Text == "0")
                {
                    var exchar = cn_logistica.BuscExisteCursoProgramado(
                        idTrabCurso, Convert.ToDateTime("2026-01-01"), 2
                        );

                    if (exchar == true)
                    {
                        Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("CURSO YA FUE PROGRAMADO", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                    else
                    {
                        string MessageBoxTitle = "GUARDAR ";
                        string MessageBoxContent = "¿Desea guardar registro? ";

                        DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ce_apimodels.UploadResponse uploadResult = null;

                            try
                            {
                                // =========================
                                // 🔹 SUBIR DOCUMENTO
                                // =========================
                                uploadResult = await SubirDocumento();

                                // =========================
                                // 🔹 AQUÍ YA TIENES LA RESPUESTA
                                // =========================
                                if (uploadResult != null && uploadResult.success)
                                {
                                    objcnlogistica.GuardarCursosProgramados(
                                    0,
                                    comboBox_empresa.Text,//EMPRESA
                                    comboBox_sede.Text,//SEDE
                                    comboBox_TipoTrabajador.Text, //TIPO TRAB
                                    Convert.ToInt32(textBox_Id.Text.Trim()),//
                                    textBox_Curso.Text.Trim(),//
                                    textBox_Descripcion.Text.Trim(),//
                                    textBox_Comentario.Text.Trim(),//
                                    textBox_Duracion.Text.Trim(),//
                                    textRuta.Text.Trim(),//
                                    uploadResult.path,//
                                    "S", //estado
                                    ce_usuario.FechaSistema(),
                                    ce_usuario.usecod,
                                    ce_usuario.HostName(),
                                    ce_usuario.FechaSistema(),
                                    0
                                    );

                                    //Console.WriteLine("Archivo subido:");
                                    //Console.WriteLine(uploadResult.name);
                                    //Console.WriteLine(uploadResult.path);
                                    //Console.WriteLine(uploadResult.url);
                                }
                                else
                                {
                                    MessageBox.Show("Error al subir documento");
                                    return;
                                }


                            }
                            finally
                            {

                                // =========================
                                // 🔹 USAR DATOS DEL ARCHIVO
                                // =========================
                                //if (uploadResult != null && uploadResult.success)
                                //{
                                //    // AQUÍ tienes todos los campos del API
                                //    MessageBox.Show("Path "+ uploadResult.path +" "+
                                //        "Path " + uploadResult.name + " " +
                                //        "Url " + uploadResult.url);
                                //    // SI QUIERES GUARDAR EN BD:
                                //}

                                Msbox.Frm_NotificacionesPeligro ng =
                                    new Msbox.Frm_NotificacionesPeligro(
                                        "GUARDADO CORRECTAMENTE",
                                        Color.FromArgb(12, 19, 214),
                                        1);

                                ng.ShowDialog();

                                LimiparCampos();
                            }
                        }

                        //}
                        //else
                        //{
                        //    MessageBox.Show("RANGO DE FECHA SELECCIONADA YA CUENTA CON REGISTRO","NO GUARDADO");
                        //    //Msbox.Frm_NotificacionesPeligro ng =
                        //    //new Msbox.Frm_NotificacionesPeligro("RANGO DE FECHAS YA CUENTA CON REGISTRO", Color.FromArgb(238, 24, 24), 3);
                        //    //ng.ShowDialog();
                        //}
                    }
                }
                else
                {

                    string MessageBoxTitle = "ACTUALIZAR";
                    string MessageBoxContent = "¿Desea actualizar registro? ";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ce_apimodels.UploadResponse uploadResult = null;

                        try
                        {
                            if (textRuta.Text.Trim().StartsWith(
                                @"C:\proyecto\CursosAsa\",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                // No subir documento
                                uploadResult = new ce_apimodels.UploadResponse
                                {
                                    success = true,
                                    path = textRuta.Text.Trim()
                                };
                            }
                            else
                            {
                                // Subir documento normalmente
                                uploadResult = await SubirDocumento();
                            }

                            if (uploadResult != null && uploadResult.success)
                            {
                                objcnlogistica.GuardarCursosProgramados(
                                    Convert.ToInt32(label_Id.Text.Trim()),
                                    comboBox_empresa.Text,
                                    comboBox_sede.Text,
                                    comboBox_TipoTrabajador.Text,
                                    Convert.ToInt32(textBox_Id.Text.Trim()),
                                    textBox_Curso.Text.Trim(),
                                    textBox_Descripcion.Text.Trim(),
                                    textBox_Comentario.Text.Trim(),
                                    textBox_Duracion.Text.Trim(),
                                    textRuta.Text.Trim(),
                                    uploadResult.path, // Será textRuta.Text cuando se omita la subida
                                    "S",
                                    ce_usuario.FechaSistema(),
                                    ce_usuario.usecod,
                                    ce_usuario.HostName(),
                                    ce_usuario.FechaSistema(),
                                    0
                                );
                            }
                            else
                            {
                                MessageBox.Show("Error al subir documento");
                                return;
                            }
                        }
                        finally
                        {

                            // =========================
                            // 🔹 USAR DATOS DEL ARCHIVO
                            // =========================
                            //if (uploadResult != null && uploadResult.success)
                            //{
                            //    // AQUÍ tienes todos los campos del API
                            //    MessageBox.Show("Path "+ uploadResult.path +" "+
                            //        "Path " + uploadResult.name + " " +
                            //        "Url " + uploadResult.url);
                            //    // SI QUIERES GUARDAR EN BD:
                            //}

                            Msbox.Frm_NotificacionesPeligro ng =
                                new Msbox.Frm_NotificacionesPeligro(
                                    "ACTUALIZADO CORRECTAMENTE",
                                    Color.FromArgb(12, 19, 214),
                                    1);

                            ng.ShowDialog();

                            //LimiparCampos();
                        }
                    }

                }

            }
        }


        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimiparCampos();
        }

        public void LimiparCampos()
        {
            textBox_Id.Text = string.Empty;
            textBox_Curso.Text = string.Empty;
            textBox_Descripcion.Text = string.Empty;
            textBox_Comentario.Text = string.Empty;
            textRuta.Text = string.Empty;
            //textBox_Area.Text = string.Empty;
        }



        private void textBox_Proveedor_DoubleClick(object sender, EventArgs e)
        {
            Frm_BuscarCursos frbm = new Frm_BuscarCursos();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }

        private void textBox_Ruc_DoubleClick(object sender, EventArgs e)
        {
            Frm_BuscarCursos frbm = new Frm_BuscarCursos();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }


        public void TablaAgregarDatosFilaCursos(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        public void TablaAgregarDatosFilaAsigCursos(DataGridViewRow fila1a)
        {
            string id = (string)fila1a.Cells[1].Value.ToString();
            string curso = (string)fila1a.Cells[2].Value.ToString();
            textBox_Id.Text = id;
            textBox_Curso.Text = curso;
        }

        private void textBox_Ruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox_Proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Seleccionar documento";

            openFileDialog.Filter =
                "Todos los archivos|*.*|" +
                "PDF|*.pdf|" +
                "Word|*.doc;*.docx|" +
                "Excel|*.xls;*.xlsx|" +
                "Imagenes|*.jpg;*.png";

            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar ruta completa
                rutaArchivo = openFileDialog.FileName;

                // Mostrar SOLO nombre del archivo
                textRuta.Text = Path.GetFileName(rutaArchivo);
            }
        }

        private async Task<ce_apimodels.UploadResponse> SubirDocumento()
        {
            try
            {
                // =========================
                // 🔹 NOMBRE PERSONALIZADO
                // =========================
                string nombreArchivo =
                    textBox_Id.Text.Trim() + "_" +
                    comboBox_sede.Text.Trim() + "_" +
                    comboBox_TipoTrabajador.Text.Trim() + "_" +
                    textBox_Curso.Text.Trim();

                if (string.IsNullOrEmpty(rutaArchivo))
                {
                    MessageBox.Show("Seleccione un documento");
                    return null;
                }

                // =========================
                // 🔹 SUBIDA
                // =========================
                ce_apimodels.UploadResponse result =
                    await apiService.SubirDocumentoAsync(rutaArchivo, nombreArchivo);

                if (result != null && result.success)
                {
                    //MessageBox.Show("Documento enviado correctamente");

                    //textRuta.Text = "";
                    rutaArchivo = "";

                    return result;
                }
                else
                {
                    MessageBox.Show("Error al enviar documento");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void textBox_Duracion_TextChanged(object sender, EventArgs e)
        {
            if (_formateando) return;

            _formateando = true;

            try
            {
                // solo números
                string numeros = new string(textBox_Duracion.Text
                    .Where(char.IsDigit)
                    .ToArray());

                if (numeros.Length == 0)
                {
                    textBox_Duracion.Text = "";
                    return;
                }

                // limitar a 6 dígitos máximo (HHMMSS)
                if (numeros.Length > 6)
                    numeros = numeros.Substring(numeros.Length - 6);

                // rellenar a la izquierda con ceros
                numeros = numeros.PadLeft(6, '0');

                string hh = numeros.Substring(0, 2);
                string mm = numeros.Substring(2, 2);
                string ss = numeros.Substring(4, 2);

                textBox_Duracion.Text = $"{hh}:{mm}:{ss}";

                textBox_Duracion.SelectionStart = textBox_Duracion.Text.Length;
            }
            finally
            {
                _formateando = false;
            }
        }

    }

    internal interface VarDatosEntroFormCursos
    {
        void TablaAgregarDatosFilaCursos(DataGridViewRow fila1a);
        void TablaAgregarDatosFilaAsigCursos(DataGridViewRow fila1a);
    }
}
