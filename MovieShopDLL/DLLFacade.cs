using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;
using MovieShopDLL.Managers;

namespace MovieShopDLL
{
    public class DLLFacade
    {
        public IManager<Genre> GetGenreManager()
        {
            return new GenreManager();
        }

        public IManager<Movie> GetMovieManager()
        {
            return new MovieManager();
        }
    }
}
