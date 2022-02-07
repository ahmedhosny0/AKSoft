using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AKSoft
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
<<<<<<< HEAD
                defaults: new { controller = "Product", action = "Home", id = UrlParameter.Optional }
=======
                defaults: new { controller = "Product", action = "Start", id = UrlParameter.Optional }
>>>>>>> 694e4ae47ce3c58ec8d8d1adbd4f14409b0a9950
            );
        }
    }
}
