using System;

namespace CapaEntidad
{
    public class ce_tareofinalOF
    {
        public string codigo { get; set; }
        public string ape_nom { get; set; }
        public string dni { get; set; }
        public string cod_planilla { get; set; }
        public DateTime fecha_ing { get; set; } // date (fecha)
        public string empresa { get; set; }
        public string sede { get; set; }
        public string fundo { get; set; }
        public string cargo { get; set; }
        public string area { get; set; }
        public string gerencia { get; set; }
        public string actividad { get; set; }
        public string labor { get; set; }
        public string labor_correcta { get; set; }
        public string centro_costo { get; set; }
        public string jornada { get; set; }
        public DateTime fecha_tareo { get; set; } // date (fecha)
        public TimeSpan hora_tareo { get; set; } // time (solo hora)
        public string dnisupervisor { get; set; }
        public string nombresupervisor { get; set; }
        public DateTime fecha_ingreso_tareo { get; set; } // date (fecha)
        public TimeSpan hora_ingreso_tareo { get; set; } // time (solo hora)
        public DateTime fecha_salida_tareo { get; set; } // date (fecha)
        public TimeSpan hora_salida_tareo { get; set; } // time (solo hora)
        public TimeSpan horas_en_sede { get; set; } // time (solo hora)
        public TimeSpan refrigerio { get; set; } // time (solo hora)
        public TimeSpan horas_normales { get; set; } // time (solo hora)
        public DateTime fecha_ingreso_real { get; set; } // date (fecha)
        public TimeSpan hora_ingreso_real { get; set; } // time (solo hora)
        public DateTime fecha_salida_real { get; set; } // date (fecha)
        public TimeSpan hora_salida_real { get; set; } // time (solo hora)
        public TimeSpan horas_pagar { get; set; } // time (solo hora)
        public TimeSpan horas_compensadas { get; set; } // time (solo hora)
        public TimeSpan devolución_horas { get; set; } // time (solo hora)
        public DateTime día_tareo { get; set; } // date (fecha)
        public TimeSpan horas_nocturnas { get; set; } // time (solo hora)
        public string turno { get; set; }
        public string usuario_registro { get; set; }
        public DateTime fecha_registro { get; set; } // date (fecha)
        public string usuario_modificación { get; set; }
        public DateTime fecha_modificación { get; set; } // date (fecha)
        public float num_hora_ingreso_tareo { get; set; }
        public float num_hora_ingreso_real { get; set; }
        public float num_hora_salida_tareo { get; set; }
        public float num_hora_salida_real { get; set; }
        public float horas_no_validadas_ingreso { get; set; }
        public float horas_no_validadas_ingreso_final { get; set; }
        public float horas_no_validadas_salida { get; set; }
        public float horas_no_validadas_salida_final { get; set; }
        public float hh_no_validadas_final { get; set; }
        public float horas_extra { get; set; }
        public float num_horas_compensadas { get; set; }
        public float num_devolución_horas { get; set; }
        public float almuerzo { get; set; }
        public float cena { get; set; }
        public float alimentación_total { get; set; }
        public float horas_efectivas_fundo { get; set; }
        public float sobretiempo_ingresado { get; set; }
        public float sobretiempo_final { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; } // datetime
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; } // datetime
        public int useedit { get; set; }
    }

    public class TareoFinal
    {
        public string Codigo { get; set; }
        public string Ape_Nom { get; set; }
        public string Dni { get; set; }
        public string Cod_Planilla { get; set; }
        public DateTime? Fecha_Ing { get; set; }
        public string Empresa { get; set; }
        public string Sede { get; set; }
        public string Fundo { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Gerencia { get; set; }
        public string Actividad { get; set; }
        public string Labor { get; set; }
        public string Labor_Correcta { get; set; }
        public string Centro_Costo { get; set; }
        public string Jornada { get; set; }
        public DateTime? Fecha_Tareo { get; set; }
        public TimeSpan? Hora_Tareo { get; set; }
        public string DniSupervisor { get; set; }
        public string NombreSupervisor { get; set; }
        public DateTime? Fecha_Ingreso_Tareo { get; set; }
        public TimeSpan? Hora_Ingreso_Tareo { get; set; }
        public DateTime? Fecha_Salida_Tareo { get; set; }
        public TimeSpan? Hora_Salida_Tareo { get; set; }
        public TimeSpan? Horas_En_Sede { get; set; }
        public TimeSpan? Refrigerio { get; set; }
        public TimeSpan? Horas_Normales { get; set; }
        public DateTime? Fecha_Ingreso_Real { get; set; }
        public TimeSpan? Hora_Ingreso_Real { get; set; }
        public DateTime? Fecha_Salida_Real { get; set; }
        public TimeSpan? Hora_Salida_Real { get; set; }
        public TimeSpan? Horas_Pagar { get; set; }
        public TimeSpan? Horas_Compensadas { get; set; }
        public TimeSpan? Devolucion_Horas { get; set; }
        public DateTime? Dia_Tareo { get; set; }
        public TimeSpan? Horas_Nocturnas { get; set; }
        public string Turno { get; set; }
        public string Usuario_Registro { get; set; }
        public DateTime? Fecha_Registro { get; set; }
        public string Usuario_Modificacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public double? Num_Hora_Ingreso_Tareo { get; set; }
        public double? Num_Hora_Ingreso_Real { get; set; }
        public double? Num_Hora_Salida_Tareo { get; set; }
        public double? Num_Hora_Salida_Real { get; set; }
        public double? Horas_No_Validadas_Ingreso { get; set; }
        public double? Horas_No_Validadas_Ingreso_Final { get; set; }
        public double? Horas_No_Validadas_Salida { get; set; }
        public double? Horas_No_Validadas_Salida_Final { get; set; }
        public double? HH_NO_Validadas_Final { get; set; }
        public double? Horas_extra { get; set; }
        public double? Num_Horas_Compensadas { get; set; }
        public double? Num_Devolucion_Horas { get; set; }
        public double? Almuerzo { get; set; }
        public double? Cena { get; set; }
        public double? Alimentacion_Total { get; set; }
        public double? Horas_Efectivas_Fundo { get; set; }
        public double? Sobretiempo_Ingresado { get; set; }
        public double? Sobretiempo_Final { get; set; }
        public string Hoja { get; set; }
        public string Estado { get; set; }
        public DateTime? FecCre { get; set; }
        public int? UseReg { get; set; }
        public string Hostname { get; set; }
        public DateTime? FecEdit { get; set; }
        public int? UseEdit { get; set; }
    }


}