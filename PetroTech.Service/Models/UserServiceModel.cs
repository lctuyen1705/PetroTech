using System;
using System.Collections.Generic;

namespace PetroTech.Service.Models
{
    public class UserServiceModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserCode { get; set; }

        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Status { get; set; }

        public bool IsSystemAccount { get; set; }

        public int AccessFailedCount { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTime LockoutEndDateUtc { get; set; }

        public IEnumerable<FunctionServiceModel> Functions { get; set; }
    }
}