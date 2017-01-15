using System;
using System.Web.Mvc;

namespace Pro_MVC_18_Filters.Infrastructure
{
    // Exception filters are run only if an unhandled exception has been thrown when invoking an action method.
    // The exception can come from the following locations:
    // • Another kind of filter(authorization, action, or result filter)
    // • The action method itself
    // • When the action result is executed

    // Notice that I have derived the RangeExceptionAttribute class from
    // the FilterAttribute class, in addition to implementing the IExceptionFilter interface. In order for a.NET attribute
    // class to be treated as an MVC filter, the class has to implement the IMvcFilter interface. You can do this directly, but
    // the easiest way to create a filter is to derive your class from FilterAttribute, which implements the required interface
    // and provides some useful basic features, such as handling the default order in which filters are processed(which I will
    // come to later in this chapter)
    public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            {
                //filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");

                // add more information for user
                var val = (int) ((ArgumentOutOfRangeException) filterContext.Exception).ActualValue;
                filterContext.Result = new ViewResult
                {
                    ViewName = "RangeError",
                    ViewData = new ViewDataDictionary<int>(val)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}