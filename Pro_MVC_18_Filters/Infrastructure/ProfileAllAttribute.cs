using System.Diagnostics;
using System.Web.Mvc;

namespace Pro_MVC_18_Filters.Infrastructure
{
    public class ProfileAllAttribute : ActionFilterAttribute
    {
        private Stopwatch _timer;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _timer = Stopwatch.StartNew();
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _timer.Stop();
            filterContext.HttpContext.Response.Write(
                $"<div>Total elapsed time: {_timer.Elapsed.TotalSeconds:F6}</div>");
        }
    }
}