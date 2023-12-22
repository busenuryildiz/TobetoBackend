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
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options").HasKey(o => o.Id);


            builder.Property(o => o.Answer)
                .IsRequired()
                .HasColumnName("Answer"); 

            builder.Property(o => o.QuestionId)
                .IsRequired()
                .HasColumnName("QuestionId");

            builder.Property(o => o.IsCorrect)
                .IsRequired()
                .HasColumnName("IsCorrect"); 

            builder.HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId); 

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }


}
