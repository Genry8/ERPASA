using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_compraproducto : cd_conexion
    {
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
        // MOSTRAR LISTA DE PROVVEDORES
        public DataTable ListaTipoOrden()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_TIPO_ORDEN", conex);
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
        // MOSTRAR LISTA DE PROVVEDORES
        public DataTable ListaProveedores()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_PROVEEDORES", conex);
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
        // MOSTRAR LISTA CONDICION COSTO COMPRA
        public DataTable ListaCondicionCompra()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_LISTA_CONDICION_COSTO_COMPRA", conex);
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

        // METODO PARA BUSCAR SECUENCIA DE ORDEN COMRA
        public bool BuscarSecuenciaOrden(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_ORDEN_COMPRA"))
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
                            ce_compraproducto.invnum_ordpro = reader.GetInt32(0);
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

        // METODO PARA BUSCAR SECUENCIA DE ORDEN COMRA
        public bool BuscarCompraProducto_Ord()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_ORDEN_COMPRA"))
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
                            ce_compraproducto.invnum_ordpro = reader.GetInt32(0);
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

        //BuscarCompraProductoOrden
        // METODO PARA BUSCAR SECUENCIA DE ORDEN DE COMRA PRODUCTO
        public bool BuscarCompraProductoOrden(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_ORDEN_EN_COMPRA_PRODUCTO"))
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
                            ce_compraproducto.invnum_sec_ordpro = reader.GetInt32(0);
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

        // METODO PARA BUSCAR SECUENCIA DE ORDEN ULTIMO
        public bool BuscarSecuenciaOrden_Ultimo()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_ORDEN_COMPRA_PRODUCTO"))
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
                            ce_compraproducto.invnum_ordpro_ultimo = reader.GetInt32(0);
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

        // METODO PARA BUSCAR SECUENCIA DE COMPRA PRODUCTO
        public bool BuscarSecuenciaCompraProducto(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_COMPRA_PODUCTO"))
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
                            ce_compraproducto.invnum_prod = reader.GetInt32(0);
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

        // METODO PARA BUSCAR SECUENCIA DE ORDEN +1
        public bool BuscarSecuenciaOrden_mas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_ORDEN_COMPRA_MAS1"))
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
                            ce_compraproducto.invnum_ordpro_mas = reader.GetInt32(0);
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


        // METODO PARA BUSCAR SECUENCIA DE COMPRA PRODUCTO + 1
        public bool BuscarSecuenciaCompraProducto_mas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_SECUENCIA_COMPRA_PRODUCTO_MAS1"))
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
                            ce_compraproducto.invnum_prod_mas = reader.GetInt32(0);
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

        //GUARDAR ORDEN COMPRA PRODUCTO CABECERA
        public DataTable GuardarCompraProductoCabecera(int invnum, int ordsec, string tipord, string codalm, string codprov, string codtcos,
            string codarea, DateTime fecvig, string tippago, string tipdoc, string numdoc1, string numdoc2, string medcont, string moneda, DateTime feccom, DateTime fecentr,
            int plazo_d, string coment, decimal totpar, decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto,
            decimal envio, string itmsta,
            string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_COMPRA_PRODUCTO_CABECERA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();

                comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = invnum;
                comando.Parameters.AddWithValue("@ordsec", SqlDbType.Int).Value = ordsec;
                comando.Parameters.AddWithValue("@tipord", SqlDbType.VarChar).Value = tipord;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@codprov", SqlDbType.VarChar).Value = codprov;
                comando.Parameters.AddWithValue("@codtcos", SqlDbType.VarChar).Value = codtcos;

                comando.Parameters.AddWithValue("@codarea", SqlDbType.VarChar).Value = codarea;
                comando.Parameters.AddWithValue("@fecvig", SqlDbType.DateTime).Value = fecvig;
                comando.Parameters.AddWithValue("@tip_pag", SqlDbType.VarChar).Value = tippago;
                comando.Parameters.AddWithValue("@tipdoc", SqlDbType.VarChar).Value = tipdoc;
                comando.Parameters.AddWithValue("@numdoc1", SqlDbType.VarChar).Value = numdoc1;
                comando.Parameters.AddWithValue("@numdoc2", SqlDbType.VarChar).Value = numdoc2;
                comando.Parameters.AddWithValue("@med_cont", SqlDbType.Int).Value = medcont;

                comando.Parameters.AddWithValue("@moneda", SqlDbType.VarChar).Value = moneda;
                comando.Parameters.AddWithValue("@feccomp", SqlDbType.DateTime).Value = feccom;
                comando.Parameters.AddWithValue("@fecentr", SqlDbType.DateTime).Value = fecentr;
                comando.Parameters.AddWithValue("@plazo_d", SqlDbType.Int).Value = plazo_d;
                comando.Parameters.AddWithValue("@coment", SqlDbType.VarChar).Value = coment;
                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@tot_igv", SqlDbType.Decimal).Value = igv_par;
                comando.Parameters.AddWithValue("@tot_brt", SqlDbType.Decimal).Value = totpar_brt;

                comando.Parameters.AddWithValue("@reb_par", SqlDbType.Decimal).Value = reb_par;
                comando.Parameters.AddWithValue("@pag_con", SqlDbType.Decimal).Value = pagcon;
                comando.Parameters.AddWithValue("@vuelto", SqlDbType.Decimal).Value = vuelto;
                comando.Parameters.AddWithValue("@c_envio", SqlDbType.Decimal).Value = envio;
                comando.Parameters.AddWithValue("@itmsta", SqlDbType.VarChar).Value = itmsta;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;

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

        //GUARDAR ORDEN COMPRA PRODUCTO CABECERA
        public DataTable GuardarOrdenCompraCabecera(int ordsec, string tipord, string codalm, string codprov, string codtcos,
            string codarea, DateTime fecvig, string tippago, string tiptarj, string medcont, string moneda, DateTime feccom, DateTime fecentr,
            int plazo_d, string coment, decimal totpar, decimal igv_par, decimal totpar_brt, decimal reb_par, decimal pagcon, decimal vuelto,
            decimal envio, string itmsta,
            string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg, string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ORDEN_COMPRA_PRODUCTO_CABECERA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();

                comando.Parameters.AddWithValue("@ordsec", SqlDbType.Int).Value = ordsec;
                comando.Parameters.AddWithValue("@tipord", SqlDbType.VarChar).Value = tipord;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@codprov", SqlDbType.VarChar).Value = codprov;
                comando.Parameters.AddWithValue("@codtcos", SqlDbType.VarChar).Value = codtcos;

                comando.Parameters.AddWithValue("@codarea", SqlDbType.VarChar).Value = codarea;
                comando.Parameters.AddWithValue("@fecvig", SqlDbType.DateTime).Value = fecvig;
                comando.Parameters.AddWithValue("@tip_pag", SqlDbType.VarChar).Value = tippago;
                comando.Parameters.AddWithValue("@tip_tarj", SqlDbType.VarChar).Value = tiptarj;
                comando.Parameters.AddWithValue("@med_cont", SqlDbType.Int).Value = medcont;

                comando.Parameters.AddWithValue("@moneda", SqlDbType.VarChar).Value = moneda;
                comando.Parameters.AddWithValue("@feccomp", SqlDbType.DateTime).Value = feccom;
                comando.Parameters.AddWithValue("@fecentr", SqlDbType.DateTime).Value = fecentr;
                comando.Parameters.AddWithValue("@plazo_d", SqlDbType.Int).Value = plazo_d;
                comando.Parameters.AddWithValue("@coment", SqlDbType.VarChar).Value = coment;
                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@tot_igv", SqlDbType.Decimal).Value = igv_par;
                comando.Parameters.AddWithValue("@tot_brt", SqlDbType.Decimal).Value = totpar_brt;

                comando.Parameters.AddWithValue("@reb_par", SqlDbType.Decimal).Value = reb_par;
                comando.Parameters.AddWithValue("@pag_con", SqlDbType.Decimal).Value = pagcon;
                comando.Parameters.AddWithValue("@vuelto", SqlDbType.Decimal).Value = vuelto;
                comando.Parameters.AddWithValue("@c_envio", SqlDbType.Decimal).Value = envio;
                comando.Parameters.AddWithValue("@itmsta", SqlDbType.VarChar).Value = itmsta;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;

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

        //GUARDAR ORDEN COMPRA PRODUCTO DETALLE
        public DataTable GuardarCompraProductoDetalle(int secord, int numitm, string tipord, string codalm, string codprov, string codarea,
            string codpro, string despro, string marca, string genero, string talla, string color, int stock_e, decimal stock_K, int cant_e, decimal cant_K, decimal qtypro,
            decimal desc1, decimal desc2, decimal desc3, decimal igv, decimal totpar, decimal totpar_brt, decimal cos_com, decimal bas_com, decimal prec_com,
            decimal parcial, string obsprod, string itmsta, string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg,
            string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_COMPRA_PRODUCTO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@secord", SqlDbType.Int).Value = secord;
                comando.Parameters.AddWithValue("@numitm", SqlDbType.Int).Value = numitm;
                comando.Parameters.AddWithValue("@tipord", SqlDbType.VarChar).Value = tipord;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@codprov", SqlDbType.VarChar).Value = codprov;
                comando.Parameters.AddWithValue("@codarea", SqlDbType.VarChar).Value = codarea;

                comando.Parameters.AddWithValue("@codpro", SqlDbType.VarChar).Value = codpro;
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@genero", SqlDbType.VarChar).Value = genero;
                comando.Parameters.AddWithValue("@talla", SqlDbType.VarChar).Value = talla;
                comando.Parameters.AddWithValue("@color", SqlDbType.VarChar).Value = color;

                comando.Parameters.AddWithValue("@stock_e", SqlDbType.Int).Value = stock_e;
                comando.Parameters.AddWithValue("@stock_k", SqlDbType.Decimal).Value = stock_K;
                comando.Parameters.AddWithValue("@cant_e", SqlDbType.Int).Value = cant_e;
                comando.Parameters.AddWithValue("@cant_k", SqlDbType.Decimal).Value = cant_K;
                comando.Parameters.AddWithValue("@qtypro", SqlDbType.Decimal).Value = qtypro;

                comando.Parameters.AddWithValue("@desc1", SqlDbType.Decimal).Value = desc1;
                comando.Parameters.AddWithValue("@desc2", SqlDbType.Decimal).Value = desc2;
                comando.Parameters.AddWithValue("@desc3", SqlDbType.Decimal).Value = desc3;
                comando.Parameters.AddWithValue("@igv", SqlDbType.Decimal).Value = igv;

                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@brt_par", SqlDbType.Decimal).Value = totpar_brt;
                comando.Parameters.AddWithValue("@cos_com", SqlDbType.Decimal).Value = cos_com;
                comando.Parameters.AddWithValue("@bas_com", SqlDbType.Decimal).Value = bas_com;
                comando.Parameters.AddWithValue("@prec_com", SqlDbType.Decimal).Value = prec_com;
                comando.Parameters.AddWithValue("@parcial", SqlDbType.Decimal).Value = parcial;
                comando.Parameters.AddWithValue("@obsprod", SqlDbType.VarChar).Value = obsprod;

                comando.Parameters.AddWithValue("@itmsta", SqlDbType.VarChar).Value = itmsta;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
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

        //GUARDAR ORDEN COMPRA PRODUCTO DETALLE
        public DataTable GuardarOrdenCompraDetalle(int ordsec, int numitm, string tipord, string codalm, string codprov, string codarea,
            string codpro, string despro, string marca, string genero, string talla, string color, int stock_e, decimal stock_K, int cant_e, decimal cant_K, decimal qtypro,
            decimal desc1, decimal desc2, decimal desc3, decimal igv, decimal totpar, decimal totpar_brt, decimal cos_com, decimal bas_com, decimal prec_com,
            decimal parcial, string obsprod, string itmsta, string estado, DateTime feccre, DateTime fecmov, int siscod, int userreg, string usenamreg,
            string hostname, string ipcre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_ORDEN_COMPRA_PRODUCTO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@ordsec", SqlDbType.Int).Value = ordsec;
                comando.Parameters.AddWithValue("@numitm", SqlDbType.Int).Value = numitm;
                comando.Parameters.AddWithValue("@tipord", SqlDbType.VarChar).Value = tipord;
                comando.Parameters.AddWithValue("@codalm", SqlDbType.VarChar).Value = codalm;
                comando.Parameters.AddWithValue("@codprov", SqlDbType.VarChar).Value = codprov;
                comando.Parameters.AddWithValue("@codarea", SqlDbType.VarChar).Value = codarea;

                comando.Parameters.AddWithValue("@codpro", SqlDbType.VarChar).Value = codpro;
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                comando.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
                comando.Parameters.AddWithValue("@genero", SqlDbType.VarChar).Value = genero;
                comando.Parameters.AddWithValue("@talla", SqlDbType.VarChar).Value = talla;
                comando.Parameters.AddWithValue("@color", SqlDbType.VarChar).Value = color;

                comando.Parameters.AddWithValue("@stock_e", SqlDbType.Int).Value = stock_e;
                comando.Parameters.AddWithValue("@stock_k", SqlDbType.Decimal).Value = stock_K;
                comando.Parameters.AddWithValue("@cant_e", SqlDbType.Int).Value = cant_e;
                comando.Parameters.AddWithValue("@cant_k", SqlDbType.Decimal).Value = cant_K;
                comando.Parameters.AddWithValue("@qtypro", SqlDbType.Decimal).Value = qtypro;

                comando.Parameters.AddWithValue("@desc1", SqlDbType.Decimal).Value = desc1;
                comando.Parameters.AddWithValue("@desc2", SqlDbType.Decimal).Value = desc2;
                comando.Parameters.AddWithValue("@desc3", SqlDbType.Decimal).Value = desc3;
                comando.Parameters.AddWithValue("@igv", SqlDbType.Decimal).Value = igv;

                comando.Parameters.AddWithValue("@tot_par", SqlDbType.Decimal).Value = totpar;
                comando.Parameters.AddWithValue("@brt_par", SqlDbType.Decimal).Value = totpar_brt;
                comando.Parameters.AddWithValue("@cos_com", SqlDbType.Decimal).Value = cos_com;
                comando.Parameters.AddWithValue("@bas_com", SqlDbType.Decimal).Value = bas_com;
                comando.Parameters.AddWithValue("@prec_com", SqlDbType.Decimal).Value = prec_com;
                comando.Parameters.AddWithValue("@parcial", SqlDbType.Decimal).Value = parcial;
                comando.Parameters.AddWithValue("@obsprod", SqlDbType.VarChar).Value = obsprod;

                comando.Parameters.AddWithValue("@itmsta", SqlDbType.VarChar).Value = itmsta;
                comando.Parameters.AddWithValue("@estado", SqlDbType.VarChar).Value = estado;
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


        //BUSCAR ORDEN DE COMPRA EN TABLA
        public DataTable BuscarOrdenCompra(int sec)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_ORDEN_COMPRA", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
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
        //BUSCAR ORDEN DE COMPRA EN TABLA
        public DataTable BuscarCompraProducto_ord(int sec)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_COMPRA_PRODUCTO_DETALLE_POR_ORD", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = sec;
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


        // METODO PARA BUSCAR DETALLE DE ORDEN COMPRA
        public bool BuscarDatosCompraProducto_ord(int secord)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOS_COMPRA_PRODUCTO_POR_ORD"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = secord;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_compraproducto.secuencia_busc = reader.GetInt32(0);
                            ce_compraproducto.TipoOrden_busc = reader.GetString(1);
                            ce_compraproducto.Almacen_busc = reader.GetString(2);
                            ce_compraproducto.Proveedor_busc = reader.GetString(3);

                            ce_compraproducto.TipoCosto_busc = reader.GetString(4);
                            ce_compraproducto.Area_busc = reader.GetString(5);
                            ce_compraproducto.FechaVigencia_busc = reader.GetDateTime(6);
                            ce_compraproducto.TipoPago_Busc = reader.GetString(7);

                            ce_compraproducto.TipoDocumento_Busc = reader.GetString(8);
                            ce_compraproducto.MedioContacto_busc = reader.GetInt32(9);
                            ce_compraproducto.Moneda_Busc = reader.GetString(10);
                            ce_compraproducto.FechaCompra_busc = reader.GetDateTime(11);
                            ce_compraproducto.FechaEntrega_busc = reader.GetDateTime(12);
                            ce_compraproducto.DiasPlazo_busc = reader.GetInt32(13);
                            ce_compraproducto.Observaciones_busc = reader.GetString(14);

                            ce_compraproducto.Total_busc = reader.GetDecimal(15);
                            ce_compraproducto.Igv_busc = reader.GetDecimal(16);
                            ce_compraproducto.SubTotal_busc = reader.GetDecimal(17);
                            ce_compraproducto.rebaja_pagar_busc = reader.GetDecimal(18);
                            ce_compraproducto.Pagacon_busc = reader.GetDecimal(19);
                            ce_compraproducto.Vuelto_busc = reader.GetDecimal(20);

                            ce_compraproducto.CosEnvio_busc = reader.GetDecimal(21);
                            ce_compraproducto.Documento1_busc = reader.GetString(22);
                            ce_compraproducto.Documento2_busc = reader.GetString(23);
                            ce_compraproducto.factura_busc = reader.GetInt32(24);
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

        // METODO PARA BUSCAR DETALLE DE ORDEN COMPRA
        public bool BuscarDatosOrdenCompra(int sec)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOS_ORDEN_COMPRA_PRODUCTO"))
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
                            ce_compraproducto.secuencia_busc = reader.GetInt32(0);
                            ce_compraproducto.TipoOrden_busc = reader.GetString(1);
                            ce_compraproducto.Almacen_busc = reader.GetString(2);
                            ce_compraproducto.Proveedor_busc = reader.GetString(3);

                            ce_compraproducto.TipoCosto_busc = reader.GetString(4);
                            ce_compraproducto.Area_busc = reader.GetString(5);
                            ce_compraproducto.FechaVigencia_busc = reader.GetDateTime(6);
                            ce_compraproducto.TipoPago_Busc = reader.GetString(7);

                            ce_compraproducto.TarjetaPago_Busc = reader.GetString(8);
                            ce_compraproducto.MedioContacto_busc = reader.GetInt32(9);
                            ce_compraproducto.Moneda_Busc = reader.GetString(10);
                            ce_compraproducto.FechaCompra_busc = reader.GetDateTime(11);
                            ce_compraproducto.FechaEntrega_busc = reader.GetDateTime(12);
                            ce_compraproducto.DiasPlazo_busc = reader.GetInt32(13);
                            ce_compraproducto.Observaciones_busc = reader.GetString(14);

                            ce_compraproducto.Total_busc = reader.GetDecimal(15);
                            ce_compraproducto.Igv_busc = reader.GetDecimal(16);
                            ce_compraproducto.SubTotal_busc = reader.GetDecimal(17);
                            ce_compraproducto.rebaja_pagar_busc = reader.GetDecimal(18);
                            ce_compraproducto.Pagacon_busc = reader.GetDecimal(19);
                            ce_compraproducto.Vuelto_busc = reader.GetDecimal(20);
                            ce_compraproducto.CosEnvio_busc = reader.GetDecimal(21);
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


        //BUSCAR COMPRA PRODUCTO DETALLE EN TABLA
        public DataTable BuscarCompraProductoDetalle(int fac)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_COMPRA_PRODUCTO_DETALLE", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = fac;
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

        // METODO PARA BUSCAR DETALLE DE ORDEN COMPRA
        public bool BuscarDatosCompraProducto(int invnum)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOS_COMPRA_PRODUCTO"))
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
                            ce_compraproducto.factura_busc = reader.GetInt32(0);
                            ce_compraproducto.TipoOrden_busc = reader.GetString(1);
                            ce_compraproducto.Almacen_busc = reader.GetString(2);
                            ce_compraproducto.Proveedor_busc = reader.GetString(3);

                            ce_compraproducto.TipoCosto_busc = reader.GetString(4);
                            ce_compraproducto.Area_busc = reader.GetString(5);
                            ce_compraproducto.FechaVigencia_busc = reader.GetDateTime(6);
                            ce_compraproducto.TipoPago_Busc = reader.GetString(7);

                            ce_compraproducto.TipoDocumento_Busc = reader.GetString(8);
                            ce_compraproducto.MedioContacto_busc = reader.GetInt32(9);
                            ce_compraproducto.Moneda_Busc = reader.GetString(10);
                            ce_compraproducto.FechaCompra_busc = reader.GetDateTime(11);
                            ce_compraproducto.FechaEntrega_busc = reader.GetDateTime(12);
                            ce_compraproducto.DiasPlazo_busc = reader.GetInt32(13);
                            ce_compraproducto.Observaciones_busc = reader.GetString(14);

                            ce_compraproducto.Total_busc = reader.GetDecimal(15);
                            ce_compraproducto.Igv_busc = reader.GetDecimal(16);
                            ce_compraproducto.SubTotal_busc = reader.GetDecimal(17);
                            ce_compraproducto.rebaja_pagar_busc = reader.GetDecimal(18);
                            ce_compraproducto.Pagacon_busc = reader.GetDecimal(19);
                            ce_compraproducto.Vuelto_busc = reader.GetDecimal(20);

                            ce_compraproducto.Documento1_busc = reader.GetString(21);
                            ce_compraproducto.Documento2_busc = reader.GetString(22);
                            ce_compraproducto.secuencia_busc = reader.GetInt32(23);
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
        public void EliminarOrdenCompraProducto(int sec)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_ORDEN_COMPRA_PRODUCTO"))
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
        public void EliminarCompraProducto(int invnum)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_COMPRA_PRODUCTO"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@invnum", SqlDbType.Int).Value = invnum;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR COMPRA PRODUCTO DETALLE
        public void EliminarCompraProductoDetalle(int secord)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ELIMINAR_COMPRA_PRODUCTO_DETALLE"))
                {

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = secord;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA ELIMINAR COMPRA PRODUCTO DETALLE
        public void FacturarOrdenCompraProducto(int secord)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_FACTURAR_ORDEN_COMPRA_PRODUCTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@sec", SqlDbType.Int).Value = secord;
                    comando.ExecuteNonQuery();

                }
            }

        }

        //
    }
}
