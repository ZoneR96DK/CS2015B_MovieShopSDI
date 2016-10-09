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
    public class CustomersController : Controller
    {
        private IManager<Customer> _cm = DllFacade.GetCustomerManager();
        private IManager<Address> _am = DllFacade.GetAddressManager();
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _cm.Read();
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_am.Read(), "Id", "StreetName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _cm.Create(customer);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_am.Read(), "Id", "StreetName", customer.Id);
            return View(customer);
        }


        // GET: VerifyEmail
        public ActionResult CheckEmail()
        {
            return View();
        }

        // GET: Customers/VerifyEmail
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult ConfirmCustomerDetails(string email)
        {
            
                var customers = _cm.Read();
                var customerFound = customers.FirstOrDefault(x => x.Email == email);
                if (customerFound != null)
                {

                    return View(customerFound); //view with prefilled data of customer "customerFound";
                }
                    return RedirectToAction("Index"); //new customer view
            
        }
    }
}
