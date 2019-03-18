using PetroTech.Data.Infa;
using PetroTech.Model.Models;

namespace PetroTech.Data.Repo
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
    }

    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}