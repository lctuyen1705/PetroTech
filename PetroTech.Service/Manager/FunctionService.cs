using AutoMapper;
using PetroTech.Data.Infa;
using PetroTech.Data.Repo;
using PetroTech.Model.Models;
using PetroTech.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroTech.Service.Manager
{
    public interface IFunctionService
    {
        IEnumerable<FunctionServiceModel> GetListFunction();
        void Save();
    }

    public class FunctionService : IFunctionService
    {
        private IFunctionRepository _functionRepository;
        private IUnitOfWork _unitOfWork;

        public FunctionService(IFunctionRepository functionRepository,
                           IUnitOfWork unitOfWork)
        {
            this._functionRepository = functionRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<FunctionServiceModel> GetListFunction()
        {
            var func = from r in _functionRepository.Table
                       select r;

            return Mapper.Map<IQueryable<Function>, IEnumerable<FunctionServiceModel>>(func);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
