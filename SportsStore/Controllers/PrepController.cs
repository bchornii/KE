using System.Threading.Tasks;
using System.Web.Mvc;
using SportsStore.Models;

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
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _repo.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
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
    }
}