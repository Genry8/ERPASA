using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class cd_administracion : cd_conexion
    {

        // METODO PARA
        public bool BuscExisteMetaVariedad(string id_actividad, string codigo, DateTime? fecini)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_META_ACTIVIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Idactividad", SqlDbType.VarChar).Value = id_actividad;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@fecini", SqlDbType.DateTime).Value = fecini;
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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteMetaLocalidad(string cabezal, string localidad, DateTime? fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_META_LOCALIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExistePersFijoTemporal(string emp, string sede, string area, string tippers, int semana)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_META_PERSONAL_FIJO_TEMPORAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tippers;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = semana;
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


        // METODO PARA LLAMAR SI EXISTE META AVANCE
        public bool BuscExisteMetaAvance(string emp, string sede
            , string labor, string area, int semana)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_META_AVANCE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = semana;
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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteMetaSector(string labor, string sector, string fundo, int semana)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_META_SECTOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = semana;
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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteMetaLabor(string fundo, string labor, DateTime? fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_META_LABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteDetalleCosechador(DateTime? fecha, string dni, string stiker)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_DETALLE_COSECHADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Sticker", SqlDbType.VarChar).Value = stiker;
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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteTareoFinal(string fecha, string dni)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_TAREO_FINAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteTareoFinalDiario(string fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_TAREO_FINAL_DIARIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
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


        // METODO EXISTE TAREO DETALLADO
        public bool BuscExisteTareoDetallado(DateTime? fecha, string dni, string gruplabor)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_TAREO_DETALLADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Grupo_Labor", SqlDbType.VarChar).Value = gruplabor;
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

        // METODO EXISTE PRESUPUESTO
        public bool BuscExistePresupuesto(string partida, int sem, string mes, int año)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_PRESUPUESTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Partida", SqlDbType.VarChar).Value = partida;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
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


        // METODO EXISTE ESTACION METEOROLÓCIGA
        public bool BuscExisteEstacionMeteorologica(string empresa, string sede, DateTime fecha, DateTime hora)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_ESTACION_METEOROLÓGICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.Int).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Hora", SqlDbType.Time).Value = hora;
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


        // METODO EXISTE PERCOLACION
        public bool BuscExisteMetroCubico(string sede
            , string cabezal, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_RIE_METRO_CUBICO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
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


        // METODO EXISTE PERCOLACION
        public bool BuscExistePersonalObservado(DateTime fecha, string dni)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_CP_OBSERVADO_CAMPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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



        // METODO EXISTE PERCOLACION
        public bool BuscExisteProgramaRiego(string empresa
            , string cabezal, DateTime fecha, string programa)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_RIE_PROGRAMA_RIEGO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Programa", SqlDbType.VarChar).Value = programa;
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



        // METODO EXISTE PERCOLACION
        public bool BuscExisteEvaluacionCampo(string empresa
            , DateTime fecha, string sede, string cabezal, string cultivo
            , string lote, string grupo_var, string variable)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_SA_EVALUACION_CAMPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Lote", SqlDbType.VarChar).Value = lote;
                    comando.Parameters.AddWithValue("@Grupo_Variable", SqlDbType.VarChar).Value = grupo_var;
                    comando.Parameters.AddWithValue("@Variable", SqlDbType.VarChar).Value = variable;
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


        // METODO EXISTE PERCOLACION
        public bool BuscExisteReservorio(string empresa
            , DateTime fecha, string reservorio, string hora_medida)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_RIE_RESERVORIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Reservorio", SqlDbType.VarChar).Value = reservorio;
                    comando.Parameters.AddWithValue("@Hora_Medida", SqlDbType.VarChar).Value = hora_medida;
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



        // METODO EXISTE PERCOLACION
        public bool BuscExisteFertilizacion(string empresa, int id, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_RIE_FERTILIZACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
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


        // METODO EXISTE PERCOLACION
        public bool BuscExistePulsos(string sede
            , string cabezal, string variedad, int valvula, DateTime fecha
            )
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_RIE_PROGRAMA_PULSOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.AddWithValue("@Valvula", SqlDbType.Int).Value = valvula;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
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


        // METODO 
        public void ActualizarMetaVariedad(string idactividad, string cabezal, string codigo
            , string variedad, string presentacion, decimal JAB, decimal KG
            , DateTime fec_ini, DateTime fec_fin, decimal KG_JAB, string sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_META_ACTIVIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Idactividad", SqlDbType.VarChar).Value = idactividad;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@JAB", SqlDbType.Decimal).Value = JAB;
                    comando.Parameters.AddWithValue("@KG", SqlDbType.Decimal).Value = KG;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fec_ini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fec_fin;
                    comando.Parameters.AddWithValue("@KG_JAB", SqlDbType.Decimal).Value = KG_JAB;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // META LOCALIDAD 
        public void ActualizarMetaLocalidad(string cabezal, string localidad
            , DateTime fecha, string sem, decimal horas, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_META_LOCALIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.Decimal).Value = horas;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // META LOCALIDAD 
        public void ActualizarMetaPersFijoTemporal(string empresa, string sede
            , string area, string tipopersonal, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_META_PERSONAL_FIJO_TEMPORAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Decimal).Value = cantidad;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // META LOCALIDAD 
        public void ActualizarMetaAvance(string empresa, string sede
            , string labor, string area, string tipo_bono, DateTime fecini, DateTime fecfin
            , decimal meta, decimal horas, int sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_META_AVANCE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Bono", SqlDbType.VarChar).Value = tipo_bono;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.Decimal).Value = meta;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.Decimal).Value = horas;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // META SECTOR 
        public void ActualizarMetaSector(string labor, string sector
            , string fundo, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_META_SECTOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Decimal).Value = cantidad;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // META LOCALIDAD 
        public void ActualizarMetaLabor(string labor, string fundo
            , DateTime fecini, DateTime fecfin, string sem, decimal meta, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_META_LABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Fecini", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@Fecfin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.Decimal).Value = meta;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // DETALLE COSECHADOR
        public void ActualizarDetalleCosechador(DateTime Fecha, string Empresa, string fundo
            , string Cod_Cabezal, string Cabezal, string Campana, string Cultivo
            , string Cod_Variedad, string Variedad, string TipoEnvaseDes, string Dni
            , string Ape_Nom, decimal Jabas, decimal Kilos, decimal Meta
            , decimal PrecioUnitario, decimal Bono, decimal Rendimiento, string Categoría
            , string Cod_Modalidad, string Modalidad, string Cod_Presentacion
            , string Presentacion, string Nro_Ticket, int año, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_DETALLE_COSECHADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cod_Cabezal", SqlDbType.VarChar).Value = Cod_Cabezal;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = Cabezal;
                    comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = Campana;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = Cultivo;
                    comando.Parameters.AddWithValue("@Cod_Variedad", SqlDbType.VarChar).Value = Cod_Variedad;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = Variedad;
                    comando.Parameters.AddWithValue("@TipoEnvaseDes", SqlDbType.VarChar).Value = TipoEnvaseDes;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Jabas", SqlDbType.Decimal).Value = Jabas;
                    comando.Parameters.AddWithValue("@Kilos", SqlDbType.Decimal).Value = Kilos;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.Decimal).Value = Meta;
                    comando.Parameters.AddWithValue("@PrecioUnitario", SqlDbType.Decimal).Value = PrecioUnitario;
                    comando.Parameters.AddWithValue("@Bono", SqlDbType.Decimal).Value = Bono;
                    comando.Parameters.AddWithValue("@Rendimiento", SqlDbType.Decimal).Value = Rendimiento;
                    comando.Parameters.AddWithValue("@Categoría", SqlDbType.VarChar).Value = Categoría;
                    comando.Parameters.AddWithValue("@Cod_Modalidad", SqlDbType.VarChar).Value = Cod_Modalidad;
                    comando.Parameters.AddWithValue("@Modalidad", SqlDbType.VarChar).Value = Modalidad;
                    comando.Parameters.AddWithValue("@Cod_Presentacion", SqlDbType.VarChar).Value = Cod_Presentacion;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = Presentacion;
                    comando.Parameters.AddWithValue("@Nro_Ticket", SqlDbType.VarChar).Value = Nro_Ticket;
                    comando.Parameters.AddWithValue("@Campaña", SqlDbType.Int).Value = año;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // DETALLE TAREO FINAL
        public void ActualizarTareoFinal(string Codigo, string Ape_Nom, string Dni
            , string Cod_Planilla, string Fecha_Ing, string Empresa
            , string Sede, string Fundo, string Cargo, string Area, string Gerencia
            , string Actividad, string Labor, string Labor_Correcta
            , string Centro_Costo, string Jornada, string Fecha_Tareo, string Hora_Tareo
            , string DniSupervisor, string NombreSupervisor, string Fecha_Ingreso_Tareo
            , string Hora_Ingreso_Tareo, string Fecha_Salida_Tareo, string Hora_Salida_Tareo
            , string Horas_En_Sede, string Refrigerio, string Horas_Normales
            , string Fecha_Ingreso_Real, string Hora_Ingreso_Real, string Fecha_Salida_Real
            , string Hora_Salida_Real, string Horas_Pagar, string Horas_Compensadas
            , string Devolución_Horas, string Día_Tareo, string Horas_Nocturnas
            , string Turno, string Usuario_Registro, string Fecha_Registro
            , string Usuario_Modificación, string Fecha_Modificación, string Num_Hora_Ingreso_Tareo
            , string Num_Hora_Ingreso_Real, string Num_Hora_Salida_Tareo, string Num_Hora_Salida_Real
            , string Horas_No_Validadas_Ingreso, string Horas_No_Validadas_Ingreso_Final,
              string Horas_No_Validadas_Salida, string Horas_No_Validadas_Salida_Final
            , string HH_NO_Validadas_Final, string Horas_extra, string Num_Horas_Compensadas
            , string Num_Devolución_Horas, string Almuerzo, string Cena, string Alimentación_Total
            , string Horas_Efectivas_Fundo, string Sobretiempo_Ingresado, string Sobretiempo_Final
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_TAREO_FINAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Cod_Planilla", SqlDbType.VarChar).Value = Cod_Planilla;
                    comando.Parameters.AddWithValue("@Fecha_Ing", SqlDbType.VarChar).Value = Fecha_Ing;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = Fundo;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = Gerencia;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = Actividad;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = Labor;
                    comando.Parameters.AddWithValue("@Labor_Correcta", SqlDbType.VarChar).Value = Labor_Correcta;
                    comando.Parameters.AddWithValue("@Centro_Costo", SqlDbType.VarChar).Value = Centro_Costo;
                    comando.Parameters.AddWithValue("@Jornada", SqlDbType.VarChar).Value = Jornada;
                    comando.Parameters.AddWithValue("@Fecha_Tareo", SqlDbType.VarChar).Value = Fecha_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Tareo", SqlDbType.VarChar).Value = Hora_Tareo;
                    comando.Parameters.AddWithValue("@DniSupervisor", SqlDbType.VarChar).Value = DniSupervisor;
                    comando.Parameters.AddWithValue("@NombreSupervisor", SqlDbType.VarChar).Value = NombreSupervisor;
                    comando.Parameters.AddWithValue("@Fecha_Ingreso_Tareo", SqlDbType.VarChar).Value = Fecha_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Ingreso_Tareo", SqlDbType.VarChar).Value = Hora_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Fecha_Salida_Tareo", SqlDbType.VarChar).Value = Fecha_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Salida_Tareo", SqlDbType.VarChar).Value = Hora_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Horas_En_Sede", SqlDbType.VarChar).Value = Horas_En_Sede;
                    comando.Parameters.AddWithValue("@Refrigerio", SqlDbType.VarChar).Value = Refrigerio;
                    comando.Parameters.AddWithValue("@Horas_Normales", SqlDbType.VarChar).Value = Horas_Normales;
                    comando.Parameters.AddWithValue("@Fecha_Ingreso_Real", SqlDbType.VarChar).Value = Fecha_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Hora_Ingreso_Real", SqlDbType.VarChar).Value = Hora_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Fecha_Salida_Real", SqlDbType.VarChar).Value = Fecha_Salida_Real;
                    comando.Parameters.AddWithValue("@Hora_Salida_Real", SqlDbType.VarChar).Value = Hora_Salida_Real;
                    comando.Parameters.AddWithValue("@Horas_Pagar", SqlDbType.VarChar).Value = Horas_Pagar;
                    comando.Parameters.AddWithValue("@Horas_Compensadas", SqlDbType.VarChar).Value = Horas_Compensadas;
                    comando.Parameters.AddWithValue("@Devolución_Horas", SqlDbType.VarChar).Value = Devolución_Horas;
                    comando.Parameters.AddWithValue("@Día_Tareo", SqlDbType.VarChar).Value = Día_Tareo;
                    comando.Parameters.AddWithValue("@Horas_Nocturnas", SqlDbType.VarChar).Value = Horas_Nocturnas;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = Turno;
                    comando.Parameters.AddWithValue("@Usuario_Registro", SqlDbType.VarChar).Value = Usuario_Registro;
                    comando.Parameters.AddWithValue("@Fecha_Registro", SqlDbType.VarChar).Value = Fecha_Registro;
                    comando.Parameters.AddWithValue("@Usuario_Modificación", SqlDbType.VarChar).Value = Usuario_Modificación;
                    comando.Parameters.AddWithValue("@Fecha_Modificación", SqlDbType.VarChar).Value = Fecha_Modificación;
                    comando.Parameters.AddWithValue("@Num_Hora_Ingreso_Tareo", SqlDbType.VarChar).Value = Num_Hora_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Num_Hora_Ingreso_Real", SqlDbType.VarChar).Value = Num_Hora_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Num_Hora_Salida_Tareo", SqlDbType.VarChar).Value = Num_Hora_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Num_Hora_Salida_Real", SqlDbType.VarChar).Value = Num_Hora_Salida_Real;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Ingreso", SqlDbType.VarChar).Value = Horas_No_Validadas_Ingreso;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Ingreso_Final", SqlDbType.VarChar).Value = Horas_No_Validadas_Ingreso_Final;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Salida", SqlDbType.VarChar).Value = Horas_No_Validadas_Salida;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Salida_Final", SqlDbType.VarChar).Value = Horas_No_Validadas_Salida_Final;
                    comando.Parameters.AddWithValue("@HH_NO_Validadas_Final", SqlDbType.VarChar).Value = HH_NO_Validadas_Final;
                    comando.Parameters.AddWithValue("@Horas_extra", SqlDbType.VarChar).Value = Horas_extra;
                    comando.Parameters.AddWithValue("@Num_Horas_Compensadas", SqlDbType.VarChar).Value = Num_Horas_Compensadas;
                    comando.Parameters.AddWithValue("@Num_Devolución_Horas", SqlDbType.VarChar).Value = Num_Devolución_Horas;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.VarChar).Value = Almuerzo;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.VarChar).Value = Cena;
                    comando.Parameters.AddWithValue("@Alimentación_Total", SqlDbType.VarChar).Value = Alimentación_Total;
                    comando.Parameters.AddWithValue("@Horas_Efectivas_Fundo", SqlDbType.VarChar).Value = Horas_Efectivas_Fundo;
                    comando.Parameters.AddWithValue("@Sobretiempo_Ingresado", SqlDbType.VarChar).Value = Sobretiempo_Ingresado;
                    comando.Parameters.AddWithValue("@Sobretiempo_Final", SqlDbType.VarChar).Value = Sobretiempo_Final;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // DETALLE COSECHADOR
        public void ActualizarTareoDetallado(string Empresa, string Sede, string fundo
            , string Cod_Grupo_Labor, string Grupo_Labor, string Cod_Labor, string Labor
            , string Labor_Correcta, string Uni_Med, string Cod_Cultivo, string Cultivo
            , DateTime Fecha, string DNI_Supervisor
            , string Supervisor, DateTime Fec_Inicio, DateTime Fec_Fin
            , string Horas_efectivas, string Total_Horas, string DniResponsable
            , string responsable, string Dni, string Ape_Nom
            , decimal Avance, string Motivo_Salida, string Tipo_Labor, string Cabezal
            , string CodCentroCosto, string CentroCosto, string Observacion, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_TAREO_DETALLADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cod_Grupo_Labor", SqlDbType.VarChar).Value = Cod_Grupo_Labor;
                    comando.Parameters.AddWithValue("@Grupo_Labor", SqlDbType.VarChar).Value = Grupo_Labor;
                    comando.Parameters.AddWithValue("@Cod_Labor", SqlDbType.VarChar).Value = Cod_Labor;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = Labor;
                    comando.Parameters.AddWithValue("@Labor_Correcta", SqlDbType.VarChar).Value = Labor_Correcta;
                    comando.Parameters.AddWithValue("@Uni_Med", SqlDbType.VarChar).Value = Uni_Med;
                    comando.Parameters.AddWithValue("@Cod_Cultivo", SqlDbType.VarChar).Value = Cod_Cultivo;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = Cultivo;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@DNI_Supervisor", SqlDbType.VarChar).Value = DNI_Supervisor;
                    comando.Parameters.AddWithValue("@Supervisor", SqlDbType.VarChar).Value = Supervisor;
                    comando.Parameters.AddWithValue("@Fec_Inicio", SqlDbType.DateTime).Value = Fec_Inicio;
                    comando.Parameters.AddWithValue("@Fec_Fin", SqlDbType.DateTime).Value = Fec_Fin;
                    comando.Parameters.AddWithValue("@Horas_efectivas", SqlDbType.VarChar).Value = Horas_efectivas;
                    comando.Parameters.AddWithValue("@Total_Horas", SqlDbType.VarChar).Value = Total_Horas;
                    comando.Parameters.AddWithValue("@DniResponsable", SqlDbType.VarChar).Value = DniResponsable;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;

                    comando.Parameters.AddWithValue("@Avance", SqlDbType.VarChar).Value = Avance;
                    comando.Parameters.AddWithValue("@Motivo_Salida", SqlDbType.VarChar).Value = Motivo_Salida;
                    comando.Parameters.AddWithValue("@Tipo_Labor", SqlDbType.VarChar).Value = Tipo_Labor;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = Cabezal;
                    comando.Parameters.AddWithValue("@CodCentroCosto", SqlDbType.VarChar).Value = CodCentroCosto;
                    comando.Parameters.AddWithValue("@CentroCosto", SqlDbType.VarChar).Value = CentroCosto;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // DETALLE PRESUPUESTO
        public void ActualizarPresupuesto(string Empresa, string Partida
            , string IdRubro, string Area, int Semana, string Mes
            , int Año, string TipoRegistro, decimal Importe, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_PRESUPUESTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Partida", SqlDbType.VarChar).Value = Partida;
                    comando.Parameters.AddWithValue("@IdRubro", SqlDbType.VarChar).Value = IdRubro;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = Semana;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = Mes;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = Año;
                    comando.Parameters.AddWithValue("@TipoRegistro", SqlDbType.VarChar).Value = TipoRegistro;
                    comando.Parameters.AddWithValue("@Importe", SqlDbType.Decimal).Value = Importe;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarEstacionMeteorologica(string Empresa, string sede, DateTime Fecha
            , DateTime Hora, decimal Temp_Out, decimal Hi_Temp, decimal Low_Temp
            , decimal Out_Hum, decimal Dew_Pt, decimal Wind_Speed, string Wind_Dir
            , decimal Wind_Run, decimal Hi_Speed, string Hi_Dir, decimal Wind_Chill, decimal Heat_Index
            , decimal THW_Index, string THSW_Index, decimal Bar, decimal Rain, decimal Rain_Rate
            , decimal Solar_Rad, decimal Solar_Energy, decimal Hi_Solar_Rad, decimal UV_Index
            , decimal UV_Dose, decimal Hi_UV, decimal Heat_D_D, decimal Cool_D_D, decimal In_Temp
            , decimal In_Hum, decimal In_Dew, decimal In_Heat, decimal In_EMC, decimal In_Air_Density
            , decimal ET, decimal Wind_Samp, decimal Wind_Tx, decimal ISS_Recept, decimal Arc_Int
            , decimal H_H_Brillo_Solar, decimal HR_90
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_ESTACION_METEOROLOGICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Hora", SqlDbType.DateTime).Value = Hora;
                    comando.Parameters.AddWithValue("@Temp_Out", SqlDbType.Decimal).Value = Temp_Out;
                    comando.Parameters.AddWithValue("@Hi_Temp", SqlDbType.Decimal).Value = Hi_Temp;
                    comando.Parameters.AddWithValue("@Low_Temp", SqlDbType.Decimal).Value = Low_Temp;
                    comando.Parameters.AddWithValue("@Out_Hum", SqlDbType.Decimal).Value = Out_Hum;
                    comando.Parameters.AddWithValue("@Dew_Pt", SqlDbType.Decimal).Value = Dew_Pt;
                    comando.Parameters.AddWithValue("@Wind_Speed", SqlDbType.Decimal).Value = Wind_Speed;
                    comando.Parameters.AddWithValue("@Wind_Dir", SqlDbType.VarChar).Value = Wind_Dir;
                    comando.Parameters.AddWithValue("@Wind_Run", SqlDbType.Decimal).Value = Wind_Run;
                    comando.Parameters.AddWithValue("@Hi_Speed", SqlDbType.Decimal).Value = Hi_Speed;
                    comando.Parameters.AddWithValue("@Hi_Dir", SqlDbType.VarChar).Value = Hi_Dir;
                    comando.Parameters.AddWithValue("@Wind_Chill", SqlDbType.Decimal).Value = Wind_Chill;
                    comando.Parameters.AddWithValue("@Heat_Index", SqlDbType.Decimal).Value = Heat_Index;
                    comando.Parameters.AddWithValue("@THW_Index", SqlDbType.Decimal).Value = THW_Index;
                    comando.Parameters.AddWithValue("@THSW_Index", SqlDbType.VarChar).Value = THSW_Index;
                    comando.Parameters.AddWithValue("@Bar", SqlDbType.Decimal).Value = Bar;
                    comando.Parameters.AddWithValue("@Rain", SqlDbType.Decimal).Value = Rain;
                    comando.Parameters.AddWithValue("@Rain_Rate", SqlDbType.Decimal).Value = Rain_Rate;
                    comando.Parameters.AddWithValue("@Solar_Rad", SqlDbType.Decimal).Value = Solar_Rad;
                    comando.Parameters.AddWithValue("@Solar_Energy", SqlDbType.Decimal).Value = Solar_Energy;
                    comando.Parameters.AddWithValue("@Hi_Solar_Rad", SqlDbType.Decimal).Value = Hi_Solar_Rad;
                    comando.Parameters.AddWithValue("@UV_Index", SqlDbType.Decimal).Value = UV_Index;
                    comando.Parameters.AddWithValue("@UV_Dose", SqlDbType.Decimal).Value = UV_Dose;
                    comando.Parameters.AddWithValue("@Hi_UV", SqlDbType.Decimal).Value = Hi_UV;
                    comando.Parameters.AddWithValue("@Heat_D_D", SqlDbType.Decimal).Value = Heat_D_D;
                    comando.Parameters.AddWithValue("@Cool_D_D", SqlDbType.Decimal).Value = Cool_D_D;
                    comando.Parameters.AddWithValue("@In_Temp", SqlDbType.Decimal).Value = In_Temp;
                    comando.Parameters.AddWithValue("@In_Hum", SqlDbType.Decimal).Value = In_Hum;
                    comando.Parameters.AddWithValue("@In_Dew", SqlDbType.Decimal).Value = In_Dew;
                    comando.Parameters.AddWithValue("@In_Heat", SqlDbType.Decimal).Value = In_Heat;
                    comando.Parameters.AddWithValue("@In_EMC", SqlDbType.Decimal).Value = In_EMC;
                    comando.Parameters.AddWithValue("@In_Air_Density", SqlDbType.Decimal).Value = In_Air_Density;
                    comando.Parameters.AddWithValue("@ET", SqlDbType.Decimal).Value = ET;
                    comando.Parameters.AddWithValue("@Wind_Samp", SqlDbType.Decimal).Value = Wind_Samp;
                    comando.Parameters.AddWithValue("@Wind_Tx", SqlDbType.Decimal).Value = Wind_Tx;
                    comando.Parameters.AddWithValue("@ISS_Recept", SqlDbType.Decimal).Value = ISS_Recept;
                    comando.Parameters.AddWithValue("@Arc_Int", SqlDbType.Decimal).Value = Arc_Int;
                    comando.Parameters.AddWithValue("@H_H_Brillo_Solar", SqlDbType.Decimal).Value = H_H_Brillo_Solar;
                    comando.Parameters.AddWithValue("@HR_90", SqlDbType.Decimal).Value = HR_90;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarMetroCubico(string sede, string cabezal
            , DateTime Fecha, decimal programado
            , decimal ejecutado, decimal eficiencia, string Observacion
            //, string hoja
            //, string estado, DateTime fec_mov, int usedit
            )
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_RIE_METROCUBICO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Programado", SqlDbType.Decimal).Value = programado;
                    comando.Parameters.AddWithValue("@Ejecutado", SqlDbType.Decimal).Value = ejecutado;
                    comando.Parameters.AddWithValue("@Eficiencia", SqlDbType.Decimal).Value = eficiencia;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

                    //comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    //comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    ////comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    ////comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    ////comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    //comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarPersonalObservado(DateTime Fecha
            , string dni, string apenom, string Observacion
            //, string hoja
            //, string estado, DateTime fec_mov, int usedit
            )
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CP_PERSONALOBSERVADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = Observacion;

                    //comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    //comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    ////comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    ////comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    ////comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    //comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarProgramaRiego(string Empresa, string cabezal
            , DateTime Fecha, string dia, string programa, DateTime tot_horas
            , decimal Consumo_M3, decimal M3_Ha, decimal Cuba_A_Lts
            , decimal Cuba_B_Lts, decimal Cuba_C_Lts, decimal Cuba_Fito_Lts
            , string Observacion
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_RIE_PROGRAMA_RIEGO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Dia", SqlDbType.VarChar).Value = dia;
                    comando.Parameters.AddWithValue("@Programa", SqlDbType.VarChar).Value = programa;
                    comando.Parameters.AddWithValue("@Tot_Horas", SqlDbType.DateTime).Value = tot_horas;

                    comando.Parameters.AddWithValue("@Consumo_M3", SqlDbType.Decimal).Value = Consumo_M3;
                    comando.Parameters.AddWithValue("@M3_Ha", SqlDbType.Decimal).Value = M3_Ha;
                    comando.Parameters.AddWithValue("@Cuba_A_Lts", SqlDbType.Decimal).Value = Cuba_A_Lts;
                    comando.Parameters.AddWithValue("@Cuba_B_Lts", SqlDbType.Decimal).Value = Cuba_B_Lts;
                    comando.Parameters.AddWithValue("@Cuba_C_Lts", SqlDbType.Decimal).Value = Cuba_C_Lts;
                    comando.Parameters.AddWithValue("@Cuba_Fito_Lts", SqlDbType.Decimal).Value = Cuba_Fito_Lts;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarEvaluacionCampo(string empresa
            , DateTime fecha, string sede, string cabezal, string cultivo
            , string lote, string muestra, string grupo_var, string variable
            , int total, decimal promedio, string semaforo, decimal severidad
            , string semaforo_2, decimal dispersion, string fenologia, string variedad
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_SA_EVALUACION_CAMPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Lote", SqlDbType.VarChar).Value = lote;
                    comando.Parameters.AddWithValue("@Muestra", SqlDbType.VarChar).Value = muestra;
                    comando.Parameters.AddWithValue("@Grupo_Variable", SqlDbType.VarChar).Value = grupo_var;
                    comando.Parameters.AddWithValue("@Variable", SqlDbType.VarChar).Value = variable;
                    comando.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = total;
                    comando.Parameters.AddWithValue("@Promedio", SqlDbType.Decimal).Value = promedio;
                    comando.Parameters.AddWithValue("@Semaforo", SqlDbType.VarChar).Value = semaforo;
                    comando.Parameters.AddWithValue("@Severidad", SqlDbType.Decimal).Value = severidad;
                    comando.Parameters.AddWithValue("@Semaforo_2", SqlDbType.VarChar).Value = semaforo_2;
                    comando.Parameters.AddWithValue("@Dispersion", SqlDbType.Decimal).Value = dispersion;
                    comando.Parameters.AddWithValue("@Fenologia", SqlDbType.VarChar).Value = fenologia;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarReservorio(string empresa
            , DateTime fecha, string reservorio, string hora_medida
            , decimal Cantidad, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_RIE_RESERVORIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Reservorio", SqlDbType.VarChar).Value = reservorio;
                    comando.Parameters.AddWithValue("@Hora_Medida", SqlDbType.VarChar).Value = hora_medida;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Decimal).Value = Cantidad;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarFertilizacion(string empresa, int id
            , DateTime fecha, string Fenologia, string Pulsos_Fertilizados
            , string Pulsos_Riego, decimal Horas, string Variedad
            , string Nombre_Comercial, string Ing_Activo, decimal Base_1000LT
            , int Inyeccion, string Unidad, decimal Qm3_Varidad, int Volumen_Teorico
            , decimal KG_Teorico, decimal Suma_Qm3_Total, int Vol_Sol_Lt_Reportado
            , int Vol, decimal Cant, decimal Efi_Inyeccion, decimal Area
            , string Valvula_Int, string Tanque, string Operador, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_RIE_FERTILIZACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Fenologia", SqlDbType.VarChar).Value = Fenologia;
                    comando.Parameters.AddWithValue("@Pulsos_Fertilizados", SqlDbType.VarChar).Value = Pulsos_Fertilizados;
                    comando.Parameters.AddWithValue("@Pulsos_Riego", SqlDbType.VarChar).Value = Pulsos_Riego;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.Decimal).Value = Horas;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = Variedad;
                    comando.Parameters.AddWithValue("@Nombre_Comercial", SqlDbType.VarChar).Value = Nombre_Comercial;
                    comando.Parameters.AddWithValue("@Ing_Activo", SqlDbType.VarChar).Value = Ing_Activo;
                    comando.Parameters.AddWithValue("@Base_1000LT", SqlDbType.Decimal).Value = Base_1000LT;
                    comando.Parameters.AddWithValue("@Inyeccion", SqlDbType.Int).Value = Inyeccion;
                    comando.Parameters.AddWithValue("@Unidad", SqlDbType.VarChar).Value = Unidad;
                    comando.Parameters.AddWithValue("@Qm3_Varidad", SqlDbType.Decimal).Value = Qm3_Varidad;
                    comando.Parameters.AddWithValue("@Volumen_Teorico", SqlDbType.Int).Value = Volumen_Teorico;
                    comando.Parameters.AddWithValue("@KG_Teorico", SqlDbType.Decimal).Value = KG_Teorico;
                    comando.Parameters.AddWithValue("@Suma_Qm3_Total", SqlDbType.Decimal).Value = Suma_Qm3_Total;
                    comando.Parameters.AddWithValue("@Vol_Sol_Lt_Reportado", SqlDbType.Int).Value = Vol_Sol_Lt_Reportado;
                    comando.Parameters.AddWithValue("@Vol", SqlDbType.Int).Value = Vol;
                    comando.Parameters.AddWithValue("@Cant", SqlDbType.Decimal).Value = Cant;
                    comando.Parameters.AddWithValue("@Efi_Inyeccion", SqlDbType.Decimal).Value = Cant;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.Decimal).Value = Cant;
                    comando.Parameters.AddWithValue("@Valvula_Int", SqlDbType.VarChar).Value = Valvula_Int;
                    comando.Parameters.AddWithValue("@Tanque", SqlDbType.VarChar).Value = Tanque;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = Operador;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }





        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarPulsos(string sede
            , string cabezal, string variedad, int valvula, DateTime fecha
            , decimal pulsos, string obs)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_RIE_PROGRAMA_PULSOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.AddWithValue("@Valvula", SqlDbType.Int).Value = valvula;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Pulsos", SqlDbType.Decimal).Value = pulsos;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.ExecuteNonQuery();

                }
            }

        }




        // METODO PARA GUARDAR META VARIEDAD
        public void GuardarMetaVariedad(string idactividad, string cabezal, string codigo
            , string variedad, string presentacion, decimal JAB, decimal KG
            , DateTime? fec_ini, DateTime? fec_fin, decimal? KG_JAB, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_META_ACTIVIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Idactividad", SqlDbType.VarChar).Value = idactividad;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@JAB", SqlDbType.Decimal).Value = JAB;
                    comando.Parameters.AddWithValue("@KG", SqlDbType.Decimal).Value = KG;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fec_ini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fec_fin;
                    comando.Parameters.AddWithValue("@KG_JAB", SqlDbType.Decimal).Value = KG_JAB;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;

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




        // METODO PARA GUARDAR META VARIEDAD
        public void GuardarMetaLocalidad(string cabezal, string localidad
            , DateTime fecha, string sem, decimal horas, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_META_LOCALIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.Decimal).Value = horas;

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





        // METODO PARA GUARDAR META VARIEDAD
        public void GuardarMetaPersFijoTemporal(string empresa, string sede
            , string area, string tipopersonal, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_META_PERSONAL_FIJO_TEMPORAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Decimal).Value = cantidad;

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


        // METODO PARA GUARDAR META VARIEDAD
        public void GuardarMetaAvance(string empresa, string sede
            , string labor, string area, string tipo_bono, DateTime fecini, DateTime fecfin
            , decimal meta, decimal horas, int sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_META_AVANCE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Bono", SqlDbType.VarChar).Value = tipo_bono;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.Decimal).Value = meta;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.Decimal).Value = horas;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;

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



        // METODO PARA GUARDAR META VARIEDAD
        public void GuardarMetaSector(string labor, string sector
            , string fundo, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_META_SECTOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Decimal).Value = cantidad;

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




        // METODO PARA GUARDAR META VARIEDAD
        public void GuardarMetaLabor(string labor, string fundo
            , DateTime fecini, DateTime fecfin, string sem, decimal meta, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_META_LABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Fecini", SqlDbType.Date).Value = fecini;
                    comando.Parameters.AddWithValue("@Fecfin", SqlDbType.Date).Value = fecfin;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.Decimal).Value = meta;

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



        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarDetalleCosechador(DateTime Fecha, string Empresa, string fundo
            , string Cod_Cabezal, string Cabezal, string Campana, string Cultivo
            , string Cod_Variedad, string Variedad, string TipoEnvaseDes, string Dni
            , string Ape_Nom, decimal Jabas, decimal Kilos, decimal? Meta
            , decimal PrecioUnitario, decimal Bono, decimal? Rendimiento, string Categoría
            , string Cod_Modalidad, string Modalidad, string Cod_Presentacion
            , string Presentacion, string Nro_Ticket, int año, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_DETALLE_COSECHADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cod_Cabezal", SqlDbType.VarChar).Value = Cod_Cabezal;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = Cabezal;
                    comando.Parameters.AddWithValue("@Campana", SqlDbType.VarChar).Value = Campana;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = Cultivo;
                    comando.Parameters.AddWithValue("@Cod_Variedad", SqlDbType.VarChar).Value = Cod_Variedad;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = Variedad;
                    comando.Parameters.AddWithValue("@TipoEnvaseDes", SqlDbType.VarChar).Value = TipoEnvaseDes;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Jabas", SqlDbType.Decimal).Value = Jabas;
                    comando.Parameters.AddWithValue("@Kilos", SqlDbType.Decimal).Value = Kilos;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.Decimal).Value = Meta;
                    comando.Parameters.AddWithValue("@PrecioUnitario", SqlDbType.Decimal).Value = PrecioUnitario;
                    comando.Parameters.AddWithValue("@Bono", SqlDbType.Decimal).Value = Bono;
                    comando.Parameters.AddWithValue("@Rendimiento", SqlDbType.Decimal).Value = Rendimiento;
                    comando.Parameters.AddWithValue("@Categoría", SqlDbType.VarChar).Value = Categoría;
                    comando.Parameters.AddWithValue("@Cod_Modalidad", SqlDbType.VarChar).Value = Cod_Modalidad;
                    comando.Parameters.AddWithValue("@Modalidad", SqlDbType.VarChar).Value = Modalidad;
                    comando.Parameters.AddWithValue("@Cod_Presentacion", SqlDbType.VarChar).Value = Cod_Presentacion;
                    comando.Parameters.AddWithValue("@Presentacion", SqlDbType.VarChar).Value = Presentacion;
                    comando.Parameters.AddWithValue("@Nro_Ticket", SqlDbType.VarChar).Value = Nro_Ticket;
                    comando.Parameters.AddWithValue("@Campaña", SqlDbType.Int).Value = año;

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


        // METODO PARA GUARDAR TAREO FINAL
        public void GuardarTareoFinal(string Codigo, string Ape_Nom, string Dni
            , string Cod_Planilla, string Fecha_Ing, string Empresa
            , string Sede, string Fundo, string Cargo, string Area, string Gerencia
            , string Actividad, string Labor, string Labor_Correcta
            , string Centro_Costo, string Jornada, string Fecha_Tareo, string Hora_Tareo
            , string DniSupervisor, string NombreSupervisor, string Fecha_Ingreso_Tareo
            , string Hora_Ingreso_Tareo, string Fecha_Salida_Tareo, string Hora_Salida_Tareo
            , string Horas_En_Sede, string Refrigerio, string Horas_Normales
            , string Fecha_Ingreso_Real, string Hora_Ingreso_Real, string Fecha_Salida_Real
            , string Hora_Salida_Real, string Horas_Pagar, string Horas_Compensadas
            , string Devolución_Horas, string Día_Tareo, string Horas_Nocturnas
            , string Turno, string Usuario_Registro, string Fecha_Registro
            , string Usuario_Modificación, string Fecha_Modificación, string Num_Hora_Ingreso_Tareo
            , string Num_Hora_Ingreso_Real, string Num_Hora_Salida_Tareo, string Num_Hora_Salida_Real
            , string Horas_No_Validadas_Ingreso, string Horas_No_Validadas_Ingreso_Final,
              string Horas_No_Validadas_Salida, string Horas_No_Validadas_Salida_Final
            , string HH_NO_Validadas_Final, string Horas_extra, string Num_Horas_Compensadas
            , string Num_Devolución_Horas, string Almuerzo, string Cena, string Alimentación_Total
            , string Horas_Efectivas_Fundo, string Sobretiempo_Ingresado, string Sobretiempo_Final
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_TAREO_FINAL"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Cod_Planilla", SqlDbType.VarChar).Value = Cod_Planilla;
                    comando.Parameters.AddWithValue("@Fecha_Ing", SqlDbType.VarChar).Value = Fecha_Ing;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = Fundo;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = Gerencia;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = Actividad;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = Labor;
                    comando.Parameters.AddWithValue("@Labor_Correcta", SqlDbType.VarChar).Value = Labor_Correcta;
                    comando.Parameters.AddWithValue("@Centro_Costo", SqlDbType.VarChar).Value = Centro_Costo;
                    comando.Parameters.AddWithValue("@Jornada", SqlDbType.VarChar).Value = Jornada;
                    comando.Parameters.AddWithValue("@Fecha_Tareo", SqlDbType.VarChar).Value = Fecha_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Tareo", SqlDbType.VarChar).Value = Hora_Tareo;
                    comando.Parameters.AddWithValue("@DniSupervisor", SqlDbType.VarChar).Value = DniSupervisor;
                    comando.Parameters.AddWithValue("@NombreSupervisor", SqlDbType.VarChar).Value = NombreSupervisor;
                    comando.Parameters.AddWithValue("@Fecha_Ingreso_Tareo", SqlDbType.VarChar).Value = Fecha_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Ingreso_Tareo", SqlDbType.VarChar).Value = Hora_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Fecha_Salida_Tareo", SqlDbType.VarChar).Value = Fecha_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Salida_Tareo", SqlDbType.VarChar).Value = Hora_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Horas_En_Sede", SqlDbType.VarChar).Value = Horas_En_Sede;
                    comando.Parameters.AddWithValue("@Refrigerio", SqlDbType.VarChar).Value = Refrigerio;
                    comando.Parameters.AddWithValue("@Horas_Normales", SqlDbType.VarChar).Value = Horas_Normales;
                    comando.Parameters.AddWithValue("@Fecha_Ingreso_Real", SqlDbType.VarChar).Value = Fecha_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Hora_Ingreso_Real", SqlDbType.VarChar).Value = Hora_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Fecha_Salida_Real", SqlDbType.VarChar).Value = Fecha_Salida_Real;
                    comando.Parameters.AddWithValue("@Hora_Salida_Real", SqlDbType.VarChar).Value = Hora_Salida_Real;
                    comando.Parameters.AddWithValue("@Horas_Pagar", SqlDbType.VarChar).Value = Horas_Pagar;
                    comando.Parameters.AddWithValue("@Horas_Compensadas", SqlDbType.VarChar).Value = Horas_Compensadas;
                    comando.Parameters.AddWithValue("@Devolución_Horas", SqlDbType.VarChar).Value = Devolución_Horas;
                    comando.Parameters.AddWithValue("@Día_Tareo", SqlDbType.VarChar).Value = Día_Tareo;
                    comando.Parameters.AddWithValue("@Horas_Nocturnas", SqlDbType.VarChar).Value = Horas_Nocturnas;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = Turno;
                    comando.Parameters.AddWithValue("@Usuario_Registro", SqlDbType.VarChar).Value = Usuario_Registro;
                    comando.Parameters.AddWithValue("@Fecha_Registro", SqlDbType.VarChar).Value = Fecha_Registro;
                    comando.Parameters.AddWithValue("@Usuario_Modificación", SqlDbType.VarChar).Value = Usuario_Modificación;
                    comando.Parameters.AddWithValue("@Fecha_Modificación", SqlDbType.VarChar).Value = Fecha_Modificación;
                    comando.Parameters.AddWithValue("@Num_Hora_Ingreso_Tareo", SqlDbType.VarChar).Value = Num_Hora_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Num_Hora_Ingreso_Real", SqlDbType.VarChar).Value = Num_Hora_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Num_Hora_Salida_Tareo", SqlDbType.VarChar).Value = Num_Hora_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Num_Hora_Salida_Real", SqlDbType.VarChar).Value = Num_Hora_Salida_Real;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Ingreso", SqlDbType.VarChar).Value = Horas_No_Validadas_Ingreso;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Ingreso_Final", SqlDbType.VarChar).Value = Horas_No_Validadas_Ingreso_Final;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Salida", SqlDbType.VarChar).Value = Horas_No_Validadas_Salida;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Salida_Final", SqlDbType.VarChar).Value = Horas_No_Validadas_Salida_Final;
                    comando.Parameters.AddWithValue("@HH_NO_Validadas_Final", SqlDbType.VarChar).Value = HH_NO_Validadas_Final;
                    comando.Parameters.AddWithValue("@Horas_extra", SqlDbType.VarChar).Value = Horas_extra;
                    comando.Parameters.AddWithValue("@Num_Horas_Compensadas", SqlDbType.VarChar).Value = Num_Horas_Compensadas;
                    comando.Parameters.AddWithValue("@Num_Devolución_Horas", SqlDbType.VarChar).Value = Num_Devolución_Horas;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.VarChar).Value = Almuerzo;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.VarChar).Value = Cena;
                    comando.Parameters.AddWithValue("@Alimentación_Total", SqlDbType.VarChar).Value = Alimentación_Total;
                    comando.Parameters.AddWithValue("@Horas_Efectivas_Fundo", SqlDbType.VarChar).Value = Horas_Efectivas_Fundo;
                    comando.Parameters.AddWithValue("@Sobretiempo_Ingresado", SqlDbType.VarChar).Value = Sobretiempo_Ingresado;
                    comando.Parameters.AddWithValue("@Sobretiempo_Final", SqlDbType.VarChar).Value = Sobretiempo_Final;

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

        public void GuardarTareoFinalBulk(DataTable dt)
        {
            var connection = leerconexion();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string mergeQuery = @"
MERGE INTO CP_TareoFinalDiario AS target
USING @TareoFinalSource AS source
ON target.Dni = source.Dni 
AND target.Fecha_Tareo = source.Fecha_Tareo
AND target.Sede = source.Sede

WHEN MATCHED THEN
    UPDATE SET 
        target.Ape_Nom = source.Ape_Nom,
        target.Cod_Planilla = source.Cod_Planilla,
        target.Fecha_Ing = source.Fecha_Ing,
        target.Empresa = source.Empresa,
        target.Sede = source.Sede,
        target.Fundo = source.Fundo,
        target.Cargo = source.Cargo,
        target.Area = source.Area,
        target.Gerencia = source.Gerencia,
        target.Actividad = source.Actividad,
        target.Labor = source.Labor,
        target.Labor_Correcta = source.Labor_Correcta,
        target.Centro_Costo = source.Centro_Costo,
        target.Jornada = source.Jornada,
        target.Fecha_Tareo = source.Fecha_Tareo,
        target.Hora_Tareo = source.Hora_Tareo,
        target.DniSupervisor = source.DniSupervisor,
        target.NombreSupervisor = source.NombreSupervisor,
        target.Fecha_Ingreso_Tareo = source.Fecha_Ingreso_Tareo,
        target.Hora_Ingreso_Tareo = source.Hora_Ingreso_Tareo,
        target.Fecha_Salida_Tareo = source.Fecha_Salida_Tareo,
        target.Hora_Salida_Tareo = source.Hora_Salida_Tareo,
        target.Horas_En_Sede = source.Horas_En_Sede,
        target.Refrigerio = source.Refrigerio,
        target.Horas_Normales = source.Horas_Normales,
        target.Fecha_Ingreso_Real = source.Fecha_Ingreso_Real,
        target.Hora_Ingreso_Real = source.Hora_Ingreso_Real,
        target.Fecha_Salida_Real = source.Fecha_Salida_Real,
        target.Hora_Salida_Real = source.Hora_Salida_Real,
        target.Horas_Pagar = source.Horas_Pagar,
        target.Horas_Compensadas = source.Horas_Compensadas,
        target.Devolucion_Horas = source.Devolucion_Horas,
        target.Dia_Tareo = source.Dia_Tareo,
        target.Horas_Nocturnas = source.Horas_Nocturnas,
        target.Turno = source.Turno,
        target.Usuario_Registro = source.Usuario_Registro,
        target.Fecha_Registro = source.Fecha_Registro,
        target.Usuario_Modificacion = source.Usuario_Modificacion,
        target.Fecha_Modificacion = source.Fecha_Modificacion,
        target.Num_Hora_Ingreso_Tareo = source.Num_Hora_Ingreso_Tareo,
        target.Num_Hora_Ingreso_Real = source.Num_Hora_Ingreso_Real,
        target.Num_Hora_Salida_Tareo = source.Num_Hora_Salida_Tareo,
        target.Num_Hora_Salida_Real = source.Num_Hora_Salida_Real,
        target.Horas_No_Validadas_Ingreso = source.Horas_No_Validadas_Ingreso,
        target.Horas_No_Validadas_Ingreso_Final = source.Horas_No_Validadas_Ingreso_Final,
        target.Horas_No_Validadas_Salida = source.Horas_No_Validadas_Salida,
        target.Horas_No_Validadas_Salida_Final = source.Horas_No_Validadas_Salida_Final,
        target.HH_NO_Validadas_Final = source.HH_NO_Validadas_Final,
        target.Horas_extra = source.Horas_extra,
        target.Num_Horas_Compensadas = source.Num_Horas_Compensadas,
        target.Num_Devolucion_Horas = source.Num_Devolucion_Horas,
        target.Almuerzo = source.Almuerzo,
        target.Cena = source.Cena,
        target.Alimentacion_Total = source.Alimentacion_Total,
        target.Horas_Efectivas_Fundo = source.Horas_Efectivas_Fundo,
        target.Sobretiempo_Ingresado = source.Sobretiempo_Ingresado,
        target.Sobretiempo_Final = source.Sobretiempo_Final,
        target.Hoja = source.Hoja,
        target.Estado = source.Estado,
        target.FecCre = source.FecCre,
        target.UseReg = source.UseReg,
        target.Hostname = source.Hostname,
        target.FecEdit = source.FecEdit,
        target.UseEdit = source.UseEdit

WHEN NOT MATCHED THEN
    INSERT (Codigo, Ape_Nom, Dni, Cod_Planilla, Fecha_Ing, Empresa, Sede, Fundo, Cargo, Area, Gerencia, Actividad, Labor, Labor_Correcta,
            Centro_Costo, Jornada, Fecha_Tareo, Hora_Tareo, DniSupervisor, NombreSupervisor, Fecha_Ingreso_Tareo, Hora_Ingreso_Tareo,
            Fecha_Salida_Tareo, Hora_Salida_Tareo, Horas_En_Sede, Refrigerio, Horas_Normales, Fecha_Ingreso_Real, Hora_Ingreso_Real,
            Fecha_Salida_Real, Hora_Salida_Real, Horas_Pagar, Horas_Compensadas, Devolucion_Horas, Dia_Tareo, Horas_Nocturnas, Turno,
            Usuario_Registro, Fecha_Registro, Usuario_Modificacion, Fecha_Modificacion, Num_Hora_Ingreso_Tareo, Num_Hora_Ingreso_Real,
            Num_Hora_Salida_Tareo, Num_Hora_Salida_Real, Horas_No_Validadas_Ingreso, Horas_No_Validadas_Ingreso_Final,
            Horas_No_Validadas_Salida, Horas_No_Validadas_Salida_Final, HH_NO_Validadas_Final, Horas_extra, Num_Horas_Compensadas,
            Num_Devolucion_Horas, Almuerzo, Cena, Alimentacion_Total, Horas_Efectivas_Fundo, Sobretiempo_Ingresado, Sobretiempo_Final,
            Hoja, Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit)
    VALUES (source.Codigo, source.Ape_Nom, source.Dni, source.Cod_Planilla, source.Fecha_Ing, source.Empresa, source.Sede, source.Fundo,
            source.Cargo, source.Area, source.Gerencia, source.Actividad, source.Labor, source.Labor_Correcta, source.Centro_Costo,
            source.Jornada, source.Fecha_Tareo, source.Hora_Tareo, source.DniSupervisor, source.NombreSupervisor, source.Fecha_Ingreso_Tareo,
            source.Hora_Ingreso_Tareo, source.Fecha_Salida_Tareo, source.Hora_Salida_Tareo, source.Horas_En_Sede, source.Refrigerio,
            source.Horas_Normales, source.Fecha_Ingreso_Real, source.Hora_Ingreso_Real, source.Fecha_Salida_Real, source.Hora_Salida_Real,
            source.Horas_Pagar, source.Horas_Compensadas, source.Devolucion_Horas, source.Dia_Tareo, source.Horas_Nocturnas,
            source.Turno, source.Usuario_Registro, source.Fecha_Registro, source.Usuario_Modificacion, source.Fecha_Modificacion,
            source.Num_Hora_Ingreso_Tareo, source.Num_Hora_Ingreso_Real, source.Num_Hora_Salida_Tareo, source.Num_Hora_Salida_Real,
            source.Horas_No_Validadas_Ingreso, source.Horas_No_Validadas_Ingreso_Final, source.Horas_No_Validadas_Salida,
            source.Horas_No_Validadas_Salida_Final, source.HH_NO_Validadas_Final, source.Horas_extra, source.Num_Horas_Compensadas,
            source.Num_Devolucion_Horas, source.Almuerzo, source.Cena, source.Alimentacion_Total, source.Horas_Efectivas_Fundo,
            source.Sobretiempo_Ingresado, source.Sobretiempo_Final, source.Hoja, source.Estado, source.FecCre, source.UseReg,
            source.Hostname, source.FecEdit, source.UseEdit);";

                    command.CommandText = mergeQuery;

                    SqlParameter tableParam = new SqlParameter("@TareoFinalSource", SqlDbType.Structured);
                    tableParam.TypeName = "dbo.TareoFinalType";
                    tableParam.Value = dt;

                    command.Parameters.Add(tableParam);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar MERGE en la base de datos", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void GuardarTareoDiarioBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "PL_TareajeTrabajador"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }


        public void GuardarReporteAsistenciaBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_ReporteAsistencia"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarReporteAtencionTrabajadoresBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_AtencionesTrabajador"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarReporteEfectividadTrabajadoresBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_EfectividadAtenciones"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }


        public void GuardarReporteMarcacionCampamentoBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_MarcacionesCampamento"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarStickerPresentacionBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("El DataTable está vacío. No hay datos para insertar.");

            // Mostrar una excepción con las primeras 10 filas para depuración
            // Solo para revisión rápida de los primeros datos (útil durante pruebas)

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "DEST_ImpresionStickerPresentacion"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("Error al abrir la conexión o realizar la operación masiva:\n" + ex.InnerException.Message, ex.InnerException);
                }
                else
                {
                    throw new Exception("Error al abrir la conexión o realizar la operación masiva:\n" + ex.Message, ex);
                }
            }

            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }


        public void GuardarPresentacionBulk(DataTable dt)
        {
            var connection = leerconexion();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                // CREAR TABLA TEMPORAL
                string createTempTable = @"
            IF OBJECT_ID('tempdb..#TempPresentacion') IS NOT NULL DROP TABLE #TempPresentacion;

            CREATE TABLE #TempPresentacion (
                Id INT,
                Cod VARCHAR(20),
                Descripcion VARCHAR(20),
                Cantidad INT,
                Tipo VARCHAR(180),
                CodExtech VARCHAR(80),
                Precio DECIMAL(18,2),
                CantJaba INT,
                Simil INT,
                Simil2 INT,  
                Coment VARCHAR(1000),  
                Obs VARCHAR(1000),
                Estado VARCHAR(1),
                FecCre DATETIME2,
                UseReg INT,
                Hostname VARCHAR(50),
                FecEdit DATETIME2,
                UseEdit INT,
                UseElim INT
            );";

                using (SqlCommand cmd = new SqlCommand(createTempTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // INSERTAR EN TABLA TEMPORAL CON BULKCOPY
                using (SqlBulkCopy bulk = new SqlBulkCopy(connection))
                {
                    bulk.DestinationTableName = "#TempPresentacion";

                    foreach (DataColumn col in dt.Columns)
                        bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                    bulk.WriteToServer(dt);
                }

                // MERGE PARA INSERT / UPDATE
                string mergeSql = @"
            MERGE DEST_Presentacion AS T
            USING #TempPresentacion AS S
            ON T.Id = S.Id

            WHEN MATCHED THEN 
                UPDATE SET 
                    T.Cod = S.Cod,
                    T.Descripcion = S.Descripcion,
                    T.Cantidad = S.Cantidad,
                    T.Tipo = S.Tipo,
                    T.CodExtech = S.CodExtech,
                    T.Precio = S.Precio,
                    T.Obs = S.Obs,
                    T.Estado = S.Estado,
                    T.FecEdit = S.FecEdit,
                    T.UseEdit = S.UseEdit

            WHEN NOT MATCHED THEN
                INSERT (Cod, Descripcion, Cantidad, Tipo, CodExtech, Precio,CantJaba,Simil,Simil2,Coment, Obs, Estado, FecCre, UseReg, Hostname)
                VALUES (S.Cod, S.Descripcion, S.Cantidad, S.Tipo, S.CodExtech, S.Precio,S.CantJaba,S.Simil,S.Simil2,S.Coment, S.Obs, S.Estado, S.FecCre, S.UseReg, S.Hostname);
        ";

                using (SqlCommand cmdMerge = new SqlCommand(mergeSql, connection))
                {
                    cmdMerge.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Bulk + Merge", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        public void GuardarStickerPersonasBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("El DataTable está vacío. No hay datos para insertar.");

            // Mostrar una excepción con las primeras 10 filas para depuración
            // Solo para revisión rápida de los primeros datos (útil durante pruebas)


            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "DEST_ImpresionStickerPersonas"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("Error al abrir la conexión o realizar la operación masiva:\n" + ex.InnerException.Message, ex.InnerException);
                }
                else
                {
                    throw new Exception("Error al abrir la conexión o realizar la operación masiva:\n" + ex.Message, ex);
                }
            }

            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarStickerPersonasBulkTEST(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("El DataTable está vacío. No hay datos para insertar.");

            // Mostrar una excepción con las primeras 10 filas para depuración
            // Solo para revisión rápida de los primeros datos (útil durante pruebas)


            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "DEST_ImpStickPers_TEST"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("Error al abrir la conexión o realizar la operación masiva:\n" + ex.InnerException.Message, ex.InnerException);
                }
                else
                {
                    throw new Exception("Error al abrir la conexión o realizar la operación masiva:\n" + ex.Message, ex);
                }
            }

            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }


        public void GuardarReporteOcupabilidadCampamentoBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_OcupabilidadCampamento"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarReporteStatusCampamentoBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_StatusCampamento"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarReporteMovimientoCampamentoBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SPER_MovimientoCampamento"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        private string ObtenerVistaPreviaDataTable(DataTable dt, int cantidadFilas)
        {
            int maxRows = Math.Min(cantidadFilas, dt.Rows.Count);
            var sb = new StringBuilder();

            // Encabezados
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(col.ColumnName).Append("\t");
            }
            sb.AppendLine();

            // Filas
            for (int i = 0; i < maxRows; i++)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append(dt.Rows[i][col] ?? "NULL").Append("\t");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public DataTable ObtenerStickersPorSessionId(string sessionId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = leerconexion())
            {
                using (SqlCommand command = new SqlCommand("SELECT ips.*,dp.ApeNom FROM DEST_ImpresionStickerPersonas ips " +
                    " join DEST_GrupoPersonas dp on ips.IdGrupoPersona=dp.Id " +
                    " WHERE SessionId = @SessionId", connection))
                {
                    command.Parameters.AddWithValue("@SessionId", sessionId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable ObtenerStickersPorSessionIdTEST(string sessionId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = leerconexion())
            {
                using (SqlCommand command = new SqlCommand("SELECT ips.*,dp.ApeNom FROM DEST_ImpStickPers_TEST ips " +
                    " join DEST_GrupoPersonas dp on ips.IdGrupoPersona=dp.Id " +
                    " WHERE SessionId = @SessionId", connection))
                {
                    command.Parameters.AddWithValue("@SessionId", sessionId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable ObtenerStickersPresentacionSessionId(string sessionId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = leerconexion())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM DEST_ImpresionStickerPresentacion WHERE SessionId = @SessionId", connection))
                {
                    command.Parameters.AddWithValue("@SessionId", sessionId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }


        // METODO PARA GUARDAR TAREO FINAL DIARIO
        public void GuardarTareoFinalDiario(string Codigo, string Ape_Nom, string Dni
            , string Cod_Planilla, string Fecha_Ing, string Empresa
            , string Sede, string Fundo, string Cargo, string Area, string Gerencia
            , string Actividad, string Labor, string Labor_Correcta
            , string Centro_Costo, string Jornada, string Fecha_Tareo, string Hora_Tareo
            , string DniSupervisor, string NombreSupervisor, string Fecha_Ingreso_Tareo
            , string Hora_Ingreso_Tareo, string Fecha_Salida_Tareo, string Hora_Salida_Tareo
            , string Horas_En_Sede, string Refrigerio, string Horas_Normales
            , string Fecha_Ingreso_Real, string Hora_Ingreso_Real, string Fecha_Salida_Real
            , string Hora_Salida_Real, string Horas_Pagar, string Horas_Compensadas
            , string Devolución_Horas, string Día_Tareo, string Horas_Nocturnas
            , string Turno, string Usuario_Registro, string Fecha_Registro
            , string Usuario_Modificación, string Fecha_Modificación, string Num_Hora_Ingreso_Tareo
            , string Num_Hora_Ingreso_Real, string Num_Hora_Salida_Tareo, string Num_Hora_Salida_Real
            , string Horas_No_Validadas_Ingreso, string Horas_No_Validadas_Ingreso_Final,
              string Horas_No_Validadas_Salida, string Horas_No_Validadas_Salida_Final
            , string HH_NO_Validadas_Final, string Horas_extra, string Num_Horas_Compensadas
            , string Num_Devolución_Horas, string Almuerzo, string Cena, string Alimentación_Total
            , string Horas_Efectivas_Fundo, string Sobretiempo_Ingresado, string Sobretiempo_Final
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_TAREO_FINALDIARIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Cod_Planilla", SqlDbType.VarChar).Value = Cod_Planilla;
                    comando.Parameters.AddWithValue("@Fecha_Ing", SqlDbType.VarChar).Value = Fecha_Ing;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = Fundo;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = Gerencia;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = Actividad;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = Labor;
                    comando.Parameters.AddWithValue("@Labor_Correcta", SqlDbType.VarChar).Value = Labor_Correcta;
                    comando.Parameters.AddWithValue("@Centro_Costo", SqlDbType.VarChar).Value = Centro_Costo;
                    comando.Parameters.AddWithValue("@Jornada", SqlDbType.VarChar).Value = Jornada;
                    comando.Parameters.AddWithValue("@Fecha_Tareo", SqlDbType.VarChar).Value = Fecha_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Tareo", SqlDbType.VarChar).Value = Hora_Tareo;
                    comando.Parameters.AddWithValue("@DniSupervisor", SqlDbType.VarChar).Value = DniSupervisor;
                    comando.Parameters.AddWithValue("@NombreSupervisor", SqlDbType.VarChar).Value = NombreSupervisor;
                    comando.Parameters.AddWithValue("@Fecha_Ingreso_Tareo", SqlDbType.VarChar).Value = Fecha_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Ingreso_Tareo", SqlDbType.VarChar).Value = Hora_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Fecha_Salida_Tareo", SqlDbType.VarChar).Value = Fecha_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Hora_Salida_Tareo", SqlDbType.VarChar).Value = Hora_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Horas_En_Sede", SqlDbType.VarChar).Value = Horas_En_Sede;
                    comando.Parameters.AddWithValue("@Refrigerio", SqlDbType.VarChar).Value = Refrigerio;
                    comando.Parameters.AddWithValue("@Horas_Normales", SqlDbType.VarChar).Value = Horas_Normales;
                    comando.Parameters.AddWithValue("@Fecha_Ingreso_Real", SqlDbType.VarChar).Value = Fecha_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Hora_Ingreso_Real", SqlDbType.VarChar).Value = Hora_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Fecha_Salida_Real", SqlDbType.VarChar).Value = Fecha_Salida_Real;
                    comando.Parameters.AddWithValue("@Hora_Salida_Real", SqlDbType.VarChar).Value = Hora_Salida_Real;
                    comando.Parameters.AddWithValue("@Horas_Pagar", SqlDbType.VarChar).Value = Horas_Pagar;
                    comando.Parameters.AddWithValue("@Horas_Compensadas", SqlDbType.VarChar).Value = Horas_Compensadas;
                    comando.Parameters.AddWithValue("@Devolución_Horas", SqlDbType.VarChar).Value = Devolución_Horas;
                    comando.Parameters.AddWithValue("@Día_Tareo", SqlDbType.VarChar).Value = Día_Tareo;
                    comando.Parameters.AddWithValue("@Horas_Nocturnas", SqlDbType.VarChar).Value = Horas_Nocturnas;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = Turno;
                    comando.Parameters.AddWithValue("@Usuario_Registro", SqlDbType.VarChar).Value = Usuario_Registro;
                    comando.Parameters.AddWithValue("@Fecha_Registro", SqlDbType.VarChar).Value = Fecha_Registro;
                    comando.Parameters.AddWithValue("@Usuario_Modificación", SqlDbType.VarChar).Value = Usuario_Modificación;
                    comando.Parameters.AddWithValue("@Fecha_Modificación", SqlDbType.VarChar).Value = Fecha_Modificación;
                    comando.Parameters.AddWithValue("@Num_Hora_Ingreso_Tareo", SqlDbType.VarChar).Value = Num_Hora_Ingreso_Tareo;
                    comando.Parameters.AddWithValue("@Num_Hora_Ingreso_Real", SqlDbType.VarChar).Value = Num_Hora_Ingreso_Real;
                    comando.Parameters.AddWithValue("@Num_Hora_Salida_Tareo", SqlDbType.VarChar).Value = Num_Hora_Salida_Tareo;
                    comando.Parameters.AddWithValue("@Num_Hora_Salida_Real", SqlDbType.VarChar).Value = Num_Hora_Salida_Real;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Ingreso", SqlDbType.VarChar).Value = Horas_No_Validadas_Ingreso;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Ingreso_Final", SqlDbType.VarChar).Value = Horas_No_Validadas_Ingreso_Final;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Salida", SqlDbType.VarChar).Value = Horas_No_Validadas_Salida;
                    comando.Parameters.AddWithValue("@Horas_No_Validadas_Salida_Final", SqlDbType.VarChar).Value = Horas_No_Validadas_Salida_Final;
                    comando.Parameters.AddWithValue("@HH_NO_Validadas_Final", SqlDbType.VarChar).Value = HH_NO_Validadas_Final;
                    comando.Parameters.AddWithValue("@Horas_extra", SqlDbType.VarChar).Value = Horas_extra;
                    comando.Parameters.AddWithValue("@Num_Horas_Compensadas", SqlDbType.VarChar).Value = Num_Horas_Compensadas;
                    comando.Parameters.AddWithValue("@Num_Devolución_Horas", SqlDbType.VarChar).Value = Num_Devolución_Horas;
                    comando.Parameters.AddWithValue("@Almuerzo", SqlDbType.VarChar).Value = Almuerzo;
                    comando.Parameters.AddWithValue("@Cena", SqlDbType.VarChar).Value = Cena;
                    comando.Parameters.AddWithValue("@Alimentación_Total", SqlDbType.VarChar).Value = Alimentación_Total;
                    comando.Parameters.AddWithValue("@Horas_Efectivas_Fundo", SqlDbType.VarChar).Value = Horas_Efectivas_Fundo;
                    comando.Parameters.AddWithValue("@Sobretiempo_Ingresado", SqlDbType.VarChar).Value = Sobretiempo_Ingresado;
                    comando.Parameters.AddWithValue("@Sobretiempo_Final", SqlDbType.VarChar).Value = Sobretiempo_Final;

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




        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarTareoDetallado(string Empresa, string Sede, string fundo
            , string Cod_Grupo_Labor, string Grupo_Labor, string Cod_Labor, string Labor
            , string Labor_Correcta, string Uni_Med, string Cod_Cultivo, string Cultivo
            , DateTime Fecha, string DNI_Supervisor
            , string Supervisor, DateTime Fec_Inicio, DateTime Fec_Fin
            , string Horas_efectivas, string Total_Horas, string DniResponsable
            , string responsable, string Dni, string Ape_Nom
            , decimal Avance, string Motivo_Salida, string Tipo_Labor, string Cabezal
            , string CodCentroCosto, string CentroCosto, string Observacion, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_TAREO_DETALLADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cod_Grupo_Labor", SqlDbType.VarChar).Value = Cod_Grupo_Labor;
                    comando.Parameters.AddWithValue("@Grupo_Labor", SqlDbType.VarChar).Value = Grupo_Labor;
                    comando.Parameters.AddWithValue("@Cod_Labor", SqlDbType.VarChar).Value = Cod_Labor;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = Labor;
                    comando.Parameters.AddWithValue("@Labor_Correcta", SqlDbType.VarChar).Value = Labor_Correcta;
                    comando.Parameters.AddWithValue("@Uni_Med", SqlDbType.VarChar).Value = Uni_Med;
                    comando.Parameters.AddWithValue("@Cod_Cultivo", SqlDbType.VarChar).Value = Cod_Cultivo;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = Cultivo;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@DNI_Supervisor", SqlDbType.VarChar).Value = DNI_Supervisor;
                    comando.Parameters.AddWithValue("@Supervisor", SqlDbType.VarChar).Value = Supervisor;
                    comando.Parameters.AddWithValue("@Fec_Inicio", SqlDbType.DateTime).Value = Fec_Inicio;
                    comando.Parameters.AddWithValue("@Fec_Fin", SqlDbType.DateTime).Value = Fec_Fin;
                    comando.Parameters.AddWithValue("@Horas_efectivas", SqlDbType.VarChar).Value = Horas_efectivas;
                    comando.Parameters.AddWithValue("@Total_Horas", SqlDbType.VarChar).Value = Total_Horas;
                    comando.Parameters.AddWithValue("@DniResponsable", SqlDbType.VarChar).Value = DniResponsable;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;

                    comando.Parameters.AddWithValue("@Avance", SqlDbType.VarChar).Value = Avance;
                    comando.Parameters.AddWithValue("@Motivo_Salida", SqlDbType.VarChar).Value = Motivo_Salida;
                    comando.Parameters.AddWithValue("@Tipo_Labor", SqlDbType.VarChar).Value = Tipo_Labor;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = Cabezal;
                    comando.Parameters.AddWithValue("@CodCentroCosto", SqlDbType.VarChar).Value = CodCentroCosto;
                    comando.Parameters.AddWithValue("@CentroCosto", SqlDbType.VarChar).Value = CentroCosto;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

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



        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarEstacionMeteorologica(string Empresa, string sede, DateTime Fecha
            , DateTime Hora, decimal Temp_Out, decimal Hi_Temp, decimal Low_Temp
            , decimal Out_Hum, decimal Dew_Pt, decimal Wind_Speed, string Wind_Dir
            , decimal Wind_Run, decimal Hi_Speed, string Hi_Dir, decimal Wind_Chill, decimal Heat_Index
            , decimal THW_Index, string THSW_Index, decimal Bar, decimal Rain, decimal Rain_Rate
            , decimal Solar_Rad, decimal Solar_Energy, decimal Hi_Solar_Rad, decimal UV_Index
            , decimal UV_Dose, decimal Hi_UV, decimal Heat_D_D, decimal Cool_D_D, decimal In_Temp
            , decimal In_Hum, decimal In_Dew, decimal In_Heat, decimal In_EMC, decimal In_Air_Density
            , decimal ET, decimal Wind_Samp, decimal Wind_Tx, decimal ISS_Recept, decimal Arc_Int
            , decimal H_H_Brillo_Solar, decimal HR_90, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_ESTACION_METEOROLOGICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Hora", SqlDbType.DateTime).Value = Hora;
                    comando.Parameters.AddWithValue("@Temp_Out", SqlDbType.Decimal).Value = Temp_Out;
                    comando.Parameters.AddWithValue("@Hi_Temp", SqlDbType.Decimal).Value = Hi_Temp;
                    comando.Parameters.AddWithValue("@Low_Temp", SqlDbType.Decimal).Value = Low_Temp;
                    comando.Parameters.AddWithValue("@Out_Hum", SqlDbType.Decimal).Value = Out_Hum;
                    comando.Parameters.AddWithValue("@Dew_Pt", SqlDbType.Decimal).Value = Dew_Pt;
                    comando.Parameters.AddWithValue("@Wind_Speed", SqlDbType.Decimal).Value = Wind_Speed;
                    comando.Parameters.AddWithValue("@Wind_Dir", SqlDbType.VarChar).Value = Wind_Dir;
                    comando.Parameters.AddWithValue("@Wind_Run", SqlDbType.Decimal).Value = Wind_Run;
                    comando.Parameters.AddWithValue("@Hi_Speed", SqlDbType.Decimal).Value = Hi_Speed;
                    comando.Parameters.AddWithValue("@Hi_Dir", SqlDbType.VarChar).Value = Hi_Dir;
                    comando.Parameters.AddWithValue("@Wind_Chill", SqlDbType.Decimal).Value = Wind_Chill;
                    comando.Parameters.AddWithValue("@Heat_Index", SqlDbType.Decimal).Value = Heat_Index;
                    comando.Parameters.AddWithValue("@THW_Index", SqlDbType.Decimal).Value = THW_Index;
                    comando.Parameters.AddWithValue("@THSW_Index", SqlDbType.VarChar).Value = THSW_Index;
                    comando.Parameters.AddWithValue("@Bar", SqlDbType.Decimal).Value = Bar;
                    comando.Parameters.AddWithValue("@Rain", SqlDbType.Decimal).Value = Rain;
                    comando.Parameters.AddWithValue("@Rain_Rate", SqlDbType.Decimal).Value = Rain_Rate;
                    comando.Parameters.AddWithValue("@Solar_Rad", SqlDbType.Decimal).Value = Solar_Rad;
                    comando.Parameters.AddWithValue("@Solar_Energy", SqlDbType.Decimal).Value = Solar_Energy;
                    comando.Parameters.AddWithValue("@Hi_Solar_Rad", SqlDbType.Decimal).Value = Hi_Solar_Rad;
                    comando.Parameters.AddWithValue("@UV_Index", SqlDbType.Decimal).Value = UV_Index;
                    comando.Parameters.AddWithValue("@UV_Dose", SqlDbType.Decimal).Value = UV_Dose;
                    comando.Parameters.AddWithValue("@Hi_UV", SqlDbType.Decimal).Value = Hi_UV;
                    comando.Parameters.AddWithValue("@Heat_D_D", SqlDbType.Decimal).Value = Heat_D_D;
                    comando.Parameters.AddWithValue("@Cool_D_D", SqlDbType.Decimal).Value = Cool_D_D;
                    comando.Parameters.AddWithValue("@In_Temp", SqlDbType.Decimal).Value = In_Temp;
                    comando.Parameters.AddWithValue("@In_Hum", SqlDbType.Decimal).Value = In_Hum;
                    comando.Parameters.AddWithValue("@In_Dew", SqlDbType.Decimal).Value = In_Dew;
                    comando.Parameters.AddWithValue("@In_Heat", SqlDbType.Decimal).Value = In_Heat;
                    comando.Parameters.AddWithValue("@In_EMC", SqlDbType.Decimal).Value = In_EMC;
                    comando.Parameters.AddWithValue("@In_Air_Density", SqlDbType.Decimal).Value = In_Air_Density;
                    comando.Parameters.AddWithValue("@ET", SqlDbType.Decimal).Value = ET;
                    comando.Parameters.AddWithValue("@Wind_Samp", SqlDbType.Decimal).Value = Wind_Samp;
                    comando.Parameters.AddWithValue("@Wind_Tx", SqlDbType.Decimal).Value = Wind_Tx;
                    comando.Parameters.AddWithValue("@ISS_Recept", SqlDbType.Decimal).Value = ISS_Recept;
                    comando.Parameters.AddWithValue("@Arc_Int", SqlDbType.Decimal).Value = Arc_Int;
                    comando.Parameters.AddWithValue("@H_H_Brillo_Solar", SqlDbType.Decimal).Value = H_H_Brillo_Solar;
                    comando.Parameters.AddWithValue("@HR_90", SqlDbType.Decimal).Value = HR_90;

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


        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarMetroCubico(string sede, string cabezal
            , DateTime Fecha, decimal programado
            , decimal ejecutado, decimal eficiencia, string Observacion
            //, string hoja
            //, string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit
            )
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_RIE_METROCUBICO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Programado", SqlDbType.Decimal).Value = programado;
                    comando.Parameters.AddWithValue("@Ejecutado", SqlDbType.Decimal).Value = ejecutado;
                    comando.Parameters.AddWithValue("@Eficiencia", SqlDbType.Decimal).Value = eficiencia;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

                    //comando.Parameters.AddWithValue("@Time_Horas", SqlDbType.Decimal).Value = Time_Horas;
                    //comando.Parameters.AddWithValue("@Num_Pulsos", SqlDbType.Decimal).Value = Num_Pulsos;
                    //comando.Parameters.AddWithValue("@Volum_Teorico", SqlDbType.Decimal).Value = Volum_Teorico;
                    //comando.Parameters.AddWithValue("@Volum_Teorico_Maseta", SqlDbType.Decimal).Value = Volum_Teorico_Maseta;
                    //comando.Parameters.AddWithValue("@Percolado_2Macetas_Dia", SqlDbType.Decimal).Value = Percolado_2Macetas_Dia;
                    //comando.Parameters.AddWithValue("@Percolado_1Macetas_Dia", SqlDbType.Decimal).Value = Percolado_1Macetas_Dia;
                    //comando.Parameters.AddWithValue("@Porcen_Percolacion", SqlDbType.Decimal).Value = Porcen_Percolacion;
                    //comando.Parameters.AddWithValue("@PH", SqlDbType.Decimal).Value = PH;
                    //comando.Parameters.AddWithValue("@CE", SqlDbType.Decimal).Value = CE;
                    //comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

                    //comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    //comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    //comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarPersonalObservado(DateTime Fecha
            , string dni, string apenom, string Observacion
            //, string hoja
            //, string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit
            )
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CP_PERSONALOBSERVADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = Observacion;

                    //comando.Parameters.AddWithValue("@Time_Horas", SqlDbType.Decimal).Value = Time_Horas;
                    //comando.Parameters.AddWithValue("@Num_Pulsos", SqlDbType.Decimal).Value = Num_Pulsos;
                    //comando.Parameters.AddWithValue("@Volum_Teorico", SqlDbType.Decimal).Value = Volum_Teorico;
                    //comando.Parameters.AddWithValue("@Volum_Teorico_Maseta", SqlDbType.Decimal).Value = Volum_Teorico_Maseta;
                    //comando.Parameters.AddWithValue("@Percolado_2Macetas_Dia", SqlDbType.Decimal).Value = Percolado_2Macetas_Dia;
                    //comando.Parameters.AddWithValue("@Percolado_1Macetas_Dia", SqlDbType.Decimal).Value = Percolado_1Macetas_Dia;
                    //comando.Parameters.AddWithValue("@Porcen_Percolacion", SqlDbType.Decimal).Value = Porcen_Percolacion;
                    //comando.Parameters.AddWithValue("@PH", SqlDbType.Decimal).Value = PH;
                    //comando.Parameters.AddWithValue("@CE", SqlDbType.Decimal).Value = CE;
                    //comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

                    //comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    //comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    //comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarProgramaRiego(string Empresa, string cabezal
            , DateTime Fecha, string dia, string programa, DateTime tot_horas
            , decimal Consumo_M3, decimal M3_Ha, decimal Cuba_A_Lts
            , decimal Cuba_B_Lts, decimal Cuba_C_Lts, decimal Cuba_Fito_Lts
            , string Observacion, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_RIE_PROGRAMACION_RIEGO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    comando.Parameters.AddWithValue("@Dia", SqlDbType.VarChar).Value = dia;
                    comando.Parameters.AddWithValue("@Programa", SqlDbType.VarChar).Value = programa;
                    comando.Parameters.AddWithValue("@Tot_Horas", SqlDbType.DateTime).Value = tot_horas;

                    comando.Parameters.AddWithValue("@Consumo_M3", SqlDbType.Decimal).Value = Consumo_M3;
                    comando.Parameters.AddWithValue("@M3_Ha", SqlDbType.Decimal).Value = M3_Ha;
                    comando.Parameters.AddWithValue("@Cuba_A_Lts", SqlDbType.Decimal).Value = Cuba_A_Lts;
                    comando.Parameters.AddWithValue("@Cuba_B_Lts", SqlDbType.Decimal).Value = Cuba_B_Lts;
                    comando.Parameters.AddWithValue("@Cuba_C_Lts", SqlDbType.Decimal).Value = Cuba_C_Lts;
                    comando.Parameters.AddWithValue("@Cuba_Fito_Lts", SqlDbType.Decimal).Value = Cuba_Fito_Lts;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;

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



        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarEvaluacionCampo(string empresa
            , DateTime fecha, string sede, string cabezal, string cultivo
            , string lote, string muestra, string grupo_var, string variable
            , int total, decimal promedio, string semaforo, decimal severidad
            , string semaforo_2, decimal dispersion, string fenologia, string variedad
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_SA_EVALUACION_CAMPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Lote", SqlDbType.VarChar).Value = lote;
                    comando.Parameters.AddWithValue("@Muestra", SqlDbType.VarChar).Value = muestra;
                    comando.Parameters.AddWithValue("@Grupo_Variable", SqlDbType.VarChar).Value = grupo_var;
                    comando.Parameters.AddWithValue("@Variable", SqlDbType.VarChar).Value = variable;
                    comando.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = total;
                    comando.Parameters.AddWithValue("@Promedio", SqlDbType.Decimal).Value = promedio;
                    comando.Parameters.AddWithValue("@Semaforo", SqlDbType.VarChar).Value = semaforo;
                    comando.Parameters.AddWithValue("@Severidad", SqlDbType.Decimal).Value = severidad;
                    comando.Parameters.AddWithValue("@Semaforo_2", SqlDbType.VarChar).Value = semaforo_2;
                    comando.Parameters.AddWithValue("@Dispersion", SqlDbType.Decimal).Value = dispersion;
                    comando.Parameters.AddWithValue("@Fenologia", SqlDbType.VarChar).Value = fenologia;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;

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



        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarReservorio(string empresa
            , DateTime fecha, string reservorio, string hora_medida
            , decimal Cantidad, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_RIE_RESERVORIO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Reservorio", SqlDbType.VarChar).Value = reservorio;
                    comando.Parameters.AddWithValue("@Hora_Medida", SqlDbType.VarChar).Value = hora_medida;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Decimal).Value = Cantidad;

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


        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarFertilizacion(string empresa, int id
            , DateTime fecha, string Fenologia, string Pulsos_Fertilizados
            , string Pulsos_Riego, decimal Horas, string Variedad
            , string Nombre_Comercial, string Ing_Activo, decimal Base_1000LT
            , int Inyeccion, string Unidad, decimal Qm3_Varidad, int Volumen_Teorico
            , decimal KG_Teorico, decimal Suma_Qm3_Total, int Vol_Sol_Lt_Reportado
            , int Vol, decimal Cant, decimal Efi_Inyeccion, decimal Area
            , string Valvula_Int, string Tanque, string Operador, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_RIE_FERTILIZACION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Fenologia", SqlDbType.VarChar).Value = Fenologia;
                    comando.Parameters.AddWithValue("@Pulsos_Fertilizados", SqlDbType.VarChar).Value = Pulsos_Fertilizados;
                    comando.Parameters.AddWithValue("@Pulsos_Riego", SqlDbType.VarChar).Value = Pulsos_Riego;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.Decimal).Value = Horas;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = Variedad;
                    comando.Parameters.AddWithValue("@Nombre_Comercial", SqlDbType.VarChar).Value = Nombre_Comercial;
                    comando.Parameters.AddWithValue("@Ing_Activo", SqlDbType.VarChar).Value = Ing_Activo;
                    comando.Parameters.AddWithValue("@Base_1000LT", SqlDbType.Decimal).Value = Base_1000LT;
                    comando.Parameters.AddWithValue("@Inyeccion", SqlDbType.Int).Value = Inyeccion;
                    comando.Parameters.AddWithValue("@Unidad", SqlDbType.VarChar).Value = Unidad;
                    comando.Parameters.AddWithValue("@Qm3_Varidad", SqlDbType.Decimal).Value = Qm3_Varidad;
                    comando.Parameters.AddWithValue("@Volumen_Teorico", SqlDbType.Int).Value = Volumen_Teorico;
                    comando.Parameters.AddWithValue("@KG_Teorico", SqlDbType.Decimal).Value = KG_Teorico;
                    comando.Parameters.AddWithValue("@Suma_Qm3_Total", SqlDbType.Decimal).Value = Suma_Qm3_Total;
                    comando.Parameters.AddWithValue("@Vol_Sol_Lt_Reportado", SqlDbType.Int).Value = Vol_Sol_Lt_Reportado;
                    comando.Parameters.AddWithValue("@Vol", SqlDbType.Int).Value = Vol;
                    comando.Parameters.AddWithValue("@Cant", SqlDbType.Decimal).Value = Cant;
                    comando.Parameters.AddWithValue("@Efi_Inyeccion", SqlDbType.Decimal).Value = Cant;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.Decimal).Value = Cant;
                    comando.Parameters.AddWithValue("@Valvula_Int", SqlDbType.VarChar).Value = Valvula_Int;
                    comando.Parameters.AddWithValue("@Tanque", SqlDbType.VarChar).Value = Tanque;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = Operador;

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



        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarPulsos(string sede
            , string cabezal, string variedad, int valvula, DateTime fecha
            , decimal pulsos, string obs)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_RIE_PROGRAMA_PULSOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.AddWithValue("@Valvula", SqlDbType.Int).Value = valvula;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Pulsos", SqlDbType.Decimal).Value = pulsos;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.ExecuteNonQuery();

                }
            }

        }




        // MOSTRAR LISTA COSECHA VALVULA
        public DataTable ListaReporteCosechaValvula(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cab)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_COSECHA_VALVULA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cab", SqlDbType.VarChar).Value = cab;
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



        // MOSTRAR LISTA COSECHA VALVULA VARIEDAD
        public DataTable ListaReporteCosechaValvulaVariedad(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cab)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_COSECHA_VALVULA_VARIEDAD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fechaini", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Fechafin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Cab", SqlDbType.VarChar).Value = cab;
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



        public void GuardarProdKgProyectadoBulk(DataTable dt)
        {
            var connection = leerconexion(); // Tu método para obtener SqlConnection

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_GuardarProyeccionKilosBulk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.Parameters.AddWithValue("@Datos", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.ProdProyeccionKilosType";

                    cmd.CommandTimeout = 300; // Opcional: tiempo de espera

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al ejecutar el procedimiento MERGE", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al guardar datos", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        public void GuardarProgHectareaBulk(DataTable dt)
        {
            var connection = leerconexion(); // Tu método para obtener SqlConnection

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_GuardarProgHectareaBulk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.Parameters.AddWithValue("@Datos", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.PROD_PoyeccionHectareaVarType";

                    cmd.CommandTimeout = 300; // Opcional: tiempo de espera

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al ejecutar el procedimiento MERGE", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al guardar datos", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void GuardarTareoDetalladoBulk(DataTable dt)
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
                    CREATE TABLE #CP_TareoDetallado
                    (
                        Empresa VARCHAR(50),
                        Sede VARCHAR(30),
                        Fundo VARCHAR(50),
                        Grupo_Trabajo VARCHAR(80),
                        Cod_Grupo_Labor VARCHAR(20),
                        Grupo_Labor VARCHAR(80),
                        Cod_Labor VARCHAR(80),
                        Labor VARCHAR(180),
                        Labor_Correcta VARCHAR(10),
                        Uni_Med VARCHAR(20),
                        Cod_Cultivo VARCHAR(20),
                        Cultivo VARCHAR(30),
                        Fecha DATE,
                        DNI_Supervisor VARCHAR(15),
                        Supervisor VARCHAR(80),
                        Fec_Inicio DATETIME,
                        Fec_Fin DATETIME,
                        Horas_efectivas VARCHAR(80),
                        Total_Horas VARCHAR(80),
                        Dni_Responsable VARCHAR(80),
                        Responsable VARCHAR(180),
                        Dni VARCHAR(80),
                        Ape_Nom VARCHAR(80),
                        Avance DECIMAL(10,2),
                        Motivo_Salida VARCHAR(80),
                        Tipo_Labor VARCHAR(20),
                        Cabezal VARCHAR(50),
                        CodCentroCosto VARCHAR(50),
                        CentroCosto VARCHAR(180),
                        Observacion VARCHAR(480),
                        Hoja VARCHAR(150),
                        Estado VARCHAR(10),
                        FecEdit DATETIME,
                        UseEdit INT,
                        HostName VARCHAR(150),
                        FecCre DATETIME,
                        UseReg INT
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
                            bulkCopy.DestinationTableName = "#CP_TareoDetallado";

                            bulkCopy.BatchSize = 2000;
                            bulkCopy.BulkCopyTimeout = 0;

                            bulkCopy.ColumnMappings.Add("Empresa", "Empresa");
                            bulkCopy.ColumnMappings.Add("Sede", "Sede");
                            bulkCopy.ColumnMappings.Add("Fundo", "Fundo");
                            bulkCopy.ColumnMappings.Add("Grupo_Trabajo", "Grupo_Trabajo");
                            bulkCopy.ColumnMappings.Add("Cod_Grupo_Labor", "Cod_Grupo_Labor");
                            bulkCopy.ColumnMappings.Add("Grupo_Labor", "Grupo_Labor");
                            bulkCopy.ColumnMappings.Add("Cod_Labor", "Cod_Labor");
                            bulkCopy.ColumnMappings.Add("Labor", "Labor");
                            bulkCopy.ColumnMappings.Add("Labor_Correcta", "Labor_Correcta");
                            bulkCopy.ColumnMappings.Add("Uni_Med", "Uni_Med");
                            bulkCopy.ColumnMappings.Add("Cod_Cultivo", "Cod_Cultivo");
                            bulkCopy.ColumnMappings.Add("Cultivo", "Cultivo");
                            bulkCopy.ColumnMappings.Add("Fecha", "Fecha");
                            bulkCopy.ColumnMappings.Add("DNI_Supervisor", "DNI_Supervisor");
                            bulkCopy.ColumnMappings.Add("Supervisor", "Supervisor");
                            bulkCopy.ColumnMappings.Add("Fec_Inicio", "Fec_Inicio");
                            bulkCopy.ColumnMappings.Add("Fec_Fin", "Fec_Fin");
                            bulkCopy.ColumnMappings.Add("Horas_efectivas", "Horas_efectivas");
                            bulkCopy.ColumnMappings.Add("Total_Horas", "Total_Horas");
                            bulkCopy.ColumnMappings.Add("Dni_Responsable", "Dni_Responsable");
                            bulkCopy.ColumnMappings.Add("Responsable", "Responsable");
                            bulkCopy.ColumnMappings.Add("Dni", "Dni");
                            bulkCopy.ColumnMappings.Add("Ape_Nom", "Ape_Nom");
                            bulkCopy.ColumnMappings.Add("Avance", "Avance");
                            bulkCopy.ColumnMappings.Add("Motivo_Salida", "Motivo_Salida");
                            bulkCopy.ColumnMappings.Add("Tipo_Labor", "Tipo_Labor");
                            bulkCopy.ColumnMappings.Add("Cabezal", "Cabezal");
                            bulkCopy.ColumnMappings.Add("CodCentroCosto", "CodCentroCosto");
                            bulkCopy.ColumnMappings.Add("CentroCosto", "CentroCosto");
                            bulkCopy.ColumnMappings.Add("Observacion", "Observacion");
                            bulkCopy.ColumnMappings.Add("Hoja", "Hoja");
                            bulkCopy.ColumnMappings.Add("Estado", "Estado");
                            bulkCopy.ColumnMappings.Add("FecEdit", "FecEdit");
                            bulkCopy.ColumnMappings.Add("UseEdit", "UseEdit");
                            bulkCopy.ColumnMappings.Add("HostName", "HostName");
                            bulkCopy.ColumnMappings.Add("FecCre", "FecCre");
                            bulkCopy.ColumnMappings.Add("UseReg", "UseReg");

                            bulkCopy.WriteToServer(dt);
                        }


                        // =====================================================
                        // 3. EJECUTAR SP
                        // =====================================================
                        using (SqlCommand comando = new SqlCommand(
                            "SP_GUARDAR_CP_TAREO_DETALLADO_BULK",
                            conexion,
                            transaction))
                        {
                            comando.CommandType = CommandType.StoredProcedure;
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
