using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificates").HasKey(c => c.Id);

            builder.Property(c => c.UserId).IsRequired().HasColumnName("UserId"); // Örnek bir sütun adı ekledim, istediğiniz adı verebilirsiniz

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255).HasColumnName("Name");

            builder.Property(c => c.ImagePath).HasColumnName("ImagePath");

            builder.HasOne(c => c.User)
                .WithMany(u => u.Certificates)
                .HasForeignKey(c => c.UserId)
                .IsRequired();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
