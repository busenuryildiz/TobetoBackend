using Entities.Concretes.CoursesFolder;
using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(255);



            builder.HasMany(a => a.ClassroomOfCourses)
                .WithOne(ct => ct.Classroom)
                .HasForeignKey(ct => ct.ClassroomId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        }
    }
}
