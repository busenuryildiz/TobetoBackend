using Autofac;
using DataAccess.Concretes;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Module = Autofac.Module;

namespace DataAccess.DependencyResolvers.Autofac
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
            // DbContextOptions kaydı
            builder.Register<DbContextOptions<TobetoContext>>(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<TobetoContext>();
                dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("Tobeto"));
                return dbContextOptionsBuilder.Options;
            }).InstancePerLifetimeScope();

            // DbContext kaydı
            builder.Register<DbContextOptions<TobetoContext>>(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<TobetoContext>();
                dbContextOptionsBuilder.UseSqlServer(c.Resolve<IConfiguration>().GetConnectionString("Tobeto"));
                return dbContextOptionsBuilder.Options;
            }).InstancePerLifetimeScope();


            // Dal sınıfları kayıtları
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(EfInstructorDal)))
                .Where(t => t.Name.EndsWith("Dal"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // İhtiyaç duyulan diğer servis kayıtları buraya eklenebilir.

            base.Load(builder);
        }
    }
}
