
using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_almacen : cd_conexion
    {


        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void GuardarEficienciaMaquinaria(DateTime fecha, string maquinaria, string grupo_maq, string modelo, string tipo_impl
            , string codificacion, string turno, string operador, string cabezal, string actividad, string implemento
            , string labores, string obj_tancada, decimal HA, decimal GLNS, decimal Hor_ini, decimal Hor_fin
            , decimal Hor_ini_efe, decimal Hor_fin_ene, string T_E, string T_M, string horas
            , string modelo_2, string sem, string mes, string ano, string Hr_ha, string Gln_hr, string Gln_tm
            , string tipo_labor, string fundo, string H_ini_reloj, string H_fin_reloj, string H_total, string Obj_aplicacion
            , string obs, string indicador, string sector, string descricpion
            , string hoja, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_EFICIENCIA_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquinaria;
                    comando.Parameters.AddWithValue("@Grupo_Maquina", SqlDbType.VarChar).Value = grupo_maq;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Tipo_impl", SqlDbType.VarChar).Value = tipo_impl;
                    comando.Parameters.AddWithValue("@Codificacion", SqlDbType.VarChar).Value = codificacion;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = operador;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = actividad;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@Labores", SqlDbType.VarChar).Value = labores;
                    comando.Parameters.AddWithValue("@Obj_tancada", SqlDbType.VarChar).Value = obj_tancada;

                    comando.Parameters.AddWithValue("@HA", SqlDbType.Decimal).Value = HA;
                    comando.Parameters.AddWithValue("@GLNS", SqlDbType.Decimal).Value = GLNS;
                    comando.Parameters.AddWithValue("@Hor_ini", SqlDbType.Decimal).Value = Hor_ini;
                    comando.Parameters.AddWithValue("@Hor_fin", SqlDbType.Decimal).Value = Hor_fin;
                    comando.Parameters.AddWithValue("@Hor_ini_efe", SqlDbType.Decimal).Value = Hor_ini_efe;
                    comando.Parameters.AddWithValue("@Hor_fin_efe", SqlDbType.Decimal).Value = Hor_fin_ene;

                    comando.Parameters.AddWithValue("@T_E", SqlDbType.VarChar).Value = T_E;
                    comando.Parameters.AddWithValue("@T_M", SqlDbType.VarChar).Value = T_M;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.VarChar).Value = horas;
                    comando.Parameters.AddWithValue("@Modelo_2", SqlDbType.VarChar).Value = modelo_2;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@A�o", SqlDbType.VarChar).Value = ano;
                    comando.Parameters.AddWithValue("@Hr_Ha", SqlDbType.VarChar).Value = Hr_ha;
                    comando.Parameters.AddWithValue("@Gln_hr", SqlDbType.VarChar).Value = Gln_hr;
                    comando.Parameters.AddWithValue("@Gln_tm", SqlDbType.VarChar).Value = Gln_tm;
                    comando.Parameters.AddWithValue("@Tipo_labor", SqlDbType.VarChar).Value = tipo_labor;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@H_ini_reloj", SqlDbType.VarChar).Value = H_ini_reloj;
                    comando.Parameters.AddWithValue("@H_fin_reloj", SqlDbType.VarChar).Value = H_fin_reloj;
                    comando.Parameters.AddWithValue("@H_total", SqlDbType.VarChar).Value = H_total;
                    comando.Parameters.AddWithValue("@Obj_aplicacion", SqlDbType.VarChar).Value = Obj_aplicacion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Indicador", SqlDbType.VarChar).Value = indicador;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descricpion;

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

        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void ActualizarEficienciaMaquinaria(DateTime fecha, string maquinaria, string grupo_maq, string modelo, string tipo_impl
            , string codificacion, string turno, string operador, string cabezal, string actividad, string implemento
            , string labores, string obj_tancada, decimal HA, decimal GLNS, decimal Hor_ini, decimal Hor_fin
            , decimal Hor_ini_efe, decimal Hor_fin_ene, string T_E, string T_M, string horas
            , string modelo_2, string sem, string mes, string ano, string Hr_ha, string Gln_hr, string Gln_tm
            , string tipo_labor, string fundo, string H_ini_reloj, string H_fin_reloj, string H_total, string Obj_aplicacion
            , string obs, string indicador, string sector, string descricpion
            , string hoja, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_EFICIENCIA_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Maquina", SqlDbType.VarChar).Value = maquinaria;
                    comando.Parameters.AddWithValue("@Grupo_Maquina", SqlDbType.VarChar).Value = grupo_maq;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Tipo_impl", SqlDbType.VarChar).Value = tipo_impl;
                    comando.Parameters.AddWithValue("@Codificacion", SqlDbType.VarChar).Value = codificacion;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = operador;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Actividad", SqlDbType.VarChar).Value = actividad;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@Labores", SqlDbType.VarChar).Value = labores;
                    comando.Parameters.AddWithValue("@Obj_tancada", SqlDbType.VarChar).Value = obj_tancada;

                    comando.Parameters.AddWithValue("@HA", SqlDbType.Decimal).Value = HA;
                    comando.Parameters.AddWithValue("@GLNS", SqlDbType.Decimal).Value = GLNS;
                    comando.Parameters.AddWithValue("@Hor_ini", SqlDbType.Decimal).Value = Hor_ini;
                    comando.Parameters.AddWithValue("@Hor_fin", SqlDbType.Decimal).Value = Hor_fin;
                    comando.Parameters.AddWithValue("@Hor_ini_efe", SqlDbType.Decimal).Value = Hor_ini_efe;
                    comando.Parameters.AddWithValue("@Hor_fin_efe", SqlDbType.Decimal).Value = Hor_fin_ene;

                    comando.Parameters.AddWithValue("@T_E", SqlDbType.VarChar).Value = T_E;
                    comando.Parameters.AddWithValue("@T_M", SqlDbType.VarChar).Value = T_M;
                    comando.Parameters.AddWithValue("@Horas", SqlDbType.VarChar).Value = horas;
                    comando.Parameters.AddWithValue("@Modelo_2", SqlDbType.VarChar).Value = modelo_2;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sem;
                    comando.Parameters.AddWithValue("@Mes", SqlDbType.VarChar).Value = mes;
                    comando.Parameters.AddWithValue("@A�o", SqlDbType.VarChar).Value = ano;
                    comando.Parameters.AddWithValue("@Hr_Ha", SqlDbType.VarChar).Value = Hr_ha;
                    comando.Parameters.AddWithValue("@Gln_hr", SqlDbType.VarChar).Value = Gln_hr;
                    comando.Parameters.AddWithValue("@Gln_tm", SqlDbType.VarChar).Value = Gln_tm;
                    comando.Parameters.AddWithValue("@Tipo_labor", SqlDbType.VarChar).Value = tipo_labor;
                    comando.Parameters.AddWithValue("@Fundo", SqlDbType.VarChar).Value = fundo;
                    comando.Parameters.AddWithValue("@H_ini_reloj", SqlDbType.VarChar).Value = H_ini_reloj;
                    comando.Parameters.AddWithValue("@H_fin_reloj", SqlDbType.VarChar).Value = H_fin_reloj;
                    comando.Parameters.AddWithValue("@H_total", SqlDbType.VarChar).Value = H_total;
                    comando.Parameters.AddWithValue("@Obj_aplicacion", SqlDbType.VarChar).Value = Obj_aplicacion;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Indicador", SqlDbType.VarChar).Value = indicador;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descricpion;

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




        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteEficienciaMaquinaria(string cod, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TRANSPORTE_VIAJE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_taller.codigo = reader.GetString(0);
                            ce_taller.FechaInicio = reader.GetDateTime(1);
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



        //PERSONAL ABASTECIMIENTO
        public DataTable BuscarPedateoAbastecimientoGrifo(DateTime FecIni, DateTime FecFin
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_ABASTECIMIENTO_GRIFO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
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





        //PERSONAL ABASTECIMIENTO
        public DataTable BuscarPedateoAbastecimientoGrifoCorte(DateTime FecIni, DateTime FecFin
            , string area, string tipopersonal, string Empresa, string Sede, string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_ABASTECIMIENTO_GRIFO_DETALLE_CORTE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.DateTime).Value = FecIni;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.DateTime).Value = FecFin;
                comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = tipopersonal;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = Sede;
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



    }
}