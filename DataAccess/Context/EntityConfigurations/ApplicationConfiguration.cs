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
            builder.ToTable("Applications").HasKey(app => app.Id);


            builder.Property(app => app.UserId).HasColumnName("UserId").IsRequired(); // Örnek sütun ismi ekledim, istediğiniz ismi verebilirsiniz

            builder.Property(app => app.Name).HasMaxLength(255).HasColumnName("Name").IsRequired();

            builder.Property(app => app.IsActive).HasColumnName("IsActive").IsRequired();

            builder.HasOne(app => app.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(app => app.UserId)
                .IsRequired();

            builder.HasQueryFilter(app => !app.DeletedDate.HasValue); // Örnek bir query filter eklendi, silinmemiş kayıtları filtreler
        }
    }


}
