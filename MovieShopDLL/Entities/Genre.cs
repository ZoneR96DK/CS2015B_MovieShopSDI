using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL.Entities
{
    class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
