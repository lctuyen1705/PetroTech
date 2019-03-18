using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetroTech.Model.Models
{
    [Table("Areas")]
    public class Area
    {
        [Key]
        public string AreaId { get; set; }

        [Required]
        public string AreaName { get; set; }
    }
}
