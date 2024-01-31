using Core.Entities;
using Entities.Concretes.CoursesFolder;

namespace Entities.Concretes
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public List<Course>? Courses { get; set; }

    }

}
   