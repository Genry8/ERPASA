using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Comedor
{
    public partial class Frm_ReporteJustificacion : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_logistica objcnlog = new cn_logistica();
        cn_sst objcnsst = new cn_sst();
        cu_excel objexcel = new cu_excel();
        cu_excel_progress objexcel_progress = new cu_excel_progress();


        public Frm_ReporteJustificacion()
        {
            InitializeComponent();
            //BuscarUsuarioPedateado();
            //dataGridView1.ClearSelection();
        }

        private void Frm_ReporteJustificacion_Load(object sender, EventArgs e)
        {

            //ALTO RIESGO
            comboBox_Adicional.SelectedIndex = 0;
            comboBox_area.SelectedIndex = 0;
            comboBox_tipo.SelectedIndex = 0;
            comboBox_TipoPersonal.SelectedIndex = 0;

            Cargar_Empresa();
            PonerOscuroComboBox();
        }


        public void PonerOscuroComboBox()
        {
            //ALTO RIESGO
            comboBox_Adicional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_area.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TipoPersonal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_CodSede_Comedor.DropDownStyle = ComboBoxStyle.DropDownList;
            //LICENCIA
        }

        public void Cargar_Empresa()
        {
            //CARGAR EMPRESA
            comboBox_empresa.DataSource = cn_logistica.ListaCBEmpresaComedor();
            comboBox_empresa.DisplayMember = "DesEmp"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_empresa.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            //CARGAR AREA
            comboBox_area.DataSource = cn_logistica.ListaCBAreaComedor();
            comboBox_area.DisplayMember = "Area"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_area.ValueMember = "id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR

            comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaSedeComedor();
            comboBox_CodSede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            comboBox_CodSede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
        }

        private void comboBox_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_empresa.Text == comboBox_empresa.Text)
            //{
            //    comboBox_CodSede_Comedor.DataSource = cn_logistica.ListaSedeComedorEmpresa(
            //        comboBox_empresa.Text, comboBox_TipoPersonal.Text);
            //    comboBox_CodSede_Comedor.DisplayMember = "Comedor"; //NOMBRE DE LA TABLA O NOMBRE DE COLUMNA ID
            //    comboBox_CodSede_Comedor.ValueMember = "Id"; // NOMBRE DE LA COLUMNA o PARA ORDENAR
            //}
        }

        private void toolStripButton_buscar_Click(object sender, EventArgs e)
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

        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            progressBar1.Visible = true;
            label_exportar_excel.Visible = true;

            dataGridView1.AllowUserToAddRows = false;
            objexcel_progress.exportarexcelTimer(dataGridView1, progressBar1);
            progressBar1.Visible = false;
            label_exportar_excel.Visible = false;

            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    dataGridView1.AllowUserToAddRows = false;
            //    objexcel.ExportarExcel(dataGridView1);
            //}

            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}
        }

        private void toolStripButton_imprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cn_equipoti.BuscPaginaParaHoja(16, ce_usuario.Fecha_Entrega);
                ImprimirReporteComedor();
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA IMPRIMIR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
            //if (comboBox_CodSede_Comedor.Text != "COMEDOR")
            //{
            //    cn_equipoti.BuscPaginaParaHoja(16);
            //    ImprimirReporteComedor();
            //}
            //else
            //{
            //    CapaPresentacion.Msbox.Frm_NotificacionesPeligro ng = new CapaPresentacion.Msbox.Frm_NotificacionesPeligro("SELECCIONE SEDE COMEDOR", Color.FromArgb(238, 24, 24), 3);
            //    ng.ShowDialog();
            //}
        }


        public void ImprimirReporteComedor()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Comedor.DataSetComedor objDsRepVenta = new Reportes.Frm_Comedor.DataSetComedor();
            string fechainicio = dateTimePicker_Comedor_F_Inicio.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_Comedor_F_Inicio.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_Comedor_F_Inicio.Value.Date.Day.ToString("D2"));
            string fechafin = dateTimePicker_Fecha_Final.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_Fecha_Final.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_Fecha_Final.Value.Date.Day.ToString("D2"));
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
                objDsRepVenta.Tables[3].Rows.Add
                    (new object[]{
                    dataGridView1[0,i].Value.ToString(),//NRO
                    dataGridView1[1,i].Value.ToString(),//DNI, DESPUES DE DNI SIGUE FECHA
                    //dataGridView1[2,i].Value.ToString(),//FECHA
                    Convert.ToString( Convert.ToDateTime(dataGridView1[2,i].Value.ToString()).Year + "-" + Convert.ToString(Convert.ToDateTime(dataGridView1[2,i].Value.ToString()).Month.ToString("D2")) + "-" + Convert.ToString(Convert.ToDateTime(dataGridView1[2,i].Value.ToString()).Day.ToString("D2")) ),
                    dataGridView1[3,i].Value.ToString(),//APE NOM
                    dataGridView1[4,i].Value.ToString(),//AREA
                    dataGridView1[5,i].Value.ToString(),//EMPRESA
                    dataGridView1[6,i].Value.ToString(),//TIP PERSONAL
                    dataGridView1[7,i].Value.ToString(),//ADICIONAL
                    dataGridView1[8,i].Value.ToString(),//DESAYUNO
                    dataGridView1[9,i].Value.ToString(),//ALM
                    dataGridView1[10,i].Value.ToString(),//CENA
                    comboBox_CodSede_Comedor.Text,
                    fechainicio,
                    fechafin
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_Comedor.CryRep_Com_MarcProg objCryRep = new Reportes.Frm_Comedor.CryRep_Com_MarcProg();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CryRep_Com_MarcProg.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        private void textBox_Dni_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BuscarUsuarioPedateado();
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



        public void BuscarUsuarioPedateado()
        {
            String dni, adicional, tipo, tipopersonal, emp, area, sede;

            if (textBox_Dni.Text == "")
            {
                dni = "%";
            }
            else
            {
                dni = textBox_Dni.Text;
            }
            if (comboBox_Adicional.Text == "TODOS")
            {
                adicional = "%";
            }
            else
            {
                adicional = comboBox_Adicional.Text;
            }
            if (comboBox_tipo.Text == "TODOS")
            {
                tipo = "%";
            }
            else
            {
                tipo = comboBox_tipo.Text;
            }
            if (comboBox_TipoPersonal.Text == "TODOS")
            {
                tipopersonal = "%";
            }
            else
            {
                tipopersonal = comboBox_TipoPersonal.Text;
            }
            if (comboBox_empresa.Text == "SELECCIONE")
            {
                emp = "%";
            }
            else
            {
                emp = comboBox_empresa.Text;
            }
            if (comboBox_area.Text == "SELECCIONE")
            {
                area = "%";
            }
            else
            {
                area = comboBox_area.Text;
            }
            if (comboBox_CodSede_Comedor.Text == "COMEDOR")
            {
                sede = "%";
            }
            else
            {
                sede = comboBox_CodSede_Comedor.Text;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cn_logistica.BuscarPedateoPersonalComedorReporteJustificacion(
            dateTimePicker_Comedor_F_Inicio.Value.Date, dateTimePicker_Fecha_Final.Value.Date, adicional
            , tipo, tipopersonal, emp, area, sede, dni);
            dataGridView1.AllowUserToAddRows = false;
            SumarTotal();
            OrigenColorfila();
            dataGridView1.ClearSelection();

            //CONTAR LA CANTIDAD DE REGISTROS
            if (dataGridView1.Rows.Count > 0)
            {
                label_cantreg.Text = (dataGridView1.RowCount).ToString() + " REGISTROS";

                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE ENCONTRADO", Color.FromArgb(0, 179, 78), 2);
                ng.Show();
            }
            else
            {
                Msbox.Frm_NotificacionesGuardar ng = new Msbox.Frm_NotificacionesGuardar("REPORTE NO ENCONTRADO", Color.FromArgb(238, 24, 24), 3);
                ng.Show();
            }

            /////////////////////////////
            //textBox_Dni.Text = "";
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

        private void comboBox_TipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Empresa();
        }
    }
}
