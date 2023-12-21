using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.SoftwareLanguage
{
    public class DeleteSoftwareLanguageRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
