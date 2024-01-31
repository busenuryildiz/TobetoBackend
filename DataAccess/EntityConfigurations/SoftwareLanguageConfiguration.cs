using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class SoftwareLanguageConfiguration : IEntityTypeConfiguration<SoftwareLanguage>
    {
        public void Configure(EntityTypeBuilder<SoftwareLanguage> builder)
        {
            builder.ToTable("SoftwareLanguages").HasKey(sl => sl.Id);

            builder.Property(sl => sl.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name"); 

            builder.HasMany(sl => sl.Courses)
                .WithOne(c => c.SoftwareLanguage)
                .HasForeignKey(c => c.SoftwareLanguageId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        }
    }


}
