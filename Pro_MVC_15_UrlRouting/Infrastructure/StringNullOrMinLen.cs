using System.Web;
using System.Web.Routing;

namespace Pro_MVC_15_UrlRouting.Infrastructure
{
    public class StringNullOrMinLen : IRouteConstraint
    {
        private readonly int _minLen;

        public StringNullOrMinLen(int minLen)
        {
            _minLen = minLen;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            object idValue;
            if (!values.TryGetValue("id", out idValue))
            {
                return false;
            }
            return string.IsNullOrEmpty(idValue?.ToString()) || idValue.ToString().Length >= _minLen;           
        }
    }
}