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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("LanguageId").IsRequired();
            builder.Property(l => l.Name).HasColumnName("LanguageName").IsRequired();


            builder.HasMany(l => l.UserLanguages)
                .WithOne(ul => ul.Language)
                .HasForeignKey(ul => ul.LanguageId);
                

            builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
        }
    }

}
