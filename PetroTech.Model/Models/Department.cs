using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetroTech.Model.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public string DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
