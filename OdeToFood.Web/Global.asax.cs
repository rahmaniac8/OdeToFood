using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http; //Needs to be added after creating api controller class

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //application life cycle events for Httpapplication class
        //all these classes are there as a part of your app_Start folder
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            //This line has to be included when we created api folder and added scafolder api2 controller class(RestaurantControlelr.cs)
            //Instruction from readme.txt that got generated on creating api controller. Loc at (C:\Users\Durga Prasad\AppData\Local\Temp\readme.txt)
            //This has to be placed above RouteConfig.
            //The WebApiConfig.Register - register is a static method of class webapi controller that has been added in app_start folder as a file webapicontroller.cs.

            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //register container config and then pres cntl. to generate the method in containerconfig.cs. Method not found Error goes away.
            //following the above registration fashion.

            //ContainerConfig.RegsiterContainer(); //This works when you want to make for home Controller.

            //There are 2 types of controller- Regular mvc Controller(Like HomeController that returns view) and API Controller( that returns xml/Json)
            //The framework behaves differently for API and the above commented code wont work for api. For API we need to do as below
            //in the line  GlobalConfiguration.Configure(WebApiConfig.Register); above we will use the globalConfiguration and use a method it has

            ContainerConfig.RegsiterContainer(GlobalConfiguration.Configuration);
        }
    }
}
