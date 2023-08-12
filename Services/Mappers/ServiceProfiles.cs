using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Models;

namespace Services.Mappers
{
    public class ServiceProfiles : Profile
    {
        public ServiceProfiles() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
        }
    }
}
