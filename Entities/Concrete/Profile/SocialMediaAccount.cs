﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete.Client;

namespace Entities.Concrete
{
    public class SocialMediaAccount : Entity<int>
    {
        public int UserId { get; set; }
        public string SocialMedia { get; set; }
        public string SocialMediaUrl { get; set; }
        public User User { get; set; }

    }
}