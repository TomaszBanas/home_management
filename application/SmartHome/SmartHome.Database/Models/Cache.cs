﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public class Cache : BaseModel
    {
        public string Value { get; set; }
    }
}
