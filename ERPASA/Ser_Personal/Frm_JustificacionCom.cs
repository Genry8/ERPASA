using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_JustificacionCom : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        cu_excel objexcel = new cu_excel();


        public Frm_JustificacionCom()
        {
            InitializeComponent();
            //BuscarUsuarioPedateado();
            //dataGridView1.ClearSelection();
        }

        private void Frm_JustificacionCom_Load(object sender, EventArgs e)
        {

            //ALTO RIESGO
            comboBox_tipo.SelectedIndex = 0;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede_Comedor.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
            //textBox_ApeNom.Enabled = false;
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            //comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaAsignacionTI();
            //comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaSedeComedor();
            comboBox_CodSede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodSede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //    comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaSedeComedor();
            //    comboBox_CodSede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_CodSede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //}
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {
            if (comboBox_CodSede_Comedor.Text == "COMEDOR")
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE COMEDOR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    BuscarUsuarioPedateado();
                    dataGridView1.ClearSelection();
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
        }

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            objexcel.ExportarExcel(dataGridView1);
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            if (comboBox_CodSede_Comedor.Text != "COMEDOR")
            {
                cn_equipoti.BuscPaginaParaHoja(16, ce_usuario.Fecha_Entrega);
                ImprimirReporteMarcacion();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE COMEDOR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        public void ImprimirReporteMarcacion()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Comedor.DataSetComedor objDsRepVenta = new Reportes.Frm_Comedor.DataSetComedor();
            string fechaactual = currentDateTime.Date.Year + "-" + Convert.ToString(currentDateTime.Date.Month.ToString("D2")) + "-" + Convert.ToString(currentDateTime.Date.Day.ToString("D2"));
            string nombreH = ce_equipoti.NombreHoja;
            string TipoH = ce_equipoti.TipoHoja;
            string CodigoH = ce_equipoti.CodigoHoja;
            string VersionH = ce_equipoti.VersionHoja;
            DateTime FechaH = ce_equipoti.FechaHoja;
            int PaginaH = ce_equipoti.PaginaHoja;
            string EmpH = ce_equipoti.EmpresaHoja;
            string RucH = ce_equipoti.RucHoja;
            string DireccionH = ce_equipoti.DireccionHoja;
            string InspectoH = ce_equipoti.InspectorHoja;
            int DniInspectoH = ce_equipoti.DniInspectorHoja;

            DataTable dt = new DataTable();
            dt = objcuserneg.FotoUserFirma(Convert.ToString(DniInspectoH));
            byte[] FirmaH = (byte[])dt.Rows[0]["Foto"];

            objDsRepVenta.Tables[2].Rows.Add
                    (new object[]{
                    Convert.ToInt32(label_cant_desayuno.Text)+Convert.ToInt32(label_cant_almuerzo.Text)+Convert.ToInt32(label_cant_cena.Text),
                    label_cant_desayuno.Text,
                    label_cant_almuerzo.Text,
                    label_cant_cena.Text
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });

            objDsRepVenta.Tables[1].Rows.Add
            (new object[]{
                nombreH,
                TipoH,
                CodigoH,
                VersionH,
                FechaH.ToString("dd/MM/yyyy"),
                PaginaH,
                EmpH,
                RucH,
                DireccionH,
                InspectoH,
                FirmaH
            });

            int filas = dataGridView1.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[0].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//NUMERO
                    dataGridView1[1,i].Value.ToString(),//DNI
                    dataGridView1[2,i].Value.ToString(),//APENOM
                    dataGridView1[3,i].Value.ToString(),//AREA
                    dataGridView1[4,i].Value.ToString(),//TIP PER
                    dataGridView1[6,i].Value.ToString(),//DES
                    dataGridView1[7,i].Value.ToString(),//ALM
                    dataGridView1[8,i].Value.ToString(),//CENA
                    fechaactual,
                    //AQUI VA EMPRESA PERO SON DE DIFERENTES EMPRESAS
                    comboBox_CodSede_Comedor.Text,
                    dataGridView1[5,i].Value.ToString()//EMPRESA
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_Comedor.CryRep_ComedorCocina objCryRep = new Reportes.Frm_Comedor.CryRep_ComedorCocina();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRep_Comedor.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DateTime currentDateTime = DateTime.Now.Date;

                var cnexiste = cn_logistica.BuscExistePersonalComedor(textBox_Dni.Text.Trim(), comboBox_tipo.Text, comboBox_CodSede_Comedor.Text, dateTimePicker_Comedor_F_Justif.Value.Date);
                //cn_logistica.BuscExistePersonalComedor(textBox_Dni.Text);
                //MessageBox.Show("User "+ ce_logistica.NombresUsuario);
                if (comboBox_tipo.Text != "TODOS")
                {
                    if (comboBox_CodSede_Comedor.Text != "COMEDOR")
                    {
                        if (textBox_Dni.Text == "")
                        {
                            textBox_Dni.Text = "";
                        }
                        else
                        {
                            if (cnexiste == true) //textBox_Dni.Text == ce_logistica.CodUsuarioExist
                            {
                                //textBox_ApeNom.Text = ce_logistica.NombresUsuario;

                                if (comboBox_CodSede_Comedor.Text == ce_comedor.SedeComedor)
                                {
                                    label_nombre_usuario.Text = ce_comedor.ApeNom;
                                    GuardarUsuarioPedateado();
                                    ce_comedor.Dni = "";
                                    ce_comedor.ApeNom = "";
                                    ce_comedor.TipoPersonal = "";
                                    ce_comedor.Area = "";
                                    ce_comedor.Empresa = "";
                                    ce_comedor.SedeComedor = "";
                                    ce_comedor.TipoHoja = "";
                                    ce_comedor.TipoAlimentoProg = "";
                                    ce_comedor.TipoAlimentoMarcado = "";
                                    ce_comedor.TipoPersonalMarcado = "";
                                }
                                else
                                {
                                    string tipo = "EL USUARIO PERTENECE A " + ce_comedor.SedeComedor;
                                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro(tipo, Color.FromArgb(238, 24, 24), 3);
                                    ng.ShowDialog();
                                    textBox_Dni.Text = "";
                                    ce_comedor.Dni = "";
                                    ce_comedor.ApeNom = "";
                                    ce_comedor.TipoPersonal = "";
                                    ce_comedor.Area = "";
                                    ce_comedor.Empresa = "";
                                    ce_comedor.SedeComedor = "";
                                    ce_comedor.TipoHoja = "";
                                    ce_comedor.TipoAlimentoProg = "";
                                    ce_comedor.TipoAlimentoMarcado = "";
                                    ce_comedor.TipoPersonalMarcado = "";
                                }
                                //ce_logistica.FechaIngreso

                            }
                            else
                            {
                                label_nombre_usuario.Text = "";
                                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("USUARIO NO PROGRAMADO", Color.FromArgb(238, 24, 24), 3);
                                ng.ShowDialog();
                                textBox_Dni.Text = "";
                            }
                        }
                    }
                    else
                    {
                        Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE COMEDOR", Color.FromArgb(238, 24, 24), 3);
                        ng.ShowDialog();
                    }
                }
                else
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE TIPO DE ALIMENTO", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();

                }
            }

            else if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        public void GuardarUsuarioPedateado()
        {
            //DateTime currentDateTime = DateTime.Now.Date;

            //cn_logistica.BuscExistePedateoPersonalComedor(textBox_Dni.Text, dateTimePicker_Comedor_F_Justif.Value.Date, comboBox_tipo.Text);
            if (comboBox_tipo.Text == ce_comedor.TipoAlimentoMarcado)
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("EL USUARIO YA MARCO: " + ce_comedor.TipoAlimentoMarcado, Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
                textBox_Dni.Text = "";

            }
            else
            {
                //cn_logistica.BuscExistePedateoPersonalComedorAlimento(textBox_Dni.Text, dateTimePicker_Comedor_F_Justif.Value.Date, comboBox_tipo.Text);
                //if (textBox_Dni.Text == ce_logistica.CodPedateoExistAlimento & comboBox_tipo.Text == ce_logistica.CodPedateoTipoAlimentoExist)
                //{
                objcnlog.GuardarPedateoPersonalComedor(
                            textBox_Dni.Text,//DNI
                            ce_comedor.ApeNom,//APELLIDOS Y NOMBRES
                            ce_comedor.FechaProgramado,//FECHA
                            ce_comedor.TipoAlimentoProg, // TIPO ALIMENTO
                            ce_comedor.TipoHoja,//TIPO HOJA
                            ce_comedor.TipoPersonal,//TIPO PERSONAL
                            ce_usuario.FechaSistema(),
                            ce_comedor.Empresa,
                            ce_comedor.SedeComedor,
                            ce_comedor.Area,
                            ce_comedor.PrecioAlimento,//PRECIO
                            "JUSTIFICADO",//OBS
                            "S",
                            ce_usuario.FechaSistema(),
                            ce_usuario.usecod,
                            ce_usuario.HostName(),
                            ce_usuario.FechaSistema(),
                            0,
                            0
                            );

                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("JUSTIFICADO", Color.FromArgb(0, 179, 78), 2);
                ng.Show();


                textBox_Dni.Text = "";
                BuscarUsuarioPedateado();
                //}
                //else
                //{
                //    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("USUARIO NO PROGRAMADO PARA: " + comboBox_tipo.Text, Color.FromArgb(238, 24, 24), 3);
                //    ng.ShowDialog();
                //    textBox_Dni.Text = "";
                //}
            }


        }


        public void BuscarUsuarioPedateado()
        {
            //DateTime currentDateTime = DateTime.Now.Date;

            if (textBox_Dni.Text == "")
            {
                textBox_Dni.Text = "%";
            }
            else
            {
                textBox_Dni.Text = textBox_Dni.Text;
            }
            if (comboBox_tipo.Text == "TODOS")
            {
                comboBox_tipo.Text = "%";
            }
            else
            {
                comboBox_tipo.Text = comboBox_tipo.Text;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_logistica.BuscarPedateoPersonalComedorJustificado(
                textBox_Dni.Text, "%", dateTimePicker_Comedor_F_Justif.Value.Date, comboBox_CodSede_Comedor.Text);
            dataGridView1.AllowUserToAddRows = false;
            SumarTotal();
            OrigenColorfila();
            dataGridView1.ClearSelection();

            //CONTAR LA CANTIDAD DE REGISTROS

            if (dataGridView1.Rows.Count > 0)
            {
                label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
                //CapaPresentacion.Msbox.Frm_NotificacionesGuardar ng = new CapaPresentacion.Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(3, 151, 43), 2);
                //ng.Show();
            }
            else
            {
                label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";
                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                ng.Show();
            }
            /////////////////////////////
            textBox_Dni.Text = "";
        }


        //
        public void OrigenColorfila()
        {
            int c = dataGridView1.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "ANULADO")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(252, 70, 0); //DarkRed
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Calibri", 10f, FontStyle.Bold); //DarkRed
                    //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                    
                }
            }
        }


        public void SumarTotal()
        {
            int desayuno = 0;
            int almuerzo = 0;
            int cena = 0;
            //decimal otros = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //int c = dataGridView2.Rows.Count;
                //for (int i = 0; i < c; i++)
                //{
                if (item.Cells["DESAYUNO"].Value.ToString().Contains("SI"))
                {
                    desayuno = desayuno + 1;
                }
                if (item.Cells["ALMUERZO"].Value.ToString().Contains("SI"))
                {
                    almuerzo = almuerzo + 1;
                }
                if (item.Cells["CENA"].Value.ToString().Contains("SI"))
                {
                    cena = cena + 1;
                }
            }
            label_cant_desayuno.Text = desayuno.ToString();//"S/. " + Anulado.ToString("0,0.00");
            label_cant_almuerzo.Text = almuerzo.ToString();//"S/. " + NoAnulado.ToString("0,0.00");
            label_cant_cena.Text = cena.ToString();//"S/. " + total.ToString("0,0.00");
            //textBox_igv.Text = igv.ToString();
            //textBox_subtotal.Text = subtotal.ToString();
        }


        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {

        }
    }
}
