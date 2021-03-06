﻿using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SportsStore.Infrastructure.Identity
{
    public class StoreIdentityDbInitializer : CreateDatabaseIfNotExists<StoreIdentityDbContext>
    {
        protected override void Seed(StoreIdentityDbContext context)
        {
            var userMgr = new StoreUserManager(new UserStore<StoreUser>(context));
            var roleMgr = new StoreRoleManager(new RoleStore<StoreRole>(context));
            const string roleName = "Administrators";
            const string userName = "Admin";
            const string password = "secret";
            const string email = "admin@example.com";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new StoreRole(roleName));
            }
            StoreUser user = userMgr.FindByName(userName);

            if (user == null)
            {
                userMgr.Create(new StoreUser
                {
                    UserName = userName,
                    Email = email
                }, password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
            base.Seed(context);
        }
    }
}