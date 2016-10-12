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
using MovieShopUser.Models;

namespace MovieShopUser.Controllers
{
    public class CustomersController : Controller
    {
        string isEmailValid;
        private IManager<Customer> _cm = DllFacade.GetCustomerManager();
        private IManager<Address> _am = DllFacade.GetAddressManager();
        private IManager<Movie> _mm = DllFacade.GetMovieManager();
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
        public ActionResult CheckEmail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _mm.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            if (TempData["Redirected"] != null)
            {
                isEmailValid = "Submit valid email.";
                ViewBag.Message = isEmailValid;
                return View(movie);
            }
            isEmailValid = "";
            ViewBag.Message = isEmailValid;
            return View(movie);
        }


        public bool IsValidEmail(string email)
        {
            try
            {
                new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult CheckEmail(string email, int movieId)
        {
            if (ModelState.IsValid && IsValidEmail(email)) { 
                
                
                var customers = _cm.Read();
                var customerFound = customers.FirstOrDefault(x => x.Email == email);
                Movie movie = _mm.Read(movieId);
                var orderCheckoutView = new OrderCheckoutView()
                {
                    Customer = customerFound,
                    Movie = movie,
                    Email = email
                };
                TempData["orderCheckoutView"] = orderCheckoutView;
                return RedirectToAction("ConfirmCustomerDetails"); //new customer view
                
            }
            //Movie m = _mm.Read(movieId);
            TempData["Redirected"] = true;
            return RedirectToAction("CheckEmail", new {Id = movieId});

        }

        [HttpGet]
        public ActionResult ConfirmCustomerDetails()
        {
                OrderCheckoutView orderCheckoutView = (OrderCheckoutView)TempData["orderCheckoutView"];
                return View(orderCheckoutView); //new customer view
            

        }
    }
}
