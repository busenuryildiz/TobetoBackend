﻿using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IBadgeOfUserDal : IRepository<BadgeOfUser, int>, IAsyncRepository<BadgeOfUser, int>
    {
    }
}