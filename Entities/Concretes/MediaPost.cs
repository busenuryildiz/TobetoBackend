using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes
{
    public class MediaPost:Entity<int>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? Date { get; set; }

    }
}
