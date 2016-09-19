using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL
{
    public interface IManager<T>
    {
        T Create(T t);
        T Read(int id);
        List<T> Read();
        T Update(T t);
        void Delete(int id);
    }
}
