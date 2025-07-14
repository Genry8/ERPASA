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
        public bool EliminarOrdenPRD(string emp, string sed
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

        // METODO PARA GUARDAR ACTUALIZAR PROG VOLCADO
        public void GuardarActualizarProgVolcado(
            string prog, string idRec, string numPalet
            , string fecProg,string turno, string maq, string linea
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




    }
}
