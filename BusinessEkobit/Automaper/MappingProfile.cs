using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessEkobit.Models;
using DataEkobit.Entities;

namespace BusinessEkobit.Automaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
                .ForMember(d=>d.Password, s=>s.DoNotUseDestinationValue())
                .ForMember(d=>d.ZipCode, s=>s.DoNotUseDestinationValue())
                .ForMember(d =>d.Password, s => s.DoNotUseDestinationValue())
                .ForMember(d => d.Nickname, s => s.DoNotUseDestinationValue())
                .ForMember(d => d.CountryId, s => s.DoNotUseDestinationValue());
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>().ForMember(d => d.CountryCode, s => s.DoNotUseDestinationValue());
        }
    }
}
