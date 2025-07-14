using CapaDatos;
using System;

namespace CapaNegocio
{
    public class cn_comunicacion : cd_conexion
    {

        //metodo para buscar si existe
        public static bool BuscExisteCosechandoGanadores(string empresa, string sede, DateTime fecha, int item)
        {
            cd_comunicacion datos = new cd_comunicacion();
            return datos.BuscExisteCosechandoGanadores(empresa, sede, fecha, item);
        }

        //metodo para buscar si existe
        public static bool BuscExisteLideresEnAccion(string empresa, string sede, DateTime fecha, int item)
        {
            cd_comunicacion datos = new cd_comunicacion();
            return datos.BuscExisteLideresEnAccion(empresa, sede, fecha, item);
        }


        //metodo para buscar si existe
        public static bool BuscExistePotenciandoLideres(string empresa, string sede
            , DateTime fecha, int item)
        {
            cd_comunicacion datos = new cd_comunicacion();
            return datos.BuscExistePotenciandoLideres(empresa, sede, fecha, item);
        }


        //metodo para eliminar encuesta clima
        public static bool EliminarExisteEncuestaClima(
            string tipopersonal, DateTime fecha)
        {
            cd_comunicacion datos = new cd_comunicacion();
            return datos.EliminarExisteEncuestaClima(tipopersonal, fecha);
        }

        //metodo para eliminar participacion clima
        public static bool EliminarParticipacionClima(
            string tipopersonal, DateTime fecha)
        {
            cd_comunicacion datos = new cd_comunicacion();
            return datos.EliminarParticipacionClima(tipopersonal, fecha);
        }



        //ACTUALIZAR ESTACION METEOROLÓGICA
        public void ActualizarCosechandoGanadores(int item, DateTime Fecha
            , string Situacion, string Sol_Reconoce, string Sol_Empresa, string Sol_Gerencia
            , string Sol_Sede, string Sol_Cargo, string Sol_Area, string Rec_Reconocido
            , string Rec_Gerencia, string Rec_Cargo, string Rec_Area, string Rec_Motivo
            , string Rec_Tipo
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.ActualizarCosechandoGanadores(item, Fecha
            , Situacion, Sol_Reconoce, Sol_Empresa, Sol_Gerencia
            , Sol_Sede, Sol_Cargo, Sol_Area, Rec_Reconocido
            , Rec_Gerencia, Rec_Cargo, Rec_Area, Rec_Motivo
            , Rec_Tipo, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR ESTACION METEOROLÓGICA
        public void ActualizarLideresEnAccion(int item, DateTime Fecha
            , string Ape_Nom, string Dni, string Empresa, string Sede
            , string Area, string Jefe, decimal Puntaje, string Categoria
            , int Estrellas, string Premio
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.ActualizarLideresEnAccion(item, Fecha
            , Ape_Nom, Dni, Empresa, Sede
            , Area, Jefe, Puntaje, Categoria
            , Estrellas, Premio, hoja, estado
                , fec_mov, usedit);
        }



        //ACTUALIZAR ESTACION METEOROLÓGICA
        public void ActualizarPotenciandoLideres(int item
            , string Cabezal, string Area, string Empresa, string Sede
            , string Supervisor, string DniSupervidor, DateTime Fecha
            , string Entrevistado, string Dimensiones, string Observacion
            , string ObsGeneral, string Apoyo, string CuandoPlaneadoIni
            , string CuandoPlaneadoFin, string CuandoRealizadoIni
            , string CuandoRealizadoFin
            , string EstadoAvance
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.ActualizarPotenciandoLideres(item, Cabezal, Area
                , Empresa, Sede
            , Supervisor, DniSupervidor, Fecha
            , Entrevistado, Dimensiones, Observacion
            , ObsGeneral, Apoyo, CuandoPlaneadoIni
            , CuandoPlaneadoFin, CuandoRealizadoIni
            , CuandoRealizadoFin
            , EstadoAvance, hoja, estado
                , fec_mov, usedit);
        }



        //ACTUALIZAR ESTACION METEOROLÓGICA
        public void ActualizarEncuestaClima(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8, string item_9, string item_10
            , string item_11, string item_12, string item_13, string item_14, string item_15
            , string item_16, string item_17, string item_18, string item_19, string item_20
            , string item_21, string item_22, string item_23, string item_24, string item_25
            , string item_26, string item_27, string item_28, string item_29, string item_30
            , string item_31, string item_32, string item_33, string item_34, string item_35
            , string item_36, string item_37, string item_38, string item_39, string item_40
            , string item_41, string item_42, string item_43, string item_44, string item_45
            , string item_46, string item_47, string item_48, string item_49, string item_50
            , string item_51, string item_52, string item_53, string item_54, string item_55
            , string item_56, string item_57, string item_58, string item_59, string item_60
            , string item_61, string item_62, string item_63, string item_64, string item_65
            , string item_66, string item_67, string item_68, string item_69, string item_70
            , string item_71, string item_72, string sugerencia
            , string Comentario, string tipopersonal
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.ActualizarEncuestaClima(Empresa, Sede
            , Fecha_Respuesta, Fecha
            , Sexo, Rango_edad, gerencia
            , puesto, area, tiempo_compañia
            , item_1, item_2, item_3, item_4, item_5
            , item_6, item_7, item_8, item_9, item_10
            , item_11, item_12, item_13, item_14, item_15
            , item_16, item_17, item_18, item_19, item_20
            , item_21, item_22, item_23, item_24, item_25
            , item_26, item_27, item_28, item_29, item_30
            , item_31, item_32, item_33, item_34, item_35
            , item_36, item_37, item_38, item_39, item_40
            , item_41, item_42, item_43, item_44, item_45
            , item_46, item_47, item_48, item_49, item_50
            , item_51, item_52, item_53, item_54, item_55
            , item_56, item_57, item_58, item_59, item_60
            , item_61, item_62, item_63, item_64, item_65
            , item_66, item_67, item_68, item_69, item_70
            , item_71, item_72, sugerencia
            , Comentario, tipopersonal, hoja, estado
                , fec_mov, usedit);
        }




        //GUARDAR ESTACION METEOLOGICA
        public void GuardarCosechandoGanadores(int item, DateTime Fecha
            , string Situacion, string Sol_Reconoce, string Sol_Empresa, string Sol_Gerencia
            , string Sol_Sede, string Sol_Cargo, string Sol_Area, string Rec_Reconocido
            , string Rec_Gerencia, string Rec_Cargo, string Rec_Area, string Rec_Motivo
            , string Rec_Tipo, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarCosechandoGanadores(item, Fecha
            , Situacion, Sol_Reconoce, Sol_Empresa, Sol_Gerencia
            , Sol_Sede, Sol_Cargo, Sol_Area, Rec_Reconocido
            , Rec_Gerencia, Rec_Cargo, Rec_Area, Rec_Motivo
            , Rec_Tipo, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR ESTACION METEOLOGICA
        public void GuardarLideresEnAccion(int item, DateTime Fecha
            , string Ape_Nom, string Dni, string Empresa, string Sede
            , string Area, string Jefe, decimal Puntaje, string Categoria
            , int Estrellas, string Premio, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarLideresEnAccion(item, Fecha
            , Ape_Nom, Dni, Empresa, Sede
            , Area, Jefe, Puntaje, Categoria
            , Estrellas, Premio, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR ESTACION METEOLOGICA
        public void GuardarPotenciandoLideres(int item
            , string Cabezal, string Area, string Empresa, string Sede
            , string Supervisor, string DniSupervidor, DateTime Fecha
            , string Entrevistado, string Dimensiones, string Observacion
            , string ObsGeneral, string Apoyo, string CuandoPlaneadoIni
            , string CuandoPlaneadoFin, string CuandoRealizadoIni
            , string CuandoRealizadoFin
            , string EstadoAvance, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarPotenciandoLideres(item, Cabezal, Area
                , Empresa, Sede
            , Supervisor, DniSupervidor, Fecha
            , Entrevistado, Dimensiones, Observacion
            , ObsGeneral, Apoyo, CuandoPlaneadoIni
            , CuandoPlaneadoFin, CuandoRealizadoIni
            , CuandoRealizadoFin, EstadoAvance, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR ENCUESTA CLIMA
        public void GuardarEncuestaClima(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8, string item_9, string item_10
            , string item_11, string item_12, string item_13, string item_14, string item_15
            , string item_16, string item_17, string item_18, string item_19, string item_20
            , string item_21, string item_22, string item_23, string item_24, string item_25
            , string item_26, string item_27, string item_28, string item_29, string item_30
            , string item_31, string item_32, string item_33, string item_34, string item_35
            , string item_36, string item_37, string item_38, string item_39, string item_40
            , string item_41, string item_42, string item_43, string item_44, string item_45
            , string item_46, string item_47, string item_48, string item_49, string item_50
            , string item_51, string item_52, string item_53, string item_54, string item_55
            , string item_56, string item_57, string item_58, string item_59, string item_60
            , string item_61, string item_62, string item_63, string item_64, string item_65
            , string item_66, string item_67, string item_68, string item_69, string item_70
            , string item_71, string item_72, string sugerencia
            , string Comentario, string tipopersonal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarEncuestaClima(Empresa, Sede
            , Fecha_Respuesta, Fecha
            , Sexo, Rango_edad, gerencia
            , puesto, area, tiempo_compañia
            , item_1, item_2, item_3, item_4, item_5
            , item_6, item_7, item_8, item_9, item_10
            , item_11, item_12, item_13, item_14, item_15
            , item_16, item_17, item_18, item_19, item_20
            , item_21, item_22, item_23, item_24, item_25
            , item_26, item_27, item_28, item_29, item_30
            , item_31, item_32, item_33, item_34, item_35
            , item_36, item_37, item_38, item_39, item_40
            , item_41, item_42, item_43, item_44, item_45
            , item_46, item_47, item_48, item_49, item_50
            , item_51, item_52, item_53, item_54, item_55
            , item_56, item_57, item_58, item_59, item_60
            , item_61, item_62, item_63, item_64, item_65
            , item_66, item_67, item_68, item_69, item_70
            , item_71, item_72, sugerencia
            , Comentario, tipopersonal
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }




        //GUARDAR ENCUESTA COMEDOR
        public void GuardarEncuestaComedor(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8
            , string Comentario, string tipopersonal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarEncuestaComedor(Empresa, Sede
            , Fecha_Respuesta, Fecha
            , Sexo, Rango_edad, gerencia
            , puesto, area, tiempo_compañia
            , item_1, item_2, item_3, item_4, item_5
            , item_6, item_7, item_8
            , Comentario, tipopersonal
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR SUBSIDIO
        public void GuardarSubsidios(string id, string Empresa, string sede, string Dni
            , string apenom, string area, string tipotrab
            , string tipodescanso, string FecIniSubsidio, string FecFinSubsidio
            , string mes, string año, string dias
            , string fechaPresentacion, string fechaSeguimiento
            , string monto, string montoConta, string contingencia
            , string statusbienestar, string NITCIT, string obs
            , string añocarga, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarSubsidios(id, Empresa, sede, Dni
            , apenom, area, tipotrab
            , tipodescanso, FecIniSubsidio, FecFinSubsidio
            , mes, año, dias, fechaPresentacion, fechaSeguimiento
            , monto, montoConta, contingencia
            , statusbienestar, NITCIT, obs, añocarga, semana
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR ENCUESTA CAMPAMENTO
        public void GuardarEncuestaCampamento(string Empresa, string Sede
            , DateTime Fecha_Respuesta, DateTime Fecha
            , string Sexo, string Rango_edad, string gerencia
            , string puesto, string area, string tiempo_compañia
            , string item_1, string item_2, string item_3, string item_4, string item_5
            , string item_6, string item_7, string item_8, string item_9
            , string Comentario, string tipopersonal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarEncuestaCampamento(Empresa, Sede
            , Fecha_Respuesta, Fecha
            , Sexo, Rango_edad, gerencia
            , puesto, area, tiempo_compañia
            , item_1, item_2, item_3, item_4, item_5
            , item_6, item_7, item_8, item_8
            , Comentario, tipopersonal
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR LISTA VEHICULO
        public void GuardarListaVehiculos(
            string id, string placa, string tipoveh, string ructransporte
            , string transportista, string capacidad, string vencSoat
            , string VenRevTec, string VencPerTransporte, string activo
            , string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarListaVehiculos(id, placa, tipoveh, ructransporte
            , transportista, capacidad, vencSoat
            , VenRevTec, VencPerTransporte, activo
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR LISTA CONDUCTORES
        public void GuardarListaConductores(
            string id, string nombre, string dni, string ructransporte
            , string transportista
            , string num_licencia, string tipo_brevete, string vencLic
            , string vencSctr, string consalta, string activo
            , string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.GuardarListaConductores(id, nombre, dni, ructransporte
                , transportista
            , num_licencia, tipo_brevete, vencLic
            , vencSctr, consalta, activo
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //ELIMINAR SUBSIDIOS
        public void EliminarSubsidios(string año, string sem)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.EliminarSubsidios(año, sem);
        }

        //ELIMINAR ENCUESTA COMEDOR
        public void EliminarEncuestaComedor(string sede, DateTime fecha, string tipo)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.EliminarEncuestaComedor(sede, fecha, tipo);
        }

        //ELIMINAR ENCUESTA CAMPAMENTO
        public void EliminarEncuestaCampamento(string sede, DateTime fecha, string tipo)
        {
            cd_comunicacion datos = new cd_comunicacion();
            datos.EliminarEncuestaCampamento(sede, fecha, tipo);
        }




    }
}
