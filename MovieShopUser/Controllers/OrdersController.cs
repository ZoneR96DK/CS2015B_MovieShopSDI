using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopUser.Controllers
{
    public class OrdersController : Controller
    {
        private MovieShopContext db = new MovieShopContext();
        private IManager<Customer> _cm = DllFacade.GetCustomerManager();
        private IManager<Order> _om = DllFacade.GetOrderManager();
        private IManager<Movie> _mm = DllFacade.GetMovieManager();
        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Movie);
            return View(orders.ToList());
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,MovieId,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", order.CustomerId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", order.MovieId);
            return View(order);
        }

        //TODO: Fix saving orders to db
        // POST: Orders/SubmitOrder
        [HttpPost, ActionName("SubmitOrder")]
        public ActionResult SubmitOrder(Customer customer, int customerId, int movieId, Address address)
        {
            _om.Create(new Order()
            {
                CustomerId = customerId,
                MovieId = movieId,
                Date = DateTime.Now
                
            });
            return RedirectToAction("Index");
            
        }
        //TODO: Fix saving orders to db
        // POST: Orders/CreateCustAndSubmitOrder
        [HttpPost, ActionName("CreateCustAndSubmitOrder")]
        public ActionResult CreateCustAndSubmitOrder(Customer customer, int movieId, Address address)
        {
            _cm.Create(new Customer()
            {
                Address = address,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            });
            Customer orderingCustomer = _cm.Read().FirstOrDefault(x => x.Email == customer.Email);
            _om.Create(new Order()
            {
                CustomerId = orderingCustomer.Id,
                MovieId = movieId,
                Date = DateTime.Now

            });
            return RedirectToAction("Index");
        }

        
    }
}
