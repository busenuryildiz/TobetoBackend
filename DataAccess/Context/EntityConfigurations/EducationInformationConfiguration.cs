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
    public class EducationInformationConfiguration : IEntityTypeConfiguration<EducationInformation>
    {
            public void Configure(EntityTypeBuilder<EducationInformation> builder)
            {
                builder.ToTable("EducationInformations").HasKey(ei => ei.Id);

                builder.Property(ei => ei.UserId).IsRequired().HasColumnName("UserId");

                builder.Property(ei => ei.Status).IsRequired().HasMaxLength(255).HasColumnName("Status");

                builder.Property(ei => ei.University)
                    .HasMaxLength(255)
                    .HasColumnName("University");

                builder.Property(ei => ei.Faculty)
                    .HasMaxLength(255)
                    .HasColumnName("Faculty");

                builder.Property(ei => ei.BeginningYear)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("BeginningYear");

                builder.Property(ei => ei.GraduationYear)
                    .HasColumnType("datetime")
                    .HasColumnName("GraduationYear");

                builder.Property(ei => ei.IsContinue)
                    .IsRequired()
                    .HasColumnName("IsContinue");

                builder.HasOne(ei => ei.User)
                    .WithMany(u => u.EducationInformations)
                    .HasForeignKey(ei => ei.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
            }
        }

}

