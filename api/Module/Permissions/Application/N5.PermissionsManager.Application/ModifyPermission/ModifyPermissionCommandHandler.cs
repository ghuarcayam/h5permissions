using N5.PermissionsManager.Application.Configuration.Command;
using N5.PermissionsManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.ModifyPermission
{
    internal class ModifyPermissionCommandHandler : ICommandHandler<ModifyPermissionCommand, int>
    {
        private readonly IPermissionRepository permissionRepository;
        public ModifyPermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        public async Task<int> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await permissionRepository.GetPermissionAsync(request.Id);
            if (permission != null) 
            {
                PermissionType permissionType = null;
                if (request.IdTipoPermiso.HasValue)
                    permissionType = await permissionRepository.GetPermissionTypeAsync(request.IdTipoPermiso.Value, cancellationToken);

                if (permissionType == null)
                    permissionType = new PermissionType(request.DescripcionTipoPermiso);

                permission
                    .SetValues(Person.CreateNew(request.NombreEmpleado, request.ApellidoEmpleado),
                    permissionType, request.FechaPermiso);

                return permission.Id;
            }
            return 0;
        }
    }
}
