using System.Web.Mvc;

namespace Pro_MVC_15_UrlRouting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult CustomVariable(string id = "<no value supplied>")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            //ViewBag.CustomVariable = RouteData.Values["id"]; // - the first method to obtain 'id' value
            //ViewBag.CustomVariable = id ?? "<no value>"; // - the second method to obtain 'id' value and handle null
            ViewBag.CustomVariable = id; // - the third method to obtain 'id' and handle null
            return View();
        }
    }
}