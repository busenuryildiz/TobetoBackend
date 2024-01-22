using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes.Surveys;

namespace DataAccess.Context.EntityConfigurations
{
    public class SurveyQuestionConfiguration : IEntityTypeConfiguration<SurveyQuestion>
    {
        public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
        {
            builder.ToTable("SurveyQuestions");

            builder.HasKey(sq => sq.Id);
            builder.Property(sq => sq.SurveyID).IsRequired();
            builder.Property(sq => sq.QuestionText).IsRequired();
            builder.Property(sq => sq.QuestionType).IsRequired();

            builder.HasOne(sq => sq.Survey)
                .WithMany(s => s.SurveyQuestions)
                .HasForeignKey(sq => sq.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sq => sq.SurveyAnswers)
                .WithOne(sa => sa.SurveyQuestion)
                .HasForeignKey(sa => sa.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
