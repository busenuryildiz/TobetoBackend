using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Entities.Concretes;
using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TobetoContext>(options => options.UseSqlServer(configuration.GetConnectionString("Tobeto")));


            services.AddScoped<IInstructorDal, EfInstructorDal>();
            services.AddScoped<IManagerDal, EfManagerDal>();
            services.AddScoped<IStudentDal, EfStudentDal>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddScoped<IAssignmentDal, EfAssignmentDal>();
            services.AddScoped<ICourseDal, EfCourseDal>();
            services.AddScoped<ICourseLevelDal, EfCourseLevelDal>();
            services.AddScoped<ICourseStatusDal, EfCourseStatusDal>();
            services.AddScoped<ICourseSubjectDal, EfCourseSubjectDal>();
            services.AddScoped<IExamDal, EfExamDal>();
            services.AddScoped<IInstructorCourseDal, EfInstructorCourseDal>();
            services.AddScoped<ILessonDal, EfLessonDal>();
            services.AddScoped<ILessonCourseDal, EfLessonCourseDal>();
            services.AddScoped<IOptionDal, EfOptionDal>();
            services.AddScoped<IPaymentDal, EfPaymentDal>();
            services.AddScoped<IQuestionDal, EfQuestionDal>();
            services.AddScoped<ISoftwareLanguageDal, EfSoftwareLanguageDal>();
            services.AddScoped<IStudentCourseDal, EfStudentCourseDal>();
            services.AddScoped<IApplicationStudentDal, EfApplicationStudentDal>();
            services.AddScoped<IStudentAssignmentDal, EfStudentAssignmentDal>();

            services.AddScoped<ICertificateDal, EfCertificateDal>();
            services.AddScoped<IEducationInformationDal, EfEducationInformationDal>();
            services.AddScoped<ILanguageDal, EfLanguageDal>();
            services.AddScoped<ILanguageLevelDal, EfLanguageLevelDal>();
            services.AddScoped<ISkillDal, EfSkillDal>();
            services.AddScoped<ISocialMediaAccountDal, EfSocialMediaAccountDal>();
            services.AddScoped<IUserExperienceDal, EfUserExperienceDal>();
            services.AddScoped<ISoftwareLanguageDal, EfSoftwareLanguageDal>();
            services.AddScoped<IUserLanguageDal, EfUserLanguageDal>();

            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IApplicationDal, EfApplicationDal>();
            services.AddScoped<IBlogDal, EfBlogDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();
            services.AddScoped<IMediaPostDal, EfMediaPostDal>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IStudentSkillDal, EfStudentSkillDal>();
            services.AddScoped<ISubjectDal, EfSubjectDal>();
            services.AddScoped<ISurveyDal, EfSurveyDal>();
            services.AddScoped<IUserRoleDal, EfUserRoleDal>();
            services.AddScoped<ICourseSubjectDal, EfCourseSubjectDal>();
            services.AddScoped<ICityDal, EfCityDal>();
            services.AddScoped<ICountryDal, EfCountryDal>();



            return services;
        }
    }
}
