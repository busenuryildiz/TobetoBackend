using Entities.Concretes;
using Entities.Concretes.Clients;
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
    public class StudentLessonConfiguration : IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
            builder.ToTable("StudentLessons").HasKey(b => b.Id);

            builder.Property(b => b.LessonId).HasColumnName("LessonId");

            builder.Property(b => b.StudentId).HasColumnName("StudentId");
            builder.Property(b => b.Progress).HasColumnName("Progress");
            builder.Property(b => b.IsLiked).HasColumnName("IsLiked");


            builder.HasOne(l => l.Lesson);
            builder.HasOne(l => l.Student);


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
