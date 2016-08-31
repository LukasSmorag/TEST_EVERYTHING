using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST_EVERYTHING.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Contact()
        {
            ViewBag.Address = "Streety Mc Streetstreet 10";
            ViewBag.City = "1111 CityVille";
            return View();
        }
    }
}