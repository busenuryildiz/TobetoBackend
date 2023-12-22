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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(cat => cat.Id);


            builder.Property(cat => cat.Name).IsRequired().HasMaxLength(255).HasColumnName("Name");

            builder.HasMany(cat => cat.Courses)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
