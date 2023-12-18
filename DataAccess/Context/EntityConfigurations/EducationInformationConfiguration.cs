using Entities.Concrete.Profile;
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
            builder.HasKey(ei => ei.Id);
            builder.Property(ei => ei.UserId).IsRequired();
            builder.Property(ei => ei.Status).IsRequired().HasMaxLength(255);
            builder.Property(ei => ei.University).HasMaxLength(255);
            builder.Property(ei => ei.Faculty).HasMaxLength(255);
            builder.Property(ei => ei.BeginningYear).IsRequired().HasColumnType("datetime");
            builder.Property(ei => ei.GraduationYear).HasColumnType("datetime");
            builder.Property(ei => ei.IsContinue).IsRequired();

            builder.HasOne(ei => ei.User)
                .WithMany(u => u.EducationInformations)
                .HasForeignKey(ei => ei.UserId);
        }
    }


}
