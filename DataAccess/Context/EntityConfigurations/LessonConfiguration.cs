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
            builder.ToTable("Lessons");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.CourseId).IsRequired();
            builder.Property(l => l.Name).IsRequired().HasMaxLength(255);
            builder.Property(l => l.Content).IsRequired();
            builder.Property(l => l.VideoUrl).HasMaxLength(255);

         
        }
    }

}
