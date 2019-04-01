using PetroTech.Model.Models;
using PetroTech.Service.Models;
using System;
using System.Linq;

namespace PetroTech.Service.Infa.Extensions
{
    public static class EntityExtensions
    {
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
            user.CreatedBy = "System";
            user.CreateDateTime = DateTime.Now;
            user.LastUpdatedBy = "System";
            user.LastUpdatedDateTime = DateTime.Now;
        }

        public static void MappingDataToServiceModelOfUser(this UserServiceModel userServiceModel, User use)
        {
            userServiceModel.UserName = use.UserName;
            userServiceModel.FullName = use.FullName;
            userServiceModel.Email = use.Email;
            userServiceModel.PhoneNumber = use.PhoneNumber;
            userServiceModel.Address = use.Address;
            userServiceModel.City = use.City;
            userServiceModel.Area = use.Area;
            userServiceModel.Status = use.Status;
            userServiceModel.DOB = use.DOB;
            userServiceModel.Department = use.Department;
        }

        public static void MappingServiceToDataModelOfUseRole(this UserRole userRole, UserServiceModel userServiceModel)
        {
            userRole.UserName = userServiceModel.UserName;
            userRole.RoleId = Guid.Parse(userServiceModel.RoleId);
        }
    }
}