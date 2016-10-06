using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopUser.Models
{
    public class MovieViewModel
    {
        public List<Movie> RandomMovies { get; set; }
        public PagedList.IPagedList<Movie> MoviesForTable { get; set; }
    }
}