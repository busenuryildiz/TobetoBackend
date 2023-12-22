using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class CountyConfiguration : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(255);

            builder.HasOne(ct => ct.City)
                .WithMany(a => a.Counties)
                .HasForeignKey(ei => ei.CityId);

            builder.HasMany(a => a.Addresses)
                .WithOne(ct => ct.County)
                .HasForeignKey(ct => ct.CountyId);

            
        }
    }
}
