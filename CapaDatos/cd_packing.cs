using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_packing : cd_conexion
    {

        // MOSTRAR LISTA DE CULTIVO

        //
        //
        // PESO POR PRESENTACION (PACK_PesoPresentacion)
        //
        //

        // METODO PARA GUARDAR UN PESO DE PRESENTACION
        public void GuardarPesoPresentacion(
            string emp, string sed, string cultivo, string presentacion
            , decimal peso, decimal porcentajemin, decimal porcentaje, string obs
            , string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_PESO_PRESENTACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Peso", SqlDbType.Decimal).Value = peso;
                    comando.Parameters.AddWithValue("@PorcentajeMin", SqlDbType.Decimal).Value = porcentajemin;
                    comando.Parameters.AddWithValue("@Porcentaje", SqlDbType.Decimal).Value = porcentaje;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR UN PESO DE PRESENTACION
        public void ActualizarPesoPresentacion(int id,
            string emp, string sed, string cultivo, string presentacion
            , decimal peso, decimal porcentajemin, decimal porcentaje, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_PESO_PRESENTACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Peso", SqlDbType.Decimal).Value = peso;
                    comando.Parameters.AddWithValue("@PorcentajeMin", SqlDbType.Decimal).Value = porcentajemin;
                    comando.Parameters.AddWithValue("@Porcentaje", SqlDbType.Decimal).Value = porcentaje;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA) UN PESO DE PRESENTACION
        public void EliminarPesoPresentacion(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_PESO_PRESENTACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // MOSTRAR LISTA DE PESOS POR PRESENTACION
        public DataTable ListaReportePesoPresentacion(string emp, string sed, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_PESO_PRESENTACION", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
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


        // VERIFICA SI YA EXISTE ESA PRESENTACION PARA LA MISMA EMPRESA, SEDE Y
        // CULTIVO. Al editar se pasa el Id para no chocar consigo mismo.
        public bool BuscExistePesoPresentacion(string emp, string sed, string cultivo,
            string presentacion, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_PESO_PRESENTACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }




        //
        // MAESTRO PACK_Cultivo (PACK_Cultivo)
        //

        // MOSTRAR LISTA DE PACK_Cultivo
        public DataTable ListaMaestroCultivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CULTIVO", conex);
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


        // METODO PARA GUARDAR EN PACK_Cultivo
        public void GuardarMaestroCultivo(string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CULTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Cultivo
        public void ActualizarMaestroCultivo(int id, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CULTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Cultivo
        public void EliminarMaestroCultivo(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CULTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Cultivo
        public bool BuscExisteMaestroCultivo(string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CULTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Campana (PACK_Campana)
        //

        // MOSTRAR LISTA DE PACK_Campana
        public DataTable ListaMaestroCampana()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CAMPANA", conex);
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


        // METODO PARA GUARDAR EN PACK_Campana
        public void GuardarMaestroCampana(string campana, string descripcion, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CAMPANA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = campana;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Campana
        public void ActualizarMaestroCampana(int id, string campana, string descripcion, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CAMPANA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = campana;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Campana
        public void EliminarMaestroCampana(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CAMPANA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Campana
        public bool BuscExisteMaestroCampana(string campana, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CAMPANA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = campana;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Categoria (PACK_Categoria)
        //

        // MOSTRAR LISTA DE PACK_Categoria
        public DataTable ListaMaestroCategoria()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CATEGORIA", conex);
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


        // METODO PARA GUARDAR EN PACK_Categoria
        public void GuardarMaestroCategoria(string categoria, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CATEGORIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Categoria", SqlDbType.VarChar).Value = categoria;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Categoria
        public void ActualizarMaestroCategoria(int id, string categoria, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CATEGORIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Categoria", SqlDbType.VarChar).Value = categoria;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Categoria
        public void EliminarMaestroCategoria(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CATEGORIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Categoria
        public bool BuscExisteMaestroCategoria(string categoria, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CATEGORIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Categoria", SqlDbType.VarChar).Value = categoria;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Calibre (PACK_Calibre)
        //

        // MOSTRAR LISTA DE PACK_Calibre
        public DataTable ListaMaestroCalibre()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CALIBRE", conex);
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


        // METODO PARA GUARDAR EN PACK_Calibre
        public void GuardarMaestroCalibre(string codcalibre, string calibre, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CALIBRE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodCalibre", SqlDbType.VarChar).Value = codcalibre;
                    comando.Parameters.AddWithValue("@Calibre", SqlDbType.VarChar).Value = calibre;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Calibre
        public void ActualizarMaestroCalibre(int id, string codcalibre, string calibre, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CALIBRE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CodCalibre", SqlDbType.VarChar).Value = codcalibre;
                    comando.Parameters.AddWithValue("@Calibre", SqlDbType.VarChar).Value = calibre;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Calibre
        public void EliminarMaestroCalibre(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CALIBRE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Calibre
        public bool BuscExisteMaestroCalibre(string calibre, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CALIBRE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Calibre", SqlDbType.VarChar).Value = calibre;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Cabezal (PACK_Cabezal)
        //

        // MOSTRAR LISTA DE PACK_Cabezal
        public DataTable ListaMaestroCabezal()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CABEZAL", conex);
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


        // METODO PARA GUARDAR EN PACK_Cabezal
        public void GuardarMaestroCabezal(string cabezal, string cultivo, string sede, string ncorto, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CABEZAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@NCorto", SqlDbType.VarChar).Value = ncorto;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Cabezal
        public void ActualizarMaestroCabezal(int id, string cabezal, string cultivo, string sede, string ncorto, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CABEZAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@NCorto", SqlDbType.VarChar).Value = ncorto;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Cabezal
        public void EliminarMaestroCabezal(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CABEZAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Cabezal
        public bool BuscExisteMaestroCabezal(string cabezal, string cultivo, string sede, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CABEZAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_CabezalPT (PACK_CabezalPT)
        //

        // MOSTRAR LISTA DE PACK_CabezalPT
        public DataTable ListaMaestroCabezalPT()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CABEZALPT", conex);
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


        // METODO PARA GUARDAR EN PACK_CabezalPT
        public void GuardarMaestroCabezalPT(string codcab, string cabezal, string cultivo, string sede, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CABEZALPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodCab", SqlDbType.VarChar).Value = codcab;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_CabezalPT
        public void ActualizarMaestroCabezalPT(int id, string codcab, string cabezal, string cultivo, string sede, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CABEZALPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CodCab", SqlDbType.VarChar).Value = codcab;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_CabezalPT
        public void EliminarMaestroCabezalPT(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CABEZALPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_CabezalPT
        public bool BuscExisteMaestroCabezalPT(string cabezal, string cultivo, string sede, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CABEZALPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Camara (PACK_Camara)
        //

        // MOSTRAR LISTA DE PACK_Camara
        public DataTable ListaMaestroCamara()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CAMARA", conex);
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


        // METODO PARA GUARDAR EN PACK_Camara
        public void GuardarMaestroCamara(string camara, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CAMARA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Camara", SqlDbType.VarChar).Value = camara;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Camara
        public void ActualizarMaestroCamara(int id, string camara, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CAMARA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Camara", SqlDbType.VarChar).Value = camara;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Camara
        public void EliminarMaestroCamara(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CAMARA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Camara
        public bool BuscExisteMaestroCamara(string camara, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CAMARA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Camara", SqlDbType.VarChar).Value = camara;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_CamaraFrio (PACK_CamaraFrio)
        //

        // MOSTRAR LISTA DE PACK_CamaraFrio
        public DataTable ListaMaestroCamaraFrio()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CAMARAFRIO", conex);
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


        // METODO PARA GUARDAR EN PACK_CamaraFrio
        public void GuardarMaestroCamaraFrio(string camarafrio, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CAMARAFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CamaraFrio", SqlDbType.VarChar).Value = camarafrio;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_CamaraFrio
        public void ActualizarMaestroCamaraFrio(int id, string camarafrio, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CAMARAFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CamaraFrio", SqlDbType.VarChar).Value = camarafrio;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_CamaraFrio
        public void EliminarMaestroCamaraFrio(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CAMARAFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_CamaraFrio
        public bool BuscExisteMaestroCamaraFrio(string camarafrio, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CAMARAFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CamaraFrio", SqlDbType.VarChar).Value = camarafrio;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_CamaraPreFrio (PACK_CamaraPreFrio)
        //

        // MOSTRAR LISTA DE PACK_CamaraPreFrio
        public DataTable ListaMaestroCamaraPreFrio()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CAMARAPREFRIO", conex);
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


        // METODO PARA GUARDAR EN PACK_CamaraPreFrio
        public void GuardarMaestroCamaraPreFrio(string camaraprefrio, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CAMARAPREFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CamaraPreFrio", SqlDbType.VarChar).Value = camaraprefrio;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_CamaraPreFrio
        public void ActualizarMaestroCamaraPreFrio(int id, string camaraprefrio, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CAMARAPREFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CamaraPreFrio", SqlDbType.VarChar).Value = camaraprefrio;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_CamaraPreFrio
        public void EliminarMaestroCamaraPreFrio(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CAMARAPREFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_CamaraPreFrio
        public bool BuscExisteMaestroCamaraPreFrio(string camaraprefrio, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CAMARAPREFRIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CamaraPreFrio", SqlDbType.VarChar).Value = camaraprefrio;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_CamaraGasificado (PACK_CamaraGasificado)
        //

        // MOSTRAR LISTA DE PACK_CamaraGasificado
        public DataTable ListaMaestroCamaraGasificado()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_CAMARAGASIFICADO", conex);
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


        // METODO PARA GUARDAR EN PACK_CamaraGasificado
        public void GuardarMaestroCamaraGasificado(string camaragasificado, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_CAMARAGASIFICADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CamaraGasificado", SqlDbType.VarChar).Value = camaragasificado;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_CamaraGasificado
        public void ActualizarMaestroCamaraGasificado(int id, string camaragasificado, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_CAMARAGASIFICADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CamaraGasificado", SqlDbType.VarChar).Value = camaragasificado;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_CamaraGasificado
        public void EliminarMaestroCamaraGasificado(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_CAMARAGASIFICADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_CamaraGasificado
        public bool BuscExisteMaestroCamaraGasificado(string camaragasificado, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_CAMARAGASIFICADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CamaraGasificado", SqlDbType.VarChar).Value = camaragasificado;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Maquinaria (PACK_Maquinaria)
        //

        // MOSTRAR LISTA DE PACK_Maquinaria
        public DataTable ListaMaestroMaquinaria()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_MAQUINARIA", conex);
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


        // METODO PARA GUARDAR EN PACK_Maquinaria
        public void GuardarMaestroMaquinaria(string maquina, string cultivo, string maqcorto, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@MaqCorto", SqlDbType.VarChar).Value = maqcorto;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Maquinaria
        public void ActualizarMaestroMaquinaria(int id, string maquina, string cultivo, string maqcorto, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@MaqCorto", SqlDbType.VarChar).Value = maqcorto;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Maquinaria
        public void EliminarMaestroMaquinaria(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Maquinaria
        public bool BuscExisteMaestroMaquinaria(string maquina, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_FilerMaquina (PACK_FilerMaquina)
        //

        // MOSTRAR LISTA DE PACK_FilerMaquina
        public DataTable ListaMaestroFilerMaquina()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_FILERMAQUINA", conex);
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


        // METODO PARA GUARDAR EN PACK_FilerMaquina
        public void GuardarMaestroFilerMaquina(string maquina, string filer, string cultivo, int ord, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_FILERMAQUINA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Filer", SqlDbType.VarChar).Value = filer;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Ord", SqlDbType.Int).Value = ord;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_FilerMaquina
        public void ActualizarMaestroFilerMaquina(int id, string maquina, string filer, string cultivo, int ord, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_FILERMAQUINA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Filer", SqlDbType.VarChar).Value = filer;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Ord", SqlDbType.Int).Value = ord;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_FilerMaquina
        public void EliminarMaestroFilerMaquina(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_FILERMAQUINA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_FilerMaquina
        public bool BuscExisteMaestroFilerMaquina(string maquina, string filer, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_FILERMAQUINA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquina;
                    comando.Parameters.AddWithValue("@Filer", SqlDbType.VarChar).Value = filer;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Estilos (PACK_Estilos)
        //

        // MOSTRAR LISTA DE PACK_Estilos
        public DataTable ListaMaestroEstilos()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_ESTILOS", conex);
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


        // METODO PARA GUARDAR EN PACK_Estilos
        public void GuardarMaestroEstilos(string style, string presentacion, string cultivo, string sede, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_ESTILOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Style", SqlDbType.VarChar).Value = style;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Estilos
        public void ActualizarMaestroEstilos(int id, string style, string presentacion, string cultivo, string sede, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_ESTILOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Style", SqlDbType.VarChar).Value = style;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Estilos
        public void EliminarMaestroEstilos(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_ESTILOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Estilos
        public bool BuscExisteMaestroEstilos(string style, string cultivo, string sede, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_ESTILOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Style", SqlDbType.VarChar).Value = style;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_EmpaqueProceso (PACK_EmpaqueProceso)
        //

        // MOSTRAR LISTA DE PACK_EmpaqueProceso
        public DataTable ListaMaestroEmpaqueProceso()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_EMPAQUEPROCESO", conex);
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


        // METODO PARA GUARDAR EN PACK_EmpaqueProceso
        public void GuardarMaestroEmpaqueProceso(string empaque_proceso, string empresa, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_EMPAQUEPROCESO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empaque_Proceso", SqlDbType.VarChar).Value = empaque_proceso;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_EmpaqueProceso
        public void ActualizarMaestroEmpaqueProceso(int id, string empaque_proceso, string empresa, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_EMPAQUEPROCESO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Empaque_Proceso", SqlDbType.VarChar).Value = empaque_proceso;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_EmpaqueProceso
        public void EliminarMaestroEmpaqueProceso(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_EMPAQUEPROCESO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_EmpaqueProceso
        public bool BuscExisteMaestroEmpaqueProceso(string empaque_proceso, string empresa, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_EMPAQUEPROCESO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empaque_Proceso", SqlDbType.VarChar).Value = empaque_proceso;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_TipoParihuela (PACK_TipoParihuela)
        //

        // MOSTRAR LISTA DE PACK_TipoParihuela
        public DataTable ListaMaestroTipoParihuela()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TIPOPARIHUELA", conex);
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


        // METODO PARA GUARDAR EN PACK_TipoParihuela
        public void GuardarMaestroTipoParihuela(string parihuela, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TIPOPARIHUELA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Parihuela", SqlDbType.VarChar).Value = parihuela;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_TipoParihuela
        public void ActualizarMaestroTipoParihuela(int id, string parihuela, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TIPOPARIHUELA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Parihuela", SqlDbType.VarChar).Value = parihuela;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_TipoParihuela
        public void EliminarMaestroTipoParihuela(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TIPOPARIHUELA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_TipoParihuela
        public bool BuscExisteMaestroTipoParihuela(string parihuela, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TIPOPARIHUELA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Parihuela", SqlDbType.VarChar).Value = parihuela;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_TipoPaLlet (PACK_TipoPaLlet)
        //

        // MOSTRAR LISTA DE PACK_TipoPaLlet
        public DataTable ListaMaestroTipoPaLlet()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TIPOPALLET", conex);
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


        // METODO PARA GUARDAR EN PACK_TipoPaLlet
        public void GuardarMaestroTipoPaLlet(string tipopalet, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TIPOPALLET"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoPalet", SqlDbType.VarChar).Value = tipopalet;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_TipoPaLlet
        public void ActualizarMaestroTipoPaLlet(int id, string tipopalet, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TIPOPALLET"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@TipoPalet", SqlDbType.VarChar).Value = tipopalet;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_TipoPaLlet
        public void EliminarMaestroTipoPaLlet(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TIPOPALLET"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_TipoPaLlet
        public bool BuscExisteMaestroTipoPaLlet(string tipopalet, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TIPOPALLET"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoPalet", SqlDbType.VarChar).Value = tipopalet;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_TipoMateria (PACK_TipoMateria)
        //

        // MOSTRAR LISTA DE PACK_TipoMateria
        public DataTable ListaMaestroTipoMateria()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TIPOMATERIA", conex);
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


        // METODO PARA GUARDAR EN PACK_TipoMateria
        public void GuardarMaestroTipoMateria(string tipomateria, string grupomateria, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TIPOMATERIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoMateria", SqlDbType.VarChar).Value = tipomateria;
                    comando.Parameters.AddWithValue("@GrupoMateria", SqlDbType.VarChar).Value = grupomateria;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_TipoMateria
        public void ActualizarMaestroTipoMateria(int id, string tipomateria, string grupomateria, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TIPOMATERIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@TipoMateria", SqlDbType.VarChar).Value = tipomateria;
                    comando.Parameters.AddWithValue("@GrupoMateria", SqlDbType.VarChar).Value = grupomateria;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_TipoMateria
        public void EliminarMaestroTipoMateria(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TIPOMATERIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_TipoMateria
        public bool BuscExisteMaestroTipoMateria(string tipomateria, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TIPOMATERIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoMateria", SqlDbType.VarChar).Value = tipomateria;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_TipoCosecha (PACK_TipoCosecha)
        //

        // MOSTRAR LISTA DE PACK_TipoCosecha
        public DataTable ListaMaestroTipoCosecha()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TIPOCOSECHA", conex);
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


        // METODO PARA GUARDAR EN PACK_TipoCosecha
        public void GuardarMaestroTipoCosecha(string tipocosecha, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TIPOCOSECHA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoCosecha", SqlDbType.VarChar).Value = tipocosecha;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_TipoCosecha
        public void ActualizarMaestroTipoCosecha(int id, string tipocosecha, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TIPOCOSECHA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@TipoCosecha", SqlDbType.VarChar).Value = tipocosecha;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_TipoCosecha
        public void EliminarMaestroTipoCosecha(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TIPOCOSECHA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_TipoCosecha
        public bool BuscExisteMaestroTipoCosecha(string tipocosecha, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TIPOCOSECHA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoCosecha", SqlDbType.VarChar).Value = tipocosecha;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_TipoDefecto (PACK_TipoDefecto)
        //

        // MOSTRAR LISTA DE PACK_TipoDefecto
        public DataTable ListaMaestroTipoDefecto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TIPODEFECTO", conex);
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


        // METODO PARA GUARDAR EN PACK_TipoDefecto
        public void GuardarMaestroTipoDefecto(string tipodefecto, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TIPODEFECTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoDefecto", SqlDbType.VarChar).Value = tipodefecto;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_TipoDefecto
        public void ActualizarMaestroTipoDefecto(int id, string tipodefecto, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TIPODEFECTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@TipoDefecto", SqlDbType.VarChar).Value = tipodefecto;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_TipoDefecto
        public void EliminarMaestroTipoDefecto(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TIPODEFECTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_TipoDefecto
        public bool BuscExisteMaestroTipoDefecto(string tipodefecto, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TIPODEFECTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@TipoDefecto", SqlDbType.VarChar).Value = tipodefecto;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_TipoCausaError (PACK_TipoCausaError)
        //

        // MOSTRAR LISTA DE PACK_TipoCausaError
        public DataTable ListaMaestroTipoCausaError()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TIPOCAUSAERROR", conex);
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


        // METODO PARA GUARDAR EN PACK_TipoCausaError
        public void GuardarMaestroTipoCausaError(string causaerror, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TIPOCAUSAERROR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CausaError", SqlDbType.VarChar).Value = causaerror;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_TipoCausaError
        public void ActualizarMaestroTipoCausaError(int id, string causaerror, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TIPOCAUSAERROR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CausaError", SqlDbType.VarChar).Value = causaerror;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_TipoCausaError
        public void EliminarMaestroTipoCausaError(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TIPOCAUSAERROR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_TipoCausaError
        public bool BuscExisteMaestroTipoCausaError(string causaerror, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TIPOCAUSAERROR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CausaError", SqlDbType.VarChar).Value = causaerror;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_MotivoParadas (PACK_MotivoParadas)
        //

        // MOSTRAR LISTA DE PACK_MotivoParadas
        public DataTable ListaMaestroMotivoParadas()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_MOTIVOPARADAS", conex);
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


        // METODO PARA GUARDAR EN PACK_MotivoParadas
        public void GuardarMaestroMotivoParadas(string codgrup, string grupo, string motivo, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_MOTIVOPARADAS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodGrup", SqlDbType.VarChar).Value = codgrup;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Motivo", SqlDbType.VarChar).Value = motivo;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_MotivoParadas
        public void ActualizarMaestroMotivoParadas(int id, string codgrup, string grupo, string motivo, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_MOTIVOPARADAS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@CodGrup", SqlDbType.VarChar).Value = codgrup;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Motivo", SqlDbType.VarChar).Value = motivo;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_MotivoParadas
        public void EliminarMaestroMotivoParadas(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_MOTIVOPARADAS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_MotivoParadas
        public bool BuscExisteMaestroMotivoParadas(string motivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_MOTIVOPARADAS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Motivo", SqlDbType.VarChar).Value = motivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Turno (PACK_Turno)
        //

        // MOSTRAR LISTA DE PACK_Turno
        public DataTable ListaMaestroTurno()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TURNO", conex);
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


        // METODO PARA GUARDAR EN PACK_Turno
        public void GuardarMaestroTurno(string turno, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TURNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Turno
        public void ActualizarMaestroTurno(int id, string turno, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TURNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Turno
        public void EliminarMaestroTurno(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TURNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Turno
        public bool BuscExisteMaestroTurno(string turno, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TURNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Transporte (PACK_Transporte)
        //

        // MOSTRAR LISTA DE PACK_Transporte
        public DataTable ListaMaestroTransporte()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_TRANSPORTE", conex);
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


        // METODO PARA GUARDAR EN PACK_Transporte
        public void GuardarMaestroTransporte(string transporte, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_TRANSPORTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Transporte", SqlDbType.VarChar).Value = transporte;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Transporte
        public void ActualizarMaestroTransporte(int id, string transporte, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_TRANSPORTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Transporte", SqlDbType.VarChar).Value = transporte;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Transporte
        public void EliminarMaestroTransporte(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_TRANSPORTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Transporte
        public bool BuscExisteMaestroTransporte(string transporte, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_TRANSPORTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Transporte", SqlDbType.VarChar).Value = transporte;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_EstadoPT (PACK_EstadoPT)
        //

        // MOSTRAR LISTA DE PACK_EstadoPT
        public DataTable ListaMaestroEstadoPT()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_ESTADOPT", conex);
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


        // METODO PARA GUARDAR EN PACK_EstadoPT
        public void GuardarMaestroEstadoPT(string cod, string estado, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_ESTADOPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.VarChar).Value = usereg.ToString();
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_EstadoPT
        public void ActualizarMaestroEstadoPT(int id, string cod, string estado, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_ESTADOPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.VarChar).Value = usedit.ToString();
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Activo = 'N') EN PACK_EstadoPT
        public void EliminarMaestroEstadoPT(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_ESTADOPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.VarChar).Value = useelim.ToString();
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_EstadoPT
        public bool BuscExisteMaestroEstadoPT(string cod, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_ESTADOPT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }

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








        //
        // CONFIGURACION DE CORREOS (PACK_EnviarCorreo)
        //

        // METODO PARA GUARDAR UNA CONFIGURACION DE CORREO
        public void GuardarEnviarCorreo(
            DateTime fecha, string emp, string sed, string gerencia, string area,
            string responsable, string formulario, string tipocorreo,
            string de, string para, string cc, string asunto, string cuerpo, string uuid,
            DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_ENVIAR_CORREO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime2).Value = fecha;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Formulario", SqlDbType.VarChar).Value = formulario;
                    comando.Parameters.AddWithValue("@TipoCorreo", SqlDbType.VarChar).Value = tipocorreo;
                    comando.Parameters.AddWithValue("@De", SqlDbType.VarChar).Value = de;
                    comando.Parameters.AddWithValue("@Para", SqlDbType.VarChar).Value = para;
                    comando.Parameters.AddWithValue("@CC", SqlDbType.VarChar).Value = cc;
                    comando.Parameters.AddWithValue("@Asunto", SqlDbType.VarChar).Value = asunto;
                    comando.Parameters.AddWithValue("@Cuerpo", SqlDbType.VarChar).Value = cuerpo;
                    comando.Parameters.AddWithValue("@UUID", SqlDbType.VarChar).Value = uuid;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR UNA CONFIGURACION DE CORREO
        public void ActualizarEnviarCorreo(int id,
            DateTime fecha, string emp, string sed, string gerencia, string area,
            string responsable, string formulario, string tipocorreo,
            string de, string para, string cc, string asunto, string cuerpo, string uuid,
            DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_ENVIAR_CORREO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime2).Value = fecha;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Formulario", SqlDbType.VarChar).Value = formulario;
                    comando.Parameters.AddWithValue("@TipoCorreo", SqlDbType.VarChar).Value = tipocorreo;
                    comando.Parameters.AddWithValue("@De", SqlDbType.VarChar).Value = de;
                    comando.Parameters.AddWithValue("@Para", SqlDbType.VarChar).Value = para;
                    comando.Parameters.AddWithValue("@CC", SqlDbType.VarChar).Value = cc;
                    comando.Parameters.AddWithValue("@Asunto", SqlDbType.VarChar).Value = asunto;
                    comando.Parameters.AddWithValue("@Cuerpo", SqlDbType.VarChar).Value = cuerpo;
                    comando.Parameters.AddWithValue("@UUID", SqlDbType.VarChar).Value = uuid;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA) UNA CONFIGURACION DE CORREO
        public void EliminarEnviarCorreo(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_ENVIAR_CORREO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // MOSTRAR LISTA DE CONFIGURACIONES DE CORREO
        public DataTable ListaReporteEnviarCorreo(string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_ENVIAR_CORREO", conex);
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


        // VERIFICA SI YA EXISTE ESE CORREO PARA LA MISMA EMPRESA, SEDE,
        // FORMULARIO Y TIPO. Al editar se pasa el Id para no chocar consigo mismo.
        public bool BuscExisteEnviarCorreo(string emp, string sed, string formulario,
            string tipocorreo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_ENVIAR_CORREO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Formulario", SqlDbType.VarChar).Value = formulario;
                    comando.Parameters.AddWithValue("@TipoCorreo", SqlDbType.VarChar).Value = tipocorreo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


        //
        // MAESTRO PACK_Identificador (PACK_Identificador)
        //

        // MOSTRAR LISTA DE PACK_Identificador
        public DataTable ListaMaestroIdentificador()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_PACK_IDENTIFICADOR", conex);
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


        // METODO PARA GUARDAR EN PACK_Identificador
        public void GuardarMaestroIdentificador(string identificador, string cultivo, string obs
            , DateTime fec_cre, int usereg, string hostname)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PACK_IDENTIFICADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Identificador", SqlDbType.VarChar).Value = identificador;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime2).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR EN PACK_Identificador
        public void ActualizarMaestroIdentificador(int id, string identificador, string cultivo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PACK_IDENTIFICADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Identificador", SqlDbType.VarChar).Value = identificador;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ELIMINAR (BAJA LOGICA, Estado = 'N') EN PACK_Identificador
        public void EliminarMaestroIdentificador(int id, DateTime fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PACK_IDENTIFICADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime2).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // VERIFICA SI YA EXISTE EL REGISTRO EN PACK_Identificador
        public bool BuscExisteMaestroIdentificador(string identificador, string cultivo, int id)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PACK_IDENTIFICADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Identificador", SqlDbType.VarChar).Value = identificador;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }


    }
}
