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
    [Table("Functions")]
    public class Function : CurrentBase
    {
        [Required]
        public Guid FunctionId { get; set; }

        [Required]
        public string FunctionType { get; set; }

        [Required]
        public string FunctionName { get; set; }

        [Required]
        public string Component { get; set; }

        [Required]
        public string ModuleCode { get; set; }

        [Required]
        public string ModuleName { get; set; }

        [Required]
        public string Controller { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual IEnumerable<Permission> Permissions { get; set; }

    }
}
