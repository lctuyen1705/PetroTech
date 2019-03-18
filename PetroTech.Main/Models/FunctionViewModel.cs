using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetroTech.Main.Models
{
    public class FunctionViewModel
    {
        public Guid FunctionId { get; set; }

        public string FunctionType { get; set; }

        public string FunctionName { get; set; }

        public string ModuleCode { get; set; }

        public string Controller { get; set; }

        public string Status { get; set; }
    }
}