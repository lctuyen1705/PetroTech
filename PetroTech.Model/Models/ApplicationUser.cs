using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetroTech.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string UserCode { get; set; }

        [MaxLength(250)]
        public string FullName { get; set; }

        [MaxLength(250)]
        public string City { get; set; }

        [MaxLength(250)]
        public string Area { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        public DateTime? DOB { get; set; }

        public string Status { get; set; }

        public bool IsSystemAccount { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}