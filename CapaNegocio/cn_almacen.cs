using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_almacen : cd_conexion
    {

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExisteEficienciaMaquinaria(string cod, DateTime fecha)
        {
            cd_taller datos = new cd_taller();
            return datos.BuscExisteEficienciaMaquinaria(cod, fecha);
        }


        //GRIPO ABASTECIMIENTO

        public static DataTable BuscarPedateoAbastecimientoGrifo(DateTime FecIni, DateTime FecFin
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            cd_almacen datos = new cd_almacen();
            return datos.BuscarPedateoAbastecimientoGrifo(FecIni, FecFin, area
            , tipopersonal, Empresa, Sede, dni);
        }


        public static DataTable BuscarPedateoAbastecimientoGrifoCorte(DateTime FecIni, DateTime FecFin
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            cd_almacen datos = new cd_almacen();
            return datos.BuscarPedateoAbastecimientoGrifoCorte(FecIni, FecFin, area
            , tipopersonal, Empresa, Sede, dni);
        }



    }

}