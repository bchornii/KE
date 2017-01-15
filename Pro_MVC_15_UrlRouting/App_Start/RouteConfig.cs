using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using Pro_MVC_15_UrlRouting.Infrastructure;

namespace Pro_MVC_15_UrlRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // --> Routes should be in order from the most specific to the most common

            //// P1
            //// we could go even further and define old schema without any segments
            //// this route is before ShopSchema because it is more specific
            //routes.MapRoute(
            //    name: "ShopSchema2",
            //    url: "Shop/OldAction",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

            //// to keep old schema
            //// e.g. '/Shop/Index' would be controller = 'Home', action = 'Index'
            //routes.MapRoute(
            //    name: "ShopSchema",
            //    url: "Shop/{action}",
            //    defaults: new { controller = "Home"}
            //);

            //// applies to any two-segment URL where the first segment starts from 'X'
            //// the value for controller is taken from first segment excluding 'X'
            //// e.g. '/XHome/Index' would be controller = 'Home', action = 'Index'
            //routes.MapRoute("", "X{controller}/{action}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

            //routes.MapRoute(
            //    name: "public",
            //    url: "Public/{controller}/{action}",
            //    defaults: new { controller = "Home", action = "index"}
            //);

            // P2
            // The first route applies when the user explicitly requests a URL whose first segment is Home and will target the
            // Home controller in the AdditionalControllers folder.All other requests, including those where no first segment is
            // specified, will be handled by controllers in the Controllers folder.
            // Also we can constraint out controllers and actions in route by constrains like regex
            // besides we can constraint HTTP method as well (httpMethod = new HttpMethodConstraint("GET")) (P3)
            //routes.MapRoute(
            //    name: "AddContollerRoute", 
            //    url: "Home/{action}/{id}/{*catchall}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] {"URLsAndRoutes.AdditionalControllers"}
            //);

            //routes.MapRoute(
            //    name: "MyRoute",
            //    url: "{controller}/{action}/{id}/{*catchall}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] {"URLsAndRoutes.Controllers"}
            //);

            // P3
            // Enable attribute routing
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new
                {
                    controller = "^H.*",
                    action = "Index|About",
                    httpMethod = new HttpMethodConstraint("GET", "POST"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[]
                    {
                        new AlphaRouteConstraint(),
                        //new MinLengthRouteConstraint(6) -- will fail for null in 'id',
                        new StringNullOrMinLen(4)
                    })
                },
                namespaces: new[] {"URLsAndRoutes.Controllers"}
            );
        }
    }
}
