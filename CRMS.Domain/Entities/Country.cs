﻿using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class Country : BaseEntity
    {
        //One to many relationship with City
        public List<City>? Cities { get; set; }
    }
}