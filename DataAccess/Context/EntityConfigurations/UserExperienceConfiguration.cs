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
    public class UserExperienceConfiguration : IEntityTypeConfiguration<UserExperience>
    {
        public void Configure(EntityTypeBuilder<UserExperience> builder)
        {
            builder.HasKey(ue => ue.Id);
            builder.Property(ue => ue.UserId).IsRequired();
            builder.Property(ue => ue.EstablishmentName).IsRequired().HasMaxLength(255);
            builder.Property(ue => ue.Position).IsRequired().HasMaxLength(255);
            builder.Property(ue => ue.Sector).IsRequired().HasMaxLength(255);
            builder.Property(ue => ue.City).IsRequired().HasMaxLength(255);
            builder.Property(ue => ue.WorkBeginDate).IsRequired().HasColumnType("datetime");
            builder.Property(ue => ue.WorkEndDate).IsRequired().HasColumnType("datetime");
            builder.Property(ue => ue.Description);

            builder.HasOne(ue => ue.User)
                .WithMany(u => u.UserExperiences)
                .HasForeignKey(ue => ue.UserId);
        }
    }

}
