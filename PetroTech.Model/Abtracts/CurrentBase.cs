using System;
using System.ComponentModel.DataAnnotations;

namespace PetroTech.Model.Abtracts
{
    public class CurrentBase
    {
        public DateTime? CreateDateTime { get; set; }

        [MaxLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdatedDateTime { get; set; }

        [MaxLength(250)]
        public string LastUpdatedBy { get; set; }
    }
}