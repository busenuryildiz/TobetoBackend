using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class LessonCourseConfiguration : IEntityTypeConfiguration<LessonCourse>
    {
        public void Configure(EntityTypeBuilder<LessonCourse> builder)
        {
            builder.ToTable("LessonCourse").HasKey(cs => cs.Id);


            builder.Property(cs => cs.LessonId).IsRequired();
            builder.Property(cs => cs.CourseId).IsRequired();

            builder.HasOne(lc => lc.Lesson)
                .WithMany(l => l.LessonCourses)
                .HasForeignKey(lc => lc.LessonId);

            builder.HasOne(lc => lc.Course)
                .WithMany(c => c.LessonCourses)
                .HasForeignKey(lc => lc.CourseId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
