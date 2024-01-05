using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects").HasKey(sub => sub.Id); 

            builder.Property(sub => sub.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");

            builder.HasMany(s => s.CourseSubjects);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
