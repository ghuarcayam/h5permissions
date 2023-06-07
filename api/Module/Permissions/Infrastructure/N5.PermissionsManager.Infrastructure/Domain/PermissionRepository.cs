using N5.PermissionsManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace N5.PermissionsManager.Infrastructure.Domain
{
    internal class PermissionRepository : IPermissionRepository
    {
        private readonly PermissionsContext context;

        public PermissionRepository(PermissionsContext context) 
        {
            this.context = context;
        }
        public async Task AddAsync(Permission permission, CancellationToken cancellationToken = default)
        {
            await context.Permissions.AddAsync(permission, cancellationToken);
        }

        public async Task<Permission> GetPermissionAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Permissions.Include(p=>p.Permissiontype).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PermissionType> GetPermissionTypeAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.PermissionTypes.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
