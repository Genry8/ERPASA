using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Acopio.Frm_Maestros
{
    /// <summary>
    /// Alta y edición de TIPO DE DEFECTO (tabla PACK_TipoDefecto).
    /// Un solo formulario para los dos casos: id en 0 significa alta.
    /// </summary>
    public partial class frm_AgregarTipoDefecto : Form
    {
        cn_packing objcnpacking = new cn_packing();

        private readonly int id;
        private int alto = 20;

        private Guna2TextBox campo_TipoDefecto;
        private Guna2ComboBox campo_Cultivo;
        private Guna2TextBox campo_Obs;

        public frm_AgregarTipoDefecto(int idRegistro, DataRow fila)
        {
            InitializeComponent();

            id = idRegistro;
            Text = (id == 0 ? "NUEVO - " : "EDITAR - ") + "TIPO DE DEFECTO";

            campo_TipoDefecto = Caja(50);
            Agregar("TIPO DE DEFECTO", campo_TipoDefecto);
            campo_Cultivo = Combo("cultivo");
            Agregar("CULTIVO", campo_Cultivo);
            campo_Obs = CajaLarga(1000);
            Agregar("OBSERVACION", campo_Obs);

            var botonGuardar = new Button
            {
                Text = id == 0 ? "Guardar" : "Actualizar",
                Size = new Size(130, 38),
                Location = new Point(330, alto + 10)
            };
            botonGuardar.Click += delegate { Guardar(); };

            var botonCancelar = new Button
            {
                Text = "Cancelar",
                Size = new Size(120, 38),
                Location = new Point(480, alto + 10),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(botonGuardar);
            Controls.Add(botonCancelar);
            CancelButton = botonCancelar;
            ClientSize = new Size(620, alto + 70);

            if (fila != null) CargarDatosParaEditar(fila);

            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate
            {
                Estilos.EstilizadorErp.Aplicar(this);
                // El estilizador pinta todos los botones con el mismo acento;
                // cancelar queda en gris para no competir con guardar.
                botonCancelar.BackColor = Estilos.PaletaErp.Borde;
                botonCancelar.ForeColor = Estilos.PaletaErp.Texto;
            };
        }

        // ------------------------------------------------ armado de la ficha

        private void Agregar(string etiqueta, Control control)
        {
            Controls.Add(new Label
            {
                Text = etiqueta,
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 7.875F),
                Location = new Point(20, alto + 8)
            });

            control.Location = new Point(190, alto);
            Controls.Add(control);

            alto += control.Height + 10;
        }

        private Guna2TextBox Caja(int largo)
        {
            return new Guna2TextBox
            {
                Size = new Size(400, 36),
                BorderRadius = 6,
                MaxLength = largo > 0 ? largo : 32767,
                Font = new Font("Calibri", 10F, FontStyle.Bold)
            };
        }

        private Guna2TextBox CajaLarga(int largo)
        {
            return new Guna2TextBox
            {
                Size = new Size(400, 70),
                Multiline = true,
                BorderRadius = 6,
                MaxLength = largo > 0 ? largo : 32767,
                Font = new Font("Calibri", 10F, FontStyle.Bold)
            };
        }

        private Guna2ComboBox Combo(string catalogo)
        {
            var combo = new Guna2ComboBox
            {
                Size = new Size(400, 36),
                DropDownStyle = ComboBoxStyle.DropDownList,
                ItemHeight = 30,
                Font = new Font("Calibri", 10F, FontStyle.Bold)
            };

            try
            {
                if (catalogo == "cultivo")
                {
                    combo.DataSource = cn_packing.ListaCultivo();
                    combo.DisplayMember = "Cultivo"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
                    combo.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
                }
                else if (catalogo == "cabezal")
                {
                    // Los cabezales salen del propio maestro PACK_Cabezal; se
                    // listan solo los vigentes.
                    DataTable cabezales = cn_packing.ListaMaestroCabezal();
                    cabezales.DefaultView.RowFilter = "EstadoReg = 'ACTIVO'";

                    combo.DataSource = cabezales.DefaultView.ToTable();
                    combo.DisplayMember = "Cabezal";
                    combo.ValueMember = "Id";
                }
                else if (catalogo == "sede")
                {
                    combo.DataSource = cn_logistica.ListaCBSedeTodoAsignacionTI();
                    combo.DisplayMember = "DesSed";
                    combo.ValueMember = "id";
                }
                else
                {
                    combo.DataSource = cn_logistica.ListaCBEmpresaTodoAsignacionTI();
                    combo.DisplayMember = "DesEmp";
                    combo.ValueMember = "id";
                }
            }
            catch
            {
                // Si el catálogo no responde el combo queda vacío, pero la
                // pantalla abre igual y se puede seguir con lo demás.
                combo.DataSource = null;
            }

            return combo;
        }

        private void CargarDatosParaEditar(DataRow fila)
        {
            campo_TipoDefecto.Text = Convert.ToString(fila["TipoDefecto"]);
            campo_Cultivo.Text = Convert.ToString(fila["Cultivo"]);
            campo_Obs.Text = Convert.ToString(fila["Obs"]);
        }

        /// <summary>El texto "SELECCIONE" de los combos no es un dato.</summary>
        private static string Texto(Control control)
        {
            string valor = control.Text.Trim();
            return valor == "SELECCIONE" ? "" : valor;
        }

        // ------------------------------------------------------- guardado

        private void Guardar()
        {
            if (campo_TipoDefecto.Text.Trim() == "" || campo_TipoDefecto.Text.Trim() == "SELECCIONE")
            {
                Avisar("FALTA TIPO DE DEFECTO");
                return;
            }

            if (cn_packing.BuscExisteMaestroTipoDefecto(Texto(campo_TipoDefecto), Texto(campo_Cultivo), id))
            {
                Avisar("YA EXISTE UN REGISTRO CON ESOS DATOS, VERIFIQUE NUEVAMENTE");
                return;
            }

            string titulo = id == 0 ? "GUARDAR" : "ACTUALIZAR";
            string pregunta = id == 0
                ? "¿Desea guardar el registro? "
                : "¿Desea actualizar el registro? ";

            if (MessageBox.Show(pregunta, titulo,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                if (id == 0)
                {
                    objcnpacking.GuardarMaestroTipoDefecto(
                Texto(campo_TipoDefecto),
                Texto(campo_Cultivo),
                Texto(campo_Obs),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod,
                        ce_usuario.HostName());

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    LimpiarCampos();
                }
                else
                {
                    objcnpacking.ActualizarMaestroTipoDefecto(
                        id,
                Texto(campo_TipoDefecto),
                Texto(campo_Cultivo),
                Texto(campo_Obs),
                        ce_usuario.FechaSistema(),
                        ce_usuario.usecod);

                    Msbox.Frm_NotificacionesPeligro ng =
                        new Msbox.Frm_NotificacionesPeligro("ACTUALIZADO CORRECTAMENTE",
                            Color.FromArgb(12, 19, 214), 1);
                    ng.ShowDialog();

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar:\n\n" + ex.Message,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            foreach (Control c in Controls)
            {
                var caja = c as Guna2TextBox;
                if (caja != null) caja.Text = "";
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
