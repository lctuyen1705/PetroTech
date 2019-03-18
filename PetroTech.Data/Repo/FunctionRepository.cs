using PetroTech.Data.Infa;
using PetroTech.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Data.Repo
{
    public interface IFunctionRepository : IRepository<Function>
    {
    }

    public class FunctionRepository : RepositoryBase<Function>, IFunctionRepository
    {
        public FunctionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
