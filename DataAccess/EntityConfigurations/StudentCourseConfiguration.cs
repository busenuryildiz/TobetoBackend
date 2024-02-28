using Core.Entities;
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
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourses").HasKey(sc => sc.Id); 

            builder.Property(sc => sc.StudentId)
                .HasColumnName("StudentId");

            builder.Property(sc => sc.CourseId)
                .HasColumnName("CourseId"); 

            builder.Property(sc => sc.Progress)
                .HasColumnName("Progress"); 

            builder.Property(sc => sc.CertificatePath)
                .HasColumnName("CertificatePath");


            builder.Property(sc => sc.Liked)
                .HasColumnName("Liked"); 

            builder.Property(sc => sc.Saved)
                .HasColumnName("Saved"); 

            builder.Property(sc => sc.IsPaid)
                .HasColumnName("IsPaid");

            builder.Property(sc => sc.SpentTime)
                .HasColumnName("SpentTime"); 

            builder.Property(sc => sc.EstimatedTime)
                .HasColumnName("EstimatedTime");

            builder.Property(sc => sc.StartDate)
                .HasColumnName("StartDate"); 

            builder.Property(sc => sc.IsCompleted)
                .HasColumnName("IsCompleted");

        builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId); 

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            builder.HasMany(sc => sc.Payments)
                .WithOne(p => p.StudentCourse)
                .HasForeignKey(sc => sc.StudentCourseId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }



}
