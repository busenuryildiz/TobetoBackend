using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.Business.Rules;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
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


            //Extensions
            builder.AddSubClassesOfType(typeof(BaseBusinessRules));
            builder.RegisterAspects();
        }

    }
}
