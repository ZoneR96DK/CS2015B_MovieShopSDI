using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    class MovieManager : IManager<Movie>
    {
        private static MovieManager _instance;

        public static MovieManager Instance => _instance ?? (_instance = new MovieManager());

        private MovieManager() {}

        public Movie Create(Movie movie)
        {
            using (var db = new MovieShopContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return movie;
            }
        }

        public Movie Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Movies.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Movie> Read()
        {
            using (var db = new MovieShopContext())
            {
                return db.Movies.ToList();
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return movie;
            }
        }

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Movies.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
