using System.Web;
using System.Web.Mvc;

namespace Pro_MVC_18_Filters.Infrastructure
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private readonly bool _localAllowed;

        public CustomAuthAttribute(bool localAllowed)
        {
            _localAllowed = localAllowed;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) =>
            !httpContext.Request.IsLocal || _localAllowed;
    }
}