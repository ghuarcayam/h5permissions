using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using N5.PermissionsManager.Application.Contract;
using N5.PermissionsManager.Application.GetPermissions;
using N5.PermissionsManager.Application.GetPermissionTypes;
using N5.PermissionsManager.Application.GetSinglePermission;
using N5.PermissionsManager.Application.ModifyPermission;
using N5.PermissionsManager.Application.RequestPermission;
using N5.PermissionsManager.Domain;
using Nest;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.API.Modulo.Permissions
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionsModule permissionsModule;
        
        public PermissionController(IPermissionsModule permissionsModule)
        {
            this.permissionsModule = permissionsModule;
            
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission([FromBody] RequestRequestPermission permission, CancellationToken cancellationToken)
        {
            var result  = await this.permissionsModule.ExecuteCommandAsync(new RequestPermissionCommand(permission.NombreEmpleado, permission.ApellidoEmpleado, permission.FechaPermiso, permission.DescripcionTipoPermiso, permission.IdTipoPermiso), cancellationToken);
            return Ok(result);
        }

        [HttpPatch]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] RequestRequestPermission permission, CancellationToken cancellationToken)
        {
            var result = await this.permissionsModule.ExecuteCommandAsync(new ModifyPermissionCommand(id, permission.NombreEmpleado, permission.ApellidoEmpleado, permission.FechaPermiso, permission.DescripcionTipoPermiso, permission.IdTipoPermiso), cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPermissions(int startAt, int pageSize,CancellationToken cancellationToken)
        {
            
            var result = await this.permissionsModule.ExecuteQueryAsync(new GetPermissionsQuery(startAt, pageSize), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("types")]
        public async Task<IActionResult> GetPermissionType() 
        {
            var result = await this.permissionsModule.ExecuteQueryAsync(new GetPermissionTypesQuery());
            return Ok(result);
        }
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        public async Task<IActionResult> GetPermission(int id) 
        {
            var result = await this.permissionsModule.ExecuteQueryAsync(new GetSinglePermissionQuery(id));
            return Ok(result);
        }
    }
}
