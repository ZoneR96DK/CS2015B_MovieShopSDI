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
        private IManager<Order> _om = DllFacade.GetOrderManager();
        private IManager<Movie> _mm = DllFacade.GetMovieManager();
        private IManager<Customer> _cm = DllFacade.GetCustomerManager();
        // GET: Orders
        public ActionResult Index()
        {
            return View(_om.Read());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _om.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                _om.Create(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _om.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                _om.Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _om.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _om.Delete(id);
            return RedirectToAction("Index");
        }
        //TODO: Fix saving orders to db
        // POST: Orders/SubmitOrder
        [HttpPost, ActionName("SubmitOrder")]
        public ActionResult SubmitOrder(Customer customer, int? Id, Address address)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _mm.Read(Id.Value);
            Order order = new Order();
            order.Customer = customer;
            order.Customer.Address = address;
            order.Date = DateTime.Now;
            if (order.Movies == null)
            {
                order.Movies = new List<Movie>();
                order.Movies.Add(movie);
            }
            else
            {
                order.Movies.Add(movie);
            }
            _om.Create(order);
            return RedirectToAction("Index");
            
        }
        //TODO: Fix saving orders to db
        // POST: Orders/CreateCustAndSubmitOrder
        [HttpPost, ActionName("CreateCustAndSubmitOrder")]
        public ActionResult CreateCustAndSubmitOrder(Customer customer, int? id, Address address)
        {
            _cm.Create(new Customer()
            {
                Address = address,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            });
            return RedirectToAction("Index");
        }
    }
}
