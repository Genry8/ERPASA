using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_comercial
    {
        public static DataTable BuscarReporteLiquidacion(
            DateTime FecIng, DateTime FecFin, string empresa, string id)
        {
            cd_comercial datos = new cd_comercial();
            return datos.BuscarReporteLiquidacion(FecIng, FecFin, empresa, id);
        }


        //metodo para listar grupo para agregar
        public static DataTable ListaEmpresa()
        {
            cd_comercial datos = new cd_comercial();
            return datos.ListaEmpresa();
        }

        //metodo para listar
        public static DataTable ListaLiquidacion()
        {
            cd_comercial datos = new cd_comercial();
            return datos.ListaLiquidacion();
        }


        //GUARDAR ACTUALIZAR PROGRAMACION VOLCADO
        public void GuardarPesoPresentacion(
            int id, string descripcion, decimal peso, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_comercial datos = new cd_comercial();
            datos.GuardarPesoPresentacion(
                id, descripcion, peso, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //GUARDAR HOMOLOGACION
        public void GuardarHomologacionPresentacionDestajo(
            int id, string descripcion, string extech
            , string codextech
            , string tipo, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_comercial datos = new cd_comercial();
            datos.GuardarHomologacionPresentacionDestajo(
                id, descripcion, extech, codextech
                , tipo, obs, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        public static DataTable AgragarDestajoUva(
            string codSticker, string tipo, string sessionId, string id)
        {
            cd_comercial datos = new cd_comercial();
            return datos.AgregarDestajoUva(
            codSticker, tipo, sessionId, id);
        }


        public static DataTable ListaProveedorLiq()
        {
            cd_comercial datos = new cd_comercial();
            return datos.ListaProveedorLiq();
        }


    }
}
