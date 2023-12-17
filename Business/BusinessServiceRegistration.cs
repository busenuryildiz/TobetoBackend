using Business.Abstract;
using Business.Concrete;
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
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<INewService, NewManager>();
            services.AddScoped<ICatalogService, CatalogManager>();

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
