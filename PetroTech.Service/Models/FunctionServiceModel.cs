using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Service.Models
{
    public class FunctionServiceModel
    {
        public Guid FunctionId { get; set; }

        public string FunctionType { get; set; }

        public string FunctionName { get; set; }

        public string ModuleCode { get; set; }

        public string Controller { get; set; }

        public string Status { get; set; }
    }
}
