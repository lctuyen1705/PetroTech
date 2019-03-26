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
            user.UserId = userViewModel.UserId;
            user.UserName = userViewModel.UserName;
            user.FullName = userViewModel.FullName;
            user.Email = userViewModel.Email;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.Address = userViewModel.Address;
            user.City = userViewModel.City;
            user.Area = userViewModel.Area;
            user.Status = userViewModel.Status;
            user.IsSystemAccount = userViewModel.IsSystemAccount;
            user.LockoutEnabled = userViewModel.LockoutEnabled;
            user.LockoutEndDateUtc = userViewModel.LockoutEndDateUtc;
            user.RoleName = userViewModel.RoleName;
            user.PhoneNumberConfirmed = userViewModel.PhoneNumberConfirmed;
            user.DOB = userViewModel.DOB;

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

        public static void MappingServiceToDataModelOfUser(this ApplicationUser user, UserServiceModel userServiceModel)
        {
            user.Id = Guid.NewGuid().ToString();
            user.UserCode = userServiceModel.UserCode;
            user.UserName = userServiceModel.UserName;
            user.FullName = userServiceModel.FullName;
            user.Email = userServiceModel.Email;
            user.PhoneNumber = userServiceModel.PhoneNumber;
            user.Address = userServiceModel.Address;
            user.City = userServiceModel.City;
            user.Area = userServiceModel.Area;
            user.Status = userServiceModel.Status;
            user.IsSystemAccount = userServiceModel.IsSystemAccount;
            user.LockoutEnabled = userServiceModel.LockoutEnabled;
            user.LockoutEndDateUtc = userServiceModel.LockoutEndDateUtc;
            user.PhoneNumberConfirmed = userServiceModel.PhoneNumberConfirmed;
            user.DOB = userServiceModel.DOB;
        }
    }
}