using AutoMapper;
using PetroTech.Main.Models;
using PetroTech.Model.Models;
using PetroTech.Service.Models;

namespace PetroTech.Main.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserServiceModel, UserViewModel>();
                cfg.CreateMap<User, UserServiceModel>();
            });
        }
    }
}