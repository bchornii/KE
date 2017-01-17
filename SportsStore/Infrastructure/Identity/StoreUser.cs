using Microsoft.AspNet.Identity.EntityFramework;

namespace SportsStore.Infrastructure.Identity
{
    public class StoreUser : IdentityUser
    {
        public string CustomerIdentityUserPropety { get; set; }
    }
}