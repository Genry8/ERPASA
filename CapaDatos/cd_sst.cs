using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_sst : cd_conexion
    {
        // METODO PARA LLAMAR EL ULTIMO CÓDIGO DE ASIGNACION
        public bool UltimoCodigoCapacitacionSSTMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_CAPACITACION_SST_MAS_UNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_sst.UltCodigo = reader.GetInt32(0);
                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }

        // METODO PARA LLAMAR SI EXISTE EL USUARIO PARA CAPACITACION
        public bool BuscExisteUserCapacitacionSST(string cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_PERSONAL_CAP_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_sst.NumIdent = reader.GetString(0);
                            ce_sst.Codigo = reader.GetInt32(1);
                            ce_sst.Est_Cese = reader.GetString(2);
                            ce_sst.CabEstado = reader.GetString(3);
                            ce_sst.CabFecIn = reader.GetDateTime(4);
                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscDatosPersonalASA(string cod)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_DATOS_PERSONAL_ASA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_usuario.dni_asa = reader.GetString(0);
                            ce_usuario.apenom_asa = reader.GetString(1);
                            ce_usuario.gerencia_asa = reader.GetString(2);
                            ce_usuario.empresa_asa = reader.GetString(3);
                            ce_usuario.sede_asa = reader.GetString(4);
                            ce_usuario.area_asa = reader.GetString(5);
                            ce_usuario.cargo_asa = reader.GetString(6);

                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscAtencionPaciente(string cod, DateTime fecha, string horaentrada)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_DATOS_PACIENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@HoraEntrada", SqlDbType.Date).Value = horaentrada;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_topico.dni_paciente = reader.GetString(0);
                            ce_topico.apenom_paciente = reader.GetString(1);
                            ce_topico.area_paciente = reader.GetString(2);
                            ce_topico.jefearea_paciente = reader.GetString(3);
                            ce_topico.hrentrada_paciente = reader.GetString(4);
                            ce_topico.hrsalida_paciente = reader.GetString(5);
                            ce_topico.patologia_paciente = reader.GetString(6);
                            ce_topico.diagnostico_paciente = reader.GetString(7);
                            ce_topico.tratamiento_paciente = reader.GetString(8);
                            ce_topico.cantmedicamento_paciente = reader.GetString(9);
                            ce_topico.accionrealizada_paciente = reader.GetString(10);
                            ce_topico.localidad_paciente = reader.GetString(11);
                            ce_topico.incidencia_paciente = reader.GetBoolean(12);
                            ce_topico.parte_cuerpo = reader.GetString(13);
                            ce_topico.labor = reader.GetString(14);

                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool EliminarRecetaMedica(string cod, DateTime fecha, string horaentrada)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_RECETA_PACIENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@HoraEntrada", SqlDbType.Date).Value = horaentrada;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }


        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaMedicamentosTopico(string cod, string des)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_MEDICAMENTO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@cod", SqlDbType.VarChar).Value = cod;
                comando.Parameters.AddWithValue("@des", SqlDbType.VarChar).Value = des;
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



        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaRecetaAtencion(string cod, DateTime fecaten, string hora)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECETA_ATENCION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecaten;
                comando.Parameters.AddWithValue("@HoraEntrada", SqlDbType.VarChar).Value = hora;
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



        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaAtencionPaciente(DateTime fecini, DateTime fecfin, string emp, string sed, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_ATENCION_PACIENTE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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


        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaRecepcionAcopio(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECEPCION_ACOPIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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


        // MOSTRAR LISTA RECEPCION
        public DataTable ListaRecepcion(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECEPCION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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

        // MOSTRAR LISTA ESTADO PALLET
        public DataTable ListaEstadoPallet(DateTime fecini, DateTime fecfin, string emp, string sed, string pallet)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACKING_ESTADO_PALLET", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Pallet", SqlDbType.VarChar).Value = pallet;
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

        // MOSTRAR LISTA RECEPCION IMPRIMIR
        public DataTable ListaRecepcionImprimir(
            DateTime fecini, DateTime fecfin, string emp, string sed, string cult)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECEPCION_IMPRIMIR", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
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

        // MOSTRAR LISTA RECEPCION PROG VOLCADO
        public DataTable RecepcionProgVolcado(
            DateTime fecini, DateTime fecfin, string emp
            , string sed, string cult,string var,string maq)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PROGRAMADO_VOLCADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
                comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maq;
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


        // MOSTRAR LISTA RECEPCION PROG VOLCADO
        public DataTable ListaRecepcionProgVolcado(
            DateTime fecini, DateTime fecfin, string emp
            , string sed, string cult, string var, string maq)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PROGRAMADO_VOLCADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
                comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maq;
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


        // MOSTRAR LISTA PT IMPRIMIR
        public DataTable ListaPTImprimir(
            DateTime fecini, DateTime fecfin, string emp, string sed, string cult)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PT_IMPRIMIR", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
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


        // METODO PARA ACTUALIZAR COBERTURA
        public void ActualizarRecepcionImprimir(string pallet, string fecha)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_LISTA_RECEPCION_IMPRIMIR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Pallet", SqlDbType.VarChar).Value = pallet;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ACTUALIZAR
        public void ActualizarPTImprimir(string pallet, DateTime fecha)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_LISTA_PT_IMPRIMIR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Pallet", SqlDbType.VarChar).Value = pallet;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // MOSTRAR LISTA VOLCADO
        public DataTable ListaReporteVolcado(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string var)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_VOLCADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
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



        // MOSTRAR LISTA VOLCADO
        public DataTable ListaReporteFrio(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string var)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_FRIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
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


        // MOSTRAR LISTA TOMA MUESTRA
        public DataTable ListaReporteTomaMuestra(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string var)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_TOMAMUESTRA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
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

        // MOSTRAR LISTA MERMA
        public DataTable ListaReporteMerma(DateTime fecini, DateTime fecfin,
            string emp, string sed, string merma)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_MERMACONTRAMUESTRA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Merma", SqlDbType.VarChar).Value = merma;
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

        // MOSTRAR LISTA ORDEN
        public DataTable ListaReporteOrdProd(DateTime fecini, DateTime fecfin,
            string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_ORDEN_PRODUCCION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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

        // MOSTRAR LISTA PRESENTACION
        public DataTable ListaReportePresentacion(string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PRESENTACIONES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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

        // MOSTRAR LISTA PT
        public DataTable ListaReportePT(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult, string palet)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_PT", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Pallet", SqlDbType.VarChar).Value = palet;
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

        // MOSTRAR LISTA GASIFICADO
        public DataTable ListaReporteGasificado(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_GASIFICADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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

        // MOSTRAR LISTA GASIFICADO
        public DataTable ListaReportePreFrio(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_REPORTE_PREFRIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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


        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaRecepcionAcopioVariedad(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECEPCION_ACOPIO_VARIEDAD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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


        // MOSTRAR LISTA DE recepcion
        public DataTable ListaRecepcionVariedad(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECEPCION_VARIEDAD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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


        // MOSTRAR LISTA DE VOLCADO VARIEDAD
        public DataTable ListaReporteVolcadoMaquina(DateTime fecini,
            DateTime fecfin, string emp, string sed, string cult, string var)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_VOLCADO_MAQUINA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
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

        // MOSTRAR LISTA DE VOLCADO VARIEDAD
        public DataTable ListaReporteVolcadoVariedad(DateTime fecini
            , DateTime fecfin, string emp, string sed, string cult, string var)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_VOLCADO_VARIEDAD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
                comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = var;
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

        // MOSTRAR LISTA DE PT 
        public DataTable ListaReportePTMaquina(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cult)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PT_MAQUINA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
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


        // MOSTRAR LISTA DE PT 
        public DataTable ListaReportePTPresentacion(DateTime fecini
            , DateTime fecfin, string emp, string sed, string cult)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PT_PRESENTACION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cult;
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

        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaRecepcionAcopioProducto(DateTime fecini, DateTime fecfin, string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RECEPCION_ACOPIO_PRODUCTO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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


        // METODO PARA ACTUALIZAR PERSONAL SST
        public void ActualizarPersonalSST(int cod, string doc, DateTime fecind, string sem, string nota
            , string tipoemp, string empcont, string sede, string area, string venlic, string entlicind, string tiplic, string unidmanj,
            string fecmult, string puntcond, string obs, string estado, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_SST"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
                    comando.Parameters.AddWithValue("@FecInd", SqlDbType.DateTime).Value = fecind;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Nota", SqlDbType.VarChar).Value = nota;
                    comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                    comando.Parameters.AddWithValue("@EmpCont", SqlDbType.VarChar).Value = empcont;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@VenLic", SqlDbType.VarChar).Value = venlic;
                    comando.Parameters.AddWithValue("@EntLicInd", SqlDbType.VarChar).Value = entlicind;
                    comando.Parameters.AddWithValue("@TipLic", SqlDbType.VarChar).Value = tiplic;
                    comando.Parameters.AddWithValue("@UnidManj", SqlDbType.VarChar).Value = unidmanj;
                    comando.Parameters.AddWithValue("@FecMult", SqlDbType.VarChar).Value = fecmult;
                    comando.Parameters.AddWithValue("@PuntConduct", SqlDbType.VarChar).Value = puntcond;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR PERSONAL SST
        public void GuardarPersonalSST(int cod, string doc, DateTime fecind, string sem, string nota
            , string tipoemp, string empcont, string sede, string area, string venlic, string entlicind, string tiplic, string unidmanj,
            string fecmult, string puntcond, string obs, string estado, DateTime fec_cre, int usereg,
            string hostname, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PERSONAL_SST"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
                    comando.Parameters.AddWithValue("@FecInd", SqlDbType.DateTime).Value = fecind;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Nota", SqlDbType.VarChar).Value = nota;
                    comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                    comando.Parameters.AddWithValue("@EmpCont", SqlDbType.VarChar).Value = empcont;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@VenLic", SqlDbType.VarChar).Value = venlic;
                    comando.Parameters.AddWithValue("@EntLicInd", SqlDbType.VarChar).Value = entlicind;
                    comando.Parameters.AddWithValue("@TipLic", SqlDbType.VarChar).Value = tiplic;
                    comando.Parameters.AddWithValue("@UnidManj", SqlDbType.VarChar).Value = unidmanj;
                    comando.Parameters.AddWithValue("@FecMult", SqlDbType.VarChar).Value = fecmult;
                    comando.Parameters.AddWithValue("@PuntConduct", SqlDbType.VarChar).Value = puntcond;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA GUARDAR DATAGRID RECETA MEDICA
        public DataTable GuardarRecetaMedica(DateTime Fecha, string Dni, DateTime HraEntrada
            , DateTime HraSalida, string Cod, string Descripcion, string UniMed, decimal Cant
            , decimal Precio, DateTime Fecha_med, decimal Total,
             string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {

            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_RECETA_MEDICA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                comando.Parameters.AddWithValue("@HraEntrada", SqlDbType.VarChar).Value = HraEntrada;
                comando.Parameters.AddWithValue("@HraSalida", SqlDbType.VarChar).Value = HraSalida;
                comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = Cod;
                comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
                comando.Parameters.AddWithValue("@UniMed", SqlDbType.VarChar).Value = UniMed;
                comando.Parameters.AddWithValue("@Cant", SqlDbType.Decimal).Value = Cant;
                comando.Parameters.AddWithValue("@Precio", SqlDbType.Decimal).Value = Precio;
                comando.Parameters.AddWithValue("@Fecha_med", SqlDbType.Date).Value = Fecha_med;
                comando.Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = Total;

                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
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


        // METODO PARA ACTUALIZAR PERSONAL SST
        public void ActualizarCapacitacionDetalleSST(int cod, string doc,
            string Tar_ta, string Sem_ta, string Nota_ta, string Tar_ez, string Sem_ez, string Nota_ez,
            string Tar_tc, string Sem_tc, string Nota_tc, string Tar_ec, string Sem_ec, string Nota_ec,

            string Esp_map, string Sem_map, string Nota_map, string Esp_rcs, string Sem_rcs, string Nota_rcs,
            string Esp_hmp, string Sem_hmp, string Nota_hmp, string Esp_vpp, string Sem_vpp, string Nota_vpp,
            string Esp_ats, string Sem_ast, string Nota_ats,

            string Bas_iperc, string Sem_iperc, string Nota_iperc, string Bas_scc, string Sem_scc, string Nota_scc,
            string Bas_epp, string Sem_epp, string Nota_epp, string Bas_aci, string Sem_aci, string Nota_aci,

            string Ext_er, string Sem_er, string Nota_er, string Ext_ppi, string Sem_ppi, string Nota_ppi,
            string Ext_eepp, string Sem_eepp, string Nota_eepp, string Ext_rsa, string Sem_rsa, string Nota_rsa,

            string Otr_maptel, string Sem_maptel, string Nota_maptel, string Otr_tea, string Sem_tea, string Nota_tea,
            string Otr_risst, string Sem_risst, string Nota_risst,

            string obs, string estado, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CAPACITACION_DETALLE_SST"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;

                    comando.Parameters.AddWithValue("@Tar_ta", SqlDbType.VarChar).Value = Tar_ta;
                    comando.Parameters.AddWithValue("@Sem_ta", SqlDbType.VarChar).Value = Sem_ta;
                    comando.Parameters.AddWithValue("@Nota_ta", SqlDbType.VarChar).Value = Nota_ta;
                    comando.Parameters.AddWithValue("@Tar_ez", SqlDbType.VarChar).Value = Tar_ez;
                    comando.Parameters.AddWithValue("@Sem_ez", SqlDbType.VarChar).Value = Sem_ez;
                    comando.Parameters.AddWithValue("@Nota_ez", SqlDbType.VarChar).Value = Nota_ez;
                    comando.Parameters.AddWithValue("@Tar_tc", SqlDbType.VarChar).Value = Tar_tc;
                    comando.Parameters.AddWithValue("@Sem_tc", SqlDbType.VarChar).Value = Sem_tc;
                    comando.Parameters.AddWithValue("@Nota_tc", SqlDbType.VarChar).Value = Nota_tc;
                    comando.Parameters.AddWithValue("@Tar_ec", SqlDbType.VarChar).Value = Tar_ec;
                    comando.Parameters.AddWithValue("@Sem_ec", SqlDbType.VarChar).Value = Sem_ec;
                    comando.Parameters.AddWithValue("@Nota_ec", SqlDbType.VarChar).Value = Nota_ec;

                    comando.Parameters.AddWithValue("@Esp_map", SqlDbType.VarChar).Value = Esp_map;
                    comando.Parameters.AddWithValue("@Sem_map", SqlDbType.VarChar).Value = Sem_map;
                    comando.Parameters.AddWithValue("@Nota_map", SqlDbType.VarChar).Value = Nota_map;
                    comando.Parameters.AddWithValue("@Esp_rcs", SqlDbType.VarChar).Value = Esp_rcs;
                    comando.Parameters.AddWithValue("@Sem_rcs", SqlDbType.VarChar).Value = Sem_rcs;
                    comando.Parameters.AddWithValue("@Nota_rcs", SqlDbType.VarChar).Value = Nota_rcs;
                    comando.Parameters.AddWithValue("@Esp_hmp", SqlDbType.VarChar).Value = Esp_hmp;
                    comando.Parameters.AddWithValue("@Sem_hmp", SqlDbType.VarChar).Value = Sem_hmp;
                    comando.Parameters.AddWithValue("@Nota_hmp", SqlDbType.VarChar).Value = Nota_hmp;
                    comando.Parameters.AddWithValue("@Esp_vpp", SqlDbType.VarChar).Value = Esp_vpp;
                    comando.Parameters.AddWithValue("@Sem_vpp", SqlDbType.VarChar).Value = Sem_vpp;
                    comando.Parameters.AddWithValue("@Nota_vpp", SqlDbType.VarChar).Value = Nota_vpp;
                    comando.Parameters.AddWithValue("@Esp_ats", SqlDbType.VarChar).Value = Esp_ats;
                    comando.Parameters.AddWithValue("@Sem_ast", SqlDbType.VarChar).Value = Sem_ast;
                    comando.Parameters.AddWithValue("@Nota_ats", SqlDbType.VarChar).Value = Nota_ats;

                    comando.Parameters.AddWithValue("@Bas_iperc", SqlDbType.VarChar).Value = Bas_iperc;
                    comando.Parameters.AddWithValue("@Sem_iperc", SqlDbType.VarChar).Value = Sem_iperc;
                    comando.Parameters.AddWithValue("@Nota_iperc", SqlDbType.VarChar).Value = Nota_iperc;
                    comando.Parameters.AddWithValue("@Bas_scc", SqlDbType.VarChar).Value = Bas_scc;
                    comando.Parameters.AddWithValue("@Sem_scc", SqlDbType.VarChar).Value = Sem_scc;
                    comando.Parameters.AddWithValue("@Nota_scc", SqlDbType.VarChar).Value = Nota_scc;
                    comando.Parameters.AddWithValue("@Bas_epp", SqlDbType.VarChar).Value = Bas_epp;
                    comando.Parameters.AddWithValue("@Sem_epp", SqlDbType.VarChar).Value = Sem_epp;
                    comando.Parameters.AddWithValue("@Nota_epp", SqlDbType.VarChar).Value = Nota_epp;
                    comando.Parameters.AddWithValue("@Bas_aci", SqlDbType.VarChar).Value = Bas_aci;
                    comando.Parameters.AddWithValue("@Sem_aci", SqlDbType.VarChar).Value = Sem_aci;
                    comando.Parameters.AddWithValue("@Nota_aci", SqlDbType.VarChar).Value = Nota_aci;

                    comando.Parameters.AddWithValue("@Ext_er", SqlDbType.VarChar).Value = Ext_er;
                    comando.Parameters.AddWithValue("@Sem_er", SqlDbType.VarChar).Value = Sem_er;
                    comando.Parameters.AddWithValue("@Nota_er", SqlDbType.VarChar).Value = Nota_er;
                    comando.Parameters.AddWithValue("@Ext_ppi", SqlDbType.VarChar).Value = Ext_ppi;
                    comando.Parameters.AddWithValue("@Sem_ppi", SqlDbType.VarChar).Value = Sem_ppi;
                    comando.Parameters.AddWithValue("@Nota_ppi", SqlDbType.VarChar).Value = Nota_ppi;
                    comando.Parameters.AddWithValue("@Ext_eepp", SqlDbType.VarChar).Value = Ext_eepp;
                    comando.Parameters.AddWithValue("@Sem_eepp", SqlDbType.VarChar).Value = Sem_eepp;
                    comando.Parameters.AddWithValue("@Nota_eepp", SqlDbType.VarChar).Value = Nota_eepp;
                    comando.Parameters.AddWithValue("@Ext_rsa", SqlDbType.VarChar).Value = Ext_rsa;
                    comando.Parameters.AddWithValue("@Sem_rsa", SqlDbType.VarChar).Value = Sem_rsa;
                    comando.Parameters.AddWithValue("@Nota_rsa", SqlDbType.VarChar).Value = Nota_rsa;

                    comando.Parameters.AddWithValue("@Otr_maptel", SqlDbType.VarChar).Value = Otr_maptel;
                    comando.Parameters.AddWithValue("@Sem_maptel", SqlDbType.VarChar).Value = Sem_maptel;
                    comando.Parameters.AddWithValue("@Nota_maptel", SqlDbType.VarChar).Value = Nota_maptel;
                    comando.Parameters.AddWithValue("@Otr_tea", SqlDbType.VarChar).Value = Otr_tea;
                    comando.Parameters.AddWithValue("@Sem_tea", SqlDbType.VarChar).Value = Sem_tea;
                    comando.Parameters.AddWithValue("@Nota_tea", SqlDbType.VarChar).Value = Nota_tea;
                    comando.Parameters.AddWithValue("@Otr_risst", SqlDbType.VarChar).Value = Otr_risst;
                    comando.Parameters.AddWithValue("@Sem_risst", SqlDbType.VarChar).Value = Sem_risst;
                    comando.Parameters.AddWithValue("@Nota_risst", SqlDbType.VarChar).Value = Nota_risst;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR PERSONAL SST
        public void GuardarCapacitacionDetalleSST(int cod, string doc,
            string Tar_ta, string Sem_ta, string Nota_ta, string Tar_ez, string Sem_ez, string Nota_ez,
            string Tar_tc, string Sem_tc, string Nota_tc, string Tar_ec, string Sem_ec, string Nota_ec,

            string Esp_map, string Sem_map, string Nota_map, string Esp_rcs, string Sem_rcs, string Nota_rcs,
            string Esp_hmp, string Sem_hmp, string Nota_hmp, string Esp_vpp, string Sem_vpp, string Nota_vpp,
            string Esp_ats, string Sem_ast, string Nota_ats,

            string Bas_iperc, string Sem_iperc, string Nota_iperc, string Bas_scc, string Sem_scc, string Nota_scc,
            string Bas_epp, string Sem_epp, string Nota_epp, string Bas_aci, string Sem_aci, string Nota_aci,

            string Ext_er, string Sem_er, string Nota_er, string Ext_ppi, string Sem_ppi, string Nota_ppi,
            string Ext_eepp, string Sem_eepp, string Nota_eepp, string Ext_rsa, string Sem_rsa, string Nota_rsa,

            string Otr_maptel, string Sem_maptel, string Nota_maptel, string Otr_tea, string Sem_tea, string Nota_tea,
            string Otr_risst, string Sem_risst, string Nota_risst,

            string obs, string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_edit, int useedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CAPACITACIONES_DETALLE_SST"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;

                    comando.Parameters.AddWithValue("@Tar_ta", SqlDbType.VarChar).Value = Tar_ta;
                    comando.Parameters.AddWithValue("@Sem_ta", SqlDbType.VarChar).Value = Sem_ta;
                    comando.Parameters.AddWithValue("@Nota_ta", SqlDbType.VarChar).Value = Nota_ta;
                    comando.Parameters.AddWithValue("@Tar_ez", SqlDbType.VarChar).Value = Tar_ez;
                    comando.Parameters.AddWithValue("@Sem_ez", SqlDbType.VarChar).Value = Sem_ez;
                    comando.Parameters.AddWithValue("@Nota_ez", SqlDbType.VarChar).Value = Nota_ez;
                    comando.Parameters.AddWithValue("@Tar_tc", SqlDbType.VarChar).Value = Tar_tc;
                    comando.Parameters.AddWithValue("@Sem_tc", SqlDbType.VarChar).Value = Sem_tc;
                    comando.Parameters.AddWithValue("@Nota_tc", SqlDbType.VarChar).Value = Nota_tc;
                    comando.Parameters.AddWithValue("@Tar_ec", SqlDbType.VarChar).Value = Tar_ec;
                    comando.Parameters.AddWithValue("@Sem_ec", SqlDbType.VarChar).Value = Sem_ec;
                    comando.Parameters.AddWithValue("@Nota_ec", SqlDbType.VarChar).Value = Nota_ec;

                    comando.Parameters.AddWithValue("@Esp_map", SqlDbType.VarChar).Value = Esp_map;
                    comando.Parameters.AddWithValue("@Sem_map", SqlDbType.VarChar).Value = Sem_map;
                    comando.Parameters.AddWithValue("@Nota_map", SqlDbType.VarChar).Value = Nota_map;
                    comando.Parameters.AddWithValue("@Esp_rcs", SqlDbType.VarChar).Value = Esp_rcs;
                    comando.Parameters.AddWithValue("@Sem_rcs", SqlDbType.VarChar).Value = Sem_rcs;
                    comando.Parameters.AddWithValue("@Nota_rcs", SqlDbType.VarChar).Value = Nota_rcs;
                    comando.Parameters.AddWithValue("@Esp_hmp", SqlDbType.VarChar).Value = Esp_hmp;
                    comando.Parameters.AddWithValue("@Sem_hmp", SqlDbType.VarChar).Value = Sem_hmp;
                    comando.Parameters.AddWithValue("@Nota_hmp", SqlDbType.VarChar).Value = Nota_hmp;
                    comando.Parameters.AddWithValue("@Esp_vpp", SqlDbType.VarChar).Value = Esp_vpp;
                    comando.Parameters.AddWithValue("@Sem_vpp", SqlDbType.VarChar).Value = Sem_vpp;
                    comando.Parameters.AddWithValue("@Nota_vpp", SqlDbType.VarChar).Value = Nota_vpp;
                    comando.Parameters.AddWithValue("@Esp_ats", SqlDbType.VarChar).Value = Esp_ats;
                    comando.Parameters.AddWithValue("@Sem_ast", SqlDbType.VarChar).Value = Sem_ast;
                    comando.Parameters.AddWithValue("@Nota_ats", SqlDbType.VarChar).Value = Nota_ats;

                    comando.Parameters.AddWithValue("@Bas_iperc", SqlDbType.VarChar).Value = Bas_iperc;
                    comando.Parameters.AddWithValue("@Sem_iperc", SqlDbType.VarChar).Value = Sem_iperc;
                    comando.Parameters.AddWithValue("@Nota_iperc", SqlDbType.VarChar).Value = Nota_iperc;
                    comando.Parameters.AddWithValue("@Bas_scc", SqlDbType.VarChar).Value = Bas_scc;
                    comando.Parameters.AddWithValue("@Sem_scc", SqlDbType.VarChar).Value = Sem_scc;
                    comando.Parameters.AddWithValue("@Nota_scc", SqlDbType.VarChar).Value = Nota_scc;
                    comando.Parameters.AddWithValue("@Bas_epp", SqlDbType.VarChar).Value = Bas_epp;
                    comando.Parameters.AddWithValue("@Sem_epp", SqlDbType.VarChar).Value = Sem_epp;
                    comando.Parameters.AddWithValue("@Nota_epp", SqlDbType.VarChar).Value = Nota_epp;
                    comando.Parameters.AddWithValue("@Bas_aci", SqlDbType.VarChar).Value = Bas_aci;
                    comando.Parameters.AddWithValue("@Sem_aci", SqlDbType.VarChar).Value = Sem_aci;
                    comando.Parameters.AddWithValue("@Nota_aci", SqlDbType.VarChar).Value = Nota_aci;

                    comando.Parameters.AddWithValue("@Ext_er", SqlDbType.VarChar).Value = Ext_er;
                    comando.Parameters.AddWithValue("@Sem_er", SqlDbType.VarChar).Value = Sem_er;
                    comando.Parameters.AddWithValue("@Nota_er", SqlDbType.VarChar).Value = Nota_er;
                    comando.Parameters.AddWithValue("@Ext_ppi", SqlDbType.VarChar).Value = Ext_ppi;
                    comando.Parameters.AddWithValue("@Sem_ppi", SqlDbType.VarChar).Value = Sem_ppi;
                    comando.Parameters.AddWithValue("@Nota_ppi", SqlDbType.VarChar).Value = Nota_ppi;
                    comando.Parameters.AddWithValue("@Ext_eepp", SqlDbType.VarChar).Value = Ext_eepp;
                    comando.Parameters.AddWithValue("@Sem_eepp", SqlDbType.VarChar).Value = Sem_eepp;
                    comando.Parameters.AddWithValue("@Nota_eepp", SqlDbType.VarChar).Value = Nota_eepp;
                    comando.Parameters.AddWithValue("@Ext_rsa", SqlDbType.VarChar).Value = Ext_rsa;
                    comando.Parameters.AddWithValue("@Sem_rsa", SqlDbType.VarChar).Value = Sem_rsa;
                    comando.Parameters.AddWithValue("@Nota_rsa", SqlDbType.VarChar).Value = Nota_rsa;

                    comando.Parameters.AddWithValue("@Otr_maptel", SqlDbType.VarChar).Value = Otr_maptel;
                    comando.Parameters.AddWithValue("@Sem_maptel", SqlDbType.VarChar).Value = Sem_maptel;
                    comando.Parameters.AddWithValue("@Nota_maptel", SqlDbType.VarChar).Value = Nota_maptel;
                    comando.Parameters.AddWithValue("@Otr_tea", SqlDbType.VarChar).Value = Otr_tea;
                    comando.Parameters.AddWithValue("@Sem_tea", SqlDbType.VarChar).Value = Sem_tea;
                    comando.Parameters.AddWithValue("@Nota_tea", SqlDbType.VarChar).Value = Nota_tea;
                    comando.Parameters.AddWithValue("@Otr_risst", SqlDbType.VarChar).Value = Otr_risst;
                    comando.Parameters.AddWithValue("@Sem_risst", SqlDbType.VarChar).Value = Sem_risst;
                    comando.Parameters.AddWithValue("@Nota_risst", SqlDbType.VarChar).Value = Nota_risst;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_edit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        //
        //
        // MOSTRAR LISTA DE CAPACITACIONES
        public DataTable ListaCapacitacionesSST()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAPACITACION_SST", conex);
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

        // MOSTRAR LISTA DE CAPACITACIONES
        public DataTable ListaCapacitacionesFiltroSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAPACITACION_FILTRO_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fecini", SqlDbType.DateTime).Value = fechaIni;
                comando.Parameters.AddWithValue("@Fecfin", SqlDbType.DateTime).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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



        // MOSTRAR LISTA DE CAPACITACIONES FOTOSHECK
        public DataTable ListaCapFotosheckFiltroSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAP_FOTOSHECK_FILTRO_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fechaIni;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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

        // MOSTRAR LISTA DE CAPACITACIONES FOTOSHECK
        public DataTable ListaCapFotosheckFiltroTrabAlturaSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAP_FOTOSHECK_FILTRO_TRABAJOALTURA_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fechaIni;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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

        // MOSTRAR LISTA DE CAPACITACIONES FOTOSHECK
        public DataTable ListaCapFotosheckFiltroExcZanjaSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAP_FOTOSHECK_FILTRO_EXCAVZANJA_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fechaIni;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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

        // MOSTRAR LISTA DE CAPACITACIONES FOTOSHECK
        public DataTable ListaCapFotosheckFiltroTrabCalienteSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAP_FOTOSHECK_FILTRO_TRABAJOCALIENTE_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fechaIni;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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


        // MOSTRAR LISTA DE CAPACITACIONES FOTOSHECK
        public DataTable ListaCapFotosheckFiltroEspConfSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAP_FOTOSHECK_FILTRO_ESPACIONCONFINADO_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fechaIni;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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


        // MOSTRAR LISTA DE CAPACITACIONES FOTOSHECK
        public DataTable ListaCapFotosheckFiltroLicenciaSST(DateTime fechaIni, DateTime fechafin, string emp, string sed,
            string area,
            string sem, string tipoemp,
            string doc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_CAP_FOTOSHECK_FILTRO_LICENCIACONDUCIR_SST", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fechaIni;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fechafin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                comando.Parameters.AddWithValue("@TipoEmp", SqlDbType.VarChar).Value = tipoemp;
                comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = doc;
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

        // METODO PARA LLAMAR CABECERA DE CAPACITACIONES
        public bool BuscCapacitacionesCabeceraSST(string doc)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CABECERA_CAPACITACION_SST"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = doc;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_sst.CabDoc = reader.GetString(0);
                            ce_sst.CabFecIn = reader.GetDateTime(1);
                            ce_sst.CabSem = reader.GetString(2);
                            ce_sst.CabNota = reader.GetString(3);
                            ce_sst.CabEmpCont = reader.GetString(4);
                            ce_sst.CabVencLic = reader.GetString(5);
                            ce_sst.CabEntLicInd = reader.GetString(6);
                            ce_sst.CabTipLic = reader.GetString(7);
                            ce_sst.CabUnidManj = reader.GetString(8);
                            ce_sst.CabFecMult = reader.GetString(9);
                            ce_sst.CabPuntConduct = reader.GetString(10);
                            ce_sst.CabEstado = reader.GetString(11);
                            //
                            ce_sst.Tar_ta = reader.GetString(12);
                            ce_sst.Sem_ta = reader.GetString(13);
                            ce_sst.Nota_ta = reader.GetString(14);
                            ce_sst.Tar_ez = reader.GetString(15);
                            ce_sst.Sem_ez = reader.GetString(16);
                            ce_sst.Nota_ez = reader.GetString(17);
                            ce_sst.Tar_tc = reader.GetString(18);
                            ce_sst.Sem_tc = reader.GetString(19);
                            ce_sst.Nota_tc = reader.GetString(20);
                            ce_sst.Tar_ec = reader.GetString(21);
                            ce_sst.Sem_ec = reader.GetString(22);
                            ce_sst.Nota_ec = reader.GetString(23);
                            //
                            ce_sst.Esp_map = reader.GetString(24);
                            ce_sst.Sem_map = reader.GetString(25);
                            ce_sst.Nota_map = reader.GetString(26);
                            ce_sst.Esp_rcs = reader.GetString(27);
                            ce_sst.Sem_rcs = reader.GetString(28);
                            ce_sst.Nota_rcs = reader.GetString(29);
                            ce_sst.Esp_hmp = reader.GetString(30);
                            ce_sst.Sem_hmp = reader.GetString(31);
                            ce_sst.Nota_hmp = reader.GetString(32);
                            ce_sst.Esp_vpp = reader.GetString(33);
                            ce_sst.Sem_vpp = reader.GetString(34);
                            ce_sst.Nota_vpp = reader.GetString(35);
                            ce_sst.Esp_ats = reader.GetString(36);
                            ce_sst.Sem_ast = reader.GetString(37);
                            ce_sst.Nota_ats = reader.GetString(38);
                            //
                            ce_sst.Bas_iperc = reader.GetString(39);
                            ce_sst.Sem_iperc = reader.GetString(40);
                            ce_sst.Nota_iperc = reader.GetString(41);
                            ce_sst.Bas_scc = reader.GetString(42);
                            ce_sst.Sem_scc = reader.GetString(43);
                            ce_sst.Nota_scc = reader.GetString(44);
                            ce_sst.Bas_epp = reader.GetString(45);
                            ce_sst.Sem_epp = reader.GetString(46);
                            ce_sst.Nota_epp = reader.GetString(47);
                            ce_sst.Bas_aci = reader.GetString(48);
                            ce_sst.Sem_aci = reader.GetString(49);
                            ce_sst.Nota_aci = reader.GetString(50);
                            //
                            ce_sst.Ext_er = reader.GetString(51);
                            ce_sst.Sem_er = reader.GetString(52);
                            ce_sst.Nota_er = reader.GetString(53);
                            ce_sst.Ext_ppi = reader.GetString(54);
                            ce_sst.Sem_ppi = reader.GetString(55);
                            ce_sst.Nota_ppi = reader.GetString(56);
                            ce_sst.Ext_eepp = reader.GetString(57);
                            ce_sst.Sem_eepp = reader.GetString(58);
                            ce_sst.Nota_eepp = reader.GetString(59);
                            ce_sst.Ext_rsa = reader.GetString(60);
                            ce_sst.Sem_rsa = reader.GetString(61);
                            ce_sst.Nota_rsa = reader.GetString(62);
                            //
                            ce_sst.Otr_maptel = reader.GetString(63);
                            ce_sst.Sem_maptel = reader.GetString(64);
                            ce_sst.Nota_maptel = reader.GetString(65);
                            ce_sst.Otr_tea = reader.GetString(66);
                            ce_sst.Sem_tea = reader.GetString(67);
                            ce_sst.Nota_tea = reader.GetString(68);
                            ce_sst.Otr_risst = reader.GetString(69);
                            ce_sst.Sem_risst = reader.GetString(70);
                            ce_sst.Nota_risst = reader.GetString(71);
                            //
                            ce_sst.Cab_Tipo_emp = reader.GetString(72);
                            ce_sst.CabEmpresa = reader.GetString(73);
                            ce_sst.CabSede = reader.GetString(74);
                            ce_sst.CabArea = reader.GetString(75);


                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }


        // METODO PARA ELIMINAR ACTIVO
        public void EliminarCapacitacionesCabeceraSST(int codigo, string dni, DateTime fecedit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_CAPACITACION_CABECERA_SST"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fecedit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR CESE DE CAPACITACION
        public void CeseCapacitacionesCabeceraSST(string dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_CAPACITACION_CESADO_SST"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = dni;
                    comando.ExecuteNonQuery();

                }
            }
        }
        // METODO PARA ACTUALIZAR CESE DE CAPACITACION INDIVIDUAL
        public void CeseCapacitacionesCabeceraIndividualSST(string dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_CAPACITACION_INDIVIDUAL_CESADO_SST"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = codigo;
                    comando.Parameters.AddWithValue("@Doc", SqlDbType.VarChar).Value = dni;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        //INSPECCIONES SST
        //  


        // MOSTRAR LISTA DE CAPACITACIONES EXTINTOR
        public DataTable ListaInspeccionesFiltroSST_Extintor(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_EXTINTOR", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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


        //


        // MOSTRAR LISTA DE CAPACITACIONES DUCHA LAVA OJOS
        public DataTable ListaInspeccionesFiltroSST_DuchaLavaOjos(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_DUCHALAVAOJOS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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



        // MOSTRAR LISTA DE CAPACITACIONES LAVA OJOS PORTATIL
        public DataTable ListaInspeccionesFiltroSST_LavaOjosPortatil(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_LAVAOJOSPORTATIL", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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


        //


        // MOSTRAR LISTA DE CAPACITACIONES KIT ANTIDERRAME
        public DataTable ListaInspeccionesFiltroSST_KitAntiDerrame(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_KITANTIDERRAME", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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


        //

        // MOSTRAR LISTA DE CAPACITACIONES LUCES EMERGENCIA
        public DataTable ListaInspeccionesFiltroSST_LucesEmergencia(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_LUCESEMERGENCIA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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




        //

        // MOSTRAR LISTA DE CAPACITACIONES LUCES EMERGENCIA
        public DataTable ListaInspeccionesFiltroSST_AlarmasEmergencia(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_ALARMASEMERGENCIA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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



        // MOSTRAR LISTA DE SEGURIDAD RESERVORIO
        public DataTable ListaInspeccionesFiltroSST_SeguridadReservorio(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_SEGURIDAD_RESERVORIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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


        //


        // MOSTRAR LISTA DE ARNES
        public DataTable ListaInspeccionesFiltroSST_Arnes(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_ARNES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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




        // MOSTRAR LISTA DE ARNES
        public DataTable ListaInspeccionesFiltroSST_Escalera(DateTime fecini, DateTime fecfin
            , string emp, string sed,
            string area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("LISTA_INSPECCION_FILTRO_SST_ESCALERA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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



        // METODO PARA GUARDAR CURSO CAPACITACION
        public void GuardarCursoCapacitacion(string codigo
            , string Empresa, string sede
            , string apenom, string dni, string Area, string RUC
            , string Cargo, string SedeCapacitacion, string FechaInduccion
            , string TrabajoAltura, string NotaTraAlt, string ExcavacionZanja
            , string NotaExcavZanja, string TrabajoCaliente
            , string NotaTrabCal, string EspacioConfinado, string NotaEspConf
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CURSO_CAPACITACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;

                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@RUC", SqlDbType.VarChar).Value = RUC;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@SedeCapacitacion", SqlDbType.VarChar).Value = SedeCapacitacion;
                    comando.Parameters.AddWithValue("@FechaInduccion", SqlDbType.VarChar).Value = FechaInduccion;
                    comando.Parameters.AddWithValue("@TrabajoAltura", SqlDbType.VarChar).Value = TrabajoAltura;
                    comando.Parameters.AddWithValue("@NotaTraAlt", SqlDbType.VarChar).Value = NotaTraAlt;

                    comando.Parameters.AddWithValue("@ExcavacionZanja", SqlDbType.VarChar).Value = ExcavacionZanja;
                    comando.Parameters.AddWithValue("@NotaExcavZanja", SqlDbType.VarChar).Value = NotaExcavZanja;
                    comando.Parameters.AddWithValue("@TrabajoCaliente", SqlDbType.VarChar).Value = TrabajoCaliente;
                    comando.Parameters.AddWithValue("@NotaTrabCal", SqlDbType.VarChar).Value = NotaTrabCal;
                    comando.Parameters.AddWithValue("@EspacioConfinado", SqlDbType.VarChar).Value = EspacioConfinado;
                    comando.Parameters.AddWithValue("@NotaEspConf", SqlDbType.VarChar).Value = NotaEspConf;

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


        // METODO PARA GUARDAR CURSO CAPACITACION LOGISTICA
        public void GuardarCursoCapacitacionLogistica(string codigo
            , string apenom, string dni, string RUC, string razonsocial
            , string Cargo, string FechaInduccion, string destrab
            , string HombreNuevo, string TrabajoAltura
            , string TrabajoCaliente, string ExcavZanja, string area
            , string lugar, string Empresa, string sede
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_LOG_CAPACITACIONESDETERCEROS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sec", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@NombreApellidos", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@DNI", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@RUC", SqlDbType.VarChar).Value = RUC;
                    comando.Parameters.AddWithValue("@RazonSocial", SqlDbType.VarChar).Value = razonsocial;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;

                    comando.Parameters.AddWithValue("@DiaInduccion", SqlDbType.VarChar).Value = FechaInduccion;
                    comando.Parameters.AddWithValue("@DescripcionTrabajo", SqlDbType.VarChar).Value = destrab;
                    comando.Parameters.AddWithValue("@HombreNuevo", SqlDbType.VarChar).Value = HombreNuevo;
                    comando.Parameters.AddWithValue("@TrabajosEnAltura", SqlDbType.VarChar).Value = TrabajoAltura;

                    comando.Parameters.AddWithValue("@TrabajosEnCaliente", SqlDbType.VarChar).Value = TrabajoCaliente;
                    comando.Parameters.AddWithValue("@ExcavacionZanjas", SqlDbType.VarChar).Value = ExcavZanja;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@LugarCapacitacion", SqlDbType.VarChar).Value = lugar;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;

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

        // METODO PARA GUARDAR PORG TERCEROS
        public void GuardarProgramacionTerceros(string sem
            , string RUC, string razonsocial
            , string numOS, string destrab
            , string lugarTrabajo, string sede
            , string AreaSol, string Jefatura, string cantTrab
            , string FecIni, string FecFin, string obs
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_PV_PROGRAMACIONTERCEROS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@RUC", SqlDbType.VarChar).Value = RUC;
                    comando.Parameters.AddWithValue("@Proveedor", SqlDbType.VarChar).Value = razonsocial;
                    comando.Parameters.AddWithValue("@NumeroOS", SqlDbType.VarChar).Value = numOS;

                    comando.Parameters.AddWithValue("@DescripcionTrabajo", SqlDbType.VarChar).Value = destrab;
                    comando.Parameters.AddWithValue("@LugarTrabajo", SqlDbType.VarChar).Value = lugarTrabajo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@AreaSolicitante", SqlDbType.VarChar).Value = AreaSol;
                    comando.Parameters.AddWithValue("@Jefatura", SqlDbType.VarChar).Value = Jefatura;
                    comando.Parameters.AddWithValue("@CantidadTrabajadores", SqlDbType.VarChar).Value = cantTrab;
                    comando.Parameters.AddWithValue("@FechaInicio", SqlDbType.VarChar).Value = FecIni;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = FecFin;
                    comando.Parameters.AddWithValue("@Observaciones", SqlDbType.VarChar).Value = obs;

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


        // METODO PARA GUARDAR CURSO CAPACITACION
        public void GuardarCursoRitran(string codigo, string Empresa, string sede
            , string apenom, string dni, string Area, string RUC
            , string Cargo, string fechaMTC, string FechaCap, string FecVenRitran
            , string NotaExamen, string FechaEntrega, string UnidadManejar
            , string FechaMulta, string PuntoSancionado
            , string Obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CURSO_RITRAN"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;

                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@RUC", SqlDbType.VarChar).Value = RUC;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;

                    comando.Parameters.AddWithValue("@FechaVencMTC", SqlDbType.VarChar).Value = fechaMTC;
                    comando.Parameters.AddWithValue("@FechaCapacitacion", SqlDbType.VarChar).Value = FechaCap;
                    comando.Parameters.AddWithValue("@FechaVencRitran", SqlDbType.VarChar).Value = FecVenRitran;
                    comando.Parameters.AddWithValue("@NotaExamen", SqlDbType.VarChar).Value = NotaExamen;
                    comando.Parameters.AddWithValue("@FechaEntrega", SqlDbType.VarChar).Value = FechaEntrega;

                    comando.Parameters.AddWithValue("@UnidadManejar", SqlDbType.VarChar).Value = UnidadManejar;
                    comando.Parameters.AddWithValue("@FechaMulta", SqlDbType.VarChar).Value = FechaMulta;
                    comando.Parameters.AddWithValue("@PuntoSancionado", SqlDbType.VarChar).Value = PuntoSancionado;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = Obs;

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

        //

    }
}
