using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public String TrailerUrl { get; set; }
        public Genre Genre { get; set; }
        public List<Order> Orders { get; set; }
    }
}
