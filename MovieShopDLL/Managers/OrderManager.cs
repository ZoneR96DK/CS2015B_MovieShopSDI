using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    internal class OrderManager : IManager<Order>
    {
        private static OrderManager _instance;

        public static OrderManager Instance => _instance ?? (_instance = new OrderManager());

        private OrderManager() { }

        public Order Create(Order order)
        {
            using (var db = new MovieShopContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
        }

        public Order Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Orders.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Order> Read()
        {
            using (var db = new MovieShopContext())
            {
                return db.Orders.ToList();
            }
        }

        public Order Update(Order order)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return order;
            }
        }

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Orders.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}