using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys").HasKey(s => s.Id);

            builder.Property(s => s.StudentId)
                .IsRequired()
                .HasColumnName("StudentId");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");

            builder.Property(s => s.SurveyUrl)
                .HasColumnName("SurveyUrl");

            builder.HasOne(s => s.Student)
                .WithMany(st => st.Surveys)
                .HasForeignKey(s => s.StudentId)
                .IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }

    }
}