using AutoMapper;
using PetroTech.Common.Resource;
using PetroTech.Data.Infa;
using PetroTech.Data.Repo;
using PetroTech.Model.Models;
using PetroTech.Service.Infa;
using PetroTech.Service.Models;
using PetroTech.Service.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PetroTech.Service.Infa.Extensions;

namespace PetroTech.Service.Manager
{
    public interface IRoleService
    {
        IEnumerable<RoleServiceModel> GetListRoles();
        PaginationSet<RoleServiceModel> GetAllRolePaging(string keyword, int page, int pageSize, string rolenameVal);
        ResultAPI<bool> DeleteRole(string id);
        ResultAPI<bool> DeleteRoleMulti(List<string> ids);
        ResultAPI<string> ValidationRoleCode(string roleCode);
        List<ErrorServiceModel> AddNewRole(RoleServiceModel model, bool isUpdate);
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

        public PaginationSet<RoleServiceModel> GetAllRolePaging(string keyword, int page, int pageSize, string rolenameVal)
        {
            int totalRow = 0;

            var mess = string.Empty;

            //user master take by pagesize
            var roles = from r in _roleRepository.Table
                        select r;

            if (!string.IsNullOrEmpty(rolenameVal))
            {
                roles = from u in roles
                        where u.RoleName.Contains(rolenameVal)
                        select u;
            }

            var query = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleServiceModel>>(roles);


            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();

                query = from role in query
                        where
                        role.RoleName.ToLower().Contains(keyword) ||
                        role.RoleCode.ToLower().Contains(keyword)
                        select role;
            }

            if (query.Count() == 0 || query == null)
            {
                mess = (Helper.Enum.Notification.STR_DATA_NOT_FOUND).GetDescription();
            }

            totalRow = query.Count() == 0 ? 0 : query.Count();

            query = (query.OrderByDescending(x => x.RoleCode).Skip(page * pageSize).Take(pageSize));

            var paginationSet = new PaginationSet<RoleServiceModel>
            {
                Items = query,
                Page = page,
                TotalCount = totalRow,
                TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize),
                Mess = mess
            };

            return paginationSet;
        }

        public ResultAPI<bool> DeleteRole(string id)
        {
            var rs = new ResultAPI<bool>();
            rs.Mess = (Helper.Enum.Notification.STR_DELETE_ROLE_FAILD).GetDescription();
            rs.IsProcess = false;

            if (!string.IsNullOrEmpty(id))
            {
                rs.IsProcess = true;
                rs.Mess = (Helper.Enum.Notification.STR_DELETE_ROLE_SUCCESS).GetDescription();
                _roleRepository.DeleteMulti(x => x.RoleCode.Contains(id));
            }

            Save();
            return rs;
        }

        public ResultAPI<bool> DeleteRoleMulti(List<string> ids)
        {
            var rs = new ResultAPI<bool>();
            rs.Mess = (Helper.Enum.Notification.STR_DELETE_ROLE_FAILD).GetDescription();
            rs.IsProcess = false;

            if (ids.Count() > 0 && ids != null)
            {
                foreach (var id in ids)
                {
                    _roleRepository.DeleteMulti(x => x.RoleCode.Contains(id));
                }
                rs.IsProcess = true;
                rs.Mess = (Helper.Enum.Notification.STR_DELETE_ROLE_SUCCESS).GetDescription();
            }

            Save();
            return rs;
        }

        public ResultAPI<string> ValidationRoleCode(string roleCode)
        {
            var result = new ResultAPI<string>();

            roleCode = roleCode.Trim();

            //Validation for data
            if (roleCode == "undefined" || string.IsNullOrEmpty(roleCode))
            {
                result.Mess = string.Empty;
                result.Data = "none";
                result.Class = "validate-mess-red";
                return result;
            }

            if (roleCode.Length < 3)
            {
                result.IsProcess = false;
                result.Mess = (Helper.Enum.ValidationError.STR_ROLECODE_LENGTH).GetDescription();
                result.Data = "block";
                result.Class = "validate-mess-red";
                return result;
            }

            var query = from u in _roleRepository.Table
                        where u.RoleCode == roleCode
                        select u;

            if (query.Count() > 0 && query != null)
            {
                result.IsProcess = false;
                result.Mess = (Helper.Enum.ValidationError.STR_ROLECODE_CANNOTUSE).GetDescription();
                result.Data = "block";
                result.Class = "validate-mess-red";
                return result;
            }

            result.IsProcess = true;
            result.Mess = (Helper.Enum.ValidationError.STR_ROLECODE_CANUSE).GetDescription();
            result.Data = "block";
            result.Class = "validate-mess-green";
            return result;
        }

        public List<ErrorServiceModel> AddNewRole(RoleServiceModel model, bool isUpdate)
        {
            var listErrors = new List<ErrorServiceModel>();
            var error = new ErrorServiceModel();

            #region Fileds
            var regexItem = new Regex(@"[~`!@#$%^&*()-+=|\{}':;.,<>/?]");

            var flagRoleName = true;
            var filedRoleName = (Helper.Constant.ConstantFiled.CONST_ROLENAME).GetDescription();

            var flagRoleCode = true;
            var filedRoleCode = (Helper.Constant.ConstantFiled.CONST_ROLECODE).GetDescription();
            #endregion

            #region Validation Role Code
            if (!isUpdate)
            {
                if (string.IsNullOrEmpty(model.RoleCode) && model.RoleCode.Length < 3)
                {
                    error.Filed = filedRoleCode;
                    error.ErrorMess = (Helper.Enum.ValidationError.STR_ROLECODE_LENGTH).GetDescription();
                    listErrors.Add(error);
                    error = new ErrorServiceModel();
                    flagRoleCode = false;
                }

                if (flagRoleCode)
                {
                    var resultValidate = ValidationRoleCode(model.RoleCode);

                    if (resultValidate.IsProcess == false)
                    {
                        error.Filed = filedRoleCode;
                        error.ErrorMess = resultValidate.Mess;
                        listErrors.Add(error);
                        error = new ErrorServiceModel();
                        flagRoleCode = false;
                    }

                    if (regexItem.IsMatch(model.RoleCode))
                    {
                        error.Filed = filedRoleCode;
                        error.ErrorMess = (Helper.Enum.ValidationError.STR_SPECIALCHAR).GetDescription();
                        listErrors.Add(error);
                        error = new ErrorServiceModel();
                        flagRoleCode = false;
                    }
                }
            }
            #endregion

            #region Validation Role Name
            if (regexItem.IsMatch(model.RoleName))
            {
                error.Filed = filedRoleName;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SPECIALCHAR).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagRoleName = false;
            }
            #endregion

            //Add to Role table
            if (flagRoleCode && flagRoleName)
            {
                var role = new Role();
                role.MappingServiceToDataModelOfRole(model);

                if (isUpdate)
                {
                    _roleRepository.Update(role);
                }
                else
                {
                    _roleRepository.Add(role);
                }
            }

            Save();
            return listErrors;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
