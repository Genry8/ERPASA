using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_administracion : cd_conexion
    {

        //metodo para buscar si existe meta variedad
        public static bool BuscExisteMetaVariedad(string id_actividad, string codigo, DateTime? fecini)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteMetaVariedad(id_actividad, codigo, fecini);
        }


        //metodo para buscar si existe meta variedad
        public static bool BuscExisteMetaLocalidad(string cabezal, string localidad, DateTime? fecha)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteMetaLocalidad(cabezal, localidad, fecha);
        }

        //metodo para buscar si existe meta variedad
        public static bool BuscExistePersFijoTemporal(string emp, string sede, string area, string tippers, int semana)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExistePersFijoTemporal(emp, sede, area, tippers, semana);
        }


        //metodo para buscar si existe meta labor
        public static bool BuscExisteMetaAvance(string emp, string sede
            , string labor, string area, int semana)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteMetaAvance(emp, sede, labor, area, semana);
        }

        //metodo para buscar si existe meta variedad
        public static bool BuscExisteMetaSector(string labor, string sector, string fundo, int semana)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteMetaSector(labor, sector, fundo, semana);
        }

        //metodo para buscar si existe meta variedad
        public static bool BuscExisteMetaLabor(string fundo, string labor, DateTime? fecha)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteMetaLabor(fundo, labor, fecha);
        }

        //metodo para buscar si existe detalle cosechador
        public static bool BuscExisteDetalleCosechador(DateTime? fecha, string dni, string stiker)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteDetalleCosechador(fecha, dni, stiker);
        }

        //metodo para buscar si existe detalle cosechador
        public static bool BuscExisteTareoFinal(string fecha, string dni)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteTareoFinal(fecha, dni);
        }

        //metodo para buscar si existe detalle cosechador
        public static bool EliminarTareoFinalDiario(string fecha)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteTareoFinalDiario(fecha);
        }

        //metodo para buscar si existe detalle cosechador
        public static bool BuscExisteTareoDetallado(DateTime? fecha, string dni, string gruplabor)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteTareoDetallado(fecha, dni, gruplabor);
        }


        //metodo para buscar si existe detalle cosechador
        public static bool BuscExistePresupuesto(string partida, int sem, string mes, int año)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExistePresupuesto(partida, sem, mes, año);
        }


        //metodo para buscar si existe
        public static bool BuscExisteEstacionMeteorologica(string empresa, string sede, DateTime fecha, DateTime hora)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteEstacionMeteorologica(empresa, sede, fecha, hora);
        }


        //metodo para buscar si existe
        public static bool BuscExisteMetroCubico(string sede
            , string cabezal, DateTime fecha)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteMetroCubico(sede
            , cabezal, fecha);
        }

        //metodo para buscar si existe
        public static bool BuscExistePersonalObservado(DateTime fecha,
            string dni)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExistePersonalObservado(fecha, dni);
        }

        //metodo para buscar si existe
        public static bool BuscExisteProgramaRiego(string empresa
            , string cabezal, DateTime fecha, string programa)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteProgramaRiego(empresa
            , cabezal, fecha, programa);
        }

        //metodo para buscar si existe
        public static bool BuscExisteEvaluacionCampo(string empresa
            , DateTime fecha, string sede, string cabezal, string cultivo
            , string lote, string grupo_var, string variable)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteEvaluacionCampo(empresa
            , fecha, sede, cabezal, cultivo, lote, grupo_var, variable);
        }

        //metodo para buscar si existe
        public static bool BuscExisteReservorio(string empresa
            , DateTime fecha, string reservorio, string hora_medida)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteReservorio(empresa
            , fecha, reservorio, hora_medida);
        }


        //metodo para buscar si existe
        public static bool BuscExisteFertilizacion(string empresa, int id, DateTime fecha)
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExisteFertilizacion(empresa, id, fecha);
        }


        //metodo para buscar si existe
        public static bool BuscExistePulsos(string sede
            , string cabezal, string variedad, int valvula, DateTime fecha
            )
        {
            cd_administracion datos = new cd_administracion();
            return datos.BuscExistePulsos(sede
            , cabezal, variedad, valvula, fecha
            );
        }


        //ACTUALIZAR VARIEDAD
        public void ActualizarMetaVariedad(string idactividad, string cabezal, string codigo
            , string variedad, string presentacion, decimal JAB, decimal KG
            , DateTime fec_ini, DateTime fec_fin, decimal KG_JAB, string sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetaVariedad(idactividad, cabezal, codigo
            , variedad, presentacion, JAB, KG
            , fec_ini, fec_fin, KG_JAB, sem, hoja, estado
                , fec_mov, usedit);
        }

        //ACTUALIZAR LOCALIDAD
        public void ActualizarMetaLocalidad(string cabezal, string localidad
            , DateTime fecha, string sem, decimal horas, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetaLocalidad(cabezal, localidad
            , fecha, sem, horas, hoja, estado
                , fec_mov, usedit);
        }

        //ACTUALIZAR META PERSONAL FIJO TEMPORAL
        public void ActualizarMetaPersFijoTemporal(string empresa, string sede
            , string area, string tipopersonal, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetaPersFijoTemporal(empresa, sede
            , area, tipopersonal, fecini, fecfin
            , sem, cantidad, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR META AVANCE
        public void ActualizarMetaAvance(string empresa, string sede
            , string labor, string area, string tipo_bono, DateTime fecini, DateTime fecfin
            , decimal meta, decimal horas, int sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetaAvance(empresa, sede
            , labor, area, tipo_bono, fecini, fecfin
            , meta, horas, sem, hoja, estado
                , fec_mov, usedit);
        }

        //ACTUALIZAR META SECTOR
        public void ActualizarMetaSector(string labor, string sector
            , string fundo, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetaSector(labor, sector
            , fundo, fecini, fecfin
            , sem, cantidad, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR META LABOR
        public void ActualizarMetaLabor(string labor, string fundo
            , DateTime fecini, DateTime fecfin, string sem, decimal meta, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetaLabor(labor, fundo
            , fecini, fecfin, sem, meta, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR DETALLE COSECHADOR
        public void ActualizarDetalleCosechador(DateTime Fecha, string Empresa, string fundo
            , string Cod_Cabezal, string Cabezal, string Campana, string Cultivo
            , string Cod_Variedad, string Variedad, string TipoEnvaseDes, string Dni
            , string Ape_Nom, decimal Jabas, decimal Kilos, decimal Meta
            , decimal PrecioUnitario, decimal Bono, decimal Rendimiento, string Categoría
            , string Cod_Modalidad, string Modalidad, string Cod_Presentacion
            , string Presentacion, string Nro_Ticket, int año
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarDetalleCosechador(Fecha, Empresa, fundo
            , Cod_Cabezal, Cabezal, Campana, Cultivo
            , Cod_Variedad, Variedad, TipoEnvaseDes, Dni
            , Ape_Nom, Jabas, Kilos, Meta
            , PrecioUnitario, Bono, Rendimiento, Categoría
            , Cod_Modalidad, Modalidad, Cod_Presentacion
            , Presentacion, Nro_Ticket, año, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR TAREO FINAL
        public void ActualizarTareoFinal(string Codigo, string Ape_Nom, string Dni
            , string Cod_Planilla, string Fecha_Ing, string Empresa
            , string Sede, string Fundo, string Cargo, string Area, string Gerencia
            , string Actividad, string Labor, string Labor_Correcta
            , string Centro_Costo, string Jornada, string Fecha_Tareo, string Hora_Tareo
            , string DniSupervisor, string NombreSupervisor, string Fecha_Ingreso_Tareo
            , string Hora_Ingreso_Tareo, string Fecha_Salida_Tareo, string Hora_Salida_Tareo
            , string Horas_En_Sede, string Refrigerio, string Horas_Normales
            , string Fecha_Ingreso_Real, string Hora_Ingreso_Real, string Fecha_Salida_Real
            , string Hora_Salida_Real, string Horas_Pagar, string Horas_Compensadas
            , string Devolución_Horas, string Día_Tareo, string Horas_Nocturnas
            , string Turno, string Usuario_Registro, string Fecha_Registro
            , string Usuario_Modificación, string Fecha_Modificación, string Num_Hora_Ingreso_Tareo
            , string Num_Hora_Ingreso_Real, string Num_Hora_Salida_Tareo, string Num_Hora_Salida_Real
            , string Horas_No_Validadas_Ingreso, string Horas_No_Validadas_Ingreso_Final,
              string Horas_No_Validadas_Salida, string Horas_No_Validadas_Salida_Final
            , string HH_NO_Validadas_Final, string Horas_extra, string Num_Horas_Compensadas
            , string Num_Devolución_Horas, string Almuerzo, string Cena, string Alimentación_Total
            , string Horas_Efectivas_Fundo, string Sobretiempo_Ingresado, string Sobretiempo_Final

            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarTareoFinal(Codigo, Ape_Nom, Dni
            , Cod_Planilla, Fecha_Ing, Empresa
            , Sede, Fundo, Cargo, Area, Gerencia
            , Actividad, Labor, Labor_Correcta
            , Centro_Costo, Jornada, Fecha_Tareo, Hora_Tareo
            , DniSupervisor, NombreSupervisor, Fecha_Ingreso_Tareo
            , Hora_Ingreso_Tareo, Fecha_Salida_Tareo, Hora_Salida_Tareo
            , Horas_En_Sede, Refrigerio, Horas_Normales
            , Fecha_Ingreso_Real, Hora_Ingreso_Real, Fecha_Salida_Real
            , Hora_Salida_Real, Horas_Pagar, Horas_Compensadas
            , Devolución_Horas, Día_Tareo, Horas_Nocturnas
            , Turno, Usuario_Registro, Fecha_Registro
            , Usuario_Modificación, Fecha_Modificación, Num_Hora_Ingreso_Tareo
            , Num_Hora_Ingreso_Real, Num_Hora_Salida_Tareo, Num_Hora_Salida_Real
            , Horas_No_Validadas_Ingreso, Horas_No_Validadas_Ingreso_Final,
             Horas_No_Validadas_Salida, Horas_No_Validadas_Salida_Final
            , HH_NO_Validadas_Final, Horas_extra, Num_Horas_Compensadas
            , Num_Devolución_Horas, Almuerzo, Cena, Alimentación_Total
            , Horas_Efectivas_Fundo, Sobretiempo_Ingresado, Sobretiempo_Final, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR DETALLE COSECHADOR
        public void ActualizarTareoDetallado(string Empresa, string Sede, string fundo
            , string Cod_Grupo_Labor, string Grupo_Labor, string Cod_Labor, string Labor
            , string Labor_Correcta, string Uni_Med, string Cod_Cultivo, string Cultivo
            , DateTime Fecha, string DNI_Supervisor
            , string Supervisor, DateTime Fec_Inicio, DateTime Fec_Fin
            , string Horas_efectivas, string Total_Horas, string DniResponsable
            , string responsable, string Dni, string Ape_Nom
            , decimal Avance, string Motivo_Salida, string Tipo_Labor, string Cabezal
            , string CodCentroCosto, string CentroCosto, string Observacion
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarTareoDetallado(Empresa, Sede, fundo
            , Cod_Grupo_Labor, Grupo_Labor, Cod_Labor, Labor
            , Labor_Correcta, Uni_Med, Cod_Cultivo, Cultivo
            , Fecha, DNI_Supervisor
            , Supervisor, Fec_Inicio, Fec_Fin
            , Horas_efectivas, Total_Horas, DniResponsable
            , responsable, Dni, Ape_Nom
            , Avance, Motivo_Salida, Tipo_Labor, Cabezal
            , CodCentroCosto, CentroCosto, Observacion, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR PRESUPUESTO
        public void ActualizarPresupuesto(string Empresa, string Partida
            , string IdRubro, string Area, int Semana, string Mes
            , int Año, string TipoRegistro, decimal Importe
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarPresupuesto(Empresa, Partida
            , IdRubro, Area, Semana, Mes
            , Año, TipoRegistro, Importe, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR ESTACION METEOROLÓGICA
        public void ActualizarEstacionMeteorológica(string Empresa, string sede, DateTime Fecha
            , DateTime Hora, decimal Temp_Out, decimal Hi_Temp, decimal Low_Temp
            , decimal Out_Hum, decimal Dew_Pt, decimal Wind_Speed, string Wind_Dir
            , decimal Wind_Run, decimal Hi_Speed, string Hi_Dir, decimal Wind_Chill, decimal Heat_Index
            , decimal THW_Index, string THSW_Index, decimal Bar, decimal Rain, decimal Rain_Rate
            , decimal Solar_Rad, decimal Solar_Energy, decimal Hi_Solar_Rad, decimal UV_Index
            , decimal UV_Dose, decimal Hi_UV, decimal Heat_D_D, decimal Cool_D_D, decimal In_Temp
            , decimal In_Hum, decimal In_Dew, decimal In_Heat, decimal In_EMC, decimal In_Air_Density
            , decimal ET, decimal Wind_Samp, decimal Wind_Tx, decimal ISS_Recept, decimal Arc_Int
            , decimal H_H_Brillo_Solar, decimal HR_90
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarEstacionMeteorologica(Empresa, sede, Fecha
            , Hora, Temp_Out, Hi_Temp, Low_Temp
            , Out_Hum, Dew_Pt, Wind_Speed, Wind_Dir
            , Wind_Run, Hi_Speed, Hi_Dir, Wind_Chill, Heat_Index
            , THW_Index, THSW_Index, Bar, Rain, Rain_Rate
            , Solar_Rad, Solar_Energy, Hi_Solar_Rad, UV_Index
            , UV_Dose, Hi_UV, Heat_D_D, Cool_D_D, In_Temp
            , In_Hum, In_Dew, In_Heat, In_EMC, In_Air_Density
            , ET, Wind_Samp, Wind_Tx, ISS_Recept, Arc_Int
            , H_H_Brillo_Solar, HR_90, hoja, estado
                , fec_mov, usedit);
        }

        //ACTUALIZAR PERCOLACION
        public void ActualizarMetroCubico(string sede, string cabezal
            , DateTime Fecha, decimal programado, decimal ejecutado
            , decimal eficiencia, string Observacion
            //, string hoja
            //, string estado, DateTime fec_mov, int usedit
            )
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarMetroCubico(sede, cabezal
            , Fecha, programado, ejecutado, eficiencia, Observacion
            //, hoja, estado
            //    , fec_mov, usedit
                );
        }


        //ACTUALIZAR PERSONAL OBSERVADO
        public void ActualizarPersonalObservado(DateTime Fecha
            , string dni, string apenom, string Observacion
            //, string hoja
            //, string estado, DateTime fec_mov, int usedit
            )
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarPersonalObservado(Fecha
            , dni, apenom, Observacion
            //, hoja, estado
            //    , fec_mov, usedit
                );
        }



        //ACTUALIZAR PERCOLACION
        public void ActualizarProgramaRiego(string Empresa, string cabezal
            , DateTime Fecha, string dia, string programa, DateTime tot_horas
            , decimal Consumo_M3, decimal M3_Ha, decimal Cuba_A_Lts
            , decimal Cuba_B_Lts, decimal Cuba_C_Lts, decimal Cuba_Fito_Lts
            , string Observacion
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarProgramaRiego(Empresa, cabezal
            , Fecha, dia, programa, tot_horas
            , Consumo_M3, M3_Ha, Cuba_A_Lts
            , Cuba_B_Lts, Cuba_C_Lts, Cuba_Fito_Lts, Observacion, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR EVALUACION CAMPO
        public void ActualizarEvaluacionCampo(string empresa
            , DateTime fecha, string sede, string cabezal, string cultivo
            , string lote, string muestra, string grupo_var, string variable
            , int total, decimal promedio, string semaforo, decimal severidad
            , string semaforo_2, decimal dispersion, string fenologia, string variedad
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarEvaluacionCampo(empresa
            , fecha, sede, cabezal, cultivo
            , lote, muestra, grupo_var, variable
            , total, promedio, semaforo, severidad
            , semaforo_2, dispersion, fenologia, variedad, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR PERCOLACION
        public void ActualizarReservorio(string empresa
            , DateTime fecha, string reservorio, string hora_medida
            , decimal Cantidad, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarReservorio(empresa
            , fecha, reservorio, hora_medida
            , Cantidad, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR PERCOLACION
        public void ActualizarFertilizacion(string empresa, int id
            , DateTime fecha, string Fenologia, string Pulsos_Fertilizados
            , string Pulsos_Riego, decimal Horas, string Variedad
            , string Nombre_Comercial, string Ing_Activo, decimal Base_1000LT
            , int Inyeccion, string Unidad, decimal Qm3_Varidad, int Volumen_Teorico
            , decimal KG_Teorico, decimal Suma_Qm3_Total, int Vol_Sol_Lt_Reportado
            , int Vol, decimal Cant, decimal Efi_Inyeccion, decimal Area
            , string Valvula_Int, string Tanque, string Operador
            , string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarFertilizacion(empresa, id
            , fecha, Fenologia, Pulsos_Fertilizados
            , Pulsos_Riego, Horas, Variedad
            , Nombre_Comercial, Ing_Activo, Base_1000LT
            , Inyeccion, Unidad, Qm3_Varidad, Volumen_Teorico
            , KG_Teorico, Suma_Qm3_Total, Vol_Sol_Lt_Reportado
            , Vol, Cant, Efi_Inyeccion, Area
            , Valvula_Int, Tanque, Operador, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR PERCOLACION
        public void ActualizarPulsos(string sede
            , string cabezal, string variedad, int valvula, DateTime fecha
            , decimal pulsos, string obs)
        {
            cd_administracion datos = new cd_administracion();
            datos.ActualizarPulsos(sede
            , cabezal, variedad, valvula, fecha
            , pulsos, obs);
        }


        //GUARDAR VARIEDAD
        public void GuardarMetaVariedad(string idactividad, string cabezal, string codigo
            , string variedad, string presentacion, decimal JAB, decimal KG
            , DateTime? fec_ini, DateTime? fec_fin, decimal? KG_JAB, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetaVariedad(idactividad, cabezal, codigo
            , variedad, presentacion, JAB, KG
            , fec_ini, fec_fin, KG_JAB, sem, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR LOCALIDAD
        public void GuardarMetaLocalidad(string cabezal, string localidad
            , DateTime fecha, string sem, decimal horas, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetaLocalidad(cabezal, localidad
            , fecha, sem, horas, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR META PERSONAL FIJO TEMPORAL
        public void GuardarMetaPersFijoTemporal(string empresa, string sede
            , string area, string tipopersonal, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetaPersFijoTemporal(empresa, sede
            , area, tipopersonal, fecini, fecfin
            , sem, cantidad, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR META AVANCE
        public void GuardarMetaAvance(string empresa, string sede
            , string labor, string area, string tipo_bono, DateTime fecini, DateTime fecfin
            , decimal meta, decimal horas, int sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetaAvance(empresa, sede
            , labor, area, tipo_bono, fecini, fecfin
            , meta, horas, sem, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR META PERSONAL FIJO TEMPORAL
        public void GuardarMetaSector(string labor, string sector
            , string fundo, DateTime fecini, DateTime fecfin
            , string sem, decimal cantidad, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetaSector(labor, sector
            , fundo, fecini, fecfin
            , sem, cantidad, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR LABOR
        public void GuardarMetaLabor(string labor, string fundo
            , DateTime fecini, DateTime fecfin, string sem, decimal meta, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetaLabor(labor, fundo
            , fecini, fecfin, sem, meta, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR LABOR
        public void GuardarDetalleCosechador(DateTime Fecha, string Empresa, string fundo
            , string Cod_Cabezal, string Cabezal, string Campana, string Cultivo
            , string Cod_Variedad, string Variedad, string TipoEnvaseDes, string Dni
            , string Ape_Nom, decimal Jabas, decimal Kilos, decimal? Meta
            , decimal PrecioUnitario, decimal Bono, decimal? Rendimiento, string Categoría
            , string Cod_Modalidad, string Modalidad, string Cod_Presentacion
            , string Presentacion, string Nro_Ticket, int año, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarDetalleCosechador(Fecha, Empresa, fundo
            , Cod_Cabezal, Cabezal, Campana, Cultivo
            , Cod_Variedad, Variedad, TipoEnvaseDes, Dni
            , Ape_Nom, Jabas, Kilos, Meta
            , PrecioUnitario, Bono, Rendimiento, Categoría
            , Cod_Modalidad, Modalidad, Cod_Presentacion
            , Presentacion, Nro_Ticket, año, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR LABOR
        public void GuardarTareoFinal(string Codigo, string Ape_Nom, string Dni
            , string Cod_Planilla, string Fecha_Ing, string Empresa
            , string Sede, string Fundo, string Cargo, string Area, string Gerencia
            , string Actividad, string Labor, string Labor_Correcta
            , string Centro_Costo, string Jornada, string Fecha_Tareo, string Hora_Tareo
            , string DniSupervisor, string NombreSupervisor, string Fecha_Ingreso_Tareo
            , string Hora_Ingreso_Tareo, string Fecha_Salida_Tareo, string Hora_Salida_Tareo
            , string Horas_En_Sede, string Refrigerio, string Horas_Normales
            , string Fecha_Ingreso_Real, string Hora_Ingreso_Real, string Fecha_Salida_Real
            , string Hora_Salida_Real, string Horas_Pagar, string Horas_Compensadas
            , string Devolución_Horas, string Día_Tareo, string Horas_Nocturnas
            , string Turno, string Usuario_Registro, string Fecha_Registro
            , string Usuario_Modificación, string Fecha_Modificación, string Num_Hora_Ingreso_Tareo
            , string Num_Hora_Ingreso_Real, string Num_Hora_Salida_Tareo, string Num_Hora_Salida_Real
            , string Horas_No_Validadas_Ingreso, string Horas_No_Validadas_Ingreso_Final,
              string Horas_No_Validadas_Salida, string Horas_No_Validadas_Salida_Final
            , string HH_NO_Validadas_Final, string Horas_extra, string Num_Horas_Compensadas
            , string Num_Devolución_Horas, string Almuerzo, string Cena, string Alimentación_Total
            , string Horas_Efectivas_Fundo, string Sobretiempo_Ingresado, string Sobretiempo_Final
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarTareoFinal(Codigo, Ape_Nom, Dni
            , Cod_Planilla, Fecha_Ing, Empresa
            , Sede, Fundo, Cargo, Area, Gerencia
            , Actividad, Labor, Labor_Correcta
            , Centro_Costo, Jornada, Fecha_Tareo, Hora_Tareo
            , DniSupervisor, NombreSupervisor, Fecha_Ingreso_Tareo
            , Hora_Ingreso_Tareo, Fecha_Salida_Tareo, Hora_Salida_Tareo
            , Horas_En_Sede, Refrigerio, Horas_Normales
            , Fecha_Ingreso_Real, Hora_Ingreso_Real, Fecha_Salida_Real
            , Hora_Salida_Real, Horas_Pagar, Horas_Compensadas
            , Devolución_Horas, Día_Tareo, Horas_Nocturnas
            , Turno, Usuario_Registro, Fecha_Registro
            , Usuario_Modificación, Fecha_Modificación, Num_Hora_Ingreso_Tareo
            , Num_Hora_Ingreso_Real, Num_Hora_Salida_Tareo, Num_Hora_Salida_Real
            , Horas_No_Validadas_Ingreso, Horas_No_Validadas_Ingreso_Final,
             Horas_No_Validadas_Salida, Horas_No_Validadas_Salida_Final
            , HH_NO_Validadas_Final, Horas_extra, Num_Horas_Compensadas
            , Num_Devolución_Horas, Almuerzo, Cena, Alimentación_Total
            , Horas_Efectivas_Fundo, Sobretiempo_Ingresado, Sobretiempo_Final
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR LABOR
        public void GuardarTareoFinalDiario(string Codigo, string Ape_Nom, string Dni
            , string Cod_Planilla, string Fecha_Ing, string Empresa
            , string Sede, string Fundo, string Cargo, string Area, string Gerencia
            , string Actividad, string Labor, string Labor_Correcta
            , string Centro_Costo, string Jornada, string Fecha_Tareo, string Hora_Tareo
            , string DniSupervisor, string NombreSupervisor, string Fecha_Ingreso_Tareo
            , string Hora_Ingreso_Tareo, string Fecha_Salida_Tareo, string Hora_Salida_Tareo
            , string Horas_En_Sede, string Refrigerio, string Horas_Normales
            , string Fecha_Ingreso_Real, string Hora_Ingreso_Real, string Fecha_Salida_Real
            , string Hora_Salida_Real, string Horas_Pagar, string Horas_Compensadas
            , string Devolución_Horas, string Día_Tareo, string Horas_Nocturnas
            , string Turno, string Usuario_Registro, string Fecha_Registro
            , string Usuario_Modificación, string Fecha_Modificación, string Num_Hora_Ingreso_Tareo
            , string Num_Hora_Ingreso_Real, string Num_Hora_Salida_Tareo, string Num_Hora_Salida_Real
            , string Horas_No_Validadas_Ingreso, string Horas_No_Validadas_Ingreso_Final,
              string Horas_No_Validadas_Salida, string Horas_No_Validadas_Salida_Final
            , string HH_NO_Validadas_Final, string Horas_extra, string Num_Horas_Compensadas
            , string Num_Devolución_Horas, string Almuerzo, string Cena, string Alimentación_Total
            , string Horas_Efectivas_Fundo, string Sobretiempo_Ingresado, string Sobretiempo_Final
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarTareoFinalDiario(Codigo, Ape_Nom, Dni
            , Cod_Planilla, Fecha_Ing, Empresa
            , Sede, Fundo, Cargo, Area, Gerencia
            , Actividad, Labor, Labor_Correcta
            , Centro_Costo, Jornada, Fecha_Tareo, Hora_Tareo
            , DniSupervisor, NombreSupervisor, Fecha_Ingreso_Tareo
            , Hora_Ingreso_Tareo, Fecha_Salida_Tareo, Hora_Salida_Tareo
            , Horas_En_Sede, Refrigerio, Horas_Normales
            , Fecha_Ingreso_Real, Hora_Ingreso_Real, Fecha_Salida_Real
            , Hora_Salida_Real, Horas_Pagar, Horas_Compensadas
            , Devolución_Horas, Día_Tareo, Horas_Nocturnas
            , Turno, Usuario_Registro, Fecha_Registro
            , Usuario_Modificación, Fecha_Modificación, Num_Hora_Ingreso_Tareo
            , Num_Hora_Ingreso_Real, Num_Hora_Salida_Tareo, Num_Hora_Salida_Real
            , Horas_No_Validadas_Ingreso, Horas_No_Validadas_Ingreso_Final,
             Horas_No_Validadas_Salida, Horas_No_Validadas_Salida_Final
            , HH_NO_Validadas_Final, Horas_extra, Num_Horas_Compensadas
            , Num_Devolución_Horas, Almuerzo, Cena, Alimentación_Total
            , Horas_Efectivas_Fundo, Sobretiempo_Ingresado, Sobretiempo_Final
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR LABOR
        public void GuardarTareoDetallado(string Empresa, string Sede, string fundo
            , string Cod_Grupo_Labor, string Grupo_Labor, string Cod_Labor, string Labor
            , string Labor_Correcta, string Uni_Med, string Cod_Cultivo, string Cultivo
            , DateTime Fecha, string DNI_Supervisor
            , string Supervisor, DateTime Fec_Inicio, DateTime Fec_Fin
            , string Horas_efectivas, string Total_Horas, string DniResponsable
            , string responsable, string Dni, string Ape_Nom
            , decimal Avance, string Motivo_Salida, string Tipo_Labor, string Cabezal
            , string CodCentroCosto, string CentroCosto, string Observacion, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarTareoDetallado(Empresa, Sede, fundo
            , Cod_Grupo_Labor, Grupo_Labor, Cod_Labor, Labor
            , Labor_Correcta, Uni_Med, Cod_Cultivo, Cultivo
            , Fecha, DNI_Supervisor
            , Supervisor, Fec_Inicio, Fec_Fin
            , Horas_efectivas, Total_Horas, DniResponsable
            , responsable, Dni, Ape_Nom
            , Avance, Motivo_Salida, Tipo_Labor, Cabezal
            , CodCentroCosto, CentroCosto, Observacion
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }




        //GUARDAR ESTACION METEOLOGICA
        public void GuardarEstacionMeteorologica(string Empresa, string sede, DateTime Fecha
            , DateTime Hora, decimal Temp_Out, decimal Hi_Temp, decimal Low_Temp
            , decimal Out_Hum, decimal Dew_Pt, decimal Wind_Speed, string Wind_Dir
            , decimal Wind_Run, decimal Hi_Speed, string Hi_Dir, decimal Wind_Chill, decimal Heat_Index
            , decimal THW_Index, string THSW_Index, decimal Bar, decimal Rain, decimal Rain_Rate
            , decimal Solar_Rad, decimal Solar_Energy, decimal Hi_Solar_Rad, decimal UV_Index
            , decimal UV_Dose, decimal Hi_UV, decimal Heat_D_D, decimal Cool_D_D, decimal In_Temp
            , decimal In_Hum, decimal In_Dew, decimal In_Heat, decimal In_EMC, decimal In_Air_Density
            , decimal ET, decimal Wind_Samp, decimal Wind_Tx, decimal ISS_Recept, decimal Arc_Int
            , decimal H_H_Brillo_Solar, decimal HR_90, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarEstacionMeteorologica(Empresa, sede, Fecha
            , Hora, Temp_Out, Hi_Temp, Low_Temp
            , Out_Hum, Dew_Pt, Wind_Speed, Wind_Dir
            , Wind_Run, Hi_Speed, Hi_Dir, Wind_Chill, Heat_Index
            , THW_Index, THSW_Index, Bar, Rain, Rain_Rate
            , Solar_Rad, Solar_Energy, Hi_Solar_Rad, UV_Index
            , UV_Dose, Hi_UV, Heat_D_D, Cool_D_D, In_Temp
            , In_Hum, In_Dew, In_Heat, In_EMC, In_Air_Density
            , ET, Wind_Samp, Wind_Tx, ISS_Recept, Arc_Int
            , H_H_Brillo_Solar, HR_90, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR ESTACION METEOLOGICA
        public void GuardarMetroCubico(string sede, string cabezal
            , DateTime Fecha, decimal programado
            , decimal ejecutado, decimal eficiencia, string Observacion
            //, string hoja
            //, string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit
            )
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarMetroCubico(sede, cabezal
            , Fecha, programado
            , ejecutado, eficiencia, Observacion
            //, hoja, estado, fec_cre, usereg, hostname
            //    , fec_mov, usedit
                );
        }


        //GUARDAR ESTACION METEOLOGICA
        public void GuardarPersonalObservado(DateTime Fecha
            , string dni, string apenom, string Observacion
            //, string hoja
            //, string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit
            )
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarPersonalObservado(Fecha
            , dni, apenom, Observacion
            //, hoja, estado, fec_cre, usereg, hostname
            //    , fec_mov, usedit
                );
        }


        //GUARDAR PROGRAMA RIEGO
        public void GuardarProgramaRiego(string Empresa, string cabezal
            , DateTime Fecha, string dia, string programa, DateTime tot_horas
            , decimal Consumo_M3, decimal M3_Ha, decimal Cuba_A_Lts
            , decimal Cuba_B_Lts, decimal Cuba_C_Lts, decimal Cuba_Fito_Lts
            , string Observacion, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarProgramaRiego(Empresa, cabezal
            , Fecha, dia, programa, tot_horas
            , Consumo_M3, M3_Ha, Cuba_A_Lts
            , Cuba_B_Lts, Cuba_C_Lts, Cuba_Fito_Lts, Observacion
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR EVALUACION CAMPO
        public void GuardarEvaluacionCampo(string empresa
            , DateTime fecha, string sede, string cabezal, string cultivo
            , string lote, string muestra, string grupo_var, string variable
            , int total, decimal promedio, string semaforo, decimal severidad
            , string semaforo_2, decimal dispersion, string fenologia, string variedad
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarEvaluacionCampo(empresa
            , fecha, sede, cabezal, cultivo
            , lote, muestra, grupo_var, variable
            , total, promedio, semaforo, severidad
            , semaforo_2, dispersion, fenologia, variedad
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }



        //GUARDAR PROGRAMA RIEGO
        public void GuardarReservorio(string empresa
            , DateTime fecha, string reservorio, string hora_medida
            , decimal Cantidad, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarReservorio(empresa
            , fecha, reservorio, hora_medida
            , Cantidad
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR PROGRAMA RIEGO
        public void GuardarFertilizacion(string empresa, int id
            , DateTime fecha, string Fenologia, string Pulsos_Fertilizados
            , string Pulsos_Riego, decimal Horas, string Variedad
            , string Nombre_Comercial, string Ing_Activo, decimal Base_1000LT
            , int Inyeccion, string Unidad, decimal Qm3_Varidad, int Volumen_Teorico
            , decimal KG_Teorico, decimal Suma_Qm3_Total, int Vol_Sol_Lt_Reportado
            , int Vol, decimal Cant, decimal Efi_Inyeccion, decimal Area
            , string Valvula_Int, string Tanque, string Operador, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarFertilizacion(empresa, id
            , fecha, Fenologia, Pulsos_Fertilizados
            , Pulsos_Riego, Horas, Variedad
            , Nombre_Comercial, Ing_Activo, Base_1000LT
            , Inyeccion, Unidad, Qm3_Varidad, Volumen_Teorico
            , KG_Teorico, Suma_Qm3_Total, Vol_Sol_Lt_Reportado
            , Vol, Cant, Efi_Inyeccion, Area
            , Valvula_Int, Tanque, Operador
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR ESTACION METEOLOGICA
        public void GuardarPulsos(string sede
            , string cabezal, string variedad, int valvula, DateTime fecha
            , decimal pulsos, string obs)
        {
            cd_administracion datos = new cd_administracion();
            datos.GuardarPulsos(sede
            , cabezal, variedad, valvula, fecha
            , pulsos, obs);
        }


        //LISTAR REPORTE COSECHA VALVULA
        public static DataTable ListaReporteCosechaValvula(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cab)
        {
            cd_administracion datos = new cd_administracion();
            return datos.ListaReporteCosechaValvula(fecini, fecfin, emp, sed, cab);
        }


        //LISTAR REPORTE COSECHA VALVULA
        public static DataTable ListaReporteCosechaValvulaVariedad(DateTime fecini, DateTime fecfin
            , string emp, string sed, string cab)
        {
            cd_administracion datos = new cd_administracion();
            return datos.ListaReporteCosechaValvulaVariedad(fecini, fecfin, emp, sed, cab);
        }







    }
}
