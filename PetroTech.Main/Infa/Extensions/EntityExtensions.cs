using PetroTech.Main.Models;
using PetroTech.Model.Models;
using PetroTech.Service.Models;
using System;
using System.Linq;

namespace PetroTech.Main.Infa.Extensions
{
    public static class EntityExtensions
    {
        public static void MapDataUser(this UserServiceModel userServiceModel, UserViewModel userViewModel)
        {
            userServiceModel.UserName = userViewModel.UserName;
            userServiceModel.FullName = userViewModel.FullName;
            userServiceModel.Email = userViewModel.Email;
            userServiceModel.PhoneNumber = userViewModel.PhoneNumber;
            userServiceModel.Address = userViewModel.Address;
            userServiceModel.City = userViewModel.City;
            userServiceModel.Area = userViewModel.Area;
            userServiceModel.Status = userViewModel.Status;
            userServiceModel.RoleName = userViewModel.RoleName;
            userServiceModel.DOB = userViewModel.DOB;
            userServiceModel.Department = userViewModel.Department;
            userServiceModel.RoleId = userViewModel.RoleId;

            userServiceModel.Functions = userViewModel.Functions.Select(x => new FunctionServiceModel
            {
                Controller = x.Controller,
                FunctionId = x.FunctionId,
                FunctionName = x.FunctionName,
                FunctionType = x.FunctionType,
                ModuleCode = x.ModuleCode,
                Status = x.Status
            });
        }

        public static void MappingServiceToDataModelOfUser(this User user, UserServiceModel userServiceModel)
        {
            user.UserName = userServiceModel.UserName;
            user.FullName = userServiceModel.FullName;
            user.Email = userServiceModel.Email;
            user.PhoneNumber = userServiceModel.PhoneNumber;
            user.Address = userServiceModel.Address;
            user.City = userServiceModel.City;
            user.Area = userServiceModel.Area;
            user.Status = userServiceModel.Status;
            user.DOB = userServiceModel.DOB;
            user.Department = userServiceModel.Department;
        }

        public static void MappingDataRole(this RoleServiceModel roleServiceModel, RoleViewModel roleViewModel)
        {
            roleServiceModel.RoleId = roleViewModel.RoleId;
            roleServiceModel.RoleName = roleViewModel.RoleName;
            roleServiceModel.RoleCode = roleViewModel.RoleCode;
        }
    }
}