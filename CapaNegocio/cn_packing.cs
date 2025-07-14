using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_packing : cd_conexion
    {

        public static DataTable ListaCultivo()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaCultivo();
        }

        public static DataTable ListaCampana()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaCampana();
        }


        public static DataTable ListaTipoMerma()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaTipoMerma();
        }

        public static DataTable ListaTipoMaquinaria()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaTipoMaquinaria();
        }

        public static DataTable ListaPackingTurno()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaPackingTurno();
        }

        public static DataTable ListaTipoMaquinariaCultivo(string cultivo)
        {
            cd_packing datos = new cd_packing();
            return datos.ListaTipoMaquinariaCultivo(cultivo);
        }

        public static DataTable ListaMaquinariaFiler()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaquinariaFiler();
        }


        public static DataTable ListaVariedad()
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaVariedad();
        }

        public static DataTable ListaVariedadCultivo(string cultivo)
        {
            cd_nisira datos = new cd_nisira();
            return datos.ListaVariedadCultivo(cultivo);
        }

        //metodo para buscar si existe merma
        public static bool BuscExisteMerma(string emp, string sed, DateTime fecha, string tipoeva)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMerma(emp, sed, fecha, tipoeva);
        }

        //metodo para buscar si existe orden
        public static bool BuscExisteOrdenPRD(string emp, string sed
            , DateTime fechaIni, DateTime fechaFin)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteOrdenPRD(emp, sed, fechaIni, fechaFin);
        }
        //metodo para eliminar orden
        public static bool EliminarOrdenPRD(string emp, string sed
            , DateTime fechaIni, DateTime fechaFin)
        {
            cd_packing datos = new cd_packing();
            return datos.EliminarOrdenPRD(emp, sed, fechaIni, fechaFin);
        }

        //metodo para buscar si existe presentacion
        public static bool BuscExistePresentacion(string emp, string sed
            , string presentacion)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExistePresentacion(emp, sed, presentacion);
        }


        //GUARDAR MERMA
        public void GuardarMerma(DateTime fechaproc, DateTime fechacos, string tipomateria
            , string emp, string sed, string cultivo, string campana, string maquina, string varieddad
            , decimal pesobruto, decimal pesotara, decimal pesoneto
            , string obs, string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMerma(fechaproc, fechacos, tipomateria
            , emp, sed, cultivo, campana
            , maquina, varieddad, pesobruto, pesotara, pesoneto
            , obs, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //GUARDAR ORDEN PRODUCCION
        public void GuardarOrdenPRD(string fechaini, string fechafin, string cultivo
            , string campana, string emp, string sed, string año, string sem
            , string num_cont, string prioridad, string orden, string cliente
            , string destino, string presentacion, string comentario, string calidad
            , string calibre, string timbrado, string cajas, string pallets, string FechaDespacho
            , string obs, string hoja, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarOrdenPRD(fechaini, fechafin, cultivo
            , campana, emp, sed, año, sem
            , num_cont, prioridad, orden, cliente
            , destino, presentacion, comentario, calidad
            , calibre, timbrado, cajas, pallets, FechaDespacho
            , obs, hoja, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //GUARDAR ACTUALIZAR PROGRAMACION VOLCADO
        public void GuardarActualizarProgVolcado(
            string prog, string idRec, string numPalet
            , string fecProg,string turno, string maq, string linea
            , string obs,string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarActualizarProgVolcado(
                prog, idRec, numPalet
            , fecProg,turno, maq, linea
            , obs, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //metodo buscar palet
        public static bool BuscarPaletProgVolcado(string id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscarPaletProgVolcado(id);
        }

        //GUARDAR PRESENTACION
        public void GuardarPresentacion(string cod, string emp, string sed
            , string cultivo, string presentacion, decimal peso, string cajas
            , string comentario, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarPresentacion(cod, emp, sed
            , cultivo, presentacion, peso, cajas
            , comentario, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }


        //ACTUALIZAR MERMA
        public void ActualizarMerma(int cod, string tipomateria
            , string maquina, string varieddad, decimal pesoneto
            , string obs, DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMerma(cod, tipomateria
            , maquina, varieddad, pesoneto
            , obs, fec_mov, usedit);
        }


        //ACTUALIZAR ORDEN PRODUCCION
        public void ActualizarOrdenPRD(int cod, string numcont
            , string prioridad, string orden, string cliente
            , string destino, string presentacion, string calibre
            , string cajas, string pallets
            , string obs, DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarOrdenPRD(cod, numcont
            , prioridad, orden, cliente
            , destino, presentacion, calibre
            , cajas, pallets
            , obs, fec_mov, usedit);
        }

        //ACTUALIZAR PRESENTACION
        public void ActualizarPresentacion(int cod, string codpres
            , string presentacion
            , decimal peso, string cajas
            , string obs, DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarPresentacion(cod, codpres, presentacion, peso
            , cajas
            , obs, fec_mov, usedit);
        }


        //ACTUALIZAR ELIMINAR MERMA
        public void EliminarMerma(string cod, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMerma(cod, fec_mov, useelim);
        }


        //ACTUALIZAR ELIMINAR ORDEN
        public void EliminarOrdenPRD(string cod, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarOrdenPRD(cod, fec_mov, useelim);
        }


        //ACTUALIZAR ELIMINAR PRESENTACION
        public void EliminarPresentacion(string cod, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarPresentacion(cod, fec_mov, useelim);
        }

    }
}
