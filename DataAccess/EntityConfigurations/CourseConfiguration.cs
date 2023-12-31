﻿using Entities.Concretes.Courses;
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
            builder.Property(c => c.SoftwareLanguageId).HasColumnName("SoftwareLanguageId");
            builder.Property(c => c.CategoryId).HasColumnName("CategoryId");
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255);
            builder.Property(c => c.ImagePath).HasColumnName("ImagePath");
            builder.Property(c => c.Price).HasColumnName("Price");

            // Course ile Category arasındaki ilişki
            builder.HasOne(c => c.Category)
                .WithMany(ct=>ct.Courses)
                .HasForeignKey(c => c.CategoryId);

            // Course ile CourseLevel arasındaki ilişki
            builder.HasOne(c => c.CourseLevel)
                .WithMany(cl=>cl.Courses)
                .HasForeignKey(c => c.CourseLevelId);

            // Course ile SoftwareLanguage arasındaki ilişki
            builder.HasOne(c => c.SoftwareLanguage)
                .WithMany(sl=>sl.Courses)
                .HasForeignKey(c => c.SoftwareLanguageId);

            // Course ile StudentCourse arasındaki ilişki
            builder.HasMany(c => c.StudentCourses)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            builder.HasMany(c => c.CourseSubjects);
            builder.HasMany(c => c.InstructorCourses);

            // Course tablosu üzerinde silinmiş kayıtları filtreleme
            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }

}
