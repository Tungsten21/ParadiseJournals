using AutoMapper;
using Common.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappers
{
    public class RepositoryProfiles : Profile
    {
        public RepositoryProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
