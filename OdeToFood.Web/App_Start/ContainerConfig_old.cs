using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

//namespace doesn't include till folder structure of appstart in bundle/filter.config etc. 
//So follow same for Container config and remove the appstart
//namespace OdeToFood.Web.App_Start  is changed to as below

namespace OdeToFood.Web

{
    public class ContainerConfig_old
    {
        //Invoke method from global.asax. First register the containerconfig and then Press cntrl+period. That will generate method here without parameter.
        //internal static void RegsiterContainer() this we used for Home controller. But for web api we used a parameter in global.asax.cs. So make the needed change here
        internal static void RegsiterContainer(HttpConfiguration httpConfiguration)
        {
            //create a containerbuilder using autofac api. Add name space using control+period using autofac

            var builder = new ContainerBuilder();

            //register my controller. call RegisterControllers and include namepsace . using autofac.integration.mvc
            //MvcApplication is in global.asax it is the assembly type of ode.tofood.web. so want to use the same here. 
            //We have to register the controller which is for regualr mvc controller(like home/admin controller etc)

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Copy paste the above line and do the same for api by including the api keyword. Because we need to register the Api controller.
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            //use the resgitertype() and use singleton instance

            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance(); 
            //all restaurant data in single instance. so using singleinstance. 
            //not going to wotk for multiple users as they might modify data same time

            //create container. give this to mvc5 framwork and tell when ever you have dependecies pls use this container.
            var container = builder.Build();

            //setting the contaienr as a dependecny resolver throught the mvc5 app. 
            //Now build and run to resolve the default parameter error.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //Now build and run localhost:8686/api/restaurants. This gives a xml output of restaurants. You can get Json output also for this.
            //This is shown using cmd prompt. Type comands as below

            //curl
            //curl https://localhost:44301/api/restaurants/
            // curl https://localhost:44301/api/restaurants/ -H "Accept:appliation/json" and if you want xml
            // curl https://localhost:44301/api/restaurants/ -H "Accept: application/xml" to get xml output


        }
    }
}