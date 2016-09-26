using System;
using System.Collections.Generic;

namespace MovieShopDLL.Entities
{
    public class Movie : AbstractEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public Genre Genre { get; set; }
        public List<Order> Orders { get; set; }
    }
}