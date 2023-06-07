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
    public class PermissionTypeEntityTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionTypes", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property<int>("Id").HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property<string>("_descripcion").HasColumnName("Descripcion");
        }
    }
}
