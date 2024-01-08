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
            builder.Property(ll => ll.Id).HasColumnName("LanguageLevelId").IsRequired();

            builder.Property(ll => ll.Name).HasColumnName("LanguageName").IsRequired();


            builder.HasMany(ll => ll.UserLanguages)
                .WithOne(l => l.LanguageLevel)
                .HasForeignKey(l => l.LanguageLevelId);

            builder.HasQueryFilter(ll => !ll.DeletedDate.HasValue);
        }
    }
}

