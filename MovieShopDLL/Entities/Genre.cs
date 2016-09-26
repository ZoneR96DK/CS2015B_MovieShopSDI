﻿using System.Collections.Generic;

namespace MovieShopDLL.Entities
{
    public class Genre : AbstractEntity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}