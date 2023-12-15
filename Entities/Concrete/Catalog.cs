using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class SoftwareLanguage : Entity<int>
    {
        public string Name { get; set; }

       
        public string? CatalogLevel { get; set; }
        public string? CatalogSubject { get; set; }
        
        public string? EducationStatus { get; set; }
    }
    public class UserCatalog : Entity<int>
    {
        public Guid UserId { get; set; }
    }
    public class  Category : Entity<int>
    {
        
    }
}
