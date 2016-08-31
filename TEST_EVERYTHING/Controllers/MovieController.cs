using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_EVERYTHING.Models;
using TEST_EVERYTHING.Repositories;

namespace TEST_EVERYTHING.Controllers
{
    public class MovieController : Controller
    {
        SimpleMovieRepository smr = new SimpleMovieRepository();
        // GET: Movie
        public ActionResult Index()
        {
            var model = smr.GetAll();
            return View(model);
        }

        // GET: Movie/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var model = smr.FindById(id);
            return View(model);
        }

        // GET: Movie/Create [VIEW IMPLEMENTED]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create [CODE IMPLEMENTED]
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                //Todo insert logic here
                smr.Create(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //ACTION METHOD FOR PARTIAL VIEW
        //ChildActionOnly: kan enkel aangeroepen worden door een subquery, nooit rechtstreeks via een path
        [ChildActionOnly]
        public ActionResult GetFirstMovie()
        {
            var movie = smr.GetFirstMovie();
            return PartialView("_FirstMovie",movie);
        }

    }
}
