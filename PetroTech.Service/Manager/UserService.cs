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
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using PetroTech.Service.Models.result;
using PetroTech.Service.Infa.Extensions;

namespace PetroTech.Service.Manager
{
    public interface IUserService
    {
        PaginationSet<UserServiceModel> GetAllUserPaging(string keyword, int page, int pageSize, string usernameVal, string areaVal, string departmentVal, string statusVal);
        List<ErrorServiceModel> ValidationUser(UserServiceModel modelService, bool isUpdate);
        ResultAPI<string> ValidationUserName(string userName);
        UserServiceModel GetByUser(string userName);
        void Save();
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IPermissionRepository _permissionRepository;
        private IFunctionRepository _functionRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,
                           IRoleRepository roleRepository,
                           IUserRoleRepository userRoleRepository,
                           IPermissionRepository permissionRepository,
                           IFunctionRepository functionRepository,
                           IUnitOfWork unitOfWork)
        {
            this._userRoleRepository = userRoleRepository;
            this._roleRepository = roleRepository;
            this._userRepository = userRepository;
            this._permissionRepository = permissionRepository;
            this._functionRepository = functionRepository;
            this._unitOfWork = unitOfWork;
        }

        public PaginationSet<UserServiceModel> GetAllUserPaging(string keyword, int page, int pageSize, string usernameVal, string areaVal, string departmentVal, string statusVal)
        {
            int totalRow = 0;

            var mess = string.Empty;

            //user master take by pagesize
            var users = from u in _userRepository.Table
                        select u;

            if (!string.IsNullOrEmpty(usernameVal))
            {
                users = from u in users
                        where u.UserName.Contains(usernameVal)
                        select u;
            }
            if (!string.IsNullOrEmpty(areaVal))
            {
                users = from u in users
                        where u.Area == areaVal
                        select u;
            }
            if (!string.IsNullOrEmpty(departmentVal))
            {
                users = from u in users
                        where u.Department == departmentVal
                        select u;
            }
            if (!string.IsNullOrEmpty(statusVal))
            {
                users = from u in users
                        where u.Status == statusVal
                        select u;
            }

            var query = Mapper.Map<IEnumerable<User>, IEnumerable<UserServiceModel>>(users);

            //master
            query = (from m in query
                     join ur in _userRoleRepository.Table
                         on m.UserName equals ur.UserName
                     join r in _roleRepository.Table
                     on ur.RoleId equals r.RoleId
                     select new UserServiceModel()
                     {
                         Address = m.Address,
                         UserName = m.UserName,
                         Status = m.Status,
                         RoleName = r.RoleName,
                         Area = m.Area,
                         City = m.City,
                         DOB = m.DOB,
                         FullName = m.FullName,
                         Email = m.Email,
                         PhoneNumber = m.PhoneNumber,
                         Department = m.Department
                     }).AsEnumerable();


            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();

                query = from user in query
                        where
                        user.Area.ToLower().Contains(keyword) ||
                        user.UserName.ToLower().Contains(keyword)
                        select user;
            }

            if (query.Count() == 0 || query == null)
            {
                mess = (Helper.Enum.Notification.STR_DATA_NOT_FOUND).GetDescription();
            }

            totalRow = query.Count() == 0 ? 0 : query.Count();

            query = (query.OrderByDescending(x => x.FullName).Skip(page * pageSize).Take(pageSize));

            var paginationSet = new PaginationSet<UserServiceModel>
            {
                Items = query,
                Page = page,
                TotalCount = totalRow,
                TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize),
                Mess = mess
            };

            return paginationSet;
        }

        public List<ErrorServiceModel> ValidationUser(UserServiceModel model, bool isUpdate)
        {
            var listErrors = new List<ErrorServiceModel>();
            var error = new ErrorServiceModel();

            #region Fileds
            var regexItem = new Regex(@"[~`!@#$%^&*()-+=|\{}':;.,<>/?]");
            var regexItemAddress = new Regex(@"[~`!@#$%^&*()-+=|\{}':;.,<>?]");
            var regexItemDomainEmail = new Regex(@"bbpetro.com.vn");
            var regexItemPhone = new Regex(@"^[0-9]+$");

            var flagUserName = true;
            var filedUserName = (Helper.Constant.ConstantFiled.CONST_USERNAME).GetDescription();

            var flagFullName = true;
            var filedFullName = (Helper.Constant.ConstantFiled.CONST_FULLNAME).GetDescription();

            var flagEmail = true;
            var filedEmail = (Helper.Constant.ConstantFiled.CONST_EMAIL).GetDescription();

            var flagPhoneNumber = true;
            var filedPhoneNumber = (Helper.Constant.ConstantFiled.CONST_PHONE).GetDescription();

            var flagAddress = true;
            var filedAddress = (Helper.Constant.ConstantFiled.CONST_ADDRESS).GetDescription();

            var flagCity = true;
            var filedCity = (Helper.Constant.ConstantFiled.CONST_CITY).GetDescription();

            var flagArea = true;
            var filedArea = (Helper.Constant.ConstantFiled.CONST_AREA).GetDescription();

            var flagStatus = true;
            var filedStatus = (Helper.Constant.ConstantFiled.CONST_STATUS).GetDescription();

            var flagDepartment = true;
            var filedDepartment = (Helper.Constant.ConstantFiled.CONST_DEPARTMENT).GetDescription();

            var flagRole = true;
            var filedRole = (Helper.Constant.ConstantFiled.CONST_ROLE).GetDescription();

            #endregion

            #region Validation UserName
            if (!isUpdate)
            {
                if (string.IsNullOrEmpty(model.UserName) && model.UserName.Length < 6)
                {
                    error.Filed = filedUserName;
                    error.ErrorMess = (Helper.Enum.ValidationError.STR_USERNAME_LENGTH).GetDescription();
                    listErrors.Add(error);
                    error = new ErrorServiceModel();
                    flagUserName = false;
                }

                if (flagUserName)
                {
                    var resultValidate = ValidationUserName(model.UserName);

                    if (resultValidate.IsProcess == false)
                    {
                        error.Filed = filedUserName;
                        error.ErrorMess = resultValidate.Mess;
                        listErrors.Add(error);
                        error = new ErrorServiceModel();
                        flagUserName = false;
                    }

                    if (regexItem.IsMatch(model.UserName))
                    {
                        error.Filed = filedUserName;
                        error.ErrorMess = (Helper.Enum.ValidationError.STR_SPECIALCHAR).GetDescription();
                        listErrors.Add(error);
                        error = new ErrorServiceModel();
                        flagUserName = false;
                    }
                }
            }
            #endregion

            #region Validation FullName
            if (regexItem.IsMatch(model.FullName))
            {
                error.Filed = filedFullName;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SPECIALCHAR).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagFullName = false;
            }
            #endregion

            #region Validation Email
            if (string.IsNullOrEmpty(model.Email))
            {
                error.Filed = filedEmail;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_EMAIL_FORMAT).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagEmail = false;
            }
            if (flagEmail)
            {
                var domain = model.Email.Split('@')[1];
                if (!regexItemDomainEmail.IsMatch(domain))
                {
                    error.Filed = filedEmail;
                    error.ErrorMess = (Helper.Enum.ValidationError.STR_EMAIL_FORMAT).GetDescription();
                    listErrors.Add(error);
                    error = new ErrorServiceModel();
                    flagEmail = false;
                }
            }
            #endregion

            #region Validation PhoneNumber
            if (!regexItemPhone.IsMatch(model.PhoneNumber))
            {
                error.Filed = filedPhoneNumber;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_PHONE_FORMAT).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagPhoneNumber = false;
            }
            #endregion

            #region Validation Address
            if (regexItemAddress.IsMatch(model.Address))
            {
                error.Filed = filedAddress;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SPECIALCHAR).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagAddress = false;
            }
            #endregion

            #region Validation City
            if (regexItem.IsMatch(model.City))
            {
                error.Filed = filedCity;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SPECIALCHAR).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagCity = false;
            }
            #endregion

            #region Validation Area
            if (string.IsNullOrEmpty(model.Area))
            {
                error.Filed = filedArea;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SELECT).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagArea = false;
            }
            #endregion

            #region Validation Status
            if (string.IsNullOrEmpty(model.Status))
            {
                error.Filed = filedStatus;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SELECT).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagStatus = false;
            }
            #endregion

            #region Validation Department
            if (string.IsNullOrEmpty(model.Department))
            {
                error.Filed = filedDepartment;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SELECT).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagDepartment = false;
            }
            #endregion

            #region Validation Role
            if (string.IsNullOrEmpty(model.RoleId))
            {
                error.Filed = filedRole;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_SELECT).GetDescription();
                listErrors.Add(error);
                error = new ErrorServiceModel();
                flagRole = false;
            }
            #endregion

            //Add to User Table
            if (flagUserName && flagFullName &&
                flagEmail &&
                flagPhoneNumber &&
                flagAddress &&
                flagCity &&
                flagArea &&
                flagStatus &&
                flagDepartment &&
                flagRole)
            {

                var user = new User();
                user.MappingServiceToDataModelOfUser(model);

                if (isUpdate)
                {
                    _userRepository.Update(user);
                }
                else
                {
                    _userRepository.Add(user);
                }
            }

            //Add to UserRole Table
            if (flagRole)
            {
                var userRole = new UserRole();
                userRole.MappingServiceToDataModelOfUseRole(model);

                if (isUpdate)
                {
                    _userRoleRepository.Update(userRole);
                }
                else
                {
                    _userRoleRepository.Add(userRole);
                }
            }

            //Add to Permission Table
            if (model.Functions.Count() > 0 && model.Functions != null)
            {
                foreach (var func in model.Functions)
                {
                    var permissiion = new Permission();
                    permissiion.FunctionId = func.FunctionId;
                    permissiion.UserName = model.UserName;
                    permissiion.IsPermisstion = true;
                    permissiion.CreatedBy = "System";
                    permissiion.CreateDateTime = DateTime.Now;
                    permissiion.LastUpdatedBy = "System";
                    permissiion.LastUpdatedDateTime = DateTime.Now;

                    if (isUpdate)
                    {
                        var infoUser = GetByUser(model.UserName);

                        if (model.UserName == infoUser.UserName)
                        {
                            if (infoUser.Functions.Count() > model.Functions.Count())
                            {
                                foreach (var f in infoUser.Functions)
                                {
                                    if (model.Functions.Where(x => x.FunctionId == f.FunctionId).Count() <= 0)
                                    {
                                        _permissionRepository.DeleteMulti(x => x.FunctionId == f.FunctionId &&
                                                                               x.UserName == model.UserName);
                                    }
                                    else
                                    {
                                        _permissionRepository.Update(permissiion);
                                    }
                                }
                            }
                            else
                            {
                                if (infoUser.Functions.Where(x => x.FunctionId == func.FunctionId).Count() > 0)
                                {
                                    _permissionRepository.Update(permissiion);
                                }
                                else
                                {
                                    _permissionRepository.Add(permissiion);
                                }
                            }

                        }
                    }
                    else
                    {
                        _permissionRepository.Add(permissiion);
                    }
                }
            }
            else
            {
                if (isUpdate)
                {
                    _permissionRepository.DeleteMulti(x => x.UserName == model.UserName);
                }
            }

            Save();
            return listErrors;
        }

        public ResultAPI<string> ValidationUserName(string userName)
        {
            var result = new ResultAPI<string>();

            userName = userName.Trim();

            //Validation for data
            if (userName == "undefined" || string.IsNullOrEmpty(userName))
            {
                result.Mess = string.Empty;
                result.Data = "none";
                result.Class = "validate-mess-red";
                return result;
            }

            if (userName.Length < 6)
            {
                result.IsProcess = false;
                result.Mess = (Helper.Enum.ValidationError.STR_USERNAME_LENGTH).GetDescription();
                result.Data = "block";
                result.Class = "validate-mess-red";
                return result;
            }

            var query = from u in _userRepository.Table
                        where u.UserName == userName
                        select u;

            if (query.Count() > 0 && query != null)
            {
                result.IsProcess = false;
                result.Mess = (Helper.Enum.ValidationError.STR_USERNAME_CANNOTUSE).GetDescription();
                result.Data = "block";
                result.Class = "validate-mess-red";
                return result;
            }

            result.IsProcess = true;
            result.Mess = (Helper.Enum.ValidationError.STR_USERNAME_CANUSE).GetDescription();
            result.Data = "block";
            result.Class = "validate-mess-green";
            return result;
        }

        public UserServiceModel GetByUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            var listFunctions = from u in _userRepository.Table
                                join p in _permissionRepository.Table
                                    on u.UserName equals p.UserName
                                join f in _functionRepository.Table
                                    on p.FunctionId equals f.FunctionId
                                where u.UserName == userName
                                select f;

            var query = (from u in _userRepository.Table
                         join ur in _userRoleRepository.Table
                             on u.UserName equals ur.UserName
                         join r in _roleRepository.Table
                             on ur.RoleId equals r.RoleId
                         where u.UserName == userName
                         select new UserServiceModel()
                         {
                             Address = u.Address,
                             UserName = u.UserName,
                             Status = u.Status,
                             RoleName = r.RoleName,
                             Area = u.Area,
                             City = u.City,
                             DOB = u.DOB,
                             FullName = u.FullName,
                             Email = u.Email,
                             PhoneNumber = u.PhoneNumber,
                             Department = u.Department,
                             RoleId = r.RoleId.ToString(),
                             Functions = listFunctions.Select(x => new FunctionServiceModel()
                             {
                                 FunctionId = x.FunctionId,
                                 Controller = x.Controller,
                                 FunctionName = x.FunctionName,
                                 FunctionType = x.FunctionType,
                                 ModuleCode = x.ModuleCode,
                                 Status = x.Status
                             })
                         }).FirstOrDefault();

            return query;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}