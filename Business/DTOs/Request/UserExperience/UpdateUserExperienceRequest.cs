using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.UserExperience
{
    public class UpdateUserExperienceRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string EstablishmentName { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public string City { get; set; }
        public DateTime WorkBeginDate { get; set; }
        public DateTime WorkEndDate { get; set; }
        public string Description { get; set; }
    }
}
