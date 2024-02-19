using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.EntityConfigurations
{
    public class ExamOfUserConfiguration : IEntityTypeConfiguration<ExamOfUser>
    {
        public void Configure(EntityTypeBuilder<ExamOfUser> builder)
        {
            builder.ToTable("ExamOfUsers").HasKey(e => e.Id);

            builder.Property(e => e.UserId).HasColumnName("UserId");

            builder.Property(e => e.ExamId).HasColumnName("ExamId");
            builder.Property(e => e.ExamResult).HasColumnName("ExamResult");

            builder.HasOne(e => e.User);

            builder.HasOne(e => e.Exam);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
