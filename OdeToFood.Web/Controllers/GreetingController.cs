using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting. Using Query String in parameter
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            //var name = HttpContext.Request.QueryString["name"];   
            
            //the two question marks (??) indicate that its a Coalescing operator. Coalescing operator returns the first NON-NULL value from a chain.
            //Name or no name here.

            model.Name = name ?? "No name"; 
            model.Message = ConfigurationManager.AppSettings["message"]; //included this "message" key in web.config to get custom message

            return View(model);
        }


    }
}