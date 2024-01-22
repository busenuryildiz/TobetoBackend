using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes.Surveys;

namespace DataAccess.EntityConfigurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.CreatorUserID).IsRequired();

            builder.HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.CreatorUserID)
                .OnDelete(DeleteBehavior.Cascade);

    

            builder.HasMany(s => s.SurveyQuestions)
                .WithOne(sq => sq.Survey)
                .HasForeignKey(sq => sq.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SurveyAnswers)
                .WithOne(sa => sa.Survey)
                .HasForeignKey(sa => sa.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
