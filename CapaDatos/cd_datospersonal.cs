using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace CapaDatos
{
    public class cd_datospersonal : cd_conexion
    {
        // MOSTRAR LISTA DE ESTADO GENERAL
        public DataTable ListaEstado()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ESTADO", conex);
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

        // METODO PARA LLAMAR EL ULTIMO REGISTRO DE USUARIO +1
        public bool UltimoUsuario()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ULTIMO_USUARIO"))
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
                            ce_datospersonal.CodUser_Max = reader.GetInt32(0);
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

        // MOSTRAR LISTA DE ESTADO CIVIL
        public DataTable ListaEstadoCivil()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ESTADO_CIVIL", conex);
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

        // MOSTRAR LISTA DE ESTADO CIVIL
        public DataTable ListaTipoProfesional()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TIPO_PROFESIONAL", conex);
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

        // MOSTRAR LISTA DE ESTADO CIVIL
        public DataTable ListaGrupoProfesional()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GRUPO_PROFESIONAL", conex);
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

        //
        // MOSTRAR LISTA DE ESTABLECIMIENTO
        public DataTable ListaSede()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GRUPO_SEDE", conex);
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

        //
        // MOSTRAR LISTA DE ESTABLECIMIENTO
        public DataTable ListaUbigeo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_UBIGEO_", conex);
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

        //
        // MOSTRAR LISTA DE AREA LABORAL
        public DataTable ListaAreaLaboral()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_AREA_LABORAL", conex);
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
        //
        // MOSTRAR LISTA DE CARGA LABORAL
        public DataTable ListaCargaLaboral()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CARGA_LABORAL", conex);
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

        // MOSTRAR LISTA DE CARGA LABORAL
        public DataTable ListaCondLaboral()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_LABORAL", conex);
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

        //
        // MOSTRAR LISTA DE JEFE INMEDIATO
        public DataTable ListaJefeInmediato()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_JEFE_INMEDIATO", conex);
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

        //
        // MOSTRAR LISTA DE DEPOSITO SALARIAL
        public DataTable ListaDepositoSalarial()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_DEPOSITO_SALARIAL", conex);
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

        //
        // MOSTRAR LISTA DE REGIMEN LABORAL
        public DataTable ListaRegimenLaboral()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_REGIMEN_LABORAL", conex);
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

        //
        // MOSTRAR LISTA DE FONDO DE PENSIONES
        public DataTable ListaFondoPensiones()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_FONDO_PENSIONES", conex);
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

        //
        // MOSTRAR LISTA DE ESCOLARIDA
        public DataTable ListaEscolaridad()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ESCOLARIDAD_PERSONAL", conex);
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

        //
        // MOSTRAR LISTA DE ESCOLARIDA
        public DataTable ListaAlmacenes()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_ALMACENES", conex);
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


        //
        // MOSTRAR GUARDAR USUARIO POR ALMACEN
        public DataTable GuardarAlmacenesUsuario(int usecod, string codalm, Boolean acceso)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_USUARIO_ALMACEN_PRUEBA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@acceso", SqlDbType.Bit).Value = acceso;
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
        // MOSTRAR GUARDAR USUARIO POR ALMACEN
        public DataTable ActualizarAlmacenesUsuario(int usecod, string codalm, Boolean acceso)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_UPDATE_USUARIO_ALMACEN_PRUEBA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@acceso", SqlDbType.Bit).Value = acceso;
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
        // MOSTRAR GUARDAR USUARIO POR ALMACEN
        public DataTable EliminarAlmacenesUsuario(int usecod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ELIMINAR_USUARIO_ALMACEN_PRUEBA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
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

        // METODO BOOL PARA ALMACENAR USUARIOS CON CHECKBOX --
        public DataTable ListPersonalCheck(int usecod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_ALMACENES_USUARIO_CONCHECKBOX", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                comando.ExecuteNonQuery();
                SqlDataReader reader = comando.ExecuteReader();
                //return tabla;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //ce_datospersonal.user_almc_busc = reader.GetInt32(0);
                        //ce_datospersonal.codalm_almc_bubsc = reader.GetString(2);
                        //ce_datospersonal.estado_almc_busc = reader.GetInt32(3);
                    }

                    return tabla;

                }
                else

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
        // MOSTRAR LISTA DE ESCOLARIDA
        public DataTable ListaEntidad()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ENTIDAD_PERSONAL", conex);
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


        // METODO BOOL PARA BUSCAR SI EXISTE PERONSAL
        public bool BuscarPersonalExistente(int dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_PERSONAL_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datospersonal.Busc_usedoc = reader.GetInt32(0);
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


        // METODO BOOL PARA BUSCAR SI EXISTE PERONSAL
        public bool BuscarExistenteFotoFotosheck(string dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_EXISTENTE_FOTO_FOTOSHECK"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_datospersonal.Busc_usedoc = reader.GetInt32(0);
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


        //BUSCAR PRODUCTO EN TABLA
        public DataTable BuscarPersonalFormAcademica(int dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PERSONAL_FORMACADEMICA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;

                //SqlDataReader reader = comando.ExecuteReader();
                //while (reader.Read())
                //{
                //    ce_datosventa.fac_buscar = reader.GetInt32(0);
                //}
                //conex.Dispose();
                //conex.Close();

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

        // METODO PARA BUSCAR PERSONAL POR DNI
        public bool BuscarPersonalDni(int dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_PERSONAL_DNI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datospersonal.usecod = reader.GetInt32(0);
                            ce_datospersonal.useapepat = reader.GetString(1);
                            ce_datospersonal.useapemat = reader.GetString(2);
                            ce_datospersonal.usenam = reader.GetString(3);
                            ce_datospersonal.useusr = reader.GetString(4);
                            ce_datospersonal.usesex = reader.GetString(5);
                            ce_datospersonal.useestciv = reader.GetString(6);
                            ce_datospersonal.usedom = reader.GetString(7);
                            ce_datospersonal.useemail = reader.GetString(8);
                            ce_datospersonal.useobs = reader.GetString(9);
                            ce_datospersonal.fec_cre = reader.GetDateTime(10);
                            ce_datospersonal.fec_nac = reader.GetDateTime(11);
                            ce_datospersonal.tipo_doc = reader.GetString(12);
                            ce_datospersonal.usedoc = reader.GetInt32(13);
                            ce_datospersonal.grupro = reader.GetString(14);
                            ce_datospersonal.grucod = reader.GetString(15);
                            ce_datospersonal.siscod = reader.GetInt32(16);
                            ce_datospersonal.usetel = reader.GetString(17);
                            ce_datospersonal.usepas = reader.GetString(18);
                            ce_datospersonal.estado = reader.GetString(19);
                            ce_datospersonal.codarea = reader.GetString(20);
                            ce_datospersonal.codcar = reader.GetString(21);
                            ce_datospersonal.codcond = reader.GetString(22);
                            ce_datospersonal.codjef = reader.GetString(23);
                            ce_datospersonal.fordepsal = reader.GetString(24);
                            ce_datospersonal.fec_cece = reader.GetDateTime(25);
                            ce_datospersonal.coment = reader.GetString(26);
                            ce_datospersonal.reglab = reader.GetString(27);
                            ce_datospersonal.fondpen = reader.GetString(28);
                            ce_datospersonal.codfondpen = reader.GetString(29);
                            ce_datospersonal.hr_contr = reader.GetInt32(30);
                            //ce_datospersonal.hr_ing = reader.GetDateTime(31);
                            //ce_datospersonal.hr_sal = reader.GetDateTime(32);
                            ce_datospersonal.toler = reader.GetInt32(33);
                            ce_datospersonal.vac_ini = reader.GetDateTime(34);
                            ce_datospersonal.vac_fin = reader.GetDateTime(35);

                            //Memorys
                            //ce_usuario.foto_perfil_buscar = reader.GetString(11);
                            //ce_usuario.foto_perfil_buscar
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

        // METODO PARA BUSCAR PERSONAL POR DNI
        public bool BuscarFotoFotosheck(string dni)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_FOTO_FOTOSHECK"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_fotofotosheck.dni = reader.GetString(0);
                            ce_fotofotosheck.apellidos = reader.GetString(1);
                            ce_fotofotosheck.nombres = reader.GetString(2);
                            //Memorys
                            MemoryStream ms = new MemoryStream((byte[])reader[3]);
                            Byte[] data = ms.ToArray();
                            ce_fotofotosheck.foto = data;
                            //ce_usuario.foto_perfil_buscar
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

        //
        // METODO PARA GUARDAR ESCOLARIDAD DEL PERSONAL --GuardarPersonalEscolaridad --SP_GUARDAR_PERSONAL_ESCOLARIDAD
        public DataTable GuardarPersonalEscolaridad(int usecod, int siscod, string userusr, string desesc, DateTime fec_fin, string obsesc,
            string entesc, string estado, DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg,
            string hostname, string ip_pc, int usedoc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_PERSONAL_ESCOLARIDAD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = userusr;

                comando.Parameters.AddWithValue("@desesc", SqlDbType.VarChar).Value = desesc;
                comando.Parameters.AddWithValue("@fec_fin", SqlDbType.DateTime).Value = fec_fin;
                comando.Parameters.AddWithValue("@obsesc", SqlDbType.VarChar).Value = obsesc;
                comando.Parameters.AddWithValue("@entesc", SqlDbType.VarChar).Value = entesc;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                comando.Parameters.AddWithValue("@fec_mov", SqlDbType.DateTime).Value = fec_mov;
                comando.Parameters.AddWithValue("@usereg", SqlDbType.Int).Value = usereg;
                comando.Parameters.AddWithValue("@usernamreg", SqlDbType.VarChar).Value = usenamreg;

                comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;
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

        // METODO PARA ACTUALIZAR PERSONAL ActualizarPersonalForAcademica
        public DataTable ActualizarPersonalForAcademica(int usecod, int siscod, string userusr,
            string desesc, DateTime fec_fin, string obsesc, string entesc, string estado, DateTime fec_mov, int usedoc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_FORM_ACADEMICA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = userusr;
                comando.Parameters.AddWithValue("@desesc", SqlDbType.VarChar).Value = desesc;
                comando.Parameters.AddWithValue("@fec_fin", SqlDbType.DateTime).Value = fec_fin;

                comando.Parameters.AddWithValue("@obsesc", SqlDbType.VarChar).Value = obsesc;
                comando.Parameters.AddWithValue("@entesc", SqlDbType.VarChar).Value = entesc;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                comando.Parameters.AddWithValue("@fec_mov", SqlDbType.DateTime).Value = fec_mov;
                comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;
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
        // METODO PARA GUARDAR PERSONAL
        public void GuardarPersonal(int usecod, int siscod, string usepas, string usenam, string userusr,
            string useobs, string grupro, string grucod, string estado, DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg,
            string hostname, string ip_pc, string usetel, int usedoc, Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PERSONAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                    comando.Parameters.AddWithValue("@usepas", SqlDbType.VarChar).Value = usepas;
                    comando.Parameters.AddWithValue("@usenam", SqlDbType.VarChar).Value = usenam;
                    comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = userusr;

                    comando.Parameters.AddWithValue("@useobs", SqlDbType.VarChar).Value = useobs;
                    comando.Parameters.AddWithValue("@grupro", SqlDbType.VarChar).Value = grupro;
                    comando.Parameters.AddWithValue("@grucod", SqlDbType.VarChar).Value = grucod;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fec_mov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@userreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usernamreg", SqlDbType.VarChar).Value = usenamreg;

                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@usetel", SqlDbType.VarChar).Value = usetel;
                    comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        // METODO PARA GUARDAR PERSONAL
        public void GuardarFotoFotosheck(string dni,
            string apellidos, string nombres, Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_FOTO_FOTOSHECK"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@apellidos", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;

                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        // METODO PARA GUARDAR PERSONAL DETALLE
        public void GuardarPersonalDetalle(int usecod, int siscod, string useappat, string useapmat, string usenam, string userusr, string usersex,
            string useestciv, string usedom, string usemail, string useobs, DateTime fec_cre, DateTime fec_nac, string tipdoc, int usedoc, string grupro,
            string grucod, string usetel, string estado, string codarea, string codcar, string codcon, string codjef, string codformdep, DateTime fec_cece,
            string comt, string reglab, string fondpen, string codfondpen, int hrscontr, DateTime hr_ing, DateTime hr_sal, int hrtol, DateTime vac_ini,
            DateTime vac_fin, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PERSONAL_DETALLE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                    comando.Parameters.AddWithValue("@useapepat", SqlDbType.VarChar).Value = useappat;
                    comando.Parameters.AddWithValue("@useapemat", SqlDbType.VarChar).Value = useapmat;
                    comando.Parameters.AddWithValue("@usenam", SqlDbType.VarChar).Value = usenam;
                    comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = userusr;
                    comando.Parameters.AddWithValue("@usesex", SqlDbType.VarChar).Value = usersex;

                    comando.Parameters.AddWithValue("@useestciv", SqlDbType.VarChar).Value = useestciv;
                    comando.Parameters.AddWithValue("@usedom", SqlDbType.VarChar).Value = usedom;
                    comando.Parameters.AddWithValue("@usemail", SqlDbType.VarChar).Value = usemail;
                    comando.Parameters.AddWithValue("@useobs", SqlDbType.VarChar).Value = useobs;
                    comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fec_nac", SqlDbType.DateTime).Value = fec_nac;
                    comando.Parameters.AddWithValue("@tip_doc", SqlDbType.VarChar).Value = tipdoc;
                    comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;

                    comando.Parameters.AddWithValue("@grupro", SqlDbType.VarChar).Value = grupro;
                    comando.Parameters.AddWithValue("@grucod", SqlDbType.VarChar).Value = grucod;
                    comando.Parameters.AddWithValue("@usetel", SqlDbType.VarChar).Value = usetel;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@codarea", SqlDbType.VarChar).Value = codarea;
                    comando.Parameters.AddWithValue("@codcar", SqlDbType.VarChar).Value = codcar;
                    comando.Parameters.AddWithValue("@codcon", SqlDbType.VarChar).Value = codcon;
                    comando.Parameters.AddWithValue("@codjef", SqlDbType.VarChar).Value = codjef;

                    comando.Parameters.AddWithValue("@codfordep", SqlDbType.VarChar).Value = codformdep;
                    comando.Parameters.AddWithValue("@fec_cece", SqlDbType.DateTime).Value = fec_cece;
                    comando.Parameters.AddWithValue("@coment", SqlDbType.VarChar).Value = comt;
                    comando.Parameters.AddWithValue("@reglab", SqlDbType.VarChar).Value = reglab;
                    comando.Parameters.AddWithValue("@fondpen", SqlDbType.VarChar).Value = fondpen;
                    comando.Parameters.AddWithValue("@codfondpen", SqlDbType.VarChar).Value = codfondpen;
                    comando.Parameters.AddWithValue("@hr_contr", SqlDbType.Int).Value = hrscontr;
                    comando.Parameters.AddWithValue("@hr_ing", SqlDbType.DateTime).Value = hr_ing;

                    comando.Parameters.AddWithValue("@hr_sal", SqlDbType.DateTime).Value = hr_sal;
                    comando.Parameters.AddWithValue("@toler", SqlDbType.Int).Value = hrtol;
                    comando.Parameters.AddWithValue("@vac_ini", SqlDbType.DateTime).Value = vac_ini;
                    comando.Parameters.AddWithValue("@vac_fin", SqlDbType.DateTime).Value = vac_fin;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        // METODO PARA ELIMINAR REGISTRO POR PERSONAL
        public void EliminarPersonal(int dni)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PERSONAL"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();

                }
            }

        }

        //
        // METODO PARA ELIMINAR FORMACION ACADEMICA PERSONAL
        public void EliminarFormAcademicaPersonal(int dni)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_PERSONAL_FORMACADEMICA"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ACTUALIZAR PERSONAL
        public void ActualizarPersonal(int usecod, int siscod, string usepas, string usenam, string userusr,
            string useobs, string grupro, string grucod, string estado, DateTime fec_mov,
            string usetel, int usedoc, Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                    comando.Parameters.AddWithValue("@usepas", SqlDbType.VarChar).Value = usepas;
                    comando.Parameters.AddWithValue("@usenam", SqlDbType.VarChar).Value = usenam;
                    comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = userusr;

                    comando.Parameters.AddWithValue("@useobs", SqlDbType.VarChar).Value = useobs;
                    comando.Parameters.AddWithValue("@grupro", SqlDbType.VarChar).Value = grupro;
                    comando.Parameters.AddWithValue("@grucod", SqlDbType.VarChar).Value = grucod;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fec_mov", SqlDbType.DateTime).Value = fec_mov;
                    //comando.Parameters.AddWithValue("@userreg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@usernamreg", SqlDbType.VarChar).Value = usenamreg;

                    //comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.Parameters.AddWithValue("@usetel", SqlDbType.VarChar).Value = usetel;
                    comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.ExecuteNonQuery();

                }
            }
        }


        // METODO PARA ACTUALIZAR PERSONAL
        public void ActualizarFotoFotosheck(string dni,
            string apellidos, string nombres, Byte[] imagen)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_FOTO_FOTOSHECK"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@apellidos", SqlDbType.VarChar).Value = apellidos;
                    comando.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = imagen;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        // METODO PARA ACTUALIZAR PERSONAL DETALLE
        public void ActualizarPersonalDetalle(int usecod, int siscod, string useappat, string useapmat, string usenam, string userusr, string usersex,
            string useestciv, string usedom, string usemail, string useobs, DateTime fec_nac, string tipdoc, int usedoc, string grupro,
            string grucod, string usetel, string estado, string codarea, string codcar, string codcon, string codjef, string codformdep, DateTime fec_cece,
            string comt, string reglab, string fondpen, string codfondpen, int hrscontr, DateTime hr_ing, DateTime hr_sal, int hrtol, DateTime vac_ini,
            DateTime vac_fin)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PERSONAL_DETALLE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@usecod", SqlDbType.Int).Value = usecod;
                    comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                    comando.Parameters.AddWithValue("@useapepat", SqlDbType.VarChar).Value = useappat;
                    comando.Parameters.AddWithValue("@useapemat", SqlDbType.VarChar).Value = useapmat;
                    comando.Parameters.AddWithValue("@usenam", SqlDbType.VarChar).Value = usenam;
                    comando.Parameters.AddWithValue("@useusr", SqlDbType.VarChar).Value = userusr;
                    comando.Parameters.AddWithValue("@usesex", SqlDbType.VarChar).Value = usersex;

                    comando.Parameters.AddWithValue("@useestciv", SqlDbType.VarChar).Value = useestciv;
                    comando.Parameters.AddWithValue("@usedom", SqlDbType.VarChar).Value = usedom;
                    comando.Parameters.AddWithValue("@usemail", SqlDbType.VarChar).Value = usemail;
                    comando.Parameters.AddWithValue("@useobs", SqlDbType.VarChar).Value = useobs;
                    //comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fec_nac", SqlDbType.DateTime).Value = fec_nac;
                    comando.Parameters.AddWithValue("@tip_doc", SqlDbType.VarChar).Value = tipdoc;
                    comando.Parameters.AddWithValue("@usedoc", SqlDbType.Int).Value = usedoc;

                    comando.Parameters.AddWithValue("@grupro", SqlDbType.VarChar).Value = grupro;
                    comando.Parameters.AddWithValue("@grucod", SqlDbType.VarChar).Value = grucod;
                    comando.Parameters.AddWithValue("@usetel", SqlDbType.VarChar).Value = usetel;
                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@codarea", SqlDbType.VarChar).Value = codarea;
                    comando.Parameters.AddWithValue("@codcar", SqlDbType.VarChar).Value = codcar;
                    comando.Parameters.AddWithValue("@codcon", SqlDbType.VarChar).Value = codcon;
                    comando.Parameters.AddWithValue("@codjef", SqlDbType.VarChar).Value = codjef;

                    comando.Parameters.AddWithValue("@codfordep", SqlDbType.VarChar).Value = codformdep;
                    comando.Parameters.AddWithValue("@fec_cece", SqlDbType.DateTime).Value = fec_cece;
                    comando.Parameters.AddWithValue("@coment", SqlDbType.VarChar).Value = comt;
                    comando.Parameters.AddWithValue("@reglab", SqlDbType.VarChar).Value = reglab;
                    comando.Parameters.AddWithValue("@fondpen", SqlDbType.VarChar).Value = fondpen;
                    comando.Parameters.AddWithValue("@codfondpen", SqlDbType.VarChar).Value = codfondpen;
                    comando.Parameters.AddWithValue("@hr_contr", SqlDbType.Int).Value = hrscontr;
                    comando.Parameters.AddWithValue("@hr_ing", SqlDbType.DateTime).Value = hr_ing;

                    comando.Parameters.AddWithValue("@hr_sal", SqlDbType.DateTime).Value = hr_sal;
                    comando.Parameters.AddWithValue("@toler", SqlDbType.Int).Value = hrtol;
                    comando.Parameters.AddWithValue("@vac_ini", SqlDbType.DateTime).Value = vac_ini;
                    comando.Parameters.AddWithValue("@vac_fin", SqlDbType.DateTime).Value = vac_fin;
                    //comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    //comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
    }
}
