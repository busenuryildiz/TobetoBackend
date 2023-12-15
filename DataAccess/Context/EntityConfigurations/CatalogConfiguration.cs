using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class CatalogConfiguration: IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("CatalogId").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.CatalogName).HasColumnName("CatalogName").IsRequired();
            builder.Property(b => b.CatalogEducation).HasColumnName("CatalogEducation");
            builder.Property(b => b.CatalogLevel).HasColumnName("CatalogLevel");
            builder.Property(b => b.CatalogSubject).HasColumnName("CatalogSubject");
            builder.Property(b => b.SoftwareLanguage).HasColumnName("SoftwareLanguage");
            builder.Property(b => b.Instructor).HasColumnName("Instructor");
            builder.Property(b => b.EducationStatus).HasColumnName("EducationStatus");

            builder.HasIndex(indexExpression: b => b.CatalogName, name: "UK_Catalogs_CatalogName").IsUnique();
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
