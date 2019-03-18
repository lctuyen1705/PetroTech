using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Service.Models
{
    public class ValidationServiceModel
    {
        public bool IsPass { get; set; }

        public string Mess { get; set; }

        public List<ErrorServiceModel> Errors { get; set; }
    }
}
