using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CourseStatus:Entity<int>
    {
        //tamamlanan devam eden eğitimler
        public string Name { get; set; }
        public int CourseId { get; set; }  
        

    }
}
