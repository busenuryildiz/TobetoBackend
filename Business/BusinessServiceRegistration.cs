using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.Aspects.ActionFilters;
using Core.Business.Rules;
using Core.Utilities.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public static class BusinessServiceRegistration
    {

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {







            // AUTOMAPPER
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IUserRoleService,UserRoleManager >();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<ISurveyService, SurveyManager>();
            services.AddScoped<IMediaPostService, MediaPostManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ISubjectService, SubjectManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<ILanguageLevelService, LanguageLevelManager>();
            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IApplicationStudentService, ApplicationStudentManager>();
            services.AddScoped<IStudentAssignmentService, StudentAssignmentManager>();

            services.AddScoped<ISoftwareLanguageService, SoftwareLanguageManager>();
            services.AddScoped<IStudentAssignmentService, StudentAssignmentManager>();
            services.AddScoped<IDistrictService, DistrictManager>();
            services.AddScoped<StudentAssignmentBusinessRules>();
            services.AddScoped<DistrictBusinessRules>();

            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICourseLevelService, CourseLevelManager>();
            services.AddScoped<ICourseSubjectService, CourseSubjectManager>();
            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IOptionService, OptionManager>();
            services.AddScoped<IInstructorCourseService, InstructorCourseManager>();
            services.AddScoped<ILessonCourseService, LessonCourseManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IStudentCourseService, StudentCourseManager>();
            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<IEducationInformationService, EducationInformationManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ILanguageLevelService, LanguageLevelManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
            services.AddScoped<IUserLanguageService, UserLanguageManager>();
            services.AddScoped<IUserExperienceService, UserExperienceManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IMediaPostService, MediaPostManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IStudentSkillService, StudentSkillManager>();
            services.AddScoped<ISubjectService, SubjectManager>();
            services.AddScoped<ISurveyService, SurveyManager>();

            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ILessonService, LessonManager>();
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IDistrictService, DistrictManager>();
            services.AddScoped<IUserService, UserManager>();



            services.AddScoped<InstructorBusinessRules>();
            services.AddScoped<ManagerBusinessRules>();
            services.AddScoped<AddressBusinessRules>();
            services.AddScoped<StudentBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<SoftwareLanguageBusinessRules>();

            services.AddScoped<AssignmentBusinessRules>();
            services.AddScoped<CourseBusinessRules>();
            services.AddScoped<CourseLevelBusinessRules>();
            services.AddScoped<CourseSubjectBusinessRules>();
            services.AddScoped<ExamBusinessRules>();
            services.AddScoped<InstructorCourseBusinessRules>();
            services.AddScoped<LessonCourseBusinessRules>();
            services.AddScoped<PaymentBusinessRules>();
            services.AddScoped<CertificateBusinessRules>();
            services.AddScoped<EducationInformationBusinessRules>();
            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<LanguageLevelBusinessRules>();
            services.AddScoped<SkillBusinessRules>();
            services.AddScoped<SocialMediaAccountBusinessRules>();
            services.AddScoped<UserLanguageBusinessRules>();
            services.AddScoped<UserExperienceBusinessRules>();
            services.AddScoped<AnnouncementBusinessRules>();
            services.AddScoped<ApplicationBusinessRules>();
            services.AddScoped<BlogBusinessRules>();
            services.AddScoped<MediaPostBusinessRules>();
            services.AddScoped<RoleBusinessRules>();
            services.AddScoped<StudentSkillBusinessRules>();
            services.AddScoped<StudentCourseBusinessRules>();
            services.AddScoped<CityBusinessRules>();
            services.AddScoped<CountryBusinessRules>();

            services.AddScoped<LessonBusinessRules>();
            services.AddScoped<ContactUsBusinessRules>();
            services.AddTransient<UserRoleBusinessRules>();
            services.AddScoped<JwtService>();
            //kerem@gmail.com

            return services;
        }
        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
        )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
