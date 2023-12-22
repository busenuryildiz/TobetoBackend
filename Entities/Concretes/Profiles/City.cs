using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Profiles
{
    public class City: Entity<int>
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<County> Counties { get; set; }
        public Country Country { get; set; }
    }
}
