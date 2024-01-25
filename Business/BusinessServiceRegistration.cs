using Business.Abstracts;
using Business.Concretes;
using Business.DTOs.Request.Address;
using Business.DTOs.Request.Announcement;
using Business.DTOs.Request.Application;
using Business.DTOs.Request.ApplicationStudent;
using Business.DTOs.Request.Assignments;
using Business.DTOs.Request.Blog;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Certificate;
using Business.DTOs.Request.City;
using Business.DTOs.Request.ContactUs;
using Business.DTOs.Request.Country;
using Business.DTOs.Request.Course;
using Business.DTOs.Request.CourseLevel;
using Business.DTOs.Request.District;
using Business.DTOs.Request.EducationInformation;
using Business.DTOs.Request.Exam;
using Business.DTOs.Request.InstructorCourse;
using Business.DTOs.Request.Language;
using Business.DTOs.Request.LanguageLevel;
using Business.DTOs.Request.Lesson;
using Business.DTOs.Request.MediaPost;
using Business.DTOs.Request.Option;
using Business.DTOs.Request.Role;
using Business.DTOs.Request.Skill;
using Business.DTOs.Request.SocialMediaAccount;
using Business.DTOs.Request.SoftwareLanguage;
using Business.DTOs.Request.StudentAssignment;
using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Request.Subject;
using Business.DTOs.Request.Survey;
using Business.DTOs.Request.University;
using Business.DTOs.Request.UserExperience;
using Business.DTOs.Request.UserLanguage;
using Business.DTOs.Request.UserUniversity;
using Business.Rules;
using Business.Rules.ValidationRules;
using Core.Business.Rules;
using Core.Utilities.JWT;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{

    public static class BusinessServiceRegistration
    {

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IStudentService, StudentManager>();

            services.AddScoped<IUserRoleService, UserRoleManager>();

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
            services.AddScoped<IUniversityService, UniversityManager>();
            services.AddScoped<IUserUniversityService, UserUniversityManager>();
            services.AddScoped<IClassroomOfCourseService, ClassroomOfCourseManager>();
            services.AddScoped<IClassroomService, ClassroomManager>();

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
            services.AddScoped<IEmailService, EmailManager>();



            services.AddScoped<InstructorBusinessRules>();
            services.AddScoped<ManagerBusinessRules>();
            services.AddScoped<AddressBusinessRules>();
            services.AddScoped<StudentBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<SoftwareLanguageBusinessRules>();
            services.AddScoped<UserUniversityBusinessRules>();

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


            services.AddScoped<UniversityBusinessRules>();


            //Validators
            services.AddScoped<IValidator<CreateBlogRequest>, CreateBlogRequestValidator>();
            services.AddScoped<IValidator<CreateAnnouncementRequest>, CreateAnnouncementRequestValidator>();
            services.AddScoped<IValidator<CreateMediaPostRequest>, CreateMediaPostRequestValidator>();
            services.AddScoped<IValidator<CreateCategoryRequest>, CreateCategoryRequestValidator>();
            services.AddScoped<IValidator<CreateApplicationRequest>, CreateApplicationRequestValidator>();
            services.AddScoped<IValidator<CreateApplicationStudentRequest>, CreateApplicationStudentRequestValidator>();
            services.AddScoped<IValidator<CreateContactUsRequest>, CreateContactUsRequestValidator>();
            services.AddScoped<IValidator<CreateSurveyRequest>, CreateSurveyRequestValidator>();
            services.AddScoped<IValidator<CreateSubjectRequest>, CreateSubjectRequestValidator>();
            services.AddScoped<IValidator<CreateRoleRequest>, CreateRoleRequestValidator>();
            services.AddScoped<IValidator<CreateAddressRequest>, CreateAddressRequestValidator>();
            services.AddScoped<IValidator<CreateCertificateRequest>, CreateCertificateRequestValidator>();
            services.AddScoped<IValidator<CreateCityRequest>, CreateCityRequestValidator>();
            services.AddScoped<IValidator<CreateCountryRequest>, CreateCountryRequestValidator>();
            services.AddScoped<IValidator<CreateDistrictRequest>, CreateDistrictRequestValidator>();
            services.AddScoped<IValidator<CreateEducationInformationRequest>, CreateEducationInformationRequestValidator>();
            services.AddScoped<IValidator<CreateLanguageRequest>, CreateLanguageRequestValidator>();
            services.AddScoped<IValidator<CreateLanguageLevelRequest>, CreateLanguageLevelRequestValidator>();
            services.AddScoped<IValidator<CreateSkillRequest>, CreateSkillRequestValidator>();
            services.AddScoped<IValidator<CreateSocialMediaAccountRequest>, CreateSocialMediaAccountRequestValidator>();
            services.AddScoped<IValidator<CreateUniversityRequest>, CreateUniversityRequestValidator>();
            services.AddScoped<IValidator<CreateUserExperienceRequest>, CreateUserExperienceRequestValidator>();
            services.AddScoped<IValidator<CreateUserLanguageRequest>, CreateUserLanguageRequestValidator>();
            services.AddScoped<IValidator<CreateUserUniversityRequest>, CreateUserUniversityRequestValidator>();
            services.AddScoped<IValidator<CreateAssignmentRequest>, CreateAssignmentRequestValidator>();
            services.AddScoped<IValidator<CreateCourseRequest>, CreateCourseRequestValidator>();
            services.AddScoped<IValidator<CreateCourseLevelRequest>, CreateCourseLevelRequestValidator>();
            services.AddScoped<IValidator<CreateExamRequest>, CreateExamRequestValidator>();
            services.AddScoped<IValidator<CreateInstructorCourseRequest>, CreateInstructorCourseRequestValidator>();
            services.AddScoped<IValidator<CreateLessonRequest>, CreateLessonRequestValidator>();
            services.AddScoped<IValidator<CreateOptionRequest>, CreateOptionRequestValidator>();
            services.AddScoped<IValidator<CreateQuestionRequest>, CreateQuestionRequestValidator>();
            services.AddScoped<IValidator<CreateSoftwareLanguageRequest>, CreateSoftwareLanguageRequestValidator>();
            services.AddScoped<IValidator<CreateStudentAssignmentRequest>, CreateStudentAssignmentRequestValidator>();
            services.AddScoped<IValidator<CreateStudentCourseRequest>, CreateStudentCourseRequestValidator>();


            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
            return services;

        }

        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
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
