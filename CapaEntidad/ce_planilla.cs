using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidad
{
    public class ce_planilla
    {
        //COMPENSACION DEVOLUCION
        public static DateTime FechaAlta { get; set; }
        public static DateTime FechaMovimiento { get; set; }
        public static DateTime FechaCompen { get; set; }
        public static DateTime FechaTareado { get; set; }
        public static string codAlta { get; set; }
        public static string DniAlta { get; set; }
        public static string DniCompen { get; set; }
        public static string DniTareado { get; set; }

        //HORAS EXTRAS

        public static string Dni_Extra { get; set; }
        public static DateTime FechaIni_Extra { get; set; }
        public static DateTime FechaFin_Extra { get; set; }
    }

    public class ce_compensacion
    {
        public string dni { get; set; }
        public string apenom { get; set; }
        public DateTime? fecingreso { get; set; }
        public string empresa { get; set; }
        public string sede { get; set; }
        public string gerencia { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public decimal hr_comp { get; set; }
        public decimal dev_hr { get; set; }
        public decimal saldo { get; set; }
        public int semana { get; set; }
        public int año { get; set; }
        public string hoja { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
        public int useelim { get; set; }
    }

    public class ce_horasextra
    {
        public string dni { get; set; }
        public string legajo { get; set; }
        public string apenom { get; set; }
        public string empresa { get; set; }
        public string gerencia { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public string zona { get; set; }
        public string planilla { get; set; }
        public string tipojornada { get; set; }
        public DateTime? fecha { get; set; }
        public string ceco { get; set; }
        public string nombrececo { get; set; }
        public string codigopep { get; set; }
        public string codigografo { get; set; }
        public string codigooperacion { get; set; }
        public string turno { get; set; }
        public DateTime? fechaingreso { get; set; }
        public TimeSpan? horaingreso { get; set; }
        public DateTime? fechasalida { get; set; }
        public TimeSpan? horasalida { get; set; }
        public float horasnormales { get; set; }
        public float horasnocturnas { get; set; }
        public float horasextras { get; set; }
        public float minutostardanza { get; set; }
        public float horasrefrigerio { get; set; }
        public float totales { get; set; }
        public float año { get; set; }
        public float semana { get; set; }
        public string hoja { get; set; }
        public DateTime feccre { get; set; }
        public int usereg { get; set; }
        public string hostname { get; set; }
        public DateTime fecedit { get; set; }
        public int useedit { get; set; }
    }

    public class ce_vacacion_trunca
    {
        public string Cod { get; set; }
        public string Dni { get; set; }
        public string ApeNom { get; set; }
        public DateTime? FecIngreso { get; set; }
        public DateTime? FecMigracion { get; set; }  // Agregado según la columna de la tabla SQL
        public DateTime? FecCese { get; set; }
        public string Planilla { get; set; }  // La columna Planilla no estaba en la clase original
        public string Area { get; set; }
        public string SitEspecial { get; set; }
        public string CondTrabajador { get; set; }
        public string Ceco { get; set; }
        public string Zona { get; set; }  // La columna Zona no estaba en la clase original
        public string UltPago { get; set; }  // La columna UltPago no estaba en la clase original
        public DateTime? FecUltPago { get; set; }  // La columna FecUltPago no estaba en la clase original
        public string Gerencia { get; set; }
        public string Cargo { get; set; }
        public string NivelJerarquico { get; set; }
        public string TipoTrab { get; set; }
        public string AsigFamiliar { get; set; }
        public double? RemBasica { get; set; }
        public double? TotalDiasRH { get; set; }  // Correspondencia con la columna TotalDiasRH
        public double? TotalDiasCont { get; set; }  // Correspondencia con la columna TotalDiasCont
        public double? TotalVacaciones { get; set; }  // Correspondencia con la columna TotalVaciones
        public double? TotalIndemnizacion { get; set; }  // Correspondencia con la columna TotalIndemizacion
        public double? TotalValorizacion { get; set; }  // Correspondencia con la columna TotalValorizacion
        public double? Indemnizados { get; set; }
        public double? Pendientes { get; set; }
        public double? Truncos { get; set; }
        public string Empresa { get; set; }
        public string Sede { get; set; }
        public int? Mes { get; set; }  // Correspondencia con la columna Mes
        public int? Año { get; set; }
        public string Hoja { get; set; }
        public DateTime? FecCre { get; set; }
        public int? UseReg { get; set; }
        public string Hostname { get; set; }
        public DateTime? FecEdit { get; set; }
        public int? UseEdit { get; set; }
        public int? UseElim { get; set; }
    }

    public class CeImpresionStickerPersona
    {
        public int Id { get; set; }
        public DateTime? FecProceso { get; set; }
        public int? IdGrupoPersona { get; set; }

        public string IdNave { get; set; }
        public string Nave { get; set; }

        public string IdLinea { get; set; }
        public string Linea { get; set; }

        public string IdPuestoTrabajo { get; set; }
        public string PuestoTrabajo { get; set; }

        public string Dni { get; set; }
        public string IdCodigo { get; set; }
        public string Codigo { get; set; }

        public int? Cantidad { get; set; }

        public string Obs { get; set; }

        public string Estado { get; set; }

        public DateTime? FecCre { get; set; }
        public int? UseReg { get; set; }
        public string Hostname { get; set; }

        public DateTime? FecEdit { get; set; }
        public int? UseEdit { get; set; }
        public int? UseElim { get; set; }
        public string SessionId { get; set; }

    }

    public class CeImpresionStickerPresentacion
    {
        public int Id { get; set; } // Corresponde al campo [Id]
        public int? IdPre { get; set; } // Corresponde al campo [IdPre]
        public string Cod { get; set; } // Corresponde al campo [Cod]
        public string Presentacion { get; set; } // Corresponde al campo [Presentacion]
        public decimal? Precio { get; set; } // Corresponde al campo [Precio]
        public int? Cantidad { get; set; } // Corresponde al campo [cantidad]
        public string Obs { get; set; } // Corresponde al campo [Obs]
        public string Estado { get; set; } // Corresponde al campo [Estado]
        public DateTime? FecCre { get; set; } // Corresponde al campo [FecCre]
        public int? UseReg { get; set; } // Corresponde al campo [UseReg]
        public string Hostname { get; set; } // Corresponde al campo [Hostname]
        public DateTime? FecEdit { get; set; } // Corresponde al campo [FecEdit]
        public int? UseEdit { get; set; } // Corresponde al campo [UseEdit]
        public int? UseElim { get; set; } // Corresponde al campo [UseElim]
        public string SessionId { get; set; } // Corresponde al campo [SessionId]
    }

    public class ce_pedateosticker
    {
        //public int Id { get; set; }                         // [Id] - PRIMARY KEY IDENTITY
        public string FechaProceso { get; set; }             // fecha proceso
        public string CadOriginal { get; set; }             // [CadOriginal] varchar(480)
        public int? CodPreStick { get; set; }               // [CodPreStick] int
        public string DetGrupo { get; set; }                // [DetGrupo] varchar(180)
        public int? CodGrupoStick { get; set; }             // [CodGrupoStick] int
        public int? IdNave { get; set; }             // id nave int
        public string Nave { get; set; }                    // [Nave] varchar(180)
        public int? IdLinea { get; set; }             // id nave int
        public string Linea { get; set; }                   // [Linea] varchar(180)
        public string Obs { get; set; }                     // [Obs] varchar(1000)
        public string Estado { get; set; }                  // [Estado] varchar(1)
        public DateTime? FecCre { get; set; }               // [FecCre] datetime
        public int? UseReg { get; set; }                    // [UseReg] int
        public string Hostname { get; set; }                // [Hostname] varchar(50)
        public DateTime? FecEdit { get; set; }              // [FecEdit] datetime
        public int? UseEdit { get; set; }                   // [UseEdit] int
        public int? UseElim { get; set; }                   // [UseElim] int
        public string SessionId { get; set; }               // [SessionId] varchar(50)
    }

    public class ce_datosPedateo
    {
        public static string Status { get; set; }
        public static string Fecha { get; set; }
        public static string Nave { get; set; }
        public static string Linea { get; set; }

    }

    public class EmployeeAttendanceModel
    {
        public int UDGenerico { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string TipoLectura { get; set; }

        public int Stickers { get; set; }   // ← Nueva columna
        public string Obs { get; set; } // Corresponde al campo [Obs]
    }

    public class ce_presetancion_destajo
    {
        public int? Id { get; set; }
        public string Cod { get; set; }
        public string Descripcion { get; set; }

        public int? Cantidad { get; set; }   // ← Nueva columna
        public string Tipo { get; set; } // Corresponde al campo tipo
        public string CodExtech { get; set; } // Corresponde al campo tipo
        public decimal Precio { get; set; } // Corresponde al campo tipo
        public string Obs { get; set; } // Corresponde al campo [Obs]
        public string Estado { get; set; } // Corresponde al campo [Estado]
        public DateTime? FecCre { get; set; } // Corresponde al campo [FecCre]
        public int? UseReg { get; set; } // Corresponde al campo [UseReg]
        public string Hostname { get; set; } // Corresponde al campo [Hostname]
        public DateTime? FecEdit { get; set; } // Corresponde al campo [FecEdit]
        public int? UseEdit { get; set; } // Corresponde al campo [UseEdit]
        public int? UseElim { get; set; } // Corresponde al campo [UseElim]
    }

    public class ResultadoBusquedaSticker
    {
        public DataTable Detalle { get; set; }
        public int StickerCorrecto { get; set; }
        public int StickerIncorrecto { get; set; }
        public int TotalCajas { get; set; }
        public int CajasErradas { get; set; }
    }

    public class ce_destajo_uva
    {
        public DateTime? fecha { get; set; }
        public int? centro { get; set; }
        public int? nave { get; set; }
        public string turno { get; set; }
        public int? materiaprima { get; set; }
        public string tipotareo { get; set; }
        public string grupo { get; set; }
        public string npersonal { get; set; }
        public string dni { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public string nombres { get; set; }
        public DateTime? fechaingreso { get; set; }
        public string formato { get; set; }
        public string sticker { get; set; }
    }

    public class ResumenEnvioDto
    {
        public DateTime? Fecha { get; set; }
        public string Presentacion { get; set; }
        public int Seleccion { get; set; }
        public int Pesado { get; set; }
        public int Empaque { get; set; }

        // 👉 TOTAL POR FILA
        public int Total => Seleccion + Pesado + Empaque;
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int TotalEnviados { get; set; }
        public T Data { get; set; }

        // 🔥 NUEVO – para depuración real
        public int StatusCode { get; set; }
        public string RawResponse { get; set; }

    }

    public class ce_tareo_api
    {
        public DateTime? Fecha { get; set; }
        public int? Centro { get; set; }
        public int? Nave { get; set; }
        public string Turno { get; set; }
        public int? MateriaPrima { get; set; }
        public string TipoTareo { get; set; }

        public List<ce_trabajador> Seleccion { get; set; }
        public List<ce_trabajador> Pesado { get; set; }
        public List<ce_trabajador> Empaque { get; set; }
    }

    public class ce_trabajador
    {
        public string NroPersonal { get; set; }
        public string DNI { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Formato { get; set; }
        public string Sticker { get; set; }
    }

    public class ConfirmacionResponse
    {
        public string mensaje { get; set; }
    }


}
