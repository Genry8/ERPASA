using CapaDatos;
using System;

namespace CapaNegocio
{
    public class cn_correo : cd_conexion
    {
        public static bool BuscDatosCorreo(int id)
        {
            cd_correo datos = new cd_correo();
            return datos.BuscBuscarCorreo(id);
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
            cd_correo datos = new cd_correo();

            datos.GuardarActualizarDatosCorreo(
                id,
                de,
                para,
                cc,
                asunto,
                cuerpo,
                fecEdit,
                useEdit);
        }



    }

}