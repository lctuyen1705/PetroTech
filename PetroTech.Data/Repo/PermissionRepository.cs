using PetroTech.Data.Infa;
using PetroTech.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Data.Repo
{
    public interface IPermissionRepository : IRepository<Permission>
    {
    }

    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
