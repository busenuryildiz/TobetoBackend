using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Course:Entity<Guid>
    {
        public string Name { get; set; }
        public int DateId { get; set; }
        public string ImagePath { get; set; }
        public int Progress { get; set; }
        public float Point { get; set; }
        public int Like { get; set; }
        public bool Saveds { get; set; }
    }
}
