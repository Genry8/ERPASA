using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CapaDatos
{
    public class cd_equipoti : cd_conexion
    {

        // MOSTRAR LISTA DE CONDICION EQUIPOTI
        public DataTable ListaCondicionEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE EMPRESA
        public DataTable ListaEmpresaEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_EMPRESA_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE SEDE
        public DataTable ListaSedeEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_SEDE_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE GERENCIA
        public DataTable ListaGerenciaEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GERENCIA_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE GERENCIA
        public DataTable ListaAreaEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_AREA_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE TIPO
        public DataTable ListaTipoEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TIPO_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE MARCA
        public DataTable ListaMarcaEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MARCA_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE MODELO
        public DataTable ListaModeloEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MODELO_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE SISOPERATIVO
        public DataTable ListaSisOperativoEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_SISOPERATIVO_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE PROCESADOR
        public DataTable ListaProcesadorEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PROCESADOR_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaMemoriaEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MEMORIA_EQUIPOTI", conex);
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

        // MOSTRAR LISTA DE MEMORIA
        public DataTable ListaDiscoDuroEquipoTI()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_DISCODURO_EQUIPOTI", conex);
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

        // METODO PARA LLAMAR SI EXISTE EL EMPLEADOR
        public bool BuscExisteDniEmpleador(string codempl)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_PERSONAL_EQUIPOTI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = codempl;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_equipoti.CodTrabajadorExist = reader.GetString(0);
                            ce_equipoti.EmpleadorExist = reader.GetString(1);
                            ce_equipoti.EdadEmpleadorExist = reader.GetString(2);
                            ce_equipoti.EmpresaEmpleadorExist = reader.GetString(3);
                            ce_equipoti.SedeEmpleadorExist = reader.GetString(4);
                            ce_equipoti.AreaEmpleadorExist = reader.GetString(5);
                            ce_equipoti.CargoEmpleadorExist = reader.GetString(6);
                            ce_equipoti.EstadoEmpleadorExist = reader.GetString(7);
                            ce_equipoti.FecNacEmpleadorExist = reader.GetDateTime(8);
                            ce_equipoti.ApellidoEmpleadorExist = reader.GetString(9);
                            ce_equipoti.NombreEmpleadorExist = reader.GetString(10);
                            ce_equipoti.SexoEmpleadorExist = reader.GetString(11);
                            ce_equipoti.CorreoEmpleadorExist = reader.GetString(12);
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



        // METODO PARA LLAMAR SI EXISTE EL EMPLEADOR
        public bool BuscExisteDocContrato(int cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUC_EXISTE_CONTRATO_PROV"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@cod", SqlDbType.Int).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_equipoti.CodTrabajadorExist = reader.GetString(0);

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


        // METODO PARA LLAMAR SI EXISTE EL EMPLEADOR
        public bool BuscarDocumentoContrato(int cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUCAR_DOCUMENTO_CONTRATO_PROV"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@cod", SqlDbType.Int).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                            var data = (byte[])reader[1];
                            var extn = reader.GetString(2);
                            var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss"));
                            File.WriteAllBytes(newFileName, data);
                            System.Diagnostics.Process.Start(newFileName);
                            //ce_equipoti.DocProveedor = reader.GetString(0);

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


        //BUSCAR EQUIPO EN TABLA
        public DataTable BuscarEquipoTI(string TipoEquipo, string Empresa, string Sede, string Gerencia, string Area)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_EQUIPOTI_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@tipoequipo", SqlDbType.VarChar).Value = TipoEquipo;
                comando.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = Empresa;
                comando.Parameters.AddWithValue("@sede", SqlDbType.VarChar).Value = Sede;
                comando.Parameters.AddWithValue("@gerencia", SqlDbType.VarChar).Value = Gerencia;
                comando.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = Area;
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
        //
        //


        // METODO PARA LLAMAR SI EXISTE EL EMPLEADOR
        public bool BuscPaginaParaHoja(int cod, DateTime fecha)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_PAGINA_DOCCONTROLADO_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_equipoti.NombreHoja = reader.GetString(0);
                            ce_equipoti.TipoHoja = reader.GetString(1);
                            ce_equipoti.CodigoHoja = reader.GetString(2);
                            ce_equipoti.VersionHoja = reader.GetString(3);
                            ce_equipoti.FechaHoja = reader.GetDateTime(4);
                            ce_equipoti.PaginaHoja = reader.GetInt32(5);
                            ce_equipoti.EmpresaHoja = reader.GetString(6);
                            ce_equipoti.RucHoja = reader.GetString(7);
                            ce_equipoti.DireccionHoja = reader.GetString(8);
                            ce_equipoti.InspectorHoja = reader.GetString(9);
                            ce_equipoti.DniInspectorHoja = reader.GetInt32(10);
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


        // MOSTRAR LISTA DOCUMENTO PROVEEDOR
        public DataTable ListaContratoDocumento(string proveedor)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_CONTRATO_PROVEEDOR", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@proveedor", SqlDbType.VarChar).Value = proveedor;
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



        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void ActualizarContratoDocumento(int id, byte[] data,
            string extension, string filename, string proveedor, string contrato
            , string ruta, DateTime fec_ini, DateTime fec_fin, string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CONTRATO_PROVEEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.AddWithValue("@Data", SqlDbType.VarBinary).Value = data;
                    comando.Parameters.AddWithValue("@Extension", SqlDbType.Char).Value = extension;
                    comando.Parameters.AddWithValue("@FileName", SqlDbType.VarChar).Value = filename;
                    comando.Parameters.AddWithValue("@Proveedor", SqlDbType.VarChar).Value = proveedor;
                    comando.Parameters.AddWithValue("@Contrato", SqlDbType.VarChar).Value = contrato;
                    comando.Parameters.AddWithValue("@Ruta", SqlDbType.VarChar).Value = ruta;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fec_ini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fec_fin;

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



        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void ActualizarContratoDocumentoEstado(int id, string estado, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_CONTRATO_PROVEEDOR_ESTADO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

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




        // METODO PARA GUARDAR ATENCION MEDICA
        public void GuardarContratoDocumento(byte[] data,
            string extension, string filename, string proveedor, string contrato
            , string ruta, DateTime fec_ini, DateTime fec_fin, string estado
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_CONTRATO_PROVEEDOR"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    comando.Parameters.AddWithValue("@Data", SqlDbType.VarBinary).Value = data;
                    comando.Parameters.AddWithValue("@Extension", SqlDbType.Char).Value = extension;
                    comando.Parameters.AddWithValue("@FileName", SqlDbType.VarChar).Value = filename;
                    comando.Parameters.AddWithValue("@Proveedor", SqlDbType.VarChar).Value = proveedor;
                    comando.Parameters.AddWithValue("@Contrato", SqlDbType.VarChar).Value = contrato;
                    comando.Parameters.AddWithValue("@Ruta", SqlDbType.VarChar).Value = ruta;
                    comando.Parameters.AddWithValue("@FecIni", SqlDbType.Date).Value = fec_ini;
                    comando.Parameters.AddWithValue("@FecFin", SqlDbType.Date).Value = fec_fin;

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




    }
}
