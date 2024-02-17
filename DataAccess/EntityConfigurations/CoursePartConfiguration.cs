using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CoursePartConfiguration : IEntityTypeConfiguration<CoursePart>
{
    public void Configure(EntityTypeBuilder<CoursePart> builder)
    {
        // Tablo adı ve anahtar özelliklerin belirlenmesi
        builder.ToTable("CourseParts");
        builder.HasKey(cp => cp.Id);

        // CourseId ile Course arasındaki ilişkinin belirlenmesi
        builder.HasOne(cp => cp.Course)
               .WithMany(c => c.CourseParts)
               .HasForeignKey(cp => cp.CourseId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); // CoursePart silindiğinde Lessons'ların da silinmesi

        // Lessons ile ilişkinin belirlenmesi (CoursePart ile One-to-Many ilişki)
        builder.HasMany(cp => cp.Lessons)
               .WithOne(l => l.CoursePart)
               .HasForeignKey(l => l.CoursePartId)
               .OnDelete(DeleteBehavior.Restrict); // Kaskat kaldırma davranışını değiştir

    }
}