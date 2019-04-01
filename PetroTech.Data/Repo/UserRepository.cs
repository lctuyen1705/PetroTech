using PetroTech.Data.Infa;
using PetroTech.Model.Models;

namespace PetroTech.Data.Repo
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}