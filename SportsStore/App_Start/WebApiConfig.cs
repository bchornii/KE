using System.Web.Http;
using SportsStore.Infrastructure;

namespace SportsStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "OrdersRoute",
                routeTemplate: "nonrest/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // remove XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // custom DI resolver
            config.DependencyResolver = new CustomResolver();

            // ignore circular references 
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
