using AutoMapper;
using Common.Dtos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Mappers
{
    public class ViewModelProfiles : Profile
    {
        public ViewModelProfiles() 
        {
            CreateMap<JournalModel, JournalDto>().ReverseMap();
        }
    }
}
