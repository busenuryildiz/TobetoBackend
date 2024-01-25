using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Clients;

namespace DataAccess.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("StudentId").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.StudentNumber).HasColumnName("StudentNumber").IsRequired();

            // User ilişkisi
            builder.HasOne(b => b.User);
           

            // Surveys ilişkisi
            builder.HasMany(b => b.Surveys)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);


            builder.HasMany(u => u.StudentAssignments)
                .WithOne(ei => ei.Student)
                .HasForeignKey(ei => ei.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.StudentSkills)
                .WithOne(ei => ei.Student)
                .HasForeignKey(ei => ei.StudentId);

            builder.HasMany(u => u.ApplicationStudents)
               .WithOne(ei => ei.Student)
               .HasForeignKey(ei => ei.StudentId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
