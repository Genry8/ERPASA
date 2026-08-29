using System;

namespace CapaEntidad
{
    public class ce_logistica
    {
        public static string CodTiExist { get; set; }
        public static string CodSerieExist { get; set; }
        public static string CodUsuarioExist { get; set; }
        public static string NombresUsuario { get; set; }
        public static string UsuarioArea { get; set; }
        public static string UsuarioEmpresa { get; set; }
        public static string UsuarioSede { get; set; }
        public static string TipoHoja { get; set; }
        public static decimal PrecioMar { get; set; }

        public static DateTime FechaIngreso { get; set; }
        public static string CodTiMas_Busc { get; set; }
        public static int codigo { get; set; }
        public static string codigo_ti { get; set; }
        public static string descripcion_ti { get; set; }
        public static string comentario_ti { get; set; }
        public static string ruc_ti { get; set; }
        public static string dirección_ti { get; set; }
        public static string telefono_ti { get; set; }
        public static string estado_ti { get; set; }
        public static string establecimiento { get; set; }
        public static int codigoprv { get; set; }


        public static string CodPedateoExist { get; set; }
        public static string CodPedateoExistAlimento { get; set; }
        public static string CodUsuarioPedateoExist { get; set; }
        public static string CodPedateoTiExist { get; set; }
        public static DateTime FechaPedateoExist { get; set; }
        public static string CodPedateoTipoAlimentoExist { get; set; }

        //GUARDAR DATAGRIDVIEW
        public static int itemTI { get; set; }
        public static string codperTI { get; set; }
        public static string serieTI { get; set; }
        public static string ImeiTI { get; set; }
        public static string ModeloTI { get; set; }
        public static string ObservacionTI { get; set; }
        public static string EstadoTI { get; set; }
        public static string CodActTI { get; set; }
        public static int ContGridTI { get; set; }

        //BUSCAR PERSONAL
        public static int cod_userTI { get; set; }
        public static string dni_userTI { get; set; }
        public static string dni_userCargoTI { get; set; }

        //DATOS DE ASIGNACION
        public static string ItemTI { get; set; }
        public static string CodActAsigTI { get; set; }
        public static string NumAsigTI { get; set; }
        public static string CantAsigTI { get; set; }
        public static string UbicAsigTI { get; set; }
        public static string EstAsigTI { get; set; }
        public static string Obs1AsigTI { get; set; }
        public static string Obs2AsigTI { get; set; }
        public static int ItemAsigTI { get; set; }

        //DATOS ENTREGA DEVOLUCION
        public static int CodEntDevTI { get; set; }
        public static string FechaEntDev { get; set; }
        public static string CodStringEntDevTI { get; set; }
        public static string CodAsigEntDevTI { get; set; }
        public static string CodActEntDevTI { get; set; }
        public static int DniEntDevTI { get; set; }

        //DATOS MANTENIMIENTO
        public static int CodMantTI { get; set; }
        public static string CodStringMantTI { get; set; }
        public static string CodAsigMantTI { get; set; }
        public static string CodActMantTI { get; set; }
        public static int DniMantTI { get; set; }

        //BUSQUEDA PEDIDO
        public static string EmpPedido { get; set; }
        public static DateTime FecPedido { get; set; }
        public static string SedePedido { get; set; }

    }
}
