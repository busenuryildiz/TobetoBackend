using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class LanguageLevelConfiguration : IEntityTypeConfiguration<LanguageLevel>
    {
        public void Configure(EntityTypeBuilder<LanguageLevel> builder)
        {
            builder.ToTable("LanguageLevels").HasKey(ll => ll.Id);

            builder.Property(ll => ll.Name).HasColumnName("Name").IsRequired();


            builder.HasMany(ll => ll.Languages)
                .WithOne(l => l.LanguageLevel)
                .HasForeignKey(l => l.LanguageLevelId)
                .IsRequired();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}

