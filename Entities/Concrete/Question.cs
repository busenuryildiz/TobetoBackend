using System.Security.AccessControl;
using Core.Entities;

namespace Entities.Concrete
{
    public class Question:Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string? Problem { get; set; }
        public string? Answer { get; set; }
        public Exam? Exam { get; set; }
    }
}