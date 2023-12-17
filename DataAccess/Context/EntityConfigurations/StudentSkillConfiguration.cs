using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class StudentSkillConfiguration : IEntityTypeConfiguration<StudentSkill>
    {
        public void Configure(EntityTypeBuilder<StudentSkill> builder)
        {
            builder.HasKey(ss => ss.Id);
            builder.Property(ss => ss.StudentId).IsRequired();
            builder.Property(ss => ss.SkillId).IsRequired();

            builder.HasOne(ss => ss.Student)
                .WithMany()
                .HasForeignKey(ss => ss.StudentId);

            builder.HasOne(ss => ss.Skill)
                .WithMany()
                .HasForeignKey(ss => ss.SkillId);
        }
    }
}
