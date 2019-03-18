using PetroTech.Main.Models;
using PetroTech.Main.Models.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Service.Models.map
{
    public class FuncRoleViewModelList
    {
        public string Components { get; set; }

        public string ModuleName { get; set; }

        public IEnumerable<FunctionViewModel> Funcs { get; set; }
    }
}
