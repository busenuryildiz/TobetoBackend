using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concretes.Surveys;

namespace DataAccess.EntityConfigurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys"); // Veritabanında kullanılacak tablo adı

            builder.HasKey(s => s.Id); // Id özelliğini primary key olarak belirt

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(255); // Örnek bir maksimum uzunluk belirleme

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(1000); // Örnek bir maksimum uzunluk belirleme

            // CreatorUserID için bir nullable GUID (Guid?) alanı belirtme
            builder.Property(s => s.CreatorUserID)
                .IsRequired(false);

            // User ile ilişkilendirme
            builder.HasOne(s => s.User)
                .WithMany(u => u.Surveys)
                .HasForeignKey(s => s.CreatorUserID)
                .OnDelete(DeleteBehavior.SetNull); // İlişkili User silindiğinde CreatorUserID'yi null yap

            // SurveyQuestions ile ilişkilendirme
            builder.HasMany(s => s.SurveyQuestions)
                .WithOne(sq => sq.Survey)
                .HasForeignKey(sq => sq.SurveyID)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Survey silindiğinde SurveyQuestions'ları da sil

            // SurveyAnswers ile ilişkilendirme
            builder.HasMany(s => s.SurveyAnswers)
                .WithOne(sa => sa.Survey)
                .HasForeignKey(sa => sa.SurveyID)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Survey silindiğinde SurveyAnswers'ları da sil
        }
    }
}
