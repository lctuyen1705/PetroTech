using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetroTech.Main.Models
{
    public class RoleViewModel
    {
        public string RoleId { get; set; }

        public string RoleCode { get; set; }

        public string RoleName { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }
    }
}