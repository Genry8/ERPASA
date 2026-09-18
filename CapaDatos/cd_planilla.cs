using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_planilla : cd_conexion
    {

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteAtenMedica(string cod, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_ATEN_MEDICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_topico.dni_paciente = reader.GetString(0);
                            ce_topico.Fecha = reader.GetDateTime(1);
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
        public bool BuscExisteAltasCeses(string emp, string cod, DateTime fechamov)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_ALTAS_CESES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha_movimiento", SqlDbType.DateTime).Value = fechamov;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_planilla.codAlta = reader.GetString(0);
                            ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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


        // METODO PARA LLAMAR SI EXISTE ASISTENCIA DETALLADA
        public bool BuscExisteAsistenciaDetallada(string cod, DateTime fechamov)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PL_ASISTENCIA_DETALLADA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fechamov;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.codAlta = reader.GetString(0);
                            //ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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
        public bool BuscExisteEficiencia(string año, int sem)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_EFICIENCIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    //comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.codAlta = reader.GetString(0);
                            //ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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


        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COBERTURA
        public bool EliminarCobertura(int año,
            string sem)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_COBERTURA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = sem;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.codAlta = reader.GetString(0);
                            //ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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



        // METODO PARA LLAMAR SI EXISTE REVISION GRUPO
        public bool BuscExisteRevisionGrupo(string cod, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_REVISION_GRUPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.codAlta = reader.GetString(0);
                            //ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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


        // METODO PARA LLAMAR SI EXISTE LABOR
        public bool BuscExisteLabor(string cod)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_LABOR"))
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
                            //ce_planilla.codAlta = reader.GetString(0);
                            //ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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


        // METODO PARA LLAMAR SI EXISTE LABOR
        public bool BuscExisteGrupoLabor(string cod, string grupo)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_GRUPOLABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.codAlta = reader.GetString(0);
                            //ce_planilla.FechaMovimiento = reader.GetDateTime(1);
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE TRABAJADOR TAREADO
        public bool BuscExisteTareajeTrabajador(string emp, string cod, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_TAREAJE_TRABAJADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_planilla.DniTareado = reader.GetString(0);
                            //ce_planilla.FechaTareado = reader.GetDateTime(1);
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
        public bool BuscExisteCompensacionDevolucion(int sem, int año)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_COMPENSACION_DEVOLUCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    //comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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
        public bool BuscExisteVacacionesTruncas(string empresa, int sem, int año)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_VACACIONES_TRUNCAS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    //comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
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
        public bool BuscExisteHorasExtras(string emp, string cod, int sem, int año)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_HORAS_EXTRAS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO COMPENSACION Y DEVOLUCION
        public bool BuscExisteCharla(string emp, string sed)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_SST_CHARLA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                    //comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    //comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    //comando.Parameters.AddWithValue("@TipEva", SqlDbType.VarChar).Value = tipoeva;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_planilla.DniCompen = reader.GetString(0);
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
        public bool BuscExisteAccidente(string cod, DateTime fec)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_SST_ACCIDENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fec;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_planilla.DniCompen = reader.GetString(0);
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
        public bool BuscExisteActoCondicion(
            string emp, string sed)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_SST_ACTO_CONDICION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    //comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    //comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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

        public bool BuscExisteInspeccion(
            string emp, string sed)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_SST_INSPECCIONES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    //comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    //comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
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


        // METODO PARA GUARDAR ALTAS Y CESES
        public void GuardarAltasCeses(string cod, string apenom, string dni
            , DateTime fecing_empresa, DateTime fecing_planilla, string est_ant, string est_actual, string motcese
            , DateTime fecha_movimiento, string cod_cc, string razon_social
            , string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ALTAS_CESES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Fecinge_empresa", SqlDbType.DateTime).Value = fecing_empresa;
                    comando.Parameters.AddWithValue("@Fecinge_planilla", SqlDbType.DateTime).Value = fecing_planilla;
                    comando.Parameters.AddWithValue("@EstAnt", SqlDbType.VarChar).Value = est_ant;
                    comando.Parameters.AddWithValue("@EstActual", SqlDbType.VarChar).Value = est_actual;
                    comando.Parameters.AddWithValue("@MotCese", SqlDbType.VarChar).Value = motcese;
                    comando.Parameters.AddWithValue("@Fec_movimiento", SqlDbType.DateTime).Value = fecha_movimiento;
                    comando.Parameters.AddWithValue("@Cod_CC", SqlDbType.Decimal).Value = cod_cc;
                    comando.Parameters.AddWithValue("@Razon_social", SqlDbType.VarChar).Value = razon_social;
                    comando.Parameters.AddWithValue("@Nombre_CC", SqlDbType.VarChar).Value = nombre_cc;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@TipoJornada", SqlDbType.VarChar).Value = tipojornada;
                    comando.Parameters.AddWithValue("@Zona", SqlDbType.VarChar).Value = zona;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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



        // METODO PARA GUARDAR ASISTENCIA DETALLADA
        public void GuardarAsistenciaDetallada(DateTime fecha, string empresa, string dni
            , string ape_nom, string hora_ingreso, string hora_salida
            , string hora_salida_refrigerio, string hora_retorno_refrigerio
            , string observacion, string pto_llegada, string gerencia, string area
            , string sub_area, string cargo, string cod_planilla, string usuario_R, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_PL_ASISTENCIA_DETALLADA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = ape_nom;
                    comando.Parameters.AddWithValue("@Hora_Ingreso", SqlDbType.VarChar).Value = hora_ingreso;
                    comando.Parameters.AddWithValue("@Hora_Salida", SqlDbType.VarChar).Value = hora_salida;
                    comando.Parameters.AddWithValue("@Hr_Sal_Refrigerio", SqlDbType.VarChar).Value = hora_salida_refrigerio;
                    comando.Parameters.AddWithValue("@Hr_Ret_Refrigerio", SqlDbType.VarChar).Value = hora_retorno_refrigerio;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = observacion;
                    comando.Parameters.AddWithValue("@Punto_Llegada", SqlDbType.VarChar).Value = pto_llegada;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@SubArea", SqlDbType.VarChar).Value = sub_area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@CodPlanilla", SqlDbType.VarChar).Value = cod_planilla;
                    comando.Parameters.AddWithValue("@UsuarioReg", SqlDbType.VarChar).Value = usuario_R;

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



        // METODO PARA GUARDAR COMPENSACION DEVOLUCION
        public void GuardarCompensacionDevolucion(string dni, string apenom, string empresa
            , string sede, string gerencia, string area, string cargo, decimal hr_comp, decimal dev_hr
            , decimal saldo, int sem, int año, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_COMPENSACION_DEVOLUCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@Hr_comp", SqlDbType.Decimal).Value = hr_comp;
                    comando.Parameters.AddWithValue("@Dev_hr", SqlDbType.Decimal).Value = dev_hr;
                    comando.Parameters.AddWithValue("@Saldo", SqlDbType.Decimal).Value = saldo;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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




        // METODO PARA GUARDAR COMPENSACION DEVOLUCION
        public void GuardarHorasExtra(
              string dni, string legajo
            , string apenom, string emp, string gerencia, string area
            , string cargo, string zona, string planilla
            , string tipojornada, string fecha, string ceco, string nombceco
            , string codigopep, string codigografo, string codOperacion
            , string turno, string fecingreso, string horaIngreso
            , string fechaSalida, string HoraSalida, string horasNormales
            , string horasNocturnas, string horasExtras, string minutoTarde
            , string HoraRefrigerio, string totales
            , string año, string semana

            , string hoja
            , DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_HORAS_EXTRA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Legajo", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@Zona", SqlDbType.VarChar).Value = zona;
                    comando.Parameters.AddWithValue("@Planilla", SqlDbType.VarChar).Value = planilla;
                    comando.Parameters.AddWithValue("@TipoJornada", SqlDbType.VarChar).Value = tipojornada;

                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecingreso;
                    comando.Parameters.AddWithValue("@Ceco", SqlDbType.VarChar).Value = ceco;
                    comando.Parameters.AddWithValue("@NombreCeco", SqlDbType.VarChar).Value = nombceco;
                    comando.Parameters.AddWithValue("@CodigoPEP", SqlDbType.VarChar).Value = codigopep;
                    comando.Parameters.AddWithValue("@CodigoGrafo", SqlDbType.VarChar).Value = codigografo;
                    comando.Parameters.AddWithValue("@CodigoOperacion", SqlDbType.VarChar).Value = codOperacion;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@FechaIngreso", SqlDbType.VarChar).Value = fecingreso;
                    comando.Parameters.AddWithValue("@HoraIngreso", SqlDbType.VarChar).Value = horaIngreso;
                    comando.Parameters.AddWithValue("@FechaSalida", SqlDbType.VarChar).Value = fechaSalida;
                    comando.Parameters.AddWithValue("@HoraSalida", SqlDbType.VarChar).Value = HoraSalida;
                    comando.Parameters.AddWithValue("@HorasNormales", SqlDbType.VarChar).Value = horasNormales;
                    comando.Parameters.AddWithValue("@HorasNocturnas", SqlDbType.VarChar).Value = horasNocturnas;
                    comando.Parameters.AddWithValue("@HorasExtras", SqlDbType.VarChar).Value = horasExtras;
                    comando.Parameters.AddWithValue("@MinutosTardanza", SqlDbType.VarChar).Value = minutoTarde;
                    comando.Parameters.AddWithValue("@HorasRefrigerio", SqlDbType.VarChar).Value = HoraRefrigerio;
                    comando.Parameters.AddWithValue("@Totales", SqlDbType.VarChar).Value = totales;

                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = semana;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA GUARDAR TAREAJE TRABAJADOR
        public void GuardarActualizarTareajeTrabajador(string emp, string cod, string dni
            , string apenom, string fec_tar, string fecing, string feccese
            , string cod_cc, string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona
            , string est_trab, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_TAREAJE_TRABAJADOR"))//SP_GUARDAR_TAREAJE_TRABAJADOR
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Fectar", SqlDbType.VarChar).Value = fec_tar;
                    comando.Parameters.AddWithValue("@Fecing", SqlDbType.VarChar).Value = fecing;
                    comando.Parameters.AddWithValue("@Feccese", SqlDbType.VarChar).Value = feccese;
                    //comando.Parameters.AddWithValue("@Permanencia", SqlDbType.Decimal).Value = permanencia;
                    comando.Parameters.AddWithValue("@Cod_CC", SqlDbType.VarChar).Value = cod_cc;
                    comando.Parameters.AddWithValue("@Nombre_CC", SqlDbType.VarChar).Value = nombre_cc;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@TipoJornada", SqlDbType.VarChar).Value = tipojornada;
                    comando.Parameters.AddWithValue("@Zona", SqlDbType.VarChar).Value = zona;
                    comando.Parameters.AddWithValue("@Est_trab", SqlDbType.VarChar).Value = est_trab;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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



        // METODO PARA GUARDAR ATENCION MEDICA
        public void GuardarAtenMedica(DateTime fecha, Boolean quincena, string mes, string emp, string sed, string dni
            , string apenom, string area, string jefearea, string patologia
            , string diagnostico, string sintomas, string localidad
            , decimal cant_med, string accion_realizada
            , string parteCuerpo, string labor
            , DateTime hr_ent, DateTime hr_sal
            , DateTime hr_campo, DateTime hr_topico, string nivelAtencion, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ATEN_MEDICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Incidencia", SqlDbType.Bit).Value = quincena;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@JefeArea", SqlDbType.VarChar).Value = jefearea;
                    comando.Parameters.AddWithValue("@Patologia", SqlDbType.VarChar).Value = patologia;
                    comando.Parameters.AddWithValue("@Diagnostico", SqlDbType.VarChar).Value = diagnostico;
                    comando.Parameters.AddWithValue("@Sintomas", SqlDbType.VarChar).Value = sintomas;
                    comando.Parameters.AddWithValue("@Tratamiento", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Cant_med", SqlDbType.Decimal).Value = cant_med;
                    comando.Parameters.AddWithValue("@Accion_realizada", SqlDbType.VarChar).Value = accion_realizada;
                    comando.Parameters.AddWithValue("@ParteCuerpo", SqlDbType.VarChar).Value = parteCuerpo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Hr_ent", SqlDbType.Time).Value = hr_ent;
                    comando.Parameters.AddWithValue("@Hr_sal", SqlDbType.Time).Value = hr_sal;
                    comando.Parameters.AddWithValue("@Hr_campo", SqlDbType.Time).Value = hr_campo;
                    comando.Parameters.AddWithValue("@Hr_topico", SqlDbType.Time).Value = hr_topico;
                    comando.Parameters.AddWithValue("@Nivel_atencion", SqlDbType.VarChar).Value = nivelAtencion;

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




        // METODO PARA GUARDAR CHARLA
        public void GuardarCharla(string cod, string emp, string sed
            , string area, string tipoeva
            , int num_trab, int num_eje, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_SST_CHARLA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoEvaluacion", SqlDbType.VarChar).Value = tipoeva;
                    comando.Parameters.AddWithValue("@NroTrabajador", SqlDbType.Int).Value = num_trab;
                    comando.Parameters.AddWithValue("@NroEjecutado", SqlDbType.Int).Value = num_eje;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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



        // METODO PARA GUARDAR REGLA ORO
        public void GuardarReglaOro(int cod, string emp, string sed
            , string area, string tipo
            , string num_trab, string num_ejec, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_REGLADEORO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoEvaluacion", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@NroTrabajador", SqlDbType.VarChar).Value = num_trab;
                    comando.Parameters.AddWithValue("@NroCompromiso", SqlDbType.VarChar).Value = num_ejec;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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


        // METODO PARA GUARDAR PERCEPCION
        public void GuardarPercepcion(int cod, string emp, string sed
            , string area, string tipo
            , string num_trab, string num_ejec, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_PERCEPCIONDERIESGO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoEvaluacion", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@NroTrabajador", SqlDbType.VarChar).Value = num_trab;
                    comando.Parameters.AddWithValue("@NroCapacitados", SqlDbType.VarChar).Value = num_ejec;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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


        // METODO PARA GUARDAR INSPECCION
        public void GuardarInspeccion(int cod, string emp, string sed
            , string area, string tipo
            , string num_trab, string num_ejec, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_INSPECCIONES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoEvaluacion", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@NroProgramados", SqlDbType.VarChar).Value = num_trab;
                    comando.Parameters.AddWithValue("@NroEjecutados", SqlDbType.VarChar).Value = num_ejec;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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



        // METODO PARA GUARDAR CHARLA
        public void GuardarActoCondicion(string cod, int sem, string emp, string sed
            , string area, string incidencia, string hallazgo, string peligro, string jerarquia
            , string hallazgo_desv, string medida_correc, string respon, DateTime fec_Rep, string est_insp
            , string medida_correc_2, string evidencia, DateTime fec_levant, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_SST_ACTO_CONDICION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Incidencia", SqlDbType.VarChar).Value = incidencia;
                    comando.Parameters.AddWithValue("@Hallazgo", SqlDbType.VarChar).Value = hallazgo;
                    comando.Parameters.AddWithValue("@Peligro", SqlDbType.VarChar).Value = peligro;
                    comando.Parameters.AddWithValue("@Jerarquia", SqlDbType.VarChar).Value = jerarquia;
                    comando.Parameters.AddWithValue("@Hallazgo_desv", SqlDbType.VarChar).Value = hallazgo_desv;
                    comando.Parameters.AddWithValue("@Medida_Correctiva", SqlDbType.VarChar).Value = medida_correc;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = respon;
                    comando.Parameters.AddWithValue("@FechaRep", SqlDbType.DateTime).Value = fec_Rep;
                    comando.Parameters.AddWithValue("@Estado_Insp", SqlDbType.VarChar).Value = est_insp;
                    comando.Parameters.AddWithValue("@Medida_Correctiva_2", SqlDbType.VarChar).Value = medida_correc_2;
                    comando.Parameters.AddWithValue("@Evidencia", SqlDbType.VarChar).Value = evidencia;
                    comando.Parameters.AddWithValue("@FechaLev", SqlDbType.DateTime).Value = fec_levant;

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



        // METODO PARA GUARDAR EFICIENCIA
        public void GuardarEficiencia(string id, int sem, string posicion, string area, string nivel
            , string estadoproceso, string año, string fechareq, string tiporeq
            , string sede, string timeproceso, string tipopersonal
            , string fechaterna, string fecharpta, int dias
            , string resptarea, string fecingreso, int duraciondias
            , int vencimiento, string tipoefectivo, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_EFICIENCIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Posicion", SqlDbType.VarChar).Value = posicion;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Nivel", SqlDbType.VarChar).Value = nivel;
                    comando.Parameters.AddWithValue("@EstadoProceso", SqlDbType.VarChar).Value = estadoproceso;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@FechaReq", SqlDbType.VarChar).Value = fechareq;
                    comando.Parameters.AddWithValue("@TipoReq", SqlDbType.VarChar).Value = tiporeq;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@TiempoProceso", SqlDbType.VarChar).Value = timeproceso;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;

                    comando.Parameters.AddWithValue("@FechaTerna", SqlDbType.VarChar).Value = fechaterna;
                    comando.Parameters.AddWithValue("@FechaRpta", SqlDbType.VarChar).Value = fecharpta;
                    comando.Parameters.AddWithValue("@Dias", SqlDbType.Int).Value = dias;

                    comando.Parameters.AddWithValue("@FechaResp", SqlDbType.VarChar).Value = resptarea;
                    comando.Parameters.AddWithValue("@FechaIng", SqlDbType.VarChar).Value = fecingreso;
                    comando.Parameters.AddWithValue("@DiasDuracion", SqlDbType.Int).Value = duraciondias;
                    comando.Parameters.AddWithValue("@Vencimiento", SqlDbType.Int).Value = vencimiento;
                    comando.Parameters.AddWithValue("@TipoEfectivo", SqlDbType.VarChar).Value = tipoefectivo;
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




        // METODO PARA GUARDAR EFICIENCIA
        public void GuardarCobertura(DateTime fecha, string turno, string jefatura
            , string fundo, string cultivo, string area, string recurso, string tiporecurso
            , string labor, string cant_prog, string obs, string totalprog, string area_extech
            , string area_, int año, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_COBERTURA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Jefatura", SqlDbType.VarChar).Value = jefatura;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Recurso", SqlDbType.VarChar).Value = recurso;
                    comando.Parameters.AddWithValue("@TipoRecurso", SqlDbType.VarChar).Value = tiporecurso;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@CantProg", SqlDbType.VarChar).Value = cant_prog;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@TotalProg", SqlDbType.VarChar).Value = totalprog;
                    comando.Parameters.AddWithValue("@AreaExtech", SqlDbType.VarChar).Value = area_extech;
                    comando.Parameters.AddWithValue("@Area_", SqlDbType.VarChar).Value = area_;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
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




        // METODO PARA GUARDAR EFICIENCIA
        public void GuardarRevisionGrupo(string emp, string sede
            , string codgrupo, int numpersona, string grupolabor, string labor
            , string fundo, string cabezal
            , string supervisor, string cultivo, DateTime fecgrupo
            , string meta, string preciounit, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_REVISION_GRUPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@SedeLabor", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@GrupoTrabajo", SqlDbType.VarChar).Value = codgrupo;
                    comando.Parameters.AddWithValue("@NumPersonas", SqlDbType.Int).Value = numpersona;
                    comando.Parameters.AddWithValue("@AgrupaLabor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Supervisor", SqlDbType.VarChar).Value = supervisor;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@FechaGrupo", SqlDbType.Date).Value = fecgrupo;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.VarChar).Value = meta;
                    comando.Parameters.AddWithValue("@PrecioUnit", SqlDbType.VarChar).Value = preciounit;
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



        // METODO PARA GUARDAR LABOR
        public void GuardarLabor(string cod, string codactividad, string actividad
            , string codtiplabor, string tipoactividad, string codgrupolabor
            , string grupolabor, string unidadmedida, decimal meta, string codavance
            , decimal preciounit
            , string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_LABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@cod_labor", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@cod_actividad", SqlDbType.VarChar).Value = codactividad;
                    comando.Parameters.AddWithValue("@actividad", SqlDbType.VarChar).Value = actividad;
                    comando.Parameters.AddWithValue("@cod_tipo_labor", SqlDbType.Int).Value = codtiplabor;
                    comando.Parameters.AddWithValue("@tipo_actividad", SqlDbType.VarChar).Value = tipoactividad;
                    comando.Parameters.AddWithValue("@cod_grupo_labor", SqlDbType.VarChar).Value = codgrupolabor;
                    comando.Parameters.AddWithValue("@grupo_labor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@unidad_medida", SqlDbType.VarChar).Value = unidadmedida;
                    comando.Parameters.AddWithValue("@meta", SqlDbType.Decimal).Value = meta;
                    comando.Parameters.AddWithValue("@cod_avance", SqlDbType.VarChar).Value = codavance;
                    comando.Parameters.AddWithValue("@precio_unit_adicional", SqlDbType.Decimal).Value = preciounit;
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



        // METODO PARA GUARDAR GRUPO LABOR
        public void GuardarGrupoLabor(string codgrupolabor
            , string grupolabor, string empresa
            , string etapa
            , string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_GRUPOLABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@cod_grupo_labor", SqlDbType.VarChar).Value = codgrupolabor;
                    comando.Parameters.AddWithValue("@grupo_labor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@etapa", SqlDbType.VarChar).Value = etapa;
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





        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void ActualizarAtenMedica(DateTime fecha, Boolean quincena, string mes, string emp, string sed, string dni
            , string apenom, string area, string jefearea, string patologia
            , string diagnostico, string sintomas, string localidad
            , decimal cant_med, string accion_realizada
            , string parteCuerpo, string labor
            , DateTime hr_ent, DateTime hr_sal
            , DateTime hr_campo, DateTime hr_topico, string nivelAtencion
            , string hoja, string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_ATEN_MEDICA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Incidencia", SqlDbType.Bit).Value = quincena;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@JefeArea", SqlDbType.VarChar).Value = jefearea;
                    comando.Parameters.AddWithValue("@Patologia", SqlDbType.VarChar).Value = patologia;
                    comando.Parameters.AddWithValue("@Diagnostico", SqlDbType.VarChar).Value = diagnostico;
                    comando.Parameters.AddWithValue("@Sintomas", SqlDbType.VarChar).Value = sintomas;
                    comando.Parameters.AddWithValue("@Tratamiento", SqlDbType.VarChar).Value = localidad;
                    comando.Parameters.AddWithValue("@Cant_med", SqlDbType.Decimal).Value = cant_med;
                    comando.Parameters.AddWithValue("@Accion_realizada", SqlDbType.VarChar).Value = accion_realizada;
                    comando.Parameters.AddWithValue("@ParteCuerpo", SqlDbType.VarChar).Value = parteCuerpo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Hr_ent", SqlDbType.Time).Value = hr_ent;
                    comando.Parameters.AddWithValue("@Hr_sal", SqlDbType.Time).Value = hr_sal;
                    comando.Parameters.AddWithValue("@Hr_campo", SqlDbType.Time).Value = hr_campo;
                    comando.Parameters.AddWithValue("@Hr_topico", SqlDbType.Time).Value = hr_topico;
                    comando.Parameters.AddWithValue("@Nivel_atencion", SqlDbType.VarChar).Value = nivelAtencion;

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



        // METODO 
        public void ActualizarCharla(string cod, string emp, string sed
            , string area, string tipoeva
            , int num_trab, int num_eje, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_SST_CHARLA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoEvaluacion", SqlDbType.VarChar).Value = tipoeva;
                    comando.Parameters.AddWithValue("@NroTrabajador", SqlDbType.Int).Value = num_trab;
                    comando.Parameters.AddWithValue("@NroEjecutado", SqlDbType.Int).Value = num_eje;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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


        // METODO 
        public void ActualizarAccidente(string cod, string emp, string sed
            , string area, string tipoacci
            , int cantidad, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_SST_ACIDENTE_INCIDENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@TipoAccidente", SqlDbType.VarChar).Value = tipoacci;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = cantidad;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
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


        // METODO 
        public void ActualizarActoCondicion(string cod, int sem, string emp, string sed
            , string area, string incidencia, string hallazgo, string peligro, string jerarquia
            , string hallazgo_desv, string medida_correc, string respon, DateTime fec_Rep, string est_insp
            , string medida_correc_2, string evidencia, DateTime fec_levant, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_SST_ACTO_CONDICION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Incidencia", SqlDbType.VarChar).Value = incidencia;
                    comando.Parameters.AddWithValue("@Hallazgo", SqlDbType.VarChar).Value = hallazgo;
                    comando.Parameters.AddWithValue("@Peligro", SqlDbType.VarChar).Value = peligro;
                    comando.Parameters.AddWithValue("@Jerarquia", SqlDbType.VarChar).Value = jerarquia;
                    comando.Parameters.AddWithValue("@Hallazgo_desv", SqlDbType.VarChar).Value = hallazgo_desv;
                    comando.Parameters.AddWithValue("@Medida_Correctiva", SqlDbType.VarChar).Value = medida_correc;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = respon;
                    comando.Parameters.AddWithValue("@FechaRep", SqlDbType.DateTime).Value = fec_Rep;
                    comando.Parameters.AddWithValue("@Estado_Insp", SqlDbType.VarChar).Value = est_insp;
                    comando.Parameters.AddWithValue("@Medida_Correctiva_2", SqlDbType.VarChar).Value = medida_correc_2;
                    comando.Parameters.AddWithValue("@Evidencia", SqlDbType.VarChar).Value = evidencia;
                    comando.Parameters.AddWithValue("@FechaLev", SqlDbType.DateTime).Value = fec_levant;

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


        // METODO PARA GUARDAR EFICIENCIA
        public void ActualizarEficiencia(string id, int sem, string posicion, string area, string nivel
            , string estadoproceso, string año, string fechareq, string tiporeq
            , string sede, string timeproceso, string tipopersonal
            , string fechaterna, string fecharpta, int dias
            , string resptarea, string fecingreso, int duraciondias
            , int vencimiento, string tipoefectivo, string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_EFICIENCIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Posicion", SqlDbType.VarChar).Value = posicion;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Nivel", SqlDbType.VarChar).Value = nivel;
                    comando.Parameters.AddWithValue("@EstadoProceso", SqlDbType.VarChar).Value = estadoproceso;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@FechaReq", SqlDbType.VarChar).Value = fechareq;
                    comando.Parameters.AddWithValue("@TipoReq", SqlDbType.VarChar).Value = tiporeq;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@TiempoProceso", SqlDbType.VarChar).Value = timeproceso;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = tipopersonal;

                    comando.Parameters.AddWithValue("@FechaTerna", SqlDbType.VarChar).Value = fechaterna;
                    comando.Parameters.AddWithValue("@FechaRpta", SqlDbType.VarChar).Value = fecharpta;
                    comando.Parameters.AddWithValue("@Dias", SqlDbType.Int).Value = dias;

                    comando.Parameters.AddWithValue("@FechaResp", SqlDbType.VarChar).Value = resptarea;
                    comando.Parameters.AddWithValue("@FechaIng", SqlDbType.VarChar).Value = fecingreso;
                    comando.Parameters.AddWithValue("@DiasDuracion", SqlDbType.Int).Value = duraciondias;
                    comando.Parameters.AddWithValue("@Vencimiento", SqlDbType.Int).Value = vencimiento;
                    comando.Parameters.AddWithValue("@TipoEfectivo", SqlDbType.VarChar).Value = tipoefectivo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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



        // METODO PARA ACTUALIZAR COBERTURA
        public void ActualizarCobertura(DateTime fecha, string turno, string jefatura
            , string fundo, string cultivo, string area, string recurso, string tiporecurso
            , string labor, string cant_prog, string obs, string totalprog, string area_extech
            , string area_, string semana, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_COBERTURA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Jefatura", SqlDbType.VarChar).Value = jefatura;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Recurso", SqlDbType.VarChar).Value = recurso;
                    comando.Parameters.AddWithValue("@TipoRecurso", SqlDbType.VarChar).Value = tiporecurso;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@CantProg", SqlDbType.VarChar).Value = cant_prog;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@TotalProg", SqlDbType.VarChar).Value = totalprog;
                    comando.Parameters.AddWithValue("@AreaExtech", SqlDbType.VarChar).Value = area_extech;
                    comando.Parameters.AddWithValue("@Area_", SqlDbType.VarChar).Value = area_;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = semana;

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


        // METODO PARA ACTUALIZAR EFICIENCIA
        public void ActualizarRevisionGrupo(string emp, string sede
            , string codgrupo, int numpersona, string grupolabor, string labor
            , string fundo, string cabezal
            , string supervisor, string cultivo, DateTime fecgrupo
            , string meta, string preciounit, string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_REVISION_GRUPO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@SedeLabor", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@GrupoTrabajo", SqlDbType.VarChar).Value = codgrupo;
                    comando.Parameters.AddWithValue("@NumPersonas", SqlDbType.Int).Value = numpersona;
                    comando.Parameters.AddWithValue("@AgrupaLabor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Supervisor", SqlDbType.VarChar).Value = supervisor;
                    comando.Parameters.AddWithValue("@Cultivo", SqlDbType.VarChar).Value = cultivo;
                    comando.Parameters.AddWithValue("@FechaGrupo", SqlDbType.Date).Value = fecgrupo;
                    comando.Parameters.AddWithValue("@Meta", SqlDbType.VarChar).Value = meta;
                    comando.Parameters.AddWithValue("@PrecioUnit", SqlDbType.VarChar).Value = preciounit;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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



        // METODO PARA ACTUALIZAR LABOR
        public void ActualizarLabor(string cod, string codactividad, string actividad
            , string codtiplabor, string tipoactividad, string codgrupolabor
            , string grupolabor, string unidadmedida, decimal meta, string codavance
            , decimal preciounit
            , string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_LABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@cod_labor", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@cod_actividad", SqlDbType.VarChar).Value = codactividad;
                    comando.Parameters.AddWithValue("@actividad", SqlDbType.VarChar).Value = actividad;
                    comando.Parameters.AddWithValue("@cod_tipo_labor", SqlDbType.Int).Value = codtiplabor;
                    comando.Parameters.AddWithValue("@tipo_actividad", SqlDbType.VarChar).Value = tipoactividad;
                    comando.Parameters.AddWithValue("@cod_grupo_labor", SqlDbType.VarChar).Value = codgrupolabor;
                    comando.Parameters.AddWithValue("@grupo_labor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@unidad_medida", SqlDbType.VarChar).Value = unidadmedida;
                    comando.Parameters.AddWithValue("@meta", SqlDbType.Decimal).Value = meta;
                    comando.Parameters.AddWithValue("@cod_avance", SqlDbType.VarChar).Value = codavance;
                    comando.Parameters.AddWithValue("@precio_unit_adicional", SqlDbType.Decimal).Value = preciounit;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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



        // METODO PARA GUARDAR Y ACTUALIZAR PRODUCTIVIDAD
        public void GuardarActualizarProductividad(string empresa, string sede,
            string fecha, string dni, string nombres
            , string cabezal, string variedad, string presentacion
            , string grupolabor, string labor, decimal avance, decimal meta
            , string tipoprod, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_PRODUCTIVIDAD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@cabezal", SqlDbType.Int).Value = cabezal;
                    comando.Parameters.AddWithValue("@variedad", SqlDbType.VarChar).Value = variedad;
                    comando.Parameters.AddWithValue("@presentacion", SqlDbType.VarChar).Value = presentacion;
                    comando.Parameters.AddWithValue("@grupo_labor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@avance", SqlDbType.Decimal).Value = avance;
                    comando.Parameters.AddWithValue("@meta", SqlDbType.Decimal).Value = meta;
                    comando.Parameters.AddWithValue("@TipoProd", SqlDbType.VarChar).Value = tipoprod;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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




        //
        //
        // CARGAS MASIVAS DE COMUNICACION (SqlBulkCopy)
        //
        //
        // COM_ParticipacionEncuesta: el borrado por tipo de personal y año va
        // antes, desde el formulario; aca solo se insertan las filas nuevas.
        public void GuardarParticipacionEncuestaMasivo(DataTable datos)
        {
            CargaMasivaDirecta(datos, "COM_ParticipacionEncuesta");
        }


        // COM_MovimientoCanje: idem, el borrado por año va antes.
        public void GuardarMovimientoCanjeMasivo(DataTable datos)
        {
            CargaMasivaDirecta(datos, "COM_MovimientoCanje");
        }


        // COM_MovimientoCanjePlanilla: alta o actualizacion por dni + Fecha_entrega.
        public void GuardarActualizarSaldoPlanillaMasivo(DataTable datos)
        {
            CargaMasiva(datos, "#MovCanjePlanilla", @"CREATE TABLE #MovCanjePlanilla(
                        empresa              varchar(180),
                        dni                  varchar(20),
                        nombre_completo      varchar(180),
                        puntos               float,
                        codigo_producto      varchar(180),
                        descripcion_producto varchar(180),
                        monto_planilla       float,
                        IGV                  float,
                        Total                float,
                        estado_canje         varchar(180),
                        Fecha_entrega        date,
                        Hoja                 varchar(150),
                        FecCre               datetime,
                        UseReg               int,
                        Hostname             varchar(50),
                        FecEdit              datetime,
                        UseEdit              int,
                        UseElim              int)", "SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla_MASIVO");
        }


        // COM_Saldo: alta o actualizacion por dni + sede + fecha.
        public void GuardarActualizarSaldoMasivo(DataTable datos)
        {
            CargaMasiva(datos, "#Saldo", @"CREATE TABLE #Saldo(
                        fecha            date,
                        empresa          varchar(180),
                        Sede             varchar(180),
                        nombres          varchar(180),
                        dni              varchar(15),
                        correo           varchar(180),
                        telefono         varchar(20),
                        saldo            decimal(18,4),
                        activo           varchar(180),
                        estado_plantilla varchar(180),
                        acceso           varchar(180),
                        Semana           int,
                        Año              int,
                        Obs              varchar(500),
                        Hoja             varchar(50),
                        Estado           varchar(10),
                        FecCre           datetime,
                        UseReg           int,
                        Hostname         varchar(50),
                        FecEdit          datetime,
                        UseEdit          int,
                        UseElim          int)", "SP_GUARDAR_ACTUALIZAR_SALDO_MASIVO");
        }


        // METODO PARA GUARDAR Y ACTUALIZAR SALDO
        public void GuardarActualizarSaldo(DateTime fecha,
            string emp, string sed, string nombres, string dni, string correo
            , string telefono, decimal saldo, string activo
            , string est_pla, string acceso, int semana, int año
            , string obs, string hoja
            , string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SALDO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@nombres", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = correo;
                    comando.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
                    comando.Parameters.AddWithValue("@saldo", SqlDbType.Decimal).Value = saldo;
                    comando.Parameters.AddWithValue("@activo", SqlDbType.VarChar).Value = activo;
                    comando.Parameters.AddWithValue("@estado_plantilla", SqlDbType.VarChar).Value = est_pla;
                    comando.Parameters.AddWithValue("@acceso", SqlDbType.VarChar).Value = acceso;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.Int).Value = semana;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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


        // METODO PARA GUARDAR Y ACTUALIZAR SALDO PLANILLA
        public void GuardarActualizarSaldoPlanilla(
            string emp, string dni, string nombres
            , string puntos, string codprod
            , string desprod, string monto, string igv
            , string total, string estadocanje, string fecha
            , string hoja, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@nombre_completo", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@puntos", SqlDbType.VarChar).Value = puntos;
                    comando.Parameters.AddWithValue("@codigo_producto", SqlDbType.VarChar).Value = codprod;
                    comando.Parameters.AddWithValue("@descripcion_producto", SqlDbType.VarChar).Value = desprod;
                    comando.Parameters.AddWithValue("@monto_planilla", SqlDbType.VarChar).Value = monto;
                    comando.Parameters.AddWithValue("@IGV", SqlDbType.VarChar).Value = igv;
                    comando.Parameters.AddWithValue("@Total", SqlDbType.VarChar).Value = total;
                    comando.Parameters.AddWithValue("@estado_canje", SqlDbType.VarChar).Value = estadocanje;
                    comando.Parameters.AddWithValue("@Fecha_entrega", SqlDbType.VarChar).Value = fecha;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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



        // METODO PARA GUARDAR Y ACTUALIZAR MOVIMIENTO CAJE
        public void GuardarActualizarMovimientoCanje(
            string emp, string dni
            , string nombres, string sede, string tipomov, string tipolog
            , string tipo_bono, string labor, string cantidad
            , string puntos, string preciosigv, string codnisira, string codigo
            , string codpro, string despro, string est_canje, string fechamov
            , string fechaest, string fechaent, string estado, string correo, string direccion
            , string telefono, string u_registra, string u_edita, string u_entrega
            , string hoja, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_MOVIMIENTO_CANJE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@nombre_completo", SqlDbType.VarChar).Value = nombres;
                    comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@tipo_movimiento", SqlDbType.VarChar).Value = tipomov;
                    comando.Parameters.AddWithValue("@tipo_logico", SqlDbType.VarChar).Value = tipolog;
                    comando.Parameters.AddWithValue("@tipo_bono", SqlDbType.VarChar).Value = tipo_bono;
                    comando.Parameters.AddWithValue("@labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@cantidad", SqlDbType.VarChar).Value = cantidad;
                    comando.Parameters.AddWithValue("@puntos", SqlDbType.VarChar).Value = puntos;
                    comando.Parameters.AddWithValue("@precioigv", SqlDbType.VarChar).Value = preciosigv;

                    comando.Parameters.AddWithValue("@codigonisira", SqlDbType.VarChar).Value = codnisira;
                    comando.Parameters.AddWithValue("@codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@codigo_producto", SqlDbType.VarChar).Value = codpro;
                    comando.Parameters.AddWithValue("@descripcion_producto", SqlDbType.VarChar).Value = despro;
                    comando.Parameters.AddWithValue("@estado_canje", SqlDbType.VarChar).Value = est_canje;
                    comando.Parameters.AddWithValue("@fecha_movimiento", SqlDbType.Date).Value = fechamov;
                    comando.Parameters.AddWithValue("@fecha_estimada", SqlDbType.Date).Value = fechaest;
                    comando.Parameters.AddWithValue("@fecha_entrega", SqlDbType.Date).Value = fechaent;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;

                    comando.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = correo;
                    comando.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = direccion;
                    comando.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;

                    comando.Parameters.AddWithValue("@usuario_registro", SqlDbType.VarChar).Value = u_registra;
                    comando.Parameters.AddWithValue("@usuario_edicion", SqlDbType.VarChar).Value = u_edita;
                    comando.Parameters.AddWithValue("@usuario_entrega", SqlDbType.VarChar).Value = u_entrega;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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



        // METODO PARA GUARDAR Y ACTUALIZAR MOVIMIENTO CAJE
        public void GuardarActualizarParticipacionEncuesta(DateTime fecha,
             string emp, string sed, string tiptrab, string sexo
            , string gerencia, string area
            , string cantidad, string obs
            , string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_PARTICIPACION_ENCUESTA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@tipo_trabajador", SqlDbType.VarChar).Value = tiptrab;
                    comando.Parameters.AddWithValue("@sexo", SqlDbType.VarChar).Value = sexo;
                    comando.Parameters.AddWithValue("@gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@cantidad", SqlDbType.VarChar).Value = cantidad;

                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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

        // METODO PARA ACTUALIZAR GRUPO LABOR
        public void ActualizarGrupoLabor(string codgrupolabor
            , string grupolabor, string empresa
            , string etapa
            , string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_GRUPOLABOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@cod_grupo_labor", SqlDbType.VarChar).Value = codgrupolabor;
                    comando.Parameters.AddWithValue("@grupo_labor", SqlDbType.VarChar).Value = grupolabor;
                    comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@etapa", SqlDbType.VarChar).Value = etapa;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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

        // METODO PARA ACTUALIZAR ALTAS Y CESES
        public void ActualizarAltasCeses(string cod, string apenom, string dni
            , DateTime fecing_empresa, DateTime fecing_planilla, string est_ant, string est_actual, string motcese
            , DateTime fecha_movimiento, string cod_cc, string razon_social
            , string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona, string hoja
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_ALTAS_CESES"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Fecinge_empresa", SqlDbType.DateTime).Value = fecing_empresa;
                    comando.Parameters.AddWithValue("@Fecinge_planilla", SqlDbType.DateTime).Value = fecing_planilla;
                    comando.Parameters.AddWithValue("@EstAnt", SqlDbType.VarChar).Value = est_ant;
                    comando.Parameters.AddWithValue("@EstActual", SqlDbType.VarChar).Value = est_actual;
                    comando.Parameters.AddWithValue("@MotCese", SqlDbType.VarChar).Value = motcese;
                    comando.Parameters.AddWithValue("@Fec_movimiento", SqlDbType.DateTime).Value = fecha_movimiento;
                    comando.Parameters.AddWithValue("@Cod_CC", SqlDbType.Decimal).Value = cod_cc;
                    comando.Parameters.AddWithValue("@Razon_social", SqlDbType.VarChar).Value = razon_social;
                    comando.Parameters.AddWithValue("@Nombre_CC", SqlDbType.VarChar).Value = nombre_cc;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@TipoJornada", SqlDbType.VarChar).Value = tipojornada;
                    comando.Parameters.AddWithValue("@Zona", SqlDbType.VarChar).Value = zona;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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



        // METODO PARA ACTUALIZAR ALTAS Y CESES
        public void ActualizarAsistenciaDetallada(DateTime fecha, string empresa, string dni
            , string ape_nom, string hora_ingreso, string hora_salida
            , string hora_salida_refrigerio, string hora_retorno_refrigerio
            , string observacion, string pto_llegada, string gerencia, string area
            , string sub_area, string cargo, string cod_planilla, string usuario_R, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_PL_ASISTENCIA_DETALLADA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Ape_Nom", SqlDbType.VarChar).Value = ape_nom;
                    comando.Parameters.AddWithValue("@Hora_Ingreso", SqlDbType.VarChar).Value = hora_ingreso;
                    comando.Parameters.AddWithValue("@Hora_Salida", SqlDbType.VarChar).Value = hora_salida;
                    comando.Parameters.AddWithValue("@Hr_Sal_Refrigerio", SqlDbType.VarChar).Value = hora_salida_refrigerio;
                    comando.Parameters.AddWithValue("@Hr_Ret_Refrigerio", SqlDbType.VarChar).Value = hora_retorno_refrigerio;
                    comando.Parameters.AddWithValue("@Observacion", SqlDbType.VarChar).Value = observacion;
                    comando.Parameters.AddWithValue("@Punto_Llegada", SqlDbType.VarChar).Value = pto_llegada;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@SubArea", SqlDbType.VarChar).Value = sub_area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@CodPlanilla", SqlDbType.VarChar).Value = cod_planilla;
                    comando.Parameters.AddWithValue("@UsuarioReg", SqlDbType.VarChar).Value = usuario_R;

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



        // METODO PARA ACTUALIZAR COMPENSACION DEVOLUCION
        public void ActualizarCompensacionDevolucion(string dni, string apenom, string empresa
            , string sede, string gerencia, string area, string cargo, decimal hr_comp, decimal dev_hr
            , decimal saldo, int sem, int año, string hoja, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_COMPENSACION_DEVOLUCION"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@Hr_comp", SqlDbType.Decimal).Value = hr_comp;
                    comando.Parameters.AddWithValue("@Dev_hr", SqlDbType.Decimal).Value = dev_hr;
                    comando.Parameters.AddWithValue("@Saldo", SqlDbType.Decimal).Value = saldo;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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




        // METODO PARA ACTUALIZAR COMPENSACION DEVOLUCION
        public void ActualizarHorasExtras(string emp, DateTime fecha, string cod, string dni
            , string apenom, string gerencia, string area
            , string cargo, string zona, string planilla
            , string tipojornada, string fecingreso
            , string feccese, string codigocc, string nombrecc
            , int sem, int año

            , string Nocturnos, string Diurnos, string Descansos, string Feriados
            , string DM, string Licencia_Goce, string Subsidios, string Total_Dia_Efec
            , string Faltas, string Suspensiones, string Permisos, string Vacaciones
            , string Total_Dias_No_Lab

            , string diu25, string noc25, string diu35
            , string noc35, string total, string ftd, string ftn
            , string diasafam, string diasbeta, string dessemal, string dessemanlnoct

            , string Total_Otros, string H_Efec_Laboradas, string Total_H_Efec
            , string Horas_Feriado_Sem, string Total_Frd_Sem

            , string hoja, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_HORAS_EXTRA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@Zona", SqlDbType.VarChar).Value = zona;
                    comando.Parameters.AddWithValue("@Planilla", SqlDbType.VarChar).Value = planilla;
                    comando.Parameters.AddWithValue("@TipoJornada", SqlDbType.VarChar).Value = tipojornada;
                    comando.Parameters.AddWithValue("@FecIngreso", SqlDbType.VarChar).Value = fecingreso;
                    comando.Parameters.AddWithValue("@FecCese", SqlDbType.VarChar).Value = feccese;
                    comando.Parameters.AddWithValue("@CodigoCC", SqlDbType.VarChar).Value = codigocc;
                    comando.Parameters.AddWithValue("@NombreCC", SqlDbType.VarChar).Value = nombrecc;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.Int).Value = sem;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;
                    comando.Parameters.AddWithValue("@Nocturnos", SqlDbType.VarChar).Value = Nocturnos;
                    comando.Parameters.AddWithValue("@Diurnos", SqlDbType.VarChar).Value = Diurnos;
                    comando.Parameters.AddWithValue("@Descansos", SqlDbType.VarChar).Value = Descansos;
                    comando.Parameters.AddWithValue("@Feriados", SqlDbType.VarChar).Value = Feriados;
                    comando.Parameters.AddWithValue("@DM", SqlDbType.VarChar).Value = DM;
                    comando.Parameters.AddWithValue("@Licencia_Goce", SqlDbType.VarChar).Value = Licencia_Goce;
                    comando.Parameters.AddWithValue("@Subsidios", SqlDbType.VarChar).Value = Subsidios;
                    comando.Parameters.AddWithValue("@Total_Dia_Efec", SqlDbType.VarChar).Value = Total_Dia_Efec;
                    comando.Parameters.AddWithValue("@Faltas", SqlDbType.VarChar).Value = Faltas;
                    comando.Parameters.AddWithValue("@Suspensiones", SqlDbType.VarChar).Value = Suspensiones;
                    comando.Parameters.AddWithValue("@Permisos", SqlDbType.VarChar).Value = Permisos;
                    comando.Parameters.AddWithValue("@Vacaciones", SqlDbType.VarChar).Value = Vacaciones;
                    comando.Parameters.AddWithValue("@Total_Dias_No_Lab", SqlDbType.VarChar).Value = Total_Dias_No_Lab;

                    comando.Parameters.AddWithValue("@HE_Diu_25_", SqlDbType.VarChar).Value = diu25;
                    comando.Parameters.AddWithValue("@HE_Noc_25_", SqlDbType.VarChar).Value = noc25;
                    comando.Parameters.AddWithValue("@HE_Diu_35_", SqlDbType.VarChar).Value = diu35;
                    comando.Parameters.AddWithValue("@HE_Noc_35_", SqlDbType.VarChar).Value = noc35;
                    comando.Parameters.AddWithValue("@Total", SqlDbType.VarChar).Value = total;
                    comando.Parameters.AddWithValue("@FT_D", SqlDbType.VarChar).Value = ftd;
                    comando.Parameters.AddWithValue("@FT_N", SqlDbType.VarChar).Value = ftn;
                    comando.Parameters.AddWithValue("@DiasBeta", SqlDbType.VarChar).Value = diasbeta;
                    comando.Parameters.AddWithValue("@DiasAfam", SqlDbType.VarChar).Value = diasafam;
                    comando.Parameters.AddWithValue("@DesSemanal", SqlDbType.VarChar).Value = dessemal;
                    comando.Parameters.AddWithValue("@DesSemanalNoct", SqlDbType.VarChar).Value = dessemanlnoct;
                    comando.Parameters.AddWithValue("@Total_Otros", SqlDbType.VarChar).Value = Total_Otros;
                    comando.Parameters.AddWithValue("@H_Efec_Laboradas", SqlDbType.VarChar).Value = H_Efec_Laboradas;
                    comando.Parameters.AddWithValue("@Total_H_Efec", SqlDbType.VarChar).Value = Total_H_Efec;
                    comando.Parameters.AddWithValue("@Horas_Feriado_Sem", SqlDbType.VarChar).Value = Horas_Feriado_Sem;
                    comando.Parameters.AddWithValue("@Total_Frd_Sem", SqlDbType.VarChar).Value = Total_Frd_Sem;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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

        // METODO PARA ACTUALIZAR TAREAJE TRABAJADOR
        public void ActualizarTareajeTrabajador(string emp, string cod, string dni
            , string apenom, DateTime fec_tar, DateTime fecing, string feccese
            , string cod_cc, string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona
            , string est_trab, string hoja, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_TAREAJE_TRABAJADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = dni;
                    comando.Parameters.AddWithValue("@Apenom", SqlDbType.VarChar).Value = apenom;
                    comando.Parameters.AddWithValue("@Fectar", SqlDbType.DateTime).Value = fec_tar;
                    comando.Parameters.AddWithValue("@Fecing", SqlDbType.DateTime).Value = fecing;
                    comando.Parameters.AddWithValue("@Feccese", SqlDbType.VarChar).Value = feccese;
                    //comando.Parameters.AddWithValue("@Permanencia", SqlDbType.Decimal).Value = permanencia;
                    comando.Parameters.AddWithValue("@Cod_CC", SqlDbType.VarChar).Value = cod_cc;
                    comando.Parameters.AddWithValue("@Nombre_CC", SqlDbType.VarChar).Value = nombre_cc;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = cargo;
                    comando.Parameters.AddWithValue("@TipoJornada", SqlDbType.VarChar).Value = tipojornada;
                    comando.Parameters.AddWithValue("@Zona", SqlDbType.VarChar).Value = zona;
                    comando.Parameters.AddWithValue("@Est_trab", SqlDbType.VarChar).Value = est_trab;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
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


        // METODO PARA ELIMINAR TAREAJE
        public void EliminarTareajeTrabajador(
            string emp, string fecha)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TAREAJE_TRABAJADOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR TAREAJE
        public void EliminarHorasExtra(
            string emp, string año, string semana)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_HORAS_EXTRA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = semana;
                    comando.ExecuteNonQuery();

                }
            }

        }


        public void GuardarCompensacionBulk(DataTable dt)
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
                    bulkCopy.DestinationTableName = "PL_Compensaciones"; // Cambia el nombre a la tabla que estás usando

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

        public void GuardarHoraExtraBulk(DataTable dt)
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
                    bulkCopy.DestinationTableName = "PL_HorasExtra"; // Cambia el nombre a la tabla que estás usando

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

        public void GuardarVacacionesTruncasBulk(DataTable dt)
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
                    bulkCopy.DestinationTableName = "PL_VacacionesTruncas"; // Cambia el nombre a la tabla que estás usando

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

        public void GuardarLecturaStickerBulk(DataTable dt)
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
                    bulkCopy.DestinationTableName = "DEST_PedateoSticker"; // Cambia el nombre a la tabla que estás usando

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

        public (List<int> CodGruposDuplicados, string Mensaje, string SessionId
            , string CadOriginal)
    GuardarLecturaStickerBulkTVP(DataTable dt)
        {
            List<int> duplicados = new List<int>();
            string mensaje = "";
            string sessionId = "";
            string cadOriginal = "";

            SqlConnection connection = leerconexion();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GuardarPedateoStickerBulk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.Parameters.AddWithValue("@Datos", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.TP_DEST_PedateoSticker";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 🔹 Leer CodGrupoStick
                            int? codGrupo = reader["CodGrupoStick"] != DBNull.Value
                                ? Convert.ToInt32(reader["CodGrupoStick"])
                                : (int?)null;

                            if (codGrupo != null)
                                duplicados.Add(codGrupo.Value);

                            // 🔹 Leer SessionId (SIEMPRE viene de tu SP)
                            sessionId = reader["SessionId"] != DBNull.Value
                                ? reader["SessionId"].ToString()
                                : "";
                            // 🔹 Leer CadOriginal (SIEMPRE viene de tu SP)
                            cadOriginal = reader["CadOriginal"] != DBNull.Value
                                ? reader["CadOriginal"].ToString()
                                : "";
                            // 🔹 Leer mensaje
                            mensaje = reader["Mensaje"].ToString();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al ejecutar", sqlEx);
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

            return (duplicados, mensaje, sessionId, cadOriginal);
        }



        public (List<int> CodGruposDuplicados, string Mensaje, string SessionId
            , string CadOriginal)
    GuardarLecturaStickerBulkTVPTEST(DataTable dt)
        {
            List<int> duplicados = new List<int>();
            string mensaje = "";
            string sessionId = "";
            string cadOriginal = "";

            SqlConnection connection = leerconexion();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GuardarPedateoStickerBulkTEST", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.Parameters.AddWithValue("@Datos", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.TP_DEST_PedateoStickerTEST";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 🔹 Leer CodGrupoStick
                            int? codGrupo = reader["CodGrupoStick"] != DBNull.Value
                                ? Convert.ToInt32(reader["CodGrupoStick"])
                                : (int?)null;

                            if (codGrupo != null)
                                duplicados.Add(codGrupo.Value);

                            // 🔹 Leer SessionId (SIEMPRE viene de tu SP)
                            sessionId = reader["SessionId"] != DBNull.Value
                                ? reader["SessionId"].ToString()
                                : "";
                            // 🔹 Leer CadOriginal (SIEMPRE viene de tu SP)
                            cadOriginal = reader["CadOriginal"] != DBNull.Value
                                ? reader["CadOriginal"].ToString()
                                : "";
                            // 🔹 Leer mensaje
                            mensaje = reader["Mensaje"].ToString();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al ejecutar", sqlEx);
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

            return (duplicados, mensaje, sessionId, cadOriginal);
        }


        /*
        public (List<int> CodGruposDuplicados, string Mensaje) GuardarLecturaStickerBulkTVP(DataTable dt)
        {
            List<int> duplicados = new List<int>();
            string mensaje = "";

            // ✅ Usa tu conexión personalizada
            SqlConnection connection = leerconexion();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GuardarPedateoStickerBulk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.Parameters.AddWithValue("@Datos", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.TP_DEST_PedateoSticker";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int? codGrupo = reader["CodGrupoStick"] != DBNull.Value
                                ? Convert.ToInt32(reader["CodGrupoStick"])
                                : (int?)null;

                            string mensajeTmp = reader["Mensaje"].ToString();

                            if (codGrupo != null)
                                duplicados.Add(codGrupo.Value);

                            mensaje = mensajeTmp;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al ejecutar", sqlEx);
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

            return (duplicados, mensaje);
        }
        */

        // MOSTRAR LISTA RECEPCION PROG VOLCADO
        public DataTable PlanillaProgTareo(
            DateTime fecini, string nave
            , string linea, string trabajo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_GRUPO_TAREO_PERSONAS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Nave", SqlDbType.VarChar).Value = nave;
                comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
                comando.Parameters.AddWithValue("@Trabajo", SqlDbType.VarChar).Value = trabajo;
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


        // MOSTRAR LISTA REPORTE DESTAJO
        public DataTable ReporteDestajo(
            DateTime fecini, DateTime fecfin, string nave
            , string linea, string trabajo, int id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_DESTAJO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Nave", SqlDbType.VarChar).Value = nave;
                comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
                comando.Parameters.AddWithValue("@Trabajo", SqlDbType.VarChar).Value = trabajo;
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



        // MOSTRAR LISTA REPORTE AVANCE GRUPAL
        public DataTable ReporteAvanceGrupal(
            DateTime fecini, DateTime fecfin, string nave
            , string linea, string trabajo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_GRUPO_DESTAJO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FechaIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FechaFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Nave", SqlDbType.VarChar).Value = nave;
                comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
                comando.Parameters.AddWithValue("@Trabajo", SqlDbType.VarChar).Value = trabajo;
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



        // MOSTRAR LISTA REPORTE DESTAJO
        public DataTable ReporteCierreProcesoDia(
            DateTime fecini)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_CIERRE_PROCESO_DIA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
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


        // MOSTRAR LISTA REPORTE DESTAJO
        public DataTable ReporteDestajoCuadreCaja(
            DateTime fecini, string linea, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_DESTAJO_CUADRE_CAJAS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
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

        // MOSTRAR REPORTE PRORRATEO CAJAS
        public DataTable ReporteProrrateoCajas(
            DateTime fecini, string linea, string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_REPORTE_DESTAJO_DISTRIBUCION_CAJAS_PERSONA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
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


        // MOSTRAR LISTA RECEPCION PROG VOLCADO
        public DataTable DestajoPresentacion()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();

                // Cambiamos el procedimiento almacenado por una consulta SELECT * FROM
                SqlCommand comando = new SqlCommand("SELECT " +
                    " cast(0 as bit)Selec,Id,Cod,Descripcion,Cantidad Stickers,Tipo FROM [DEST_Presentacion]", conex);

                comando.CommandType = CommandType.Text; // Especificamos que es una consulta SQL directa
                conex.Open();

                resultado = comando.ExecuteReader();
                tabla.Load(resultado); // Cargamos los resultados en el DataTable

                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // Cerramos la conexión
            }
        }

        public (DataTable Detalle, int TotalSticker, int StickerCorrecto
            , int StickerInCorrecto
            , int TotalCajas, int CajasErradas, string Mensaje)
DestajoLecturaSticker(DateTime fecini, string nave, string linea)
        {
            DataTable detalle = new DataTable();
            int total = 0;
            int correctos = 0;
            int incorrectos = 0;
            int totalcajas = 0;
            int cajaserradas = 0;
            string mensaje = "No se recibieron datos de resumen.";

            using (SqlConnection conex = cd_conexion.CrearInstancia().leerconexion())
            using (SqlCommand comando = new SqlCommand("SP_MOSTRAR_DESTAJO_STICKER_PEDATEO", conex))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", fecini);
                comando.Parameters.AddWithValue("@Nave", nave);
                comando.Parameters.AddWithValue("@Linea", linea);

                conex.Open();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    // Crear columnas dinámicamente a partir del reader
                    for (int i = 0; i < dr.FieldCount; i++)
                        detalle.Columns.Add(dr.GetName(i), dr.GetFieldType(i));

                    // Leer filas del detalle
                    while (dr.Read())
                    {
                        DataRow row = detalle.NewRow();
                        for (int i = 0; i < dr.FieldCount; i++)
                            row[i] = dr.IsDBNull(i) ? DBNull.Value : dr.GetValue(i);
                        detalle.Rows.Add(row);
                    }

                    // Avanzar al segundo resultado (resumen)
                    if (dr.NextResult())
                    {
                        if (dr.Read())
                        {
                            total = dr.GetInt32(dr.GetOrdinal("TotalSticker"));
                            correctos = dr.GetInt32(dr.GetOrdinal("StickerCorrecto"));
                            incorrectos = dr.GetInt32(dr.GetOrdinal("StickerInCorrecto"));
                            totalcajas = dr.GetInt32(dr.GetOrdinal("TotalCajas"));
                            cajaserradas = dr.GetInt32(dr.GetOrdinal("CajasErradas"));
                            mensaje = dr.GetString(dr.GetOrdinal("Mensaje"));
                        }
                    }
                }
            }

            return (detalle, total, correctos, incorrectos
                , totalcajas, cajaserradas, mensaje);
        }

        // METODO PARA GUARDAR CIERRE PROCESO DIA
        public void GuardarCierreProcesoDestajo(
            int id, DateTime fechaproc, bool status
            , string idnave, string nave
            , string idlinea, string linea, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim, string sesion)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_CIERRE_PROCESO_DESTAJO_DIA"))
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

        /*
        public DataTable DestajoLecturaSticker(
            DateTime fecini, string nave
            , string linea)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_DESTAJO_STICKER_PEDATEO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@Nave", SqlDbType.VarChar).Value = nave;
                comando.Parameters.AddWithValue("@Linea", SqlDbType.VarChar).Value = linea;
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
        */



    }
}
