using PetroTech.Data.Infa;
using PetroTech.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Data.Repo
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
    }

    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
