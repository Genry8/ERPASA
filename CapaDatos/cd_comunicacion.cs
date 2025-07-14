using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_comunicacion : cd_conexion
    {

        // METODO EXISTE ESTACION METEOROLÓCIGA
        public bool BuscExisteCosechandoGanadores(string empresa, string sede, DateTime fecha, int item)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_COM_COSECHANDOGANADORES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
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
        public bool BuscExisteLideresEnAccion(string empresa, string sede, DateTime fecha, int item)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_COM_LIDERESACCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
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
        public bool BuscExistePotenciandoLideres(string empresa, string sede, DateTime fecha, int item)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_COM_POTENCIANDOLIDERES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
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



        // METODO ELIMINAR ENCUESTA CLIMA
        public bool EliminarExisteEncuestaClima(
            string tipopersonal, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_COM_ENCUESTACLIMA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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

        // METODO ELIMINAR PARTICIPACION CLIMA
        public bool EliminarParticipacionClima(
            string tipopersonal, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_COM_PARTICIPACION_CLIMA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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



        // ACTUAKIZAR ESTACION METEOROLOGICA
        public void ActualizarCosechandoGanadores(int item, DateTime Fecha
            , string Situacion, string Sol_Reconoce, string Sol_Empresa, string Sol_Gerencia
            , string Sol_Sede, string Sol_Cargo, string Sol_Area, string Rec_Reconocido
            , string Rec_Gerencia, string Rec_Cargo, string Rec_Area, string Rec_Motivo
            , string Rec_Tipo
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_COM_COSECHANDOGANADORES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Situacion", SqlDbType.VarChar).Value = Situacion;
                    comando.Parameters.AddWithValue("@Sol_Reconoce", SqlDbType.VarChar).Value = Sol_Reconoce;
                    comando.Parameters.AddWithValue("@Sol_Empresa", SqlDbType.VarChar).Value = Sol_Empresa;
                    comando.Parameters.AddWithValue("@Sol_Gerencia", SqlDbType.VarChar).Value = Sol_Gerencia;
                    comando.Parameters.AddWithValue("@Sol_Sede", SqlDbType.VarChar).Value = Sol_Sede;
                    comando.Parameters.AddWithValue("@Sol_Cargo", SqlDbType.VarChar).Value = Sol_Cargo;
                    comando.Parameters.AddWithValue("@Sol_Area", SqlDbType.VarChar).Value = Sol_Area;
                    comando.Parameters.AddWithValue("@Rec_Reconocido", SqlDbType.VarChar).Value = Rec_Reconocido;
                    comando.Parameters.AddWithValue("@Rec_Gerencia", SqlDbType.VarChar).Value = Rec_Gerencia;
                    comando.Parameters.AddWithValue("@Rec_Cargo", SqlDbType.VarChar).Value = Rec_Cargo;
                    comando.Parameters.AddWithValue("@Rec_Area", SqlDbType.VarChar).Value = Rec_Area;
                    comando.Parameters.AddWithValue("@Rec_Motivo", SqlDbType.VarChar).Value = Rec_Motivo;
                    comando.Parameters.AddWithValue("@Rec_Tipo", SqlDbType.VarChar).Value = Rec_Tipo;

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
        public void ActualizarLideresEnAccion(int item, DateTime Fecha
            , string Ape_Nom, string Dni, string Empresa, string Sede
            , string Area, string Jefe, decimal Puntaje, string Categoria
            , int Estrellas, string Premio
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_COM_LIDERESACCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Jefe", SqlDbType.VarChar).Value = Jefe;
                    comando.Parameters.AddWithValue("@Puntaje", SqlDbType.Decimal).Value = Puntaje;
                    comando.Parameters.AddWithValue("@Categoria", SqlDbType.VarChar).Value = Categoria;
                    comando.Parameters.AddWithValue("@Estrellas", SqlDbType.Int).Value = Estrellas;
                    comando.Parameters.AddWithValue("@Premio", SqlDbType.VarChar).Value = Premio;

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
        public void ActualizarPotenciandoLideres(int item
            , string Cabezal, string Area, string Empresa, string Sede
            , string Supervisor, string DniSupervidor, DateTime Fecha
            , string Entrevistado, string Dimensiones, string Observacion
            , string ObsGeneral, string Apoyo, string CuandoPlaneadoIni
            , string CuandoPlaneadoFin, string CuandoRealizadoIni
            , string CuandoRealizadoFin
            , string EstadoAvance
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_COM_POTENCIANDOLIDERES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = Cabezal;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Supervisor", SqlDbType.VarChar).Value = Supervisor;
                    comando.Parameters.AddWithValue("@DniSupervidor", SqlDbType.VarChar).Value = DniSupervidor;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Entrevistado", SqlDbType.VarChar).Value = Entrevistado;
                    comando.Parameters.AddWithValue("@Dimensiones", SqlDbType.VarChar).Value = Dimensiones;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;
                    comando.Parameters.AddWithValue("@ObsGeneral", SqlDbType.VarChar).Value = ObsGeneral;
                    comando.Parameters.AddWithValue("@Apoyo", SqlDbType.VarChar).Value = Apoyo;
                    comando.Parameters.AddWithValue("@CuandoPlaneadoIni", SqlDbType.VarChar).Value = CuandoPlaneadoIni;
                    comando.Parameters.AddWithValue("@CuandoPlaneadoFin", SqlDbType.VarChar).Value = CuandoPlaneadoFin;
                    comando.Parameters.AddWithValue("@CuandoRealizadoIni", SqlDbType.VarChar).Value = CuandoRealizadoIni;
                    comando.Parameters.AddWithValue("@CuandoRealizadoFin", SqlDbType.VarChar).Value = CuandoRealizadoFin;
                    comando.Parameters.AddWithValue("@EstadoAvance", SqlDbType.VarChar).Value = EstadoAvance;

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
        public void ActualizarEncuestaClima(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8, string item_9, string item_10
            , string item_11, string item_12, string item_13, string item_14, string item_15
            , string item_16, string item_17, string item_18, string item_19, string item_20
            , string item_21, string item_22, string item_23, string item_24, string item_25
            , string item_26, string item_27, string item_28, string item_29, string item_30
            , string item_31, string item_32, string item_33, string item_34, string item_35
            , string item_36, string item_37, string item_38, string item_39, string item_40
            , string item_41, string item_42, string item_43, string item_44, string item_45
            , string item_46, string item_47, string item_48, string item_49, string item_50
            , string item_51, string item_52, string item_53, string item_54, string item_55
            , string item_56, string item_57, string item_58, string item_59, string item_60
            , string item_61, string item_62, string item_63, string item_64, string item_65
            , string item_66, string item_67, string item_68, string item_69, string item_70
            , string item_71, string item_72, string sugerencia
            , string Comentario, string tipopersonal
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_COM_ENCUESTACLIMA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fecha_Respuesta", SqlDbType.Date).Value = Fecha_Respuesta;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = Sexo;
                    comando.Parameters.AddWithValue("@Rango_Edad", SqlDbType.VarChar).Value = Rango_edad;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Puesto", SqlDbType.VarChar).Value = puesto;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Tiempo_en_Compañia", SqlDbType.VarChar).Value = tiempo_compañia;
                    comando.Parameters.AddWithValue("@Item_1", SqlDbType.VarChar).Value = item_1;
                    comando.Parameters.AddWithValue("@Item_2", SqlDbType.VarChar).Value = item_2;
                    comando.Parameters.AddWithValue("@Item_3", SqlDbType.VarChar).Value = item_3;
                    comando.Parameters.AddWithValue("@Item_4", SqlDbType.VarChar).Value = item_4;
                    comando.Parameters.AddWithValue("@Item_5", SqlDbType.VarChar).Value = item_5;
                    comando.Parameters.AddWithValue("@Item_6", SqlDbType.VarChar).Value = item_6;
                    comando.Parameters.AddWithValue("@Item_7", SqlDbType.VarChar).Value = item_7;
                    comando.Parameters.AddWithValue("@Item_8", SqlDbType.VarChar).Value = item_8;
                    comando.Parameters.AddWithValue("@Item_9", SqlDbType.VarChar).Value = item_9;
                    comando.Parameters.AddWithValue("@Item_10", SqlDbType.VarChar).Value = item_10;
                    comando.Parameters.AddWithValue("@Item_11", SqlDbType.VarChar).Value = item_11;
                    comando.Parameters.AddWithValue("@Item_12", SqlDbType.VarChar).Value = item_12;
                    comando.Parameters.AddWithValue("@Item_13", SqlDbType.VarChar).Value = item_13;
                    comando.Parameters.AddWithValue("@Item_14", SqlDbType.VarChar).Value = item_14;
                    comando.Parameters.AddWithValue("@Item_15", SqlDbType.VarChar).Value = item_15;
                    comando.Parameters.AddWithValue("@Item_16", SqlDbType.VarChar).Value = item_16;
                    comando.Parameters.AddWithValue("@Item_17", SqlDbType.VarChar).Value = item_17;
                    comando.Parameters.AddWithValue("@Item_18", SqlDbType.VarChar).Value = item_18;
                    comando.Parameters.AddWithValue("@Item_19", SqlDbType.VarChar).Value = item_19;
                    comando.Parameters.AddWithValue("@Item_20", SqlDbType.VarChar).Value = item_20;
                    comando.Parameters.AddWithValue("@Item_21", SqlDbType.VarChar).Value = item_21;
                    comando.Parameters.AddWithValue("@Item_22", SqlDbType.VarChar).Value = item_22;
                    comando.Parameters.AddWithValue("@Item_23", SqlDbType.VarChar).Value = item_23;
                    comando.Parameters.AddWithValue("@Item_24", SqlDbType.VarChar).Value = item_24;
                    comando.Parameters.AddWithValue("@Item_25", SqlDbType.VarChar).Value = item_25;
                    comando.Parameters.AddWithValue("@Item_26", SqlDbType.VarChar).Value = item_26;
                    comando.Parameters.AddWithValue("@Item_27", SqlDbType.VarChar).Value = item_27;
                    comando.Parameters.AddWithValue("@Item_28", SqlDbType.VarChar).Value = item_28;
                    comando.Parameters.AddWithValue("@Item_29", SqlDbType.VarChar).Value = item_29;
                    comando.Parameters.AddWithValue("@Item_30", SqlDbType.VarChar).Value = item_30;
                    comando.Parameters.AddWithValue("@Item_31", SqlDbType.VarChar).Value = item_31;
                    comando.Parameters.AddWithValue("@Item_32", SqlDbType.VarChar).Value = item_32;
                    comando.Parameters.AddWithValue("@Item_33", SqlDbType.VarChar).Value = item_33;
                    comando.Parameters.AddWithValue("@Item_34", SqlDbType.VarChar).Value = item_34;
                    comando.Parameters.AddWithValue("@Item_35", SqlDbType.VarChar).Value = item_35;
                    comando.Parameters.AddWithValue("@Item_36", SqlDbType.VarChar).Value = item_36;
                    comando.Parameters.AddWithValue("@Item_37", SqlDbType.VarChar).Value = item_37;
                    comando.Parameters.AddWithValue("@Item_38", SqlDbType.VarChar).Value = item_38;
                    comando.Parameters.AddWithValue("@Item_39", SqlDbType.VarChar).Value = item_39;
                    comando.Parameters.AddWithValue("@Item_40", SqlDbType.VarChar).Value = item_40;
                    comando.Parameters.AddWithValue("@Item_41", SqlDbType.VarChar).Value = item_41;
                    comando.Parameters.AddWithValue("@Item_42", SqlDbType.VarChar).Value = item_42;
                    comando.Parameters.AddWithValue("@Item_43", SqlDbType.VarChar).Value = item_43;
                    comando.Parameters.AddWithValue("@Item_44", SqlDbType.VarChar).Value = item_44;
                    comando.Parameters.AddWithValue("@Item_45", SqlDbType.VarChar).Value = item_45;
                    comando.Parameters.AddWithValue("@Item_46", SqlDbType.VarChar).Value = item_46;
                    comando.Parameters.AddWithValue("@Item_47", SqlDbType.VarChar).Value = item_47;
                    comando.Parameters.AddWithValue("@Item_48", SqlDbType.VarChar).Value = item_48;
                    comando.Parameters.AddWithValue("@Item_49", SqlDbType.VarChar).Value = item_49;
                    comando.Parameters.AddWithValue("@Item_50", SqlDbType.VarChar).Value = item_50;
                    comando.Parameters.AddWithValue("@Item_51", SqlDbType.VarChar).Value = item_51;
                    comando.Parameters.AddWithValue("@Item_52", SqlDbType.VarChar).Value = item_52;
                    comando.Parameters.AddWithValue("@Item_53", SqlDbType.VarChar).Value = item_53;
                    comando.Parameters.AddWithValue("@Item_54", SqlDbType.VarChar).Value = item_54;
                    comando.Parameters.AddWithValue("@Item_55", SqlDbType.VarChar).Value = item_55;
                    comando.Parameters.AddWithValue("@Item_56", SqlDbType.VarChar).Value = item_56;
                    comando.Parameters.AddWithValue("@Item_57", SqlDbType.VarChar).Value = item_57;
                    comando.Parameters.AddWithValue("@Item_58", SqlDbType.VarChar).Value = item_58;
                    comando.Parameters.AddWithValue("@Item_59", SqlDbType.VarChar).Value = item_59;
                    comando.Parameters.AddWithValue("@Item_60", SqlDbType.VarChar).Value = item_60;
                    comando.Parameters.AddWithValue("@Item_61", SqlDbType.VarChar).Value = item_61;
                    comando.Parameters.AddWithValue("@Item_62", SqlDbType.VarChar).Value = item_62;
                    comando.Parameters.AddWithValue("@Item_63", SqlDbType.VarChar).Value = item_63;
                    comando.Parameters.AddWithValue("@Item_64", SqlDbType.VarChar).Value = item_64;
                    comando.Parameters.AddWithValue("@Item_65", SqlDbType.VarChar).Value = item_65;
                    comando.Parameters.AddWithValue("@Item_66", SqlDbType.VarChar).Value = item_66;
                    comando.Parameters.AddWithValue("@Item_67", SqlDbType.VarChar).Value = item_67;
                    comando.Parameters.AddWithValue("@Item_68", SqlDbType.VarChar).Value = item_68;
                    comando.Parameters.AddWithValue("@Item_69", SqlDbType.VarChar).Value = item_69;
                    comando.Parameters.AddWithValue("@Item_70", SqlDbType.VarChar).Value = item_70;
                    comando.Parameters.AddWithValue("@Item_71", SqlDbType.VarChar).Value = item_71;
                    comando.Parameters.AddWithValue("@Item_72", SqlDbType.VarChar).Value = item_72;
                    comando.Parameters.AddWithValue("@Sugerencia", SqlDbType.VarChar).Value = sugerencia;
                    comando.Parameters.AddWithValue("@Recomendacion_Sugerencia", SqlDbType.VarChar).Value = Comentario;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;

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






        // METODO PARA GUARDAR DETALLE COSECHADOR
        public void GuardarCosechandoGanadores(int item, DateTime Fecha
            , string Situacion, string Sol_Reconoce, string Sol_Empresa, string Sol_Gerencia
            , string Sol_Sede, string Sol_Cargo, string Sol_Area, string Rec_Reconocido
            , string Rec_Gerencia, string Rec_Cargo, string Rec_Area, string Rec_Motivo
            , string Rec_Tipo, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_COM_COSECHANDOGANADORES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Situacion", SqlDbType.VarChar).Value = Situacion;
                    comando.Parameters.AddWithValue("@Sol_Reconoce", SqlDbType.VarChar).Value = Sol_Reconoce;
                    comando.Parameters.AddWithValue("@Sol_Empresa", SqlDbType.VarChar).Value = Sol_Empresa;
                    comando.Parameters.AddWithValue("@Sol_Gerencia", SqlDbType.VarChar).Value = Sol_Gerencia;
                    comando.Parameters.AddWithValue("@Sol_Sede", SqlDbType.VarChar).Value = Sol_Sede;
                    comando.Parameters.AddWithValue("@Sol_Cargo", SqlDbType.VarChar).Value = Sol_Cargo;
                    comando.Parameters.AddWithValue("@Sol_Area", SqlDbType.VarChar).Value = Sol_Area;
                    comando.Parameters.AddWithValue("@Rec_Reconocido", SqlDbType.VarChar).Value = Rec_Reconocido;
                    comando.Parameters.AddWithValue("@Rec_Gerencia", SqlDbType.VarChar).Value = Rec_Gerencia;
                    comando.Parameters.AddWithValue("@Rec_Cargo", SqlDbType.VarChar).Value = Rec_Cargo;
                    comando.Parameters.AddWithValue("@Rec_Area", SqlDbType.VarChar).Value = Rec_Area;
                    comando.Parameters.AddWithValue("@Rec_Motivo", SqlDbType.VarChar).Value = Rec_Motivo;
                    comando.Parameters.AddWithValue("@Rec_Tipo", SqlDbType.VarChar).Value = Rec_Tipo;

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
        public void GuardarLideresEnAccion(int item, DateTime Fecha
            , string Ape_Nom, string Dni, string Empresa, string Sede
            , string Area, string Jefe, decimal Puntaje, string Categoria
            , int Estrellas, string Premio, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_COM_LIDERESACCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = Ape_Nom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Jefe", SqlDbType.VarChar).Value = Jefe;
                    comando.Parameters.AddWithValue("@Puntaje", SqlDbType.Decimal).Value = Puntaje;
                    comando.Parameters.AddWithValue("@Categoria", SqlDbType.VarChar).Value = Categoria;
                    comando.Parameters.AddWithValue("@Estrellas", SqlDbType.Int).Value = Estrellas;
                    comando.Parameters.AddWithValue("@Premio", SqlDbType.VarChar).Value = Premio;

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
        public void GuardarPotenciandoLideres(int item
            , string Cabezal, string Area, string Empresa, string Sede
            , string Supervisor, string DniSupervidor, DateTime Fecha
            , string Entrevistado, string Dimensiones, string Observacion
            , string ObsGeneral, string Apoyo, string CuandoPlaneadoIni
            , string CuandoPlaneadoFin, string CuandoRealizadoIni
            , string CuandoRealizadoFin
            , string EstadoAvance, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_COM_POTENCIANDOLIDERES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = item;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = Cabezal;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Supervisor", SqlDbType.VarChar).Value = Supervisor;
                    comando.Parameters.AddWithValue("@DniSupervidor", SqlDbType.VarChar).Value = DniSupervidor;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Entrevistado", SqlDbType.VarChar).Value = Entrevistado;
                    comando.Parameters.AddWithValue("@Dimensiones", SqlDbType.VarChar).Value = Dimensiones;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = Observacion;
                    comando.Parameters.AddWithValue("@ObsGeneral", SqlDbType.VarChar).Value = ObsGeneral;
                    comando.Parameters.AddWithValue("@Apoyo", SqlDbType.VarChar).Value = Apoyo;
                    comando.Parameters.AddWithValue("@CuandoPlaneadoIni", SqlDbType.VarChar).Value = CuandoPlaneadoIni;
                    comando.Parameters.AddWithValue("@CuandoPlaneadoFin", SqlDbType.VarChar).Value = CuandoPlaneadoFin;
                    comando.Parameters.AddWithValue("@CuandoRealizadoIni", SqlDbType.VarChar).Value = CuandoRealizadoIni;
                    comando.Parameters.AddWithValue("@CuandoRealizadoFin", SqlDbType.VarChar).Value = CuandoRealizadoFin;
                    comando.Parameters.AddWithValue("@EstadoAvance", SqlDbType.VarChar).Value = EstadoAvance;

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



        // METODO PARA GUARDAR ENCUESTA CLIMA
        public void GuardarEncuestaClima(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8, string item_9, string item_10
            , string item_11, string item_12, string item_13, string item_14, string item_15
            , string item_16, string item_17, string item_18, string item_19, string item_20
            , string item_21, string item_22, string item_23, string item_24, string item_25
            , string item_26, string item_27, string item_28, string item_29, string item_30
            , string item_31, string item_32, string item_33, string item_34, string item_35
            , string item_36, string item_37, string item_38, string item_39, string item_40
            , string item_41, string item_42, string item_43, string item_44, string item_45
            , string item_46, string item_47, string item_48, string item_49, string item_50
            , string item_51, string item_52, string item_53, string item_54, string item_55
            , string item_56, string item_57, string item_58, string item_59, string item_60
            , string item_61, string item_62, string item_63, string item_64, string item_65
            , string item_66, string item_67, string item_68, string item_69, string item_70
            , string item_71, string item_72, string sugerencia
            , string Comentario, string tipopersonal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_COM_ENCUESTACLIMA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fecha_Respuesta", SqlDbType.Date).Value = Fecha_Respuesta;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = Sexo;
                    comando.Parameters.AddWithValue("@Rango_Edad", SqlDbType.VarChar).Value = Rango_edad;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Puesto", SqlDbType.VarChar).Value = puesto;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Tiempo_en_Compañia", SqlDbType.VarChar).Value = tiempo_compañia;
                    comando.Parameters.AddWithValue("@Item_1", SqlDbType.VarChar).Value = item_1;
                    comando.Parameters.AddWithValue("@Item_2", SqlDbType.VarChar).Value = item_2;
                    comando.Parameters.AddWithValue("@Item_3", SqlDbType.VarChar).Value = item_3;
                    comando.Parameters.AddWithValue("@Item_4", SqlDbType.VarChar).Value = item_4;
                    comando.Parameters.AddWithValue("@Item_5", SqlDbType.VarChar).Value = item_5;
                    comando.Parameters.AddWithValue("@Item_6", SqlDbType.VarChar).Value = item_6;
                    comando.Parameters.AddWithValue("@Item_7", SqlDbType.VarChar).Value = item_7;
                    comando.Parameters.AddWithValue("@Item_8", SqlDbType.VarChar).Value = item_8;
                    comando.Parameters.AddWithValue("@Item_9", SqlDbType.VarChar).Value = item_9;
                    comando.Parameters.AddWithValue("@Item_10", SqlDbType.VarChar).Value = item_10;
                    comando.Parameters.AddWithValue("@Item_11", SqlDbType.VarChar).Value = item_11;
                    comando.Parameters.AddWithValue("@Item_12", SqlDbType.VarChar).Value = item_12;
                    comando.Parameters.AddWithValue("@Item_13", SqlDbType.VarChar).Value = item_13;
                    comando.Parameters.AddWithValue("@Item_14", SqlDbType.VarChar).Value = item_14;
                    comando.Parameters.AddWithValue("@Item_15", SqlDbType.VarChar).Value = item_15;
                    comando.Parameters.AddWithValue("@Item_16", SqlDbType.VarChar).Value = item_16;
                    comando.Parameters.AddWithValue("@Item_17", SqlDbType.VarChar).Value = item_17;
                    comando.Parameters.AddWithValue("@Item_18", SqlDbType.VarChar).Value = item_18;
                    comando.Parameters.AddWithValue("@Item_19", SqlDbType.VarChar).Value = item_19;
                    comando.Parameters.AddWithValue("@Item_20", SqlDbType.VarChar).Value = item_20;
                    comando.Parameters.AddWithValue("@Item_21", SqlDbType.VarChar).Value = item_21;
                    comando.Parameters.AddWithValue("@Item_22", SqlDbType.VarChar).Value = item_22;
                    comando.Parameters.AddWithValue("@Item_23", SqlDbType.VarChar).Value = item_23;
                    comando.Parameters.AddWithValue("@Item_24", SqlDbType.VarChar).Value = item_24;
                    comando.Parameters.AddWithValue("@Item_25", SqlDbType.VarChar).Value = item_25;
                    comando.Parameters.AddWithValue("@Item_26", SqlDbType.VarChar).Value = item_26;
                    comando.Parameters.AddWithValue("@Item_27", SqlDbType.VarChar).Value = item_27;
                    comando.Parameters.AddWithValue("@Item_28", SqlDbType.VarChar).Value = item_28;
                    comando.Parameters.AddWithValue("@Item_29", SqlDbType.VarChar).Value = item_29;
                    comando.Parameters.AddWithValue("@Item_30", SqlDbType.VarChar).Value = item_30;
                    comando.Parameters.AddWithValue("@Item_31", SqlDbType.VarChar).Value = item_31;
                    comando.Parameters.AddWithValue("@Item_32", SqlDbType.VarChar).Value = item_32;
                    comando.Parameters.AddWithValue("@Item_33", SqlDbType.VarChar).Value = item_33;
                    comando.Parameters.AddWithValue("@Item_34", SqlDbType.VarChar).Value = item_34;
                    comando.Parameters.AddWithValue("@Item_35", SqlDbType.VarChar).Value = item_35;
                    comando.Parameters.AddWithValue("@Item_36", SqlDbType.VarChar).Value = item_36;
                    comando.Parameters.AddWithValue("@Item_37", SqlDbType.VarChar).Value = item_37;
                    comando.Parameters.AddWithValue("@Item_38", SqlDbType.VarChar).Value = item_38;
                    comando.Parameters.AddWithValue("@Item_39", SqlDbType.VarChar).Value = item_39;
                    comando.Parameters.AddWithValue("@Item_40", SqlDbType.VarChar).Value = item_40;
                    comando.Parameters.AddWithValue("@Item_41", SqlDbType.VarChar).Value = item_41;
                    comando.Parameters.AddWithValue("@Item_42", SqlDbType.VarChar).Value = item_42;
                    comando.Parameters.AddWithValue("@Item_43", SqlDbType.VarChar).Value = item_43;
                    comando.Parameters.AddWithValue("@Item_44", SqlDbType.VarChar).Value = item_44;
                    comando.Parameters.AddWithValue("@Item_45", SqlDbType.VarChar).Value = item_45;
                    comando.Parameters.AddWithValue("@Item_46", SqlDbType.VarChar).Value = item_46;
                    comando.Parameters.AddWithValue("@Item_47", SqlDbType.VarChar).Value = item_47;
                    comando.Parameters.AddWithValue("@Item_48", SqlDbType.VarChar).Value = item_48;
                    comando.Parameters.AddWithValue("@Item_49", SqlDbType.VarChar).Value = item_49;
                    comando.Parameters.AddWithValue("@Item_50", SqlDbType.VarChar).Value = item_50;
                    comando.Parameters.AddWithValue("@Item_51", SqlDbType.VarChar).Value = item_51;
                    comando.Parameters.AddWithValue("@Item_52", SqlDbType.VarChar).Value = item_52;
                    comando.Parameters.AddWithValue("@Item_53", SqlDbType.VarChar).Value = item_53;
                    comando.Parameters.AddWithValue("@Item_54", SqlDbType.VarChar).Value = item_54;
                    comando.Parameters.AddWithValue("@Item_55", SqlDbType.VarChar).Value = item_55;
                    comando.Parameters.AddWithValue("@Item_56", SqlDbType.VarChar).Value = item_56;
                    comando.Parameters.AddWithValue("@Item_57", SqlDbType.VarChar).Value = item_57;
                    comando.Parameters.AddWithValue("@Item_58", SqlDbType.VarChar).Value = item_58;
                    comando.Parameters.AddWithValue("@Item_59", SqlDbType.VarChar).Value = item_59;
                    comando.Parameters.AddWithValue("@Item_60", SqlDbType.VarChar).Value = item_60;
                    comando.Parameters.AddWithValue("@Item_61", SqlDbType.VarChar).Value = item_61;
                    comando.Parameters.AddWithValue("@Item_62", SqlDbType.VarChar).Value = item_62;
                    comando.Parameters.AddWithValue("@Item_63", SqlDbType.VarChar).Value = item_63;
                    comando.Parameters.AddWithValue("@Item_64", SqlDbType.VarChar).Value = item_64;
                    comando.Parameters.AddWithValue("@Item_65", SqlDbType.VarChar).Value = item_65;
                    comando.Parameters.AddWithValue("@Item_66", SqlDbType.VarChar).Value = item_66;
                    comando.Parameters.AddWithValue("@Item_67", SqlDbType.VarChar).Value = item_67;
                    comando.Parameters.AddWithValue("@Item_68", SqlDbType.VarChar).Value = item_68;
                    comando.Parameters.AddWithValue("@Item_69", SqlDbType.VarChar).Value = item_69;
                    comando.Parameters.AddWithValue("@Item_70", SqlDbType.VarChar).Value = item_70;
                    comando.Parameters.AddWithValue("@Item_71", SqlDbType.VarChar).Value = item_71;
                    comando.Parameters.AddWithValue("@Item_72", SqlDbType.VarChar).Value = item_72;
                    comando.Parameters.AddWithValue("@Sugerencia", SqlDbType.VarChar).Value = sugerencia;
                    comando.Parameters.AddWithValue("@Recomendacion_Sugerencia", SqlDbType.VarChar).Value = Comentario;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;

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




        // METODO PARA GUARDAR ENCUESTA COMEDOR
        public void GuardarEncuestaComedor(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8
            , string Comentario, string tipopersonal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_ENCUESTA_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fecha_Respuesta", SqlDbType.Date).Value = Fecha_Respuesta;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = Sexo;
                    comando.Parameters.AddWithValue("@Rango_Edad", SqlDbType.VarChar).Value = Rango_edad;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Puesto", SqlDbType.VarChar).Value = puesto;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Tiempo_en_Compañia", SqlDbType.VarChar).Value = tiempo_compañia;
                    comando.Parameters.AddWithValue("@Item_1", SqlDbType.VarChar).Value = item_1;
                    comando.Parameters.AddWithValue("@Item_2", SqlDbType.VarChar).Value = item_2;
                    comando.Parameters.AddWithValue("@Item_3", SqlDbType.VarChar).Value = item_3;
                    comando.Parameters.AddWithValue("@Item_4", SqlDbType.VarChar).Value = item_4;
                    comando.Parameters.AddWithValue("@Item_5", SqlDbType.VarChar).Value = item_5;
                    comando.Parameters.AddWithValue("@Item_6", SqlDbType.VarChar).Value = item_6;
                    comando.Parameters.AddWithValue("@Item_7", SqlDbType.VarChar).Value = item_7;
                    comando.Parameters.AddWithValue("@Item_8", SqlDbType.VarChar).Value = item_8;
                    comando.Parameters.AddWithValue("@Recomendacion_Sugerencia", SqlDbType.VarChar).Value = Comentario;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;

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


        // METODO PARA GUARDAR SUBSIDIOS
        public void GuardarSubsidios(string id, string Empresa, string sede, string Dni
            , string apenom, string area, string tipotrab
            , string tipodescanso, string FecIniSubsidio, string FecFinSubsidio
            , string mes, string año, string dias
            , string fechaPresentacion, string fechaSeguimiento
            , string monto, string montoConta, string contingencia
            , string statusbienestar, string NITCIT, string obs
            , string añocarga, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SUBSIDIOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@NombreCompleto", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoTrab", SqlDbType.VarChar).Value = tipotrab;
                    comando.Parameters.AddWithValue("@TipoDescanso", SqlDbType.VarChar).Value = tipodescanso;
                    comando.Parameters.AddWithValue("@FecInicioSub", SqlDbType.DateTime).Value = FecIniSubsidio;
                    comando.Parameters.AddWithValue("@FecFinSub", SqlDbType.DateTime).Value = FecFinSubsidio;
                    comando.Parameters.AddWithValue("@mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@dias", SqlDbType.Int).Value = dias;
                    comando.Parameters.AddWithValue("@FechaPresentacion", SqlDbType.Int).Value = fechaPresentacion;
                    comando.Parameters.AddWithValue("@FechaSeguimiento", SqlDbType.Int).Value = fechaSeguimiento;
                    comando.Parameters.AddWithValue("@MontoSubsidio", SqlDbType.VarChar).Value = monto;
                    comando.Parameters.AddWithValue("@MontoContabilidad", SqlDbType.VarChar).Value = montoConta;
                    comando.Parameters.AddWithValue("@contingencia", SqlDbType.VarChar).Value = contingencia;
                    comando.Parameters.AddWithValue("@StatusBienestar", SqlDbType.VarChar).Value = statusbienestar;
                    comando.Parameters.AddWithValue("@NittCitt", SqlDbType.VarChar).Value = NITCIT;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@AñoCarga", SqlDbType.VarChar).Value = añocarga;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = semana;

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

        // METODO PARA GUARDAR ENCUESTA COMEDOR
        public void GuardarEncuestaCampamento(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8, string item_9
            , string Comentario, string tipopersonal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_ENCUESTA_CAMPAMENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Fecha_Respuesta", SqlDbType.Date).Value = Fecha_Respuesta;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = Fecha;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = Sexo;
                    comando.Parameters.AddWithValue("@Rango_Edad", SqlDbType.VarChar).Value = Rango_edad;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Puesto", SqlDbType.VarChar).Value = puesto;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Tiempo_en_Compañia", SqlDbType.VarChar).Value = tiempo_compañia;
                    comando.Parameters.AddWithValue("@Item_1", SqlDbType.VarChar).Value = item_1;
                    comando.Parameters.AddWithValue("@Item_2", SqlDbType.VarChar).Value = item_2;
                    comando.Parameters.AddWithValue("@Item_3", SqlDbType.VarChar).Value = item_3;
                    comando.Parameters.AddWithValue("@Item_4", SqlDbType.VarChar).Value = item_4;
                    comando.Parameters.AddWithValue("@Item_5", SqlDbType.VarChar).Value = item_5;
                    comando.Parameters.AddWithValue("@Item_6", SqlDbType.VarChar).Value = item_6;
                    comando.Parameters.AddWithValue("@Item_7", SqlDbType.VarChar).Value = item_7;
                    comando.Parameters.AddWithValue("@Item_8", SqlDbType.VarChar).Value = item_8;
                    comando.Parameters.AddWithValue("@Item_9", SqlDbType.VarChar).Value = item_9;
                    comando.Parameters.AddWithValue("@Recomendacion_Sugerencia", SqlDbType.VarChar).Value = Comentario;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;

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

        // METODO PARA GUARDAR LISTA VEHICULO
        public void GuardarListaVehiculos(
            string id, string placa, string tipoveh, string ructransporte
            , string transportista, string capacidad, string vencSoat
            , string VenRevTec, string VencPerTransporte, string activo
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_LISTA_VEHICULOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod_Vehiculo", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
                    comando.Parameters.AddWithValue("@Tipo_Vehiculo", SqlDbType.VarChar).Value = tipoveh;
                    comando.Parameters.AddWithValue("@RUC_Transportista", SqlDbType.VarChar).Value = ructransporte;
                    comando.Parameters.AddWithValue("@Transportistas", SqlDbType.VarChar).Value = transportista;
                    comando.Parameters.AddWithValue("@Capacidad", SqlDbType.VarChar).Value = capacidad;
                    comando.Parameters.AddWithValue("@Vencimiento_SOAT", SqlDbType.VarChar).Value = vencSoat;
                    comando.Parameters.AddWithValue("@Vencimiento_RevTec", SqlDbType.VarChar).Value = VenRevTec;
                    comando.Parameters.AddWithValue("@Vencimiento_Permiso", SqlDbType.VarChar).Value = VencPerTransporte;
                    comando.Parameters.AddWithValue("@Activo", SqlDbType.VarChar).Value = activo;

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

        // METODO PARA GUARDAR LISTA CONDUCTORES
        public void GuardarListaConductores(
            string id, string nombre, string dni, string ructransporte
            , string transportista
            , string num_licencia, string tipo_brevete, string vencLic
            , string vencSctr, string consalta, string activo
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_LISTA_CONDUCTORES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod_Conductor", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@RUC_Transportista", SqlDbType.VarChar).Value = ructransporte;
                    comando.Parameters.AddWithValue("@Transportista", SqlDbType.VarChar).Value = transportista;
                    comando.Parameters.AddWithValue("@Numero_Licencia", SqlDbType.VarChar).Value = num_licencia;
                    comando.Parameters.AddWithValue("@Tipo_Brevete", SqlDbType.VarChar).Value = tipo_brevete;
                    comando.Parameters.AddWithValue("@Vencimiento_Licencia", SqlDbType.VarChar).Value = vencLic;
                    comando.Parameters.AddWithValue("@Vencimiento_SCTR", SqlDbType.VarChar).Value = vencSctr;
                    comando.Parameters.AddWithValue("@Constancia_Alta", SqlDbType.VarChar).Value = consalta;
                    comando.Parameters.AddWithValue("@Activo", SqlDbType.VarChar).Value = activo;

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


        // METODO PARA ELIMINAR SUBSIDIOS
        public void EliminarSubsidios(string año, string sem)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_SUBSIDIOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ELIMINAR ENCUESTA COMEDOR
        public void EliminarEncuestaComedor(string sede, DateTime fecha, string tipo)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_ENCUESTA_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipo;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ELIMINAR ENCUESTA CAMPAMENTO
        public void EliminarEncuestaCampamento(string sede, DateTime fecha, string tipo)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_ENCUESTA_CAMPAMENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipo;
                    comando.ExecuteNonQuery();

                }
            }

        }





    }
}
