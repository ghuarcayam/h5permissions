using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using N5.PermissionsManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure
{
    internal class PermissionsContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionType> PermissionTypes { get; set; }

        public PermissionsContext(DbContextOptions options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
