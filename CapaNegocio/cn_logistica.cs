using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_logistica : cd_conexion
    {
        //metodo para listar talla para agregar
        public static DataTable ListaTallProd()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaTallaProducto();
        }


        //metodo para listar grupo para agregar
        public static DataTable ListaGrupoProd()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaGrupoProducto();
        }

        //metodo para listar tipo para agregar
        public static DataTable ListaTipoProd()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaTipoProducto();
        }

        //metodo para listar grupo para agregar
        public static DataTable ListaEmpresaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaEmpresaTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodEmpresaMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoEmpresaMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodEmpresa(string codemp)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoEmpresa(codemp);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaSedeTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaSedeTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodSedeMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoSedeMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodSede(string codsede)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoSede(codsede);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaGerenciaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaGerenciaTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodGerenciaMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoGerenciaMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodGerencua(string codger)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoGerencia(codger);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaAreaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAreaTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodAreaMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoAreaMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodArea(string codArea)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoArea(codArea);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaEstActivoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaEstActivoTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodEstActivoMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoEstActivoMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodEstActivo(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoEstActivo(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaSisOperativoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaSisOperativoTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodSisOperativoMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoSisOperativoMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodSisOperativo(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoSisOperativo(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaMemoriaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaMemoriaTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodMemoriaMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoMemoriaMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodMemoria(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoMemoria(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaMarcaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaMarcaTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodMarcaTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoMarcaTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodMarcaTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoMarcaTI(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaOrigenActTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaOrigenActTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodOrigenActTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoOrigenActTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodOrigenActTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoOrigenActTI(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaProcesadorTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaProcesadorTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodProcesadorTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoProcesadorTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodProcesadorTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoProcesadorTI(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaDiscoDuroTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaDiscoDuroTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodDiscoDuroTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoDiscoDuroTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodDiscoDuroTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoDiscoDuroTI(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaModeloTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaModeloTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodModeloTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoModeloTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodModeloTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoModeloTI(cod);
        }

        //metodo para listar marca para agregar
        public static DataTable ListaTipoActivoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaTipoActivoTI();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodTipoActivoTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoTipoActivoTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodTipoActivoTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoTipoActivoTI(cod);
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodProveedorTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoProveedorTIMas();
        }


        //metodo para listar Plan Movil
        public static DataTable ListaPlanMovilTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPlanMovilTI();
        }

        //metodo para buscar ultimo codigo de Plan Movil +1
        public static bool BuscUltimoCodPlanMovilTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoPlanMovilTIMas();
        }

        //metodo para buscar si existe codigo de Plan Movil
        public static bool BuscExisteCodPlanMovilTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoPlanMovilTI(cod);
        }

        //metodo para listar activo
        //public static DataTable ListaActivoFiltroTI()
        //{
        //    cd_logistica datos = new cd_logistica();
        //    return datos.ListaActivoFiltroTI();

        //}
        //metodo para listar activo
        public static DataTable ListaActivoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoTI();
        }

        //metodo para buscar ultimo codigo de Plan Movil +1
        public static bool BuscUltimoCodActivoTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoActivoTIMas();
        }

        //metodo para buscar si existe codigo de Plan Movil
        public static bool BuscExisteCodActivoTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoActivoTI(cod);
        }

        public static bool BuscExisteCodActivoTIS(string cod, string serie)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoActivoTIS(cod, serie);
        }

        //metodo para buscar si existe codigo de Plan Movil
        public static bool BuscExisteCodActivoPerTI(string cod, string codper)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoActivoPerTI(cod, codper);
        }

        //metodo para buscar si existe codigo de Plan Movil
        public static bool BuscExisteCodActivoPerEstTI(string cod, string codper)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoActivoPerEstTI(cod, codper);
        }

        //metodo para listar Asignacion
        public static DataTable ListaAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionTI();
        }

        //metodo para buscar ultimo codigo de Asignacion +1
        public static bool BuscUltimoCodAsignacionTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoAsignacionTIMas();
        }

        //metodo para buscar si existe codigo de Asignacion
        public static bool BuscExisteCodAsignacionTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoAsignacionTI(cod);
        }

        //metodo para buscar si existe codigo de Plan Movil
        public static bool BuscExisteCodAsignacionActivoTI(string cod, int item)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoAsignacionActivoTI(cod, item);
        }

        //
        //METODO PARA LISTAR ASIGANCION GENERAL
        //

        //metodo para listar filtros
        public static DataTable ListaAsignacionFiltroTI(string emp, string sed, string ger, string area, string dni, string user, string activo
            , string estact, string origen, string marca, string modelo, string serie, string imei, string macether, string macwifi)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionFiltroTI(emp, sed, ger, area, dni, user, activo
            , estact, origen, marca, modelo, serie, imei, macether, macwifi);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionEmpTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionEmpTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionSedeTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionSedeTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionGerenciaTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionGerenciaTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionAreaTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionAreaTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionDniTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionDniTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionUsuarioTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionUsuarioTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionActivoTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionActivoTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionEstadoActivoTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionEstActivoTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionOrigenBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionOrigenBuscTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionMarcaBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionMarcaBuscTI(desc);
        }


        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionModeloBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionModeloBuscTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionSerieBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionSerieBuscTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionImeiBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionImeiBuscTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionMacEtherBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionMacEtherBuscTI(desc);
        }

        //metodo para listar Asignacion empresa
        public static DataTable ListaAsignacionMacWifiBuscTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionMacWifiBuscTI(desc);
        }

        //
        //metodo para listar Asignacion BUSCQUEDA
        public static DataTable ListaAsignacionBuscTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionBuscTI();
        }

        //LISTA PERIFERICO POR FILTRO
        //
        public static DataTable ListaAsignacionFiltroTI(string desc, string marca, string modelo
            , string serie, string imei, string macether, string macwifi)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionFiltroTI(desc, marca, modelo
            , serie, imei, macether, macwifi);
        }

        //
        //LISTA PERIFERICO POR DESCRIPCION
        //
        public static DataTable ListaAsignacionDescripcionTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionDescripcionTI(desc);
        }

        //LISTA PERIFERICO POR MODELO
        public static DataTable ListaAsignacionMarcaTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionMarcaTI(desc);
        }

        //LISTA PERIFERICO POR MODELO
        public static DataTable ListaAsignacionModeloTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionModeloTI(desc);
        }

        //LISTA PERIFERICO POR SERIE
        public static DataTable ListaAsignacionSerieTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionSerieTI(desc);
        }
        //LISTA PERIFERICO POR IMEI
        public static DataTable ListaAsignacionIMEITI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionIMEITI(desc);
        }

        //LISTA PERIFERICO POR SERIE
        public static DataTable ListaAsignacionMacEtherTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionMacEtherTI(desc);
        }
        //LISTA PERIFERICO POR IMEI
        public static DataTable ListaAsignacionMacWifiTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAsignacionMacWifiTI(desc);
        }

        //
        // EQUIPOS TI
        //

        //metodo para listar marca para agregar
        public static DataTable ListaPerifericoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPerifericoTI();
        }

        //metodo para agregar
        public static DataTable ListaPerifericoActTI(string des)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPerifericoActTI(des);
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodPerifericoTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoPerifericoTIMas();
        }

        //metodo para buscar si existe codigo de color
        public static bool BuscExisteCodPerifericoTI(string cod)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoPerifericoTI(cod);
        }

        //LISTAR PERSONAL
        public static DataTable ListaPersonalTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalTI();
        }

        public static DataTable ListaPersonalDniTI(string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalDniTI(dni);
        }

        public static bool ListaPersonalExistenteTI(string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalExistenteTI(dni);
        }

        public void ElimPersonalDniTI(string dni)
        {
            cd_logistica datos = new cd_logistica();
            datos.eliminarPersonalDniTI(dni);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigTI();
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigDniTI(string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigDniTI(dni);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigApeTI(string ape)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigApeTI(ape);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigNomTI(string nom)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigNomTI(nom);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigAreaTI(string area)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigAreaTI(area);
        }

        //
        //ST LISTA PERSONAL
        //

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigST()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigST();
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigDniST(string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigDniST(dni);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigApeST(string ape)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigApeST(ape);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigNomST(string nom)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigNomST(nom);
        }

        //metodo para listar busqueda de personal
        public static DataTable ListaPersonalAsigAreaST(string area)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPersonalAsigAreaST(area);
        }

        //
        //LISTA PERIFERICO POR DESCRIPCION
        //
        public static DataTable ListaPerifericoDescripcionTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPerifericoDescripcionTI(desc);
        }
        //LISTA PERIFERICO POR SERIE
        public static DataTable ListaPerifericoSerieTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPerifericoSerieTI(desc);
        }
        //LISTA PERIFERICO POR IMEI
        public static DataTable ListaPerifericoIMEITI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPerifericoIMEITI(desc);
        }
        //LISTA PERIFERICO POR MODELO
        public static DataTable ListaPerifericoModeloTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaPerifericoModeloTI(desc);
        }

        //
        //DATOS PARA BUSCAR ACTIVOS POR FILTRO
        //

        //LISTA ACTIVO POR ACTIVO
        public static DataTable ListaActivoActivoTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoActivoTI(desc);
        }

        //LISTA ACTIVO POR ORIGEN
        public static DataTable ListaActivoOrigenTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoOrigenTI(desc);
        }

        //LISTA ACTIVO POR PROCESADOR
        public static DataTable ListaActivoProcesadorTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoProcesadorTI(desc);
        }

        //LISTA ACTIVO POR MEMORIA
        public static DataTable ListaActivoMemoriaTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoMemoriaTI(desc);
        }

        //LISTA ACTIVO POR MARCA
        public static DataTable ListaActivoMarcaTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoMarcaTI(desc);
        }

        //LISTA ACTIVO POR MODELO
        public static DataTable ListaActivoModeloTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoModeloTI(desc);
        }

        //LISTA ACTIVO POR SERIE
        public static DataTable ListaActivoSerieTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoSerieTI(desc);
        }

        //LISTA ACTIVO POR IMEI
        public static DataTable ListaActivoImeiTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoImeiTI(desc);
        }

        //LISTA ACTIVO POR MAC ETHERNET
        public static DataTable ListaActivoMacEthernetTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoMacEthernetTI(desc);
        }

        //LISTA ACTIVO POR MAC WIFI
        public static DataTable ListaActivoMacWifiTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoMacWifiTI(desc);
        }

        //LISTA ACTIVO POR MAC EQUIPO
        public static DataTable ListaActivoMacEquipoTI(string desc)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaActivoMacEquipoTI(desc);
        }

        //
        //LISTA PARA CARGAR COMBOX
        //

        //metodo para listar la condicion de producto
        public static DataTable ListaGerencia()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaGerencia();
        }



        //metodo para listar la condicion de producto
        public static DataTable ListaCBTipoActivoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBTipoActivoTI();
        }

        //metodo para listar la condicion de producto
        public static DataTable ListaCBTipoActivoTI2()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBTipoActivoTI2();
        }

        //metodo para listar
        public static DataTable ListaCBOrigenActivoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBOrigenActivoTI();
        }

        //metodo para listar
        public static DataTable ListaCBSisOperativoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBSisOperativoTI();
        }

        //metodo para listar
        public static DataTable ListaCBProcesadorTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBProcesadorTI();
        }

        //metodo para listar
        public static DataTable ListaCBMemoriaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBMemoriaTI();
        }

        //metodo para listar
        public static DataTable ListaCBDiscoDuroTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBDiscoDuroTI();
        }

        //metodo para listar
        public static DataTable ListaCBMarcaTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBMarcaTI();
        }

        //metodo para listar
        public static DataTable ListaCBModeloTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBModeloTI();
        }

        //metodo para listar
        public static DataTable ListaCBProveedorTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBProveedorTI();
        }

        //metodo para listar
        public static DataTable ListaCBCabezal()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBCabezal();
        }

        //metodo para listar
        public static DataTable ListaCBPlanMovilTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBPlanMovilTI();
        }

        //
        //COMBO BOX DE ASIGNACION
        //

        //metodo para listar la condicion de producto
        public static DataTable ListaCBEmpresaAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBEmpresaAsignacionTI();
        }
        public static DataTable ListaCBEmpresaComedor()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBEmpresaComedor();
        }
        //metodo para listar area
        public static DataTable ListaCBAreaComedor()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBAreaComedor();
        }

        //metodo para listar sede comecodr
        public static DataTable ListaSedeComedor()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaSedeComedor();
        }

        //metodo para listar sede comecodr
        public static DataTable ListaTipoPersonal()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaTipoPersonal();
        }

        //metodo para listar sede comedor por empresa
        public static DataTable ListaSedeComedorEmpresa(string emp, string personal)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaSedeComedorEmpresa(emp, personal);
        }
        public static DataTable ListaCBEmpresaTodoAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBEmpresaTodoAsignacionTI();
        }
        public static DataTable ListaTransportistas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaTransportistas();
        }
        public static DataTable ListaCBFundo()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBFundo();
        }

        //metodo para listar
        public static DataTable ListaCBSedeAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBSedeAsignacionTI();
        }

        public static DataTable ListaCBSedeTodoAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBSedeTodoAsignacionTI();
        }


        //metodo para listar sede empresa
        public static DataTable ListaCBSedeEmpresaAsignacionTI(string empresa)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBSedeEmpresaAsignacionTI(empresa);
        }

        public static DataTable ListaCBSedeEmpresaTodoAsignacionTI(string empresa)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBSedeEmpresaTodoAsignacionTI(empresa);
        }

        //metodo para listar
        public static DataTable ListaCBAreaAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBAreaAsignacionTI();
        }

        public static DataTable ListaCBAreaTodoAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBAreaTodoAsignacionTI();
        }

        public static DataTable ListaCBAreaTodoInspeccionSST()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBAreaTodoInspeccionSST();
        }

        //metodo para listar
        public static DataTable ListaCBTipoActAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBTipoActAsignacionTI();
        }

        //metodo para listar estado activo
        public static DataTable ListaCBEstActivoAsignacionTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBEstActivoAsignacionTI();
        }

        //metodo para listar cargo
        public static DataTable ListaCBEstCargoTI()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaCBEstCargoTI();
        }
























        //metodo para listar almacen para agregar
        public static DataTable ListaAlmacenProd()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaAlmacenProducto();
        }

        //metodo para listar proveedor para agregar
        public static DataTable ListaProveedorProd()
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaProveedorProducto();
        }

        //metodo para buscar si existe codigo de talla
        public static bool BuscExisteCodTall(string codtalla)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoTalla(codtalla);
        }

        //metodo para buscar si existe codigo de talla
        public static bool BuscExisteCodMarc(string codmarca)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoMarca(codmarca);
        }

        //metodo para buscar si existe codigo de talla
        public static bool BuscExisteCodGroup(string codgrupo)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoGrupo(codgrupo);
        }

        //metodo para buscar si existe codigo de tipo
        public static bool BuscExisteCodTipo(string codtipo)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoTipo(codtipo);
        }



        //metodo para buscar si existe codigo de almacen
        public static bool BuscExisteCodAlm(string codalmacen)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoAlm(codalmacen);
        }

        //metodo para buscar si existe codigo de proveedor
        public static bool BuscExisteCodProv(string codaprov)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodigoProveedor(codaprov);
        }

        //metodo para buscar ultimo codigo de talla +1
        public static bool BuscUltimoCodTallMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoTallaMas();
        }

        //metodo para buscar ultimo codigo de marca +1
        public static bool BuscUltimoCodMarcaMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoMarcaMas();
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodGrupoMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoGrupoMas();
        }

        //metodo para buscar ultimo codigo de tipo +1
        public static bool BuscUltimoCodTipoMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoTipoMas();
        }


        //metodo para buscar ultimo codigo de proveedor +1
        public static bool BuscUltimoCodProvMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodigoProveedorMas();
        }


        //metodo para guardar talla 
        public void GuardTalla(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarTalla(codigo, descripcion, comentario, estado
                , fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para actualizar talla 
        public void ActuaTalla(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarTalla(codigo, descripcion, comentario, estado
                , fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para eliminar talla 
        public void EliminTall(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarTalla(codigo);
        }

        //metodo para guardar marca 
        public void GuardMarca(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarMarca(codigo, descripcion, comentario, estado
                , fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para actualizar marca 
        public void ActuaMarca(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarMarca(codigo, descripcion, comentario, estado
                , fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para eliminar marca 
        public void EliminMarc(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarMarca(codigo);
        }

        //metodo para guardar grupo 
        public void GuardGroup(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarGrupo(codigo, descripcion, comentario, estado
                , fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para actualizar grupo 
        public void ActuaGroup(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarGrupo(codigo, descripcion, comentario, estado
                , fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para eliminar grupo 
        public void EliminGroup(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarGrupo(codigo);
        }

        //metodo para guardar TIPO 
        public void GuardTipo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarTipo(codigo, descripcion, comentario, estado
                , fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para actualizar TIPO 
        public void ActuaTipo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string abrund)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarTipo(codigo, descripcion, comentario, estado
                , fec_mov, usereg, usenamreg, hostname, ip_pc, abrund);
        }

        //metodo para eliminar TIPO 
        public void EliminTipo(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarTipo(codigo);
        }

        //metodo para guardar EMPRESA 
        public void GuardEmpresa(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarEmpresa(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar EMPRESA 
        public void ActuaEmpresa(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarEmpresa(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar EMPRESA 
        public void EliminEmpresa(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarEmpresa(codigo);
        }

        //metodo para guardar SEDE 
        public void GuardSede(string codigo, string descripcion, string empresa, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarSede(codigo, descripcion, empresa, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar SEDE 
        public void ActuaSede(string codigo, string descripcion, string empresa, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarSede(codigo, descripcion, empresa, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar SEDE 
        public void EliminSede(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarSede(codigo);
        }

        //metodo para guardar GERENCIA 
        public void GuardGerencia(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarGerencia(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaGerencia(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarGerencia(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminGerencia(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarArea(codigo);
        }

        //metodo para guardar AREA
        public void GuardArea(string codigo, string descripcion, string CodGer, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarArea(codigo, descripcion, CodGer, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaArea(string codigo, string descripcion, string CodGer, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarArea(codigo, descripcion, CodGer, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminArea(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarArea(codigo);
        }

        //metodo para guardar AREA
        public void GuardEstActivo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarEstActivo(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaEstActivo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarEstActivo(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminEstActivo(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarEstActivo(codigo);
        }

        //metodo para guardar AREA
        public void GuardSisOperativo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarSisOperativo(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaSisOperativo(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarSisOperativo(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminSisOperativo(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarSisOperativo(codigo);
        }

        //metodo para guardar AREA
        public void GuardMemoria(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarMemoria(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaMemoria(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarMemoria(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminMemoria(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarMemoria(codigo);
        }

        //metodo para guardar AREA
        public void GuardMarcaTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarMarcaTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaMarcaTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarMarcaTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminMarcaTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarMarcaTI(codigo);
        }

        //metodo para guardar AREA
        public void GuardOrigenActTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarOrigenActTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaOrigenActTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarOrigenActTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminOrigenActTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarOrigenActTI(codigo);
        }

        //metodo para guardar AREA
        public void GuardProcesadorTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarProcesadorTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaProcesadorTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarProcesadorTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminProcesadorTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarProcesadorTI(codigo);
        }

        //metodo para guardar AREA
        public void GuardDiscoDuroTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarDiscoDuroTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaDiscoDuroTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarDiscoDuroTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminDiscoDuroTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarDiscoDuroTI(codigo);
        }

        //Modelo
        //metodo para guardar 
        public void GuardModeloTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarModeloTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaModeloTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarModeloTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminModeloTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarModeloTI(codigo);
        }

        //Modelo
        //metodo para guardar 
        public void GuardTipoActivoTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarTipoActivoTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaTipoActivoTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarTipoActivoTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminTipoActivoTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarTipoActivoTI(codigo);
        }

        //metodo para guardar 
        public void GuardPlanMovilTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarPlanMovilTI(codigo, descripcion, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaPlanMovilTI(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPlanMovilTI(codigo, descripcion, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminPlanMovilTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarPlanMovilTI(codigo);
        }

        //
        //EQUIPO TI Periferico
        //

        //metodo para guardar 
        public void GuardPerifericoTI(string codigo, string descripcion, string serie, string imei, string modelo, string comentario, string estado
            , DateTime fec_cre, string usereg, string hostname, DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarPerifericoTI(codigo, descripcion, serie, imei, modelo, comentario, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar GERENCIA 
        public void ActuaPerifericoTI(string codigo, string descripcion, string serie, string imei, string modelo, string comentario, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPerifericoTI(codigo, descripcion, serie, imei, modelo, comentario, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar GERENCIA 
        public void EliminPerifericoTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarPerifericoTI(codigo);
        }


        //metodo para actualizar GERENCIA 
        public void ActuaActPerifericoTI(string codigo, string descripcion, string estado
            , DateTime fec_edit, string useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarActPerifericoTI(codigo, descripcion, estado
            , fec_edit, useedit);
        }


        //
        //METODO PARA GUARDAR ACTIVO
        //

        //metodo para guardar ACTIVO
        public void GuardActivoTI(string codigo, string descripcion, string estact, string codorg, string codsisope, string codproc, string codmem, string codDD
            , string codmar, string codmod, string codprv, string numord, string numcel, string plan, string serie, string imei, string macether
            , string macwifi, string macequipo, DateTime feccom, DateTime fecgar, string obs1, string obs2, string estado
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarActivoTI(codigo, descripcion, estact, codorg, codsisope, codproc, codmem, codDD
            , codmar, codmod, codprv, numord, numcel, plan, serie, imei, macether
            , macwifi, macequipo, feccom, fecgar, obs1, obs2, estado
            , fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para guardar ACTIVO
        public static DataTable GuardActivoPerTI(string codigo, int item, string codper, string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            return datos.GuardarActivoPerTI(codigo, item, codper, estado, fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar ACTIVO 
        public void ActuaActivoTI(string codigo, string descripcion, string estact, string codorg, string codsisope, string codproc, string codmem, string codDD
            , string codmar, string codmod, string codprv, string numord, string numcel, string plan, string serie, string imei, string macether
            , string macwifi, string macequipo, DateTime feccom, DateTime fecgar, string obs1, string obs2, string estado
            , DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarActivoTI(codigo, descripcion, estact, codorg, codsisope, codproc, codmem, codDD
            , codmar, codmod, codprv, numord, numcel, plan, serie, imei, macether
            , macwifi, macequipo, feccom, fecgar, obs1, obs2, estado
            , fec_edit, useedit);
        }

        //metodo para eliminar ACTIVO 
        public void EliminActivoTI(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarActivoTI(codigo);
        }

        public void EliminActivoPer2TI(string codigo, string codper)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarActivoPer2TI(codigo, codper);
        }

        //
        //METODO PARA GUARDAR ASIGNACION
        //       

        //metodo para guardar ASIGNACION
        public static DataTable GuardAsignacionActTI(string codigo, int item, string codact, string codemp, string codsede, string area, string dni,
            string estact, string devevent, string obs1, string obs2, string num, string cant, string ubic, DateTime fecent, DateTime fecdev,
             string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            return datos.GuardarAsignacionActTI(codigo, item, codact, codemp, codsede, area, dni,
            estact, devevent, obs1, obs2, num, cant, ubic, fecent, fecdev,
             estado, fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar ASIGNACION 
        public void ActuaAsignacionActTI(string codigo, int item, string codemp, string codsede, string area, string dni,
            string estact, string devevent, string obs1, string obs2, string num, string cant, string ubic, DateTime fecent, DateTime fecdev,
             string estado, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarAsignacionActTI(codigo, item, codemp, codsede, area, dni,
            estact, devevent, obs1, obs2, num, cant, ubic, fecent, fecdev,
             estado, fec_edit, useedit);
        }

        //metodo para eliminar ASIGNACION 
        public void EliminAsignacionActTI(string codigo, string item, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarAsignacionActTI(codigo, item, fec_edit, useedit);
        }

        //metodo para buscar ultimo codigo de grupo +1
        public static bool BuscUltimoCodEntregaDevolucionTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodEntregaDevolucionTIMas();//UltimoCodEntregaDevolucionTIMas
        }

        //metodo para buscar ultimo codigo de mantenimiento +1
        public static bool BuscUltimoCodMantenimientoEquipoTIMas()
        {
            cd_logistica datos = new cd_logistica();
            return datos.UltimoCodMantenimientoEquipoTIMas();//UltimoCodEntregaDevolucionTIMas
        }

        //
        //METODO PARA GUARDAR ENTREGA DEVOLUCION
        //       
        //metodo para listar tipo devolucion entrega
        public static DataTable ListaDevolucionEntregaAsigTI(string codasig, string codact, int dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaDevolucionEntregaAsigTI(codasig, codact, dni);
        }

        //metodo para buscar si existe codigo de entrega devolucion
        public static bool BuscExisteCodEntregaDevolucionAsigTI(string cod, string codasig, string codact, int dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteCodEntregaDevolucionAsigTI(cod, codasig, codact, dni);
        }

        //metodo para buscar si existe codigo de entrega devolucion
        public static bool EliminarCodEntregaDevolucionAsigTI(string cod, string codasig, string codact, int dni, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            return datos.EliminarCodEntregaDevolucionAsigTI(cod, codasig, codact, dni, fec_edit, useedit);
        }

        //metodo para guardar ASIGNACION
        public static DataTable GuardEntregaDevolucionAsigActTI(string cod, string codasig, string codact, int dni, string tipmov, DateTime fecha,
             string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            return datos.GuardarEntregaDevolucionAsigActTI(cod, codasig, codact, dni, tipmov, fecha, estado, fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para actualizar ASIGNACION 
        public void ActuaEntregaDevolucionAsigActTI(string cod, string codasig, string codact, int dni, string tipmov, DateTime fecha,
             string estado, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarEntregaDevolucionAsigActTI(cod, codasig, codact, dni, tipmov, fecha, estado, fec_edit, useedit);
        }

        //metodo para guardar MANTENIMIENTO DE EQUIPO
        public static DataTable GuardMantenimientoEquipoActTI(string cod, string codasig, string codact, int dni, string tipmant, DateTime fecha,
             string estado, string obs, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            return datos.GuardarMantenimientoEquipoAsigActTI(cod, codasig, codact, dni, tipmant, fecha, estado, obs, fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para buscar si existe codigo de entrega devolucion
        public static bool EliminarMantenimientoEquipoAsigTI(string cod, string codasig, int dni, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            return datos.EliminarCodMantenimientoEquipoAsigTI(cod, codasig, dni, fec_edit, useedit);
        }

        //metodo para listar mantenimiento de equipo
        public static DataTable ListaMantenimientoEquipoAsigTI(string codasig, string codact, int dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.ListaMantenimientoEquipoAsigTI(codasig, codact, dni);//MantenimientoEquipo
        }


        //
        //GUARDAR PERSONAL TI
        //

        public void GuardPersonalTI(string dni, string apellidos, string nombres, string sexo, string codemp
            , string codsed, string codarea, DateTime FecNac, string Email, string obs, Byte[] imagen, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarPersonalTI(dni, apellidos, nombres, sexo, codemp
            , codsed, codarea, FecNac, Email, obs, imagen, estado,
            fec_cre, usereg, hostname, fec_edit, useedit);
        }

        //metodo para buscar foto
        public DataTable FotoPersonalTI(string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.FotoPersonalTI(dni);
        }

        //ACTUALIZAR PERSONAL TI
        public void ActualizarPersonalTI(string dni, string apellidos, string nombres, string sexo, string codemp
            , string codsed, string codarea, DateTime FecNac, string Email, string obs, Byte[] imagen, string estado,
            DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPersonalTI(dni, apellidos, nombres, sexo, codemp, codsed, codarea, FecNac, Email, obs, imagen, estado, fec_edit, useedit);
        }

        //ACTUALIZAR PERSONAL
        public void ActualizarPersonal(string dni, string Email, string obs, string estado,
            DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPersonal(dni, Email, obs, estado, fec_edit, useedit);
        }

        public void ActualizarPersonalFoto(Byte[] imagen)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPersonalFoto(imagen);
        }

        //ACTUALIZAR PERSONAL COMEDOR
        public void ActualizarPersonalComedor(string dni, string apellidos,
            DateTime FecCese, string Tipo
            , string Empresa, string Sede, string Area, string est_des, string desayuno, string est_alm, string almuerzo
            , string est_cen, string cena, string hoja, string obs, string estado,
            DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPersonalComedor(dni, apellidos, FecCese, Tipo, Empresa, Sede, Area, est_des, desayuno
                , est_alm, almuerzo, est_cen, cena, hoja, obs, estado, fec_edit, useedit);
        }

        //ACTUALIZAR PEDIDO COMEDOR
        public void ActualizarPedidoComedor(DateTime FecIng, string Empresa, string Sede,
            string PedDes, string PedAlm, string PedCen, string ConDes, string ConAlm
            , string ConCen, string obs, string estado,
            DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPedidoComedor(FecIng, Empresa, Sede, PedDes, PedAlm, PedCen
                , ConDes, ConAlm, ConCen, obs, estado, fec_edit, useedit);
        }


        //ACTUALIZAR TRANSPORTE VIAJES
        public void ActualizarTransporteViaje(DateTime fecha, int dia, int semana
            , string num_reporte, string localidad, string unidad, string proveedor, string ruc, string placa
            , decimal costo, string area, int cant_real, int capacidad, string porc_ocupa, string destino
            , string comentario, string tipo, decimal costo_percapita, string empresa, string sede, string hoja
            , DateTime fec_mov, int usedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarTransporteViajes(fecha, dia, semana, num_reporte, localidad, unidad
                , proveedor, ruc, placa, costo, area, cant_real, capacidad, porc_ocupa, destino
            , comentario, tipo, costo_percapita, empresa, sede, hoja
                , fec_mov, usedit);
        }




        //ACTUALIZAR PERSONAL COMEDOR
        public void ActualizarPersonalComedorEliminar(string dni, DateTime fecing, string des, string alm, string cen
            , DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPersonalComedorEliminar(dni, fecing, des, alm, cen, fec_edit, useedit);
        }

        //AGREGAR PERSONAL COMEDOR UNICO
        public void ActualizarPersonalComedorAgregar(string dni, DateTime fecing, string des, string alm, string cen
            , DateTime fec_edit, int useedit)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarPersonalComedorAgregar(dni, fecing, des, alm, cen, fec_edit, useedit);
        }


        //metodo para buscar si existe codigo de usuario
        public static bool BuscExistePersonalComedor(string cod, string tipo, string sede, DateTime fecha)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExistePersonalComedor(cod, tipo, sede, fecha);
        }

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExistePersonalProgramado(string cod, string sede, DateTime fecha)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExistePersonalProgramado(cod, sede, fecha);
        }
        //metodo para buscar si existe codigo de usuario
        public static bool BuscExisteTransporteViaje(string cod, DateTime fecha)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExisteTransporteViaje(cod, fecha);
        }

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExistePedidoComedor(string emp, DateTime fecha)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExistePedidoComedor(emp, fecha);
        }

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExistePedateoPersonalComedor(string cod, DateTime FecReg, string Tipo)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExistePedateoPersonalComedor(cod, FecReg, Tipo);
        }

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExistePedateoPersonalComedorAlimento(string cod, DateTime FecReg, string Tipo)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscExistePedateoPersonalComedorAlimento(cod, FecReg, Tipo);
        }

        //metodo para buscar si existe codigo de usuario
        public void EliminarRegistroComedorFecha(DateTime FecIng, string Tipo, string Emp, string sede)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarRegistroComedorFecha(FecIng, Tipo, Emp, sede);
        }

        //metodo para guardar almacen 
        public void GuardAlm(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string siscod)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarAlmacen(codigo, descripcion, comentario, estado
                , fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, siscod);
        }

        //metodo para actualizar almacen 
        public void ActuaAlm(string codigo, string descripcion, string comentario, string estado
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, string siscod)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarAlmacen(codigo, descripcion, comentario, estado
                , fec_mov, usereg, usenamreg, hostname, ip_pc, siscod);
        }

        //metodo para eliminar almacen 
        public void EliminAlm(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarAlmacen(codigo);
        }


        //metodo para guardar proveedor 
        public void GuarProv(string codigo, string descripcion, string comentario, string ruc, string direccion
            , string telefono, string estado, string distrito
            , DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, int siscod)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarProveedor(codigo, descripcion, comentario, ruc, direccion
            , telefono, estado, distrito, fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, siscod);
        }

        //metodo para actualizar proveedor 
        public void ActuaProv(string codigo, string descripcion, string comentario, string ruc, string direccion
            , string telefono, string estado, string distrito
            , DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc, int siscod)
        {
            cd_logistica datos = new cd_logistica();
            datos.ActualizarProveedor(codigo, descripcion, comentario, ruc, direccion
            , telefono, estado, distrito, fec_mov, usereg, usenamreg, hostname, ip_pc, siscod);
        }

        //metodo para eliminar proveedor 
        public void EliminProv(string codigo)
        {
            cd_logistica datos = new cd_logistica();
            datos.EliminarProveedor(codigo);
        }


        //GUARDAR PERSONAL COMEDOR
        public void GuardarPersonalComedor(string dni, string apellidos, DateTime FecCese, string Tipo
            , string Empresa, string Sede, string Area, string est_des, string desayuno, string est_alm, string almuerzo
            , string est_cen, string cena, string hoja, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarPersonalComedor(dni, apellidos, FecCese, Tipo, Empresa, Sede, Area, est_des, desayuno
                , est_alm, almuerzo, est_cen, cena, hoja, obs, estado, fec_cre, usereg, hostname
                , fec_mov, usedit, useelim);
        }

        //GUARDAR TRANSPORTE VIAJES
        public void GuardarTransporteViaje(DateTime fecha, int dia, int semana
            , string num_reporte, string localidad, string unidad, string proveedor, string ruc, string placa
            , decimal costo, string area, int cant_real, int capacidad, string porc_ocupa, string destino
            , string comentario, string tipo, decimal costo_percapita, string empresa, string sede, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarTransporteViajes(fecha, dia, semana, num_reporte, localidad, unidad
                , proveedor, ruc, placa, costo, area, cant_real, capacidad, porc_ocupa, destino
            , comentario, tipo, costo_percapita, empresa, sede, hoja, fec_cre, usereg, hostname
                , fec_mov, usedit, useelim);
        }


        public void GuardarRegistroPedido(DateTime FecIng, string Empresa, string Sede,
            string personal,string PedDes, string PedAlm, string PedCen, string ConDes, string ConAlm
            , string ConCen, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarRegistroPedido(FecIng, Empresa, Sede,personal, PedDes, PedAlm, PedCen
                , ConDes, ConAlm, ConCen, obs, estado, fec_cre, usereg, hostname
                , fec_mov, usedit, useelim);
        }

        public void GuardarPedateoPersonalComedor(string dni, string apellidos, DateTime FecIng, string Tipo, string hoja
            , string TipoPer, DateTime FecReg, string Empresa, string Sede, string Area, decimal precio, string obs, string estado,
            DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_logistica datos = new cd_logistica();
            datos.GuardarPedateoPersonalComedor(dni, apellidos, FecIng, Tipo, hoja, TipoPer, FecReg, Empresa, Sede, Area, precio,
                obs, estado, fec_cre, usereg, hostname, fec_mov, usedit, useelim);
        }


        //BUSCAR PERSONAL PEDATEADA

        public static DataTable BuscarPedateoPersonalComedor(string dni, string Tipo
            , DateTime FecReg, string Sede)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedor(dni, Tipo, FecReg, Sede);
        }

        public static DataTable BuscarPedateoPersonalComedorJustificado(string dni, string Tipo
            , DateTime FecReg, string Sede)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorJustificado(dni, Tipo, FecReg, Sede);
        }

        public static DataTable BuscarPedateoPersonalComedorReporte(DateTime FecIni, DateTime FecFin, string adicional
            , string tipoalimento, string TipoPer, string Empresa, string area, string Sede, string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorReporte(FecIni, FecFin, adicional
            , tipoalimento, TipoPer, Empresa, area, Sede, dni);
        }

        public static DataTable BuscarPedateoPersonalComedorReporteJustificacion(DateTime FecIni, DateTime FecFin, string adicional
            , string tipoalimento, string TipoPer, string Empresa, string area, string Sede, string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorReporteJustificacion(FecIni, FecFin, adicional
            , tipoalimento, TipoPer, Empresa, area, Sede, dni);
        }

        public static DataTable BuscarPedateoPersonalComedorProgramado(DateTime FecIni, DateTime FecFin, string adicional
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorProgramado(FecIni, FecFin, adicional, area
            , tipopersonal, Empresa, Sede, dni);
        }

        public static DataTable BuscarRegistroPedido(
            DateTime FecIng, DateTime FecFin, string empresa, string id)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarRegistroPedido(FecIng, FecFin, empresa, id);
        }

        //INASISTENCIA
        public static DataTable BuscarPedateoPersonalComedorInasistencia(DateTime FecIni, DateTime FecFin, string adicional
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorInasistencia(FecIni, FecFin, adicional, area
            , tipopersonal, Empresa, Sede, dni);
        }

        //RESUMEN
        public static DataTable BuscarPedateoPersonalComedorResumen(DateTime FecIni, DateTime FecFin
            , string tipopersonal, string Empresa, string Sede)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorResumen(FecIni, FecFin
            , tipopersonal, Empresa, Sede);
        }

        //PEDIDO PROGRAMADO RESUMEN BuscarPedidoProgramadoComedorResumen
        public static DataTable BuscarPedidoProgramadoComedorResumen(DateTime FecIni, DateTime FecFin
            , string tipopersonal, string Empresa, string Sede)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedidoProgramadoComedorResumen(FecIni, FecFin
            , tipopersonal, Empresa, Sede);
        }

        //PEDIDO REGISTRO
        public static DataTable BuscarPedidoRegistro(DateTime FecIni, DateTime FecFin
            , string Empresa)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedidoRegistro(FecIni, FecFin
            , Empresa);
        }

        //RESUMEN DETEALLE
        public static DataTable BuscarPedateoPersonalComedorResumen_Detalle(DateTime FecIni, DateTime FecFin
            , string tipopersonal, string Empresa, string Sede)
        {
            cd_logistica datos = new cd_logistica();
            return datos.BuscarPedateoPersonalComedorResumen_Detalle(FecIni, FecFin
            , tipopersonal, Empresa, Sede);
        }

    }
}
