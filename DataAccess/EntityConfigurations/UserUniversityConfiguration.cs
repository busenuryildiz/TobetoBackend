using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class UserUniversityConfiguration : IEntityTypeConfiguration<UserUniversity>
    {
        public void Configure(EntityTypeBuilder<UserUniversity> builder)
        {
            builder.ToTable("UserUniversities");

            builder.HasKey(sa => sa.Id);
            builder.Property(sa => sa.UserId).IsRequired();
            builder.Property(sa => sa.UniversityId).IsRequired();

            builder.HasOne(sa => sa.User)
                .WithMany(a => a.UserUniversities)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.University)
                .WithMany(s => s.UserUniversities)
                .HasForeignKey(sa => sa.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
