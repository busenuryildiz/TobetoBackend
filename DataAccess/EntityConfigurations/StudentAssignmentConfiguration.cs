using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.EntityConfigurations
{
    public class StudentAssignmentConfiguration : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.ToTable("StudentAssignments");

            builder.HasKey(sa => sa.Id);
            builder.Property(sa => sa.AssignmentId).IsRequired();
            builder.Property(sa => sa.StudentId).IsRequired();

            builder.HasOne(sa => sa.Assignment)
                .WithMany(a => a.StudentAssignments)
                .HasForeignKey(sa => sa.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
