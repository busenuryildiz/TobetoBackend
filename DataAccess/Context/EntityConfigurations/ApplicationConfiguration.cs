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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(app => app.Id);
            builder.Property(app => app.UserId).IsRequired();
            builder.Property(app => app.Name).IsRequired().HasMaxLength(255);
            builder.Property(app => app.IsActive).IsRequired();

            builder.HasOne(app => app.User)
                .WithMany()
                .HasForeignKey(app => app.UserId);
        }
    }
   
}
