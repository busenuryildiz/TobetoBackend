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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons").HasKey(l => l.Id); // Primary key'i belirtiyoruz

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name"); 

            builder.Property(l => l.Content)
                .IsRequired()
                .HasColumnName("Content"); 

            builder.Property(l => l.VideoUrl)
                .IsRequired()
                .HasColumnName("VideoUrl"); 

            builder.HasMany(l => l.LessonCourses)
                .WithOne(lc => lc.Lesson)
                .HasForeignKey(lc => lc.LessonId); 

            builder.HasMany(l => l.Assignments)
                .WithOne(a => a.Lesson)
                .HasForeignKey(a => a.LessonId); 

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        }
    }

}
