using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPASA.Frm_DestajoUva
{
    public partial class frm_AgregarSticker : Form
    {
        DataTable dtg;
        List<RegistroQR> lista = new List<RegistroQR>();
        DataTable dtgCampos;

        public frm_AgregarSticker()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void guna2TextBox_liquidacion_TextChanged(object sender, EventArgs e)
        {

        }

        public void TablaAgregarDatosFilaLiquidacion(DataGridViewRow fila1a)
        {
            throw new NotImplementedException();
        }

        private void pictureBox_EliminarLiq_Click(object sender, EventArgs e)
        {
            SepararCampos();

        }

        public void limpiarCampos()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(limpiarCampos));
                return;
            }

            guna2TextBox_presentacion.Text = "";
            guna2TextBox_seleccion.Text = "";
            guna2TextBox_pesado.Text = "";
            guna2TextBox_empaque.Text = "";
            guna2TextBox_presentacion.Focus();
        }

        private void SepararCampos()
        {
            string trama = "PR'" + guna2TextBox_presentacion.Text.Trim() +
                "SM000'" + guna2TextBox_seleccion.Text.Trim() +
                "PM000'" + guna2TextBox_pesado.Text.Trim() +
                "EM000'" + guna2TextBox_empaque.Text.Trim();
            string inputNave = ce_datosPedateo.Nave;
            string inputLine = ce_datosPedateo.Linea;

            if (guna2TextBox_presentacion.Text.Trim() == "")
            {
                MessageBox.Show("FALTA PRESENTACION");
                return;
            }
            if (guna2TextBox_seleccion.Text.Trim() == "")
            {
                MessageBox.Show("FALTA SELECCION");
                return;
            }
            if (guna2TextBox_pesado.Text.Trim() == "")
            {
                MessageBox.Show("FALTA PESADO");
                return;
            }
            if (guna2TextBox_empaque.Text.Trim() == "")
            {
                MessageBox.Show("FALTA EMPAQUE");
                return;
            }
            // Mínimo 10 caracteres
            if (trama.Length < 11 || !trama.Contains("'"))
            {
                MessageBox.Show("LA TRAMA NO TIENE EL FORMATO CORRECTO");
                limpiarCampos();
                return;
            }


            lista.Clear();

            // ==================================================
            // 1️⃣ Obtener PR'####
            // ==================================================
            int codPre = 0;
            var matchPR = Regex.Match(trama, @"PR'(\d+)");
            if (matchPR.Success)
                codPre = int.Parse(matchPR.Groups[1].Value);


            // ==================================================
            // 2️⃣ Obtener los códigos EM, SM, PM en cualquier orden
            // ==================================================
            int codSM = 0;
            int codPM = 0;
            int codEM = 0;

            // Selección (SM)
            var matchSM = Regex.Match(trama, @"SM\d+'(\d+)");
            if (matchSM.Success)
                codSM = int.Parse(matchSM.Groups[1].Value);

            // Pesado (PM)
            var matchPM = Regex.Match(trama, @"PM\d+'(\d+)");
            if (matchPM.Success)
                codPM = int.Parse(matchPM.Groups[1].Value);

            // Empaque (EM)
            var matchEM = Regex.Match(trama, @"EM\d+'(\d+)");
            if (matchEM.Success)
                codEM = int.Parse(matchEM.Groups[1].Value);


            // ==================================================
            // 3️⃣ Construir SIEMPRE las 3 filas en orden fijo
            // ==================================================

            // Selección
            lista.Add(new RegistroQR
            {
                TramaReal = trama,
                CodPre = codPre,
                Detalle = "Seleccion",
                CodSticker = codSM
            });

            // Pesado
            lista.Add(new RegistroQR
            {
                TramaReal = trama,
                CodPre = codPre,
                Detalle = "Pesado",
                CodSticker = codPM
            });

            // Empaque
            lista.Add(new RegistroQR
            {
                TramaReal = trama,
                CodPre = codPre,
                Detalle = "Empaque",
                CodSticker = codEM
            });

            // Guardar datos
            string sessionId = Guid.NewGuid().ToString();
            GuardarDatosSync(sessionId);
        }

        private async void GuardarDatosSync(string sessionId)
        {
            Cursor.Current = Cursors.WaitCursor;
            //// Mostrar el formulario de carga de manera no modal
            //Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            ////frbm.StartPosition = FormStartPosition.CenterParent;
            //frbm.Show(this); // Mostrar como formulario hijo
            ////frbm.label1.Text = "GUARDANDO DATOS..."; // Actualizar el texto del formulario de carga

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarLecturaStickerBulk(lista, sessionId);//dtgCampos
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                //frbm.Close(); // Cerrar el formulario de carga
                // Mostrar mensaje de éxito
                //Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("GUARDADO CORRECTAMENTE", Color.FromArgb(12, 19, 214), 1);
                //ng.ShowDialog();
            }
        }

        public void GuardarLecturaStickerBulk(List<RegistroQR> listaQR, string sessionId)
        {
            // 1. Convertir lista de RegistroQR a lista para BD
            List<ce_pedateosticker> listaBD = ConvertirDataTableALista(listaQR, sessionId);

            // 2. Convertir lista a DataTable
            DataTable dt = ConvertirListaADataTable(listaBD);

            // 3. Guardar en BD
            cd_planilla datos = new cd_planilla();
            var resultado = datos.GuardarLecturaStickerBulkTVP(dt);

            // 4. Manejar mensajes de duplicados
            if (resultado.CodGruposDuplicados != null && resultado.CodGruposDuplicados.Count > 0)
            {
                label_estado_reg.Invoke(new MethodInvoker(() =>
                {
                    label_estado_reg.ForeColor = Color.Red;
                    label_estado_reg.Text = "REGISTROS  " + string.Join(", ", resultado.CodGruposDuplicados) + "   YA EXISTEN";
                }));
            }
            else
            {
                label_estado_reg.Invoke(new MethodInvoker(() =>
                {
                    label_estado_reg.ForeColor = Color.Green;
                    label_estado_reg.Text = "✅ " + resultado.Mensaje;
                }));

            }
            limpiarCampos();

        }

        public List<ce_pedateosticker> ConvertirDataTableALista(List<RegistroQR> lista, string sessionId)
        {

            List<ce_pedateosticker> listaBD = new List<ce_pedateosticker>();

            foreach (var item in lista)
            {
                listaBD.Add(new ce_pedateosticker
                {
                    FechaProceso = ce_datosPedateo.Fecha,
                    CadOriginal = item.TramaReal,
                    CodPreStick = item.CodPre,
                    DetGrupo = item.Detalle,
                    CodGrupoStick = item.CodSticker,
                    IdNave = 0,
                    Nave = ce_datosPedateo.Nave,
                    IdLinea = 0,
                    Linea = ce_datosPedateo.Linea,
                    Obs = "MANUAL",
                    Estado = "S",
                    FecCre = ce_usuario.FechaSistema(),
                    UseReg = ce_usuario.usecod,
                    Hostname = ce_usuario.HostName(),
                    FecEdit = ce_usuario.FechaSistema(),
                    UseEdit = 0,
                    UseElim = 0,
                    SessionId = sessionId
                });
            }

            return listaBD;
        }


        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Crear columnas
            foreach (var propiedad in propiedades)
            {
                Type tipo = propiedad.PropertyType;

                if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipo = Nullable.GetUnderlyingType(tipo);
                }

                dt.Columns.Add(propiedad.Name, tipo);
            }

            // Llenar filas
            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                foreach (var propiedad in propiedades)
                {
                    var valor = propiedad.GetValue(entidad);
                    fila[propiedad.Name] = valor ?? DBNull.Value;
                }

                dt.Rows.Add(fila);
            }

            return dt;
        }


        private void frm_AgregarSticker_Load(object sender, EventArgs e)
        {
            guna2TextBox_seleccion.Focus();

            /*
            MessageBox.Show("Fecha: "+ce_datosPedateo.Fecha+"\n " +
                " Nave: "+ce_datosPedateo.Nave+"\n"+
                " Linea: " + ce_datosPedateo.Linea);
            */
        }

        private void guna2TextBox_presentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir solo números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }

        private void guna2TextBox_seleccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir solo números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }

        private void guna2TextBox_pesado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir solo números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }

        private void guna2TextBox_empaque_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir solo números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }
    }

    //internal interface VarDatosEntroFormLiquidacion
    //{
    //    void TablaAgregarDatosFilaLiquidacion(DataGridViewRow fila1a);
    //    void TablaAgregarDatosFilaAsigLiquidacion(DataGridViewRow fila1a);
    //}

}
