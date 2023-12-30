using Autofac;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class AutofacDataAccessModule : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacDataAccessModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TobetoContext>()
                .WithParameter("options", new DbContextOptionsBuilder<TobetoContext>()
                    .UseSqlServer(_configuration.GetConnectionString("Tobeto"))
                    .Options)
                .InstancePerLifetimeScope();

            RegisterRepositories(builder);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<EfInstructorDal>().As<IInstructorDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfManagerDal>().As<IManagerDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfAssignmentDal>().As<IAssignmentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCourseLevelDal>().As<ICourseLevelDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCourseSubjectDal>().As<ICourseSubjectDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfExamDal>().As<IExamDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfInstructorCourseDal>().As<IInstructorCourseDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfLessonCourseDal>().As<ILessonCourseDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfOptionDal>().As<IOptionDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfSoftwareLanguageDal>().As<ISoftwareLanguageDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfStudentCourseDal>().As<IStudentCourseDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfApplicationStudentDal>().As<IApplicationStudentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfStudentAssignmentDal>().As<IStudentAssignmentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCertificateDal>().As<ICertificateDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfEducationInformationDal>().As<IEducationInformationDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfLanguageLevelDal>().As<ILanguageLevelDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfSkillDal>().As<ISkillDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfSocialMediaAccountDal>().As<ISocialMediaAccountDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserExperienceDal>().As<IUserExperienceDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserLanguageDal>().As<IUserLanguageDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfApplicationDal>().As<IApplicationDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfContactUsDal>().As<IContactUsDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfMediaPostDal>().As<IMediaPostDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfStudentSkillDal>().As<IStudentSkillDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfSubjectDal>().As<ISubjectDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfSurveyDal>().As<ISurveyDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserRoleDal>().As<IUserRoleDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCourseSubjectDal>().As<ICourseSubjectDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCityDal>().As<ICityDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfDistrictDal>().As<IDistrictDal>().InstancePerLifetimeScope();
        }

        // Diğer repository kayıtları buraya eklenir
    }
}

