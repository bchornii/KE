using System.Web.Mvc;

namespace Pro_MVC_15_UrlRouting.Controllers
{
    public class CustomerController : Controller
    {
        [Route("Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        // Without :int constraint we will get an error because two
        // of controller methods have the same number of segment variables
        [Route("Users/Add/{user}/{id:int}")]   
        public string Create(string user, int id) => $"User: {user}, ID: {id}";

        [Route("Users/Add/{user}/{password}")]
        public string ChangePass(string user, string password) => 
            $"ChangePass Method - User: {user}, Pass: {password}";

        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }
    }
}