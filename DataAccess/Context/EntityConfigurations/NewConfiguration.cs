using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Context.EntityConfigurations
{
    public class NewConfiguration: IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("News").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("NewId").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description");
            builder.Property(b => b.Content).HasColumnName("Content");
            builder.Property(b => b.ImagePath).HasColumnName("ImagePath");
            builder.Property(b => b.Date).HasColumnName("Date");

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

   

    }
}
}
