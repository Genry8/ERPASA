using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_contabilidad : cd_conexion
    {

        // MOSTRAR LISTA REPORTE CAMPAÑA
        public DataTable ListaReporteCampaña(
            string periodo, string sucursal, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_CONT_CAMPANA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = periodo;
                comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
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

        // MOSTRAR LISTA REPORTE CAMPAÑA
        public DataTable ListaReporteCampañaConsumidor(
            string empresa, string sucursal, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_CONT_CAMPANA_CONSUMIDOR", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
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

        // MOSTRAR LISTA PARTIDAS PENDIENTES
        public DataTable ListaReportePartidasPendientes(
            int id, string emp, string suc, string cult, string area, string cod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PARTIDAS_PENDIENTES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = suc;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
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

        // MOSTRAR LISTA CONTROL CUMPLIMIENTO
        public DataTable ListaReporteControlCumplimiento(
            int id, string emp, string ger, string area, string año, string mes)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_CONTROL_CUMPLIMIENTO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = ger;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
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

        // MOSTRAR LISTA KILOS PROYECTADO
        public DataTable ListaReporteKilosProyectado(
            int id, string emp, string año, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_KILOS_PROYECTADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
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

        // MOSTRAR LISTA CECOS PENDIENTES
        public DataTable ListaReporteCecoPendientes(
            int id, string emp, string area, string idcuenta)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_CECO_PENDIENTES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@IdCuenta", SqlDbType.VarChar).Value = idcuenta;
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


        // METODO PARA GUARDAR CAMPAÑA CONTA
        public void GuardarCampañaConta(int cod,
            string sucursal, string cultivo, string etapa, string campaña
            , string fecini, string fecfin, string factor, string emp, string sed
            , string hoja, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CAMPANA_CONTABILIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Etapa", SqlDbType.VarChar).Value = etapa;
                    comando.Parameters.AddWithValue("@Campaña", SqlDbType.VarChar).Value = campaña;
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fecini;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fecfin;
                    comando.Parameters.AddWithValue("@Factor", SqlDbType.VarChar).Value = factor;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR CAMPAÑA SUCURSAL CONTA
        public void GuardarCampañaConsumidorConta(int cod,
            string sucursal, string cultivo, string etapa
            , string consumidor, string campaña
            , string fecini, string fecfin, string factor, string emp, string sed
            , string hoja, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CAMPANACONSUMIDOR_CONTABILIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Etapa", SqlDbType.VarChar).Value = etapa;
                    comando.Parameters.AddWithValue("@Consumidor", SqlDbType.VarChar).Value = consumidor;
                    comando.Parameters.AddWithValue("@Campaña", SqlDbType.VarChar).Value = campaña;
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fecini;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fecfin;
                    comando.Parameters.AddWithValue("@Factor", SqlDbType.VarChar).Value = factor;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR SUCURSAL CONTA
        public void GuardarSucursalConta(int cod,
            string emp, string sucursal, string sucnisira, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SUCURSAL_CONTABILIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@SucursalNisira", SqlDbType.VarChar).Value = sucnisira;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR CULTIVO CONTA
        public void GuardarCultivoConta(int cod,
            string emp, string sucursal, string cultivo
            , string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SUCURSAL_CULTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }



        // METODO PARA GUARDAR ETAPA CONTA
        public void GuardarEtapaConta(int cod,
            string etapa, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_ETAPA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Etapa", SqlDbType.VarChar).Value = etapa;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR TIPO GASTO
        public void GuardarTipoGasto(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_TIPOGASTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR politica
        public void GuardarRendicionPolitica(int cod,
            string descripcion, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_RENDICIONPOLITICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR politica
        public void GuardarRendicionTipoGasto(int cod,
            string descripcion, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_RENDICION_TIPOGASTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }



        // METODO PARA GUARDAR categoria
        public void GuardarRendicionCategoria(int cod,
            string politica, string descripcion, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_RENDICIONCATEGORIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Politica", SqlDbType.VarChar).Value = politica;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR movilidad
        public void GuardarRendicionMovilidad(int cod,
            string descripcion, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_RENDICIONMOVILIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }



        // METODO PARA GUARDAR ESTRUCTURA
        public void GuardarTipoEstructura(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_TIPOESTRUCTURA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR AREA
        public void GuardarArea(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_AREA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR TIPO RECURSO
        public void GuardarTipoRecurso(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_TIPORECURSO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR RECURSO
        public void GuardarRecurso(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_RECURSO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR CLASIFICADOR
        public void GuardarClasificador(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_CLASIFICADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR CLASIFICADOR
        public void GuardarGerencia(int cod,
            string descripcion, string estado, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CONT_GERENCIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR PARTIDA CONTA
        public void GuardarActualizarPartidaConta(string emp, string area_sis,
            string idrubro, string partida, string partida_final
            , string sucursal, string cultivo, string etapa, string valid
            , string tipogasto, string tipoestruc, string estruc_area
            , string etiqueta, string tiporecurso, string recurso
            , string clasif, string gerencia, string agrup
            , DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CLASIFICACION_PARTIDA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@AREA_SISTEMA", SqlDbType.VarChar).Value = area_sis;
                    comando.Parameters.AddWithValue("@COD_AREA", SqlDbType.VarChar).Value = idrubro;
                    comando.Parameters.AddWithValue("@PARTIDA_PRESUPUESTAL", SqlDbType.VarChar).Value = partida;
                    comando.Parameters.AddWithValue("@PARTIDA_FINAL", SqlDbType.VarChar).Value = partida_final;
                    comando.Parameters.AddWithValue("@SUCURSAL", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@CULTIVO", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@ETAPA", SqlDbType.VarChar).Value = etapa;
                    comando.Parameters.AddWithValue("@VALID", SqlDbType.VarChar).Value = valid;

                    comando.Parameters.AddWithValue("@TIPO_GASTO", SqlDbType.VarChar).Value = tipogasto;
                    comando.Parameters.AddWithValue("@ESTRC_TIPO", SqlDbType.VarChar).Value = tipoestruc;
                    comando.Parameters.AddWithValue("@ESTRUC_AREA", SqlDbType.VarChar).Value = estruc_area;
                    comando.Parameters.AddWithValue("@ETIQUETA", SqlDbType.VarChar).Value = etiqueta;
                    comando.Parameters.AddWithValue("@TIPO_RECURSO", SqlDbType.VarChar).Value = tiporecurso;
                    comando.Parameters.AddWithValue("@RECURSO", SqlDbType.VarChar).Value = recurso;
                    comando.Parameters.AddWithValue("@CLASIFIC", SqlDbType.VarChar).Value = clasif;
                    comando.Parameters.AddWithValue("@GERENCIA", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@AGRUPADOR", SqlDbType.VarChar).Value = agrup;

                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR ACTUALIZAR CUMPLIMIENTO CONTA
        public void GuardActualizarControlCumplimientoConta(
            int id, string emp, string sede,
            string gerencia, string area, string actividad
            , string responsable, string calif, string fecha_ini, string fecha_obli
            , string fecha_cump, string mes, string año
            , string hoja, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_GUARDAR_CONTROL_CUMPLIMIENTO_CONTA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = actividad;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Clasificacion", SqlDbType.VarChar).Value = calif;
                    comando.Parameters.AddWithValue("@FechaInicio", SqlDbType.VarChar).Value = fecha_ini;
                    comando.Parameters.AddWithValue("@FechaObligacion", SqlDbType.VarChar).Value = fecha_obli;

                    comando.Parameters.AddWithValue("@FechaCumplimiento", SqlDbType.VarChar).Value = fecha_cump;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR CUMPLIMIENTO DOCUMENTOS
        public void EliminarControlCumplimientoConta(string año, string mes)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_CONTROLCUMPLIMIENTO_AÑOMES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA GUARDAR ACTUALIZAR CUMPLIMIENTO CONTA
        public void GuardarControlCumplimientoConta(
            string id, string emp, string sede,
            string gerencia, string area, string actividad
            , string responsable, string calif, string fecha_ini, string fecha_obli
            , string fecha_cump, string mes, string año
            , string hoja, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_CONTROL_CUMPLIMIENTO_CONTA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = actividad;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Clasificacion", SqlDbType.VarChar).Value = calif;
                    comando.Parameters.AddWithValue("@FechaInicio", SqlDbType.VarChar).Value = fecha_ini;
                    comando.Parameters.AddWithValue("@FechaObligacion", SqlDbType.VarChar).Value = fecha_obli;

                    comando.Parameters.AddWithValue("@FechaCumplimiento", SqlDbType.VarChar).Value = fecha_cump;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR PARTIDA CONTA
        public void GuardarActualizarCecoConta(string emp, string area_sis,
            string idccosto, string ccosto, string idcuenta
            , string partida, string partida_final
            , string sucursal, string cultivo, string etapa, string valid
            , string tipogasto, string tipoestruc, string estruc_area
            , string etiqueta, string tiporecurso, string recurso
            , string clasif, string gerencia, string agrup
            , DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CLASIFICACION_CECO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@AREA_SISTEMA", SqlDbType.VarChar).Value = area_sis;
                    comando.Parameters.AddWithValue("@IDCCOSTO", SqlDbType.VarChar).Value = idccosto;
                    comando.Parameters.AddWithValue("@CCOSTO", SqlDbType.VarChar).Value = ccosto;
                    comando.Parameters.AddWithValue("@IDCUENTA", SqlDbType.VarChar).Value = idcuenta;
                    comando.Parameters.AddWithValue("@PARTIDA_PRESUPUESTAL", SqlDbType.VarChar).Value = partida;
                    comando.Parameters.AddWithValue("@PARTIDA_FINAL", SqlDbType.VarChar).Value = partida_final;
                    comando.Parameters.AddWithValue("@SUCURSAL", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@CULTIVO", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@ETAPA", SqlDbType.VarChar).Value = etapa;
                    comando.Parameters.AddWithValue("@VALID", SqlDbType.VarChar).Value = valid;

                    comando.Parameters.AddWithValue("@TIPO_GASTO", SqlDbType.VarChar).Value = tipogasto;
                    comando.Parameters.AddWithValue("@ESTRC_TIPO", SqlDbType.VarChar).Value = tipoestruc;
                    comando.Parameters.AddWithValue("@ESTRUC_AREA", SqlDbType.VarChar).Value = estruc_area;
                    comando.Parameters.AddWithValue("@ETIQUETA", SqlDbType.VarChar).Value = etiqueta;
                    comando.Parameters.AddWithValue("@TIPO_RECURSO", SqlDbType.VarChar).Value = tiporecurso;
                    comando.Parameters.AddWithValue("@RECURSO", SqlDbType.VarChar).Value = recurso;
                    comando.Parameters.AddWithValue("@CLASIFIC", SqlDbType.VarChar).Value = clasif;
                    comando.Parameters.AddWithValue("@GERENCIA", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@AGRUPADOR", SqlDbType.VarChar).Value = agrup;

                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR CAMPAÑA CONTA
        public void GuardarPartidasNisira(
            string emp, string idrubro, string partida, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PARTIDAS_NISIRA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@IdRubro", SqlDbType.VarChar).Value = idrubro;
                    comando.Parameters.AddWithValue("@Partida", SqlDbType.VarChar).Value = partida;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;

                    comando.ExecuteNonQuery();

                }
            }
        }



        // METODO PARA GUARDAR CAMPAÑA CONTA
        public void GuardarVoucherRindeGasto(
            int id, int idRend, string voucher, DateTime fec_cre
            , int usereg, string hostname, DateTime fec_edit, int usedit
            , DateTime fec_elim, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_RENDICION_VOUCHER"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@IdRend", SqlDbType.Int).Value = idRend;
                    comando.Parameters.AddWithValue("@Voucher", SqlDbType.VarChar).Value = voucher;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@FecElim", SqlDbType.DateTime).Value = fec_elim;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;

                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR CAMPAMENTO
        public void EliminarPartida()
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PARTIDAS_PENDIENTES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();

                }
            }

        }

        public DataTable ListaAreaPartida(string emp, string sucursal, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_AREA_PARTIDA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
                comando.Parameters.AddWithValue("@cultivo", SqlDbType.VarChar).Value = cultivo;
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

        public DataTable ListaCodigoPartida(string emp, string sucursal, string cultivo, string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_CODIGO_PARTIDA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
                comando.Parameters.AddWithValue("@cultivo", SqlDbType.VarChar).Value = cultivo;
                comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
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

        public DataTable ListaAreaCumplimiento(string emp, string gerencia)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_AREA_CUMPLIMIENTO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@gerencia", SqlDbType.VarChar).Value = gerencia;
                //comando.Parameters.AddWithValue("@cultivo", SqlDbType.VarChar).Value = cultivo;
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

        public DataTable ListaIdCuentaCeco(string emp)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_IDCUENTA_CECO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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



        public DataTable ListaSucursal(string emp)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_CONT_EMPRESA_SUCURSAL", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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

        public DataTable ListaGerenciaCumplimiento(string emp)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_GERENCIA_CONTABILIDAD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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

        public DataTable ReporteSucursal(string emp)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CONT_EMPRESA_SUCURSAL", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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

        public DataTable ReporteCultivo(string emp, string sucursal)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CONT_SUCURSAL_CULTIVO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ListaConsumidor(
            string emp, string sucursal, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CONT_CONSUMIDOR_SUCURSAL_CULTIVO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
                comando.Parameters.AddWithValue("@cultivo", SqlDbType.VarChar).Value = cultivo;
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

        public DataTable ReporteEtapa()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CONT_ETAPA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteUsuarioConsumidor()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // Cambiar la consulta SQL directamente, en lugar de ejecutar un procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT Id,IdUser,Dni,apeNom,Empresa,Gerencia," +
                    " Area,IdAud,Auditor,Estado,Obs  FROM CONT_RendicionUsuarioConsumidor", conex);
                comando.CommandType = CommandType.Text; // Cambiar a CommandType.Text para ejecutar una consulta directa
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
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar la conexión
            }
        }

        public DataTable ReporteUsuarioCeco()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // Cambiar la consulta SQL directamente, en lugar de ejecutar un procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT Id,IdUser,Dni,apeNom,Empresa," +
                    " TipoGasto,Consumidor,Placa,Estado,Obs  FROM CONT_RendicionUsuarioCeco ", conex);
                comando.CommandType = CommandType.Text; // Cambiar a CommandType.Text para ejecutar una consulta directa
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
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar la conexión
            }
        }

        public DataTable ReportePolitica()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // Cambiar la consulta SQL directamente, en lugar de ejecutar un procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT Id,Politica,Obs  FROM CONT_RendicionPolitica", conex);
                comando.CommandType = CommandType.Text; // Cambiar a CommandType.Text para ejecutar una consulta directa
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
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar la conexión
            }
        }

        public DataTable ReporteCategoria()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // Cambiar la consulta SQL directamente, en lugar de ejecutar un procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT Id,Politica,Categoria,Obs  FROM CONT_RendicionCategoria", conex);
                comando.CommandType = CommandType.Text; // Cambiar a CommandType.Text para ejecutar una consulta directa
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
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar la conexión
            }
        }

        public DataTable ReporteMovilidad()
        {
            SqlDataReader resultado; // Permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                // Cambiar la consulta SQL directamente, en lugar de ejecutar un procedimiento almacenado
                SqlCommand comando = new SqlCommand("SELECT Id,Movilidad,Obs  FROM CONT_RendicionMovilidad", conex);
                comando.CommandType = CommandType.Text; // Cambiar a CommandType.Text para ejecutar una consulta directa
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
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerrar la conexión
            }
        }

        public DataTable ReporteTipoGasto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, TipoGasto from CONT_TipoGasto", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable RendTipoGasto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, TipoGasto,Obs from CONT_RendicionTipoGasto", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable RendEstadoGasto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, EstadoGasto,Obs from CONT_RendicionEstadoGasto", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable RendCuentaCategoria()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id,IdCat, Categoria,Empresa" +
                    ",TipoGasto,Cuenta,Estado,Obs from CONT_RendicionCuentaCategoria", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable RendConsumidor()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select  * from DIM_Consumidor", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteTipoEstructura()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, TipoEstructura from CONT_TipoEstructura", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteArea()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, Area from CONT_Area", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteTipoRecurso()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, TipoRecurso from CONT_TipoRecurso", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteRecurso()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, Recurso from CONT_Recurso", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteClasificar()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, Clasificador from CONT_Clasificador", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ReporteGerencia()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("select Id, Gerencia from CONT_Gerencia", conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
                //comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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

        public DataTable ListaCultivo(string emp, string sucursal)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_CONT_CULTIVO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = sucursal;
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


        public DataTable ListaEtapa()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_CONT_ETAPA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                //comando.Parameters.AddWithValue("@emp", SqlDbType.VarChar).Value = emp;
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


        // METODO PARA GUARDAR ACTUALIZAR USUARIO CONSUMIDOR
        public void GuardarActualizarUsuarioConsumidorCont(
            int id, int idUser, string dni, string nombre, string empresa
            , string sucursal, string gerencia, string area, string tipogasto
            , string consumidor, string regimen
            , string destino, string placa, int idAud, string auditor
            , string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_USUARIOCONSUMIDOR_CONT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@IdUser", SqlDbType.Int).Value = idUser;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoGasto", SqlDbType.VarChar).Value = tipogasto;
                    comando.Parameters.AddWithValue("@Consumidor", SqlDbType.VarChar).Value = consumidor;
                    comando.Parameters.AddWithValue("@Regimen", SqlDbType.VarChar).Value = regimen;
                    comando.Parameters.AddWithValue("@Destino", SqlDbType.VarChar).Value = destino;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
                    comando.Parameters.AddWithValue("@IdAud", SqlDbType.Int).Value = idAud;
                    comando.Parameters.AddWithValue("@Auditor", SqlDbType.VarChar).Value = auditor;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA GUARDAR ACTUALIZAR USUARIO CECO
        public void GuardarActualizarUsuarioCecoCont(
            int id, int idUser, string dni, string nombre, string empresa
            , string sucursal, string tipogasto, string consumidor, string placa,
            string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_USUARIOCECO_CONT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@IdUser", SqlDbType.Int).Value = idUser;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    comando.Parameters.AddWithValue("@TipoGasto", SqlDbType.VarChar).Value = tipogasto;
                    comando.Parameters.AddWithValue("@Consumidor", SqlDbType.VarChar).Value = consumidor;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA GUARDAR ACTUALIZAR PROG VOLCADO
        public void GuardarActualizarCuentaCategoriaCont(
            int id, int idCat, string categoria, string empresa
            , string tipogasto, string cuenta,
            string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CUENTACATEGORIA_CONT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@IdCat", SqlDbType.Int).Value = idCat;
                    comando.Parameters.AddWithValue("@Categoria", SqlDbType.VarChar).Value = categoria;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@TipoGasto", SqlDbType.VarChar).Value = tipogasto;
                    comando.Parameters.AddWithValue("@Cuenta", SqlDbType.VarChar).Value = cuenta;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // MOSTRAR LISTA LIBERACION PALET
        public DataTable ListaReporteDetalleGasto(DateTime fecini, DateTime fecfin
            , string emp, string politica, string tipogasto, string ger,
            string area, string estado, int id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_RENDICION_DETALLEGASTOS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Politica", SqlDbType.VarChar).Value = politica;
                comando.Parameters.AddWithValue("@TipoGasto", SqlDbType.VarChar).Value = tipogasto;
                comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = ger;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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



        // METODO PARA GUARDAR ACTUALIZAR PROG VOLCADO
        public string GuardarActualizarGuiaPalets(
    bool programado,
    int idRec,
    string numeroPallet,
    DateTime fecProgramado,
    string numeroGuia,
    DateTime? fechaGuia,
    string documento,
    string obs,
    string estado,
    DateTime fecCre,
    int useReg,
    string hostname,
    DateTime fecEdit,
    int useEdit,
    int useElim)
        {
            using (SqlConnection conexion = leerconexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_GUARDAR_ASIGNACION_GUIA_PALETS", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@Programado", SqlDbType.Bit).Value = programado;
                    comando.Parameters.Add("@IdRec", SqlDbType.Int).Value = idRec;
                    comando.Parameters.Add("@NumeroPallet", SqlDbType.VarChar, 80).Value = numeroPallet;
                    comando.Parameters.Add("@FecProgramado", SqlDbType.Date).Value = fecProgramado;

                    comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 180).Value =
                        string.IsNullOrEmpty(numeroGuia)
                        ? (object)DBNull.Value
                        : numeroGuia;


                    comando.Parameters.Add("@FechaGuia", SqlDbType.Date).Value =
                        fechaGuia.HasValue
                        ? (object)fechaGuia.Value
                        : DBNull.Value;


                    comando.Parameters.Add("@Documento", SqlDbType.VarChar, 180).Value =
                        string.IsNullOrEmpty(documento)
                        ? (object)DBNull.Value
                        : documento;


                    comando.Parameters.Add("@Obs", SqlDbType.VarChar).Value =
                        string.IsNullOrEmpty(obs)
                        ? (object)DBNull.Value
                        : obs;

                    comando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = estado;
                    comando.Parameters.Add("@FecCre", SqlDbType.DateTime2).Value = fecCre;
                    comando.Parameters.Add("@UseReg", SqlDbType.Int).Value = useReg;
                    comando.Parameters.Add("@Hostname", SqlDbType.VarChar, 50).Value = hostname;
                    comando.Parameters.Add("@FecEdit", SqlDbType.DateTime2).Value = fecEdit;
                    comando.Parameters.Add("@UseEdit", SqlDbType.Int).Value = useEdit;
                    comando.Parameters.Add("@UseElim", SqlDbType.Int).Value = useElim;

                    SqlParameter mensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200);
                    mensaje.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(mensaje);

                    conexion.Open();
                    comando.ExecuteNonQuery();

                    return mensaje.Value == DBNull.Value
                        ? ""
                        : mensaje.Value.ToString();
                }
            }
        }




    }
}
