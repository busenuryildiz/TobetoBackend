using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request
{
    public class CreateCatalogRequest
    {
        public Guid UserId { get; set; }
        public string CatalogName { get; set; }
        public string? CatalogEducation { get; set; }
        public string? CatalogLevel { get; set; }
        public string? CatalogSubject { get; set; }
        public string? SoftwareLanguage { get; set; }
        public string? Instructor { get; set; }
        public string? EducationStatus { get; set; }
    }
}
