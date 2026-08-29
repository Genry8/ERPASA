using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class cd_datosventa : cd_conexion
    {
        /// <summary>
        /// ////////////////////////////////////
        /// ///QUERY PARA CARGAR LOS COMBOS EN EL FORMULARIO ORDEN DE VENTA
        /// ///////////////////////////////////
        /// </summary>
        /// 

        //
        // MOSTRAR LISTA DE ALMACENES USUARIO
        public DataTable ListaAlmacenesUsuario(int usecod)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_ALMACENES_DAPRO", conex);
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

        //
        // MOSTRAR LISTA DE ALMACENES USUARIO
        public DataTable ListaAlmacenes()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ALMACENES_DAPROD", conex);
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

        // MOSTRAR LISTA DE ALMACENES USUARIO
        public DataTable ListaAlmacenesStock()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ALMACENES_STOCK", conex);
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

        // MOSTRAR LISTA DE PRODUCTO CON STOCK
        public DataTable ListaProductos()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PRODUCTOS_STOCK", conex);
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

        // MOSTRAR LISTA DE PRODUCTO TALLA CON STOCK
        public DataTable ListaProductosTalla()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PRODUCTOS_TALLA_STOCK", conex);
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

        // MOSTRAR LISTA DE DOCUMETO
        public DataTable ListaDocumento()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CARGAR_DOCUMENTO", conex);
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

        // MOSTRAR LISTA DE DOCUMETO SERIE
        public DataTable ListaDocumentoSerie(string codoc)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CARGAR_DOCUMENTO_SERIE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@TDOFAC", SqlDbType.Int).Value = codoc;
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


        /// 
        /// ////////////////////////////////////
        /// ////////////////////////////////////
        /// QUERY PARA LLAMAR FACTURA
        /// ///////////////////////////////////
        /// ///////////////////////////////////
        /// 
        /// 
        // MOSTRAR TODA LA LISTA DE PERFILES
        public DataTable EstadoFac()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ESTADO_FAC", conex);
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

        //BUSCAR FACTURA EN TABLA
        public DataTable BuscarFactura(int fac)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_FACTURA_PRUEBA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@fac", SqlDbType.Int).Value = fac;
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

        //BUSCAR VENTA FACTURA POR ORDEN
        public DataTable BuscarVentaSecuencia_Ord(int invnum)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_VENTA_MOVIMIENTO_ORD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = invnum;
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

        //BUSCAR MOVIMIENTO DETALLE EN TABLA
        public DataTable BuscarMovimientoDetalle(int fac)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_MOVIMIENTO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@fac", SqlDbType.Int).Value = fac;
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

        // METODO PARA BUSCAR FACTURA BOOL
        public bool BuscarFacturaText(int fac)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_FACTURA_TEXT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@fac", SqlDbType.Int).Value = fac;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.fac_buscar = reader.GetInt32(0);
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

        // METODO PARA BUSCAR FACTURA BOOL
        public bool BuscarSecuenciaOrdenParaMov(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SEC_ORDEN_VENTA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.fac_buscar = reader.GetInt32(0);
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


        // METODO PARA BUSCAR FACTURA BOOL
        public bool BuscarSecuenciaText(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_TEXT"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.sec_buscar = reader.GetInt32(0);
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

        // METODO PARA BUSCAR FACTURA MOVIMIENTO POR ORDEN
        public bool BuscarMovimientoOrdenText(int invnum)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_VENTA_MOVIMIENTO_POR_ORD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = invnum;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.invnum_buscar = reader.GetInt32(0);
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

        // METODO PARA BUSCAR FACTURA BOOL
        public bool BuscarSecuenciaMovimiento(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_MOVIMIENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.secmov_buscar = reader.GetInt32(0);
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

        //GUARDAR ORDEN COMPRA CABECERA
        public DataTable GuardarOrdenCompraCabecera(int sec, int docclient, string desclient, string codalm, decimal totpar,
            decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto, string estado,
            string coddoc, string sexclient, string doc_fa, string doc_ser, string doc_pag, string tarj_cod, int codcontac,
            string obs_fac, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ORDEN_COMPRA_CABECERA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                //comando.Parameters.AddWithValue("@numfac", SqlDbType.Int).Value = numfac;
                comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = sec;
                comando.Parameters.AddWithValue("@docclient", SqlDbType.Int).Value = docclient;
                comando.Parameters.AddWithValue("@desclient", SqlDbType.VarChar).Value = desclient;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;

                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@igv_par", SqlDbType.Decimal).Value = igv_par;
                comando.Parameters.AddWithValue("@brt_par", SqlDbType.Decimal).Value = totpar_brt;
                comando.Parameters.AddWithValue("@reb_par", SqlDbType.Decimal).Value = reb_par;
                comando.Parameters.AddWithValue("@pagcon", SqlDbType.Decimal).Value = pagcon;
                comando.Parameters.AddWithValue("@vuelto", SqlDbType.Decimal).Value = vuelto;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;

                comando.Parameters.AddWithValue("@coddoc", SqlDbType.VarChar).Value = coddoc;
                comando.Parameters.AddWithValue("@sexclient", SqlDbType.VarChar).Value = sexclient;
                comando.Parameters.AddWithValue("@doc_fa", SqlDbType.VarChar).Value = doc_fa;
                comando.Parameters.AddWithValue("@doc_ser", SqlDbType.VarChar).Value = doc_ser;
                comando.Parameters.AddWithValue("@doc_pag", SqlDbType.VarChar).Value = doc_pag;
                comando.Parameters.AddWithValue("@tarj_cod", SqlDbType.VarChar).Value = tarj_cod;
                comando.Parameters.AddWithValue("@codcontac", SqlDbType.Int).Value = codcontac;
                comando.Parameters.AddWithValue("@obs_fac", SqlDbType.VarChar).Value = obs_fac;

                comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = feccre;
                comando.Parameters.AddWithValue("@fecmov", SqlDbType.Date).Value = fecmov;
                comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                comando.Parameters.AddWithValue("@usereg", SqlDbType.Int).Value = userreg;
                comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ipcre;
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

        //GUARDAR ORDEN COMPRA DETALLE
        public DataTable GuardarOrdenCompraDetalle(int sec, int item, int docclient, string desclient, string codalm, string codpro,
            string despro, string marca, string talla, string genero, string color, int cantpro, decimal precio, decimal descpro, decimal igv, decimal totpar,
            decimal totpar_brt, string itmsta, decimal pordsc1, decimal pordsc2, string estado, decimal coscom, int stkalm,
            decimal qtypro_m, int qtysal, int qtysalm, string obsprod, DateTime feccre, DateTime fecmov, int siscod, int userreg,
            string usenamreg, string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ORDEN_COMPRA_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                //comando.Parameters.AddWithValue("@numfac", SqlDbType.Int).Value = numfac;
                comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = sec;
                comando.Parameters.AddWithValue("@numitm", SqlDbType.Int).Value = item;
                comando.Parameters.AddWithValue("@docclient", SqlDbType.Int).Value = docclient;
                comando.Parameters.AddWithValue("@desclient", SqlDbType.VarChar).Value = desclient;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@codpro", SqlDbType.VarChar).Value = codpro;
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;

                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@talla", SqlDbType.VarChar).Value = talla;
                comando.Parameters.AddWithValue("@genero", SqlDbType.VarChar).Value = genero;
                comando.Parameters.AddWithValue("@color", SqlDbType.VarChar).Value = color;
                comando.Parameters.AddWithValue("@cantpro", SqlDbType.Int).Value = cantpro;
                comando.Parameters.AddWithValue("@qtypro", SqlDbType.Decimal).Value = precio;
                comando.Parameters.AddWithValue("@descpro", SqlDbType.Decimal).Value = descpro;
                comando.Parameters.AddWithValue("@igv", SqlDbType.Decimal).Value = igv;

                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@brt_par", SqlDbType.Decimal).Value = totpar_brt;
                comando.Parameters.AddWithValue("@itmsta", SqlDbType.VarChar).Value = itmsta;
                comando.Parameters.AddWithValue("@pordsc1", SqlDbType.Decimal).Value = pordsc1;
                comando.Parameters.AddWithValue("@pordsc2", SqlDbType.Decimal).Value = pordsc2;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;

                comando.Parameters.AddWithValue("@coscom", SqlDbType.Int).Value = coscom;
                comando.Parameters.AddWithValue("@stkalm", SqlDbType.Int).Value = stkalm;
                comando.Parameters.AddWithValue("@qtypro_m", SqlDbType.Decimal).Value = qtypro_m;
                comando.Parameters.AddWithValue("@qtysal", SqlDbType.Decimal).Value = qtysal;
                comando.Parameters.AddWithValue("@qtysal_m", SqlDbType.Decimal).Value = qtysalm;
                comando.Parameters.AddWithValue("@obsprod", SqlDbType.Decimal).Value = obsprod;

                comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = feccre;
                comando.Parameters.AddWithValue("@fecmov", SqlDbType.Date).Value = fecmov;
                comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                comando.Parameters.AddWithValue("@usereg", SqlDbType.Int).Value = userreg;
                comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ipcre;
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

        //GUARDAR MOVIMIENTO CABECERA
        public DataTable GuardarMovimientosCabecera(int numfac, int sec, int docclient, string desclient, string codalm, decimal totpar,
            decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto, string estado,
            string coddoc, string sexclient, string doc_fa, string doc_ser, string doc_pag, string tarj_cod, int codcontac,
            string obs_fac, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_MOVIMIENTO_CABECERA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@numfac", SqlDbType.Int).Value = numfac;
                comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = sec;
                comando.Parameters.AddWithValue("@docclient", SqlDbType.Int).Value = docclient;
                comando.Parameters.AddWithValue("@desclient", SqlDbType.VarChar).Value = desclient;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;

                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@igv_par", SqlDbType.Decimal).Value = igv_par;
                comando.Parameters.AddWithValue("@brt_par", SqlDbType.Decimal).Value = totpar_brt;
                comando.Parameters.AddWithValue("@reb_par", SqlDbType.Decimal).Value = reb_par;
                comando.Parameters.AddWithValue("@pagcon", SqlDbType.Decimal).Value = pagcon;
                comando.Parameters.AddWithValue("@vuelto", SqlDbType.Decimal).Value = vuelto;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;

                comando.Parameters.AddWithValue("@coddoc", SqlDbType.VarChar).Value = coddoc;
                comando.Parameters.AddWithValue("@sexclient", SqlDbType.VarChar).Value = sexclient;
                comando.Parameters.AddWithValue("@doc_fa", SqlDbType.VarChar).Value = doc_fa;
                comando.Parameters.AddWithValue("@doc_ser", SqlDbType.VarChar).Value = doc_ser;
                comando.Parameters.AddWithValue("@doc_pag", SqlDbType.VarChar).Value = doc_pag;
                comando.Parameters.AddWithValue("@tarj_cod", SqlDbType.VarChar).Value = tarj_cod;
                comando.Parameters.AddWithValue("@codcontac", SqlDbType.Int).Value = codcontac;
                comando.Parameters.AddWithValue("@obs_fac", SqlDbType.VarChar).Value = obs_fac;

                comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = feccre;
                comando.Parameters.AddWithValue("@fecmov", SqlDbType.Date).Value = fecmov;
                comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                comando.Parameters.AddWithValue("@usereg", SqlDbType.Int).Value = userreg;
                comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ipcre;
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


        //GUARDAR ORDEN COMPRA DETALLE
        public DataTable GuardarMovimientoDetalle(int sec, int item, int docclient, string desclient, string codalm, string codpro,
            string despro, string marca, string talla, string genero, string color, int cantpro, decimal precio, decimal descpro, decimal igv, decimal totpar,
            decimal totpar_brt, string itmsta, decimal pordsc1, decimal pordsc2, string estado, decimal coscom, int stkalm,
            decimal qtypro_m, int qtysal, int qtysalm, string obsprod, DateTime feccre, DateTime fecmov, int siscod, int userreg,
            string usenamreg, string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_MOVIMIENTO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = sec;
                comando.Parameters.AddWithValue("@numitm", SqlDbType.Int).Value = item;
                comando.Parameters.AddWithValue("@docclient", SqlDbType.Int).Value = docclient;
                comando.Parameters.AddWithValue("@desclient", SqlDbType.VarChar).Value = desclient;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@codpro", SqlDbType.VarChar).Value = codpro;
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;

                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@talla", SqlDbType.VarChar).Value = talla;
                comando.Parameters.AddWithValue("@genero", SqlDbType.VarChar).Value = genero;
                comando.Parameters.AddWithValue("@color", SqlDbType.VarChar).Value = color;
                comando.Parameters.AddWithValue("@cantpro", SqlDbType.Int).Value = cantpro;
                comando.Parameters.AddWithValue("@qtypro", SqlDbType.Decimal).Value = precio;
                comando.Parameters.AddWithValue("@descpro", SqlDbType.Decimal).Value = descpro;
                comando.Parameters.AddWithValue("@igv", SqlDbType.Decimal).Value = igv;

                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@brt_par", SqlDbType.Decimal).Value = totpar_brt;
                comando.Parameters.AddWithValue("@itmsta", SqlDbType.VarChar).Value = itmsta;
                comando.Parameters.AddWithValue("@pordsc1", SqlDbType.Decimal).Value = pordsc1;
                comando.Parameters.AddWithValue("@pordsc2", SqlDbType.Decimal).Value = pordsc2;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;

                comando.Parameters.AddWithValue("@coscom", SqlDbType.Int).Value = coscom;
                comando.Parameters.AddWithValue("@stkalm", SqlDbType.Int).Value = stkalm;
                comando.Parameters.AddWithValue("@qtypro_m", SqlDbType.Decimal).Value = qtypro_m;
                comando.Parameters.AddWithValue("@qtysal", SqlDbType.Decimal).Value = qtysal;
                comando.Parameters.AddWithValue("@qtysal_m", SqlDbType.Decimal).Value = qtysalm;
                comando.Parameters.AddWithValue("@obsprod", SqlDbType.Decimal).Value = obsprod;

                comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = feccre;
                comando.Parameters.AddWithValue("@fecmov", SqlDbType.Date).Value = fecmov;
                comando.Parameters.AddWithValue("@siscod", SqlDbType.Int).Value = siscod;
                comando.Parameters.AddWithValue("@usereg", SqlDbType.Int).Value = userreg;
                comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ipcre;
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


        //BUSCAR PRODUCTO EN TABLA
        public DataTable BuscarProductoParaVenta(string despro, string codalm)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PRODUCTO_PARA_VENTA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
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

        //BUSCAR PRODUCTO PARA COMPRA EN TABLA
        public DataTable BuscarProductoParaCompra(string despro, string codalm)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PRODUCTO_PARA_COMPRA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
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

        // METODO PARA ELIMINAR FACTURA
        public void EliminarFactura(int sec)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_FACTURA_PRUEBA"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR FACTURA
        public void FacturarOrden(int sec)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_FACTURAR_ORDEN_PRUEBA"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR FACTURA MOVIMIENTO
        public void EliminarMovimiento(int fac)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_FACTURA_MOVIMIENTO"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@fac", SqlDbType.Int).Value = fac;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA BUSCAR DETALLE DE ORDEN VENTA
        public bool BuscarDatosVenta(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOSVENTA_ORDEN_COMPRA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.Almacen_busc = reader.GetString(0);
                            ce_datosventa.TipoDocumento_busc = reader.GetString(1);
                            ce_datosventa.SerieDocumento_busc = reader.GetString(2);
                            ce_datosventa.MedioContacto_busc = reader.GetInt32(3);

                            ce_datosventa.TipDocIdent_busc = reader.GetString(4);
                            ce_datosventa.DniCliente_busc = reader.GetInt32(5);
                            ce_datosventa.Cliente_busc = reader.GetString(6);
                            ce_datosventa.ClienteSexo_busc = reader.GetString(7);

                            ce_datosventa.TelefonoCliente_busc = reader.GetString(8);
                            ce_datosventa.Total_busc = reader.GetDecimal(9);
                            ce_datosventa.Igv_busc = reader.GetDecimal(10);
                            ce_datosventa.SubTotal_busc = reader.GetDecimal(11);

                            ce_datosventa.Rebaja_busc = reader.GetDecimal(12);
                            ce_datosventa.Pagacon_busc = reader.GetDecimal(13);
                            ce_datosventa.Vuelto_busc = reader.GetDecimal(14);
                            ce_datosventa.Observacion_busc = reader.GetString(15);

                            ce_datosventa.ApellidoCliente_busc = reader.GetString(16);
                            ce_datosventa.NombresCliente_busc = reader.GetString(17);
                            ce_datosventa.Dirección_busc = reader.GetString(18);
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

        //BuscarDatosVenta_PorOrden

        // METODO PARA BUSCAR DETALLE DE ORDEN VENTA
        public bool BuscarDatosVenta_PorOrden(int invnum)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOSVENTA_POR_ORDEN"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = invnum;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.Almacen_busc = reader.GetString(0);
                            ce_datosventa.TipoDocumento_busc = reader.GetString(1);
                            ce_datosventa.SerieDocumento_busc = reader.GetString(2);
                            ce_datosventa.MedioContacto_busc = reader.GetInt32(3);

                            ce_datosventa.TipDocIdent_busc = reader.GetString(4);
                            ce_datosventa.DniCliente_busc = reader.GetInt32(5);
                            ce_datosventa.Cliente_busc = reader.GetString(6);
                            ce_datosventa.ClienteSexo_busc = reader.GetString(7);

                            ce_datosventa.TelefonoCliente_busc = reader.GetString(8);
                            ce_datosventa.Total_busc = reader.GetDecimal(9);
                            ce_datosventa.Igv_busc = reader.GetDecimal(10);
                            ce_datosventa.SubTotal_busc = reader.GetDecimal(11);

                            ce_datosventa.Rebaja_busc = reader.GetDecimal(12);
                            ce_datosventa.Pagacon_busc = reader.GetDecimal(13);
                            ce_datosventa.Vuelto_busc = reader.GetDecimal(14);
                            ce_datosventa.Observacion_busc = reader.GetString(15);

                            ce_datosventa.ApellidoCliente_busc = reader.GetString(16);
                            ce_datosventa.NombresCliente_busc = reader.GetString(17);
                            ce_datosventa.Dirección_busc = reader.GetString(18);

                            ce_datosventa.TipoPago_Busc = reader.GetString(19);
                            ce_datosventa.TarjetaPago_Busc = reader.GetString(20);
                            ce_datosventa.Comentario_Busc = reader.GetString(21);
                            ce_datosventa.Secuencia_Busc = reader.GetInt32(22);

                            ce_datosventa.Factura_Busc = reader.GetInt32(23);
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

        // METODO PARA BUSCAR DETALLE DE MOVIMIENTO VENTA
        public bool BuscarDatosVentaMov(int fac)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOSVENTA_MOVIMIENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@fac", SqlDbType.Int).Value = fac;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.Almacen_busc = reader.GetString(0);
                            ce_datosventa.TipoDocumento_busc = reader.GetString(1);
                            ce_datosventa.SerieDocumento_busc = reader.GetString(2);
                            ce_datosventa.MedioContacto_busc = reader.GetInt32(3);

                            ce_datosventa.TipDocIdent_busc = reader.GetString(4);
                            ce_datosventa.DniCliente_busc = reader.GetInt32(5);
                            ce_datosventa.Cliente_busc = reader.GetString(6);
                            ce_datosventa.ClienteSexo_busc = reader.GetString(7);

                            ce_datosventa.TelefonoCliente_busc = reader.GetString(8);
                            ce_datosventa.Total_busc = reader.GetDecimal(9);
                            ce_datosventa.Igv_busc = reader.GetDecimal(10);
                            ce_datosventa.SubTotal_busc = reader.GetDecimal(11);

                            ce_datosventa.Rebaja_busc = reader.GetDecimal(12);
                            ce_datosventa.Pagacon_busc = reader.GetDecimal(13);
                            ce_datosventa.Vuelto_busc = reader.GetDecimal(14);
                            ce_datosventa.Observacion_busc = reader.GetString(15);

                            ce_datosventa.ApellidoCliente_busc = reader.GetString(16);
                            ce_datosventa.NombresCliente_busc = reader.GetString(17);
                            ce_datosventa.Dirección_busc = reader.GetString(18);

                            ce_datosventa.TipoPago_Busc = reader.GetString(19);
                            ce_datosventa.TarjetaPago_Busc = reader.GetString(20);
                            ce_datosventa.Comentario_Busc = reader.GetString(21);
                            ce_datosventa.Secuencia_Busc = reader.GetInt32(22);
                            ce_datosventa.Factura_Busc = reader.GetInt32(23);

                            ce_datosventa.Usr_Busc = reader.GetString(24);
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

        // METODO PARA LLAMAR LA ULTIMA FACTURA +1 FACTURA BOOL
        public bool UltimaFacturaText()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ULTIMA_FACTURA"))
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
                            ce_datosventa.Ult_NumFac = reader.GetInt32(0);
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

        // METODO PARA LLAMAR LA ULTIMA SECUENCIA + 1 FACTURA BOOL
        public bool UltimaSecuenciaText()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ULTIMA_SECUENCIA"))
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
                            ce_datosventa.Ult_Sec = reader.GetInt32(0);
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

        // METODO PARA LLAMAR LA ULTIMA FACTURA FACTURA BOOL
        public bool UltimaFacturaOrden()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ULTIMA_FACTURA_ORDEN"))
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
                            ce_datosventa.Ult_NumFac = reader.GetInt32(0);
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

        // METODO PARA LLAMAR LA ULTIMA SECUENCIA FACTURA BOOL
        public bool UltimaSecuenciaOrden()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ULTIMA_SECUENCIA_ORDEN"))
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
                            ce_datosventa.Ult_Sec = reader.GetInt32(0);
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

        // METODO PARA GUARDAR CLIENTE
        public void GuardarCliente(string codcli, string apellcli, string namcli, string tipdoc, string sexo,
            string pacobs, string apcdoc, string ubicod, string pactel, string pacdir, string estado, DateTime fec_cre,
            DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_CLIENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codcli", SqlDbType.VarChar).Value = codcli;
                    comando.Parameters.AddWithValue("@pacapell", SqlDbType.VarChar).Value = apellcli;
                    comando.Parameters.AddWithValue("@pacnam", SqlDbType.VarChar).Value = namcli;
                    comando.Parameters.AddWithValue("@tipdoc", SqlDbType.VarChar).Value = tipdoc;
                    comando.Parameters.AddWithValue("@sexcod", SqlDbType.VarChar).Value = sexo;

                    comando.Parameters.AddWithValue("@pacobs", SqlDbType.VarChar).Value = pacobs;
                    comando.Parameters.AddWithValue("@pacdoc", SqlDbType.VarChar).Value = apcdoc;
                    comando.Parameters.AddWithValue("@ubicod", SqlDbType.VarChar).Value = ubicod;
                    comando.Parameters.AddWithValue("@pactel", SqlDbType.VarChar).Value = pactel;
                    comando.Parameters.AddWithValue("@pacdir", SqlDbType.VarChar).Value = pacdir;

                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fec_mov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@userreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usernamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA GUARDAR CLIENTE
        public void ActualizarCliente(string codcli, string apellcli, string namcli, string tipdoc, string sexo,
            string pacobs, string apcdoc, string ubicod, string pactel, string pacdir, string estado,
            DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_CLIENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codcli", SqlDbType.VarChar).Value = codcli;
                    comando.Parameters.AddWithValue("@pacapell", SqlDbType.VarChar).Value = apellcli;
                    comando.Parameters.AddWithValue("@pacnam", SqlDbType.VarChar).Value = namcli;
                    comando.Parameters.AddWithValue("@tipdoc", SqlDbType.VarChar).Value = tipdoc;
                    comando.Parameters.AddWithValue("@sexcod", SqlDbType.VarChar).Value = sexo;

                    comando.Parameters.AddWithValue("@pacobs", SqlDbType.VarChar).Value = pacobs;
                    comando.Parameters.AddWithValue("@pacdoc", SqlDbType.VarChar).Value = apcdoc;
                    comando.Parameters.AddWithValue("@ubicod", SqlDbType.VarChar).Value = ubicod;
                    comando.Parameters.AddWithValue("@pactel", SqlDbType.VarChar).Value = pactel;
                    comando.Parameters.AddWithValue("@pacdir", SqlDbType.VarChar).Value = pacdir;

                    comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
                    //comando.Parameters.AddWithValue("@fec_cre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fec_mov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@userreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usernamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO BOOL PARA BUSCAR SI EXISTE PERONSAL
        public bool CodigoClienteMasUno()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CLIENTE_MAXIMO_MASUNO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    //comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_datosventa.Codigo_Cliente = reader.GetInt32(0);
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

        // MOSTRAR LISTA DE ORDENES PENDIENTES POR FACTURAR
        public DataTable ListaOrdenPendiente()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ORDENES_PENDIENTES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                //comando.Parameters.AddWithValue("@dni", SqlDbType.Int).Value = dni;
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

        // MOSTRAR LISTA DE ORDENES PENDIENTES POR FACTURAR USUARIO
        public DataTable ListaOrdenPendientePorUsuario(int user)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_ORDENES_PENDIENTES_POR_USUARIO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@user", SqlDbType.Int).Value = user;
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


        public static DataTable GetDataTable()
        {
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var conex = cd_conexion.CrearInstancia().leerconexion();

            try
            {
                conex.Open();
                cmd.Connection = conex;
                SqlCommand comando = new SqlCommand("SP_ORDENES_PENDIENTES", conex);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
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

    }
}
