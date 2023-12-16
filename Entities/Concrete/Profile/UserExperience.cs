using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Concrete.Profile
{
    public class UserExperience : Entity<int>
    {
        public Guid UserId { get; set; }
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
