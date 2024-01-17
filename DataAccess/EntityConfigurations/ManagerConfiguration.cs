using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Clients;

namespace DataAccess.EntityConfigurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Managers").HasKey(m => m.Id);
            builder.Property(b => b.Id).HasColumnName("ManagerId").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.ManagerCode).HasColumnName("ManagerCode").IsRequired();

            // User ilişkisi
            builder.HasOne(b => b.User);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


        }
    }
}
