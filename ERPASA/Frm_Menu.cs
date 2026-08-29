using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using ERPASA.Reportes.Acopio;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA
{
    public partial class Frm_Menu : Form
    {
        cd_rolesuser datos = new cd_rolesuser();
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            string password = ce_usuario.usepas;

            // Validación de longitud, mayúsculas, números y caracteres especiales
            bool isValidLength = password.Length >= 8;
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            // Si la contraseña no cumple con uno o más requisitos, mostrar alerta
            if (!(isValidLength && hasUpperCase && hasDigit && hasSpecialChar))
            {
                MessageBox.Show(
                    "POR SEGURIDAD CAMBIE SU CONTRASEÑA EN LA OPCIÓN MAESTROS",
                    "⚠️ ALERTA DE SEGURIDAD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Frm_TabMaestra.Usuario.CambiarContrasena frbm =
                new Frm_TabMaestra.Usuario.CambiarContrasena();
                AddOwnedForm(frbm);
                frbm.ShowDialog();

                Application.Exit();

            }


            menuStrip1.Renderer = new CustomRenderer();
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
            menuStrip1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            //
            //textBox_bienvenida.Text = "BIENVENIDO :  " + ce_usuario.usenam;
            label_Bienvenido.Text = "BIENVENIDO :  " + ce_usuario.usenam;
            //textBox_hostname.Text = ce_usuario.HostName().ToString();
            label_hostname.Text = ce_usuario.HostName().ToString();
            //textBox_ip.Text = ce_usuario.IpMostrar().ToString();
            label_ip.Text = ce_usuario.IpMostrar().ToString();
            //textBox_version.Text = ce_usuario.version_actual;
            label_version.Text = ce_usuario.version_actual;
            //textBox_fechasistema.Text = DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToLongTimeString();
            //label_fechasistema.Text = DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToLongTimeString();
            //textBox_sede.Text = "EMPRESA :  " + ce_usuario.sede_user;
            label_sede.Text = "EMPRESA :  " + ce_usuario.sede_user;
            //

            FormBorderStyle = FormBorderStyle.Sizable;
            ShowInTaskbar = true;

            //BUSCAR EL ROL DE USUARIO 
            cn_rolesuser.BuscExisteUsuarioRol(ce_usuario.usecod);

            //PERFILES DE LOGIN
            //ConsultarRol(button_Inicio);
            ConsultarRol(button_RRHH);
            ConsultarRol(button_sistema);
            ConsultarRol(button_taller); //4
            ConsultarRol(button_almacen);
            ConsultarRol(button_comercial);
            ConsultarRol(button_serpersonal);
            ConsultarRol(button_administracion);
            ConsultarRol(button_packing);
            ConsultarRol(button_tablas_maestras);//10

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(45, 66, 90);//Border color

        }

        public class CustomRenderer : ToolStripProfessionalRenderer
        {
            public CustomRenderer() : base(new LightColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.TextColor = Color.White;
                }
                else
                {
                    e.TextColor = e.Item.ForeColor;
                }

                base.OnRenderItemText(e);
            }
        }


        public class LightColorTable : ProfessionalColorTable
        {
            private Color _activeBackground = Color.FromArgb(50, 123, 153); // Azul deseado

            public override Color MenuItemSelected => _activeBackground;
            public override Color MenuItemBorder => Color.LightGray;
            public override Color MenuItemSelectedGradientBegin => _activeBackground;
            public override Color MenuItemSelectedGradientEnd => _activeBackground;
            public override Color MenuItemPressedGradientBegin => _activeBackground;
            public override Color MenuItemPressedGradientEnd => _activeBackground;

            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            label_fechasistema.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            label_Fecha_Centro.Text = DateTime.Now.ToShortDateString();
            label_Hora_Centro.Text = DateTime.Now.ToLongTimeString();

        }


        private void ConsultarRol(ToolStripMenuItem pTool)
        {
            //var extroluser = cn_rolesuser.BuscExistePermisoRol(ce_rolesuser.IdRolUsuario);
            var extroluser = datos.BuscExistePermiso(ce_rolesuser.IdRolUsuario);

            foreach (ToolStripMenuItem tool in pTool.DropDownItems)
            {
                foreach (var opc in extroluser)
                {
                    if (opc.IdSubMenu == Convert.ToInt32(tool.Tag))
                    {
                        if (!opc.Activo)
                            tool.Enabled = false;
                    }
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Ipram);

        private int borderSize = 0;



        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(0, 0, 0, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }


        public void AbrirFormularioHijo<MiForm>() where MiForm : Form, new()
        {
            Form fh;
            fh = panel_contenedor.Controls.OfType<MiForm>().FirstOrDefault(); //busca en la colección del formulario

            //si el formulario no existe
            if (fh == null)
            {

                fh = new MiForm();
                fh.TopLevel = false;
                //fh.Dock = DockStyle.Fill;            
                this.panel_contenedor.Controls.Add(fh);
                this.panel_contenedor.Tag = fh;
                fh.Show();
                fh.BringToFront();

            }
            else
            {
                fh.BringToFront();
            }
        }

        Panel p = new Panel();

        private void btnMouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            panel_titulo2.Controls.Add(p);
            p.BackColor = Color.FromArgb(90, 210, 2);
            p.Size = new Size(110, 3);
            p.Location = new
                Point(btn.Location.X, btn.Location.Y + 0);
        }

        private void btnMouseLeave(object sender, EventArgs e)
        {
            panel_titulo2.Controls.Remove(p);

        }

        private void Frm_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_minimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void button_min_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Normal;
            }
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel_titulo2_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);

            }
            else
                WindowState = FormWindowState.Maximized;
        }

        private void Frm_Menu_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void button_Inicio_Click(object sender, EventArgs e)
        {

        }

        private void button_RRHH_Click(object sender, EventArgs e)
        {

        }

        private void button_sistema_Click(object sender, EventArgs e)
        {

        }

        private void button_comedor_Click(object sender, EventArgs e)
        {

        }

        private void button_roles_Click(object sender, EventArgs e)
        {

        }

        private void button_tablas_maestras_Click(object sender, EventArgs e)
        {

        }

        private void button_comedor_regis_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_RegistrarCom>();
        }

        private void button_comedor_regis_pedido_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_RegistrarPedido>();
        }

        private void button_comedor_transporte_fac_viaje_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_Registrar_FacViaje>();
        }

        private void button_comedor_transporte_listavehiculo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarListaVehiculos>();
        }

        private void button_comedor_transporte_listaconductores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarListaConductores>();
        }
        private void button_comedor_transporte_imprimirQRplaca_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Frm_Comedor.Frm_ImprimirQRVehiculo>();
        }

        private void button_comedor_marca_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_MarcarCom>();
        }

        private void button_comedor_marca_justificacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_JustificacionCom>();
        }

        private void button_comedor_reporte_marcado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReporteCom>();
        }

        private void button_comedor_reporte_programado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReporteProg>();
        }

        private void button_comedor_reporte_inasistencia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReporteInasistencia>();
        }

        private void button_comedor_reporte_resumen_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReporteResumenCom>();
        }


        private void button_comedor_reporte_resumen_pedido_compra_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReporteResumenPedProgCom>();
        }

        private void button_comedor_reporte_justificados_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReporteJustificacion>();
        }

        private void button_comedor_reporte_fotosheck_campamento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Frm_Comedor.Frm_FotosheckCampamento>();
        }

        private void button_comedor_reporte_SubirFoto_campamento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Frm_Comedor.Frm_CargarFoto>();
        }

        private void button_comedor_reporte_Pedidos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comedor.Frm_ReportePedido>();
        }
        private void button_comedor_reporte_IngSalBuses_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_ReporteIngresoSalidaBuses>();
        }

        private void button_comedor_reporte_IngSalBusesDet_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_ReporteDetalleIngresoSalidaBuses>();
        }


        private void button_comedor_reporte_InspBuses_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_ReporteinspeccionBuses>();
        }

        /// <summary>
        /// ROLES USUARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabMaest_RolesUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RolesUser>();
        }

        private void TabMaest_PowerBI_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RolesBI>();
        }

        private void TabMaest_VersionAPP_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Roles.frm_versionAPP>();
        }
        private void TabMaest_EmpEmp_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegEmpresa>();
        }

        private void TabMaest_EmpSed_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegSede>();
        }

        private void TabMaest_EmpGerencia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegGerencia>();
        }

        private void TabMaest_EmpArea_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegaArea>();
        }

        private void TabMaest_CompTipo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegTipoActivo>();
        }

        private void TabMaest_CompMarca_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegMarca>();
        }

        private void TabMaest_CompModelo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegModelo>();
        }

        private void TabMaest_CompMemoria_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegMemoria>();
        }

        private void TabMaest_CompSistOpe_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegSisOperativo>();
        }

        private void TabMaest_CompProcesador_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegProcesador>();
        }

        private void TabMaest_CompDiscoDuro_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegDiscoDuro>();
        }

        private void TabMaest_CompOrigen_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegOrigenActivo>();
        }

        private void TabMaest_CompEstado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegEstadoActivo>();
        }

        private void TabMaest_CompPlan_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegPlanMovil>();
        }

        private void TabMaest_CompProveedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegProveedor>();
        }

        private void button_tablas_maestras_cambiarcontraseña_Click(object sender, EventArgs e)
        {
            Frm_TabMaestra.Usuario.CambiarContrasena frbm =
                new Frm_TabMaestra.Usuario.CambiarContrasena();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
            //AbrirFormularioHijo<Frm_TabMaestra.Usuario.CambiarContrasena>();
        }

        private void TabMaest_UserReg_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.frm_Registrar_usuario>();
        }

        private void TabMaest_UserAPP_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_TabMaestra.Frm_RegistroPersonal>();
        }

        private void Sistema_ActivoAsig_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Sistema.Frm_RegAsignacion>();
        }

        private void Sistema_ActivoActivo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Sistema.Frm_RegActivo>();
        }

        private void Sistema_ActivoPeriferico_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Sistema.Frm_RegPeriferico>();
        }

        private void Sistema_ActivoReporte_Click(object sender, EventArgs e)
        {

        }


        private void button_sistema_contratos_proveedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Sistema.Frm_Cargar_Contrato>();
        }
        private void button_sistema_reporte_printcamara_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Sistema.Frm_ImprimirUbicacionAcopio>();
        }

        private void button_taller_mantenimiento_preventivo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_MantenimientoPreventivo>();
        }

        private void button_taller_mantenimiento_correctivo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_MantenimientoCorrectivo>();
        }
        private void button_taller_mantenimiento_insumos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.frm_AgregarInsumo>();
        }
        private void button_taller_maquinaria_eficiencia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_EficienciaMaquinaria>();
        }
        private void button_taller_tablas_generales_vehiculos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_RegistrarVehiculos>();
        }

        private void button_taller_tablas_generales_GrupoVehiculo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_RegistrarGrupoVehiculo>();
        }

        private void button_taller_tablas_generales_MarcaVehiculo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_RegistrarMarcaVehiculo>();
        }

        private void button_taller_tablas_generales_ModeloVehiculo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_RegistrarModeloVehiculo>();
        }
        private void button_taller_reportes_OrdenTrabajo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_ReporteOrdenTrabajo>();
        }

        private void button_taller_reportes_PorxMantPrev_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_ProximosMantPreventivo>();

        }

        private void button_taller_reportes_KilometrajeGrif_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Taller.Frm_ReporteKilometraje>();
        }

        //ALMACEN
        private void button_almacen_cargarBI_EvInventario_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Almacen.Frm_Registrar_EvInventario>();
        }

        private void button_almacen_reporte_abastecimiento_grifo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Almacen.Frm_ReporteAbastecimiento>();
        }

        private void button_almacen_reporte_abastecimiento_grifo_corte_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Almacen.Frm_ReporteAbastecimiento_Corte>();
        }

        //
        /// <summary>
        /// CONTABILIDAD
        /// </summary>


        private void button_comercial_comercial_cargamasivaliquidacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comercial.Frm_CargarLiquidacion>();
        }

        private void button_comercial_comercial_reporteliquidacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comercial.Frm_ReporteLiquidacion>();
        }

        private void button_comercial_comercial_regpesopresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comercial.Frm_RegistrarPesoPresentacion>();
        }


        private void button_comercial_comercial_cargamasivaliqui_Citrico_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comercial.Frm_CargarLiquidacionCIT>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void button_ofLima_logistica_programarCursos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Logistica.Frm_ProgramarCursoProveedor>();
        }

        private void button_comercial_contabilidad_campaña_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_CampanaSucursal>();
        }

        private void button_comercial_contabilidad_PartSinClasi_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_ClasificacionPartidas>();
        }
        private void button_comercial_contabilidad_ClasifCeco_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_ClasificacionCeco>();
        }

        private void button_comercial_contabilidad_TablasMaestras_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_TablasMaestras>();
        }
        private void button_comercial_contabilidad_ControlCumplimiento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_CargarCumplimiento>();
        }

        private void button_comercial_contabilidad_KilosProyectado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_CargarKilosProyectado>();
        }

        private void button_comercial_contabilidad_TablasMaestrasRendicion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_TablasMaestrasRendicion>();
        }

        private void button_comercial_contabilidad_RepDetalleRindGasto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_RepDetalle_RindeCuentas>();
        }

        private void button_comercial_contabilidad_RepResumenRindGasto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_RepDetalle_RindeGastoNisira>();
        }

        private void button_comercial_contabilidad_InfRindeGasto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_Rep_RindeCuentas>();
        }

        private void button_comercial_contabilidad_RepPlanillaMovilidad_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_RepMovilidad_RindeCuentas>();
        }



        //rep
        private void button_comercial_reportes_InfRindeGasto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_Rep_RindeCuentas>();
        }

        private void button_comercial_reportes_PlanillaMovilidad_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Contabilidad.Frm_RepMovilidad_RindeCuentas>();
        }


        //PLANILLA
        private void RRHH_Planilla_Actualizar_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_Registrar_TareajeTrabajador>();
        }

        private void RRHH_Planilla_Cese_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_Registrar_AltasCeses>();
        }

        private void RRHH_Planilla_Compensaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_Registrar_Compensaciones>();
        }

        private void RRHH_Planilla_HorasExtra_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_HorasExtras>();
        }

        private void RRHH_Planilla_Vacaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_Registrar_VacTruncasDev>();
        }

        private void RRHH_Planilla_ReporteAsistenciOffline_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_ReporteAsistenciaOffline>();
        }

        private void RRHH_Planilla_AsistenciaDetallada_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Planilla.Frm_RegistrarAsistenciaDetallada>();
        }

        private void RRHH_Planilla_TareFinalDiario_Click(object sender, EventArgs e)
        {

        }

        private void RRHH_SIG_CumplimientoDocumentos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SIG.Frm_Cargar_CumplimientoDocumentos>();
        }

        private void RRHH_SIG_CumplimientoCertificaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SIG.Frm_Cargar_CumplimientoCertificaciones>();
        }
        private void RRHH_Topico_AtenMedica_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_Cargar_AtenMed>();
        }

        private void RRHH_Topico_RegAtenMedica_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_Registrar_AtenMed>();
        }


        private void RRHH_Topico_ReporteAtenMedica_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Topico.Frm_Reporte_AtenMed>();
        }

        private void RRHH_SelecDesarr_Eficiencia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_CargarEficiencia>();
        }

        private void RRHH_SelecDesarr_RevGrupo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarRevisionGrupo>();
        }

        private void RRHH_SelecDesarr_TrabActivo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_Registrar_Trabajador>();
        }

        private void RRHH_SelecDesarr_Cobertura_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_CargarCobertura>();
        }

        private void RRHH_SelecDesarr_Obs_Cobertura_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_Cargar_Obs_Cobertura>();
        }

        private void RRHH_SelecDesarr_Labor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_CargarLabores>();
        }
        private void RRHH_SelecDesarr_GrupoLabor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_CargarGrupoLabor>();
        }

        private void RRHH_SelecDesarr_Productividad_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SelecDesarrollo.Frm_CargarProductividad>();
        }

        private void RRHH_SelecDesarr_TareoFinal_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarTareoFinalDiario>();
        }

        private void RRHH_Serv_Personal_Subsidios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarSubsidios>();
        }

        private void RRHH_ServPersonal_EncuestaComedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarEncuestaComedor>();
        }

        private void RRHH_ServPersonal_EncuestaCampamento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarEncuestaCampamento>();
        }
        private void RRHH_ServPersonal_Inspeccion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarInspecciones>();
        }
        private void RRHH_ServPersonal_Asistencia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarAsistenciaPersonal>();
        }
        private void RRHH_ServPersonal_HabCampamento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarCampamentoBunker>();
        }
        private void RRHH_ServPersonal_DescComedorPlanilla_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarDescuentoPlanilla>();
        }

        private void RRHH_ServPersonal_marcacioncampamentoexterno_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarMarcacionCampamento>();
        }

        private void RRHH_ServPersonal_ocupabilidadcampamento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarStatusCampExternos>();
        }


        private void RRHH_ServPersonal_movimientocamp_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarMovimientoCampExternos>();
        }

        private void RRHH_ServPersonal_atenciontrabajadores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarAtencionTrabajadores>();
        }

        private void RRHH_ServPersonal_efectividadtrabajadores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarEfectividadAtencion>();
        }


        private void RRHH_Destajo_Uva_ImpSticker_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ImpresionStiker>();
        }

        private void RRHH_Destajo_Uva_ImpPresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ImpresionStikerPresentacion>();
        }

        private void RRHH_Destajo_Uva_ImpStikerClamshells_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ImpresionPresentDest>();
        }

        private void RRHH_LecturaDestajo_lecdestajo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_RegistrarLecturaDestajo>();
        }

        private void RRHH_Reportes_DestajoUva_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ReporteDestajo>();
        }

        private void RRHH_repote_destajo_avance_grupal_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ReporteAvanceGrupal>();
        }

        private void RRHH_Cuadre_CajasDestajo_Nisira_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ReporteCuadreCajes>();
        }

        private void RRHH_Maestros_Homologacion_Nisira_Extech_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_RegistrarHomologacionPresent>();
        }

        private void RRHH_Maestros_CierreDeProceso_DelDia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_CierreProcesoDia>();
        }


        private void RRHH_Maestros_ProrrateoCajas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_ProrrateoCajasPersona>();
        }

        private void RRHH_Maestros_SincronizarExtech_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_DestajoUva.Frm_EnviarCuadreAExtech>();
        }

        /// <summary>
        /// //
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RRHH_SST_Inspeccion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Frm_sst.Frm_MisInspecciones>();
        }

        private void RRHH_SST_Fotosheck_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Frm_Reporte_Fotosheck>();
        }

        private void RRHH_SST_BalanceScord_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_Cargar_SSTScorcard>();
        }

        private void RRHH_SST_CursoCapacitacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_Cargar_CursosDeCapacitacion>();
        }
        private void RRHH_SST_CursoRitran_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_Cargar_CursosDeRitran>();
        }
        private void RRHH_SST_CargarTareoFinal_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarTareoFinal>();
        }
        private void RRHH_SST_CargarMotivoAccidente_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_CargarMotivoAccidente>();
        }
        private void RRHH_SST_CargarLogisticaCapacitacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Logistica.Frm_Cargar_LogisticaCapacitacion>();
        }
        private void RRHH_SST_CargarProgTerceros_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_SST.Frm_Cargar_ProgramacionTerceros>();
        }

        private void RRHH_SST_ProgramarCursos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Logistica.Frm_ProgramarCursos>();
        }

        private void RRHH_SST_ProgramarCursosProveedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Logistica.Frm_ProgramarCursoProveedor>();
        }
        private void RRHH_SST_ProgramarCursosPregunta_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Logistica.Frm_ProgramarCursosRespuesta>();
        }

        private void RRHH_SST_Reportes_AsistenciaCurso_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Logistica.Frm_ReporteRegistroAsistencia>();
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        private void RRHH_Comunicaciones_CosechGanadores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarCosechandoGanadores>();
        }

        private void RRHH_Comunicaciones_LideresEnAccion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarLideresEnAccion>();
        }

        private void RRHH_Comunicaciones_PotenciandoLideres_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarPotenciandoLideres>();
        }

        private void RRHH_Comunicaciones_EncuestaClima_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarEncuestaClima>();
        }

        private void RRHH_Comunicaciones_ParticipacionEncuesta_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarEncuestaParticipacion>();
        }

        private void RRHH_Comunicaciones_PuntosPlanilla_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarPuntosPlanilla>();
        }
        private void RRHH_Comunicaciones_EncuestaComedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarEncuestaComedor>();
        }

        private void RRHH_Comunicaciones_EncuestaCampamento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Ser_personal.Frm_CargarEncuestaCampamento>();
        }

        private void RRHH_Comunicaciones_SaldoPuntos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarSaldoPuntos>();
        }

        private void RRHH_Comunicaciones_MovimientoCanjes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Comunicacion.Frm_CargarMovimientoCanje>();
        }

        private void button_administracion_presupuesto_TareoFinal_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarTareoFinal>();
        }

        private void button_administracion_presupuesto_DetalleCosechador_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarDetalleCosechador>();
        }

        private void button_administracion_presupuesto_TareDetallado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarTareoDetallado>();
        }

        private void button_administracion_presupuesto_MetaVariedad_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_Cargar_Metas>();
        }

        private void button_administracion_presupuesto_observado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarPersonalObservado>();
        }

        private void button_administracion_riego_tensiometro_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarRiegoReservorio>();
        }

        private void button_administracion_riego_hermisan_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarProgramaRiego>();
        }

        private void button_administracion_riego_reservorio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarRiegoReservorio>();
        }

        private void button_administracion_producci_CosValvula_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Administracion.Frm_Reporte_CosechaValvula>();
        }

        private void button_administracion_producci_KgProyectado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_Cargar_Prod_KgProyectado>();
        }

        private void button_administracion_producci_HaProgramado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_Cargar_ProgHectarea>();
        }
        private void button_administracion_riego_ph_ce_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarRiegoProgramaPulsos>();
        }

        private void button_administracion_riego_percolacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarRiegoMetroCubico>();
        }

        private void button_administracion_riego_fertilizantes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarRiegoFertlizacion>();
        }

        private void button_administracion_Sanidad_EstacionMeteorologica_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarEstacionMeteorologica>();
        }

        private void button_administracion_Sanidad_EvaluacionCampo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarEvaluacionCampo_SA>();
        }


        private void button_packing_mantenimiento_ConsEnergia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.AcopioPacking.Frm_Cargar_ConsumoEnergia>();
        }

        private void button_packing_mantenimiento_paradamaquina_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_ParadasMaquina>();
        }
        private void button_packing_produccion_Ordenes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_SaveOrdenProduccion>();
        }

        private void button_packing_produccion_Presentacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_SavePresentacion>();
        }
        private void button_packing_calidad_tomamuestra_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_TomaMuestra>();
        }

        private void button_packing_calidad_control_palets_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_ControlDefectos>();
        }

        private void button_packing_calidad_brixAcidez_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_BrixAcidez>();
        }

        private void button_packing_calidad_libpalets_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_LiberacionPalet>();
        }
        private void rECEPCIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_AcopioRecepcion>();
        }

        private void button_acopio_reporte_recepcion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_RecepcionAcopio>();
        }


        private void button_packing_proceso_recepcion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_Recepcion>();
        }

        private void button_packing_proceso_gasificado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_Gasificado>();
        }

        private void button_packing_proceso_prefrio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_PreFrio>();
        }
        private void button_packing_proceso_prog_pallet_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_ProgramacionPallets>();
        }

        private void button_packing_proceso_prog_presentacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_ProgMaqPresentacion>();
        }

        private void button_packing_proceso_volcado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_Volcado>();
        }

        private void button_packing_proceso_ControlProc_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_ReporteControlProceso>();
        }

        private void button_packing_proceso_TomaMuestra_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_TomaMuestra>();
        }
        private void button_packing_proceso_PT_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_PT>();
        }

        private void button_packing_proceso_frio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_Frio>();
        }
        private void button_packing_proceso_imprimir_pallet_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_ImprimirPallet_ASA>();
        }

        private void button_packing_proceso_imprimir_tarjaPT_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_ImprimirTarjaPT_ASA>();
        }
        private void button_packing_proceso_agregar_merma_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_SaveRpto_Merma>();
        }

        private void button_packing_reporte_estadopallet_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_Reporte_EstadoPallet>();
        }
        //

        private void button_packing_guiafactura_grrCosecha_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_AsignacionGuiaPallet>();
        }

        private void button_packing_guiafactura_facServicio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_AsignacionFacturaServicio>();
        }

        private void button_packing_guiafactura_facExportacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_AsignacionFacturaExportacion>();
        }

        private void button_packing_guiafactura_RepConsolidado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_ReporteGGRConsolidado>();
        }

        private void button_packing_cierre_proceso_CierrePacking_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_CierreProcesoPacking>();
        }

        private void button_packing_cierre_proceso_PT_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.Acopio.Frm_CierreProcesoPackingPT>();
        }

        private void button_packing_rrhh_tareodetallado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Frm_Administracion.Frm_CargarTareoDetallado>();
        }

        private void button_packing_rrhh_progrSemanalPersonal_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.AcopioRRHH.Frm_CargarReqPersonalSemanal>();
        }

        private void button_packing_rrhh_progrAnualPersonal_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<Reportes.AcopioRRHH.Frm_CargarReqPersonalAnual>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tablas_maestras_Click_1(object sender, EventArgs e)
        {

        }

    }
}
