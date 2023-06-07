using N5.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Domain.Events
{
    public class PremissionCreatedEvent: DomainEventBase
    {
        private readonly Permission permission;
       public PremissionCreatedEvent(Permission permission) : base()
       {
            this.permission = permission;
            TipoPermiso = permission.TipoPermisoId.HasValue ? permission.TipoPermisoId.Value: default(int);

            NombreEmpleado = permission.Person.NombreEmpleado;
            ApellidoEmpleado = permission.Person.ApellidoEmpleado;
            FechaPermiso = permission.FechaPermiso;

        }

        public int TipoPermiso { get;  }
        public int DomainId { get => permission.Id; }
        public string NombreEmpleado { get;  }
        public string ApellidoEmpleado { get; }
        public DateTime FechaPermiso { get;  }
    }
}
