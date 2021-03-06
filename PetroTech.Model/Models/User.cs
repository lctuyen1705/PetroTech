﻿using PetroTech.Model.Abtracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Model.Models
{
    [Table("Users")]
    public class User : CurrentBase
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(250)]
        public string City { get; set; }

        [MaxLength(250)]
        public string Area { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public bool IsSystemAccount { get; set; }

        public IEnumerable<UserPassword> UserPasswords { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
