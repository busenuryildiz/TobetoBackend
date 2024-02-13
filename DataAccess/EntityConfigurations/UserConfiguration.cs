using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concretes.Clients;

namespace DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
            builder.Property(u => u.Email).HasMaxLength(255);
            builder.Property(u => u.Password);
            builder.Property(u => u.NationalIdentity);
            builder.Property(u => u.BirthDate).HasColumnType("date");
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.ImagePath).HasMaxLength(255); // İmge yolu için örnek sınırlama

            builder.HasMany(u => u.EducationInformations)
                .WithOne(ei => ei.User)
                .HasForeignKey(ei => ei.UserId);

            builder.HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Certificates)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.SocialMediaAccounts)
                .WithOne(sma => sma.User)
                .HasForeignKey(sma => sma.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserExperiences)
                .WithOne(ue => ue.User)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserLanguages)
                .WithOne(ul => ul.User)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(u => u.Surveys)
            //    .WithOne(s => s.User)
            //    .HasForeignKey(s => s.CreatorUserID)
            //    .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.SurveyAnswers)
                .WithOne(sa => sa.User)
                .HasForeignKey(sa => sa.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserUniversities)
                .WithOne(uu => uu.User)
                .HasForeignKey(uu => uu.UserId);

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }
}
