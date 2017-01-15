using System.Diagnostics;
using System.Web.Mvc;

namespace Pro_MVC_18_Filters.Infrastructure
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch _timer;
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _timer = Stopwatch.StartNew();
        }
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _timer.Stop();
            filterContext.HttpContext.Response.Write(
                $"<div>Result elapsed time: {_timer.Elapsed.TotalSeconds:F6}</div>");
        }
    }
}