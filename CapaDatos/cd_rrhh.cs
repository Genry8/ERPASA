using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class cd_rrhh : cd_conexion
    {

        // MOSTRAR LISTA DE TIPO DE VISITA
        public DataTable ListaCBTipoVisitaRRHH()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PV_TIPOVISITA", conex);
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

        // MOSTRAR LISTA DE TIPO DOCUMENTO
        public DataTable ListaCBTipoDocumentoRRHH()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PV_TIPODOCUMENTO", conex);
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

        // MOSTRAR LISTA SEXO
        public DataTable ListaCBTipoSexoRRHH()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PV_TIPOSEXO", conex);
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

        // MOSTRAR LISTA SEXO
        public DataTable ListaCBNacionalidadRRHH()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_PV_TIPONACIONALIDAD", conex);
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
        //
        // VISITAS ESPERADAS
        //
        //
        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteVisita(int numident, DateTime fecvist)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_VISITA_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@NumIdent", SqlDbType.Int).Value = numident;
                    comando.Parameters.AddWithValue("@FecVist", SqlDbType.DateTime).Value = fecvist;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_rrhh.NumIdent = reader.GetInt32(0);
                            ce_rrhh.FecVist = reader.GetDateTime(1);
                            ce_rrhh.NomApe = reader.GetString(2);
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

        // METODO PARA GUARDAR USUARIO BI
        public void GuardarVisitaPV(string CodVist, int Item, string Empresa, string Sede, string Area, String TipDoc, int NumIdent, string Apellido,
            string Sexo, string Nacionalidad, string TipVisita, string Fotosheck, string Compañia, string MotVisita,
            DateTime FecVisita, byte FtshEnt, byte FtshDev, string Hr_Ing, string Hr_sal, string firmvisi, string firmsello_resp,
            string estado, DateTime feccre, int usereg, string hostname, DateTime fecedit, int Useedit)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_GUARDAR_VISITASPV"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@CodVist", SqlDbType.VarChar).Value = CodVist;
                    comando.Parameters.AddWithValue("@Item", SqlDbType.Int).Value = Item;
                    comando.Parameters.AddWithValue("@DesEmp", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@DesSed", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@DesArea", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@DesTDoc", SqlDbType.VarChar).Value = TipDoc;
                    comando.Parameters.AddWithValue("@Num_Ident", SqlDbType.Int).Value = NumIdent;
                    comando.Parameters.AddWithValue("@Ape", SqlDbType.VarChar).Value = Apellido;
                    comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = Sexo;
                    comando.Parameters.AddWithValue("@Nacionalidad", SqlDbType.VarChar).Value = Nacionalidad;
                    comando.Parameters.AddWithValue("@DesTVist", SqlDbType.VarChar).Value = TipVisita;
                    comando.Parameters.AddWithValue("@DesFtsh", SqlDbType.VarChar).Value = Fotosheck;
                    comando.Parameters.AddWithValue("@Compañia", SqlDbType.VarChar).Value = Compañia;
                    comando.Parameters.AddWithValue("@Motivo_Visita", SqlDbType.VarChar).Value = MotVisita;
                    comando.Parameters.AddWithValue("@FecVisita", SqlDbType.DateTime).Value = FecVisita;
                    comando.Parameters.AddWithValue("@FtshEnt", SqlDbType.Bit).Value = FtshEnt;
                    comando.Parameters.AddWithValue("@FtshDev", SqlDbType.Bit).Value = FtshDev;
                    comando.Parameters.AddWithValue("@Hr_Ing", SqlDbType.VarChar).Value = Hr_Ing;
                    comando.Parameters.AddWithValue("@Hr_Sal", SqlDbType.VarChar).Value = Hr_sal;
                    comando.Parameters.AddWithValue("@FirmaVisita", SqlDbType.VarChar).Value = firmvisi;
                    comando.Parameters.AddWithValue("@FirmSell_Resp", SqlDbType.VarChar).Value = firmsello_resp;
                    comando.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = estado;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = feccre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fecedit;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = Useedit;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // METODO PARA ACTUALIZAR USUARIO BI
        public void ActualizarVisitaPV(string codigo, string pagina, string comentario, int index)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_ACTUALIZAR_PAGINABI"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = codigo;
                    comando.Parameters.AddWithValue("@Pag", SqlDbType.VarChar).Value = pagina;
                    comando.Parameters.AddWithValue("@Obs", SqlDbType.VarChar).Value = comentario;
                    comando.Parameters.AddWithValue("@Ind", SqlDbType.Int).Value = index;

                    comando.ExecuteNonQuery();

                }
            }
        }

        // MOSTRAR LISTA DE USUARIOSBI
        public DataTable ListaVisitaPV(DateTime fechavini, DateTime fechavfin)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                SqlCommand comando = new SqlCommand("SP_MOSTRAR_VISITAS_PV", conex);
                comando.CommandType = CommandType.StoredProcedure;
                conex.Open();
                comando.Parameters.AddWithValue("@fechavisitainicio", SqlDbType.VarChar).Value = fechavini;
                comando.Parameters.AddWithValue("@fechavisitafin", SqlDbType.VarChar).Value = fechavfin;
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

        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE COLOR
        public bool BuscCodExisteVisitaMas()
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_VISITA_MAS"))
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
                            ce_rrhh.CodigoV = reader.GetString(0);
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
