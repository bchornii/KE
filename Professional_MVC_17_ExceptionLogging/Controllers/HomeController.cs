using System;
using System.Web.Mvc;

namespace Professional_MVC_17_ExceptionLogging.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            throw new Exception("Hello from exception");
            return View();
        }
    }
}