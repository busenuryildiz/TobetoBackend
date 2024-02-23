using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class EducationInformationConfiguration : IEntityTypeConfiguration<EducationInformation>
    {
        public void Configure(EntityTypeBuilder<EducationInformation> builder)
        {
            builder.ToTable("EducationInformations").HasKey(ei => ei.Id);

            builder.Property(ei => ei.UserId).HasColumnName("UserId");
            
            builder.Property(ei => ei.Status).HasMaxLength(255).HasColumnName("Status");

            builder.Property(ei => ei.BeginningYear)
                    .HasColumnType("datetime")
                    .HasColumnName("BeginningYear");

            builder.Property(ei => ei.GraduationYear)
                .HasColumnType("datetime")
                .HasColumnName("GraduationYear");

            builder.Property(ei => ei.IsContinue)
                .HasColumnName("IsContinue");

            builder.Property(ei => ei.University);

            builder.Property(ei => ei.Faculty);


            builder.HasOne(ei => ei.User)
                .WithMany(u => u.EducationInformations)
                .HasForeignKey(ei => ei.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }

}

