using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(255);

            builder.HasOne(ct => ct.City)
                .WithMany(a => a.Districts)
                .HasForeignKey(ei => ei.CityId);

            builder.HasMany(a => a.Addresses)
                .WithOne(ct => ct.District)
                .HasForeignKey(ct => ct.DistrictId);

            
        }
    }
}
