using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Service.Models.map
{
    public class FuncRoleServiceModelList
    {
        public string Components { get; set; }

        public string ModuleName { get; set; }

        public List<FunctionServiceModel> Funcs { get; set; }
    }
}
