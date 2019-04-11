using PetroTech.Model.Abtracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetroTech.Model.Models
{
    [Table("Roles")]
    public class Role : CurrentBase
    {
        [Key]
        public Guid RoleId { get; set; }

        [Required]
        public string RoleCode { get; set; }

        [Required]
        public string RoleName { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
