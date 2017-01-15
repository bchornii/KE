using System.Web.Mvc;
using System.Web.Routing;

namespace Pro_MVC_23_AjaxUrlHelpers
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
