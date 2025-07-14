
using System;

namespace CapaEntidad
{
    public partial class ce_equipoti
    {
        public static string CodTrabajadorExist { get; set; }
        public static string EmpleadorExist { get; set; }
        public static string EdadEmpleadorExist { get; set; }
        public static string EmpresaEmpleadorExist { get; set; }
        public static string SedeEmpleadorExist { get; set; }
        public static string AreaEmpleadorExist { get; set; }
        public static string CargoEmpleadorExist { get; set; }
        public static string EstadoEmpleadorExist { get; set; }
        public static string NombreEmpleadorExist { get; set; }
        public static string ApellidoEmpleadorExist { get; set; }
        public static string SexoEmpleadorExist { get; set; }
        public static string CorreoEmpleadorExist { get; set; }
        public static DateTime FecNacEmpleadorExist { get; set; }

        //RECIBE DATOS PARA ENVIAR A FORMULARIO AGREGAR EQUIPO
        public static string CodigoEquipo { get; set; }
        public static string TipoEquipo { get; set; }
        public static string EmpresaEquipo { get; set; }
        public static string SedeEquipo { get; set; }
        public static string UsuarioEquipo { get; set; }
        public static string GerenciaEquipo { get; set; }
        public static string AreaEquipo { get; set; }
        public static string MarcaEquipo { get; set; }
        public static string ModeloEquipo { get; set; }
        public static string SerieEquipo { get; set; }
        public static string IMEIEquipo { get; set; }
        public static string CargadorEquipo { get; set; }
        public static string MACEthernetEquipo { get; set; }
        public static string MACWifiEquipo { get; set; }
        //
        public static string MACEquipoEquipo { get; set; }
        public static string EstadoEquipo { get; set; }
        public static string SISOperativoEquipo { get; set; }
        public static string ProcesadorEquipo { get; set; }
        public static string MemoriaEquipo { get; set; }
        public static string DiscoDuroEquipo { get; set; }
        public static string DevEventEquipo { get; set; }
        public static string DniRespEquipo { get; set; }
        public static string ResponsableEquipo { get; set; }
        public static string ObservacionEquipo { get; set; }
        public static string UbicacionEquipo { get; set; }
        public static DateTime FechaEntregaEquipo { get; set; }
        public static DateTime FechaCompraEquipo { get; set; }
        //
        public static DateTime FechaMantenimiento { get; set; }
        public static string ObservacionMantenimiento { get; set; }
        public static DateTime FechaGarantiaEquipo { get; set; }
        public static DateTime FechaDevolucionEquipo { get; set; }
        public static string ProveedorEquipo { get; set; }
        public static string ReparacionEquipo { get; set; }
        public static string PropioEquipo { get; set; }
        public static string Equipo { get; set; }
        public static string NumeroEquipo { get; set; }
        public static string CantidadEquipo { get; set; }
        public static string ActivoEquipo { get; set; }
        public static string CodActivo { get; set; }

        //ENCABEZADO DOCUMENTO CONTROLADO
        public static string NombreHoja { get; set; }
        public static string TipoHoja { get; set; }
        public static string CodigoHoja { get; set; }
        public static string VersionHoja { get; set; }
        public static DateTime FechaHoja { get; set; }
        public static int PaginaHoja { get; set; }
        public static string EmpresaHoja { get; set; }
        public static string RucHoja { get; set; }
        public static string DireccionHoja { get; set; }
        public static string InspectorHoja { get; set; }
        public static int DniInspectorHoja { get; set; }

        //
        public static byte[] DocProveedor { get; set; }

    }
}
