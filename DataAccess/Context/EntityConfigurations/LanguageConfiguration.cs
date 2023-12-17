using Entities.Concrete.Profile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).IsRequired().HasMaxLength(255);
            builder.Property(l => l.LanguageLevelId).IsRequired();

            builder.HasOne(l => l.LanguageLevel)
                .WithMany()
                .HasForeignKey(l => l.LanguageLevelId);
        }
    }
}
