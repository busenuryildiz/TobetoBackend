using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(r => r.Id); 

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        }
    }

}
