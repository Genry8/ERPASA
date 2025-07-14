using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_contabilidad : cd_conexion
    {
        public static DataTable ListaReporteCampaña(
            string periodo, string sucursal, string cultivo)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaReporteCampaña(
            periodo, sucursal, cultivo);
        }
        public static DataTable ListaReporteCampañaConsumidor(
            string empresa, string sucursal, string cultivo)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaReporteCampañaConsumidor(
            empresa, sucursal, cultivo);
        }

        public static DataTable ListaReportePartidasPendientes(
            int id, string emp,string suc,string cult, string area)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaReportePartidasPendientes(
                id, emp, suc, cult, area);
        }

        public static DataTable ListaReporteControlCumplimiento(
            int id, string emp, string ger, string area, string año,string mes)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaReporteControlCumplimiento(
            id, emp, ger, area, año, mes);
        }

        public static DataTable ListaReporteCecoPendientes(
            int id, string emp, string area, string idcuenta)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaReporteCecoPendientes(
                id, emp, area, idcuenta);
        }

        //
        //metodo para guardar campaña
        public void GuardCampañaConta(int cod,
            string sucursal, string cultivo, string etapa, string campaña
            , string fecini, string fecfin, string factor, string emp, string sed
            , string hoja, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarCampañaConta(cod,
                sucursal, cultivo, etapa, campaña
            , fecini, fecfin, factor, emp, sed
            , hoja, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar campaña sucursal
        public void GuardCampañaConsumidorConta(int cod,
            string sucursal, string cultivo, string etapa
            ,string consumidor, string campaña
            , string fecini, string fecfin, string factor, string emp, string sed
            , string hoja, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarCampañaConsumidorConta(cod,
                sucursal, cultivo, etapa, consumidor, campaña
            , fecini, fecfin, factor, emp, sed
            , hoja, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar campaña
        public void GuardSucursalConta(int cod,
            string emp, string sucursal,string sucnisira, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarSucursalConta(cod,
                emp, sucursal, sucnisira, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar cultivo
        public void GuardCultivoConta(int cod,
            string emp, string sucursal, string cultivo
            , string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarCultivoConta(cod,
                emp, sucursal, cultivo, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar etapa
        public void GuardEtapaConta(int cod,
            string etapa, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarEtapaConta(cod,
                etapa, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar tipo gasto
        public void GuardarTipoGasto(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarTipoGasto(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar tipo estructura
        public void GuardarTipoEstructura(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarTipoEstructura(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar area
        public void GuardarArea(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarArea(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar tipo recurso
        public void GuardarTipoRecurso(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarTipoRecurso(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar tipo recurso
        public void GuardarRecurso(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarRecurso(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar tipo recurso
        public void GuardarClasificador(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarClasificador(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar tipo recurso
        public void GuardarGerencia(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarGerencia(cod,
                descripcion, estado, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar actualizar partidas asa
        public void GuardActualizarPartidasConta(string emp, string area_sis,
            string idrubro, string partida, string partida_final
            , string sucursal, string cultivo, string etapa, string valid
            , string tipogasto, string tipoestruc, string estruc_area
            , string etiqueta, string tiporecurso, string recurso
            , string clasif, string gerencia, string agrup
            , DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarActualizarPartidaConta(emp, area_sis,
            idrubro, partida, partida_final
            , sucursal, cultivo, etapa, valid
            , tipogasto, tipoestruc, estruc_area
            , etiqueta, tiporecurso, recurso
            , clasif, gerencia, agrup, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar actualizar control cumplimiento asa
        public void GuardActualizarControlCumplimientoConta(
            int id,string emp, string sede,
            string gerencia, string area, string actividad
            , string responsable, string calif, string fecha_ini, string fecha_obli
            , string fecha_cump, string mes, string año
            , string hoja, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardActualizarControlCumplimientoConta(
                id, emp, sede,
            gerencia, area, actividad
            , responsable, calif, fecha_ini, fecha_obli
            , fecha_cump, mes, año
            , hoja, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }


        //ELIMINAR CUMPLIMIENTO DOCUMENTO
        public void EliminarControlCumplimientoConta(string año, string mes)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.EliminarControlCumplimientoConta(año, mes);
        }


        //
        //metodo para guardar actualizar control cumplimiento asa
        public void GuardarControlCumplimientoConta(
            string id,string emp, string sede,
            string gerencia, string area, string actividad
            , string responsable, string calif, string fecha_ini, string fecha_obli
            , string fecha_cump, string mes, string año
            , string hoja, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarControlCumplimientoConta(
                id,emp, sede,
            gerencia, area, actividad
            , responsable, calif, fecha_ini, fecha_obli
            , fecha_cump, mes, año
            , hoja, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar actualizar partidas asa
        public void GuardActualizarCecoConta(string emp, string area_sis,
            string idccosto, string ccosto, string idcuenta
            , string partida, string partida_final
            , string sucursal, string cultivo, string etapa, string valid
            , string tipogasto, string tipoestruc, string estruc_area
            , string etiqueta, string tiporecurso, string recurso
            , string clasif, string gerencia, string agrup
            , DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarActualizarCecoConta(emp, area_sis,
            idccosto, ccosto, idcuenta, partida, partida_final
            , sucursal, cultivo, etapa, valid
            , tipogasto, tipoestruc, estruc_area
            , etiqueta, tiporecurso, recurso
            , clasif, gerencia, agrup, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //
        //metodo para guardar campaña
        public void GuardarPartidasNisira(
             string emp, string idrubro, string partida, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.GuardarPartidasNisira(
              emp, idrubro, partida, fec_cre
            , usereg, hostname, fec_edit, usedit);
        }

        //LISTA PARTIDAS NISIRA
        public static DataTable ListaPartidasNisira()
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaPartidasNisira();
        }


        //ELIMINAR PARTIDAS
        public void EliminarPartida()
        {
            cd_contabilidad datos = new cd_contabilidad();
            datos.EliminarPartida();
        }

        public static DataTable ListaAreaPartida(
            string empresa,string sucursal, string cultivo)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaAreaPartida(empresa, sucursal,cultivo);
        }

        public static DataTable ListaAreaCumplimiento(
            string empresa, string gerencia)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaAreaCumplimiento(empresa, gerencia);
        }

        public static DataTable ListaIdCuentaCeco(string empresa)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaIdCuentaCeco(empresa);
        }

        public static DataTable ListaSucursal(string emp)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaSucursal(emp);
        }

        public static DataTable ListaGerenciaCumplimiento(string emp)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaGerenciaCumplimiento(emp);
        }

        public static DataTable ReporteSucursal(string emp)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteSucursal(emp);
        }

        public static DataTable ReporteCultivo(string emp, string sucursal)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteCultivo(emp, sucursal);
        }

        public static DataTable ListaConsumidor(
            string emp, string sucursal, string cultivo)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaConsumidor(emp, sucursal, cultivo);
        }

        public static DataTable ReporteEtapa()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteEtapa();
        }

        public static DataTable ReporteTipoGasto()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteTipoGasto();
        }

        public static DataTable ReporteTipoEstructura()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteTipoEstructura();
        }

        public static DataTable ReporteArea()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteArea();
        }

        public static DataTable ReporteTipoRecurso()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteTipoRecurso();
        }

        public static DataTable ReporteRecurso()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteRecurso();
        }

        public static DataTable ReporteClasificar()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteClasificar();
        }

        public static DataTable ReporteGerencia()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ReporteGerencia();
        }

        public static DataTable ListaCultivo(string emp,string sucursal)
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaCultivo(emp,sucursal);
        }

        public static DataTable ListaEtapa()
        {
            cd_contabilidad datos = new cd_contabilidad();
            return datos.ListaEtapa();
        }



    }
}
