using System;
using System.Collections.Generic;

namespace MovieShopDLL.Entities
{
    public class Order : AbstractEntity
    {
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; }
        public DateTime Date { get; set; }
    }
}