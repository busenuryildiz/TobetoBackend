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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons").HasKey(l => l.Id); 

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

            builder.Property(l => l.LessonTime)
               .IsRequired()
               .HasColumnName("LessonTime");

            builder.HasMany(l => l.LessonCourses)
                .WithOne(lc => lc.Lesson)
                .HasForeignKey(l => l.LessonId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        }
    }

}
