using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_servpersonal : cd_conexion
    {

        // METODO PARA GUARDAR ASISTENCIA
        public void GuardarInspeccion(string cod, int sem, string emp, string sed
            , string area, string incidencia, string hallazgo, string peligro, string jerarquia
            , string hallazgo_desv, string medida_correc, string respon, string fec_Rep, string est_insp
            , string medida_correc_2, string evidencia, string fec_levant, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SPER_INSPECCION"))
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
                    comando.Parameters.AddWithValue("@FechaRep", SqlDbType.VarChar).Value = fec_Rep;
                    comando.Parameters.AddWithValue("@Estado_Insp", SqlDbType.VarChar).Value = est_insp;
                    comando.Parameters.AddWithValue("@Medida_Correctiva_2", SqlDbType.VarChar).Value = medida_correc_2;
                    comando.Parameters.AddWithValue("@Evidencia", SqlDbType.VarChar).Value = evidencia;
                    comando.Parameters.AddWithValue("@FechaLev", SqlDbType.VarChar).Value = fec_levant;

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



        // METODO PARA GUARDAR ASISTENCIA
        public void GuardarAsistencia(
            string Asistencia, string Punto_de_control, string Tipo
            , string Fecha_hora_asistencia, string DNI, string Nombres
            , string año, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SPER_ASISTENCIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Asistencia", SqlDbType.VarChar).Value = Asistencia;
                    comando.Parameters.AddWithValue("@Punto_de_control", SqlDbType.VarChar).Value = Punto_de_control;
                    comando.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = Tipo;
                    comando.Parameters.AddWithValue("@Fecha_hora", SqlDbType.VarChar).Value = Fecha_hora_asistencia;
                    comando.Parameters.AddWithValue("@DNI", SqlDbType.VarChar).Value = DNI;
                    comando.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = Nombres;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
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

        // METODO PARA GUARDAR ASISTENCIA
        public void GuardarDescuentoComedorPlanilla(
              string DNI, string Nombres, string emp, string sede
            , string comedor, string monto
            , string año, string semana, string fecini, string fecfin
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SPER_DESC_COMEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@DNI", SqlDbType.VarChar).Value = DNI;
                    comando.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = Nombres;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sede;
                    comando.Parameters.AddWithValue("@Comedor", SqlDbType.VarChar).Value = comedor;
                    comando.Parameters.AddWithValue("@Monto", SqlDbType.VarChar).Value = monto;

                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = semana;
                    comando.Parameters.AddWithValue("@FechaIni", SqlDbType.VarChar).Value = fecini;
                    comando.Parameters.AddWithValue("@FechaFin", SqlDbType.VarChar).Value = fecfin;

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

        // METODO PARA GUARDAR ASISTENCIA
        public void GuardarMotivoAccidente(
            string DNI, string Nombres
            , string fecha, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SPER_MOTIVOACCIDENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@DNI", SqlDbType.VarChar).Value = DNI;
                    comando.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = Nombres;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
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


        // METODO PARA GUARDAR CAMPAMENTO BUNKET
        public void GuardarCampamentoBunker(string emp, string sed,
            string Pabellon, string N, string Campamento
            , string DNI, string Responsable_habitacion, string Sexo
            , string Gerencia, string Area, string Cargo
            , string Lugar_de_residencia, string Condicion_de_alojamiento
            , string Condicion_contrato, string Capacidad, string Ocupabilidad
            , string Disponibilidad, string diascamp, string obs
            , string año, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_SPER_CAMPAMENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Pabellon", SqlDbType.VarChar).Value = Pabellon;
                    comando.Parameters.AddWithValue("@N", SqlDbType.VarChar).Value = N;
                    comando.Parameters.AddWithValue("@Campamento", SqlDbType.VarChar).Value = Campamento;
                    comando.Parameters.AddWithValue("@DNI", SqlDbType.VarChar).Value = DNI;
                    comando.Parameters.AddWithValue("@Responsable_habitacion", SqlDbType.VarChar).Value = Responsable_habitacion;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = Sexo;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = Gerencia;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@Lugar_de_residencia", SqlDbType.VarChar).Value = Lugar_de_residencia;
                    comando.Parameters.AddWithValue("@Condicion_de_alojamiento", SqlDbType.VarChar).Value = Condicion_de_alojamiento;
                    comando.Parameters.AddWithValue("@Condicion_contrato", SqlDbType.VarChar).Value = Condicion_contrato;
                    comando.Parameters.AddWithValue("@Capacidad", SqlDbType.VarChar).Value = Capacidad;
                    comando.Parameters.AddWithValue("@Ocupabilidad", SqlDbType.VarChar).Value = Ocupabilidad;
                    comando.Parameters.AddWithValue("@Disponibilidad", SqlDbType.VarChar).Value = Disponibilidad;
                    comando.Parameters.AddWithValue("@DiasCampamento", SqlDbType.VarChar).Value = diascamp;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
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


        // METODO PARA ELIMINAR CAMPAMENTO
        public void EliminarCampamento(
            string emp, string sed, string año, string semana)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_SPER_CAMPAMENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = año;
                    comando.Parameters.AddWithValue("@Semana", SqlDbType.VarChar).Value = semana;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR ASISTENCIA
        public void EliminarAsistencia(
            string emp, string sed)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_SPER_ASISTENCIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Año", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sem", SqlDbType.VarChar).Value = sed;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // MOSTRAR LISTA RECEPCION IMPRIMIR
        public DataTable ListaReporteQRTransportista(string trans)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_IMPRIMIR_LISTA_VEHICULOS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Transportista", SqlDbType.VarChar).Value = trans;
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


        // MOSTRAR LISTA REPORTE INGRESO SALIDA BUSES RESUMEN
        public DataTable ListaReporteResumenIngresoSalidaBuses(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string transporte, string placa)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_RESUMEN_INGRESO_SALIDA_BUSES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Transporte", SqlDbType.VarChar).Value = transporte;
                comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
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


        // MOSTRAR LISTA REPORTE INGRESO SALIDA BUSES RESUMEN
        public DataTable ListaReporteDetalleIngresoSalidaBuses(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string transporte, string placa)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_DETALLE_INGRESO_SALIDA_BUSES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Transporte", SqlDbType.VarChar).Value = transporte;
                comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
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
