using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Service.Models.map
{
    public class FuncRoleServiceModel
    {
        public List<FuncRoleServiceModelList> FuncModels { get; set; }

        public IEnumerable<RoleServiceModel> RoleModels { get; set; }
    }
}
