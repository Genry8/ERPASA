using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_sig : cd_conexion
    {
        public static DataTable ListaNormaSig()
        {
            cd_sig datos = new cd_sig();
            return datos.ListaNormaSig();
        }

        //GUARDAR CUMPLIMIENTO DOCUMENTO
        public void GuardarCumplimientoDocumentos(int año, int sem,
            string codigo, string Empresa, string sede
            , string revision, string titulo, string solicitante
            , string fecha_solic, string tipo_doc, string gerencia
            , string area, string tipo_actividad, string responsable
            , string etapa_flujo, string fecha_reg
            , string condicion, string detalle, string fecha_public, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_sig datos = new cd_sig();
            datos.GuardarCumplimientoDocumentos(año, sem,
                codigo, Empresa, sede
            , revision, titulo, solicitante
            , fecha_solic, tipo_doc, gerencia
            , area, tipo_actividad, responsable
            , etapa_flujo, fecha_reg
            , condicion, detalle, fecha_public
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //ELIMINAR CUMPLIMIENTO DOCUMENTO
        public void EliminarCumplimientoDocumentos(int año, int sem)
        {
            cd_sig datos = new cd_sig();
            datos.EliminarCumplimientoDocumentos(año, sem);
        }

        //ELIMINAR CUMPLIMIENTO CERTIFICACION
        public void EliminarCumplimientoCertificacion(
            string emp, string sed, string norma, int año, int sem)
        {
            cd_sig datos = new cd_sig();
            datos.EliminarCumplimientoCertificacion(
                emp, sed, norma, año, sem);
        }

        //BUSCAR CONSUMO ENERGIA
        public void BuscConsumoEnergia(
            string emp, string sed, string grupo, string fecha)
        {
            cd_sig datos = new cd_sig();
            datos.BuscConsumoEnergia(
                emp, sed, grupo, fecha);
        }

        //GUARDAR CUMPLIMIENTO CERTIFICACIONES
        public void GuardarCumplimientoCertificaciones(
            int año, int sem, string codigo
            , string Empresa, string sede
            , string nombre_req, string requisito, string nivel
            , string gerencia, string area, string responsable, string evidencia
            , string frecuencia, string fecha_planif
            , string tipo_norma, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_sig datos = new cd_sig();
            datos.GuardarCumplimientoCertificaciones(año, sem, codigo
            , Empresa, sede
            , nombre_req, requisito, nivel
            , gerencia, area, responsable, evidencia
            , frecuencia, fecha_planif
            , tipo_norma
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR CONSUMO ENERGIA
        public void GuardarConsumoEnergia(
              string Empresa, string sede, string grupo, string fecha, string horas
            , string consumo, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_sig datos = new cd_sig();
            datos.GuardarConsumoEnergia(
              Empresa, sede, grupo, fecha, horas, consumo, obs
            , hoja, estado, fec_cre, usereg, hostname
            , fec_mov, usedit);
        }


        //GUARDAR OBS COBERTURA
        public void GuardarObsCobertura(
              string Empresa, string sede, string area, string fecha,
              string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_sig datos = new cd_sig();
            datos.GuardarObsCobertura(
              Empresa, sede, area, fecha, obs
            , hoja, estado, fec_cre, usereg, hostname
            , fec_mov, usedit);
        }






    }
}
