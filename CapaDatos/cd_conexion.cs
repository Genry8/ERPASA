using System.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_conexion
    {
        private readonly string conexionstring;
        private static cd_conexion con = null; // Crear la conexion
        public cd_conexion()
        {
            string srtserver = ConfigurationManager.AppSettings["server"];
            //srtserver
            conexionstring = "server=10.250.200.9;DataBase=BD_ASA; Integrated Security = false; uid=sa; pwd=Admin.-2030**$";
            //conexionstring = "server=10.250.200.7;DataBase=BD_ASA; Integrated Security = false; uid=sa; pwd=Admin.-2030**$";
            //conexionstring = "server=10.250.200.7\\FSFASA;DataBase=TI_ACTIVOS; Integrated Security = false; uid=sa; pwd=asa.*2022";
            //conexionstring = "Data Source=GALBERTO;Initial Catalog=TI_ACTIVOS;Integrated Security = false; uid=sa; pwd=Santa2024*.";

            //conexionstring = "Data Source=192.168.10.8\\SRVAP01;Initial Catalog=IPRESS;Persist Security Info=True;User ID=siscsp; password=C1n1c4123*";
            //SqlConnection conex = new SqlConnection(conexionstring);
        }


        //Crear un método para generar instancia dentro de una clase

        public static cd_conexion CrearInstancia()
        {
            if (con == null)
            {
                con = new cd_conexion();
            }

            return con;
        }

        public SqlConnection leerconexion()
        {
            return new SqlConnection(conexionstring);
        }
    }
}
