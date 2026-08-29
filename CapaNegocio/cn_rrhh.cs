using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_rrhh : cd_conexion
    {
        //metodo para listar tipo visita
        public static DataTable ListaCBTipoVisitaRRHH()
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.ListaCBTipoVisitaRRHH();
        }

        //metodo para listar tipo documento
        public static DataTable ListaCBTipoDocumentoRRHH()
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.ListaCBTipoDocumentoRRHH();
        }

        //metodo para listar tipo sexo
        public static DataTable ListaCBTipoSexoRRHH()
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.ListaCBTipoSexoRRHH();
        }

        //metodo para listar nacionalidad
        public static DataTable ListaCBNacionalidadRRHH()
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.ListaCBNacionalidadRRHH();
        }

        //
        //VISITAS ESPERADAS
        //
        //
        //metodo para buscar si existe usuario
        public static bool BuscExisteVisita(int numident, DateTime fecvist)
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.BuscExisteVisita(numident, fecvist);
        }

        //
        //metodo para guardar usuario 
        public void GuardVisitaPV(string CodVist, int Item, string Empresa, string Sede, string Area, String TipDoc, int NumIdent, string Apellido,
            string Sexo, string Nacionalidad, string TipVisita, string Fotosheck, string Compañia, string MotVisita,
            DateTime FecVisita, byte FtshEnt, byte FtshDev, string Hr_Ing, string Hr_sal, string firmvisi, string firmsello_resp,
            string estado, DateTime feccre, int usereg, string hostname, DateTime fecedit, int Useedit)
        {
            cd_rrhh datos = new cd_rrhh();
            datos.GuardarVisitaPV(CodVist, Item, Empresa, Sede, Area, TipDoc, NumIdent, Apellido,
             Sexo, Nacionalidad, TipVisita, Fotosheck, Compañia, MotVisita,
             FecVisita, FtshEnt, FtshDev, Hr_Ing, Hr_sal, firmvisi, firmsello_resp,
             estado, feccre, usereg, hostname, fecedit, Useedit);
        }

        //
        //metodo para actualizar usuario 
        public void ActuaVisitaPV(string codigo, string pagina, string comentario, int index)
        {
            cd_rrhh datos = new cd_rrhh();
            datos.ActualizarVisitaPV(codigo, pagina, comentario, index);
        }

        //
        //metodo para listar usuarios
        public static DataTable ListaVisitaPV(DateTime fechavini, DateTime fechavfin)
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.ListaVisitaPV(fechavini, fechavfin);
        }

        //metodo para buscar ultimo codigo de visita +1
        public static bool BuscUltimoCodVisitaMas()
        {
            cd_rrhh datos = new cd_rrhh();
            return datos.BuscCodExisteVisitaMas();
        }




    }
}
