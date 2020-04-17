using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        // GET: Restaurants

        IRestaurantData Db;
        public RestaurantsController(IRestaurantData db)
        {
            this.Db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = Db.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = Db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                Db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                Db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = Db.Get(id);
            if(model==null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        //this is used and not httpdelete cuz end point is browser. If we are using api then Httpdelete is used
        //Formcollecton is used to differentiate 2  delete methods. Formcollection will encapsulate the name value pair that the browser is posting in a form

        [HttpPost] 
        [ValidateAntiForgeryToken]
        
        public ActionResult Delete(int id, FormCollection form)
        {
            Db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}