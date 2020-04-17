using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController_old : Controller
    {
        // GET: Restaurants

        IRestaurantData Db;
        public RestaurantsController_old(IRestaurantData db)
        {
            this.Db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = Db.GetAll();

            return View(model); //Create a scaffolding list tempalte view and edit to show all restaurants
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = Db.Get(id);
            if (model == null)
            {
                return View("NotFound"); //Add a view called NotFound and create one 
            }
            return View(model); //Create a scaffolding detail tempalte view and edit
        }

        //This create() below is not actually creating a restaurant. It is responding to a Http GET request and a GET request will never
        //or should never perform write operation on my server. So what this is doing is responding to a request to get a form that will
        //allow a user to create a restaurant. I'm not creating but giving you a html that you need to create a restaurant. That's the way to see it.
        //so when the user clicks on create button to save into db, it is a different action that we have to create that will recieve the 
        //details and validate it and save in db.

        [HttpGet] // This is the action where I want to get the resource that will allow me edit/create a restaurant. So httpget
        public ActionResult Create()
        {
            return View(); //Create a scaffolding create template view and modify
        }

        //Now, anytime you are implementing a feature/scenario where the user needs to edit data, we typically have a pair of functions
        //that are required to implement that feature. So we have 2 controllEr actions.First controller action will be the one which gives
        //the user the form that they fill to edit/create. The second controller action is the one that recieves the innformation that the user has filled out.
        //So one action simply returns a view which contains the form that user can type into and the second one is where that recieves the information back from the user.

        [HttpPost] // I'm posting/writing the details to save to db. The httppost is required to differnetiate b/w 2 create methods. But no harm to use both.

        [ValidateAntiForgeryToken] //has to be there for post actions
        public ActionResult Create(Restaurant restaurant)
        {

            //The below code does the job but this can be done using data annotations. [Required] in model class
            //if(string.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name),"Restaurant Name is required");
            //}

            //Learn model binding. applicable here.
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
                return View("NotFound");
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
               return RedirectToAction("Details", new { id=restaurant.Id});
            }

            return View(restaurant); //different from create. returns reataurant.
        }
    }
}