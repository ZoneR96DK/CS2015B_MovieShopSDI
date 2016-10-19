using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;

namespace MovieShopDLL.Managers
{
    abstract class AbstractManager<T> : IManager<T>
    {
        public T Create(T item)
        {
            using (var db = new MovieShopContext())
            {
                var addedItem = Create(db, item);
                db.SaveChanges();
                return addedItem;
            }
        }

        public abstract T Create(MovieShopContext db, T item);

        public T Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return Read(db, id);
            }
        }

        public abstract T Read(MovieShopContext db, int id);

        public List<T> Read()
        {
            using (var db = new MovieShopContext())
            {
                return Read(db);
            }
        }

        public abstract List<T> Read(MovieShopContext db);

        public T Update(T item)
        {
            using (var db = new MovieShopContext())
            {
                return Update(db, item);
            }
        }

        public abstract T Update(MovieShopContext db, T item);

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                Delete(db, id);
            }
        }

        public abstract void Delete(MovieShopContext db, int id);
    }
}
