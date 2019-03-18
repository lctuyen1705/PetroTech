using PetroTech.Data.Infa;
using PetroTech.Data.Repo;
using PetroTech.Model.Models;
using PetroTech.Service.Infa;
using System;
using System.Linq;
using PetroTech.Common.Resource;
using System.Collections;
using System.Collections.Generic;
using PetroTech.Service.Models;
using AutoMapper;
using PetroTech.Service.Models.map;

namespace PetroTech.Service.Manager.inter
{
    public interface IInternalService
    {
        FuncRoleServiceModel GetFuncRole();
        void Save();
    }
    public class InternalService : IInternalService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IFunctionRepository _functionRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUnitOfWork _unitOfWork;

        public InternalService(IUserRepository userRepository,
                               IRoleRepository roleRepository,
                               IFunctionRepository functionRepository,
                               IUserRoleRepository userRoleRepository,
                               IUnitOfWork unitOfWork)
        {
            this._functionRepository = functionRepository;
            this._userRoleRepository = userRoleRepository;
            this._roleRepository = roleRepository;
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public FuncRoleServiceModel GetFuncRole()
        {
            var model = new FuncRoleServiceModel();

            var funcsList = new List<FuncRoleServiceModelList>();

            var funcs = new FuncRoleServiceModelList();

            var temp = string.Empty;

            var funcMaster = from func in _functionRepository.Table
                             orderby func.Component
                             select func;

            var roleMaster = from role in _roleRepository.Table
                             select role;

            var componentTotal = funcMaster.GroupBy(x => x.Component).Select(x => new
            {
                Component = x.Key,
                ComponentCount = x.Count()
            });

            foreach (var item in funcMaster)
            {
                var fun = new FunctionServiceModel();

                funcs.Components = item.Component;
                funcs.ModuleName = item.ModuleName;
                bool flagComponent = item.Component == temp ? true : false;
                bool flagComponentTotal = false;

                if (flagComponent)
                {
                    fun.Controller = item.Controller;
                    fun.FunctionId = item.FunctionId;
                    fun.FunctionName = item.FunctionName;
                    fun.FunctionType = item.FunctionType;
                    fun.Status = item.Status;
                    fun.ModuleCode = item.ModuleCode;

                    funcs.Funcs.Add(fun);
                }
                else
                {
                    funcs = new FuncRoleServiceModelList();
                    funcs.Funcs = new List<FunctionServiceModel>();

                    funcs.Components = item.Component;
                    funcs.ModuleName = item.ModuleName;
                    fun.Controller = item.Controller;
                    fun.FunctionId = item.FunctionId;
                    fun.FunctionName = item.FunctionName;
                    fun.FunctionType = item.FunctionType;
                    fun.Status = item.Status;
                    fun.ModuleCode = item.ModuleCode;

                    funcs.Funcs.Add(fun);
                }

                foreach (var con in componentTotal)
                {
                    if (con.ComponentCount.Equals(funcs.Funcs.Count()) && con.Component.Equals(item.Component))
                        flagComponent = true;
                }


                if (flagComponent)
                {
                    foreach (var con in componentTotal)
                    {
                        if (funcs.Funcs.Count().Equals(1))
                            flagComponentTotal = true;

                        if (item.Component == con.Component && funcs.Funcs.Count().Equals(con.ComponentCount))
                            flagComponentTotal = true;

                        if (flagComponentTotal)
                        {
                            funcsList.Add(funcs);
                            funcs = new FuncRoleServiceModelList();
                            funcs.Funcs = new List<FunctionServiceModel>();
                            flagComponentTotal = false;
                        }
                    }
                }
                temp = item.Component;

            }

            model.FuncModels = funcsList;

            model.RoleModels = Mapper.Map<IQueryable<Role>, IEnumerable<RoleServiceModel>>(roleMaster);

            return model;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
