using PetroTech.Service.Models.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetroTech.Main.Models.map
{
    public class FuncRoleViewModel
    {
        public List<FuncRoleViewModelList> FuncModels { get; set; }

        public IEnumerable<RoleViewModel> RoleModels { get; set; }
    }
}