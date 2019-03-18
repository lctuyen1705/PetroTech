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


namespace PetroTech.Service.Manager
{
    public interface IUserService
    {
        PaginationSet<UserServiceModel> GetAllUserPaging(string keyword, int page, int pageSize);
        bool AddNewUser(ApplicationUser model, UserServiceModel modelService);
        bool ValidationUser(string userName);
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

        public bool AddNewUser(ApplicationUser model, UserServiceModel modelService)
        {
            //Add to User Table
            _userRepository.Add(model);


            //Add to Role Table

            //Add to UserRole Table

            //Add to Permission Table

            return true;
        }

        public bool ValidationUser(string userName)
        {
            //Validation for data
            var query = from u in _userRepository.Table
                        where u.UserCode == userName
                        select u;

            if (query.Count() > 0 && query != null)
                return true;

            return false;

        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}