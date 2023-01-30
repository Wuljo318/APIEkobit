using AutoMapper;
using BusinessEkobit.Exceptions;
using BusinessEkobit.Interfaces;
using BusinessEkobit.Models;
using DataEkobit.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIEkobit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ICountryService countryService)
        {
            _userService = userService;
            _mapper = mapper;
            _countryService = countryService;
        }

        [HttpGet("getall")]
        public async Task<List<UserDTO>> GetAll()
        {
            List<User> users = await _userService.GetAll();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (User user in users)
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                usersDTO.Add(userDTO);
            }
            return usersDTO;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<UserDTO> GetById([FromRoute] long id)
        {
            try
            {
                var entity = await _userService.GetById(_ => _.UserId == id);
                entity.Country = await _countryService.GetById(_ => _.CountryId == entity.CountryId);
                UserDTO userDTO = _mapper.Map<UserDTO>(entity);
                return userDTO;
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(ex.Message, ex);
            }

        }

        [HttpPost("add")]
        public async Task Add([FromBody] UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            user.CountryId = userDTO.CountryDTO.CountryId;
            await _userService.Add(user);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] UserDTO userDTO)
        {
            long id = userDTO.UserId;
            var entity = await _userService.GetById(_ => _.UserId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong user");
            }
            else
            {
                entity = _mapper.Map<User>(userDTO);
                await _userService.Update(entity);
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task Delete([FromRoute] long id)
        {
            var entity = await _userService.GetById(_ => _.UserId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong user");
            }
            else
            {
                await _userService.Delete(entity);
            }

        }

    }
}
