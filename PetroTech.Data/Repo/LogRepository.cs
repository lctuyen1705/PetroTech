using PetroTech.Data.Infa;
using PetroTech.Model.Models;

namespace PetroTech.Data.Repo
{
    public interface ILogRepository : IRepository<Log>
    {
    }

    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}