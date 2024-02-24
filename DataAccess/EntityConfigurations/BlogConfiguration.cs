using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs").HasKey(b => b.Id);

            builder.Property(b => b.Title).HasColumnName("Title");

            builder.Property(b => b.Content).HasColumnName("Content");
            builder.Property(b => b.ImagePath).HasColumnName("ImagePath");

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
