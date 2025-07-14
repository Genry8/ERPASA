using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_taller : cd_conexion
    {

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExisteEficienciaMaquinaria(DateTime fecha
            , string maquinaria, string turno, string operador, string cabezal)
        {
            cd_selecdesarrollo datos = new cd_selecdesarrollo();
            return datos.BuscExisteEficienciaMaquinaria(fecha
                , maquinaria, turno, operador, cabezal);
        }


        public static DataTable ListaGrupoVehiculo()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaGrupoVehiculo();
        }
        public static DataTable ListaMetaKm()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaMetaKM();
        }

        public static DataTable ListaVehiculo(string grupo)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaVehiculo(grupo);
        }

        public static DataTable ListaDetalleInsumos(
            string grupo, string marca, string modelo, string km)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaDetalleInsumos(
            grupo, marca, modelo, km);
        }

        public static DataTable ListaMarcaVehiculo(string id, string grupo)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaMarcaVehiculo(id, grupo);
        }

        public static DataTable ListaModeloVehiculo(string num, string marca)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaModeloVehiculo(num, marca);
        }

        public static DataTable ListaStatusCorrectivo()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaStatusCorrectivo();
        }

        public static DataTable ListaLabor()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaLabor();
        }

        public static DataTable ListaLaborImplemento(string labor)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaLaborImplemento(labor);
        }

        public static DataTable ListaTipoLabor()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaTipoLabor();
        }

        public static DataTable ListaSistemaCorrectivo()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaSistemaCorrectivo();
        }

        public static DataTable ListaSustentoCorrectivo()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaSustentoCorrectivo();
        }

        public static DataTable ListaTipoCorrectivo()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaTipoCorrectivo();
        }

        public static DataTable ListaTipoFallaCorrectivo()
        {
            cd_taller datos = new cd_taller();
            return datos.ListaTipoFallaCorrectivo();
        }

        public static DataTable ListaReporteVehiculos(
            string emp, string sed, string grupo)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteVehiculo(emp, sed, grupo);
        }

        public static DataTable ListaReporteMantenimientoPrev(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string grupo, string vehiculo)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteMantenimientoPrev(
                fecini, fecfin, emp, sed, grupo, vehiculo);
        }

        public static DataTable ListaReporteProxMantPrev(
            string emp, string sed, string grupo, string vehiculo)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteProxMantPrev(
                emp, sed, grupo, vehiculo);
        }

        public static DataTable ListaReporteOrdenTrabajo(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string estado)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteOrdenTrabajo(
                fecini, fecfin, emp, sed, estado);
        }

        public static DataTable ListaReporteMantemientoInsumo(
            string grupo, string marca, string modelo, string km)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteMantemientoInsumo(
                grupo, marca, modelo, km);
        }

        public static DataTable ListaReporteMantenimientoCorrectivo(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string grupo, string vehiculo)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteMantenimientoCorrectivo(
                fecini, fecfin, emp, sed, grupo, vehiculo);
        }

        public static DataTable ListaReporteEficienciaMaquinaria(
            DateTime fecini, DateTime fecfin,
            string emp, string sed)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaReporteEficienciaMaquinaria(
                fecini, fecfin, emp, sed);
        }


        //GUARDAR LISTA VEHICULOS
        public void GuardarListaVehiculos(
            string emp, string sed, string area, string placa
            , string tipovehiculo, string marca, string modelo, string responsable
            , string consumidor, string grupo, string nombre_maq, string potencia
            , string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarListaVehiculos(emp, sed, area, placa
            , tipovehiculo, marca, modelo, responsable
            , consumidor, grupo, nombre_maq, potencia
            , estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //GUARDAR LISTA VEHICULOS
        public void GuardarListaInsumos(string emp, string sed,
            string grupo, string marca, string modelo, string codigo
            , string descripcion, string unidad, string cantidad, string km_ini
            , string km_fin
            , string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarListaInsumos(emp, sed, grupo, marca, modelo, codigo
            , descripcion, unidad, cantidad, km_ini
            , km_fin
            , estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //GUARDAR GRUPO VEHICULO
        public void GuardarGrupoVehiculo(
            string grupo, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarGrupoVehiculo(grupo, obs
            , estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //GUARDAR MARCA VEHICULO
        public void GuardarMarcaVehiculo(
            string grupo, string marca, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarMarcaVehiculo(grupo, marca, obs
            , estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //GUARDAR MODELO VEHICULO
        public void GuardarModeloVehiculo(
            string marca, string modelo, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarModeloVehiculo(marca, modelo, obs
            , estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //ACTUALIZAR GRUPO VEHICULO
        public void ActualizarGrupoVehiculo(string id,
            string grupo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarGrupoVehiculo(id, grupo, obs
            , fec_mov, usedit);
        }

        //ACTUALIZAR MARCA VEHICULO
        public void ActualizarMarcaVehiculo(string id,
            string grupo, string marca, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarMarcaVehiculo(id, grupo, marca, obs
            , fec_mov, usedit);
        }

        //ACTUALIZAR MODELO VEHICULO
        public void ActualizarModeloVehiculo(string id,
            string marca, string modelo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarModeloVehiculo(id, marca, modelo, obs
            , fec_mov, usedit);
        }

        //GUARDAR MANTENIMIENTO PREVENTIVO
        public void GuardarMantenimientoVehiculos(string fecha,
            string emp, string sed, string area, string idveh
            , string kmInicial, string kmFinal, string difKm, string implemento
            , string cabezal, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarMantenimientoVehiculos(fecha,
            emp, sed, area, idveh
            , kmInicial, kmFinal, difKm, implemento
            , cabezal, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //GUARDAR MANTENIMIENTO CORRECTIVO
        public void GuardarMantenimientoCorrectivo(string fechaing, string fechasal,
            string emp, string sed, string idveh
            , string diasinop, string hrsinop, string km, string status, string sistema
            , string sustento, string tipo, string falla, string costo
            , string labor, string implemento
            , string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarMantenimientoCorrectivo(fechaing, fechasal,
            emp, sed, idveh
            , diasinop, hrsinop, km, status, sistema
            , sustento, tipo, falla, costo, labor, implemento
            , obs,
            estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //GUARDAR EFICIENCIA MAQUINARIA
        public void GuardarEficienciaMaquinaria(
              string emp, string sed, string fecha, string idveh
            , string turno, string operador, string cabezal
            , string labor, string implemento, string tipolabor
            , string obj_tancada, string HA, string GLNS
            , string km_ini, string km_fin
            , string Hor_ini_efe, string Hor_fin_efe
            , string Hor_ini, string Hor_fin, string Obj_aplicacion
            , string obs, string indicador, string sector
            , string descricpion, string estado
            , DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.GuardarEficienciaMaquinaria(emp, sed, fecha, idveh
            , turno, operador, cabezal
            , labor, implemento, tipolabor
            , obj_tancada, HA, GLNS
            , km_ini, km_fin
            , Hor_ini_efe, Hor_fin_efe
            , Hor_ini, Hor_fin, Obj_aplicacion
            , obs, indicador, sector
            , descricpion, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //GUARDAR EFICIENCIA MAQUINARIA
        public void ActualizarEficienciaMaquinaria(string id,
              string emp, string sed, string fecha, string idveh
            , string turno, string operador, string cabezal
            , string labor, string implemento, string tipolabor
            , string obj_tancada, string HA, string GLNS
            , string km_ini, string km_fin
            , string Hor_ini_efe, string Hor_fin_efe
            , string Hor_ini, string Hor_fin, string Obj_aplicacion
            , string obs, string indicador, string sector
            , string descricpion
            , DateTime fec_cre, int usereg)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarEficienciaMaquinaria(
                id, emp, sed, fecha, idveh
            , turno, operador, cabezal
            , labor, implemento, tipolabor
            , obj_tancada, HA, GLNS
            , km_ini, km_fin
            , Hor_ini_efe, Hor_fin_efe
            , Hor_ini, Hor_fin, Obj_aplicacion
            , obs, indicador, sector
            , descricpion, fec_cre, usereg);
        }



        //ACTUALIZAR MANTENIMIENTO CORRECTIVO
        public void ActualizarMantenimientoCorrectivo(string id,
            string fechaing, string fechasal,
            string emp, string sed, string idveh
            , string diasinop, string hrsinop, string km, string status, string sistema
            , string sustento, string tipo, string falla, string costo
            , string labor, string implemento
            , string obs, DateTime fec_mov, int usedit)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarMantenimientoCorrectivo(id, fechaing, fechasal,
            emp, sed, idveh
            , diasinop, hrsinop, km, status, sistema
            , sustento, tipo, falla, costo, labor, implemento
            , obs, fec_mov, usedit);
        }


        //GUARDAR LISTA VEHICULOS
        public void ActualizarMantenimientoVehiculos(string id
            , string fecha, string emp, string sed, string area, string idveh
            , string kmInicial, string kmFinal, string difKm, string implemento
            , string cabezal, DateTime fecedit, int useedit)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarMantenimientoVehiculos(
            id, fecha, emp, sed, area, idveh
            , kmInicial, kmFinal, difKm, implemento
            , cabezal, fecedit, useedit);
        }


        //ACTUALIZAR LISTA VEHICULOS
        public void ActualizarListaVehiculos(int id,
            string emp, string sed, string area, string placa
            , string tipovehiculo, string marca, string modelo, string responsable
            , string consumidor, string grupo, string nombre_maq, string potencia
            , DateTime fec_mov, int usedit)
        {
            cd_taller datos = new cd_taller();
            datos.ActualizarListaVehiculos(id, emp, sed, area, placa
            , tipovehiculo, marca, modelo, responsable
            , consumidor, grupo, nombre_maq, potencia
            , fec_mov, usedit);
        }

        //ELIMINAR VEHICULO
        public void EliminarListaVehiculo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarListaVehiculo(cod, fec_mov, useelim);
        }

        //ELIMINAR LISTA GRUPO VEHICULO
        public void EliminarGrupoVehiculo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarGrupoVehiculo(cod, fec_mov, useelim);
        }

        //ELIMINAR MARCA  VEHICULO
        public void EliminarMarcaVehiculo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarMarcaVehiculo(cod, fec_mov, useelim);
        }

        //ELIMINAR MODELO  VEHICULO
        public void EliminarModeloVehiculo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarModeloVehiculo(cod, fec_mov, useelim);
        }

        //ACTUALIZAR ELIMINAR MANTENIMIENTO PREVENTIVO
        public void EliminarListaMantPreventivo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarListaMantPreventivo(cod, fec_mov, useelim);
        }

        //ACTUALIZAR ELIMINAR ORDEN DE TRABAJO
        public void EliminarListaOrdenTrabajo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarListaOrdenTrabajo(cod, fec_mov, useelim);
        }

        //ACTUALIZAR ELIMINAR MANTENIMIENTO CORRECTIVO
        public void EliminarListaMantCorrectivo(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarListaMantCorrectivo(cod, fec_mov, useelim);
        }

        //ACTUALIZAR ELIMINAR EFICIENCIA
        public void EliminarListaEficiencia(string cod, DateTime fec_mov, int useelim)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarListaEficiencia(cod, fec_mov, useelim);
        }

        //ELIMINAR MANTENIMIENTO INSUMO
        public void EliminarMantenimientoInsumos(
            string grupo, string marca, string modelo, string km)
        {
            cd_taller datos = new cd_taller();
            datos.EliminarMantenimientoInsumos(
            grupo, marca, modelo, km);
        }

        //LISTA VEHICULO POR FILTRO
        //
        public static DataTable ListaVehiculo(string cod, string desc)
        {
            cd_taller datos = new cd_taller();
            return datos.ListaVehiculo(cod, desc);
        }


        //metodo para buscar si existe grupo
        public static bool BuscExisteGrupoVehiculo(string grupo)
        {
            cd_taller datos = new cd_taller();
            return datos.BuscExisteGrupoVehiculo(grupo);
        }

        //metodo para buscar si existe grupo y marca
        public static bool BuscExisteMarcaVehiculo(string grupo, string marca)
        {
            cd_taller datos = new cd_taller();
            return datos.BuscExisteMarcaVehiculo(grupo, marca);
        }

        //metodo para buscar si existe marca y modelo
        public static bool BuscExisteModeloVehiculo(string marca, string modelo)
        {
            cd_taller datos = new cd_taller();
            return datos.BuscExisteModeloVehiculo(marca, modelo);
        }

        //metodo para buscar si existe placa
        public static bool BuscExistePlacaVehiculo(string placa)
        {
            cd_taller datos = new cd_taller();
            return datos.BuscExistePlacaVehiculo(placa);
        }


    }

}