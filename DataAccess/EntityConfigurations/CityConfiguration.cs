using Entities.Concretes;
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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            // City sınıfının District koleksiyonu ile ilişkisi
            builder.HasMany(c => c.Districts)
                   .WithOne()
                   .HasForeignKey(c => c.CityId)
                   .OnDelete(DeleteBehavior.Cascade);

            // City sınıfının Country ilişkisi
            builder.HasOne(c => c.Country)
                   .WithMany()
                   .HasForeignKey(c => c.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
