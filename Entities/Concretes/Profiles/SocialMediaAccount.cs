using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes
{
    public class SocialMediaAccount : Entity<int>
    {
        public Guid UserId { get; set; }
        public string SocialMedia { get; set; }
        public string SocialMediaUrl { get; set; }
        public User User { get; set; }

    }
}
