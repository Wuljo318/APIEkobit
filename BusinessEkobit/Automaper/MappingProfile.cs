using AutoMapper;
using BusinessEkobit.Models;
using DataEkobit.Entities;

namespace BusinessEkobit.Automaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDTO>();

            CreateMap<CountryDTO, Country>()
                .ForMember(d => d.CountryCode, s => s.DoNotUseDestinationValue());

            CreateMap<User, UserDTO>()
                .ForMember(d => d.CountryDTO, s => s.MapFrom(src => src.Country));

            CreateMap<UserDTO, User>()
                .ForMember(d => d.Password, s => s.DoNotUseDestinationValue())
                .ForMember(d => d.ZipCode, s => s.DoNotUseDestinationValue())
                .ForMember(d => d.Password, s => s.DoNotUseDestinationValue())
                .ForMember(d => d.Nickname, s => s.DoNotUseDestinationValue())
                .ForMember(d => d.CountryId, s => s.DoNotUseDestinationValue());

            CreateMap<Group, GroupDTO>();
            //.ForMember(d => d.UserGroups, s => s.MapFrom(src => src.UserGroups.Where(_ => _.UserId == d.UserId)));  //kak bi formuliral querry da mi dohvati usera prema id-u?
            CreateMap<GroupDTO, Group>();


            CreateMap<UserGroup, UserGroupDTO>()
                .ForMember(d => d.UserDTO, s => s.MapFrom(src => src.User))
                .ForMember(d => d.GroupDTO, s => s.MapFrom(src => src.Group));

            CreateMap<UserGroupDTO, UserGroup>();
        }
    }
}
