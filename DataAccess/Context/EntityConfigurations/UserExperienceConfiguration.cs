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
    public class UserExperienceConfiguration : IEntityTypeConfiguration<UserExperience>
    {
        public void Configure(EntityTypeBuilder<UserExperience> builder)
        {
            builder.HasKey(ue => ue.Id);
            builder.Property(ue => ue.UserId).IsRequired();
            builder.Property(ue => ue.EstablishmentName).IsRequired().HasMaxLength(255);
            builder.Property(ue => ue.Position).HasMaxLength(255);
            builder.Property(ue => ue.Sector).HasMaxLength(255);
            builder.Property(ue => ue.City).HasMaxLength(255);
            builder.Property(ue => ue.WorkBeginDate).HasColumnType("date").IsRequired();
            builder.Property(ue => ue.WorkEndDate).HasColumnType("date").IsRequired();
            builder.Property(ue => ue.Description);

            builder.HasOne(ue => ue.User)
                .WithMany(u => u.UserExperiences)
                .HasForeignKey(ue => ue.UserId);
        }
    }
}
