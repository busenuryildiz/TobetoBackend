using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public  int ExamDuration { get; set; }
        public int NumberOfQuestion {  get; set; }
        public int Point { get; set; }
    }
}
