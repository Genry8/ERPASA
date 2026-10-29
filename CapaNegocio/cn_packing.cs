using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class cn_packing : cd_conexion
    {


        //
        // PESO POR PRESENTACION (PACK_PesoPresentacion)
        //
        public void GuardarPesoPresentacion(
            string emp, string sed, string cultivo, string presentacion
            , decimal peso, decimal porcentajemin, decimal porcentaje, string obs
            , string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarPesoPresentacion(emp, sed, cultivo, presentacion, peso, porcentajemin,
                porcentaje, obs, estado, fec_cre, usereg, hostname, fec_mov, usedit, useelim);
        }

        public void ActualizarPesoPresentacion(int id,
            string emp, string sed, string cultivo, string presentacion
            , decimal peso, decimal porcentajemin, decimal porcentaje, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarPesoPresentacion(id, emp, sed, cultivo, presentacion, peso,
                porcentajemin, porcentaje, obs, fec_mov, usedit);
        }

        public void EliminarPesoPresentacion(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarPesoPresentacion(id, fec_mov, useelim);
        }

        public static DataTable ListaReportePesoPresentacion(string emp, string sed, string cultivo)
        {
            cd_packing datos = new cd_packing();
            return datos.ListaReportePesoPresentacion(emp, sed, cultivo);
        }

        public static bool BuscExistePesoPresentacion(string emp, string sed, string cultivo,
            string presentacion, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExistePesoPresentacion(emp, sed, cultivo, presentacion, id);
        }



        //
        //maestro PACK_Cultivo
        public static DataTable ListaMaestroCultivo()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCultivo();
        }

        public void GuardarMaestroCultivo(string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCultivo(cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCultivo(int id, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCultivo(id, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCultivo(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCultivo(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCultivo(string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCultivo(cultivo, id);
        }

        //
        //maestro PACK_Campana
        public static DataTable ListaMaestroCampana()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCampana();
        }

        public void GuardarMaestroCampana(string campana, string descripcion, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCampana(campana, descripcion, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCampana(int id, string campana, string descripcion, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCampana(id, campana, descripcion, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCampana(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCampana(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCampana(string campana, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCampana(campana, id);
        }

        //
        //maestro PACK_Categoria
        public static DataTable ListaMaestroCategoria()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCategoria();
        }

        public void GuardarMaestroCategoria(string categoria, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCategoria(categoria, cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCategoria(int id, string categoria, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCategoria(id, categoria, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCategoria(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCategoria(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCategoria(string categoria, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCategoria(categoria, cultivo, id);
        }

        //
        //maestro PACK_Calibre
        public static DataTable ListaMaestroCalibre()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCalibre();
        }

        public void GuardarMaestroCalibre(string codcalibre, string calibre, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCalibre(codcalibre, calibre, cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCalibre(int id, string codcalibre, string calibre, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCalibre(id, codcalibre, calibre, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCalibre(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCalibre(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCalibre(string calibre, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCalibre(calibre, cultivo, id);
        }

        //
        //maestro PACK_Cabezal
        public static DataTable ListaMaestroCabezal()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCabezal();
        }

        public void GuardarMaestroCabezal(string cabezal, string cultivo, string sede, string ncorto, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCabezal(cabezal, cultivo, sede, ncorto, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCabezal(int id, string cabezal, string cultivo, string sede, string ncorto, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCabezal(id, cabezal, cultivo, sede, ncorto, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCabezal(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCabezal(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCabezal(string cabezal, string cultivo, string sede, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCabezal(cabezal, cultivo, sede, id);
        }

        //
        //maestro PACK_CabezalPT
        public static DataTable ListaMaestroCabezalPT()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCabezalPT();
        }

        public void GuardarMaestroCabezalPT(string codcab, string cabezal, string cultivo, string sede, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCabezalPT(codcab, cabezal, cultivo, sede, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCabezalPT(int id, string codcab, string cabezal, string cultivo, string sede, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCabezalPT(id, codcab, cabezal, cultivo, sede, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCabezalPT(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCabezalPT(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCabezalPT(string cabezal, string cultivo, string sede, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCabezalPT(cabezal, cultivo, sede, id);
        }

        //
        //maestro PACK_Camara
        public static DataTable ListaMaestroCamara()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCamara();
        }

        public void GuardarMaestroCamara(string camara, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCamara(camara, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCamara(int id, string camara, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCamara(id, camara, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCamara(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCamara(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCamara(string camara, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCamara(camara, id);
        }

        //
        //maestro PACK_CamaraFrio
        public static DataTable ListaMaestroCamaraFrio()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCamaraFrio();
        }

        public void GuardarMaestroCamaraFrio(string camarafrio, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCamaraFrio(camarafrio, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCamaraFrio(int id, string camarafrio, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCamaraFrio(id, camarafrio, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCamaraFrio(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCamaraFrio(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCamaraFrio(string camarafrio, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCamaraFrio(camarafrio, id);
        }

        //
        //maestro PACK_CamaraPreFrio
        public static DataTable ListaMaestroCamaraPreFrio()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCamaraPreFrio();
        }

        public void GuardarMaestroCamaraPreFrio(string camaraprefrio, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCamaraPreFrio(camaraprefrio, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCamaraPreFrio(int id, string camaraprefrio, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCamaraPreFrio(id, camaraprefrio, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCamaraPreFrio(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCamaraPreFrio(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCamaraPreFrio(string camaraprefrio, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCamaraPreFrio(camaraprefrio, id);
        }

        //
        //maestro PACK_CamaraGasificado
        public static DataTable ListaMaestroCamaraGasificado()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroCamaraGasificado();
        }

        public void GuardarMaestroCamaraGasificado(string camaragasificado, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroCamaraGasificado(camaragasificado, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroCamaraGasificado(int id, string camaragasificado, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroCamaraGasificado(id, camaragasificado, obs, fec_mov, usedit);
        }

        public void EliminarMaestroCamaraGasificado(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroCamaraGasificado(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroCamaraGasificado(string camaragasificado, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroCamaraGasificado(camaragasificado, id);
        }

        //
        //maestro PACK_Maquinaria
        public static DataTable ListaMaestroMaquinaria()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroMaquinaria();
        }

        public void GuardarMaestroMaquinaria(string maquina, string cultivo, string maqcorto, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroMaquinaria(maquina, cultivo, maqcorto, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroMaquinaria(int id, string maquina, string cultivo, string maqcorto, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroMaquinaria(id, maquina, cultivo, maqcorto, obs, fec_mov, usedit);
        }

        public void EliminarMaestroMaquinaria(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroMaquinaria(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroMaquinaria(string maquina, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroMaquinaria(maquina, cultivo, id);
        }

        //
        //maestro PACK_FilerMaquina
        public static DataTable ListaMaestroFilerMaquina()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroFilerMaquina();
        }

        public void GuardarMaestroFilerMaquina(string maquina, string filer, string cultivo, int ord, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroFilerMaquina(maquina, filer, cultivo, ord, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroFilerMaquina(int id, string maquina, string filer, string cultivo, int ord, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroFilerMaquina(id, maquina, filer, cultivo, ord, obs, fec_mov, usedit);
        }

        public void EliminarMaestroFilerMaquina(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroFilerMaquina(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroFilerMaquina(string maquina, string filer, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroFilerMaquina(maquina, filer, cultivo, id);
        }

        //
        //maestro PACK_Estilos
        public static DataTable ListaMaestroEstilos()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroEstilos();
        }

        public void GuardarMaestroEstilos(string style, string presentacion, string cultivo, string sede, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroEstilos(style, presentacion, cultivo, sede, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroEstilos(int id, string style, string presentacion, string cultivo, string sede, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroEstilos(id, style, presentacion, cultivo, sede, obs, fec_mov, usedit);
        }

        public void EliminarMaestroEstilos(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroEstilos(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroEstilos(string style, string cultivo, string sede, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroEstilos(style, cultivo, sede, id);
        }

        //
        //maestro PACK_EmpaqueProceso
        public static DataTable ListaMaestroEmpaqueProceso()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroEmpaqueProceso();
        }

        public void GuardarMaestroEmpaqueProceso(string empaque_proceso, string empresa, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroEmpaqueProceso(empaque_proceso, empresa, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroEmpaqueProceso(int id, string empaque_proceso, string empresa, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroEmpaqueProceso(id, empaque_proceso, empresa, obs, fec_mov, usedit);
        }

        public void EliminarMaestroEmpaqueProceso(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroEmpaqueProceso(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroEmpaqueProceso(string empaque_proceso, string empresa, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroEmpaqueProceso(empaque_proceso, empresa, id);
        }

        //
        //maestro PACK_TipoParihuela
        public static DataTable ListaMaestroTipoParihuela()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTipoParihuela();
        }

        public void GuardarMaestroTipoParihuela(string parihuela, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTipoParihuela(parihuela, cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTipoParihuela(int id, string parihuela, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTipoParihuela(id, parihuela, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTipoParihuela(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTipoParihuela(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTipoParihuela(string parihuela, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTipoParihuela(parihuela, cultivo, id);
        }

        //
        //maestro PACK_TipoPaLlet
        public static DataTable ListaMaestroTipoPaLlet()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTipoPaLlet();
        }

        public void GuardarMaestroTipoPaLlet(string tipopalet, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTipoPaLlet(tipopalet, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTipoPaLlet(int id, string tipopalet, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTipoPaLlet(id, tipopalet, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTipoPaLlet(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTipoPaLlet(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTipoPaLlet(string tipopalet, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTipoPaLlet(tipopalet, id);
        }

        //
        //maestro PACK_TipoMateria
        public static DataTable ListaMaestroTipoMateria()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTipoMateria();
        }

        public void GuardarMaestroTipoMateria(string tipomateria, string grupomateria, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTipoMateria(tipomateria, grupomateria, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTipoMateria(int id, string tipomateria, string grupomateria, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTipoMateria(id, tipomateria, grupomateria, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTipoMateria(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTipoMateria(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTipoMateria(string tipomateria, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTipoMateria(tipomateria, id);
        }

        //
        //maestro PACK_TipoCosecha
        public static DataTable ListaMaestroTipoCosecha()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTipoCosecha();
        }

        public void GuardarMaestroTipoCosecha(string tipocosecha, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTipoCosecha(tipocosecha, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTipoCosecha(int id, string tipocosecha, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTipoCosecha(id, tipocosecha, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTipoCosecha(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTipoCosecha(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTipoCosecha(string tipocosecha, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTipoCosecha(tipocosecha, id);
        }

        //
        //maestro PACK_TipoDefecto
        public static DataTable ListaMaestroTipoDefecto()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTipoDefecto();
        }

        public void GuardarMaestroTipoDefecto(string tipodefecto, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTipoDefecto(tipodefecto, cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTipoDefecto(int id, string tipodefecto, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTipoDefecto(id, tipodefecto, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTipoDefecto(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTipoDefecto(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTipoDefecto(string tipodefecto, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTipoDefecto(tipodefecto, cultivo, id);
        }

        //
        //maestro PACK_TipoCausaError
        public static DataTable ListaMaestroTipoCausaError()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTipoCausaError();
        }

        public void GuardarMaestroTipoCausaError(string causaerror, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTipoCausaError(causaerror, cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTipoCausaError(int id, string causaerror, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTipoCausaError(id, causaerror, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTipoCausaError(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTipoCausaError(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTipoCausaError(string causaerror, string cultivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTipoCausaError(causaerror, cultivo, id);
        }

        //
        //maestro PACK_MotivoParadas
        public static DataTable ListaMaestroMotivoParadas()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroMotivoParadas();
        }

        public void GuardarMaestroMotivoParadas(string codgrup, string grupo, string motivo, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroMotivoParadas(codgrup, grupo, motivo, cultivo, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroMotivoParadas(int id, string codgrup, string grupo, string motivo, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroMotivoParadas(id, codgrup, grupo, motivo, cultivo, obs, fec_mov, usedit);
        }

        public void EliminarMaestroMotivoParadas(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroMotivoParadas(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroMotivoParadas(string motivo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroMotivoParadas(motivo, id);
        }

        //
        //maestro PACK_Turno
        public static DataTable ListaMaestroTurno()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTurno();
        }

        public void GuardarMaestroTurno(string turno, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTurno(turno, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTurno(int id, string turno, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTurno(id, turno, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTurno(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTurno(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTurno(string turno, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTurno(turno, id);
        }

        //
        //maestro PACK_Transporte
        public static DataTable ListaMaestroTransporte()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroTransporte();
        }

        public void GuardarMaestroTransporte(string transporte, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroTransporte(transporte, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroTransporte(int id, string transporte, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroTransporte(id, transporte, obs, fec_mov, usedit);
        }

        public void EliminarMaestroTransporte(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroTransporte(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroTransporte(string transporte, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroTransporte(transporte, id);
        }

        //
        //maestro PACK_EstadoPT
        public static DataTable ListaMaestroEstadoPT()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaMaestroEstadoPT();
        }

        public void GuardarMaestroEstadoPT(string cod, string estado, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarMaestroEstadoPT(cod, estado, obs, fec_cre, usereg, hostname);
        }

        public void ActualizarMaestroEstadoPT(int id, string cod, string estado, string obs
            , DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarMaestroEstadoPT(id, cod, estado, obs, fec_mov, usedit);
        }

        public void EliminarMaestroEstadoPT(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarMaestroEstadoPT(id, fec_mov, useelim);
        }

        public static bool BuscExisteMaestroEstadoPT(string cod, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteMaestroEstadoPT(cod, id);
        }

        public static DataTable ListaCultivo()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaCultivo();
        }

        public static DataTable ListaNave()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaNave();
        }

        public static DataTable ListaLinea()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaLinea();
        }


        public static DataTable ListaPuestoTrabajo()
        {
            cd_packing datos = new cd_packing();
            return datos.ListaPuestoTrabajo();
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

        public static DataTable ListaFiltroMaquinariaFiler(string maq)
        {
            cd_packing datos = new cd_packing();
            return datos.ListaFiltroMaquinariaFiler(maq);
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
            , string cultivo, DateTime fechaIni, DateTime fechaFin)
        {
            cd_packing datos = new cd_packing();
            return datos.EliminarOrdenPRD(emp, sed, cultivo, fechaIni, fechaFin);
        }

        public static bool EliminarOrdenPRD_AR(string emp, string sed
            , string cultivo, DateTime fechaIni, DateTime fechaFin)
        {
            cd_packing datos = new cd_packing();
            return datos.EliminarOrdenPRD_AR(emp, sed, cultivo, fechaIni, fechaFin);
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

        // GUARDAR ORDEN PRODUCCIÓN AR
        public void GuardarOrdenPRD_AR(
            string fechaini,
            string fechafin,
            string cultivo,
            string campana,
            string emp,
            string sed,
            string año,
            string sem,
            string exportador,
            string cliente,
            string prioridad,
            string orden,
            string destino,
            string calidadVia,
            string tecnologia,
            string ac,
            string packStyle,
            string variedad,
            string restCabezal,
            string calibre,
            string equivPalets,
            string fechaDespacho,
            string obs,
            string hoja,
            string estado,
            DateTime fec_cre,
            int usereg,
            string hostname,
            DateTime fec_mov,
            int usedit,
            int useelim)
        {
            cd_packing datos = new cd_packing();

            datos.GuardarOrdenPRD_AR(
                fechaini,
                fechafin,
                cultivo,
                campana,
                emp,
                sed,
                año,
                sem,
                exportador,
                cliente,
                prioridad,
                orden,
                destino,
                calidadVia,
                tecnologia,
                ac,
                packStyle,
                variedad,
                restCabezal,
                calibre,
                equivPalets,
                fechaDespacho,
                obs,
                hoja,
                estado,
                fec_cre,
                usereg,
                hostname,
                fec_mov,
                usedit,
                useelim
            );
        }



        //GUARDAR ACTUALIZAR PROGRAMACION VOLCADO
        public void GuardarActualizarProgVolcado(
            string prog, string idRec, string numPalet
            , string fecProg, string turno, string maq, string linea
            , string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarActualizarProgVolcado(
                prog, idRec, numPalet
            , fecProg, turno, maq, linea
            , obs, estado, fec_cre, usereg, hostname
            , fec_mov, usedit, useelim);
        }

        //GUARDAR ACTUALIZAR PROGRAMACION PRESENTACION
        public void GuardarActualizarProgPresentacion(
            string empresa, string sede, string fecProg
            , string cultivo, string maq, string turno, string linea
            , string presentacion, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarActualizarProgPresentacion(
            empresa, sede, fecProg
            , cultivo, maq, turno, linea
            , presentacion, obs, estado, fec_cre
            , usereg, hostname
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


        public static DataTable ListaGuiaPallet(int id, DateTime fecini, DateTime fecfin
            , string emp, string sed, string Cultivo)
        {
            cd_packing datos = new cd_packing();
            return datos.ListaGuiaPallet(id, fecini, fecfin, emp, sed, Cultivo);
        }


        //GUARDAR CIERRE PROCESO DIA
        public void GuardarCierreProcesoPacking(
            int id, DateTime fechaproc, bool status
            , string idnave, string nave
            , string idlinea, string linea, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim, string sesion)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarCierreProcesoPacking(
                id, fechaproc, status
            , idnave, nave
            , idlinea, linea, obs, estado, fec_cre
            , usereg, hostname
            , fec_mov, usedit, useelim, sesion);
        }


        public static DataTable ReporteCierreProcesoPacking(int id,
            DateTime fecini)
        {
            cd_packing datos = new cd_packing();
            return datos.ReporteCierreProcesoPacking(id, fecini);
        }


        public void GuardarReqPersonalSemanalBulk(DataTable dt)
        {
            cd_packing datos = new cd_packing();

            datos.GuardarReqPersonalSemanalBulk(dt);
        }


        public void GuardarReqPersonalAnualBulk(DataTable dt)
        {
            cd_packing datos = new cd_packing();

            datos.GuardarReqPersonalAnualBulk(dt);
        }




        //
        // CONFIGURACION DE CORREOS (PACK_EnviarCorreo)
        //
        public void GuardarEnviarCorreo(
            DateTime fecha, string emp, string sed, string gerencia, string area,
            string responsable, string formulario, string tipocorreo,
            string de, string para, string cc, string asunto, string cuerpo, string uuid,
            DateTime fec_cre, int usereg, string hostname)
        {
            cd_packing datos = new cd_packing();
            datos.GuardarEnviarCorreo(fecha, emp, sed, gerencia, area, responsable,
                formulario, tipocorreo, de, para, cc, asunto, cuerpo, uuid,
                fec_cre, usereg, hostname);
        }

        public void ActualizarEnviarCorreo(int id,
            DateTime fecha, string emp, string sed, string gerencia, string area,
            string responsable, string formulario, string tipocorreo,
            string de, string para, string cc, string asunto, string cuerpo, string uuid,
            DateTime fec_mov, int usedit)
        {
            cd_packing datos = new cd_packing();
            datos.ActualizarEnviarCorreo(id, fecha, emp, sed, gerencia, area, responsable,
                formulario, tipocorreo, de, para, cc, asunto, cuerpo, uuid,
                fec_mov, usedit);
        }

        public void EliminarEnviarCorreo(int id, DateTime fec_mov, int useelim)
        {
            cd_packing datos = new cd_packing();
            datos.EliminarEnviarCorreo(id, fec_mov, useelim);
        }

        public static DataTable ListaReporteEnviarCorreo(string emp, string sed)
        {
            cd_packing datos = new cd_packing();
            return datos.ListaReporteEnviarCorreo(emp, sed);
        }

        public static bool BuscExisteEnviarCorreo(string emp, string sed, string formulario,
            string tipocorreo, int id)
        {
            cd_packing datos = new cd_packing();
            return datos.BuscExisteEnviarCorreo(emp, sed, formulario, tipocorreo, id);
        }

    }
}
