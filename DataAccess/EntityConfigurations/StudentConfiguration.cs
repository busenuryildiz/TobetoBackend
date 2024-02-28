    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Entities.Concretes.Clients;

    namespace DataAccess.EntityConfigurations
    {
        public class StudentConfiguration : IEntityTypeConfiguration<Student>
        {
            public void Configure(EntityTypeBuilder<Student> builder)
            {
                builder.ToTable("Students").HasKey(b => b.Id);
                builder.Property(b => b.Id).HasColumnName("StudentId").IsRequired();
                builder.Property(b => b.UserId).HasColumnName("UserId");

                // Öğrenci numarası için otomatik oluşturulması ve unique olması
                builder.Property(s => s.StudentNumber)
         .ValueGeneratedNever(); // Otomatik artan olmayacak


                builder.HasIndex(b => b.StudentNumber)
                    .IsUnique();  // Benzersiz index oluştur

                // User ilişkisi
                builder.HasOne(b => b.User)
                       .WithOne(u => u.Student)
                       .HasForeignKey<Student>(b => b.UserId)
                       .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.StudentAssignments);


                builder.HasMany(u => u.StudentAssignments)
                    .WithOne(ei => ei.Student)
                    .HasForeignKey(ei => ei.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(u => u.StudentSkills)
                    .WithOne(ei => ei.Student)
                    .HasForeignKey(ei => ei.StudentId);

                builder.HasMany(u => u.ApplicationStudents)
                   .WithOne(ei => ei.Student)
                   .HasForeignKey(ei => ei.StudentId);

                builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
            }
        }
    }
