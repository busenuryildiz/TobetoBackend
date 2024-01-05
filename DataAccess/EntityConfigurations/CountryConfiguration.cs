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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries").HasKey(c => c.Id);
            builder.Property(c=>c.Name).HasColumnName("CountryName").IsRequired();


            builder.HasMany(c => c.Cities)
                .WithOne(ci => ci.Country)
                .HasForeignKey(ci => ci.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
