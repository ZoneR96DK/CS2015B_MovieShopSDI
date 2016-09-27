using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    class GenreManager : IManager<Genre>
    {
        private static GenreManager _instance;

        public static GenreManager Instance => _instance ?? (_instance = new GenreManager());

        private GenreManager() { }

        public Genre Create(Genre genre)
        {
            using (var db = new MovieShopContext())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return genre;
            }
        }

        public Genre Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Genre> Read()
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.ToList();
            }
        }

        public Genre Update(Genre genre)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return genre;
            }
        }

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Genres.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
