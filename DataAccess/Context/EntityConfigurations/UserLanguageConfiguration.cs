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
    public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
    {
        public void Configure(EntityTypeBuilder<UserLanguage> builder)
        {
            builder.HasKey(ul => ul.Id);
            builder.Property(ul => ul.UserId).IsRequired();
            builder.Property(ul => ul.LanguageId).IsRequired();
            builder.Property(ul => ul.LanguageLevelId).IsRequired();

            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(ul => ul.UserId);

            builder.HasOne(ul => ul.Language)
                .WithMany()
                .HasForeignKey(ul => ul.LanguageId);

            builder.HasOne(ul => ul.LanguageLevel)
                .WithMany()
                .HasForeignKey(ul => ul.LanguageLevelId);
        }
    }
}
