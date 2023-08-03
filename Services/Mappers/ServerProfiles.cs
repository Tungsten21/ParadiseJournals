using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Models;

namespace Services.Mappers
{
    public class ServerProfiles : Profile
    {
        public ServerProfiles() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
        }
    }
}
