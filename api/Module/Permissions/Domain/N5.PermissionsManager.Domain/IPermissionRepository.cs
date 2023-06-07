using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Domain
{
    public interface IPermissionRepository
    {
        Task AddAsync(Permission permission, CancellationToken cancellationToken = default);
        Task<Permission> GetPermissionAsync(int id, CancellationToken cancellationToken = default);
        Task<PermissionType> GetPermissionTypeAsync(int id, CancellationToken cancellationToken = default);
    }
}
