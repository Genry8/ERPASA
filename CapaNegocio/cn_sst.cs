using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_sst : cd_conexion
    {

        //metodo para buscar ultimo codigo de capacitacion +1
        public static bool BuscUltimoCodCapacitacionSSTMas()
        {
            cd_sst datos = new cd_sst();
            return datos.UltimoCodigoCapacitacionSSTMas();
        }


        //metodo para buscar si existe dni y fecha atencion
        public static bool BuscDatosPersonalASA(string dni)
        {
            cd_sst datos = new cd_sst();
            return datos.BuscDatosPersonalASA(dni);
        }

        //metodo para buscar atencion
        public static bool BuscAtencionPaciente(string dni, DateTime fecha, string horaentrada)
        {
            cd_sst datos = new cd_sst();
            return datos.BuscAtencionPaciente(dni, fecha, horaentrada);
        }

        //metodo para eliminar receta
        public static bool EliminarRecetaMedica(string dni, DateTime fecha, string horaentrada)
        {
            cd_sst datos = new cd_sst();
            return datos.EliminarRecetaMedica(dni, fecha, horaentrada);
        }

        //metodo para buscar si existe la persona para capacitacion cabecera
        public static bool BuscExisteUserCapacitacionSST(string cod)
        {
            cd_sst datos = new cd_sst();
            return datos.BuscExisteUserCapacitacionSST(cod);
        }

        //LISTA MEDICAMENTO POR FILTRO
        //
        public static DataTable ListaMedicamentoTopico(string cod, string desc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaMedicamentosTopico(cod, desc);
        }

        //LISTA 
        //
        public static DataTable ListaRecetaAtencion(string cod, DateTime fecaten, string hora)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecetaAtencion(cod, fecaten, hora);
        }

        //LISTA 
        //
        public static DataTable ListaAtencionPaciente(DateTime fecini, DateTime fecfin, string emp, string sed, string dni)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaAtencionPaciente(fecini, fecfin, emp, sed, dni);
        }

        //LISTA 
        //
        public static DataTable ListaRecepcionAcopio(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcionAcopio(fecini, fecfin, emp, sed);
        }

        public static DataTable ListaRecepcion(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcion(fecini, fecfin, emp, sed);
        }

        public static DataTable ListaEstadoPallet(DateTime fecini, DateTime fecfin, string emp, string sed, string pallet)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaEstadoPallet(fecini, fecfin, emp, sed, pallet);
        }

        public static DataTable ListaRecepcionImprimir(
            DateTime fecini, DateTime fecfin, string emp, string sed, string cult)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcionImprimir(fecini, fecfin, emp, sed, cult);
        }

        public static DataTable RecepcionProgVolcado(
            DateTime fecini, DateTime fecfin, string emp
            , string sed, string cult,string var,string maq)
        {
            cd_sst datos = new cd_sst();
            return datos.RecepcionProgVolcado(fecini, fecfin, emp
                , sed, cult,var,maq);
        }

        public static DataTable ListaRecepcionProgVolcado(
            DateTime fecini, DateTime fecfin, string emp
            , string sed, string cult, string var, string maq)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcionProgVolcado(fecini, fecfin, emp
                , sed, cult, var, maq);
        }

        public static DataTable ListaPTImprimir(
            DateTime fecini, DateTime fecfin, string emp, string sed, string cult)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaPTImprimir(fecini, fecfin, emp, sed, cult);
        }

        public void ActualizarRecepcionImprimir(string pallet, string fecha)
        {
            cd_sst datos = new cd_sst();
            datos.ActualizarRecepcionImprimir(pallet, fecha);
        }

        public void ActualizarPTImprimir(string pallet, DateTime fecha)
        {
            cd_sst datos = new cd_sst();
            datos.ActualizarPTImprimir(pallet, fecha);
        }

        public static DataTable ListaReporteVolcado(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string var)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteVolcado(fecini, fecfin, emp, sed, cult, var);
        }

        public static DataTable ListaReporteFrio(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string var)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteFrio(fecini, fecfin, emp, sed, cult, var);
        }

        public static DataTable ListaReporteTomaMuestra(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string var)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteTomaMuestra(fecini, fecfin, emp, sed, cult, var);
        }
        public static DataTable ListaReporteMerma(DateTime fecini,
            DateTime fecfin, string emp, string sed, string merma)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteMerma(fecini, fecfin, emp, sed, merma);
        }

        public static DataTable ListaReporteOrdProd(DateTime fecini,
            DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteOrdProd(fecini, fecfin, emp, sed);
        }

        public static DataTable ListaReportePresentacion(string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReportePresentacion(emp, sed);
        }

        public static DataTable ListaReportePT(DateTime fecini
            , DateTime fecfin, string emp, string sed, string cult, string palet)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReportePT(fecini, fecfin, emp, sed, cult, palet);
        }

        public static DataTable ListaReporteGasificado(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteGasificado(fecini, fecfin, emp, sed);
        }

        public static DataTable ListaReportePreFrio(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReportePreFrio(fecini, fecfin, emp, sed);
        }



        //LISTA 
        //
        public static DataTable ListaRecepcionAcopioVariedad(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcionAcopioVariedad(fecini, fecfin, emp, sed);
        }

        public static DataTable ListaRecepcionVariedad(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcionVariedad(fecini, fecfin, emp, sed);
        }

        public static DataTable ListaReporteVolcadoMaquina(DateTime fecini,
            DateTime fecfin, string emp, string sed, string cult, string var)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteVolcadoMaquina(fecini, fecfin, emp, sed, cult, var);
        }
        public static DataTable ListaReporteVolcadoVariedad(DateTime fecini
            , DateTime fecfin, string emp, string sed, string cult, string var)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReporteVolcadoVariedad(fecini, fecfin, emp, sed, cult, var);
        }

        public static DataTable ListaReportePTMaquina(DateTime fecini
            , DateTime fecfin, string emp, string sed, string cult)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReportePTMaquina(fecini, fecfin, emp, sed, cult);
        }

        public static DataTable ListaReportePTPresentacion(DateTime fecini
            , DateTime fecfin, string emp, string sed, string cult)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaReportePTPresentacion(fecini, fecfin, emp, sed, cult);
        }

        //LISTA 
        //
        public static DataTable ListaRecepcionAcopioProducto(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaRecepcionAcopioProducto(fecini, fecfin, emp, sed);
        }

        //ACTUALIZAR PERSONAL SST
        public void ActualizarPersonalSST(int cod, string doc, DateTime fecind, string sem, string nota
            , string tipoemp, string empcont, string sede, string area, string venlic, string entlicind, string tiplic, string unidmanj,
            string fecmult, string puntcond, string obs, string estado, DateTime fec_edit, int useedit)
        {
            cd_sst datos = new cd_sst();
            datos.ActualizarPersonalSST(cod, doc, fecind, sem, nota, tipoemp, empcont, sede, area, venlic, entlicind,
                tiplic, unidmanj, fecmult, puntcond, obs, estado, fec_edit, useedit);
        }

        //GUARDAR PERSONAL SST
        public void GuardarPersonalSST(int cod, string doc, DateTime fecind, string sem, string nota
            , string tipoemp, string empcont, string sede, string area, string venlic, string entlicind, string tiplic, string unidmanj,
            string fecmult, string puntcond, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_sst datos = new cd_sst();
            datos.GuardarPersonalSST(cod, doc, fecind, sem, nota, tipoemp, empcont, sede, area, venlic, entlicind, tiplic,
                 unidmanj, fecmult, puntcond, obs, estado, fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //ACTUALIZAR CAPACITACION DEETALLE SST
        public void ActualizarCapacitacionDetallelSST(int cod, string doc,
           string Tar_ta, string Sem_ta, string Nota_ta, string Tar_ez, string Sem_ez, string Nota_ez,
            string Tar_tc, string Sem_tc, string Nota_tc, string Tar_ec, string Sem_ec, string Nota_ec,

            string Esp_map, string Sem_map, string Nota_map, string Esp_rcs, string Sem_rcs, string Nota_rcs,
            string Esp_hmp, string Sem_hmp, string Nota_hmp, string Esp_vpp, string Sem_vpp, string Nota_vpp,
            string Esp_ats, string Sem_ast, string Nota_ats,

            string Bas_iperc, string Sem_iperc, string Nota_iperc, string Bas_scc, string Sem_scc, string Nota_scc,
            string Bas_epp, string Sem_epp, string Nota_epp, string Bas_aci, string Sem_aci, string Nota_aci,

            string Ext_er, string Sem_er, string Nota_er, string Ext_ppi, string Sem_ppi, string Nota_ppi,
            string Ext_eepp, string Sem_eepp, string Nota_eepp, string Ext_rsa, string Sem_rsa, string Nota_rsa,

            string Otr_maptel, string Sem_maptel, string Nota_maptel, string Otr_tea, string Sem_tea, string Nota_tea,
            string Otr_risst, string Sem_risst, string Nota_risst,

            string obs, string estado, DateTime fec_edit, int useedit)
        {
            cd_sst datos = new cd_sst();
            datos.ActualizarCapacitacionDetalleSST(cod, doc,
                Tar_ta, Sem_ta, Nota_ta, Tar_ez, Sem_ez, Nota_ez,
             Tar_tc, Sem_tc, Nota_tc, Tar_ec, Sem_ec, Nota_ec,

             Esp_map, Sem_map, Nota_map, Esp_rcs, Sem_rcs, Nota_rcs,
             Esp_hmp, Sem_hmp, Nota_hmp, Esp_vpp, Sem_vpp, Nota_vpp,
             Esp_ats, Sem_ast, Nota_ats,

             Bas_iperc, Sem_iperc, Nota_iperc, Bas_scc, Sem_scc, Nota_scc,
             Bas_epp, Sem_epp, Nota_epp, Bas_aci, Sem_aci, Nota_aci,

             Ext_er, Sem_er, Nota_er, Ext_ppi, Sem_ppi, Nota_ppi,
             Ext_eepp, Sem_eepp, Nota_eepp, Ext_rsa, Sem_rsa, Nota_rsa,

             Otr_maptel, Sem_maptel, Nota_maptel, Otr_tea, Sem_tea, Nota_tea,
             Otr_risst, Sem_risst, Nota_risst,

             obs, estado, fec_edit, useedit);
        }

        //GUARDAR CAPACITACION DETALLE SST
        public void GuardarCapacitacionDetalleSST(int cod, string doc,
            string Tar_ta, string Sem_ta, string Nota_ta, string Tar_ez, string Sem_ez, string Nota_ez,
            string Tar_tc, string Sem_tc, string Nota_tc, string Tar_ec, string Sem_ec, string Nota_ec,

            string Esp_map, string Sem_map, string Nota_map, string Esp_rcs, string Sem_rcs, string Nota_rcs,
            string Esp_hmp, string Sem_hmp, string Nota_hmp, string Esp_vpp, string Sem_vpp, string Nota_vpp,
            string Esp_ats, string Sem_ast, string Nota_ats,

            string Bas_iperc, string Sem_iperc, string Nota_iperc, string Bas_scc, string Sem_scc, string Nota_scc,
            string Bas_epp, string Sem_epp, string Nota_epp, string Bas_aci, string Sem_aci, string Nota_aci,

            string Ext_er, string Sem_er, string Nota_er, string Ext_ppi, string Sem_ppi, string Nota_ppi,
            string Ext_eepp, string Sem_eepp, string Nota_eepp, string Ext_rsa, string Sem_rsa, string Nota_rsa,

            string Otr_maptel, string Sem_maptel, string Nota_maptel, string Otr_tea, string Sem_tea, string Nota_tea,
            string Otr_risst, string Sem_risst, string Nota_risst,

            string obs, string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_sst datos = new cd_sst();
            datos.GuardarCapacitacionDetalleSST(cod, doc,
             Tar_ta, Sem_ta, Nota_ta, Tar_ez, Sem_ez, Nota_ez,
             Tar_tc, Sem_tc, Nota_tc, Tar_ec, Sem_ec, Nota_ec,

             Esp_map, Sem_map, Nota_map, Esp_rcs, Sem_rcs, Nota_rcs,
             Esp_hmp, Sem_hmp, Nota_hmp, Esp_vpp, Sem_vpp, Nota_vpp,
             Esp_ats, Sem_ast, Nota_ats,

             Bas_iperc, Sem_iperc, Nota_iperc, Bas_scc, Sem_scc, Nota_scc,
             Bas_epp, Sem_epp, Nota_epp, Bas_aci, Sem_aci, Nota_aci,

             Ext_er, Sem_er, Nota_er, Ext_ppi, Sem_ppi, Nota_ppi,
             Ext_eepp, Sem_eepp, Nota_eepp, Ext_rsa, Sem_rsa, Nota_rsa,

             Otr_maptel, Sem_maptel, Nota_maptel, Otr_tea, Sem_tea, Nota_tea,
             Otr_risst, Sem_risst, Nota_risst,

             obs, estado, fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //
        //


        //metodo para guardar receta medica
        public static DataTable GuardRecetaMedica(DateTime Fecha, string Dni, DateTime HraEntrada
            , DateTime HraSalida, string Cod, string Descripcion, string UniMed, decimal Cant
            , decimal Precio, DateTime Fecha_med, decimal Total,
             string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_sst datos = new cd_sst();
            return datos.GuardarRecetaMedica(Fecha, Dni, HraEntrada
            , HraSalida, Cod, Descripcion, UniMed, Cant
            , Precio, Fecha_med, Total,
             estado, fec_cre, usereg, hostname, fec_edit, useedit);
        }


        //metodo para listar capacitaciones
        public static DataTable ListaCapacitacionesSST()
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapacitacionesSST();
        }

        //metodo para listar capacitaciones filtro
        public static DataTable ListaCapacitacionesFiltroSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapacitacionesFiltroSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }

        //metodo para listar capacitaciones fotosheck
        public static DataTable ListaCapFotosheckFiltroSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapFotosheckFiltroSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }

        //metodo para listar capacitaciones fotosheck trabajos en altura
        public static DataTable ListaCapFotosheckFiltroTrabAlturaSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapFotosheckFiltroTrabAlturaSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }

        //metodo para listar capacitaciones fotosheck trabajos en excavaciones y zanja
        public static DataTable ListaCapFotosheckFiltroExcZanjaSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapFotosheckFiltroExcZanjaSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }

        //metodo para listar capacitaciones fotosheck trabajos en caliente
        public static DataTable ListaCapFotosheckFiltroTrabCalienteSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapFotosheckFiltroTrabCalienteSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }

        //metodo para listar capacitaciones fotosheck espacios confinados
        public static DataTable ListaCapFotosheckFiltroEspConfiSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapFotosheckFiltroEspConfSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }


        //metodo para listar capacitaciones fotosheck licencia
        public static DataTable ListaCapFotosheckFiltroLicenciaSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaCapFotosheckFiltroLicenciaSST(fechaIni, fechafin, emp, sed,
                area,
                sem, tipoemp,
                doc);
        }

        //BUSCAR CABECERA DE CAPACITACIONES
        public static bool BuscCapacitacionesCabeceraSST(string dni)
        {
            cd_sst datos = new cd_sst();
            return datos.BuscCapacitacionesCabeceraSST(dni);
        }

        //metodo para eliminar CAPACITACION 
        public void EliminCapacitacionesCabeceraSST(int codigo, string dni, DateTime fecedit, int useedit)
        {
            cd_sst datos = new cd_sst();
            datos.EliminarCapacitacionesCabeceraSST(codigo, dni, fecedit, useedit);
        }

        //metodo para actualizar CESE DE CAPACITACION 
        public void CeseCapacitacionesCabeceraSST(string dni)
        {
            cd_sst datos = new cd_sst();
            datos.CeseCapacitacionesCabeceraSST(dni);
        }
        //metodo para actualizar CESE DE CAPACITACION INDIVIDUAL
        public void CeseCapacitacionesCabeceraIndividualSST(string dni)
        {
            cd_sst datos = new cd_sst();
            datos.CeseCapacitacionesCabeceraIndividualSST(dni);
        }


        //DETALLE DE INSPECCIONES
        //metodo para listar capacitaciones filtro
        //EXTINTORES
        public static DataTable ListaInspeccionFiltroSST_Extintor(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_Extintor(fecini, fecfin, emp, sed, area);
        }

        //DUCHA LAVA OJOS
        public static DataTable ListaInspeccionFiltroSST_DuchaLavaOjos(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_DuchaLavaOjos(fecini, fecfin, emp, sed, area);
        }

        //LAVA OJOS PORTATIL
        public static DataTable ListaInspeccionFiltroSST_LavaOjosPortatil(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_LavaOjosPortatil(fecini, fecfin, emp, sed, area);
        }

        //KIT ANTIDERRAME
        public static DataTable ListaInspeccionFiltroSST_KitAntiDerrame(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_KitAntiDerrame(fecini, fecfin, emp, sed, area);
        }

        //LUCES EMERGENCIA
        public static DataTable ListaInspeccionFiltroSST_LucesEmergencia(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_LucesEmergencia(fecini, fecfin, emp, sed, area);
        }

        //ALARMAS EMERGENCIA
        public static DataTable ListaInspeccionFiltroSST_AlarmasEmergencia(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_AlarmasEmergencia(fecini, fecfin, emp, sed, area);
        }

        //SEGURIDAD RESERVORIO
        public static DataTable ListaInspeccionFiltroSST_SeguridadReservorio(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_SeguridadReservorio(fecini, fecfin, emp, sed, area);
        }

        //ARNES
        public static DataTable ListaInspeccionFiltroSST_Arnes(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_Arnes(fecini, fecfin, emp, sed, area);
        }


        //ARNES
        public static DataTable ListaInspeccionFiltroSST_Escalera(DateTime fecini, DateTime fecfin,
            string emp, string sed,
            string area)
        {
            cd_sst datos = new cd_sst();
            return datos.ListaInspeccionesFiltroSST_Escalera(fecini, fecfin, emp, sed, area);
        }


        //GUARDAR CURSO CAPACITACION
        public void GuardarCursoCapacitacion(string codigo
            , string Empresa, string sede
            , string apenom, string dni, string Area, string RUC
            , string Cargo, string SedeCapacitacion, string FechaInduccion
            , string TrabajoAltura, string NotaTraAlt, string ExcavacionZanja
            , string NotaExcavZanja, string TrabajoCaliente
            , string NotaTrabCal, string EspacioConfinado, string NotaEspConf,
            string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_sst datos = new cd_sst();
            datos.GuardarCursoCapacitacion(codigo
                , Empresa, sede
            , apenom, dni, Area, RUC
            , Cargo, SedeCapacitacion, FechaInduccion
            , TrabajoAltura, NotaTraAlt, ExcavacionZanja
            , NotaExcavZanja, TrabajoCaliente
            , NotaTrabCal, EspacioConfinado, NotaEspConf
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR CURSO CAPACITACION
        public void GuardarCursoCapacitacionLogistica(string codigo
            , string apenom, string dni, string RUC, string razonsocial
            , string Cargo, string FechaInduccion, string destrab
            , string HombreNuevo, string TrabajoAltura
            , string TrabajoCaliente, string ExcavZanja, string area
            , string lugar
            , string Empresa, string sede
            , string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_sst datos = new cd_sst();
            datos.GuardarCursoCapacitacionLogistica(codigo
                , apenom, dni, RUC, razonsocial
            , Cargo, FechaInduccion, destrab
            , HombreNuevo, TrabajoAltura
            , TrabajoCaliente, ExcavZanja, area
            , lugar, Empresa, sede
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR CURSO CAPACITACION
        public void GuardarProgramacionTerceros(string sem
            , string RUC, string razonsocial
            , string numOS, string destrab
            , string lugarTrabajo, string sede
            , string AreaSol, string Jefatura, string cantTrab
            , string FecIni, string FecFin, string obs
            , string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_sst datos = new cd_sst();
            datos.GuardarProgramacionTerceros(sem
            , RUC, razonsocial
            , numOS, destrab
            , lugarTrabajo, sede
            , AreaSol, Jefatura, cantTrab
            , FecIni, FecFin, obs
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR CURSO RITRAN
        public void GuardarCursoRitran(string codigo, string Empresa, string sede
            , string apenom, string dni, string Area, string RUC
            , string Cargo, string fechaMTC, string FechaCap, string FecVenRitran
            , string NotaExamen, string FechaEntrega, string UnidadManejar
            , string FechaMulta, string PuntoSancionado
            , string Obs,
            string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_sst datos = new cd_sst();
            datos.GuardarCursoRitran(codigo, Empresa, sede
            , apenom, dni, Area, RUC
            , Cargo, fechaMTC, FechaCap, FecVenRitran
            , NotaExamen, FechaEntrega, UnidadManejar
            , FechaMulta, PuntoSancionado
            , Obs
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }




    }
}
