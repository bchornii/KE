using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace Pro_MVC_18_Filters.Infrastructure
{
    // This filter works together with GoogleAccount controller
    // and defines authentication logic for particular controller actions
    // in the same time when whole application is using form authentication and
    // credentials are defined in Web.Config file (<authentication/> element)
    public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;
            if (!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        // This method is used to challenge the user for credentials by redirecting their
        // browser to GoogleAccount controller (controller convenience methods for creating
        // action result is not accessible, so we should use RouteValueDictionary)
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // the null check is for handling final challenge request
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    ["controller"] = "GoogleAccount",
                    ["action"] = "Login",
                    ["returnUrl"] = filterContext.HttpContext.Request.RawUrl
                });
            }
            else
            {
                // this is usefull when you need to sign in every time you request the action
                FormsAuthentication.SignOut();  
            }

        }
    }
}