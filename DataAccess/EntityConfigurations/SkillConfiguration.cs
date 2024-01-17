using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills").HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name"); 

            builder.HasMany(s => s.StudentSkills)
                .WithOne(ss => ss.Skill)
                .HasForeignKey(ss => ss.SkillId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }



}
