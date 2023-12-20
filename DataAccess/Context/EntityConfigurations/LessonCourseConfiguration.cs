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
    public class LessonCourseConfiguration : IEntityTypeConfiguration<LessonCourse>
    {
        public void Configure(EntityTypeBuilder<LessonCourse> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.CourseId });

            builder.HasOne(lc => lc.Lesson)
                .WithMany(l => l.LessonCourses)
                .HasForeignKey(lc => lc.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lc => lc.Course)
                .WithMany(c => c.LessonCourses)
                .HasForeignKey(lc => lc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
