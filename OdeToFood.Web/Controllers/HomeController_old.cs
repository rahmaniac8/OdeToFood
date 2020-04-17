using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers //use namespace that maps tp physcial folder structure
{
    public class HomeController_old : Controller
    {
        //IRestaurantData db;
        //public HomeController()
        //{
        //    db = new InMemoryRestaurantData(); //Concrete type
        //}

        //Dependency Injection

        //IRestaurantData db;
        //public HomeController(IRestaurantData db)
        //{
        //    this.db = db;

        //}

        // The above code change alone would throw an error saying "No parameterless constructor defined for this object." This is where we need IOC.
        //Inversion of control (IOC) container : If we tell IOC container to instantiate home controller and we can figure the IOC containers
        //  when something needs irestauranat data, we need IOC. To resolve the above error 
        //We need to have 3rd party componenet : Ninajct or structuremap or automap. Download the package Autofac.mvc5. Add appstart\containerconfig.cs file
        //Make changes in the global.asax.cs and also containerconfig.cs


        IRestaurantData db;
        public HomeController_old(IRestaurantData db)
        {
            this.db = db;

        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}