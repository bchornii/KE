using System.Threading.Tasks;
using System.Web.Mvc;
using SportsStore.Models;
using SportsStore.Infrastructure.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Security.Claims;

namespace SportsStore.Controllers
{
    public class PrepController : Controller
    {
        readonly IRepository _repo;
        public PrepController()
        {
            _repo = new ProductRepository();
        }
        public ActionResult Index()
        {
            return View(_repo.Products);
        }

        [Authorize(Roles = "Administrators")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _repo.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrators")]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            await _repo.SaveProductAsync(product);
            return RedirectToAction("Index");
        }

        public ActionResult Orders()
        {
            return View(_repo.Orders);
        }
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _repo.DeleteOrderAsync(id);
            return RedirectToAction("Orders");
        }
        public async Task<ActionResult> SaveOrder(Order order)
        {
            await _repo.SaveOrderAsync(order);
            return RedirectToAction("Orders");
        }

        public async Task<ActionResult> SignIn()
        {
            IAuthenticationManager authMng = HttpContext.GetOwinContext().Authentication;
            StoreUserManager userMng = HttpContext.GetOwinContext().GetUserManager<StoreUserManager>();
            StoreUser user = await userMng.FindAsync("Admin", "secret");
            authMng.SignIn(await userMng.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie));
            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}