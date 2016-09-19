using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Content;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    class GenreManager : IManager<Genre>
    {
        public Genre Create(Genre t)
        {
            using (var db = new MovieShopContext())
            {
                db.Genres.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public Genre Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.FirstOrDefault(x => x.GenreId == id);
            }
        }

        public List<Genre> Read()
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.ToList();
            }
        }

        public Genre Update(Genre t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
