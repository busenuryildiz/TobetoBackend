using Entities.Concretes;
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
    public class AddressConfiguration: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(255);
            builder.Property(b => b.AboutMe);

            builder.HasOne(ei => ei.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(ei => ei.UserId);


            builder.HasOne(ei => ei.District)
                .WithMany(u => u.Addresses)
                .HasForeignKey(ei => ei.CountyId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}
