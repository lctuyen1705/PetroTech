using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetroTech.Model.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
