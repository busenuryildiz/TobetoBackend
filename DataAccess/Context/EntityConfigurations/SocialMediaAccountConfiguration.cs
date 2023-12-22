using Entities.Concretes;
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
            builder.ToTable("SocialMediaAccounts").HasKey(sma => sma.Id); 

            builder.Property(sma => sma.UserId)
                .IsRequired()
                .HasColumnName("UserId"); 

            builder.Property(sma => sma.SocialMedia)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("SocialMedia"); 

            builder.Property(sma => sma.SocialMediaUrl)
                .IsRequired()
                .HasColumnName("SocialMediaUrl");

            builder.HasOne(sma => sma.User)
                .WithMany(u => u.SocialMediaAccounts)
                .HasForeignKey(sma => sma.UserId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
