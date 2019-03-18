using PetroTech.Data.Infa;
using PetroTech.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Data.Repo
{
    public interface IRoleRepository : IRepository<Role>
    {
    }

    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
