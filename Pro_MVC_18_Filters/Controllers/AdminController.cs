using System.Web.Mvc;
using System.Web.Security;

namespace Pro_MVC_18_Filters.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public void Index()
        {
            if (!Request.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            // ...rest of action method
        }
        public void Create()
        {
            if (!Request.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            // ...rest of action method
        }

        public void Edit(int productId)
        {
            if (!Request.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            // ...rest of action method
        }
    }
}