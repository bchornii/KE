using System.Web.Mvc;
using System.Web.Routing;
using Pro_MVC_18_Filters.App_Start;

namespace Pro_MVC_18_Filters
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
