using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class SocialMediaAccountConfiguration : IEntityTypeConfiguration<SocialMediaAccount>
    {
        public void Configure(EntityTypeBuilder<SocialMediaAccount> builder)
        {
            builder.HasKey(sma => sma.Id);
            builder.Property(sma => sma.UserId).IsRequired();
            builder.Property(sma => sma.SocialMedia).IsRequired().HasMaxLength(255);
            builder.Property(sma => sma.SocialMediaUrl);

            builder.HasOne(sma => sma.User)
                .WithMany(u => u.SocialMediaAccounts)
                .HasForeignKey(sma => sma.UserId);
        }
    }
}
