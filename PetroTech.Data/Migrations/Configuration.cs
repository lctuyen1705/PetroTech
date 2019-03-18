namespace PetroTech.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PetroTech.Model.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetroTech.Data.PetroTechDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetroTech.Data.PetroTechDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PetroTechDbContext()));

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new PetroTechDbContext()));

            //Create user when application start
            var admin = new ApplicationUser()
            {
                UserCode = "admin",
                UserName = "admin",
                Address = "1 Le Duan Street",
                Status = "A",
                FullName = "Admin",
                DOB = DateTime.Now,
                City = "Ho Chi Minh",
                Area = "HCMC",
                Email = "admin.petrotech@psd.com.vn",
                PhoneNumber = "+84903378241",
                IsSystemAccount = true
            };

            manager.Create(admin, "admin@123");
        }
    }
}