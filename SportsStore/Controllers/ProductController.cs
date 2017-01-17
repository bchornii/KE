using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : ApiController
    {
        private IRepository Repository { get; }

        public ProductController()
        {
            Repository = (IRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }
        public IEnumerable<Product> GetProducts()
        {
            return Repository.Products;
        }

        //public Product GetProduct(int id)
        //{
        //    var result = Repository.Products.FirstOrDefault(p => p.Id == id);
        //    if (result == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }
        //    return result;
        //}
        public IHttpActionResult GetProduct(int id)
        {
            var result = Repository.Products.FirstOrDefault(p => p.Id == id);
            return result == null ? (IHttpActionResult)BadRequest("No Product Found") : Ok(result);
        }

        [Authorize(Roles = "Administrators")]
        public async Task PostProduct(Product product)
        {
            await Repository.SaveProductAsync(product);
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);
        }
    }
}
