using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopUser.Models
{
    public class OrderCheckoutView
    {
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        
    }
}