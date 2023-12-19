using Core.Entities;
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
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.StudentId).IsRequired();
            builder.Property(sc => sc.CourseId).IsRequired();
            builder.Property(sc => sc.Progress).IsRequired();
            builder.Property(sc => sc.CertificatePath);
            builder.Property(sc => sc.Point).IsRequired();
            builder.Property(sc => sc.Liked).IsRequired();
            builder.Property(sc => sc.Saved).IsRequired();
            builder.Property(sc => sc.IsPaid);
            builder.Property(sc => sc.SpentTime).IsRequired();
            builder.Property(sc => sc.EstimatedTime).IsRequired();

            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }


}
