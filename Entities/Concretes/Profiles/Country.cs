using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Profiles
{
    public class Country: Entity<int>
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }

    }
}
