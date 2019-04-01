using System;
using System.Collections.Generic;

namespace PetroTech.Main.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string Department { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Status { get; set; }

        public IEnumerable<FunctionViewModel> Functions { get; set; }
    }
}