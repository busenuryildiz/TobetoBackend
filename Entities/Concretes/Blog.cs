using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Blog : Entity<int>
    {
   
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
    }
}
