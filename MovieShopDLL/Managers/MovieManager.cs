using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    class MovieManager : IManager<Movie>
    {
        public Movie Create(Movie t)
        {
            using (var db = new MovieShopContext())
            {
                db.Movies.Add(t);
                db.SaveChanges();
                return t;
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

        public Movie Update(Movie t)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return t;
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
