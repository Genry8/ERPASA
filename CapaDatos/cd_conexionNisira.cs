using System.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_conexionNisira
    {
        private readonly string conexionstring;
        private static cd_conexionNisira con = null; // Crear la conexion
        public cd_conexionNisira()
        {

            string srtserver = ConfigurationManager.AppSettings["136.248.243.17"];

            conexionstring = "server=" + "136.248.243.17" + ";DataBase=SANTAAZUL2018; Integrated Security = false; uid=nisira; pwd=Nisir@2024.Peru";

            //conexionstring = "Data Source=192.168.10.8\\SRVAP01;Initial Catalog=IPRESS;Persist Security Info=True;User ID=siscsp; password=C1n1c4123*";
            //SqlConnection conex = new SqlConnection(conexionstring);
        }


        //Crear un método para generar instancia dentro de una clase

        public static cd_conexionNisira CrearInstancia()
        {
            if (con == null)
            {
                con = new cd_conexionNisira();
            }
            return con;
        }

        public SqlConnection leerconexion()
        {
            return new SqlConnection(conexionstring);
        }
    }
}

