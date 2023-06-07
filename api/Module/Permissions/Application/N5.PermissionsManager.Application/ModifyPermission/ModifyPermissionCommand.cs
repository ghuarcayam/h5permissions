using N5.PermissionsManager.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.ModifyPermission
{
    public class ModifyPermissionCommand : ICommand<int>
    {
        public ModifyPermissionCommand(int id, string nombreEmpleado, string apellidoEmpleado, DateTime fechaPermiso, string descripcionTipoPermiso,  int? idTipoPermiso)
        {
            Id = id;
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
            FechaPermiso = fechaPermiso;
            DescripcionTipoPermiso = descripcionTipoPermiso;
            IdTipoPermiso = idTipoPermiso;
        }
        public int? IdTipoPermiso { get; }
        public int Id { get;  }
        public string NombreEmpleado { get;  }
        public string ApellidoEmpleado { get;  }
        public DateTime FechaPermiso { get;  }
        public string DescripcionTipoPermiso { get;  }
    }
}
