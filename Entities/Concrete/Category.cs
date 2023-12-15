using Core.Entities;

namespace Entities.Concrete
{
    public class  Category : Entity<int>  
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }   


        
    }

}
