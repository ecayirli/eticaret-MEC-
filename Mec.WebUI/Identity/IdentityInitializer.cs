using Mec.WebUI.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mec.WebUI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roles
            if (!context.Roles.Any(x=>x.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() {Name="admin",Description="admin rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(x => x.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }
                if (!context.Users.Any(x => x.Name =="mecayirli"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() {Name="Melik",Surname="Cayirli",UserName="mecayirli",Email="ecayirli@gmail.com" };
                manager.Create(user,"123456");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id,"user");

            }
            if (!context.Users.Any(x => x.Name =="ecayirli"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Eralp", Surname = "Cayirli",UserName="ecayirli", Email = "ecayirli26@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id,"user");

            }
            base.Seed(context);
        }
    }
}