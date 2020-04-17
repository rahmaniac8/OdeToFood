using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OdeToFood.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                // localhost:4040/api/restaurants/
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }


                //After adding api controlelr class if you just execute with api/restaurants then there is an 
                //error on browser in xml format that says there is no action() found, 
            );
        }
    }
}
