﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.County
{
    public class CreateCountyRequest
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
