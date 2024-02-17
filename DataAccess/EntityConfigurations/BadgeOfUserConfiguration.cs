using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;

namespace DataAccess.EntityConfigurations
{
    public class BadgeOfUserConfiguration : IEntityTypeConfiguration<BadgeOfUser>
    {
        public void Configure(EntityTypeBuilder<BadgeOfUser> builder)
        {
            builder.ToTable("BadgeOfUsers").HasKey(b => b.Id);

            builder.Property(b => b.UserId).HasColumnName("UserId");

            builder.Property(b => b.BadgeId).HasColumnName("BadgeId");

            builder.HasOne(b => b.User);

            builder.HasOne(b => b.Badge);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
