using Entities.Concrete;
using Entities.Concrete.Client;
using Entities.Concrete.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TobetoContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<New> News { get; set; }


        public TobetoContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(
            dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Konfigirasyon dosyalarını bul ve onu uygula demek
        }
    }
}
