using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GalacticPuffin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("privacy", "privacy",
            new { controller = "home", action = "privacy", id = UrlParameter.Optional });

            routes.MapRoute("contact", "contact",
           new { controller = "home", action = "contact", id = UrlParameter.Optional });

            routes.MapRoute("service", "service",
            new { controller = "home", action = "service", id = UrlParameter.Optional });

            routes.MapRoute("app", "app",
            new { controller = "home", action = "app", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "home",
               url: "{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
