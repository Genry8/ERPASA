using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPASA.Reportes.Acopio
{
    public partial class Frm_SaveOrdenProduccion : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        cu_excel objexcel = new cu_excel();
        cn_packing objcnpack = new cn_packing();

        string TipoAlimento;

        Frm_Menu frm_Menu;

        public Frm_SaveOrdenProduccion()
        {
            InitializeComponent();
        }

        private void Frm_SaveOrdenProduccion_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //MAYUSCULA
            PonerOscuroComboBox();
            CargarDatosComboBox();
            //textBox_Dni.Focus();
        }


        public void PonerOscuroComboBox()
        {
            //DETALLE DE REPORTE
            comboBox_detalle_empresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_detalle_sede.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox_TipoMerma.DropDownStyle = ComboBoxStyle.DropDownList;
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



        public void BuscarReporteOrdenProduccion()
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
            dataGridView2.DataSource = cn_sst.ListaReporteOrdProd(dateTimePicker_FecInicio.Value.Date
                , dateTimePicker_FecFin.Value.Date, emp
                , sed);

            dataGridView2.AllowUserToAddRows = false;
            OrigenColorfila();
            dataGridView2.ClearSelection();

            //}
            //else
            //{

            //}

        }


        private void toolStripButton_buscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BuscarReporteOrdenProduccion();
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
            if (dataGridView2.Rows.Count > 0)
            {
                cn_equipoti.BuscPaginaParaHoja(18, dateTimePicker_FecFin.Value.Date);
                if (comboBox_detalle_empresa.Text == "SELECCIONE")
                {
                    Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("SELECCIONE EMPRESA", Color.FromArgb(238, 24, 24), 3);
                    ng.ShowDialog();
                }
                else if (comboBox_detalle_empresa.Text == "AGRICOLA SANTA AZUL S.R.L")
                {
                    cn_equipoti.BuscPaginaParaHoja(20, dateTimePicker_FecInicio.Value.Date);
                    ImprimirReporteDetalleAtencionASA();
                }
                else if (comboBox_detalle_empresa.Text == "AGRICOLA INTERANDINA S.A.C")
                {
                    cn_equipoti.BuscPaginaParaHoja(21, dateTimePicker_FecInicio.Value.Date);
                    ImprimirReporteDetalleAtencionIA();
                }
            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("NO HAY REGISTROS PARA IMPRIMIR", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }
        }


        public void ImprimirReporteDetalleAtencionASA()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Topico.DataSetTopico objDsRepVenta = new Reportes.Frm_Topico.DataSetTopico();

            string fechainicio = dateTimePicker_FecInicio.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_FecInicio.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_FecInicio.Value.Date.Day.ToString("D2"));
            string fechafin = dateTimePicker_FecFin.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_FecFin.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_FecFin.Value.Date.Day.ToString("D2"));
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

            objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    0,
                    0,
                    0,
                    0
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });

            objDsRepVenta.Tables[0].Rows.Add
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

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[2].Rows.Add
                    (new object[]{
                    "1",//N°
                    Convert.ToString( Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Year + "-" + Convert.ToString(Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Month.ToString("D2")) + "-" + Convert.ToString(Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Day.ToString("D2")) ),
                    //dataGridView1[1,i].Value.ToString(),//FECHA
                    dataGridView2[1,i].Value.ToString(),//QUINCENA
                    dataGridView2[2,i].Value.ToString(),//MES
                    dataGridView2[3,i].Value.ToString(),//DNI
                    dataGridView2[4,i].Value.ToString(),//APE NOM
                    dataGridView2[5,i].Value.ToString(),//AREA
                    dataGridView2[6,i].Value.ToString(),//JEFE AREA
                    dataGridView2[7,i].Value.ToString(),//PATOLOGIA
                    dataGridView2[8,i].Value.ToString(),//DIAGNOSTICO
                    dataGridView2[10,i].Value.ToString(),//TRATAMIENTO
                    dataGridView2[11,i].Value.ToString(),//CANTIDAD
                    dataGridView2[12,i].Value.ToString(),//ACCION REALIZADA
                    dataGridView2[13,i].Value.ToString(),//HR_ENTRADA
                    dataGridView2[14,i].Value.ToString(),//HR_SALIDA
                    comboBox_detalle_empresa.Text,
                    comboBox_detalle_sede.Text,
                    fechainicio,
                    fechafin,
                    dataGridView2[9,i].Value.ToString()//SINTOMAS
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_Topico.CrystalReport_AtenMed_ASA objCryRep = new Reportes.Frm_Topico.CrystalReport_AtenMed_ASA();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReport_AtenMed_ASA.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }


        public void ImprimirReporteDetalleAtencionIA()
        {
            DateTime currentDateTime = DateTime.Now.Date;

            Reportes.Frm_CrpVetaUsuario objImpresion = new Reportes.Frm_CrpVetaUsuario();
            AddOwnedForm(objImpresion);
            objImpresion.Show();

            Reportes.Frm_Topico.DataSetTopico objDsRepVenta = new Reportes.Frm_Topico.DataSetTopico();

            string fechainicio = dateTimePicker_FecInicio.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_FecInicio.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_FecInicio.Value.Date.Day.ToString("D2"));
            string fechafin = dateTimePicker_FecFin.Value.Date.Year + "-" + Convert.ToString(dateTimePicker_FecFin.Value.Date.Month.ToString("D2")) + "-" + Convert.ToString(dateTimePicker_FecFin.Value.Date.Day.ToString("D2"));
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

            objDsRepVenta.Tables[1].Rows.Add
                    (new object[]{
                    0,
                    0,
                    0,
                    0
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });

            objDsRepVenta.Tables[0].Rows.Add
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

            int filas = dataGridView2.Rows.Count;
            for (int i = 0; i <= filas - 1; i++)
            {
                objDsRepVenta.Tables[2].Rows.Add
                    (new object[]{
                    "1",//N°
                    Convert.ToString( Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Year + "-" + Convert.ToString(Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Month.ToString("D2")) + "-" + Convert.ToString(Convert.ToDateTime(dataGridView2[0,i].Value.ToString()).Day.ToString("D2")) ),
                    //dataGridView1[1,i].Value.ToString(),//FECHA
                    dataGridView2[1,i].Value.ToString(),//QUINCENA
                    dataGridView2[2,i].Value.ToString(),//MES
                    dataGridView2[3,i].Value.ToString(),//DNI
                    dataGridView2[4,i].Value.ToString(),//APE NOM
                    dataGridView2[5,i].Value.ToString(),//AREA
                    dataGridView2[6,i].Value.ToString(),//JEFE AREA
                    dataGridView2[7,i].Value.ToString(),//PATOLOGIA
                    dataGridView2[8,i].Value.ToString(),//DIAGNOSTICO
                    dataGridView2[10,i].Value.ToString(),//TRATAMIENTO
                    dataGridView2[11,i].Value.ToString(),//CANTIDAD
                    dataGridView2[12,i].Value.ToString(),//ACCION REALIZADA
                    dataGridView2[13,i].Value.ToString(),//HR_ENTRADA
                    dataGridView2[14,i].Value.ToString(),//HR_SALIDA
                    comboBox_detalle_empresa.Text,
                    comboBox_detalle_sede.Text,
                    fechainicio,
                    fechafin,
                    dataGridView2[9,i].Value.ToString()//SINTOMAS
                    //(byte[])dataGridView2[36,i].Value //Foto
                    });
            }

            Reportes.Frm_Topico.CrystalReport_AtenMed_IA objCryRep = new Reportes.Frm_Topico.CrystalReport_AtenMed_IA();
            //string dir = @"~\CryRep_VentasUsuario.rpt";
            objCryRep.Load(@"~\CrystalReport_AtenMed_IA.rpt");
            objCryRep.SetDataSource(objDsRepVenta);
            objImpresion.crystalReportViewer1.ReportSource = objCryRep;

        }

        private void toolStripButton_nuevo_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<Reportes.Acopio.frm_AgregarMerma>();

            frm_AgregarOrdenProduccion frbm = new frm_AgregarOrdenProduccion();
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
            //frm_EditarMerma frbm = new frm_EditarMerma();
            //AddOwnedForm(frbm);
            //frbm.ShowDialog();
            BuscarRegistroParaEditar();

        }

        public void BuscarRegistroParaEditar()
        {
            if (dataGridView2.CurrentRow.Cells["Estado"].Value.ToString() == "ACTIVO")
            {

                frm_EditarOrdenPoduccion obj = new frm_EditarOrdenPoduccion();
                obj.PonerOscuroComboBox();
                obj.CargarDatosComboBox();
                obj.label_Id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //obj.comboBox_detalle_empresa.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                //obj.comboBox_detalle_sede.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                //obj.comboBox_Cultivo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                //obj.comboBox_Campana.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();

                obj.textBox_NumCont.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                obj.textBox_Prioridad.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                obj.textBox_Orden.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                obj.textBox_Cliente.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                obj.textBox_Destino.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                obj.textBox_Presentacion.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                obj.textBox_Calibre.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                obj.textBox_Cajas.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                obj.textBox_Pallets.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();

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

                objcnpack.EliminarOrdenPRD(
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
                    BuscarReporteOrdenProduccion();
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



    }
}
