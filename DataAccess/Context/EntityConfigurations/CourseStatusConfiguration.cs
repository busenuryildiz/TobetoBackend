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
    public class CourseStatusConfiguration : IEntityTypeConfiguration<CourseStatus>
    {
        public void Configure(EntityTypeBuilder<CourseStatus> builder)
        {
            builder.HasKey(cs => cs.Id);
            builder.Property(cs => cs.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(cs => cs.Courses)
                .WithOne(c => c.CourseStatus)
                .HasForeignKey(c => c.CourseStatusId);
        }
    }

}
