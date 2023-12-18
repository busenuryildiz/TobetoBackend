using Entities.Concrete.CourseFolder;
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
            builder.HasKey(cl => cl.Id);
            builder.Property(cl => cl.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(cl => cl.Courses)
                .WithOne(c => c.CourseLevel)
                .HasForeignKey(c => c.CourseLevelId);
        }
    }

}
