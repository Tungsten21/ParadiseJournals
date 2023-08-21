using AutoMapper;
using Common.Dtos;
using Data.Entities;
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
            CreateMap<JournalModel, JournalDto>().ReverseMap().ForMember(x => x.Days, opt => opt.MapFrom(src => src.JournalDays));
            CreateMap<JournalDayModel, JournalDayDto>().ReverseMap();
            CreateMap<WishListModel, WishlistDto>().ReverseMap();
        }
    }
}
