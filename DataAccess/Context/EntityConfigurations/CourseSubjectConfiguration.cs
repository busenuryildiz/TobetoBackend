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
    public class CourseSubjectConfiguration : IEntityTypeConfiguration<CourseSubject>
    {
        public void Configure(EntityTypeBuilder<CourseSubject> builder)
        {
            builder.HasKey(cs => cs.Id);
            builder.Property(cs => cs.SubjectId).IsRequired();
            builder.Property(cs => cs.CourseId).IsRequired();

            // Course ilişkisi
            builder.HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSubject)
                .HasForeignKey(cs => cs.CourseId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Subject ilişkisi
            builder.HasOne(cs => cs.Subject)
                .WithMany(s => s.CourseSubject)
                .HasForeignKey(cs => cs.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
