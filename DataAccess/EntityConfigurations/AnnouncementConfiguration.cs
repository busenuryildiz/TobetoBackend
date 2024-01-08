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
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("AnnouncementId").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(a => a.Description).HasColumnName("Description");

            // Örnek bir query filter eklenmiş, DeletedDate'i null olmayanları filtreler
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }

}