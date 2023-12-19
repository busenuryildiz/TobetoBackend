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

            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<ISurveyService, SurveyManager>();
            services.AddScoped<IMediaPostService, MediaPostManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ISubjectService, SubjectManager>();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<BlogBusinessRules>();
            services.AddScoped<InstructorBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<StudentBusinessRules>();
            services.AddScoped<MediaPostBusinessRules>();
            services.AddScoped<CourseBusinessRules>();


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
