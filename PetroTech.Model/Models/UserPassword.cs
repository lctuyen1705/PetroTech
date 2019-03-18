using PetroTech.Model.Abtracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Model.Models
{
    [Table("UserPasswords")]
    public class UserPassword : CurrentBase
    {
        [Key]
        public Guid UserPasswordId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
