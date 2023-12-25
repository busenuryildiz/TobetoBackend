using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class CourseLevelConfiguration : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder.ToTable("CourseLevels").HasKey(cl => cl.Id);

            builder.Property(cl => cl.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();


            builder.HasMany(cl => cl.Courses)
                .WithOne(c => c.CourseLevel)
                .HasForeignKey(c => c.CourseLevelId);

            builder.HasQueryFilter(cl => !cl.DeletedDate.HasValue);
        }
    }


}
