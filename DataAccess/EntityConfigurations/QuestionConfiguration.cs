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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions").HasKey(q => q.Id); 

            builder.Property(q => q.ExamId)
                .IsRequired()
                .HasColumnName("ExamId"); 

            builder.Property(q => q.Problem)
                .HasColumnName("Problem"); 

            builder.HasOne(q => q.Exam)
                .WithMany(e => e.Questions)
                .HasForeignKey(q => q.ExamId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
