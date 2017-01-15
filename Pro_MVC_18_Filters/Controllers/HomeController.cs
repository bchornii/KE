using System;
using System.Diagnostics;
using System.Web.Mvc;
using Pro_MVC_18_Filters.Infrastructure;

namespace Pro_MVC_18_Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch _timer;

        //[CustomAuth(true)]
        [Authorize(Users = "admin")]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [GoogleAuth]
        [Authorize(Users = "bob@google.com")]
        public string List()
        {
            return "This is the List action on the Home controller";
        }

        //[RangeException]
        // The 'HandleError' filter will work only if web.config has customErrors="On"/"RemoteOnly"
        //[HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return $"The id value is: {id}";
            }
            throw new ArgumentOutOfRangeException(nameof(id), id, "");
        }

        //[CustomAction]
        //[ProfileAction]
        //[ProfileResult]
        //[ProfileAll]
        public string FilterTest()
        {
            //throw new ArgumentOutOfRangeException();
            return "This is the FilterTest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _timer = Stopwatch.StartNew();
        }
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _timer.Stop();
            filterContext.HttpContext.Response.Write(
                $"<div>Total elapsed time: {_timer.Elapsed.TotalSeconds}</div>");
        }
    }
}