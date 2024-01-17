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
    public class UserExperienceConfiguration : IEntityTypeConfiguration<UserExperience>
    {
        public void Configure(EntityTypeBuilder<UserExperience> builder)
        {
            builder.ToTable("UserExperiences").HasKey(ue => ue.Id); 

            builder.Property(ue => ue.UserId)
                .IsRequired()
                .HasColumnName("UserId"); 

            builder.Property(ue => ue.EstablishmentName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("EstablishmentName"); 

            builder.Property(ue => ue.Position)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Position"); 

            builder.Property(ue => ue.Sector)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Sector"); 

            builder.Property(ue => ue.City)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("City"); 
            builder.Property(ue => ue.WorkBeginDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("WorkBeginDate"); 

            builder.Property(ue => ue.WorkEndDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("WorkEndDate"); 

            builder.Property(ue => ue.Description)
                .HasColumnName("Description");

            builder.HasOne(ue => ue.User)
                .WithMany(u => u.UserExperiences)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
