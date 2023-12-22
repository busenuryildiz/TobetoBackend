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
            builder.ToTable("StudentCourses").HasKey(sc => sc.Id); 

            builder.Property(sc => sc.StudentId)
                .IsRequired()
                .HasColumnName("StudentId");

            builder.Property(sc => sc.CourseId)
                .IsRequired()
                .HasColumnName("CourseId"); 

            builder.Property(sc => sc.Progress)
                .IsRequired()
                .HasColumnName("Progress"); 

            builder.Property(sc => sc.CertificatePath)
                .HasColumnName("CertificatePath");

            builder.Property(sc => sc.Point)
                .IsRequired()
                .HasColumnName("Point");

            builder.Property(sc => sc.Liked)
                .IsRequired()
                .HasColumnName("Liked"); 

            builder.Property(sc => sc.Saved)
                .IsRequired()
                .HasColumnName("Saved"); 

            builder.Property(sc => sc.IsPaid)
                .HasColumnName("IsPaid");

            builder.Property(sc => sc.SpentTime)
                .IsRequired()
                .HasColumnName("SpentTime"); 

            builder.Property(sc => sc.EstimatedTime)
                .IsRequired()
                .HasColumnName("EstimatedTime"); 

            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId); 

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }



}
