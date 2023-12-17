using Entities.Concrete.Client;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("StudentId").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.StudentNumber).HasColumnName("StudentNumber").IsRequired();

            builder.HasOne(b => b.User);
            builder.HasMany(b => b.Surveys);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        //public int CourseId { get; set; }

        //public User User { get; set; }

        //public List<Survey> Surveys { get; set; }

    }
    }
}
