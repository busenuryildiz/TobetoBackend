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
            services.AddScoped<IMediaPostService, MediaPostManager>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<InstructorBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<StudentBusinessRules>();
            services.AddScoped<MediaPostBusinessRules>();



            return services;
        }

    }
}
