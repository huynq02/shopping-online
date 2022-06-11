using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace shopping_online
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );
            
            //routes.MapRoute(
            //    name: "Default", //Route Name
            //    url: "{controller}/{action}/{id}", //Route Pattern
            //    defaults: new
            //    {
            //        controller = "Home", //Controller Name
            //        action = "Index", //Action method Name
            //        id = UrlParameter.Optional //Defaut value for above defined parameter
            //    });
        }
    }
}
