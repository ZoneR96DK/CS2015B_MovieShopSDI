﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL.Entities
{
    public class Genre : AbstractEntity
    {
        
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
