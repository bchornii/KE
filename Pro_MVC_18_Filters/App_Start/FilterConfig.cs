using System.Web.Mvc;

namespace Pro_MVC_18_Filters.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // The 'HandleError' filter will work only if web.config has customErrors="On"/"RemoteOnly"
            filters.Add(new HandleErrorAttribute()); // apply global HandleError attribute
        }
    }
}