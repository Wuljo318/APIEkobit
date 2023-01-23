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
    public class MappingProfile 
    {

        public UserDTO MappingUserUserDTO(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var userDTO = mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public User MappingUserDTOUser(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userDTO);

            return user;
        }
    }
}
