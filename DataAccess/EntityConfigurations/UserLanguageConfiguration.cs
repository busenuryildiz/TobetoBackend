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
    public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
    {
        public void Configure(EntityTypeBuilder<UserLanguage> builder)
        {
            builder.ToTable("UserLanguages").HasKey(ul => ul.Id);

            builder.Property(ul => ul.UserId)
                .IsRequired()
                .HasColumnName("UserId"); 

            builder.Property(ul => ul.LanguageId)
                .IsRequired()
                .HasColumnName("LanguageId");

            builder.Property(ul => ul.LanguageLevelId)
                .IsRequired()
                .HasColumnName("LanguageLevelId");


            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(ul => ul.UserId);

            builder.HasOne(ul => ul.Language)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(ul => ul.LanguageId);


            builder.HasOne(ul => ul.LanguageLevel)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(ul => ul.LanguageLevelId);

            builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
        }
    }



}
