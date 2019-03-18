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
    public interface IRoleService
    {
        IEnumerable<RoleServiceModel> GetListRoles();
        void Save();
    }

    class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository,
                           IUnitOfWork unitOfWork)
        {
            this._roleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<RoleServiceModel> GetListRoles()
        {
            var role = from r in _roleRepository.Table
                       select r;

            return Mapper.Map<IQueryable<Role>, IEnumerable<RoleServiceModel>>(role);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
