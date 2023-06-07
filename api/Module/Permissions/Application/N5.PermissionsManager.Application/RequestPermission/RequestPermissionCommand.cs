using N5.PermissionsManager.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.RequestPermission
{
    public class RequestPermissionCommand : ICommand<OperationResultRequestDto>
    {
        public RequestPermissionCommand(string nombreEmpleado, string apellidoEmpleado, DateTime fechaPermiso, string descripcionTipoPermiso, int? idTipoPermiso)
        {
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
            FechaPermiso = fechaPermiso;
            DescripcionTipoPermiso = descripcionTipoPermiso;
            IdTipoPermiso = idTipoPermiso;
        }
        public int? IdTipoPermiso { get; }
        public string NombreEmpleado { get; }
        public string ApellidoEmpleado { get; }
        public DateTime FechaPermiso { get; }
        public string DescripcionTipoPermiso { get; }
    }
}
