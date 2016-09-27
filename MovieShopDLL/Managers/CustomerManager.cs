using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    internal class CustomerManager : IManager<Customer>
    {
        private static CustomerManager _instance;

        public static CustomerManager Instance => _instance ?? (_instance = new CustomerManager());

        private CustomerManager() { }

        public Customer Create(Customer customer)
        {
            using (var db = new MovieShopContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return customer;
            }
        }

        public Customer Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Customer> Read()
        {
            using (var db = new MovieShopContext())
            {
                return db.Customers.ToList();
            }
        }

        public Customer Update(Customer customer)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return customer;
            }
        }

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Customers.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}