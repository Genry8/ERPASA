using CapaDatos;
using System;

namespace CapaNegocio
{
    public class cn_planilla : cd_conexion
    {

        //metodo para buscar si existe dni y fecha atencion
        public static bool BuscExisteAtenMedica(string dni, DateTime fecha)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteAtenMedica(dni, fecha);
        }

        //metodo para buscar si existe altas y ceses
        public static bool BuscExisteAltasCeses(string emp, string cod, DateTime fechamov)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteAltasCeses(emp, cod, fechamov);
        }

        //metodo para buscar si existe altas y ceses
        public static bool BuscExisteAsistenciaDetallada(string cod, DateTime fechamov)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteAsistenciaDetallada(cod, fechamov);
        }
        //metodo para buscar si existe eficiencia
        public static bool BuscExisteEficiencia(string año, int sem, string id)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteEficiencia(año, sem, id);
        }

        //metodo para buscar si existe cobertura
        public static bool EliminarCobertura(int año,
            string sem)
        {
            cd_planilla datos = new cd_planilla();
            return datos.EliminarCobertura(año, sem);
        }
        //metodo para buscar si existe revision grupo
        public static bool BuscExisteRevisionGrupo(string cod, DateTime fecha)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteRevisionGrupo(cod, fecha);
        }


        //metodo para buscar si existe labor
        public static bool BuscExisteLabor(string cod)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteLabor(cod);
        }


        //metodo para buscar si existe grupo labor
        public static bool BuscExisteGrupoLabor(string cod, string grupo)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteGrupoLabor(cod, grupo);
        }

        //metodo para buscar compensacion y devolucion
        public static bool BuscExisteCompensacionDevolucion(string emp, int sem, int año, string dni)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteCompensacionDevolucion(emp, sem, año, dni);
        }


        //metodo para buscar compensacion y devolucion
        public static bool BuscExisteHorasExtras(string emp, string cod, int sem, int año)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteHorasExtras(emp, cod, sem, año);
        }


        //metodo para buscar si existe revision grupo
        public static bool BuscExisteCharla(string emp, string sed, string area, DateTime fecha, string tipoeva)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteCharla(emp, sed, area, fecha, tipoeva);
        }


        //metodo para buscar si existe accidente
        public static bool BuscExisteAccidente(string cod, DateTime fecha)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteAccidente(cod, fecha);
        }


        //metodo para buscar si existe revision grupo
        public static bool BuscExisteActoCondicion(string cod, DateTime fecha, string emp, string sed, string area)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteActoCondicion(cod, fecha, emp, sed, area);
        }

        //metodo para buscar si existe tareaje trabajador
        public static bool BuscExisteTareajeTrabajador(string emp, string cod, DateTime fecha)
        {
            cd_planilla datos = new cd_planilla();
            return datos.BuscExisteTareajeTrabajador(emp, cod, fecha);
        }


        //GUARDAR ATENCIONES MEDICAS
        public void GuardarAtenMedica(DateTime fecha, Boolean quincena, string mes, string emp, string sed, string dni
            , string apenom, string area, string jefearea, string patologia, string diagnostico
            , string sintomas, string localidad
            , decimal cant_med, string accion_realizada
            , string parteCuerpo, string labor
            , DateTime hr_ent, DateTime hr_sal, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarAtenMedica(fecha, quincena, mes, emp, sed, dni
            , apenom, area, jefearea, patologia, diagnostico, sintomas, localidad
            , cant_med, accion_realizada, parteCuerpo, labor
            , hr_ent, hr_sal, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR CHARLA
        public void GuardarCharla(string cod, string emp, string sed
            , string area, string tipoeva
            , int num_trab, int num_eje, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarCharla(cod, emp, sed
            , area, tipoeva
            , num_trab, num_eje, fecha, sem, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR REGLA ORO
        public void GuardarReglaOro(int cod, string emp, string sed
            , string area, string tipo
            , string num_trab, string num_ejec, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarReglaOro(cod, emp, sed
            , area, tipo
            , num_trab, num_ejec, fecha, sem, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR REGLA PERCEPCION
        public void GuardarPercepcion(int cod, string emp, string sed
            , string area, string tipo
            , string num_trab, string num_ejec, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarPercepcion(cod, emp, sed
            , area, tipo
            , num_trab, num_ejec, fecha, sem, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR REGLA INSPECCION
        public void GuardarInspeccion(int cod, string emp, string sed
            , string area, string tipo
            , string num_trab, string num_ejec, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarInspeccion(cod, emp, sed
            , area, tipo
            , num_trab, num_ejec, fecha, sem, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR CHARLA
        public void GuardarActoCondicion(string cod, int sem, string emp, string sed
            , string area, string incidencia, string hallazgo, string peligro, string jerarquia
            , string hallazgo_desv, string medida_correc, string respon, DateTime fec_Rep, string est_insp
            , string medida_correc_2, string evidencia, DateTime fec_levant
            , string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActoCondicion(cod, sem, emp, sed
            , area, incidencia, hallazgo, peligro, jerarquia
            , hallazgo_desv, medida_correc, respon, fec_Rep
            , est_insp, medida_correc_2, evidencia, fec_levant
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR EFICIENCIA
        public void GuardarEficiencia(string id, int sem, string posicion, string area, string nivel
            , string estadoproceso, string año, string fechareq, string tiporeq, string sede
            , string timeproceso, string tipopersonal, string fechaterna, string fecharpta, int dias
            , string resptarea, string fecingreso, int duraciondias
            , int vencimiento, string tipoefectivo, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarEficiencia(id, sem, posicion, area, nivel
            , estadoproceso, año, fechareq, tiporeq, sede, timeproceso
            , tipopersonal, fechaterna, fecharpta, dias, resptarea, fecingreso, duraciondias
            , vencimiento, tipoefectivo, obs, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR COBERTURA
        public void GuardarCobertura(DateTime fecha, string turno, string jefatura
            , string fundo, string cultivo, string area, string recurso, string tiporecurso
            , string labor, string cant_prog, string obs, string totalprog, string area_extech
            , string area_, int año, string semana, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarCobertura(fecha, turno, jefatura
            , fundo, cultivo, area, recurso, tiporecurso
            , labor, cant_prog, obs, totalprog, area_extech
            , area_, año, semana, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR GRUPO
        public void GuardarRevisionGrupo(string emp, string sede
            , string codgrupo, int numpersona, string grupolabor, string labor
            , string fundo, string cabezal
            , string supervisor, string cultivo, DateTime fecgrupo
            , string meta, string preciounit, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarRevisionGrupo(emp, sede
            , codgrupo, numpersona, grupolabor, labor
            , fundo, cabezal
            , supervisor, cultivo, fecgrupo
            , meta, preciounit, obs, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR LABOR
        public void GuardarLabor(string cod, string codactividad, string actividad
            , string codtiplabor, string tipoactividad, string codgrupolabor
            , string grupolabor, string unidadmedida, decimal meta, string codavance
            , decimal preciounit
            , string obs, string hoja
            , string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarLabor(cod, codactividad, actividad
            , codtiplabor, tipoactividad, codgrupolabor
            , grupolabor, unidadmedida, meta, codavance
            , preciounit, obs, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR GRUPO LABOR
        public void GuardarGrupoLabor(string codgrupolabor
            , string grupolabor, string empresa
            , string etapa, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarGrupoLabor(codgrupolabor
            , grupolabor, empresa
            , etapa, obs, hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR ALTAS CESES
        public void GuardarAltasCeses(string cod, string apenom, string dni
            , DateTime fecing_empresa, DateTime fecing_planilla, string est_ant
            , string est_actual, string motcese
            , DateTime fecha_movimiento, string cod_cc, string razon_social
            , string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarAltasCeses(cod, apenom, dni, fecing_empresa, fecing_planilla, est_ant
                , est_actual, motcese, fecha_movimiento, cod_cc, razon_social
                , nombre_cc, gerencia, area
            , cargo, tipojornada, zona
                , hoja, fec_cre, usereg, hostname
                , fec_mov, usedit, useelim);
        }


        //GUARDAR ASISTENCIA DETALLADA
        public void GuardarAsistenciaDetallada(DateTime fecha, string empresa, string dni
            , string ape_nom, string hora_ingreso, string hora_salida
            , string hora_salida_refrigerio, string hora_retorno_refrigerio
            , string observacion, string pto_llegada, string gerencia, string area
            , string sub_area, string cargo, string cod_planilla, string usuario_R
            , string hoja, string estado
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarAsistenciaDetallada(fecha, empresa, dni
            , ape_nom, hora_ingreso, hora_salida
            , hora_salida_refrigerio, hora_retorno_refrigerio
            , observacion, pto_llegada, gerencia, area
            , sub_area, cargo, cod_planilla, usuario_R
            , hoja, estado, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }

        //GUARDAR COMPENSACION DEVOLUCION
        public void GuardarCompensacionDevolucion(string dni, string apenom, string empresa
            , string sede, string gerencia, string area, string cargo, decimal hr_comp, decimal dev_hr
            , decimal saldo, int sem, int año, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarCompensacionDevolucion(dni, apenom, empresa
            , sede, gerencia, area, cargo, hr_comp, dev_hr, saldo, sem, año
                , hoja, fec_cre, usereg, hostname
                , fec_mov, usedit, useelim);
        }



        //GUARDAR HORAS EXTRA
        public void GuardarHorasExtra(
              string dni, string legajo
            , string apenom, string emp, string gerencia, string area
            , string cargo, string zona, string planilla
            , string tipojornada, string fecha, string ceco, string nombceco
            , string codigopep, string codigografo, string codOperacion
            , string turno, string fecingreso, string horaIngreso
            , string fechaSalida, string HoraSalida, string horasNormales
            , string horasNocturnas, string horasExtras, string minutoTarde
            , string HoraRefrigerio, string totales
            , string año, string semana

            , string hoja
            , DateTime fec_cre, int usereg, string hostname
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarHorasExtra(
              dni, legajo
            , apenom, emp, gerencia, area
            , cargo, zona, planilla
            , tipojornada, fecha, ceco, nombceco
            , codigopep, codigografo, codOperacion
            , turno, fecingreso, horaIngreso
            , fechaSalida, HoraSalida, horasNormales
            , horasNocturnas, horasExtras, minutoTarde
            , HoraRefrigerio, totales
            , año, semana

            , hoja, fec_cre, usereg, hostname
                , fec_mov, usedit);
        }


        //GUARDAR TAREAJE TRABAJADOR
        public void GuardarActualizarTareajeTrabajador(string emp, string cod, string dni
            , string apenom, string fec_tar, string fecing, string feccese
            , string cod_cc, string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona
            , string est_trab, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActualizarTareajeTrabajador(emp, cod, dni, apenom, fec_tar, fecing, feccese
                , cod_cc, nombre_cc, gerencia, area
            , cargo, tipojornada, zona
                , est_trab, hoja, fec_cre, usereg, hostname
                , fec_mov, usedit, useelim);
        }




        //ACTUALIZAR ATENCIONES MEDICAS
        public void ActualizarAtenMedica(DateTime fecha, Boolean quincena, string mes, string emp, string sed, string dni
            , string apenom, string area, string jefearea, string patologia
            , string diagnostico, string sintomas, string localidad
            , decimal cant_med, string accion_realizada
            , string parteCuerpo, string labor
            , DateTime hr_ent, DateTime hr_sal, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarAtenMedica(fecha, quincena, mes, emp, sed, dni
            , apenom, area, jefearea, patologia, diagnostico, sintomas, localidad
            , cant_med, accion_realizada, parteCuerpo, labor, hr_ent, hr_sal, hoja, estado
                , fec_mov, usedit);
        }

        //ACTUALIZAR CHARLA
        public void ActualizarCharla(string cod, string emp, string sed
            , string area, string tipoeva
            , int num_trab, int num_eje, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarCharla(cod, emp, sed
            , area, tipoeva
            , num_trab, num_eje, fecha, sem, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR ACCIDENTE
        public void ActualizarAccidente(string cod, string emp, string sed
            , string area, string tipoacci
            , int cantidad, DateTime fecha, string sem, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarAccidente(cod, emp, sed
            , area, tipoacci
            , cantidad, fecha, sem, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR CHARLA
        public void ActualizarActoCondicion(string cod, int sem, string emp, string sed
            , string area, string incidencia, string hallazgo, string peligro, string jerarquia
            , string hallazgo_desv, string medida_correc, string respon, DateTime fec_Rep, string est_insp
            , string medida_correc_2, string evidencia, DateTime fec_levant
            , string hoja, string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarActoCondicion(cod, sem, emp, sed
            , area, incidencia, hallazgo, peligro, jerarquia
            , hallazgo_desv, medida_correc, respon, fec_Rep
            , est_insp, medida_correc_2, evidencia, fec_levant, hoja, estado
                , fec_mov, usedit);
        }



        //ACTUALIZAR ATENCIONES MEDICAS
        public void ActualizarEficiencia(string id, int sem, string posicion, string area, string nivel
            , string estadoproceso, string año, string fechareq, string nuevo, string sede
            , string timeproceso, string condicion
            , string fechaterna, string fecharpta, int dias
            , string resptarea, string fecingreso, int duraciondias
            , int vencimiento, string condicion2, string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarEficiencia(id, sem, posicion, area, nivel
            , estadoproceso, año, fechareq, nuevo, sede, timeproceso
            , condicion, fechaterna, fecharpta, dias, resptarea, fecingreso, duraciondias
            , vencimiento, condicion2, obs, hoja, estado
                , fec_mov, usedit);
        }



        //ACTUALIZAR ATENCIONES MEDICAS
        public void ActualizarCobertura(DateTime fecha, string turno, string jefatura
            , string fundo, string cultivo, string area, string recurso, string tiporecurso
            , string labor, string cant_prog, string obs, string totalprog, string area_extech
            , string area_, string semana, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarCobertura(fecha, turno, jefatura
            , fundo, cultivo, area, recurso, tiporecurso
            , labor, cant_prog, obs, totalprog, area_extech
            , area_, semana, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR ATENCIONES MEDICAS
        public void ActualizarRevisionGrupo(string emp, string sede
            , string codgrupo, int numpersona, string grupolabor, string labor
            , string fundo, string cabezal
            , string supervisor, string cultivo, DateTime fecgrupo
            , string meta, string preciounit, string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarRevisionGrupo(emp, sede
            , codgrupo, numpersona, grupolabor, labor
            , fundo, cabezal
            , supervisor, cultivo, fecgrupo
            , meta, preciounit, obs, hoja, estado
                , fec_mov, usedit);
        }


        //ACTUALIZAR LABOR
        public void ActualizarLabor(string cod, string codactividad, string actividad
            , string codtiplabor, string tipoactividad, string codgrupolabor
            , string grupolabor, string unidadmedida, decimal meta, string codavance
            , decimal preciounit
            , string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarLabor(cod, codactividad, actividad
            , codtiplabor, tipoactividad, codgrupolabor
            , grupolabor, unidadmedida, meta, codavance
            , preciounit, obs, hoja, estado
                , fec_mov, usedit);
        }

        //GUARDAR Y ACTUALIZAR PRODUCTIVIDAD
        public void GuardarActualizarProductividad(string empresa, string sede,
            string fecha, string dni, string nombres
            , string cabezal, string variedad, string presentacion
            , string grupolabor, string labor, decimal avance, decimal meta
            , string tipoprod, string obs, string hoja
            , string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActualizarProductividad(empresa, sede, 
                fecha, dni, nombres
            , cabezal, variedad, presentacion
            , grupolabor, labor, avance, meta
            , tipoprod, obs, hoja
            , estado, fec_cre, usereg
            , hostname, fec_mov, usedit, useelim);
        }

        //GUARDAR Y ACTUALIZAR SALDOS
        public void GuardarActualizarSaldo(DateTime fecha, string emp, string nombres, string dni, string correo
            , string telefono, decimal saldo, string activo
            , string est_pla, string acceso, int semana, int año
            , string obs, string hoja
            , string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActualizarSaldo(fecha, emp, nombres, dni, correo
            , telefono, saldo, activo
            , est_pla, acceso, semana, año, obs, hoja
            , estado, fec_cre, usereg
            , hostname, fec_mov, usedit, useelim);
        }

        //GUARDAR Y ACTUALIZAR SALDOS PLANILLA
        public void GuardarActualizarSaldoPlanilla(
              string emp, string dni, string nombres
            , string puntos, string codprod
            , string desprod, string monto, string igv
            , string total, string estadocanje, string fecha
            , string hoja, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActualizarSaldoPlanilla(
                emp, dni, nombres
            , puntos, codprod
            , desprod, monto, igv
            , total, estadocanje, fecha, hoja
            , fec_cre, usereg
            , hostname, fec_mov, usedit, useelim);
        }

        //GUARDAR Y ACTUALIZAR MOVIMIENTO Y CANJE
        public void GuardarActualizarMovimientoCanje(
            string emp, string dni
            , string nombres, string tipomov, string tipolog
            , string tipo_bono, string labor, string puntos, string codigo
            , string codpro, string despro, string est_canje, string fechamov
            , string fechaest, string fechaent, string estado, string correo, string direccion
            , string telefono, string u_registra, string u_edita, string u_entrega
            , string hoja, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim)
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActualizarMovimientoCanje(
            emp, dni, nombres
            , tipomov, tipolog
            , tipo_bono, labor, puntos, codigo
            , codpro, despro, est_canje, fechamov
            , fechaest, fechaent, estado, correo, direccion
            , telefono, u_registra, u_edita, u_entrega
            , hoja, fec_cre, usereg
            , hostname, fec_mov, usedit, useelim);
        }

        //GUARDAR Y ACTUALIZAR MOVIMIENTO Y CANJE
        public void GuardarActualizarParticipacionEncuesta(DateTime fecha,
             string emp, string sed, string tiptrab, string sexo
            , string gerencia, string area
            , string cantidad, string obs
            , string hoja, string estado, DateTime fec_cre, int usereg
            , string hostname, DateTime fec_mov, int usedit, int useelim
            )
        {
            cd_planilla datos = new cd_planilla();
            datos.GuardarActualizarParticipacionEncuesta(
              fecha, emp, sed, tiptrab, sexo
            , gerencia, area, cantidad, obs
            , hoja, estado, fec_cre, usereg
            , hostname, fec_mov, usedit, useelim
            );
        }

        //ACTUALIZAR GRUPO LABOR
        public void ActualizarGrupoLabor(string codgrupolabor
            , string grupolabor, string empresa
            , string etapa
            , string obs, string hoja
            , string estado, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarGrupoLabor(codgrupolabor
            , grupolabor, empresa
            , etapa, obs, hoja, estado
                , fec_mov, usedit);
        }

        //ACTUALIZAR ALTAS Y CESES
        public void ActualizarAltasCeses(string cod, string apenom, string dni
            , DateTime fecing_empresa, DateTime fecing_planilla, string est_ant, string est_actual, string motcese
            , DateTime fecha_movimiento, string cod_cc, string razon_social
            , string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona, string hoja
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarAltasCeses(cod, apenom, dni, fecing_empresa, fecing_planilla, est_ant
                , est_actual, motcese, fecha_movimiento, cod_cc, razon_social
                , nombre_cc, gerencia, area
            , cargo, tipojornada, zona, hoja
                , fec_mov, usedit);
        }


        //ACTUALIZAR ASISTENCIA DETALLADA
        public void ActualizarAsistenciaDetallada(DateTime fecha, string empresa, string dni
            , string ape_nom, string hora_ingreso, string hora_salida
            , string hora_salida_refrigerio, string hora_retorno_refrigerio
            , string observacion, string pto_llegada, string gerencia, string area
            , string sub_area, string cargo, string cod_planilla, string usuario_R
            , string hoja, string estado
            , DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarAsistenciaDetallada(fecha, empresa, dni
            , ape_nom, hora_ingreso, hora_salida
            , hora_salida_refrigerio, hora_retorno_refrigerio
            , observacion, pto_llegada, gerencia, area
            , sub_area, cargo, cod_planilla, usuario_R, hoja
             , estado, fec_mov, usedit);
        }


        //ACTUALIZAR COMPENSACION DEVOLUCION
        public void ActualizarCompensacionDevolucion(string dni, string apenom, string empresa
            , string sede, string gerencia, string area, string cargo, decimal hr_comp, decimal dev_hr
            , decimal saldo, int sem, int año, string hoja, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarCompensacionDevolucion(dni, apenom, empresa
            , sede, gerencia, area, cargo, hr_comp, dev_hr, saldo, sem, año, hoja
                , fec_mov, usedit);
        }


        //ACTUALIZAR COMPENSACION DEVOLUCION
        public void ActualizarHorasExtras(string emp, DateTime fecha, string cod
            , string dni, string apenom, string gerencia, string area
            , string cargo, string zona, string planilla
            , string tipojornada, string fecingreso
            , string feccese, string codigocc, string conbrecc
            , int sem, int año

            , string Nocturnos, string Diurnos, string Descansos, string Feriados
            , string DM, string Licencia_Goce, string Subsidios, string Total_Dia_Efec
            , string Faltas, string Suspensiones, string Permisos, string Vacaciones
            , string Total_Dias_No_Lab

            , string diu25, string noc25, string diu35
            , string noc35, string total, string ftd, string ftn
            , string diasafam, string diasbeta, string dessemal, string dessemanlnoct

            , string Total_Otros, string H_Efec_Laboradas, string Total_H_Efec
            , string Horas_Feriado_Sem, string Total_Frd_Sem

            , string hoja, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarHorasExtras(emp, fecha, cod, dni, apenom
                , gerencia, area
            , cargo, zona, planilla
            , tipojornada
                , fecingreso
            , feccese, codigocc, conbrecc, sem, año

            , Nocturnos, Diurnos, Descansos, Feriados
            , DM, Licencia_Goce, Subsidios, Total_Dia_Efec
            , Faltas, Suspensiones, Permisos, Vacaciones
            , Total_Dias_No_Lab
            , diu25, noc25, diu35, noc35
            , total, ftd, ftn
            , diasafam, diasbeta, dessemal, dessemanlnoct

            , Total_Otros, H_Efec_Laboradas, Total_H_Efec
            , Horas_Feriado_Sem, Total_Frd_Sem

            , hoja
                , fec_mov, usedit);
        }


        //ACTUALIZAR ALTAS Y CESES
        public void ActualizarTareajeTrabajador(string emp, string cod, string dni
            , string apenom, DateTime fec_tar, DateTime fecing, string feccese
            , string cod_cc, string nombre_cc, string gerencia, string area
            , string cargo, string tipojornada, string zona
            , string est_trab, string hoja, DateTime fec_mov, int usedit)
        {
            cd_planilla datos = new cd_planilla();
            datos.ActualizarTareajeTrabajador(emp, cod, dni, apenom, fec_tar, fecing
                , feccese, cod_cc, nombre_cc, gerencia, area
            , cargo, tipojornada, zona
                , est_trab, hoja, fec_mov, usedit);
        }



        //ELIMINAR TAREAJE TRABAJADOR
        public void EliminarTareajeTrabajador(
            string emp, string fecha)
        {
            cd_planilla datos = new cd_planilla();
            datos.EliminarTareajeTrabajador(
                emp, fecha);
        }

        //ELIMINAR HORAS EXTRA
        public void EliminarHorasExtras(
            string emp, string año, string semana)
        {
            cd_planilla datos = new cd_planilla();
            datos.EliminarHorasExtra(
                emp, año, semana);
        }



    }
}
