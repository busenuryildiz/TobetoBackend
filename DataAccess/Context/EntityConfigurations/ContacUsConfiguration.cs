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
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasKey(cu => cu.Id);
            builder.Property(cu => cu.FullName).IsRequired().HasMaxLength(255);
            builder.Property(cu => cu.Email).IsRequired().HasMaxLength(255);
            builder.Property(cu => cu.Message).IsRequired();
        }
    }
}
