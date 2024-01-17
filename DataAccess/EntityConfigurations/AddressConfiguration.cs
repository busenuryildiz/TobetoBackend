using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class AddressConfiguration: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(255);
            builder.Property(b => b.Description);

            builder.HasOne(ei => ei.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(ei => ei.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ei => ei.District)
                .WithMany(u => u.Addresses)
                .HasForeignKey(ei => ei.DistrictId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}
