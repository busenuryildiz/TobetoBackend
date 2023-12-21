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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CourseLevelId).IsRequired();
            builder.Property(c => c.SoftwareLanguageId).IsRequired();
            builder.Property(c => c.CategoryId).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.ImagePath);
            builder.Property(c => c.Price).IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId);

            builder.HasMany(c => c.LessonCourses)  // HasMany kullanılmalı
                .WithOne(lc => lc.Course)           // WithOne ve HasForeignKey LessonCourse sınıfının Course özelliği için kullanılmalı
                .HasForeignKey(lc => lc.CourseId)  // LessonCourse sınıfının CourseId özelliğiyle eşleşmeli
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);

            builder.HasMany(c => c.Exams)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            builder.HasOne(c => c.CourseLevel)
                .WithMany(cl => cl.Courses)
                .HasForeignKey(c => c.CourseLevelId);

            builder.HasOne(c => c.CourseStatus)
                .WithMany(cs => cs.Courses)
                .HasForeignKey(c => c.CourseStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CourseSubject)  // HasMany kullanılmalı
                .WithOne(lc => lc.Course)           // WithOne ve HasForeignKey LessonCourse sınıfının Course özelliği için kullanılmalı
                .HasForeignKey(lc => lc.CourseId)  // LessonCourse sınıfının CourseId özelliğiyle eşleşmeli
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.SoftwareLanguage)
                .WithMany(sl => sl.Courses)
                .HasForeignKey(c => c.SoftwareLanguageId);
        }
    }

}
