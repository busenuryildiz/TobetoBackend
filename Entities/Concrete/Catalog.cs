using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Catalog : Entity<int>
    {
       
       
        public string? CatalogLevel { get; set; }
        public string? CatalogSubject { get; set; }
        public string? SoftwareLanguage { get; set; }
        
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
