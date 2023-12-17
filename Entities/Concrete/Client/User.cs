using Core.Entities;
using Entities.Concrete.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Client
{
    public class User : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int NationalIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsInstructor { get; set; }
        public List<EducationInformation> EducationInformations { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public List<UserExperience> UserExperiences { get; set; }
        public List<UserLanguage> UserLanguage { get; set; }
        public Student Student { get; set; }    
        public Instructor  Instructor { get; set; } 

    }

}
