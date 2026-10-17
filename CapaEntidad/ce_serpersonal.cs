using System;

namespace CapaEntidad
{
    public class sper_repasistencia
    {
        public string asistencia { get; set; }
        public string punto_de_control { get; set; }
        public string tipo { get; set; }
        public DateTime fecha_hora_asistencia { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public float año { get; set; }
        public float semana { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }

    }

    public class sper_subsidio
    {
        public string id { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string dni { get; set; }
        public string nombrecompleto { get; set; }
        public string area { get; set; }
        public string tipotrabajador { get; set; }
        public string tipodescanso { get; set; }
        public DateTime? feciniciosub { get; set; }
        public DateTime? fecfinsub { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public int dias { get; set; }
        public DateTime? fechapresentacion { get; set; }
        public DateTime? fechaseguimiento { get; set; }
        public float montosubsidio { get; set; }
        public float montocontabilidad { get; set; }
        public string contingencia { get; set; }
        public string statusbienestar { get; set; }
        public string nittcitt { get; set; }
        public string obs { get; set; }
        public float añocarga { get; set; }
        public float semana { get; set; }
        public string hoja { get; set; }
        public string estado { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class SperMarcacionCampamento
    {
        public DateTime? FechaMarcacion { get; set; }     // date NULL
        public TimeSpan? HoraMarca { get; set; }          // time NULL
        public string TipoMarcacion { get; set; }         // varchar NULL
        // El orden de estas propiedades es el que usa SqlBulkCopy para
        // mapear contra la tabla: no lleva ColumnMappings, asi que la
        // correspondencia es por POSICION, no por nombre.
        public string Resultado { get; set; }             // varchar NULL  (col 4 del Excel)
        public string Motivo { get; set; }                // varchar NULL  (col 5 del Excel)
        public string Marcador { get; set; }              // varchar NULL
        public string Empresa { get; set; }               // varchar NULL
        public string Sede { get; set; }                  // varchar NULL
        public string CodCampamento { get; set; }         // varchar NULL
        public string Campamento { get; set; }            // varchar NULL
        public string CodCarpa { get; set; }              // varchar NULL
        public string Carpa { get; set; }                 // varchar NULL
        public string CodEspacio { get; set; }            // varchar NULL
        public string Espacio { get; set; }               // varchar NULL
        public string DNI { get; set; }                   // varchar NULL
        public string NombreCompleto { get; set; }        // varchar NULL
        public string EmpresaTrabajador { get; set; }     // varchar NULL
        public string Gerencia { get; set; }              // varchar NULL
        public string Area { get; set; }                  // varchar NULL
        public int? Ano { get; set; }                     // int NULL
        public int? Semana { get; set; }                  // int NULL
        public string Hoja { get; set; }                  // varchar NULL
        public string Estado { get; set; }                // varchar NULL
        public DateTime? FecCre { get; set; }             // datetime NULL
        public int? UseReg { get; set; }                  // int NULL
        public string Hostname { get; set; }              // varchar NULL
        public DateTime? FecEdit { get; set; }            // datetime NULL
        public int? UseEdit { get; set; }                 // int NULL
    }

    public class SperOcupabilidadCampamento
    {
        public int? Campamento { get; set; }                    // int NULL
        public string Nombre { get; set; }                      // varchar(180)
        public DateTime? FechaRegistro { get; set; }            // datetime NULL
        public string RazonSocial { get; set; }                 // varchar(180)
        public string Sede { get; set; }                        // varchar(180)
        public string Estad { get; set; }                       // varchar(20)
        public decimal? EspaciosDisponibles { get; set; }        // decimal(18,2) NULL
        public decimal? EspaciosOcupados { get; set; }           // decimal(18,2) NULL
        public decimal? EspaciosTotal { get; set; }              // decimal(18,2) NULL
        public decimal? Ocupabilidad { get; set; }               // decimal(18,2) NULL
        public int? Ano { get; set; }                            // int NULL
        public int? Semana { get; set; }                         // int NULL

        // Campos extra estándar
        public string Hoja { get; set; }                         // varchar(50) NULL
        public string Estado { get; set; }                       // varchar(20) NULL
        public DateTime? FecCre { get; set; }                    // datetime NULL
        public int? UseReg { get; set; }                         // int NULL
        public string Hostname { get; set; }                     // varchar(80) NULL
        public DateTime? FecEdit { get; set; }                   // datetime NULL
        public int? UseEdit { get; set; }                        // int NULL
    }

    public class SperAtencionesTrabajador
    {
        public int? Correlativo { get; set; }
        public DateTime? Fecha { get; set; }
        public string DNITrabajador { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Empresa { get; set; }
        public string Sede { get; set; }
        public string Area { get; set; }
        public string ComedorZona { get; set; }
        public int? CantPersonasAtendidas { get; set; }
        public string Supervisor { get; set; }
        public string MotivoAtencion { get; set; }
        public string Detalle { get; set; }
        public string Tipo { get; set; }
        public string QuejaOSugerencia { get; set; }
        public string PlanDeAccion { get; set; }
        public string AtendidoPor { get; set; }
        public DateTime? FechaSolucion { get; set; }
        public int? Ano { get; set; }
        public int? Semana { get; set; }
        public string Hoja { get; set; }
        public string Estado { get; set; }
        public DateTime FecCre { get; set; }
        public int UseReg { get; set; }
        public string Hostname { get; set; }
        public DateTime FecEdit { get; set; }
        public int UseEdit { get; set; }
    }

    public class SperEfectividadAtenciones
    {
        public DateTime? Fecha { get; set; }
        public string Empresa { get; set; }
        public string Sede { get; set; }
        public string Area { get; set; }
        public decimal? Efectividad { get; set; }
        public string ComedorZona { get; set; }
        public string Observacion { get; set; }
        public int? Ano { get; set; }
        public int? Semana { get; set; }
        public string Hoja { get; set; }
        public string Estado { get; set; }
        public DateTime FecCre { get; set; }
        public int UseReg { get; set; }
        public string Hostname { get; set; }
        public DateTime FecEdit { get; set; }
        public int UseEdit { get; set; }
    }

    public class SperMovimientoCampamento
    {
        public DateTime? FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        // El orden de estas propiedades es el que usa SqlBulkCopy para
        // mapear contra la tabla: no lleva ColumnMappings, asi que la
        // correspondencia es por POSICION, no por nombre.
        public string Detalle { get; set; }               // col 3 del Excel
        // Se llama EstadoMovimiento y no Estado porque la tabla ya tiene una
        // columna Estado, la de auditoria que vale "S".
        public string EstadoMovimiento { get; set; }      // col 4 del Excel
        public string Origen { get; set; }

        public string Empresa { get; set; }
        public string Sede { get; set; }

        public int? CodCampamento { get; set; }
        public string Campamento { get; set; }

        public int? CodCarpa { get; set; }
        public string Carpa { get; set; }
        public string TipoOcupante { get; set; }

        public int? CodEspacio { get; set; }
        public string Espacio { get; set; }

        public string Dni { get; set; }
        public string NombreCompleto { get; set; }
        public string EmpresaTrabajador { get; set; }
        public string Gerencia { get; set; }
        public string Area { get; set; }

        public string BonoAlimentacion { get; set; }
        public DateTime? FechaPosibleSalida { get; set; }

        public string Usuario { get; set; }
        public DateTime? FechaHoraRegistro { get; set; }

        public string ModificadoAnuladoPor { get; set; }  // col 24 del Excel
        public DateTime? FechaModificacion { get; set; }  // col 25 del Excel

        public int? Ano { get; set; }
        public int? Semana { get; set; }

        public string Hoja { get; set; }
        public string Estado { get; set; }

        public DateTime? FecCre { get; set; }
        public int? UseReg { get; set; }
        public string Hostname { get; set; }

        public DateTime? FecEdit { get; set; }
        public int? UseEdit { get; set; }
    }

    public class SperStatusCampamento
    {
        public string Empresa { get; set; }
        public string Sede { get; set; }

        public int? CodCampamento { get; set; }
        public string Campamento { get; set; }
        public string EstadoCampamento { get; set; }

        public int? CodCarpa { get; set; }
        public string Carpa { get; set; }
        public string TipoOcupante { get; set; }
        public string EstadoCarpa { get; set; }

        public int? CodEspacio { get; set; }
        public string Espacio { get; set; }
        public string EstadoEspacio { get; set; }

        public string Situacion { get; set; }
        // El orden de estas propiedades es el que usa SqlBulkCopy para
        // mapear contra la tabla: no lleva ColumnMappings, asi que la
        // correspondencia es por POSICION, no por nombre.
        public string Programado { get; set; }            // col 14 del Excel
        public DateTime? FechaProgramada { get; set; }    // col 15 del Excel

        public string Dni { get; set; }
        public string NombreCompleto { get; set; }

        public string Vigencia { get; set; }              // col 18 del Excel
        public string Motivo { get; set; }                // col 19 del Excel

        public string EmpresaTrabajador { get; set; }
        public string Gerencia { get; set; }
        public string Area { get; set; }

        public DateTime? FechaAsignacion { get; set; }

        public int? Ano { get; set; }
        public int? Semana { get; set; }

        public string Hoja { get; set; }
        public string Estado { get; set; }

        public DateTime? FecCre { get; set; }
        public int? UseReg { get; set; }
        public string Hostname { get; set; }

        public DateTime? FecEdit { get; set; }
        public int? UseEdit { get; set; }
    }

}
