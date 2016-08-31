using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_EVERYTHING.DataLayer;
using TEST_EVERYTHING.Models;

namespace TEST_EVERYTHING.Controllers
{
    public class CartController : Controller
    {
        private MovieContext context;

        public CartController()
        {
            context = new MovieContext();
        }


        //SHOPPING BASKET SESSION HANDLING
        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(context.Movies.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                if (!IsExisting(id))
                    cart.Add(new Item(context.Movies.Find(id), 1));
                Session["cart"] = cart;
            }

            return View();
        }

        private bool IsExisting(int id)
        {
            foreach (var item in (List<Item>)Session["cart"])
            {
                if (item.Movie.Id == id)
                {
                    item.Quantity += 1;
                    return true;
                }
            }
            return false;
        }


        // GET: Cart
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                Session["cart"] = cart;
            }

            return View();
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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
    }
}
