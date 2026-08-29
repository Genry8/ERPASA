
using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_correo : cd_conexion
    {
        public bool BuscBuscarCorreo(int cod)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("SP_BUSCAR_DATOS_CORREO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = cod;
                    //comando.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_correo.codCorreo = reader.GetInt32(0);
                            ce_correo.fecha = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1);
                            ce_correo.empresa = reader.GetString(2);
                            ce_correo.sede = reader.GetString(3);
                            ce_correo.gerencia = reader.GetString(4);
                            ce_correo.area = reader.GetString(5);
                            ce_correo.responsable = reader.GetString(6);
                            ce_correo.formulario = reader.GetString(7);
                            ce_correo.tipocorreo = reader.GetString(8);
                            ce_correo.de = reader.GetString(9);
                            ce_correo.para = reader.GetString(10);
                            ce_correo.cc = reader.GetString(11);
                            ce_correo.asunto = reader.GetString(12);
                            ce_correo.cuerpo = reader.GetString(13);
                            //ce_correo.uuid = reader.GetString(14);
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

        public void GuardarActualizarDatosCorreo(
    int id,
    string de,
    string para,
    string cc,
    string asunto,
    string cuerpo,
    DateTime fecEdit,
    int useEdit)
        {
            using (var conexion = leerconexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_GUARDAR_ACTUALIZAR_CORREO", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    comando.Parameters.Add("@De", SqlDbType.VarChar).Value = de;
                    comando.Parameters.Add("@Para", SqlDbType.VarChar).Value = para;
                    comando.Parameters.Add("@CC", SqlDbType.VarChar).Value = cc;
                    comando.Parameters.Add("@Asunto", SqlDbType.VarChar).Value = asunto;
                    comando.Parameters.Add("@Cuerpo", SqlDbType.VarChar).Value = cuerpo;
                    comando.Parameters.Add("@FecEdit", SqlDbType.DateTime2).Value = fecEdit;
                    comando.Parameters.Add("@UseEdit", SqlDbType.Int).Value = useEdit;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }


    }
}