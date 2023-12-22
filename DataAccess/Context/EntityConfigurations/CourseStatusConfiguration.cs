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
    public class CourseStatusConfiguration : IEntityTypeConfiguration<CourseStatus>
    {
        public void Configure(EntityTypeBuilder<CourseStatus> builder)
        {
            builder.ToTable("CourseStatuses").HasKey(cs => cs.Id);

            builder.Property(cs => cs.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();



            builder.HasMany(cs => cs.Courses)
                .WithOne(c => c.CourseStatus)
                .HasForeignKey(c => c.CourseStatusId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
