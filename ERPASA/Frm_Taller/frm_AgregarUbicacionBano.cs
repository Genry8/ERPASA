using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERPASA.Frm_Taller
{
    /// <summary>
    /// Alta y edición de una ubicación de baño (tabla TALL_UbicacionBaños).
    ///
    /// Es un solo formulario para los dos casos, a diferencia de vehículos que
    /// tiene uno para agregar y otro para editar: la pantalla es idéntica y
    /// mantener dos copias solo duplica el trabajo ante cualquier cambio.
    /// Lo que distingue un caso del otro es label_Id: "0" significa alta.
    /// </summary>
    public partial class frm_AgregarUbicacionBano : Form
    {
        cn_taller objcntaller = new cn_taller();

        public frm_AgregarUbicacionBano()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void frm_AgregarUbicacionBano_Load(object sender, EventArgs e)
        {
            PonerOscuroComboBox();
            CargarDatosComboBox();

            // En edición los valores llegan por ce_taller desde el reporte.
            if (label_Id.Text != "0")
            {
                Text = "EDITAR UBICACION DE BAÑO";
                CargarDatosParaEditar();
            }
        }

        public void PonerOscuroComboBox()
        {
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Genero.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox_Cabezal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarDatosComboBox()
        {
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            // Los cabezales salen del maestro PACK_Cabezal; solo los vigentes.
            DataTable cabezales = cn_packing.ListaMaestroCabezal();
            cabezales.DefaultView.RowFilter = "EstadoReg = 'ACTIVO'";

            textBox_Cabezal.DataSource = cabezales.DefaultView.ToTable();
            textBox_Cabezal.DisplayMember = "Cabezal"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            textBox_Cabezal.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            // La tabla guarda un solo carácter, pero en pantalla se ve completo.
            comboBox_Genero.Items.Clear();
            comboBox_Genero.Items.Add("SELECCIONE");
            comboBox_Genero.Items.Add("M - MASCULINO");
            comboBox_Genero.Items.Add("F - FEMENINO");
            comboBox_Genero.Items.Add("X - MIXTO");
            comboBox_Genero.SelectedIndex = 0;
        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CARGAR SEDE
            comboBox_sede.DataSource = cn_logistica.ListaCBSedeEmpresaTodoAsignacionTI(comboBox_empresa.Text);
            comboBox_sede.DisplayMember = "DesSed"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_sede.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        /// <summary>
        /// Rellena la pantalla con el registro que se eligió en el reporte.
        /// La sede se asigna después de la empresa porque su lista depende de ella.
        /// </summary>
        private void CargarDatosParaEditar()
        {
            comboBox_empresa.Text = ce_taller.empresa;
            comboBox_sede.Text = ce_taller.sede;

            textBox_Cabezal.Text = ce_taller.bano_cabezal;
            textBox_Valvula.Text = ce_taller.bano_valvula;
            textBox_NroBano.Text = ce_taller.bano_numero;
            textBox_Obs.Text = ce_taller.bano_obs;
            textBox_Foto.Text = ce_taller.bano_foto;

            foreach (object item in comboBox_Genero.Items)
            {
                if (item.ToString().StartsWith(ce_taller.bano_genero + " "))
                {
                    comboBox_Genero.SelectedItem = item;
                    break;
                }
            }
        }

        /// <summary>
        /// El combo muestra "M - MASCULINO" y la tabla guarda solo "M".
        /// </summary>
        private string GeneroSeleccionado()
        {
            string texto = comboBox_Genero.Text.Trim();
            return texto.Length > 0 ? texto.Substring(0, 1) : "";
        }

        private void button_Foto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrir = new OpenFileDialog())
            {
                abrir.Title = "Seleccionar foto del baño";
                abrir.Filter = "Imagenes|*.jpg;*.jpeg;*.png|Todos los archivos|*.*";

                if (abrir.ShowDialog() != DialogResult.OK) return;

                // La columna admite 200 caracteres: se guarda el nombre, no la
                // ruta completa de la PC de quien registra.
                textBox_Foto.Text = Path.GetFileName(abrir.FileName);
            }
        }

        private void toolStripButton_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            textBox_Cabezal.Text = "";
            textBox_Valvula.Text = "";
            textBox_NroBano.Text = "";
            textBox_Obs.Text = "";
            textBox_Foto.Text = "";
            if (comboBox_Genero.Items.Count > 0) comboBox_Genero.SelectedIndex = 0;
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            AlertaGuardarUbicacionBano();
        }

        public void AlertaGuardarUbicacionBano()
        {
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE EMPRESA");
            }
            else if (comboBox_sede.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE SEDE");
            }
            else if (textBox_Cabezal.Text.Trim() == "")
            {
                Avisar("FALTA CABEZAL");
            }
            else if (textBox_Valvula.Text.Trim() == "")
            {
                Avisar("FALTA VALVULA");
            }
            else if (textBox_NroBano.Text.Trim() == "")
            {
                Avisar("FALTA N° DE BAÑO");
            }
            else if (comboBox_Genero.Text == "SELECCIONE")
            {
                Avisar("SELECCIONE GENERO");
            }
            else
            {
                int id = Convert.ToInt32(label_Id.Text.Trim());

                // En edición se excluye el propio registro de la verificación.
                var existe = cn_taller.BuscExisteUbicacionBano(
                    comboBox_empresa.Text,
                    comboBox_sede.Text,
                    textBox_Cabezal.Text.Trim(),
                    textBox_Valvula.Text.Trim(),
                    textBox_NroBano.Text.Trim(),
                    id);

                if (existe == true)
                {
                    Avisar("ESE BAÑO YA ESTA REGISTRADO, VERIFIQUE NUEVAMENTE");
                    return;
                }

                string MessageBoxTitle = id == 0 ? "GUARDAR" : "ACTUALIZAR";
                string MessageBoxContent = id == 0
                    ? "¿Desea guardar la ubicación del baño? "
                    : "¿Desea actualizar la ubicación del baño? ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult != DialogResult.Yes) return;

                if (id == 0)
                {
                    objcntaller.GuardarUbicacionBano(
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        textBox_Cabezal.Text.Trim(),//cabezal
                        textBox_Valvula.Text.Trim(),//valvula
                        textBox_NroBano.Text.Trim(),//nro bano
                        GeneroSeleccionado(),//genero
                        textBox_Obs.Text.Trim(),//obs
                        textBox_Foto.Text.Trim(),//foto

                        "S", //estado
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName(),
                        ce_usuario.FechaSistema(),
                        0,
                        0
                        );

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    LimpiarCampos();
                }
                else
                {
                    objcntaller.ActualizarUbicacionBano(
                        id,
                        comboBox_empresa.Text,//EMPRESA
                        comboBox_sede.Text,//SEDE
                        textBox_Cabezal.Text.Trim(),//cabezal
                        textBox_Valvula.Text.Trim(),//valvula
                        textBox_NroBano.Text.Trim(),//nro bano
                        GeneroSeleccionado(),//genero
                        textBox_Obs.Text.Trim(),//obs
                        textBox_Foto.Text.Trim(),//foto
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod
                        );

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    Close();
                }
            }
        }

        private void Avisar(string mensaje)
        {
            Msbox.Frm_NotificacionesPeligro ng =
                new Msbox.Frm_NotificacionesPeligro(mensaje, Color.FromArgb(238, 24, 24), 3);
            ng.ShowDialog();
        }
    }
}
