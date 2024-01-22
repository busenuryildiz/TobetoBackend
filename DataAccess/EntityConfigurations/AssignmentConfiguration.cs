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
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments").HasKey(a => a.Id);


            builder.Property(a => a.CourseId).IsRequired().HasColumnName("CourseId"); // Örnek bir sütun adı ekledim, istediğiniz adı verebilirsiniz

            builder.Property(a => a.Name).IsRequired().HasMaxLength(255).HasColumnName("Name");

            builder.Property(a => a.Description).HasColumnName("Description");

            builder.Property(a => a.FilePath).HasColumnName("FilePath");

            builder.Property(a => a.DeadLine).IsRequired().HasColumnName("DeadLine");

            builder.Property(a => a.IsSend).IsRequired().HasColumnName("IsSend");

            builder.HasOne(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId);








            // Application ile ApplicationStudent arasındaki ilişki
            builder.HasMany(a => a.StudentAssignments)
                .WithOne(a => a.Assignment)
                .HasForeignKey(a => a.AssignmentId);
        }
    }


}
