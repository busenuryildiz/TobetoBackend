using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.Core.Configuration;
using Core.Business.Rules;
using Core.Utilities.Interceptors;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Module = Autofac.Module;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using AutoMapper;
using Business.Rules.BusinessRules;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module

    {
        private IConfiguration _configuration;


        public AutofacBusinessModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {



            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<InstructorManager>().As<IInstructorService>();
            builder.RegisterType<SurveyManager>().As<ISurveyService>();
            builder.RegisterType<MediaPostManager>().As<IMediaPostService>();
            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<SubjectManager>().As<ISubjectService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<ApplicationManager>().As<IApplicationService>();
            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<LanguageLevelManager>().As<ILanguageLevelService>();
            builder.RegisterType<ExamManager>().As<IExamService>();
            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<ManagerManager>().As<IManagerService>();
            builder.RegisterType<CertificateManager>().As<ICertificateService>();
            builder.RegisterType<LanguageManager>().As<ILanguageService>();
            builder.RegisterType<SocialMediaAccountManager>().As<ISocialMediaAccountService>();
            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>();
            builder.RegisterType<ApplicationStudentManager>().As<IApplicationStudentService>();
            builder.RegisterType<StudentAssignmentManager>().As<IStudentAssignmentService>();
            builder.RegisterType<SoftwareLanguageManager>().As<ISoftwareLanguageService>();
            builder.RegisterType<AssignmentManager>().As<IAssignmentService>();
            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<CourseLevelManager>().As<ICourseLevelService>();
            builder.RegisterType<CourseSubjectManager>().As<ICourseSubjectService>();
            builder.RegisterType<QuestionManager>().As<IQuestionService>();
            builder.RegisterType<OptionManager>().As<IOptionService>();
            builder.RegisterType<InstructorCourseManager>().As<IInstructorCourseService>();
            builder.RegisterType<LessonCourseManager>().As<ILessonCourseService>();
            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<StudentCourseManager>().As<IStudentCourseService>();
            builder.RegisterType<CertificateManager>().As<ICertificateService>();
            builder.RegisterType<EducationInformationManager>().As<IEducationInformationService>();
            builder.RegisterType<LanguageManager>().As<ILanguageService>();
            builder.RegisterType<LanguageLevelManager>().As<ILanguageLevelService>();
            builder.RegisterType<SkillManager>().As<ISkillService>();
            builder.RegisterType<SocialMediaAccountManager>().As<ISocialMediaAccountService>();
            builder.RegisterType<UserLanguageManager>().As<IUserLanguageService>();
            builder.RegisterType<UserExperienceManager>().As<IUserExperienceService>();
            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>();
            builder.RegisterType<ApplicationManager>().As<IApplicationService>();
            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<MediaPostManager>().As<IMediaPostService>();
            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<StudentSkillManager>().As<IStudentSkillService>();
            builder.RegisterType<SubjectManager>().As<ISubjectService>();
            builder.RegisterType<SurveyManager>().As<ISurveyService>();
            builder.RegisterType<UserRoleManager>().As<IUserRoleService>();
            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<LessonManager>().As<ILessonService>();
            builder.RegisterType<ContactUsManager>().As<IContactUsService>();
            builder.RegisterType<DistrictManager>().As<IDistrictService>();

            // İş kuralları
            builder.RegisterType<InstructorBusinessRules>().AsSelf();
            builder.RegisterType<ManagerBusinessRules>().AsSelf();
            builder.RegisterType<AddressBusinessRules>().AsSelf();
            builder.RegisterType<StudentBusinessRules>().AsSelf();
            builder.RegisterType<UserBusinessRules>().AsSelf();
            builder.RegisterType<SoftwareLanguageBusinessRules>().AsSelf();
            builder.RegisterType<AssignmentBusinessRules>().AsSelf();
            builder.RegisterType<CourseBusinessRules>().AsSelf();
            builder.RegisterType<CourseLevelBusinessRules>().AsSelf();
            builder.RegisterType<CourseSubjectBusinessRules>().AsSelf();
            builder.RegisterType<ExamBusinessRules>().AsSelf();
            builder.RegisterType<InstructorCourseBusinessRules>().AsSelf();
            builder.RegisterType<LessonCourseBusinessRules>().AsSelf();
            builder.RegisterType<PaymentBusinessRules>().AsSelf();
            builder.RegisterType<CertificateBusinessRules>().AsSelf();
            builder.RegisterType<EducationInformationBusinessRules>().AsSelf();
            builder.RegisterType<LanguageBusinessRules>().AsSelf();
            builder.RegisterType<LanguageLevelBusinessRules>().AsSelf();
            builder.RegisterType<SkillBusinessRules>().AsSelf();
            builder.RegisterType<SocialMediaAccountBusinessRules>().AsSelf();
            builder.RegisterType<UserLanguageBusinessRules>().AsSelf();
            builder.RegisterType<UserExperienceBusinessRules>().AsSelf();
            builder.RegisterType<AnnouncementBusinessRules>().AsSelf();
            builder.RegisterType<ApplicationBusinessRules>().AsSelf();
            builder.RegisterType<BlogBusinessRules>().AsSelf();
            builder.RegisterType<MediaPostBusinessRules>().AsSelf();
            builder.RegisterType<RoleBusinessRules>().AsSelf();
            builder.RegisterType<StudentSkillBusinessRules>().AsSelf();
            builder.RegisterType<StudentCourseBusinessRules>().AsSelf();
            builder.RegisterType<UserRoleBusinessRules>().AsSelf();
            builder.RegisterType<CityBusinessRules>().AsSelf();
            builder.RegisterType<CountryBusinessRules>().AsSelf();
            builder.RegisterType<LessonBusinessRules>().AsSelf();
            builder.RegisterType<ContactUsBusinessRules>().AsSelf();


            // DATA ACCESS LAYER

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
            builder.RegisterType<AutoMapper.MapperConfiguration>().SingleInstance();


            //Extensions
            builder.AddSubClassesOfType(typeof(BaseBusinessRules));
            builder.RegisterAspects();
            // AutofacDataAccessModule.cs veya benzer bir yerde
            builder.Register<DbContextOptions<TobetoContext>>(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<TobetoContext>();
                dbContextOptionsBuilder.UseSqlServer(c.Resolve<IConfiguration>().GetConnectionString("Tobeto"));
                return dbContextOptionsBuilder.Options;
            }).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(type => type.IsSubclassOf(typeof(BaseBusinessRules)))
                .AsSelf();



            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => typeof(Profile).IsAssignableFrom(t))
               .As<Profile>()
               .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    {
                        cfg.AddProfile(profile);
                    }
                });
                return config.CreateMapper();
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            // 
            //builder.RegisterType<TobetoContext>()
            //    .WithParameter("options", new DbContextOptionsBuilder<TobetoContext>()
            //        .UseSqlServer(_configuration.GetConnectionString("Tobeto"))
            //        .Options)
            //    .InstancePerLifetimeScope();

            builder.RegisterType<TobetoContext>()
        .AsSelf()
            .InstancePerLifetimeScope()
        .WithParameter("connectionString", _configuration.GetConnectionString("Tobeto"));


        }

    }
}
