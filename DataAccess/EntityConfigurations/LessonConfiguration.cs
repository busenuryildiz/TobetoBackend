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
                .HasMaxLength(255)
                .HasColumnName("Name"); 

            builder.Property(l => l.Content)
                .HasColumnName("Content"); 

            builder.Property(l => l.VideoUrl)
                .HasColumnName("VideoUrl");

            builder.Property(l => l.LessonDuration).HasColumnName("LessonDuration");

            builder.Property(c => c.LessonDateAndHour).HasColumnName("LessonDateAndHour");

            builder.Property(c => c.Speaker).HasColumnName("Speaker");

            builder.Property(c => c.AboutSpeaker).HasColumnName("AboutSpeaker");

            builder.HasMany(l => l.StudentLessons);


            builder.HasOne(l => l.CoursePart)
                   .WithMany(cp => cp.Lessons)
                   .HasForeignKey(l => l.CoursePartId);

            builder.HasOne(l => l.Course)
                .WithMany(l=>l.Lessons)
                .HasForeignKey(l=>l.CourseId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
    }

}
