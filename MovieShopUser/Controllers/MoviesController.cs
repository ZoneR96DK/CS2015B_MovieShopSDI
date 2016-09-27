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
    public class MoviesController : Controller
    {
        private IManager<Movie> _mm = DllFacade.GetMovieManager();

        // GET: Movies
        public ActionResult Index()
        {
            return View(_mm.Read());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
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
            return View(movie);
        }
    }
}
