﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
