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
            routes.MapRoute(
               name: "Ship",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "shipping", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Orderss",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Order_Status",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Order_status", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
