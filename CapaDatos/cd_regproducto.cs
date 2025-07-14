using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_regproducto : cd_conexion
    {
        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaGrupoProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GRUPO_PRODUCTO", conex);
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

        // MOSTRAR LISTA DESCUENTO POR GRUPO PRODUCTO 
        public DataTable ListaGrupoProductoDescuento()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_GRUPO_PRODUCTO_PARA_DESC", conex);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaTipoProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TIPO_PRODUCTO", conex);
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

        // MOSTRAR LISTA DE GRUPO PRODUCTO
        public DataTable ListaTipoProductoDescuento()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TIPO_PRODUCTO_PARA_DESC", conex);
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

        // MOSTRAR LISTA DE MARCA PRODUCTO
        public DataTable ListaMarcaProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MARCA_PRODUCTO", conex);
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

        // MOSTRAR LISTA DE MARCA PRODUCTO
        public DataTable ListaMarcaProductoDescuento()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MARCA_PRODUCTO_PARA_DESC", conex);
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

        // MOSTRAR LISTA DE TALLA PRODUCTO
        public DataTable ListaTallaProducto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TALLA_PRODUCTO", conex);
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

        // MOSTRAR LISTA DE TALLA PRODUCTO
        public DataTable ListaTallaProductoDescuento()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_TALLA_PRODUCTO_PARA_DESC", conex);
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

        // MOSTRAR LISTA DE CONDICION PRODUCTO
        public DataTable ListaCondicion()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_EMPRESATI", conex);
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

        // MOSTRAR LISTA DE CONDICION PRODUCTO
        public DataTable ListaCondicionST()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_ST", conex);
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



        // MOSTRAR LISTA DE CONDICION PRODUCTO
        public DataTable ListaCondicionAlmacen()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CONDICION_ALMACEN", conex);
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

        // MOSTRAR LISTA DE MONEDA
        public DataTable ListaMoneda()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MONEDA", conex);
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

        // MOSTRAR CENTRO DE COSTO
        public DataTable ListaCentroCosto()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_CENTRO_COSTO", conex);
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

        // MOSTRAR LISTA DE PROVEEDORES
        public DataTable ListaProveedores()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PROVEEDORES", conex);
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

        // MOSTRAR LISTA DE PROVEEDORES
        public DataTable ListaFabricantes()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PRODUCTO_FABRICANTES", conex);
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

        // MOSTRAR LISTA DE FABRICANTES
        public DataTable ListaColores()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PRODUCTO_COLORES", conex);
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

        // MOSTRAR LISTA DE ABCDARIO
        public DataTable ListaABCDARIO()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PRODUCTO_ABC", conex);
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

        // METODO PARA BUSCAR PERSONAL POR DNI
        public bool BuscarProductoCpd(string codpro)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_PRODUCTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codpro", SqlDbType.Int).Value = codpro;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_regproducto.codpro = reader.GetInt32(0);
                            ce_regproducto.codgru = reader.GetString(1);
                            ce_regproducto.codtip = reader.GetString(2);
                            ce_regproducto.despro = reader.GetString(3);
                            ce_regproducto.despro_l = reader.GetString(4);
                            ce_regproducto.codprov = reader.GetString(5);
                            ce_regproducto.obsprod = reader.GetString(6);
                            ce_regproducto.comentpro = reader.GetString(7);
                            ce_regproducto.marcpro = reader.GetString(8);
                            ce_regproducto.tallpro = reader.GetString(9);
                            ce_regproducto.condprod = reader.GetString(10);
                            ce_regproducto.monpro = reader.GetString(11);
                            ce_regproducto.fabpro = reader.GetString(12);
                            ce_regproducto.cosprod = reader.GetDecimal(13);
                            ce_regproducto.imcompro = reader.GetDecimal(14);
                            ce_regproducto.imvenpro = reader.GetDecimal(15);
                            ce_regproducto.fracpro = reader.GetDecimal(16);
                            ce_regproducto.ultbspro = reader.GetDecimal(17);
                            ce_regproducto.descvenpro = reader.GetDecimal(18);
                            ce_regproducto.ultvtapro = reader.GetDecimal(19);
                            ce_regproducto.prefnpro = reader.GetDecimal(20);
                            ce_regproducto.cencospro = reader.GetString(21);
                            ce_regproducto.cosbspro = reader.GetDecimal(22);
                            ce_regproducto.coscmpro = reader.GetDecimal(23);
                            ce_regproducto.cosprpro = reader.GetDecimal(24);
                            ce_regproducto.stkpro = reader.GetInt32(25);
                            ce_regproducto.genpro = reader.GetString(26);
                            ce_regproducto.fampro = reader.GetString(27);
                            ce_regproducto.admpro = reader.GetString(28);
                            ce_regproducto.cantpro = reader.GetString(29);
                            ce_regproducto.abc = reader.GetString(30);
                            ce_regproducto.desabc = reader.GetString(31);
                            ce_regproducto.codabc = reader.GetString(32);

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


        // METODO BOOL PARA BUSCAR SI EXISTE PRODUCTO
        public bool BuscarPproductoExistente(string codpro)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_PRODUCTOL_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codpro", SqlDbType.VarChar).Value = codpro;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_regproducto.codproexiste = reader.GetInt32(0);
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
        public DataTable BuscarProductoRegistrado(string despro)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_BUSCAR_PRODUCTO_REGISTRADO", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
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


        // METODO PARA LLAMAR EL ULTIMO REGISTRO DE PRODUCTO
        public bool UltimoPorducto()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ULTIMO_PRODUCTO"))
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
                            ce_regproducto.codpromax = reader.GetInt32(0);
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
        // METODO PARA GUARDAR PRODUCTO DETALLADO
        public void GuardarProducto(int codpro, string codgru, string codtip, string despro, string despro_l, string codprov, string obsprod,
            string comentpro, string marcpro, string tallpro, string condpro, string monpro, string fabpro, decimal cospro, decimal impcompro,
             decimal impvenpro, decimal fracpro, decimal ultbspro, decimal descvenpro, decimal ultvtapro, decimal frac, decimal prefnpro, string cencos, decimal cosbspro,
             decimal coscmpro, decimal cosprpro, int stkpro, string genpro, string fampro, string admpro, int cantpro, string abc, string desabc,
             string codabc, DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_PRODUCTO_DETALLE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codpro", SqlDbType.Int).Value = codpro;
                    comando.Parameters.AddWithValue("@codgru", SqlDbType.VarChar).Value = codgru;
                    comando.Parameters.AddWithValue("@codtip", SqlDbType.VarChar).Value = codtip;
                    comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                    comando.Parameters.AddWithValue("@despro_l", SqlDbType.VarChar).Value = despro_l;
                    comando.Parameters.AddWithValue("@codprov", SqlDbType.VarChar).Value = codprov;
                    comando.Parameters.AddWithValue("@obsprod", SqlDbType.VarChar).Value = obsprod;

                    comando.Parameters.AddWithValue("@comentpro", SqlDbType.VarChar).Value = comentpro;
                    comando.Parameters.AddWithValue("@codmar", SqlDbType.VarChar).Value = marcpro;
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = tallpro;
                    comando.Parameters.AddWithValue("@condcod", SqlDbType.VarChar).Value = condpro;
                    comando.Parameters.AddWithValue("@monpro", SqlDbType.VarChar).Value = monpro;
                    comando.Parameters.AddWithValue("@fabpro", SqlDbType.VarChar).Value = fabpro;
                    comando.Parameters.AddWithValue("@cosprod", SqlDbType.Decimal).Value = cospro;
                    comando.Parameters.AddWithValue("@imcompro", SqlDbType.Decimal).Value = impcompro;

                    comando.Parameters.AddWithValue("@imvenpro", SqlDbType.Decimal).Value = impvenpro;
                    comando.Parameters.AddWithValue("@fracpro", SqlDbType.Decimal).Value = fracpro;
                    comando.Parameters.AddWithValue("@ultbspro", SqlDbType.Decimal).Value = ultbspro;
                    comando.Parameters.AddWithValue("@descvenpro", SqlDbType.Decimal).Value = descvenpro;
                    comando.Parameters.AddWithValue("@ultvtapro", SqlDbType.Decimal).Value = ultvtapro;
                    comando.Parameters.AddWithValue("@frac", SqlDbType.Decimal).Value = frac;
                    comando.Parameters.AddWithValue("@prefnpro", SqlDbType.Decimal).Value = prefnpro;
                    comando.Parameters.AddWithValue("@cencospro", SqlDbType.VarChar).Value = cencos;
                    comando.Parameters.AddWithValue("@cosbspro", SqlDbType.Decimal).Value = cosbspro;

                    comando.Parameters.AddWithValue("@coscmpro", SqlDbType.Decimal).Value = coscmpro;
                    comando.Parameters.AddWithValue("@cosprpro", SqlDbType.Decimal).Value = cosprpro;
                    comando.Parameters.AddWithValue("@stkpro", SqlDbType.Int).Value = stkpro;
                    comando.Parameters.AddWithValue("@genpro", SqlDbType.VarChar).Value = genpro;
                    comando.Parameters.AddWithValue("@fampro", SqlDbType.VarChar).Value = fampro;
                    comando.Parameters.AddWithValue("@admpro", SqlDbType.VarChar).Value = admpro;
                    comando.Parameters.AddWithValue("@cantpro", SqlDbType.VarChar).Value = cantpro;
                    comando.Parameters.AddWithValue("@abc", SqlDbType.VarChar).Value = abc;

                    comando.Parameters.AddWithValue("@desabc", SqlDbType.VarChar).Value = desabc;
                    comando.Parameters.AddWithValue("@codabc", SqlDbType.VarChar).Value = codabc;
                    comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        // METODO PARA ACTUALIZAR PRODUCTO DETALLADO
        public void ActualizarProducto(int codpro, string codgru, string codtip, string despro, string despro_l, string codprov, string obsprod,
            string comentpro, string marcpro, string tallpro, string condpro, string monpro, string fabpro, decimal cospro, decimal impcompro,
             decimal impvenpro, decimal fracpro, decimal frac, decimal ultbspro, decimal descvenpro, decimal ultvtapro, decimal prefnpro, string cencos, decimal cosbspro,
             decimal coscmpro, decimal cosprpro, int stkpro, string genpro, string fampro, string admpro, int cantpro, string abc, string desabc,
             string codabc, DateTime fec_mov)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PRODUCTO_DETALLE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codpro", SqlDbType.Int).Value = codpro;
                    comando.Parameters.AddWithValue("@codgru", SqlDbType.VarChar).Value = codgru;
                    comando.Parameters.AddWithValue("@codtip", SqlDbType.VarChar).Value = codtip;
                    comando.Parameters.AddWithValue("@despro", SqlDbType.VarChar).Value = despro;
                    comando.Parameters.AddWithValue("@despro_l", SqlDbType.VarChar).Value = despro_l;
                    comando.Parameters.AddWithValue("@codprov", SqlDbType.VarChar).Value = codprov;
                    comando.Parameters.AddWithValue("@obsprod", SqlDbType.VarChar).Value = obsprod;

                    comando.Parameters.AddWithValue("@comentpro", SqlDbType.VarChar).Value = comentpro;
                    comando.Parameters.AddWithValue("@codmar", SqlDbType.VarChar).Value = marcpro;
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = tallpro;
                    comando.Parameters.AddWithValue("@condcod", SqlDbType.VarChar).Value = condpro;
                    comando.Parameters.AddWithValue("@monpro", SqlDbType.VarChar).Value = monpro;
                    comando.Parameters.AddWithValue("@fabpro", SqlDbType.VarChar).Value = fabpro;
                    comando.Parameters.AddWithValue("@cosprod", SqlDbType.Decimal).Value = cospro;
                    comando.Parameters.AddWithValue("@imcompro", SqlDbType.Decimal).Value = impcompro;

                    comando.Parameters.AddWithValue("@imvenpro", SqlDbType.Decimal).Value = impvenpro;
                    comando.Parameters.AddWithValue("@fracpro", SqlDbType.Decimal).Value = fracpro;
                    comando.Parameters.AddWithValue("@frac", SqlDbType.Decimal).Value = frac;
                    comando.Parameters.AddWithValue("@ultbspro", SqlDbType.Decimal).Value = ultbspro;
                    comando.Parameters.AddWithValue("@descvenpro", SqlDbType.Decimal).Value = descvenpro;
                    comando.Parameters.AddWithValue("@ultvtapro", SqlDbType.Decimal).Value = ultvtapro;
                    comando.Parameters.AddWithValue("@prefnpro", SqlDbType.Decimal).Value = prefnpro;
                    comando.Parameters.AddWithValue("@cencospro", SqlDbType.VarChar).Value = cencos;
                    comando.Parameters.AddWithValue("@cosbspro", SqlDbType.Decimal).Value = cosbspro;

                    comando.Parameters.AddWithValue("@coscmpro", SqlDbType.Decimal).Value = coscmpro;
                    comando.Parameters.AddWithValue("@cosprpro", SqlDbType.Decimal).Value = cosprpro;
                    comando.Parameters.AddWithValue("@stkpro", SqlDbType.Int).Value = stkpro;
                    comando.Parameters.AddWithValue("@genpro", SqlDbType.VarChar).Value = genpro;
                    comando.Parameters.AddWithValue("@fampro", SqlDbType.VarChar).Value = fampro;
                    comando.Parameters.AddWithValue("@admpro", SqlDbType.VarChar).Value = admpro;
                    comando.Parameters.AddWithValue("@cantpro", SqlDbType.VarChar).Value = cantpro;
                    comando.Parameters.AddWithValue("@abc", SqlDbType.VarChar).Value = abc;

                    comando.Parameters.AddWithValue("@desabc", SqlDbType.VarChar).Value = desabc;
                    comando.Parameters.AddWithValue("@codabc", SqlDbType.VarChar).Value = codabc;
                    //comando.Parameters.AddWithValue("@feccre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@fecmov", SqlDbType.DateTime).Value = fec_mov;
                    //comando.Parameters.AddWithValue("@usecodreg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@usenamreg", SqlDbType.VarChar).Value = usenamreg;
                    //comando.Parameters.AddWithValue("@hostname", SqlDbType.VarChar).Value = hostname;
                    //comando.Parameters.AddWithValue("@ip_cre", SqlDbType.VarChar).Value = ip_pc;
                    comando.ExecuteNonQuery();

                }
            }
        }

        //
        // METODO PARA ELIMINAR REGISTRO POR PRODUCTO
        public void EliminarProducto(string codpro)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ELIMINAR_PRODUCTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codpro", SqlDbType.VarChar).Value = codpro;
                    comando.ExecuteNonQuery();
                }
            }

        }


        // METODO PARA ACTUALIZAR DESCUENTO A PRODUCTOS
        public void GuardarDescuentoDeProductos(string codgru, string codmar, string codtall, decimal desc)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_PRODUCTO_DESCUENTO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@codgru", SqlDbType.VarChar).Value = codgru;
                    comando.Parameters.AddWithValue("@codmar", SqlDbType.VarChar).Value = codmar;
                    comando.Parameters.AddWithValue("@codtall", SqlDbType.VarChar).Value = codtall;
                    comando.Parameters.AddWithValue("@desc", SqlDbType.Decimal).Value = desc;
                    comando.ExecuteNonQuery();
                }
            }

        }


    }
}
