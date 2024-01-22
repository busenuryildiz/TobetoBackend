using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes.Surveys;

namespace DataAccess.Context.EntityConfigurations
{
    public class SurveyAnswerConfiguration : IEntityTypeConfiguration<SurveyAnswer>
    {
        public void Configure(EntityTypeBuilder<SurveyAnswer> builder)
        {
            builder.ToTable("SurveyAnswers");

            builder.HasKey(sa => sa.Id);
            builder.Property(sa => sa.UserID).IsRequired();
            builder.Property(sa => sa.SurveyID).IsRequired();
            builder.Property(sa => sa.QuestionID).IsRequired();
            builder.Property(sa => sa.AnswerValue).IsRequired();

            builder.HasOne(sa => sa.User)
                .WithMany()
                .HasForeignKey(sa => sa.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.Survey)
                .WithMany(s => s.SurveyAnswers)
                .HasForeignKey(sa => sa.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.SurveyQuestion)
                .WithMany(sq => sq.SurveyAnswers)
                .HasForeignKey(sa => sa.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
