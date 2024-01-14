using Entities.Concretes;
using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ApplicationStudentConfiguration : IEntityTypeConfiguration<ApplicationStudent>
    {
        public void Configure(EntityTypeBuilder<ApplicationStudent> builder)
        {
            builder.ToTable("ApplicationStudents");

            builder.HasKey(cs => cs.Id);
            builder.Property(cs => cs.ApplicationId).IsRequired();
            builder.Property(cs => cs.StudentId).IsRequired();

            builder.HasOne(cs => cs.Application)
                .WithMany(c => c.ApplicationStudents)
                .HasForeignKey(cs => cs.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cs => cs.Student)
                .WithMany(s => s.ApplicationStudents)
                .HasForeignKey(cs => cs.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}
