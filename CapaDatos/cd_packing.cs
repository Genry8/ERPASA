using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_packing : cd_conexion
    {

        // MOSTRAR LISTA DE CULTIVO
        public DataTable ListaCultivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_CULTIVO", conex);
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

        // MOSTRAR LISTA DE NAVE
        public DataTable ListaNave()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_DESTAJO_NAVE", conex);
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


        // MOSTRAR LISTA DE NAVE
        public DataTable ListaLinea()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_DESTAJO_LINEA", conex);
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

        // MOSTRAR LISTA DE NAVE
        public DataTable ListaPuestoTrabajo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_DESTAJO_PUESTOTRABAJO", conex);
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


        // MOSTRAR LISTA CAMPAÑA
        public DataTable ListaCampana()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_CAMPANA", conex);
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

        // MOSTRAR LISTA TIPO MERMA
        public DataTable ListaTipoMerma()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TIPOMERMA", conex);
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


        // MOSTRAR LISTA TIPO MAQUINARIA
        public DataTable ListaTipoMaquinaria()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_MAQUINA_PACKING", conex);
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

        // MOSTRAR LISTA TIPO MAQUINARIA
        public DataTable ListaPackingTurno()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TURNO_PACKING", conex);
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


        // MOSTRAR LISTA TIPO MAQUINARIA CULTIVO
        public DataTable ListaTipoMaquinariaCultivo(string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_MAQUINA_CULTIVO_PACKING", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
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




        // MOSTRAR LISTA TIPO MAQUINARIA
        public DataTable ListaMaquinariaFiler()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_MAQUINA_FILER_PACKING", conex);
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


        // MOSTRAR LISTA FILTRO TIPO MAQUINARIA
        public DataTable ListaFiltroMaquinariaFiler(string maq)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_FILTRO_MAQUINA_FILER_PACKING", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
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


        // METODO PARA LLAMAR SI EXISTE MERMA
        public bool BuscExisteMerma(string emp, string sed, DateTime fecha, string tipo)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TOMAMUESTRA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@TipoMerma", SqlDbType.VarChar).Value = tipo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniCompen = reader.GetString(0);
                            //ce_planilla.FechaCompen = reader.GetDateTime(1);
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


        // METODO PARA LLAMAR SI EXISTE ORDEN
        public bool BuscExisteOrdenPRD(string emp, string sed
            , DateTime fechaIni, DateTime fechafin)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_ORDEN_PRODUCCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fechaIni;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.Date).Value = fechafin;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniCompen = reader.GetString(0);
                            //ce_planilla.FechaCompen = reader.GetDateTime(1);
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


        // METODO PARA ELIMINAR ORDEN
        public bool EliminarOrdenPRD(string emp, string sed, string cultivo
            , DateTime fechaIni, DateTime fechafin)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_ORDEN_PRODUCCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fechaIni;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.Date).Value = fechafin;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniCompen = reader.GetString(0);
                            //ce_planilla.FechaCompen = reader.GetDateTime(1);
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

        public bool EliminarOrdenPRD_AR(string emp, string sed, string cultivo
            , DateTime fechaIni, DateTime fechafin)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_ORDEN_PRODUCCION_AR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fechaIni;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.Date).Value = fechafin;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniCompen = reader.GetString(0);
                            //ce_planilla.FechaCompen = reader.GetDateTime(1);
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


        // METODO PARA LLAMAR SI EXISTE ORDEN
        public bool BuscExistePresentacion(string emp, string sed
            , string presentacion)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_ORDEN_PRODUCCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniCompen = reader.GetString(0);
                            //ce_planilla.FechaCompen = reader.GetDateTime(1);
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


        // METODO PARA GUARDAR MERMA
        public void GuardarMerma(DateTime fechaproc, DateTime fechacos, string tipomateria
            , string emp, string sed, string cultivo, string campana, string maquina
            , string varieddad, decimal pesobruto, decimal pesotara, decimal pesoneto
            , string obs, string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PACK_MermaContramuestra"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@FechaProceso", SqlDbType.Date).Value = fechaproc;
                    comando.Parameters.AddWithValue("@FecCosecha", SqlDbType.Date).Value = fechacos;
                    comando.Parameters.AddWithValue("@TipoMateria", SqlDbType.VarChar).Value = tipomateria;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = campana;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = varieddad;
                    comando.Parameters.AddWithValue("@PesoBruto", SqlDbType.Decimal).Value = pesobruto;
                    comando.Parameters.AddWithValue("@PesoTara", SqlDbType.Decimal).Value = pesotara;
                    comando.Parameters.AddWithValue("@PesoNeto", SqlDbType.Decimal).Value = pesoneto;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.Decimal).Value = obs;

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



        // METODO PARA GUARDAR ORDEN PRD
        public void GuardarOrdenPRD(string fechaini, string fechafin, string cultivo
            , string campana, string emp, string sed, string año, string sem
            , string num_cont, string prioridad, string orden, string cliente
            , string destino, string presentacion, string comentario, string calidad
            , string calibre, string timbrado, string cajas, string pallets, string FechaDespacho
            , string obs, string hoja, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_OrdenesProduccion"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fechaini;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.Date).Value = fechafin;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Campaña", SqlDbType.VarChar).Value = campana;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Num_cont", SqlDbType.VarChar).Value = num_cont;
                    comando.Parameters.AddWithValue("@Prioridad", SqlDbType.VarChar).Value = prioridad;
                    comando.Parameters.AddWithValue("@Orden", SqlDbType.VarChar).Value = orden;
                    comando.Parameters.AddWithValue("@Cliente", SqlDbType.VarChar).Value = cliente;
                    comando.Parameters.AddWithValue("@Destino", SqlDbType.VarChar).Value = destino;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Comentarios", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Calidad", SqlDbType.VarChar).Value = calidad;
                    comando.Parameters.AddWithValue("@Calibre", SqlDbType.VarChar).Value = calibre;
                    comando.Parameters.AddWithValue("@Timbrado", SqlDbType.VarChar).Value = timbrado;
                    comando.Parameters.AddWithValue("@Cajas", SqlDbType.VarChar).Value = cajas;
                    comando.Parameters.AddWithValue("@Pallets", SqlDbType.VarChar).Value = pallets;
                    comando.Parameters.AddWithValue("@FechaDespacho", SqlDbType.VarChar).Value = FechaDespacho;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.Decimal).Value = obs;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.Decimal).Value = hoja;
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

        // MÉTODO PARA GUARDAR ORDEN PRD ARÁNDANO
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
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_OrdenesProduccionAR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;

                    conexion.Open();

                    comando.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaini;
                    comando.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechafin;
                    comando.Parameters.Add("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.Add("@Campaña", SqlDbType.VarChar).Value = campana;
                    comando.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.Add("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.Add("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.Add("@Semana", SqlDbType.VarChar).Value = sem;

                    // NUEVOS CAMPOS SEGÚN TU GRID
                    comando.Parameters.Add("@Exportador", SqlDbType.VarChar).Value = exportador;
                    comando.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = cliente;
                    comando.Parameters.Add("@Prioridad", SqlDbType.VarChar).Value = prioridad;
                    comando.Parameters.Add("@OrdenNumero", SqlDbType.VarChar).Value = orden;
                    comando.Parameters.Add("@Destino", SqlDbType.VarChar).Value = destino;
                    comando.Parameters.Add("@Via", SqlDbType.VarChar).Value = calidadVia;
                    comando.Parameters.Add("@Tecnologia", SqlDbType.VarChar).Value = tecnologia;
                    comando.Parameters.Add("@AC", SqlDbType.VarChar).Value = ac;
                    comando.Parameters.Add("@PackStyle", SqlDbType.VarChar).Value = packStyle;
                    comando.Parameters.Add("@Variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.Add("@RestriccionesCabezal", SqlDbType.VarChar).Value = restCabezal;
                    comando.Parameters.Add("@Calibre", SqlDbType.VarChar).Value = calibre;
                    comando.Parameters.Add("@EquivPallets", SqlDbType.VarChar).Value = equivPalets;

                    comando.Parameters.Add("@FechaDespacho", SqlDbType.VarChar).Value = fechaDespacho;

                    comando.Parameters.Add("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.Add("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.Add("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.Add("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.Add("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.Add("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.Add("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.Add("@UseElim", SqlDbType.Int).Value = useelim;

                    comando.ExecuteNonQuery();
                }
            }
        }


        // METODO PARA GUARDAR ACTUALIZAR PROG VOLCADO
        public void GuardarActualizarProgVolcado(
            string prog, string idRec, string numPalet
            , string fecProg, string turno, string maq, string linea
            , string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PROGRAMACION_VOLCADO_MAQUINA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Programado", SqlDbType.Bit).Value = prog;
                    comando.Parameters.AddWithValue("@IdRec", SqlDbType.VarChar).Value = idRec;
                    comando.Parameters.AddWithValue("@NumeroPallet", SqlDbType.VarChar).Value = numPalet;
                    comando.Parameters.AddWithValue("@FecProgramado", SqlDbType.VarChar).Value = fecProg;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maq;
                    comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.Decimal).Value = obs;
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
        public void GuardarActualizarProgPresentacion(
            string empresa, string sede, string fecProg
            , string cultivo, string maq, string turno, string linea
            , string presentacion, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PROGRAMACION_PRESENTACION_MAQUINA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@FecProgramado", SqlDbType.VarChar).Value = fecProg;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maq;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.Decimal).Value = obs;
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
        public bool BuscarPaletProgVolcado(string id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_MOSTRAR_LISTA_PALET_PROGRAMADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniCompen = reader.GetString(0);
                            //ce_planilla.FechaCompen = reader.GetDateTime(1);
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


        // METODO PARA GUARDAR ORDEN PRD
        public void GuardarPresentacion(string cod, string emp, string sed
            , string cultivo, string presentacion, decimal peso, string cajas
            , string comentario, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PACK_PresentacionPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Peso", SqlDbType.Decimal).Value = peso;
                    comando.Parameters.AddWithValue("@Cajas", SqlDbType.VarChar).Value = cajas;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
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



        // METODO PARA ACTUALIZAR MERMA
        public void ActualizarMerma(int cod, string tipomateria
            , string maquina, string varieddad, decimal pesoneto
            , string obs, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_MermaContramuestra"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@TipoMateria", SqlDbType.VarChar).Value = tipomateria;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = varieddad;
                    comando.Parameters.AddWithValue("@PesoNeto", SqlDbType.Decimal).Value = pesoneto;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.Decimal).Value = obs;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA ACTUALIZAR ORDER PRODUCCION
        public void ActualizarOrdenPRD(int cod, string numcont
            , string prioridad, string orden, string cliente
            , string destino, string presentacion, string calibre
            , string cajas, string pallets
            , string obs, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_OrdenProduccion"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Num_cont", SqlDbType.VarChar).Value = numcont;
                    comando.Parameters.AddWithValue("@Prioridad", SqlDbType.VarChar).Value = prioridad;
                    comando.Parameters.AddWithValue("@Orden", SqlDbType.VarChar).Value = orden;
                    comando.Parameters.AddWithValue("@Cliente", SqlDbType.VarChar).Value = cliente;
                    comando.Parameters.AddWithValue("@Destino", SqlDbType.VarChar).Value = destino;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Calibre", SqlDbType.VarChar).Value = calibre;
                    comando.Parameters.AddWithValue("@Cajas", SqlDbType.VarChar).Value = cajas;
                    comando.Parameters.AddWithValue("@Pallets", SqlDbType.VarChar).Value = pallets;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.Decimal).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA ACTUALIZAR ORDER PRODUCCION
        public void ActualizarPresentacion(int cod, string codpres, string presentacion
            , decimal peso, string cajas
            , string obs, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_PresentacionPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = codpres;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Peso", SqlDbType.VarChar).Value = peso;
                    comando.Parameters.AddWithValue("@Cajas", SqlDbType.VarChar).Value = cajas;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA ELIMINAR MERMA
        public void EliminarMerma(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_MermaContramuestra"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.Int).Value = Fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR ORDEN PRD
        public void EliminarOrdenPRD(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_OrdenProduccion"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.Int).Value = Fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ELIMINAR ORDEN PRD
        public void EliminarPresentacion(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_Presentacion"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.Int).Value = Fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // MOSTRAR LISTA GUIA PALLET
        public DataTable ListaGuiaPallet(int id, DateTime fecini, DateTime fecfin
            , string emp, string sed, string Cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GUIA_PALLET_FAC", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = Cultivo;
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


        // METODO PARA GUARDAR CIERRE PROCESO DIA
        public void GuardarCierreProcesoPacking(
            int id, DateTime fechaproc, bool status
            , string idnave, string nave
            , string idlinea, string linea, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim, string sesion)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_CIERRE_PROCESO_DIA_PACKING"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FechaProceso", SqlDbType.VarChar).Value = fechaproc;
                    comando.Parameters.AddWithValue("@Estatus", SqlDbType.Bit).Value = status;
                    comando.Parameters.AddWithValue("@IdNave", SqlDbType.VarChar).Value = idnave;
                    comando.Parameters.AddWithValue("@Nave", SqlDbType.VarChar).Value = nave;
                    comando.Parameters.AddWithValue("@IdLinea", SqlDbType.VarChar).Value = idlinea;
                    comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.Parameters.AddWithValue("@SessionId", SqlDbType.VarChar).Value = sesion;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // REPORTE CIERRE PROCESO PACKING
        public DataTable ReporteCierreProcesoPacking(int id,
            DateTime fecini)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_PROCESO_DIA_PACKING", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fecini;
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

        public void GuardarReqPersonalSemanalBulk(DataTable dt)
        {
            using (var conexion = leerconexion())
            {
                conexion.Open();

                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // =====================================================
                        // 1. CREAR TABLA TEMPORAL
                        // =====================================================

                        string sqlTemp = @"
                CREATE TABLE #Pack_ReqPersonalSemanal
                (
                    Anio INT,
                    Semana INT,
                    Fecha DATE,
                    Turno VARCHAR(20),
                    Supervisor VARCHAR(100),
                    Jefatura VARCHAR(100),
                    Area VARCHAR(150),
                    Labor_Sistema VARCHAR(180),
                    Cantidad INT,

                    Observacion VARCHAR(480),
                    Hoja VARCHAR(50),
                    Estado VARCHAR(20),
                    FecCre DATETIME,
                    UseReg INT,
                    Hostname VARCHAR(80),
                    FecEdit DATETIME,
                    UseEdit INT
                );";


                        using (SqlCommand comandoTemp = new SqlCommand(
                            sqlTemp,
                            conexion,
                            transaction))
                        {
                            comandoTemp.CommandTimeout = 0;
                            comandoTemp.ExecuteNonQuery();
                        }


                        // =====================================================
                        // 2. BULK COPY A TABLA TEMPORAL
                        // =====================================================

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                            conexion,
                            SqlBulkCopyOptions.Default,
                            transaction))
                        {
                            bulkCopy.DestinationTableName =
                                "#Pack_ReqPersonalSemanal";

                            bulkCopy.BatchSize = 2000;
                            bulkCopy.BulkCopyTimeout = 0;


                            bulkCopy.ColumnMappings.Add(
                                "Anio",
                                "Anio");

                            bulkCopy.ColumnMappings.Add(
                                "Semana",
                                "Semana");

                            bulkCopy.ColumnMappings.Add(
                                "Fecha",
                                "Fecha");

                            bulkCopy.ColumnMappings.Add(
                                "Turno",
                                "Turno");

                            bulkCopy.ColumnMappings.Add(
                                "Supervisor",
                                "Supervisor");

                            bulkCopy.ColumnMappings.Add(
                                "Jefatura",
                                "Jefatura");

                            bulkCopy.ColumnMappings.Add(
                                "Area",
                                "Area");

                            bulkCopy.ColumnMappings.Add(
                                "Labor_Sistema",
                                "Labor_Sistema");

                            bulkCopy.ColumnMappings.Add(
                                "Cantidad",
                                "Cantidad");


                            bulkCopy.ColumnMappings.Add(
                                "Observacion",
                                "Observacion");

                            bulkCopy.ColumnMappings.Add(
                                "Hoja",
                                "Hoja");

                            bulkCopy.ColumnMappings.Add(
                                "Estado",
                                "Estado");

                            bulkCopy.ColumnMappings.Add(
                                "FecCre",
                                "FecCre");

                            bulkCopy.ColumnMappings.Add(
                                "UseReg",
                                "UseReg");

                            bulkCopy.ColumnMappings.Add(
                                "Hostname",
                                "Hostname");

                            bulkCopy.ColumnMappings.Add(
                                "FecEdit",
                                "FecEdit");

                            bulkCopy.ColumnMappings.Add(
                                "UseEdit",
                                "UseEdit");


                            bulkCopy.WriteToServer(dt);
                        }


                        // =====================================================
                        // 3. EJECUTAR SP
                        // =====================================================

                        using (SqlCommand comando = new SqlCommand(
                            "SP_GUARDAR_PACK_REQ_PERSONAL_SEMANAL_BULK",
                            conexion,
                            transaction))
                        {
                            comando.CommandType =
                                CommandType.StoredProcedure;

                            comando.CommandTimeout = 0;

                            comando.ExecuteNonQuery();
                        }


                        // =====================================================
                        // 4. CONFIRMAR
                        // =====================================================

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void GuardarReqPersonalAnualBulk(DataTable dt)
        {
            using (var conexion = leerconexion())
            {
                conexion.Open();

                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // =====================================================
                        // 1. CREAR TABLA TEMPORAL
                        // =====================================================

                        string sqlTemp = @"
                CREATE TABLE #Pack_ReqPersonalAnual
                (
                    Anio INT,
                    Semana INT,
                    Fecha DATE,
                    Turno VARCHAR(20),
                    Supervisor VARCHAR(100),
                    Jefatura VARCHAR(100),
                    Area VARCHAR(150),
                    Labor_Sistema VARCHAR(180),
                    Cantidad INT,

                    Observacion VARCHAR(480),
                    Hoja VARCHAR(50),
                    Estado VARCHAR(20),
                    FecCre DATETIME,
                    UseReg INT,
                    Hostname VARCHAR(80),
                    FecEdit DATETIME,
                    UseEdit INT
                );";


                        using (SqlCommand comandoTemp = new SqlCommand(
                            sqlTemp,
                            conexion,
                            transaction))
                        {
                            comandoTemp.CommandTimeout = 0;
                            comandoTemp.ExecuteNonQuery();
                        }


                        // =====================================================
                        // 2. BULK COPY A TABLA TEMPORAL
                        // =====================================================

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                            conexion,
                            SqlBulkCopyOptions.Default,
                            transaction))
                        {
                            bulkCopy.DestinationTableName =
                                "#Pack_ReqPersonalAnual";

                            bulkCopy.BatchSize = 2000;
                            bulkCopy.BulkCopyTimeout = 0;


                            bulkCopy.ColumnMappings.Add(
                                "Anio",
                                "Anio");

                            bulkCopy.ColumnMappings.Add(
                                "Semana",
                                "Semana");

                            bulkCopy.ColumnMappings.Add(
                                "Fecha",
                                "Fecha");

                            bulkCopy.ColumnMappings.Add(
                                "Turno",
                                "Turno");

                            bulkCopy.ColumnMappings.Add(
                                "Supervisor",
                                "Supervisor");

                            bulkCopy.ColumnMappings.Add(
                                "Jefatura",
                                "Jefatura");

                            bulkCopy.ColumnMappings.Add(
                                "Area",
                                "Area");

                            bulkCopy.ColumnMappings.Add(
                                "Labor_Sistema",
                                "Labor_Sistema");

                            bulkCopy.ColumnMappings.Add(
                                "Cantidad",
                                "Cantidad");


                            bulkCopy.ColumnMappings.Add(
                                "Observacion",
                                "Observacion");

                            bulkCopy.ColumnMappings.Add(
                                "Hoja",
                                "Hoja");

                            bulkCopy.ColumnMappings.Add(
                                "Estado",
                                "Estado");

                            bulkCopy.ColumnMappings.Add(
                                "FecCre",
                                "FecCre");

                            bulkCopy.ColumnMappings.Add(
                                "UseReg",
                                "UseReg");

                            bulkCopy.ColumnMappings.Add(
                                "Hostname",
                                "Hostname");

                            bulkCopy.ColumnMappings.Add(
                                "FecEdit",
                                "FecEdit");

                            bulkCopy.ColumnMappings.Add(
                                "UseEdit",
                                "UseEdit");


                            bulkCopy.WriteToServer(dt);
                        }


                        // =====================================================
                        // 3. EJECUTAR SP
                        // =====================================================

                        using (SqlCommand comando = new SqlCommand(
                            "SP_GUARDAR_PACK_REQ_PERSONAL_ANUAL_BULK",
                            conexion,
                            transaction))
                        {
                            comando.CommandType =
                                CommandType.StoredProcedure;

                            comando.CommandTimeout = 0;

                            comando.ExecuteNonQuery();
                        }


                        // =====================================================
                        // 4. CONFIRMAR
                        // =====================================================

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }







    }
}
