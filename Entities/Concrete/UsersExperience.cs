using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Concrete
{
    public class UsersExperience
    {
        public string EstablishmentName { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public string City { get; set; }
        public DateTime WorkBeginDate { get; set; }
        public DateTime WorkEndDate { get; set; }
        public string Description { get; set; }
        public User User { get; set; }

    }
}
