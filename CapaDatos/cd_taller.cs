
using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_taller : cd_conexion
    {



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


        // MOSTRAR LISTA DE GRUPO VEHICULO
        public DataTable ListaGrupoVehiculo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_GRUPOVEHICULO", conex);
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

        // MOSTRAR LISTA DE GRUPO VEHICULO
        public DataTable ListaMetaKM()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_META_KM", conex);
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


        // MOSTRAR LISTA DE STATUS CORRECTIVO
        public DataTable ListaStatusCorrectivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_StatusCorrectivo", conex);
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

        // MOSTRAR LISTA DE LABOR
        public DataTable ListaLabor()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TALL_Labor", conex);
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

        // MOSTRAR LISTA DE LABOR
        public DataTable ListaLaborImplemento(string labor)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TALL_LaborImplemento", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
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

        // MOSTRAR LISTA DE TIPO LABOR
        public DataTable ListaTipoLabor()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TALL_TipoLabor", conex);
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

        // MOSTRAR LISTA DE SISTEMA CORRECTIVO
        public DataTable ListaSistemaCorrectivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_SistemaCorrectivo", conex);
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

        // MOSTRAR LISTA DE SUSTENTO CORRECTIVO
        public DataTable ListaSustentoCorrectivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_SustentoCorrectivo", conex);
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

        // MOSTRAR LISTA DE TIPO CORRECTIVO
        public DataTable ListaTipoCorrectivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TipoCorrectivo", conex);
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

        // MOSTRAR LISTA DE TIPO CORRECTIVO
        public DataTable ListaTipoFallaCorrectivo()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_TipoFallaCorrectivo", conex);
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

        // MOSTRAR LISTA DE VEHICULO
        public DataTable ListaVehiculo(string grupo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_VEHICULO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
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

        // MOSTRAR LISTA DETALLE INSUMOS
        public DataTable ListaDetalleInsumos(
            string grupo, string marca, string modelo, string km)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_DETALLE_INSUMOS_VEHICULO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.AddWithValue("@Km", SqlDbType.VarChar).Value = km;
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


        // MOSTRAR LISTA DE MARCA VEHICULO
        public DataTable ListaMarcaVehiculo(string id, string grupo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_MARCAVEHICULO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Num", SqlDbType.VarChar).Value = id;
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
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


        // MOSTRAR LISTA DE MARCA VEHICULO
        public DataTable ListaModeloVehiculo(string num, string marca)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_MODELOVEHICULO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Num", SqlDbType.VarChar).Value = num;
                comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
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

        // MOSTRAR LISTA REPORTE VEHICULO
        public DataTable ListaReporteVehiculo(
            string emp, string sed, string grupo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_VEHICULOS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
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

        // MOSTRAR LISTA REPORTE GRUPO VEHICULO
        public DataTable ListaReporteGrupoVehiculo(
            string emp, string sed, string grupo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_VEHICULOS", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                //comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
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

        // MOSTRAR LISTA REPORTE MANT PREVENTIVO
        public DataTable ListaReporteMantenimientoPrev(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string grupo, string vehiculo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_MANTENIMIENTO_PREVENTIVO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.AddWithValue("@Vehiculo", SqlDbType.VarChar).Value = grupo;
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

        // MOSTRAR LISTA REPORTE PROXIMO MANT PREVENTIVO
        public DataTable ListaReporteProxMantPrev(
            string emp, string sed, string grupo, string vehiculo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_PROX_MANT_PREVENTIVO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.AddWithValue("@Vehiculo", SqlDbType.VarChar).Value = grupo;
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

        // MOSTRAR LISTA REPORTE ORDEN TRABAJO
        public DataTable ListaReporteOrdenTrabajo(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string estado)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_ORDEN_TRABAJO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
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

        // MOSTRAR LISTA REPORTE KM METAS
        public DataTable ListaReporteMantemientoInsumo(
            string grupo, string marca, string modelo, string km)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_MANTENIMIENTO_INSUMO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.AddWithValue("@Km", SqlDbType.VarChar).Value = km;
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

        // MOSTRAR LISTA REPORTE MANT PREVENTIVO
        public DataTable ListaReporteMantenimientoCorrectivo(
            DateTime fecini, DateTime fecfin,
            string emp, string sed, string grupo, string vehiculo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_MANTENIMIENTO_CORRECTIVO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.AddWithValue("@Vehiculo", SqlDbType.VarChar).Value = grupo;
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


        // MOSTRAR LISTA REPORTE EFICIENCIA MAQUINARIA
        public DataTable ListaReporteEficienciaMaquinaria(
            DateTime fecini, DateTime fecfin,
            string emp, string sed)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_EFICIENCIA_MAQUINARIA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fecini;
                comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fecfin;
                comando.Parameters.AddWithValue("@Emp", SqlDbType.VarChar).Value = emp;
                comando.Parameters.AddWithValue("@Sed", SqlDbType.VarChar).Value = sed;
                //comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                //comando.Parameters.AddWithValue("@Vehiculo", SqlDbType.VarChar).Value = grupo;
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


        // METODO PARA GUARDAR LISTA VEHICULOS
        public void GuardarListaVehiculos(
            string emp, string sed, string area, string placa
            , string tipovehiculo, string marca, string modelo, string responsable
            , string consumidor, string grupo, string nombre_maq, string potencia
            , string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_ListaVehiculos"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
                    comando.Parameters.AddWithValue("@TipoVehiculo", SqlDbType.VarChar).Value = tipovehiculo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@IdConsumidor", SqlDbType.VarChar).Value = consumidor;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Nombre_Maq", SqlDbType.VarChar).Value = nombre_maq;
                    comando.Parameters.AddWithValue("@Potencia_HP", SqlDbType.VarChar).Value = potencia;

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

        // METODO PARA GUARDAR LISTA VEHICULOS
        public void GuardarListaInsumos(
            string emp, string sed,
            string grupo, string marca, string modelo, string codigo
            , string descripcion, string unidad, string cantidad, string km_ini
            , string km_fin
            , string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_MANTENIMIENTO_INSUMOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    comando.Parameters.AddWithValue("@Unidad", SqlDbType.VarChar).Value = unidad;
                    comando.Parameters.AddWithValue("@Cantidad", SqlDbType.VarChar).Value = cantidad;
                    comando.Parameters.AddWithValue("@KmInicial", SqlDbType.VarChar).Value = km_ini;
                    comando.Parameters.AddWithValue("@KmFinal", SqlDbType.VarChar).Value = km_fin;

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



        // METODO PARA GUARDAR LISTA VEHICULOS
        public void GuardarGrupoVehiculo(
            string grupo, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_GrupoVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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

        // METODO PARA GUARDAR LISTA VEHICULOS
        public void GuardarMarcaVehiculo(
            string grupo, string marca, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_MarcaVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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


        // METODO PARA GUARDAR MODELO VEHICULO
        public void GuardarModeloVehiculo(
            string marca, string modelo, string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_ModeloVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

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


        // METODO PARA ACTUALIZAR GRUPO VEHICULO
        public void ActualizarGrupoVehiculo(string id,
            string grupo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALL_GrupoVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ACTUALIZAR MARCA VEHICULO
        public void ActualizarMarcaVehiculo(string id,
            string grupo, string marca, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALL_MarcaVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ACTUALIZAR MODELO VEHICULO
        public void ActualizarModeloVehiculo(string id,
            string marca, string modelo, string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALL_ModeloVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA GUARDAR MANTENIMIENTO VEHICULO
        public void GuardarMantenimientoVehiculos(string fecha,
            string emp, string sed, string area, string idveh
            , string kmInicial, string kmFinal, string difKm, string implemento
            , string cabezal, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_MantenimientoVehiculos"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;

                    comando.Parameters.AddWithValue("@IdVeh", SqlDbType.VarChar).Value = idveh;
                    comando.Parameters.AddWithValue("@KmInicial", SqlDbType.VarChar).Value = kmInicial;
                    comando.Parameters.AddWithValue("@KmFinal", SqlDbType.VarChar).Value = kmFinal;
                    comando.Parameters.AddWithValue("@DifKm", SqlDbType.VarChar).Value = difKm;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@CabezalArea", SqlDbType.VarChar).Value = cabezal;

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

        // METODO PARA GUARDAR MANTENIMIENTO CORRECTIVO
        public void GuardarMantenimientoCorrectivo(string fechaing, string fechasal,
            string emp, string sed, string idveh
            , string diasinop, string hrsinop, string km, string status, string sistema
            , string sustento, string tipo, string falla, string costo
            , string labor, string implemento
            , string obs, string estado, DateTime fec_cre
            , int usereg, string hostname
            , DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_TALL_MantenimientoCorrectivo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@FechaIng", SqlDbType.VarChar).Value = fechaing;
                    comando.Parameters.AddWithValue("@FechaSal", SqlDbType.VarChar).Value = fechasal;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;

                    comando.Parameters.AddWithValue("@IdVeh", SqlDbType.VarChar).Value = idveh;
                    comando.Parameters.AddWithValue("@DiasInop", SqlDbType.VarChar).Value = diasinop;
                    comando.Parameters.AddWithValue("@HorasInop", SqlDbType.VarChar).Value = hrsinop;
                    comando.Parameters.AddWithValue("@Km", SqlDbType.VarChar).Value = km;
                    comando.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = status;
                    comando.Parameters.AddWithValue("@Sistema", SqlDbType.VarChar).Value = sistema;
                    comando.Parameters.AddWithValue("@Sustento", SqlDbType.VarChar).Value = sustento;
                    comando.Parameters.AddWithValue("@TipoCorrectivo", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@TipoFalla", SqlDbType.VarChar).Value = falla;
                    comando.Parameters.AddWithValue("@Costo", SqlDbType.VarChar).Value = costo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@DetalleObs", SqlDbType.VarChar).Value = obs;

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


        // METODO PARA GUARDAR EFICIENCIA
        public void GuardarEficienciaMaquinaria(
            string emp, string sed, string fecha, string idveh
            , string turno, string operador, string cabezal
            , string labor, string implemento, string tipolabor
            , string obj_tancada, string HA, string GLNS
            , string km_ini, string km_fin
            , string Hor_ini_efe, string Hor_fin_efe
            , string Hor_ini, string Hor_fin, string Obj_aplicacion
            , string obs, string indicador, string sector
            , string descricpion, string estado
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_EFICIENCIA_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@IdVeh", SqlDbType.VarChar).Value = idveh;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = operador;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@Tipo_labor", SqlDbType.VarChar).Value = tipolabor;
                    comando.Parameters.AddWithValue("@Obj_tancada", SqlDbType.VarChar).Value = obj_tancada;
                    comando.Parameters.AddWithValue("@HA", SqlDbType.VarChar).Value = HA;
                    comando.Parameters.AddWithValue("@GLNS", SqlDbType.VarChar).Value = GLNS;
                    comando.Parameters.AddWithValue("@Km_ini", SqlDbType.VarChar).Value = km_ini;
                    comando.Parameters.AddWithValue("@Km_fin", SqlDbType.VarChar).Value = km_fin;
                    comando.Parameters.AddWithValue("@Hor_ini_efe", SqlDbType.VarChar).Value = Hor_ini_efe;
                    comando.Parameters.AddWithValue("@Hor_fin_efe", SqlDbType.VarChar).Value = Hor_fin_efe;
                    comando.Parameters.AddWithValue("@Hor_ini", SqlDbType.VarChar).Value = Hor_ini;
                    comando.Parameters.AddWithValue("@Hor_fin", SqlDbType.VarChar).Value = Hor_fin;
                    comando.Parameters.AddWithValue("@Objetivo_aplicacion", SqlDbType.VarChar).Value = obj_tancada;
                    comando.Parameters.AddWithValue("@Observaciones", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Indicador", SqlDbType.VarChar).Value = indicador;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descricpion;

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

        // METODO PARA ACTUALIZAR EFICIENCIA
        public void ActualizarEficienciaMaquinaria(string id,
            string emp, string sed, string fecha, string idveh
            , string turno, string operador, string cabezal
            , string labor, string implemento, string tipolabor
            , string obj_tancada, string HA, string GLNS
            , string km_ini, string km_fin
            , string Hor_ini_efe, string Hor_fin_efe
            , string Hor_ini, string Hor_fin, string Obj_aplicacion
            , string obs, string indicador, string sector
            , string descricpion
            , DateTime fec_cre, int usereg)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_EFICIENCIA_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@IdVeh", SqlDbType.VarChar).Value = idveh;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = operador;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@Tipo_labor", SqlDbType.VarChar).Value = tipolabor;
                    comando.Parameters.AddWithValue("@Obj_tancada", SqlDbType.VarChar).Value = obj_tancada;
                    comando.Parameters.AddWithValue("@HA", SqlDbType.VarChar).Value = HA;
                    comando.Parameters.AddWithValue("@GLNS", SqlDbType.VarChar).Value = GLNS;
                    comando.Parameters.AddWithValue("@Km_ini", SqlDbType.VarChar).Value = km_ini;
                    comando.Parameters.AddWithValue("@Km_fin", SqlDbType.VarChar).Value = km_fin;
                    comando.Parameters.AddWithValue("@Hor_ini_efe", SqlDbType.VarChar).Value = Hor_ini_efe;
                    comando.Parameters.AddWithValue("@Hor_fin_efe", SqlDbType.VarChar).Value = Hor_fin_efe;
                    comando.Parameters.AddWithValue("@Hor_ini", SqlDbType.VarChar).Value = Hor_ini;
                    comando.Parameters.AddWithValue("@Hor_fin", SqlDbType.VarChar).Value = Hor_fin;
                    comando.Parameters.AddWithValue("@Objetivo_aplicacion", SqlDbType.VarChar).Value = obj_tancada;
                    comando.Parameters.AddWithValue("@Observaciones", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@Indicador", SqlDbType.VarChar).Value = indicador;
                    comando.Parameters.AddWithValue("@Sector", SqlDbType.VarChar).Value = sector;
                    comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = descricpion;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usereg;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ACTUALIZAR MANTENIMIENTO CORRECTIVO
        public void ActualizarMantenimientoCorrectivo(string id,
            string fechaing, string fechasal,
            string emp, string sed, string idveh
            , string diasinop, string hrsinop, string km, string status, string sistema
            , string sustento, string tipo, string falla, string costo
            , string labor, string implemento
            , string obs
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALL_MantenimientoCorrectivo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@FechaIng", SqlDbType.VarChar).Value = fechaing;
                    comando.Parameters.AddWithValue("@FechaSal", SqlDbType.VarChar).Value = fechasal;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;

                    comando.Parameters.AddWithValue("@IdVeh", SqlDbType.VarChar).Value = idveh;
                    comando.Parameters.AddWithValue("@DiasInop", SqlDbType.VarChar).Value = diasinop;
                    comando.Parameters.AddWithValue("@HorasInop", SqlDbType.VarChar).Value = hrsinop;
                    comando.Parameters.AddWithValue("@Km", SqlDbType.VarChar).Value = km;
                    comando.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = status;
                    comando.Parameters.AddWithValue("@Sistema", SqlDbType.VarChar).Value = sistema;
                    comando.Parameters.AddWithValue("@Sustento", SqlDbType.VarChar).Value = sustento;
                    comando.Parameters.AddWithValue("@TipoCorrectivo", SqlDbType.VarChar).Value = tipo;
                    comando.Parameters.AddWithValue("@TipoFalla", SqlDbType.VarChar).Value = falla;
                    comando.Parameters.AddWithValue("@Costo", SqlDbType.VarChar).Value = costo;
                    comando.Parameters.AddWithValue("@Labor", SqlDbType.VarChar).Value = labor;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@DetalleObs", SqlDbType.VarChar).Value = obs;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA GUARDAR MANTENIMIENTO VEHICULO
        public void ActualizarMantenimientoVehiculos(string id
            , string fecha, string emp, string sed, string area, string idveh
            , string kmInicial, string kmFinal, string difKm, string implemento
            , string cabezal, DateTime fecedit, int useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALL_MantenimientoVehiculos"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = id;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.VarChar).Value = fecha;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;

                    comando.Parameters.AddWithValue("@IdVeh", SqlDbType.VarChar).Value = idveh;
                    comando.Parameters.AddWithValue("@KmInicial", SqlDbType.VarChar).Value = kmInicial;
                    comando.Parameters.AddWithValue("@KmFinal", SqlDbType.VarChar).Value = kmFinal;
                    comando.Parameters.AddWithValue("@DifKm", SqlDbType.VarChar).Value = difKm;
                    comando.Parameters.AddWithValue("@Implemento", SqlDbType.VarChar).Value = implemento;
                    comando.Parameters.AddWithValue("@CabezalArea", SqlDbType.VarChar).Value = cabezal;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fecedit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = useedit;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // METODO PARA ACTUALIZAR LISTA VEHICULOS
        public void ActualizarListaVehiculos(int id,
            string emp, string sed, string area, string placa
            , string tipovehiculo, string marca, string modelo, string responsable
            , string consumidor, string grupo, string nombre_maq, string potencia
            , DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_TALL_ListaVehiculos"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = emp;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = sed;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = area;
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
                    comando.Parameters.AddWithValue("@TipoVehiculo", SqlDbType.VarChar).Value = tipovehiculo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Responsable", SqlDbType.VarChar).Value = responsable;
                    comando.Parameters.AddWithValue("@IdConsumidor", SqlDbType.VarChar).Value = consumidor;
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Nombre_Maq", SqlDbType.VarChar).Value = nombre_maq;
                    comando.Parameters.AddWithValue("@Potencia_HP", SqlDbType.VarChar).Value = potencia;

                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }


        // METODO PARA ELIMINAR LISTA VEHICULO
        public void EliminarListaVehiculo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_Vehiculos"))
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

        // METODO PARA ELIMINAR LISTA VEHICULO
        public void EliminarGrupoVehiculo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_GrupoVehiculo"))
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

        // METODO PARA ELIMINAR MARCA VEHICULO
        public void EliminarMarcaVehiculo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_MarcaVehiculo"))
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

        // METODO PARA ELIMINAR MODELO VEHICULO
        public void EliminarModeloVehiculo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_ModeloVehiculo"))
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


        // METODO PARA ELIMINAR LISTA MANTENIMIENTO PREV
        public void EliminarListaMantPreventivo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_MANTENIMIENTO_PREVENTIVO"))
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

        // METODO PARA ELIMINAR LISTA ORDEN TRABAJO
        public void EliminarListaOrdenTrabajo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_ORDEN_TRABAJO"))
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


        // METODO PARA ELIMINAR LISTA MANTENIMIENTO CORRECTIVO
        public void EliminarListaMantCorrectivo(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_MANTENIMIENTO_CORRECTIVO"))
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



        // METODO PARA ELIMINAR LISTA EFICIENCIA
        public void EliminarListaEficiencia(string cod, DateTime Fec_mov, int useelim)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_EFICIENCIA_MAQUINARIA"))
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


        // ELIMINAR MANTENIMIENTO INSUMOS
        public void EliminarMantenimientoInsumos(
            string grupo, string marca, string modelo, string km)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_TALL_MANTENIMIENTO_INSUMOS"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
                    comando.Parameters.AddWithValue("@Km", SqlDbType.VarChar).Value = km;
                    comando.ExecuteNonQuery();

                }
            }

        }



        // MOSTRAR LISTA DE ASIGNACION POR FILTROS
        public DataTable ListaVehiculo(string cod, string des)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_LISTA_VEHICULO", conex);
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


        // METODO PARA LLAMAR SI EXISTE GRUPO
        public bool BuscExisteGrupoVehiculo(string grupo)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_GrupoVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
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

        // METODO PARA LLAMAR SI EXISTE MARCA
        public bool BuscExisteMarcaVehiculo(string grupo, string marca)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_MarcaVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Grupo", SqlDbType.VarChar).Value = grupo;
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
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

        // METODO PARA LLAMAR SI EXISTE MODELO
        public bool BuscExisteModeloVehiculo(string marca, string modelo)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_ModeloVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Marca", SqlDbType.VarChar).Value = marca;
                    comando.Parameters.AddWithValue("@Modelo", SqlDbType.VarChar).Value = modelo;
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

        // METODO PARA LLAMAR SI EXISTE PLACA
        public bool BuscExistePlacaVehiculo(string placa)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_PlacaVehiculo"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = placa;
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




    }
}