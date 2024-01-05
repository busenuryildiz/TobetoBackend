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

    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Applications").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
            builder.Property(a => a.IsActive).HasColumnName("IsActive").IsRequired();

            // Application ile ApplicationStudent arasındaki ilişki
            builder.HasMany(a => a.ApplicationStudents)
                .WithOne(a => a.Application)
                .HasForeignKey(a => a.ApplicationId);

            // Application tablosu üzerinde silinmiş kayıtları filtreleme
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
