using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.Business.Rules;
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IStudentService, StudentManager>();

            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<ISurveyService, SurveyManager>();
            services.AddScoped<IMediaPostService, MediaPostManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ISubjectService, SubjectManager>();
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
            services.AddScoped<ISoftwareLanguageService ,SoftwareLanguageManager>();

            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IInstructorService, InstructorManager>();

            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICourseLevelService, CourseLevelManager>();
            services.AddScoped<ICourseStatusService, CourseStatusManager>();
            services.AddScoped<ICourseSubjectService, CourseSubjectManager>();

            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IOptionService, OptionManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IInstructorCourseService, InstructorCourseManager>();

            services.AddScoped<ILessonCourseService, LessonCourseManager>();
            //services.AddScoped<IOptionService, OptionManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IStudentCourseService, StudentCourseManager>();

            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<IEducationInformationService, EducationInformationManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ILanguageLevelService, LanguageLevelManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
            services.AddScoped<IUserLanguageService, UserLanguageManager>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IMediaPostService, MediaPostManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IStudentSkillService, StudentSkillManager>();
            services.AddScoped<ISubjectService, SubjectManager>();
            services.AddScoped<ISurveyService, SurveyManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();

            services.AddScoped<InstructorBusinessRules>();
            services.AddScoped<ManagerBusinessRules>();
            services.AddScoped<StudentBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<SoftwareLanguageBusinessRules>();

            services.AddScoped<AssignmentBusinessRules>();
            services.AddScoped<CourseBusinessRules>();
            services.AddScoped<CourseLevelBusinessRules>();
            services.AddScoped<CourseStatusBusinessRules>();
            services.AddScoped<CourseSubjectBusinessRules>();
            services.AddScoped<ExamBusinessRules>();
            services.AddScoped<InstructorCourseBusinessRules>();
            //services.AddScoped<LessonBusinessRules>();
            services.AddScoped<LessonCourseBusinessRules>();
            //services.AddScoped<OptionBusinessRules>();
            services.AddScoped<PaymentBusinessRules>();
            //services.AddScoped<QuestionBusinessRules>();
            //services.AddScoped<SoftwareLanguageBusinessRules>();
            //services.AddScoped<StudentCourseBusinessRules>();

            services.AddScoped<CertificateBusinessRules>();
            services.AddScoped<EducationInformationBusinessRules>();
            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<LanguageLevelBusinessRules>();
            services.AddScoped<SkillBusinessRules>();
            services.AddScoped<SocialMediaAccountBusinessRules>();
            services.AddScoped<UserLanguageBusinessRules>();
            services.AddScoped<AnnouncementBusinessRules>();
            services.AddScoped<ApplicationBusinessRules>();
            services.AddScoped<BlogBusinessRules>();
            //services.AddScoped<CategoryBusinessRules>();
            //services.AddScoped<ContactUsBusinessRules>();
            services.AddScoped<MediaPostBusinessRules>();
            services.AddScoped<RoleBusinessRules>();
            services.AddScoped<StudentSkillBusinessRules>();
            //services.AddScoped<SubjectBusinessRules>();
            //services.AddScoped<SurveyBusinessRules>();
            services.AddScoped<UserRoleBusinessRules>();


            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
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
