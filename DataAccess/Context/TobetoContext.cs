using Entities.Concretes;
using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Courses;
using Entities.Concretes.Profiles;

namespace DataAccess.Context
{
    public class TobetoContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<CourseStatus> CourseStatuses { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Lesson> Lessons{ get; set; }
        public DbSet<Language> Languages{ get; set; }
        public DbSet<LanguageLevel> LanguageLevels{ get; set; }
        public DbSet<Option> Options{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Instructor> Instructors{ get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<MediaPost> MediaPosts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SoftwareLanguage> SoftwareLanguages { get; set; }
        public DbSet<EducationInformation> EducationInformations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Manager> Managers { get; set; }



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
