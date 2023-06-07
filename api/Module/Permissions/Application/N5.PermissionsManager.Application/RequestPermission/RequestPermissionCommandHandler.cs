using N5.PermissionsManager.Application.Configuration.Command;
using N5.PermissionsManager.Application.ModifyPermission;
using N5.PermissionsManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.RequestPermission
{
    internal class RequestPermissionCommandHandler : ICommandHandler<RequestPermissionCommand, OperationResultRequestDto>
    {
        private readonly IPermissionRepository permissionRepository;
        public RequestPermissionCommandHandler(IPermissionRepository permissionRepository) 
        {
            this.permissionRepository = permissionRepository;
        }
        public async Task<OperationResultRequestDto> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            PermissionType permissionType = null;
            if (request.IdTipoPermiso.HasValue)
                permissionType = await permissionRepository.GetPermissionTypeAsync(request.IdTipoPermiso.Value, cancellationToken);

            if (permissionType == null) 
                permissionType = new PermissionType(request.DescripcionTipoPermiso);
            
            
            Permission permission = new(permissionType, Person.CreateNew(request.NombreEmpleado, request.ApellidoEmpleado),
                                               request.FechaPermiso);

            await this.permissionRepository.AddAsync(permission);
            
            return new (permission);
        }
    }
}
