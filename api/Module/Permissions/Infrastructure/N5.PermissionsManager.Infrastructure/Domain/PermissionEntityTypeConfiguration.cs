using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.PermissionsManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Infrastructure.Domain
{
    internal class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions", "dbo");

            

            builder.HasKey(x => x.Id);
            builder.Property<int>("Id").HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property<DateTime>("_fechaPermiso").HasColumnName("FechaPermiso");
            builder.Property<int?>("TipoPermisoId").HasColumnName("TipoPermiso");

            builder.HasOne(p => p.Permissiontype)
                .WithMany()
                .HasForeignKey(p => p.TipoPermisoId)
                .OnDelete(DeleteBehavior.Restrict);
                

            builder.OwnsOne<Person>("_person", b => {
                b.Property(p => p.ApellidoEmpleado).HasColumnName("ApellidoEmpleado");
                b.Property(p => p.NombreEmpleado).HasColumnName("NombreEmpleado");
            });
        }
    }
}
