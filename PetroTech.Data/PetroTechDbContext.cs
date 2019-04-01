using Microsoft.AspNet.Identity.EntityFramework;
using PetroTech.Model.Models;
using System.Data.Entity;

namespace PetroTech.Data
{
    public class PetroTechDbContext : DbContext
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
        public DbSet<User> Users { set; get; }

        public static PetroTechDbContext Create()
        {
            return new PetroTechDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Role>().HasKey(i => new { i.RoleId });
            builder.Entity<UserRole>().HasKey(i => new { i.UserName, i.RoleId });
            builder.Entity<Permission>().HasKey(i => new { i.FunctionId, i.UserName });
            builder.Entity<Function>().HasKey(i => new { i.FunctionId });
            builder.Entity<User>().HasKey(i => new { i.UserName });
        }
    }
}