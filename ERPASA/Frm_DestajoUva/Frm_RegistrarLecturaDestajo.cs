using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Comercial;
using ExcelDataReader;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERPASA.Frm_DestajoUva
{
    public partial class Frm_RegistrarLecturaDestajo : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg, dtgCierre;
        List<RegistroQR> lista = new List<RegistroQR>();
        DataTable dtgCampos;


        public static DataTable dtgTodosCampos = new DataTable();

        private CancellationTokenSource _cts;


        public Frm_RegistrarLecturaDestajo()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void Frm_RegistrarLecturaDestajo_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            PonerOscuroComboBox();
            CargarDatosComboBox();
            guna2TextBox_LecturaSticker.Text = guna2TextBox_LecturaSticker.Text.ToUpper();
            guna2TextBox_LecturaSticker.Focus();
            inicializarDtgCampos();
            comboBox_nave.Text = "NAVE 01";
        }

        public void inicializarDtgCampos()
        {
            dtgCampos = new DataTable();

            dtgCampos.Columns.Add("TramaReal", typeof(string));
            dtgCampos.Columns.Add("CodPre", typeof(int));
            dtgCampos.Columns.Add("Detalle", typeof(string));
            dtgCampos.Columns.Add("CodSticker", typeof(int));

        }

        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_nave.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_linea.DropDownStyle = ComboBoxStyle.DropDownList;
            //DATAGRIDVIEW
        }


        public void CargarDatosComboBox()
        {
            comboBox_nave.DataSource = cn_packing.ListaNave();
            comboBox_nave.DisplayMember = "Nave"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_nave.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_linea.DataSource = cn_packing.ListaLinea();
            comboBox_linea.DisplayMember = "Linea"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_linea.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }


        private async void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_cargando frbm = new Msbox.frm_cargando();
            frbm.Show(this); // Mostrar como formulario hijo
            Application.DoEvents(); // 🔧 permite que el formulario se pinte

            try
            {
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    mostrarDatos();
                    dataGridView1.ClearSelection();
                });

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtg;
                dataGridView1.AllowUserToAddRows = false;

                // Verificar el número de registros y mostrar un mensaje adecuado
                if (dataGridView1.Rows.Count > 1)
                {
                    label_estado_reg.Text = (dataGridView1.RowCount - 1).ToString() + " REGISTROS";
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    label_estado_reg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
                }
                else
                {
                    Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                    ng.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
            }
        }

        public void mostrarDatos()
        {
            string naveText = string.Empty, lineaText = string.Empty;
            ////////////////////////////////////
            if (comboBox_nave.InvokeRequired)
            {
                comboBox_nave.Invoke(new MethodInvoker(() =>
                {
                    naveText = comboBox_nave.Text;
                }));
            }
            else
            {
                naveText = comboBox_nave.Text;
            }


            // Rellenar el DataGridView con los datos
            //dataGridView1.DataSource = dtg;
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

        public List<ce_pedateosticker> ConvertirDataTableALista1(DataTable dgv)
        {
            string naveText = string.Empty, idnaveText = string.Empty,
                lineaText = string.Empty, idlineaText = string.Empty;

            // Obtener el valor de la Nave (comboBox_nave)
            if (comboBox_nave.InvokeRequired)
            {
                comboBox_nave.Invoke(new MethodInvoker(() =>
                {
                    naveText = comboBox_nave.Text;
                    idnaveText = comboBox_nave.SelectedValue.ToString();
                }));
            }
            else
            {
                naveText = comboBox_nave.Text;
            }

            // Obtener el valor de la Línea (comboBox_linea)
            if (comboBox_linea.InvokeRequired)
            {
                comboBox_linea.Invoke(new MethodInvoker(() =>
                {
                    lineaText = comboBox_linea.Text;
                    idlineaText = comboBox_linea.SelectedValue.ToString();
                }));
            }
            else
            {
                lineaText = comboBox_linea.Text;
            }

            List<ce_pedateosticker> lista = new List<ce_pedateosticker>();

            foreach (DataRow row in dgv.Rows)
            {
                // Puedes validar que la fila no esté vacía
                if (row.RowState != DataRowState.Deleted && row[0] != DBNull.Value)
                {
                    var entidad = new ce_pedateosticker
                    {
                        //Id = 0,
                        FechaProceso = Fecha_Proceso.Value.ToString("yyyy-MM-dd"),
                        CadOriginal = row[0]?.ToString(),
                        CodPreStick = int.TryParse(row[1]?.ToString(), out int codPre) ? codPre : (int?)null,
                        DetGrupo = row[2]?.ToString(),
                        CodGrupoStick = int.TryParse(row[3]?.ToString(), out int codGrupo) ? codGrupo : (int?)null,
                        IdNave = int.TryParse(idnaveText?.ToString(), out int idnav) ? idnav : (int?)null,
                        Nave = naveText?.ToString(),
                        IdLinea = int.TryParse(idlineaText?.ToString(), out int idLinea) ? idLinea : (int?)null,
                        Linea = lineaText,
                        Obs = "", // Puedes agregar campo si viene desde otro lado
                        Estado = "S", // Estado activo por defecto
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = 0,
                        UseElim = 0,
                        SessionId = "" // Llénalo si usas sesiones
                    };

                    lista.Add(entidad);
                }
            }

            return lista;
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
                    SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.mixkit_game_show_buzz_in_3090);
                    sp.Play();

                    label_estado_reg.ForeColor = Color.Red;
                    label_estado_reg.Text = "REGISTROS  " + string.Join(", ", resultado.CodGruposDuplicados) + "   YA EXISTEN";
                }));

                guna2TextBox_LecturaSticker.Invoke(new MethodInvoker(() =>
                {
                    guna2TextBox_LecturaSticker.Text = "";
                }));
                return;

            }
            else if (resultado.Mensaje.IndexOf("FALTA", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                label_estado_reg.Invoke(new MethodInvoker(() =>
                {
                    SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.mixkit_game_show_buzz_in_3090);
                    sp.Play();

                    label_estado_reg.ForeColor = Color.Red;
                    label_estado_reg.Text = "❌ " + resultado.Mensaje;
                }));

                guna2TextBox_LecturaSticker.Invoke(new MethodInvoker(() =>
                {
                    guna2TextBox_LecturaSticker.Text = "";
                }));
                return;
            }

            else
            {
                label_estado_reg.Invoke(new MethodInvoker(() =>
                {
                    SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.beep_401570);
                    sp.Play();

                    label_estado_reg.ForeColor = Color.Green;
                    label_estado_reg.Text = "✅ " + resultado.Mensaje;
                }));

            }
            // 👉 Aquí es seguro limpiar el textbox
            guna2TextBox_LecturaSticker.Invoke(new MethodInvoker(() =>
            {
                guna2TextBox_LecturaSticker.Text = "";
            }));

            CargarDatosSync();
        }

        public List<ce_pedateosticker> ConvertirDataTableALista(List<RegistroQR> lista, string sessionId)
        {
            string naveText = comboBox_nave.InvokeRequired
                ? (string)comboBox_nave.Invoke(new Func<string>(() => comboBox_nave.Text))
                : comboBox_nave.Text;

            int idNave = comboBox_nave.InvokeRequired
                ? (int)comboBox_nave.Invoke(new Func<int>(() => Convert.ToInt32(comboBox_nave.SelectedValue)))
                : Convert.ToInt32(comboBox_nave.SelectedValue);

            string lineaText = comboBox_linea.InvokeRequired
                ? (string)comboBox_linea.Invoke(new Func<string>(() => comboBox_linea.Text))
                : comboBox_linea.Text;

            int idLinea = comboBox_linea.InvokeRequired
                ? (int)comboBox_linea.Invoke(new Func<int>(() => Convert.ToInt32(comboBox_linea.SelectedValue)))
                : Convert.ToInt32(comboBox_linea.SelectedValue);

            List<ce_pedateosticker> listaBD = new List<ce_pedateosticker>();

            foreach (var item in lista)
            {
                listaBD.Add(new ce_pedateosticker
                {
                    FechaProceso = Fecha_Proceso.Value.ToString("yyyy-MM-dd"),
                    CadOriginal = item.TramaReal,
                    CodPreStick = item.CodPre,
                    DetGrupo = item.Detalle,
                    CodGrupoStick = item.CodSticker,
                    IdNave = idNave,
                    Nave = naveText,
                    IdLinea = idLinea,
                    Linea = lineaText,
                    Obs = "LECTURA SCANNER",
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

        private void guna2TextBox_LecturaSticker_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Convertir la tecla presionada a mayúsculas
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido "beep" al presionar Enter
                SepararCampos();
                //GuardarDatosSync(); // Llama a tu método
                //SepararCampos();
                return;
            }
        }

        private string NormalizarCadena(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
                return "";

            // Dividir por '
            var partes = cadena
                .Split('\'')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            // Ordenar las partes
            partes.Sort();

            // Unir nuevamente
            return string.Join("'", partes);
        }

        private void SepararCampos()
        {
            string trama = guna2TextBox_LecturaSticker.Text.Trim();
            string inputNave = comboBox_nave.Text.Trim();
            string inputLine = comboBox_linea.Text.Trim();
            string lectura = NormalizarCadena(guna2TextBox_LecturaSticker.Text);

            // Mantener todos tus if de validación tal como están
            int countPR = Regex.Matches(trama, @"PR'").Count;
            if (countPR > 1)
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();

                label_estado_reg.ForeColor = Color.Red;
                label_estado_reg.Text = "❌ LA LECTURA TIENE FORMATO INCORRECTO";
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            if (trama.Length < 11 || !trama.Contains("'"))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("LA LECTURA NO TIENE EL FORMATO CORRECTO");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            if (inputNave == "SELECCIONE")
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("Por favor, seleccione nave");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            if (inputLine == "SELECCIONE")
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("Por favor, seleccione línea");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            if (string.IsNullOrWhiteSpace(trama))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("POR FAVOR, LECTURE LOS STICKER");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            // ================================================
            // Procesamiento de la trama
            // ================================================
            lista.Clear();

            // 1️⃣ Obtener PR'####
            int codPre = 0;
            var matchPR = Regex.Match(trama, @"PR'(\d+)");
            if (matchPR.Success)
                codPre = int.Parse(matchPR.Groups[1].Value);

            // 2️⃣ Obtener los códigos EM, SM, PM en cualquier orden
            int codSM = 0, codPM = 0, codEM = 0;

            var matchSM = Regex.Match(trama, @"SM\d+'(\d+)");
            if (matchSM.Success)
                codSM = int.Parse(matchSM.Groups[1].Value);

            var matchPM = Regex.Match(trama, @"PM\d+'(\d+)");
            if (matchPM.Success)
                codPM = int.Parse(matchPM.Groups[1].Value);

            var matchEM = Regex.Match(trama, @"EM\d+'(\d+)");
            if (matchEM.Success)
                codEM = int.Parse(matchEM.Groups[1].Value);

            // 3️⃣ Construir filas solo si hay al menos un código válido
            if (matchSM.Success || matchPM.Success || matchEM.Success)
            {
                if (matchSM.Success)
                    lista.Add(new RegistroQR
                    {
                        TramaReal = trama,
                        CodPre = codPre,
                        Detalle = "Seleccion",
                        CodSticker = codSM
                    });

                if (matchPM.Success)
                    lista.Add(new RegistroQR
                    {
                        TramaReal = trama,
                        CodPre = codPre,
                        Detalle = "Pesado",
                        CodSticker = codPM
                    });

                if (matchEM.Success)
                    lista.Add(new RegistroQR
                    {
                        TramaReal = trama,
                        CodPre = codPre,
                        Detalle = "Empaque",
                        CodSticker = codEM
                    });

                // Generar nueva sessionId para esta lectura
                string sessionId = Guid.NewGuid().ToString();
                GuardarDatosSync(sessionId);
            }
        }

        /*
        private void SepararCampos()
        {
            string trama = guna2TextBox_LecturaSticker.Text.Trim();
            string inputNave = comboBox_nave.Text.Trim();
            string inputLine = comboBox_linea.Text.Trim();
            string lectura = NormalizarCadena(guna2TextBox_LecturaSticker.Text);
            // Validar que PR' solo aparezca una vez
            int countPR = Regex.Matches(trama, @"PR'").Count;
            if (countPR > 1)
            {                
                SoundPlayer sp = new SoundPlayer(
                    Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();

                label_estado_reg.ForeColor = Color.Red;
                label_estado_reg.Text = "❌ LA LECTURA TIENE FORMATO INCORRECTO";
                //MessageBox.Show("LA TRAMA CONTIENE PR DUPLICADO");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            // Mínimo 10 caracteres
            if (trama.Length < 11 || !trama.Contains("'"))
            {
                SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                // Reproducir sonido de error del sistema
                //label_estado_reg.ForeColor = Color.Red;
                MessageBox.Show("LA LECTURA NO TIENE EL FORMATO CORRECTO");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }

            if (inputNave == "SELECCIONE")
            {
                SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("Por favor, seleccione nave");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }
            if (inputLine == "SELECCIONE")
            {
                SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("Por favor, seleccione línea");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }
            //if (lectura == dbValue)
            //{
            //    MessageBox.Show("La cadena ya existe");
            //    guna2TextBox_LecturaSticker.Text = "";
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(trama))
            {
                SoundPlayer sp = new SoundPlayer(
                   Properties.Resources.mixkit_game_show_buzz_in_3090);
                sp.Play();
                MessageBox.Show("POR FAVOR, LECTURE LOS STICKER");
                guna2TextBox_LecturaSticker.Text = "";
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
        */

        private async void CargarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // 🔹 Preparar DataGrid antes de cargar datos
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.SuspendLayout();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }));

                // 🔹 1) Procesar datos en un hilo secundario
                ResultadoBusquedaSticker resultado =
                    await Task.Run(() => BuscarDestajoSticker());

                // 🔹 2) Actualizar UI en el hilo principal
                dataGridView1.Invoke(new Action(() =>
                {
                    // --- DATOS ---
                    dataGridView1.Columns.Clear();
                    dtg = resultado.Detalle;
                    dataGridView1.DataSource = dtg;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // --- CONFIGURAR COLUMNAS ---
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.MinimumWidth = 60;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // --- VALIDAR FILAS ---
                    int[] columnasARevisar = { 3, 5, 7 };

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        bool filaInvalida = false;

                        int requiredCount = 0;
                        int.TryParse(row.Cells[9].Value?.ToString(), out requiredCount);

                        int validCount = columnasARevisar
                            .Count(idx =>
                            {
                                var value = row.Cells[idx].Value?.ToString()?.Trim();
                                return !string.IsNullOrEmpty(value) && value != "0";
                            });

                        // Condición de fila inválida
                        filaInvalida = validCount < requiredCount;

                        if (filaInvalida)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 162, 151);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            row.ReadOnly = false;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            row.ReadOnly = true;
                        }
                    }

                    // --- OCULTAR COL 9 ---
                    if (dataGridView1.Columns.Count > 9)
                        dataGridView1.Columns[9].Visible = false;

                    // Encabezados
                    ColorearEncabezados(dataGridView1);
                    dataGridView1.ClearSelection();
                }));


                // 🔹 3) Actualizar labels (UI thread)
                label_total_sticker.Invoke(new MethodInvoker(() =>
                {
                    label_total_sticker.Text = resultado.StickerCorrecto.ToString();
                }));

                label_sticker_incorrectos.Invoke(new MethodInvoker(() =>
                {
                    label_sticker_incorrectos.Text = resultado.StickerIncorrecto.ToString();
                }));

                label_totalCajas.Invoke(new MethodInvoker(() =>
                {
                    label_totalCajas.Text = resultado.TotalCajas.ToString();
                }));

                label_CajasErradas.Invoke(new MethodInvoker(() =>
                {
                    label_CajasErradas.Text = resultado.CajasErradas.ToString();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.ResumeLayout();
                }));
                Cursor.Current = Cursors.Default;
            }
        }


        private void ColorearEncabezados(DataGridView dgv)
        {
            Color colorVerde = Color.LightGreen;
            Color colorNaranja = Color.LightSalmon;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                // Verde: Seleccionador (2) y SecuenciaSel (3)
                if (col.Index == 2 || col.Index == 3)
                {
                    col.HeaderCell.Style.BackColor = colorVerde;
                    col.HeaderCell.Style.ForeColor = Color.Black;
                }
                // Naranja: Empacador (6) y SecuenciaEmp (7)
                else if (col.Index == 6 || col.Index == 7)
                {
                    col.HeaderCell.Style.BackColor = colorNaranja;
                    col.HeaderCell.Style.ForeColor = Color.Black;
                }
            }
        }



        public void BuscarDestajoStickerOF()
        {
            //var val = cn_sst.BuscAtencionPaciente(textBox_Dni.Text, dateTimePicker_FecAtencion.Value.Date,textBox_HoraEntrada.Text);
            //if (val == true)
            //{

            string naveText = string.Empty, lineaText = string.Empty;
            string nave, linea;

            ////////////////////////////////////
            if (comboBox_nave.InvokeRequired)
            {
                comboBox_nave.Invoke(new MethodInvoker(() =>
                {
                    naveText = comboBox_nave.Text;
                }));
            }
            else
            {
                naveText = comboBox_nave.Text;
            }
            ////////////////////////////////////
            if (comboBox_linea.InvokeRequired)
            {
                comboBox_linea.Invoke(new MethodInvoker(() =>
                {
                    lineaText = comboBox_linea.Text;
                }));
            }
            else
            {
                lineaText = comboBox_linea.Text;
            }


            if (naveText == "SELECCIONE")
            {
                nave = "%";
            }
            else
            {
                nave = naveText;
            }
            if (lineaText == "SELECCIONE")
            {
                linea = "%";
            }
            else
            {
                linea = lineaText;
            }


            //dataGridView3.ReadOnly = true;

            var resultado = cn_planilla.DestajoLecturaSticker(
            Fecha_Proceso.Value.Date, nave, linea);

            // Mostrar detalle en DataGridView
            dtg = resultado.Detalle;
            /*
            dtg = cn_planilla.DestajoLecturaSticker(Fecha_Proceso.Value.Date
                , nave, linea);
            */
            label_total_sticker.Invoke(new MethodInvoker(() =>
            {
                label_total_sticker.Text = resultado.StickerCorrecto.ToString();
            }));
            label_sticker_incorrectos.Invoke(new MethodInvoker(() =>
            {
                label_sticker_incorrectos.Text = resultado.StickerInCorrecto.ToString();
            }));
            label_totalCajas.Invoke(new MethodInvoker(() =>
            {
                label_totalCajas.Text = resultado.TotalCajas.ToString();
            }));
            label_CajasErradas.Invoke(new MethodInvoker(() =>
            {
                label_CajasErradas.Text = resultado.CajasErradas.ToString();
            }));
        }

        public ResultadoBusquedaSticker BuscarDestajoSticker()
        {
            string naveText = "", lineaText = "";

            // Obtener valores de combos con Invoke SOLO para leerlos
            comboBox_nave.Invoke(new MethodInvoker(() =>
            {
                naveText = comboBox_nave.Text;
            }));

            comboBox_linea.Invoke(new MethodInvoker(() =>
            {
                lineaText = comboBox_linea.Text;
            }));

            string nave = (naveText == "SELECCIONE") ? "%" : naveText;
            string linea = (lineaText == "SELECCIONE") ? "%" : lineaText;

            // Realizamos consulta a BD (SIN tocar UI)
            var resultado = cn_planilla.DestajoLecturaSticker(
                Fecha_Proceso.Value.Date, nave, linea);

            return new ResultadoBusquedaSticker
            {
                Detalle = resultado.Detalle,
                StickerCorrecto = resultado.StickerCorrecto,
                StickerIncorrecto = resultado.StickerInCorrecto,
                TotalCajas = resultado.TotalCajas,
                CajasErradas = resultado.CajasErradas
            };
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string pres="", sel = "", pes = "", emp = "",session="";
            //if (e.RowIndex >= 0) // Asegura que no haga click en el header
            //{
            //    pres = 
            //        dataGridView1.Rows[e.RowIndex].Cells["CodPre"].Value?.ToString();
            //    TextBox_Presentacion.Text = pres;

            //    sel =
            //            dataGridView1.Rows[e.RowIndex].Cells["SecuenciaSel"].Value?.ToString();
            //    TextBox_Seleccion.Text = sel;

            //    pes =
            //        dataGridView1.Rows[e.RowIndex].Cells["SecuenciaPes"].Value?.ToString();
            //    TextBox_Pesado.Text = pes;

            //    emp =
            //        dataGridView1.Rows[e.RowIndex].Cells["SecuenciaEmp"].Value?.ToString();
            //    TextBox_Empaque.Text = emp;
            //    session =
            //        dataGridView1.Rows[e.RowIndex].Cells["SessionId"].Value?.ToString();
            //    label_SessionId.Text = session;
            //}

            //// Convertir a número
            //if (int.TryParse(pres, out int numPre))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Presentacion.Enabled = numPre <= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Presentacion.Enabled = true;
            //    TextBox_Presentacion.Equals("");
            //}
            //// Convertir a número
            //if (int.TryParse(sel, out int numSel))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Seleccion.Enabled = numSel <= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Seleccion.Enabled = true;
            //    TextBox_Seleccion.Equals("");
            //}// Convertir a número
            //if (int.TryParse(pes, out int numPes))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Pesado.Enabled = numPes <= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Pesado.Enabled = true;
            //    TextBox_Pesado.Text.Equals("");
            //}// Convertir a número
            //if (int.TryParse(emp, out int numEmp))
            //{
            //    // Si es mayor a 0 → bloquear
            //    TextBox_Empaque.Enabled = numEmp<= 0;
            //}
            //else
            //{
            //    // Si no es número, lo dejamos habilitado
            //    TextBox_Empaque.Enabled = true;
            //    TextBox_Empaque.Text.Equals("");
            //}
        }

        private async void comboBox_linea_SelectedValueChanged(object sender, EventArgs e)
        {
            await CargarDatosSyncFechaProceso();

            if (dtgCierre == null || dtgCierre.Rows.Count == 0)
                return;

            bool procesoCerrado = dtgCierre.AsEnumerable()
                .Any(row =>
                    row.Field<DateTime>("FechaProceso").Date == Fecha_Proceso.Value.Date &&
                    row.Field<bool>("Estatus"));

            if (procesoCerrado)
            {
                var msg = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = "⚠️ EL PROCESO YA HA CERRADO PARA ESTA FECHA",
                    Caption = "Proceso Cerrado",
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
                };

                msg.Show();
                Fecha_Proceso.Value = DateTime.Now;
                return;
            }


            CargarDatosSync();
            guna2TextBox_LecturaSticker.Focus();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string value = cell.Value?.ToString().Trim();

            // ✔ Permitir editar SI:
            //   - está vacío
            //   - es exactamente "0"
            if (value == "0")
            {
                e.Cancel = false; // permitir edición
            }
            else
            {
                e.Cancel = true; // ❌ bloquear edición
            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (txt != null)
            {
                txt.KeyPress -= Txt_KeyPress; // evitar múltiples suscripciones
                txt.KeyPress += Txt_KeyPress;
            }
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y teclas de control (borrar, flechas, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // bloquea la tecla
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener fila y columna editada
            int fila = e.RowIndex + 1; // sumar 1 para que no empiece en 0
            string nombreColumna = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            // Obtener el nuevo valor escrito
            string nuevoValor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            // --- Obtener valor de la columna SessionId ---
            string sessionId = dataGridView1.Rows[e.RowIndex].Cells["SessionId"].Value?.ToString();

            if (nombreColumna == "CodPre")
            {
                string MessageBoxTitle = "AGREGAR";
                string MessageBoxContent = "¿Desea agregar presentacion?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    cn_comercial.AgragarDestajoUva(nuevoValor,
                        "Presentacion", sessionId, "1");
                }
                CargarDatosSync();
            }

            if (nombreColumna == "SecuenciaSel")
            {
                string MessageBoxTitle = "AGREGAR";
                string MessageBoxContent = "¿Desea agregar seleccionador?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    cn_comercial.AgragarDestajoUva(nuevoValor,
                        "Seleccion", sessionId, "2");
                }
                CargarDatosSync();
            }

            if (nombreColumna == "SecuenciaPesa")
            {
                string MessageBoxTitle = "AGREGAR";
                string MessageBoxContent = "¿Desea agregar pesador?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    cn_comercial.AgragarDestajoUva(nuevoValor,
                        "Pesado", sessionId, "3");
                }
                CargarDatosSync();
            }

            if (nombreColumna == "SecuenciaEmp")
            {
                string MessageBoxTitle = "AGREGAR";
                string MessageBoxContent = "¿Desea agregar empaque?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    cn_comercial.AgragarDestajoUva(nuevoValor,
                        "Empaque", sessionId, "4");
                }
                CargarDatosSync();
            }
        }

        private async void Fecha_Proceso_ValueChanged(object sender, EventArgs e)
        {
            await CargarDatosSyncFechaProceso();

            if (dtgCierre == null || dtgCierre.Rows.Count == 0)
                return;

            bool procesoCerrado = dtgCierre.AsEnumerable()
                .Any(row =>
                    row.Field<DateTime>("FechaProceso").Date == Fecha_Proceso.Value.Date &&
                    row.Field<bool>("Estatus"));

            if (procesoCerrado)
            {
                var msg = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Text = "⚠️ EL PROCESO YA HA CERRADO PARA ESTA FECHA",
                    Caption = "Proceso Cerrado",
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
                };

                msg.Show();
                Fecha_Proceso.Value = DateTime.Now;
                return;
            }

            guna2TextBox_LecturaSticker.Focus();
        }



        private async Task CargarDatosSyncFechaProceso()
        {
            try
            {
                await Task.Run(() =>
                {
                    BuscarReporteDestajo();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }



        public void BuscarReporteDestajo()
        {
            var resultado = cn_planilla.ReporteCierreProcesoDia(
                                        Fecha_Proceso.Value.Date);

            dtgCierre = resultado;

            // Imprimir el contenido del DataTable en consola
            ImprimirDataTable(dtgCierre);
        }

        private void ImprimirDataTable(DataTable dt)
        {
            // Verificar que el DataTable no sea nulo ni vacío
            if (dt == null || dt.Rows.Count == 0)
            {
                Console.WriteLine("El DataTable está vacío o es nulo.");
                return;
            }

            // Imprimir nombres de las columnas
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();  // Salto de línea después de los nombres de columnas

            // Imprimir los datos de las filas
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item.ToString() + "\t");
                }
                Console.WriteLine();  // Salto de línea después de cada fila
            }
        }

        private void comboBox_nave_SelectedValueChanged(object sender, EventArgs e)
        {
            guna2TextBox_LecturaSticker.Focus();
        }

        private void pictureBox_agregarErrores_Click(object sender, EventArgs e)
        {

            if (comboBox_nave.Text.Trim() == "SELECCIONE")
            {
                MessageBox.Show("Por favor, seleccione nave");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }
            if (comboBox_linea.Text.Trim() == "SELECCIONE")
            {
                MessageBox.Show("Por favor, seleccione línea");
                guna2TextBox_LecturaSticker.Text = "";
                return;
            }
            else
            {
                ce_datosPedateo.Fecha = Fecha_Proceso.Value.Date.ToString("yyyy-MM-dd");
                ce_datosPedateo.Nave = comboBox_nave.Text;
                ce_datosPedateo.Linea = comboBox_linea.Text;

                frm_AgregarSticker frbm = new frm_AgregarSticker();
                AddOwnedForm(frbm);
                frbm.ShowDialog();
            }
        }
    }
}
