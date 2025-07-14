using System;
using System.Net;
using System.Net.Sockets;

namespace CapaEntidad
{
    public class ce_usuario
    {
        //DATOS DE USUARIOS DE INICIO DE SESION
        public static DateTime Fecha_Entrega { get; set; }
        public static int usecod { get; set; }
        public static int siscod { get; set; }
        public static string usenam { get; set; }
        public static int usedoc { get; set; }
        public static string useusr { get; set; }
        public static string usepas { get; set; }
        public static string estado { get; set; }
        public static string grucod { get; set; }
        public static string grudes { get; set; }
        public static string sede_user { get; set; }
        public static string permiso_app { get; set; }
        public static string useestado { get; set; }

        //USUARIOS DE BUSQUEDA POR DNI PARA AGREGAR SI EXISTE
        public static int dni_buscar { get; set; }
        public static string Nombre_buscar { get; set; }
        public static string Apellido_buscar { get; set; }
        public static string Sexo_buscar { get; set; }
        public static string Grupo_buscar { get; set; }
        public static string Contraseña_buscar { get; set; }
        public static string Estado_buscar { get; set; }
        public static string Planilla_buscar { get; set; }
        public static Byte[] foto_perfil_buscar { get; set; }

        //VERSION DE IPRESS REPORTE
        public static string version_ipress { get; set; }
        public static string version_actual { get; set; }

        //PERSONAL ASA
        public static DateTime Fecha_asa { get; set; }
        public static string dni_asa { get; set; }
        public static string dni_as { get; set; }
        public static string apenom_asa { get; set; }
        public static string gerencia_asa { get; set; }
        public static string area_asa { get; set; }
        public static string empresa_asa { get; set; }
        public static string sede_asa { get; set; }
        public static string cargo_asa { get; set; }

        //MOSTRAR IP DE LA PC
        public static string IpMostrar()
        {
            IPHostEntry iPHost;
            string srtLocalip = "";
            iPHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in iPHost.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    srtLocalip = ip.ToString();
                    break;
                }
            }
            return srtLocalip;
        }

        //MOSTRAR EL HOSTANME DE LA PC
        public static string HostName()
        {
            String hostName = Dns.GetHostName();
            Console.WriteLine("Computer name :" + hostName);

            return hostName;
        }

        //MOSTRAR LA FECHA DE SISTEMA
        public static DateTime FechaSistema()
        {
            DateTime fecha = DateTime.Now;
            Console.WriteLine(fecha);
            return fecha;
        }

        //public static void Solonumeros(object sender, KeyPressEventArgs V)
        //{
        //    if (char.IsDigit(V.KeyChar))
        //    {
        //        V.Handled = false;
        //    }

        //    else if (char.IsSeparator(V.KeyChar))
        //    {
        //        V.Handled = false;
        //    }

        //    else if (char.IsControl(V.KeyChar))
        //    {
        //        V.Handled = false;
        //    }

        //    else
        //    {
        //        V.Handled = true;
        //    }

        //}


    }

}
