﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    internal class OrderManager : AbstractManager<Order>
    {
        private static OrderManager _instance;

        public static OrderManager Instance => _instance ?? (_instance = new OrderManager());

        private OrderManager() { }

        public override Order Create(MovieShopContext db, Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        public override Order Read(MovieShopContext db, int id)
        {
            return db.Orders.FirstOrDefault(x => x.Id == id);
        }

        public override List<Order> Read(MovieShopContext db)
        {
            return db.Orders.ToList();
        }

        public override Order Update(MovieShopContext db, Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return order;
        }

        public override void Delete(MovieShopContext db, int id)
        {
            db.Entry(db.Orders.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}