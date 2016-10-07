using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopAdmin.Models
{
    public class EditMovieModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
    }
}