using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Courses
{
    public class Payment : Entity<int>
    {
        public int? StudentCourseId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool? Status { get; set; }
        public StudentCourse? StudentCourse { get; set; }
    }
}
