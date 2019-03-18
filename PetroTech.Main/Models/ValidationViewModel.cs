using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetroTech.Main.Models
{
    public class ValidationViewModel
    {
        public bool IsPass { get; set; }

        public string Mess { get; set; }

        public List<ErrorViewModel> Errors { get; set; }
    }
}