using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Client
{
    public class Student : Entity<int>
    {
        public Guid UserId { get; set; }
        public int StudentNumber { get; set; }
        public User User { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}
