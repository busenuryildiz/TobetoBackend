using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Certificate : Entity <int>
    {
        public int UserId { get; set; }// Kullanıcıya ait sertifika
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; } // Sertifikayı kullanıcıyla ilişkilendirmek için referans
    }
}
