using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SportsStore.Infrastructure.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<StoreUser>
    {
        public StoreIdentityDbContext() : base("SportsStoreIdentityDb")
        {
            Database.SetInitializer(new StoreIdentityDbInitializer());
        }
        public static StoreIdentityDbContext Create()
        {
            return new StoreIdentityDbContext();
        }
    }
}