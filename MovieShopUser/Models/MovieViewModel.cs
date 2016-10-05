using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopUser.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Movie> RandomMovies { get; set; }
        public IEnumerable<Movie> MoviesForTable { get; set; }
    }
}