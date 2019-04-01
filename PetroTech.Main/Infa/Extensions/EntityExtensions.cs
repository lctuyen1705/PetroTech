using PetroTech.Main.Models;
using PetroTech.Model.Models;
using PetroTech.Service.Models;
using System;
using System.Linq;

namespace PetroTech.Main.Infa.Extensions
{
    public static class EntityExtensions
    {
        public static void MapDataUser(this UserServiceModel user, UserViewModel userViewModel)
        {
            user.UserName = userViewModel.UserName;
            user.FullName = userViewModel.FullName;
            user.Email = userViewModel.Email;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.Address = userViewModel.Address;
            user.City = userViewModel.City;
            user.Area = userViewModel.Area;
            user.Status = userViewModel.Status;
            user.RoleName = userViewModel.RoleName;
            user.DOB = userViewModel.DOB;
            user.Department = userViewModel.Department;
            user.RoleId = userViewModel.RoleId;

            user.Functions = userViewModel.Functions.Select(x => new FunctionServiceModel
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
    }
}