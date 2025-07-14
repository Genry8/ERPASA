using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_equipoti : cd_conexion
    {
        //metodo para listar almacenes por usuario
        public static DataTable ListEstadoEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaCondicionEquipoTI();
        }

        public static DataTable ListEmpresaEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaEmpresaEquipoTI();
        }

        public static DataTable ListSedeEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaSedeEquipoTI();
        }

        public static DataTable ListGerenciaEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaGerenciaEquipoTI();
        }

        public static DataTable ListAreaEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaAreaEquipoTI();
        }
        public static DataTable ListTipoEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaTipoEquipoTI();
        }

        public static DataTable ListMarcaEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaMarcaEquipoTI();
        }

        public static DataTable ListModeloEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaModeloEquipoTI();
        }

        public static DataTable ListSisOperativoEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaSisOperativoEquipoTI();
        }

        public static DataTable ListProcesadorEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaProcesadorEquipoTI();
        }

        public static DataTable ListMemoriaEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaMemoriaEquipoTI();
        }

        public static DataTable ListDiscoDuroEquipoTI()
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaDiscoDuroEquipoTI();
        }


        //metodo para buscar si existe codigo de empleador
        public static bool BuscExisteEmpleador(string dni)
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.BuscExisteDniEmpleador(dni);
        }

        //metodo para buscar si existe codigo de contrato
        public static bool BuscExisteDocContrato(int cod)
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.BuscExisteDocContrato(cod);
        }

        //metodo para buscar si existe codigo de contrato
        public static bool BuscarDocumentoContrato(int cod)
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.BuscarDocumentoContrato(cod);
        }


        //BUSCAR DATOS DE EQUIPOTI
        public static DataTable BuscaEquipoTI(string TipoEquipo, string Empresa, string Sede, string Gerencia, string Area)
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.BuscarEquipoTI(TipoEquipo, Empresa, Sede, Gerencia, Area);
        }

        //BUSCAR PARA HOJA
        public static bool BuscPaginaParaHoja(int id, DateTime fecha)
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.BuscPaginaParaHoja(id, fecha);
        }


        //LISTA PERIFERICO POR FILTRO
        //
        public static DataTable ListaContratoDocumento(string proveedor)
        {
            cd_equipoti datos = new cd_equipoti();
            return datos.ListaContratoDocumento(proveedor);
        }



        //ACTUALIZAR 
        public void ActualizarContratoDocumento(int id, byte[] data,
            string extension, string filename, string proveedor, string contrato
            , string ruta, DateTime fec_ini, DateTime fec_fin, string estado, DateTime fec_mov, int usedit)
        {
            cd_equipoti datos = new cd_equipoti();
            datos.ActualizarContratoDocumento(id, data
            , extension, filename, proveedor, contrato, ruta, fec_ini, fec_fin, estado
            , fec_mov, usedit);
        }



        //ACTUALIZAR 
        public void ActualizarContratoDocumentoEstado(int id, string estado, DateTime fec_mov, int usedit)
        {
            cd_equipoti datos = new cd_equipoti();
            datos.ActualizarContratoDocumentoEstado(id, estado
            , fec_mov, usedit);
        }




        //GUARDAR ATENCIONES MEDICAS
        public void GuardarContratoDocumento(byte[] data,
            string extension, string filename, string proveedor, string contrato
            , string ruta, DateTime fec_ini, DateTime fec_fin, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_equipoti datos = new cd_equipoti();
            datos.GuardarContratoDocumento(data
            , extension, filename, proveedor, contrato, ruta, fec_ini, fec_fin
            , estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


    }
}
