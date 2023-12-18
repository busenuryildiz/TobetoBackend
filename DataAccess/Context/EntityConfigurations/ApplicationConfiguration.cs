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
            builder.ToTable("Applications");

            builder.HasKey(app => app.Id);

            builder.Property(app => app.UserId).IsRequired();

            builder.HasOne(app => app.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(app => app.UserId)
                .IsRequired();
        }
    }


}
