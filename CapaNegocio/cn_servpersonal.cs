using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_servpersonal : cd_conexion
    {

        //GUARDAR INSPECION
        public void GuardarInspeccion(string cod, int sem, string emp, string sed
            , string area, string incidencia, string hallazgo, string peligro, string jerarquia
            , string hallazgo_desv, string medida_correc, string respon, string fec_Rep, string est_insp
            , string medida_correc_2, string evidencia, string fec_levant
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.GuardarInspeccion(cod, sem, emp, sed
            , area, incidencia, hallazgo, peligro, jerarquia
            , hallazgo_desv, medida_correc, respon, fec_Rep
            , est_insp, medida_correc_2, evidencia, fec_levant
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR ASISTENCIA
        public void GuardarAsistencia(
            string Asistencia, string Punto_de_control, string Tipo
            , string Fecha_hora_asistencia, string DNI, string Nombres
            , string año, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.GuardarAsistencia(Asistencia, Punto_de_control, Tipo
            , Fecha_hora_asistencia, DNI, Nombres
            , año, semana, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR DESCUENTO PLANILLA
        public void GuardarDescuentoComedorPlanilla(
              string DNI, string Nombres, string emp, string sede
            , string comedor, string monto
            , string año, string semana, string fecini, string fecfin
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.GuardarDescuentoComedorPlanilla(
              DNI, Nombres, emp, sede
            , comedor, monto, año, semana, fecini, fecfin
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR MOTIVO ACCIDENTE
        public void GuardarMotivoAccidente(
            string DNI, string Nombres
            , string fecha, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.GuardarMotivoAccidente(
                DNI, Nombres
            , fecha, obs, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR CAMPAMENTO
        public void GuardarCampamentoBunker(string emp, string sed,
            string Pabellon, string N, string Campamento
            , string DNI, string Responsable_habitacion, string Sexo
            , string Gerencia, string Area, string Cargo
            , string Lugar_de_residencia, string Condicion_de_alojamiento
            , string Condicion_contrato, string Capacidad, string Ocupabilidad
            , string Disponibilidad, string diascamp, string obs
            , string año, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.GuardarCampamentoBunker(emp, sed,
                Pabellon, N, Campamento
            , DNI, Responsable_habitacion, Sexo
            , Gerencia, Area, Cargo
            , Lugar_de_residencia, Condicion_de_alojamiento
            , Condicion_contrato, Capacidad, Ocupabilidad
            , Disponibilidad, diascamp, obs, año, semana
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //ELIMINAR CUMPLIMIENTO CAMPAMENTO
        public void EliminarCampamento(
            string emp, string sed, string año, string semana)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.EliminarCampamento(
                emp, sed, año, semana);
        }

        //ELIMINAR CUMPLIMIENTO ASISTENCIA
        public void EliminarAsistencia(
            string año, string semana)
        {
            cd_servpersonal datos = new cd_servpersonal();
            datos.EliminarAsistencia(
                año, semana);
        }


        public static DataTable ListaReporteQRTransportista(string trans)
        {
            cd_servpersonal datos = new cd_servpersonal();
            return datos.ListaReporteQRTransportista(trans);
        }


        public static DataTable ListaReporteResumenIngresoSalidaBuses(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string transporte, string placa)
        {
            cd_servpersonal datos = new cd_servpersonal();
            return datos.ListaReporteResumenIngresoSalidaBuses(
                fecini, fecfin, emp, sed, transporte, placa);
        }

        public static DataTable ListaReporteDetalleIngresoSalidaBuses(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string transporte, string placa)
        {
            cd_servpersonal datos = new cd_servpersonal();
            return datos.ListaReporteDetalleIngresoSalidaBuses(
                fecini, fecfin, emp, sed, transporte, placa);
        }


    }
}
