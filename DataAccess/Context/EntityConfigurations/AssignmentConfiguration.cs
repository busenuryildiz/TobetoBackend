using Entities.Concrete.CourseFolder;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CourseId).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(255);
            builder.Property(a => a.Description);
            builder.Property(a => a.FilePath);
            builder.Property(a => a.DeadLine).IsRequired();
            builder.Property(a => a.IsSend).IsRequired();

            builder.HasOne(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId);
        }
    }

}
