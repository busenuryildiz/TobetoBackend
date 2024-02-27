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
    public class InstructorCourseConfiguration : IEntityTypeConfiguration<InstructorCourse>
    {
        public void Configure(EntityTypeBuilder<InstructorCourse> builder)
        {
            builder.ToTable("InstructorCourses").HasKey(ic => ic.Id);

            builder.Property(ic => ic.InstructorId)
                .HasColumnName("InstructorId");

            builder.Property(ic => ic.CourseId)
                .HasColumnName("CourseId");

            builder.HasOne(ic => ic.Instructor)
                .WithMany(i => i.InstructorCourses)
                .HasForeignKey(ic => ic.InstructorId);

            builder.HasOne(ic => ic.Course)
                .WithMany(c => c.InstructorCourses)
                .HasForeignKey(ic => ic.CourseId);

            // İlgili ilişkileri tanımladık, ancak silinmiş öğeleri filtrelemek için DeletedDate kullanmıyoruz.
            // DeletedDate'e göre filtreleme yapılmayacaksa, HasQueryFilter metodu kaldırılabilir.
        }
    }

}
