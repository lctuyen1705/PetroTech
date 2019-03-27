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

namespace PetroTech.Service.Manager
{
    public interface IUserService
    {
        PaginationSet<UserServiceModel> GetAllUserPaging(string keyword, int page, int pageSize);
        List<ErrorServiceModel> AddNewUser(UserServiceModel modelService);
        ResultAPI<string> ValidationUser(string userName);
        void Save();
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,
                           IRoleRepository roleRepository,
                           IUserRoleRepository userRoleRepository,
                           IUnitOfWork unitOfWork)
        {
            this._userRoleRepository = userRoleRepository;
            this._roleRepository = roleRepository;
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public PaginationSet<UserServiceModel> GetAllUserPaging(string keyword, int page, int pageSize)
        {
            int totalRow = 0;

            var mess = string.Empty;

            //user master take by pagesize
            var users = _userRepository.GetAll();

            var query = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserServiceModel>>(users);

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
                         IsSystemAccount = m.IsSystemAccount,
                         AccessFailedCount = m.AccessFailedCount,
                         Email = m.Email,
                         LockoutEnabled = m.LockoutEnabled,
                         LockoutEndDateUtc = m.LockoutEndDateUtc,
                         PhoneNumber = m.PhoneNumber,
                         PhoneNumberConfirmed = m.PhoneNumberConfirmed,
                         UserId = m.UserId
                     }).AsEnumerable();


            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();

                query = from user in query
                        where
                        user.FullName.ToLower().Contains(keyword) ||
                        user.Area.ToLower().Contains(keyword)
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

        public List<ErrorServiceModel> AddNewUser(UserServiceModel model)
        {
            var listErrors = new List<ErrorServiceModel>();
            var error = new ErrorServiceModel();
            var regexItem = new Regex(@"[~`!@#$%^&*()-+=|\{}':;.,<>/?]");
            var regexItemDomainEmail = new Regex(@"psd.com.vn");

            #region Fileds
            var flagUserName = true;
            var filedUserName = (Helper.Constant.ConstantFiled.CONST_USERNAME).GetDescription();
            var flagFullName = true;
            var filedFullName = (Helper.Constant.ConstantFiled.CONST_FULLNAME).GetDescription();
            var flagEmail = true;
            var filedEmail = (Helper.Constant.ConstantFiled.CONST_EMAIL).GetDescription();
            #endregion

            #region Validation UserName
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
                var resultValidate = ValidationUser(model.UserName);

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
                    error.ErrorMess = (Helper.Enum.ValidationError.STR_USERNAME_SPECIALCHAR).GetDescription();
                    listErrors.Add(error);
                    error = new ErrorServiceModel();
                    flagUserName = false;
                }
            }
            #endregion

            #region Validation FullName
            if (regexItem.IsMatch(model.FullName))
            {
                error.Filed = filedFullName;
                error.ErrorMess = (Helper.Enum.ValidationError.STR_FULLNAME_SPECIALCHAR).GetDescription();
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

            if (flagUserName && flagFullName && flagEmail)
            {
                var data = Mapper.Map<UserServiceModel, ApplicationUser>(model);
                //_userRepository.Add(data);
            }


            //Add to Role Table

            //Add to UserRole Table

            //Add to Permission Table

            return listErrors;
        }

        public ResultAPI<string> ValidationUser(string userName)
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
                        where u.UserCode == userName
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

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}