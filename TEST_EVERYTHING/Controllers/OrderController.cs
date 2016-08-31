using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_EVERYTHING.DataLayer;
using TEST_EVERYTHING.Models;
using TEST_EVERYTHING.ViewModels;

namespace TEST_EVERYTHING.Controllers
{
    public class OrderController : Controller
    {
        SimpleOrderRepository orderRepo = new SimpleOrderRepository();
        // GET: Order
        public ActionResult Index()
        {
            var orders = orderRepo.GetOrders();
            

            //SET A PERSISTENT COOKIE WHEN VISITED
            //create
            HttpCookie _userInfoCookie = Request.Cookies["UserInfo"];
            int visits = 0;
            if (_userInfoCookie != null)
            {
                if (_userInfoCookie["UserName"].Equals(this.User.Identity.Name.ToString()))
                {
                    visits = Convert.ToInt32(_userInfoCookie["Visited"]);
                    visits++;
                    _userInfoCookie["Visited"] = Convert.ToString(visits);
                    _userInfoCookie.Expires = DateTime.Now.AddDays(5);
                }
                else
                {
                    if (_userInfoCookie["UserName"].Equals(""))
                    {
                        _userInfoCookie["UserName"] = this.User.Identity.Name.ToString();
                    }
                }
            } else 
            {
                _userInfoCookie = new HttpCookie("UserInfo");
                //set content
                _userInfoCookie["UserName"] = this.User.Identity.Name.ToString() ;
                _userInfoCookie["Visited"] = "0";
                _userInfoCookie["Expire"] = "5 Days";
                //add expire time
                _userInfoCookie.Expires = DateTime.Now.AddDays(5);
                //add cookie to response
            }
            Response.Cookies.Add(_userInfoCookie);
            return View(orders);
        }

        //VIEWMODEL ACTIONRESULT!!!
        public ActionResult OrderDetailed(int id)
        {
            OrderLineItemViewModel OlVM = new OrderLineItemViewModel();
            var order = orderRepo.GetOrderWithLineItems(id);
            OlVM.Order = order;
            OlVM.LineItems = order.Orders;
            return View(OlVM);
        }


        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
