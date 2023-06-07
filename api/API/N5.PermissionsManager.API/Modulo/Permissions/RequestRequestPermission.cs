using System;

namespace N5.PermissionsManager.API.Modulo.Permissions
{
    public class RequestRequestPermission
    {
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public DateTime FechaPermiso{ get; set; }
        public string DescripcionTipoPermiso { get; set; }
        public int? IdTipoPermiso { get; set; }
    }
}
