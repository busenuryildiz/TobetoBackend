using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Language
{
    public class CreateLanguageRequest
    {
        public string Name { get; set; }
        public int LanguageLevelId { get; set; }
    }
}
