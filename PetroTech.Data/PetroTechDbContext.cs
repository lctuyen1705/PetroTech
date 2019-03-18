using Microsoft.AspNet.Identity.EntityFramework;
using PetroTech.Model.Models;
using System.Data.Entity;

namespace PetroTech.Data
{
    public class PetroTechDbContext : IdentityDbContext<ApplicationUser>
    {
        public PetroTechDbContext() : base("PetroConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Log> Logs { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<UserRole> UserRoles { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<Function> Functions { set; get; }

        public static PetroTechDbContext Create()
        {
            return new PetroTechDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUser>().HasKey(i => new { i.Id });
            builder.Entity<IdentityRole>().HasKey(i => new { i.Id });
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);

            builder.Entity<Role>().HasKey(i => new { i.RoleId });
            builder.Entity<UserRole>().HasKey(i => new { i.UserName, i.RoleId });
            builder.Entity<Permission>().HasKey(i => new { i.FunctionId, i.RoleId });
            builder.Entity<Function>().HasKey(i => new { i.FunctionId });
        }
    }
}