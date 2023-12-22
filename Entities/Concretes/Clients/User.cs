using Core.Entities;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Entities.Concretes.Clients
{
    public class User : Entity<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NationalIdentity { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
        public List<EducationInformation> EducationInformations { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public List<UserExperience> UserExperiences { get; set; }
        public List<UserLanguage> UserLanguages { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public List<UserRole> UserRoles { get; set; }


    }

}
