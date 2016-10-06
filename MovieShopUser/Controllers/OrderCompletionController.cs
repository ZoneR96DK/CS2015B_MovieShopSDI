using MovieShopDLL;
using MovieShopDLL.Entities;
using MovieShopUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopUser.Controllers
{
    public class OrderCompletionController : Controller
    {
        private IManager<Order> _mm = DllFacade.GetOrderManager();
        // GET: OrderCompletion
        public ActionResult OrderCompletion()
        {
            return View(OrderCompletionViewModel);
        }
    }
}