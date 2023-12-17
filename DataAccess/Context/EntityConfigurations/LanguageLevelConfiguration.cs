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
    public class LanguageLevelConfiguration : IEntityTypeConfiguration<LanguageLevel>
    {
        public void Configure(EntityTypeBuilder<LanguageLevel> builder)
        {
            builder.HasKey(ll => ll.Id);
            builder.Property(ll => ll.Name).IsRequired().HasMaxLength(255);
        }
    }
}
