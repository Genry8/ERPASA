using System;

namespace CapaEntidad
{
    public class ce_rolespermiso
    {
        //ENABLE DISABLE PARA SUBMENU DE ITEMS

        public int IdPermiso { get; set; }
        public int IdRol { get; set; }
        public int IdSubMenu { get; set; }
        public Boolean Activo { get; set; }
    }
}
