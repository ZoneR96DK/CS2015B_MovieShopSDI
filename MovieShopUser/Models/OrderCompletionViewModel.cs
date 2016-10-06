using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopUser.Models
{
    public class OrderCompletionViewModel
    {
        public IEnumerable<Customer> Email { get; set; }
        public IEnumerable<Order> OrderCompletionForm { get; set; }
    }
}