using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Profiles
{
    public class County: Entity<int>
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
