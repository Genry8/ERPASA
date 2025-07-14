using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_sig : cd_conexion
    {
        public DataTable ListaNormaSig()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_NORMA_SIG", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }


        // METODO PARA GUARDAR CUMPLIMIENTO DOCUMENTOS
        public void GuardarCumplimientoDocumentos(int año, int sem,
            string codigo, string Empresa, string sede
            , string revision, string titulo, string solicitante
            , string fecha_solic, string tipo_doc, string gerencia
            , string area, string tipo_actividad, string responsable
            , string etapa_flujo, string fecha_reg
            , string condicion, string detalle, string fecha_public, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CUMPLIMIENTODOCUMENTOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Revision", SqlDbType.VarChar).Value = revision;
                    comando.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar).Value = titulo;
                    comando.Parameters.AddWithValue("@Solicitante", SqlDbType.VarChar).Value = solicitante;
                    comando.Parameters.AddWithValue("@FechaSolicitud", SqlDbType.VarChar).Value = fecha_solic;
                    comando.Parameters.AddWithValue("@TipoDocumento", SqlDbType.VarChar).Value = tipo_doc;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoActividad", SqlDbType.VarChar).Value = tipo_actividad;
                    comando.Parameters.AddWithValue("@ResponsableFlujo", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@EtapaFlujo", SqlDbType.VarChar).Value = etapa_flujo;
                    comando.Parameters.AddWithValue("@FechaRegistro", SqlDbType.VarChar).Value = fecha_reg;
                    comando.Parameters.AddWithValue("@Condicion", SqlDbType.VarChar).Value = condicion;
                    comando.Parameters.AddWithValue("@Detalle", SqlDbType.VarChar).Value = detalle;
                    comando.Parameters.AddWithValue("@FechaPublicacion", SqlDbType.VarChar).Value = fecha_public;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ELIMINAR CUMPLIMIENTO DOCUMENTOS
        public void EliminarCumplimientoDocumentos(int año, int sem)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_CUMPLIMIENTODOCUMENTOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA GUARDAR CUMPLIMIENTO DOCUMENTOS
        public void EliminarCumplimientoCertificacion(
            string emp, string sed, string norma, int año, int sem)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_CUMPLIMIENTO_CERTIFICACIONES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@TipoNorma", SqlDbType.VarChar).Value = norma;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA GUARDAR CUMPLIMIENTO DOCUMENTOS
        public void BuscConsumoEnergia(
            string emp, string sed, string grupo, string fecha)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_BUSCAR_COSUMO_ENERGIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA GUARDAR CUMPLIMIENTO CERTIFICACIONES
        public void GuardarCumplimientoCertificaciones(
            int año, int sem, string codigo
            , string Empresa, string sede
            , string nombre_req, string requisito, string nivel
            , string gerencia, string area, string responsable, string evidencia
            , string frecuencia, string fecha_planif
            , string tipo_norma, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CUMPLIMIENTOCERTIFICACIONES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@NombreRequisito", SqlDbType.VarChar).Value = nombre_req;
                    comando.Parameters.AddWithValue("@Requisito", SqlDbType.VarChar).Value = requisito;
                    comando.Parameters.AddWithValue("@Nivel", SqlDbType.VarChar).Value = nivel;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;

                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Evidencia", SqlDbType.VarChar).Value = evidencia;
                    comando.Parameters.AddWithValue("@Frecuencia", SqlDbType.VarChar).Value = frecuencia;
                    comando.Parameters.AddWithValue("@FechaPlanificada", SqlDbType.VarChar).Value = fecha_planif;
                    comando.Parameters.AddWithValue("@TipoNorma", SqlDbType.VarChar).Value = tipo_norma;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA GUARDAR CONSUMO ENERGIA
        public void GuardarConsumoEnergia(
              string Empresa, string sede, string grupo, string fecha, string horas
            , string consumo, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONSUMO_ENERGIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.VarChar).Value = horas;
                    comando.Parameters.AddWithValue("@Consumo", SqlDbType.VarChar).Value = consumo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA GUARDAR OBS COBERTURA
        public void GuardarObsCobertura(
              string Empresa, string sede, string area, string fecha,
              string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_OBSERVACION_COBERTURA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }








    }
}
