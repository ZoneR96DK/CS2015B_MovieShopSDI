using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using PagedList;

namespace MovieShopUser.Controllers
{
    public class MoviesController : Controller
    {
        private int NUMBER_OF_TABLE_ITEMS_PER_PAGE = 15;
        private IManager<Movie> _mm = DllFacade.GetMovieManager();

        // GET: Movies
        public ActionResult Index(string sortOrder ,string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentSort = searchString;
            IEnumerable<Movie> movies = _mm.Read();
            int pageSize = NUMBER_OF_TABLE_ITEMS_PER_PAGE;
            int pageNumber = (page ?? 1);
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(x => x.Title.ToLower().Contains(searchString.ToLower()));
                return View(movies.ToPagedList(pageNumber, pageSize));
            }
            
;            return View(movies.ToPagedList(pageNumber, pageSize));
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
