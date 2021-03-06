﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Pro_MVC_25_ModelValidation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "MakeBooking", id = UrlParameter.Optional }
            );
        }
    }
}
