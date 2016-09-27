using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    internal class AddressManager : IManager<Address>
    {
        private static AddressManager _instance;

        public static AddressManager Instance => _instance ?? (_instance = new AddressManager());

        private AddressManager() { }

        public Address Create(Address address)
        {
            using (var db = new MovieShopContext())
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return address;
            }
        }

        public Address Read(int id)
        {
            using (var db = new MovieShopContext())
            {
                return db.Addresses.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Address> Read()
        {
            using (var db = new MovieShopContext())
            {
                return db.Addresses.ToList();
            }
        }

        public Address Update(Address address)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return address;
            }
        }

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Addresses.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}