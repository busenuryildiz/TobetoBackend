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
            // Tablo adı
            builder.ToTable("Students");

            // Anahtar (Primary Key)
            builder.HasKey(s => s.Id);

            // Özellikler
            builder.Property(s => s.UserId).IsRequired();
            builder.Property(s => s.StudentNumber).IsRequired();
            builder.Property(s => s.CourseId).IsRequired();

            // İlişkiler
            builder.HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Surveys)
                .WithOne(survey => survey.Student)
                .HasForeignKey(survey => survey.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
