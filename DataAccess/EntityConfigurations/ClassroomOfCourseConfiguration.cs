using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ClassroomOfCourseConfiguration : IEntityTypeConfiguration<ClassroomOfCourse>
    {
        public void Configure(EntityTypeBuilder<ClassroomOfCourse> builder)
        {
            builder.ToTable("ClassroomOfCourses").HasKey(ic => ic.Id);

            builder.Property(ic => ic.ClassroomId)
                .IsRequired()
                .HasColumnName("ClassroomId");

            builder.Property(ic => ic.CourseId)
                .IsRequired()
                .HasColumnName("CourseId");

            builder.HasOne(ic => ic.Classroom)
                .WithMany(i => i.ClassroomOfCourses)
                .HasForeignKey(ic => ic.ClassroomId);

            builder.HasOne(ic => ic.Course)
                .WithMany(c => c.ClassroomOfCourses)
                .HasForeignKey(ic => ic.CourseId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }

}
