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
            builder.ToTable("Courses").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.CourseLevelId).HasColumnName("CourseLevelId");
            builder.Property(c => c.CourseStatusId).HasColumnName("CourseStatusId");
            builder.Property(c => c.SoftwareLanguageId).HasColumnName("SoftwareLanguageId");
            builder.Property(c => c.CategoryId).HasColumnName("CategoryId");
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255);
            builder.Property(c => c.ImagePath).HasColumnName("ImagePath");
            builder.Property(c => c.Price).HasColumnName("Price");

            // Course ile Category arasındaki ilişki
            builder.HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId);

            // Course ile CourseLevel arasındaki ilişki
            builder.HasOne(c => c.CourseLevel)
                .WithMany()
                .HasForeignKey(c => c.CourseLevelId);

            // Course ile CourseStatus arasındaki ilişki
            builder.HasOne(c => c.CourseStatus)
                .WithMany()
                .HasForeignKey(c => c.CourseStatusId);

            // Course ile SoftwareLanguage arasındaki ilişki
            builder.HasOne(c => c.SoftwareLanguage)
                .WithMany()
                .HasForeignKey(c => c.SoftwareLanguageId);

            // Course ile StudentCourse arasındaki ilişki
            builder.HasMany(c => c.StudentCourses)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            // Course tablosu üzerinde silinmiş kayıtları filtreleme
            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }

}
