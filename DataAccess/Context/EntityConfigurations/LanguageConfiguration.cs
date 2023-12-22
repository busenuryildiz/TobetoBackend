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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(l => l.Id);

            builder.Property(l => l.Name).HasColumnName("Name").IsRequired();

            builder.HasMany(l => l.UserLanguages)
                .WithOne(ul => ul.Language)
                .HasForeignKey(ul => ul.LanguageId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }

}
