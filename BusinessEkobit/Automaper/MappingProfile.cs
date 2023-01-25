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
            CreateMap<UserDTO, User>();
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
        }
    }
}
