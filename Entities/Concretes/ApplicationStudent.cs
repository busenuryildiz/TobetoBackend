using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes
{
    public class ApplicationStudent : Entity<int>
    {
        public int ApplicationId { get; set; }
        public Guid StudentId { get; set; }
        public Application Application { get; set; }
        public Student Student { get; set; }
    }
}
