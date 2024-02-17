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
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges").HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Bade");

            builder.Property(b => b.BadgePath).HasColumnName("BadgePath");
            
            builder.HasMany(b => b.BadgeOfUsers);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
