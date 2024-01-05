using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.UserLanguage
{
    public class UpdateUserLanguageRequest
    {
        public int? Id { get; set; }
        public Guid? UserId { get; set; }
        public int? LanguageId { get; set; }
        public int? LanguageLevelId { get; set; }
    }
}
