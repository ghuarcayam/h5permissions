using N5.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Domain.Events
{
    public class PermissionGotEvent : DomainEventBase
    {
        public PermissionGotEvent(int tipoPermiso, int domainId, string nombreEmpleado, string apellidoEmpleado, DateTime fechaPermiso)
        {
            TipoPermiso = tipoPermiso;
            DomainId = domainId;
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
            FechaPermiso = fechaPermiso;
        }

        public int TipoPermiso { get; }
        public int DomainId { get; }
        public string NombreEmpleado { get; }
        public string ApellidoEmpleado { get; }
        public DateTime FechaPermiso { get; }
    }
}
