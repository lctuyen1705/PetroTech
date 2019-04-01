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
    [Table("Permissions")]
    public class Permission : CurrentBase
    {
        [Required]
        public Guid FunctionId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public bool IsPermisstion { get; set; }

        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }

        [ForeignKey("UserName")]
        public virtual User User { get; set; }
    }
}
