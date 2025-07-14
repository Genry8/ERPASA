using System;
using System.Linq;

namespace CapaUtilidad
{
    public class cu_encriptar
    {
        public static string Encriptar(string DatoAencriptar)
        {
            string result = string.Empty;
            byte[] encryted =
            System.Text.Encoding.Unicode.GetBytes(DatoAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesEncriptar(string DatoAencriptar)
        {
            string result = string.Empty;
            byte[] descryted =
            Convert.FromBase64String(DatoAencriptar);
            //result = 
            System.Text.Encoding.Unicode.GetString(descryted, 0, descryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(descryted);
            return result;
        }

    }
}
