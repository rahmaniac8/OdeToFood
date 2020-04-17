
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        //public string Get()
        //{
        //    return "Hello";
        //}

        //The above works fine when u go to /api/Restaurants. But if i want to show the list of restaurants, 
        //Change similar to Home controller. The above change alone wont work. Page shows error "Error while creating Restaurant controller.
        //Make sure the controller has parameterless constructor". So we need to make the change in global.asax.cs and also in Cotainerconfig.cs
        //in order to accomodate the change.

        IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        //web api uses http methods : get, put ,post, delete
        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }

     
    }
}
