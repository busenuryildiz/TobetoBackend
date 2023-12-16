using Core.Entities;
using Entities.Concrete.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Survey : Entity<int>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string SurveyUrl { get; set; }
        public User User { get; set; }

    }
}
